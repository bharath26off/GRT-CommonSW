using Advantech;
using Advantech.Motion;
using DIO;
using DynamicCylinders;
using ExceptionLib;
using GRT_BG1.Data;
using GRT_BG1.Function;
using GRT_BG1.Function.Calibration;
using GRT_BG1.Function.Classes;
using GRT_BG1_V54.Function.CommonClass;
using Master;
using Master.CommonClass;
using Master.GRT.Function.Stopper;
using Master.Log.LogClass;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static DIO.DIDO;

namespace GRT_BG1.Function.DryRun
{
    public class LoadingConveyor : IlodingConveyor
    {


        // SFC_PDCA.SFC sfc = new SFC_PDCA.SFC();
        ScannerSystem scnr = new ScannerSystem();
        WorkingConveyor1 wk1;
        PalletData PalletData;
        public static int iLodingConStep = 10;
        public static bool running = false;
        public static int initialStep = 10;
        public static int retrycount = 0;
        public static bool ScanCon_Seq_completed = true;
        public static bool scanRunning = false;
        public static event Func<int, int, string, string, bool, bool> updatecavity;
        public static event Action clearcavity;
        Position[,] pos = null;
        bool WK1_run = false;
        static PartData[,] data = new PartData[GlobalVariable.CavityRows, GlobalVariable.CavityCols];
        private static string ErrorLogDATAFilePAth = "D:\\TEAL\\";
        public static PartData[,] CurrentData => data;
        public static string carrierbar = "";


        bool dryrun = false;
        bool production = false;

        public LoadingConveyor(Position[,] position)
        {
            wk1 = new WorkingConveyor1(GlobalVariable.WK1Positions);
            pos = position;

        }

