using DIO;
using ExceptionLib;
using GRT_BG1.Data;
using GRT_BG1_V54.Function.CommonClass;
using HelperClassLib;
using Program;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using UI.UI_Forms;
using static DIO.DIDO;

namespace Master
{

    /*****************************************************************************
   *                     MASTER GLOBAL VARIABLES CONFIGURATION                  *
   ******************************************************************************/


    public partial class GlobalVariable
    {
        public static bool CCD4_Trigger_Fail = false;
        public static bool Working_Pallet_NotMoves = false;
        public static int PDCA_count_all_Updated = 0;
        public static bool loading_Pause = false;
        public static bool Z1_Pickedup = false;
        public static bool Z2_Pickedup = false;
        public static bool pause = false;
        public static bool tossingBuzzer = false;
        public static bool b_gHomingRunning = false;
        public static int Nozzletossing = 0;


        public static string Version = "V 1.10";

        public static double Servo_Y1_Min_N1 = 0;
        public static double Servo_X1_Min_N1 = 0;
        public static double Servo_X1_Max_N1 = 0;

        public static double Servo_Y1_Min_N2 = 0;
        public static double Servo_X1_Min_N2 = 0;
        public static double Servo_X1_Max_N2 = 0;



        public static double Z2SafePos = 0;
        public static double Z2Accdec = 0;
        public static double Z2Speed = 0;

        public static bool PopubActive = false;
        public static int _Error_code = 0;
        public static string AckTime = string.Empty;
        public static string Ack_errcode = string.Empty;

        public static string Category = string.Empty;
        public static bool InvokeRequired = false;
        public static readonly string AlarmFileExtension = "csv";
        public static string xmlAlarmNode = "//Alarm//AlarmDetails";
        public static bool g_bAlarm = false;
        public static bool _PopupRequired = false;
        public static bool g_CardInitSucc = false;
        public static bool b_EStop = false;
        public static bool b_gHomingDone = false;

        public static int Z_Delay = 0;

        public static int Stopper_loading_Time = 0;
        public static int Stopper_Working_Time = 0;
        public static int Stopper_Recheck_Time = 0;

        public static int Scanning_Exit_Sens_Delay = 0;
        public static int Working_Conv_1_Exit_Sens_Delay = 0;
        public static int Working_Conv_2_Exit_Sens_Delay = 0;
        public static int Barcode_Scanner_Recevier_Delay = 0;
        public static int Stopper_loader_Time = 0;
        public static string StationID;


        public static bool New_Pallet_Only = false;
        public static bool g_HomingDone = false;
        public static uint g_DOChanNum = 0;
        public static uint g_DIChanNum = 0;

        public static bool b_gDryRun = false;
        public static bool PDCARuning = false;
        public static bool b_gPRoduction = false;
        public static bool StaticMode_Cal = false;
        public static bool DynamicMode_Cal = false;
        public static bool b_gDummyRun = false;

        public static bool SFC_Mcmini_Wait = false;

        public static barcodeView[,] barcodeViewld;
        public static barcodeView[,] barcodeViewwk1;
        public static barcodeView[,] barcodeViewwk2;

        public static string[] cavitynum = new string[13];
        public static bool[] cavitynumcon = new bool[13];
        public static string[] cavitynumwkt1 = new string[13];
        public static int[] cavitynumwkt1con = new int[13];
        public static string[] cavitynumwkt2 = new string[13];
        public static bool[] cavitynumwkt2con = new bool[13];

        public static bool[] AxisHomingStatus;

        public static SqlHelper sqlHelperConn;
        public static string SQL_ConnStr;

        public static double txtstatic_XAxis = 0;
        public static double txtstatic_YAxis = 0;
        public static double txtstatic_ZAxis = 0;
        public static int RunningCount = 0;

        public static double txtDynamic_XAxis = 0;
        public static double txtDynamic_YAxis = 0;
        public static double txtDynamic_ZAxis = 0;
        public static double txtDynamic_RAxis = 0; // AK

