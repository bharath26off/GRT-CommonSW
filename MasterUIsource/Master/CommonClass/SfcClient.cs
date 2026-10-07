using ExceptionLib;
using System.IO;
using System.Text;
using System;
using System.Collections.Concurrent;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Master;

/// <summary>
/// Small SFC client helper used to send barcode data to SFC with retries, timeout and state tracking.
/// Designed to be thread-safe and non-blocking for caller (returns Task<bool>).
/// </summary>
public static class SfcClient
{
    // Track per-cavity results and whether SN data was sent to SFC.
    // Using ConcurrentDictionary so we don't need to know cavity count at compile time.
    public static ConcurrentDictionary<int, string> barcode__Recheck_result = new ConcurrentDictionary<int, string>();
    public static ConcurrentDictionary<int, bool> SFC_Cavity_sn_data_Sent = new ConcurrentDictionary<int, bool>();
    private static object get;
    //Arulkumar Fixed random stoppage start
    //Reason:
    //Root Cause: Concurrent access to the same SFC CSV file caused file-in-use exceptions.
    //Fix: Serialized the existing file-write operation and ensured the existing file handle is released correctly.
    private static readonly object sfcFileWriteLock = new object();
    //Arulkumar Fixed random stoppage end

    /// <summary>
    /// Send barcode to SFC with retries and timeout. Sets per-cavity state in barcode__Recheck_result and SFC_Cavity_sn_data_Sent.
    /// Returns true when the barcode has been accepted / logically handled; false otherwise.
    /// If GlobalVariable.SFC_PDCA_Bypass is set this will record an "OFFLINE" result and return true (treated as handled).
    /// </summary>
    /// <param name="cavityIndex">Index of cavity to record state for.</param>
    /// <param name="barcode">Barcode string to send. If null/empty or "NA" this will return false immediately and record "NOK".</param>
    /// <param name="ct">Cancellation token to abort waiting or retries.</param>
    /// <param name="retries">Number of retries (default 2).</param>
    /// <param name="timeoutMs">Per-attempt timeout in milliseconds (default 2000).</param>
    public static async Task<bool> SendBarcodeToSfcAsync(int cavityIndex, string barcode, CancellationToken ct = default, int retries = 2, int timeoutMs = 2000)
    {
        try
        {
            // Validate barcode
            if (string.IsNullOrWhiteSpace(barcode) || string.Equals(barcode, "NA", StringComparison.OrdinalIgnoreCase))
            {
                barcode__Recheck_result[cavityIndex] = "NOK";
                SFC_Cavity_sn_data_Sent[cavityIndex] = false;
                Logger.WriteLog(Logger.LogType.Info, "SfcClient", "SendBarcodeToSfcAsync", "Barcode empty or NA - not sent", barcode);
                return false;
            }

            // Respect bypass / offline mode
            try
            {
                if (Master.GlobalVariable.SFC_PDCA_Bypass)
                {
                    barcode__Recheck_result[cavityIndex] = "OFFLINE";
                    SFC_Cavity_sn_data_Sent[cavityIndex] = true;
                    Logger.WriteLogasTask(Logger.LogType.Info, "SfcClient", "SendBarcodeToSfcAsync", "SFC_PDCA_Bypass enabled - marking OFFLINE", barcode);
                    return true;
                }
            }
            catch (Exception)
            {
                // If GlobalVariable not available for some reason, proceed with normal flow.
            }

            int attempt = 0;
            int maxAttempts = Math.Max(1, retries + 1);
            int backoffMs = 250; // base backoff

            for (attempt = 1; attempt <= maxAttempts; attempt++)
            {
                if (ct.IsCancellationRequested)
                {
                    Logger.WriteLog(Logger.LogType.Info, "SfcClient", "SendBarcodeToSfcAsync", "Cancellation requested before send", barcode);
                    barcode__Recheck_result[cavityIndex] = "NOK";
                    SFC_Cavity_sn_data_Sent[cavityIndex] = false;
                    return false;
                }

                Logger.WriteLog(Logger.LogType.Info, "SfcClient", "SendBarcodeToSfcAsync", $"Attempt {attempt}/{maxAttempts} sending barcode to SFC", barcode);

                // Store what is being sent to SFC (one-line CSV per send)
                try
                {
                    StoreSfcData(barcode);
                }
                catch (Exception ex)
                {
                    //Arulkumar Fixed random stoppage start
                    Logger.WriteLog(Logger.LogType.Error, "SfcClient", "SendBarcodeToSfcAsync", ex.Message, ex.ToString());
                    //Arulkumar Fixed random stoppage end
                }

                bool? sendResult = null;

                try
                {
                    // Run the send on a background thread and enforce timeout
                    var sendTask = Task.Run(() =>
                    {
                        try
                        {
                            // Prefer specialized SFC send API if available, otherwise use generic Send
                            var sfc = ObjectList.SFC;
                            if (sfc == null)
                                return false;

                            Type sfcType = sfc.GetType();
                            // also try to find a project-level SocketClient helper class (common in this codebase)
                            Type socketClientType = Type.GetType("G1_Testing.SocketClient") ?? Type.GetType("SocketClient");

                            // 1) Prefer static or instance Barcode_Data_Send_SFC if available (many SocketClient implementations expose this)
                            MethodInfo staticBarcode = sfcType.GetMethod("Barcode_Data_Send_SFC", BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
                            MethodInfo instBarcode = sfcType.GetMethod("Barcode_Data_Send_SFC", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
                            // fallback to SocketClient static method if present
                            if ((staticBarcode == null || staticBarcode.DeclaringType == null) && socketClientType != null)
                                staticBarcode = socketClientType.GetMethod("Barcode_Data_Send_SFC", BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);

                            if (staticBarcode != null || instBarcode != null)
                            {
                                object ret = null;
                                if (staticBarcode != null)
                                {
                                    ret = staticBarcode.Invoke(null, new object[] { barcode });
                                }
                                else
                                {
                                    ret = instBarcode.Invoke(sfc, new object[] { barcode });
                                }
                                if (ret is bool br) return br;
                                return ret != null;
                            }

                            // 1b) Some implementations provide Final_Data_Send_SFC (builds query and polls). Prefer if available.
                            MethodInfo finalStatic = sfcType.GetMethod("Final_Data_Send_SFC", BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
                            MethodInfo finalInst = sfcType.GetMethod("Final_Data_Send_SFC", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
                            if ((finalStatic == null || finalStatic.DeclaringType == null) && socketClientType != null)
                                finalStatic = socketClientType.GetMethod("Final_Data_Send_SFC", BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
                            if (finalStatic != null || finalInst != null)
                            {
                                bool res = false;
                                if (finalStatic != null)
                                {
                                    var r = finalStatic.Invoke(null, new object[] { barcode });
                                    if (r is bool b) res = b;
                                    else res = r != null;
                                }
                                else
                                {
                                    var r = finalInst.Invoke(sfc, new object[] { barcode });
                                    if (r is bool b) res = b; else res = r != null;
                                }
                                return res;
                            }

                            // 2) Try TCP_Senddata_SFC + polling V_ReceiveSFCData2 pattern (as in user's snippet)
                            var tcpMethod = sfcType.GetMethod("TCP_Senddata_SFC", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
                            // fallback to static TCP_Senddata_SFC on SocketClient
                            if (tcpMethod == null && socketClientType != null)
                                tcpMethod = socketClientType.GetMethod("TCP_Senddata_SFC", BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
                            if (tcpMethod != null)
                            {
                                // try calling with full query string; many implementations expect that
                                string querysend = "sfc_post@c=ADD_RECORD&product=V53&test_station_name=AE-1&station_id=TEHR_B01-GFPD-03_1_AE-1&mac_address=10:dd:b1:e4:45:a3&sw_version=TEAL_BOT-GRT_v1.0&audit_mode=0&start_time=" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "&stop_time=" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "&sn=" + barcode;
                                try
                                {
                                    // If tcpMethod is static on SocketClient, invoke with null target
                                    if (tcpMethod.IsStatic)
                                        tcpMethod.Invoke(null, new object[] { querysend });
                                    else
                                        tcpMethod.Invoke(sfc, new object[] { querysend });
                                }
                                catch
                                {
                                    try
                                    {
                                        if (tcpMethod.IsStatic)
                                            tcpMethod.Invoke(null, new object[] { barcode });
                                        else
                                            tcpMethod.Invoke(sfc, new object[] { barcode });
                                    }
                                    catch (Exception ex)
                                    {
                                        //Arulkumar Fixed random stoppage start
                                        Logger.WriteLog(Logger.LogType.Error, "SfcClient", "SendBarcodeToSfcAsync", ex.Message, ex.ToString());
                                        //Arulkumar Fixed random stoppage end
                                    }
                                }

                                // After sending, poll for response
                                string resp = string.Empty;
                                FieldInfo staticField = sfcType.GetField("V_ReceiveSFCData2", BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
                                PropertyInfo staticProp = sfcType.GetProperty("V_ReceiveSFCData2", BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
                                FieldInfo instField = sfcType.GetField("V_ReceiveSFCData2", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
                                PropertyInfo instProp = sfcType.GetProperty("V_ReceiveSFCData2", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
                                // fallback to SocketClient static field/property if not found on instance type
                                if (staticField == null && socketClientType != null)
                                    staticField = socketClientType.GetField("V_ReceiveSFCData2", BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
                                if (staticProp == null && socketClientType != null)
                                    staticProp = socketClientType.GetProperty("V_ReceiveSFCData2", BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
                                if (instField == null && socketClientType != null)
                                    instField = socketClientType.GetField("V_ReceiveSFCData2", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
                                if (instProp == null && socketClientType != null)
                                    instProp = socketClientType.GetProperty("V_ReceiveSFCData2", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);

                                int waited = 0;
                                int pollInterval = 100;
                                while (waited < timeoutMs)
                                {
                                    //Arulkumar Fixed random stoppage start
                                    if (ct.IsCancellationRequested)
                                    {
                                        return false;
                                    }
                                    //Arulkumar Fixed random stoppage end
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
                                    else if (instField != null)
                                    {
                                        var val = instField.GetValue(sfc);
                                        resp = val?.ToString() ?? string.Empty;
                                    }
                                    else if (instProp != null)
                                    {
                                        var val = instProp.GetValue(sfc);
                                        resp = val?.ToString() ?? string.Empty;
                                    }
                                    else
                                    {
                                        // fallback: try calling Receive() if available
                                        var recv = sfcType.GetMethod("Receive", new Type[] { typeof(int) });
                                        if (recv != null)
                                        {
                                            try
                                            {
                                                var r = recv.Invoke(sfc, new object[] { 100 });
                                                resp = r?.ToString() ?? string.Empty;
                                            }
                                            catch (Exception ex)
                                            {
                                                //Arulkumar Fixed random stoppage start
                                                Logger.WriteLog(Logger.LogType.Error, "SfcClient", "SendBarcodeToSfcAsync", ex.Message, ex.ToString());
                                                //Arulkumar Fixed random stoppage end
                                            }
                                        }
                                    }

                                    if (!string.IsNullOrEmpty(resp))
                                    {
                                        if (resp.Contains("SFC_OK"))
                                        {
                                            // log via X3Y3 if available
                                            var logMeth = GetX3LogMethod();
                                            //Arulkumar Fixed random stoppage start
                                            try { logMeth?.Invoke(null, new object[] { resp }); } catch (Exception logEx) { Logger.WriteLog(Logger.LogType.Error, "SfcClient", "SendBarcodeToSfcAsync.LogResponse", logEx.Message, logEx.ToString()); }
                                            //Arulkumar Fixed random stoppage end
                                            return true;
                                        }
                                        if (resp.Contains("bad@{") || resp.Contains("err@{"))
                                        {
                                            var logMeth = GetX3LogMethod();
                                            //Arulkumar Fixed random stoppage start
                                            try { logMeth?.Invoke(null, new object[] { resp }); } catch (Exception logEx) { Logger.WriteLog(Logger.LogType.Error, "SfcClient", "SendBarcodeToSfcAsync.LogErrorResponse", logEx.Message, logEx.ToString()); }
                                            //Arulkumar Fixed random stoppage end
                                            return false;
                                        }
                                    }

                                    Thread.Sleep(pollInterval);
                                    waited += pollInterval;
                                }

                                // timed out
                                return false;
                            }

                            // 3) Fallback to generic Send/Receive
                            var sendMeth = sfcType.GetMethod("Send", new Type[] { typeof(string) });
                            var recvMeth = sfcType.GetMethod("Receive", new Type[] { typeof(int) });

                            if (sendMeth != null)
                            {
                                var ret = sendMeth.Invoke(sfc, new object[] { barcode });
                                bool sendOk = false;
                                if (ret is bool b2) sendOk = b2; else sendOk = ret != null;

                                if (sendOk && recvMeth != null)
                                {
                                    try
                                    {
                                        var r = recvMeth.Invoke(sfc, new object[] { timeoutMs + 100 });
                                        if (r != null && r.ToString().Contains("SFC_OK"))
                                            return true;
                                        if (r != null && (r.ToString().Contains("bad@{") || r.ToString().Contains("err@{")))
                                            return false;
                                    }
                                    catch (Exception ex)
                                    {
                                        //Arulkumar Fixed random stoppage start
                                        Logger.WriteLog(Logger.LogType.Error, "SfcClient", "SendBarcodeToSfcAsync", ex.Message, ex.ToString());
                                        //Arulkumar Fixed random stoppage end
                                    }
                                }

                                return sendOk;
                            }

                            // Nothing to call
                            return false;
                        }
                        catch (Exception ex)
                        {
                            Task.Run(() => Logger.WriteLog(Logger.LogType.Error, "SfcClient", "SendBarcode (invoked)", ex.Message, ex.ToString()));
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
                        // timed out
                        sendResult = false;
                        Logger.WriteLogasTask(Logger.LogType.Error, "SfcClient", "SendBarcodeToSfcAsync", $"Attempt {attempt} timed out after {timeoutMs}ms", barcode);
                    }
                }
                catch (OperationCanceledException)
                {
                    Logger.WriteLog(Logger.LogType.Info, "SfcClient", "SendBarcodeToSfcAsync", "Operation cancelled during send", barcode);
                    sendResult = false;
                }
                catch (Exception ex)
                {
                    Logger.WriteLog(Logger.LogType.Error, "SfcClient", "SendBarcodeToSfcAsync", ex.Message, ex.ToString());
                    sendResult = false;
                }

                if (sendResult == true)
                {
                    barcode__Recheck_result[cavityIndex] = "OK";
                    SFC_Cavity_sn_data_Sent[cavityIndex] = true;
                    Logger.WriteLog(Logger.LogType.Info, "SfcClient", "SendBarcodeToSfcAsync", $"Barcode sent successfully on attempt {attempt}", barcode);
                    return true;
                }

                // Not successful - if we have more attempts, back off and retry
                if (attempt < maxAttempts)
                {
                    int wait = backoffMs * attempt; // linear backoff
                    Logger.WriteLog(Logger.LogType.Info, "SfcClient", "SendBarcodeToSfcAsync", $"Will retry after {wait}ms", barcode);
                    //Arulkumar Fixed random stoppage start
                    try { await Task.Delay(wait, ct).ConfigureAwait(false); } catch (OperationCanceledException) { }
                    //Arulkumar Fixed random stoppage end
                }
            }

            // All attempts failed
            barcode__Recheck_result[cavityIndex] = "NOK";
            SFC_Cavity_sn_data_Sent[cavityIndex] = false;
            Logger.WriteLog(Logger.LogType.Error, "SfcClient", "SendBarcodeToSfcAsync", $"Failed to send barcode after {retries + 1} attempts", barcode);
            return false;
        }
        catch (Exception ex)
        {
            Logger.WriteLog(Logger.LogType.Error, "SfcClient", "SendBarcodeToSfcAsync", ex.Message, ex.ToString());
            try
            {
                barcode__Recheck_result[cavityIndex] = "NOK";
                SFC_Cavity_sn_data_Sent[cavityIndex] = false;
            }
            catch (Exception innerEx)
            {
                //Arulkumar Fixed random stoppage start
                Logger.WriteLog(Logger.LogType.Error, "SfcClient", "SendBarcodeToSfcAsync", innerEx.Message, innerEx.ToString());
                //Arulkumar Fixed random stoppage end
            }
            return false;
        }
    }

    private static MethodInfo GetX3LogMethod()
    {
        return GetX3LogMethod(get);
    }

    private static MethodInfo GetX3LogMethod(object get)
    {
    get:

        {
            // try to find X3Y3.SFC_Station3_SFC_Log static method if available anywhere
            try
            {
                var type = Type.GetType("X3Y3");
                if (type != null)
                {
                    var m = type.GetMethod("SFC_Station3_SFC_Log", BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
                    return m;
                }
            }
            catch (Exception ex)
            {
                //Arulkumar Fixed random stoppage start
                Logger.WriteLog(Logger.LogType.Error, "SfcClient", "GetX3LogMethod", ex.Message, ex.ToString());
                //Arulkumar Fixed random stoppage end
            }
            return null;
        }
    }


    public static void commonLOG(string Command)
    {
        //Arulkumar Fixed random stoppage start
        //Reason:
        //Root Cause: Concurrent access to the same SFC CSV file caused file-in-use exceptions.
        //Fix: Serialized the existing file-write operation and ensured the existing file handle is released correctly.
        lock (sfcFileWriteLock)
        {
            try
            {
                string baseDir = @"D:\TEAL\Common_Log_Data";
                if (!Directory.Exists(baseDir)) Directory.CreateDirectory(baseDir);

                // string ts = DateTime.Now.ToString("dd-MM-yyyy_HH-mm");
                string ts = DateTime.Now.ToString("dd-MM-yyyy-" + GlobalVariable.CurrentShift);
                string filename = Path.Combine(baseDir, ts + ".csv");
                bool exists = File.Exists(filename);

                var sb = new StringBuilder();
                if (!exists)
                {
                    sb.AppendLine("S.No,DateTime,Commands");
                }

                // S.No: use file line count + 1 (cheap method)
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
                    Logger.WriteLog(Logger.LogType.Error, "SfcClient", "StoreSfcData", ex.Message, ex.ToString());
                    //Arulkumar Fixed random stoppage end
                }
                string line = "";
                if (Command != null)
                {
                    line = string.Format("{0},{1},\"{2}\"", sno, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), Command.Replace('"', '\'').Replace('\r', ' ').Replace('\n', ' '));

                }
                sb.AppendLine(line);

                File.AppendAllText(filename, sb.ToString(), Encoding.UTF8);
            }
            catch (Exception ex)
            {
                //Arulkumar Fixed random stoppage start
                Logger.WriteLog(Logger.LogType.Error, "SfcClient", "StoreSfcData", ex.Message, ex.ToString());
                //Arulkumar Fixed random stoppage end
            }
        }
        //Arulkumar Fixed random stoppage end
    }

    // Store SFC send data into daily CSV file at D:\TEAL\SFCC_Data\DD-MM-YYYY_HH-MM.csv
    public static void StoreSfcData(string sfcData)
    {
        //Arulkumar Fixed random stoppage start
        //Reason:
        //Root Cause: Concurrent access to the same SFC CSV file caused file-in-use exceptions.
        //Fix: Serialized the existing file-write operation and ensured the existing file handle is released correctly.
        lock (sfcFileWriteLock)
        {
            try
            {
                string baseDir = @"D:\TEAL\SFC_Data_Log";
                if (!Directory.Exists(baseDir)) Directory.CreateDirectory(baseDir);

                // string ts = DateTime.Now.ToString("dd-MM-yyyy_HH-mm");
                string ts = DateTime.Now.ToString("dd-MM-yyyy-" + GlobalVariable.CurrentShift);
                string filename = Path.Combine(baseDir, ts + ".txt");
                bool exists = File.Exists(filename);

                var sb = new StringBuilder();
                if (!exists)
                {
                    sb.AppendLine("S.No,DateTime,SFC_Data");
                }

                // S.No: use file line count + 1 (cheap method)
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
                    Logger.WriteLog(Logger.LogType.Error, "SfcClient", "StoreSfcData", ex.Message, ex.ToString());
                    //Arulkumar Fixed random stoppage end
                }
                string line = "";
                if (sfcData != null)
                {
                    line = string.Format("{0},{1},\"{2}\"", sno, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), sfcData.Replace('"', '\'').Replace('\r', ' ').Replace('\n', ' '));

                }
                sb.AppendLine(line);

                File.AppendAllText(filename, sb.ToString(), Encoding.UTF8);
            }
            catch (Exception ex)
            {
                //Arulkumar Fixed random stoppage start
                Logger.WriteLog(Logger.LogType.Error, "SfcClient", "StoreSfcData", ex.Message, ex.ToString());
                //Arulkumar Fixed random stoppage end
            }
        }
        //Arulkumar Fixed random stoppage end
    }

}