        public static Stopwatch Exit_sen_scan = new Stopwatch();
        public async Task LoadingConveyor_Seq(CancellationToken token)
        {
            #region Scanning Process In LoadingConveyor Started
            try
            {
                if (GlobalVariable.g_bMachineMode == GlobalVariable.OperationMode.DryRun)  //Dry Run Purpose Interlock
                {
                    dryrun = true;
                    production = false;
                }
                else
                  if (GlobalVariable.g_bMachineMode == GlobalVariable.OperationMode.Production)
                {
                    production = true;
                    dryrun = false;
                }
                else if (GlobalVariable.g_bMachineMode == GlobalVariable.OperationMode.CPK) // AK
                {
                    production = true;
                    dryrun = false;

                }
                //StationName = "LoadingConveyor";
                while (!token.IsCancellationRequested)
                {
                    token.ThrowIfCancellationRequested();
                    //await Task.Delay(100);
                    //ConveyorSystem._pauseEvent.WaitOne();  // Wait Unit sequnce Resume or Error Clear // By Ak

                    GlobalVariable.LoadReceipe();
                    if (GlobalVariable.b_gPause)
                    {
                        ConveyorSystem._pauseEvent?.WaitOne();
                        //Arulkumar Fixed Hung start
                        await Task.Delay(100);
                        //Arulkumar Fixed Hung end
                        continue;
                    }
                    if (GlobalVariable.current_MCStatus == GlobalVariable.MachineStatus.Running)
                    {
                        //ModuleName = "AutoSeq - LoadingConv";
                        if (GlobalVariable.g_bMachineMode == GlobalVariable.OperationMode.DryRun) //Dry Run Purpose Interlock
                        {
                            //if (!GlobalVariable.LoadingConvWrk)
                            //{
                            //    continue;
                            //}
                        }
                        await Task.Delay(100);
                        switch (iLodingConStep)
                        {


                            case 10:
                                running = true;
                                await Datainitialize(token);
                                if(GlobalVariable.CavityRows == 4 && GlobalVariable.CavityCols == 3)
                                {
                                    data[1, 2].cavityNo = 6;
                                    data[1, 0].cavityNo = 4;
                                    data[3, 2].cavityNo = 12;
                                    data[3, 0].cavityNo = 10;
                                }
                                else if(GlobalVariable.CavityRows == 3 && GlobalVariable.CavityCols == 4)
                                {
                                    data[0, 0].cavityNo = 1;
                                    data[0, 1].cavityNo = 2;
                                    data[0, 2].cavityNo = 3;
                                    data[0, 3].cavityNo = 4;

                                    data[1, 3].cavityNo = 8;
                                    data[1, 2].cavityNo = 7;
                                    data[1, 1].cavityNo = 6;
                                    data[1, 0].cavityNo = 5;

                                    data[2, 0].cavityNo = 9;
                                    data[2, 1].cavityNo = 10;
                                    data[2, 2].cavityNo = 11;
                                    data[2, 3].cavityNo = 12;
                                }
                                else
                                {
                                    ConveyorSystem.Stop();
                                    GlobalVariable.current_MCStatus = GlobalVariable.MachineStatus.Stop;
                                    MessageBox.Show("The Config was not corret in valid value check config.txt for rows : " + GlobalVariable.CavityRows + " and  Cols : " + GlobalVariable.CavityCols, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);
                                    break;

                                }


                                await Logger.WriteLogasTask(Logger.LogType.Running, "LoadingConveyor", "LoadingConveyor", "iLodingConStep 10: Moving gantry to initial position.", "");
                                Task T1 = Task.Run(() => StepperSystem.Stepper_1GoinitialPos());
                                Task T2 = Task.Run(() => StepperSystem.Stepper_2GoinitialPos());
                                await Task.WhenAll(T1, T2);
                                iLodingConStep = 20;
                                break;

                            case 20:

                                if (!GlobalVariable.DI[(int)EInput.Scan_Conv_Pallet_Inplace_Sen])
                                {
                                    if (!GlobalVariable.Semimachk)
                                    {
                                        GlobalVariable.DIDO.WriteOPS(true, (int)EOutput.GRT_Ready_To_Receive_Pallet);

                                        if (GlobalVariable.DI[(int)EInput.Previous_M_C_Ready_To_Send_Pallet])
                                        {
                                            //Arulkumar Fixed random stoppage start
                                            //Reason:
                                            //Root Cause: Existing state loop repeatedly writes the same non-transition log, generating unnecessary log volume.
                                            await Logger.WriteLogasTask(Logger.LogType.Running, "LoadingConveyor & Semmima Conveyor", "LoadingConveyor & Semmima Conveyor", "iLodingConStep 20:LoadingConveyor & Semmima Conveyor starts again.", "");
                                            //Arulkumar Fixed random stoppage end
                                            StepperSystem.MovePlate(new bool?[] { true, true, null, null, null, null });
                                        }
                                        else
                                        {
                                            break;
                                        }
                                    }
                                    else if (GlobalVariable.Semimachk)
                                    {
                                        //Arulkumar Fixed random stoppage start
                                        //Reason:
                                        //Root Cause: Existing state loop repeatedly writes the same non-transition log, generating unnecessary log volume.
                                        await Logger.WriteLogasTask(Logger.LogType.Running, "LoadingConveyor & Semmima Conveyor", "LoadingConveyor & Semmima Conveyor", "iLodingConStep 20:LoadingConveyor & Semmima Conveyor starts again.", "");
                                        //Arulkumar Fixed random stoppage end
                                        StepperSystem.MovePlate(new bool?[] { true, true, null, null, null, null });
                                    }
                                    // await Task.Delay(1000); // AK
                                    iLodingConStep = 30;
                                }


                                break;
                            case 30:
                                if (GlobalVariable.current_MCStatus == GlobalVariable.MachineStatus.Pause)
                                {
                                    iLodingConStep = 20;
                                }
                                if (GlobalVariable.DI[(int)EInput.Scan_Conv_Pallet_Inplace_Sen] || dryrun)
                                {
                                    if (!GlobalVariable.Semimachk)
                                    {
                                        GlobalVariable.DIDO.WriteOPS(false, (int)EOutput.GRT_Ready_To_Receive_Pallet);
                                        await Logger.WriteLogasTask(Logger.LogType.Running, "LoadingConveyor", "LoadingConveyor", "iLodingConStep 30: Conveyor-1 stop", "");
                                        StepperSystem.MovePlate(new bool?[] { true, true, null, null, null, null }); // AK
                                        await Task.Delay(100); // AK
                                        StepperSystem.MovePlate(new bool?[] { false, false, null, null, null, null });
                                        iLodingConStep = 40;
                                    }
                                    else if (GlobalVariable.Semimachk)
                                    {
                                        await Logger.WriteLogasTask(Logger.LogType.Running, "LoadingConveyor", "LoadingConveyor", "iLodingConStep 30: Conveyor-1 stop", "");
                                        StepperSystem.MovePlate(new bool?[] { true, true, null, null, null, null }); // AK
                                        await Task.Delay(100); // AK
                                        StepperSystem.MovePlate(new bool?[] { false, false, null, null, null, null });
                                        iLodingConStep = 40;
                                    }
                                }
                                break;

                            case 40:
                                await Logger.WriteLogasTask(Logger.LogType.Running, "LoadingConveyor", "LoadingConveyor", "iLodingConStep 40: Scanning 12 MLBs.", "");

                                if (!GlobalVariable.Scanner_Bypass)
                                {
                                    if (!scanRunning)
                                    {
                                        //await Task.Delay(1000); // AK
                                        scanRunning = true;
                                        pos = GlobalVariable.scannerCnvPositions;// bharath added for updating scanner position data
                                        await PalletBarcodeTrigger();
                                        await ScanBarcode(token); // Traverses array and scans
                                    }
                                    scanRunning = false;
                                }
                                else
                                {
                                    await ScanBarcode(token);
                                }

                                iLodingConStep = 41;
                                break;

                            case 41:

                                if (!GlobalVariable.DI[(int)EInput.Work_Conv_1_Pallet_Inplace_Sen] && GlobalVariable.DI[(int)EInput.Work_Conv_1_Stopper_Cyl_Up])
                                {
                                    Exit_sen_scan.Start();
                                    Exit_sen_scan.Restart();
                                    Cylinder_config.Cylinders_List[(int)Cylinder_config.Cylinders.Scan_Conv_Stopper_Cyl].Cylinder_Retract();
                                    await Logger.WriteLogasTask(Logger.LogType.Running, "LoadingConveyor", "LoadingConveyor", "iLodingConStep 41: Loading Stopper Cylinder_Retract.", "");

                                    StepperSystem.MovePlate(new bool?[] { true, true, true, true, null, null });
                                    GlobalVariable.New_Pallet_Only = true;
                                    iLodingConStep = 42;

                                }
                                break;

                            case 42:
                                if (dryrun)
                                {
                                    iLodingConStep = 50;

                                }
                                else
                                {
                                    StepperSystem.MovePlate(new bool?[] { true, true, true, true, null, null });
                                    if (GlobalVariable.DI[(int)EInput.Scan_Conv_Pallet_Exit_Sen])
                                    {

                                        //GlobalVariable.LoadingStopper_Start = true;
                                        //LoadingStopper.Start();
                                        //LoadingStopper.Loadingstopper = 0;


                                        Exit_sen_scan.Stop();
                                        iLodingConStep = 43;



                                    }
                                    else
                                    {
                                        if (Exit_sen_scan.ElapsedMilliseconds > GlobalVariable.Scanning_Exit_Sens_Delay)
                                        {
                                            await Logger.WriteLogasTask(Logger.LogType.Running, "LoadingConveyor", "LoadingConveyor", "iLodingConStep 42: Loading stopper Exit_sen_scan Time out .", "");

                                            GlobalVariable.Working_Pallet_NotMoves = true;
                                            DialogResult res = MessageBox.Show("Loading Conv Exit Sensor Not Sensed.Give OK to proceed Next", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);
                                            if (res == DialogResult.OK)
                                            {
                                                Task.Run(() => Logger.WriteLog(Logger.LogType.Error, "LoadingConveyor", "LoadingCon_Seq", "", "Loading Conv Exit Sensor Not Sensed.Give OK to proceed Next"));
                                                GlobalVariable.Working_Pallet_NotMoves = false;
                                                StepperSystem.MovePlate(new bool?[] { true, true, true, true, null, null });
                                                await Task.Delay(2000);

                                                //GlobalVariable.LoadingStopper_Start = true;
                                                //LoadingStopper.Start();
                                                //LoadingStopper.Loadingstopper = 0;

                                                iLodingConStep = 43;
                                                Exit_sen_scan.Stop();
                                            }

                                        }
                                    }
                                }
                                break;


                            case 43:
                                StepperSystem.MovePlate(new bool?[] { true, true, true, true, null, null });

                                if (!GlobalVariable.DI[(int)EInput.Scan_Conv_Pallet_Exit_Sen])
                                {
                                    await Task.Delay(GlobalVariable.Stopper_loading_Time);
                                    iLodingConStep = 44;
                                }
                                break;

                            case 44:
                                StepperSystem.MovePlate(new bool?[] { true, true, true, true, null, null });

                                if (!GlobalVariable.DI[(int)EInput.Scan_Conv_Pallet_Exit_Sen] && !GlobalVariable.DI[(int)EInput.Scan_Conv_Pallet_Inplace_Sen])
                                {
                                    await Logger.WriteLogasTask(Logger.LogType.Running, "LoadingConveyor", "LoadingConveyor", "iLodingConStep 44: Loading pallet Exit .", "");

                                    await Task.Delay(GlobalVariable.Stopper_loader_Time);

                                    Cylinder_config.Cylinders_List[(int)Cylinder_config.Cylinders.Scan_Conv_Stopper_Cyl].Cylinder_Extend();
                                    await Logger.WriteLogasTask(Logger.LogType.Running, "LoadingConveyor", "LoadingConveyor", "iLodingConStep 44: Loading Stopper Cylinder_Extend.", "");

                                    iLodingConStep = 50;
                                }
                                break;

                            case 50:
                                if (dryrun)
                                {
                                    Cylinder_config.Cylinders_List[(int)Cylinder_config.Cylinders.Scan_Conv_Stopper_Cyl].Cylinder_Retract();

                                }
                                if (WorkingConveyor1.semaphoreSlim.CurrentCount > 0 && WorkingConveyor1.semaphoreSlim1.CurrentCount > 0)
                                {
                                    if (dryrun && !WorkingConveyor1.running)
                                    {

                                        PartData[,] copy = PartData.DeepCopy(data);
                                        _ = Task.Run(() => wk1.WorkingCon_Seq(token, copy));
                                        iLodingConStep = 60;

                                    }

                                    else if ((!GlobalVariable.DI[(int)EInput.Work_Conv_1_Pallet_Inplace_Sen] || GlobalVariable.New_Pallet_Only) && GlobalVariable.DI[(int)EInput.Work_Conv_1_Stopper_Cyl_Up])
                                    {
                                        GlobalVariable.New_Pallet_Only = false;
                                        PartData[,] copy = PartData.DeepCopy(data);
                                        StepperSystem.MovePlate(new bool?[] { true, true, true, true, false, false }); // add by rajkumar
                                        _ = Task.Run(() => wk1.WorkingCon_Seq(token, copy));
                                        await Logger.WriteLogasTask(Logger.LogType.Running, "LoadingConveyor", "LoadingConveyor", "iLodingConStep 50: Loading Conveyor to Working Conveyor Data Token Passed.", "");

                                        iLodingConStep = 60;
                                    }

                                }
                                break;

                            case 60:
                                if (dryrun)
                                {
                                    await Task.Delay(1000);
                                    StepperSystem.MovePlate(new bool?[] { false, false, false, false, null, null });
                                    running = false;
                                    await Task.Delay(GlobalVariable.Stopper_loader_Time);
                                    Cylinder_config.Cylinders_List[(int)Cylinder_config.Cylinders.Scan_Conv_Stopper_Cyl].Cylinder_Extend();
                                    clearcavity?.Invoke();
                                    iLodingConStep = 10; // Done

                                }
                                else
                                    if (GlobalVariable.DI[(int)EInput.Work_Conv_1_Pallet_Inplace_Sen] && !GlobalVariable.DI[(int)EInput.Scan_Conv_Pallet_Inplace_Sen])
                                {

                                    running = false;
                                    //data = new PartData[GlobalVariable.CavityRows, GlobalVariable.CavityCols];
                                    data = new PartData[GlobalVariable.CavityRows, GlobalVariable.CavityCols];
                                    cavityno = 0;
                                    clearcavity?.Invoke();
                                    await Logger.WriteLogasTask(Logger.LogType.Running, "LoadingConveyor", "LoadingConveyor", "iLodingConStep 60: clearcavity - ", "");
                                    await Logger.WriteLogasTask(Logger.LogType.Running, "LoadingConveyor", "LoadingConveyor", "iLodingConStep 60: Moved Step 10", "");

                                    iLodingConStep = 10; // Done
                                }
                                break;
                                //case 70:
                                //    break;


                        }
                    }

                }

            }
            catch (Exception ex)
            {
                Logger.WriteLog(Logger.LogType.Error, "ConveyorSequence", "LoadingCon_Seq", ex.Message, ex.ToString());
            }


        }