        public static double txtDynamic_X1Axis = 0;
        public static double txtDynamic_Y1Axis = 0;
        public static double txtDynamic_Z1Axis = 0;
        public static int txtCounts_value = 0;
        public static int txtCavityPosition_value = 0;
        public static int txtSpeed_value = 0;
        public static double X_LSL = 0;
        public static double X_USL = 0;
        public static double Y_LSL = 0;
        public static double Y_USL = 0;
        public static double A_LSl = 0;
        public static double A_USl = 0;
        public static double F_USl = 0;
        public static double F_LSl = 0;

        public static double loadconverz1 =0.0;
        public static double loadconverz2 = 0.0;

        public static bool IsFirstLogin = false;
        public static bool UIResetClicked = false; //MK
        public static bool UIEstopClicked = false;
        public static XmlDocument g_xmlDoc = new XmlDocument();
        public static string g_MachineName;
        public static string g_MachineSite;
        public static string g_MachineVersion;
        public static string delimiter = ConfigurationManager.AppSettings["Delimiter"];


        public static float OrginalFormWidth = 1024;
        public static float OrginalFormHeight = 768;

        public static DIDO DIDO = new DIDO();

        public static Advantech_PCIE ComObj = new Advantech_PCIE(0, "ComObj");
        public static Advantech_PCIE_Stepper ComObj1 = new Advantech_PCIE_Stepper(1, 0, "ComObj0");
        public static Advantech_PCIE DI_DO_Read = new Advantech_PCIE(0, "DI_DO_Read", 1, null);


        #region DIDO, AIAO, CONFIG, ALARM 

        // Here Array Count  need to pass based on the Input Count for Both DI and DO
        public static bool[] DI;
        public static bool[] DO;
        public static double[] AI;
        public static double[] newAI;

        public static List<IOParam> lstInputConfig = new List<IOParam>();
        public static List<IOParam> lstOutputConfig = new List<IOParam>();
        public static List<IOParam> lstAnalogIntputConfig = new List<IOParam>();

        public static List<AxisParam> g_lstAxisConfig = new List<AxisParam>();

        /// <summary>
        /// Alarm information list
        /// </summary>
        public static List<ErrorManage> g_lstAlarmInfo = new List<ErrorManage>();

        // for Input status grid
        public static List<CardDLL.IInput> lst_Input = new List<CardDLL.IInput>();
        #endregion

        #region MACHINE DETAILS LOAD
        public static string g_sAppPath = Application.StartupPath;

        public static string RunningLogPath = ConfigurationManager.AppSettings["LogFilePath"];
        public static string CurrentShift = string.Empty;

        public static decimal MachineRuntime = 0;
        public static decimal MachineIdletime = 0;
        public static decimal MachineDowntime = 0;
        public static decimal MachineTotaltime = 0;

        public static int InputPortCfg = 0;
        public static int OutputPortCfg = 0;

        public static int CavityRows = 0;
        public static int CavityCols = 0;
        public static int ConveyorCount = 0;
        public static string ConveyorIO;
        public static string g_MachineIoChaged;


