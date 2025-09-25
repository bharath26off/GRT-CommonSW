using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace StreamlineProcess.BaseClass
{
    public class ParallelBase
    {
        private static ParallelBase _instance;
        private static readonly List<Func<Task>> _asyncHandlers = new List<Func<Task>>();

        private readonly Dictionary<Func<Task>, CancellationTokenSource> _handlerTokens = new Dictionary<Func<Task>, CancellationTokenSource>();
        private readonly Dictionary<Func<Task>, Task> _handlerTasks = new Dictionary<Func<Task>, Task>();

        private readonly object _lock = new object();
        private ManualResetEventSlim _pauseEvent = new ManualResetEventSlim(true); // Signaled initially
        private volatile bool _isPaused = false;

        private ParallelBase() { }

        public static ParallelBase GetInstance()
        {
            return _instance ?? (_instance = new ParallelBase());
        }

        // Register handler
        public static bool RegisterAsyncHandler(Func<Task> handler)
        {
            if (_asyncHandlers.Contains(handler))
                return false;

            _asyncHandlers.Add(handler);
            return true;
        }

        public static void UnregisterAsyncHandler(Func<Task> handler)
        {
            _asyncHandlers.Remove(handler);
        }

        // Start execution
        public void Start()
        {
            lock (_lock)
            {
                foreach (var handler in _asyncHandlers)
                {
                    if (_handlerTokens.ContainsKey(handler))
                        continue;

                    var cts = new CancellationTokenSource();
                    var token = cts.Token;

                    var task = Task.Factory.StartNew(async () =>
                    {
                        while (!token.IsCancellationRequested)
                        {
                            _pauseEvent.Wait(); // Pause-safe

                            try
                            {
                                await handler(); // Async execution
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine($"[Handler Exception]: {ex.Message}");
                            }

                            await Task.Delay(200, token); // Control loop rate
                        }
                    }, token, TaskCreationOptions.LongRunning, TaskScheduler.Default).Unwrap();

                    _handlerTokens[handler] = cts;
                    _handlerTasks[handler] = task;
                }
            }
        }

        // Stop everything
        public void Stop()
        {
            lock (_lock)
            {
                foreach (var tokenSource in _handlerTokens.Values)
                {
                    tokenSource.Cancel();
                }

                try
                {
                    Task.WaitAll(_handlerTasks.Values.ToArray(), TimeSpan.FromSeconds(5));
                }
                catch { /* Handle task failures or timeout */ }

                foreach (var cts in _handlerTokens.Values)
                    cts.Dispose();

                _handlerTokens.Clear();
                _handlerTasks.Clear();

                _pauseEvent.Set(); // Ensure unblocked
                _isPaused = false;
            }
        }

        public void Pause()
        {
            _isPaused = true;
            _pauseEvent.Reset(); // Blocks all threads
        }

        public void Resume()
        {
            _isPaused = false;
            _pauseEvent.Set(); // Unblocks all
        }

        public void Reset()
        {
            Stop();
            _asyncHandlers.Clear();
        }

        public bool IsRunning => _handlerTasks.Count > 0;
        public bool IsPaused => _isPaused;
    }
}
