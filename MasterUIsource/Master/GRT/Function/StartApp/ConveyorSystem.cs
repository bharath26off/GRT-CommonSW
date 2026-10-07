using Advantech.Motion;
using ExceptionLib;
using GRT_BG1.Data;
using GRT_BG1.Function;
using GRT_BG1.Function.Calibration;
using GRT_BG1.Function.DryRun;
using GRT_BG1_V54.Function.Interface;
using Master;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static DIO.DIDO;

namespace GRT_BG1_V54.Function.CommonClass
{
    

    public class ConveyorSystem
    {
        PalletData palletData = new PalletData();
        private readonly BlockingCollection<PalletData> _pool = new BlockingCollection<PalletData>();
       static PalletData[,] data1 = new PalletData[GlobalVariable.CavityRows, GlobalVariable.CavityCols];
        static LoadingConveyor ld=null;
       static Task T2 = null;
        //added
        private static ConveyorSystem instance = null;
        public static ManualResetEvent _pauseEvent = new ManualResetEvent(true); // start unpaused      
        public static CancellationTokenSource _cts;
        public static event Action OnbuttonStatusChanged;
        public static ManualResetEvent _pauseEvent_Homming = new ManualResetEvent(true);

       
      
        public ConveyorSystem(int dataCount)
        {
            // Initialize fixed data objects
            for (int i = 1; i <= dataCount; i++)
            {
                _pool.Add( palletData);
            }
          //   wk1 = new WorkingConveyor1(GlobalVariable.WK1Positions);

        }
       
        //create each MLB data object
        private async Task CreatePart(int row, int col)
        {
            palletData.PalletArr[row, col] = new PartData
            {
                //PositionX = GlobalVariable.pos[row, col].x, //read position x
                // PositionY = GlobalVariable.pos[row, col].y////read position y
            };

        }

        public static async Task StartAutoSequnce1(CancellationToken token)
        {
            ld = new LoadingConveyor(GlobalVariable.scannerCnvPositions);
        }


        public static async Task StartAutoSequnce(CancellationToken token)
        {
            try
            {
                GlobalVariable.bautoseq_running = true;
                //Arulkumar Fixed Hung start
                //Reason: After Homing then Start, GoFeederPlace spun on if (b_gPause) continue
                //Root Cause: Homing/Alarm left b_gPause=true; StartAutoSequnce never cleared it before launching sequences.
                GlobalVariable.b_gPause = false;
                HomingResume();
                //Arulkumar Fixed Hung end
                //ObjectList.Servo_X1.ResetAxisError_All_Axis();
                ObjectList.Stepper_1.ResetAxis();
                ObjectList.Stepper_2.ResetAxis();
                ObjectList.Stepper_1.ResumeAxis();
                ObjectList.Stepper_2.ResumeAxis();
                GantrySystem.Resume();

                // Initialy Reset all Variables
                LoadingConveyor.iLodingConStep = 10;
                LoadingConveyor.initialStep = 10;
                LoadingConveyor.running = false;
                LoadingConveyor.ScanCon_Seq_completed = true;
                WorkingConveyor1.nozzle1Graphhitetaken = false;
                WorkingConveyor1.nozzle2Graphhitetaken=false;
                WorkingConveyor1.firsttiimewait = false;
                WorkingConveyor1.blockcreated = false;
                if (WorkingConveyor1.semaphoreSlim.CurrentCount == 0)
                {
                    WorkingConveyor1.semaphoreSlim.Release();
                }
                if (WorkingConveyor1.semaphoreSlim1.CurrentCount==0)
                {
                    WorkingConveyor1.semaphoreSlim1.Release();

                }
                if (WorkingConveyor1.semaphoreSlim2.CurrentCount==0)
                {
                    WorkingConveyor1.semaphoreSlim2.Release();
                }

                if (WorkingConveyor2.semaphoreSlimwk2.CurrentCount == 0) // AK
                {
                    WorkingConveyor2.semaphoreSlimwk2.Release();
                }

                WorkingConveyor1.WorkingCon_Seq_completed = true;
                WorkingConveyor1.i_rejection = 10;
                WorkingConveyor1.currentState = 10;
                WorkingConveyor1.running = false;
                WorkingConveyor1.step = 10;
                WorkingConveyor1.firsttimePick = false;

                WorkingConveyor2.WorkingCon2_Seq_completed = true;
                WorkingConveyor2.i_step = 34;
                WorkingConveyor2.running = false;
                LoadingConveyor.scanRunning = false;
                WorkingConveyor1.pastingRunning = false;
                WorkingConveyor1.camerascanRuning = false;
                WorkingConveyor1.ResetCavityWork();
                //iWorkingConStep = 10;
                //iUnloadingConStep = 10;
                //iRejConStep = 10;
                GlobalVariable.LoadingConvWrk = false;
                GlobalVariable.UnLoadingConvWrk = false;
                GlobalVariable.WorkingConvWrk = false;

                ld = new LoadingConveyor(GlobalVariable.scannerCnvPositions);

                await Task.Delay(1000);
                //  GlobalVariable.RejectionConvWrk = false;
               // await ld.palletOut(token); // AK
                _ = Task.Run(() => WorkingConveyor1.GoRejectionPlace(token));

               // await Task.Delay(1000);
                //Start Loading Conveyor Task Sequence
                T2  = Task.Run(() => ld.LoadingConveyor_Seq(token));
              
                ////Start Working Conveyor Task Sequence
                //Task.Run(() => WorkingCon_Seq(token));
                ////Start Unloading Conveyor Task Sequence
                //Task.Run(() => UnLoadingCon_Seq(token));
            }
            catch (Exception ex)
            {
                Logger.WriteLog(Logger.LogType.Error, "ConveyorSequence", "StartAutoSequnce", ex.Message, ex.ToString());
            }
        }

      