        public static void LoadMachineDetails()
        {
            try
            {
                g_xmlDoc.Load(g_sAppPath + @"\Data\Config.txt");
                SQL_ConnStr = g_xmlDoc.DocumentElement.ChildNodes[4].InnerText; // cmd by arul
                g_MachineName = g_xmlDoc.DocumentElement.ChildNodes[5].InnerText;
                g_MachineVersion = g_xmlDoc.DocumentElement.ChildNodes[6].InnerText;

                InputPortCfg = Convert.ToInt32(g_xmlDoc.DocumentElement.ChildNodes[7].InnerText);
                OutputPortCfg = Convert.ToInt32(g_xmlDoc.DocumentElement.ChildNodes[8].InnerText);
                if (InputPortCfg == 0 || OutputPortCfg == 0)
                {
                    MessageBox.Show("Input or Output Port not Configured!!!");
                }

                SQL_ConnStr = g_xmlDoc.DocumentElement.ChildNodes[9].InnerText;
                if (!string.IsNullOrEmpty(SQL_ConnStr))
                {
                    sqlHelperConn = new SqlHelper(SQL_ConnStr);
                }
                SQL_ConnStr = g_xmlDoc.DocumentElement.ChildNodes[9].InnerText;
                
                
                CavityRows = Convert.ToInt32(g_xmlDoc.DocumentElement.ChildNodes[10].InnerText);
                CavityCols = Convert.ToInt32(g_xmlDoc.DocumentElement.ChildNodes[11].InnerText);
                g_MachineSite = g_xmlDoc.DocumentElement.ChildNodes[12].InnerText;
                ConveyorCount = Convert.ToInt32(g_xmlDoc.DocumentElement.ChildNodes[13].InnerText);
                ConveyorIO = g_xmlDoc.DocumentElement.ChildNodes[14].InnerText;
                g_MachineIoChaged = g_xmlDoc.DocumentElement.ChildNodes[15].InnerText;
            }
            catch (Exception ex)
            {
                Logger.WriteLog(Logger.LogType.Error, "GlobalVariable", "", ex.Message, ex.ToString());
                //MessageBox.Show("Info","Error: GlobalVariable_LoadMachineDetails()",MessageBoxDefaultButton.Button1,MessageBoxOptions.ServiceNotification);
                                MessageBox.Show("Error: GlobalVariable_LoadMachineDetails()", "Info", MessageBoxButtons.OK,MessageBoxIcon.Information,MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);

            }
        }
        #endregion


        #region (MACHINE,SEQUENCE) STATE VARIABLES, ENUMS

        public static int icount = 0;

        //MACHINE STATE
        public static bool b_gPause = false;
        public static bool b_gResume = false;
        public static bool b_gStop = false;

        public static bool b_gCardInitSucc = false;

        //SEQUENCE STATE
        public static bool bmachine_ReadytoStart = false;
        public static bool bautoseq_running = false;
        public static bool bhomeseq_running = false;
        public static bool VbUOP_ProcessFail = false;
        public static bool bactive_machine = false;
        public static bool Recheck_NG = false;

        #endregion


        #region StopperCYL

        public static bool LoadingStopper_Start = false;
        public static bool WorkingStopper_Start = false;
        public static bool RecheckStopper_Start = false;

        #endregion


        #region MACHINE MODE AND STATUS ENUMS

        public enum OperationMode
        {
            DryRun
           , Production
           , GRR
           , CPK
           , Static
           , Dynamic
            , DummyRun
        }

        public enum MachineStatus
        {
            Ideal,
            Running,
            Pause,
            Error,
            Stop,
            EStop,
            CloseApplication,
            Reset
        }
        public static double cycle_time = 0;
        public static double cycle_time_out = 0;

        public static OperationMode g_bMachineMode = OperationMode.Production;//OperationMode.Production;
        public static MachineStatus current_MCStatus = MachineStatus.Ideal;

        #endregion

        #region SAFETY BYPASS VARIABLES

        public static bool Safety_door_Bypass = false;
        public static bool Scanner_Bypass = false;
        public static bool Buzzer_Bypass = false;
        public static bool SFC_PDCA_Bypass = false;
        public static bool Semimachk = false;
        public static bool stop_pb = true;
        public static bool Loadcelchkbox = false; // AK
        public static bool Four_Graphit = false;
        public static bool NK_Enable = false;
        public static bool K_Enable = false;
        public static bool Enable_4_3 = false;
        #endregion

        #region MACHINE HOME SCREEN COUNT VARIABLES

        public static double dGlobal_Cycle_time = 0;
        public static double dGlobal_Pass_count = 0;
        public static double dGlobal_Reject_count = 0;
        public static double dGlobal_Total_count = 0;
        public static double dGlobal_Yield_Count = 0;
        public static int dGlobal_GraphiteToss_Count = 0;

        #endregion

