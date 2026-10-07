using Advantech;
using DynamicCylinders;
using ExceptionLib;
using GRT_BG1.Data;
using GRT_BG1.Function.Calibration;
using GRT_BG1_V54.Function.CommonClass;
using Master;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static DIO.DIDO;

namespace GRT_BG1.Function.DryRun
{

    public class HomingCls
    {
        public static int homingStep = 10;
        bool palletPresent = false;
        string StationName = "Servo Homing Station";
        public static bool homingdone = false;
        public static Stopwatch Homing_Time = new Stopwatch();
        //Arulkumar Fixed Hung start
        private static int _lastHomingWaitStep = -1;
        private static readonly Stopwatch _homingStepWaitSw = new Stopwatch();
        private const int HOMING_SENSOR_STEP_TIMEOUT_MS = 60000;
        private const int HOMING_AXIS_STEP_TIMEOUT_MS = 120000;
        //Arulkumar Fixed Hung end



        public int start = 90;

        public async Task StartHomingSequence(CancellationToken token)
        {
            try
            {
                await Task.Run(() => ServoHomingModeSeq(token));
                GC.Collect();
            }
            catch (Exception ex2)
            {
                Exception ex = ex2;
                Logger.WriteLog(Logger.LogType.Error, "HomingSequence", "TimerMethod", "Exception Error", ex.ToString(), default(DateTime), "StartHomingSequence", 40);
            }
        }