        public async Task PalletBarcodeTrigger()
        {
            if (production)
            {

                carrierbar = ScannerSystem.Trig_Scanner(ObjectList.Barcode_Scanner, "+");
                if (carrierbar == "error" || carrierbar == "Timeout" || carrierbar == null || carrierbar == "NG" || carrierbar == "NoRead")
                {
                    for (int i = 0; i < 2; i++)
                    {
                        carrierbar = ScannerSystem.Trig_Scanner(ObjectList.Barcode_Scanner, "+");
                        await Task.Delay(1000);
                        if (carrierbar != null)
                        {
                            i = 3;
                        }
                        if (carrierbar != "Timeout")
                            break;
                    }
                }
                if (carrierbar != null)
                {
                    data[0, 0].CarrierBarcode = carrierbar.Split('\r')[0];
                    await Logger.WriteLogasTask(Logger.LogType.Running, "LoadingConveyor", "PalletBarcodeTrigger", "CarrierBarcode : " + data[0, 0].CarrierBarcode, "");


                }

            }
        }


        public async Task ScanBarcode(CancellationToken token)
        {
            if (pos == null) return;


            int rows = pos.GetLength(0);
            int cols = pos.GetLength(1);

            await Logger.WriteLogasTask(Logger.LogType.Running, "LoadingConveyor", "LoadingConveyor", "iLodingConStep 40 ScanBarcode: Moving gantry to each MLB.", "");
            Task T1 = Task.Run(() => StepperSystem.Stepper_1GoinitialPos());
            Task T2 = Task.Run(() => StepperSystem.Stepper_2GoinitialPos());
            await Task.WhenAll(T1, T2);

            if (!GlobalVariable.Scanner_Bypass)
            {
                await GantrySystem.TraverseArray(GantryMovement, rows, cols, token);
            }
            else
            {
                await GantrySystem.TraverseArray(GantryMovements, rows, cols, token);
            }


        }
        public async Task GantryMovements(int row, int col)
        {
            await GantrySystem.ldmove(pos[row, col]);

            data[row, col].SNno = "GWTHTC000F400019MP";
            data[row, col].ScannerData = true;
            updatecavity(row, col, "GWTHTC000F400019MP", "A08426P-0035-BT", true);


        }
        string path = ErrorLogDATAFilePAth + @"\Error_Log\";

