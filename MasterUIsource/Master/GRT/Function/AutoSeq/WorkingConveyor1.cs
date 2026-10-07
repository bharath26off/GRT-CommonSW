using DIO;
using DynamicCylinders;
using DynamicVacuums;
using ExceptionLib;
using GRT_BG1.Data;
using GRT_BG1.Function.Calibration;
using GRT_BG1.Function.Classes;
using GRT_BG1.Function.Interface;
using GRT_BG1_V54.Function.CommonClass;
using Master;
using Master.GRT.Function.Stopper;
using Master.Log.LogClass;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static DIO.DIDO;
using static ExceptionLib.Logger;

namespace GRT_BG1.Function.DryRun
{
    public class WorkingConveyor1 : IWorkingConveyor
    {
        public static int step = 13;
        public static int retryccd = 0;

        public static bool firsttimePick = false;
        public static int i_rejection = 10;
        public static int i_feed = 10;
        public static int currentState = 10;
        public static bool running = false;
        public static SemaphoreSlim semaphoreSlim = new SemaphoreSlim(1, 1);
        public static SemaphoreSlim semaphoreSlim1 = new SemaphoreSlim(1, 1);
        public static SemaphoreSlim semaphoreSlim2 = new SemaphoreSlim(1, 1);
        public static bool WorkingCon_Seq_completed = true;
        public static bool camerascanRuning = false;
        public static bool pastingRunning = false;
        public static event Func<int, int, string, int, string, bool> updatecavity;
        public static event Action clearwk1cavity;
        public static bool nozzle1Graphhitetaken = false;
        public static bool nozzle2Graphhitetaken = false;
        static bool dryrun = false;
        static string fedTime_stmp = "";
        public static bool blockcreated = false;
        static bool production = false;
        static VisionSystem camera = new VisionSystem();
        string[] ccd2nozzle1;
        string[] ccd2nozle2;

        private static string _dir = @"D:\TEAL\Tossing_Data";
        private static string _filePath;
        private static DateTime _fileCreationTime;
        public static PartData[,] CurrentData => Data;
        static PartData[,] Data;
        Tossdata[,] Data1;
        static string[] splitdataccd3;
        public static bool firsttiimewait = false;
        public static double CT;
        public static int Count_CCD4 = 0;
        public static int Graphite_TossCount = 0;
        public static Stopwatch Cycle_Time = new Stopwatch();

        // ─────────────────────────────────────────────
        // RESUME STATE VARIABLES
        // ─────────────────────────────────────────────
        public static int savedStep = 10;
        public static int savedState = 10;
        public static bool resumeRequired = false;
        public static string resumeReason = "";
        private static int _safeRetryCount = 0;
        private const int MAX_SAFE_RETRIES = 3;
        private const int MAX_TRIGGER_LOOP_RETRIES = 100;

        public static string _dir_ = @"D:\TEAL\MoveandPast";

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
        // saved nozzle state for mid-paste recovery
        public static bool nozzle1WasDown = false;
        public static bool nozzle2WasDown = false;
        // ─────────────────────────────────────────────

        public static Stopwatch Exitsen_wok1 = new Stopwatch();
        public static Stopwatch Inplacesen_wok1 = new Stopwatch();
        PalletData pallet;
        public int nozzleno = 0;
        WorkingConveyor2 wk2;
        int PreRow = 0; int PreCol = 0;
        static Position[,] pos = null;

        // X2Y2-style index-based cavity tracking (replaces queueZ1/queueZ2)
        private static readonly List<(int row, int col)> n1OkCavities = new List<(int, int)>();
        private static readonly List<(int row, int col)> n2OkCavities = new List<(int, int)>();
        public static int assemblyCavityN1 = 0;
        public static int assemblyCavityN2 = 0;
        public static bool secondposN1Ok = false;
        public static bool secondposN2Ok = false;
        public static bool n1Toss = false;
        public static bool n2Toss = false;

        private static bool HasN1Cavity => assemblyCavityN1 < n1OkCavities.Count;
        private static bool HasN2Cavity => assemblyCavityN2 < n2OkCavities.Count;
        private static int RemainingN1Count => n1OkCavities.Count - assemblyCavityN1;
        private static int RemainingN2Count => n2OkCavities.Count - assemblyCavityN2;
        private static (int row, int col) N1Cell => n1OkCavities[assemblyCavityN1];
        private static (int row, int col) N2Cell => n2OkCavities[assemblyCavityN2];
        private static Position PeekN1Pos => pos[N1Cell.row, N1Cell.col];
        private static Position PeekN2Pos => pos[N2Cell.row, N2Cell.col];

        public static void ResetCavityWork()
        {
            n1OkCavities.Clear();
            n2OkCavities.Clear();
            assemblyCavityN1 = 0;
            assemblyCavityN2 = 0;
            secondposN1Ok = false;
            secondposN2Ok = false;
            n1Toss = false;
            n2Toss = false;
        }

        private static void AdvanceN1Cavity() => assemblyCavityN1++;
        private static void AdvanceN2Cavity() => assemblyCavityN2++;

        string dtm = DateTime.Now.ToString("HHmmss");
        public static bool Z2_Triggered_the_Nozzle_2 = false;
        public static bool Z1_Triggered_the_Nozzle_1 = false;
        public static int count = 0;
        public static bool Z2_Trigger_While = false;
        public static int Z2_Trigger_Step = 0;
        public static bool Z1_Trigger_While = false;
        public static int Z1_Trigger_Step = 0;
        public static string cmd1_1 = "";
        public static string cmd2_1 = "";
        public static string camdata_1 = "";
        public static string camdata_2 = "";

        #region WorkingConveyor1
        public WorkingConveyor1(Position[,] position)
        {
            wk2 = new WorkingConveyor2(GlobalVariable.Wk2Positions);
            pos = position;
        }
        #endregion

        #region Cycletime
        public static Stopwatch CycleTime = new Stopwatch();

        public static void Update_Cycle_Time()
        {
            if (!CycleTime.IsRunning)
            {
                CycleTime.Restart();
            }
            else
            {
                CycleTime.Stop();
                GlobalVariable.cycle_time = CycleTime.Elapsed.TotalSeconds;
                CycleTime.Restart();
            }
        }
        #endregion

        #region Working Sequence Started
        public async Task WorkingCon_Seq(CancellationToken token, PartData[,] data)
        {
            //Arulkumar Fixed random stoppage start
            bool semaphoreHeld = false;
            //Arulkumar Fixed random stoppage end
            await semaphoreSlim.WaitAsync(token);
            //Arulkumar Fixed random stoppage start
            semaphoreHeld = true;
            //Arulkumar Fixed random stoppage end
            try
            {
                if (GlobalVariable.g_bMachineMode == GlobalVariable.OperationMode.DryRun)
                {
                    dryrun = true;
                    production = false;
                }
                else if (GlobalVariable.g_bMachineMode == GlobalVariable.OperationMode.Production)
                {
                    production = true;
                    dryrun = false;
                    Data = data;
                }
                else if (GlobalVariable.g_bMachineMode == GlobalVariable.OperationMode.CPK)
                {
                    production = true;
                    dryrun = false;
                    Data = data;
                }

                // ── RESUME CHECK ──────────────────────────────────────────
                // If an alarm was triggered (e.g. InvalidServoCoordinate),
                // operator resets and restarts. We restore saved step/state
                // and keep cavity indices intact so the sequence continues from
                // exactly where it stopped.
                if (resumeRequired)
                {
                    step = savedStep;
                    currentState = savedState;
                    resumeRequired = false;

                    await Logger.WriteLogasTask(Logger.LogType.Running,
                        "WorkingCon_Seq", "Working Conv1",
                        $"RESUME: Restoring from savedStep={savedStep}, " +
                        $"savedState={savedState}. " +
                        $"Reason was: {resumeReason}", "");

                    // Recover nozzle if it was mid-paste when alarm fired
                    if (nozzle1WasDown)
                    {
                        await Logger.WriteLogasTask(Logger.LogType.Running,
                            "WorkingCon_Seq", "Working Conv1",
                            "RESUME: Nozzle1 was down at alarm — moving up", "");
                        await Task.Run(() => NozzleSystem.Nozzle1Moveup(GlobalVariable.SafePosition));
                        nozzle1WasDown = false;
                    }
                    if (nozzle2WasDown)
                    {
                        await Logger.WriteLogasTask(Logger.LogType.Running,
                            "WorkingCon_Seq", "Working Conv1",
                            "RESUME: Nozzle2 was down at alarm — moving up", "");
                        await Task.Run(() => NozzleSystem.Nozzle2Moveup(GlobalVariable.SafePosition));
                        nozzle2WasDown = false;
                    }
                }
                else
                {
                    // Fresh start — full reset
                    step = 10;
                    currentState = 10;
                    ResetCavityWork();
                    blockcreated = false;
                    _safeRetryCount = 0;
                }
                // ─────────────────────────────────────────────────────────

                WorkingCon_Seq_completed = true;
                while (!token.IsCancellationRequested && WorkingCon_Seq_completed)
                {
                    token.ThrowIfCancellationRequested();
                    if (GlobalVariable.b_gPause)
                    {
                        ConveyorSystem._pauseEvent.WaitOne();
                        await Task.Delay(100);
                        continue;
                    }
                    if (GlobalVariable.current_MCStatus == GlobalVariable.MachineStatus.Running)
                    {
                        await Task.Delay(100);
                        switch (step)
                        {
                            case 10:
                                running = true;
                                //StepperSystem.MovePlate(new bool?[] { null, null, true, true, null, null });
                                if (GlobalVariable.ConveyorCount == 4)
                                {
                                    StepperSystem.MovePlate(new bool?[] { null, null, true, null, null, null });

                                }
                                else if (GlobalVariable.ConveyorCount == 6)
                                {
                                    StepperSystem.MovePlate(new bool?[] { null, null, true, true, null, null });
                                }

                                if (dryrun)
                                {
                                    running = true;
                                    await Task.Delay(200);
                                    Cylinder_config.Cylinders_List[(int)Cylinder_config.Cylinders.Work_Conv_1_pallet_Lift_Cyl].Cylinder_Extend_without_sense();
                                    if (!firsttimePick)
                                        Updatedata();
                                    Cycle_Time.Start();
                                    step = 20;
                                }
                                else if (production && GlobalVariable.DI[(int)EInput.Work_Conv_1_Pallet_Inplace_Sen])
                                {
                                    await Logger.WriteLogasTask(Logger.LogType.Running, "WorkingCon_Seq", "Working Conv1", "Working Conveyor1 lifting cylinder up", "");
                                    running = true;
                                    //Arulkumar Fixed Null start
                                    clearwk1cavity?.Invoke();
                                    //Arulkumar Fixed Null end
                                    await Task.Delay(300);
                                    StepperSystem.MovePlate(new bool?[] { false, false, false, false, null, null });
                                    Cylinder_config.Cylinders_List[(int)Cylinder_config.Cylinders.Work_Conv_1_pallet_Lift_Cyl].Cylinder_Extend();
                                    Update_Cycle_Time();
                                    if (!firsttimePick)
                                        Updatedata();
                                    Cycle_Time.Start();

                                    step = 20;


                                }
                                break;

                            case 20:
                                await Logger.WriteLogasTask(Logger.LogType.Running, "WorkingCon_Seq", "Working Conv1", "Working Conveyor1 Stopper cylinder up", "");

                                Cylinder_config.Cylinders_List[(int)Cylinder_config.Cylinders.Work_Conv_1_Stopper_Cyl].Cylinder_Retract();

                                if (GlobalVariable.DI[(int)EInput.Work_Conv_1_Pallet_Lift_Cyl_Up])
                                {
                                    Cylinder_config.Cylinders_List[(int)Cylinder_config.Cylinders.Work_Conv_1_Stopper_Cyl].Cylinder_Retract();

                                    if (!blockcreated && GlobalVariable.DI[(int)EInput.Work_Conv_1_Stopper_Cyl_Dn])
                                    {
                                        await createBlock();
                                        blockcreated = true;
                                        step = 30;
                                    }
                                }
                                else if (!GlobalVariable.DI[(int)EInput.Work_Conv_1_Pallet_Lift_Cyl_Up])
                                {
                                    _ = Task.Run(() => Logger.WriteLog(Logger.LogType.Error, "Working1Conveyor", "WorkingCon_Seq", "", "Working1 Pallet Cylinder is not lifted. Check the conveyer !"));
                                    DialogResult result = MessageBox.Show("Working1 Pallet Cylinder is not lifted. Check the conveyer !","Warning...!",MessageBoxButtons.OK,MessageBoxIcon.Warning,MessageBoxDefaultButton.Button1,MessageBoxOptions.ServiceNotification);
                                   
                                    if (result==DialogResult.OK)
                                    {
                                        Cylinder_config.Cylinders_List[(int)Cylinder_config.Cylinders.Work_Conv_1_pallet_Lift_Cyl].Cylinder_Retract();
                                        step = 10;
                                    }
                                }
                                break;

                            case 30:
                                await Logger.WriteLogasTask(Logger.LogType.Running, "WorkingCon_Seq", "Working Conv1", "Working Conveyor1 Camera Scan Started", "");
                                if (GlobalVariable.DI[(int)EInput.Work_Conv_1_Pallet_Lift_Cyl_Up])
                                {
                                    if (!camerascanRuning)
                                    {
                                        camerascanRuning = true;
                                        await CameraScan(token);
                                        step = 40;
                                        camerascanRuning = false;
                                    }
                                }

                                break;

                            case 40:
                                await Logger.WriteLogasTask(Logger.LogType.Running, "WorkingCon_Seq", "Working Conv1", "Working Conveyor1 Moving and Pasting Started", "");

                                if (GlobalVariable.DI[(int)EInput.Work_Conv_1_Pallet_Lift_Cyl_Up])
                                {
                                    firsttimePick = false;
                                    if (!pastingRunning)
                                    {
                                        pastingRunning = true;
                                        await MoveAndPast(token);
                                    }
                                    pastingRunning = false;
                                    step = 50;
                                }

                                break;

                            case 50:
                                await Task.Run(() => ObjectList.Servo_Z2.Move_Abs(GlobalVariable.Z2SafePos, GlobalVariable.Z2Speed, GlobalVariable.Z2Accdec, GlobalVariable.Z2Accdec, 5000, true));
                                ObjectList.Servo_R2.Move_Abs(Convert.ToDouble(GlobalVariable.WK1_initial.PositionR2), Convert.ToDouble(GlobalVariable.WK1_initial.RVel), Convert.ToDouble(GlobalVariable.WK1_initial.RAcc), Convert.ToDouble(GlobalVariable.WK1_initial.ZDeAcc), 15000);
                                await Logger.WriteLogasTask(Logger.LogType.Running, "WorkingCon_Seq", "Working Conv1", "Working Conveyor1 lifting cylinder Down", "");
                                Cylinder_config.Cylinders_List[(int)Cylinder_config.Cylinders.Work_Conv_1_pallet_Lift_Cyl].Cylinder_Retract();
                                step = 51;
                                break;

                            case 51:
                                if(GlobalVariable.g_MachineIoChaged == "Yes" ? GlobalVariable.DI[(int)EInput_1.Work_Conv_1_Pallet_Lift_Cyl_Up] : GlobalVariable.DI[(int)EInput.Work_Conv_1_Pallet_Lift_Cyl_Up]) //bharath
                                {
                                    step = 50;
                                    break;
                                }
                                if (GlobalVariable.g_MachineIoChaged == "Yes" ? !GlobalVariable.DI[(int)EInput_1.Work_Conv_2_Pallet_Inplace_Sen] : !GlobalVariable.DI[(int)EInput.Work_Conv_2_Pallet_Inplace_Sen])
                                {
                                    if (GlobalVariable.g_MachineIoChaged == "Yes" ? GlobalVariable.DI[(int)EInput_1.Work_Conv_2_Stopper_Cyl_Up] : GlobalVariable.DI[(int)EInput.Work_Conv_2_Stopper_Cyl_Up])
                                    {
                                        if (!WorkingConveyor2.running)
                                        {
                                            Exitsen_wok1.Start();
                                            Exitsen_wok1.Restart();
                                            //StepperSystem.MovePlate(new bool?[] { null, null, true, true, true, true });
                                            if (GlobalVariable.ConveyorCount == 4)
                                            {
                                                StepperSystem.MovePlate(new bool?[] { null, null, true, true, null, null });

                                            }
                                            else if (GlobalVariable.ConveyorCount == 6)
                                            {
                                                StepperSystem.MovePlate(new bool?[] { null, null, true, true, true, true });
                                            }
                                            step = 100;
                                        }

                                    }

                                }
                                break;

                            case 100:
                                if (dryrun)
                                {
                                    step = 52;
                                }
                                else
                                {
                                    if (GlobalVariable.DI[(int)EInput.Work_Conv_1_Pallet_Exit_Sen])
                                    {
                                        //GlobalVariable.WorkingStopper_Start = true;
                                        //WorkingStopper.Start();
                                        //WorkingStopper.WorkingStopper_Steep = 0;

                                        step = 101;
                                        Exitsen_wok1.Stop();
                                    }
                                    else
                                    {
                                        if (Exitsen_wok1.ElapsedMilliseconds > GlobalVariable.Working_Conv_1_Exit_Sens_Delay)
                                        {
                                            GlobalVariable.Working_Pallet_NotMoves = true;
                                           _ = Task.Run(() =>Logger.WriteLog(Logger.LogType.Error, "Working1Conveyor", "WorkingCon_Seq", "", "Working 1 Exit Sensor Not Sensed.Pleas Give OK"));
                                            DialogResult res = MessageBox.Show("Working 1 Exit Sensor Not Sensed.Pleas Give OK", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);

                                            if (res == DialogResult.OK)
                                            {
                                                GlobalVariable.Working_Pallet_NotMoves = false;
                                                //StepperSystem.MovePlate(new bool?[] { null, null, true, true, true, true });
                                                if (GlobalVariable.ConveyorCount == 4)
                                                {
                                                    StepperSystem.MovePlate(new bool?[] { null, null, true, true, null, null });

                                                }
                                                else if (GlobalVariable.ConveyorCount == 6)
                                                {
                                                    StepperSystem.MovePlate(new bool?[] { null, null, true, true, true, true });
                                                }
                                                await Task.Delay(1000);

                                                //GlobalVariable.WorkingStopper_Start = true;
                                                //WorkingStopper.Start();
                                                //WorkingStopper.WorkingStopper_Steep = 0;
                                                await Task.Delay(GlobalVariable.Stopper_Working_Time);
                                                Cylinder_config.Cylinders_List[(int)Cylinder_config.Cylinders.Work_Conv_1_Stopper_Cyl].Cylinder_Extend();



                                                Exitsen_wok1.Stop();
                                                step = 52;
                                            }
                                            else
                                            {
                                                //StepperSystem.MovePlate(new bool?[] { null, null, true, true, true, true });
                                                if (GlobalVariable.ConveyorCount == 4)
                                                {
                                                    StepperSystem.MovePlate(new bool?[] { null, null, true, true, null, null });

                                                }
                                                else if (GlobalVariable.ConveyorCount == 6)
                                                {
                                                    StepperSystem.MovePlate(new bool?[] { null, null, true, true, true, true });
                                                }
                                                await Task.Delay(1000);
                                                GlobalVariable.Working_Pallet_NotMoves = false;

                                                //GlobalVariable.WorkingStopper_Start = true;
                                                //WorkingStopper.Start();
                                                //WorkingStopper.WorkingStopper_Steep = 0;
                                                await Task.Delay(GlobalVariable.Stopper_Working_Time);
                                                Cylinder_config.Cylinders_List[(int)Cylinder_config.Cylinders.Work_Conv_1_Stopper_Cyl].Cylinder_Extend();

                                                Exitsen_wok1.Stop();
                                                step = 52;
                                            }



                                        }
                                    }
                                }
                                break;

                            case 101:
                                if (GlobalVariable.ConveyorCount == 4)
                                {
                                    StepperSystem.MovePlate(new bool?[] { null, null, true, true, null, null });

                                }
                                else if (GlobalVariable.ConveyorCount == 6)
                                {
                                    StepperSystem.MovePlate(new bool?[] { null, null, true, true, true, true });
                                }

                                if (!GlobalVariable.DI[(int)EInput.Work_Conv_1_Pallet_Exit_Sen])
                                {
                                    step = 102;
                                }
                                break;

                            case 102:
                                if (GlobalVariable.ConveyorCount == 4)
                                {
                                    StepperSystem.MovePlate(new bool?[] { null, null, true, true, null, null });

                                }
                                else if (GlobalVariable.ConveyorCount == 6)
                                {
                                    StepperSystem.MovePlate(new bool?[] { null, null, true, true, true, true });
                                }

                                if (!GlobalVariable.DI[(int)EInput.Work_Conv_1_Pallet_Exit_Sen] && !GlobalVariable.DI[(int)EInput.Work_Conv_1_Pallet_Inplace_Sen])
                                {
                                    Cylinder_config.Cylinders_List[(int)Cylinder_config.Cylinders.Work_Conv_1_Stopper_Cyl].Cylinder_Extend();

                                    step = 52;
                                }
                                break;


                            case 52:
                                if (GlobalVariable.ConveyorCount == 4)
                                {
                                    StepperSystem.MovePlate(new bool?[] { null, null, true, true, null, null });

                                }
                                else if (GlobalVariable.ConveyorCount == 6)
                                {
                                    StepperSystem.MovePlate(new bool?[] { null, null, true, true, true, true });
                                }
                                if (production)
                                {
                                    if (!GlobalVariable.DI[(int)EInput.Work_Conv_1_Pallet_Inplace_Sen] && !GlobalVariable.DI[(int)EInput.Work_Conv_1_Pallet_Exit_Sen] )
                                    {
                                        if (GlobalVariable.g_MachineIoChaged == "Yes" ? GlobalVariable.DI[(int)EInput_1.Work_Conv_2_Pallet_Inplace_Sen] : GlobalVariable.DI[(int)EInput.Work_Conv_2_Pallet_Inplace_Sen])
                                        {
                                            {
                                                step = 60;
                                            }
                                        }
                                    }
                                    
                                }

                                else
                                {
                                    step = 52;
                                }
                                break;

                            case 60:
                                await Logger.WriteLogasTask(Logger.LogType.Running, "WorkingCon_Seq", "Working Conv1", "Working Conveyor1 Called working Conveyor2", "");
                                if (GlobalVariable.ConveyorCount == 4)
                                {
                                    StepperSystem.MovePlate(new bool?[] { null, null, true, true, null, null });

                                }
                                else if (GlobalVariable.ConveyorCount == 6)
                                {
                                    StepperSystem.MovePlate(new bool?[] { null, null, true, true, true, true });
                                }
                                if (WorkingConveyor2.semaphoreSlimwk2.CurrentCount > 0)
                                {
                                    if (!WorkingConveyor2.running && dryrun)
                                    {
                                        PartData[,] copy = PartData.DeepCopy(data);
                                        _ = Task.Run(async () => await wk2.WorkingCon2_Seq(token, copy));
                                        step = 70;
                                    }
                                    else if (!WorkingConveyor2.running && production)
                                    {
                                        PartData[,] copy = PartData.DeepCopy(data);
                                        _ = Task.Run(async () => await wk2.WorkingCon2_Seq(token, copy));
                                        step = 70;
                                    }
                                }
                                break;

                            case 70:
                                await Logger.WriteLogasTask(Logger.LogType.Running, "WorkingCon_Seq", "Working Conv1", "Working Conveyor1 Stopper Cylinder Down a Conveyor Started", "");
                                Updatedata();
                                step = 80;
                                break;

                            case 80:
                                await Logger.WriteLogasTask(Logger.LogType.Running, "WorkingCon_Seq", "Working Conv1", "Working Conveyor1 gantry Going Fedder Location", "");
                                await GoFeederPlace(token);
                                step = 140;
                                break;

                            case 140:
                                if (await GantrySystem.move(pos[0, 0]))
                                    step = 150;
                                break;

                            case 150:
                                if (dryrun && !WorkingConveyor2.running)
                                {
                                    Cylinder_config.Cylinders_List[(int)Cylinder_config.Cylinders.Work_Conv_1_Stopper_Cyl].Cylinder_Extend();
                                    await Task.Delay(1000);
                                    if (GlobalVariable.ConveyorCount == 4)
                                    {
                                        StepperSystem.MovePlate(new bool?[] { null, null, false, false, null, null });

                                    }
                                    else if (GlobalVariable.ConveyorCount == 6)
                                    {
                                        StepperSystem.MovePlate(new bool?[] { null, null, false, false, false, false });
                                    }
                                    WorkingCon_Seq_completed = false;
                                    blockcreated = false;
                                    ResetCavityWork();
                                    running = false;
                                    currentState = 10;
                                    step = 10;
                                }
                                else if (production)
                                {
                                    // Only do a full reset if this is a clean cycle end
                                    // (not an alarm resume path)
                                    if (!resumeRequired)
                                    {
                                        Data = new PartData[GlobalVariable.CavityRows, GlobalVariable.CavityCols];
                                        WorkingCon_Seq_completed = false;
                                        blockcreated = false;
                                        ResetCavityWork();
                                        running = false;
                                        currentState = 10;
                                        _safeRetryCount = 0;
                                        step = 10;
                                        savedStep = 10;
                                    }
                                    else if (production)
                                    {
                                        Data = new PartData[GlobalVariable.CavityRows, GlobalVariable.CavityCols];
                                        WorkingCon_Seq_completed = false;
                                        blockcreated = false;
                                        ResetCavityWork();
                                        running = false;
                                        currentState = 10;
                                        _safeRetryCount = 0;
                                        step = 10;
                                        savedStep = 10;
                                    }
                                }
                                break;

                            default:
                                Console.WriteLine($"Unknown step: {step}");
                                step = 10;
                                break;
                        }
                    }
                }
            }
            catch (OperationCanceledException)
            {
                await Logger.WriteLogasTask(Logger.LogType.Running, "WorkingCon_Seq", "Working Conv1", "Sequence cancelled by token", "");
            }
            catch (Exception ex)
            {
                await Logger.WriteLogasTask(Logger.LogType.Error, "WorkingCon_Seq", "Working Conv1", ex.ToString(), "");
            }
            finally
            {
                //Arulkumar Fixed random stoppage start
                if (semaphoreHeld)
                {
                    try
                    {
                        semaphoreSlim.Release();
                    }
                    catch (SemaphoreFullException)
                    {
                    }
                }
                //Arulkumar Fixed random stoppage end
            }
        }

        #endregion

        #region CameraScan started
        public async Task CameraScan(CancellationToken token)
        {
            if (pos == null) return;
            int rows = pos.GetLength(0);
            int cols = pos.GetLength(1);

            await Logger.WriteLogasTask(Logger.LogType.Running, "WorkingCon_Seq", "Working Conv1", "ScanCameraData - PreCheck ", "");

            await GantrySystem.TraverseArray(ScanCameraData, rows, cols, token);
            camerascanRuning = false;
        }

