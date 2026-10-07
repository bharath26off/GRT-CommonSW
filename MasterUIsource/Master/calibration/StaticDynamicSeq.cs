using ExceptionLib;
using GRT_BG1.Data;
using GRT_BG1.Function.Calibration;
using Program;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using static DIO.DIDO;

namespace Master.GRT.Function.DryRun
{
    public static class StaticDynamicSeq
    {
        private static readonly object _csvLock = new object();
        private static readonly VisionSystem _camera = new VisionSystem();

        // allow override of csv path from UI
        public static string CsvPath { get; set; } = Path.Combine(Environment.CurrentDirectory, "Data", "CCD_Triggers.csv");

        // map UI CCD number to hardware CCD number
        private static int MapUserCCD(int uiCcd)
        {
            // mapping requested: ccd1 => ccd4, ccd2 => ccd1, ccd3 => ccd2, ccd4 => ccd3
            switch (uiCcd)
            {
                case 1:
                case 2:
                case 3:
                case 4:
                default: return uiCcd;
            }
        }

        // Runs sequence. progressCallback reports the current running count (1..count).
        public static async Task RunSequenceAsync(
            bool isStatic,
            int count,
            double staticX,
            double staticY,
            double dynX1,
            double dynY1,
            double dynX2,
            double dynY2,
             double dynZ,// AK
            double dynR, //AK
            int speed,
            List<int> selectedCCDs,
            Action<int> progressCallback = null,
            CancellationToken ct = default)
        {
            if (count <= 0 || selectedCCDs == null || selectedCCDs.Count == 0)
                return;

            await Logger.WriteLogasTask(Logger.LogType.Running, "StaticDynamicSeq", "RunSequenceAsync", "Sequence started. Mode=" + (isStatic ? "Static" : "Dynamic") + ", Count=" + count + ", CCDs=" + string.Join(",", selectedCCDs.Select(i => i.ToString())), "");

            // Helper to move X1/Y1
            async Task MoveXY1(double x, double y)
            {
                try
                {
                    // Start X1 and Y1 moves in parallel
                    var moveTasks = new List<Task>();
                    if (ObjectList.Servo_X1 != null)
                        moveTasks.Add(Task.Run(() => ObjectList.Servo_X1?.Move_Abs(x, speed, GlobalVariable.g_lstAxisConfig[(int)EAxis.Servo_X1].Acc, GlobalVariable.g_lstAxisConfig[(int)EAxis.Servo_X1].DeAcc, 5000)));
                    if (ObjectList.Servo_Y1 != null)
                        moveTasks.Add(Task.Run(() => ObjectList.Servo_Y1?.Move_Abs(y, speed, GlobalVariable.g_lstAxisConfig[(int)EAxis.Servo_Y1].Acc, GlobalVariable.g_lstAxisConfig[(int)EAxis.Servo_Y1].DeAcc, 5000)));

                    Task Move_R = Task.Run(() => ObjectList.Servo_R1?.Move_Abs(dynR, speed, GlobalVariable.g_lstAxisConfig[(int)EAxis.Servo_R1].Acc, GlobalVariable.g_lstAxisConfig[(int)EAxis.Servo_R1].DeAcc, 15000)); // AK
                    Task Move_Z = Task.Run(() => ObjectList.Servo_Z1?.Move_Abs(dynZ, speed, GlobalVariable.g_lstAxisConfig[(int)EAxis.Servo_Z1].Acc, GlobalVariable.g_lstAxisConfig[(int)EAxis.Servo_Z1].DeAcc, 5000)); // AK

                    await Task.WhenAll(Move_R, Move_Z);

                    if (moveTasks.Count > 0)
                        await Task.WhenAll(moveTasks);

                    // wait for motion complete by polling position in parallel
                    var waitTasks = new List<Task<bool>>();
                    if (ObjectList.Servo_X1 != null)
                        waitTasks.Add(WaitForAxisPositionAsync(ObjectList.Servo_X1, x, 5000, ct));
                    if (ObjectList.Servo_Y1 != null)
                        waitTasks.Add(WaitForAxisPositionAsync(ObjectList.Servo_Y1, y, 5000, ct));

                    bool ok = true;
                    if (waitTasks.Count > 0)
                    {
                        var results = await Task.WhenAll(waitTasks);
                        ok = results.All(r => r);
                    }

                    await Logger.WriteLogasTask(Logger.LogType.Running, "StaticDynamicSeq", "MoveXY1", "Moved X1 to " + x + " and Y1 to " + y + " (ok=" + ok + ")", "");
                }
                catch (Exception ex)
                {
                    await Logger.WriteLogasTask(Logger.LogType.Error, "StaticDynamicSeq", "MoveXY1", "Exception moving XY1", ex.ToString());
                }
            }

            // Helper to move X2/Y2
            async Task MoveXY2(double x, double y)
            {
                try
                {
                    // Start X2 and Y2 moves in parallel
                    var moveTasks = new List<Task>();
                    if (ObjectList.Servo_X2 != null)
                        moveTasks.Add(Task.Run(() => ObjectList.Servo_X2?.Move_Abs(x, speed, GlobalVariable.g_lstAxisConfig[(int)EAxis.Servo_X2].Acc, GlobalVariable.g_lstAxisConfig[(int)EAxis.Servo_X2].DeAcc, 5000)));
                    if (ObjectList.Servo_Y2 != null)
                        moveTasks.Add(Task.Run(() => ObjectList.Servo_Y2?.Move_Abs(y, speed, GlobalVariable.g_lstAxisConfig[(int)EAxis.Servo_Y2].Acc, GlobalVariable.g_lstAxisConfig[(int)EAxis.Servo_Y2].DeAcc, 5000)));

                    if (moveTasks.Count > 0)
                        await Task.WhenAll(moveTasks);

                    // wait for motion complete by polling position in parallel
                    var waitTasks = new List<Task<bool>>();
                    if (ObjectList.Servo_X2 != null)
                        waitTasks.Add(WaitForAxisPositionAsync(ObjectList.Servo_X2, x, 5000, ct));
                    if (ObjectList.Servo_Y2 != null)
                        waitTasks.Add(WaitForAxisPositionAsync(ObjectList.Servo_Y2, y, 5000, ct));

                    bool ok = true;
                    if (waitTasks.Count > 0)
                    {
                        var results = await Task.WhenAll(waitTasks);
                        ok = results.All(r => r);
                    }

                    await Logger.WriteLogasTask(Logger.LogType.Running, "StaticDynamicSeq", "MoveXY2", "Moved X2 to " + x + " and Y2 to " + y + " (ok=" + ok + ")", "");
                }
                catch (Exception ex)
                {
                    await Logger.WriteLogasTask(Logger.LogType.Error, "StaticDynamicSeq", "MoveXY2", "Exception moving XY2", ex.ToString());
                }
            }

            // determine mapped CCDs
            var mappedCCDs = selectedCCDs.Select(MapUserCCD).Distinct().ToList();

            bool usesXY1 = mappedCCDs.Any(c => c >= 1 && c <= 2);
            bool usesXY2 = mappedCCDs.Any(c => c == 3);

            if (isStatic)
            {
                // Ensure Z1/Z2 are safe; if not, perform homing first
                if (!NozzleSystem.nozzleZ1Z2Safe())
                {
                    await Logger.WriteLogasTask(Logger.LogType.Running, "StaticDynamicSeq", "RunSequenceAsync", "Z1/Z2 not in safe position - performing homing before static move", "");
                    // start homing for both nozzles
                    await Task.Run(() =>
                    {
                        //Arulkumar Fixed random stoppage start
                        try { NozzleSystem.Nozzle1Homing(); } catch (Exception ex) { Logger.WriteLog(Logger.LogType.Error, "StaticDynamicSeq", "RunSequenceAsync.Nozzle1Homing", ex.Message, ex.ToString()); }
                        try { NozzleSystem.Nozzle2Homing(); } catch (Exception ex) { Logger.WriteLog(Logger.LogType.Error, "StaticDynamicSeq", "RunSequenceAsync.Nozzle2Homing", ex.Message, ex.ToString()); }
                        //Arulkumar Fixed random stoppage end
                    });

                    // wait until safe or timeout
                    int waited = 0;
                    const int pollMs = 200;
                    const int timeoutMs = 15000;
                    while (waited < timeoutMs && !NozzleSystem.nozzleZ1Z2Safe())
                    {
                        if (ct.IsCancellationRequested) return;
                        await Task.Delay(pollMs, ct).ContinueWith(_ => { });
                        waited += pollMs;
                    }
                    if (!NozzleSystem.nozzleZ1Z2Safe())
                    {
                        await Logger.WriteLogasTask(Logger.LogType.Error, "StaticDynamicSeq", "RunSequenceAsync", "Z1/Z2 did not reach safe position after homing", "");
                        return;
                    }
                }

                if (ct.IsCancellationRequested) return;

                // Move XY1 and XY2 in parallel when both are needed
                var moveTasks = new List<Task>();
                if (usesXY1)
                    moveTasks.Add(MoveXY1(staticX, staticY));
                if (usesXY2)
                    moveTasks.Add(MoveXY2(staticX, staticY));

                //if (moveTasks.Count > 0)
                //    await Task.WhenAll(moveTasks);
                if (mappedCCDs[0] == 1)
                {
                    Task Move_R = Task.Run(() => ObjectList.Servo_R1?.Move_Abs(dynR, speed, GlobalVariable.g_lstAxisConfig[(int)EAxis.Servo_R1].Acc, GlobalVariable.g_lstAxisConfig[(int)EAxis.Servo_R1].DeAcc, 15000)); // AK
                    Task Move_Z = Task.Run(() => ObjectList.Servo_Z1?.Move_Abs(dynZ, speed, GlobalVariable.g_lstAxisConfig[(int)EAxis.Servo_Z1].Acc, GlobalVariable.g_lstAxisConfig[(int)EAxis.Servo_Z1].DeAcc, 5000)); // AK

                    await Task.WhenAll(Move_R, Move_Z);
                }

                for (int i = 0; i < count; i++)
                {
                    if (ct.IsCancellationRequested) break;

                    try
                    {
                        // Trigger and capture responses
                        await TriggerSelectedCCDsAsync(selectedCCDs, i + 1);
                        await Logger.WriteLogasTask(Logger.LogType.Running, "StaticDynamicSeq", "Trigger", "Triggered CCDs: " + string.Join(",", selectedCCDs.Select(n => n.ToString())) + " (cycle " + (i + 1) + ")", "");

                        progressCallback?.Invoke(i + 1);
                        await Task.Delay(100, ct).ContinueWith(_ => { });
                    }
                    catch (Exception ex)
                    {
                        await Logger.WriteLogasTask(Logger.LogType.Error, "StaticDynamicSeq", "RunSequenceAsync.StaticLoop", "Exception in static loop", ex.ToString());
                    }
                }

                // AK
                Position NozzleSafe = GlobalVariable.SafePosition;
                Task T1 = Task.Run(() => NozzleSystem.Nozzle1safe(NozzleSafe));
                Task T2 = Task.Run(() => NozzleSystem.Nozzle2safe(NozzleSafe));

                await Task.WhenAll(T1, T2);

                await Logger.WriteLogasTask(Logger.LogType.Running, "StaticDynamicSeq", "RunSequenceAsync", "Static sequence completed", "");
                return;
            }

            // ================= DYNAMIC MODE =================


            // Ensure starting at Dynamic Pos1 if needed
            // Ensure Z1/Z2 are safe for dynamic as well; if not perform homing
            if (!NozzleSystem.nozzleZ1Z2Safe())
            {
                await Logger.WriteLogasTask(Logger.LogType.Running, "StaticDynamicSeq", "RunSequenceAsync", "Z1/Z2 not in safe position - performing homing before dynamic move", "");
                await Task.Run(() =>
                {
                    //Arulkumar Fixed random stoppage start
                    try { NozzleSystem.Nozzle1Homing(); } catch (Exception ex) { Logger.WriteLog(Logger.LogType.Error, "StaticDynamicSeq", "RunSequenceAsync.Nozzle1Homing", ex.Message, ex.ToString()); }
                    try { NozzleSystem.Nozzle2Homing(); } catch (Exception ex) { Logger.WriteLog(Logger.LogType.Error, "StaticDynamicSeq", "RunSequenceAsync.Nozzle2Homing", ex.Message, ex.ToString()); }
                    //Arulkumar Fixed random stoppage end
                });

                int waited = 0;
                const int pollMs = 200;
                const int timeoutMs = 15000;
                while (waited < timeoutMs && !NozzleSystem.nozzleZ1Z2Safe())
                {
                    if (ct.IsCancellationRequested) return;
                    await Task.Delay(pollMs, ct).ContinueWith(_ => { });
                    waited += pollMs;
                }
                if (!NozzleSystem.nozzleZ1Z2Safe())
                {
                    await Logger.WriteLogasTask(Logger.LogType.Error, "StaticDynamicSeq", "RunSequenceAsync", "Z1/Z2 did not reach safe position after homing", "");
                    return;
                }
            }

            var initTasks = new List<Task>();
            if (usesXY1)
                initTasks.Add(MoveXY1(dynX1, dynY1));
            if (usesXY2)
                initTasks.Add(MoveXY2(dynX1, dynY1));

            if (initTasks.Count > 0)
            {
                if (ct.IsCancellationRequested) return;
                await Task.WhenAll(initTasks);
            }

            for (int i = 0; i < count; i++)
            {
                if (ct.IsCancellationRequested)
                    break;

                try
                {
                    // Move to Dynamic Pos2 (target)
                    var toTarget = new List<Task>();
                    if (usesXY1)
                        toTarget.Add(MoveXY1(dynX2, dynY2));
                    if (usesXY2)
                        toTarget.Add(MoveXY2(dynX2, dynY2));

                    if (toTarget.Count > 0)
                        await Task.WhenAll(toTarget);

                    // Trigger selected CCDs once per cycle (pass UI-selected list so mapping is applied inside)
                    await TriggerSelectedCCDsAsync(selectedCCDs, i + 1);

                    progressCallback?.Invoke(i + 1);

                    // small pause
                    await Task.Delay(100, ct).ContinueWith(_ => { });

                    // Move back to Dynamic Pos1
                    var toHome = new List<Task>();
                    if (usesXY1)
                        toHome.Add(MoveXY1(dynX1, dynY1));
                    if (usesXY2)
                        toHome.Add(MoveXY2(dynX1, dynY1));

                    if (toHome.Count > 0)
                        await Task.WhenAll(toHome);
                }
                catch (OperationCanceledException)
                {
                    break;
                }
                catch (Exception ex)
                {
                    await Logger.WriteLogasTask(Logger.LogType.Running, "StaticDynamicSeq", "RunSequenceAsync.DynamicLoop", "Exception in dynamic loop", "" + ex.ToString());
                }
            }

            await Logger.WriteLogasTask(Logger.LogType.Running, "StaticDynamicSeq", "RunSequenceAsync", "Dynamic sequence completed", "");
        }