        //added
        public static void Start()
        {
            HardButtons(true, false, false);
            RaiseButtonStatusChanged();
        }

        public  static void Stop()
        {
            //HardButtons(false, false, true);
            //GlobalVariable.b_gHomingDone = false;
            //GlobalVariable.bautoseq_running = false;
            //GlobalVariable.bmachine_ReadytoStart = false;
            //GlobalVariable.bhomeseq_running = false;
            GlobalVariable.current_MCStatus = GlobalVariable.MachineStatus.Stop;
            Logger.WriteLogasTask(Logger.LogType.AlarmError, "GlobalAutoSequenceExecutor", "Stop", "Auto Sequence Stopped", "");
            if (ConveyorSystem._cts != null)
            {
                try
                {

                    _cts?.Cancel();
                    _cts?.Dispose();
                    _cts = null;
                }
                catch (Exception ex)
                {
                    //Arulkumar Fixed random stoppage start
                    Logger.WriteLog(Logger.LogType.Error, "ConveyorSystem", "Stop.CancelCts", ex.Message, ex.ToString());
                    //Arulkumar Fixed random stoppage end
                }
            }

            //GlobalVariable.LoadingConvWrk = false;
            //GlobalVariable.UnLoadingConvWrk = false;
            //GlobalVariable.WorkingConvWrk = false;


            ObjectList.Servo_X1?.PauseAxis();
            ObjectList.Servo_Y1?.PauseAxis();
            ObjectList.Servo_Z1?.PauseAxis();
            ObjectList.Servo_Z2?.PauseAxis();
            ObjectList.Servo_X2?.PauseAxis();
            ObjectList.Servo_Y2?.PauseAxis();
            ObjectList.Stepper_1?.PauseAxis();
            ObjectList.Stepper_2?.PauseAxis();

            ObjectList.Servo_X1?.Stop();
            ObjectList.Servo_Y1?.Stop();
            ObjectList.Servo_Z1?.Stop();
            ObjectList.Servo_X2?.Stop();
            ObjectList.Servo_Y2?.Stop();
            ObjectList.Servo_Z2?.Stop();
            ObjectList.Stepper_1?.Stop();
            ObjectList.Stepper_2?.Stop();
            

            StepperSystem.MovePlate(new bool?[] { false, false, false, false, false, false });

            RaiseButtonStatusChanged();
            T2 = null;
            //Arulkumar Fixed random stoppage start
            try
            {
                _pauseEvent?.Set();
                _pauseEvent?.Dispose();
            }
            catch (Exception ex)
            {
                //Arulkumar Fixed random stoppage start
                Logger.WriteLog(Logger.LogType.Error, "ConveyorSystem", "Stop.DisposePauseEvent", ex.Message, ex.ToString());
                //Arulkumar Fixed random stoppage end
            }
            //Arulkumar Fixed random stoppage end
            _pauseEvent = new ManualResetEvent(true); // Or reset it for reuse
        }