        private async Task ScanCameraData(int row, int col)
        {

            if (dryrun)
            {
                await GantrySystem.move(pos[row, col]);
                string cmd1 = "T2,S,1,4,2,4,TEST";
                string ScnrResult = await camera.Trig_Camera(ObjectList.CCD3, cmd1);
            }
            else if (production)
            {

                if (Data[row, col].ScannerData)
                {
                    //Arulkumar Fixed random stoppage start
                    //SafePauseEventWait();  // Cmd by arul 27-08-2026
                    //Arulkumar Fixed random stoppage end
                    if (GlobalVariable.b_gPause)
                    {
                        ConveyorSystem._pauseEvent.WaitOne();
                        //Arulkumar Fixed Hung start
                        await Task.Delay(100);
                        //Arulkumar Fixed Hung end
                        return;
                    }
                    await GantrySystem.Premove(pos[row, col]);
                    await Logger.WriteLogasTask(Logger.LogType.Running, "WorkingCon_Seq", "Working Conv1", "ScanCameraData - PreCheck " + "Premove Row and Col " + pos[row, col] + "", "");

                    pos[row, col].trigger = false;
                    double Xpos = GantrySystem.getcurrentpos(ObjectList.Servo_X1);
                    double Ypos = GantrySystem.getcurrentpos(ObjectList.Servo_Y1);
                    double A1 = GantrySystem.getcurrentpos(ObjectList.Servo_R1);
                    string ScnrResult = "";
                    string cmd1;
                    string dtm1 = DateTime.Now.ToString("HHmmss");

                    ScnrResult = null;
                    cmd1 = null;
                    bool ccdDone = false;
                    retryccd = 0;
                    while (!ccdDone)
                    {

                        if(GlobalVariable.CavityRows == 4 && GlobalVariable.CavityCols == 3)
                        {
                            if (Data[row, col].SNno == null)
                            {
                                if (row == 0 || row == 1)
                                {
                                    cmd1 = "T2,S,1,3,1," + Data[row, col].cavityNo + "," + dtm1 + "_NA_NA," + GlobalVariable.Nozzle_loc_Z1.PositionX + "," + GlobalVariable.Nozzle_loc_Z1.PositionY + "," + GlobalVariable.TrainNozzle1.PositionR1 + "," + pos[row, col].PositionX + "," + pos[row, col].PositionY + ",0," + "0,0,0,1" + ((GlobalVariable.K_Enable) ? ", K" : (GlobalVariable.NK_Enable) ? ", NK" : "");
                                    await Logger.WriteLogasTask(Logger.LogType.Running, " ScanCameraData", "Working Conv1", " Row = " + row + " Col = " + col + " SNno = " + Data[row, col].SNno + " CMD = " + cmd1 + "", "");

                                }
                                else
                                {
                                    cmd1 = "T2,S,1,3,2," + Data[row, col].cavityNo + "," + dtm1 + "_NA_NA," + GlobalVariable.Nozzle_loc_Z2.PositionX + "," + GlobalVariable.Nozzle_loc_Z2.PositionY + "," + GlobalVariable.TrainNozzle1.PositionR1 + "," + pos[row, col].PositionX + "," + pos[row, col].PositionY + ",0," + "0,0,0,1" + ((GlobalVariable.K_Enable) ? ", K" : (GlobalVariable.NK_Enable) ? ", NK" : "");
                                    await Logger.WriteLogasTask(Logger.LogType.Running, " ScanCameraData", "Working Conv1", " Row = " + row + " Col = " + col + " SNno = " + Data[row, col].SNno + " CMD = " + cmd1 + "", "");

                                }
                            }
                            else
                            {
                                if (row == 0 || row == 1)
                                {
                                    cmd1 = "T2,S,1,3,1," + Data[row, col].cavityNo + "," + dtm1 + "_" + Data[row, col].SNno + "," + GlobalVariable.Nozzle_loc_Z1.PositionX + "," + GlobalVariable.Nozzle_loc_Z1.PositionY + "," + GlobalVariable.TrainNozzle1.PositionR1 + "," + pos[row, col].PositionX + "," + pos[row, col].PositionY + ",0," + "0,0,0,1" + ((GlobalVariable.K_Enable) ? ", K" : (GlobalVariable.NK_Enable) ? ", NK" : "");
                                    await Logger.WriteLogasTask(Logger.LogType.Running, " ScanCameraData", "Working Conv1", " Row = " + row + " Col = " + col + " SNno = " + Data[row, col].SNno + " CMD = " + cmd1 + "", "");

                                }
                                else
                                {
                                    cmd1 = "T2,S,1,3,2," + Data[row, col].cavityNo + "," + dtm1 + "_" + Data[row, col].SNno + "," + GlobalVariable.Nozzle_loc_Z2.PositionX + "," + GlobalVariable.Nozzle_loc_Z2.PositionY + "," + GlobalVariable.TrainNozzle1.PositionR1 + "," + pos[row, col].PositionX + "," + pos[row, col].PositionY + ",0," + "0,0,0,1" + ((GlobalVariable.K_Enable) ? ", K" : (GlobalVariable.NK_Enable) ? ", NK" : "");
                                    await Logger.WriteLogasTask(Logger.LogType.Running, " ScanCameraData", "Working Conv1", " Row = " + row + " Col = " + col + " SNno = " + Data[row, col].SNno + " CMD = " + cmd1 + "", "");

                                }
                            }
                        }
                        else if (GlobalVariable.CavityRows == 3 && GlobalVariable.CavityCols == 4)
                        {
                            if (Data[row, col].SNno == null)
                            {
                                if (row == 0 || (row == 2 && col == 0) || (row == 2 && col == 2))
                                {
                                    cmd1 = "T2,S,1,3,1," + Data[row, col].cavityNo + "," + dtm1 + "_NA_NA," + GlobalVariable.Nozzle_loc_Z1.PositionX + "," + GlobalVariable.Nozzle_loc_Z1.PositionY + "," + GlobalVariable.TrainNozzle1.PositionR1 + "," + pos[row, col].PositionX + "," + pos[row, col].PositionY + ",0," + "0,0,0,1" + ((GlobalVariable.K_Enable) ? ", K" : (GlobalVariable.NK_Enable) ? ", NK" : "");
                                    await Logger.WriteLogasTask(Logger.LogType.Running, " ScanCameraData", "Working Conv1", " Row = " + row + " Col = " + col + " SNno = " + Data[row, col].SNno + " CMD = " + cmd1 + "", "");

                                }
                                else if (row == 1 || (row == 2 && col == 1) || (row == 2 && col == 3))
                                {
                                    cmd1 = "T2,S,1,3,2," + Data[row, col].cavityNo + "," + dtm1 + "_NA_NA," + GlobalVariable.Nozzle_loc_Z2.PositionX + "," + GlobalVariable.Nozzle_loc_Z2.PositionY + "," + GlobalVariable.TrainNozzle1.PositionR1 + "," + pos[row, col].PositionX + "," + pos[row, col].PositionY + ",0," + "0,0,0,1" + ((GlobalVariable.K_Enable) ? ", K" : (GlobalVariable.NK_Enable) ? ", NK" : "");
                                    await Logger.WriteLogasTask(Logger.LogType.Running, " ScanCameraData", "Working Conv1", " Row = " + row + " Col = " + col + " SNno = " + Data[row, col].SNno + " CMD = " + cmd1 + "", "");

                                }
                            }
                            else
                            {
                                if (row == 0 || (row == 2 && col == 0) || (row == 2 && col == 2))
                                {
                                    cmd1 = "T2,S,1,3,1," + Data[row, col].cavityNo + "," + dtm1 + "_" + Data[row, col].SNno + "," + GlobalVariable.Nozzle_loc_Z1.PositionX + "," + GlobalVariable.Nozzle_loc_Z1.PositionY + "," + GlobalVariable.TrainNozzle1.PositionR1 + "," + pos[row, col].PositionX + "," + pos[row, col].PositionY + ",0," + "0,0,0,1" + ((GlobalVariable.K_Enable) ? ", K" : (GlobalVariable.NK_Enable) ? ", NK" : "");
                                    await Logger.WriteLogasTask(Logger.LogType.Running, " ScanCameraData", "Working Conv1", " Row = " + row + " Col = " + col + " SNno = " + Data[row, col].SNno + " CMD = " + cmd1 + "", "");

                                }
                                else if (row == 1 || (row == 2 && col == 1) || (row == 2 && col == 3))
                                {
                                    cmd1 = "T2,S,1,3,2," + Data[row, col].cavityNo + "," + dtm1 + "_" + Data[row, col].SNno + "," + GlobalVariable.Nozzle_loc_Z2.PositionX + "," + GlobalVariable.Nozzle_loc_Z2.PositionY + "," + GlobalVariable.TrainNozzle1.PositionR1 + "," + pos[row, col].PositionX + "," + pos[row, col].PositionY + ",0," + "0,0,0,1" + ((GlobalVariable.K_Enable) ? ", K" : (GlobalVariable.NK_Enable) ? ", NK" : "");
                                    await Logger.WriteLogasTask(Logger.LogType.Running, " ScanCameraData", "Working Conv1", " Row = " + row + " Col = " + col + " SNno = " + Data[row, col].SNno + " CMD = " + cmd1 + "", "");

                                }
                            }
                        }

                        await Task.Delay(100);

                        ScnrResult = await camera.Trig_Camera(ObjectList.CCD3, cmd1);
                        await Logger.WriteLogasTask(Logger.LogType.Running, " ScanCameraData", "Working Conv1 ", " Row = " + row + " Col = " + col + " SNno = " + Data[row, col].SNno + " ScnrResult = " + ScnrResult + "", "");

                        Data[row, col].MLBTime_stmp = dtm1;
                        string[] splitdata = ScnrResult.Split(',');
                        //ScnrResult = null;
                        //ScnrResult = "";
                        if (splitdata.Length > 5 && splitdata.Length == 11)
                        {
                            ScnrResult = null;
                            ScnrResult = "";

                            Data[row, col].CCD2receiveX = splitdata[6];
                            Data[row, col].CCD2receiveY = splitdata[7];
                            Data[row, col].CCD2receiveR = splitdata[8];
                            Data[row, col].CCD2receiveError = splitdata[3];
                            if (!Data[row, col].CCD2receiveX.Contains("999.999"))
                            {
                                updatecavity(row, col, Data[row, col].SNno, 1, Data[0, 0].CarrierBarcode);
                                await Logger.WriteLogasTask(Logger.LogType.Running, " ScanCameraData", "Working Conv1 - Pass ", "Row = " + row + " Col = " + col + " SNno = " + Data[row, col].SNno + " CCD2receiveX = " + Data[row, col].CCD2receiveX + " CCD2receiveY = " + Data[row, col].CCD2receiveY + " CCD2receiveR = " + Data[row, col].CCD2receiveR, "");
                                ccdDone = true;
                            }
                            else
                            {
                                updatecavity(row, col, Data[row, col].SNno, 2, Data[0, 0].CarrierBarcode);
                                //MessageBox.Show("Scamera Data pass but return fail.....!");
                                await Logger.WriteLogasTask(Logger.LogType.Running, " ScanCameraData", "Working Conv1 - Fail ", "Row = " + row + " Col = " + col + " SNno = " + Data[row, col].SNno + " CCD2receiveX = " + Data[row, col].CCD2receiveX + " CCD2receiveY = " + Data[row, col].CCD2receiveY + " CCD2receiveR = " + Data[row, col].CCD2receiveR, "");
                                ccdDone = true;
                            }

                        }
                        else if (splitdata.Length < 5)
                        {
                            await Logger.WriteLogasTask(Logger.LogType.Running, " ScanCameraData", "Working Conv1 - Fail and Retry CCD : " + retryccd, "Data Length " + splitdata.Length, "");

                            ScnrResult = null;
                            cmd1 = null;
                            cmd1 = "";
                            ScnrResult = "";
                            retryccd++;
                            if (retryccd < 3)
                            {
                                continue;
                            }
                            retryccd = 0;
                            return;
                        }
                        else if (splitdata.Length > 11)
                        {
                            await Logger.WriteLogasTask(Logger.LogType.Running, " ScanCameraData", "Working Conv1 - Pass : ", "Data Length ( Line 713 )" + splitdata.Length, "");


                            ScnrResult = null;
                            ScnrResult = "";

                            Data[row, col].CCD2receiveX = splitdata[14];
                            Data[row, col].CCD2receiveY = splitdata[15];
                            Data[row, col].CCD2receiveR = splitdata[16];
                            Data[row, col].CCD2receiveError = splitdata[3];
                            if (!Data[row, col].CCD2receiveX.Contains("999.999"))
                            {
                                updatecavity(row, col, Data[row, col].SNno, 1, Data[0, 0].CarrierBarcode);
                                await Logger.WriteLogasTask(Logger.LogType.Running, " ScanCameraData", "Working Conv1 - Pass ", "Row = " + row + " Col = " + col + " SNno = " + Data[row, col].SNno + " CCD2receiveX = " + Data[row, col].CCD2receiveX + " CCD2receiveY = " + Data[row, col].CCD2receiveY + " CCD2receiveR = " + Data[row, col].CCD2receiveR, "");
                                ccdDone = true;
                            }
                            else
                            {
                                updatecavity(row, col, Data[row, col].SNno, 2, Data[0, 0].CarrierBarcode);
                                //MessageBox.Show("Scamera Data pass but return fail.....!");
                                await Logger.WriteLogasTask(Logger.LogType.Running, " ScanCameraData", "Working Conv1 - Fail (LINE 747) ", "Row = " + row + " Col = " + col + " SNno = " + Data[row, col].SNno + " CCD2receiveX = " + Data[row, col].CCD2receiveX + " CCD2receiveY = " + Data[row, col].CCD2receiveY + " CCD2receiveR = " + Data[row, col].CCD2receiveR, "");
                                ccdDone = true;
                            }

                            await Logger.WriteLogasTask(Logger.LogType.Running, " ScanCameraData", "Working Conv1 - Fail and Retry CCD : " + retryccd, "Data Length " + splitdata.Length, "");


                        }
                        else
                        {
                            ccdDone = true;
                            updatecavity(row, col, Data[row, col].SNno, 2, Data[0, 0].CarrierBarcode);
                            await Logger.WriteLogasTask(Logger.LogType.Running, " ScanCameraData", "Working Conv1 - Fail ", "Row = " + row + " Col = " + col + " SNno = " + Data[row, col].SNno + " CCD2receiveX = " + Data[row, col].CCD2receiveX + " CCD2receiveY = " + Data[row, col].CCD2receiveY + " CCD2receiveR = " + Data[row, col].CCD2receiveR, "");


                        }
                    }

                }
                else
                    updatecavity(row, col, "SN", 2, "SN");
            }
        }
        #endregion

        #region Cycle Timer 
        private void Updatedata()
        {
            Cycle_Time.Stop();
            TimeSpan ts = Cycle_Time.Elapsed;
            CT = Math.Round(ts.TotalSeconds, 2);
            GlobalVariable.dGlobal_Cycle_time = CT;
            Cycle_Time.Reset();
        }
        #endregion