        #region CONTROL RESIZER
        public static void ResizeAllControls(Control parent, float xRatio, float yRatio)
        {
            try
            {
                if (parent == null) return;

                foreach (Control ctrl in parent.Controls)
                {
                    // Resize control
                    ctrl.Left = (int)(ctrl.Left * xRatio);
                    ctrl.Top = (int)(ctrl.Top * yRatio);
                    ctrl.Width = (int)(ctrl.Width * xRatio);
                    ctrl.Height = (int)(ctrl.Height * yRatio);

                    // Special handling for ComboBox
                    if (ctrl is ComboBox cmbctrl)
                    {
                        // Only set SelectedIndex if there are items
                        if (cmbctrl.Items.Count > 0)
                        {
                            cmbctrl.SelectedIndex = 0;
                        }

                        cmbctrl.DropDownStyle = ComboBoxStyle.DropDownList;
                    }

                    // Recursively resize child controls
                    if (ctrl.HasChildren)
                    {
                        ResizeAllControls(ctrl, xRatio, yRatio);
                    }
                }
            }
            catch (Exception ex)
            {
                //Arulkumar Fixed random stoppage start
                Logger.WriteLog(Logger.LogType.Error, "GlobalVariable", "ResizeAllControls", ex.Message, ex.ToString());
                //Arulkumar Fixed random stoppage end
            }
        }
        #endregion

        #region ALARM HANDLER AND ERROR MANAGER 

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
                        //if (ls[i].Length >= 5)
                        //{
                        //    ErrorManage TempInfo = new ErrorManage();
                        //    TempInfo.AlarmCode = ls[i][1];
                        //    TempInfo.AlarmGroup = ls[i][2];
                        //    TempInfo.AlarmMessage = ls[i][3];
                        //    TempInfo.AlarmContent = ls[i][4];
                        //    AlarmInfoTempList.Add(TempInfo);
                        //}
                        ErrorManage TempInfo = new ErrorManage();
                        TempInfo.AlarmCode = ls[i][0];
                        //TempInfo.AlarmGroup = ls[i][2];
                        TempInfo.AlarmMessage = ls[i][2];
                        TempInfo.AlarmContent = ls[i][1];
                        AlarmInfoTempList.Add(TempInfo);

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

        //private static void ErrorManage_AlarmShowPopUp(object sender, ErrorManage.AlarmEventArgs e)
        //{
        //    string ErrorStr = "";
        //    if (e.ErrName != "")
        //    {
        //        ErrorStr = e.ErrName + " - ";
        //    }
        //    ErrorStr = ErrorStr + e.ErrDesc;
        //    var popup = new AlarmPopup((int)(DIDO.ECode)Enum.Parse(typeof(DIDO.ECode), e.ErrEnum), ErrorStr);
        //    if (e.ErrHappen)
        //    {
        //        popup.ShowDialog();
        //        popup.Focus();
        //    }
        //    else
        //    {
        //        popup.Close();
        //    }
        //}

        public static void HandleGlobalError(CommonAlarmInfo info)
        {
            //Arulkumar Fixed Null start
            if (info == null || string.IsNullOrEmpty(info.ErrorCode))
            {
                return;
            }
            //Arulkumar Fixed Null end
            int errorcode = Convert.ToInt16(info.ErrorCode);
            GlobalVariable.AlarmTrigger((ECode)errorcode, true, 1, info.IOName);
        }
        public static ErrorManage errorManage = new ErrorManage();

        public static double DefaultZ2 { get; internal set; }
        public static double DefaultZ1 { get; internal set; }

