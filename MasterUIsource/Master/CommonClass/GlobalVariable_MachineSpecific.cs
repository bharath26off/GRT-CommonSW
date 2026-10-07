using ExceptionLib;
using GRT_BG1.Data;
using GRT_BG1_V54.Data;
using Master.GRT.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Windows.Forms;
namespace Master
{

    /******************************************************************************
    *              MACHINE SPECIFIC GLOBAL VARIABLES CONFIGURATION                 
    *              [interlocks, variables, receipes]
    *******************************************************************************/

    //**devchange: change the variables according the machine
    public partial class GlobalVariable
    {

        #region  ROBOT VARIABLES
        public static bool g_RoboSafePos = false;
        public static bool g_RobotSeqRun = false;
        public static string g_RobotCmd = string.Empty;
        public static string g_RobotErrCmd = string.Empty;
        public static string g_RobotStatus = string.Empty;
        public static string g_RobotResult = string.Empty;
        public static string g_RobotSeqCmd = string.Empty;
        public static double g_RoboXValue;
        public static double g_RoboYValue;
        public static double g_RobotAngle;
        public static double g_RobotHValue;
        public static int g_RobotretryCount = 3;

        #endregion


        #region VISION VARIABLES
        public static string g_VisionCmd = string.Empty;
        public static string g_VisionStatus = string.Empty;
        public static string g_VisionResult = string.Empty;
        public static int g_VisionretryCount = 3;
        public static List<string> g_VisionObservation = new List<string>();

        #endregion

        #region  TOSSING SEQUENCE VARIABLES
        public static string g_TossingCmd = string.Empty;
        public static string g_TossingResult = string.Empty;
        #endregion


        #region CONVEYOR MOTOR SPEEDS

        public static int LoadingConveyorDir = 0;
        public static double LoadingConveyorVelocity = 1000;
        public static double LoadingConveyorAcc = 1000;
        public static double LoadingConveyorDeAcc = 1000;
        public static int WorkingConveyorDir = 0;
        public static double WorkingConveyorVelocity = 1000;
        public static double WorkingConveyorAcc = 1000;
        public static double WorkingConveyorDeAcc = 1000;
        public static int UnLoadingConveyorDir = 0;
        public static double UnLoadingConveyorVelocity = 1000;
        public static double UnLoadingConveyorAcc = 1000;
        public static double UnLoadingConveyorDeAcc = 1000;

        public static bool IsBTHLoadingFeeder_Run = false;
        public static bool IsBTHInspection_Run = false;

        public static bool LoadingConvWrk = false;
        public static bool WorkingConvWrk = false;
        public static bool UnLoadingConvWrk = false;

        #endregion


        #region RECEIPE SCREEN HELPERS and RECEIPE VARIABLES

        //Receipe


        public static double Recipe_RoboSpeed;
        public static double Recipe_RoboPickDelay;
        public static double Recipe_RoboplaceDelay;
        public static Position[,] scannerCnvPositions;
        public static Position scan_Carrier_Barcode;
        public static Position[,] WK1Positions;
        public static Position WK1_initial;
        public static Position Wk1_Z1FedPos;
        public static Position Wk1_Z2FedPos;
        public static Position Wk1_Z1CCD2pos;
        public static Position Wk1_Z2CCD2pos;
        public static Position Wk1_Z1FedPos2;
        public static Position Wk1_Z1FedPos3;
        public static Position Wk1_Z1FedPos4;
        public static Position Wk1_Z2FedPos1;
        public static Position Wk1_Z2FedPos3;
        public static Position Wk1_Z2FedPos4;

        public static OFFSET[] offset = null;
        public static OFFSETK[] offsetK = null;
        public static OFFSETNK[] offsetNK = null;
        public static AEParameter[] AEParameters = null;
        public static SFC_PDCA_Data[] SFC_PDCA_Data = null;
        public static DELAY[] delay = null;
        public static FEEDER_SAFE[] Feeder_MinMax = null;


        public static Position Wk1_Rejpos;
        public static Position[,] Wk2Positions;
        public static Position Wk2_initial;
        public static Position Photo_z2;
        public static Position Photo_Z1;
        public static Position Nozzle_loc_Z1;
        public static Position Nozzle_loc_Z2;
        public static Position pickup_loc_Z1;
        public static Position pickup_loc_Z2;
        public static Position feddrop_loc_Z1;
        public static Position feddrop_loc_Z2;
        public static Position[,] Wk2CalibPositions;
        public static Position SafePosition;
        public static Position TrainNozzle1;
        public static Position TrainNozzle2;
        static bool wk2positiondone = false;

        // public static double Positionarray 