        public static void Outside_LOG_dataman(string filepath, string Datetime, string Description, int retry)//, string ok, string DataTransfer_SN, string X_val, string Y_val, string Angle, string filename)//, string Recheck_SN, string Carrier_SN, string Re_Check_Length, string Re_check_Width, string status)
        {
            StringBuilder sFilename = new StringBuilder();
            //string sRecorddate = string.Format("{0}{1}{2}{3}", Datetime, X_val, Y_val, Angle);
            //sFilename.AppendLine(sRecorddate);
            string sLine = "";


            sLine = filepath + DateTime.Now.ToString("dd_MM_yyyy") + "_" + "OutsideLog_dattaman" + ".csv";

            Process[] processes = Process.GetProcessesByName("excel");
            foreach (Process process in processes)
            {
                if (process.MainWindowTitle.Contains(sLine))
                {
                    //Arulkumar Fixed random stoppage start
                    try
                    {
                        process.Kill();
                        Thread.Sleep(100);
                    }
                    catch (Exception ex)
                    {
                        Logger.WriteLog(Logger.LogType.Error, "LoadingConveyor", "Outside_LOG_dataman.KillExcel", ex.Message, ex.ToString());
                    }
                    //Arulkumar Fixed random stoppage end
                }
            }
            if (!Directory.Exists(filepath))
            {
                Directory.CreateDirectory(filepath);
            }
            ///DateTime.Now.ToString("yyy_MM_dd hh mm ss")
            if (!File.Exists(sLine))
            {
                using (StreamWriter sw = new StreamWriter(sLine, true))
                {
                    sw.WriteLine("Datetime,Code And Description,Retry");//,Re_Check_Angle,Re_Check_Length,Re_check_Width,Status,DateTime");
                }
            }
            using (StreamWriter sw = new StreamWriter(sLine, true))
            {
                string Barcode = Datetime;

                sw.WriteLine($"{Barcode},{Description},{retry}");//,{Re_Check_Length},{Re_check_Width},{status},{DateTime.Now.ToString("yyy_MM_dd hh:mm:ss:ffff tt")},");
                sw.Close();
                sw.Dispose();
            }
        }

        public static void ScannerLog_Temp(string filepath, string Datetime, string Description, int retry)//, string ok, string DataTransfer_SN, string X_val, string Y_val, string Angle, string filename)//, string Recheck_SN, string Carrier_SN, string Re_Check_Length, string Re_check_Width, string status)
        {
            StringBuilder sFilename = new StringBuilder();
            //string sRecorddate = string.Format("{0}{1}{2}{3}", Datetime, X_val, Y_val, Angle);
            //sFilename.AppendLine(sRecorddate);
            string sLine = "";


            sLine = filepath + DateTime.Now.ToString("dd_MM_yyyy") + "_" + "ErrorLog" + ".csv";

            Process[] processes = Process.GetProcessesByName("excel");
            foreach (Process process in processes)
            {
                if (process.MainWindowTitle.Contains(sLine))
                {
                    //Arulkumar Fixed random stoppage start
                    try
                    {
                        process.Kill();
                        Thread.Sleep(100);
                    }
                    catch (Exception ex)
                    {
                        Logger.WriteLog(Logger.LogType.Error, "LoadingConveyor", "Outside_LOG_dataman.KillExcel", ex.Message, ex.ToString());
                    }
                    //Arulkumar Fixed random stoppage end
                }
            }
            if (!Directory.Exists(filepath))
            {
                Directory.CreateDirectory(filepath);
            }
            ///DateTime.Now.ToString("yyy_MM_dd hh mm ss")
            if (!File.Exists(sLine))
            {
                using (StreamWriter sw = new StreamWriter(sLine, true))
                {
                    sw.WriteLine("Datetime,Code And Description,Retry");//,Re_Check_Angle,Re_Check_Length,Re_check_Width,Status,DateTime");
                }
            }
            using (StreamWriter sw = new StreamWriter(sLine, true))
            {
                string Barcode = Datetime;

                sw.WriteLine($"{Barcode},{Description},{retry}");//,{Re_Check_Length},{Re_check_Width},{status},{DateTime.Now.ToString("yyy_MM_dd hh:mm:ss:ffff tt")},");
                sw.Close();
                sw.Dispose();
            }
        }

        //Move Gantry to each MLB and scan the barcode
        //public async Task GantryMovement(int row, int col)
        //{

        //    try
        //    {
        //        string Datetime = DateTime.Now.ToString("dd-MM-yyyy hh:mm:ss:ffff tt");
        //        string sacnerData = "";
        //        //log(datetime,scannerData,place);

