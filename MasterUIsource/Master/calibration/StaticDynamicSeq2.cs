using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Master;
using System.Threading;
using static DIO.DIDO;
using System.IO;
using ExceptionLib;
using GRT_BG1.Function.Calibration;
using Advantech;
using Advantech.Motion;
using DynamicCylinders;
using DynamicVacuums;
using ExceptionLib;
using GRT_BG1.Data;
using GRT_BG1.Function.Calibration;
using GRT_BG1.Function.Classes;
using GRT_BG1.Function.Interface;
using GRT_BG1.GlobalVar;
using GRT_BG1_V54.Function.CommonClass;
using Master;
using System.Collections;
using System.Data;
using System.Diagnostics;
using Program;

namespace Master.GRT.Function.DryRun
{
    public static class StaticDynamicSeq
    {
        private static readonly object _csvLock = new object();
        private static readonly VisionSystem _camera = new VisionSystem();

        // allow override of csv path from UI
        public static string CsvPath { get; set; } = Path.Combine(Environment.CurrentDirectory, "Data", "CCD_Triggers.csv");

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
                    await Task.Run(() => ObjectList.Servo_X1?.Move_Abs(x, speed, GlobalVariable.g_lstAxisConfig[(int)EAxis.Servo_X1].Acc, GlobalVariable.g_lstAxisConfig[(int)EAxis.Servo_X1].DeAcc, 5000));
                    await Task.Run(() => ObjectList.Servo_Y1?.Move_Abs(y, speed, GlobalVariable.g_lstAxisConfig[(int)EAxis.Servo_Y1].Acc, GlobalVariable.g_lstAxisConfig[(int)EAxis.Servo_Y1].DeAcc, 5000));

                    // wait for motion complete by polling position
                    bool ok = await WaitForAxisPositionAsync(ObjectList.Servo_X1, x, 5000, ct);
                    bool ok2 = await WaitForAxisPositionAsync(ObjectList.Servo_Y1, y, 5000, ct);

                    await Logger.WriteLogasTask(Logger.LogType.Running, "StaticDynamicSeq", "MoveXY1", "Moved X1 to " + x + " (ok=" + ok + "), Y1 to " + y + " (ok=" + ok2 + ")", "");
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
                    await Task.Run(() => ObjectList.Servo_X2?.Move_Abs(x, speed, GlobalVariable.g_lstAxisConfig[(int)EAxis.Servo_X2].Acc, GlobalVariable.g_lstAxisConfig[(int)EAxis.Servo_X2].DeAcc, 5000));
                    await Task.Run(() => ObjectList.Servo_Y2?.Move_Abs(y, speed, GlobalVariable.g_lstAxisConfig[(int)EAxis.Servo_Y2].Acc, GlobalVariable.g_lstAxisConfig[(int)EAxis.Servo_Y2].DeAcc, 5000));

                    bool ok = await WaitForAxisPositionAsync(ObjectList.Servo_X2, x, 5000, ct);
                    bool ok2 = await WaitForAxisPositionAsync(ObjectList.Servo_Y2, y, 5000, ct);

