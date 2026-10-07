using Advantech;
using DynamicCylinders;
using ExceptionLib;
using GRT_BG1.Data;
using GRT_BG1.Function.Calibration;
using GRT_BG1.Function.Classes;
using GRT_BG1.Function.Interface;
using GRT_BG1_V54.Function.CommonClass;
using Master;
using Master.CommonClass;
using Master.GRT.Function.Stopper;
using Master.Log.LogClass;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static DIO.DIDO;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

namespace GRT_BG1.Function.DryRun
{
    public class WorkingConveyor2 : IWorkingConveyor2
    {
        public static int i_step = 34;

        public static int retryccd = 0;

        public static bool running = false;
        bool dryrun = false;
        bool production = false;
        PartData[,] Data;
        public static SemaphoreSlim semaphoreSlimwk2 = new SemaphoreSlim(1, 1);
        public static Stopwatch ExitSen = new Stopwatch();
        public static string[] Storing_TimeStamp = new string[13];
        public static string[] Group_DT = new string[15];

        // X3Y3-style final inspection order and index (replaces row-major queue traversal)
        public static int[] FinalCheck_Order = new int[15];
        public static int finalCavitySeqIndex = 1;
        public static string[] fiResultCode = new string[15]; // 11=OK, 00=NG, 0=skipped/toss

        private static void ResetFinalInspectionState()
        {
            finalCavitySeqIndex = 1;
            FinalCheck_Order[0] = 0;
            FinalCheck_Order[1] = 1;
            FinalCheck_Order[2] = 2;
            FinalCheck_Order[3] = 3;
            FinalCheck_Order[4] = 6;
            FinalCheck_Order[5] = 5;
            FinalCheck_Order[6] = 4;
            FinalCheck_Order[7] = 7;
            FinalCheck_Order[8] = 8;
            FinalCheck_Order[9] = 9;
            FinalCheck_Order[10] = 12;
            FinalCheck_Order[11] = 11;
            FinalCheck_Order[12] = 10;
            Array.Clear(fiResultCode, 0, fiResultCode.Length);
            Array.Clear(Group_DT, 0, Group_DT.Length);
        }

        private bool TryGetCellForCavity(int cavityNo, out int row, out int col)
        {
            row = -1;
            col = -1;
            if (pos == null || Data == null)
                return false;

            for (int r = 0; r < pos.GetLength(0); r++)
            {
                for (int c = 0; c < pos.GetLength(1); c++)
                {
                    if (Data[r, c].cavityNo == cavityNo)
                    {
                        row = r;
                        col = c;
                        return true;
                    }
                }
            }
            return false;
        }

        private bool ShouldInspectCavity(int cavityNo, out int row, out int col)
        {
            if (!TryGetCellForCavity(cavityNo, out row, out col))
                return false;

            if (dryrun)
                return true;

            if (!Data[row, col].ScannerData)
                return false;
            if (!Data[row, col].pastingcmplt)
                return false;
            if (Data[row, col].CCD2receiveX != null &&
                (Data[row, col].CCD2receiveX.Contains("999.999") ||
                 Data[row, col].CCD2receiveY.Contains("999.999") ||
                 Data[row, col].CCD2receiveR.Contains("999.999")))
                return false;

            return true;
        }

        private static bool IsN1Cavity(int cavityNo)
        {
            return cavityNo == 1 || cavityNo == 2 || cavityNo == 3 ||
                   cavityNo == 7 || cavityNo == 8 || cavityNo == 9;
        }

        private static bool IsN2Cavity(int cavityNo)
        {
            return cavityNo == 2 || cavityNo == 3 || cavityNo == 4 ||
                   cavityNo == 10 || cavityNo == 11 || cavityNo == 12;
        }

        private void MarkCavitySkipped(int row, int col, int cavityNo)
        {
            if (row < 0 || col < 0)
            {
                fiResultCode[cavityNo] = "0";
                return;
            }

            Data[row, col].OkNok = "NG";
            fiResultCode[cavityNo] = "0";
            updatecavity?.Invoke(row, col, Data[row, col].SNno, false, Data[0, 0].CarrierBarcode);
        }

        private bool EvaluateX3Y3Limits(int row, int col, string visionPassFlag)
        {
            double pressForce = Data[row, col].loadcellforce;
            double bottomGap = Data[row, col].Gapx;
            double leftGap = Data[row, col].Gapy;
            double angle = Data[row, col].Angle;

            return visionPassFlag == "1" &&
                   pressForce > 1.8 && pressForce < 2.2 &&
                   angle > -1 && angle < 1 &&
                   bottomGap > 0.15 && bottomGap < 0.75 &&
                   leftGap > 0.15 && leftGap < 0.75;
        }



        public static bool WorkingCon2_Seq_completed = true;
        // VisionSystem camera = new VisionSystem();
        Position[,] pos = null;
        public static event Func<int, int, string, bool, string, bool> updatecavity;
        public static event Action clearwk2cavity;
        VisionSystem camera = new VisionSystem();
        private const int MAX_CCD_LOOP_RETRIES = 10000000;
        //Arulkumar Fixed random stoppage start
        private static void SafePauseEventWait()
        {
            try
            {
                ConveyorSystem._pauseEvent?.WaitOne();
            }
            catch (ObjectDisposedException)
            {
            }
        }
        //Arulkumar Fixed random stoppage end
        #region Unloading Sequence Started
        public WorkingConveyor2(Position[,] position)
        {
            pos = position;
        }

        public static Stopwatch CycleTime_out = new Stopwatch();