        //        ScannerLog_Temp(path, Datetime, sacnerData, 1);
        //        await GantrySystem.ldmove(pos[row, col]);
        //        await Task.Delay(300);
        //        await GantrySystem.ldmove(pos[row, col]);
        //        ScannerLog_Temp(path, Datetime, sacnerData, 2);
        //        if (production)
        //        {
        //            retrycount = 0;
        //        RETRY:
        //            sacnerData = ScannerSystem.Trig_Scanner(ObjectList.Barcode_Scanner, "+");
        //            //log(datetime,scannerData,place);
        //            ScannerLog_Temp(path, Datetime, sacnerData, 3);
        //            if (sacnerData != null)
        //                //if(!=null)
        //                sacnerData = sacnerData.Replace("\r", "").Replace("\n", "").Replace("+", "").Trim();
        //            //log(datetime,scannerData,place);
        //            ScannerLog_Temp(path, Datetime, sacnerData, 4);
        //            if ((sacnerData.Length > 18) || (sacnerData.Length < 18) || (sacnerData.Contains('-')))
        //            {
        //                sacnerData = "NG";
        //                return;
        //            }
        //            if ((sacnerData != "Timeout") && ((sacnerData != "")) && (sacnerData != "error") && (sacnerData != null) && (sacnerData != "NG"))
        //            {
        //                ScannerLog_Temp(path, Datetime, sacnerData, 5);
        //                //log(datetime,scannerData,place);
        //                //if (sacnerData.Length > 18)
        //                //{
        //                //    sacnerData = sacnerData.Replace("NG", "");
        //                //}
        //                bool ok = false;
        //                if (!GlobalVariable.SFC_PDCA_Bypass)
        //                {
        //                    ok = S_Pdca.Barcode_Data_Send_SFC(sacnerData.Split('\r')[0]);
        //                }
        //                else
        //                {
        //                    ok = true;
        //                }
        //                if (ok)
        //                {
        //                    //log(datetime,scannerData,place);
        //                    ScannerLog_Temp(path, Datetime, sacnerData, 6);
        //                    data[row, col].SNno = sacnerData.Split('\r')[0];

        //                    data[row, col].ScannerData = true;
        //                }
        //                else
        //                {
        //                    ScannerLog_Temp(path, Datetime, sacnerData, 7);
        //                    data[row, col].OkNok = "NG";
        //                    data[row, col].SNno = "UOP";
        //                    data[row, col].ScannerData = false;
        //                    GlobalVariable.VbUOP_ProcessFail = true;
        //                    // updatecavity(row, col, "UOP_NG", data[0, 0].CarrierBarcode, true);
        //                    DialogResult res = MessageBox.Show("UNIT OUT OF PROCESS", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning,
        //                    MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);
        //                    if (res == DialogResult.OK)
        //                    {
        //                        GlobalVariable.VbUOP_ProcessFail = false;
        //                    }
        //                    //MessageBox.Show("UNIT OUT OF PROCESS", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning,
        //                    //    MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);

        //                }
        //                if ((sacnerData.Split('\r')[0] != "Timeout"))
        //                {
        //                    if ((ok))
        //                    {
        //                        ScannerLog_Temp(path, Datetime, sacnerData, 8);
        //                        //log(datetime,scannerData,place);
        //                        GlobalVariable.VbUOP_ProcessFail = false;
        //                        data[row, col].SNno = sacnerData.Split('\r')[0]; ;
        //                        data[row, col].ScannerData = true;
        //                        updatecavity(row, col, sacnerData.Split('\r')[0], data[0, 0].CarrierBarcode, true);
        //                        if (GlobalVariable.SFC_PDCA_Bypass)
        //                        {

        //                            data[row, col].OkNok = "ok";

        //                        }
        //                        else
        //                        {
        //                            //log(datetime,scannerData,place);
        //                            // Fire-and-forget SFC process
        //                            _ = Task.Run(async () =>
        //                            {
        //                                // var result = await sfc.SFC_Varification(sacnerData);
        //                                data[row, col].OkNok = "ok";//result;

        //                            });
        //                        }
        //                    }
        //                    else
        //                    {
        //                        data[row, col].OkNok = "NG";
        //                        data[row, col].SNno = "UOP";
        //                        data[row, col].ScannerData = false;
        //                        updatecavity(row, col, "UOP_NG", data[0, 0].CarrierBarcode, false);
        //                    }
        //                }
        //            }
        //            else
        //            {
        //                if (retrycount > 2)
        //                {
        //                    ScannerLog_Temp(path, Datetime, sacnerData + " " + "Retry", retrycount);
        //                    //log(datetime,scannerData,retrycount);
        //                    retrycount = 0;
        //                    data[row, col].OkNok = "NG";
        //                    data[row, col].SNno = null;
        //                    data[row, col].ScannerData = false;
        //                    updatecavity(row, col, "NG", data[0, 0].CarrierBarcode, false);
        //                }
        //                else
        //                {
        //                    retrycount++;
        //                    await Task.Delay(50);
        //                    goto RETRY;
        //                }
        //            }
        //        }
        //        else
        //        {
        //            _ = ScannerSystem.Trig_Scanner(ObjectList.Barcode_Scanner, "+");
        //            updatecavity(row, col, "SN", "SN", true);
        //        }
        //        await Task.Delay(100);
        //        await Logger.WriteLogasTask(Logger.LogType.Running, "LoadingConveyor", "LoadingConveyor", "GntrayMovement:" + data[row, col].cavityNo + "Scan Completed", "");








        //        await GantrySystem.ldmove(pos[row, col]);

        //        //if (production)
        //        //{
        //        //    if (GlobalVariable.b_gPause)
        //        //    {
        //        //        return;
        //        //    }

        //        //    if (GlobalVariable.current_MCStatus != GlobalVariable.MachineStatus.Running)
        //        //    {
        //        //        return;
        //        //    }

        //        //    await GantrySystem.ldmove(pos[row, col]);


        //        //    await Task.Delay(300);

        //        //     string sacnerData = null;

        //        //    sacnerData = ScannerSystem.Trig_Scanner(ObjectList.Barcode_Scanner, "+");
        //        //    if ((sacnerData == null)||(sacnerData == "")||(sacnerData == "error") ||(sacnerData == "Timeout"))
        //        //    {
        //        //        ObjectList.ScnrObj[0].ClearRcvdDta(); // AK
        //        //        for (int i = 0; i < 2; i++)
        //        //        {
        //        //            sacnerData = ScannerSystem.Trig_Scanner(ObjectList.Barcode_Scanner, "+");
        //        //            if (sacnerData != null)
        //        //            {
        //        //                i = 3;
        //        //            }
        //        //            await Task.Delay(200);
        //        //            ObjectList.ScnrObj[0].ClearRcvdDta();

        //        //        }
        //        //    }
        //        //    //if (!string.IsNullOrWhiteSpace(sacnerData) && sacnerData == "error" && sacnerData == "Timeout")
        //        //    //{

