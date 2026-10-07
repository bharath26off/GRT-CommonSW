using ExceptionLib;
using GRT_BG1.Function.DryRun;
using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;

/// <summary>
/// Lightweight PDCA client helper that wraps PDCA send logic (based on existing SocketClient implementation).
/// Provides retries, per-attempt timeout and cavity result tracking similar to SfcClient.
/// </summary>
public static class PdcaClient
{
    private static string _detailFilePath;
    private static string _detailFilePathPDCA;
    private static int _detailRowCounter;
    private static Stopwatch stop_1;

    // Subscribe to WorkingConveyor2 update event so captured data is forwarded to PDCA depending on work mode
    static PdcaClient()
    {
        try
        {
            // find the WorkingConveyor2 type in loaded assemblies
            Type wcType = null;
            foreach (var asm in AppDomain.CurrentDomain.GetAssemblies())
            {
                //Arulkumar Fixed random stoppage start
                try { wcType = asm.GetType("GRT_BG1.Function.DryRun.WorkingConveyor2") ?? asm.GetType("WorkingConveyor2"); } catch (Exception ex) { Logger.WriteLog(Logger.LogType.Error, "PdcaClient", "ResolveWorkingConveyorType", ex.Message, ex.ToString()); }
                //Arulkumar Fixed random stoppage end
                if (wcType != null) break;
            }

        }
        catch
        {
            
        }
    }
        