                    await Logger.WriteLogasTask(Logger.LogType.Running, "StaticDynamicSeq", "MoveXY2", "Moved X2 to " + x + " (ok=" + ok + "), Y2 to " + y + " (ok=" + ok2 + ")", "");
                }
                catch (Exception ex)
                {
                    await Logger.WriteLogasTask(Logger.LogType.Error, "StaticDynamicSeq", "MoveXY2", "Exception moving XY2", ex.ToString());
                }
            }

            bool usesXY1 = selectedCCDs.Any(c => c >= 1 && c <= 3);
            bool usesXY2 = selectedCCDs.Any(c => c == 4);

            if (isStatic)
            {
                if (ct.IsCancellationRequested) return;

                if (usesXY1)
                    await MoveXY1(staticX, staticY);
                if (usesXY2)
                    await MoveXY2(staticX, staticY);

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

                await Logger.WriteLogasTask(Logger.LogType.Running, "StaticDynamicSeq", "RunSequenceAsync", "Static sequence completed", "");
                return;
            }

            // Dynamic mode
            for (int i = 0; i < count; i++)
            {
                if (ct.IsCancellationRequested) break;

                if (usesXY1)
                {
                    await MoveXY1(dynX1, dynY1);
                    var ccds13 = selectedCCDs.Where(c => c >= 1 && c <= 3).ToList();
                    if (ccds13.Count > 0)
                    {
                        await TriggerSelectedCCDsAsync(ccds13, i + 1);
                        await Logger.WriteLogasTask(Logger.LogType.Running, "StaticDynamicSeq", "Trigger", "Triggered CCDs (1-3): " + string.Join(",", ccds13.Select(n => n.ToString())) + " (cycle " + (i + 1) + ")", "");
                    }
                }

                if (ct.IsCancellationRequested) break;

                if (usesXY2)
                {
                    await MoveXY2(dynX2, dynY2);
                    var ccd4 = selectedCCDs.Where(c => c == 4).ToList();
                    if (ccd4.Count > 0)
                    {
                        await TriggerSelectedCCDsAsync(ccd4, i + 1);
                        await Logger.WriteLogasTask(Logger.LogType.Running, "StaticDynamicSeq", "Trigger", "Triggered CCD4 (cycle " + (i + 1) + ")", "");
                    }
                }

                progressCallback?.Invoke(i + 1);
                await Task.Delay(100, ct).ContinueWith(_ => { });
            }

            await Logger.WriteLogasTask(Logger.LogType.Running, "StaticDynamicSeq", "RunSequenceAsync", "Dynamic sequence completed", "");
        }

        private static async Task TriggerSelectedCCDsAsync(List<int> ccds, int runningCount)
        {
            if (ccds == null || ccds.Count == 0)
                return;

            foreach (var c in ccds)
            {
                try
                {
                    string cmd1 = ""; // fallback trigger command
                    string cmd2 = ""; // fallback trigger command
                    string cmd3 = ""; // fallback trigger command
                    string cmd4 = ""; // fallback trigger command
                    string resp = string.Empty;

                    // choose camera object
                    switch (c)
                    {
                        case 1:
                            if (ObjectList.CCD1 != null)
                            {
                                try
                                {
                                    double xpos1 = GantrySystem.getcurrentpos(ObjectList.Servo_X1);
                                    double ypos1 = GantrySystem.getcurrentpos(ObjectList.Servo_Y1);
                                    // Build CCD1 command per template: GoFeederPlace / T3
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

                                    // Use Trig_Camera to send and receive response
                                    resp = await _camera.Trig_Camera(ObjectList.CCD1, cmd1Built);
                                }
                                catch (Exception ex)
                                {
                                    Logger.WriteLog(Logger.LogType.Error, "StaticDynamicSeq", "TriggerSelectedCCDsAsync", "Error trigging CCD1", ex.ToString());
                                }
                            }
                            break;
                        case 2:
                            if (ObjectList.CCD2 != null)
                            {
                                try
                                {
                                    // MoveAndPast templates for CCD2
                                    string dtm = DateTime.Now.ToString("yyyyMMddHHmmss");
                                    int cavityNo = 1;

                                    var tn1 = GlobalVariable.TrainNozzle1;
                                    var tn2 = GlobalVariable.TrainNozzle2;

                                    double posX = GantrySystem.getcurrentpos(ObjectList.Servo_X1);
                                    double posY = GantrySystem.getcurrentpos(ObjectList.Servo_Y1);
                                    double posR = 0; // no R available here

                                    // choose nozzle template based on which nozzle is active near current R or selection - fallback to nozzle1
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
                                            0, 0, 0 // CCD2 receive values placeholder
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
                                }
                                catch (Exception ex)
                                {
                                    Logger.WriteLog(Logger.LogType.Error, "StaticDynamicSeq", "TriggerSelectedCCDsAsync", "Error trigging CCD2", ex.ToString());
                                }
                            }
                            break;
                        case 3:
                            if (ObjectList.CCD3 != null)
                            {
                                try
                                {
                                    // CameraScan templates for CCD3
                                    string dtm = DateTime.Now.ToString("yyyyMMddHHmmss");
                                    int cavityNo = 1;
                                    string sn = ""; // not available here

                                    double nozzleX = GantrySystem.getcurrentpos(ObjectList.Servo_X1);
                                    double nozzleY = GantrySystem.getcurrentpos(ObjectList.Servo_Y1);
                                    // pos = current gantry pos
                                    double posX = nozzleX;
                                    double posY = nozzleY;

                                    // For simplicity assume Z1 (row 0/1)
                                    string cmd3Built = string.Format("T2,S,1,3,1,{0},{1}_NA_NA{2},{3},{4},{5},{6},{7},0,0,0,1",
                                        cavityNo,
                                        dtm,
                                        sn,
                                        nozzleX,
                                        nozzleY,
                                        GlobalVariable.TrainNozzle1?.PositionR1 ?? 0,
                                        posX,
                                        posY);

                                    resp = await _camera.Trig_Camera(ObjectList.CCD3, cmd3Built);
                                }
                                catch (Exception ex)
                                {
                                    Logger.WriteLog(Logger.LogType.Error, "StaticDynamicSeq", "TriggerSelectedCCDsAsync", "Error trigging CCD3", ex.ToString());
                                }
                            }
                            break;
                        case 4:
                            if (ObjectList.CCD4 != null)
                            {
                                try
                                {
                                    // WorkingConveyor2 templates for CCD4
                                    string dtm = DateTime.Now.ToString("yyyyMMddHHmmss");
                                    int cavityNo = 1;
                                    string sn = "";

                                    // choose one-zone template as default
                                    string cmd4Built = string.Format("T2C,S,1,1,{0},{1}_NA{2},1",
                                        cavityNo,
                                        dtm,
                                        sn);

                                    resp = await _camera.Trig_Camera(ObjectList.CCD4, cmd4Built);
                                }
                                catch (Exception ex)
                                {
                                    Logger.WriteLog(Logger.LogType.Error, "StaticDynamicSeq", "TriggerSelectedCCDsAsync", "Error trigging CCD4", ex.ToString());
                                }
                            }
                            break;
                    }

                    // After triggering, capture CSV with optional response
                    CaptureCsvAfterTrigger(new List<int> { c }, runningCount, resp);
                }
                catch (Exception ex)
                {
                    Logger.WriteLog(Logger.LogType.Error, "StaticDynamicSeq", "TriggerSelectedCCDsAsync", "Error triggering CCD " + c, ex.ToString());
                }
            }
        }

        private static void CaptureCsvAfterTrigger(List<int> ccds, int runningCount, string cameraResponse = null)
        {
            try
            {
                if (ccds == null || ccds.Count == 0) return;

                string csvPath = CsvPath;
                Directory.CreateDirectory(Path.GetDirectoryName(csvPath));

                foreach (var c in ccds)
                {
                    double xpos = 0, ypos = 0, zpos = 0;
                    if (c >= 1 && c <= 3)
                    {
                        xpos = GantrySystem.getcurrentpos(ObjectList.Servo_X1);
                        ypos = GantrySystem.getcurrentpos(ObjectList.Servo_Y1);
                        try { zpos = GantrySystem.getcurrentpos(ObjectList.Servo_Z1); } catch { zpos = 0; }
                    }
                    else if (c == 4)
                    {
                        xpos = GantrySystem.getcurrentpos(ObjectList.Servo_X2);
                        ypos = GantrySystem.getcurrentpos(ObjectList.Servo_Y2);
                        try { zpos = GantrySystem.getcurrentpos(ObjectList.Servo_Z2); } catch { zpos = 0; }
                    }

                    // include camera response as last column if present
                    string line = string.Format("{0},{1},{2},{3},{4}", DateTime.Now.ToString("s"), c, xpos, ypos, runningCount);
                    if (!string.IsNullOrEmpty(cameraResponse))
                    {
                        line += ",\"" + cameraResponse.Replace("\"", "'") + "\"";
                    }

                    lock (_csvLock)
                    {
                        File.AppendAllText(csvPath, line + Environment.NewLine);
                    }
                }

                Logger.WriteLog(Logger.LogType.Running, "StaticDynamicSeq", "CaptureCsvAfterTrigger", "Saved CSV for CCDs " + string.Join(",", ccds.Select(n => n.ToString())), "");
            }
            catch (Exception ex)
            {
                Logger.WriteLog(Logger.LogType.Error, "StaticDynamicSeq", "CaptureCsvAfterTrigger", "Failed to save CSV", ex.ToString());
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