        private static async Task TriggerSelectedCCDsAsync(List<int> ccds, int runningCount)
        {
            if (ccds == null || ccds.Count == 0)
                return;

            foreach (var uiC in ccds)
            {
                try
                {
                    int c = MapUserCCD(uiC); // mapped hardware CCD
                    // Log mapping for diagnosis
                    //Arulkumar Fixed random stoppage start
                    try { await Logger.WriteLogasTask(Logger.LogType.Running, "StaticDynamicSeq", "TriggerSelectedCCDsAsync", "UI CCD=" + uiC + " mapped to hardware CCD=" + c, ""); } catch (Exception logEx) { Logger.WriteLog(Logger.LogType.Error, "StaticDynamicSeq", "TriggerSelectedCCDsAsync.LogMapping", logEx.Message, logEx.ToString()); }
                    //Arulkumar Fixed random stoppage end

                    string resp = string.Empty;

                    switch (c)
                    {
                        case 1:
                            if (ObjectList.CCD2 != null)
                            {
                                try
                                {
                                    string dtm = DateTime.Now.ToString("yyyyMMddHHmmss");
                                    int cavityNo = 1;

                                    var tn1 = GlobalVariable.TrainNozzle1;
                                    var tn2 = GlobalVariable.TrainNozzle2;

                                    double posX = GantrySystem.getcurrentpos(ObjectList.Servo_X1);
                                    double posY = GantrySystem.getcurrentpos(ObjectList.Servo_Y1);
                                    double posR = 0;

                                    bool useNozzle1 = true;
                                    string cmd2Built;
                                    if (useNozzle1)
                                    {
                                        cmd2Built = string.Format("T1,S,1,3,1,{0},{1}_NA,{2},{3},{4},{5},{6},{7},{8},{9},{10}",
                                            cavityNo,
                                            dtm,
                                            tn1?.PositionX ?? 0,
                                            tn1?.PositionY ?? 0,
                                            tn1?.PositionR1 ?? 0,
                                            posX,
                                            posY,
                                            posR,
                                            0, 0, 0
                                            );
                                    }
                                    else
                                    {
                                        cmd2Built = string.Format("T1,S,1,3,2,{0},{1}_NA,{2},{3},{4},{5},{6},{7},{8},{9},{10}",
                                            cavityNo,
                                            dtm,
                                            tn2?.PositionX ?? 0,
                                            tn2?.PositionY ?? 0,
                                            tn2?.PositionR2 ?? 0,
                                            posX,
                                            posY,
                                            posR,
                                            0, 0, 0
                                            );
                                    }

                                    resp = await _camera.Trig_Camera(ObjectList.CCD2, cmd2Built);
                                    //Arulkumar Fixed random stoppage start
                                    try { await Logger.WriteLogasTask(Logger.LogType.Running, "StaticDynamicSeq", "TriggerSelectedCCDsAsync", "CCD2 response: " + resp, ""); } catch (Exception logEx) { Logger.WriteLog(Logger.LogType.Error, "StaticDynamicSeq", "TriggerSelectedCCDsAsync.CCD2Log", logEx.Message, logEx.ToString()); }
                                    //Arulkumar Fixed random stoppage end
                                }
                                catch (Exception ex)
                                {
                                    Logger.WriteLog(Logger.LogType.Error, "StaticDynamicSeq", "TriggerSelectedCCDsAsync", "Error trigging CCD2", ex.ToString());
                                }
                            }
                            break;

                        case 2:
                            if (ObjectList.CCD3 != null)
                            {
                                try
                                {
                                    // Use X2/Y2 for CCD3 as requested
                                    double xpos = GantrySystem.getcurrentpos(ObjectList.Servo_X2);
                                    double ypos = GantrySystem.getcurrentpos(ObjectList.Servo_Y2);
                                    string dtm = DateTime.Now.ToString("yyyyMMddHHmmss");
                                    int cavityNo = 1;
                                    string sn = "";

                                    string cmd3Built = string.Format("T2,S,1,3,1,{0},{1}_NA_NA{2},{3},{4},{5},{6},{7},0,0,0,1",
                                        cavityNo,
                                        dtm,
                                        sn,
                                        xpos,
                                        ypos,
                                        GlobalVariable.TrainNozzle1?.PositionR1 ?? 0,
                                        xpos,
                                        ypos);

                                    resp = await _camera.Trig_Camera(ObjectList.CCD3, cmd3Built);
                                    //Arulkumar Fixed random stoppage start
                                    try { await Logger.WriteLogasTask(Logger.LogType.Running, "StaticDynamicSeq", "TriggerSelectedCCDsAsync", "CCD3 response: " + resp, ""); } catch (Exception logEx) { Logger.WriteLog(Logger.LogType.Error, "StaticDynamicSeq", "TriggerSelectedCCDsAsync.CCD3Log", logEx.Message, logEx.ToString()); }
                                    //Arulkumar Fixed random stoppage end
                                }
                                catch (Exception ex)
                                {
                                    Logger.WriteLog(Logger.LogType.Error, "StaticDynamicSeq", "TriggerSelectedCCDsAsync", "Error trigging CCD3", ex.ToString());
                                }
                            }
                            break;

                        case 3:
                            if (ObjectList.CCD4 != null)
                            {
                                try
                                {
                                    string dtm = DateTime.Now.ToString("yyyyMMddHHmmss");
                                    int cavityNo = 1;
                                    string sn = "";

                                    string cmd4Built = string.Format("T2C,S,1,1,{0},{1}_NA{2},1",
                                        cavityNo,
                                        dtm,
                                        sn);

                                    resp = await _camera.Trig_Camera(ObjectList.CCD4, cmd4Built);
                                    //Arulkumar Fixed random stoppage start
                                    try { await Logger.WriteLogasTask(Logger.LogType.Running, "StaticDynamicSeq", "TriggerSelectedCCDsAsync", "CCD4 response: " + resp, ""); } catch (Exception logEx) { Logger.WriteLog(Logger.LogType.Error, "StaticDynamicSeq", "TriggerSelectedCCDsAsync.CCD4Log", logEx.Message, logEx.ToString()); }
                                    //Arulkumar Fixed random stoppage end
                                }
                                catch (Exception ex)
                                {
                                    Logger.WriteLog(Logger.LogType.Error, "StaticDynamicSeq", "TriggerSelectedCCDsAsync", "Error trigging CCD4", ex.ToString());
                                }
                            }
                            break;

                        case 4:
                            if (ObjectList.CCD1 != null)
                            {
                                try
                                {
                                    double xpos1 = GantrySystem.getcurrentpos(ObjectList.Servo_X1);
                                    double ypos1 = GantrySystem.getcurrentpos(ObjectList.Servo_Y1);
                                    string dtm = DateTime.Now.ToString("yyyyMMddHHmmss");
                                    var tn1 = GlobalVariable.TrainNozzle1;
                                    var tn2 = GlobalVariable.TrainNozzle2;
                                    string cmd1Built = string.Format("T3,2,T3_{0}_NA_NA,1,{1},{2},{3},2,{4},{5},{6}",
                                        dtm,
                                        tn1?.PositionX ?? 0,
                                        tn1?.PositionY ?? 0,
                                        tn1?.PositionR1 ?? 0,
                                        tn2?.PositionX ?? 0,
                                        tn2?.PositionY ?? 0,
                                        tn2?.PositionR2 ?? 0);

                                    resp = await _camera.Trig_Camera(ObjectList.CCD1, cmd1Built);
                                    //Arulkumar Fixed random stoppage start
                                    try { await Logger.WriteLogasTask(Logger.LogType.Running, "StaticDynamicSeq", "TriggerSelectedCCDsAsync", "CCD1 response: " + resp, ""); } catch (Exception logEx) { Logger.WriteLog(Logger.LogType.Error, "StaticDynamicSeq", "TriggerSelectedCCDsAsync.CCD1Log", logEx.Message, logEx.ToString()); }
                                    //Arulkumar Fixed random stoppage end
                                }
                                catch (Exception ex)
                                {
                                    Logger.WriteLog(Logger.LogType.Error, "StaticDynamicSeq", "TriggerSelectedCCDsAsync", "Error trigging CCD1", ex.ToString());
                                }
                            }
                            break;
                    }

                    // After triggering, capture CSV with optional response
                    //Arulkumar Fixed random stoppage start
                    try { await Logger.WriteLogasTask(Logger.LogType.Running, "StaticDynamicSeq", "TriggerSelectedCCDsAsync", "Capturing CSV for mapped CCD=" + c + " resp=" + (resp ?? "(null)"), ""); } catch (Exception logEx) { Logger.WriteLog(Logger.LogType.Error, "StaticDynamicSeq", "TriggerSelectedCCDsAsync.CaptureLog", logEx.Message, logEx.ToString()); }
                    //Arulkumar Fixed random stoppage end
                    CaptureCsvAfterTrigger(new List<int> { c }, runningCount, resp);
                }
                catch (Exception ex)
                {
                    Logger.WriteLog(Logger.LogType.Error, "StaticDynamicSeq", "TriggerSelectedCCDsAsync", "Error triggering CCD " + uiC, ex.ToString());
                }
            }
        }