        //        //    //    if (sacnerData.Split('\r')[0] != carrierbar)
        //        //    //    {
        //        //    //        return;
        //        //    //    }
        //        //    //}
        //        //    if ((sacnerData != null)&&(sacnerData != "")&&(sacnerData != "error") && (sacnerData != "Timeout"))
        //        //    {
        //        //        if (sacnerData.Split('\r')[0] == carrierbar)
        //        //        {
        //        //            for (int i = 0; i < 3; i++)
        //        //            {
        //        //                ObjectList.ScnrObj[0].ClearRcvdDta(); // AK
        //        //                sacnerData = ScannerSystem.Trig_Scanner(ObjectList.Barcode_Scanner, "+");
        //        //                await Task.Delay(100);
        //        //                ObjectList.ScnrObj[0].ClearRcvdDta();
        //        //            }
        //        //        }

        //        //        //if (sacnerData == "error" || sacnerData == "Timeout")
        //        //        //{
        //        //        //    for (int i = 0; i < 3; i++)
        //        //        //    {
        //        //        //        ObjectList.ScnrObj[0].ClearRcvdDta(); // AK
        //        //        //        sacnerData = ScannerSystem.Trig_Scanner(ObjectList.Barcode_Scanner, "+");
        //        //        //        await Task.Delay(100);
        //        //        //        if (sacnerData != "Timeout")
        //        //        //            break;
        //        //        //    }
        //        //        //}
        //        //        else
        //        //        if (sacnerData == "")
        //        //        {
        //        //            await Task.Run(() => Logger.WriteLogasTask(Logger.LogType.Running, "Conveyor1", "Conveyor1", "Loading Conveyor Scanner data empty.", ""));
        //        //        }
        //        //        bool ok = false;
        //        //        if (!GlobalVariable.SFC_PDCA_Bypass)
        //        //        {
        //        //            ok = S_Pdca.Barcode_Data_Send_SFC(sacnerData.Split('\r')[0]);
        //        //        }
        //        //        else
        //        //        {
        //        //            ok = true;
        //        //        }
        //        //        if (ok)
        //        //        {
        //        //            data[row, col].SNno = sacnerData.Split('\r')[0];

        //        //            data[row, col].ScannerData = true;
        //        //        }
        //        //        else
        //        //        {
        //        //            data[row, col].OkNok = "NG";
        //        //            data[row, col].SNno = "UOP";
        //        //            data[row, col].ScannerData = false;
        //        //            GlobalVariable.VbUOP_ProcessFail = true;
        //        //            // updatecavity(row, col, "UOP_NG", data[0, 0].CarrierBarcode, true);
        //        //            DialogResult res = MessageBox.Show("UNIT OUT OF PROCESS", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning,
        //        //            MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);
        //        //            if (res == DialogResult.OK)
        //        //            {
        //        //                GlobalVariable.VbUOP_ProcessFail = false;
        //        //            }
        //        //            //MessageBox.Show("UNIT OUT OF PROCESS", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning,
        //        //            //    MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);

        //        //        }


        //        //        //if (sacnerData != null && sacnerData.Split('\r')[0] != "Timeout")
        //        //        //{
        //        //        //    var barcode = sacnerData.Split('\r')[0];
        //        //        //    data[row, col].SNno = barcode;
        //        //        //    data[row, col].ScannerData = true;
        //        //        //    // updatecavity(row, col, sacnerData.Split('\r')[0], data[0, 0].CarrierBarcode, true);
        //        //        //    updatecavity(row, col, barcode, data[0, 0].CarrierBarcode, true);
        //        //        //    if (GlobalVariable.SFC_PDCA_Bypass)
        //        //        //    {

        //        //        //        data[row, col].OkNok = "ok";

        //        //        //    }
        //        //        //    else
        //        //        //    {
        //        //        //        // Ensure we only send once per cavity
        //        //        //        int cavityIndex = data[row, col].cavityNo;
        //        //        //        bool alreadySent = false;
        //        //        //        try
        //        //        //        {
        //        //        //            alreadySent = SfcClient.SFC_Cavity_sn_data_Sent.TryGetValue(cavityIndex, out bool v) && v;
        //        //        //        }
        //        //        //        catch { }

        //        //        //        if (!alreadySent)
        //        //        //        {
        //        //        //            // Fire-and-forget: send to SFC in background and update data when done
        //        //        //            _ = Task.Run(async () =>
        //        //        //            {
        //        //        //                try
        //        //        //                {
        //        //        //                    using (var cts = new CancellationTokenSource(10000)) // per-send safety timeout
        //        //        //                    {
        //        //        //                      bool ok = S_Pdca.Barcode_Data_Send_SFC(barcode); //AK
        //        //        //                        data[row, col].OkNok = ok ? "ok" : "NG";
        //        //        //                        // Notify UI/host about result
        //        //        //                        try { updatecavity?.Invoke(row, col, data[row, col].OkNok, data[0, 0].CarrierBarcode, ok); } catch { }
        //        //        //                    }
        //        //        //                }
        //        //        //                catch (Exception ex)
        //        //        //                {
        //        //        //                    data[row, col].OkNok = "NG";
        //        //        //                    try { updatecavity?.Invoke(row, col, data[row, col].OkNok, data[0, 0].CarrierBarcode, false); } catch { }
        //        //        //                    await Logger.WriteLogasTask(Logger.LogType.Error, "LoadingConveyor", "GantryMovement", "SFC send error", ex.ToString());
        //        //        //                }
        //        //        //            });
        //        //        //        }
        //        //        //        else
        //        //        //        {
        //        //        //            // already sent, mark OK if client recorded OK
        //        //        //            if (SfcClient.barcode__Recheck_result.TryGetValue(data[row, col].cavityNo, out string res) && res == "OK")
        //        //        //                data[row, col].OkNok = "ok";
        //        //        //        }
        //        //        //    }
        //        //        //}

        //        //        if ((sacnerData.Split('\r')[0] != "Timeout"))
        //        //        {
        //        //            if ((ok))
        //        //            {
        //        //                GlobalVariable.VbUOP_ProcessFail = false;
        //        //                data[row, col].SNno = sacnerData.Split('\r')[0]; ;
        //        //                data[row, col].ScannerData = true;
        //        //                updatecavity(row, col, sacnerData.Split('\r')[0], data[0, 0].CarrierBarcode, true);
        //        //                if (GlobalVariable.SFC_PDCA_Bypass)
        //        //                {

        //        //                    data[row, col].OkNok = "ok";