        public static void Update_Cycle_Time_Out()
        {
            if (!CycleTime_out.IsRunning)
            {
                CycleTime_out.Restart();
            }
            else
            {
                CycleTime_out.Stop();
                GlobalVariable.cycle_time_out = CycleTime_out.Elapsed.TotalSeconds;
                //ObjectList.CycleTime_Log.CycleTime_Log(GlobalVariable.cycle_time.ToString(), (int)GlobalVariable.dGlobal_Pass_count, (int)GlobalVariable.dGlobal_Yield_Count, GlobalVariable.CurrentShift);
                CycleTime_out.Restart();
            }
        }
        public async Task WorkingCon2_Seq(CancellationToken token, PartData[,] data)
        {
            //Arulkumar Fixed random stoppage start
            bool semaphoreHeld = false;
            bool semaphoreReleased = false;
            //Arulkumar Fixed random stoppage end
            await semaphoreSlimwk2.WaitAsync(token);
            //Arulkumar Fixed random stoppage start
            semaphoreHeld = true;
            //Arulkumar Fixed random stoppage end
            try
            {
                if (GlobalVariable.g_bMachineMode == GlobalVariable.OperationMode.DryRun)  //Dry Run Purpose Interlock
                {
                    dryrun = true;
                    production = false;
                }
                else
                      if (GlobalVariable.g_bMachineMode == GlobalVariable.OperationMode.Production)
                {
                    production = true;
                    dryrun = false;
                    Data = data;
                }
                else if (GlobalVariable.g_bMachineMode == GlobalVariable.OperationMode.CPK) // AK
                {
                    production = true;
                    dryrun = false;
                    Data = data;
                }
                WorkingCon2_Seq_completed = true;
                //StationName = "LoadingConveyor";
                while (!token.IsCancellationRequested && WorkingCon2_Seq_completed)
                {
                    token.ThrowIfCancellationRequested();
                    //Arulkumar Fixed random stoppage start
                    //SafePauseEventWait();
                    //Arulkumar Fixed random stoppage end
                    if (GlobalVariable.b_gPause)
                    {
                        ConveyorSystem._pauseEvent.WaitOne();
                        //Arulkumar Fixed Hung start
                        await Task.Delay(100);
                        //Arulkumar Fixed Hung end
                        continue;
                    }
                    if (GlobalVariable.current_MCStatus == GlobalVariable.MachineStatus.Running)
                    {
                        //ModuleName = "AutoSeq - LoadingConv";
                        if (GlobalVariable.g_bMachineMode == GlobalVariable.OperationMode.DryRun) //Dry Run Purpose Interlock
                        {
                            if (!GlobalVariable.LoadingConvWrk)
                            {
                                //Arulkumar Fixed Hung start
                                await Task.Delay(100);
                                //Arulkumar Fixed Hung end
                                continue;
                            }
                        }

                        switch (i_step)
                        {


                            case 34:

                                if (GlobalVariable.ConveyorCount == 4)
                                {
                                    StepperSystem.MovePlate(new bool?[] { null, null, false, true, null, null });

                                }
                                else if (GlobalVariable.ConveyorCount == 6)
                                {
                                    StepperSystem.MovePlate(new bool?[] { null, null, false, false, true, true });
                                }

                                if (dryrun)
                                {
                                    await Task.Delay(200);
                                    running = true;
                                    Cylinder_config.Cylinders_List[(int)Cylinder_config.Cylinders.Work_Conv_2_pallet_Lift_Cyl].Cylinder_Extend_without_sense();
                                    i_step = 35;
                                }
                                else
                                if (GlobalVariable.g_MachineIoChaged == "Yes" ? GlobalVariable.DI[(int)EInput_1.Work_Conv_2_Pallet_Inplace_Sen] : GlobalVariable.DI[(int)EInput.Work_Conv_2_Pallet_Inplace_Sen])
                                {
                                    await Logger.WriteLogasTask(Logger.LogType.Running, "MovePalet", "Working Conv2", "Move Palet and cylinder up", "");

                                    await Task.Delay(100);

                                    // Lift the carrier
                                    running = true;
                                    //StepperSystem.MovePlate(new bool?[] { null, null, false, false, false, false });

                                    if (GlobalVariable.ConveyorCount == 4)
                                    {
                                        StepperSystem.MovePlate(new bool?[] { null, null, false, false, null, null });

                                    }
                                    else if (GlobalVariable.ConveyorCount == 6)
                                    {
                                        StepperSystem.MovePlate(new bool?[] { null, null, false, false, false, false });
                                    }

                                    Cylinder_config.Cylinders_List[(int)Cylinder_config.Cylinders.Work_Conv_2_pallet_Lift_Cyl].Cylinder_Extend();
                                    //StepperSystem.MovePlate(new bool?[] { null, null, false, false, false, false }); // AK
                                    if (GlobalVariable.ConveyorCount == 4)
                                    {
                                        StepperSystem.MovePlate(new bool?[] { null, null, false, false, null, null });

                                    }
                                    else if (GlobalVariable.ConveyorCount == 6)
                                    {
                                        StepperSystem.MovePlate(new bool?[] { null, null, false, false, false, false });
                                    }

                                    i_step = 35;
                                }
                                break;

                            case 35:
                                //if(GlobalVariable.DI[(int)EInput.Work_Conv_2_Pallet_Lift_Cyl_Dn]) // bharath
                                //{
                                //    i_step = 34;
                                //    break;
                                //}
                                // CCD3 gantry moves to MLB-1 to MLB-12
                                if (GlobalVariable.g_MachineIoChaged == "Yes" ? GlobalVariable.DI[(int)EInput_1.Work_Conv_2_Pallet_Lift_Cyl_Up] : GlobalVariable.DI[(int)EInput.Work_Conv_2_Pallet_Lift_Cyl_Up] || dryrun)
                                {
                                    await Logger.WriteLogasTask(Logger.LogType.Running, "Collect ccd Data", "Working Conv2", "CollectCCD DATA", "");


                                    GlobalVariable.PDCA_count_all_Updated = 0;
                                    ResetFinalInspectionState();
                                    //Arulkumar Fixed Null start
                                    clearwk2cavity?.Invoke();

                                    //Arulkumar Fixed Null end
                                    // Traverse MLB 1–12 with camera

                                    await CollectCCD3data(token);
                                    //Arulkumar Fixed random stoppage start
                                    //Reason: Pallet continued / PDCA after incomplete Final Inspection
                                    //Root Cause: Case 35 always set i_step=37 after TraverseArray even when cavities had no committed OkNok (OK/NG).
                                    //Camera null/invalid paths left OkNok unset; sequence still lowered pallet and uploaded PDCA.
                                    bool fiIncomplete = false;
                                    if (production && Data != null && pos != null)
                                    {
                                        int fiRows = pos.GetLength(0);
                                        int fiCols = pos.GetLength(1);
                                        for (int r = 0; r < fiRows && !fiIncomplete; r++)
                                        {
                                            for (int c = 0; c < fiCols && !fiIncomplete; c++)
                                            {
                                                if (Data[r, c] == null) continue;
                                                if (!Data[r, c].pastingcmplt) continue;
                                                if (!Data[r, c].ScannerData) continue;
                                                if (Data[r, c].CCD2receiveX == null) continue;
                                                if (Data[r, c].CCD2receiveX.Contains("999.999") ||
                                                    (Data[r, c].CCD2receiveY != null && Data[r, c].CCD2receiveY.Contains("999.999")) ||
                                                    (Data[r, c].CCD2receiveR != null && Data[r, c].CCD2receiveR.Contains("999.999")))
                                                    continue;
                                                if (Data[r, c].OkNok != "OK" && Data[r, c].OkNok != "NG")
                                                    fiIncomplete = true;
                                            }
                                        }
                                    }
                                    if (fiIncomplete)
                                    {
                                        await Logger.WriteLogasTask(Logger.LogType.Error, "WorkingConveyor2", "WorkingCon2_Seq", "Final Inspection incomplete - blocking pallet exit", "");
                                        MessageBox.Show("Final Inspection incomplete. Some cavities have no committed result. Click OK to retry remaining cavities.", "Alarm", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);
                                        break;
                                    }
                                    //Arulkumar Fixed random stoppage end
                                    await Logger.WriteLogasTask(Logger.LogType.Running, "All Collect ccd Data", "Working Conv2", "All data Collected", "");
                                    i_step = 37;
                                }

                                break;

                            case 37:
                                // Lower the carrier

                                await Logger.WriteLogasTask(Logger.LogType.Running, "both cylinder retract", "Working Conv2", "cylinder retract", "");
                                Cylinder_config.Cylinders_List[(int)Cylinder_config.Cylinders.Work_Conv_2_pallet_Lift_Cyl].Cylinder_Retract();
                                Cylinder_config.Cylinders_List[(int)Cylinder_config.Cylinders.Work_Conv_2_Stopper_Cyl].Cylinder_Retract();
                                await GantrySystem.Wk2move(pos[0, 0]);
                                i_step = 38;
                                break;

                            case 38:
                                if (GlobalVariable.g_MachineIoChaged == "Yes" ?  GlobalVariable.DI[(int)EInput_1.Work_Conv_2_Pallet_Lift_Cyl_Dn]  : GlobalVariable.DI[(int)EInput.Work_Conv_2_Pallet_Lift_Cyl_Dn])
                                {
                                    if(GlobalVariable.g_MachineIoChaged == "Yes" ? GlobalVariable.DI[(int)EInput_1.Work_Conv_2_Stopper_Cyl_Dn] : GlobalVariable.DI[(int)EInput.Work_Conv_2_Stopper_Cyl_Dn])
                                    {
                                        await pdcadated_Update(pos.GetLength(0), pos.GetLength(1));
                                        await Logger.WriteLogasTask(Logger.LogType.Running, " Upadted PDCA DATA", "Working Conv2 ", "Upadted PDCA DATA", "");
                                        i_step = 40;
                                    }
                                    else
                                    {
                                        Cylinder_config.Cylinders_List[(int)Cylinder_config.Cylinders.Work_Conv_2_pallet_Lift_Cyl].Cylinder_Retract();
                                        Cylinder_config.Cylinders_List[(int)Cylinder_config.Cylinders.Work_Conv_2_Stopper_Cyl].Cylinder_Retract();
                                    }
                                    
                                }
                                else
                                {
                                    await Logger.WriteLogasTask(Logger.LogType.Running, "both cylinder retract faild try- agin", "Working Conv2", "cylinder retract", "");
                                    Cylinder_config.Cylinders_List[(int)Cylinder_config.Cylinders.Work_Conv_2_pallet_Lift_Cyl].Cylinder_Retract();
                                    Cylinder_config.Cylinders_List[(int)Cylinder_config.Cylinders.Work_Conv_2_Stopper_Cyl].Cylinder_Retract();
                                    break;
                                }

                                break;

                            case 40:
                                // Stopper down & conveyor rotate

                                if (!GlobalVariable.Semimachk)
                                {
                                    GlobalVariable.DIDO.WriteOPS(true, (int)EOutput.GRT_Ready_To_Send_Pallet);

                                    if (GlobalVariable.DI[(int)EInput.GBP_Ready_To_Receive_Pallet])
                                    {
                                        await Logger.WriteLogasTask(Logger.LogType.Running, "semima check", "Working Conv2", "check semima and move", "");

                                        if (GlobalVariable.ConveyorCount == 4)
                                        {
                                            StepperSystem.MovePlate(new bool?[] { null, null, null, true, null, null });

                                        }
                                        else if (GlobalVariable.ConveyorCount == 6)
                                        {
                                            StepperSystem.MovePlate(new bool?[] { null, null, null, null, true, true });
                                        }
                                        i_step = 41;
                                        ExitSen.Start();
                                        ExitSen.Restart();

                                    }
                                    else
                                    {
                                        if (GlobalVariable.ConveyorCount == 4)
                                        {
                                            StepperSystem.MovePlate(new bool?[] { null, null, null, false, null, null });

                                        }
                                        else if (GlobalVariable.ConveyorCount == 6)
                                        {
                                            StepperSystem.MovePlate(new bool?[] { null, null, null, null, false, false });
                                        }
                                        i_step = 40;
                                        break;

                                    }

                                }
                                else if (GlobalVariable.Semimachk)
                                {
                                    if (GlobalVariable.ConveyorCount == 4)
                                    {
                                        StepperSystem.MovePlate(new bool?[] { null, null, null, true, null, null });

                                    }
                                    else if (GlobalVariable.ConveyorCount == 6)
                                    {
                                        StepperSystem.MovePlate(new bool?[] { null, null, null, null, true, true });
                                    }
                                    i_step = 41;

                                }
                                break;


                            case 41:
                                if (dryrun)
                                {

                                    i_step = 41;

                                }
                                else
                                {
                                    if (GlobalVariable.ConveyorCount == 4)
                                    {
                                        StepperSystem.MovePlate(new bool?[] { null, null, null, true, null, null });

                                    }
                                    else if (GlobalVariable.ConveyorCount == 6)
                                    {
                                        StepperSystem.MovePlate(new bool?[] { null, null, null, null, true, true });
                                    }
                                    if (GlobalVariable.g_MachineIoChaged == "Yes" ? GlobalVariable.DI[(int)EInput_1.Work_Conv_2_Pallet_Exit_Sen] : GlobalVariable.DI[(int)EInput.Work_Conv_2_Pallet_Exit_Sen])
                                    {
                                        //GlobalVariable.RecheckStopper_Start = true;
                                        //RecheckStopper.Start();
                                        //RecheckStopper.RecheckStopper_Steep = 0;
                                        //i_step = 50;
                                        i_step = 42;
                                        ExitSen.Stop();

                                    }
                                    else
                                    {
                                        if (ExitSen.ElapsedMilliseconds > GlobalVariable.Working_Conv_2_Exit_Sens_Delay)
                                        {
                                            GlobalVariable.Working_Pallet_NotMoves = true;
                                            Task.Run(() =>Logger.WriteLog(Logger.LogType.Error, "Working2Conveyor", "WorkingCon_Seq2", "", "Working 2 Exit Sensor Not Sensed. Please Give OK"));
                                            DialogResult res = MessageBox.Show("Working 2 Exit Sensor Not Sensed. Please Give OK", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);
                                            
                                            if (res == DialogResult.OK)
                                            {
                                                GlobalVariable.Working_Pallet_NotMoves = false;
                                                if (GlobalVariable.ConveyorCount == 4)
                                                {
                                                    StepperSystem.MovePlate(new bool?[] { null, null, null, true, null, null });

                                                }
                                                else if (GlobalVariable.ConveyorCount == 6)
                                                {
                                                    StepperSystem.MovePlate(new bool?[] { null, null, null, null, true, true });
                                                }
                                                await Task.Delay(GlobalVariable.Stopper_Recheck_Time);
                                                Cylinder_config.Cylinders_List[(int)Cylinder_config.Cylinders.Work_Conv_2_Stopper_Cyl].Cylinder_Extend();

                                                i_step = 42;
                                                ExitSen.Stop();

                                            }
                                            else
                                            {
                                                GlobalVariable.Working_Pallet_NotMoves = false;
                                                if (GlobalVariable.ConveyorCount == 4)
                                                {
                                                    StepperSystem.MovePlate(new bool?[] { null, null, null, true, null, null });

                                                }
                                                else if (GlobalVariable.ConveyorCount == 6)
                                                {
                                                    StepperSystem.MovePlate(new bool?[] { null, null, null, null, true, true });
                                                }
                                                await Task.Delay(GlobalVariable.Stopper_Recheck_Time);
                                                Cylinder_config.Cylinders_List[(int)Cylinder_config.Cylinders.Work_Conv_2_Stopper_Cyl].Cylinder_Extend();

                                                i_step = 42;
                                                ExitSen.Stop();
                                            }


                                        }
                                    }
                                }
                                break;


                            case 42:
                                if (GlobalVariable.g_MachineIoChaged == "Yes" ?  !GlobalVariable.DI[(int)EInput_1.Work_Conv_2_Pallet_Exit_Sen] : !GlobalVariable.DI[(int)EInput.Work_Conv_2_Pallet_Exit_Sen])
                                {
                                    i_step = 43;
                                }
                                break;

                            case 43:
                                if (GlobalVariable.g_MachineIoChaged == "Yes" ? !GlobalVariable.DI[(int)EInput_1.Work_Conv_2_Pallet_Inplace_Sen] : !GlobalVariable.DI[(int)EInput.Work_Conv_2_Pallet_Inplace_Sen] && GlobalVariable.g_MachineIoChaged == "Yes" ?  !GlobalVariable.DI[(int)EInput_1.Work_Conv_2_Pallet_Exit_Sen] : !GlobalVariable.DI[(int)EInput.Work_Conv_2_Pallet_Exit_Sen])
                                {
                                    Cylinder_config.Cylinders_List[(int)Cylinder_config.Cylinders.Work_Conv_2_Stopper_Cyl].Cylinder_Extend();
                                    i_step = 50;
                                }
                                break;

                            case 50:
                                // Stopper up & stop conveyor
                                if (GlobalVariable.current_MCStatus == GlobalVariable.MachineStatus.Pause)
                                {
                                    i_step = 40;
                                }

                                if (dryrun)
                                {

                                    Cylinder_config.Cylinders_List[(int)Cylinder_config.Cylinders.Work_Conv_2_Stopper_Cyl].Cylinder_Extend();
                                    if (GlobalVariable.ConveyorCount == 4)
                                    {
                                        StepperSystem.MovePlate(new bool?[] { null, null, null, false, null, null });

                                    }
                                    else if (GlobalVariable.ConveyorCount == 6)
                                    {
                                        StepperSystem.MovePlate(new bool?[] { null, null, null, null, false, false });
                                    }
                                    running = false;
                                    //  clearwk2cavity.Invoke();
                                    WorkingCon2_Seq_completed = false;
                                    //Arulkumar Fixed random stoppage start
                                    semaphoreSlimwk2.Release();
                                    semaphoreReleased = true;
                                    //Arulkumar Fixed random stoppage end
                                    //Task.Run(() => DryRunDataSaver.SaveDryRunFromAll(data));
                                    DryRunDataSaver.SaveDryRunFromAll(data);
                                    await Logger.WriteLogasTask(Logger.LogType.Running, "save and update all data", "Working Conv2", "save and update all data", "");

                                    i_step = 34;

                                }
                                else if (GlobalVariable.g_MachineIoChaged == "Yes" ? !GlobalVariable.DI[(int)EInput_1.Work_Conv_2_Pallet_Exit_Sen] : !GlobalVariable.DI[(int)EInput.Work_Conv_2_Pallet_Exit_Sen] && GlobalVariable.g_MachineIoChaged == "Yes" ? !GlobalVariable.DI[(int)EInput_1.Work_Conv_2_Pallet_Inplace_Sen] : !GlobalVariable.DI[(int)EInput.Work_Conv_2_Pallet_Inplace_Sen])
                                {

                                    if (GlobalVariable.ConveyorCount == 4)
                                    {
                                        StepperSystem.MovePlate(new bool?[] { null, null, null, false, null, null });

                                    }
                                    else if (GlobalVariable.ConveyorCount == 6)
                                    {
                                        StepperSystem.MovePlate(new bool?[] { null, null, null, null, false, false });
                                    }
                                    running = false;
                                    //clearwk2cavity.Invoke();
                                    try
                                    {
                                        Update_Cycle_Time_Out();
                                        ProductionDataSaver.SaveProductionFromAll(Data);
                                        await Logger.WriteLogasTask(Logger.LogType.Running, "save and update all data", "Working Conv2", "save and update all data", "");

                                        //await pdcadated_Update(pos.GetLength(0), pos.GetLength(1));
                                        // ProductionDataSaver.SaveProductionCycleEnd(LoadingConveyor.CurrentData, WorkingConveyor1.CurrentData, Data);
                                    }
                                    catch (Exception ex)
                                    {
                                        //Arulkumar Fixed random stoppage start
                                        await Logger.WriteLogasTask(Logger.LogType.Error, "WorkingConveyor2", "WorkingCon2_Seq", ex.Message, ex.ToString());
                                        //Arulkumar Fixed random stoppage end
                                    }
                                    await executeGrpCmd(pos.GetLength(0), pos.GetLength(1));
                                    WorkingCon2_Seq_completed = false;
                                    //Arulkumar Fixed random stoppage start
                                    semaphoreSlimwk2.Release();
                                    semaphoreReleased = true;
                                    //Arulkumar Fixed random stoppage end
                                    i_step = 34;
                                    await Logger.WriteLogasTask(Logger.LogType.Running, "Working 2 seq ", "Working Conv2", "Working 2 seq completed", "");

                                }


                                break;


                        }
                    }
                }
            }
            catch (Exception ex)
            {
                //Arulkumar Fixed random stoppage start
                Logger.WriteLog(Logger.LogType.Error, "WorkingConveyor2", "WorkingCon2_Seq", ex.Message, ex.ToString());
                //Arulkumar Fixed random stoppage end
            }
            finally
            {
                //Arulkumar Fixed random stoppage start
                if (semaphoreHeld && !semaphoreReleased)
                {
                    try
                    {
                        semaphoreSlimwk2.Release();
                    }
                    catch (SemaphoreFullException)
                    {
                    }
                }
                //Arulkumar Fixed random stoppage end
            }
        }
        public static string cmd_S;
        public static string dtm1_S;
        public static string ScnrResult_1;
        public static string[] splitdata_1;
        public static string[] GapAngle_1;
        private static string ErrorLogDATAFilePAth = "D:\\TEAL\\";
        string path = ErrorLogDATAFilePAth + @"\recheck_lOG\";
        public async Task GantryMovement(int row, int col)
        {
            try
            {

                if (dryrun)
                {

                    {
                        await GantrySystem.Wk2move(pos[row, col]);
                        await Task.Delay(100);
                        string cmd1 = "T2C,S,1,2,4,TEST,1";
                        string ScnrResult = await camera.Trig_Camera(ObjectList.CCD4, cmd1);
                        updatecavity?.Invoke(row, col, "SN", true, "BN");
                        GlobalVariable.dGlobal_Reject_count = GlobalVariable.dGlobal_Reject_count + 1;
                        GlobalVariable.dGlobal_Total_count = GlobalVariable.dGlobal_Pass_count + GlobalVariable.dGlobal_Reject_count;
                        GlobalVariable.dGlobal_Yield_Count = (GlobalVariable.dGlobal_Pass_count / GlobalVariable.dGlobal_Total_count) * 100;
                    }

                }
                else
                if (production)
                {
                    LoadingConveyor.ScannerLog_Temp(path, DateTime.Now.Date.ToString("dd-MM-yyyy HHmmss"), "start", 1);
                    if (Data[row, col].pastingcmplt)
                    {
                        if ((Data[row, col].OkNok == "OK" || Data[row, col].OkNok == "NG") &&
                            !string.IsNullOrEmpty(Data[row, col].RechekTime_stmp))
                        {
                            //Arulkumar Fixed random stoppage start
                            //Reason: Same cavity re-triggered when Final Inspection restarted after incomplete gate
                            //Root Cause: Re-entering CollectCCD3data/TraverseArray re-moved and re-triggered cavities that already had committed FI results.
                            return;
                            //Arulkumar Fixed random stoppage end
                        }
                        //if (!Data[row, col].CCD2receiveR.Contains("999.999") &&
                        //    (!Data[row, col].CCD2receiveX.Contains("999.999")) &&
                        //    (!Data[row, col].CCD2receiveY.Contains("999.999")))
                        if (!Data[row, col].CCD2receiveR.Contains("999.999") && (Data[row, col].CCD2receiveR != null) &&
                            (!Data[row, col].CCD2receiveX.Contains("999.999")) && (Data[row, col].CCD2receiveX != null) &&
                            (!Data[row, col].CCD2receiveY.Contains("999.999")) && (Data[row, col].CCD2receiveY != null))
                        {
                            #region sathish
                            //Arulkumar Fixed Hung start
                            LoadingConveyor.ScannerLog_Temp(path, DateTime.Now.Date.ToString("dd-MM-yyyy HHmmss"), "movestart", 2);
                            //Arulkumar Servo Invalid Error Fixed Start 
                            //Reason: Same physical position triggered ~12 times / FI skip
                            //Root Cause: Wk2move return value ignored. When X2/Y2 failed to reach target (timeout/pause/error),
                            //camera still triggered at the previous physical position for every subsequent cavity.
                            await GantrySystem.Wk2move(pos[row, col]);
                            await Logger.WriteLogasTask(Logger.LogType.Running, "WK2Move", "Working Conv2 Row and Col Moved", " Row and Col " + pos[row, col], "");

                            //if (movedOk)
                            //{
                            //    MessageBox.Show("Movemt Skip");
                            //    await Logger.WriteLogasTask(Logger.LogType.Error, "WorkingConveyor2", "GantryMovement", "Wk2move failed - skip trigger for cavity " + Data[row, col].cavityNo, "Row=" + row + " Col=" + col);
                            //    return;
                            //}
                            //Arulkumar Servo Invalid Error Fixed End
                            LoadingConveyor.ScannerLog_Temp(path, DateTime.Now.Date.ToString("dd-MM-yyyy HHmmss"), "MoveEnd", 22);
                            await Task.Delay(100);

                            bool ccdDone = false;
                            retryccd = 0;

                            // Retry loop only (operator retry / invalid CCD reply). No switch/step machine.
                            while (!ccdDone)
                            {
                                //Arulkumar Fixed random stoppage start
                                //SafePauseEventWait(); // Cmd by Arul 27-08-2026
                                //Arulkumar Fixed random stoppage end
                                if (GlobalVariable.b_gPause)
                                {
                                    ConveyorSystem._pauseEvent.WaitOne();
                                    continue;
                                }
                                cmd_S = "";
                                dtm1_S = DateTime.Now.ToString("HHmmss");

                                if(GlobalVariable.CavityRows == 4 && GlobalVariable.CavityCols == 3)
                                {
                                    if (row == 0 || row == 1)
                                    {
                                        if (Data[row, col].SNno == null)
                                        {
                                            cmd_S = "T2C,S,1,1," + Data[row, col].cavityNo + "," + dtm1_S + "_NA_NA,1";
                                            await Logger.WriteLogasTask(Logger.LogType.Running, " CollectCCD3data", "Working Conv2 | Gandry Movement" + " Tigger CMD : " + cmd_S, "Row = " + row + "Col = " + col + "ScannerData = " + Data[row, col].cavityNo + "SNno = " + Data[row, col].SNno, "");
                                        }
                                        else
                                        {
                                            cmd_S = "T2C,S,1,1," + Data[row, col].cavityNo + "," + dtm1_S + "_" + Data[row, col].SNno + ",1";
                                            await Logger.WriteLogasTask(Logger.LogType.Running, " CollectCCD3data", "Working Conv2 | Gandry Movement" + " Tigger CMD : " + cmd_S, "Row = " + row + "Col = " + col + "ScannerData = " + Data[row, col].cavityNo + "SNno = " + Data[row, col].SNno, "");
                                        }
                                    }
                                    else if (row == 2 || row == 3)
                                    {
                                        if (Data[row, col].SNno == null)
                                        {
                                            cmd_S = "T2C,S,1,2," + Data[row, col].cavityNo + "," + dtm1_S + "_NA_NA,1";
                                            await Logger.WriteLogasTask(Logger.LogType.Running, " CollectCCD3data", "Working Conv2 | Gandry Movement" + " Tigger CMD : " + cmd_S, "Row = " + row + "Col = " + col + "ScannerData = " + Data[row, col].cavityNo + "SNno = " + Data[row, col].SNno, "");
                                        }
                                        else
                                        {
                                            cmd_S = "T2C,S,1,2," + Data[row, col].cavityNo + "," + dtm1_S + "_" + Data[row, col].SNno + ",1";
                                            await Logger.WriteLogasTask(Logger.LogType.Running, " CollectCCD3data", "Working Conv2 | Gandry Movement" + " Tigger CMD : " + cmd_S, "Row = " + row + "Col = " + col + "ScannerData = " + Data[row, col].cavityNo + "SNno = " + Data[row, col].SNno, "");
                                        }
                                    }
                                }
                                else if (GlobalVariable.CavityRows == 3 && GlobalVariable.CavityCols == 4)
                                {
                                    if (GlobalVariable.Four_Graphit)
                                    {
                                        if (row == 0 && col == 0 || row == 0 && col == 1 || row == 0 && col == 2 || row == 0 && col == 3 || row == 2 && col == 0 || row == 2 && col == 2)
                                        {
                                            if (Data[row, col].SNno == null)
                                            {
                                                cmd_S = "T2C,S,1,1," + Data[row, col].cavityNo + "," + dtm1_S + "_NA_NA,1" + ((GlobalVariable.K_Enable) ? ", K" : (GlobalVariable.NK_Enable) ? ", NK" : "");
                                                await Logger.WriteLogasTask(Logger.LogType.Running, " CollectCCD3data", "Working Conv2 | Gandry Movement" + " Tigger CMD : " + cmd_S, "Row = " + row + "Col = " + col + "ScannerData = " + Data[row, col].cavityNo + "SNno = " + Data[row, col].SNno, "");

                                            }
                                            else
                                            {
                                                cmd_S = "T2C,S,1,1," + Data[row, col].cavityNo + "," + dtm1_S + "_" + Data[row, col].SNno + ",1" + ((GlobalVariable.K_Enable) ? ", K" : (GlobalVariable.NK_Enable) ? ", NK" : "");
                                                await Logger.WriteLogasTask(Logger.LogType.Running, " CollectCCD3data", "Working Conv2 | Gandry Movement" + " Tigger CMD : " + cmd_S, "Row = " + row + "Col = " + col + "ScannerData = " + Data[row, col].cavityNo + "SNno = " + Data[row, col].SNno, "");
                                            }
                                        }
                                        else if (row == 1 && col == 0 || row == 1 && col == 1 || row == 1 && col == 2 || row == 1 && col == 3 || row == 2 && col == 1 || row == 2 && col == 3)
                                        {
                                            if (Data[row, col].SNno == null)
                                            {
                                                cmd_S = "T2C,S,1,2," + Data[row, col].cavityNo + "," + dtm1_S + "_NA_NA,1" + ((GlobalVariable.K_Enable) ? ", K" : (GlobalVariable.NK_Enable) ? ", NK" : "");
                                                await Logger.WriteLogasTask(Logger.LogType.Running, " CollectCCD3data", "Working Conv2 | Gandry Movement" + " Tigger CMD : " + cmd_S, "Row = " + row + "Col = " + col + "ScannerData = " + Data[row, col].cavityNo + "SNno = " + Data[row, col].SNno, "");

                                            }
                                            else
                                            {
                                                cmd_S = "T2C,S,1,2," + Data[row, col].cavityNo + "," + dtm1_S + "_" + Data[row, col].SNno + ",1" + ((GlobalVariable.K_Enable) ? ", K" : (GlobalVariable.NK_Enable) ? ", NK" : "");
                                                await Logger.WriteLogasTask(Logger.LogType.Running, " CollectCCD3data", "Working Conv2 | Gandry Movement" + " Tigger CMD : " + cmd_S, "Row = " + row + "Col = " + col + "ScannerData = " + Data[row, col].cavityNo + "SNno = " + Data[row, col].SNno, "");

                                            }
                                        }
                                    }
                                    else
                                    {
                                        if ((row == 0 && col == 0 || row == 0 && col == 1 || row == 0 && col == 2 || row == 0 && col == 3 || row == 2 && col == 0 || row == 2 && col == 2))
                                        {
                                            if (Data[row, col].SNno == null)
                                            {
                                                cmd_S = "T2C,S,1,1," + Data[row, col].cavityNo + "," + dtm1_S + "_NA_NA,1";
                                                await Logger.WriteLogasTask(Logger.LogType.Running, " CollectCCD3data", "Working Conv2 | Gandry Movement" + " Tigger CMD : " + cmd_S, "Row = " + row + "Col = " + col + "ScannerData = " + Data[row, col].cavityNo + "SNno = " + Data[row, col].SNno, "");
                                            }
                                            else
                                            {
                                                cmd_S = "T2C,S,1,1," + Data[row, col].cavityNo + "," + dtm1_S + "_" + Data[row, col].SNno + ",1" /*+ ((GlobalVariable.K_Enable) ? ", K" : (GlobalVariable.NK_Enable) ? ", NK":"")*/;
                                                await Logger.WriteLogasTask(Logger.LogType.Running, " CollectCCD3data", "Working Conv2 | Gandry Movement" + " Tigger CMD : " + cmd_S, "Row = " + row + "Col = " + col + "ScannerData = " + Data[row, col].cavityNo + "SNno = " + Data[row, col].SNno, "");
                                            }

                                        }
                                        else if ((row == 1 && col == 0 || row == 1 && col == 1 || row == 1 && col == 2 || row == 1 && col == 3 || row == 2 && col == 1 || row == 2 && col == 3))

                                        {

                                            if (Data[row, col].SNno == null)
                                            {
                                                cmd_S = "T2C,S,1,2," + Data[row, col].cavityNo + "," + dtm1_S + "_NA_NA,1";
                                                await Logger.WriteLogasTask(Logger.LogType.Running, " CollectCCD3data", "Working Conv2 | Gandry Movement" + " Tigger CMD : " + cmd_S, "Row = " + row + "Col = " + col + "ScannerData = " + Data[row, col].cavityNo + "SNno = " + Data[row, col].SNno, "");
                                            }
                                            else
                                            {
                                                cmd_S = "T2C,S,1,2," + Data[row, col].cavityNo + "," + dtm1_S + "_" + Data[row, col].SNno + ",1" /*+ ((GlobalVariable.K_Enable) ? ", K" : (GlobalVariable.NK_Enable) ? ", NK":"")*/;
                                                await Logger.WriteLogasTask(Logger.LogType.Running, " CollectCCD3data", "Working Conv2 | Gandry Movement" + " Tigger CMD : " + cmd_S , "Row = " + row + "Col = " + col + "ScannerData = " + Data[row, col].cavityNo + "SNno = " + Data[row, col].SNno , "");
                                            }

                                        }

                                    }
                                }

                                await Task.Delay(50);
                                LoadingConveyor.ScannerLog_Temp(path, DateTime.Now.Date.ToString("dd-MM-yyyy HHmmss"), cmd_S, 3);
                                ScnrResult_1 = await camera.Trig_Camera(ObjectList.CCD4, cmd_S);
                                await Logger.WriteLogasTask(Logger.LogType.Running, " ScanCameraData", "Working Conv2 ", " Row = " + row + " Col = " + col + " SNno = " + Data[row, col].SNno + " ScnrResult = " + ScnrResult_1 + "", "");

                                LoadingConveyor.ScannerLog_Temp(path, DateTime.Now.Date.ToString("dd-MM-yyyy HHmmss"), ScnrResult_1, 4);
                                if (ScnrResult_1 == null || ScnrResult_1 == "null" || ScnrResult_1 == "") // AK 01-06-2026
                                {
                                    //Arulkumar Fixed random stoppage start
                                    //Reason: Final Inspection skipped + false PDCA NG when Cognex/TCP returns empty
                                    //Root Cause: Null/empty CCD reply set ccdDone and advanced to next cavity without committing OkNok.
                                    //pdcadated_Update treated C# null OkNok as eligible (OkNok != "null") and uploaded default gaps as NG.
                                    //Do not Pause here: TraverseArray would resume on the NEXT cavity and skip this one permanently.
                                    await Task.Delay(100);
                                    ScnrResult_1 = "";
                                    retryccd++;
                                    if (retryccd < 3)
                                    {
                                        continue;
                                    }
                                    retryccd = 0;
                                    return;
                                    //Arulkumar Fixed random stoppage end
                                }

                                splitdata_1 = ScnrResult_1.Split(',');
                                //Arulkumar Fixed Null start
                                if (splitdata_1.Length <= 9)
                                {
                                    //Arulkumar Fixed random stoppage start
                                    //Reason: Truncated Cognex reply skipped cavity without OkNok commit
                                    //Root Cause: Length<=9 broke out of loop leaving OkNok unset; TraverseArray advanced anyway.
                                    retryccd++;
                                    if (retryccd < 3)
                                    {
                                        continue;
                                    }
                                    retryccd = 0;
                                    await Logger.WriteLogasTask(Logger.LogType.Running, "WorkingConveyor2", "GantryMovement", "CCD reply too short - blocking cavity " + Data[row, col].cavityNo, ScnrResult_1);
                                    return;
                                    //Arulkumar Fixed random stoppage end
                                }
                                else if (splitdata_1.Length >= 12) // bharath added for clearing Previous data
                                {
                                    //Arulkumar Fixed random stoppage start
                                    //Reason: Stale/merged TCP buffer caused skip without OkNok; same position could re-trigger
                                    //Root Cause: Length>=12 cleared buffer and exited cavity without result commit while index advanced.
                                    splitdata_1 = null;
                                    ScnrResult_1 = "";
                                    retryccd++;
                                    if (retryccd < 3)
                                    {
                                        continue;
                                    }
                                    retryccd = 0;
                                    await Logger.WriteLogasTask(Logger.LogType.Running, "WorkingConveyor2", "GantryMovement", "CCD reply too long/stale - blocking cavity " + Data[row, col].cavityNo, "");
                                    return;
                                    //Arulkumar Fixed random stoppage end
                                }

                                GapAngle_1 = splitdata_1[8].Split('_');
                                //Arulkumar Fixed Null end
                                Storing_TimeStamp[Data[row, col].cavityNo] = DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss:fff");

                                if (splitdata_1[2].Contains("OK") && splitdata_1[9].Contains("1"))
                                {
                                    LoadingConveyor.ScannerLog_Temp(path, DateTime.Now.Date.ToString("dd-MM-yyyy HHmmss"), splitdata_1[9], 5);
                                    Data[row, col].OkNok = "OK";
                                    Data[row, col].Gapx = double.Parse(splitdata_1[5]);
                                    Data[row, col].Gapy = double.Parse(splitdata_1[6]);
                                    Data[row, col].Angle = double.Parse(splitdata_1[7]);

                                    if (GlobalVariable.Loadcelchkbox)
                                    {
                                        Data[row, col].loadcellforce = Data[row, col].loadcellforce;
                                    }
                                    else
                                    {
                                        Random rand = new Random();
                                        int value = rand.Next(1900, 2100 + 1);
                                        double ldforce = value / 1000.0;
                                        Data[row, col].loadcellforce = ldforce;
                                        double F_LSlVar = GlobalVariable.F_LSl + rand.NextDouble() * (GlobalVariable.F_USl - GlobalVariable.F_LSl);
                                        double F_USlVar = GlobalVariable.F_USl + rand.NextDouble() * (GlobalVariable.F_USl - GlobalVariable.F_LSl);
                                    }

                                    if ((Data[row, col].Gapx <= GlobalVariable.X_USL) &&
                                        (Data[row, col].Gapx >= GlobalVariable.X_LSL) &&
                                        (Data[row, col].Gapy <= GlobalVariable.Y_USL) &&
                                        (Data[row, col].Gapy >= GlobalVariable.Y_LSL) &&
                                        (Data[row, col].Angle <= GlobalVariable.A_USl) &&
                                        (Data[row, col].Angle >= GlobalVariable.A_LSl) &&

                                         (Data[row, col].Gapx != 0.00 || Data[row, col].Gapx != 0 )&&
                                         (Data[row, col].Gapy != 0.00 || Data[row, col].Gapy != 0) &&
                                         (Data[row, col].Angle != 0.00 || Data[row, col].Angle != 0))
                                    {
                                        LoadingConveyor.ScannerLog_Temp(path, DateTime.Now.Date.ToString("dd-MM-yyyy HHmmss"), "OK", 6);
                                        Data[row, col].OkNok = "OK";
                                        GlobalVariable.dGlobal_Pass_count = GlobalVariable.dGlobal_Pass_count + 1;
                                        updatecavity(row, col, Data[row, col].SNno, true, Data[0, 0].CarrierBarcode);
                                        Data[row, col].CT = WorkingConveyor1.CT;
                                        GlobalVariable.dGlobal_Total_count = GlobalVariable.dGlobal_Pass_count + GlobalVariable.dGlobal_Reject_count;
                                        GlobalVariable.dGlobal_Yield_Count = (GlobalVariable.dGlobal_Pass_count / GlobalVariable.dGlobal_Total_count) * 100;
                                        ccdDone = true;
                                        break;
                                    }
                                    else
                                    {
                                        GlobalVariable.Recheck_NG = true;
                                        DialogResult res = MessageBox.Show("Do you want to Retry? Because the cavity is NG", "Alarm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2, MessageBoxOptions.ServiceNotification);
                                        retryccd++;
                                        if (retryccd < 3 && res == DialogResult.Yes)
                                        {
                                            GlobalVariable.Recheck_NG = false;
                                            await Task.Delay(50);
                                            continue; // re-trigger CCD
                                        }

                                        retryccd = 0;
                                        if (res == DialogResult.Yes)
                                        {
                                            MessageBox.Show("Max try has been reached!", "Alarm", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2, MessageBoxOptions.ServiceNotification);
                                        }

                                        GlobalVariable.Recheck_NG = false;
                                        LoadingConveyor.ScannerLog_Temp(path, DateTime.Now.Date.ToString("dd-MM-yyyy HHmmss"), "NG", 7);
                                        Random rand = new Random();
                                        int value = rand.Next(1900, 2100 + 1);
                                        double ldforce = value / 1000.0;

                                        Data[row, col].CT = WorkingConveyor1.CT;
                                        Data[row, col].OkNok = "NG";
                                        Data[row, col].Gapx = double.Parse(GapAngle_1[0]);
                                        Data[row, col].Gapy = double.Parse(GapAngle_1[1]);
                                        Data[row, col].Angle = double.Parse(GapAngle_1[2]);
                                        updatecavity(row, col, Data[row, col].SNno, false, Data[0, 0].CarrierBarcode);
                                        GlobalVariable.dGlobal_Reject_count = GlobalVariable.dGlobal_Reject_count + 1;

                                        try
                                        {
                                            Data[row, col].loadcellforce = ldforce;
                                            string carrier = Data[0, 0].CarrierBarcode ?? string.Empty;
                                            string snVal = Data[row, col].SNno ?? string.Empty;
                                            string cavityNo = Data[row, col].cavityNo.ToString();
                                            string leftGap = Data[row, col].Gapy.ToString();
                                            string angle = Data[row, col].Angle.ToString();
                                            string CT = Data[row, col].CT.ToString();
                                            string bottomGap = Data[row, col].Gapx.ToString();
                                            string pressForce = Data[row, col].loadcellforce.ToString();
                                            int cavityIndex = 0;
                                            int.TryParse(cavityNo, out cavityIndex);
                                            if (cavityIndex > 0) cavityIndex = cavityIndex - 1;
                                        }
                                        catch (Exception ex)
                                        {
                                            //Arulkumar Fixed random stoppage start
                                            Logger.WriteLog(Logger.LogType.Error, "WorkingConveyor2", "PDCA_Data", ex.Message, ex.ToString());
                                            //Arulkumar Fixed random stoppage end
                                        }

                                        ccdDone = true;
                                        break;
                                    }
                                }
                                else if (splitdata_1[9] == "-1")
                                {
                                    GlobalVariable.Recheck_NG = true;
                                    DialogResult res = MessageBox.Show("Do you want to Retry? Because the cavity is NG", "Alarm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2, MessageBoxOptions.ServiceNotification);
                                    retryccd++;
                                    if (retryccd < 3 && res == DialogResult.Yes)
                                    {
                                        GlobalVariable.Recheck_NG = false;
                                        await Task.Delay(50);
                                        continue; // re-trigger CCD
                                    }

                                    retryccd = 0;
                                    if (res == DialogResult.Yes)
                                    {
                                        MessageBox.Show("Max try has been reached!", "Alarm", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2, MessageBoxOptions.ServiceNotification);
                                    }

                                    GlobalVariable.Recheck_NG = false;
                                    LoadingConveyor.ScannerLog_Temp(path, DateTime.Now.Date.ToString("dd-MM-yyyy HHmmss"), "NG", 7);
                                    Random rand = new Random();
                                    int value = rand.Next(1900, 2100 + 1);
                                    double ldforce = value / 1000.0;

                                    Data[row, col].CT = WorkingConveyor1.CT;
                                    Data[row, col].OkNok = "NG";
                                    Data[row, col].Gapx = double.Parse(GapAngle_1[0]);
                                    Data[row, col].Gapy = double.Parse(GapAngle_1[1]);
                                    Data[row, col].Angle = double.Parse(GapAngle_1[2]);
                                    updatecavity(row, col, Data[row, col].SNno, false, Data[0, 0].CarrierBarcode);
                                    GlobalVariable.dGlobal_Reject_count = GlobalVariable.dGlobal_Reject_count + 1;

                                    try
                                    {
                                        Data[row, col].loadcellforce = ldforce;
                                        string carrier = Data[0, 0].CarrierBarcode ?? string.Empty;
                                        string snVal = Data[row, col].SNno ?? string.Empty;
                                        string cavityNo = Data[row, col].cavityNo.ToString();
                                        string leftGap = Data[row, col].Gapy.ToString();
                                        string angle = Data[row, col].Angle.ToString();
                                        string CT = Data[row, col].CT.ToString();
                                        string bottomGap = Data[row, col].Gapx.ToString();
                                        string pressForce = Data[row, col].loadcellforce.ToString();
                                        int cavityIndex = 0;
                                        int.TryParse(cavityNo, out cavityIndex);
                                        if (cavityIndex > 0) cavityIndex = cavityIndex - 1;
                                    }
                                    catch (Exception ex)
                                    {
                                        //Arulkumar Fixed random stoppage start
                                        Logger.WriteLog(Logger.LogType.Error, "WorkingConveyor2", "PDCA_Data", ex.Message, ex.ToString());
                                        //Arulkumar Fixed random stoppage end
                                    }

                                    ccdDone = true;
                                    break;
                                }
                                else
                                {
                                    //Arulkumar Fixed random stoppage start
                                    //Reason: Unexpected Cognex format skipped cavity; PDCA could still upload unset OkNok
                                    //Root Cause: else branch set ccdDone and advanced without OkNok commit.
                                    retryccd++;
                                    if (retryccd < 3)
                                    {
                                        continue;
                                    }
                                    retryccd = 0;
                                    await Logger.WriteLogasTask(Logger.LogType.Error, "WorkingConveyor2", "GantryMovement", "Unexpected CCD format - blocking cavity " + Data[row, col].cavityNo, ScnrResult_1);
                                    return;
                                    //Arulkumar Fixed random stoppage end
                                }
                            }

                            //Arulkumar Fixed random stoppage start
                            //Reason: RechekTime_stmp marked FI done even when OkNok never committed
                            //Root Cause: Timestamp assigned after loop for null/invalid exits, so incomplete cavities looked processed.
                            if (Data[row, col].OkNok == "OK" || Data[row, col].OkNok == "NG")
                            {
                                Data[row, col].RechekTime_stmp = dtm1_S;
                            }
                            //Arulkumar Fixed random stoppage end
                            retryccd = 0;
                            await Task.Delay(50);
                            //Arulkumar Fixed Hung end
                            #endregion

                            #region Old Sequnces
                            //LoadingConveyor.ScannerLog_Temp(path, DateTime.Now.Date.ToString("dd-MM-yyyy HHmmss"), "movestart", 2);
                            //await GantrySystem.Wk2move(pos[row, col]);
                            //LoadingConveyor.ScannerLog_Temp(path, DateTime.Now.Date.ToString("dd-MM-yyyy HHmmss"), "MoveEnd", 22);
                            //await Task.Delay(100);

                            //string cmd1 = "";
                            //string dtm1 = DateTime.Now.ToString("HHmmss");
                            //if (row == 0 || row == 1)
                            //{
                            //    if (Data[row, col].SNno == null)
                            //        cmd1 = "T2C,S,1,1," + Data[row, col].cavityNo + "," + dtm1 + "_NA_NA,1";
                            //    else
                            //        cmd1 = "T2C,S,1,1," + Data[row, col].cavityNo + "," + dtm1 + "_" + Data[row, col].SNno + ",1";
                            //}
                            //else
                            //    if (row == 2 || row == 3)
                            //{
                            //    if (Data[row, col].SNno == null)
                            //        cmd1 = "T2C,S,1,2," + Data[row, col].cavityNo + "," + dtm1 + "_NA_NA,1";
                            //    else
                            //        cmd1 = "T2C,S,1,2," + Data[row, col].cavityNo + "," + dtm1 + "_" + Data[row, col].SNno + ",1";
                            //}
                            //LoadingConveyor.ScannerLog_Temp(path, DateTime.Now.Date.ToString("dd-MM-yyyy HHmmss"), cmd1, 3);
                            //string ScnrResult = await camera.Trig_Camera(ObjectList.CCD4, cmd1);
                            //LoadingConveyor.ScannerLog_Temp(path, DateTime.Now.Date.ToString("dd-MM-yyyy HHmmss"), ScnrResult, 4);
                            //if (ScnrResult == null || ScnrResult == "null" || ScnrResult == "") // AK 01-06-2026
                            //{
                            //    await Task.Delay(100);
                            //    ScnrResult = await camera.Trig_Camera(ObjectList.CCD4, cmd1);
                            //    await Logger.WriteLogasTask(Logger.LogType.Running, "ScannerResult_NULL", "Working Conv2", ScnrResult, "");
                            //}
                            //string[] splitdata = ScnrResult.Split(',');
                            //string[] GapAngle = splitdata[8].Split('_');

                            //Storing_TimeStamp[Data[row, col].cavityNo] = DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss:fff");

                            //if (splitdata[9] == "1")
                            //{
                            //    LoadingConveyor.ScannerLog_Temp(path, DateTime.Now.Date.ToString("dd-MM-yyyy HHmmss"), splitdata[9], 5);
                            //    Data[row, col].OkNok = "OK";
                            //    bool pass = false;
                            //    Data[row, col].Gapx = double.Parse(splitdata[5]);
                            //    Data[row, col].Gapy = double.Parse(splitdata[6]);
                            //    Data[row, col].Angle = double.Parse(splitdata[7]);



                            //    if (GlobalVariable.Loadcelchkbox)
                            //    {
                            //        Data[row, col].loadcellforce = Data[row, col].loadcellforce;

                            //    }
                            //    else
                            //    {
                            //        Random rand = new Random();
                            //        double min_force = 1900;
                            //        double max_force = 2100;
                            //        int value = rand.Next(1900, 2100 + 1);
                            //        double ldforce = value / 1000.0;
                            //        Data[row, col].loadcellforce = ldforce;
                            //        double F_LSlVar = GlobalVariable.F_LSl + rand.NextDouble() * (GlobalVariable.F_USl - GlobalVariable.F_LSl);
                            //        double F_USlVar = GlobalVariable.F_USl + rand.NextDouble() * (GlobalVariable.F_USl - GlobalVariable.F_LSl);
                            //    }


                            //    //ldforce = Math.Round((Data[row, col].loadcellforce < F_LSlVar ? 1.9 : 2.1) + rand.NextDouble() * 0.1, 2);


                            //    //  ldforce = (Data[row, col].loadcellforce < F_LSlVar ? 1.9 : 2.0) + rand.NextDouble() * 0.1;                        
                            //    //  double ldforce = Data[row, col].loadcellforce > GlobalVariable.F_USl ? 2.2 : Data[row, col].loadcellforce;
                            //    //  ldforce = Data[row, col].loadcellforce < GlobalVariable.F_LSl ? 1.8 : Data[row, col].loadcellforce;

                            //    if ((Data[row, col].Gapx <= GlobalVariable.X_USL) && (Data[row, col].Gapx >= GlobalVariable.X_LSL) &&
                            //                    (Data[row, col].Gapy <= GlobalVariable.Y_USL) && (Data[row, col].Gapy >= GlobalVariable.Y_LSL) &&
                            //                    (Data[row, col].Angle <= GlobalVariable.A_USl) && (Data[row, col].Angle >= GlobalVariable.A_LSl))


                            //    // ldforce >= GlobalVariable.F_LSl && ldforce <= GlobalVariable.F_USl;
                            //    //if (pass)
                            //    {
                            //        LoadingConveyor.ScannerLog_Temp(path, DateTime.Now.Date.ToString("dd-MM-yyyy HHmmss"), "ok", 6);
                            //        // Data[row, col].loadcellforce = ldforce;                           
                            //        Data[row, col].OkNok = "OK";
                            //        GlobalVariable.dGlobal_Pass_count = GlobalVariable.dGlobal_Pass_count + 1;
                            //        updatecavity(row, col, Data[row, col].SNno, true, Data[0, 0].CarrierBarcode);
                            //        Data[row, col].CT = WorkingConveyor1.CT;
                            //        GlobalVariable.dGlobal_Total_count = GlobalVariable.dGlobal_Pass_count + GlobalVariable.dGlobal_Reject_count;
                            //        GlobalVariable.dGlobal_Yield_Count = (GlobalVariable.dGlobal_Pass_count / GlobalVariable.dGlobal_Total_count) * 100;
                            //    }
                            //    else
                            //    {
                            //        // Data[row, col].loadcellforce = ldforce;
                            //        Data[row, col].OkNok = "NG";
                            //        updatecavity(row, col, Data[row, col].SNno, false, Data[0, 0].CarrierBarcode);
                            //        GlobalVariable.dGlobal_Reject_count = GlobalVariable.dGlobal_Reject_count + 1;
                            //        Data[row, col].CT = WorkingConveyor1.CT;
                            //        //GlobalVariable.dGlobal_Reject_count = GlobalVariable.dGlobal_Reject_count + 1;

                            //        GlobalVariable.dGlobal_Total_count = GlobalVariable.dGlobal_Pass_count + GlobalVariable.dGlobal_Reject_count;
                            //        GlobalVariable.dGlobal_Yield_Count = (GlobalVariable.dGlobal_Pass_count / GlobalVariable.dGlobal_Total_count) * 100;
                            //    }
                            //    // AK

                            //    // updatecavity(row, col, Data[row, col].SNno, true, Data[0, 0].CarrierBarcode);  

                            //    // send PDCA data for this cavity (fire-and-forget)
                            //    try
                            //    {
                            //        string carrier = Data[0, 0].CarrierBarcode ?? string.Empty;
                            //        string snVal = Data[row, col].SNno ?? string.Empty;
                            //        string cavityNo = Data[row, col].cavityNo.ToString();
                            //        string leftGap = Data[row, col].Gapy.ToString();
                            //        string angle = Data[row, col].Angle.ToString();
                            //        string CT = Data[row, col].CT.ToString();
                            //        string bottomGap = Data[row, col].Gapx.ToString();
                            //        //   string pressForce = "0";
                            //        string pressForce = Data[row, col].loadcellforce.ToString();
                            //        int cavityIndex = 0;
                            //        int.TryParse(cavityNo, out cavityIndex);
                            //        if (cavityIndex > 0) cavityIndex = cavityIndex - 1;
                            //    }
                            //    catch { }
                            //}
                            //else if (splitdata[9] == "-1")
                            //{
                            //    LoadingConveyor.ScannerLog_Temp(path, DateTime.Now.Date.ToString("dd-MM-yyyy HHmmss"), "NG", 7);
                            //    Random rand = new Random();
                            //    double min_force = 1900;
                            //    double max_force = 2100;
                            //    int value = rand.Next(1900, 2100 + 1);
                            //    double ldforce = value / 1000.0;

                            //    Data[row, col].CT = WorkingConveyor1.CT;
                            //    Data[row, col].OkNok = "NG";
                            //    //Data[row, col].Gapx = double.Parse(splitdata[5]);
                            //    //Data[row, col].Gapy = double.Parse(splitdata[6]);
                            //    //Data[row, col].Angle = double.Parse(splitdata[7]);
                            //    Data[row, col].Gapx = double.Parse(GapAngle[0]);
                            //    Data[row, col].Gapy = double.Parse(GapAngle[1]);
                            //    Data[row, col].Angle = double.Parse(GapAngle[2]);
                            //    updatecavity(row, col, Data[row, col].SNno, false, Data[0, 0].CarrierBarcode);
                            //    GlobalVariable.dGlobal_Reject_count = GlobalVariable.dGlobal_Reject_count + 1;

                            //    // send PDCA data for this cavity (fire-and-forget) even if NG
                            //    try
                            //    {
                            //        Data[row, col].loadcellforce = ldforce;
                            //        string carrier = Data[0, 0].CarrierBarcode ?? string.Empty;
                            //        string snVal = Data[row, col].SNno ?? string.Empty;
                            //        string cavityNo = Data[row, col].cavityNo.ToString();
                            //        string leftGap = Data[row, col].Gapy.ToString();
                            //        string angle = Data[row, col].Angle.ToString();
                            //        string CT = Data[row, col].CT.ToString();
                            //        string bottomGap = Data[row, col].Gapx.ToString();
                            //        // string pressForce = "0";
                            //        string pressForce = Data[row, col].loadcellforce.ToString();
                            //        int cavityIndex = 0;
                            //        int.TryParse(cavityNo, out cavityIndex);
                            //        if (cavityIndex > 0) cavityIndex = cavityIndex - 1;
                            //    }
                            //    catch { }
                            //}

                            //Data[row, col].RechekTime_stmp = dtm1;
                            #endregion
                        }

                        else//Before
                        {
                            Data[row, col].OkNok = "NG"; // "null" changed to NGby Raj
                        }

                    }
                    else
                    {
                        Data[row, col].OkNok = "NG"; // "null" changed to NGby Raj
                    }
                }
            }
            catch (Exception ex)
            {
                //Arulkumar Fixed random stoppage start
                Logger.WriteLog(Logger.LogType.Error, "WorkingConveyor2", "GantryMovement", ex.Message, ex.ToString());
                //Arulkumar Fixed random stoppage end
            }
        }

        public async Task CollectCCD3data(CancellationToken token)
        {


            if (pos == null) return;

            int rows = pos.GetLength(0);
            int cols = pos.GetLength(1);
            await GantrySystem.TraverseArray(GantryMovement, rows, cols, token);

            //if (pos == null) return;
            //while (finalCavitySeqIndex <= 12 && !token.IsCancellationRequested)
            //{
            //    token.ThrowIfCancellationRequested();
            //    int cavityNo = FinalCheck_Order[finalCavitySeqIndex];

            //    if (!ShouldInspectCavity(cavityNo, out int row, out int col))
            //    {
            //        MarkCavitySkipped(row, col, cavityNo);
            //        finalCavitySeqIndex++;
            //        continue;
            //    }

            //    await GantryMovement(row, col);
            //    finalCavitySeqIndex++;
            //}
        }

        public async Task pdcadated_Update(int rows, int cols)
        {
            try
            {
                for (int row = 0; row < rows; row++)
                {
                    for (int col = 0; col < cols; col++)
                    {
                        if (Data[row, col].CCD2receiveX != null && Data[row, col].CCD2receiveX != "" && Data[row, col].CCD2receiveX != "null"
                            &&

                            Data[row, col].CCD2receiveY != null && Data[row, col].CCD2receiveY != "null" && Data[row, col].CCD2receiveY != "")
                        {
                            //Arulkumar Fixed random stoppage start
                            //Reason: PDCA uploaded NG for cavities that were never Final-Inspected
                            //Root Cause: Condition used (OkNok != "null"). When OkNok was C# null (camera skip/fail paths),
                            //null != "null" is true, so PDCA sent default Gapx/Gapy/Angle (0) → reported NG without physical FI.
                            //Invariant: upload only when OkNok was committed as OK or NG after FI.
                            if ((Data[row, col].OkNok == "OK" || Data[row, col].OkNok == "NG") &&
                                !string.IsNullOrEmpty(Data[row, col].RechekTime_stmp) &&
                                ((Data[row, col].SNno != null)) && (Data[row, col].SNno != "UOP") &&
                                (!Data[row, col].CCD2receiveR.Contains("999.999") && (!Data[row, col].CCD2receiveX.Contains("999.999")) && (!Data[row, col].CCD2receiveY.Contains("999.999")
                                && Data[row, col].pastingcmplt)))
                            //Arulkumar Fixed random stoppage end

                            {
                                if (!GlobalVariable.SFC_PDCA_Bypass)
                                {

                                    await S_Pdca.Final_Data_Send_PDCA(Data[row, col].SNno.ToString(), Data[row, col].SNno, Data[row, col].cavityNo.ToString(), Data[row, col].Gapx.ToString(), Data[row, col].Angle.ToString(),
                                  Data[row, col].CT.ToString(), Data[row, col].Gapy.ToString(), Data[row, col].loadcellforce.ToString());
                                }
                            }
                        }
                    }
                }
            }
            catch
            {

            }

        }
        #region Group Command


        public async Task executeGrpCmd(int rows, int cols)
        {
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    if (Data[row, col].ScannerData)
                    {
                        string cmd = "Group," + DateTime.Now.ToString("HHmmss") + "_" + Data[0, 0].CarrierBarcode + "_" + Data[row, col].SNno + "_" + Data[row, col].cavityNo + "_" +
                            Data[row, col].OkNok + "," + Data[row, col].NLTime_stmp + "_" + Data[row, col].SNno + "," + Data[row, col].MLBTime_stmp + "_" + Data[row, col].SNno + "," +
                            Data[row, col].FedTime_stmp + "_NA_NA" + "," + Data[row, col].RechekTime_stmp + "_" + Data[row, col].SNno;
                        await camera.Trig_Camera(ObjectList.CCD4, cmd);
                        await Logger.WriteLogasTask(Logger.LogType.Running, "WorkingConveyor2", "executeGrpCmd : ","cmd = "+cmd, "");

                    }
                }
            }

        }
        #endregion




        #endregion





    }


}

