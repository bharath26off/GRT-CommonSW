using Advantech;
using DIO;
using ExceptionLib;
//using GRT_BG1.Data;
//using GRT_BG1.GlobalVar;
using Program;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Windows.Forms;
using System.Xml;
using UI.UI_Forms;
using static DIO.DIDO;
using static ExceptionLib.ErrorManage;

namespace MasterProject.GlobalClass
{
    public class GlobalVariable
    {

        public static bool PopubActive = false;
        public static int _Error_code = 0;
        public static string AckTime = string.Empty;
        public static int _Ack_errcode = 0;
        public static string Category = string.Empty;
        public static bool InvokeRequired = false;
        public static readonly string AlarmFileExtension = "csv";
        public static string xmlAlarmNode = "//Alarm//AlarmDetails";
        public static bool g_bAlarm = false;
        private static bool _alarmHandlersInitialized = false;
        public static bool _PopupRequired = false;



        /// All the available threads in the application
        /// </summary>
        public static List<System.Threading.Timer> g_threadList = new List<System.Threading.Timer>();

        //public static XDocument doc = XDocument.Load(ConfigurationManager.AppSettings["ConfigFilePath"]);
        //public static string SQL_SqlConnectionString = doc.Element("Configuration").Element("Database").Element("ConnectionString").Value;        

        public static string delimiter = ConfigurationManager.AppSettings["Delimiter"];

        public static float OrginalFormWidth = 1024;
        public static float OrginalFormHeight = 768;

        

        public static DIDO DIDO = new DIDO();
        public static Advantech_PCIE ComObj = new Advantech_PCIE(0, "ComObj");

        public static ExceptionLib.ErrorManage s = new ExceptionLib.ErrorManage();

        // Here Array Count  need to pass based on the Input Count for Both DI and DO
        public static bool[] DI;
        public static bool[] DO;

        public static List<IOParam> lstInputConfig = new List<IOParam>();
        public static List<IOParam> lstOutputConfig = new List<IOParam>();
        public static List<AxisParam> g_lstAxisConfig = new List<AxisParam>();
        /// <summary>
        /// Alarm information list
        /// </summary>
        public static List<ErrorManage> g_lstAlarmInfo = new List<ErrorManage>();
        /// <summary>
        /// Software running address
        /// </summary>
        public static string g_sAppPath = Application.StartupPath;

        public static string RunningLogPath = string.Empty;
        public static string CurrentShift = string.Empty;

        public static double[] AInput = new double[10];



        public static void ReadAIValue()
        {
            try
            {
                ObjectList.X1.RefreshAISetup(true);
                AInput = ObjectList.X1.RefreshAIvalues();
            }
            catch(Exception ex)
            { 
            
            }
        }