        //        //                }
        //        //                else
        //        //                {
        //        //                    // Fire-and-forget SFC process
        //        //                    _ = Task.Run(async () =>
        //        //                    {
        //        //                        // var result = await sfc.SFC_Varification(sacnerData);
        //        //                        data[row, col].OkNok = "ok";//result;

        //        //                    });
        //        //                }
        //        //            }
        //        //            else
        //        //            {
        //        //                data[row, col].OkNok = "NG";
        //        //                data[row, col].SNno = "UOP";
        //        //                data[row, col].ScannerData = false;
        //        //                updatecavity(row, col, "UOP_NG", data[0, 0].CarrierBarcode, false);
        //        //            }
        //        //        }

        //        //        else
        //        //        {
        //        //            data[row, col].OkNok = "NG";
        //        //            data[row, col].SNno = null;
        //        //            data[row, col].ScannerData = false;
        //        //            updatecavity(row, col, "NG", data[0, 0].CarrierBarcode, false);
        //        //        }



        //        //    }
        //        //    else
        //        //    {
        //        //        data[row, col].OkNok = "NG";
        //        //        data[row, col].SNno = null;
        //        //        data[row, col].ScannerData = false;
        //        //        updatecavity(row, col, "NG", data[0, 0].CarrierBarcode, false);
        //        //    }
        //        //}
        //        //else
        //        //{
        //        //    _ = ScannerSystem.Trig_Scanner(ObjectList.Barcode_Scanner, "+");
        //        //    updatecavity(row, col, "SN", "SN", true);
        //        //}
        //        //await Task.Delay(100);
        //        //await Logger.WriteLogasTask(Logger.LogType.Running, "LoadingConveyor", "LoadingConveyor", "GntrayMovement:" + data[row, col].cavityNo + "Scan Completed", "");
        //    }
        //    catch (Exception ex)
        //    {
        //        await Logger.WriteLogasTask(Logger.LogType.Running, "LoadingConveyor", "Barcode Scanning", "Barcode Scanning Status" + ex.Message, ex.ToString());

        //    }
        //}

        public async Task GantryMovement(int row, int col) // AK
        {
            try
            {
                string path = ErrorLogDATAFilePAth + @"\OutSideLog\";
                string Datetime = DateTime.Now.ToString("dd-MM-yyyy hh:mm:ss:ffff tt");
                string sacnerData = "";

                Outside_LOG_dataman(path, Datetime, "Before Move", 1);

                await GantrySystem.ldmove(pos[row, col]);
                await Task.Delay(300);
                await GantrySystem.ldmove(pos[row, col]);

                Outside_LOG_dataman(path, Datetime, "After Move", 2);

                if (production)
                {
                    retrycount = 0;

                RETRY:
                    Outside_LOG_dataman(path, Datetime, "Before Trigger", 3);
                    sacnerData = ScannerSystem.Trig_Scanner(ObjectList.Barcode_Scanner, "+");
                    Outside_LOG_dataman(path, Datetime, "Affter Trigger", 4);



                    if (sacnerData != null)
                    {
                        sacnerData = sacnerData
                            .Replace("\r", "")
                            .Replace("\n", "")
                            .Replace("+", "")
                            .Trim();
                    }

                    Outside_LOG_dataman(path, Datetime, sacnerData, 4);


                    if (string.IsNullOrWhiteSpace(sacnerData) ||
                        sacnerData.Length != 18 ||
                        sacnerData.Contains('-'))
                    {
                        sacnerData = "NG";
                    }

                    if ((sacnerData != "Timeout") &&
                        (sacnerData != "") &&
                        (sacnerData != "error") &&
                        (sacnerData != null) &&
                        (sacnerData != "NG") && sacnerData != "NoRead")
                    {
                        Outside_LOG_dataman(path, Datetime, sacnerData, 5);

                        bool ok = false;

                        if (!GlobalVariable.SFC_PDCA_Bypass)
                        {
                            ok = S_Pdca.Barcode_Data_Send_SFC(sacnerData.Split('\r')[0]);
                        }
                        else
                        {
                            ok = true;
                        }

                        if (ok)
                        {
                            Outside_LOG_dataman(path, Datetime, sacnerData, 6);

                            data[row, col].SNno = sacnerData.Split('\r')[0];
                            data[row, col].ScannerData = true;
                        }
                        else
                        {
                            Outside_LOG_dataman(path, Datetime, sacnerData, 7);

                            data[row, col].OkNok = "NG";
                            data[row, col].SNno = "UOP";
                            data[row, col].ScannerData = false;

                            GlobalVariable.VbUOP_ProcessFail = true;

                            DialogResult res = MessageBox.Show("UNIT OUT OF PROCESS", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);

                            if (res == DialogResult.OK)
                            {
                                GlobalVariable.VbUOP_ProcessFail = false;
                            }
                        }

                        if (sacnerData.Split('\r')[0] != "Timeout")
                        {
                            if (ok)
                            {
                                Outside_LOG_dataman(path, Datetime, sacnerData, 8);

                                GlobalVariable.VbUOP_ProcessFail = false;

                                data[row, col].SNno = sacnerData.Split('\r')[0];
                                data[row, col].ScannerData = true;

                                updatecavity(
                                    row,
                                    col,
                                    sacnerData.Split('\r')[0],
                                    data[0, 0].CarrierBarcode,
                                    true);

                                if (GlobalVariable.SFC_PDCA_Bypass)
                                {
                                    data[row, col].OkNok = "OK";
                                }
                                else
                                {
                                    //_ = Task.Run(async () =>{data[row, col].OkNok = "ok";}); // 24-07-2026 CMD BY ARULKUMAR
                                    await Task.Run(() => data[row, col].OkNok = "OK"); // 24-07-2026
                                }
                            }
                            else
                            {
                                data[row, col].OkNok = "NG";
                                data[row, col].SNno = "UOP";
                                data[row, col].ScannerData = false;

                                updatecavity(
                                    row,
                                    col,
                                    "UOP_NG" + data[row, col].SNno,
                                    data[0, 0].CarrierBarcode,
                                    false);
                            }
                        }
                    }
                    else
                    {

                        if (retrycount > 1)
                        {
                            Outside_LOG_dataman(
                                path,
                                Datetime,
                                sacnerData + " Retry Failed",
                                retrycount);

                            retrycount = 0;

                            data[row, col].OkNok = "NG";
                            data[row, col].SNno = "NOCODE_NG";
                            data[row, col].ScannerData = false;

                            updatecavity(
                                row,
                                col,
                                "NOCODE_NG",
                                data[0, 0].CarrierBarcode,
                                false);
                        }
                        else
                        {
                            retrycount++;

                            Outside_LOG_dataman(
                                path,
                                Datetime,
                                "Retry Count : " + retrycount,
                                retrycount);

                            await Task.Delay(50);

                            goto RETRY;
                        }
                    }
                }
                else
                {
                    _ = ScannerSystem.Trig_Scanner(ObjectList.Barcode_Scanner, "+");

                    updatecavity(row, col, "SN", "SN", true);
                }

                await Task.Delay(100);

                await Logger.WriteLogasTask(Logger.LogType.Running, "LoadingConveyor", "LoadingConveyor", "GntrayMovement:" + data[row, col].cavityNo + " SNno :" + data[row, col].SNno + " Scan Completed", "");

                await GantrySystem.ldmove(pos[row, col]);
            }
            catch (Exception ex)
            {
                await Logger.WriteLogasTask(
                    Logger.LogType.Running,
                    "LoadingConveyor",
                    "Barcode Scanning",
                    "Barcode Scanning Status " + ex.Message,
                    ex.ToString());
            }
        }