        public async Task ServoHomingModeSeq(CancellationToken token)
        {

            try
            {
                homingdone = false;
                //Arulkumar Fixed Hung start
                _lastHomingWaitStep = -1;
                _homingStepWaitSw.Reset();
                //Arulkumar Fixed Hung end
                while (!homingdone && !token.IsCancellationRequested)
                {
                    token.ThrowIfCancellationRequested();
                    //Arulkumar Fixed Hung start
                    //if (GlobalVariable.b_gStop  || GlobalVariable.g_bAlarm)
                    //{
                    //    ConveyorSystem._pauseEvent?.Set();
                    //    ConveyorSystem._pauseEvent?.Dispose();
                    //    homingdone = false;
                    //    break;
                    //}

                    //if (homingStep == 20 || homingStep == 30 || homingStep == 80)
                    //{
                    //    if (_lastHomingWaitStep != homingStep)
                    //    {
                    //        _lastHomingWaitStep = homingStep;
                    //        _homingStepWaitSw.Restart();
                    //    }

                    //    int timeoutMs = homingStep == 80 ? HOMING_AXIS_STEP_TIMEOUT_MS : HOMING_SENSOR_STEP_TIMEOUT_MS;
                    //    if (_homingStepWaitSw.ElapsedMilliseconds > timeoutMs)
                    //    {
                    //        await GlobalVariable.AlarmTriggerAsync(ECode.Homing_TimeOut_Error, true, 1, "Homing step " + homingStep, "Current Version: "+ GlobalVariable.g_MachineVersion+"");
                    //        await Logger.WriteLogasTask(Logger.LogType.Error, "Homing", StationName, "Homing step timeout at step " + homingStep, "");
                    //        homingdone = true;
                    //        break;
                    //    }
                    //}
                    //else
                    //{
                    //    _lastHomingWaitStep = -1;
                    //    _homingStepWaitSw.Reset();
                    //}
                    //Arulkumar Fixed Hung end
                    // ConveyorSystem._pauseEvent_Homming.WaitOne();
                    switch (homingStep)
                    {
                        case 10:
                            Homing_Time.Start();
                            await Task.Run(() => Logger.WriteLogasTask(Logger.LogType.Running, "Homing", StationName, "Operator selected Servo Homing mode", ""));
                            NozzleSystem.ResetNozzle();
                            homingStep = 20;
                            break;

                        case 20:
                            await Task.Run(() => Logger.WriteLogasTask(Logger.LogType.Running, "Homing", StationName, "Moving Z1, Z2 to negative limit sensor", ""));


                            Task T1 = Task.Run(() => NozzleSystem.Nozzle1Gonegative(6));
                            Task T2 = Task.Run(() => NozzleSystem.Nozzle12Gonegative(7));
                            await Task.WhenAll(T1, T2);
                            if (NozzleSystem.CheckNegative("Nozzle1"))
                            {
                                if (NozzleSystem.CheckNegative("Nozzle2"))
                                {
                                    homingStep = 30;
                                }
                            }


                            break;
                        case 30:

                            if (NozzleSystem.CheckNegative("Nozzle1"))
                            {
                                if (NozzleSystem.CheckNegative("Nozzle2"))
                                {
                                    await Task.Run(() => Logger.WriteLogasTask(Logger.LogType.Running, "Homing", StationName, "Lowering all stopper and lift cylinders", ""));
                                    Cylinder_config.Cylinders_List[(int)Cylinder_config.Cylinders.Scan_Conv_Stopper_Cyl].Cylinder_Retract();
                                    Cylinder_config.Cylinders_List[(int)Cylinder_config.Cylinders.Work_Conv_1_Stopper_Cyl].Cylinder_Retract();
                                    Cylinder_config.Cylinders_List[(int)Cylinder_config.Cylinders.Work_Conv_1_pallet_Lift_Cyl].Cylinder_Retract();
                                    Cylinder_config.Cylinders_List[(int)Cylinder_config.Cylinders.Work_Conv_2_pallet_Lift_Cyl].Cylinder_Retract();
                                    Cylinder_config.Cylinders_List[(int)Cylinder_config.Cylinders.Work_Conv_2_Stopper_Cyl].Cylinder_Retract();
                                    await Task.Delay(500);
                                    homingStep = 60;
                                }
                            }
                            break;

                        case 60:

                            await Task.Run(() => Logger.WriteLogasTask(Logger.LogType.Running, "Homing", StationName, " starting conveyors", ""));
                            StepperSystem.MovePlate(new bool?[] { true, true, true, true, true, true });

                            DialogResult Res = MessageBox.Show("Please Confirom pallet not inside ....!", "Info", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);
                            if (Res == DialogResult.OK)
                            {

                                StepperSystem.MovePlate(new bool?[] { false, false, false, false, false, false });
                                Cylinder_config.Cylinders_List[(int)Cylinder_config.Cylinders.Scan_Conv_Stopper_Cyl].Cylinder_Extend();
                                Cylinder_config.Cylinders_List[(int)Cylinder_config.Cylinders.Work_Conv_1_Stopper_Cyl].Cylinder_Extend(); ;
                                Cylinder_config.Cylinders_List[(int)Cylinder_config.Cylinders.Work_Conv_2_Stopper_Cyl].Cylinder_Extend();
                                homingStep = 70;
                            }

                            break;

                        case 70:
                            await Task.Run(() => Logger.WriteLogasTask(Logger.LogType.Running, "Homing", StationName, "Gantray Moving Homing position", ""));

                            Task T14 = Task.Run(() => GantrySystem.wk1_homeX());
                            Task T15 = Task.Run(() => GantrySystem.wk1_homeY());
                            Task T16 = Task.Run(() => GantrySystem.wk2_homeX());
                            Task T17 = Task.Run(() => GantrySystem.wk2_homeY());
                            Task T18 = Task.Run(async () => await GantrySystem.scanCnv_home());
                            Task T19 = Task.Run(() => GantrySystem.wk1_homeR2());
                            Task T20 = Task.Run(() => GantrySystem.wk1_homeR1());
                            await Task.WhenAll(T19, T20, T14, T15, T16, T17, T18);

                            homingStep = 80;


                            break;

                        #region OLD
                        //case 80:
                        //    await Task.Run(() => Logger.WriteLogasTask(Logger.LogType.Running, "Homing", StationName, "Gantray Moving Homing position", ""));
                        //    bool x1_home_cmplt = GantrySystem.CheckHome(4);
                        //    bool x2_home_cmplt = GantrySystem.CheckHome(10);
                        //    bool y2_home_cmplt = GantrySystem.CheckHome(11);
                        //    bool y1_home_cmplt = GantrySystem.CheckHome(5);
                        //    bool x1_stepper_home = GantrySystem.CheckHome(12);
                        //    bool y1_stepper_home = GantrySystem.CheckHome(13);
                        //    string motor = y1_stepper_home ? (x1_stepper_home ? (y2_home_cmplt ? (x2_home_cmplt ? (y1_home_cmplt ? (x1_home_cmplt ? "Completed" : "x1_home_not_completed ") : " y1_home_not_completed") : "x2_home_not_completed") : "y2_home_not_completed") : "X1_stepper_not_completed") : "y1_stepper_not_completed";
                        //    if (GantrySystem.CheckHome(4) && GantrySystem.CheckHome(5) && GantrySystem.CheckHome(10) && GantrySystem.CheckHome(11) && StepperSystem.CheckHome(12) && StepperSystem.CheckHome(13))
                        //    {
                        //        await Task.Run(() => Logger.WriteLogasTask(Logger.LogType.Running, "Homing", StationName, "Moving Z1,Z2 axis to home", ""));
                        //        Task T3 = Task.Run(() => NozzleSystem.Nozzle1Homing());
                        //        Task T4 = Task.Run(() => NozzleSystem.Nozzle2Homing());
                        //        //Arulkumar Fixed Hung start
                        //        await Task.WhenAll(T3, T4);
                        //        //Arulkumar Fixed Hung end
                        //        //GlobalVariable.DIDO.WriteOPS(true, (int)EOutput.Pick_Place_Z2_Axis_Vaccuum_Blow);
                        //        //GlobalVariable.DIDO.WriteOPS(true, (int)EOutput.Pick_Place_Z1_Axis_Vaccuum_Blow);
                        //        //await Task.Delay(500);
                        //        //GlobalVariable.DIDO.WriteOPS(false, (int)EOutput.Pick_Place_Z2_Axis_Vaccuum_Blow);
                        //        //GlobalVariable.DIDO.WriteOPS(false, (int)EOutput.Pick_Place_Z1_Axis_Vaccuum_Blow);

                        //        homingStep = 90;
                        //    }
                        //    else
                        //        await Task.Run(() => Logger.WriteLogasTask(Logger.LogType.Running, "Homing", StationName, motor + " Homing is not Completed", ""));
                        //    break;
                        #endregion OLD

                        case 80:
                            await Task.Delay(200);
                            if (ObjectList.Servo_X1.GetSingleMotionIOBit(Program.Advantech_PCIE.MotionIOBit.ORG) &&
                                ObjectList.Servo_Y1.GetSingleMotionIOBit(Program.Advantech_PCIE.MotionIOBit.ORG) &&
                                ObjectList.Servo_R1.GetSingleMotionIOBit(Program.Advantech_PCIE.MotionIOBit.ORG) &&
                                ObjectList.Servo_R2.GetSingleMotionIOBit(Program.Advantech_PCIE.MotionIOBit.ORG) &&
                                ObjectList.Servo_X2.GetSingleMotionIOBit(Program.Advantech_PCIE.MotionIOBit.ORG) &&
                                ObjectList.Servo_Y2.GetSingleMotionIOBit(Program.Advantech_PCIE.MotionIOBit.ORG) &&
                                ObjectList.Stepper_1.GetSingleMotionIOBit(Program.Advantech_PCIE.MotionIOBit.ORG) &&
                                ObjectList.Stepper_2.GetSingleMotionIOBit(Program.Advantech_PCIE.MotionIOBit.ORG)
                                )
                            {
                                await Task.Run(() => Logger.WriteLogasTask(Logger.LogType.Running, "Homing", StationName, "Moving Z1,Z2 axis to home", ""));
                                Task T3 = Task.Run(() => NozzleSystem.Nozzle1Homing());
                                Task T4 = Task.Run(() => NozzleSystem.Nozzle2Homing());

                                await Task.WhenAll(T3, T4);

                                homingStep = 90;
                            }
                            else
                            {
                                ConveyorSystem.Stop();
                                GlobalVariable.b_gHomingDone = false;
                                GlobalVariable.bhomeseq_running = false;
                                GlobalVariable.current_MCStatus = GlobalVariable.MachineStatus.Stop;
                                System.Windows.Forms.MessageBox.Show(" Make sure homing is done properly ", " Unable to start Auto sequence ! ", MessageBoxButtons.OK, MessageBoxIcon.Error);

                            }

                            break;


                        case 90:
                            //Arulkumar Fixed Hung start

                            await Task.Run(() => AllAxiesInitialPos.GoinitialPosition());
                            homingStep = 100;
                            break;

                        case 100:

                            //Arulkumar Fixed Hung start
                            //TimeSpan ts = Homing_Time.Elapsed;
                            //double CT = Math.Round(ts.TotalSeconds, 2);
                            //if (CT > 1500)
                            //{
                            //    await GlobalVariable.AlarmTriggerAsync(ECode.Homing_TimeOut_Error, true, 1, "Overall homing timeout", "Current Version: "+ GlobalVariable.g_MachineVersion+"");
                            //    await Logger.WriteLogasTask(Logger.LogType.Error, "Homing", StationName, "Overall homing exceeded 1500 seconds", CT.ToString());
                            //    Homing_Time.Restart();
                            //}
                            ////Arulkumar Fixed Hung end
                            ///


                            GlobalVariable.current_MCStatus = GlobalVariable.MachineStatus.Ideal;

                            homingdone = true;
                            homingStep = 200; // Reset
                            break;


                        default:
                            homingStep = 10;
                            break;
                    }
                    //Arulkumar Fixed Hung start
                    await Task.Delay(50);
                    //Arulkumar Fixed Hung end

                }
            }
            catch (Exception e)
            {
                #region Exception Running Log
                await Task.Run(() => Logger.WriteLogasTask(Logger.LogType.Running, "Homing", "UnloadingConveyor_HomingSeq", e.Message.ToString(), e.ToString()));
                #endregion
            }
            finally
            {
            }

        }


    }

}