        //public static void AlarmTrigger(ECode eCode, bool _bMotion, int type, string name = "")
        public static void AlarmTrigger(ECode eCode, bool _bMotion, int type, string name = "")
        {
            try
            {
                if (!GlobalVariable.g_bAlarm)
                {
                    GlobalVariable.g_bAlarm = true;
                    GlobalVariable.b_gPause = true;

                    //Arulkumar Fixed random stoppage start
                    try
                    {
                        ConveyorSystem.Pause();
                    }
                    catch (Exception pauseEx)
                    {
                        Logger.WriteLog(Logger.LogType.Error, "GlobalVariable", "AlarmTrigger", pauseEx.Message, pauseEx.ToString());
                    }
                    //Arulkumar Fixed random stoppage end

                    //Arulkumar Fixed Null start
                    if (GlobalVariable.g_lstAlarmInfo == null || (int)eCode < 0 || (int)eCode >= GlobalVariable.g_lstAlarmInfo.Count)
                    {
                        return;
                    }
                    //Arulkumar Fixed Null end
                    GlobalVariable.g_lstAlarmInfo[(int)eCode].AlarmHappen = _bMotion;
                    GlobalVariable.g_lstAlarmInfo[(int)eCode].AlarmName = name;

                    string ErrorDes = "";
                    if (name != "")
                    {
                        ErrorDes = name + " - ";
                    }
                    ErrorDes = ErrorDes + GlobalVariable.g_lstAlarmInfo[(int)eCode].AlarmMessage;
                    //errorManage.Alarm_AddInfo(GlobalVariable.CurrentShift, ErrorDes, GlobalVariable.g_lstAlarmInfo[(int)eCode].AlarmCode, true);
                    InsertAlarmInfo(GlobalVariable.CurrentShift, ErrorDes,GlobalVariable.g_lstAlarmInfo[(int)eCode].AlarmCode, true);
                    GlobalVariable.SFC_Mcmini_Wait = false;

                    //if (type == 1)
                    //{
                    //    var popup = new AlarmPopup((int)(DIDO.ECode)eCode, ErrorDes);
                    //    popup.ShowDialog();
                    //    popup.Focus();
                    //}

                    //if (type == 0)
                    //{
                    //    _PopupRequired = false;
                    //    g_lstAlarmInfo[(int)eCode].AlarmHappen = _bMotion;
                    //}
                    //else if (type == 1)
                    //{
                    //    _PopupRequired = true;
                    //    GlobalVariable.g_lstAlarmInfo[(int)eCode].AlarmHappen = _bMotion;
                    //    var popup = new AlarmPopup(Convert.ToInt32((int)eCode), GlobalVariable.g_lstAlarmInfo[(int)eCode].AlarmMessage, DateTime.Now);
                    //    popup.ShowDialog();
                    //    popup.Focus();
                    //}
                    //g_lstAlarmInfo[(int)eCode].Alarm_AddInfo(HomeScreen.ShiftLAble, g_lstAlarmInfo[(int)eCode].AlarmMessage, g_lstAlarmInfo[(int)eCode].AlarmCode, true);
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog(Logger.LogType.Error, "GlobalVariable", "AlarmTrigger", ex.Message, ex.ToString());
            }
        }

        private static async Task<bool> InsertAlarmInfo(string _shift, string _smsg, string _command, bool _bhappen = true)
        {
            try
            {
                SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@shift", _shift),
                    new SqlParameter("@AlarmType", "Critical"),
                    new SqlParameter("@ErrorCode", _command),
                    new SqlParameter("@ErrorDescription", _smsg)
            };
                // need to uncommand bellow line
                await SqlUtility.ExecuteNonQueryAsync("sp_InsertAlarmLogs", parameters);
                return true;
            }
            catch (Exception ex)
            {
                Logger.WriteLog(Logger.LogType.Error, "InsertAlarmInfo", "", ex.Message, ex.ToString());
                return false;
            }

        }


        public static void ShowAlarmMessage(int ErrCode, string Description)
        {
            try
            {

                //AlarmPopup Almsg = new AlarmPopup(ErrCode, Description);
                //Almsg.ShowDialog();
            }
            catch (Exception ex)
            {
                //Arulkumar Fixed random stoppage start
                Logger.WriteLog(Logger.LogType.Error, "GlobalVariable", "ShowAlarmMessage", ex.Message, ex.ToString());
                //Arulkumar Fixed random stoppage end
            }
        }
        public static void ResetAllAlarms()
        {
            try
            {
                //Arulkumar Fixed Null start
                if (g_lstAlarmInfo != null)
                {
                    foreach (var alarm in g_lstAlarmInfo)
                    {
                        alarm?.ResetAlarm();
                    }
                }
                //Arulkumar Fixed Null end
                GlobalVariable.g_bAlarm = false;
                //GlobalVariable.b_gPause = false;
                //Arulkumar Automatic resume reduce 12/08/2026
                if(GlobalVariable.current_MCStatus != GlobalVariable.MachineStatus.Pause)
                {
                    GlobalVariable.b_gPause = false;
                }
            }
            catch (Exception ex)
            {
                //Arulkumar Fixed random stoppage start
                Logger.WriteLog(Logger.LogType.Error, "GlobalVariable", "ResetAllAlarms", ex.Message, ex.ToString());
                //Arulkumar Fixed random stoppage end
            }
        }
        #endregion