        public static void ResizeAllControls(Control parent, float xRatio, float yRatio)
        {            
                try
                {
                    foreach (Control ctrl in parent.Controls)
                    {
                        if (ctrl.AccessibilityObject.Role.ToString().ToUpper().Contains("COMBOBOX"))
                        {
                            System.Windows.Forms.ComboBox cmbctrl;
                            cmbctrl = new System.Windows.Forms.ComboBox();
                            cmbctrl = (ComboBox)ctrl;
                            cmbctrl.SelectedIndex = 0;
                            cmbctrl.DropDownStyle = ComboBoxStyle.DropDownList;
                        }
                        ctrl.Left = (int)(ctrl.Left * xRatio);
                        ctrl.Top = (int)(ctrl.Top * yRatio);
                        ctrl.Width = (int)(ctrl.Width * xRatio);
                        ctrl.Height = (int)(ctrl.Height * yRatio);
                        if (ctrl.HasChildren)
                        {
                            ResizeAllControls(ctrl, xRatio, yRatio);
                        }
                    }
                }
                catch (Exception)
                {

                    throw;
                }
        }
        public static void ShowAlarmMessage(int ErrCode, string Description)
        {
            try
            {

                AlarmPopup Almsg = new AlarmPopup(ErrCode, Description);
                Almsg.ShowDialog();
            }
            catch (Exception)
            {

                throw;
            }
        }
        /// <summary>
        /// Read alarm code
        /// </summary>
        public static bool LoadAlarmCode()
        {
            try
            {
                g_lstAlarmInfo.Clear();           
                #region  Import alarm file contents
                List<ErrorManage> AlarmInfoTempList = new List<ErrorManage>();
                XmlDocument xmlConfig = new XmlDocument();
                XmlElement xmlElement;
                XmlNodeList xmlNodes;
                if (AlarmFileExtension == "csv")
                {
                    List<String[]> ls = new List<String[]>();
                    StreamReader fileReader = new StreamReader(g_sAppPath + @"\Data\AlarmInfo.csv", System.Text.Encoding.Default);
                    string strLine = "";
                    while (strLine != null)
                    {
                        strLine = fileReader.ReadLine();
                        if (strLine != null && strLine.Length > 0)
                        {
                            ls.Add(strLine.Split(','));
                        }
                    }

                    fileReader.Close();
                    for (int i = 1; i < ls.Count; i++)
                    {
                        if (ls[i].Length >= 5)
                        {
                            ErrorManage TempInfo = new ErrorManage();
                            TempInfo.AlarmCode = ls[i][1];
                            TempInfo.AlarmGroup = ls[i][2];
                            TempInfo.AlarmMessage = ls[i][3];
                            TempInfo.AlarmContent = ls[i][4];
                            AlarmInfoTempList.Add(TempInfo);
                        }

                    }
                }
                else
                {
                    if (File.Exists(Environment.CurrentDirectory + @"\Data\Config.xml"))
                    {
                        xmlConfig.Load(Environment.CurrentDirectory + @"\Data\Config.xml");

                        if (xmlConfig != null)
                        {
                            xmlElement = xmlConfig.DocumentElement;
                            xmlNodes = xmlElement.SelectNodes(xmlAlarmNode);
                            if (xmlNodes != null)
                            {
                                foreach (XmlNode node in xmlNodes)
                                {
                                    if (node.Attributes != null)
                                    {
                                        ErrorManage tempInfo = new ErrorManage();
                                        tempInfo.AlarmCode = node.Attributes["AlarmCode"].Value;
                                        tempInfo.AlarmGroup = node.Attributes["AlarmGroup"].Value;
                                        tempInfo.AlarmMessage = node.Attributes["AlarmMessage"].Value;
                                        tempInfo.AlarmContent = node.Attributes["AlarmComment"].Value;
                                        AlarmInfoTempList.Add(tempInfo);
                                    }
                                }
                            }
                        }
                    }
                }
                #endregion

                #region Reorder by project enumeration definition

                if (AlarmInfoTempList.Count < ((int)DIDO.ECode.TotalAlarm))
                {
                    MessageBox.Show("AlarmInfo The number of file alarm message definitions is insufficient.", "hint", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);
                    return false;
                }
                else
                {
                    bool bFind = false;
                    string sLackMsg = "";

                    for (int i = 0; i < ((int)DIDO.ECode.TotalAlarm); i++)
                    {
                        bFind = false;
                        for (int j = 0; j < AlarmInfoTempList.Count; j++)
                        {
                            if (AlarmInfoTempList[j].AlarmMessage.Trim() == (DIDO.ECode.Start + i + 1).ToString())
                            {
                                g_lstAlarmInfo.Add(AlarmInfoTempList[j]);
                                bFind = true;
                                break;
                            }
                        }

                        if (!bFind)
                        {
                            sLackMsg += (DIDO.ECode.Start + i + 1).ToString() + "\n";
                        }
                        
                    }
                    //foreach (var alarm in g_lstAlarmInfo)
                    //{
                    //    // initialize the Alarm show popup funcion    
                    //    alarm.AlarmShowPopUp += ErrorManage_AlarmShowPopUp;

                    //}
                    if (g_lstAlarmInfo.Count < ((int)DIDO.ECode.TotalAlarm))
                    {
                        MessageBox.Show("AlarmInfoThe number of valid definitions of file alarm information is insufficient and missing：\n" + sLackMsg, "hint", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);
                        return false;
                    }
                }
                #endregion

            }
            catch (Exception e)
            {
                MessageBox.Show("LoadAlarmCode()\r\nReport an error:" + e.Message + "\n\r\nPlease reopen the software", "hint", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);
                return false;
            }
            finally
            {

            }
            return true;
        }
        