        public static void Pause()
        {
            //HardButtons(false, true, false);
            GlobalVariable.current_MCStatus = GlobalVariable.MachineStatus.Pause;
            RaiseButtonStatusChanged();
            StepperSystem.MovePlate(new bool?[] { false, false, false, false, false, false });
            //Arulkumar Fixed random stoppage start
            try
            {
                _pauseEvent?.Reset(); // Pause all threads
            }
            catch (ObjectDisposedException)
            {
                _pauseEvent = new ManualResetEvent(false);
            }
            //Arulkumar Fixed random stoppage end
            GantrySystem.Pause();
            Logger.WriteLogasTask(Logger.LogType.Running, "GlobalAutoSequenceExecutor", "Pause", "Auto Sequence Paused", "");
            ObjectList.Servo_X1?.PauseAxis();
            ObjectList.Servo_Y1?.PauseAxis();
            ObjectList.Servo_Z1?.PauseAxis();
            ObjectList.Servo_Z2?.PauseAxis();
            ObjectList.Servo_X2?.PauseAxis();
            ObjectList.Servo_Y2?.PauseAxis();
            ObjectList.Servo_R1?.PauseAxis();
            ObjectList.Servo_R2?.PauseAxis();
            ObjectList.Stepper_1?.PauseAxis();
            ObjectList.Stepper_2?.PauseAxis();
        }

        public static void Resume()
        {
            HardButtons(true, false, false);
            GlobalVariable.current_MCStatus = GlobalVariable.MachineStatus.Running;
            RaiseButtonStatusChanged();
            //Arulkumar Fixed random stoppage start
            try
            {
                _pauseEvent?.Set();
            }
            catch (ObjectDisposedException)
            {
                _pauseEvent = new ManualResetEvent(true);
            }
            //Arulkumar Fixed random stoppage end
            GantrySystem.Resume();
            //Arulkumar Fixed Hung start
            //Reason: After Homing/Alarm, GoFeederPlace looped forever on b_gPause continue
            //Root Cause: AlarmTriggerAsync sets b_gPause=true; AlarmPopup/ResetAllAlarms intentionally leave it true while MCStatus==Pause.
            //Resume() released _pauseEvent but never cleared b_gPause, so GoFeederPlace/WorkingCon loops hit continue forever.
            GlobalVariable.b_gPause = false;
            //Arulkumar Fixed Hung end
             // Resume all threads
            ObjectList.Servo_X1?.ResumeAxis();
            ObjectList.Servo_Y1?.ResumeAxis();
            ObjectList.Servo_Z1?.ResumeAxis();
            ObjectList.Servo_Z2?.ResumeAxis();
            ObjectList.Servo_X2?.ResumeAxis();
            ObjectList.Servo_Y2?.ResumeAxis();
            ObjectList.Servo_R1?.ResumeAxis();
            ObjectList.Servo_R2?.ResumeAxis();
            ObjectList.Stepper_1?.ResumeAxis();
            ObjectList.Stepper_2?.ResumeAxis();
           
            Logger.WriteLogasTask(Logger.LogType.Running, "GlobalAutoSequenceExecutor", "Resume", "Auto Sequence Resumed", "");
        }
        public static void HomingPause()
        {
            //Arulkumar Fixed random stoppage start
            try
            {
                _pauseEvent_Homming?.Reset(); // Pause all threads
            }
            catch (ObjectDisposedException)
            {
                _pauseEvent_Homming = new ManualResetEvent(false);
            }
            //Arulkumar Fixed random stoppage end
        }

        public static void HomingResume()
        {
            //Arulkumar Fixed random stoppage start
            try
            {
                _pauseEvent_Homming?.Set(); // Resume all threads
            }
            catch (ObjectDisposedException)
            {
                _pauseEvent_Homming = new ManualResetEvent(true);
            }
            //Arulkumar Fixed random stoppage end
        }

        public static void RaiseButtonStatusChanged()
        {
            OnbuttonStatusChanged?.Invoke();
        }

        public static void HardButtons(bool start, bool stop, bool reset)
        {
            GlobalVariable.DIDO.WriteOPS(start, (int)EOutput.Str_PB);

            GlobalVariable.DIDO.WriteOPS(stop, (int)EOutput.Stop_PB);

            GlobalVariable.DIDO.WriteOPS(reset, (int)EOutput.Reset_PB);
        }
    }
   
}