        public static DataTable LoadCsvData(string filePath)
        {
            string[] csvLines;
            DataTable dataTable = new DataTable();
            try
            {
                if (File.Exists(filePath))
                {
                    csvLines = File.ReadAllLines(filePath);

                    if (csvLines.Length > 0)
                    {
                        //Add columns to DataTable
                        string[] headers = csvLines[0].Split(',');
                        headers = headers.Take(5).ToArray();
                        //string toremove = headers[0];
                        //headers = headers.Where(x => x != toremove).ToArray();
                        foreach (string header in headers)
                        {
                            dataTable.Columns.Add(header);
                        }

                        //Add rows to DataTable
                        for (int i = 1; i < csvLines.Length; i++)
                        {
                            string[] data = csvLines[i].Split(',');
                            data = data.Take(5).ToArray();
                            //string elementToRemove = data[1];
                            //data = data.Where(x => x != elementToRemove).ToArray();
                            dataTable.Rows.Add(data);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Recipe Param File is missing", "Recipe Group Manager Software", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog(Logger.LogType.Error, "GlobalVariable", "", ex.Message, ex.ToString());
            }
            return dataTable;
        }
        public static void LoadReceipe()
        {
            try
            {
                DataTable dataTable = new DataTable();
                dataTable = HelperClassLib.GetDataFromHelper.GetDataFromCSV(Environment.CurrentDirectory + @"\Data\ScannerModuleReceipe_Param.csv");
                LoadReceipeTables(dataTable, "SCANNERMODULE");
                dataTable = HelperClassLib.GetDataFromHelper.GetDataFromCSV(Environment.CurrentDirectory + @"\Data\Wk1ModuleReceipe_Param.csv");
                LoadReceipeTables(dataTable, "WK1MODULE");
                dataTable = HelperClassLib.GetDataFromHelper.GetDataFromCSV(Environment.CurrentDirectory + @"\Data\Wk2ModuleReceipe_Param.csv");
                LoadReceipeTables(dataTable, "WK2MODULE");
                dataTable = HelperClassLib.GetDataFromHelper.GetDataFromCSV(Environment.CurrentDirectory + @"\Data\Nozzle1_Param.csv");
                LoadReceipeTables(dataTable, "Nozzle1");
                dataTable = HelperClassLib.GetDataFromHelper.GetDataFromCSV(Environment.CurrentDirectory + @"\Data\Nozzle2_Param.csv");
                LoadReceipeTables(dataTable, "Nozzle2");
                dataTable = HelperClassLib.GetDataFromHelper.GetDataFromCSV(Environment.CurrentDirectory + @"\Data\Final_Param.csv");
                LoadReceipeTables(dataTable, "Final");
                dataTable = HelperClassLib.GetDataFromHelper.GetDataFromCSV(Environment.CurrentDirectory + @"\Data\Nozzle1_Train_Param.csv");
                LoadReceipeTables(dataTable, "Nozzle1_TrainParam");
                dataTable = HelperClassLib.GetDataFromHelper.GetDataFromCSV(Environment.CurrentDirectory + @"\Data\Nozzle2_Train_Param.csv");
                LoadReceipeTables(dataTable, "Nozzle2_TrainParam");
                dataTable = HelperClassLib.GetDataFromHelper.GetDataFromCSV(Environment.CurrentDirectory + @"\Data\OFFSET.csv");
                LoadReceipeTables(dataTable, "OFFSET");
                dataTable = HelperClassLib.GetDataFromHelper.GetDataFromCSV(Environment.CurrentDirectory + @"\Data\OFFSETK.csv");
                LoadReceipeTables(dataTable, "OFFSETK");
                dataTable = HelperClassLib.GetDataFromHelper.GetDataFromCSV(Environment.CurrentDirectory + @"\Data\OFFSETNK.csv");
                LoadReceipeTables(dataTable, "OFFSETNK");
                dataTable = HelperClassLib.GetDataFromHelper.GetDataFromCSV(Environment.CurrentDirectory + @"\Data\AEPARAMETER.csv");
                LoadReceipeTables(dataTable, "AEPARAMETER");
                dataTable = HelperClassLib.GetDataFromHelper.GetDataFromCSV(Environment.CurrentDirectory + @"\Data\DELAY.csv");
                LoadReceipeTables(dataTable, "DELAY");
                dataTable = HelperClassLib.GetDataFromHelper.GetDataFromCSV(Environment.CurrentDirectory + @"\Data\SFC_PDCA_Data.csv");
                LoadReceipeTables(dataTable, "SFC_PDCA_Data");
                dataTable = HelperClassLib.GetDataFromHelper.GetDataFromCSV(Environment.CurrentDirectory + @"\Data\Feeder_Min_Max.csv");
                LoadReceipeTables(dataTable, "Feeder_Min_Max");
            }
            catch (Exception ex)
            {
                Logger.WriteLog(Logger.LogType.Error, "GlobalVariable", "", ex.Message, ex.ToString());
            }
        }
        public static void LoadReceipeTables(DataTable dt, string Gantry)
        {
            try
            {


                if (Gantry.ToUpper() == "SCANNERMODULE")
                {
                    int totalPositions = dt.Rows.Count;

                    // Decide on your grid layout (e.g., 4x3 for 12 positions)
                    int cols = GlobalVariable.CavityCols;  // number of columns you want
                    int rows = (int)Math.Ceiling(totalPositions / (double)cols);

                    scannerCnvPositions = new Position[GlobalVariable.CavityRows, cols];

                    for (int index = 0; index < totalPositions; index++)
                    {
                        DataRow row = dt.Rows[index];

                        double GetDouble(object value)
                        {
                            if (value == null || value == DBNull.Value) return 0.0;
                            if (double.TryParse(value.ToString(), out double result))
                                return result;
                            return 0.0;
                        }

                        Position pos = new Position
                        {

                            PositionX = GetDouble(row["col(X)"]),
                            XVel = GetDouble(row["X-Vel (mm)"]),
                            XAcc = GetDouble(row["X Acc (mm/s)"]),
                            XDeAcc = GetDouble(row["X DeAcc"]),
                            PositionY = GetDouble(row["Row(Y)"]),
                            YVel = GetDouble(row["Y-Vel (mm)"]),
                            YAcc = GetDouble(row["Y Acc (mm/s)"]),
                            YDeAcc = GetDouble(row["Y DeAcc"]),

                        };

                        int rowIdx = index / cols;
                        int colIdx = index % cols;
                        string Name = row["Position"]?.ToString()?.Trim() ?? "";

                        switch (Name)
                        {
                            case "Home":
                                //X1_home = pos;
                                break;
                            case "Carrier Barcode":
                                scan_Carrier_Barcode = pos;
                                break;
                            default:
                                //Arulkumar Fixed random stoppage start
                                //Reason:
                                //Root Cause: LoadPositions accessed an array using an invalid index.
                                //Fix: Added the minimum required bounds protection at the existing access point.
                                if (scannerCnvPositions != null
                                    && rowIdx >= 0 && rowIdx < scannerCnvPositions.GetLength(0)
                                    && colIdx >= 0 && colIdx < scannerCnvPositions.GetLength(1))
                                {
                                    scannerCnvPositions[rowIdx, colIdx] = pos;
                                }
                                else
                                {
                                    int maxR = scannerCnvPositions != null ? scannerCnvPositions.GetLength(0) - 1 : -1;
                                    int maxC = scannerCnvPositions != null ? scannerCnvPositions.GetLength(1) - 1 : -1;
                                    Logger.WriteLog(Logger.LogType.Error, "GlobalVariable_MachineSpecific", "LoadPositions",
                                        $"Array:scannerCnvPositions Index:[{rowIdx},{colIdx}] Valid:[0..{maxR},0..{maxC}] Cavity:{Name} Row:{rowIdx} Column:{colIdx} Step:LoadReceipeTables/{Gantry}",
                                        "");
                                }
                                //Arulkumar Fixed random stoppage end

                                break;
                        }

                    }
                }
                else if (Gantry.ToUpper() == "WK1MODULE")
                {
                    int totalPositions = dt.Rows.Count;

                    // Decide on your grid layout (e.g., 4x3 for 12 positions)
                    int cols = GlobalVariable.CavityCols;  // number of columns you want
                    int rows = (int)Math.Ceiling(totalPositions / (double)cols);

                    WK1Positions = new Position[GlobalVariable.CavityRows, cols];

                    for (int index = 0; index < totalPositions; index++)
                    {
                        DataRow row = dt.Rows[index];

                        try
                        {
                            double GetDouble(object value)
                            {
                                if (value == null || value == DBNull.Value) return 0.0;
                                if (double.TryParse(value.ToString(), out double result))
                                    return result;
                                return 0.0;
                            }
                            int rowIdx = index / cols;
                            int colIdx = index % cols;
                            string Name = row["Position"]?.ToString()?.Trim() ?? "";

                            Position pos = new Position
                            {

                                row = rowIdx,
                                col = colIdx,
                                PositionX = GetDouble(row["Col(X)"]),
                                XVel = GetDouble(row["X-Vel (mm)"]),
                                XAcc = GetDouble(row["X Acc (mm/s)"]),
                                XDeAcc = GetDouble(row["X DeAcc"]),
                                PositionY = GetDouble(row["Row(Y)"]),
                                YVel = GetDouble(row["Y-Vel (mm)"]),
                                YAcc = GetDouble(row["Y Acc (mm/s)"]),
                                YDeAcc = GetDouble(row["Y DeAcc"]),
                                PositionZ1 = GetDouble(row["Z1"]),
                                PositionZ2 = GetDouble(row["Z2"]),
                                ZVel = GetDouble(row["Z-Vel (mm)"]),
                                ZAcc = GetDouble(row["Z Acc (mm/s)"]),
                                ZDeAcc = GetDouble(row["Z DeAcc"]),
                                PositionR1 = GetDouble(row["R1"]),
                                PositionR2 = GetDouble(row["R2"]),
                                RVel = GetDouble(row["R-Vel (mm)"]),
                                RAcc = GetDouble(row["R Acc (mm/s)"]),
                                RDeAcc = GetDouble(row["R DeAcc"]),
                                CavityX = GetDouble(row["CavityX"]),
                                CavityY = GetDouble(row["CavityY"]),
                                PreXVel = GetDouble(row["X-PreVel (mm)"]),
                                PreXAcc = GetDouble(row["X PreAcc (mm/s)"]),
                                PreXDeAcc = GetDouble(row["X PreDeAcc"]),
                                PreYAcc = GetDouble(row["Y PreAcc (mm/s)"]),
                                PreYVel = GetDouble(row["Y-PreVel (mm)"]),
                                PreYDeAcc = GetDouble(row["Y PreDeAcc"])
                            };



                            switch (Name)
                            {
                                case "Feeding Z1Position1":
                                    Wk1_Z1FedPos = pos;
                                    break;
                                case "Feeding Z2Position2":
                                    Wk1_Z2FedPos = pos;
                                    break;
                                case "Feeding Z1Position2":
                                    Wk1_Z1FedPos2 = pos;
                                    break;
                                case "Feeding Z2Position1":
                                    Wk1_Z2FedPos1 = pos;
                                    break;
                                case "Feeding Z1Position3":
                                    Wk1_Z1FedPos3 = pos;
                                    break;
                                case "Feeding Z1Position4":
                                    Wk1_Z1FedPos4 = pos;
                                    break;
                                case "Feeding Z2Position3":
                                    Wk1_Z2FedPos3 = pos;
                                    break;
                                case "Feeding Z2Position4":
                                    Wk1_Z2FedPos4 = pos;
                                    break;
                                case "CCD2 Z1position":
                                    Wk1_Z1CCD2pos = pos;
                                    break;
                                case "CCD2 Z2position":
                                    Wk1_Z2CCD2pos = pos;
                                    break;
                                case "initial position":
                                    WK1_initial = pos;
                                    break;
                                case "RejectionPlace":
                                    Wk1_Rejpos = pos;
                                    break;
                                case "Safe Position":
                                    SafePosition = pos;
                                    //GlobalVariable.Z2SafePos = Convert.ToInt32(row["Z2"]);
                                    //GlobalVariable.Z2Accdec = Convert.ToInt32(row["Z Acc (mm/s)"]);
                                    //GlobalVariable.Z2Speed = Convert.ToInt32(row["Z-Vel (mm)"]);
                                    break;

                                //case "Z_Delay":
                                //    GlobalVariable.Z_Delay = Convert.ToInt32(row["Col(X)"]);
                                //    break;

                                //case "Stopper_loading_Time":
                                //    GlobalVariable.Stopper_loading_Time = Convert.ToInt32(row["Col(X)"]);
                                //    break;

                                //case "Stopper_Working_Time":
                                //    GlobalVariable.Stopper_Working_Time = Convert.ToInt32(row["Col(X)"]);
                                //    break;

                                //case "Stopper_Recheck_Time":
                                //    GlobalVariable.Stopper_Recheck_Time = Convert.ToInt32(row["Col(X)"]);
                                //    break;
                                default:
                                    //Arulkumar Fixed random stoppage start
                                    //Reason:
                                    //Root Cause: LoadPositions accessed an array using an invalid index.
                                    //Fix: Added the minimum required bounds protection at the existing access point.
                                    if (WK1Positions != null
                                        && rowIdx >= 0 && rowIdx < WK1Positions.GetLength(0)
                                        && colIdx >= 0 && colIdx < WK1Positions.GetLength(1))
                                    {
                                        WK1Positions[rowIdx, colIdx] = pos;
                                    }
                                    else
                                    {
                                        int maxR = WK1Positions != null ? WK1Positions.GetLength(0) - 1 : -1;
                                        int maxC = WK1Positions != null ? WK1Positions.GetLength(1) - 1 : -1;
                                        Logger.WriteLog(Logger.LogType.Error, "GlobalVariable_MachineSpecific", "LoadPositions",
                                            $"Array:WK1Positions Index:[{rowIdx},{colIdx}] Valid:[0..{maxR},0..{maxC}] Cavity:{Name} Row:{rowIdx} Column:{colIdx} Step:LoadReceipeTables/{Gantry}",
                                            "");
                                    }
                                    //Arulkumar Fixed random stoppage end

                                    break;
                            }
                        }
                        catch (Exception ex)
                        {
                            //Arulkumar Fixed random stoppage start
                            Logger.WriteLog(Logger.LogType.Error, "GlobalVariable_MachineSpecific", "LoadPositions", ex.Message, ex.ToString());
                            //Arulkumar Fixed random stoppage end
                        }

                    }


                }
                else if (Gantry.ToUpper() == "WK2MODULE")
                {
                    int totalPositions = dt.Rows.Count;

                    // Decide on your grid layout (e.g., 4x3 for 12 positions)
                    int cols = GlobalVariable.CavityCols;  // number of columns you want
                    int rows = (int)Math.Ceiling(totalPositions / (double)cols);

                    Wk2Positions = new Position[GlobalVariable.CavityRows, cols];

                    for (int index = 0; index < totalPositions; index++)
                    {
                        DataRow row = dt.Rows[index];

                        double GetDouble(object value)
                        {
                            if (value == null || value == DBNull.Value) return 0.0;
                            if (double.TryParse(value.ToString(), out double result))
                                return result;
                            return 0.0;
                        }

                        Position pos = new Position
                        {

                            PositionX = GetDouble(row["Col(X)"]),
                            XVel = GetDouble(row["X-Vel (mm)"]),
                            XAcc = GetDouble(row["X Acc (mm/s)"]),
                            XDeAcc = GetDouble(row["X DeAcc"]),
                            PositionY = GetDouble(row["Row(Y)"]),
                            YVel = GetDouble(row["Y-Vel (mm)"]),
                            YAcc = GetDouble(row["Y Acc (mm/s)"]),
                            YDeAcc = GetDouble(row["Y DeAcc"]),

                        };

                        int rowIdx = index / cols;
                        int colIdx = index % cols;
                        string Name = row["Position"]?.ToString()?.Trim() ?? "";

                        switch (Name)
                        {

                            case "initial position":
                                Wk2_initial = pos;
                                break;
                            default:
                                //Arulkumar Fixed random stoppage start
                                //Reason:
                                //Root Cause: LoadPositions accessed an array using an invalid index.
                                //Fix: Added the minimum required bounds protection at the existing access point.
                                if (Wk2Positions != null
                                    && rowIdx >= 0 && rowIdx < Wk2Positions.GetLength(0)
                                    && colIdx >= 0 && colIdx < Wk2Positions.GetLength(1))
                                {
                                    Wk2Positions[rowIdx, colIdx] = pos;
                                }
                                else
                                {
                                    int maxR = Wk2Positions != null ? Wk2Positions.GetLength(0) - 1 : -1;
                                    int maxC = Wk2Positions != null ? Wk2Positions.GetLength(1) - 1 : -1;
                                    Logger.WriteLog(Logger.LogType.Error, "GlobalVariable_MachineSpecific", "LoadPositions",
                                        $"Array:Wk2Positions Index:[{rowIdx},{colIdx}] Valid:[0..{maxR},0..{maxC}] Cavity:{Name} Row:{rowIdx} Column:{colIdx} Step:LoadReceipeTables/{Gantry}",
                                        "");
                                }
                                //Arulkumar Fixed random stoppage end

                                break;
                        }

                    }
                }
                else if (Gantry == "Nozzle1")
                {
                    int totalPositions = dt.Rows.Count;

                    // Decide on your grid layout (e.g., 4x3 for 12 positions)
                    int cols = GlobalVariable.CavityCols;  // number of columns you want
                    int rows = (int)Math.Ceiling(totalPositions / (double)cols);
                    for (int index = 0; index < totalPositions; index++)
                    {
                        DataRow row = dt.Rows[index];

                        double GetDouble(object value)
                        {
                            if (value == null || value == DBNull.Value) return 0.0;
                            if (double.TryParse(value.ToString(), out double result))
                                return result;
                            return 0.0;
                        }

                        Position pos = new Position
                        {


                            PositionX = GetDouble(row["col(X)"]),
                            XVel = GetDouble(row["X-Vel (mm)"]),
                            XAcc = GetDouble(row["X Acc (mm/s)"]),
                            XDeAcc = GetDouble(row["X DeAcc"]),
                            PositionY = GetDouble(row["Row(Y)"]),
                            YVel = GetDouble(row["Y-Vel (mm)"]),
                            YAcc = GetDouble(row["Y Acc (mm/s)"]),
                            YDeAcc = GetDouble(row["Y DeAcc"]),
                            PositionZ1 = GetDouble(row["Z1"]),
                            ZVel = GetDouble(row["Z-Vel (mm)"]),
                            ZAcc = GetDouble(row["Z Acc (mm/s)"]),
                            ZDeAcc = GetDouble(row["Z DeAcc"]),
                            PositionR1 = GetDouble(row["R1"]),
                            RVel = GetDouble(row["R-Vel (mm)"]),
                            RAcc = GetDouble(row["RAcc (mm/s)"]),
                            RDeAcc = GetDouble(row["R DeAcc"])

                        };

                        int rowIdx = index / cols;
                        int colIdx = index % cols;
                        string Name = row["Position"]?.ToString()?.Trim() ?? "";

                        switch (Name)
                        {

                            case "cavity Photo":
                                Photo_Z1 = pos;
                                break;
                            case "cavity Position":
                                pickup_loc_Z1 = pos;
                                break;
                            case "Nozzle Location":
                                Nozzle_loc_Z1 = pos;
                                break;
                            case "Feeder position":
                                feddrop_loc_Z1 = pos;
                                break;


                        }

                    }
                }
                else if (Gantry == "Nozzle2")
                {
                    try
                    {
                        int totalPositions = dt.Rows.Count;

                        // Decide on your grid layout (e.g., 4x3 for 12 positions)
                        int cols = GlobalVariable.CavityCols;  // number of columns you want
                        int rows = (int)Math.Ceiling(totalPositions / (double)cols);

                        for (int index = 0; index < totalPositions; index++)
                        {
                            DataRow row = dt.Rows[index];

                            double GetDouble(object value)
                            {
                                if (value == null || value == DBNull.Value) return 0.0;
                                if (double.TryParse(value.ToString(), out double result))
                                    return result;
                                return 0.0;
                            }

                            Position pos = new Position
                            {


                                PositionX = GetDouble(row["col(X)"]),
                                XVel = GetDouble(row["X-Vel (mm)"]),
                                XAcc = GetDouble(row["X Acc (mm/s)"]),
                                XDeAcc = GetDouble(row["X DeAcc"]),
                                PositionY = GetDouble(row["Row(Y)"]),
                                YVel = GetDouble(row["Y-Vel (mm)"]),
                                YAcc = GetDouble(row["Y Acc (mm/s)"]),
                                YDeAcc = GetDouble(row["Y DeAcc"]),
                                PositionZ2 = GetDouble(row["Z2"]),
                                ZVel = GetDouble(row["Z-Vel (mm)"]),
                                ZAcc = GetDouble(row["Z Acc (mm/s)"]),
                                ZDeAcc = GetDouble(row["Z DeAcc"]),
                                PositionR2 = GetDouble(row["R2"]),
                                RVel = GetDouble(row["R-Vel (mm)"]),
                                RAcc = GetDouble(row["RAcc (mm/s)"]),
                                RDeAcc = GetDouble(row["R DeAcc"])


                            };

                            int rowIdx = index / cols;
                            int colIdx = index % cols;
                            string Name = row["Position"]?.ToString()?.Trim() ?? "";

                            switch (Name)
                            {

                                case "cavity Photo":
                                    Photo_z2 = pos;
                                    break;
                                case "cavity Position":
                                    pickup_loc_Z2 = pos;
                                    break;
                                case "Nozzle Location":
                                    Nozzle_loc_Z2 = pos;
                                    break;
                                case "Feeder position":
                                    feddrop_loc_Z2 = pos;
                                    break;
                                case "Train Nozzle":
                                    break;
                                case "Distance":
                                    break;
                                case "Angle":
                                    break;

                            }

                        }
                    }
                    catch (Exception ex)
                    {
                        //Arulkumar Fixed random stoppage start
                        Logger.WriteLog(Logger.LogType.Error, "GlobalVariable_MachineSpecific", "LoadPositions", ex.Message, ex.ToString());
                        //Arulkumar Fixed random stoppage end
                    }


                }
                else if (Gantry == "Nozzle1_TrainParam")
                {
                    try
                    {
                        int totalPositions = dt.Rows.Count;

                        // Decide on your grid layout (e.g., 4x3 for 12 positions)
                        int cols = GlobalVariable.CavityCols;  // number of columns you want
                        int rows = (int)Math.Ceiling(totalPositions / (double)cols);
                        for (int index = 0; index < totalPositions; index++)
                        {
                            DataRow row = dt.Rows[index];

                            double GetDouble(object value)
                            {
                                if (value == null || value == DBNull.Value) return 0.0;
                                if (double.TryParse(value.ToString(), out double result))
                                    return result;
                                return 0.0;
                            }

                            Position pos = new Position
                            {


                                PositionX = GetDouble(row["col(X)"]),
                                XVel = GetDouble(row["X-Vel (mm)"]),
                                XAcc = GetDouble(row["X Acc (mm/s)"]),
                                XDeAcc = GetDouble(row["X DeAcc"]),
                                PositionY = GetDouble(row["Row(Y)"]),
                                YVel = GetDouble(row["Y-Vel (mm)"]),
                                YAcc = GetDouble(row["Y Acc (mm/s)"]),
                                YDeAcc = GetDouble(row["Y DeAcc"]),
                                PositionZ1 = GetDouble(row["Z1"]),
                                ZVel = GetDouble(row["Z-Vel (mm)"]),
                                ZAcc = GetDouble(row["Z Acc (mm/s)"]),
                                ZDeAcc = GetDouble(row["Z DeAcc"]),
                                PositionR1 = GetDouble(row["R1"]),
                                RVel = GetDouble(row["R-Vel (mm)"]),
                                RAcc = GetDouble(row["RAcc (mm/s)"]),
                                RDeAcc = GetDouble(row["R DeAcc"])


                            };

                            int rowIdx = index / cols;
                            int colIdx = index % cols;
                            string Name = row["Position"]?.ToString()?.Trim() ?? "";

                            switch (Name)
                            {


                                case "Nozzle Location":
                                    TrainNozzle1 = pos;
                                    break;

                                default:

                                    break;
                            }

                        }
                    }
                    catch (Exception ex)
                    {
                        //Arulkumar Fixed random stoppage start
                        Logger.WriteLog(Logger.LogType.Error, "GlobalVariable_MachineSpecific", "LoadPositions", ex.Message, ex.ToString());
                        //Arulkumar Fixed random stoppage end
                    }
                }

                else if (Gantry == "Nozzle2_TrainParam")
                {
                    try
                    {
                        int totalPositions = dt.Rows.Count;

                        // Decide on your grid layout (e.g., 4x3 for 12 positions)
                        int cols = GlobalVariable.CavityCols;  // number of columns you want
                        int rows = (int)Math.Ceiling(totalPositions / (double)cols);
                        for (int index = 0; index < totalPositions; index++)
                        {
                            DataRow row = dt.Rows[index];

                            double GetDouble(object value)
                            {
                                if (value == null || value == DBNull.Value) return 0.0;
                                if (double.TryParse(value.ToString(), out double result))
                                    return result;
                                return 0.0;
                            }

                            Position pos = new Position
                            {


                                PositionX = GetDouble(row["col(X)"]),
                                XVel = GetDouble(row["X-Vel (mm)"]),
                                XAcc = GetDouble(row["X Acc (mm/s)"]),
                                XDeAcc = GetDouble(row["X DeAcc"]),
                                PositionY = GetDouble(row["Row(Y)"]),
                                YVel = GetDouble(row["Y-Vel (mm)"]),
                                YAcc = GetDouble(row["Y Acc (mm/s)"]),
                                YDeAcc = GetDouble(row["Y DeAcc"]),
                                PositionZ2 = GetDouble(row["Z2"]),
                                ZVel = GetDouble(row["Z-Vel (mm)"]),
                                ZAcc = GetDouble(row["Z Acc (mm/s)"]),
                                ZDeAcc = GetDouble(row["Z DeAcc"]),
                                PositionR2 = GetDouble(row["R2"]),
                                RVel = GetDouble(row["R-Vel (mm)"]),
                                RAcc = GetDouble(row["RAcc (mm/s)"]),
                                RDeAcc = GetDouble(row["R DeAcc"])

                            };

                            int rowIdx = index / cols;
                            int colIdx = index % cols;
                            string Name = row["Position"]?.ToString()?.Trim() ?? "";

                            switch (Name)
                            {


                                case "Nozzle Location":
                                    TrainNozzle2 = pos;
                                    break;

                                default:

                                    break;
                            }
                        }


                    }
                    catch (Exception ex)
                    {
                        //Arulkumar Fixed random stoppage start
                        Logger.WriteLog(Logger.LogType.Error, "GlobalVariable_MachineSpecific", "LoadPositions", ex.Message, ex.ToString());
                        //Arulkumar Fixed random stoppage end
                    }
                }
                else if (Gantry == "Final")
                {
                    try
                    {
                        int totalPositions = dt.Rows.Count;

                        // Decide on your grid layout (e.g., 4x3 for 12 positions)
                        int cols = GlobalVariable.CavityCols;  // number of columns you want
                        int rows = (int)Math.Ceiling(totalPositions / (double)cols);
                        Wk2CalibPositions = new Position[GlobalVariable.CavityRows, cols];
                        for (int index = 0; index < totalPositions; index++)
                        {
                            DataRow row = dt.Rows[index];

                            double GetDouble(object value)
                            {
                                if (value == null || value == DBNull.Value) return 0.0;
                                if (double.TryParse(value.ToString(), out double result))
                                    return result;
                                return 0.0;
                            }

                            Position pos = new Position
                            {


                                PositionX = GetDouble(row["col(X)"]),
                                XVel = GetDouble(row["X-Vel (mm)"]),
                                XAcc = GetDouble(row["X Acc (mm/s)"]),
                                XDeAcc = GetDouble(row["X DeAcc"]),
                                PositionY = GetDouble(row["Row(Y)"]),
                                YVel = GetDouble(row["Y-Vel (mm)"]),
                                YAcc = GetDouble(row["Y Acc (mm/s)"]),
                                YDeAcc = GetDouble(row["Y DeAcc"]),


                            };

                            int rowIdx = index / cols;
                            int colIdx = index % cols;
                            string Name = row["Position"]?.ToString()?.Trim() ?? "";

                            //Arulkumar Fixed random stoppage start
                            //Reason:
                            //Root Cause: LoadPositions accessed an array using an invalid index.
                            //Fix: Added the minimum required bounds protection at the existing access point.
                            if (Wk2CalibPositions != null
                                && rowIdx >= 0 && rowIdx < Wk2CalibPositions.GetLength(0)
                                && colIdx >= 0 && colIdx < Wk2CalibPositions.GetLength(1))
                            {
                                Wk2CalibPositions[rowIdx, colIdx] = pos;
                            }
                            else
                            {
                                int maxR = Wk2CalibPositions != null ? Wk2CalibPositions.GetLength(0) - 1 : -1;
                                int maxC = Wk2CalibPositions != null ? Wk2CalibPositions.GetLength(1) - 1 : -1;
                                Logger.WriteLog(Logger.LogType.Error, "GlobalVariable_MachineSpecific", "LoadPositions",
                                    $"Array:Wk2CalibPositions Index:[{rowIdx},{colIdx}] Valid:[0..{maxR},0..{maxC}] Cavity:{Name} Row:{rowIdx} Column:{colIdx} Step:LoadReceipeTables/{Gantry}",
                                    "");
                            }
                            //Arulkumar Fixed random stoppage end



                        }
                    }
                    catch (Exception ex)
                    {
                        //Arulkumar Fixed random stoppage start
                        Logger.WriteLog(Logger.LogType.Error, "GlobalVariable_MachineSpecific", "LoadPositions", ex.Message, ex.ToString());
                        //Arulkumar Fixed random stoppage end
                    }
                }

                else if (Gantry == "OFFSET")
                {
                    try
                    {
                        int totalPositions = dt.Rows.Count;
                        offset = new OFFSET[20];

                        for (int index = 0; index < totalPositions; index++)
                        {
                            DataRow row = dt.Rows[index];

                            double GetDouble(object value)
                            {
                                if (value == null || value == DBNull.Value) return 0.0;
                                if (double.TryParse(value.ToString(), out double result))
                                    return result;
                                return 0.0;
                            }

                            OFFSET pos = new OFFSET
                            {


                                Xvalue = GetDouble(row["Xvalue"]),
                                Yvalue = GetDouble(row["Yvalue"]),
                                Rvalue = GetDouble(row["Rvalue"]),



                            };

                            //Arulkumar Fixed random stoppage start
                            //Reason:
                            //Root Cause: LoadPositions accessed an array using an invalid index.
                            //Fix: Added the minimum required bounds protection at the existing access point.
                            if (offset != null && index >= 0 && index < offset.Length)
                            {
                                offset[index] = pos;
                            }
                            else
                            {
                                int maxIdx = offset != null ? offset.Length - 1 : -1;
                                string Name = row["Name"]?.ToString()?.Trim() ?? "";
                                Logger.WriteLog(Logger.LogType.Error, "GlobalVariable_MachineSpecific", "LoadPositions",
                                    $"Array:offset Index:[{index}] Valid:[0..{maxIdx}] Cavity:{Name} Row:N/A Column:N/A Step:LoadReceipeTables/{Gantry}",
                                    "");
                            }
                            //Arulkumar Fixed random stoppage end



                        }
                    }
                    catch (Exception ex)
                    {
                        //Arulkumar Fixed random stoppage start
                        Logger.WriteLog(Logger.LogType.Error, "GlobalVariable_MachineSpecific", "LoadPositions", ex.Message, ex.ToString());
                        //Arulkumar Fixed random stoppage end
                    }
                }

                else if (Gantry == "OFFSETK")
                {
                    try
                    {
                        int totalPositions = dt.Rows.Count;
                        offsetK = new OFFSETK[20];

                        for (int index = 0; index < totalPositions; index++)
                        {
                            DataRow row = dt.Rows[index];

                            double GetDouble(object value)
                            {
                                if (value == null || value == DBNull.Value) return 0.0;
                                if (double.TryParse(value.ToString(), out double result))
                                    return result;
                                return 0.0;
                            }

                            OFFSETK pos = new OFFSETK
                            {


                                Xvalue = GetDouble(row["Xvalue"]),
                                Yvalue = GetDouble(row["Yvalue"]),
                                Rvalue = GetDouble(row["Rvalue"]),



                            };

                            //Arulkumar Fixed random stoppage start
                            //Reason:
                            //Root Cause: LoadPositions accessed an array using an invalid index.
                            //Fix: Added the minimum required bounds protection at the existing access point.
                            if (offsetK != null && index >= 0 && index < offsetK.Length)
                            {
                                offsetK[index] = pos;
                            }
                            else
                            {
                                int maxIdx = offsetK != null ? offsetK.Length - 1 : -1;
                                string Name = row["Name"]?.ToString()?.Trim() ?? "";
                                Logger.WriteLog(Logger.LogType.Error, "GlobalVariable_MachineSpecific", "LoadPositions",
                                    $"Array:offsetK Index:[{index}] Valid:[0..{maxIdx}] Cavity:{Name} Row:N/A Column:N/A Step:LoadReceipeTables/{Gantry}",
                                    "");
                            }
                            //Arulkumar Fixed random stoppage end



                        }
                    }
                    catch (Exception ex)
                    {
                        //Arulkumar Fixed random stoppage start
                        Logger.WriteLog(Logger.LogType.Error, "GlobalVariable_MachineSpecific", "LoadPositions", ex.Message, ex.ToString());
                        //Arulkumar Fixed random stoppage end
                    }
                }

                else if (Gantry == "OFFSETNK")
                {
                    try
                    {
                        int totalPositions = dt.Rows.Count;
                        offsetNK = new OFFSETNK[20];

                        for (int index = 0; index < totalPositions; index++)
                        {
                            DataRow row = dt.Rows[index];

                            double GetDouble(object value)
                            {
                                if (value == null || value == DBNull.Value) return 0.0;
                                if (double.TryParse(value.ToString(), out double result))
                                    return result;
                                return 0.0;
                            }

                            OFFSETNK pos = new OFFSETNK
                            {


                                Xvalue = GetDouble(row["Xvalue"]),
                                Yvalue = GetDouble(row["Yvalue"]),
                                Rvalue = GetDouble(row["Rvalue"]),



                            };

                            offsetNK[index] = pos;



                        }
                    }
                    catch (Exception ex) { }
                }

                else if (Gantry == "AEPARAMETER")
                {
                    try
                    {
                        int totalPositions = dt.Rows.Count;
                        AEParameters = new AEParameter[17];

                        for (int index = 0; index < totalPositions; index++)
                        {
                            DataRow row = dt.Rows[index];

                            double GetDouble(object value)
                            {
                                if (value == null || value == DBNull.Value) return 0.0;
                                if (double.TryParse(value.ToString(), out double result))
                                    return result;
                                return 0.0;
                            }

                            AEParameter pos = new AEParameter
                            {

                                LSL = GetDouble(row["LSL"]),
                                USL = GetDouble(row["USL"])
                            };

                            AEParameters[index] = pos;



                        }
                    }
                    catch (Exception ex) { }



                }

                else if (Gantry == "DELAY")
                {
                    try
                    {
                        int totalPositions = dt.Rows.Count;
                        delay = new DELAY[17];

                        for (int index = 0; index < totalPositions; index++)
                        {
                            DataRow row = dt.Rows[index];

                            double GetDouble(object value)
                            {
                                if (value == null || value == DBNull.Value) return 0.0;
                                if (double.TryParse(value.ToString(), out double result))
                                    return result;
                                return 0.0;
                            }

                            DELAY pos = new DELAY
                            {


                                Delay = GetDouble(row["Delay"]),



                            };

                            //GlobalVariable.Move_Timeout_error_Delay = Convert.ToDouble(delay[7].Delay);

                            delay[index] = pos;



                        }
                    }
                    catch (Exception ex) { }
                }

                else if (Gantry == "SFC_PDCA_Data")
                {
                    try
                    {
                        int totalPositions = dt.Rows.Count;
                        SFC_PDCA_Data = new SFC_PDCA_Data[17];

                        for (int index = 0; index < totalPositions; index++)
                        {
                            DataRow row = dt.Rows[index];

                            string GetString(object value)
                            {
                                if (value == null || value == DBNull.Value) return "";
                                // if (double.TryParse(value.ToString(), out double result))

                                return value.ToString();

                            }

                            SFC_PDCA_Data pos = new SFC_PDCA_Data
                            {

                                //Station_Id = GetString(row["Station_Id"]),
                                Station_Id = GetString(row["Value"]),

                            };

                            SFC_PDCA_Data[index] = pos;



                        }
                    }
                    catch (Exception ex) { }



                }

                else if (Gantry == "Feeder_Min_Max")
                {
                    try
                    {
                        int totalPositions = dt.Rows.Count;
                        Feeder_MinMax = new FEEDER_SAFE[17];

                        for (int index = 0; index < totalPositions; index++)
                        {
                            DataRow row = dt.Rows[index];

                            double GetDouble(object value)
                            {
                                if (value == null || value == DBNull.Value) return 0.0;
                                if (double.TryParse(value.ToString(), out double result))
                                    return result;
                                return 0.0;
                            }

                            FEEDER_SAFE pos = new FEEDER_SAFE
                            {


                                Y1_Min = GetDouble(row["Y1_Min"]),
                                X1_Min = GetDouble(row["X1_Min"]),
                                X1_Max = GetDouble(row["X1_Max"]),



                            };

                            //Arulkumar Fixed random stoppage start
                            //Reason:
                            //Root Cause: LoadPositions accessed an array using an invalid index.
                            //Fix: Added the minimum required bounds protection at the existing access point.
                            if (Feeder_MinMax != null && index >= 0 && index < Feeder_MinMax.Length)
                            {
                                Feeder_MinMax[index] = pos;
                            }
                            else
                            {
                                int maxIdx = Feeder_MinMax != null ? Feeder_MinMax.Length - 1 : -1;
                                string Name = row["Name"]?.ToString()?.Trim() ?? "";
                                Logger.WriteLog(Logger.LogType.Error, "GlobalVariable_MachineSpecific", "LoadPositions",
                                    $"Array:offset Index:[{index}] Valid:[0..{maxIdx}] Cavity:{Name} Row:N/A Column:N/A Step:LoadReceipeTables/{Gantry}",
                                    "");
                            }
                            //Arulkumar Fixed random stoppage end



                        }
                    }
                    catch (Exception ex)
                    {
                        //Arulkumar Fixed random stoppage start
                        Logger.WriteLog(Logger.LogType.Error, "GlobalVariable_MachineSpecific", "LoadPositions", ex.Message, ex.ToString());
                        //Arulkumar Fixed random stoppage end
                    }
                }


            }
            catch (Exception ex)
            {
                Logger.WriteLog(Logger.LogType.Error, "GlobalVariable", "", ex.Message, ex.ToString());
            }
        }
        #endregion
    }
}