        /// <summary>
        /// Trigger the Alarm based on the User Input with alarmpopup or without alarm popup
        /// <param name="eCode">Pass the Error Code .</param>
        /// <param name="_bMotion">pass as a alarm happend true</param>
        /// <param name="type">type pass as a "Zero" means without popup alarm log in logfile and added in SQL
        /// pass as "1" means with popup and log in LiveAlarm also stored in SQL</param>
        /// <param name="pollIntervalMs">interval for timesec</param>
        /// </summary>
        public static void AlarmTrigger(ECode eCode, bool _bMotion, int type)
        {
            try
            {
                g_bAlarm = true;
                if (type == 0)
                {
                    _PopupRequired = false; 
                    g_lstAlarmInfo[(int)eCode].AlarmHappen = _bMotion;
                }
                else if (type == 1)
                {
                    _PopupRequired = true;
                    GlobalVariable.g_lstAlarmInfo[(int)eCode].AlarmHappen = _bMotion;
                    var popup = new AlarmPopup(Convert.ToInt32((int)eCode), GlobalVariable.g_lstAlarmInfo[(int)eCode].AlarmMessage, DateTime.Now);
                    popup.ShowDialog();
                    popup.Focus();
                }
                g_lstAlarmInfo[(int)eCode].Alarm_AddInfo(HomeScreen.ShiftLAble, g_lstAlarmInfo[(int)eCode].AlarmMessage, g_lstAlarmInfo[(int)eCode].AlarmCode, true);
            }
            catch (Exception ex)
            {
                Logger.WriteLog(Logger.LogType.Error, "GlobalVariable", "AlarmTrigger", ex.Message, ex.ToString());
            }
        }



        public void ResetAllAlarms()
        {
            try
            {
                foreach (var alarm in g_lstAlarmInfo)
                {
                    alarm.ResetAlarm();
                }
            }
            catch (Exception ex)
            {

            }
        }
        public GlobalVariable() { }

        ///<Summary>
        ///Properties variable for insert(into DB) the Ack error Alarm from alarm popup window.
        /// Need to write a code based on the MAchine
        ///</Summary>
        ///





        #region AXIS HELPERS

        public static EnumerableRowCollection<DataRow> stepperRows;
        public static EnumerableRowCollection<DataRow> ServoRows;
        private static readonly string filePath = Environment.CurrentDirectory + @"\Data\AxisList.Csv";
        public static DataTable LoadAxes()
        {
            DataTable ds = new DataTable();
            try
            {
                ds = HelperClassLib.GetDataFromHelper.GetDataFromCSV(filePath);
                GlobalVariable.stepperRows = ds.AsEnumerable()
                .Where(row => !string.IsNullOrWhiteSpace(row.Field<string>("Stepper")));
                GlobalVariable.ServoRows = ds.AsEnumerable()
               .Where(row => !string.IsNullOrWhiteSpace(row.Field<string>("Servo")));

                return ds;
            }
            catch (Exception ex)
            {
                return ds;
            }
        }
        #endregion


        #region RECEIPE SCREEN HELPERS


        //Receipe

       static int rows = 3;
       static int cols = 4;
        //public static position[,] posArray = new position[rows, cols];
        //public static position wk1_FeederPos = new position();
        //public static position wk1_CCD2Pos = new position();
        //public static position wk1_RejBin = new position();
        //public static CCD2Data[] cCD2Data = new CCD2Data[2];
        //public static position scan_home = new position();
        //public static position Carrier_Barcode = new position();
        //public static position wk1_home = new position();
        //public static position wk2_home = new position();
        public static double[] Receipe_Pressing_X = new double[2];
        public static double[] Receipe_Pressing_XVel = new double[2];
        public static double[] Receipe_Pressing_XAcc = new double[2];
        public static double[] Receipe_Pressing_XDeAcc = new double[2];
        public static double[] Receipe_Pressing_Z = new double[2];
        public static double[] Receipe_Pressing_ZVel = new double[2];
        public static double[] Receipe_Pressing_ZAcc = new double[2];
        public static double[] Receipe_Pressing_ZDeAcc = new double[2];
        public static double[] Receipe_Inspection_X = new double[9];
        public static double[] Receipe_Inspection_XVel = new double[9];
        public static double[] Receipe_Inspection_XAcc = new double[9];
        public static double[] Receipe_Inspection_XDeAcc = new double[9];
        public static double[] Receipe_Inspection_Y = new double[9];
        public static double[] Receipe_Inspection_YVel = new double[9];
        public static double[] Receipe_Inspection_YAcc = new double[9];
        public static double[] Receipe_Inspection_YDeAcc = new double[9];
        public static double[] Receipe_BTH = new double[15];
        public static double[] Receipe_BTHVel = new double[15];
        public static double[] Receipe_BTHAcc = new double[15];
        public static double[] Receipe_BTHDeAcc = new double[15];

