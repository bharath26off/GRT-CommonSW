using ExceptionLib;
using HelperClassLib;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Master.CommonClass
{
    public class MachineHealthTracker
    {
        private static MachineHealthTracker _instance = null;


        private double _lastRuntimeSeconds = 0;
        private double _lastDowntimeSeconds = 0;
        private double _lastIdleTimeSeconds = 0;

        public Stopwatch _runtimeStopwatch = new Stopwatch();
        public Stopwatch _downtimeStopwatch = new Stopwatch();
        public Stopwatch _idleStopwatch = new Stopwatch();

        public DateTime _runtimeStartTime;
        public DateTime _downtimeStartTime;
        public DateTime _idleStartTime;


        public static MachineHealthTracker GetInstance()
        {
            if (_instance == null)
            {
                _instance = new MachineHealthTracker();
            }
            return _instance;
        }

        public async Task MonitorHealthStatus()
        {
            try
            {
                DateTime lastRun = DateTime.MinValue;
                while (true)
                {
                    //Arulkumar Fixed random stoppage start
                    if (GlobalVariable.b_gStop || GlobalVariable.current_MCStatus == GlobalVariable.MachineStatus.CloseApplication)
                        break;
                    //Arulkumar Fixed random stoppage end
                    await Task.Delay(100);
                    var tempShift = SqlUtility.GetCurrentShift();
                    if(string.IsNullOrEmpty(tempShift) || (DateTime.UtcNow - lastRun).TotalSeconds >= 30)
                    {
                        lastRun = DateTime.UtcNow;
                        tempShift = SqlUtility.GetCurrentShift();
                    }
                    if (GlobalVariable.CurrentShift != tempShift)
                    {
                        await GetLiveMachineHealthAndShift();
                        //await GetLiveMachineStatus();
                        // Runtime
                        if (_runtimeStopwatch != null && _runtimeStopwatch.IsRunning)
                        {
                            StartRuntimeTracking();
                        }

                        // Downtime
                        if (_downtimeStopwatch != null && _downtimeStopwatch.IsRunning)
                        {
                            StartDowntimeTracking();
                        }

                        // Idletime
                        if (_idleStopwatch != null && _idleStopwatch.IsRunning)
                        {
                            StartIdleTracking();
                        }
                    }


                    await InsertorUpdateMachineStatus();
                    if (GlobalVariable.current_MCStatus == GlobalVariable.MachineStatus.CloseApplication)
                    {
                        StopAllStatusTimers();
                        //Arulkumar Fixed random stoppage start
                        break;
                        //Arulkumar Fixed random stoppage end
                        //StartRuntimeTracking();
                        //StartDowntimeTracking();
                        //StartIdleTracking();
                    }
                    if (GlobalVariable.current_MCStatus == GlobalVariable.MachineStatus.Running && !_runtimeStopwatch.IsRunning)
                    {
                        StopAllStatusTimers();
                        StartRuntimeTracking();
                    }

                    if (GlobalVariable.g_bAlarm && GlobalVariable.current_MCStatus == GlobalVariable.MachineStatus.Pause && !_downtimeStopwatch.IsRunning)
                    {
                        StopAllStatusTimers();
                        StartDowntimeTracking();
                    }

                    if (!GlobalVariable.g_bAlarm && GlobalVariable.current_MCStatus == GlobalVariable.MachineStatus.Pause)
                    {
                        StopAllStatusTimers();
                        StartIdleTracking();
                    }

                    if (_runtimeStopwatch != null && _runtimeStopwatch.IsRunning)
                    {
                        double currentseconds = _runtimeStopwatch.Elapsed.TotalSeconds;
                        double GetSeconds = currentseconds - _lastRuntimeSeconds;
                        if (GetSeconds > 0)
                        {
                            GlobalVariable.MachineRuntime += (decimal)(GetSeconds / 3600);
                            _lastRuntimeSeconds = currentseconds;
                        }
                    }

                    if (_downtimeStopwatch != null && _downtimeStopwatch.IsRunning)
                    {
                        double currentseconds = _downtimeStopwatch.Elapsed.TotalSeconds;
                        double GetSeconds = currentseconds - _lastDowntimeSeconds;
                        if (GetSeconds > 0)
                        {
                            GlobalVariable.MachineDowntime += (decimal)(GetSeconds / 3600);
                            _lastDowntimeSeconds = currentseconds;
                        }
                    }


                    if (_idleStopwatch != null && _idleStopwatch.IsRunning)
                    {
                        double currentseconds = _idleStopwatch.Elapsed.TotalSeconds;
                        double GetSeconds = currentseconds - _lastIdleTimeSeconds;
                        if (GetSeconds > 0)
                        {
                            GlobalVariable.MachineIdletime += (decimal)(GetSeconds / 3600);
                            _lastIdleTimeSeconds = currentseconds;
                        }
                    }

                    GlobalVariable.MachineTotaltime = GlobalVariable.MachineIdletime + GlobalVariable.MachineRuntime + GlobalVariable.MachineDowntime;
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog(Logger.LogType.Error, "MonitorHealthStatus", "", ex.Message, ex.ToString());
            }
        }

        //public async Task MonitorHealthStatus()
        //{
        //    try
        //    {
        //        DateTime lastRun = DateTime.MinValue;
        //        while (true)
        //        {
        //            await Task.Delay(100);
        //            var tempShift = SqlUtility.GetCurrentShift();
        //            if (GlobalVariable.CurrentShift != tempShift)
        //            {
        //                await InsertorUpdateMachineStatus();
        //                await GetLiveMachineHealthAndShift();
        //                await GetLiveMachineStatus();
        //                // Runtime
        //                if (_runtimeStopwatch != null && _runtimeStopwatch.IsRunning)
        //                {
        //                    StartRuntimeTracking();
        //                }

        //                // Downtime
        //                if (_downtimeStopwatch != null && _downtimeStopwatch.IsRunning)
        //                {
        //                    StartDowntimeTracking();
        //                }

        //                // Idletime
        //                if (_idleStopwatch != null && _idleStopwatch.IsRunning)
        //                {
        //                    StartIdleTracking();
        //                }
        //            }



        //            if (GlobalVariable.current_MCStatus == GlobalVariable.MachineStatus.CloseApplication)
        //            {
        //                StopAllStatusTimers();
        //                //StartRuntimeTracking();
        //                //StartDowntimeTracking();
        //                //StartIdleTracking();
        //            }
        //            if (GlobalVariable.current_MCStatus == GlobalVariable.MachineStatus.Running && !_runtimeStopwatch.IsRunning)
        //            {
        //                StopAllStatusTimers();
        //                StartRuntimeTracking();
        //            }

        //            if (GlobalVariable.g_bAlarm && GlobalVariable.current_MCStatus == GlobalVariable.MachineStatus.Pause && !_downtimeStopwatch.IsRunning)
        //            {
        //                StopAllStatusTimers();
        //                StartDowntimeTracking();
        //            }

        //            if ( GlobalVariable.current_MCStatus == GlobalVariable.MachineStatus.Pause)
        //            {
        //                StopAllStatusTimers();
        //                StartIdleTracking();
        //            }

        //            if (_runtimeStopwatch != null && _runtimeStopwatch.IsRunning)
        //            {
        //                double currentseconds = _runtimeStopwatch.Elapsed.TotalSeconds;
        //                double GetSeconds = currentseconds - _lastRuntimeSeconds;
        //                if (GetSeconds > 0)
        //                {
        //                    GlobalVariable.MachineRuntime += (decimal)(GetSeconds / 3600);
        //                    _lastRuntimeSeconds = currentseconds;
        //                }
        //            }

        //            if (_downtimeStopwatch != null && _downtimeStopwatch.IsRunning)
        //            {
        //                double currentseconds = _downtimeStopwatch.Elapsed.TotalSeconds;
        //                double GetSeconds = currentseconds - _lastDowntimeSeconds;
        //                if (GetSeconds > 0)
        //                {
        //                    GlobalVariable.MachineDowntime += (decimal)(GetSeconds / 3600);
        //                    _lastDowntimeSeconds = currentseconds;
        //                }
        //            }


        //            if (_idleStopwatch != null && _idleStopwatch.IsRunning)
        //            {
        //                double currentseconds = _idleStopwatch.Elapsed.TotalSeconds;
        //                double GetSeconds = currentseconds - _lastIdleTimeSeconds;
        //                if (GetSeconds > 0)
        //                {
        //                    GlobalVariable.MachineIdletime += (decimal)(GetSeconds / 3600);
        //                    _lastIdleTimeSeconds = currentseconds;
        //                }
        //            }

        //            GlobalVariable.MachineTotaltime = GlobalVariable.MachineIdletime + GlobalVariable.MachineRuntime + GlobalVariable.MachineDowntime;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Logger.WriteLog(Logger.LogType.Error, "MonitorHealthStatus", "", ex.Message, ex.ToString());
        //    }
        //}

        // Runtime
        public void StartRuntimeTracking()
        {
            try
            {
                if (_runtimeStopwatch.IsRunning) return;

                _runtimeStopwatch.Restart(); // Automatically resets and starts
                _runtimeStartTime = DateTime.Now;

            }
            catch (Exception ex)
            {
                Logger.WriteLog(Logger.LogType.Error, "StartRuntimeTracking", "", ex.Message, ex.ToString());
            }
        }

        public void StopRuntimeTracking()
        {
            try
            {
                if (!_runtimeStopwatch.IsRunning) return;
                _runtimeStopwatch.Stop();
                DateTime endTime = DateTime.Now;
                TimeSpan duration = _runtimeStopwatch.Elapsed;
                //GlobalVariable.MachineRuntime += Convert.ToDecimal(duration.TotalHours);
                SqlUtility.InsertMachineHelthData("Runtime", _runtimeStartTime, endTime, duration.TotalMinutes, GlobalVariable.CurrentShift);
            }
            catch (Exception ex)
            {
                Logger.WriteLog(Logger.LogType.Error, "StopRuntimeTracking", "", ex.Message, ex.ToString());
            }
        }

        // Idletime
        public void StartIdleTracking()
        {
            try
            {
                if (_idleStopwatch.IsRunning) return;

                _idleStopwatch.Restart();
                _idleStartTime = DateTime.Now;
            }
            catch (Exception ex)
            {
                Logger.WriteLog(Logger.LogType.Error, "StartIdleTracking", "", ex.Message, ex.ToString());
            }
        }

        public void StopIdleTracking()
        {
            try
            {
                if (!_idleStopwatch.IsRunning) return;
                _idleStopwatch.Stop();
                DateTime endTime = DateTime.Now;
                TimeSpan duration = _idleStopwatch.Elapsed;
                //GlobalVariable.MachineIdletime += Convert.ToDecimal(duration.TotalHours);
                SqlUtility.InsertMachineHelthData("Idletime", _idleStartTime, endTime, duration.TotalMinutes, GlobalVariable.CurrentShift);
            }
            catch (Exception ex)
            {
                Logger.WriteLog(Logger.LogType.Error, "StopIdleTracking", "", ex.Message, ex.ToString());
            }
        }

        // Downtime
        public void StartDowntimeTracking()
        {
            try
            {
                if (_downtimeStopwatch.IsRunning) return;
                _downtimeStopwatch.Restart();
                _downtimeStartTime = DateTime.Now;
            }
            catch (Exception ex)
            {
                Logger.WriteLog(Logger.LogType.Error, "StartDowntimeTracking", "", ex.Message, ex.ToString());
            }
        }

        public void StopDowntimeTracking()
        {
            try
            {
                if (!_downtimeStopwatch.IsRunning) return;
                _downtimeStopwatch.Stop();
                DateTime endTime = DateTime.Now;
                TimeSpan duration = _downtimeStopwatch.Elapsed;
                //GlobalVariable.MachineDowntime += Convert.ToDecimal(duration.TotalHours);
                SqlUtility.InsertMachineHelthData("Downtime", _downtimeStartTime, endTime, duration.TotalMinutes, GlobalVariable.CurrentShift);
            }
            catch (Exception ex)
            {
                Logger.WriteLog(Logger.LogType.Error, "StopDowntimeTracking", "", ex.Message, ex.ToString());
            }
        }

        public void StopAllStatusTimers()
        {
            StopRuntimeTracking();
            StopDowntimeTracking();
            StopIdleTracking();
        }

        private async Task GetLiveMachineHealthAndShift()
        {
            //try
            //{
            //    using (SqlDataReader reader = await SqlUtility.ExecuteReaderAsync("SP_GetMachineHealth"))
            //    {
            //        if (reader.Read())
            //        {
            //            decimal runtime = reader["Runtime"] != DBNull.Value ? Convert.ToDecimal(reader["Runtime"]) : 0;
            //            decimal downtime = reader["Downtime"] != DBNull.Value ? Convert.ToDecimal(reader["Downtime"]) : 0;
            //            decimal idletime = reader["Idletime"] != DBNull.Value ? Convert.ToDecimal(reader["Idletime"]) : 0;
            //            string shiftValue = reader["Shift"] != DBNull.Value ? reader["Shift"].ToString() : "N/A";

            //            GlobalVariable.MachineRuntime = Math.Round(runtime / 60, 2);
            //            GlobalVariable.MachineDowntime = Math.Round(downtime / 60, 2);
            //            GlobalVariable.MachineIdletime = Math.Round(idletime / 60, 2);
            //            GlobalVariable.MachineTotaltime = Math.Round((runtime + downtime + idletime) / 60, 2);
            //            GlobalVariable.CurrentShift = shiftValue;
            //        }
            //        else
            //        {
            //            ResetMachineHealthVariables();
            //        }
            //    }
            //}
            //catch (Exception)
            //{
            //    ResetMachineHealthVariables();
            //}
        }

        private async Task InsertorUpdateMachineStatus()
        {
            try
            {
                if (GlobalVariable.dGlobal_Cycle_time != 0)
                {
                    SqlParameter[] parameters = new SqlParameter[]
                   {
                        new SqlParameter("@Date", DateTime.Now.Date.ToLongDateString()),
                        new SqlParameter("@Shift", GlobalVariable.CurrentShift),
                        new SqlParameter("@PassCount", GlobalVariable.dGlobal_Pass_count),
                        new SqlParameter("@FailCount", GlobalVariable.dGlobal_Reject_count),
                        new SqlParameter("@Yield", GlobalVariable.dGlobal_Yield_Count),
                        new SqlParameter("@OverallCount", GlobalVariable.dGlobal_Total_count),
                        new SqlParameter("@CycleTime", GlobalVariable.dGlobal_Cycle_time.ToString("F2"))
                   };
                    await SqlUtility.ExecuteNonQueryAsync("SP_UpsertMachineStatus", parameters);
                }
                //return true;
            }
            catch (Exception ex)
            {

                Logger.WriteLog(Logger.LogType.Error, "MachineHealthTracker", "InsertorUpdateMachineStatus", ex.Message, ex.ToString());

            }
        }

        private async Task GetLiveMachineStatus()
        {
            try
            {
                if (GlobalVariable.dGlobal_Cycle_time != 0)
                {
                    SqlParameter[] parameters = new SqlParameter[]
                       {
                        new SqlParameter("@Shift", GlobalVariable.CurrentShift)
                       };
                    using (SqlDataReader reader = await SqlUtility.ExecuteReaderAsync("SP_GetMachineCurrentStatus", parameters))
                    {
                        if (reader != null && reader.Read())
                        {
                            GlobalVariable.dGlobal_Pass_count = reader.GetInt32(reader.GetOrdinal("TotalPassCount"));
                            GlobalVariable.dGlobal_Reject_count = reader.GetInt32(reader.GetOrdinal("TotalFailCount"));
                            GlobalVariable.dGlobal_Total_count = reader.GetInt32(reader.GetOrdinal("TotalOverallCount"));
                            GlobalVariable.dGlobal_Cycle_time = (float)reader.GetDouble(reader.GetOrdinal("TotalCycleTime"));
                        }
                        else
                        {
                            //ResetMachineStatusVariables(); //Cmd by Arul
                        }
                    }
                }
            }
            catch (Exception)
            {
                //ResetMachineStatusVariables(); //Cmd by Arul
            }
        }

        private void ResetMachineHealthVariables()
        {
            GlobalVariable.MachineRuntime = 0;
            GlobalVariable.MachineDowntime = 0;
            GlobalVariable.MachineIdletime = 0;
            GlobalVariable.MachineTotaltime = 0;
        }


        private void ResetMachineStatusVariables()
        {
            GlobalVariable.dGlobal_Pass_count = 0;
            GlobalVariable.dGlobal_Reject_count = 0;
            GlobalVariable.dGlobal_Total_count = 0;
            GlobalVariable.dGlobal_Cycle_time = 0;
        }
    }
}
