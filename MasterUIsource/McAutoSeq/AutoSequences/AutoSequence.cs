using ExceptionLib;
using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using Master;
namespace Master.AutoSequences
{
    public class AutoSequence
    {
        public static System.Threading.Timer tmr_Conveyor;
        private static readonly object obj_LodingConLock = new object();
        private static readonly object obj_WorkingConLock = new object();
        private static readonly object obj_DecapLock = new object();
        private static readonly object obj_UnLodingConLock = new object();
        private static readonly object obj_RejConLock = new object();
        public static int iUnloadingConStep = 10;
        public static int iLodingConStep = 10;
        public static int iWorkingConStep = 10;
        public static int iDecapStep = 10;
        public static int iRejConStep = 10;
        public static string LoadingScannerReceiveString = "";
        public static string WorkingScannerReceiveString = "";
        public static string Vision1ReceiveString = "";
        public static string Vision2ReceiveString = "";
        public static string Vision3ReceiveString = "";
        private static int iLoadConRotateSec = 2000; //millisec
        private static int iWorkConRotateSec = 2000; //millisec
        //private static int iWorkConCylTimeOut = 500; //millisec
        public static string StationName = "";
        public static string ModuleName = "AutoSequence";
        //public static int iCylDelayTime = 500; //milliSec
        //private static readonly SemaphoreSlim _semaphoreLoading = new SemaphoreSlim(1, 1);
        //private static readonly SemaphoreSlim _semaphoreWorking = new SemaphoreSlim(1, 1);
        //private static readonly SemaphoreSlim _semaphoreDecap = new SemaphoreSlim(1, 1);
        //private static readonly SemaphoreSlim _semaphoreUnloading = new SemaphoreSlim(1, 1);
        //private static readonly SemaphoreSlim _semaphoreRejection = new SemaphoreSlim(1, 1);
        public static Stopwatch Cycle_Time = new Stopwatch();

        public static async Task RunSequence()
        {
            try
            {
                if (GlobalAutoSequenceExecutor._cts == null)
                {
                    GlobalAutoSequenceExecutor._cts = new CancellationTokenSource();
                }
                await Task.Run(() => StartAutoSequnce(GlobalAutoSequenceExecutor._cts.Token));
            }
            catch (Exception ex)
            {
                Logger.WriteLog(Logger.LogType.Error, "ConveyorSequence", "TimerMethod1", "Exception Error", ex.ToString());
                //throw;
            }
        }
        public static async Task StartAutoSequnce(CancellationToken token)
        {
            try
            {
                if (GlobalVariable.icount == 25)
                {
                    GlobalVariable.icount = 0;
                }
                GlobalVariable.icount = GlobalVariable.icount + 1;
                iLodingConStep = 10;
                iWorkingConStep = 10;
                iUnloadingConStep = 10;
                iRejConStep = 10;
                GlobalVariable.LoadingConvWrk = false;
                GlobalVariable.UnLoadingConvWrk = false;
                GlobalVariable.WorkingConvWrk = false;
                await Task.Run(() => Logger.WriteLogasTask(Logger.LogType.Running, ModuleName, StationName, "Auto Sequence Count : " + Convert.ToString(GlobalVariable.icount), ""));

                //GlobalVariable.RaiseStatusChanged();
                //MainForm Mf = new MainForm();
                //Mf.InvokeRequired = true;
                //Mf.HandleButtonControl();
                //Mf.Dispose();

                //**devchange: add your autosequences here
                
            }
            catch (Exception)
            {
                //Arulkumar Fixed random stoppage start
                Logger.WriteLog(Logger.LogType.Error, "AutoSequence", "StartAutoSequnce", "Exception in auto sequence start", "");
                //Arulkumar Fixed random stoppage end
            }
        }
        

    }

}