        public static double Recipe_RoboSpeed;
        public static double Recipe_RoboPickDelay;
        public static double Recipe_RoboplaceDelay;

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
                dataTable = HelperClassLib.GetDataFromHelper.GetDataFromCSV(Environment.CurrentDirectory + @"\Data\RoboReceipe_Param.csv");
                LoadReceipeTables(dataTable, "ROBOT");
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
                if (Gantry.ToUpper() == "ROBOT")
                {
                    Recipe_RoboSpeed = Convert.ToDouble(dt.Rows[0][1].ToString());
                    Recipe_RoboPickDelay = Convert.ToDouble(dt.Rows[1][1].ToString());
                    Recipe_RoboplaceDelay = Convert.ToDouble(dt.Rows[2][1].ToString());
                }
                else
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        if (Gantry.ToUpper() == "SCANNERMODULE")
                        {
                            //DataRow rowData = dt.Rows[i];

                            //double GetDouble(object value)
                            //{
                            //    if (value == null || value == DBNull.Value) return 0.0;
                            //    return Convert.ToDouble(value);
                            //}

                            //position obj = new position
                            //{
                            //    x = GetDouble(rowData["X"]),
                            //    XVel = GetDouble(rowData[2]),
                            //    XAcc = GetDouble(rowData[3]),
                            //    XDeAcc = GetDouble(rowData[4]),

                            //    y = GetDouble(rowData["Y"]),
                            //    YVel = GetDouble(rowData[6]),
                            //    YAcc = GetDouble(rowData[7]),
                            //    YDeAcc = GetDouble(rowData[8]),

                            //    z = GetDouble(rowData["Z"]),
                            //    ZVel = GetDouble(rowData[10]),
                            //    ZAcc = GetDouble(rowData[11]),
                            //    ZDeAcc = GetDouble(rowData[12])
                            //};

                            //int row = i / cols;
                            //int col = i % cols;
                            //string pos = rowData["position"]?.ToString().Trim() ?? "";

                            //switch (pos)
                            //{
                            //    case "Home":
                            //        scan_home = obj;
                            //        break;
                            //    case "Carrier Barcode":
                            //        Carrier_Barcode = obj;
                            //        break;
                            //    default:
                            //        if (row < rows && col < cols)
                            //        {
                            //            posArray[row, col] = obj;
                            //        }
                            //        break;
                            //}


                        }
                        else if (Gantry.ToUpper() == "WK1MODULE")
                        {
                            Receipe_Inspection_X[i] = Convert.ToDouble(dt.Rows[i]["X"].ToString());
                            Receipe_Inspection_Y[i] = Convert.ToDouble(dt.Rows[i]["Y"].ToString());

                            Receipe_Inspection_XVel[i] = Convert.ToDouble(dt.Rows[i][2].ToString());
                            Receipe_Inspection_XAcc[i] = Convert.ToDouble(dt.Rows[i][3].ToString());
                            Receipe_Inspection_XDeAcc[i] = Convert.ToDouble(dt.Rows[i][4].ToString());

                            Receipe_Inspection_YVel[i] = Convert.ToDouble(dt.Rows[i][6].ToString());
                            Receipe_Inspection_YAcc[i] = Convert.ToDouble(dt.Rows[i][7].ToString());
                            Receipe_Inspection_YDeAcc[i] = Convert.ToDouble(dt.Rows[i][8].ToString());
                        }
                        else if (Gantry.ToUpper() == "WK1MODULE")
                        {
                            Receipe_BTH[i] = Convert.ToDouble(dt.Rows[i]["X"].ToString());

                            Receipe_BTHVel[i] = Convert.ToDouble(dt.Rows[i][2].ToString());
                            Receipe_BTHAcc[i] = Convert.ToDouble(dt.Rows[i][3].ToString());
                            Receipe_BTHDeAcc[i] = Convert.ToDouble(dt.Rows[i][4].ToString());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog(Logger.LogType.Error, "GlobalVariable", "", ex.Message, ex.ToString());
            }
        }
        #endregion



        #region DEVICE SETTINGS SCREEN HELPERS

        public static bool Safety_door_Bypass = false;
        public static bool Scanner_Bypass = false;
        public static bool Buzzer_Bypass = false;
        public static bool SFC_PDCA_Bypass = false;
        public static string Operation_Mode = "Production";


        //public static string TCP_IP_Setting_Path = Path.Combine(Environment.CurrentDirectory, "Data", "Settings", "TCPIP_Settings.xml");
        public static string TCP_IP_Setting_Path = Path.Combine(Environment.CurrentDirectory, "Data", "", "TCPIP_Settings.xml");


        #endregion



        public static int Ack_errcode
        {
            get
            {
                return _Ack_errcode;
            }
            set
            {

            }
        }

        public static void AllowOnlyDecimal_TextBox(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) &&
                !char.IsDigit(e.KeyChar) &&
                (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        public static void AllowOnlyNumber_TextBox(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
