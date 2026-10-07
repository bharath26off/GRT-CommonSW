using ExceptionLib;
using Master;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Master.AutoSequences
{
    public static class GlobalAutoSequenceExecutor
    {
        private static System.Threading.Timer _timer;
        private static readonly object _lock = new object();
        private static List<Func<Task>> _methodsToRun;
        private static bool _isRunning = false;
        public static ManualResetEvent _pauseEvent = new ManualResetEvent(true); // start unpaused

        public static CancellationTokenSource _cts;
        public static event Action OnbuttonStatusChanged;

        public static void SetMethods(params Func<Task>[] methods)
        {
            lock (_lock)
            {
                _methodsToRun = methods.ToList();
            }
        }

        public static void Start()
        {

            //if (_cts != null)
            //    return; // Already running

            //_cts = new CancellationTokenSource();

            //List<Func<Task>> methodsCopy;
            //lock (_lock)
            //{
            //    methodsCopy = new List<Func<Task>>(_methodsToRun);
            //}
            //try
            //{
            //    var tasks = methodsCopy.Select(m => Task.Run(() => m()));
            //    Task.WhenAll(tasks);
            //}
            //catch (Exception ex)
            //{
            //    // console.writeline($"timer error: {ex.message}");
            //}
            //finally
            //{
            //    //_isrunning = false;
            //}

            RaiseButtonStatusChanged();


        }

        public static void Stop()
        {
            GlobalVariable.b_gHomingDone = false;
            GlobalVariable.bautoseq_running = false;
            GlobalVariable.bactive_machine = false;
            GlobalVariable.bhomeseq_running = false;

            GlobalVariable.b_gStop = true;
            GlobalVariable.current_MCStatus = GlobalVariable.MachineStatus.Stop;

            RaiseButtonStatusChanged();

            if (GlobalAutoSequenceExecutor._cts != null)
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
                    Logger.WriteLog(Logger.LogType.Error, "GlobalAutoSequenceExecutor", "Stop.CancelCts", ex.Message, ex.ToString());
                    //Arulkumar Fixed random stoppage end
                }
            }
            //Arulkumar Fixed random stoppage start
            try
            {
                _pauseEvent?.Set();
                _pauseEvent?.Dispose();
            }
            catch (Exception ex)
            {
                //Arulkumar Fixed random stoppage start
                Logger.WriteLog(Logger.LogType.Error, "GlobalAutoSequenceExecutor", "Stop.DisposePauseEvent", ex.Message, ex.ToString());
                //Arulkumar Fixed random stoppage end
            }
            //Arulkumar Fixed random stoppage end
            _pauseEvent = new ManualResetEvent(true); // Or reset it for reuse
        }

        public static void Pause()
        {
            GlobalVariable.b_gPause = true;
            GlobalVariable.current_MCStatus = GlobalVariable.MachineStatus.Pause;
            RaiseButtonStatusChanged();
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
        }

        public static void Resume()
        {
            GlobalVariable.b_gPause = false;
            GlobalVariable.current_MCStatus = GlobalVariable.MachineStatus.Running;
            RaiseButtonStatusChanged();
            //Arulkumar Fixed random stoppage start
            try
            {
                _pauseEvent?.Set(); // Resume all threads
            }
            catch (ObjectDisposedException)
            {
                _pauseEvent = new ManualResetEvent(true);
            }
            //Arulkumar Fixed random stoppage end
        }

        public static void RaiseButtonStatusChanged()
        {
            OnbuttonStatusChanged?.Invoke();
        }
    }
}