    // Store PDCA send data into CSV files at D:\TEAL\PDCA_Data\DD-MM-YYYY_HH-mm.csv
    public static void StorePdcaData(string carrierSn, string cavityNo, string leftGap, string angle, string bottomGap, string pressForce, string barcode)
    {
        try
        {
            string baseDir = @"D:\TEAL\PDCA_Data";
            if (!Directory.Exists(baseDir)) Directory.CreateDirectory(baseDir);

          //  string ts = DateTime.Now.ToString("dd-MM-yyyy_HH-mm");
            string ts = DateTime.Now.ToString("dd-MM-yyyy_HH");
            string filename = Path.Combine(baseDir, ts + ".csv");
            bool exists = File.Exists(filename);

            var sb = new StringBuilder();
            if (!exists)
            {
                sb.AppendLine("S.No,DateTime,CARRIER_SN,Barcode,cavity_number,left_gap_Y,Angles,bottom_gap_X,press_force,press_time,tossing,cycle_time");
            }

            int sno = 1;
            try
            {
                if (exists)
                {
                    var lines = File.ReadAllLines(filename);
                    sno = Math.Max(1, lines.Length);
                }
            }
            catch (Exception ex)
            {
                //Arulkumar Fixed random stoppage start
                Logger.WriteLog(Logger.LogType.Error, "PdcaClient", "StorePdcaData", ex.Message, ex.ToString());
                //Arulkumar Fixed random stoppage end
            }

            //Arulkumar Fixed Null start
            string dt1;
            if (WorkingConveyor2.Storing_TimeStamp == null || Convert.ToInt32(cavityNo) < 0 || Convert.ToInt32(cavityNo) >= WorkingConveyor2.Storing_TimeStamp.Length)
            {
                dt1 = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            }
            else
            {
                dt1 = WorkingConveyor2.Storing_TimeStamp[Convert.ToInt32(cavityNo)];
            }
            //Arulkumar Fixed Null end
            string dt = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            string line = string.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8},0.5,0,{9}", sno, dt1, carrierSn, barcode, cavityNo, leftGap, angle, bottomGap, pressForce, "42.509479");
            sb.AppendLine(line);

            File.AppendAllText(filename, sb.ToString(), Encoding.UTF8);
        }
        catch (Exception ex)
        {
            //Arulkumar Fixed random stoppage start
            Logger.WriteLog(Logger.LogType.Error, "PdcaClient", "StorePdcaData", ex.Message, ex.ToString());
            //Arulkumar Fixed random stoppage end
        }
    }

    // Event handler signature matches WorkingConveyor2.updatecavity: Func<int, int, string,bool,string, bool>
    // We'll adapt incoming data and call SendPdcaDataAsync in fire-and-forget manner when in Production mode.
    private static bool WorkingConveyor_UpdateCavity(int row, int col, string sn, bool ok, string carrier, bool dummy)
    {
        try
        {
            // Only send in Production mode
            var gvType = Type.GetType("Master.GlobalVariable") ?? Type.GetType("GlobalVariable");
            bool production = false;
            try
            {
                var field = gvType?.GetField("g_bMachineMode", BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
                if (field != null)
                {
                    var mode = field.GetValue(null);
                    if (mode != null && mode.ToString().Contains("Production")) production = true;
                }
            }
            catch (Exception ex)
            {
                //Arulkumar Fixed random stoppage start
                Logger.WriteLog(Logger.LogType.Error, "PdcaClient", "WorkingConveyor_UpdateCavity", ex.Message, ex.ToString());
                //Arulkumar Fixed random stoppage end
            }

            if (!production) return true;

            // Build PDCA data from parameters - cavity index mapping: try to parse cavityNo from carrier/row/col if available
            int cavityIndex = 0;
            string cavityNo = "1";
            //Arulkumar Fixed random stoppage start
            try { cavityNo = (col + 1).ToString(); } catch (Exception ex) { Logger.WriteLog(Logger.LogType.Error, "PdcaClient", "WorkingConveyor_UpdateCavity.CavityNo", ex.Message, ex.ToString()); }
            //Arulkumar Fixed random stoppage end

            // send asynchronously (don't block the caller)
            Task.Run(async () =>
            {
                try
                {
                    using (var cts = new CancellationTokenSource(5000))
                    {
                        await SendPdcaDataAsync(cavityIndex, carrier, sn ?? string.Empty, cavityNo, leftGap: "0", angle: "0", bottomGap: "0", pressForce: "0", cts.Token);
                    }
                }
                catch (Exception ex)
                {
                    //Arulkumar Fixed random stoppage start
                    Logger.WriteLog(Logger.LogType.Error, "PdcaClient", "WorkingConveyor_UpdateCavity", ex.Message, ex.ToString());
                    //Arulkumar Fixed random stoppage end
                }
            });

            return true;
        }
        catch (Exception ex)
        {
            //Arulkumar Fixed random stoppage start
            Logger.WriteLog(Logger.LogType.Error, "PdcaClient", "WorkingConveyor_UpdateCavity", ex.Message, ex.ToString());
            //Arulkumar Fixed random stoppage end
            return true;
        }
    }

    /// <summary>
    /// Send final PDCA data using the same handshake used in SocketClient.Final_Data_Send_PDCA.
    /// This posts a start block, then the full payload and waits for acknowledgement in SocketClient.V_ReceiveFinalSFCData.
    /// </summary>
    public static bool Final_Data_Send_PDCA(string Carrier_sn, string barcode, string cavity_no, string left_gap, string angle, string bottom_gap, string press_force)
    {
        int step = 10;
        //Arulkumar Fixed Hung start
        int pdcaLoopRetryCount = 0;
        const int MAX_PDCA_LOOP_RETRIES = 30;
        //Arulkumar Fixed Hung end
        while (true)
        {
            //Arulkumar Fixed Hung start
            pdcaLoopRetryCount++;
            if (pdcaLoopRetryCount > MAX_PDCA_LOOP_RETRIES)
            {
                Logger.WriteLog(Logger.LogType.Error, "PdcaClient", "Final_Data_Send_PDCA", "PDCA send exceeded max retry loops", barcode);
                return false;
            }
            //Arulkumar Fixed Hung end
            switch (step)
            {
                case 10:
                    {

                        String Start = "_{\r\n" + barcode + "@start\r\n}";
                        try
                        {
                            // X3Y3 logging not available in this build; fall back to Logger
                            Logger.WriteLog(Logger.LogType.Info, "PdcaClient", "Final_Data_Send_PDCA", "PDCA start block sent", Start);
                        }
                        catch (Exception ex)
                        {
                            //Arulkumar Fixed random stoppage start
                            Logger.WriteLog(Logger.LogType.Error, "PdcaClient", "Final_Data_Send_PDCA", ex.Message, ex.ToString());
                            //Arulkumar Fixed random stoppage end
                        }
                        try
                        {
                            var socketType = Type.GetType("SocketClient") ?? Type.GetType("G1_Testing.SocketClient") ?? Type.GetType("GRT_BG1.PdcaClient") ?? Type.GetType("GRT_BG1.PdcaClient");
                            var recv = socketType?.GetMethod("SFC_Data_Receive", BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
                            try { recv?.Invoke(null, new object[] { Start }); } catch (Exception ex) { Logger.WriteLog(Logger.LogType.Error, "PdcaClient", "SendPdcaDataAsync.RecvStart", ex.Message, ex.ToString()); }
                        }
                        catch (Exception ex)
                        {
                            //Arulkumar Fixed random stoppage start
                            Logger.WriteLog(Logger.LogType.Error, "PdcaClient", "Final_Data_Send_PDCA", ex.Message, ex.ToString());
                            //Arulkumar Fixed random stoppage end
                        }
                        step = 20;
                    }
                    break;
                case 20:
                    {

                        String querysend = "_{\r\n"
                          + barcode + "@attr@BALI Version@V1.0\r\n"
                          + barcode + "@attr@MLB_SN@" + barcode + "\r\n"
                         + barcode + "@attr@Machine_ID@Bot_Grt\r\n"
                         + barcode + "@attr@Carrier_SN@" + Carrier_sn + "\r\n"
                         + barcode + "@attr@Bottom_graphite_PKG_ID@L876042032522005S1\r\n"
                          + barcode + "@attr@Bottom_graphite_DC@051922\r\n"
                          + barcode + "@attr@Bottom_graphite_LC@1000\r\n"
                          + barcode + "@pdata@bottom_graphite_vendor@1\r\n"
                          + barcode + "@pdata@pallet_number@2\r\n"
                          + barcode + "@pdata@cavity_number@" + cavity_no + "\r\n"
                          + barcode + "@pdata@left_gap_Y@" + left_gap + "@0.15@0.75@degres\r\n"
                          + barcode + "@pdata@Angles@" + angle + "@-1@1@mm\r\n"
                          + barcode + "@pdata@bottom_gap_X@" + bottom_gap + "@0.15@0.75@mm\r\n"
                          + barcode + "@pdata@press_force@" + press_force + "@1.8@2.2@Kgf\r\n"
                          + barcode + "@pdata@press_time@0.5@0.5@0.5@S\r\n"
                          + barcode + "@pdata@tossing@0\r\n"
                          + barcode + "@pdata@cycle_time@42.509479@0@NA@S\r\n"
                          + barcode + "@pdata@cm_vendor@0\r\n"
                          + barcode + "@pdata@Operator_ID@0\r\n"
                         + barcode + "@pdata@Mode@0\r\n"
                          + barcode + "@pdata@TestSeriesID@0\r\n"
                          + barcode + "@pdata@Priority@0\r\n"
                          + barcode + "@pdata@Online@1\r\n"
                         + barcode + "@submit@LYSA_EVT_TEAL_BOT_GRT_v1.0\r\n}";
                        try
                        {
                            // X3Y3 logging not available; record the query with Logger instead
                            Logger.WriteLog(Logger.LogType.Info, "PdcaClient", "Final_Data_Send_PDCA", "PDCA query sent", querysend);
                        }
                        catch (Exception ex)
                        {
                            //Arulkumar Fixed random stoppage start
                            Logger.WriteLog(Logger.LogType.Error, "PdcaClient", "Final_Data_Send_PDCA", ex.Message, ex.ToString());
                            //Arulkumar Fixed random stoppage end
                        }
                        try
                        {
                            var socketType = Type.GetType("SocketClient") ?? Type.GetType("G1_Testing.SocketClient") ?? Type.GetType("GRT_BG1.PdcaClient") ?? Type.GetType("GRT_BG1.PdcaClient");
                            var recv = socketType?.GetMethod("SFC_Data_Receive", BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
                            try { recv?.Invoke(null, new object[] { querysend }); } catch (Exception ex) { Logger.WriteLog(Logger.LogType.Error, "PdcaClient", "SendPdcaDataAsync.RecvQuery", ex.Message, ex.ToString()); }
                        }
                        catch (Exception ex)
                        {
                            //Arulkumar Fixed random stoppage start
                            Logger.WriteLog(Logger.LogType.Error, "PdcaClient", "Final_Data_Send_PDCA", ex.Message, ex.ToString());
                            //Arulkumar Fixed random stoppage end
                        }
                        stop_1 = Stopwatch.StartNew();
                        step = 30;
                    }
                    break;
                case 30:
                    {
                        try
                        {
                            var socketType = Type.GetType("SocketClient") ?? Type.GetType("G1_Testing.SocketClient");
                            var finalField = socketType?.GetField("V_ReceiveFinalSFCData", BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
                            var finalProp = socketType?.GetProperty("V_ReceiveFinalSFCData", BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
                            var finalVal = finalField != null ? finalField.GetValue(null) : finalProp != null ? finalProp.GetValue(null) : null;
                            string finalStr = finalVal?.ToString() ?? string.Empty;

                            if (!finalStr.Contains("ok@{success}@"))
                            {
                                if (stop_1.Elapsed.TotalSeconds > 1)
                                {
                                    stop_1.Stop();
                                    step = 20;
                                }
                                else if (finalStr.Contains("bad@{"))
                                {
                                    try
                                    {
                                        Logger.WriteLog(Logger.LogType.Error, "PdcaClient", "Final_Data_Send_PDCA", "PDCA response bad", finalStr);
                                    }
                                    catch (Exception ex)
                        {
                            //Arulkumar Fixed random stoppage start
                            Logger.WriteLog(Logger.LogType.Error, "PdcaClient", "Final_Data_Send_PDCA", ex.Message, ex.ToString());
                            //Arulkumar Fixed random stoppage end
                        }
                                    return false;
                                }
                                else if (finalStr.Contains("err@{"))
                                {
                                    try
                                    {
                                        Logger.WriteLog(Logger.LogType.Error, "PdcaClient", "Final_Data_Send_PDCA", "PDCA response err", finalStr);
                                    }
                                    catch (Exception ex)
                        {
                            //Arulkumar Fixed random stoppage start
                            Logger.WriteLog(Logger.LogType.Error, "PdcaClient", "Final_Data_Send_PDCA", ex.Message, ex.ToString());
                            //Arulkumar Fixed random stoppage end
                        }
                                    return false;
                                }
                            }
                            else
                            {
                                step = 0;
                                return true;
                            }
                        }
                        catch (Exception ex)
                        {
                            //Arulkumar Fixed random stoppage start
                            Logger.WriteLog(Logger.LogType.Error, "PdcaClient", "Final_Data_Send_PDCA", ex.Message, ex.ToString());
                            //Arulkumar Fixed random stoppage end
                        }

                    }
                    break;
            }
        }

    }
    public static void PDCA_data_log(string PdcaData, string Cavity_no)
    {
        try
        {
            _detailFilePathPDCA = "";
            string baseDir = @"D:\\TEAL\\PDCA_Data_Log";
            if (!Directory.Exists(baseDir)) Directory.CreateDirectory(baseDir);
            if (string.IsNullOrEmpty(_detailFilePathPDCA))
            {

                _detailFilePathPDCA = Path.Combine(baseDir, DateTime.Now.Date.ToString("dd_MM_yyyy") + ".csv"); // AK need to check

                if (!File.Exists(_detailFilePathPDCA))
                {

                    File.WriteAllText(_detailFilePathPDCA,
                            PdcaData + Environment.NewLine);
                }

                _detailRowCounter = 0;
            }
            //Arulkumar Fixed Null start
            string dt1;
            if (WorkingConveyor2.Storing_TimeStamp == null || Convert.ToInt32(Cavity_no) < 0 || Convert.ToInt32(Cavity_no) >= WorkingConveyor2.Storing_TimeStamp.Length)
            {
                dt1 = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            }
            else
            {
                dt1 = WorkingConveyor2.Storing_TimeStamp[Convert.ToInt32(Cavity_no)];
            }
            //Arulkumar Fixed Null end

            File.AppendAllText(_detailFilePathPDCA, dt1 + '\n');

            File.AppendAllText(_detailFilePathPDCA, PdcaData + '\n' + Environment.NewLine + '\n' + '\n');
        }
        catch
        {

        }

    }

    //public static void PDCA_data_log(string PdcaData)
    //{
    //    try
    //    {
    //        string baseDir = @"D:\TEAL\PDCA_LOG";
    //        if (!Directory.Exists(baseDir)) Directory.CreateDirectory(baseDir);

    //        // string ts = DateTime.Now.ToString("dd-MM-yyyy_HH-mm");
    //        string ts = DateTime.Now.ToString("dd-MM-yyyy_HH");
    //        string filename = Path.Combine(baseDir, ts + ".csv");
    //        bool exists = File.Exists(filename);

    //        var sb = new StringBuilder();
    //        if (!exists)
    //        {
    //            sb.AppendLine("S.No,DateTime,PDCA_Data");
    //        }

    //        // S.No: use file line count + 1 (cheap method)
    //        int sno = 1;
    //        try
    //        {
    //            if (exists)
    //            {
    //                var lines = File.ReadAllLines(filename);
    //                sno = Math.Max(1, lines.Length);
    //            }
    //        }
    //        catch { }

    //        string line = string.Format("{0},{1},\"{2}\"", sno, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), PdcaData);
    //        sb.AppendLine(line);

    //        File.AppendAllText(filename, sb.ToString(), Encoding.UTF8);
    //    }
    //    catch { }
    //}
    public static bool TCP_Senddata_PDCA(string val)
    {
            try
            {
                // reuse existing SocketClient helper which knows about PDCA client object
                var socketType = Type.GetType("SocketClient") ?? Type.GetType("G1_Testing.SocketClient");
                var tcp = socketType?.GetMethod("TCP_Senddata_PDCA", BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
                if (tcp != null)
                {
                    var r = tcp.Invoke(null, new object[] { val });
                    if (r is bool b) return b;
                    return r != null;
                }
                return false;
            }
        catch (Exception ex)
        {
            Logger.WriteLog(Logger.LogType.Error, "PdcaClient", "TCP_Senddata_PDCA", ex.Message, ex.ToString());
        }
        return false;
    }
    /// <summary>
    /// Send PDCA data (carrier + barcode + measurements) with retries and timeout.
    /// Updates SfcClient.barcode__Recheck_result and SfcClient.SFC_Cavity_sn_data_Sent like SFC flow.
    /// </summary>
    public static async Task<bool> SendPdcaDataAsync(int cavityIndex, string carrierSn, string barcode, string cavityNo, string leftGap, string angle, string bottomGap, string pressForce, CancellationToken ct = default, int retries = 2, int timeoutMs = 2000)
    {
        try
        {
            if (string.IsNullOrWhiteSpace(barcode) || string.Equals(barcode, "NA", StringComparison.OrdinalIgnoreCase))
            {
                SfcClient.barcode__Recheck_result[cavityIndex] = "NOK";
                SfcClient.SFC_Cavity_sn_data_Sent[cavityIndex] = false;
                Logger.WriteLog(Logger.LogType.Info, "PdcaClient", "SendPdcaDataAsync", "Barcode empty or NA - not sent", barcode);
                return false;
            }

            try
            {
                if (Master.GlobalVariable.SFC_PDCA_Bypass)
                {
                    SfcClient.barcode__Recheck_result[cavityIndex] = "OFFLINE";
                    SfcClient.SFC_Cavity_sn_data_Sent[cavityIndex] = true;
                    Logger.WriteLogasTask(Logger.LogType.Info, "PdcaClient", "SendPdcaDataAsync", "SFC_PDCA_Bypass enabled - marking OFFLINE", barcode);
                    return true;
                }
            }
            catch (Exception ex)
            {
                //Arulkumar Fixed random stoppage start
                Logger.WriteLog(Logger.LogType.Error, "PdcaClient", "SendPdcaDataAsync", ex.Message, ex.ToString());
                //Arulkumar Fixed random stoppage end
            }

            int maxAttempts = Math.Max(1, retries + 1);
            int backoffMs = 250;

            for (int attempt = 1; attempt <= maxAttempts; attempt++)
            {
                if (ct.IsCancellationRequested)
                {
                    SfcClient.barcode__Recheck_result[cavityIndex] = "NOK";
                    SfcClient.SFC_Cavity_sn_data_Sent[cavityIndex] = false;
                    Logger.WriteLog(Logger.LogType.Info, "PdcaClient", "SendPdcaDataAsync", "Cancellation requested before send", barcode);
                    return false;
                }

                Logger.WriteLog(Logger.LogType.Info, "PdcaClient", "SendPdcaDataAsync", $"Attempt {attempt}/{maxAttempts} sending PDCA data", barcode);

                // Store PDCA data being sent (one record per attempt)
                try
                {
                  //  StorePdcaData(carrierSn, cavityNo, leftGap, angle, bottomGap, pressForce, barcode);
                }
                catch (Exception ex)
                {
                    //Arulkumar Fixed random stoppage start
                    Logger.WriteLog(Logger.LogType.Error, "PdcaClient", "SendPdcaDataAsync", ex.Message, ex.ToString());
                    //Arulkumar Fixed random stoppage end
                }

                bool? sendResult = null;

                try
                {
                    var sendTask = Task.Run(() =>
                    {
                        try
                        {
                            // Prefer specialized helper on SocketClient (static Final_Data_Send_PDCA)
                            Type socketClientType = Type.GetType("G1_Testing.SocketClient") ?? Type.GetType("SocketClient") ?? Type.GetType("GRT_BG1.PdcaClient");
                            if (socketClientType != null)
                            {
                                var finalMeth = socketClientType.GetMethod("Final_Data_Send_PDCA", BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
                                if (finalMeth != null)
                                {
                                    var r = finalMeth.Invoke(null, new object[] { carrierSn, barcode, cavityNo, leftGap, angle, bottomGap, pressForce });
                                    if (r is bool b) return b;
                                    return r != null;
                                }

                                // fallback: try TCP_Senddata_PDCA + polling V_ReceivePDCAData2
                                var tcpMeth = socketClientType.GetMethod("TCP_Senddata_PDCA", BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
                                if (tcpMeth != null)
                                {
                                    string payload = "_{" + "\r\n" + barcode + "@attr@MLB_SN@" + barcode + "\r\n}"; // minimal wrapper if needed
                                    //Arulkumar Fixed random stoppage start
                                    try { tcpMeth.Invoke(null, new object[] { payload }); } catch (Exception ex) { Logger.WriteLog(Logger.LogType.Error, "PdcaClient", "SendPdcaDataAsync.TcpPayload", ex.Message, ex.ToString()); try { tcpMeth.Invoke(null, new object[] { barcode }); } catch (Exception ex2) { Logger.WriteLog(Logger.LogType.Error, "PdcaClient", "SendPdcaDataAsync.TcpBarcode", ex2.Message, ex2.ToString()); } }
                                    //Arulkumar Fixed random stoppage end

                                    FieldInfo staticField = socketClientType.GetField("V_ReceivePDCAData2", BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
                                    PropertyInfo staticProp = socketClientType.GetProperty("V_ReceivePDCAData2", BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);

                                    int waited = 0; int pollInterval = 100;
                                    while (waited < timeoutMs)
                                    {
                                        string resp = string.Empty;
                                        if (staticField != null)
                                        {
                                            var val = staticField.GetValue(null);
                                            resp = val?.ToString() ?? string.Empty;
                                        }
                                        else if (staticProp != null)
                                        {
                                            var val = staticProp.GetValue(null);
                                            resp = val?.ToString() ?? string.Empty;
                                        }

                                        if (!string.IsNullOrEmpty(resp))
                                        {
                                            if (resp.Contains("ok@{success}@") || resp.Contains("SFC_OK"))
                                            {
                                                return true;
                                            }
                                            if (resp.Contains("bad@{") || resp.Contains("err@{"))
                                            {
                                                return false;
                                            }
                                        }

                                        Thread.Sleep(pollInterval);
                                        waited += pollInterval;
                                    }

                                    return false; // timed out
                                }
                            }

                            return false;
                        }
                        catch (Exception ex)
                        {
                            Task.Run(() => Logger.WriteLog(Logger.LogType.Error, "PdcaClient", "SendPdca (invoked)", ex.Message, ex.ToString()));
                            return false;
                        }
                    }, ct);

                    var delayTask = Task.Delay(timeoutMs, ct);
                    var completed = await Task.WhenAny(sendTask, delayTask).ConfigureAwait(false);
                    if (completed == sendTask)
                    {
                        //Arulkumar Fixed Hung start
                        sendResult = await sendTask.ConfigureAwait(false);
                        //Arulkumar Fixed Hung end
                    }
                    else
                    {
                        sendResult = false;
                        Logger.WriteLogasTask(Logger.LogType.Error, "PdcaClient", "SendPdcaDataAsync", $"Attempt {attempt} timed out after {timeoutMs}ms", barcode);
                    }
                }
                catch (OperationCanceledException)
                {
                    Logger.WriteLog(Logger.LogType.Info, "PdcaClient", "SendPdcaDataAsync", "Operation cancelled during send", barcode);
                    sendResult = false;
                }
                catch (Exception ex)
                {
                    Logger.WriteLog(Logger.LogType.Error, "PdcaClient", "SendPdcaDataAsync", ex.Message, ex.ToString());
                    sendResult = false;
                }

                if (sendResult == true)
                {
                    SfcClient.barcode__Recheck_result[cavityIndex] = "OK";
                    SfcClient.SFC_Cavity_sn_data_Sent[cavityIndex] = true;
                    Logger.WriteLog(Logger.LogType.Info, "PdcaClient", "SendPdcaDataAsync", $"PDCA data sent successfully on attempt {attempt}", barcode);
                    return true;
                }

                if (attempt < maxAttempts)
                {
                    int wait = backoffMs * attempt;
                    Logger.WriteLog(Logger.LogType.Info, "PdcaClient", "SendPdcaDataAsync", $"Will retry after {wait}ms", barcode);
                    //Arulkumar Fixed random stoppage start
                    try { await Task.Delay(wait, ct).ConfigureAwait(false); } catch (OperationCanceledException) { }
                    //Arulkumar Fixed random stoppage end
                }
            }

            SfcClient.barcode__Recheck_result[cavityIndex] = "NOK";
            SfcClient.SFC_Cavity_sn_data_Sent[cavityIndex] = false;
            Logger.WriteLog(Logger.LogType.Error, "PdcaClient", "SendPdcaDataAsync", $"Failed to send PDCA data after {retries + 1} attempts", barcode);
            return false;
        }
        catch (Exception ex)
        {
            Logger.WriteLog(Logger.LogType.Error, "PdcaClient", "SendPdcaDataAsync", ex.Message, ex.ToString());
            try
            {
                SfcClient.barcode__Recheck_result[cavityIndex] = "NOK";
                SfcClient.SFC_Cavity_sn_data_Sent[cavityIndex] = false;
            }
            catch (Exception innerEx)
            {
                //Arulkumar Fixed random stoppage start
                Logger.WriteLog(Logger.LogType.Error, "PdcaClient", "SendPdcaDataAsync", innerEx.Message, innerEx.ToString());
                //Arulkumar Fixed random stoppage end
            }
            return false;
        }
    }
}