        #region AXIS HELPERS

        //public static EnumerableRowCollection<DataRow> stepperRows;
        //public static EnumerableRowCollection<DataRow> ServoRows;
        //private static readonly string filePath = Environment.CurrentDirectory + @"\Data\AxisList.Csv";
        //public static DataTable LoadAxes()
        //{
        //    DataTable ds = new DataTable();
        //    try
        //    {
        //        ds = HelperClassLib.GetDataFromHelper.GetDataFromCSV(filePath);
        //        GlobalVariable.stepperRows = ds.AsEnumerable()
        //        .Where(row => !string.IsNullOrWhiteSpace(row.Field<string>("Stepper")));
        //        GlobalVariable.ServoRows = ds.AsEnumerable()
        //       .Where(row => !string.IsNullOrWhiteSpace(row.Field<string>("Servo")));

        //        return ds;
        //    }
        //    catch (Exception ex)
        //    {
        //        return ds;
        //    }
        //}
        #endregion

        #region TEXTBOX VALIDATORS

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


        public static void ApplyTextBoxConfig(TextBox textBox, string configKey, KeyPressEventArgs e, bool allowDecimal, bool allowMinus)

        {
            int maxLength = int.Parse(ConfigurationManager.AppSettings[configKey]);
            char c = e.KeyChar;

            if (char.IsControl(c))
            {
                return;
            }

            int currentLength = textBox.Text.Length - textBox.SelectionLength;
            if (currentLength >= maxLength)
            {
                e.Handled = true;
                return;
            }

            if (char.IsDigit(c))
            {
                if (textBox.Text.Contains("."))
                {
                    int indexOfDecimal = textBox.Text.IndexOf(".");

                    int digitsAfterDecimal = textBox.Text.Length - indexOfDecimal - 1;

                    if (textBox.SelectionStart > indexOfDecimal && digitsAfterDecimal >= 4)
                    {
                        e.Handled = true;
                        return;

                    }
                }
                return;
            }

            if (allowDecimal && c == '.')
            {
                if (!textBox.Text.Contains(".") && textBox.SelectionStart != 0)
                {
                    return;
                }
                e.Handled = true;
                return;
            }

            if (allowMinus && c == '-')
            {
                if (!textBox.Text.Contains("-") && textBox.SelectionStart == 0)
                {
                    return;
                }
                e.Handled = true;
                return;
            }
            e.Handled = true;
        }
        #endregion