        public async Task palletOut(CancellationToken token)
        {
            try
            {
                if (GlobalVariable.g_bMachineMode == GlobalVariable.OperationMode.DryRun)  //Dry Run Purpose Interlock
                {
                    GlobalVariable.LoadingConvWrk = true;
                }
                //StationName = "LoadingConveyor";
                while (!token.IsCancellationRequested && initialStep < 30)
                {
                    //await Task.Delay(100);
                    //ConveyorSystem._pauseEvent.WaitOne();  // Wait Unit sequnce Resume or Error Clear // by AK
                    //if (GlobalVariable.b_gPause)
                    //{
                    //    continue;
                    //}s
                    if (GlobalVariable.current_MCStatus == GlobalVariable.MachineStatus.Running)
                    {
                        //ModuleName = "AutoSeq - LoadingConv";
                        if (GlobalVariable.g_bMachineMode == GlobalVariable.OperationMode.DryRun) //Dry Run Purpose Interlock
                        {
                            if (!GlobalVariable.LoadingConvWrk)
                            {
                                continue;
                            }
                        }
                        await Task.Delay(100);
                        switch (initialStep)
                        {
                            case 10:


                                await Logger.WriteLogasTask(Logger.LogType.Running, "Homing", "loading cnv", "Lowering all stopper and lift cylinders", "");
                                //Cylinder_config.Cylinders_List[(int)Cylinder_config.Cylinders.Scan_Conv_Stopper_Cyl].Cylinder_Retract();
                                //Cylinder_config.Cylinders_List[(int)Cylinder_config.Cylinders.Work_Conv_1_Stopper_Cyl].Cylinder_Retract();
                                //Cylinder_config.Cylinders_List[(int)Cylinder_config.Cylinders.Work_Conv_1_pallet_Lift_Cyl].Cylinder_Retract();
                                //Cylinder_config.Cylinders_List[(int)Cylinder_config.Cylinders.Work_Conv_2_pallet_Lift_Cyl].Cylinder_Retract();
                                //Cylinder_config.Cylinders_List[(int)Cylinder_config.Cylinders.Work_Conv_2_Stopper_Cyl].Cylinder_Retract();
                                await Task.Delay(1000);
                                initialStep = 20;

                                break;

                            case 20:

                                await Logger.WriteLogasTask(Logger.LogType.Running, "Homing", "Loading cnv", " starting conveyors", "");
                                StepperSystem.MovePlate(new bool?[] { true, true, true, true, true, true });
                                await Task.Delay(10000);
                                //Arulkumar Fixed Null start
                                if (GlobalVariable.DI != null && GlobalVariable.DI.Length > (GlobalVariable.g_MachineIoChaged == "Yes" ? (int)EInput_1.Work_Conv_2_Pallet_Exit_Sen : (int)EInput.Work_Conv_2_Pallet_Exit_Sen)
                                    && (!GlobalVariable.DI[(int)EInput.Work_Conv_1_Pallet_Inplace_Sen] || !GlobalVariable.DI[(int)EInput.Scan_Conv_Pallet_Inplace_Sen] || !GlobalVariable.DI[(int)EInput.Scan_Conv_Pallet_Exit_Sen] || !GlobalVariable.DI[(int)EInput.Work_Conv_1_Pallet_Exit_Sen] || (GlobalVariable.g_MachineIoChaged == "Yes" ?  !GlobalVariable.DI[(int)EInput_1.Work_Conv_2_Pallet_Exit_Sen] : !GlobalVariable.DI[(int)EInput.Work_Conv_2_Pallet_Exit_Sen])))
                                //Arulkumar Fixed Null end
                                {
                                    StepperSystem.MovePlate(new bool?[] { false, false, false, false, false, false });
                                    //Cylinder_config.Cylinders_List[(int)Cylinder_config.Cylinders.Scan_Conv_Stopper_Cyl].Cylinder_Extend();
                                    // Cylinder_config.Cylinders_List[(int)Cylinder_config.Cylinders.Work_Conv_1_Stopper_Cyl].Cylinder_Extend(); ;
                                    //Cylinder_config.Cylinders_List[(int)Cylinder_config.Cylinders.Work_Conv_2_Stopper_Cyl].Cylinder_Extend();

                                    initialStep = 30;
                                }
                                initialStep = 30;
                                break;
                        }
                    }
                }
            }

            catch (Exception ex)
            {
                //Arulkumar Fixed random stoppage start
                Logger.WriteLog(Logger.LogType.Error, "LoadingConveyor", "palletOut", ex.Message, ex.ToString());
                //Arulkumar Fixed random stoppage end
            }
        }
        #endregion

        private async Task Datainitialize(CancellationToken token)
        {
            if (pos == null) return;


            int rows = pos.GetLength(0);
            int cols = pos.GetLength(1);
            await GantrySystem.TraverseArray(CreatePart, rows, cols, token);
        }

        int cavityno = 0;
        private async Task CreatePart(int row, int col)
        {
            data[row, col] = new PartData();
            cavityno++;
            data[row, col].cavityNo = cavityno;


        }


    }
}
