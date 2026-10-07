using ExceptionLib;
using System;
using System.Threading.Tasks;

namespace Master.AutoSequences
{

    public class HomingSequence
    {
        public static System.Threading.Timer tmr_Homing;
        private static readonly object obj_UnlodinghomeLock = new object();
        public static int iUnloadingHomeStep = 10;
        private static readonly object obj_RejectionhomeLock = new object();
        public static int iRejectionHomeStep = 10;
        private static readonly object obj_WorkinghomeLock = new object();
        public static int iWorkingHomeStep = 10;
        public static int iLoadingHomeStep = 10;
        public static int iDeCapHomeStep = 10;

        private static readonly int iConveyorRotateTimeSec = 5000;

        public static string StationName = "";
        public static string ModuleName = "HomingSequence";

        private static bool bUnloadingHomingDone = false;
        private static bool bWorkingHomingDone = false;
        private static bool bRejectionHomingDone = false;
        private static bool bLoadingHomingDone = false;
        private static bool DecapModuleHomingDone = false;

        public static void start_Thread_I_hme()
        {
            //iHomeStep = 10;
            //tmr_Homing = new System.Threading.Timer(new TimerCallback(TimerMethod), null, 10, 20);
        }

        public static void stop_Thread_I_hme()
        {
            GlobalVariable.b_gHomingDone = false;
            //Arulkumar Fixed Null start
            if (tmr_Homing != null)
            {
                tmr_Homing.Dispose();
                tmr_Homing = null;
            }
            //Arulkumar Fixed Null end
        }

        //private static void TimerMethod(object state)
        //{
        //    UnloadingConveyor_HomingSeq();
        //    RejectionConveyor_HomingSeq();
        //    WorkingConveyor_HomingSeq();
        //    LoadingConveyor_HomingSeq();
        //    //Home_Seq();
        //}

        