        private static void CaptureCsvAfterTrigger(List<int> ccds, int runningCount, string cameraResponse = null)
        {
            try
            {
                if (ccds == null || ccds.Count == 0) return;

                // keep original CCD triggers csv
                string csvPath = CsvPath;
                var csvDir = Path.GetDirectoryName(csvPath);
                if (!string.IsNullOrEmpty(csvDir))
                {
                    try
                    {
                        Directory.CreateDirectory(csvDir);
                    }
                    catch (Exception ex)
                    {
                        Logger.WriteLog(Logger.LogType.Error, "StaticDynamicSeq", "CaptureCsvAfterTrigger", "Failed to create CSV directory: " + csvDir, ex.ToString());
                    }
                }

                // target directory requested by user (explicit root on D:)

                string targetDir = Path.Combine(@"D:\", "TEAL", "Static_Cali");
                try
                {
                    Directory.CreateDirectory(targetDir);
                }
                catch (Exception ex)
                {
                    Logger.WriteLog(Logger.LogType.Error, "StaticDynamicSeq", "CaptureCsvAfterTrigger", "Failed to create target dir on D:, falling back to LocalAppData", ex.ToString());
                    targetDir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "TEAL", "Static_Cali");
                    try
                    {
                        Directory.CreateDirectory(targetDir);
                    }
                    catch (Exception ex2)
                    {
                        Logger.WriteLog(Logger.LogType.Error, "StaticDynamicSeq", "CaptureCsvAfterTrigger", "Failed to create fallback target dir: " + targetDir, ex2.ToString());
                    }
                }

                // SINGLE file per day
                string dateStamp = DateTime.Now.ToString("yyyyMMdd");
                string outFile = Path.Combine(targetDir, dateStamp + "_StaticCali.csv");

                // write header only once
                if (!File.Exists(outFile))
                {
                    // Extended header: include optional parsed values for dual-CCD responses (ParsedX1..Angle2)
                    File.AppendAllText(
                        outFile,
                        "DateTime,RunCount,CCD,Xpos,Ypos,ParsedX,ParsedY,Angle,ParsedX1,ParsedY1,Angle1,ParsedX2,ParsedY2,Angle2,CameraStatus" +
                        Environment.NewLine);
                }

                foreach (var c in ccds)
                {
                    double xpos = 0, ypos = 0, zpos = 0;

                    // c is mapped hardware CCD number
                    if (c >= 1 && c <= 3)
                    {
                        // For mapped CCDs 1..3 use Servo_X1/Y1 except when c==3 (special: use X2/Y2 handled earlier)
                        if (c == 3)
                        {
                            xpos = GantrySystem.getcurrentpos(ObjectList.Servo_X2);
                            ypos = GantrySystem.getcurrentpos(ObjectList.Servo_Y2);
                            //Arulkumar Fixed random stoppage start
                            try { zpos = GantrySystem.getcurrentpos(ObjectList.Servo_Z2); } catch (Exception ex) { Logger.WriteLog(Logger.LogType.Error, "StaticDynamicSeq", "CaptureCsvAfterTrigger.Z2", ex.Message, ex.ToString()); }
                            //Arulkumar Fixed random stoppage end
                        }
                        else
                        {
                            xpos = GantrySystem.getcurrentpos(ObjectList.Servo_X1);
                            ypos = GantrySystem.getcurrentpos(ObjectList.Servo_Y1);
                            //Arulkumar Fixed random stoppage start
                            try { zpos = GantrySystem.getcurrentpos(ObjectList.Servo_Z1); } catch (Exception ex) { Logger.WriteLog(Logger.LogType.Error, "StaticDynamicSeq", "CaptureCsvAfterTrigger.Z1", ex.Message, ex.ToString()); }
                            //Arulkumar Fixed random stoppage end
                        }
                    }
                    else if (c == 4)
                    {
                        xpos = GantrySystem.getcurrentpos(ObjectList.Servo_X2);
                        ypos = GantrySystem.getcurrentpos(ObjectList.Servo_Y2);
                        //Arulkumar Fixed random stoppage start
                        try { zpos = GantrySystem.getcurrentpos(ObjectList.Servo_Z2); } catch (Exception ex) { Logger.WriteLog(Logger.LogType.Error, "StaticDynamicSeq", "CaptureCsvAfterTrigger.Z2_CCD4", ex.Message, ex.ToString()); }
                        //Arulkumar Fixed random stoppage end
                    }

                    // ---------------- ORIGINAL CSV (UNCHANGED) ----------------
                    string originalLine = string.Format(
                        "{0},{1},{2},{3},{4}",
                        DateTime.Now.ToString("s"),
                        c,
                        xpos,
                        ypos,
                        runningCount);

                    if (!string.IsNullOrEmpty(cameraResponse))
                    {
                        originalLine += ",\"" + cameraResponse.Replace("\"", "'") + "\"";
                    }

                    lock (_csvLock)
                    {
                        File.AppendAllText(csvPath, originalLine + Environment.NewLine);
                    }

                    // ---------------- PARSE CAMERA STATUS ----------------
                    string cameraStatus = "FAILED";

                    if (!string.IsNullOrEmpty(cameraResponse))
                    {
                        try
                        {
                            var lines = cameraResponse
                                .Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);

                            if (lines.Length > 0)
                            {
                                var parts = lines[0].Split(',');
                                if (parts.Length >= 3)
                                {
                                    cameraStatus = parts[2].Trim().ToUpper();
                                    if (cameraStatus != "OK")
                                        cameraStatus = "NOT OK";
                                }
                            }
                        }
                        //Arulkumar Fixed random stoppage start
                        catch (Exception parseEx)
                        {
                            Logger.WriteLog(Logger.LogType.Error, "StaticDynamicSeq", "CaptureCsvAfterTrigger.ParseCameraStatus", parseEx.Message, parseEx.ToString());
                            cameraStatus = "FAILED";
                        }
                        //Arulkumar Fixed random stoppage end
                    }

                    // ---------------- PARSE X / Y / ANGLE ----------------
                    string parsedX = string.Empty;
                    string parsedY = string.Empty;
                    string parsedAngle = string.Empty;

                    // for CCD4 we may have two parsed results (nozzle1 and nozzle2). Prepare variables
                    string parsedX1 = string.Empty, parsedY1 = string.Empty, parsedA1 = string.Empty;
                    string parsedX2 = string.Empty, parsedY2 = string.Empty, parsedA2 = string.Empty;

                    if (!string.IsNullOrEmpty(cameraResponse))
                    {
                        try
                        {
                            var lines = cameraResponse
                                .Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);

                            // Try original style parse first
                            foreach (var l in lines)
                            {
                                int lastComma = l.LastIndexOf(',');
                                string afterComma = lastComma >= 0 ? l.Substring(lastComma + 1).Trim() : l;

                                var parts = afterComma.Split('_');
                                if (parts.Length >= 3)
                                {
                                    parsedX = parts[0];
                                    parsedY = parts[1];
                                    parsedAngle = parts[2];
                                    break;
                                }
                            }

                            // We want the three values at indexes 3,4,5.
                            if (string.IsNullOrEmpty(parsedX))
                            {
                                try
                                {
                                    var firstLine = lines.FirstOrDefault();
                                    if (!string.IsNullOrEmpty(firstLine))
                                    {
                                        var csvParts = firstLine.Split(',');
                                        if (csvParts.Length >= 6 && c != 4)
                                        {
                                            string fx = csvParts[3].Trim();
                                            string fy = csvParts[4].Trim();
                                            string fa = csvParts[5].Trim();
                                            double tmp;
                                            if (double.TryParse(fx, System.Globalization.NumberStyles.Float, System.Globalization.CultureInfo.InvariantCulture, out tmp)
                                                && double.TryParse(fy, System.Globalization.NumberStyles.Float, System.Globalization.CultureInfo.InvariantCulture, out tmp)
                                                && double.TryParse(fa, System.Globalization.NumberStyles.Float, System.Globalization.CultureInfo.InvariantCulture, out tmp))
                                            {
                                                parsedX = fx;
                                                parsedY = fy;
                                                parsedAngle = fa;
                                            }
                                        }
                                    }
                                }
                                //Arulkumar Fixed random stoppage start
                                catch (Exception parseEx)
                                {
                                    Logger.WriteLog(Logger.LogType.Error, "StaticDynamicSeq", "CaptureCsvAfterTrigger.ParseCsvParts", parseEx.Message, parseEx.ToString());
                                }
                                //Arulkumar Fixed random stoppage end
                            }

                            // for single-result cameras (not the dual result camera mapped as c==4).
                            if (string.IsNullOrEmpty(parsedX))
                            {
                                try
                                {
                                    if (c != 4)
                                    {
                                        var numMatches = System.Text.RegularExpressions.Regex.Matches(cameraResponse, "-?\\d+\\.?\\d*");
                                        if (numMatches.Count >= 3)
                                        {
                                            //int start = numMatches.Count - 3; // AK
                                            int start = numMatches.Count - 6;  // AK
                                            parsedX = numMatches[start + 0].Value;
                                            parsedY = numMatches[start + 1].Value;
                                            parsedAngle = numMatches[start + 2].Value;
                                        }
                                    }
                                }
                                //Arulkumar Fixed random stoppage start
                                catch (Exception parseEx)
                                {
                                    Logger.WriteLog(Logger.LogType.Error, "StaticDynamicSeq", "CaptureCsvAfterTrigger.ParseCsvParts", parseEx.Message, parseEx.ToString());
                                }
                                //Arulkumar Fixed random stoppage end
                            }

                            // Use a local 'mappedC' variable captured from outer scope via closure
                        }
                        //Arulkumar Fixed random stoppage start
                        catch (Exception parseEx)
                        {
                            Logger.WriteLog(Logger.LogType.Error, "StaticDynamicSeq", "CaptureCsvAfterTrigger.ParseResponse", parseEx.Message, parseEx.ToString());
                        }
                        //Arulkumar Fixed random stoppage end
                    }

                    // perform dual-value extraction only for mapped CCD == 3 (the camera object CCD4 used in switch case 3)
                    try
                    {
                        // dual-result cameras are produced by the CCD4 trigger (mapped c == 4).
                        // Keep CCD3 behavior as single-result (ParsedX/ParsedY/Angle) only.
                        if (c == 4 && !string.IsNullOrEmpty(cameraResponse))
                        {
                            var numMatches = System.Text.RegularExpressions.Regex.Matches(cameraResponse, "-?\\d+\\.?\\d*");
                            if (numMatches.Count >= 6)
                            {
                                int start = numMatches.Count - 6;
                                parsedX1 = numMatches[start + 0].Value;
                                parsedY1 = numMatches[start + 1].Value;
                                parsedA1 = numMatches[start + 2].Value;
                                parsedX2 = numMatches[start + 3].Value;
                                parsedY2 = numMatches[start + 4].Value;
                                parsedA2 = numMatches[start + 5].Value;

                                // if original single parse was empty, fill from first group
                                if (string.IsNullOrEmpty(parsedX))
                                {
                                    parsedX = parsedX1;
                                    parsedY = parsedY1;
                                    parsedAngle = parsedA1;
                                }
                            }
                        }
                    }
                    //Arulkumar Fixed random stoppage start
                    catch (Exception parseEx)
                    {
                        Logger.WriteLog(Logger.LogType.Error, "StaticDynamicSeq", "CaptureCsvAfterTrigger.ParseDualResult", parseEx.Message, parseEx.ToString());
                    }
                    //Arulkumar Fixed random stoppage end

                    // ---------------- STATIC CALI CSV ----------------
                    // include parsedX1..parsedA2 (may be empty for other CCDs)
                    // For the dual-result camera (mapped c==4) prefer the first parsed group as the primary ParsedX/Y/Angle
                    if (c == 4)
                    {
                        if (!string.IsNullOrEmpty(parsedX1))
                        {
                            parsedX = parsedX1;
                            parsedY = parsedY1;
                            parsedAngle = parsedA1;
                        }
                    }

                    // User requested: do not save primary ParsedX/ParsedY/ParsedAngle for mapped CCD==4.
                    // Keep parsedX1..parsedA2 if needed, but clear primary fields for CCD4 so CSV shows them only for CCD1-3.
                    if (c == 4)
                    {
                        parsedX = string.Empty;
                        parsedY = string.Empty;
                        parsedAngle = string.Empty;
                    }

                    // ---------------- STATIC CALI CSV ----------------
                    // include parsedX1..parsedA2 (may be empty for other CCDs)
                    string outLine = string.Format(
                    "{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13},{14}",
                    DateTime.Now.ToString("s"),  // DateTime
                    runningCount,                // RunCount
                    c,                           // CCD (mapped hardware number)
                    xpos,                        // Xpos
                    ypos,                        // Ypos
                    parsedX,                     // ParsedX
                    parsedY,                     // ParsedY
                    parsedAngle,                 // Angle
                    parsedX1,
                    parsedY1,
                    parsedA1,
                    parsedX2,
                    parsedY2,
                    parsedA2,
                    cameraStatus);

                    lock (_csvLock)
                    {
                        File.AppendAllText(outFile, outLine + Environment.NewLine);
                    }

                    // If this mapped CCD is 3, also save to Dynamic_Data daily file
                    try
                    {
                        if (c == 3 || c == 1 || c == 2 || c == 4)
                        {
                            // Save dynamic calibration data to D:\TEAL\Dynamic_Cali
                            if (GlobalVariable.DynamicMode_Cal)
                            {
                                string dynDir = Path.Combine(@"D:\", "TEAL", "Dynamic_Cali");
                                try
                                {
                                    Directory.CreateDirectory(dynDir);
                                }
                                catch (Exception ex)
                                {
                                    Logger.WriteLog(Logger.LogType.Error, "StaticDynamicSeq", "CaptureCsvAfterTrigger", "Failed to create Dynamic_Cali dir on D:, falling back to LocalAppData", ex.ToString());
                                    dynDir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "TEAL", "Dynamic_Cali");
                                    try
                                    {
                                        Directory.CreateDirectory(dynDir);
                                    }
                                    catch (Exception ex2)
                                    {
                                        Logger.WriteLog(Logger.LogType.Error, "StaticDynamicSeq", "CaptureCsvAfterTrigger", "Failed to create fallback Dynamic_Cali dir: " + dynDir, ex2.ToString());
                                    }
                                }

                                string dynFile = Path.Combine(dynDir, DateTime.Now.ToString("yyyyMMdd") + "_DynamicCali.csv");
                                // Use same header/format as Static CSV and append the same outLine
                                if (!File.Exists(dynFile))
                                {
                                    File.AppendAllText(
                                        dynFile,
                                        "DateTime,RunCount,CCD,Xpos,Ypos,ParsedX,ParsedY,Angle,ParsedX1,ParsedY1,Angle1,ParsedX2,ParsedY2,Angle2,CameraStatus" + Environment.NewLine);
                                }

                                lock (_csvLock)
                                {
                                    File.AppendAllText(dynFile, outLine + Environment.NewLine);
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Logger.WriteLog(Logger.LogType.Error, "StaticDynamicSeq", "CaptureCsvAfterTrigger", "Failed write dynamic file", ex.ToString());
                    }
                }

                Logger.WriteLog(
                    Logger.LogType.Running,
                    "StaticDynamicSeq",
                    "CaptureCsvAfterTrigger",
                    "Saved StaticCali CSV",
                    "");
            }
            catch (Exception ex)
            {
                Logger.WriteLog(
                    Logger.LogType.Error,
                    "StaticDynamicSeq",
                    "CaptureCsvAfterTrigger",
                    "Failed to save CSV",
                    ex.ToString()
                );
            }
        }

        private static async Task<bool> WaitForAxisPositionAsync(Advantech_PCIE axisObj, double target, int timeoutMs, CancellationToken ct)
        {
            try
            {
                int waited = 0;
                const int pollMs = 50;
                while (waited < timeoutMs)
                {
                    if (ct.IsCancellationRequested) return false;
                    double current = GantrySystem.getcurrentpos(axisObj);
                    if (Math.Abs(current - target) <= 0.02) // 20 micron tolerance
                        return true;
                    await Task.Delay(pollMs, ct).ContinueWith(_ => { });
                    waited += pollMs;
                }
                return false;
            }
            catch (Exception ex)
            {
                Logger.WriteLog(Logger.LogType.Error, "StaticDynamicSeq", "WaitForAxisPositionAsync", "Exception waiting for axis position", ex.ToString());
                return false;
            }
        }
    }
}