        #region Picking and Pasting Graphite
        private async Task MoveAndPast(CancellationToken cts)
        {
            try
            {
                while ((HasN1Cavity || HasN2Cavity) && !cts.IsCancellationRequested)
                {
                    cts.ThrowIfCancellationRequested();
                    //Arulkumar Fixed random stoppage start
                    //SafePauseEventWait();  // // Cmd by arul 27-08-2026
                    //Arulkumar Fixed random stoppage end
                    if (GlobalVariable.b_gPause)
                    {
                        ConveyorSystem._pauseEvent.WaitOne();
                        await Task.Delay(100);
                        continue;
                    }
                    switch (currentState)
                    {
                        // =============== INIT =================
                        case 10:
                            if (!firsttimePick)
                                currentState = 20;
                            else
                                currentState = 70;

                            GlobalVariable.Nozzletossing = 0;
                            break;

                        // =============== MOVE TO CCD POSITIONS =================
                        case 20:
                            try
                            {
                                if (dryrun)
                                {
                                    await GantrySystem.GoWK1Z1CCD2Pos();
                                    string cmd1 = "T1,S,1,4,2,3,TEST";
                                    string camdata = await camera.Trig_Camera(ObjectList.CCD2, cmd1);
                                    await GantrySystem.GoWK1Z2CCD2Pos();
                                    string camdata1 = await camera.Trig_Camera(ObjectList.CCD2, cmd1);
                                    currentState = 30;
                                    break;
                                }
                                if (HasN1Cavity)
                                {
                                    //GlobalVariable.LoadReceipe(); // Add by Arulkumar 25-07-2026
                                    Data[N1Cell.row, N1Cell.col].FedTime_stmp = fedTime_stmp;
                                    if (Data[N1Cell.row, N1Cell.col].CCD2receiveX != null)
                                    {
                                        if ((!Data[N1Cell.row, N1Cell.col].CCD2receiveX.Contains("999.999") ||
                                            Data[N1Cell.row, N1Cell.col].CCD2receiveError.Contains("0")))
                                        {
                                            if (!PeekN1Pos.trigger || GlobalVariable.Z1_Pickedup)
                                            {
                                                await GantrySystem.move(GlobalVariable.Wk1_Z1CCD2pos);
                                                await Task.Run(() => NozzleSystem.Nozzle1MoveDown(GlobalVariable.TrainNozzle1));
                                                await GantrySystem.MoveR1(GlobalVariable.TrainNozzle1);
                                                await Task.Delay(20);
                                                if (production)
                                                {
                                                    camdata_1 = null;
                                                    cmd1_1 = "";
                                                    try
                                                    {

                                                        //Arulkumar Fixed Hung start

                                                        await Task.Delay(50);
                                                        //Arulkumar Fixed Hung end


                                                        double Xpos_1 = GantrySystem.getcurrentpos(ObjectList.Servo_X1);
                                                        double Ypos1 = GantrySystem.getcurrentpos(ObjectList.Servo_Y1);
                                                        double A1_1 = GantrySystem.getcurrentpos(ObjectList.Servo_R1);

                                                        if (Data[N1Cell.row, N1Cell.col].SNno == null)
                                                        {
                                                            cmd1_1 = "T1,S,1,3,1," + Data[N1Cell.row, N1Cell.col].cavityNo + "," + dtm + "_NA," + GlobalVariable.TrainNozzle1.PositionX + "," + GlobalVariable.TrainNozzle1.PositionY + "," + GlobalVariable.TrainNozzle1.PositionR1 + "," + pos[N1Cell.row, N1Cell.col].PositionX + "," + pos[N1Cell.row, N1Cell.col].PositionY + "," + pos[N1Cell.row, N1Cell.col].PositionR1 + "," + Data[N1Cell.row, N1Cell.col].CCD2receiveX + "," + Data[N1Cell.row, N1Cell.col].CCD2receiveY + "," + Data[N1Cell.row, N1Cell.col].CCD2receiveR + ((GlobalVariable.K_Enable) ? ", K" : (GlobalVariable.NK_Enable) ? ", NK" : "");
                                                            await Logger.WriteLogasTask(Logger.LogType.Running, "WorkingConveyor 1", "WorkingConveyor 1", "currentState 20 " + "Nozzle1 Cmd : " + cmd1_1, "");


                                                        }
                                                        else
                                                        {
                                                            cmd1_1 = "T1,S,1,3,1," + Data[N1Cell.row, N1Cell.col].cavityNo + "," + dtm + "_" + Data[N1Cell.row, N1Cell.col].SNno + "," + GlobalVariable.TrainNozzle1.PositionX + "," + GlobalVariable.TrainNozzle1.PositionY + "," + GlobalVariable.TrainNozzle1.PositionR1 + "," + pos[N1Cell.row, N1Cell.col].PositionX + "," + pos[N1Cell.row, N1Cell.col].PositionY + "," + pos[N1Cell.row, N1Cell.col].PositionR1 + "," + Data[N1Cell.row, N1Cell.col].CCD2receiveX + "," + Data[N1Cell.row, N1Cell.col].CCD2receiveY + "," + Data[N1Cell.row, N1Cell.col].CCD2receiveR + ((GlobalVariable.K_Enable) ? ", K" : (GlobalVariable.NK_Enable) ? ", NK" : "");
                                                            await Logger.WriteLogasTask(Logger.LogType.Running, "WorkingConveyor 1", "WorkingConveyor 1", "currentState 20 " + "Nozzle1 Cmd : " + cmd1_1, "");
                                                        }
                                                        camdata_1 = await camera.Trig_Camera(ObjectList.CCD2, cmd1_1);

                                                        await Logger.WriteLogasTask(Logger.LogType.Running, "WorkingConveyor 1", "WorkingConveyor 1", "currentState 20 " + "Camera Tigger Result : " + camdata_1, "");


                                                        if (camdata_1 == null || camdata_1 == "null" || camdata_1 == "")
                                                        {
                                                            camdata_1 = "";
                                                            break;
                                                        }

                                                        Data[N1Cell.row, N1Cell.col].NLTime_stmp = dtm;
                                                        PeekN1Pos.trigger = true;
                                                        GlobalVariable.Z1_Pickedup = false;
                                                        Z1_Triggered_the_Nozzle_1 = true;
                                                        ccd2nozzle1 = camdata_1.Split(',');
                                                        //if (ccd2nozzle1.Length > 3)
                                                        //    n1Toss = ccd2nozzle1[3] == "0"; //cmd by Arul
                                                        camdata_1 = "";

                                                    }
                                                    catch (Exception ex)
                                                    {
                                                        await Logger.WriteLogasTask(Logger.LogType.Running, "Working Conveyor1", "Working Conveyor1", "Nozzle 1 exited. Raising CDD3 Tigger.", "");
                                                    }


                                                    // Guard: check array length before indexing
                                                    if (ccd2nozzle1 == null)
                                                    {
                                                        PeekN1Pos.trigger = false;
                                                        nozzle1Graphhitetaken = false;
                                                        i_rejection = 10;

                                                        if (GlobalVariable.Nozzletossing < 3)
                                                        {
                                                            await Logger.WriteLogasTask(Logger.LogType.Running, "WorkingConveyor 1", "WorkingConveyor 1", "currentState 20 " + "GoRejectionPlace ", "");

                                                            await GoRejectionPlace(cts);

                                                        }
                                                        else
                                                        {

                                                            GlobalVariable.tossingBuzzer = true;
                                                            MessageBox.Show("Nozzle Reached Max Tossing Limit ", "Warring", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);
                                                            Task.Run(() => Logger.WriteLog(Logger.LogType.Error, "Working1Conveyor", "MoveAndPaste", "", "Nozzle Reached Max Tossing Limit"));
                                                            await Logger.WriteLogasTask(Logger.LogType.Running, "WorkingConveyor 1", "WorkingConveyor 1", "currentState 20 " + " Message Box Nozzle Reached Max Tossing Limit  ", "");
                                                            GlobalVariable.tossingBuzzer = false;

                                                            await Logger.WriteLogasTask(Logger.LogType.Running, "WorkingConveyor 1", "WorkingConveyor 1", "currentState 20 " + "GoRejectionPlace ", "");
                                                            await GoRejectionPlace(cts);
                                                            GlobalVariable.Nozzletossing = 0;
                                                        }
                                                        break;
                                                    }
                                                    else if (ccd2nozzle1.Length < 9 || ccd2nozzle1.Length > 9)
                                                    {
                                                        PeekN1Pos.trigger = false;
                                                        nozzle1Graphhitetaken = false;
                                                        i_rejection = 10;
                                                        GlobalVariable.Nozzletossing++;
                                                        if (GlobalVariable.Nozzletossing < 3)
                                                        {
                                                            await Logger.WriteLogasTask(Logger.LogType.Running, "WorkingConveyor 1", "WorkingConveyor 1", "currentState 20 " + "GoRejectionPlace ", "");

                                                            await GoRejectionPlace(cts);

                                                        }
                                                        else
                                                        {

                                                            GlobalVariable.tossingBuzzer = true;
                                                            MessageBox.Show("Nozzle Reached Max Tossing Limit ", "Warring", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);
                                                            Task.Run(() => Logger.WriteLog(Logger.LogType.Error, "Working1Conveyor", "MoveAndPaste", "", "Nozzle Reached Max Tossing Limit"));
                                                            await Logger.WriteLogasTask(Logger.LogType.Running, "WorkingConveyor 1", "WorkingConveyor 1", "currentState 20 " + " Message Box Nozzle Reached Max Tossing Limit  ", "");
                                                            GlobalVariable.tossingBuzzer = false;

                                                            await Logger.WriteLogasTask(Logger.LogType.Running, "WorkingConveyor 1", "WorkingConveyor 1", "currentState 20 " + "GoRejectionPlace ", "");
                                                            await GoRejectionPlace(cts);
                                                            GlobalVariable.Nozzletossing = 0;
                                                        }

                                                        //await GoRejectionPlace(cts);
                                                        break;
                                                    }
                                                    else if ((ccd2nozzle1[0] == null || ccd2nozzle1[1] == null || ccd2nozzle1[2] == null || ccd2nozzle1[4] == null || ccd2nozzle1[5] == null || ccd2nozzle1[6] == null || ccd2nozzle1[7] == null || ccd2nozzle1[8] == null))
                                                    {
                                                        PeekN1Pos.trigger = false;
                                                        nozzle1Graphhitetaken = false;
                                                        i_rejection = 10;

                                                        if (GlobalVariable.Nozzletossing < 3)
                                                        {
                                                            await Logger.WriteLogasTask(Logger.LogType.Running, "WorkingConveyor 1", "WorkingConveyor 1", "currentState 20 " + "GoRejectionPlace ", "");

                                                            await GoRejectionPlace(cts);

                                                        }
                                                        else
                                                        {

                                                            GlobalVariable.tossingBuzzer = true;
                                                            MessageBox.Show("Nozzle Reached Max Tossing Limit ", "Warring", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);
                                                            _=Task.Run(() => Logger.WriteLog(Logger.LogType.Error, "Working1Conveyor", "MoveAndPaste", "", "Nozzle Reached Max Tossing Limit"));
                                                            await Logger.WriteLogasTask(Logger.LogType.Running, "WorkingConveyor 1", "WorkingConveyor 1", "currentState 20 " + " Message Box Nozzle Reached Max Tossing Limit  ", "");
                                                            GlobalVariable.tossingBuzzer = false;

                                                            await Logger.WriteLogasTask(Logger.LogType.Running, "WorkingConveyor 1", "WorkingConveyor 1", "currentState 20 " + "GoRejectionPlace ", "");
                                                            await GoRejectionPlace(cts);
                                                            GlobalVariable.Nozzletossing = 0;
                                                        }
                                                        break;
                                                    }
                                                    else if (ccd2nozzle1.Length > 7 && ccd2nozzle1[7].Contains("-1"))
                                                    {
                                                        PeekN1Pos.trigger = false;
                                                        nozzle1Graphhitetaken = false;
                                                        i_rejection = 10;
                                                        //await GoRejectionPlace(cts);
                                                        GlobalVariable.Nozzletossing++;
                                                        if (GlobalVariable.Nozzletossing < 3)
                                                        {
                                                            await Logger.WriteLogasTask(Logger.LogType.Running, "WorkingConveyor 1", "WorkingConveyor 1", "currentState 20 " + "GoRejectionPlace ", "");

                                                            await GoRejectionPlace(cts);

                                                        }
                                                        else
                                                        {

                                                            GlobalVariable.tossingBuzzer = true;
                                                            MessageBox.Show("Nozzle Reached Max Tossing Limit ", "Warring", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);
                                                            _=Task.Run(() => Logger.WriteLog(Logger.LogType.Error, "Working1Conveyor", "MoveAndPaste", "", "Nozzle Reached Max Tossing Limit"));
                                                            await Logger.WriteLogasTask(Logger.LogType.Running, "WorkingConveyor 1", "WorkingConveyor 1", "currentState 20 " + " Message Box Nozzle Reached Max Tossing Limit  ", "");
                                                            GlobalVariable.tossingBuzzer = false;

                                                            await Logger.WriteLogasTask(Logger.LogType.Running, "WorkingConveyor 1", "WorkingConveyor 1", "currentState 20 " + "GoRejectionPlace ", "");
                                                            await GoRejectionPlace(cts);
                                                            GlobalVariable.Nozzletossing = 0;
                                                        }
                                                        break;
                                                    }
                                                }
                                                await Task.Run(() => NozzleSystem.Nozzle1Moveup(GlobalVariable.TrainNozzle1));
                                            }
                                            else if (!HasN2Cavity)
                                            {
                                                currentState = 30;
                                                await Logger.WriteLogasTask(Logger.LogType.Running, "WorkingConveyor 1", "Nozzle 1", "currentState 20 " + RemainingN2Count.ToString(), "");


                                            }
                                        }
                                        else
                                        {
                                            updatecavity(N1Cell.row, N1Cell.col, Data[N1Cell.row, N1Cell.col].SNno, 2, Data[0, 0].CarrierBarcode);
                                            AdvanceN1Cavity();
                                            await Logger.WriteLogasTask(Logger.LogType.Running, "WorkingConveyor 1", "Nozzle 2", "currentState 20  Z1:Dequeue: " + RemainingN1Count.ToString(), "");


                                            currentState = 20;
                                            break;
                                        }
                                    }
                                    else
                                    {
                                        updatecavity(N1Cell.row, N1Cell.col, Data[N1Cell.row, N1Cell.col].SNno, 2, Data[0, 0].CarrierBarcode);
                                        AdvanceN1Cavity();
                                        await Logger.WriteLogasTask(Logger.LogType.Running, "WorkingConveyor 1", "Nozzle 2", "currentState 20  Z1:Dequeue: " + RemainingN1Count.ToString(), "");

                                        currentState = 20;
                                        break;
                                    }
                                }
                                if (HasN2Cavity)
                                {
                                    //GlobalVariable.LoadReceipe(); // Add by Arulkumar 25-07-2026
                                    Data[N2Cell.row, N2Cell.col].FedTime_stmp = fedTime_stmp;
                                    if (Data[N2Cell.row, N2Cell.col].CCD2receiveError != null)
                                    {
                                        if (!Data[N2Cell.row, N2Cell.col].CCD2receiveX.Contains("999.999") || Data[N2Cell.row, N2Cell.col].CCD2receiveError.Contains("0"))
                                        {
                                            if (!PeekN2Pos.trigger || GlobalVariable.Z2_Pickedup)
                                            {
                                                await GantrySystem.move(GlobalVariable.Wk1_Z2CCD2pos);
                                                await Task.Run(() => NozzleSystem.Nozzle2MoveDown(GlobalVariable.TrainNozzle2));
                                                await GantrySystem.MoveR2(GlobalVariable.TrainNozzle2);
                                                await Task.Delay(20);
                                                if (production)
                                                {
                                                    cmd2_1 = "";
                                                    camdata_2 = null;
                                                    try
                                                    {

                                                        //Arulkumar Fixed Hung start

                                                        await Task.Delay(50);
                                                        //Arulkumar Fixed Hung end



                                                        double Xpos_1 = GantrySystem.getcurrentpos(ObjectList.Servo_X1);
                                                        double Ypos_1 = GantrySystem.getcurrentpos(ObjectList.Servo_Y1);
                                                        double A1_1 = GantrySystem.getcurrentpos(ObjectList.Servo_R1);

                                                        if (Data[N2Cell.row, N2Cell.col].SNno == null)
                                                        {
                                                            cmd2_1 = "T1,S,1,3,2," + Data[N2Cell.row, N2Cell.col].cavityNo + "," + dtm + "_NA," + GlobalVariable.TrainNozzle2.PositionX + "," + GlobalVariable.TrainNozzle2.PositionY + "," + GlobalVariable.TrainNozzle2.PositionR2 + "," + pos[N2Cell.row, N2Cell.col].PositionX + "," + pos[N2Cell.row, N2Cell.col].PositionY + "," + pos[N2Cell.row, N2Cell.col].PositionR1 + "," + Data[N2Cell.row, N2Cell.col].CCD2receiveX + "," + Data[N2Cell.row, N2Cell.col].CCD2receiveY + "," + Data[N2Cell.row, N2Cell.col].CCD2receiveR + ((GlobalVariable.K_Enable) ? ", K" : (GlobalVariable.NK_Enable) ? ", NK" : "");
                                                            await Logger.WriteLogasTask(Logger.LogType.Running, "WorkingConveyor 1", "WorkingConveyor 1", "currentState 20 " + "Nozzle2 Cmd : " + cmd1_1, "");

                                                        }
                                                        else
                                                        {
                                                            cmd2_1 = "T1,S,1,3,2," + Data[N2Cell.row, N2Cell.col].cavityNo + "," + dtm + "_" + Data[N2Cell.row, N2Cell.col].SNno + "," + GlobalVariable.TrainNozzle2.PositionX + "," + GlobalVariable.TrainNozzle2.PositionY + "," + GlobalVariable.TrainNozzle2.PositionR2 + "," + pos[N2Cell.row, N2Cell.col].PositionX + "," + pos[N2Cell.row, N2Cell.col].PositionY + "," + pos[N2Cell.row, N2Cell.col].PositionR1 + "," + Data[N2Cell.row, N2Cell.col].CCD2receiveX + "," + Data[N2Cell.row, N2Cell.col].CCD2receiveY + "," + Data[N2Cell.row, N2Cell.col].CCD2receiveR + ((GlobalVariable.K_Enable) ? ", K" : (GlobalVariable.NK_Enable) ? ", NK" : "");
                                                            await Logger.WriteLogasTask(Logger.LogType.Running, "WorkingConveyor 1", "WorkingConveyor 1", "currentState 20 " + "Nozzle2 Cmd : " + cmd1_1, "");


                                                        }

                                                        camdata_2 = await camera.Trig_Camera(ObjectList.CCD2, cmd2_1);
                                                        await Logger.WriteLogasTask(Logger.LogType.Running, "WorkingConveyor 1", "WorkingConveyor 1", "currentState 20 " + "Camera Tigger Result : " + cmd2_1, "");


                                                        if (camdata_2 == null || camdata_2 == "null" || camdata_2 == "")
                                                        {
                                                            camdata_2 = "";
                                                            break;
                                                        }

                                                        Data[N2Cell.row, N2Cell.col].NLTime_stmp = dtm;
                                                        ccd2nozle2 = camdata_2.Split(',');
                                                        //if (ccd2nozle2.Length > 3)
                                                        //{
                                                        //    n2Toss = ccd2nozle2[3] == "0"; //cmd by arul
                                                        //}
                                                        PeekN2Pos.trigger = true;
                                                        Z2_Trigger_While = true;
                                                        Z2_Triggered_the_Nozzle_2 = true;
                                                        Z2_Trigger_Step = 0;
                                                        GlobalVariable.Z2_Pickedup = false;
                                                        camdata_2 = "";




                                                    }
                                                    catch (Exception ex)
                                                    {
                                                        await Logger.WriteLogasTask(Logger.LogType.Running, "Working Conveyor2", "Working Conveyor2", "Nozzle 2, CCD3 Tigger.", "");

                                                    }

                                                    // Guard: check array length before indexing
                                                    if (ccd2nozle2 == null)
                                                    {
                                                        PeekN2Pos.trigger = false;
                                                        nozzle2Graphhitetaken = false;
                                                        i_rejection = 10;
                                                        GlobalVariable.Nozzletossing++;
                                                        if (GlobalVariable.Nozzletossing < 3)
                                                        {
                                                            await Logger.WriteLogasTask(Logger.LogType.Running, "WorkingConveyor 1", "WorkingConveyor 1", "currentState 20 " + "GoRejectionPlace ", "");

                                                            await GoRejectionPlace(cts);

                                                        }
                                                        else
                                                        {

                                                            GlobalVariable.tossingBuzzer = true;
                                                            MessageBox.Show("Nozzle Reached Max Tossing Limit ", "Warring", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);
                                                            Task.Run(() => Logger.WriteLog(Logger.LogType.Error, "Working1Conveyor", "MoveAndPaste", "", "Nozzle Reached Max Tossing Limit"));
                                                            await Logger.WriteLogasTask(Logger.LogType.Running, "WorkingConveyor 1", "WorkingConveyor 1", "currentState 20 " + " Message Box Nozzle Reached Max Tossing Limit  ", "");
                                                            GlobalVariable.tossingBuzzer = false;

                                                            await Logger.WriteLogasTask(Logger.LogType.Running, "WorkingConveyor 1", "WorkingConveyor 1", "currentState 20 " + "GoRejectionPlace ", "");
                                                            await GoRejectionPlace(cts);
                                                            GlobalVariable.Nozzletossing = 0;
                                                        }
                                                        break;
                                                    }
                                                    else if (ccd2nozle2.Length < 9 || ccd2nozle2.Length > 9)
                                                    {
                                                        PeekN2Pos.trigger = false;
                                                        nozzle2Graphhitetaken = false;
                                                        i_rejection = 10;
                                                        //await GoRejectionPlace(cts);
                                                        GlobalVariable.Nozzletossing++;
                                                        if (GlobalVariable.Nozzletossing < 3)
                                                        {
                                                            await Logger.WriteLogasTask(Logger.LogType.Running, "WorkingConveyor 1", "WorkingConveyor 1", "currentState 20 " + "GoRejectionPlace ", "");

                                                            await GoRejectionPlace(cts);

                                                        }
                                                        else
                                                        {

                                                            GlobalVariable.tossingBuzzer = true;
                                                            MessageBox.Show("Nozzle Reached Max Tossing Limit ", "Warring", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);
                                                            Task.Run(() => Logger.WriteLog(Logger.LogType.Error, "Working1Conveyor", "MoveAndPaste", "", "Nozzle Reached Max Tossing Limit"));
                                                            await Logger.WriteLogasTask(Logger.LogType.Running, "WorkingConveyor 1", "WorkingConveyor 1", "currentState 20 " + " Message Box Nozzle Reached Max Tossing Limit  ", "");
                                                            GlobalVariable.tossingBuzzer = false;

                                                            await Logger.WriteLogasTask(Logger.LogType.Running, "WorkingConveyor 1", "WorkingConveyor 1", "currentState 20 " + "GoRejectionPlace ", "");
                                                            await GoRejectionPlace(cts);
                                                            GlobalVariable.Nozzletossing = 0;
                                                        }

                                                        break;
                                                    }
                                                    else if ((ccd2nozle2[0] == null || ccd2nozle2[1] == null || ccd2nozle2[2] == null || ccd2nozle2[4] == null || ccd2nozle2[5] == null || ccd2nozle2[6] == null || ccd2nozle2[7] == null || ccd2nozle2[8] == null))
                                                    {

                                                        PeekN2Pos.trigger = false;
                                                        nozzle2Graphhitetaken = false;
                                                        i_rejection = 10;
                                                        //await GoRejectionPlace(cts);
                                                        GlobalVariable.Nozzletossing++;
                                                        if (GlobalVariable.Nozzletossing < 3)
                                                        {
                                                            await GoRejectionPlace(cts);

                                                        }
                                                        else
                                                        {
                                                            GlobalVariable.tossingBuzzer = true;
                                                            MessageBox.Show("Nozzle Reached Max Tossing Limit ", "Warring", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);
                                                            _ = Task.Run(() => Logger.WriteLog(Logger.LogType.Error, "Working1Conveyor", "MoveAndPaste", "", "Nozzle Reached Max Tossing Limit"));
                                                            GlobalVariable.tossingBuzzer = false;
                                                            await GoRejectionPlace(cts);
                                                            GlobalVariable.Nozzletossing = 0;
                                                        }

                                                        break;
                                                    }
                                                    else if (ccd2nozle2.Length > 7 && ccd2nozle2[7].Contains("-1"))
                                                    {
                                                        PeekN2Pos.trigger = false;
                                                        nozzle2Graphhitetaken = false;
                                                        i_rejection = 10;
                                                        //await GoRejectionPlace(cts);
                                                        GlobalVariable.Nozzletossing++;
                                                        if (GlobalVariable.Nozzletossing < 3)
                                                        {
                                                            await Logger.WriteLogasTask(Logger.LogType.Running, "WorkingConveyor 1", "WorkingConveyor 1", "currentState 20 " + "GoRejectionPlace ", "");

                                                            await GoRejectionPlace(cts);

                                                        }
                                                        else
                                                        {

                                                            GlobalVariable.tossingBuzzer = true;
                                                            MessageBox.Show("Nozzle Reached Max Tossing Limit ", "Warring", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);
                                                            _ = Task.Run(() => Logger.WriteLog(Logger.LogType.Error, "Working1Conveyor", "MoveAndPaste", "", "Nozzle Reached Max Tossing Limit"));
                                                            await Logger.WriteLogasTask(Logger.LogType.Running, "WorkingConveyor 1", "WorkingConveyor 1", "currentState 20 " + " Message Box Nozzle Reached Max Tossing Limit  ", "");
                                                            GlobalVariable.tossingBuzzer = false;

                                                            await Logger.WriteLogasTask(Logger.LogType.Running, "WorkingConveyor 1", "WorkingConveyor 1", "currentState 20 " + "GoRejectionPlace ", "");
                                                            await GoRejectionPlace(cts);
                                                            GlobalVariable.Nozzletossing = 0;
                                                        }
                                                        break;
                                                    }
                                                }
                                                await Task.Run(() => NozzleSystem.Nozzle2Moveup(GlobalVariable.TrainNozzle2));
                                                currentState = 30;
                                            }
                                        }
                                        else
                                        {
                                            updatecavity(N2Cell.row, N2Cell.col, Data[N2Cell.row, N2Cell.col].SNno, 2, Data[0, 0].CarrierBarcode);
                                            AdvanceN2Cavity();
                                            await Logger.WriteLogasTask(Logger.LogType.Running, "WorkingConveyor 1", "Nozzle 2", "currentState 20  Z2:Dequeue: " + RemainingN1Count.ToString(), "");

                                            currentState = 20;
                                            break;
                                        }
                                    }
                                    else
                                    {
                                        updatecavity(N2Cell.row, N2Cell.col, Data[N2Cell.row, N2Cell.col].SNno, 2, Data[0, 0].CarrierBarcode);
                                        AdvanceN2Cavity();
                                        await Logger.WriteLogasTask(Logger.LogType.Running, "WorkingConveyor 1", "Nozzle 2", "currentState 20  Z2:Dequeue: " + RemainingN1Count.ToString(), "");

                                        currentState = 20;
                                        break;
                                    }
                                }
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("error" + ex);
                            }
                            break;

                        // =============== MOVE Z1 TO TARGET =================
                        case 30:
                            await Logger.WriteLogasTask(Logger.LogType.Running, "MoveAndPast", "Working Conv1", "Nozzle 1 Moving For Pasting", "");
                            if (dryrun)
                            {
                                if (HasN1Cavity)
                                    _ = Task.Run(() => ObjectList.Servo_R1.Move_Abs(Convert.ToDouble(PeekN1Pos.PositionR1), Convert.ToDouble(PeekN1Pos.RVel), Convert.ToDouble(PeekN1Pos.RAcc), Convert.ToDouble(PeekN1Pos.RDeAcc), 15000));
                                if (HasN2Cavity)
                                    _ = Task.Run(() => ObjectList.Servo_R2.Move_Abs(Convert.ToDouble(PeekN2Pos.PositionR2), Convert.ToDouble(PeekN2Pos.RVel), Convert.ToDouble(PeekN2Pos.RAcc), Convert.ToDouble(PeekN2Pos.RDeAcc), 15000));

                                if (await GantrySystem.move(PeekN1Pos, PeekN1Pos.CavityX, PeekN1Pos.CavityY))
                                {
                                    if (Safe(PeekN1Pos.CavityX, GantrySystem.getcurrentpos(ObjectList.Servo_X1), currentState, step) &&
                                        Safe(PeekN1Pos.CavityY, GantrySystem.getcurrentpos(ObjectList.Servo_Y1), currentState, step))
                                    {
                                        _safeRetryCount = 0;
                                        currentState = 40;

                                    }
                                    else
                                    {
                                        // Safe() already saved state & fired alarm
                                        // Just break and wait for operator reset+restart
                                        break;
                                    }
                                }
                            }
                            else if (production)
                            {
                                Z1_Trigger_While = false;
                                Z2_Trigger_While = false;

                                if (ccd2nozzle1 != null && ccd2nozzle1.Length > 6 && ccd2nozzle1[6] != null)
                                {
                                    if (!ccd2nozzle1[6].Contains("999.999") && HasN1Cavity)
                                    {
                                        _ = Task.Run(() => GantrySystem.MoveR1(PeekN1Pos, double.Parse(ccd2nozzle1[6]) + (
                                                                                    GlobalVariable.K_Enable ? GlobalVariable.offsetK[Data[N1Cell.row, N1Cell.col].cavityNo - 1].Rvalue :
                                                                                    GlobalVariable.NK_Enable ? GlobalVariable.offsetNK[Data[N1Cell.row, N1Cell.col].cavityNo - 1].Rvalue :
                                                                                    GlobalVariable.offset[Data[N1Cell.row, N1Cell.col].cavityNo - 1].Rvalue)));

                                        await Logger.WriteLogasTask(Logger.LogType.Running, "WorkingConveyor 1", "R1", "currentState 30 ", "");

                                    }

                                    if (ccd2nozle2 != null && ccd2nozle2.Length > 6 && ccd2nozle2[6] != null)
                                    {

                                        if (!ccd2nozle2[6].Contains("999.999") && HasN2Cavity)
                                        {
                                            _ = Task.Run(() => GantrySystem.MoveR2(PeekN2Pos, double.Parse(ccd2nozle2[6]) + (
                                                                                            GlobalVariable.K_Enable ? GlobalVariable.offsetK[Data[N2Cell.row, N2Cell.col].cavityNo - 1].Rvalue :
                                                                                            GlobalVariable.NK_Enable ? GlobalVariable.offsetNK[Data[N2Cell.row, N2Cell.col].cavityNo - 1].Rvalue :
                                                                                            GlobalVariable.offset[Data[N2Cell.row, N2Cell.col].cavityNo - 1].Rvalue)));

                                            await Logger.WriteLogasTask(Logger.LogType.Running, "WorkingConveyor 1", "R2", "currentState 30 ", "");

                                        }
                                    }

                                    //await Logger.WriteLogasTask(Logger.LogType.Running, "Nozzle1", "Working Con1 ", "R1:Offset:" + (PeekN1Pos, double.Parse(ccd2nozzle1[6]) + GlobalVariable.offset[Data[N1Cell.row, N1Cell.col].cavityNo - 1].Rvalue), "");
                                    // await Logger.WriteLogasTask(Logger.LogType.Running, "Nozzle2", "Working Con1 ", "R2:Offset1:" + (PeekN2Pos, double.Parse(ccd2nozle2[6]) + GlobalVariable.offset[Data[N2Cell.row, N2Cell.col].cavityNo - 1].Rvalue), "");

                                    if (ccd2nozzle1.Length > 5 &&
                                        Safe(PeekN1Pos.CavityX, double.Parse(ccd2nozzle1[4]), currentState, step) &&
                                        Safe(PeekN1Pos.CavityY, double.Parse(ccd2nozzle1[5]), currentState, step))
                                    {
                                        await Logger.WriteLogasTask(Logger.LogType.Running, "Nozzle1", "Working Con1 ", "X,Y:Offset:" + (PeekN1Pos, double.Parse(ccd2nozzle1[4]) +

                                                                                    (GlobalVariable.K_Enable ? GlobalVariable.offsetK[Data[N1Cell.row, N1Cell.col].cavityNo - 1].Xvalue :
                                                                                    GlobalVariable.NK_Enable ? GlobalVariable.offsetNK[Data[N1Cell.row, N1Cell.col].cavityNo - 1].Xvalue :
                                                                                    GlobalVariable.offset[Data[N1Cell.row, N1Cell.col].cavityNo - 1].Xvalue), double.Parse(ccd2nozzle1[5]) +

                                                                                    (GlobalVariable.K_Enable ? GlobalVariable.offsetK[Data[N1Cell.row, N1Cell.col].cavityNo - 1].Yvalue :
                                                                                    GlobalVariable.NK_Enable ? GlobalVariable.offsetNK[Data[N1Cell.row, N1Cell.col].cavityNo - 1].Yvalue :
                                                                                    GlobalVariable.offset[Data[N1Cell.row, N1Cell.col].cavityNo - 1].Yvalue)), "");

                                        if (await GantrySystem.move(PeekN1Pos, double.Parse(ccd2nozzle1[4]) + (
                                           GlobalVariable.K_Enable ? GlobalVariable.offsetK[Data[N1Cell.row, N1Cell.col].cavityNo - 1].Xvalue :
                                           GlobalVariable.NK_Enable ? GlobalVariable.offsetNK[Data[N1Cell.row, N1Cell.col].cavityNo - 1].Xvalue :
                                           GlobalVariable.offset[Data[N1Cell.row, N1Cell.col].cavityNo - 1].Xvalue), double.Parse(ccd2nozzle1[5]) +

                                           (
                                           GlobalVariable.K_Enable ? GlobalVariable.offsetK[Data[N1Cell.row, N1Cell.col].cavityNo - 1].Yvalue :
                                           GlobalVariable.NK_Enable ? GlobalVariable.offsetNK[Data[N1Cell.row, N1Cell.col].cavityNo - 1].Yvalue :
                                           GlobalVariable.offset[Data[N1Cell.row, N1Cell.col].cavityNo - 1].Yvalue)))
                                        {
                                            if (Z1_Triggered_the_Nozzle_1)
                                            {
                                                Z1_Triggered_the_Nozzle_1 = false;
                                                if (ccd2nozzle1[6] != null)
                                                {
                                                    if (!ccd2nozzle1[6].Contains("999.999") && HasN1Cavity)
                                                    {
                                                        double s = 0;

                                                        s = double.Parse(ccd2nozzle1[6]) + (
                                                            GlobalVariable.K_Enable ? GlobalVariable.offsetK[Data[N1Cell.row, N1Cell.col].cavityNo - 1].Rvalue :
                                                            GlobalVariable.NK_Enable ? GlobalVariable.offsetNK[Data[N1Cell.row, N1Cell.col].cavityNo - 1].Rvalue :
                                                            GlobalVariable.offset[Data[N1Cell.row, N1Cell.col].cavityNo - 1].Rvalue);
                                                        if (ObjectList.Servo_R1.CheckDoneAxis(s * ObjectList.Servo_R1.Global_pulse, 5000, true) != 0)
                                                        {
                                                            break;
                                                        }
                                                    }
                                                }
                                            }

                                            if (Z2_Triggered_the_Nozzle_2)
                                            {

                                                Z2_Triggered_the_Nozzle_2 = false;
                                                if (ccd2nozle2[6] != null && HasN2Cavity)
                                                {
                                                    if (!ccd2nozle2[6].Contains("999.999") && HasN2Cavity)
                                                    {
                                                        double s = 0;
                                                        s = double.Parse(ccd2nozle2[6]) + (
                                                            GlobalVariable.K_Enable ? GlobalVariable.offsetK[Data[N2Cell.row, N2Cell.col].cavityNo - 1].Rvalue :
                                                            GlobalVariable.NK_Enable ? GlobalVariable.offsetNK[Data[N2Cell.row, N2Cell.col].cavityNo - 1].Rvalue :
                                                            GlobalVariable.offset[Data[N2Cell.row, N2Cell.col].cavityNo - 1].Rvalue);
                                                        if (ObjectList.Servo_R2.CheckDoneAxis(s * ObjectList.Servo_R2.Global_pulse, 5000, true) != 0)
                                                        {
                                                            break;
                                                        }

                                                    }
                                                }
                                                else
                                                {

                                                    break;


                                                }
                                            }
                                            _safeRetryCount = 0;
                                            currentState = 40;
                                        }
                                    }
                                    else
                                    {
                                        // Safe() saved state & fired alarm — wait for reset
                                        break;
                                    }
                                }
                                else
                                    currentState = 60;
                            }
                            break;

                        // =============== Z1 PASTE DOWN =================
                        case 40:

                            await Logger.WriteLogasTask(Logger.LogType.Running, "WorkingConveyor 1", "MoveAndPast", "currentState 40 " + "Nozzle1 Down for Pasting", "");

                            if (dryrun)
                            {
                                if (await Task.Run(() => NozzleSystem.Nozzle1MoveDown(PeekN1Pos)))
                                {
                                    await Task.Delay(GlobalVariable.Z_Delay);
                                    currentState = 50;
                                }
                            }
                            else
                            {
                                // track for mid-paste resume
                                double s = double.Parse(ccd2nozzle1[6]) + (
                                    GlobalVariable.K_Enable ? GlobalVariable.offsetK[Data[N1Cell.row, N1Cell.col].cavityNo - 1].Rvalue :
                                    GlobalVariable.NK_Enable ? GlobalVariable.offsetNK[Data[N1Cell.row, N1Cell.col].cavityNo - 1].Rvalue :
                                    GlobalVariable.offset[Data[N1Cell.row, N1Cell.col].cavityNo - 1].Rvalue);
                                if (ObjectList.Servo_R1.CheckDoneAxis_Agaibn(s * ObjectList.Servo_R1.Global_pulse, true) == 0)
                                {
                                    nozzle1WasDown = true;
                                    if (await Task.Run(() => NozzleSystem.Nozzle1MoveDown(PeekN1Pos)))
                                    {

                                        Data[N1Cell.row, N1Cell.col].pastingcmplt = true;

                                        GlobalVariable.DIDO.WriteOPS(false, (int)EOutput.Pick_Place_Z1_Axis_Vaccuum_ON);
                                        await Task.Delay(50);
                                        GlobalVariable.DIDO.WriteOPS(true, (int)EOutput.Pick_Place_Z1_Axis_Vaccuum_Blow);
                                        //Vacuum_config.Vacuums_List[(int)Vacuum_config.Vacuums.Vacuum1].Both_Vacuum_and_Blow_Off();
                                        //await Task.Delay(200); cmd by arul
                                        await Task.Delay(GlobalVariable.Z_Delay);
                                        GlobalVariable.DIDO.WriteOPS(false, (int)EOutput.Pick_Place_Z1_Axis_Vaccuum_Blow);

                                        Data[N1Cell.row, N1Cell.col].loadcellforce = Convert.ToDouble(GlobalVariable.loadconverz1.ToString());
                                        currentState = 50;
                                    }
                                }
                                else
                                {
                                    // MessageBox.Show("Z1 need to move ");
                                    _ = Task.Run(() => GantrySystem.MoveR1(PeekN1Pos, double.Parse(ccd2nozzle1[6]) + (
                                        GlobalVariable.K_Enable ? GlobalVariable.offsetK[Data[N1Cell.row, N1Cell.col].cavityNo - 1].Rvalue :
                                        GlobalVariable.NK_Enable ? GlobalVariable.offsetNK[Data[N1Cell.row, N1Cell.col].cavityNo - 1].Rvalue :
                                        GlobalVariable.offset[Data[N1Cell.row, N1Cell.col].cavityNo - 1].Rvalue)));

                                }
                            }
                            break;

                        // =============== Z1 PASTE UP =================
                        case 50:
                            await Logger.WriteLogasTask(Logger.LogType.Running, "MoveAndPast", "Working Conv1", "Nozzle 1 Pasted and UP", "");
                            if (dryrun)
                            {
                                if (await Task.Run(() => NozzleSystem.Nozzle1Moveup(PeekN1Pos)))
                                {
                                    _ = Task.Run(() => ObjectList.Servo_R1.Move_Abs(double.Parse("0"), Convert.ToDouble(PeekN1Pos.RVel), Convert.ToDouble(PeekN1Pos.RAcc), Convert.ToDouble(PeekN1Pos.RDeAcc), 15000));
                                    updatecavity(N1Cell.row, N1Cell.col, "SN", 3, "SN");
                                    currentState = 60;
                                }
                            }
                            else
                            {
                                if (await Task.Run(() => NozzleSystem.Nozzle1Moveup(PeekN1Pos)))
                                {
                                    nozzle1WasDown = false; // nozzle safely up
                                    try
                                    {
                                        await Task.Delay(100);
                                        if (!GlobalVariable.DI[(int)EInput.Pick_Place_Z1_Axis_Vaccuum_Fb])
                                        {
                                            DialogResult res = MessageBox.Show("Nozzle Z1 has vaccum feed-back. Do you want to retry !", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);

                                            if (res == DialogResult.Yes)
                                            {
                                                _ = Task.Run(() => Logger.WriteLog(Logger.LogType.Error, "Working1Conveyor", "MoveAndPaste", "", "Nozzle Z1 has vaccum feed-back. Do you want to retry"));
                                                // FIX: was incorrectly referencing queueZ2 here
                                                Data[N1Cell.row, N1Cell.col].pastingcmplt = false;
                                                nozzle1Graphhitetaken = false;
                                                i_rejection = 10;
                                                await Logger.WriteLogasTask(Logger.LogType.Running, "MoveAndPast", "Working Conv1", "Nozzle 1 Pasted and UP - Vaccum feed back not reset ", "");
                                                i_rejection = 10;
                                                await GoRejectionPlace(cts);
                                                GantrySystem.GoR1initialPos();
                                                currentState = 20;
                                            }
                                            else
                                            {
                                                Data[N1Cell.row, N1Cell.col].pastingcmplt = true;
                                                nozzle1Graphhitetaken = false;
                                                GantrySystem.GoR1initialPos();
                                                updatecavity(N1Cell.row, N1Cell.col, Data[N1Cell.row, N1Cell.col].SNno, 3, Data[0, 0].CarrierBarcode);
                                                currentState = 60;
                                                if (!HasN2Cavity)
                                                    currentState = 67;
                                            }

                                        }
                                        else if (GlobalVariable.DI[(int)EInput.Pick_Place_Z1_Axis_Vaccuum_Fb])
                                        {
                                            Data[N1Cell.row, N1Cell.col].pastingcmplt = true;
                                            nozzle1Graphhitetaken = false;
                                            GantrySystem.GoR1initialPos();
                                            updatecavity(N1Cell.row, N1Cell.col, Data[N1Cell.row, N1Cell.col].SNno, 3, Data[0, 0].CarrierBarcode);
                                            currentState = 60;
                                            if (!HasN2Cavity)
                                                currentState = 67;
                                        }

                                    }
                                    catch (Exception ex)
                                    {
                                        await Logger.WriteLogasTask(Logger.LogType.Error, "MoveAndPast", "Working Conv1", $"State 50 exception: {ex}", "");
                                    }
                                }
                            }
                            break;

                        // =============== MOVE Z2 TO TARGET =================
                        case 60:
                            await Logger.WriteLogasTask(Logger.LogType.Running, "MoveAndPast", "Working Conv1", "Nozzle 2 Moving to Cavity", "");
                            if (dryrun)
                            {
                                if (await GantrySystem.move(PeekN2Pos, PeekN2Pos.CavityX, PeekN2Pos.CavityY))
                                {
                                    if (Safe(PeekN2Pos.CavityX, GantrySystem.getcurrentpos(ObjectList.Servo_X1), currentState, step) &&
                                        Safe(PeekN2Pos.CavityY, GantrySystem.getcurrentpos(ObjectList.Servo_Y1), currentState, step))
                                    {
                                        _safeRetryCount = 0;
                                        currentState = 65;
                                    }
                                    else
                                    {
                                        break;
                                    }
                                }
                            }
                            else if (production)
                            {
                                if (ccd2nozle2 != null && ccd2nozle2.Length > 6 && ccd2nozle2[6] != null)
                                {
                                    if (!ccd2nozle2[6].Contains("999.999") && HasN2Cavity)
                                        _ = Task.Run(async () => await GantrySystem.MoveR2(PeekN2Pos, double.Parse(ccd2nozle2[6]) + (
                                            GlobalVariable.K_Enable ? GlobalVariable.offsetK[Data[N2Cell.row, N2Cell.col].cavityNo - 1].Rvalue :
                                            GlobalVariable.NK_Enable ? GlobalVariable.offsetNK[Data[N2Cell.row, N2Cell.col].cavityNo - 1].Rvalue :
                                            GlobalVariable.offset[Data[N2Cell.row, N2Cell.col].cavityNo - 1].Rvalue)));

                                    await Logger.WriteLogasTask(Logger.LogType.Running, "Nozzle2", "Working Con1 ", "MoveR2:Offset:" + (PeekN2Pos, double.Parse(ccd2nozle2[6]) + (
                                        GlobalVariable.K_Enable ? GlobalVariable.offsetK[Data[N2Cell.row, N2Cell.col].cavityNo - 1].Rvalue :
                                        GlobalVariable.NK_Enable ? GlobalVariable.offsetNK[Data[N2Cell.row, N2Cell.col].cavityNo - 1].Rvalue :
                                        GlobalVariable.offset[Data[N2Cell.row, N2Cell.col].cavityNo - 1].Rvalue)), "");

                                    if (ccd2nozle2.Length > 5 &&
                                        Safe(PeekN2Pos.CavityX, double.Parse(ccd2nozle2[4]), currentState, step) &&
                                        Safe(PeekN2Pos.CavityY, double.Parse(ccd2nozle2[5]), currentState, step))
                                    {
                                        await Logger.WriteLogasTask(Logger.LogType.Running, "Nozzle2", "Working Con1 ", "X,Y:Offset:" + (PeekN2Pos, double.Parse(ccd2nozle2[4]) + (
                                            GlobalVariable.K_Enable ? GlobalVariable.offsetK[Data[N2Cell.row, N2Cell.col].cavityNo - 1].Xvalue :
                                            GlobalVariable.NK_Enable ? GlobalVariable.offsetNK[Data[N2Cell.row, N2Cell.col].cavityNo - 1].Xvalue :
                                            GlobalVariable.offset[Data[N2Cell.row, N2Cell.col].cavityNo - 1].Xvalue), double.Parse(ccd2nozle2[5])
                                            + (
                                            GlobalVariable.K_Enable ? GlobalVariable.offsetK[Data[N2Cell.row, N2Cell.col].cavityNo - 1].Yvalue :
                                            GlobalVariable.NK_Enable ? GlobalVariable.offsetNK[Data[N2Cell.row, N2Cell.col].cavityNo - 1].Yvalue :
                                            GlobalVariable.offset[Data[N2Cell.row, N2Cell.col].cavityNo - 1].Yvalue)), "");

                                        if (await GantrySystem.move(PeekN2Pos, double.Parse(ccd2nozle2[4]) + (
                                            GlobalVariable.K_Enable ? GlobalVariable.offsetK[Data[N2Cell.row, N2Cell.col].cavityNo - 1].Xvalue :
                                            GlobalVariable.NK_Enable ? GlobalVariable.offsetNK[Data[N2Cell.row, N2Cell.col].cavityNo - 1].Xvalue :
                                            GlobalVariable.offset[Data[N2Cell.row, N2Cell.col].cavityNo - 1].Xvalue), double.Parse(ccd2nozle2[5]) + (

                                            GlobalVariable.K_Enable ? GlobalVariable.offsetK[Data[N2Cell.row, N2Cell.col].cavityNo - 1].Yvalue :
                                            GlobalVariable.NK_Enable ? GlobalVariable.offsetNK[Data[N2Cell.row, N2Cell.col].cavityNo - 1].Yvalue :
                                            GlobalVariable.offset[Data[N2Cell.row, N2Cell.col].cavityNo - 1].Yvalue)))
                                        {
                                            _safeRetryCount = 0;
                                            currentState = 65;
                                        }
                                    }
                                    else
                                    {
                                        break;
                                    }
                                }
                                else
                                    currentState = 67;
                            }
                            break;

                        // =============== Z2 PASTE DOWN =================
                        case 65:
                            await Logger.WriteLogasTask(Logger.LogType.Running, "MoveAndPast", "Working Conv1", "Nozzle2 Down for Pasting", "");
                            if (dryrun)
                            {
                                await Task.Run(() => NozzleSystem.Nozzle2MoveDown(PeekN2Pos, 15));
                                currentState = 66;
                            }
                            else
                            {
                                double s = double.Parse(ccd2nozle2[6]) + (
                                    GlobalVariable.K_Enable ? GlobalVariable.offsetK[Data[N2Cell.row, N2Cell.col].cavityNo - 1].Rvalue :
                                    GlobalVariable.NK_Enable ? GlobalVariable.offsetNK[Data[N2Cell.row, N2Cell.col].cavityNo - 1].Rvalue :
                                    GlobalVariable.offset[Data[N2Cell.row, N2Cell.col].cavityNo - 1].Rvalue);

                                if (ObjectList.Servo_R2.CheckDoneAxis_Agaibn(s * ObjectList.Servo_R2.Global_pulse, true) == 0)
                                {
                                    // FIX: removed duplicate Nozzle2MoveDown call
                                    nozzle2WasDown = true; // track for mid-paste resume
                                    if (await Task.Run(() => NozzleSystem.Nozzle2MoveDown(PeekN2Pos)))
                                    {

                                        Data[N2Cell.row, N2Cell.col].pastingcmplt = true;

                                        GlobalVariable.DIDO.WriteOPS(false, (int)EOutput.Pick_Place_Z2_Axis_Vaccuum_ON);
                                        await Task.Delay(50);
                                        GlobalVariable.DIDO.WriteOPS(true, (int)EOutput.Pick_Place_Z2_Axis_Vaccuum_Blow);
                                        //Vacuum_config.Vacuums_List[(int)Vacuum_config.Vacuums.Vacuum2].Both_Vacuum_and_Blow_Off();
                                        await Task.Delay(GlobalVariable.Z_Delay);
                                        GlobalVariable.DIDO.WriteOPS(false, (int)EOutput.Pick_Place_Z2_Axis_Vaccuum_Blow);


                                        Data[N2Cell.row, N2Cell.col].loadcellforce = Convert.ToDouble(GlobalVariable.loadconverz2.ToString());
                                        currentState = 66;



                                    }
                                }
                                else
                                {
                                    // MessageBox.Show("Z2 need to move ");
                                    _ = Task.Run(() => GantrySystem.MoveR2(PeekN2Pos, double.Parse(ccd2nozle2[6]) + (
                                        GlobalVariable.K_Enable ? GlobalVariable.offsetK[Data[N2Cell.row, N2Cell.col].cavityNo - 1].Rvalue :
                                        GlobalVariable.NK_Enable ? GlobalVariable.offsetNK[Data[N2Cell.row, N2Cell.col].cavityNo - 1].Rvalue :
                                        GlobalVariable.offset[Data[N2Cell.row, N2Cell.col].cavityNo - 1].Rvalue)));

                                }
                            }
                            break;

                        // =============== Z2 PASTE UP =================
                        case 66:
                            await Logger.WriteLogasTask(Logger.LogType.Running, "MoveAndPast", "Working Conv1", "Nozzle 2 Pasted and UP", "");
                            if (dryrun)
                            {
                                if (await Task.Run(() => NozzleSystem.Nozzle2Moveup(PeekN2Pos)))
                                {
                                    _ = Task.Run(() => ObjectList.Servo_R2.Move_Abs(double.Parse("0"), Convert.ToDouble(PeekN2Pos.RVel), Convert.ToDouble(PeekN2Pos.RAcc), Convert.ToDouble(PeekN2Pos.RDeAcc), 15000));
                                    updatecavity(N2Cell.row, N2Cell.col, "SN", 3, "SN");
                                    currentState = 67;
                                }
                            }
                            else
                            {
                                if (!HasN2Cavity)
                                {
                                    await GlobalVariable.AlarmTriggerAsync(ECode.queue_empty, true, 1, "", "Current Version: " + GlobalVariable.Version + "");
                                    break;
                                }
                                if (await Task.Run(() => NozzleSystem.Nozzle2Moveup(PeekN2Pos)))
                                {
                                    nozzle2WasDown = false; // nozzle safely up
                                    await Task.Delay(50);
                                    if (!GlobalVariable.DI[(int)EInput.Pick_Place_Z2_Axis_Vaccuum_Fb])
                                    {
                                        Task.Run(() => Logger.WriteLog(Logger.LogType.Error, "Working1Conveyor", "MoveAndPaste", "", "Nozzle Z2 has vaccum feed-back. Do you want to retry"));
                                        DialogResult res = MessageBox.Show("Nozzle Z2 has vaccum feed-back. Do you want to retry !", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);

                                        if (res == DialogResult.Yes)
                                        {
                                            Data[N2Cell.row, N2Cell.col].pastingcmplt = false;
                                            nozzle2Graphhitetaken = false;
                                            await Logger.WriteLogasTask(Logger.LogType.Running, "MoveAndPast", "Working Conv1", "Nozzle 2 Pasted and UP - Vaccum feed back not reset ", "");
                                            i_rejection = 10;
                                            await GoRejectionPlace(cts);
                                            GantrySystem.GoR2initialPos();
                                            currentState = 20;
                                        }
                                        else
                                        {
                                            Data[N2Cell.row, N2Cell.col].pastingcmplt = true;
                                            nozzle2Graphhitetaken = false;
                                            GantrySystem.GoR2initialPos();
                                            updatecavity(N2Cell.row, N2Cell.col, Data[N2Cell.row, N2Cell.col].SNno, 3, Data[0, 0].CarrierBarcode);
                                            currentState = 67;

                                        }
                                    }
                                    else if (GlobalVariable.DI[(int)EInput.Pick_Place_Z2_Axis_Vaccuum_Fb])
                                    {
                                        Data[N2Cell.row, N2Cell.col].pastingcmplt = true;
                                        nozzle2Graphhitetaken = false;
                                        GantrySystem.GoR2initialPos();
                                        updatecavity(N2Cell.row, N2Cell.col, Data[N2Cell.row, N2Cell.col].SNno, 3, Data[0, 0].CarrierBarcode);
                                        currentState = 67;
                                    }

                                }
                            }
                            break;

                        // =============== CLEANUP =================
                        case 67:
                            await Logger.WriteLogasTask(Logger.LogType.Running, "MoveAndPast", "Working Conv1", "Cleaning Both Nozzles", "");
                            if (HasN1Cavity)
                            {
                                AdvanceN1Cavity();
                                await Logger.WriteLogasTask(Logger.LogType.Running, "TEST_Nozzle2", "Working Con1", RemainingN1Count.ToString(), "");

                                if (production && ccd2nozzle1 != null)
                                {
                                    int l = ccd2nozzle1.Length;
                                    Array.Clear(ccd2nozzle1, 0, l);
                                }
                            }
                            if (HasN2Cavity)
                            {
                                AdvanceN2Cavity();
                                await Logger.WriteLogasTask(Logger.LogType.Running, "TEST_Nozzle2", "Working Con1", RemainingN2Count.ToString(), "");

                                if (production && ccd2nozle2 != null)
                                {
                                    int l = ccd2nozle2.Length;
                                    Array.Clear(ccd2nozle2, 0, l);
                                }
                            }
                            firsttimePick = true;
                            if (!HasN1Cavity && !HasN2Cavity)
                            {
                                if (production)
                                    await Feeding.Feed();
                                currentState = 1000;
                            }
                            else if (HasN1Cavity || HasN2Cavity)
                            {
                                currentState = 70;
                                GlobalVariable.Nozzletossing = 0;
                            }
                            break;

                        // =============== NORMAL PICK-PASTE LOOP =================
                        case 70:
                            await Logger.WriteLogasTask(Logger.LogType.Running, "MoveAndPast", "Working Conv1", "Moving to Feed position", "");
                            if (dryrun)
                            {
                                await GoFeederPlace(cts);
                                currentState = 130;
                            }
                            else
                            {
                                await GoFeederPlace(cts);
                                if (HasN1Cavity)
                                    Data[N1Cell.row, N1Cell.col].FedTime_stmp = fedTime_stmp;
                                if (HasN2Cavity)
                                    Data[N2Cell.row, N2Cell.col].FedTime_stmp = fedTime_stmp;
                                currentState = 130;
                                GlobalVariable.Nozzletossing = 0;


                            }
                            break;

                        case 130:
                            await Logger.WriteLogasTask(Logger.LogType.Running, "MoveAndPast", "Working Conv", "Move gantry to CCD positions For Photos", "");
                            if (dryrun)
                            {
                                string cmd1 = "T1,S,1,4,2,3,TEST";
                                await GantrySystem.move(GlobalVariable.Wk1_Z1CCD2pos);
                                string camdata = await camera.Trig_Camera(ObjectList.CCD2, cmd1);
                                await GantrySystem.move(GlobalVariable.Wk1_Z2CCD2pos);
                                string camdata1 = await camera.Trig_Camera(ObjectList.CCD2, cmd1);
                                currentState = 140;
                                break;
                            }
                            else if (production)
                            {
                                try
                                {

                                    if (HasN1Cavity)
                                    {
                                        GlobalVariable.LoadReceipe(); // Add by Arulkumar 25-07-2026/

                                        if (Data[N1Cell.row, N1Cell.col].CCD2receiveX != null)
                                        {
                                            if (!Data[N1Cell.row, N1Cell.col].CCD2receiveX.Contains("999.999") || Data[N1Cell.row, N1Cell.col].CCD2receiveError.Contains("0"))
                                            {
                                                if (!PeekN1Pos.trigger || GlobalVariable.Z1_Pickedup)
                                                {
                                                    count = 0;
                                                    await GantrySystem.move(GlobalVariable.Wk1_Z1CCD2pos);
                                                    await Task.Run(() => NozzleSystem.Nozzle1MoveDown(GlobalVariable.TrainNozzle1));
                                                    ObjectList.Servo_R1.Move_Abs(Convert.ToDouble(GlobalVariable.TrainNozzle1.PositionR1), Convert.ToDouble(GlobalVariable.TrainNozzle1.RVel), Convert.ToDouble(GlobalVariable.TrainNozzle1.RAcc), Convert.ToDouble(GlobalVariable.TrainNozzle1.RDeAcc), 15000);
                                                    await Task.Delay(20);
                                                    if (production)
                                                    {
                                                        ccd2nozzle1 = null;
                                                        cmd1_1 = "";

                                                        try
                                                        {
                                                            //Arulkumar Fixed Hung start
                                                            await Task.Delay(50);
                                                            //Arulkumar Fixed Hung end


                                                            double Xpos_1 = GantrySystem.getcurrentpos(ObjectList.Servo_X1);
                                                            double Ypos1 = GantrySystem.getcurrentpos(ObjectList.Servo_Y1);
                                                            double A1_1 = GantrySystem.getcurrentpos(ObjectList.Servo_R1);

                                                            if (Data[N1Cell.row, N1Cell.col].SNno == null)
                                                            {
                                                                cmd1_1 = "T1,S,1,3,1," + Data[N1Cell.row, N1Cell.col].cavityNo + "," + dtm + "_NA," + GlobalVariable.TrainNozzle1.PositionX + "," + GlobalVariable.TrainNozzle1.PositionY + "," + GlobalVariable.TrainNozzle1.PositionR1 + "," + pos[N1Cell.row, N1Cell.col].PositionX + "," + pos[N1Cell.row, N1Cell.col].PositionY + "," + pos[N1Cell.row, N1Cell.col].PositionR1 + "," + Data[N1Cell.row, N1Cell.col].CCD2receiveX + "," + Data[N1Cell.row, N1Cell.col].CCD2receiveY + "," + Data[N1Cell.row, N1Cell.col].CCD2receiveR + ((GlobalVariable.K_Enable) ? ", K" : (GlobalVariable.NK_Enable) ? ", NK" : "");
                                                                await Logger.WriteLogasTask(Logger.LogType.Running, "WorkingConveyor 1", "WorkingConveyor 1", "currentState 130 " + "Nozzle2 Cmd : " + cmd1_1, "");

                                                            }
                                                            else
                                                            {
                                                                cmd1_1 = "T1,S,1,3,1," + Data[N1Cell.row, N1Cell.col].cavityNo + "," + dtm + "_" + Data[N1Cell.row, N1Cell.col].SNno + "," + GlobalVariable.TrainNozzle1.PositionX + "," + GlobalVariable.TrainNozzle1.PositionY + "," + GlobalVariable.TrainNozzle1.PositionR1 + "," + pos[N1Cell.row, N1Cell.col].PositionX + "," + pos[N1Cell.row, N1Cell.col].PositionY + "," + pos[N1Cell.row, N1Cell.col].PositionR1 + "," + Data[N1Cell.row, N1Cell.col].CCD2receiveX + "," + Data[N1Cell.row, N1Cell.col].CCD2receiveY + "," + Data[N1Cell.row, N1Cell.col].CCD2receiveR + ((GlobalVariable.K_Enable) ? ", K" : (GlobalVariable.NK_Enable) ? ", NK" : "");
                                                                await Logger.WriteLogasTask(Logger.LogType.Running, "WorkingConveyor 1", "WorkingConveyor 1", "currentState 130 " + "Nozzle2 Cmd : " + cmd1_1, "");

                                                            }

                                                            camdata_1 = await camera.Trig_Camera(ObjectList.CCD2, cmd1_1);
                                                            await Logger.WriteLogasTask(Logger.LogType.Running, "WorkingConveyor 1", "WorkingConveyor 1", "currentState 130 " + "Camera Tigger Result : " + camdata_1, "");



                                                            if (camdata_1 == null || camdata_1 == "null" || camdata_1 == "")
                                                            {
                                                                camdata_1 = "";
                                                                break;

                                                            }



                                                            Data[N1Cell.row, N1Cell.col].NLTime_stmp = dtm;
                                                            PeekN1Pos.trigger = true;
                                                            GlobalVariable.Z1_Pickedup = false;
                                                            Z1_Triggered_the_Nozzle_1 = true;
                                                            ccd2nozzle1 = camdata_1.Split(',');
                                                            //if (ccd2nozzle1.Length > 3)
                                                            //    n1Toss = ccd2nozzle1[3] == "0";  // cmd by arul
                                                            camdata_1 = "";


                                                        }
                                                        catch (Exception ex)
                                                        {
                                                            await Logger.WriteLogasTask(Logger.LogType.Running, "Working Conveyor1", "Working Conveyor1", "Nozzle 1 exited. Raising CDD3 Tigger.", "");

                                                        }


                                                        if (ccd2nozzle1 == null)
                                                        {
                                                            PeekN1Pos.trigger = false;
                                                            nozzle1Graphhitetaken = false;
                                                            i_rejection = 10;
                                                            GlobalVariable.Nozzletossing++;
                                                            if (GlobalVariable.Nozzletossing < 3)
                                                            {
                                                                await Logger.WriteLogasTask(Logger.LogType.Running, "WorkingConveyor 1", "WorkingConveyor 1", "currentState 20 " + "GoRejectionPlace ", "");

                                                                await GoRejectionPlace(cts);

                                                            }
                                                            else
                                                            {

                                                                GlobalVariable.tossingBuzzer = true;
                                                                MessageBox.Show("Nozzle Reached Max Tossing Limit ", "Warring", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);
                                                                _ = Task.Run(() => Logger.WriteLog(Logger.LogType.Error, "Working1Conveyor", "MoveAndPaste", "", "Nozzle Reached Max Tossing Limit"));
                                                                await Logger.WriteLogasTask(Logger.LogType.Running, "WorkingConveyor 1", "WorkingConveyor 1", "currentState 20 " + " Message Box Nozzle Reached Max Tossing Limit  ", "");
                                                                GlobalVariable.tossingBuzzer = false;

                                                                await Logger.WriteLogasTask(Logger.LogType.Running, "WorkingConveyor 1", "WorkingConveyor 1", "currentState 20 " + "GoRejectionPlace ", "");
                                                                await GoRejectionPlace(cts);
                                                                GlobalVariable.Nozzletossing = 0;
                                                            }
                                                            //await GoRejectionPlace(cts);
                                                            break;
                                                        }
                                                        else if (ccd2nozzle1.Length < 9 || ccd2nozzle1.Length > 9)
                                                        {
                                                            PeekN1Pos.trigger = false;
                                                            nozzle1Graphhitetaken = false;
                                                            i_rejection = 10;
                                                            //await GoRejectionPlace(cts);
                                                            GlobalVariable.Nozzletossing++;
                                                            if (GlobalVariable.Nozzletossing < 3)
                                                            {
                                                                await Logger.WriteLogasTask(Logger.LogType.Running, "WorkingConveyor 1", "WorkingConveyor 1", "currentState 20 " + "GoRejectionPlace ", "");

                                                                await GoRejectionPlace(cts);

                                                            }
                                                            else
                                                            {

                                                                GlobalVariable.tossingBuzzer = true;
                                                                MessageBox.Show("Nozzle Reached Max Tossing Limit ", "Warring", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);
                                                                _ = Task.Run(() => Logger.WriteLog(Logger.LogType.Error, "Working1Conveyor", "MoveAndPaste", "", "Nozzle Reached Max Tossing Limit"));
                                                                await Logger.WriteLogasTask(Logger.LogType.Running, "WorkingConveyor 1", "WorkingConveyor 1", "currentState 20 " + " Message Box Nozzle Reached Max Tossing Limit  ", "");
                                                                GlobalVariable.tossingBuzzer = false;

                                                                await Logger.WriteLogasTask(Logger.LogType.Running, "WorkingConveyor 1", "WorkingConveyor 1", "currentState 20 " + "GoRejectionPlace ", "");
                                                                await GoRejectionPlace(cts);
                                                                GlobalVariable.Nozzletossing = 0;
                                                            }
                                                        }
                                                        else if ((ccd2nozzle1[0] == null || ccd2nozzle1[1] == null || ccd2nozzle1[2] == null || ccd2nozzle1[4] == null || ccd2nozzle1[5] == null || ccd2nozzle1[6] == null || ccd2nozzle1[7] == null || ccd2nozzle1[8] == null))
                                                        {
                                                            PeekN1Pos.trigger = false;
                                                            nozzle1Graphhitetaken = false;
                                                            i_rejection = 10;
                                                            //await GoRejectionPlace(cts);
                                                            GlobalVariable.Nozzletossing++;
                                                            if (GlobalVariable.Nozzletossing < 3)
                                                            {
                                                                await Logger.WriteLogasTask(Logger.LogType.Running, "WorkingConveyor 1", "WorkingConveyor 1", "currentState 20 " + "GoRejectionPlace ", "");

                                                                await GoRejectionPlace(cts);

                                                            }
                                                            else
                                                            {

                                                                GlobalVariable.tossingBuzzer = true;
                                                                MessageBox.Show("Nozzle Reached Max Tossing Limit ", "Warring", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);
                                                                Task.Run(() => Logger.WriteLog(Logger.LogType.Error, "Working1Conveyor", "MoveAndPaste", "", "Nozzle Reached Max Tossing Limit"));
                                                                await Logger.WriteLogasTask(Logger.LogType.Running, "WorkingConveyor 1", "WorkingConveyor 1", "currentState 20 " + " Message Box Nozzle Reached Max Tossing Limit  ", "");
                                                                GlobalVariable.tossingBuzzer = false;

                                                                await Logger.WriteLogasTask(Logger.LogType.Running, "WorkingConveyor 1", "WorkingConveyor 1", "currentState 20 " + "GoRejectionPlace ", "");
                                                                await GoRejectionPlace(cts);
                                                                GlobalVariable.Nozzletossing = 0;
                                                            }
                                                            break;
                                                        }
                                                        else
                                                        {
                                                            if (ccd2nozzle1.Length > 7 && ccd2nozzle1[7].Contains("-1"))
                                                            {
                                                                PeekN1Pos.trigger = false;
                                                                nozzle1Graphhitetaken = false;
                                                                i_rejection = 10;
                                                                //await GoRejectionPlace(cts);
                                                                GlobalVariable.Nozzletossing++;
                                                                if (GlobalVariable.Nozzletossing < 3)
                                                                {
                                                                    await Logger.WriteLogasTask(Logger.LogType.Running, "WorkingConveyor 1", "WorkingConveyor 1", "currentState 20 " + "GoRejectionPlace ", "");

                                                                    await GoRejectionPlace(cts);

                                                                }
                                                                else
                                                                {

                                                                    GlobalVariable.tossingBuzzer = true;
                                                                    MessageBox.Show("Nozzle Reached Max Tossing Limit ", "Warring", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);
                                                                    Task.Run(() => Logger.WriteLog(Logger.LogType.Error, "Working1Conveyor", "MoveAndPaste", "", "Nozzle Reached Max Tossing Limit"));
                                                                    await Logger.WriteLogasTask(Logger.LogType.Running, "WorkingConveyor 1", "WorkingConveyor 1", "currentState 20 " + " Message Box Nozzle Reached Max Tossing Limit  ", "");
                                                                    GlobalVariable.tossingBuzzer = false;

                                                                    await Logger.WriteLogasTask(Logger.LogType.Running, "WorkingConveyor 1", "WorkingConveyor 1", "currentState 20 " + "GoRejectionPlace ", "");
                                                                    await GoRejectionPlace(cts);
                                                                    GlobalVariable.Nozzletossing = 0;
                                                                }
                                                                break;
                                                            }
                                                        }
                                                    }
                                                    await Task.Run(() => NozzleSystem.Nozzle1Moveup(GlobalVariable.TrainNozzle1));
                                                }
                                                else if (!HasN2Cavity)
                                                {
                                                    currentState = 140;
                                                }
                                                else
                                                {

                                                    count = count + 1;
                                                    if (count <= 3)
                                                    {
                                                        GlobalVariable.Z1_Pickedup = true;
                                                        Z1_Trigger_While = false;
                                                        Z1_Trigger_Step = 0;
                                                    }

                                                }
                                            }
                                            else
                                            {
                                                updatecavity(N1Cell.row, N1Cell.col, Data[N1Cell.row, N1Cell.col].SNno, 2, Data[0, 0].CarrierBarcode);
                                                AdvanceN1Cavity();
                                                await Logger.WriteLogasTask(Logger.LogType.Running, "TEST_Nozzle2", "Working Con ", "Z1:Dequeue:" + RemainingN1Count.ToString(), "");

                                                currentState = 130;
                                                break;
                                            }
                                        }
                                        else
                                        {
                                            updatecavity(N1Cell.row, N1Cell.col, Data[N1Cell.row, N1Cell.col].SNno, 2, Data[0, 0].CarrierBarcode);
                                            AdvanceN1Cavity();
                                            await Logger.WriteLogasTask(Logger.LogType.Running, "TEST_Nozzle2", "Working Con ", "Z1:Dequeue:" + RemainingN1Count.ToString(), "");

                                            currentState = 130;
                                            break;
                                        }
                                    }
                                    if (HasN2Cavity)
                                    {
                                        //GlobalVariable.LoadReceipe(); // Add by Arulkumar 24-07-2026
                                        if (Data[N2Cell.row, N2Cell.col].CCD2receiveError != null)
                                        {
                                            if (!Data[N2Cell.row, N2Cell.col].CCD2receiveX.Contains("999.999") || Data[N2Cell.row, N2Cell.col].CCD2receiveError.Contains("0"))
                                            {
                                                if (!PeekN2Pos.trigger || GlobalVariable.Z2_Pickedup)
                                                {
                                                    count = 0;
                                                    await GantrySystem.move(GlobalVariable.Wk1_Z2CCD2pos);
                                                    await Task.Run(() => NozzleSystem.Nozzle2MoveDown(GlobalVariable.TrainNozzle2));
                                                    ObjectList.Servo_R2.Move_Abs(Convert.ToDouble(GlobalVariable.TrainNozzle2.PositionR2), Convert.ToDouble(GlobalVariable.TrainNozzle2.RVel), Convert.ToDouble(GlobalVariable.TrainNozzle2.RAcc), Convert.ToDouble(GlobalVariable.TrainNozzle2.RDeAcc), 15000);
                                                    await Task.Delay(20);
                                                    if (production)
                                                    {
                                                        ccd2nozle2 = null;
                                                        cmd2_1 = "";
                                                        try
                                                        {

                                                            //Arulkumar Fixed Hung start

                                                            await Task.Delay(50);
                                                            //Arulkumar Fixed Hung end



                                                            double Xpos_1 = GantrySystem.getcurrentpos(ObjectList.Servo_X1);
                                                            double Ypos_1 = GantrySystem.getcurrentpos(ObjectList.Servo_Y1);
                                                            double A1_1 = GantrySystem.getcurrentpos(ObjectList.Servo_R1);

                                                            if (Data[N2Cell.row, N2Cell.col].SNno == null)
                                                            {
                                                                cmd2_1 = "T1,S,1,3,2," + Data[N2Cell.row, N2Cell.col].cavityNo + "," + dtm + "_NA," + GlobalVariable.TrainNozzle2.PositionX + "," + GlobalVariable.TrainNozzle2.PositionY + "," + GlobalVariable.TrainNozzle2.PositionR2 + "," + pos[N2Cell.row, N2Cell.col].PositionX + "," + pos[N2Cell.row, N2Cell.col].PositionY + "," + pos[N2Cell.row, N2Cell.col].PositionR1 + "," + Data[N2Cell.row, N2Cell.col].CCD2receiveX + "," + Data[N2Cell.row, N2Cell.col].CCD2receiveY + "," + Data[N2Cell.row, N2Cell.col].CCD2receiveR + ((GlobalVariable.K_Enable) ? ", K" : (GlobalVariable.NK_Enable) ? ", NK" : "");
                                                                await Logger.WriteLogasTask(Logger.LogType.Running, "WorkingConveyor 1", "WorkingConveyor 1", "currentState 130 " + "Nozzle2 Cmd : " + cmd2_1, "");

                                                            }
                                                            else
                                                            {
                                                                cmd2_1 = "T1,S,1,3,2," + Data[N2Cell.row, N2Cell.col].cavityNo + "," + dtm + "_" + Data[N2Cell.row, N2Cell.col].SNno + "," + GlobalVariable.TrainNozzle2.PositionX + "," + GlobalVariable.TrainNozzle2.PositionY + "," + GlobalVariable.TrainNozzle2.PositionR2 + "," + pos[N2Cell.row, N2Cell.col].PositionX + "," + pos[N2Cell.row, N2Cell.col].PositionY + "," + pos[N2Cell.row, N2Cell.col].PositionR1 + "," + Data[N2Cell.row, N2Cell.col].CCD2receiveX + "," + Data[N2Cell.row, N2Cell.col].CCD2receiveY + "," + Data[N2Cell.row, N2Cell.col].CCD2receiveR + ((GlobalVariable.K_Enable) ? ", K" : (GlobalVariable.NK_Enable) ? ", NK" : "");
                                                                await Logger.WriteLogasTask(Logger.LogType.Running, "WorkingConveyor 1", "WorkingConveyor 1", "currentState 130 " + "Nozzle2 Cmd : " + cmd2_1, "");

                                                            }


                                                            camdata_2 = await camera.Trig_Camera(ObjectList.CCD2, cmd2_1);
                                                            await Logger.WriteLogasTask(Logger.LogType.Running, "WorkingConveyor 1", "WorkingConveyor 1", "currentState 130 " + "Camera Tigger Result : " + camdata_2, "");


                                                            if (camdata_2 == null || camdata_2 == "null" || camdata_2 == "")
                                                            {
                                                                camdata_2 = "";
                                                                break;
                                                            }

                                                            Data[N2Cell.row, N2Cell.col].NLTime_stmp = dtm;
                                                            ccd2nozle2 = camdata_2.Split(',');
                                                            //if (ccd2nozle2.Length > 3)
                                                            //{
                                                            //    n2Toss = ccd2nozle2[3] == "0";  //Cmd By Arulkumar
                                                            //}
                                                            PeekN2Pos.trigger = true;
                                                            Z2_Triggered_the_Nozzle_2 = true;
                                                            Z2_Trigger_Step = 0;
                                                            GlobalVariable.Z2_Pickedup = false;
                                                            camdata_2 = "";





                                                        }
                                                        catch (Exception)
                                                        {
                                                            await Logger.WriteLogasTask(Logger.LogType.Running, "Working Conveyor1", "Working Conveyor1", "Nozzle 2 exited. Raising CDD3 Tigger.", "");

                                                        }

                                                        #region
                                                        //double Xpos = GantrySystem.getcurrentpos(ObjectList.Servo_X1);
                                                        //double Ypos = GantrySystem.getcurrentpos(ObjectList.Servo_Y1);
                                                        //double A1 = GantrySystem.getcurrentpos(ObjectList.Servo_R1);
                                                        //string cmd2 = "";
                                                        //if (Data[N2Cell.row, N2Cell.col].SNno == null)
                                                        //{
                                                        //    cmd2 = "T1,S,1,3,2," + Data[N2Cell.row, N2Cell.col].cavityNo + "," + dtm + "_NA," + GlobalVariable.TrainNozzle2.PositionX + "," + GlobalVariable.TrainNozzle2.PositionY + "," + GlobalVariable.TrainNozzle2.PositionR2 + "," + pos[N2Cell.row, N2Cell.col].PositionX + "," + pos[N2Cell.row, N2Cell.col].PositionY + "," + pos[N2Cell.row, N2Cell.col].PositionR1 + "," + Data[N2Cell.row, N2Cell.col].CCD2receiveX + "," + Data[N2Cell.row, N2Cell.col].CCD2receiveY + "," + Data[N2Cell.row, N2Cell.col].CCD2receiveR;
                                                        //    await Logger.WriteLogasTask(Logger.LogType.Running, "TEST_Nozzle2", "Working Con NULL", cmd2, "");

                                                        //}
                                                        //else
                                                        //{
                                                        //    cmd2 = "T1,S,1,3,2," + Data[N2Cell.row, N2Cell.col].cavityNo + "," + dtm + "_" + Data[N2Cell.row, N2Cell.col].SNno + "," + GlobalVariable.TrainNozzle2.PositionX + "," + GlobalVariable.TrainNozzle2.PositionY + "," + GlobalVariable.TrainNozzle2.PositionR2 + "," + pos[N2Cell.row, N2Cell.col].PositionX + "," + pos[N2Cell.row, N2Cell.col].PositionY + "," + pos[N2Cell.row, N2Cell.col].PositionR1 + "," + Data[N2Cell.row, N2Cell.col].CCD2receiveX + "," + Data[N2Cell.row, N2Cell.col].CCD2receiveY + "," + Data[N2Cell.row, N2Cell.col].CCD2receiveR;
                                                        //    await Logger.WriteLogasTask(Logger.LogType.Running, "TEST_Nozzle2", "Working Con ", cmd2, "");

                                                        //}
                                                        //string camdata = await camera.Trig_Camera(ObjectList.CCD2, cmd2);
                                                        //if (camdata == null || camdata == "null" || camdata == "")
                                                        //{
                                                        //    break;
                                                        //}
                                                        //await Logger.WriteLogasTask(Logger.LogType.Running, "TEST_Nozzle2", "Working Con ", camdata, "");

                                                        //Data[N2Cell.row, N2Cell.col].NLTime_stmp = dtm;
                                                        //ccd2nozle2 = camdata.Split(',');
                                                        //PeekN2Pos.trigger = true;
                                                        //GlobalVariable.Z1_Pickedup = false;
                                                        //camdata = "";
                                                        #endregion

                                                        // Guard: check array length before indexing
                                                        if (ccd2nozle2 == null)
                                                        {
                                                            PeekN2Pos.trigger = false;
                                                            nozzle2Graphhitetaken = false;
                                                            i_rejection = 10;
                                                            //await GoRejectionPlace(cts);
                                                            GlobalVariable.Nozzletossing++;
                                                            if (GlobalVariable.Nozzletossing < 3)
                                                            {
                                                                await Logger.WriteLogasTask(Logger.LogType.Running, "WorkingConveyor 1", "WorkingConveyor 1", "currentState 20 " + "GoRejectionPlace ", "");

                                                                await GoRejectionPlace(cts);

                                                            }
                                                            else
                                                            {

                                                                GlobalVariable.tossingBuzzer = true;
                                                                MessageBox.Show("Nozzle Reached Max Tossing Limit ", "Warring", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);
                                                                Task.Run(() => Logger.WriteLog(Logger.LogType.Error, "Working1Conveyor", "MoveAndPaste", "", "Nozzle Reached Max Tossing Limit"));
                                                                await Logger.WriteLogasTask(Logger.LogType.Running, "WorkingConveyor 1", "WorkingConveyor 1", "currentState 20 " + " Message Box Nozzle Reached Max Tossing Limit  ", "");
                                                                GlobalVariable.tossingBuzzer = false;

                                                                await Logger.WriteLogasTask(Logger.LogType.Running, "WorkingConveyor 1", "WorkingConveyor 1", "currentState 20 " + "GoRejectionPlace ", "");
                                                                await GoRejectionPlace(cts);
                                                                GlobalVariable.Nozzletossing = 0;
                                                            }
                                                            break;
                                                        }
                                                        else if (ccd2nozle2.Length < 9 || ccd2nozle2.Length > 9)
                                                        {
                                                            PeekN2Pos.trigger = false;
                                                            nozzle2Graphhitetaken = false;
                                                            i_rejection = 10;
                                                            //await GoRejectionPlace(cts);
                                                            GlobalVariable.Nozzletossing++;
                                                            if (GlobalVariable.Nozzletossing < 3)
                                                            {
                                                                await Logger.WriteLogasTask(Logger.LogType.Running, "WorkingConveyor 1", "WorkingConveyor 1", "currentState 20 " + "GoRejectionPlace ", "");

                                                                await GoRejectionPlace(cts);

                                                            }
                                                            else
                                                            {

                                                                GlobalVariable.tossingBuzzer = true;
                                                                MessageBox.Show("Nozzle Reached Max Tossing Limit ", "Warring", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);
                                                                Task.Run(() => Logger.WriteLog(Logger.LogType.Error, "Working1Conveyor", "MoveAndPaste", "", "Nozzle Reached Max Tossing Limit"));
                                                                await Logger.WriteLogasTask(Logger.LogType.Running, "WorkingConveyor 1", "WorkingConveyor 1", "currentState 20 " + " Message Box Nozzle Reached Max Tossing Limit  ", "");
                                                                GlobalVariable.tossingBuzzer = false;

                                                                await Logger.WriteLogasTask(Logger.LogType.Running, "WorkingConveyor 1", "WorkingConveyor 1", "currentState 20 " + "GoRejectionPlace ", "");
                                                                await GoRejectionPlace(cts);
                                                                GlobalVariable.Nozzletossing = 0;
                                                            }
                                                            break;
                                                        }
                                                        else if ((ccd2nozle2[0] == null || ccd2nozle2[1] == null || ccd2nozle2[2] == null || ccd2nozle2[4] == null || ccd2nozle2[5] == null || ccd2nozle2[6] == null || ccd2nozle2[7] == null || ccd2nozle2[8] == null))
                                                        {
                                                            PeekN2Pos.trigger = false;
                                                            nozzle2Graphhitetaken = false;
                                                            i_rejection = 10;
                                                            //await GoRejectionPlace(cts);
                                                            GlobalVariable.Nozzletossing++;
                                                            if (GlobalVariable.Nozzletossing < 3)
                                                            {
                                                                await Logger.WriteLogasTask(Logger.LogType.Running, "WorkingConveyor 1", "WorkingConveyor 1", "currentState 20 " + "GoRejectionPlace ", "");

                                                                await GoRejectionPlace(cts);

                                                            }
                                                            else
                                                            {

                                                                GlobalVariable.tossingBuzzer = true;
                                                                MessageBox.Show("Nozzle Reached Max Tossing Limit ", "Warring", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);
                                                                Task.Run(() => Logger.WriteLog(Logger.LogType.Error, "Working1Conveyor", "MoveAndPaste", "", "Nozzle Reached Max Tossing Limit"));
                                                                await Logger.WriteLogasTask(Logger.LogType.Running, "WorkingConveyor 1", "WorkingConveyor 1", "currentState 20 " + " Message Box Nozzle Reached Max Tossing Limit  ", "");
                                                                GlobalVariable.tossingBuzzer = false;

                                                                await Logger.WriteLogasTask(Logger.LogType.Running, "WorkingConveyor 1", "WorkingConveyor 1", "currentState 20 " + "GoRejectionPlace ", "");
                                                                await GoRejectionPlace(cts);
                                                                GlobalVariable.Nozzletossing = 0;
                                                            }
                                                            break;
                                                        }
                                                        else
                                                            if (ccd2nozle2.Length > 7 && ccd2nozle2[7].Contains("-1"))
                                                        {
                                                            PeekN2Pos.trigger = false;
                                                            nozzle2Graphhitetaken = false;
                                                            i_rejection = 10;
                                                            //await GoRejectionPlace(cts);
                                                            GlobalVariable.Nozzletossing++;
                                                            if (GlobalVariable.Nozzletossing < 3)
                                                            {
                                                                await Logger.WriteLogasTask(Logger.LogType.Running, "WorkingConveyor 1", "WorkingConveyor 1", "currentState 20 " + "GoRejectionPlace ", "");

                                                                await GoRejectionPlace(cts);

                                                            }
                                                            else
                                                            {

                                                                GlobalVariable.tossingBuzzer = true;
                                                                MessageBox.Show("Nozzle Reached Max Tossing Limit ", "Warring", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);
                                                                Task.Run(() => Logger.WriteLog(Logger.LogType.Error, "Working1Conveyor", "MoveAndPaste", "", "Nozzle Reached Max Tossing Limit"));
                                                                await Logger.WriteLogasTask(Logger.LogType.Running, "WorkingConveyor 1", "WorkingConveyor 1", "currentState 20 " + " Message Box Nozzle Reached Max Tossing Limit  ", "");
                                                                GlobalVariable.tossingBuzzer = false;

                                                                await Logger.WriteLogasTask(Logger.LogType.Running, "WorkingConveyor 1", "WorkingConveyor 1", "currentState 20 " + "GoRejectionPlace ", "");
                                                                await GoRejectionPlace(cts);
                                                                GlobalVariable.Nozzletossing = 0;
                                                            }
                                                            break;
                                                        }

                                                    }
                                                    await Task.Run(() => NozzleSystem.Nozzle2Moveup(GlobalVariable.TrainNozzle2));
                                                    currentState = 140;
                                                }
                                                else
                                                {
                                                    count = count + 1;
                                                    if (count <= 3)
                                                    {
                                                        GlobalVariable.Z2_Pickedup = true;
                                                        Z2_Trigger_While = false;
                                                        Z2_Trigger_Step = 0;
                                                    }
                                                }
                                            }
                                            else
                                            {
                                                updatecavity(N2Cell.row, N2Cell.col, Data[N2Cell.row, N2Cell.col].SNno, 2, Data[0, 0].CarrierBarcode);
                                                AdvanceN2Cavity();
                                                await Logger.WriteLogasTask(Logger.LogType.Running, "TEST_Nozzle2", "Working Con ", "Z2:Dequeue:" + RemainingN2Count.ToString(), "");

                                                currentState = 130;
                                                break;
                                            }
                                        }
                                        else
                                        {
                                            updatecavity(N2Cell.row, N2Cell.col, Data[N2Cell.row, N2Cell.col].SNno, 2, Data[0, 0].CarrierBarcode);
                                            AdvanceN2Cavity();
                                            await Logger.WriteLogasTask(Logger.LogType.Running, "TEST_Nozzle2", "Working Con ", "Z2:Dequeue:" + RemainingN2Count.ToString(), "");

                                            currentState = 130;
                                            break;
                                        }
                                    }
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show("error" + ex);
                                }
                            }
                            break;

                        // =============== MOVE Z1 TO TARGET =================

                        case 140:
                            await Logger.WriteLogasTask(Logger.LogType.Running, "MoveAndPast", "Working Conv1", "Nozzle 1 Moving For Pasting", "");
                            if (HasN1Cavity)
                            {
                                if (dryrun)
                                {
                                    if (HasN1Cavity)
                                        _ = Task.Run(() => ObjectList.Servo_R1.Move_Abs(Convert.ToDouble(PeekN1Pos.PositionR1), Convert.ToDouble(PeekN1Pos.RVel), Convert.ToDouble(PeekN1Pos.RAcc), Convert.ToDouble(PeekN1Pos.RDeAcc), 15000));
                                    if (HasN2Cavity)
                                        _ = Task.Run(() => ObjectList.Servo_R2.Move_Abs(Convert.ToDouble(PeekN2Pos.PositionR2), Convert.ToDouble(PeekN2Pos.RVel), Convert.ToDouble(PeekN2Pos.RAcc), Convert.ToDouble(PeekN2Pos.RDeAcc), 15000));

                                    if (await GantrySystem.move(PeekN1Pos, PeekN1Pos.CavityX, PeekN1Pos.CavityY))
                                    {
                                        if (Safe(PeekN1Pos.CavityX, GantrySystem.getcurrentpos(ObjectList.Servo_X1), currentState, step) &&
                                            Safe(PeekN1Pos.CavityY, GantrySystem.getcurrentpos(ObjectList.Servo_Y1), currentState, step))
                                        {
                                            _safeRetryCount = 0;
                                            currentState = 150;
                                        }
                                        else
                                        {
                                            break;
                                        }
                                    }
                                }
                                else if (production)
                                {
                                    Z1_Trigger_While = false;
                                    Z2_Trigger_While = false;

                                    if (ccd2nozzle1 != null && ccd2nozzle1.Length > 6 && ccd2nozzle1[6] != null)
                                    {

                                        if (!ccd2nozzle1[6].Contains("999.999") && HasN1Cavity)
                                        {

                                            _ = Task.Run(() => GantrySystem.MoveR1(PeekN1Pos, double.Parse(ccd2nozzle1[6]) + (
                                                                                            GlobalVariable.K_Enable ? GlobalVariable.offsetK[Data[N1Cell.row, N1Cell.col].cavityNo - 1].Rvalue :
                                                                                            GlobalVariable.NK_Enable ? GlobalVariable.offsetNK[Data[N1Cell.row, N1Cell.col].cavityNo - 1].Rvalue :
                                                                                            GlobalVariable.offset[Data[N1Cell.row, N1Cell.col].cavityNo - 1].Rvalue)));
                                            await Logger.WriteLogasTask(Logger.LogType.Running, "WorkingConveyor 1", "R1", "currentState 140 ", "");


                                        }
                                        if (ccd2nozle2 != null && ccd2nozle2.Length > 6 && ccd2nozle2[6] != null)
                                        {

                                            if (!ccd2nozle2[6].Contains("999.999") && HasN2Cavity)
                                            {
                                                _ = Task.Run(() => GantrySystem.MoveR2(PeekN2Pos, double.Parse(ccd2nozle2[6]) + (
                                                                                                    GlobalVariable.K_Enable ? GlobalVariable.offsetK[Data[N2Cell.row, N2Cell.col].cavityNo - 1].Rvalue :
                                                                                                    GlobalVariable.NK_Enable ? GlobalVariable.offsetNK[Data[N2Cell.row, N2Cell.col].cavityNo - 1].Rvalue :
                                                                                                    GlobalVariable.offset[Data[N2Cell.row, N2Cell.col].cavityNo - 1].Rvalue)));
                                                await Logger.WriteLogasTask(Logger.LogType.Running, "WorkingConveyor 1", "R2", "currentState 140 ", "");

                                            }
                                        }

                                        if (ccd2nozzle1.Length > 5 &&
                                            Safe(PeekN1Pos.CavityX, double.Parse(ccd2nozzle1[4]), currentState, step) &&
                                            Safe(PeekN1Pos.CavityY, double.Parse(ccd2nozzle1[5]), currentState, step))
                                        {
                                            try
                                            {
                                                await Logger.WriteLogasTask(Logger.LogType.Running, "Nozzle1", "Working Con1 ", "Cavity, X:Offset, Y:Offset - " + Convert.ToString(Data[N1Cell.row, N1Cell.col].cavityNo) + "," + Convert.ToString(double.Parse(ccd2nozzle1[4])) + ":" + ((
                                                    GlobalVariable.K_Enable ? GlobalVariable.offsetK[Data[N1Cell.row, N1Cell.col].cavityNo - 1].Xvalue :
                                                    GlobalVariable.NK_Enable ? GlobalVariable.offsetNK[Data[N1Cell.row, N1Cell.col].cavityNo - 1].Xvalue :
                                                    GlobalVariable.offset[Data[N1Cell.row, N1Cell.col].cavityNo - 1].Xvalue)) + "," + Convert.ToString(double.Parse(ccd2nozzle1[5])) + ":" + (

                                                    GlobalVariable.K_Enable ? GlobalVariable.offsetK[Data[N1Cell.row, N1Cell.col].cavityNo - 1].Yvalue :
                                                    GlobalVariable.NK_Enable ? GlobalVariable.offsetNK[Data[N1Cell.row, N1Cell.col].cavityNo - 1].Yvalue :
                                                    GlobalVariable.offset[Data[N1Cell.row, N1Cell.col].cavityNo - 1].Yvalue), "");
                                            }                                           
                                            catch (Exception)
                                            {
                                            }
                                            if (await GantrySystem.move(PeekN1Pos, double.Parse(ccd2nozzle1[4]) + (
                                                GlobalVariable.K_Enable ? GlobalVariable.offsetK[Data[N1Cell.row, N1Cell.col].cavityNo - 1].Xvalue :
                                                GlobalVariable.NK_Enable ? GlobalVariable.offsetNK[Data[N1Cell.row, N1Cell.col].cavityNo - 1].Xvalue :
                                                GlobalVariable.offset[Data[N1Cell.row, N1Cell.col].cavityNo - 1].Xvalue), double.Parse(ccd2nozzle1[5])
                                                +
                                                (
                                                GlobalVariable.K_Enable ? GlobalVariable.offsetK[Data[N1Cell.row, N1Cell.col].cavityNo - 1].Yvalue :
                                                GlobalVariable.NK_Enable ? GlobalVariable.offsetNK[Data[N1Cell.row, N1Cell.col].cavityNo - 1].Yvalue :
                                                GlobalVariable.offset[Data[N1Cell.row, N1Cell.col].cavityNo - 1].Yvalue)))
                                            {
                                                if (Z1_Triggered_the_Nozzle_1)
                                                {
                                                    Z1_Triggered_the_Nozzle_1 = false;

                                                    if (ccd2nozzle1[6] != null)
                                                    {
                                                        if (!ccd2nozzle1[6].Contains("999.999") && HasN1Cavity)
                                                        {
                                                            double s = 0;

                                                            s = double.Parse(ccd2nozzle1[6]) + (
                                                               GlobalVariable.K_Enable ? GlobalVariable.offsetK[Data[N1Cell.row, N1Cell.col].cavityNo - 1].Rvalue :
                                                               GlobalVariable.NK_Enable ? GlobalVariable.offsetNK[Data[N1Cell.row, N1Cell.col].cavityNo - 1].Rvalue :
                                                               GlobalVariable.offset[Data[N1Cell.row, N1Cell.col].cavityNo - 1].Rvalue);
                                                            if (ObjectList.Servo_R1.CheckDoneAxis(s * ObjectList.Servo_R1.Global_pulse, 5000, true) != 0)
                                                            {
                                                                break;
                                                            }

                                                        }
                                                    }
                                                }
                                                if (Z2_Triggered_the_Nozzle_2)
                                                {
                                                    Z2_Triggered_the_Nozzle_2 = false;
                                                    if (ccd2nozle2[6] != null)
                                                    {
                                                        if (!ccd2nozle2[6].Contains("999.999") && HasN2Cavity)
                                                        {
                                                            double s = 0;
                                                            s = double.Parse(ccd2nozle2[6]) + (
                                                                GlobalVariable.K_Enable ? GlobalVariable.offsetK[Data[N2Cell.row, N2Cell.col].cavityNo - 1].Rvalue :
                                                                GlobalVariable.NK_Enable ? GlobalVariable.offsetNK[Data[N2Cell.row, N2Cell.col].cavityNo - 1].Rvalue :
                                                                GlobalVariable.offset[Data[N2Cell.row, N2Cell.col].cavityNo - 1].Rvalue);
                                                            if (ObjectList.Servo_R2.CheckDoneAxis(s * ObjectList.Servo_R2.Global_pulse, 5000, true) != 0)
                                                            {
                                                                break;
                                                            }

                                                        }
                                                        else
                                                            break;
                                                    }
                                                }

                                                _safeRetryCount = 0;
                                                currentState = 150;
                                            }
                                        }
                                        else
                                        {
                                            break;
                                        }
                                    }
                                    else
                                        currentState = 170;
                                }
                            }
                            else
                                currentState = 170;
                            break;

                        // =============== Z1 PASTE DOWN =================
                        case 150:
                            await Logger.WriteLogasTask(Logger.LogType.Running, "MoveAndPast", "Working Conv1", "Nozzle1 Down for Pasting", "");
                            if (dryrun)
                            {
                                if (await Task.Run(() => NozzleSystem.Nozzle1MoveDown(PeekN1Pos)))
                                {
                                    await Task.Delay(GlobalVariable.Z_Delay);
                                    currentState = 160;
                                }
                            }
                            else
                            {
                                // track for mid-paste resume
                                double s = double.Parse(ccd2nozzle1[6]) + (
                                    GlobalVariable.K_Enable ? GlobalVariable.offsetK[Data[N1Cell.row, N1Cell.col].cavityNo - 1].Rvalue :
                                    GlobalVariable.NK_Enable ? GlobalVariable.offsetNK[Data[N1Cell.row, N1Cell.col].cavityNo - 1].Rvalue :
                                    GlobalVariable.offset[Data[N1Cell.row, N1Cell.col].cavityNo - 1].Rvalue);
                                
                                if (ObjectList.Servo_R1.CheckDoneAxis_Agaibn(s * ObjectList.Servo_R1.Global_pulse, true) == 0)
                                {
                                    nozzle1WasDown = true;
                                    if (await Task.Run(() => NozzleSystem.Nozzle1MoveDown(PeekN1Pos)))
                                    {

                                        Data[N1Cell.row, N1Cell.col].pastingcmplt = true;
                                        await Logger.WriteLogasTask(Logger.LogType.Running, "Nozzle1 ", "Working Conv1", "SNno : " + Data[N1Cell.row, N1Cell.col].SNno + "Pasted : " + Data[N1Cell.row, N1Cell.col].pastingcmplt, "Move and past");

                                        GlobalVariable.DIDO.WriteOPS(false, (int)EOutput.Pick_Place_Z1_Axis_Vaccuum_ON);
                                        await Task.Delay(10);
                                        GlobalVariable.DIDO.WriteOPS(true, (int)EOutput.Pick_Place_Z1_Axis_Vaccuum_Blow);
                                        //Vacuum_config.Vacuums_List[(int)Vacuum_config.Vacuums.Vacuum1].Both_Vacuum_and_Blow_Off();
                                        //await Task.Delay(200); cmd by arul
                                        await Task.Delay(GlobalVariable.Z_Delay);
                                        GlobalVariable.DIDO.WriteOPS(false, (int)EOutput.Pick_Place_Z1_Axis_Vaccuum_Blow);

                                        Data[N1Cell.row, N1Cell.col].loadcellforce = Convert.ToDouble(GlobalVariable.loadconverz1.ToString());
                                        currentState = 160;
                                    }
                                }
                                else
                                {
                                    _ = Task.Run(() => GantrySystem.MoveR1(PeekN1Pos, double.Parse(ccd2nozzle1[6]) + (
                                        GlobalVariable.K_Enable ? GlobalVariable.offsetK[Data[N1Cell.row, N1Cell.col].cavityNo - 1].Rvalue :
                                        GlobalVariable.NK_Enable ? GlobalVariable.offsetNK[Data[N1Cell.row, N1Cell.col].cavityNo - 1].Rvalue :
                                        GlobalVariable.offset[Data[N1Cell.row, N1Cell.col].cavityNo - 1].Rvalue)));

                                }
                            }
                            break;

                        // =============== Z1 PASTE UP =================
                        case 160:
                            await Logger.WriteLogasTask(Logger.LogType.Running, "MoveAndPast", "Working Conv1", "Nozzle 1 Pasted and UP", "");
                            if (dryrun)
                            {
                                if (await Task.Run(() => NozzleSystem.Nozzle1Moveup(PeekN1Pos)))
                                {
                                    _ = Task.Run(() => ObjectList.Servo_R1.Move_Abs(double.Parse("0"), Convert.ToDouble(PeekN1Pos.RVel), Convert.ToDouble(PeekN1Pos.RAcc), Convert.ToDouble(PeekN1Pos.RDeAcc), 15000));
                                    updatecavity(N1Cell.row, N1Cell.col, "SN", 3, "SN");
                                    currentState = 170;
                                }
                            }
                            else
                            {
                                if (await Task.Run(() => NozzleSystem.Nozzle1Moveup(PeekN1Pos)))
                                {
                                    nozzle1WasDown = false; // nozzle safely up
                                    try
                                    {
                                        await Task.Delay(100);

                                        if (!GlobalVariable.DI[(int)EInput.Pick_Place_Z1_Axis_Vaccuum_Fb])
                                        {
                                            Task.Run(() => Logger.WriteLog(Logger.LogType.Error, "Working1Conveyor", "MoveAndPaste", "", "Nozzle Z1 has vaccum feed-back. Do you want to retry"));
                                            DialogResult res = MessageBox.Show("Nozzle Z1 has vaccum feed-back. Do you want to retry !", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);
                                            if (res == DialogResult.Yes)
                                            {
                                                // FIX: was incorrectly referencing queueZ2 here
                                                Data[N1Cell.row, N1Cell.col].pastingcmplt = false;
                                                nozzle1Graphhitetaken = false;
                                                i_rejection = 10;
                                                await Logger.WriteLogasTask(Logger.LogType.Running, "MoveAndPast", "Working Conv1", "Nozzle 1 Pasted and UP - Vaccum feed back not reset ", "");

                                                await GoRejectionPlace(cts);
                                                GantrySystem.GoR1initialPos();
                                                currentState = 70;
                                            }
                                            else
                                            {
                                                Data[N1Cell.row, N1Cell.col].pastingcmplt = true;
                                                nozzle1Graphhitetaken = false;
                                                GantrySystem.GoR1initialPos();
                                                updatecavity(N1Cell.row, N1Cell.col, Data[N1Cell.row, N1Cell.col].SNno, 3, Data[0, 0].CarrierBarcode);
                                                currentState = 170;
                                                if (!HasN2Cavity)
                                                    currentState = 200;
                                            }
                                        }
                                        else if (GlobalVariable.DI[(int)EInput.Pick_Place_Z1_Axis_Vaccuum_Fb])
                                        {
                                            Data[N1Cell.row, N1Cell.col].pastingcmplt = true;
                                            nozzle1Graphhitetaken = false;
                                            GantrySystem.GoR1initialPos();
                                            updatecavity(N1Cell.row, N1Cell.col, Data[N1Cell.row, N1Cell.col].SNno, 3, Data[0, 0].CarrierBarcode);
                                            currentState = 170;
                                            if (!HasN2Cavity)
                                                currentState = 200;
                                        }
                                    }
                                    catch (Exception ex)
                                    {
                                        await Logger.WriteLogasTask(Logger.LogType.Error, "MoveAndPast", "Working Conv1", $"State 50 exception: {ex}", "");
                                    }
                                }
                            }
                            break;

                        // =============== MOVE Z2 TO TARGET =================
                        case 170:
                            await Logger.WriteLogasTask(Logger.LogType.Running, "MoveAndPast", "Working Conv1", "Nozzle 2 Moving to Cavity", "");
                            if (dryrun)
                            {
                                if (await GantrySystem.move(PeekN2Pos, PeekN2Pos.CavityX, PeekN2Pos.CavityY))
                                {
                                    if (Safe(PeekN2Pos.CavityX, GantrySystem.getcurrentpos(ObjectList.Servo_X1), currentState, step) &&
                                        Safe(PeekN2Pos.CavityY, GantrySystem.getcurrentpos(ObjectList.Servo_Y1), currentState, step))
                                    {
                                        _safeRetryCount = 0;
                                        currentState = 180;
                                    }
                                    else
                                    {
                                        break;
                                    }
                                }
                            }
                            else if (production)
                            {
                                if (ccd2nozle2 != null && ccd2nozle2.Length > 6 && ccd2nozle2[6] != null)
                                {
                                    if (!ccd2nozle2[6].Contains("999.999") && HasN2Cavity)
                                        _ = Task.Run(async () => await GantrySystem.MoveR2(PeekN2Pos, double.Parse(ccd2nozle2[6]) + (
                                            GlobalVariable.K_Enable ? GlobalVariable.offsetK[Data[N2Cell.row, N2Cell.col].cavityNo - 1].Rvalue :
                                            GlobalVariable.NK_Enable ? GlobalVariable.offsetNK[Data[N2Cell.row, N2Cell.col].cavityNo - 1].Rvalue :
                                            GlobalVariable.offset[Data[N2Cell.row, N2Cell.col].cavityNo - 1].Rvalue)));

                                    await Logger.WriteLogasTask(Logger.LogType.Running, "Nozzle2", "Working Con1 ", "MoveR2:Offset:" + (PeekN2Pos, double.Parse(ccd2nozle2[6]) + (
                                        GlobalVariable.K_Enable ? GlobalVariable.offsetK[Data[N2Cell.row, N2Cell.col].cavityNo - 1].Rvalue :
                                        GlobalVariable.NK_Enable ? GlobalVariable.offsetNK[Data[N2Cell.row, N2Cell.col].cavityNo - 1].Rvalue :
                                        GlobalVariable.offset[Data[N2Cell.row, N2Cell.col].cavityNo - 1].Rvalue)), "");

                                    if (ccd2nozle2.Length > 5 &&
                                        Safe(PeekN2Pos.CavityX, double.Parse(ccd2nozle2[4]), currentState, step) &&
                                        Safe(PeekN2Pos.CavityY, double.Parse(ccd2nozle2[5]), currentState, step))
                                    {
                                        await Logger.WriteLogasTask(Logger.LogType.Running, "Nozzle2", "Working Con1 ", "X,Y:Offset:" + (PeekN2Pos, double.Parse(ccd2nozle2[4]) + (
                                            GlobalVariable.K_Enable ? GlobalVariable.offsetK[Data[N2Cell.row, N2Cell.col].cavityNo - 1].Xvalue :
                                            GlobalVariable.NK_Enable ? GlobalVariable.offsetNK[Data[N2Cell.row, N2Cell.col].cavityNo - 1].Xvalue :
                                            GlobalVariable.offset[Data[N2Cell.row, N2Cell.col].cavityNo - 1].Xvalue), double.Parse(ccd2nozle2[5])
                                            + (
                                            GlobalVariable.K_Enable ? GlobalVariable.offsetK[Data[N2Cell.row, N2Cell.col].cavityNo - 1].Yvalue :
                                            GlobalVariable.NK_Enable ? GlobalVariable.offsetNK[Data[N2Cell.row, N2Cell.col].cavityNo - 1].Yvalue :
                                            GlobalVariable.offset[Data[N2Cell.row, N2Cell.col].cavityNo - 1].Yvalue)), "");

                                        if (await GantrySystem.move(PeekN2Pos, double.Parse(ccd2nozle2[4]) + (
                                            GlobalVariable.K_Enable ? GlobalVariable.offsetK[Data[N2Cell.row, N2Cell.col].cavityNo - 1].Xvalue :
                                            GlobalVariable.NK_Enable ? GlobalVariable.offsetNK[Data[N2Cell.row, N2Cell.col].cavityNo - 1].Xvalue :
                                            GlobalVariable.offset[Data[N2Cell.row, N2Cell.col].cavityNo - 1].Xvalue), double.Parse(ccd2nozle2[5])
                                            + (
                                            GlobalVariable.K_Enable ? GlobalVariable.offsetK[Data[N2Cell.row, N2Cell.col].cavityNo - 1].Yvalue :
                                            GlobalVariable.NK_Enable ? GlobalVariable.offsetNK[Data[N2Cell.row, N2Cell.col].cavityNo - 1].Yvalue :
                                            GlobalVariable.offset[Data[N2Cell.row, N2Cell.col].cavityNo - 1].Yvalue)))
                                        {
                                            _safeRetryCount = 0;
                                            currentState = 180;
                                        }
                                    }
                                    else
                                    {
                                        currentState = 130;

                                        break;
                                    }
                                }
                                else
                                    currentState = 200;
                            }
                            break;

                        // =============== Z2 PASTE DOWN =================
                        case 180:
                            await Logger.WriteLogasTask(Logger.LogType.Running, "MoveAndPast", "Working Conv1", "Nozzle2 Down for Pasting", "");
                            if (dryrun)
                            {
                                await Task.Run(() => NozzleSystem.Nozzle2MoveDown(PeekN2Pos, 15));
                                currentState = 190;
                            }
                            else
                            {
                                double s = double.Parse(ccd2nozle2[6]) + (
                                    GlobalVariable.K_Enable ? GlobalVariable.offsetK[Data[N2Cell.row, N2Cell.col].cavityNo - 1].Rvalue :
                                    GlobalVariable.NK_Enable ? GlobalVariable.offsetNK[Data[N2Cell.row, N2Cell.col].cavityNo - 1].Rvalue :
                                    GlobalVariable.offset[Data[N2Cell.row, N2Cell.col].cavityNo - 1].Rvalue);

                                if (ObjectList.Servo_R2.CheckDoneAxis_Agaibn(s * ObjectList.Servo_R2.Global_pulse, true) == 0)
                                {
                                    // FIX: removed duplicate Nozzle2MoveDown call
                                    nozzle2WasDown = true; // track for mid-paste resume
                                    if (await Task.Run(() => NozzleSystem.Nozzle2MoveDown(PeekN2Pos)))
                                    {

                                        Data[N2Cell.row, N2Cell.col].pastingcmplt = true;
                                        await Logger.WriteLogasTask(Logger.LogType.Running, "Nozzle2 ", "Working Conv1", "SNno : " + Data[N2Cell.row, N2Cell.col].SNno + "Pasted : " + Data[N2Cell.row, N2Cell.col].pastingcmplt, "Move and past");

                                        GlobalVariable.DIDO.WriteOPS(false, (int)EOutput.Pick_Place_Z2_Axis_Vaccuum_ON);
                                        await Task.Delay(10);
                                        GlobalVariable.DIDO.WriteOPS(true, (int)EOutput.Pick_Place_Z2_Axis_Vaccuum_Blow);
                                        //Vacuum_config.Vacuums_List[(int)Vacuum_config.Vacuums.Vacuum2].Both_Vacuum_and_Blow_Off();
                                        await Task.Delay(GlobalVariable.Z_Delay);
                                        GlobalVariable.DIDO.WriteOPS(false, (int)EOutput.Pick_Place_Z2_Axis_Vaccuum_Blow);


                                        Data[N2Cell.row, N2Cell.col].loadcellforce = Convert.ToDouble(GlobalVariable.loadconverz2.ToString());
                                        currentState = 190;



                                    }
                                }
                                else
                                {
                                    // MessageBox.Show("Z2 need to move ");
                                    _ = Task.Run(() => GantrySystem.MoveR2(PeekN2Pos, double.Parse(ccd2nozle2[6]) + (
                                        GlobalVariable.K_Enable ? GlobalVariable.offsetK[Data[N2Cell.row, N2Cell.col].cavityNo - 1].Rvalue :
                                        GlobalVariable.NK_Enable ? GlobalVariable.offsetNK[Data[N2Cell.row, N2Cell.col].cavityNo - 1].Rvalue :
                                        GlobalVariable.offset[Data[N2Cell.row, N2Cell.col].cavityNo - 1].Rvalue)));

                                }
                            }
                            break;

                        // =============== Z2 PASTE UP =================
                        case 190:
                            await Logger.WriteLogasTask(Logger.LogType.Running, "MoveAndPast", "Working Conv1", "Nozzle 2 Pasted and UP", "");
                            if (dryrun)
                            {
                                if (await Task.Run(() => NozzleSystem.Nozzle2Moveup(PeekN2Pos)))
                                {
                                    _ = Task.Run(() => ObjectList.Servo_R2.Move_Abs(double.Parse("0"), Convert.ToDouble(PeekN2Pos.RVel), Convert.ToDouble(PeekN2Pos.RAcc), Convert.ToDouble(PeekN2Pos.RDeAcc), 15000));
                                    updatecavity(N2Cell.row, N2Cell.col, "SN", 3, "SN");
                                    currentState = 200;
                                }
                            }
                            else
                            {
                                if (!HasN2Cavity)
                                {
                                    await GlobalVariable.AlarmTriggerAsync(ECode.queue_empty, true, 1, "", "Current Version: " + GlobalVariable.g_MachineVersion + "");
                                    break;
                                }
                                if (await Task.Run(() => NozzleSystem.Nozzle2Moveup(PeekN2Pos)))
                                {
                                    nozzle2WasDown = false; // nozzle safely up
                                    await Task.Delay(50);
                                    nozzle2WasDown = false; // nozzle safely up
                                    if (!GlobalVariable.DI[(int)EInput.Pick_Place_Z2_Axis_Vaccuum_Fb])
                                    {
                                        Task.Run(() => Logger.WriteLog(Logger.LogType.Error, "Working1Conveyor", "MoveAndPaste", "", "Nozzle Z2 has vaccum feed-back. Do you want to retry"));
                                        DialogResult res = MessageBox.Show("Nozzle Z2 has vaccum feed-back. Do you want to retry !", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);
                                        if (res == DialogResult.Yes)
                                        {
                                            Data[N2Cell.row, N2Cell.col].pastingcmplt = false;
                                            nozzle2Graphhitetaken = false;
                                            i_rejection = 10;
                                            await Logger.WriteLogasTask(Logger.LogType.Running, "MoveAndPast", "Working Conv1", "Nozzle 2 Pasted and UP - Vaccum feed back not reset ", "");

                                            await GoRejectionPlace(cts);
                                            GantrySystem.GoR2initialPos();
                                            currentState = 130;
                                        }
                                        else
                                        {
                                            Data[N2Cell.row, N2Cell.col].pastingcmplt = true;
                                            nozzle2Graphhitetaken = false;
                                            GantrySystem.GoR2initialPos();
                                            updatecavity(N2Cell.row, N2Cell.col, Data[N2Cell.row, N2Cell.col].SNno, 3, Data[0, 0].CarrierBarcode);
                                            currentState = 200;
                                        }
                                    }
                                    else if (GlobalVariable.DI[(int)EInput.Pick_Place_Z2_Axis_Vaccuum_Fb])
                                    {
                                        Data[N2Cell.row, N2Cell.col].pastingcmplt = true;
                                        nozzle2Graphhitetaken = false;
                                        GantrySystem.GoR2initialPos();
                                        updatecavity(N2Cell.row, N2Cell.col, Data[N2Cell.row, N2Cell.col].SNno, 3, Data[0, 0].CarrierBarcode);
                                        currentState = 200;
                                    }

                                }
                            }
                            break;

                        // =============== CLEANUP =================
                        case 200:
                            await Logger.WriteLogasTask(Logger.LogType.Running, "MoveAndPast", "Working Conv", "Cleaning Both Nozzles", "");
                            if (HasN1Cavity)
                            {
                                AdvanceN1Cavity();
                                if (production && ccd2nozzle1 != null)
                                {
                                    int l = ccd2nozzle1.Length;
                                    Array.Clear(ccd2nozzle1, 0, l);
                                }
                            }
                            if (HasN2Cavity)
                            {
                                AdvanceN2Cavity();
                                if (production && ccd2nozle2 != null)
                                {
                                    int l = ccd2nozle2.Length;
                                    Array.Clear(ccd2nozle2, 0, l);
                                }
                            }
                            if (!HasN1Cavity && !HasN2Cavity)
                            {
                                if (production)
                                    await Feeding.Feed();
                                currentState = 1000;
                            }
                            else if (HasN1Cavity || HasN2Cavity)
                            {
                                currentState = 70;
                            }
                            else
                                currentState = 70;
                            break;
                    }
                }
            }
            catch (OperationCanceledException ex)
            {
                await Logger.WriteLogasTask(Logger.LogType.Running, "MoveAndPast", "Working Conv1", ex.ToString(), "");
            }
            catch (Exception ex)
            {
                await Logger.WriteLogasTask(Logger.LogType.Error, "MoveAndPast", "Working Conv1", ex.ToString(), "");
            }
        }
        #endregion

