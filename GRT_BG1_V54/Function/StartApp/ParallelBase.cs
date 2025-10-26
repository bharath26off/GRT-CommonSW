using System;
using System.Collections.Concurrent;
using System.Threading;
using System.Threading.Tasks;

namespace StreamlineProcess.BaseClass
{
    public class Parallelbase : IDisposable
    {
        private readonly ConcurrentBag<Task> _runningTasks = new ConcurrentBag<Task>();
        private readonly ManualResetEventSlim _pauseEvent = new ManualResetEventSlim(true);
        private CancellationTokenSource _cts = new CancellationTokenSource();

        // ------------------------ Public Control Methods ------------------------
        public void Pause() => _pauseEvent.Reset();
        public void Resume() => _pauseEvent.Set();

        /// <summary>
        /// Immediately stops all running loops.
        /// </summary>
        public void EmergencyStop()
        {
            _cts.Cancel();             // trigger cancellation
            _pauseEvent.Set();         // release any paused loops
            while (_runningTasks.TryTake(out _)) { } // clear tracked tasks
            _cts.Dispose();
            _cts = new CancellationTokenSource();
        }

        public void Dispose()
        {
            EmergencyStop();
            _pauseEvent.Dispose();
            _cts.Dispose();
        }

        // ------------------------ Run Async Loop ------------------------
        /// <summary>
        /// Runs an async function repeatedly until the condition is false or emergency stop is triggered.
        /// </summary>
        /// <param name="asyncFunc">Async function to execute. Accepts a CancellationToken.</param>
        /// <param name="condition">Loop condition. Loop runs while this returns true.</param>
        /// <param name="delayMs">Delay between iterations to reduce CPU usage (default 100ms).</param>
        /// <param name="fireAndForget">If true, returns immediately without waiting for the loop to finish.</param>
        public Task RunAsyncLoop(
            Func<CancellationToken, Task> asyncFunc,
            Func<bool> condition,
            int delayMs = 100,
            bool fireAndForget = false)
        {
            if (asyncFunc == null) throw new ArgumentNullException(nameof(asyncFunc));
            if (condition == null) throw new ArgumentNullException(nameof(condition));

            var token = _cts.Token;

            Task loopTask = Task.Factory.StartNew(async () =>
            {
                try
                {
                    while (!token.IsCancellationRequested && condition())
                    {
                        // Respect pause
                        _pauseEvent.Wait(token);

                        try
                        {
                            await asyncFunc(token);
                        }
                        catch (OperationCanceledException)
                        {
                            break; // stop immediately on cancel
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("[ASYNC LOOP ERROR] " + ex.Message);
                        }

                        // Reduce CPU usage
                        if (delayMs > 0)
                        {
                            try { await Task.Delay(delayMs, token); }
                            catch (OperationCanceledException) { break; }
                        }
                        else
                        {
                            await Task.Yield(); // minimal yield to prevent CPU spin
                        }
                    }
                }
                catch (OperationCanceledException)
                {
                    // loop stopped immediately
                }
                catch (Exception ex)
                {
                    Console.WriteLine("[ASYNC LOOP FATAL ERROR] " + ex.Message);
                }
            }, token, TaskCreationOptions.LongRunning, TaskScheduler.Default).Unwrap();

            _runningTasks.Add(loopTask);
            return fireAndForget ? Task.CompletedTask : loopTask;
        }
    }
}