        public static async Task StartHomingSequence()
        {
            try
            {
                iUnloadingHomeStep = 10;
                iRejectionHomeStep = 10;
                iWorkingHomeStep = 10;
                iLoadingHomeStep = 10;
                iDeCapHomeStep = 10;

                bUnloadingHomingDone = false;
                bWorkingHomingDone = false;
                bRejectionHomingDone = false;
                bLoadingHomingDone = false;
                DecapModuleHomingDone = false;

                await UnloadingConveyor_HomingSeq();
                await WorkingConveyor_HomingSeq();
                await LoadingConveyor_HomingSeq();
                await DecapModule_HomingSeq();                
            }
            catch (Exception ex)
            {
                Logger.WriteLog(Logger.LogType.Error, "HomingSequence", "TimerMethod", "Exception Error", ex.ToString());
                //throw;
            }
        }
        public static async Task UnloadingConveyor_HomingSeq()
        {
            try
            {
                //await _semaphoreUnloading.WaitAsync();
                while (!bUnloadingHomingDone)
                {
                    //Arulkumar Fixed Hung start
                    if (GlobalVariable.b_gStop)
                    {
                        break;
                    }
                    //Arulkumar Fixed Hung end
                    if(GlobalVariable.b_gPause)
                    {
                        //Arulkumar Fixed Hung start
                        await Task.Delay(100);
                        //Arulkumar Fixed Hung end
                        continue;
                    }
                    StationName = "Unloading Conveyor";
                    switch (iUnloadingHomeStep)
                    {
                       
                    }
                    //Arulkumar Fixed Hung start
                    await Task.Delay(100);
                    //Arulkumar Fixed Hung end
                }
            }
            catch (Exception e)
            {
                #region Exception Running Log
                await Logger.WriteLogasTask(Logger.LogType.Running, ModuleName, StationName, e.Message.ToString(), e.ToString());
                #endregion
            }
            finally
            {
                //_semaphoreUnloading.Release();
            }
        }
        public static async Task RejectionConveyor_HomingSeq()
        {
            try
            {
                StationName = "RejectionConveyor";
                while(!bRejectionHomingDone)
                {
                    //Arulkumar Fixed Hung start
                    if (GlobalVariable.b_gStop)
                    {
                        break;
                    }
                    //Arulkumar Fixed Hung end
                    if (GlobalVariable.b_gPause)
                    {
                        //Arulkumar Fixed Hung start
                        await Task.Delay(100);
                        //Arulkumar Fixed Hung end
                        continue;
                    }
                    switch (iRejectionHomeStep)
                    {
                        
                    }
                    //Arulkumar Fixed Hung start
                    await Task.Delay(100);
                    //Arulkumar Fixed Hung end
                }
               
            }
            catch (Exception ex)
            {
                Logger.WriteLog(Logger.LogType.Error, "HomingSequence", "RejectionConveyor_HomingSeq", "Exception Error", ex.ToString());
                //throw;
            }
            finally
            {
                //_semaphoreUnloading.Release();
            }
        }
        public static async Task WorkingConveyor_HomingSeq()
        {
            double XAxisCurrentPosition = 0;
            double ZAxisCurrentPosition = 0;


            try
            {
                StationName = "WorkingConveyor";
                
                while (!bWorkingHomingDone)
                {
                    //Arulkumar Fixed Hung start
                    if (GlobalVariable.b_gStop)
                    {
                        break;
                    }
                    //Arulkumar Fixed Hung end
                    if (GlobalVariable.b_gPause)
                    {
                        //Arulkumar Fixed Hung start
                        await Task.Delay(100);
                        //Arulkumar Fixed Hung end
                        continue;
                    }
                   // XAxisCurrentPosition = ServoList.XAxis.GetCurrentPosition();
                    
                    switch (iWorkingHomeStep)
                    {
                        
                    }
                    //Arulkumar Fixed Hung start
                    await Task.Delay(100);
                    //Arulkumar Fixed Hung end
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog(Logger.LogType.Error, "HomingSequence", "WorkingConveyor_HomingSeq", "Exception Error", ex.ToString());
                //throw;
            }
            finally
            {
                //_semaphoreWorking.Release();
            }
        }

        public static async Task LoadingConveyor_HomingSeq()
        {
            try
            {
                StationName = "LoadingConveyor";
               
                while (!bLoadingHomingDone)
                {
                    //Arulkumar Fixed Hung start
                    if (GlobalVariable.b_gStop)
                    {
                        break;
                    }
                    //Arulkumar Fixed Hung end
                    if (GlobalVariable.b_gPause)
                    {
                        //Arulkumar Fixed Hung start
                        await Task.Delay(100);
                        //Arulkumar Fixed Hung end
                        continue;
                    }
                    switch (iLoadingHomeStep)
                    {
                       
                    }
                    //Arulkumar Fixed Hung start
                    await Task.Delay(100);
                    //Arulkumar Fixed Hung end
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog(Logger.LogType.Error, "HomingSequence", "LoadingConveyor_HomingSeq", "Exception Error", ex.ToString());
                //throw;
            }
            finally
            {
                //_semaphoreLoading.Release();
            }
        }

        public static async Task DecapModule_HomingSeq()
        {
            try
            {
                Double XAxisCurrentPosition = 0;
                Double ZAxisCurrentPosition = 0;
                Double XAxisSafePosition = 0;
                Double ZAxisSafePosition = 0;
                bool bZaxisCheckHome = false;
                bool bFlipaxisCheckHome = false;
                bool bXaxisCheckHome = false;
                StationName = "Decap Module";
               
                while (!DecapModuleHomingDone)
                {
                    //Arulkumar Fixed Hung start
                    if (GlobalVariable.b_gStop)
                    {
                        break;
                    }
                    //Arulkumar Fixed Hung end
                    if (GlobalVariable.b_gPause)
                    {
                        //Arulkumar Fixed Hung start
                        await Task.Delay(100);
                        //Arulkumar Fixed Hung end
                        continue;
                    }
                    switch (iDeCapHomeStep)
                    {
                        

                    }
                    //Arulkumar Fixed Hung start
                    await Task.Delay(100);
                    //Arulkumar Fixed Hung end
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog(Logger.LogType.Error, "HomingSequence", "DecapModule_HomingSeq", "Exception Error", ex.ToString());
                //throw;
            }
        }
    }
}