        #region Build OK cavity lists (X1Y1- index tracking)
        private async Task createBlock()
        {
            await Logger.WriteLogasTask(Logger.LogType.Running, "createBlock", "Working Conv1", "Building OK cavity lists", "");
            await semaphoreSlim2.WaitAsync();
            try
            {
                if (pos == null) return;
                int rows = pos.GetLength(0);
                int cols = pos.GetLength(1);

                n1OkCavities.Clear();
                n2OkCavities.Clear();
                assemblyCavityN1 = 0;
                assemblyCavityN2 = 0;

                for (int row = 0; row < rows; row++)
                {
                    for (int col = 0; col < cols; col++)
                    {
                        if (GlobalVariable.CavityRows == 4 && GlobalVariable.CavityCols == 3)
                        {
                            if (production)
                            {
                                if (Data[row, col].ScannerData)
                                {
                                    if (row == 0 || row == 1)
                                    {

                                        n1OkCavities.Add((row, col));
                                        await Logger.WriteLogasTask(Logger.LogType.Running, " Create Block", "Working Conv1", "Row = " + row + " Col = " + col + " ScannerData = " + Data[row, col].ScannerData + "", "");

                                    }

                                    else if (row == 2 || row == 3)
                                    {
                                        n2OkCavities.Add((row, col));
                                        await Logger.WriteLogasTask(Logger.LogType.Running, " Create Block", "Working Conv1", "Row = " + row + "Col = " + col + "ScannerData = " + Data[row, col].ScannerData + "", "");

                                    }

                                }
                            }
                            else
                            {
                                if (row == 0 || row == 1)
                                {
                                    n1OkCavities.Add((row, col));
                                    await Logger.WriteLogasTask(Logger.LogType.Running, " Create Block", "Working Conv1", "Row = " + row + "Col = " + col + "ScannerData = " + Data[row, col].ScannerData + "", "");

                                }

                                else if (row == 2 || row == 3)
                                {
                                    n2OkCavities.Add((row, col));
                                    await Logger.WriteLogasTask(Logger.LogType.Running, " Create Block", "Working Conv1", "Row = " + row + "Col = " + col + "ScannerData = " + Data[row, col].ScannerData + "", "");

                                }

                            }
                        }
                        if (GlobalVariable.CavityRows == 3 && GlobalVariable.CavityCols == 4)
                        {
                            if (production)
                            {
                                if (Data[row, col].ScannerData)
                                {
                                    if (row == 0 || (row == 2 && col == 0) || (row == 2 && col == 2))
                                    {

                                        n1OkCavities.Add((row, col));
                                        await Logger.WriteLogasTask(Logger.LogType.Running, " Create Block", "Working Conv1", "Row = " + row + "Col = " + col + "Scanner SNno : " + Data[row, col].SNno + "ScannerData = " + Data[row, col].ScannerData, "");

                                    }

                                    else if (row == 1 || (row == 2 && col == 1) || (row == 2 && col == 3))
                                    {
                                        n2OkCavities.Add((row, col));
                                        await Logger.WriteLogasTask(Logger.LogType.Running, " Create Block", "Working Conv1", "Row = " + row + "Col = " + col + "Scanner SNno : " + Data[row, col].SNno + "ScannerData = " + Data[row, col].ScannerData, "");

                                    }

                                }
                            }
                            else
                            {
                                if (row == 0 || (row == 2 && col == 0) || (row == 2 && col == 2))
                                {
                                    n1OkCavities.Add((row, col));
                                    await Logger.WriteLogasTask(Logger.LogType.Running, " Create Block", "Working Conv1", "Row = " + row + "Col = " + col + "Scanner SNno : " + Data[row, col].SNno + "ScannerData = " + Data[row, col].ScannerData, "");

                                }

                                else if (row == 1 || (row == 2 && col == 1) || (row == 2 && col == 3))
                                {
                                    n2OkCavities.Add((row, col));
                                    await Logger.WriteLogasTask(Logger.LogType.Running, " Create Block", "Working Conv1", "Row = " + row + "Col = " + col + "Scanner SNno : " + Data[row, col].SNno + "ScannerData = " + Data[row, col].ScannerData, "");

                                }

                            }
                        }
                    }
                }
            }
            finally
            {
                semaphoreSlim2.Release();
            }
        }
        #endregion