        public static async Task AlarmTriggerAsync(ECode eCode, bool _bMotion, int type, string name = "", string version = "")
        {
            try
            {
                GlobalVariable.g_bAlarm = true;
                GlobalVariable.b_gPause = true;
                if (GlobalVariable.bhomeseq_running)
                {
                    //ConveyorSystem.HomingPause();

                    ObjectList.Servo_R1.Stop();
                    ObjectList.Servo_R2.Stop();
                    ObjectList.Servo_X1.Stop();
                    ObjectList.Servo_Y1.Stop();
                    ObjectList.Servo_Z1.Stop();
                    ObjectList.Servo_Z2.Stop();
                    ObjectList.Servo_X2.Stop();
                    ObjectList.Servo_Y2.Stop();
                }
                else
                {
                    if (GlobalVariable.current_MCStatus != GlobalVariable.MachineStatus.Pause)
                    {
                        //Arulkumar Fixed random stoppage start
                        try
                        {
                            ConveyorSystem.Pause();
                        }
                        catch (Exception pauseEx)
                        {
                            Logger.WriteLog(Logger.LogType.Error, "GlobalVariable", "AlarmTriggerAsync", pauseEx.Message, pauseEx.ToString());
                        }
                        //Arulkumar Fixed random stoppage end
                    }
                }


                //Arulkumar Fixed Null start
                if (GlobalVariable.g_lstAlarmInfo == null || (int)eCode < 0 || (int)eCode >= GlobalVariable.g_lstAlarmInfo.Count)
                {
                    return;
                }
                //Arulkumar Fixed Null end
                GlobalVariable.g_lstAlarmInfo[(int)eCode].AlarmHappen = _bMotion;
                GlobalVariable.g_lstAlarmInfo[(int)eCode].AlarmName = name;

                string ErrorDes = "";
                if (name != "")
                {
                    ErrorDes = name + " - ";
                }
                ErrorDes = ErrorDes + GlobalVariable.g_lstAlarmInfo[(int)eCode].AlarmMessage;

                #region Running Log
                await Task.Run(() => Logger.WriteLogasTask(Logger.LogType.Running, "AlarmTriggerAsync", "Alarm", ErrorDes, ""));
                #endregion
                //await InsertAlarmInfo(GlobalVariable.CurrentShift, ErrorDes, GlobalVariable.g_lstAlarmInfo[(int)eCode].AlarmCode, true);
                await InsertAlarmInfo(GlobalVariable.CurrentShift, ErrorDes, GlobalVariable.g_lstAlarmInfo[(int)eCode].AlarmCode, true);

                //sp_InsertAlarmLogs

                //errorManage.Alarm_AddInfo(GlobalVariable.CurrentShift, ErrorDes, GlobalVariable.g_lstAlarmInfo[(int)eCode].AlarmCode, true);
                //Task.Run(()=> InsertAlarmInfo(GlobalVariable.CurrentShift, ErrorDes, GlobalVariable.g_lstAlarmInfo[(int)eCode].AlarmCode, true));
                //if (type == 1)
                //{
                //    var popup = new AlarmPopup((int)(DIDO.ECode)eCode, ErrorDes);
                //    popup.ShowDialog();
                //    popup.Focus();
                //}

                //if (type == 0)
                //{
                //    _PopupRequired = false;
                //    g_lstAlarmInfo[(int)eCode].AlarmHappen = _bMotion;
                //}
                //else if (type == 1)
                //{
                //    _PopupRequired = true;
                //    GlobalVariable.g_lstAlarmInfo[(int)eCode].AlarmHappen = _bMotion;
                //    var popup = new AlarmPopup(Convert.ToInt32((int)eCode), GlobalVariable.g_lstAlarmInfo[(int)eCode].AlarmMessage, DateTime.Now);
                //    popup.ShowDialog();
                //    popup.Focus();
                //}
                //g_lstAlarmInfo[(int)eCode].Alarm_AddInfo(HomeScreen.ShiftLAble, g_lstAlarmInfo[(int)eCode].AlarmMessage, g_lstAlarmInfo[(int)eCode].AlarmCode, true);
            }
            catch (Exception ex)
            {
                Logger.WriteLog(Logger.LogType.Error, "GlobalVariable", "AlarmTrigger", ex.Message, ex.ToString());
            }
        }

        public static bool CheckMinMaxSpeedLimits(double enteredSpeed, double maxSpeed)
        {
            try
            {
                if (enteredSpeed <= 0)
                {
                    MessageBox.Show("Velocity cannot be 0 or negative values", "Manual Screen", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);
                    return false;
                }
                else if (enteredSpeed > maxSpeed)
                {
                    MessageBox.Show("Maximum Velocity should be less than " + maxSpeed,
                        "Manual Screen", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);
                    return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                Logger.WriteLog(Logger.LogType.Error, "GlobalVariable", "", ex.Message, ex.ToString());
                return false;
            }
        }


        //public static List<DIDO.RobotInputs> lst_RobotInput = new List<DIDO.RobotInputs>();
        //public static List<DIDO.RobotOutputs> lst_RobotOutput = new List<DIDO.RobotOutputs>();
    }
}