        #region Rejection Sequence Start
        public static async Task GoRejectionPlace(CancellationToken token)
        {
            await semaphoreSlim1.WaitAsync(token);
            try
            {
                if (GlobalVariable.g_bMachineMode == GlobalVariable.OperationMode.DryRun)
                    GlobalVariable.LoadingConvWrk = true;
                if (GlobalVariable.g_bMachineMode == GlobalVariable.OperationMode.Production)
                    production = true;

                while (!token.IsCancellationRequested && i_rejection < 80)
                {
                    token.ThrowIfCancellationRequested();
                    if (GlobalVariable.current_MCStatus == GlobalVariable.MachineStatus.Running)
                    {
                        if (GlobalVariable.g_bMachineMode == GlobalVariable.OperationMode.DryRun)
                        {
                            if (!GlobalVariable.LoadingConvWrk)
                                continue;
                        }
                        await Task.Delay(50);
                        switch (i_rejection)
                        {
                            case 10:
                                running = true;
                                await Logger.WriteLogasTask(Logger.LogType.Running, "GoRejectionPlace", "Working Conv1", "Gantry Move Rejection Bin and Blow on", "");
                                if (await Task.Run(() => NozzleSystem.Nozzle1Moveup(GlobalVariable.SafePosition)))
                                    if (await Task.Run(() => NozzleSystem.Nozzle2Moveup(GlobalVariable.SafePosition)))
                                        if (await GantrySystem.move(GlobalVariable.Wk1_Rejpos))
                                        {
                                            if (!nozzle1Graphhitetaken && !nozzle2Graphhitetaken)
                                            {
                                                Vacuum_config.Vacuums_List[(int)Vacuum_config.Vacuums.Vacuum1].Blow_On();
                                                Vacuum_config.Vacuums_List[(int)Vacuum_config.Vacuums.Vacuum2].Blow_On();
                                                await Task.Delay(200);
                                                Vacuum_config.Vacuums_List[(int)Vacuum_config.Vacuums.Vacuum1].Both_Vacuum_and_Blow_Off();
                                                Vacuum_config.Vacuums_List[(int)Vacuum_config.Vacuums.Vacuum2].Both_Vacuum_and_Blow_Off();

                                                if ((GlobalVariable.DI[(int)DIDO.EInput.Pick_Place_Z1_Axis_Vaccuum_Fb]) && (GlobalVariable.DI[(int)DIDO.EInput.Pick_Place_Z2_Axis_Vaccuum_Fb]))
                                                {
                                                    Vacuum_config.Vacuums_List[(int)Vacuum_config.Vacuums.Vacuum1].Blow_On();
                                                    Vacuum_config.Vacuums_List[(int)Vacuum_config.Vacuums.Vacuum2].Blow_On();
                                                    await Task.Delay(200);
                                                    Vacuum_config.Vacuums_List[(int)Vacuum_config.Vacuums.Vacuum1].Both_Vacuum_and_Blow_Off();
                                                    Vacuum_config.Vacuums_List[(int)Vacuum_config.Vacuums.Vacuum2].Both_Vacuum_and_Blow_Off();
                                                }
                                                GlobalVariable.dGlobal_GraphiteToss_Count = GlobalVariable.dGlobal_GraphiteToss_Count + 2;
                                                ProductionDataSaver.TossingdataFile("2", GlobalVariable.dGlobal_GraphiteToss_Count);
                                            }
                                            else if (!nozzle1Graphhitetaken)
                                            {
                                                Vacuum_config.Vacuums_List[(int)Vacuum_config.Vacuums.Vacuum1].Blow_On();
                                                await Task.Delay(300);
                                                Vacuum_config.Vacuums_List[(int)Vacuum_config.Vacuums.Vacuum1].Both_Vacuum_and_Blow_Off();
                                                if ((GlobalVariable.DI[(int)DIDO.EInput.Pick_Place_Z1_Axis_Vaccuum_Fb]))
                                                {
                                                    Vacuum_config.Vacuums_List[(int)Vacuum_config.Vacuums.Vacuum1].Blow_On();
                                                    await Task.Delay(200);
                                                    Vacuum_config.Vacuums_List[(int)Vacuum_config.Vacuums.Vacuum1].Both_Vacuum_and_Blow_Off();
                                                }
                                                GlobalVariable.dGlobal_GraphiteToss_Count = GlobalVariable.dGlobal_GraphiteToss_Count + 1;
                                                ProductionDataSaver.TossingdataFile("1", GlobalVariable.dGlobal_GraphiteToss_Count);
                                            }
                                            else
                                            {
                                                Vacuum_config.Vacuums_List[(int)Vacuum_config.Vacuums.Vacuum2].Blow_On();
                                                await Task.Delay(300);
                                                Vacuum_config.Vacuums_List[(int)Vacuum_config.Vacuums.Vacuum2].Both_Vacuum_and_Blow_Off();
                                                if ((GlobalVariable.DI[(int)DIDO.EInput.Pick_Place_Z2_Axis_Vaccuum_Fb]))
                                                {
                                                    Vacuum_config.Vacuums_List[(int)Vacuum_config.Vacuums.Vacuum2].Blow_On();
                                                    await Task.Delay(200);
                                                    Vacuum_config.Vacuums_List[(int)Vacuum_config.Vacuums.Vacuum2].Both_Vacuum_and_Blow_Off();
                                                }
                                                GlobalVariable.dGlobal_GraphiteToss_Count = GlobalVariable.dGlobal_GraphiteToss_Count + 1;
                                                ProductionDataSaver.TossingdataFile("1", GlobalVariable.dGlobal_GraphiteToss_Count);
                                            }
                                            await Task.Delay(50);
                                            i_rejection = 30;
                                        }
                                break;

                            case 30:
                                await Logger.WriteLogasTask(Logger.LogType.Running, "GoRejectionPlace", "Working Conv1", "Gantry Moving Feeder position", "");
                                await GoFeederPlace(token);
                                i_rejection = 60;
                                break;

                            case 60:
                                if (!firsttiimewait)
                                {
                                    if (await GantrySystem.move(pos[0, 0]))
                                    {
                                        await Task.Delay(100);
                                        firsttiimewait = true;
                                        running = false;
                                        i_rejection = 100;
                                    }
                                }
                                else
                                {
                                    await Task.Delay(100);
                                    firsttiimewait = true;
                                    running = false;
                                    i_rejection = 100;
                                }
                                break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                //Arulkumar Fixed random stoppage start
                await Logger.WriteLogasTask(Logger.LogType.Error, "WorkingConveyor1", "GoRejection", ex.Message, ex.ToString());
                //Arulkumar Fixed random stoppage end
            }
            finally { semaphoreSlim1.Release(); }
        }
        #endregion

        #region Feeder
        public static async Task GoFeederPlace(CancellationToken token)
        {
            GlobalVariable.LoadReceipe();
            i_feed = 30;
            bool N1left = false;
            bool N1left2 = false;
            bool N1right = false;
            bool N1right2 = false;
            bool N2left = false;
            bool N2left2 = false;
            bool N2right = false;
            bool N2right2 = false;
            if (GlobalVariable.g_bMachineMode == GlobalVariable.OperationMode.DryRun)
                dryrun = true;
            if (GlobalVariable.g_bMachineMode == GlobalVariable.OperationMode.Production)
                production = true;

            while (!token.IsCancellationRequested && i_feed < 80)
            {
                token.ThrowIfCancellationRequested();
                await Task.Delay(10);
                //SafePauseEventWait(); // cmd by arul
                if (GlobalVariable.b_gPause)
                {
                    SafePauseEventWait();
                    await Task.Delay(100);
                    continue;
                }
                if (GlobalVariable.current_MCStatus == GlobalVariable.MachineStatus.Running)
                {
                    await Task.Delay(100);
                    #region Four Graphite Slot Logic
                    if (GlobalVariable.Four_Graphit)
                    {
                        switch (i_feed)
                        {
                            case 30:
                                await Logger.WriteLogasTask(Logger.LogType.Running, " GoFeederPlace", "Working Conv1", "Feeder Position Camera Trigger", "");
                                if (production)
                                {
                                    if (!nozzle1Graphhitetaken || !nozzle2Graphhitetaken)
                                    {
                                        if (splitdataccd3 != null)
                                        {
                                            int l = splitdataccd3.Length;
                                            Array.Clear(splitdataccd3, 0, l);
                                        }
                                        double Xpos = GantrySystem.getcurrentpos(ObjectList.Servo_X1);
                                        double Ypos = GantrySystem.getcurrentpos(ObjectList.Servo_Y1);
                                        double A1 = GantrySystem.getcurrentpos(ObjectList.Servo_R1);

                                        if (Count_CCD4 == 4)
                                        {
                                            await GantrySystem.move(GlobalVariable.Wk1_Z2FedPos, GlobalVariable.WK1_initial.PositionX, GlobalVariable.WK1_initial.PositionY);
                                            GlobalVariable.CCD4_Trigger_Fail = true;
                                            DialogResult res = MessageBox.Show("CCD4 Trigger fail,Please Feed", "Alarm", MessageBoxButtons.OK, MessageBoxIcon.Question,
                                                                MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);
                                            if (res == DialogResult.OK)
                                            {
                                                GlobalVariable.CCD4_Trigger_Fail = false;
                                                Count_CCD4 = 0;
                                                break;
                                            }
                                            else
                                                break;
                                        }

                                        string dtm = DateTime.Now.ToString("HHmmss");
                                        String cmd1 = "T3,2,T3_" + dtm + "_NA_NA,1," + GlobalVariable.TrainNozzle1.PositionX + "," + GlobalVariable.TrainNozzle1.PositionY + "," + GlobalVariable.TrainNozzle1.PositionR1 + ",2," + GlobalVariable.TrainNozzle2.PositionX + "," + GlobalVariable.TrainNozzle2.PositionY + "," + GlobalVariable.TrainNozzle2.PositionR2;
                                        string ScnrResult = await camera.Trig_Camera(ObjectList.CCD1, cmd1);
                                        //Arulkumar Fixed Hung start
                                        int scnrRetryCount = 0;
                                        while (ScnrResult == null && scnrRetryCount < MAX_SAFE_RETRIES)
                                        {
                                            scnrRetryCount++;
                                            ScnrResult = await camera.Trig_Camera(ObjectList.CCD1, cmd1);
                                        }
                                        //Arulkumar Fixed Hung end

                                        Count_CCD4++;
                                        fedTime_stmp = dtm;
                                        if (ScnrResult == null || ScnrResult == "null" || ScnrResult == "")
                                        {
                                            ScnrResult = await camera.Trig_Camera(ObjectList.CCD1, cmd1);

                                        }
                                        splitdataccd3 = ScnrResult.Split(',');

                                        N1left = N1left2 = N1right = N1right2 = false;
                                        N2left = N2left2 = N2right = N2right2 = false;

                                        if (!splitdataccd3[2].Contains("999") && !splitdataccd3[3].Contains("999") && !splitdataccd3[4].Contains("999"))
                                        {
                                            N1left = true;
                                            N2left = true;
                                        }
                                        if (!splitdataccd3[5].Contains("999") && !splitdataccd3[6].Contains("999") && !splitdataccd3[7].Contains("999"))
                                        {
                                            N1left2 = true;
                                            N2left2 = true;
                                        }
                                        if (!splitdataccd3[8].Contains("999") && !splitdataccd3[9].Contains("999") && !splitdataccd3[10].Contains("999"))
                                        {
                                            N1right = true;
                                            N2right = true;
                                        }
                                        if (!splitdataccd3[11].Contains("999") && !splitdataccd3[12].Contains("999") && !splitdataccd3[13].Contains("999"))
                                        {
                                            N1right2 = true;
                                            N2right2 = true;
                                        }
                                        if (!splitdataccd3[15].Contains("999") && !splitdataccd3[16].Contains("999") && !splitdataccd3[17].Contains("999"))
                                        {
                                            N2left = true;
                                            N1left = true;
                                        }
                                        if (!splitdataccd3[18].Contains("999") && !splitdataccd3[19].Contains("999") && !splitdataccd3[20].Contains("999"))
                                        {
                                            N1left2 = true;
                                            N2left2 = true;
                                        }
                                        if (!splitdataccd3[21].Contains("999") && !splitdataccd3[22].Contains("999") && !splitdataccd3[23].Contains("999"))
                                        {
                                            N2right = true;
                                            N1right = true;
                                        }
                                        if (!splitdataccd3[24].Contains("999") && !splitdataccd3[25].Contains("999") && !splitdataccd3[26].Contains("999"))
                                        {
                                            N1right2 = true;
                                            N2right2 = true;
                                        }
                                    }
                                    else
                                    {
                                        return;
                                    }
                                }
                                else
                                {
                                    String cmd1 = "T3,1,SN,1,276.493,-312.";
                                    string ScnrResult = await camera.Trig_Camera(ObjectList.CCD1, cmd1);
                                }
                                i_feed = 40;
                                break;

                            case 40:
                                if (production)
                                {
                                    if (!nozzle1Graphhitetaken)
                                    {
                                        if (N1left)
                                        {
                                            Count_CCD4 = 0;
                                            if (double.Parse(splitdataccd3[2]) > -20 && double.Parse(splitdataccd3[3]) < 300)
                                            {
                                                if (Safe(GlobalVariable.Wk1_Z1FedPos.PositionX, double.Parse(splitdataccd3[2]), currentState, step) &&
                                                    Safe(GlobalVariable.Wk1_Z1FedPos.PositionY, double.Parse(splitdataccd3[3]), currentState, step))
                                                {
                                                    if (GlobalVariable.K_Enable)
                                                    {
                                                        Task T1 = Task.Run(() => GantrySystem.move(GlobalVariable.Wk1_Z1FedPos, double.Parse(splitdataccd3[2]) + GlobalVariable.offsetK[12].Xvalue, double.Parse(splitdataccd3[3]) + GlobalVariable.offsetK[12].Yvalue));
                                                        Task T2 = Task.Run(() => GantrySystem.MoveR1(GlobalVariable.Nozzle_loc_Z1, (double.Parse(splitdataccd3[4]) + GlobalVariable.offsetK[12].Rvalue)));
                                                        await Task.WhenAll(T1, T2);
                                                    }
                                                    else if (GlobalVariable.NK_Enable)
                                                    {
                                                        Task T1 = Task.Run(() => GantrySystem.move(GlobalVariable.Wk1_Z1FedPos, double.Parse(splitdataccd3[2]) + GlobalVariable.offsetNK[12].Xvalue, double.Parse(splitdataccd3[3]) + GlobalVariable.offsetNK[12].Yvalue));
                                                        Task T2 = Task.Run(() => GantrySystem.MoveR1(GlobalVariable.Nozzle_loc_Z1, (double.Parse(splitdataccd3[4]) + GlobalVariable.offsetNK[12].Rvalue)));
                                                        await Task.WhenAll(T1, T2);
                                                    }
                                                    else
                                                    {
                                                        Task T1 = Task.Run(() => GantrySystem.move(GlobalVariable.Wk1_Z1FedPos, double.Parse(splitdataccd3[2]) + GlobalVariable.offset[12].Xvalue, double.Parse(splitdataccd3[3]) + GlobalVariable.offset[12].Yvalue));
                                                        Task T2 = Task.Run(() => GantrySystem.MoveR1(GlobalVariable.Nozzle_loc_Z1, (double.Parse(splitdataccd3[4]) + GlobalVariable.offset[12].Rvalue)));
                                                        await Task.WhenAll(T1, T2);
                                                    }
                                                    N2left = false;
                                                }
                                                else { i_feed = 30; break; }
                                            }
                                        }
                                        else if (N1left2)
                                        {
                                            Count_CCD4 = 0;
                                            if (double.Parse(splitdataccd3[5]) > -20 && double.Parse(splitdataccd3[6]) < 300)
                                            {
                                                if (Safe(GlobalVariable.Wk1_Z1FedPos2.PositionX, double.Parse(splitdataccd3[5]), currentState, step) &&
                                                    Safe(GlobalVariable.Wk1_Z1FedPos2.PositionY, double.Parse(splitdataccd3[6]), currentState, step))
                                                {
                                                    if (GlobalVariable.K_Enable)
                                                    {
                                                        Task T5 = Task.Run(() => GantrySystem.move(GlobalVariable.Wk1_Z1FedPos, double.Parse(splitdataccd3[5]) + GlobalVariable.offsetK[13].Xvalue, double.Parse(splitdataccd3[6]) + GlobalVariable.offsetK[13].Yvalue));
                                                        Task T6 = Task.Run(() => GantrySystem.MoveR1(GlobalVariable.Nozzle_loc_Z1, (double.Parse(splitdataccd3[7]) + GlobalVariable.offsetK[13].Rvalue)));
                                                        await Task.WhenAll(T5, T6);
                                                    }
                                                    else if (GlobalVariable.NK_Enable)
                                                    {
                                                        Task T5 = Task.Run(() => GantrySystem.move(GlobalVariable.Wk1_Z1FedPos, double.Parse(splitdataccd3[5]) + GlobalVariable.offsetNK[13].Xvalue, double.Parse(splitdataccd3[6]) + GlobalVariable.offsetNK[13].Yvalue));
                                                        Task T6 = Task.Run(() => GantrySystem.MoveR1(GlobalVariable.Nozzle_loc_Z1, (double.Parse(splitdataccd3[7]) + GlobalVariable.offsetNK[13].Rvalue)));
                                                        await Task.WhenAll(T5, T6);
                                                    }
                                                    else
                                                    {
                                                        Task T5 = Task.Run(() => GantrySystem.move(GlobalVariable.Wk1_Z1FedPos, double.Parse(splitdataccd3[5]) + GlobalVariable.offset[13].Xvalue, double.Parse(splitdataccd3[6]) + GlobalVariable.offset[13].Yvalue));
                                                        Task T6 = Task.Run(() => GantrySystem.MoveR1(GlobalVariable.Nozzle_loc_Z1, (double.Parse(splitdataccd3[7]) + GlobalVariable.offset[13].Rvalue)));
                                                        await Task.WhenAll(T5, T6);
                                                    }
                                                    N2left2 = false;
                                                }
                                                else { i_feed = 30; break; }
                                            }
                                        }
                                        else if (N1right)
                                        {
                                            Count_CCD4 = 0;
                                            if (double.Parse(splitdataccd3[8]) > -20 && double.Parse(splitdataccd3[9]) < 300)
                                            {
                                                if (Safe(GlobalVariable.Wk1_Z1FedPos3.PositionX, double.Parse(splitdataccd3[8]), currentState, step) &&
                                                    Safe(GlobalVariable.Wk1_Z1FedPos3.PositionY, double.Parse(splitdataccd3[9]), currentState, step))
                                                {
                                                    if (GlobalVariable.K_Enable)
                                                    {
                                                        Task T9 = Task.Run(() => GantrySystem.move(GlobalVariable.Wk1_Z1FedPos3, double.Parse(splitdataccd3[8]) + GlobalVariable.offsetK[16].Xvalue, double.Parse(splitdataccd3[9]) + GlobalVariable.offsetK[16].Yvalue));
                                                        Task T10 = Task.Run(() => GantrySystem.MoveR1(GlobalVariable.Nozzle_loc_Z1, (double.Parse(splitdataccd3[10]) + GlobalVariable.offsetK[16].Rvalue)));
                                                        await Task.WhenAll(T9, T10);
                                                    }
                                                    else
                                                    if (GlobalVariable.NK_Enable)
                                                    {
                                                        Task T9 = Task.Run(() => GantrySystem.move(GlobalVariable.Wk1_Z1FedPos3, double.Parse(splitdataccd3[8]) + GlobalVariable.offsetNK[16].Xvalue, double.Parse(splitdataccd3[9]) + GlobalVariable.offsetNK[16].Yvalue));
                                                        Task T10 = Task.Run(() => GantrySystem.MoveR1(GlobalVariable.Nozzle_loc_Z1, (double.Parse(splitdataccd3[10]) + GlobalVariable.offsetNK[16].Rvalue)));
                                                        await Task.WhenAll(T9, T10);
                                                    }
                                                    else
                                                    {
                                                        Task T9 = Task.Run(() => GantrySystem.move(GlobalVariable.Wk1_Z1FedPos3, double.Parse(splitdataccd3[8]) + GlobalVariable.offset[16].Xvalue, double.Parse(splitdataccd3[9]) + GlobalVariable.offset[16].Yvalue));
                                                        Task T10 = Task.Run(() => GantrySystem.MoveR1(GlobalVariable.Nozzle_loc_Z1, (double.Parse(splitdataccd3[10]) + GlobalVariable.offset[16].Rvalue)));
                                                        await Task.WhenAll(T9, T10);
                                                    }
                                                    N2right = false;
                                                }
                                                else { i_feed = 30; break; }
                                            }
                                        }
                                        else if (N1right2)
                                        {
                                            Count_CCD4 = 0;
                                            if (double.Parse(splitdataccd3[11]) > -20 && double.Parse(splitdataccd3[12]) < 300)
                                            {
                                                if (Safe(GlobalVariable.Wk1_Z1FedPos4.PositionX, double.Parse(splitdataccd3[11]), currentState, step) &&
                                                    Safe(GlobalVariable.Wk1_Z1FedPos4.PositionY, double.Parse(splitdataccd3[12]), currentState, step))
                                                {
                                                    if (GlobalVariable.K_Enable)
                                                    {
                                                        Task T13 = Task.Run(() => GantrySystem.move(GlobalVariable.Wk1_Z1FedPos4, double.Parse(splitdataccd3[11]) + GlobalVariable.offsetK[17].Xvalue, double.Parse(splitdataccd3[12]) + GlobalVariable.offsetK[17].Yvalue));
                                                        Task T14 = Task.Run(() => GantrySystem.MoveR1(GlobalVariable.Nozzle_loc_Z1, (double.Parse(splitdataccd3[13]) + GlobalVariable.offsetK[17].Rvalue)));
                                                        await Task.WhenAll(T13, T14);
                                                    }
                                                    else
                                                    if (GlobalVariable.NK_Enable)
                                                    {
                                                        Task T13 = Task.Run(() => GantrySystem.move(GlobalVariable.Wk1_Z1FedPos4, double.Parse(splitdataccd3[11]) + GlobalVariable.offsetNK[17].Xvalue, double.Parse(splitdataccd3[12]) + GlobalVariable.offsetNK[17].Yvalue));
                                                        Task T14 = Task.Run(() => GantrySystem.MoveR1(GlobalVariable.Nozzle_loc_Z1, (double.Parse(splitdataccd3[13]) + GlobalVariable.offsetNK[17].Rvalue)));
                                                        await Task.WhenAll(T13, T14);
                                                    }
                                                    else
                                                    {
                                                        Task T13 = Task.Run(() => GantrySystem.move(GlobalVariable.Wk1_Z1FedPos4, double.Parse(splitdataccd3[11]) + GlobalVariable.offset[17].Xvalue, double.Parse(splitdataccd3[12]) + GlobalVariable.offset[17].Yvalue));
                                                        Task T14 = Task.Run(() => GantrySystem.MoveR1(GlobalVariable.Nozzle_loc_Z1, (double.Parse(splitdataccd3[13]) + GlobalVariable.offset[17].Rvalue)));
                                                        await Task.WhenAll(T13, T14);
                                                    }
                                                    N2right2 = false;
                                                }
                                                else { i_feed = 30; break; }
                                            }
                                        }
                                        else
                                        {
                                            await GantrySystem.move(GlobalVariable.Wk1_Z2FedPos, GlobalVariable.Wk1_Z1CCD2pos.PositionX, GlobalVariable.Wk1_Z1CCD2pos.PositionY);
                                            await Task.Run(async () => await Feeding.Feed());
                                            i_feed = 30;
                                            break;
                                        }
                                    }
                                    else { i_feed = 45; break; }
                                }
                                else
                                    await GantrySystem.GoWK1Z1FeedPos();
                                i_feed = 45;
                                break;

                            case 45:
                                if (dryrun)
                                {
                                    await Task.Run(() => NozzleSystem.Nozzle1MoveDown(GlobalVariable.Wk1_Z1FedPos));
                                }
                                else if (!nozzle1Graphhitetaken)
                                {
                                    if (GantrySystem.getcurrentpos(ObjectList.Servo_Y1) < GlobalVariable.Servo_Y1_Min_N1 && GantrySystem.getcurrentpos(ObjectList.Servo_X1) > GlobalVariable.Servo_X1_Min_N1 && GantrySystem.getcurrentpos(ObjectList.Servo_X1) < GlobalVariable.Servo_X1_Max_N1)
                                    {
                                        GlobalVariable.DIDO.WriteOPS(true, (int)EOutput.Pick_Place_Z1_Axis_Vaccuum_ON);
                                        await Task.Run(() => NozzleSystem.Nozzle1MoveDown(GlobalVariable.Wk1_Z1FedPos));
                                        GlobalVariable.Z1_Pickedup = true;
                                        Z1_Trigger_While = false;
                                    }
                                    await Task.Delay(50);
                                }
                                i_feed = 47;
                                break;

                            case 47:
                                if (dryrun)
                                {
                                    await Task.Run(() => NozzleSystem.Nozzle1Moveup(GlobalVariable.Wk1_Z1FedPos));
                                }
                                else if (!nozzle1Graphhitetaken)
                                {
                                    await Task.Run(() => NozzleSystem.Nozzle1Moveup(GlobalVariable.Wk1_Z1FedPos));
                                    //await GantrySystem.move(GlobalVariable.Wk1_Z2CCD2pos);
                                    _ = Task.Run(() => GantrySystem.MoveR1(GlobalVariable.TrainNozzle1));

                                    nozzle1Graphhitetaken = true;
                                }
                                i_feed = 50;
                                break;

                            case 50:
                                if (production)
                                {
                                    if (!nozzle2Graphhitetaken)
                                    {
                                        if (N2right)
                                        {
                                            if (double.Parse(splitdataccd3[21]) > -20 && double.Parse(splitdataccd3[22]) < 300)
                                            {
                                                if (Safe(GlobalVariable.Wk1_Z2FedPos3.PositionX, double.Parse(splitdataccd3[21]), currentState, step) &&
                                                    Safe(GlobalVariable.Wk1_Z2FedPos3.PositionY, double.Parse(splitdataccd3[22]), currentState, step))
                                                {
                                                    if (GlobalVariable.K_Enable)
                                                    {
                                                        Task T5 = Task.Run(() => GantrySystem.move(GlobalVariable.Wk1_Z2FedPos3, double.Parse(splitdataccd3[21]) + GlobalVariable.offsetK[18].Xvalue, double.Parse(splitdataccd3[22]) + GlobalVariable.offsetK[18].Yvalue));
                                                        Task T6 = Task.Run(() => GantrySystem.MoveR2(GlobalVariable.Nozzle_loc_Z2, double.Parse(splitdataccd3[23]) + GlobalVariable.offsetK[18].Rvalue));
                                                        await Task.WhenAll(T5, T6);
                                                    }
                                                    else
                                                    if (GlobalVariable.NK_Enable)
                                                    {
                                                        Task T5 = Task.Run(() => GantrySystem.move(GlobalVariable.Wk1_Z2FedPos3, double.Parse(splitdataccd3[21]) + GlobalVariable.offsetNK[18].Xvalue, double.Parse(splitdataccd3[22]) + GlobalVariable.offsetNK[18].Yvalue));
                                                        Task T6 = Task.Run(() => GantrySystem.MoveR2(GlobalVariable.Nozzle_loc_Z2, double.Parse(splitdataccd3[23]) + GlobalVariable.offsetNK[18].Rvalue));
                                                        await Task.WhenAll(T5, T6);
                                                    }
                                                    else
                                                    {
                                                        Task T5 = Task.Run(() => GantrySystem.move(GlobalVariable.Wk1_Z2FedPos3, double.Parse(splitdataccd3[21]) + GlobalVariable.offset[18].Xvalue, double.Parse(splitdataccd3[22]) + GlobalVariable.offset[18].Yvalue));
                                                        Task T6 = Task.Run(() => GantrySystem.MoveR2(GlobalVariable.Nozzle_loc_Z2, double.Parse(splitdataccd3[23]) + GlobalVariable.offset[18].Rvalue));
                                                        await Task.WhenAll(T5, T6);
                                                    }
                                                    N1right = false;
                                                }
                                                else { i_feed = 30; break; }
                                            }
                                        }
                                        else if (N2right2)
                                        {
                                            if (double.Parse(splitdataccd3[24]) > -20 && double.Parse(splitdataccd3[25]) < 300)
                                            {
                                                if (Safe(GlobalVariable.Wk1_Z2FedPos4.PositionX, double.Parse(splitdataccd3[24]), currentState, step) &&
                                                    Safe(GlobalVariable.Wk1_Z2FedPos4.PositionY, double.Parse(splitdataccd3[25]), currentState, step))
                                                {
                                                    if (GlobalVariable.K_Enable)
                                                    {
                                                        Task T6 = Task.Run(() => GantrySystem.move(GlobalVariable.Wk1_Z2FedPos4, double.Parse(splitdataccd3[24]) + GlobalVariable.offsetK[19].Xvalue, double.Parse(splitdataccd3[25]) + GlobalVariable.offsetK[19].Yvalue));
                                                        Task T7 = Task.Run(() => GantrySystem.MoveR2(GlobalVariable.Nozzle_loc_Z2, (double.Parse(splitdataccd3[26]) + GlobalVariable.offsetK[19].Rvalue)));
                                                        await Task.WhenAll(T6, T7);
                                                    }
                                                    else
                                                    if (GlobalVariable.NK_Enable)
                                                    {
                                                        Task T6 = Task.Run(() => GantrySystem.move(GlobalVariable.Wk1_Z2FedPos4, double.Parse(splitdataccd3[24]) + GlobalVariable.offsetNK[19].Xvalue, double.Parse(splitdataccd3[25]) + GlobalVariable.offsetNK[19].Yvalue));
                                                        Task T7 = Task.Run(() => GantrySystem.MoveR2(GlobalVariable.Nozzle_loc_Z2, (double.Parse(splitdataccd3[26]) + GlobalVariable.offsetNK[19].Rvalue)));
                                                        await Task.WhenAll(T6, T7);
                                                    }
                                                    else
                                                    {
                                                        Task T6 = Task.Run(() => GantrySystem.move(GlobalVariable.Wk1_Z2FedPos4, double.Parse(splitdataccd3[24]) + GlobalVariable.offset[19].Xvalue, double.Parse(splitdataccd3[25]) + GlobalVariable.offset[19].Yvalue));
                                                        Task T7 = Task.Run(() => GantrySystem.MoveR2(GlobalVariable.Nozzle_loc_Z2, (double.Parse(splitdataccd3[26]) + GlobalVariable.offset[19].Rvalue)));
                                                        await Task.WhenAll(T6, T7);
                                                    }
                                                    N1right2 = false;
                                                }
                                                else { i_feed = 30; break; }
                                            }
                                        }
                                        else if (N2left)
                                        {
                                            try
                                            {
                                                if (Safe(GlobalVariable.Wk1_Z2FedPos1.PositionX, double.Parse(splitdataccd3[15]), currentState, step) &&
                                                    Safe(GlobalVariable.Wk1_Z2FedPos1.PositionY, double.Parse(splitdataccd3[16]), currentState, step))
                                                {
                                                    if (GlobalVariable.K_Enable)
                                                    {
                                                        Task T7 = Task.Run(() => GantrySystem.move(GlobalVariable.Wk1_Z2FedPos1, double.Parse(splitdataccd3[15]) + GlobalVariable.offsetK[14].Xvalue, double.Parse(splitdataccd3[16]) + GlobalVariable.offsetK[14].Yvalue));
                                                        Task T8 = Task.Run(() => GantrySystem.MoveR2(GlobalVariable.Nozzle_loc_Z2, (double.Parse(splitdataccd3[17]) + GlobalVariable.offsetK[14].Rvalue)));
                                                        await Task.WhenAll(T7, T8);
                                                    }
                                                    else
                                                    if (GlobalVariable.NK_Enable)
                                                    {
                                                        Task T7 = Task.Run(() => GantrySystem.move(GlobalVariable.Wk1_Z2FedPos1, double.Parse(splitdataccd3[15]) + GlobalVariable.offsetNK[14].Xvalue, double.Parse(splitdataccd3[16]) + GlobalVariable.offsetNK[14].Yvalue));
                                                        Task T8 = Task.Run(() => GantrySystem.MoveR2(GlobalVariable.Nozzle_loc_Z2, (double.Parse(splitdataccd3[17]) + GlobalVariable.offsetNK[14].Rvalue)));
                                                        await Task.WhenAll(T7, T8);
                                                    }
                                                    else
                                                    {
                                                        Task T7 = Task.Run(() => GantrySystem.move(GlobalVariable.Wk1_Z2FedPos1, double.Parse(splitdataccd3[15]) + GlobalVariable.offset[14].Xvalue, double.Parse(splitdataccd3[16]) + GlobalVariable.offset[14].Yvalue));
                                                        Task T8 = Task.Run(() => GantrySystem.MoveR2(GlobalVariable.Nozzle_loc_Z2, (double.Parse(splitdataccd3[17]) + GlobalVariable.offset[14].Rvalue)));
                                                        await Task.WhenAll(T7, T8);
                                                    }
                                                    N1left = false;
                                                }
                                                else { i_feed = 30; break; }
                                            }
                                            catch (Exception) { }
                                        }
                                        else if (N2left2)
                                        {
                                            try
                                            {
                                                if (Safe(GlobalVariable.Wk1_Z2FedPos.PositionX, double.Parse(splitdataccd3[18]), currentState, step) &&
                                                    Safe(GlobalVariable.Wk1_Z2FedPos.PositionY, double.Parse(splitdataccd3[19]), currentState, step))
                                                {
                                                    if (GlobalVariable.K_Enable)
                                                    {
                                                        Task T8 = Task.Run(() => GantrySystem.move(GlobalVariable.Wk1_Z2FedPos, double.Parse(splitdataccd3[18]) + GlobalVariable.offsetK[15].Xvalue, double.Parse(splitdataccd3[19]) + GlobalVariable.offsetK[15].Yvalue));
                                                        Task T9 = Task.Run(() => GantrySystem.MoveR2(GlobalVariable.Nozzle_loc_Z2, (double.Parse(splitdataccd3[20]) + GlobalVariable.offsetK[15].Rvalue)));
                                                        await Task.WhenAll(T8, T9);
                                                    }
                                                    else
                                                    if (GlobalVariable.NK_Enable)
                                                    {
                                                        Task T8 = Task.Run(() => GantrySystem.move(GlobalVariable.Wk1_Z2FedPos, double.Parse(splitdataccd3[18]) + GlobalVariable.offsetNK[15].Xvalue, double.Parse(splitdataccd3[19]) + GlobalVariable.offsetNK[15].Yvalue));
                                                        Task T9 = Task.Run(() => GantrySystem.MoveR2(GlobalVariable.Nozzle_loc_Z2, (double.Parse(splitdataccd3[20]) + GlobalVariable.offsetNK[15].Rvalue)));
                                                        await Task.WhenAll(T8, T9);
                                                    }
                                                    else
                                                    {
                                                        Task T8 = Task.Run(() => GantrySystem.move(GlobalVariable.Wk1_Z2FedPos, double.Parse(splitdataccd3[18]) + GlobalVariable.offset[15].Xvalue, double.Parse(splitdataccd3[19]) + GlobalVariable.offset[15].Yvalue));
                                                        Task T9 = Task.Run(() => GantrySystem.MoveR2(GlobalVariable.Nozzle_loc_Z2, (double.Parse(splitdataccd3[20]) + GlobalVariable.offset[15].Rvalue)));
                                                        await Task.WhenAll(T8, T9);
                                                    }
                                                    N1left2 = false;
                                                }
                                                else { i_feed = 30; break; }
                                            }
                                            catch (Exception) { }
                                        }
                                        else
                                        {
                                            await GantrySystem.move(GlobalVariable.Wk1_Z2FedPos, GlobalVariable.Wk1_Z1CCD2pos.PositionX, GlobalVariable.Wk1_Z1CCD2pos.PositionY);
                                            _ = Task.Run(async () => await Feeding.Feed());
                                            i_feed = 30;
                                            break;
                                        }
                                    }
                                    else { i_feed = 70; break; }
                                }
                                else
                                    await GantrySystem.GoWK1Z2FeedPos();
                                i_feed = 60;
                                break;

                            case 60:
                                if (dryrun)
                                {
                                    await Task.Run(() => NozzleSystem.Nozzle2MoveDown(GlobalVariable.Wk1_Z2FedPos));
                                }
                                else if (!nozzle2Graphhitetaken)
                                {
                                    if (GantrySystem.getcurrentpos(ObjectList.Servo_Y1) < GlobalVariable.Servo_Y1_Min_N2 && GantrySystem.getcurrentpos(ObjectList.Servo_X1) > GlobalVariable.Servo_X1_Min_N2 && GantrySystem.getcurrentpos(ObjectList.Servo_X1) < GlobalVariable.Servo_X1_Max_N2)
                                    {
                                        GlobalVariable.DIDO.WriteOPS(true, (int)EOutput.Pick_Place_Z2_Axis_Vaccuum_ON);
                                        await Task.Run(() => NozzleSystem.Nozzle2MoveDown(GlobalVariable.Wk1_Z2FedPos));
                                        nozzle2Graphhitetaken = true;
                                    }
                                }
                                i_feed = 70;
                                break;

                            case 70:
                                if (await Task.Run(() => NozzleSystem.Nozzle2Moveup(GlobalVariable.SafePosition)))
                                {
                                    if (production)
                                    {
                                        if (nozzle2Graphhitetaken && nozzle1Graphhitetaken)
                                            _ = Task.Run(async () => await Feeding.Feed());
                                        _ = Task.Run(() => GantrySystem.MoveR2(GlobalVariable.TrainNozzle2));

                                        //await Task.Run(async () => await Feeding.Feed());
                                    }
                                    Z2_Trigger_While = false;
                                    GlobalVariable.Z2_Pickedup = true;
                                    i_feed = 80;
                                }
                                break;
                        }
                    }
                    else
                    {
                        switch (i_feed)
                        {
                            case 30:
                                await Logger.WriteLogasTask(Logger.LogType.Running, " GoFeederPlace", "Working Conv1", "Feeder Position Camera Trigger", "");
                                if (production)
                                {
                                    if (!nozzle1Graphhitetaken || !nozzle2Graphhitetaken)
                                    {
                                        if (splitdataccd3 != null)
                                        {
                                            int l = splitdataccd3.Length;
                                            Array.Clear(splitdataccd3, 0, l);
                                        }
                                        if (Count_CCD4 == 4)
                                        {
                                            await GantrySystem.move(GlobalVariable.Wk1_Z2FedPos, GlobalVariable.WK1_initial.PositionX, GlobalVariable.WK1_initial.PositionY);
                                            GlobalVariable.CCD4_Trigger_Fail = true;
                                            DialogResult res = MessageBox.Show("CCD4 Trigger fail,Please Feed", "Alarm", MessageBoxButtons.OK, MessageBoxIcon.Question,
                                                                MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);
                                            if (res == DialogResult.OK)
                                            {
                                                GlobalVariable.CCD4_Trigger_Fail = false;
                                                Count_CCD4 = 0;
                                                break;
                                            }
                                            else
                                                break;
                                        }
                                        string dtm = DateTime.Now.ToString("HHmmss");
                                        String cmd1 = "T3,2,T3_" + dtm + "_NA_NA,1," + GlobalVariable.TrainNozzle1.PositionX + "," + GlobalVariable.TrainNozzle1.PositionY + "," + GlobalVariable.TrainNozzle1.PositionR1 + ",2," + GlobalVariable.TrainNozzle2.PositionX + "," + GlobalVariable.TrainNozzle2.PositionY + "," + GlobalVariable.TrainNozzle2.PositionR2;
                                        string ScnrResult = await camera.Trig_Camera(ObjectList.CCD1, cmd1);
                                        int scnrRetryCount = 0;
                                        while (ScnrResult == null && scnrRetryCount < MAX_SAFE_RETRIES)
                                        {
                                            scnrRetryCount++;
                                            ScnrResult = await camera.Trig_Camera(ObjectList.CCD1, cmd1);
                                        }
                                        Count_CCD4++;
                                        fedTime_stmp = dtm;
                                        if (ScnrResult == null || ScnrResult == "null" || ScnrResult == "")
                                            ScnrResult = await camera.Trig_Camera(ObjectList.CCD1, cmd1);
                                        splitdataccd3 = ScnrResult.Split(',');
                                        if (!splitdataccd3[2].Contains("999") && !(splitdataccd3[3].Contains("999") && !(splitdataccd3[4].Contains("999"))))
                                        {
                                            N1left = true;
                                            N2left = true;
                                        }
                                        if (!splitdataccd3[9].Contains("999") && !(splitdataccd3[10].Contains("999") && !(splitdataccd3[11].Contains("999"))))
                                        {
                                            N1left = true;
                                            N2left = true;
                                        }
                                        if (!splitdataccd3[5].Contains("999") && !(splitdataccd3[6].Contains("999") && !(splitdataccd3[7].Contains("999"))))
                                        {
                                            N1right = true;
                                            N2right = true;
                                        }
                                        if (!splitdataccd3[12].Contains("999") && !(splitdataccd3[13].Contains("999") && !(splitdataccd3[14].Contains("999"))))
                                        {
                                            N1right = true;
                                            N2right = true;
                                        }
                                    }
                                    else
                                        return;
                                }
                                else
                                {
                                    String cmd1 = "T3,1,SN,1,276.493,-312.";
                                    string ScnrResult = await camera.Trig_Camera(ObjectList.CCD1, cmd1);
                                }
                                i_feed = 40;
                                break;

                            case 40:
                                await Logger.WriteLogasTask(Logger.LogType.Running, " GoFeederPlace", "Working Conv1", "Nozzle1 Picking", "");
                                if (production)
                                {
                                    if (!nozzle1Graphhitetaken)
                                    {
                                        if (N1left)
                                        {
                                            Count_CCD4 = 0;
                                            if (double.Parse(splitdataccd3[2]) > -20 && double.Parse(splitdataccd3[3]) < 300)
                                            {
                                                if (Safe(GlobalVariable.Wk1_Z1FedPos.PositionX, double.Parse(splitdataccd3[2]), currentState, step) &&
                                                    Safe(GlobalVariable.Wk1_Z1FedPos.PositionY, double.Parse(splitdataccd3[3]), currentState, step))
                                                {
                                                    if (GlobalVariable.K_Enable)
                                                    {
                                                        Task T1 = Task.Run(() => GantrySystem.move(GlobalVariable.Wk1_Z1FedPos, double.Parse(splitdataccd3[2]) + GlobalVariable.offsetK[12].Xvalue, double.Parse(splitdataccd3[3]) + GlobalVariable.offsetK[12].Yvalue));
                                                        Task T2 = Task.Run(() => GantrySystem.MoveR1(GlobalVariable.Nozzle_loc_Z1, (double.Parse(splitdataccd3[4]) + GlobalVariable.offsetK[12].Rvalue)));
                                                        await Task.WhenAll(T1, T2);
                                                    }
                                                    else
                                                    if (GlobalVariable.NK_Enable)
                                                    {
                                                        Task T1 = Task.Run(() => GantrySystem.move(GlobalVariable.Wk1_Z1FedPos, double.Parse(splitdataccd3[2]) + GlobalVariable.offsetNK[12].Xvalue, double.Parse(splitdataccd3[3]) + GlobalVariable.offsetNK[12].Yvalue));
                                                        Task T2 = Task.Run(() => GantrySystem.MoveR1(GlobalVariable.Nozzle_loc_Z1, (double.Parse(splitdataccd3[4]) + GlobalVariable.offsetNK[12].Rvalue)));
                                                        await Task.WhenAll(T1, T2);
                                                    }
                                                    else
                                                    {
                                                        Task T1 = Task.Run(() => GantrySystem.move(GlobalVariable.Wk1_Z1FedPos, double.Parse(splitdataccd3[2]) + GlobalVariable.offset[12].Xvalue, double.Parse(splitdataccd3[3]) + GlobalVariable.offset[12].Yvalue));
                                                        Task T2 = Task.Run(() => GantrySystem.MoveR1(GlobalVariable.Nozzle_loc_Z1, (double.Parse(splitdataccd3[4]) + GlobalVariable.offset[12].Rvalue)));
                                                        await Task.WhenAll(T1, T2);
                                                    }
                                                    N2left = false;
                                                }
                                                else { i_feed = 30; break; }
                                            }
                                        }
                                        else if (N1right)
                                        {
                                            if (double.Parse(splitdataccd3[5]) > -20 && double.Parse(splitdataccd3[6]) < 300)
                                            {
                                                if (Safe(GlobalVariable.Wk1_Z1FedPos2.PositionX, double.Parse(splitdataccd3[5]), currentState, step) &&
                                                    Safe(GlobalVariable.Wk1_Z1FedPos2.PositionY, double.Parse(splitdataccd3[6]), currentState, step))
                                                {
                                                    Count_CCD4 = 0;
                                                    if (GlobalVariable.K_Enable)
                                                    {
                                                        Task T3 = Task.Run(() => GantrySystem.move(GlobalVariable.Wk1_Z1FedPos, double.Parse(splitdataccd3[5]) + GlobalVariable.offsetK[13].Xvalue, double.Parse(splitdataccd3[6]) + GlobalVariable.offsetK[13].Yvalue));
                                                        Task T4 = Task.Run(() => GantrySystem.MoveR1(GlobalVariable.Nozzle_loc_Z1, (double.Parse(splitdataccd3[7]) + GlobalVariable.offsetK[13].Rvalue)));
                                                        await Task.WhenAll(T3, T4);
                                                    }
                                                    else
                                                    if (GlobalVariable.NK_Enable)
                                                    {
                                                        Task T3 = Task.Run(() => GantrySystem.move(GlobalVariable.Wk1_Z1FedPos, double.Parse(splitdataccd3[5]) + GlobalVariable.offsetNK[13].Xvalue, double.Parse(splitdataccd3[6]) + GlobalVariable.offsetNK[13].Yvalue));
                                                        Task T4 = Task.Run(() => GantrySystem.MoveR1(GlobalVariable.Nozzle_loc_Z1, (double.Parse(splitdataccd3[7]) + GlobalVariable.offsetNK[13].Rvalue)));
                                                        await Task.WhenAll(T3, T4);
                                                    }
                                                    else
                                                    {
                                                        Task T3 = Task.Run(() => GantrySystem.move(GlobalVariable.Wk1_Z1FedPos, double.Parse(splitdataccd3[5]) + GlobalVariable.offset[13].Xvalue, double.Parse(splitdataccd3[6]) + GlobalVariable.offset[13].Yvalue));
                                                        Task T4 = Task.Run(() => GantrySystem.MoveR1(GlobalVariable.Nozzle_loc_Z1, (double.Parse(splitdataccd3[7]) + GlobalVariable.offset[13].Rvalue)));
                                                        await Task.WhenAll(T3, T4);
                                                    }
                                                    N2right = false;
                                                    secondposN1Ok = true;
                                                }
                                                else { i_feed = 30; break; }
                                            }
                                        }
                                        else
                                        {
                                            await GantrySystem.move(GlobalVariable.Wk1_Z2FedPos, GlobalVariable.Wk1_Z2CCD2pos.PositionX, GlobalVariable.Wk1_Z2CCD2pos.PositionY);
                                            _ = Task.Run(async () => await Feeding.Feed());
                                            i_feed = 30;
                                            break;
                                        }
                                    }
                                    else { i_feed = 45; break; }
                                }
                                else
                                    await GantrySystem.GoWK1Z1FeedPos();
                                i_feed = 45;
                                break;

                            case 45:
                                if (dryrun)
                                    await Task.Run(() => NozzleSystem.Nozzle1MoveDown(GlobalVariable.Wk1_Z1FedPos));
                                else if (!nozzle1Graphhitetaken)
                                {
                                    if (GantrySystem.getcurrentpos(ObjectList.Servo_Y1) < GlobalVariable.Servo_Y1_Min_N1 + 10 && GantrySystem.getcurrentpos(ObjectList.Servo_X1) > GlobalVariable.Servo_X1_Min_N1 - 10 && GantrySystem.getcurrentpos(ObjectList.Servo_X1) < GlobalVariable.Servo_X1_Max_N1 + 10)
                                    {
                                        GlobalVariable.DIDO.WriteOPS(true, (int)EOutput.Pick_Place_Z1_Axis_Vaccuum_ON);
                                        await Task.Run(() => NozzleSystem.Nozzle1MoveDown(GlobalVariable.Wk1_Z1FedPos));
                                        GlobalVariable.Z1_Pickedup = true;
                                        Z1_Trigger_While = false;
                                    }
                                    await Task.Delay(50);
                                }
                                i_feed = 47;
                                break;

                            case 47:
                                if (dryrun)
                                    await Task.Run(() => NozzleSystem.Nozzle1Moveup(GlobalVariable.Wk1_Z1FedPos));
                                else if (!nozzle1Graphhitetaken)
                                {
                                    await Task.Run(() => NozzleSystem.Nozzle1Moveup(GlobalVariable.Wk1_Z1FedPos));
                                    _ = Task.Run(() => GantrySystem.MoveR1(GlobalVariable.TrainNozzle1));

                                    nozzle1Graphhitetaken = true;
                                }
                                i_feed = 50;
                                break;

                            case 50:
                                await Logger.WriteLogasTask(Logger.LogType.Running, " GoFeederPlace", "Working Conv1", "Nozzle2 Picking", "");
                                if (production)
                                {
                                    if (secondposN1Ok)
                                    {
                                        secondposN1Ok = false;
                                        i_feed = 70;
                                        break;
                                    }
                                    if (!nozzle2Graphhitetaken)
                                    {
                                        if (N2right)
                                        {
                                            if (double.Parse(splitdataccd3[12]) > -20 && double.Parse(splitdataccd3[13]) < 300)
                                            {
                                                if (Safe(GlobalVariable.Wk1_Z2FedPos.PositionX, double.Parse(splitdataccd3[12]), currentState, step) &&
                                                    Safe(GlobalVariable.Wk1_Z2FedPos.PositionY, double.Parse(splitdataccd3[13]), currentState, step))
                                                {
                                                    if (GlobalVariable.K_Enable)
                                                    {
                                                        Task T5 = Task.Run(() => GantrySystem.move(GlobalVariable.Wk1_Z2FedPos, double.Parse(splitdataccd3[12]) + GlobalVariable.offsetK[15].Xvalue, double.Parse(splitdataccd3[13]) + GlobalVariable.offsetK[15].Yvalue));
                                                        Task T6 = Task.Run(() => GantrySystem.MoveR2(GlobalVariable.Nozzle_loc_Z2, (double.Parse(splitdataccd3[14]) + GlobalVariable.offsetK[15].Rvalue)));
                                                        await Task.WhenAll(T5, T6);
                                                    }
                                                    else
                                                    if (GlobalVariable.NK_Enable)
                                                    {
                                                        Task T5 = Task.Run(() => GantrySystem.move(GlobalVariable.Wk1_Z2FedPos, double.Parse(splitdataccd3[12]) + GlobalVariable.offsetNK[15].Xvalue, double.Parse(splitdataccd3[13]) + GlobalVariable.offsetNK[15].Yvalue));
                                                        Task T6 = Task.Run(() => GantrySystem.MoveR2(GlobalVariable.Nozzle_loc_Z2, (double.Parse(splitdataccd3[14]) + GlobalVariable.offsetNK[15].Rvalue)));
                                                        await Task.WhenAll(T5, T6);
                                                    }
                                                    else
                                                    {
                                                        Task T5 = Task.Run(() => GantrySystem.move(GlobalVariable.Wk1_Z2FedPos, double.Parse(splitdataccd3[12]) + GlobalVariable.offset[15].Xvalue, double.Parse(splitdataccd3[13]) + GlobalVariable.offset[15].Yvalue));
                                                        Task T6 = Task.Run(() => GantrySystem.MoveR2(GlobalVariable.Nozzle_loc_Z2, (double.Parse(splitdataccd3[14]) + GlobalVariable.offset[15].Rvalue)));
                                                        await Task.WhenAll(T5, T6);
                                                    }
                                                    N1right = false;
                                                }
                                                else { i_feed = 30; break; }
                                            }
                                        }
                                        else if (N2left)
                                        {
                                            try
                                            {
                                                if (Safe(GlobalVariable.Wk1_Z2FedPos1.PositionX, double.Parse(splitdataccd3[9]), currentState, step) &&
                                                    Safe(GlobalVariable.Wk1_Z2FedPos1.PositionY, double.Parse(splitdataccd3[10]), currentState, step))
                                                {
                                                    if (GlobalVariable.K_Enable)
                                                    {
                                                        Task T7 = Task.Run(() => GantrySystem.move(GlobalVariable.Wk1_Z2FedPos1, double.Parse(splitdataccd3[9]) + GlobalVariable.offsetK[14].Xvalue, double.Parse(splitdataccd3[10]) + GlobalVariable.offsetK[14].Yvalue));
                                                        Task T8 = Task.Run(() => GantrySystem.MoveR2(GlobalVariable.Nozzle_loc_Z2, (double.Parse(splitdataccd3[11]) + GlobalVariable.offsetK[14].Rvalue)));
                                                        await Task.WhenAll(T7, T8);
                                                    }
                                                    else
                                                    if (GlobalVariable.NK_Enable)
                                                    {
                                                        Task T7 = Task.Run(() => GantrySystem.move(GlobalVariable.Wk1_Z2FedPos1, double.Parse(splitdataccd3[9]) + GlobalVariable.offsetNK[14].Xvalue, double.Parse(splitdataccd3[10]) + GlobalVariable.offsetNK[14].Yvalue));
                                                        Task T8 = Task.Run(() => GantrySystem.MoveR2(GlobalVariable.Nozzle_loc_Z2, (double.Parse(splitdataccd3[11]) + GlobalVariable.offsetNK[14].Rvalue)));
                                                        await Task.WhenAll(T7, T8);
                                                    }
                                                    else
                                                    {
                                                        Task T7 = Task.Run(() => GantrySystem.move(GlobalVariable.Wk1_Z2FedPos1, double.Parse(splitdataccd3[9]) + GlobalVariable.offset[14].Xvalue, double.Parse(splitdataccd3[10]) + GlobalVariable.offset[14].Yvalue));
                                                        Task T8 = Task.Run(() => GantrySystem.MoveR2(GlobalVariable.Nozzle_loc_Z2, (double.Parse(splitdataccd3[11]) + GlobalVariable.offset[14].Rvalue)));
                                                        await Task.WhenAll(T7, T8);
                                                    }
                                                    N1left = false;
                                                    secondposN2Ok = true;
                                                }
                                                else { i_feed = 30; break; }
                                            }
                                            catch (Exception ex)
                                            {
                                                await Logger.WriteLogasTask(Logger.LogType.Error, "GoFeederPlace", "Working Conv1", $"N2left exception: {ex}", "");
                                            }
                                        }
                                        else
                                        {
                                            await GantrySystem.move(GlobalVariable.Wk1_Z2FedPos, GlobalVariable.Wk1_Z2CCD2pos.PositionX, GlobalVariable.Wk1_Z2CCD2pos.PositionY);
                                            _ = Task.Run(async () => await Feeding.Feed());
                                            i_feed = 30;
                                            break;
                                        }
                                    }
                                    else { i_feed = 70; break; }
                                }
                                else
                                    await GantrySystem.GoWK1Z2FeedPos();
                                i_feed = 60;
                                break;

                            case 60:
                                if (dryrun)
                                    await Task.Run(() => NozzleSystem.Nozzle2MoveDown(GlobalVariable.Wk1_Z2FedPos));
                                else if (!nozzle2Graphhitetaken)
                                {
                                    if (GantrySystem.getcurrentpos(ObjectList.Servo_Y1) < GlobalVariable.Servo_Y1_Min_N2 + 10 && GantrySystem.getcurrentpos(ObjectList.Servo_X1) > GlobalVariable.Servo_X1_Min_N2 - 10 && GantrySystem.getcurrentpos(ObjectList.Servo_X1) < GlobalVariable.Servo_X1_Max_N2 + 10)
                                    {
                                        GlobalVariable.DIDO.WriteOPS(true, (int)EOutput.Pick_Place_Z2_Axis_Vaccuum_ON);
                                        await Task.Run(() => NozzleSystem.Nozzle2MoveDown(GlobalVariable.Wk1_Z2FedPos));
                                        nozzle2Graphhitetaken = true;
                                    }
                                }
                                i_feed = 70;
                                break;

                            case 70:
                                if (await Task.Run(() => NozzleSystem.Nozzle2Moveup(GlobalVariable.SafePosition)))
                                {
                                    if (production)
                                    {
                                        if (nozzle2Graphhitetaken && nozzle1Graphhitetaken)
                                            _ = Task.Run(async () => await Feeding.Feed());
                                        _ = Task.Run(() => GantrySystem.MoveR1(GlobalVariable.TrainNozzle1));

                                    }
                                    Z2_Trigger_While = false;
                                    GlobalVariable.Z2_Pickedup = true;
                                    i_feed = 80;
                                }
                                break;
                        }
                    }
                    #endregion
                }
            }
        }
        #endregion


        #region Safe Move X, Y
        // ─────────────────────────────────────────────────────────────────
        // SAFE CHECK — now saves state and awaits alarm before returning
        // Signature updated to accept currentState and step for saving
        // ─────────────────────────────────────────────────────────────────
        public static bool Safe(double actual, double current, int stateAtAlarm, int stepAtAlarm)
        {
            if (actual - 10 < current && actual + 10 > current)
            {
                return true;
            }
            else
            {
                _safeRetryCount++;

                string reason = $"Servo out of tolerance at state={stateAtAlarm}, step={stepAtAlarm}. " +
                                $"Expected: {actual:F3}, Got: {current:F3}, " +
                                $"Diff: {Math.Abs(actual - current):F3}mm " +
                                $"(retry {_safeRetryCount}/{MAX_SAFE_RETRIES})";

                // Save exactly where we are so resume can restore it
                savedStep = stepAtAlarm;
                savedState = stateAtAlarm;
                resumeReason = reason;
                resumeRequired = true;

                // Fire alarm (awaited via Task.Run so it doesn't block the bool return)
                Task.Run(async () =>
                {
                    await GlobalVariable.AlarmTriggerAsync(
                        ECode.InvalidServoCoordinate, true, 1, reason, "Current Version: " + GlobalVariable.Version + "");
                });

                return false;
            }
        }
        #endregion

        #region Safe R
        public static bool SafeR(double actual, double current)
        {
            if (actual > current)
                return true;
            else
            {
                Task.Run(() => GlobalVariable.AlarmTriggerAsync(ECode.InvalidServoCoordinate, true, 1, "", "Current Version: " + GlobalVariable.Version + ""));
                return false;
            }
        }
        #endregion

        #region Not used
        private static string Escape(string s)
        {
            if (string.IsNullOrEmpty(s)) return "";
            if (s.Contains(",") || s.Contains("\""))
                return "\"" + s.Replace("\"", "\"\"") + "\"";
            return s;
        }

        private static string DoubleStr(double d)
        {
            return double.IsNaN(d) ? "" : d.ToString(CultureInfo.InvariantCulture);
        }
        #endregion

    }
}
