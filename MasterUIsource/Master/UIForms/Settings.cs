using ExceptionLib;
using GRT_BG1.Function.Calibration;
using GRT_BG1_V54.Function.CommonClass; // added for GantrySystem
using HelperClassLib;
using Master;
using Master.GRT.Function.DryRun; // to access StaticDynamicSeq
using Program;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using static DIO.DIDO;
using static Master.GlobalVariable;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using LANG = Test_EN.Transform_Language_Tool;

namespace UI
{
    public partial class Settings : Form
    {
        public Advantech_PCIE ServoAxis;
        public Advantech_PCIE TmrServoAxis;

        int axisindex = 0;
        int axisindex2 = 0;
        int SelectedAxis = 0;
        int CurrentAxis = -1;
        private int _jogAxis = -1;
        string CurrentAxisName = "";
        double MovePosition = 0;
        Image signal_on, signal_off;
        List<System.Threading.Timer> ThreadTimer = new List<System.Threading.Timer>();
        public static bool Di_Input_read_lock = false;
        public string Teach_filepath = Environment.CurrentDirectory + @"\Data\";


        public int X_Index = 0;
        public int Y_Index = 0;
        public int Z1_Index = 0;
        public int Z2_Index = 0;
        public int R1_Index = 0;
        public int R2_Index = 0;
        public int Z_Index = 0;

        int xCount = 0;
        int yCount = 0;
        //int zCount = 0;
        int rCount = 0;

        public string SelectedXAxis = string.Empty;
        public string SelectedYAxis = string.Empty;
        public string SelectedZAxis = string.Empty;

        // Sequence control
        private CancellationTokenSource _seqCts = null;
        private bool _sequenceRunning = false;

        private XmlDocument GantryXml = new XmlDocument();
        private string GantryPath;

        XmlDocument xmlDoc = new XmlDocument();
        XmlNodeList xmlNode = null;
        XmlNode Selectednode = null;
        XmlNode Initnode = null;
        XmlNode SafePrioritynode = null;
        XmlNode Movementnode = null;
        XmlNode Operatingnode = null;
        public static List<string> SCANRepetability_Received_String = new List<string>();

        public Settings()
        {
            InitializeComponent();
            IP_Details_table.EditingControlShowing += IP_Details_table_EditingControlShowing;

            // wire mode radio handlers to update UI
            radioButtonStatic.CheckedChanged += ModeRadio_CheckedChanged;
            radioButtonDynamic.CheckedChanged += ModeRadio_CheckedChanged;
            tabControlSettings.TabPages.Remove(tabPage3);


            // wire Reset button (button3) in designer
            button3.Click -= button3_Click;
            button3.Click += button3_Click;

            //18-03-2026 - Final/Recheck caliberation move.  // AK
            AxisTable.Columns.Add("Key", typeof(int));        // or typeof(DIDO.EAxis) if you want enum
            AxisTable.Columns.Add("Servo", typeof(string));   // keep same column name if you rely on "Servo"

            foreach (var kv in ObjectList.MotorObj)
            {
                AxisTable.Rows.Add((int)kv.Key, kv.Value.motor_Params.name);
            }

            GantryPath = GlobalVariable.g_sAppPath + @"\Data\CaliberationStructure.xml";
            GantryXml.Load(GantryPath);

            float xRatio = (float)Screen.PrimaryScreen.Bounds.Width / GlobalVariable.OrginalFormWidth;
            float yRatio = (float)Screen.PrimaryScreen.Bounds.Height / GlobalVariable.OrginalFormHeight;
            GlobalVariable.ResizeAllControls(this, xRatio, yRatio);
            btn_edit.Enabled = true;
            btn_save.Enabled = true;
            var motorList = ObjectList.MotorObj
               .Select(kv => new
               {
                   Key = kv.Key,
                   Motor = kv.Value,
                   Name = kv.Value.motor_Params.name
               })
               .ToList();
            cmbAxisMoveAbs.DataSource = motorList;
            cmbAxisMoveAbs.DisplayMember = "Name";
            cmbAxisMoveAbs.ValueMember = "Key";

            GridView.Names_Text_Columns(GlobalVariable.Analog_Input_Names, GlobalVariable.Analog_Input_Units, dgvAI);

            //radioButtonProd.Checked = GlobalVariable.Operation_Mode == "Production";
            //radioButtondry.Checked = GlobalVariable.Operation_Mode == "Dry";
            //radioButtoncpk.Checked = GlobalVariable.Operation_Mode == "CPK";
            //radioButtongrr.Checked = GlobalVariable.Operation_Mode == "GRR";
            //radioButtonStatic.Checked = GlobalVariable.Operation_Mode == "Static";
            //radioButtonDynamic.Checked = GlobalVariable.Operation_Mode == "Dynamic";

            radioButtonProd.Checked = GlobalVariable.g_bMachineMode == OperationMode.Production;
            radioButtondry.Checked = GlobalVariable.g_bMachineMode == OperationMode.DryRun;
            radioButtoncpk.Checked = GlobalVariable.g_bMachineMode == OperationMode.CPK;
            radioButtongrr.Checked = GlobalVariable.g_bMachineMode == OperationMode.GRR;
            radioButtonStatic.Checked = GlobalVariable.g_bMachineMode == OperationMode.Static;
            radioButtonDynamic.Checked = GlobalVariable.g_bMachineMode == OperationMode.Dynamic;

            LoaddellChk.Checked = GlobalVariable.Loadcelchkbox;
            Buzzer_Bypass.Checked = GlobalVariable.Buzzer_Bypass;
            Barcode_scanner_bypass.Checked = GlobalVariable.Scanner_Bypass;
            SFC_PDCA_Bypass.Checked = GlobalVariable.SFC_PDCA_Bypass;
            Safety_door_bypass.Checked = GlobalVariable.Safety_door_Bypass;
            GlobalVariable.Safety_door_Bypass = Safety_door_bypass.Checked;
            Semimachk.Checked = GlobalVariable.Semimachk;
            GlobalVariable.Semimachk = Semimachk.Checked; // AK

            Four_Graphit.Checked = GlobalVariable.Four_Graphit;
            Nk_Model.Checked = GlobalVariable.NK_Enable;
            K_Model.Checked = GlobalVariable.K_Enable;

            Enable_4_3.Checked = GlobalVariable.Enable_4_3;

            //21-09-2026 - Wire K and NK Model selection events  // AK
            K_Model.CheckedChanged += K_Model_CheckedChanged;
            Nk_Model.CheckedChanged += Nk_Model_CheckedChanged;

            grpSystemSettings.Enabled = false;
            IP_Details_table.Enabled = false;
            Serial_Comm_table.Enabled = false;
            groupBox1.Enabled = false;


            if (GlobalVariable.g_CardInitSucc)
            {
                //**devchange : uncomment after connect to machine
                ThreadTimer.Add(new System.Threading.Timer(new TimerCallback(Di_Input_read), null, 10, 20)); // reading input connection, 100,10
            }
            TaskLoaBuildformation();

        }
        private void Di_Input_read(object sender)
        {
            try
            {
                if (Di_Input_read_lock == false)
                {
                    Di_Input_read_lock = true;
                    //GlobalVariable.DI = GlobalVariable.ComObj.DI_RefreshValue(GlobalVariable.DI.Length, GlobalVariable.InputPortCfg);
                    GlobalVariable.DO = GlobalVariable.ComObj.DO_RefreshValue(GlobalVariable.DO.Length, GlobalVariable.OutputPortCfg);
                    Di_Input_read_lock = false;
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog(Logger.LogType.Error, "Input_read", "Di_Input_read()", "Input_read_Error", ex.ToString());
                Di_Input_read_lock = false;
            }

        }


        public static string[][] Vision_settings = new string[20][];
        public static int Colour = 0;
        public static int OPT_ID = 1;
        public static int CCD_ID = 2;

        public static string[][] Axis_Parameter_settings = new string[20][];
        public static int Card_No = 0;
        public static int Axis_ID = 1;
        public static int Axis_Name = 2;
        public static int Pitch = 3;
        public static int Pulse = 4;
        public static int PPR = 5;
        public static int Acc = 6;
        public static int Deacc = 7;
        public static int Manual_Speed = 8;
        public static int Homing_Speed = 9;

        public void Create_Table_grid_data()
        {
            IP_Details_table.DataSource = GetDataFromHelper.GetDataFromXML(TCP_IP_Setting_Path);
            Serial_Comm_table.DataSource = GetDataFromHelper.GetDataFromXML(Serial_Comm_Setting_Path);
            Table_Vision_Settings.DataSource = GetDataFromHelper.GetDataFromXML(Vision_Setting_Path);
            Axis_Settings.DataSource = GetDataFromHelper.GetDataFromXML(Axis_Parameter_Setting_Path);
            AE_LIMITS.DataSource = GetDataFromHelper.GetDataFromXML(AE_Limits_Path_Production);
            CPK_dataGridView2.DataSource = GetDataFromHelper.GetDataFromXML(AE_Limits_Path_CPK);
            GRR_dataGridView3.DataSource = GetDataFromHelper.GetDataFromXML(AE_Limits_Path_GRR);

        }


        private void TaskLoaBuildformation()
        {
            string exepath = Assembly.GetExecutingAssembly().Location;
            string exename = Path.GetFileName(exepath);
            DateTime builddate = File.GetLastWriteTime(exepath);
            lbldat.Text = builddate.ToString();
            lblsrev.Text = GlobalVariable.g_MachineVersion;
            //lblsrev.Refresh();
            var rejectioncnt = GlobalVariable.dGlobal_Reject_count;
            lblrej.Text = rejectioncnt.ToString();
            lblsupdate.Text = "V57";
            lbllife.Text = "0";
        }


        private void Settings_Load(object sender, EventArgs e)
        {
            try
            {
                Axis_Settings.Enabled = false;
                Create_Table_grid_data();
                //**devchange : uncomment after connect to machine
                InitSourceForInput();
                InitSourceForOutput();
            }
            catch (Exception ex)
            {
                //Arulkumar Fixed random stoppage start
                Logger.WriteLog(Logger.LogType.Error, "Settings", "UI_Handler", ex.Message, ex.ToString());
                //Arulkumar Fixed random stoppage end
            }
        }

        private void btnedit_Click(object sender, EventArgs e)
        {
            try
            {
                Axis_Settings.Enabled = true;
                btnSave.Enabled = true;
            }
            catch (Exception ex)
            {
                //Arulkumar Fixed random stoppage start
                Logger.WriteLog(Logger.LogType.Error, "Settings", "UI_Handler", ex.Message, ex.ToString());
                //Arulkumar Fixed random stoppage end
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (XML.SaveGridToXml(Axis_Settings, GlobalVariable.Axis_Parameter_Setting_Path, "Axis_Parameters"))
            {
                Axis_Parameter_settings = XML.XML_Data_to_Varaiables_Column_String(GlobalVariable.Axis_Parameter_Setting_Path);
                //GlobClass.Write_Parameter_to_Axis();
                GlobalVariable.DIDO.AxisLoad();
                Axis_Settings.Enabled = false;
                MessageBox.Show("Axis Parameters  Saved Successfully !");
            }

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) &&
                !char.IsDigit(e.KeyChar) &&
                (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
            if ((e.KeyChar == '.') && ((sender as System.Windows.Forms.TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void btnEditGeneral_Click(object sender, EventArgs e)
        {

            if (cmbShift.SelectedIndex == -1 || !dtpStartTime.Checked || !dtpStartTime.Checked)
            {
                MessageBox.Show("please fill the data");
            }
            cmbShift.Enabled = true;
            dtpEndTime.Enabled = true;
            dtpStartTime.Enabled = true;
        }

        private void btnSaveGeneral_Click(object sender, EventArgs e)
        {
            if (cmbShift.SelectedIndex == -1 || !dtpStartTime.Checked || !dtpStartTime.Checked)
            {
                MessageBox.Show("please fill the data");
            }
            cmbShift.Enabled = false;
            dtpEndTime.Enabled = false;
            dtpStartTime.Enabled = false;
        }

        private void cmbShift_DrawItem(object sender, DrawItemEventArgs e)
        {
            System.Windows.Forms.ComboBox cb = sender as System.Windows.Forms.ComboBox;
            e.DrawBackground();

            string text = string.Empty;
            Brush brush = SystemBrushes.WindowText; // Default system text color

            if (e.Index >= 0)
            {
                text = cb.Items[e.Index].ToString();
                brush = new SolidBrush(cb.ForeColor); // Keep default color
            }
            else if (cb.SelectedIndex == -1)
            {
                text = "-- SELECT MODE --";
                brush = Brushes.White; // Placeholder in white
            }

            StringFormat sf = new StringFormat
            {
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center
            };

            e.Graphics.DrawString(text, cb.Font, brush, e.Bounds, sf);
            e.DrawFocusRectangle();
        }

        private void btnEditSettings_Click(object sender, EventArgs e)
        {
            try
            {
                grpSystemSettings.Enabled = true;
                IP_Details_table.Enabled = true;
                Serial_Comm_table.Enabled = true;
                groupBox1.Enabled = true;
                btnSaveSettings.Enabled = true;
            }
            catch (Exception ex)
            {
                //Arulkumar Fixed random stoppage start
                Logger.WriteLog(Logger.LogType.Error, "Settings", "UI_Handler", ex.Message, ex.ToString());
                //Arulkumar Fixed random stoppage end
            }
        }

        private async void btnSaveSettings_Click(object sender, EventArgs e)
        {
            try
            {


                //GlobalVariable.Operation_Mode = radioButtonProd.Checked ? "Production" :
                //    radioButtondry.Checked ? "Dry" :
                //    radioButtoncpk.Checked ? "CPK" :
                //    radioButtongrr.Checked ? "GRR" :
                //    radioButtonStatic.Checked ? "Static" :
                //    radioButtonDynamic.Checked ? "Dynamic" :
                //    GlobalVariable.Operation_Mode;

                // Assigning based on radio button selection
                GlobalVariable.g_bMachineMode =
                      radioButtonProd.Checked ? OperationMode.Production :
                      radioButtondry.Checked ? OperationMode.DryRun :
                      radioButtoncpk.Checked ? OperationMode.CPK :
                      radioButtongrr.Checked ? OperationMode.GRR :
                      radioButtonStatic.Checked ? OperationMode.Static :
                      radioButtonDynamic.Checked ? OperationMode.Dynamic :
                      GlobalVariable.g_bMachineMode;
                //GRR
                if (radioButtonProd.Checked)
                {
                    GlobalVariable.b_gPRoduction = true;
                    GlobalVariable.b_gDryRun = false;
                }
                if (radioButtondry.Checked)
                {
                    GlobalVariable.b_gPRoduction = false;
                    GlobalVariable.b_gDryRun = true;
                }
                if (radioButtonDynamic.Checked)
                {
                    GlobalVariable.b_gPRoduction = false;
                    GlobalVariable.b_gDryRun = false;
                    GlobalVariable.StaticMode_Cal = false;
                    GlobalVariable.DynamicMode_Cal = true;
                }
                if (radioButtonStatic.Checked)
                {
                    GlobalVariable.b_gPRoduction = false;
                    GlobalVariable.b_gDryRun = false;
                    GlobalVariable.StaticMode_Cal = true;
                    GlobalVariable.DynamicMode_Cal = false;
                }
                if (Dym_run.Checked)
                {
                    GlobalVariable.b_gPRoduction = false;
                    GlobalVariable.b_gDryRun = false;
                    GlobalVariable.StaticMode_Cal = false;
                    GlobalVariable.DynamicMode_Cal = false;
                    GlobalVariable.b_gDummyRun = true;
                }
                if (GlobalVariable.g_bMachineMode != GlobalVariable.g_bMachineMode)
                {
                    // Stop the Sequence
                    // BGS1.Functions.GlobalAutoSequenceExecutor.Stop();

                    var result = MessageBox.Show(
                        $"Sequence stopped.\nYou need to start again for selected mode: {GlobalVariable.g_bMachineMode}.\n\nDo you want to continue?",
                        "Confirm Mode Change", MessageBoxButtons.YesNo, MessageBoxIcon.Warning
                    );

                    if (result == DialogResult.Yes)
                    {
                        GlobalVariable.g_bMachineMode = GlobalVariable.g_bMachineMode;
                        MessageBox.Show($"Mode changed to {GlobalVariable.g_bMachineMode}. Please start the sequence again.",
                                        "Mode Changed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        // revert selection if user cancels
                        RevertModeSelection(GlobalVariable.g_bMachineMode);
                    }
                }
                GlobalVariable.Safety_door_Bypass = Safety_door_bypass.Checked ? true : false;
                if (GlobalVariable.Safety_door_Bypass)
                {
                    GlobalVariable.DIDO.WriteOPS(true, (int)EOutput.Main_on_off_valve);
                }
                else
                {
                    // GlobalVariable.DIDO.WriteOPS(false, (int)EOutput.Main_on_off_valve);
                }

                GlobalVariable.Safety_door_Bypass = Safety_door_bypass.Checked ? true : false;
                GlobalVariable.Scanner_Bypass = Barcode_scanner_bypass.Checked ? true : false;
                GlobalVariable.Buzzer_Bypass = Buzzer_Bypass.Checked ? true : false;
                GlobalVariable.SFC_PDCA_Bypass = SFC_PDCA_Bypass.Checked ? true : false;
                GlobalVariable.Semimachk = Semimachk.Checked ? true : false;
                GlobalVariable.Four_Graphit = Four_Graphit.Checked ? true : false;


                if(Safety_door_bypass.Checked)
                {
                    await Logger.WriteLogasTask(Logger.LogType.Running, "Setting Form", "Safety Door Bypassed", "Setting Form - Safety Door Bypassed " + GlobalVariable.g_MachineVersion, "");

                }
                else
                {
                    await Logger.WriteLogasTask(Logger.LogType.Running, "Setting Form", "Safety Door Bypassed", "Setting Form - Safety Door Not Bypassed " + GlobalVariable.g_MachineVersion, "");


                }

                if (Barcode_scanner_bypass.Checked)
                {
                    await Logger.WriteLogasTask(Logger.LogType.Running, "Setting Form", "Barcode scanner Bypassed", "Setting Form -Barcode scanner Bypassed " + GlobalVariable.g_MachineVersion, "");


                }
                else
                {
                    await Logger.WriteLogasTask(Logger.LogType.Running, "Setting Form", "Barcode scanner Not Bypassed", "Setting Form -Barcode scanner Not Bypassed " + GlobalVariable.g_MachineVersion, "");


                }

                if (Buzzer_Bypass.Checked)
                {
                    await Logger.WriteLogasTask(Logger.LogType.Running, "Setting Form", "Buzzer Bypassed", "Setting Form -Buzzer  Bypassed" + GlobalVariable.g_MachineVersion, "");


                }
                else
                {
                    await Logger.WriteLogasTask(Logger.LogType.Running, "Setting Form", "Buzzer Bypassed", "Setting Form -Buzzer Not Bypassed" + GlobalVariable.g_MachineVersion, "");

                }

                if (SFC_PDCA_Bypass.Checked)
                {
                    await Logger.WriteLogasTask(Logger.LogType.Running, "Setting Form", "SFC_PDCA Bypass", "Setting Form -SFC_PDCA Bypass" + GlobalVariable.g_MachineVersion, "");


                }
                else
                {
                    await Logger.WriteLogasTask(Logger.LogType.Running, "Setting Form", "SFC_PDCA Bypass", "Setting Form -SFC_PDCA Not Bypass" + GlobalVariable.g_MachineVersion, "");


                }

                if (Four_Graphit.Checked)
                {
                    await Logger.WriteLogasTask(Logger.LogType.Running, "Setting Form", "Four_Graphit", "Setting Form - Four_Graphit Enabled" + GlobalVariable.g_MachineVersion, "");

                }
                else
                {
                    await Logger.WriteLogasTask(Logger.LogType.Running, "Setting Form", "Four_Graphit", "Setting Form - Four_Graphit Disabled" + GlobalVariable.g_MachineVersion, "");

                }





                //21-09-2026 - Validate K and NK Model selection  // AK
                if (K_Model.Checked && Nk_Model.Checked)
                {
                    MessageBox.Show("Incorrect selection!\nPlease select only one model: K Model OR NK Model.",
                        "Model Selection Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return;
                }


                GlobalVariable.NK_Enable = Nk_Model.Checked ? true : false;
                GlobalVariable.K_Enable = K_Model.Checked ? true : false;
                GlobalVariable.Enable_4_3 = Enable_4_3.Checked ? true : false;

                grpSystemSettings.Enabled = false;
                IP_Details_table.Enabled = false;
                Serial_Comm_table.Enabled = false;
                groupBox1.Enabled = false;


                XML.SaveGridToXml1(IP_Details_table, GlobalVariable.TCP_IP_Setting_Path, "TCP_IP_Details", "Server");
                XML.SaveGridToXml1(Serial_Comm_table, GlobalVariable.Serial_Comm_Setting_Path, "OPT", "COM");
                MessageBox.Show("Device Settings Saved Successfully !");
            }
            catch (Exception ex)
            {
                //Arulkumar Fixed random stoppage start
                Logger.WriteLog(Logger.LogType.Error, "Settings", "UI_Handler", ex.Message, ex.ToString());
                //Arulkumar Fixed random stoppage end
            }
        }

        private void RevertModeSelection(GlobalVariable.OperationMode currentMode)
        {
            radioButtonProd.Checked = currentMode == GlobalVariable.OperationMode.Production;
            radioButtondry.Checked = currentMode == GlobalVariable.OperationMode.DryRun;
            radioButtoncpk.Checked = currentMode == GlobalVariable.OperationMode.CPK;
            radioButtongrr.Checked = currentMode == GlobalVariable.OperationMode.GRR;
            radioButtonStatic.Checked = currentMode == GlobalVariable.OperationMode.Static;
            radioButtonDynamic.Checked = currentMode == GlobalVariable.OperationMode.Dynamic;
        }

        private void btnccd1Browse_Click(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                //Arulkumar Fixed random stoppage start
                Logger.WriteLog(Logger.LogType.Error, "Settings", "UI_Handler", ex.Message, ex.ToString());
                //Arulkumar Fixed random stoppage end
            }
        }

        private void cmbTestMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                //Arulkumar Fixed random stoppage start
                Logger.WriteLog(Logger.LogType.Error, "Settings", "UI_Handler", ex.Message, ex.ToString());
                //Arulkumar Fixed random stoppage end
            }
        }

        private void Safety_door_bypass_CheckedChanged(object sender, EventArgs e)
        {
            if (Safety_door_bypass.Checked)
            {
                Safety_door_bypass.BackColor = Color.Lime;
                GlobalVariable.Safety_door_Bypass = true;
                Logger.WriteLog(Logger.LogType.Running, "Setting Form - Safety Door Bypassed", "Current Version:", GlobalVariable.g_MachineVersion, "");

            }
            else if (!Safety_door_bypass.Checked)
            {
                Safety_door_bypass.BackColor = Color.Gray;
                GlobalVariable.Safety_door_Bypass = false;

                Logger.WriteLog(Logger.LogType.Running, "Setting Form - Safety Door Bypassed", "Current Version:", GlobalVariable.g_MachineVersion, "");

            }
            if (GlobalVariable.Safety_door_Bypass)
            {
                Safety_door_bypass.BackColor = Color.Lime;
            }


        }

        //21-09-2026 - K Model selection handler  // AK
        private void K_Model_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (K_Model.Checked)
                {
                    // When K Model is selected, uncheck NK Model
                    Nk_Model.Checked = false;
                    GlobalVariable.K_Enable = true;
                    GlobalVariable.NK_Enable = false;
                    K_Model.BackColor = Color.Lime;
                    Nk_Model.BackColor = Color.Gray;
                }
                else
                {
                    GlobalVariable.K_Enable = false;
                    K_Model.BackColor = Color.Gray;
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog(Logger.LogType.Error, "Settings", "K_Model_CheckedChanged", ex.Message, ex.ToString());
            }
        }

        //21-09-2026 - NK Model selection handler  // AK
        private void Nk_Model_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (Nk_Model.Checked)
                {
                    // When NK Model is selected, uncheck K Model
                    K_Model.Checked = false;
                    GlobalVariable.NK_Enable = true;
                    GlobalVariable.K_Enable = false;
                    Nk_Model.BackColor = Color.Lime;
                    K_Model.BackColor = Color.Gray;
                }
                else
                {
                    GlobalVariable.NK_Enable = false;
                    Nk_Model.BackColor = Color.Gray;
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog(Logger.LogType.Error, "Settings", "Nk_Model_CheckedChanged", ex.Message, ex.ToString());
            }
        }

        private void btnCCD_start_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void dryrun_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button23_Click(object sender, EventArgs e)
        {
            if (XML.SaveGridToXml(AE_LIMITS, GlobalVariable.AE_Limits_Path_Production, "AE_Limits_Production"))
            {
                SFC_PDCA.PDCA_Data_Prodution = XML.PDCA_DATA_TO_VARAIBLES(GlobalVariable.AE_Limits_Path_Production); //**msraj
                MessageBox.Show("PDCA Parameters fro Production Saved Successfully !");
            }

        }

        private void CPK_Save_Click(object sender, EventArgs e)
        {
            if (XML.SaveGridToXml(CPK_dataGridView2, GlobalVariable.AE_Limits_Path_CPK, "AE_Limits_CPK"))
            {
                SFC_PDCA.PDCA_Data_CPK = XML.PDCA_DATA_TO_VARAIBLES(GlobalVariable.AE_Limits_Path_CPK); //**msraj
                MessageBox.Show("PDCA Parameters for CPK Saved Successfully !");
            }
        }

        private void button31_Click(object sender, EventArgs e)
        {
            if (XML.SaveGridToXml(GRR_dataGridView3, GlobalVariable.AE_Limits_Path_GRR, "AE_Limits_GRR"))
            {
                SFC_PDCA.PDCA_DATA_GRR = XML.PDCA_DATA_TO_VARAIBLES(GlobalVariable.AE_Limits_Path_GRR); //**msraj
                MessageBox.Show("PDCA Parameters for GRR Saved Successfully !");
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (XML.SaveGridToXml(Table_Vision_Settings, GlobalVariable.Vision_Setting_Path, "Vision_Settings"))
            {
                Vision_settings = XML.XML_Data_to_Varaiables_Row(GlobalVariable.Vision_Setting_Path);
                MessageBox.Show("Vision Settings Saved Successfully !");
            }
        }

        private void Add_Click(object sender, EventArgs e)
        {

        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            //**devchange: uncomment below methods after connected to machine
            UpdateInputGridStatus();
            UpdateOutputGridStatus();
            ReadAIValue();


            #region Loadcell Real Value

            double temz1 = GlobalVariable.AI[0];
            double maxval1 = 5.0;
            string load_val = GlobalVariable.Analog_Input_Names[1];
            double valls = temz1 * (maxval1 / 9.80);
            if (valls > 0)
            {
                GlobalVariable.loadconverz1 = valls;
            }

            double temz2 = GlobalVariable.AI[1];
            double maxval2 = 5.0;
            double valls2 = temz2 * (maxval2 / 9.80);
            if (valls2 > 0)
            {
                GlobalVariable.loadconverz2 = valls2;
            }

            GridView.Analog_Input_Status(GlobalVariable.Analog_Input_Names, dgvAI, GlobalVariable.AI);

            #endregion
        }
        public static void ReadAIValue()
        {
            try
            {
                GlobalVariable.ComObj.RefreshAISetup(true);
                GlobalVariable.AI = GlobalVariable.ComObj.RefreshAIvalues();
            }
            catch (Exception)
            {

            }
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void IP_Details_table_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //if (e.Button == MouseButtons.Right)
            //{
            //    IP_Details_table.Rows[e.RowIndex].Selected = true;
            //    contextMenuStrip1.Show(IP_Details_table, IP_Details_table.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true).Location);

            //}
        }
        private void Serial_Comm_table_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //if (e.Button == MouseButtons.Right)
            //{
            //    Serial_Comm_table.Rows[e.RowIndex].Selected = true;
            //    contextMenuStrip1.Show(Serial_Comm_table, Serial_Comm_table.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true).Location);

            //}
        }

        private void Axis_Settings_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //if (e.Button == MouseButtons.Right)
            //{
            //    Axis_Settings.Rows[e.RowIndex].Selected = true;
            //    contextMenuStrip1.Show(Axis_Settings, Axis_Settings.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true).Location);

            //}
        }

        private void Table_Vision_Settings_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //if (e.Button == MouseButtons.Right)
            //{
            //    Table_Vision_Settings.Rows[e.RowIndex].Selected = true;
            //    contextMenuStrip1.Show(Table_Vision_Settings, Table_Vision_Settings.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true).Location);

            //}
        }

        private void contextMenuStrip2_Opening(object sender, CancelEventArgs e)
        {

        }

        private void Add_Click_1(object sender, EventArgs e)
        {
            if (tabControlSettings.SelectedIndex == 1)
            {
                if (tabConnectionDetails.SelectedIndex == 0)
                {
                    IP_Details_table.Rows.Add();
                }
                else if (tabConnectionDetails.SelectedIndex == 1)
                {
                    Serial_Comm_table.Rows.Add();
                }

            }
            else if (tabControlSettings.SelectedIndex == 3)
            {
                Axis_Settings.Rows.Add();
            }
            else if (tabControlSettings.SelectedIndex == 4)
            {
                Table_Vision_Settings.Rows.Add();
            }
            else if (tabControlSettings.SelectedIndex == 5)
            {
                if (tabControl5.SelectedIndex == 0)
                {
                    AE_LIMITS.Rows.Add();
                }
                else if (tabControl5.SelectedIndex == 1)
                {
                    CPK_dataGridView2.Rows.Add();
                }
                else if (tabControl5.SelectedIndex == 2)
                {
                    GRR_dataGridView3.Rows.Add();
                }
            }
        }

        private void Delete_Click(object sender, EventArgs e)
        {

            if (tabControlSettings.SelectedIndex == 1)
            {

                if (tabConnectionDetails.SelectedIndex == 0)
                {
                    IP_Details_table.Rows.RemoveAt(IP_Details_table.CurrentRow.Index);
                }
                else if (tabConnectionDetails.SelectedIndex == 1)
                {
                    Serial_Comm_table.Rows.RemoveAt(Serial_Comm_table.CurrentRow.Index);
                }

            }
            else if (tabControlSettings.SelectedIndex == 3)
            {
                Axis_Settings.Rows.RemoveAt(Axis_Settings.CurrentRow.Index);

            }
            else if (tabControlSettings.SelectedIndex == 4)
            {
                Table_Vision_Settings.Rows.RemoveAt(Table_Vision_Settings.CurrentRow.Index);

            }
            else if (tabControlSettings.SelectedIndex == 5)
            {
                if (tabControl5.SelectedIndex == 0)
                {
                    AE_LIMITS.Rows.RemoveAt(AE_LIMITS.CurrentRow.Index);

                }
                else if (tabControl5.SelectedIndex == 1)
                {
                    CPK_dataGridView2.Rows.RemoveAt(CPK_dataGridView2.CurrentRow.Index);

                }
                else if (tabControl5.SelectedIndex == 2)
                {
                    GRR_dataGridView3.Rows.RemoveAt(GRR_dataGridView3.CurrentRow.Index);

                }
            }

        }

        private void grpSystemSettings_Enter(object sender, EventArgs e)
        {

        }

        private void Axis_Config_MouseClick(object sender, MouseEventArgs e)
        {

        }


        private void txtSearchForOutput_TextChanged(object sender, EventArgs e)
        {
            ApplySearchFilter(txtSearchForOutput.Text, DGV_Output1);

        }

        private void txtSearchForInput_TextChanged(object sender, EventArgs e)
        {
            ApplySearchFilter(txtSearchForInput.Text, DGV_Input1);

        }


        private void ApplySearchFilter(string term, DataGridView data)
        {
            foreach (DataGridViewRow row in data.Rows)
            {
                bool visible = false;
                foreach (DataGridViewCell cell in row.Cells)
                {
                    if (cell.Value != null &&
                        cell.Value.ToString().IndexOf(term, StringComparison.OrdinalIgnoreCase) >= 0)
                    {
                        visible = true;
                        break;
                    }
                }
                row.Visible = visible;
            }
        }
        #region custom properties
        private string input_start = "start";
        [Browsable(true)]
        [Description("The first io name displayed, the default is 'Start'"), Category("Custom control properties"), DisplayName("The first input enumeration name displayed in the current table")]
        public string Input_start
        {
            set
            {
                input_start = value;
                if (input_start == "End")
                {
                    input_start = "Start";
                }
            }
            get { return input_start; }
        }
        private string input_stop = "End";
        [Browsable(true)]
        [Description("The last io name displayed, the default is 'end'"), Category("Custom control properties"), DisplayName("The last input enumeration name displayed in the current table")]
        public string Input_stop
        {

            set
            {
                input_stop = value;
                if (input_stop == "start")
                {
                    input_stop = "End";
                }
            }
            get { return input_stop; }
        }
        #endregion
        public void InitSourceForInput()
        {
            GlobalVariable.lst_Input.Clear();
            signal_on = Image.FromFile(@"ICO\signal_on.png");
            signal_off = Image.FromFile(@"ICO\signal_off.png");

            if (DIO.DIDO.g_lstInput.Count > 0)
            {
                #region Press in the point that needs to be displayed
                int index_start = 0, index_stop = 0, lenth = 0;
                DIO.DIDO.EInput eInput_start, eInput_stop;
                if (input_start != "Start")
                {
                    Enum.TryParse<DIO.DIDO.EInput>(input_start, out eInput_start);
                    index_start = (int)eInput_start;
                }
                Enum.TryParse<DIO.DIDO.EInput>(input_stop, out eInput_stop);
                index_stop = (int)eInput_stop;
                if (input_stop == "End")
                {
                    index_stop = index_stop - 1;
                }
                lenth = index_stop - index_start + 1;
                for (int i = 0; i < lenth; i++)
                {
                    GlobalVariable.lst_Input.Add(DIO.DIDO.g_lstInput[index_start + i]);
                }
                #endregion

                //bool[] didata =  new  bool


                #region adding input to gridview
                for (int i = 0; i < (GlobalVariable.lst_Input.Count); i++)
                {
                    int firstIndex = i;
                    int rowIndex = DGV_Input1.Rows.Add();
                    DataGridViewRow row = DGV_Input1.Rows[rowIndex];
                    row.Cells["InOnOff"].Value = (firstIndex < GlobalVariable.DI.Length && GlobalVariable.DI[firstIndex]) ? signal_on : signal_off;

                    row.Cells["InputName"].Value = LANG.TL_MessageBox(GlobalVariable.lst_Input[firstIndex].BitName);
                }
                #endregion
                timer1.Start();
            }
        }
        List<CardDLL.IOutput> lst_Output = new List<CardDLL.IOutput>();
        public void InitSourceForOutput()
        {
            if (g_lstOutput.Count > 0)
            {
                #region Press in the point that needs to be displayed
                int index_start = 0, index_stop = 0, lenth = 0;
                EOutput eInput_start, eInput_stop;
                if (input_start != "Start")
                {
                    Enum.TryParse<EOutput>(input_start, out eInput_start);
                    index_start = (int)eInput_start;
                }
                Enum.TryParse<EOutput>(input_stop, out eInput_stop);
                index_stop = (int)eInput_stop;
                if (input_stop == "End")
                {
                    index_stop = index_stop - 1;
                }
                lenth = index_stop - index_start + 1;
                for (int i = 0; i < lenth; i++)
                {
                    lst_Output.Add(g_lstOutput[index_start + i]);
                }
                for (int i = 0; i < lst_Output.Count(); i++)
                {
                    DataGridViewRow dataGridViewRow = new DataGridViewRow();

                    int index = DGV_Output1.Rows.Add(dataGridViewRow);

                    DGV_Output1.Rows[index].Cells[0].Tag = i + index_start;
                    DGV_Output1.Rows[index].Cells[1].Value = LANG.TL_MessageBox(lst_Output[i].BitName);

                }
                timer2.Start();
                #endregion
            }
        }



        private void UpdateInputGridStatus()
        {

            for (int i = 0; i < GlobalVariable.DI.Length; i++)
            {
                DGV_Input1.Rows[i].Cells[0].Value = GlobalVariable.DI[i] ? signal_on : signal_off;
                DGV_Input1.Rows[i].Cells[1].Value = LANG.TL_MessageBox(GlobalVariable.lst_Input[i].BitName);
            }
        }


        private void UpdateOutputGridStatus()
        {

            //GlobalVariable.DO = dc.DO_RefreshValue();
            for (int i = 0; i < GlobalVariable.DO.Length; i++)
            {
                DGV_Output1.Rows[i].Cells[0].Style.BackColor = GlobalVariable.DO[i] ? Color.Lime : Color.LightGray;
                DGV_Output1.Rows[i].Cells[1].Value = LANG.TL_MessageBox(lst_Output[i].BitName);
            }
        }


        private void DGV_Output1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0 && e.ColumnIndex == 0)
                {
                    if (DGV_Output1.Rows[e.RowIndex].Cells[e.ColumnIndex].Tag != null)
                    {
                        var index = (int)DGV_Output1.Rows[e.RowIndex].Cells[e.ColumnIndex].Tag;
                        if ((DGV_Output1.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor == Color.Lime)) // || (DGV_Output.Rows[e.RowIndex].Cells[2].Style.BackColor == Color.Lime))
                        {
                            bool Rtn_OutPutOn = GlobalVariable.DIDO.WriteOPS(false, index);
                            if (Rtn_OutPutOn)
                            {
                                DGV_Output1.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = Color.LightGray;
                            }
                            else
                                DGV_Output1.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = Color.Lime;
                        }
                        else
                        {
                            bool Rtn_OutPutOn = GlobalVariable.DIDO.WriteOPS(true, index);
                            Rtn_OutPutOn = true; // make it true for showing click
                            if (Rtn_OutPutOn)
                            {
                                DGV_Output1.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = Color.Lime;
                                DGV_Output1.Rows[e.RowIndex].Cells[e.ColumnIndex].Selected = false;
                            }
                            else
                                DGV_Output1.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = Color.LightGray;
                        }
                        //  DGV_Output1.CurrentCell = DGV_Output1.Rows[e.RowIndex].Cells[e.ColumnIndex + 1];
                    }
                }
                //DGV_Output1.ClearSelection();

            }
            catch (Exception ex)
            {
                //Arulkumar Fixed random stoppage start
                Logger.WriteLog(Logger.LogType.Error, "Settings", "UI_Handler", ex.Message, ex.ToString());
                //Arulkumar Fixed random stoppage end
            }
        }

        private void IP_Details_table_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (IP_Details_table.CurrentCell.ColumnIndex == 1 || IP_Details_table.CurrentCell.ColumnIndex == 2)
            {
                System.Windows.Forms.TextBox tb = e.Control as System.Windows.Forms.TextBox;
                if (tb != null)
                {
                    tb.KeyPress -= TextBox_KeyPress_AllowOnlyNumbersAndDot;
                    tb.KeyPress += TextBox_KeyPress_AllowOnlyNumbersAndDot;
                }
            }
        }

        //private void TextBox_KeyPress_AllowOnlyNumbersAndDot(object sender, KeyPressEventArgs e)
        //{
        //    if (Serial_Comm_table.CurrentCell.ColumnIndex == 1 || Serial_Comm_table.CurrentCell.ColumnIndex == 2 ||
        //        IP_Details_table.CurrentCell.ColumnIndex == 1 || IP_Details_table.CurrentCell.ColumnIndex == 2)

        //    {
        //        if (!char.IsControl(e.KeyChar) &&
        //            !char.IsDigit(e.KeyChar) &&
        //            e.KeyChar != '.')
        //        {
        //            e.Handled = true;
        //        }
        //    }
        //    else if (Axis_Settings.CurrentCell.ColumnIndex != 2 || Table_Vision_Settings.CurrentCell.ColumnIndex == 1)
        //    {
        //        if (!char.IsControl(e.KeyChar) &&
        //            !char.IsDigit(e.KeyChar))
        //        {
        //            e.Handled = true;
        //        }
        //    }
        //}
        private void TextBox_KeyPress_AllowOnlyNumbersAndDot(object sender, KeyPressEventArgs e)
        {
            // Check Serial_Comm_table
            if (Serial_Comm_table.CurrentCell != null &&
                (Serial_Comm_table.CurrentCell.ColumnIndex == 1 ||
                 Serial_Comm_table.CurrentCell.ColumnIndex == 2))
            {
                if (!char.IsControl(e.KeyChar) &&
                    !char.IsDigit(e.KeyChar) &&
                    e.KeyChar != '.')
                {
                    e.Handled = true;
                }
                return;
            }

            // Check IP_Details_table
            if (IP_Details_table.CurrentCell != null &&
                (IP_Details_table.CurrentCell.ColumnIndex == 1 ||
                 IP_Details_table.CurrentCell.ColumnIndex == 2))
            {
                if (!char.IsControl(e.KeyChar) &&
                    !char.IsDigit(e.KeyChar) &&
                    e.KeyChar != '.')

                {
                    e.Handled = true;
                }
                return;
            }

            // Check Axis_Settings
            if (Axis_Settings.CurrentCell != null &&
                Axis_Settings.CurrentCell.ColumnIndex != 2)
            {
                if (!char.IsControl(e.KeyChar) &&
                    !char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                }
                return;
            }

            // Check Table_Vision_Settings
            if (Table_Vision_Settings.CurrentCell != null &&
                Table_Vision_Settings.CurrentCell.ColumnIndex == 1)
            {
                if (!char.IsControl(e.KeyChar) &&
                    !char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                }
                return;
            }
        }

        private void Serial_Comm_table_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            int ColumnIndex = Serial_Comm_table.CurrentCell.ColumnIndex;
            if (ColumnIndex == 1 || ColumnIndex == 2)
            {
                System.Windows.Forms.TextBox tb = e.Control as System.Windows.Forms.TextBox;

                if (tb != null)
                {
                    tb.KeyPress -= TextBox_KeyPress_AllowOnlyNumbersAndDot;
                    tb.KeyPress += TextBox_KeyPress_AllowOnlyNumbersAndDot;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            button1.Enabled = true;
        }

        private void button24_Click(object sender, EventArgs e)
        {
            button23.Enabled = true;
        }

        //===========Bug_ID_61======= Start
        private void Axis_Settings_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            int ColumnIndex = Axis_Settings.CurrentCell.ColumnIndex;
            //if (ColumnIndex == 1 || ColumnIndex == 2)
            {
                System.Windows.Forms.TextBox tb = e.Control as System.Windows.Forms.TextBox;

                if (tb != null)
                {
                    tb.KeyPress -= TextBox_KeyPress_AllowOnlyNumbersAndDot;
                    tb.KeyPress += TextBox_KeyPress_AllowOnlyNumbersAndDot;
                }
            }
        }

        //===========Bug_ID_61======= End

        private void btnCamera_Stop_Click(object sender, EventArgs e)
        {
            try
            {
                if (_seqCts != null && !_seqCts.IsCancellationRequested)
                {
                    _seqCts.Cancel();
                }
                ConveyorSystem.Stop();
                GantrySystem.Cancel();
                btnCamera_Stop.Enabled = false;
                btnCamera_Start.Enabled = true;
                _sequenceRunning = false;
            }
            catch (Exception)
            {
            }
        }

        private void cmbSelGantry_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmb_Nozzle_SelectedIndexChanged(object sender, EventArgs e)
        {



            try
            {
                if (cmb_Nozzle.SelectedItem == null)
                    return;

                string nozzleName = cmb_Nozzle.SelectedItem.ToString();
                if (string.IsNullOrWhiteSpace(nozzleName))
                    return;

                // Build full file path
                string filePath = Path.Combine(Teach_filepath, nozzleName + "_Param.csv");

                // Check if file exists before loading
                if (!File.Exists(filePath))
                {
                    MessageBox.Show($"Parameter file not found: " + nozzleName + "_Param.csv", "Nozzle Parameter File Missing", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    // Clear grid safely
                    dgv_Nozzle.DataSource = new DataTable();
                    dgv_Nozzle.Rows.Clear();
                    dgv_Nozzle.Refresh();
                    return;
                }

                // Load CSV data
                DataTable dt = HelperClassLib.GetDataFromHelper.GetDataFromCSV(filePath) ?? new DataTable();

                // Bind data to grid
                dgv_Nozzle.DataSource = dt;

                // Configure appearance
                dgv_Nozzle.ScrollBars = ScrollBars.Both;
                dgv_Nozzle.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgv_Nozzle.EnableHeadersVisualStyles = false;
                dgv_Nozzle.ColumnHeadersDefaultCellStyle.BackColor = Color.Beige;
                dgv_Nozzle.Enabled = false;

                // Set numeric formatting/alignment for displayed columns
                foreach (DataGridViewColumn col in dgv_Nozzle.Columns)
                {
                    col.DefaultCellStyle.Format = "N2";
                    col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                }

            }
            catch (Exception ex)
            {
                Logger.WriteLog(Logger.LogType.Error, "Settings", "cmb_Nozzle_SelectedIndexChanged", ex.Message, ex.ToString());
                MessageBox.Show("Error loading nozzle parameters:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void getAxies()
        {
            if (Initnode == null)
            {
                Logger.WriteLog(Logger.LogType.Info, "Settings", "getAxies", "Initnode is null - skipping axis discovery.", "");
                return;
            }

            foreach (XmlNode node in Initnode.ChildNodes)
            {


                if (node.InnerText.Contains("Servo_X1") || node.InnerText.Contains("Servo_X2"))
                {
                    xCount = 1;

                    SelectedXAxis = node.InnerText;

                    X_Index = FindSelectedIndex(SelectedXAxis);
                }
                else if (node.InnerText.Contains("Servo_Y1") || node.InnerText.Contains("Servo_Y2"))
                {
                    yCount = 1;

                    SelectedYAxis = node.InnerText;

                    Y_Index = FindSelectedIndex(SelectedYAxis);
                }
                else if (node.InnerText.Contains("Servo_Z1"))
                {
                    //zCount = 1;

                    SelectedZAxis = node.InnerText;

                    Z1_Index = FindSelectedIndex(SelectedZAxis);
                }
                else if (node.InnerText.Contains("Servo_Z2"))
                {
                    //zCount = 1;

                    SelectedZAxis = node.InnerText;

                    Z2_Index = FindSelectedIndex(SelectedZAxis);
                }
                else if (node.InnerText.Contains("Servo_R1"))
                {
                    rCount = 1;

                    SelectedZAxis = node.InnerText;

                    R1_Index = FindSelectedIndex(SelectedZAxis);
                }
                else if (node.InnerText.Contains("Servo_R2"))
                {
                    rCount = 1;

                    SelectedZAxis = node.InnerText;

                    R2_Index = FindSelectedIndex(SelectedZAxis);
                }
            }
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            try
            {
                dgv_Nozzle.Enabled = false;
                dgv_Nozzle.Enabled = false;

                DialogResult result = MessageBox.Show("Do you want to save the Data", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    if (tabCalib.SelectedIndex == 1)
                    {
                        if (cmb_Nozzle.SelectedItem.ToString().ToLower() != "select")
                        {
                            dt = (DataTable)dgv_Nozzle.DataSource;

                            WriteDataTableToCsv(dt, Teach_filepath + cmb_Nozzle.SelectedItem + "_Param.csv");
                            if (tabCalib.SelectedIndex > 0)
                            {
                                GlobalVariable.LoadReceipe();
                            }

                            AppendSelectedModuleToHistory(dt, cmb_Nozzle.SelectedItem.ToString());
                        }
                        else
                        {
                            MessageBox.Show("Select valid Gantry to save the Receipe_Param");
                            return;
                        }

                    }
                    else if (tabCalib.SelectedIndex == 1)
                    {
                        //dt = (DataTable)dgv_Robot.DataSource;
                        //WriteDataTableToCsv(dt, RoboReceipePath);
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog(Logger.LogType.Error, "ReceipeForm", "", ex.Message, ex.ToString());
            }
        }

        public void AppendSelectedModuleToHistory(DataTable dt, string moduleName)
        {
            try
            {
                //string historyPath = Path.Combine(Environment.CurrentDirectory, "Data", "Save_History.csv");
                string historyPath = @"D:\TEAL\Camera_Cali_SaveHistory\Camera_Cali_Save_History.csv";
                bool writeHeader = !File.Exists(historyPath);
                using (StreamWriter writer = new StreamWriter(historyPath, true))
                {
                    //if (writeHeader)
                    //{
                    //    writer.WriteLine("Module,DateTime");
                    //}
                    int rowCount = dt.Rows.Count;
                    writer.WriteLine($"Module_Name : {moduleName.ToUpper()} ");
                    writer.WriteLine("Date&Time : " + DateTime.Now.ToString());

                    writer.WriteLine();
                    writer.WriteLine(string.Join(",", dt.Columns.Cast<DataColumn>().Select(c => c.ColumnName)));
                    foreach (DataRow row in dt.Rows)
                    {
                        {
                            writer.WriteLine(string.Join(",", row.ItemArray.Select(x => x.ToString())));
                        }
                    }
                    writer.WriteLine();
                    writer.WriteLine();
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog(Logger.LogType.Error, "Save_History", "", ex.Message, ex.ToString());
            }
        }
        public void WriteDataTableToCsv(DataTable dataTable, string filePath)
        {
            try
            {


                // Create a StreamWriter to write to the CSV file
                if (File.Exists(filePath))
                {
                    using (StreamWriter writer = new StreamWriter(filePath))
                    {
                        // Write the column headers
                        for (int i = 0; i < dataTable.Columns.Count; i++)
                        {
                            writer.Write(dataTable.Columns[i].ColumnName);
                            if (i < dataTable.Columns.Count - 1)
                                writer.Write(',');
                        }
                        writer.WriteLine();

                        // Write the rows
                        foreach (DataRow row in dataTable.Rows)
                        {
                            for (int i = 0; i < dataTable.Columns.Count; i++)
                            {
                                writer.Write(row[i].ToString());
                                if (i < dataTable.Columns.Count - 1)
                                    writer.Write(',');
                            }
                            writer.WriteLine();
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
                Logger.WriteLog(Logger.LogType.Error, "ReceipeForm", "", ex.Message, ex.ToString());
            }
        }

        private void btn_edit_Click(object sender, EventArgs e)
        {
            dgv_Nozzle.ReadOnly = false;
            dgv_Nozzle.Enabled = true;
        }

        private async void btn_start_Click(object sender, EventArgs e)
        {
            if (txtdistance.Text.ToString() != "")
            {
                double distance = Convert.ToDouble(txtdistance.Text.ToString());

                CalibrationController calibration = new CalibrationController();
                if (cmb_Nozzle.SelectedItem.ToString() == "Nozzle1")
                    await calibration.Nozzle1_calib(distance);
                else
                    if (cmb_Nozzle.SelectedItem.ToString() == "Nozzle2")
                    await calibration.Nozzle2_calib(distance);
                else
                    if (cmb_Nozzle.SelectedItem.ToString() == "Final")
                    await calibration.X2Y2Final();
                else
                    if (cmb_Nozzle.SelectedItem.ToString() == "Nozzle1_Train")
                    while (await calibration.TrainNozzle(1))
                    {
                        break;
                    }
                else
                    if (cmb_Nozzle.SelectedItem.ToString() == "Nozzle2_Train")
                    while (await calibration.TrainNozzle(2))
                    {
                        break;
                    }
            }
        }

        private void cmbMoveMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbMoveMode.SelectedIndex == 1)//JOG
            {
                ////Arulkumar_27_11_2025
                lblMoveAbsPos.Visible = true;
                txtPositionAbs.Visible = false;
                lblServoX_TargetPosition.Visible = false;
                btnMoveAbs.Visible = false;
                grpGantry.Enabled = true;
                cmbAxisMoveAbs.Enabled = false;


                //lblMoveAbsPos.Visible = false;
                //txtPositionAbs.Visible = false;
                //lblServoX_TargetPosition.Visible = false;
                //btnMoveAbs.Visible = false;
                //grpGantry.Enabled = true;
                //cmbAxisMoveAbs.Enabled = false;
            }
            else
            {
                lblMoveAbsPos.Visible = true;
                txtPositionAbs.Visible = true;
                lblServoX_TargetPosition.Visible = true;
                btnMoveAbs.Visible = true;
                grpGantry.Enabled = false;
                cmbAxisMoveAbs.Enabled = true;
            }
        }

        private void cmbAxisMoveAbs_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmbAxisMoveAbs.SelectedItem == null)
                {
                    axisindex = -1;
                    ServoAxis = null;
                    return;
                }

                // keep axisindex in sync with combo selection
                axisindex = -1;
                if (cmbAxisMoveAbs.SelectedValue != null)
                {
                    try
                    {
                        // SelectedValue may be int or string
                        if (cmbAxisMoveAbs.SelectedValue is int)
                            axisindex = (int)cmbAxisMoveAbs.SelectedValue;
                        else
                        {
                            int.TryParse(cmbAxisMoveAbs.SelectedValue.ToString(), out axisindex);
                        }
                    }
                    catch
                    {
                        axisindex = -1;
                    }
                }
                else
                {
                    try { axisindex = (int)((dynamic)cmbAxisMoveAbs.SelectedItem).Key; } catch { axisindex = -1; }
                }

                if (cmb_Nozzle.SelectedIndex == 1)
                {
                    if (cmbAxisMoveAbs.SelectedIndex == 0)
                    {
                        cmbAxisMoveAbs.SelectedIndex = -1;
                        return;
                    }
                }
                else if (cmb_Nozzle.SelectedIndex == 2)
                {
                    if (cmbAxisMoveAbs.SelectedIndex == 1 || cmbAxisMoveAbs.SelectedIndex == 2)
                    {
                        cmbAxisMoveAbs.SelectedIndex = -1;
                        return;
                    }
                }

                if (axisindex >= 0 && ObjectList.MotorObj.ContainsKey(axisindex))
                    ServoAxis = ObjectList.MotorObj[axisindex];
                else
                    ServoAxis = null;

                CurrentAxis = axisindex;
                CurrentAxisName = ServoAxis != null ? ServoAxis.motor_Params.name : string.Empty;
            }
            catch (Exception ex)
            {
                Logger.WriteLog(Logger.LogType.Error, "ReceipeForm", "", ex.Message, ex.ToString());
            }
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            try
            {
                if (ServoAxis != null)
                {
                    ServoAxis.Stop();
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog(Logger.LogType.Error, "ReceipeForm", "", ex.Message, ex.ToString());
            }
        }

        private void btnMoveAbs_Click(object sender, EventArgs e)
        {
            try
            {
                //CurrentAxis = cmbAxisMoveAbs.SelectedIndex;
                //CurrentAxisName = cmbAxisMoveAbs.SelectedValue.ToString();
                if (txtPositionAbs.Text.Trim() == "")
                {
                    MessageBox.Show("Please Enter Position", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (txtetSpeedAbs.Text.Trim() == "")
                {
                    MessageBox.Show("Please Enter Speed", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (ServoAxis != null)
                {
                    double dTargetPos = 0;
                    if (!string.IsNullOrEmpty(txtPositionAbs.Text))
                    {
                        dTargetPos = Convert.ToDouble(txtPositionAbs.Text);
                        if (double.TryParse(txtetSpeedAbs.Text, out double speedValue))
                        {
                            if (!ServoAxis.Move_Abs(dTargetPos, speedValue, GlobalVariable.g_lstAxisConfig[axisindex].Acc,
                                 GlobalVariable.g_lstAxisConfig[axisindex].DeAcc, 5000))
                            {
                                //Logger.WriteLog("Device_Interface", "jogfrwrd()", "PCIE-1203_Interface", "Exception Error", es.ToString());
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Kindly Enter the vaild TargetPosition ", "Receipe", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Axis is not selected ", "Receipe", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
            }
            catch (Exception ex)
            {
                //Arulkumar Fixed random stoppage start
                Logger.WriteLog(Logger.LogType.Error, "Settings", "Recipe_Move_Handler", ex.Message, ex.ToString());
                //Arulkumar Fixed random stoppage end
            }
        }



        private void btn_stop_Click(object sender, EventArgs e)
        {
            CalibrationController.currentStepNozzle1 = 0;
            CalibrationController.currentStepNozzle2 = 0;

            ObjectList.Servo_X1.PauseAxis();
            ObjectList.Servo_Y1.PauseAxis();
            ObjectList.Servo_Z1.PauseAxis();
            ObjectList.Servo_X2.PauseAxis();
            ObjectList.Servo_R2.PauseAxis();
            ObjectList.Servo_R1.PauseAxis();
        }

        private void checkvelocity_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void timer2_Tick(object sender, EventArgs e)
        {

        }

        private void label119_Click(object sender, EventArgs e)
        {

        }

        private void label118_Click(object sender, EventArgs e)
        {

        }

        private void lblRunningCount_Click(object sender, EventArgs e)
        {

        }

        private void lblDynamicPos1_Click(object sender, EventArgs e)
        {

        }

        private void txtposition_x1_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblDynamicpos2_Click(object sender, EventArgs e)
        {

        }

        private void txtposition_x2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label90_Click(object sender, EventArgs e)
        {

        }

        private void label79_Click(object sender, EventArgs e)
        {

        }

        private void label19_Click(object sender, EventArgs e)
        {

        }

        private void txtposition_y1_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtpositionz1_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtposition_Z2_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtstaticposccd1_z_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtposition_y2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label77_Click(object sender, EventArgs e)
        {

        }

        private void txtspeed_TextChanged(object sender, EventArgs e)
        {

        }

        private void label50_Click(object sender, EventArgs e)
        {

        }

        private void txtCounts_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnCCD_stop_Click(object sender, EventArgs e)
        {

        }

        private void btnCCD_start_Click_1(object sender, EventArgs e)
        {

        }

        private void label43_Click(object sender, EventArgs e)
        {

        }

        private void txtccd1path_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnccd1Browse_Click_1(object sender, EventArgs e)
        {

        }

        private void lblStaticPos_Click(object sender, EventArgs e)
        {

        }

        private void txtstaticposccd1_x_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtstaticposccd1_y_TextChanged(object sender, EventArgs e)
        {

        }

        private void label129_Click(object sender, EventArgs e)
        {

        }

        private void label18_Click(object sender, EventArgs e)
        {

        }

        private void lblStaticUnit_Click(object sender, EventArgs e)
        {

        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void txtTestMode_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnCamera_Start_Click(object sender, EventArgs e)
        {
            try
            {

                if (_sequenceRunning)
                {
                    MessageBox.Show("Sequence already running");
                    return;
                }

                // set CSV path if provided
                if (!string.IsNullOrWhiteSpace(txtccd1path.Text))
                {
                    StaticDynamicSeq.CsvPath = txtccd1path.Text;
                }

                // read and validate inputs
                if (radioButtonStatic.Checked)
                    GlobalVariable.StaticMode_Cal = true;

                if (radioButtonStatic.Checked)
                {
                    if (string.IsNullOrWhiteSpace(txtstaticposccd1_x.Text) || string.IsNullOrWhiteSpace(txtstaticposccd1_y.Text))
                    {
                        MessageBox.Show("Enter static X and Y positions");
                        return;
                    }
                    GlobalVariable.txtstatic_XAxis = Convert.ToDouble(txtstaticposccd1_x.Text);
                    GlobalVariable.txtstatic_YAxis = Convert.ToDouble(txtstaticposccd1_y.Text);
                    GlobalVariable.txtDynamic_ZAxis = Convert.ToDouble(txtposition_Z1.Text); // AK
                    GlobalVariable.txtDynamic_RAxis = Convert.ToDouble(txtposition_R.Text); // AK
                }
                else if (radioButtonDynamic.Checked)
                {
                    if (string.IsNullOrWhiteSpace(txtposition_x1.Text) || string.IsNullOrWhiteSpace(txtposition_y1.Text) ||
                        string.IsNullOrWhiteSpace(txtposition_x2.Text) || string.IsNullOrWhiteSpace(txtposition_y2.Text) ||
                            string.IsNullOrWhiteSpace(txtposition_Z1.Text) || string.IsNullOrWhiteSpace(txtposition_R.Text)) // AK
                    {
                        MessageBox.Show("Enter dynamic positions for pos1 and pos2");
                        return;
                    }
                    GlobalVariable.txtDynamic_X1Axis = Convert.ToDouble(txtposition_x1.Text);
                    GlobalVariable.txtDynamic_Y1Axis = Convert.ToDouble(txtposition_y1.Text);
                    GlobalVariable.txtDynamic_XAxis = Convert.ToDouble(txtposition_x2.Text);
                    GlobalVariable.txtDynamic_YAxis = Convert.ToDouble(txtposition_y2.Text);

                    GlobalVariable.txtDynamic_ZAxis = Convert.ToDouble(txtposition_Z1.Text); // AK
                    GlobalVariable.txtDynamic_RAxis = Convert.ToDouble(txtposition_R.Text); // AK
                }

                if (string.IsNullOrWhiteSpace(txtCounts.Text) || !int.TryParse(txtCounts.Text, out int cnt) || cnt <= 0)
                {
                    MessageBox.Show("Enter a valid count (>0)");
                    return;
                }
                GlobalVariable.txtCounts_value = cnt;

                if (string.IsNullOrWhiteSpace(txtspeed.Text) || !int.TryParse(txtspeed.Text, out int spd) || spd <= 0)
                {
                    //MessageBox.Show("Enter a valid *speed* (>0)");
                    MessageBox.Show("Enter a valid *speed* (>0)", "Calibration", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                GlobalVariable.txtSpeed_value = spd;

                var selectedCCDs = new System.Collections.Generic.List<int>();
                if (checkCCD1.Checked) selectedCCDs.Add(1);
                if (checkCCD2.Checked) selectedCCDs.Add(2);
                if (checkCCD3.Checked) selectedCCDs.Add(3);
                if (checkCCD4.Checked) selectedCCDs.Add(4);
                if (selectedCCDs.Count == 0)
                {
                    MessageBox.Show("Select at least one CCD");
                    return;
                }

                bool isStatic = radioButtonStatic.Checked;
                int count = GlobalVariable.txtCounts_value;
                int speed = GlobalVariable.txtSpeed_value;

                // prepare UI for run
                btnCamera_Start.Enabled = false;
                btnCamera_Stop.Enabled = true;
                lblRunningCount.Text = "0";
                _sequenceRunning = true;
                _seqCts = new CancellationTokenSource();
                var ct = _seqCts.Token;

                // Disable reset while running
                button3.Enabled = false;

                if (GlobalVariable.b_gHomingDone)
                {
                    // run on background to keep UI responsive
                    Task.Run(async () =>
                    {
                        try
                        {
                            await Master.GRT.Function.DryRun.StaticDynamicSeq.RunSequenceAsync(
                                isStatic,
                                count,
                                GlobalVariable.txtstatic_XAxis,
                                GlobalVariable.txtstatic_YAxis,
                                GlobalVariable.txtDynamic_X1Axis,
                                GlobalVariable.txtDynamic_Y1Axis,
                                GlobalVariable.txtDynamic_XAxis,
                                GlobalVariable.txtDynamic_YAxis,
                                 GlobalVariable.txtDynamic_ZAxis,
                                     GlobalVariable.txtDynamic_RAxis,

                                speed,
                                selectedCCDs,
                                progress =>
                                {
                                    // update running count on UI thread
                                    try
                                    {
                                        if (lblRunningCount.InvokeRequired)
                                            lblRunningCount.BeginInvoke((Action)(() => lblRunningCount.Text = progress.ToString()));
                                        else
                                            lblRunningCount.Text = progress.ToString();
                                    }
                                    //Arulkumar Fixed random stoppage start
                                    catch (Exception uiEx)
                                    {
                                        Logger.WriteLog(Logger.LogType.Error, "Settings", "btnCamera_Start.ProgressCallback", uiEx.Message, uiEx.ToString());
                                    }
                                    //Arulkumar Fixed random stoppage end
                                },
                                ct
                            );
                        }
                        catch (OperationCanceledException) { }
                        finally
                        {
                            // restore UI
                            try
                            {
                                if (btnCamera_Start.InvokeRequired)
                                {
                                    btnCamera_Start.BeginInvoke((Action)(() => btnCamera_Start.Enabled = true));
                                    btnCamera_Stop.BeginInvoke((Action)(() => btnCamera_Stop.Enabled = false));
                                }
                                else
                                {
                                    btnCamera_Start.Enabled = true;
                                    btnCamera_Stop.Enabled = false;
                                }
                            }
                            //Arulkumar Fixed random stoppage start
                            catch (Exception uiEx)
                            {
                                Logger.WriteLog(Logger.LogType.Error, "Settings", "btnCamera_Start.RestoreButtons", uiEx.Message, uiEx.ToString());
                            }
                            //Arulkumar Fixed random stoppage end

                            // enable reset once done
                            try
                            {
                                if (button3.InvokeRequired)
                                    button3.BeginInvoke((Action)(() => button3.Enabled = true));
                                else
                                    button3.Enabled = true;
                            }
                            //Arulkumar Fixed random stoppage start
                            catch (Exception uiEx)
                            {
                                Logger.WriteLog(Logger.LogType.Error, "Settings", "btnCamera_Start.EnableReset", uiEx.Message, uiEx.ToString());
                            }
                            //Arulkumar Fixed random stoppage end

                            _sequenceRunning = false;
                            _seqCts = null;
                        }
                    });
                }
                else
                {
                    MessageBox.Show("First Homing After Static and Dynamic ", "StaticDynamic", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    btnCamera_Start.Enabled = true;
                    btnCamera_Stop.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error starting sequence: " + ex.Message);
                btnCamera_Start.Enabled = true;
                btnCamera_Stop.Enabled = false;
                _sequenceRunning = false;
                _seqCts = null;
            }
        }

        private void ModeRadio_CheckedChanged(object sender, EventArgs e)
        {
            UpdateModeUI();
        }

        private void UpdateModeUI()
        {
            try
            {
                if (radioButtonStatic.Checked)
                {
                    txtTestMode.Text = "Static";
                }
                else if (radioButtonDynamic.Checked)
                {
                    txtTestMode.Text = "Dynamic";
                }

                bool staticEnabled = radioButtonStatic.Checked;
                txtstaticposccd1_x.Enabled = staticEnabled;
                txtstaticposccd1_y.Enabled = staticEnabled;
                //txtstaticposccd1_z.Enabled = staticEnabled;

                bool dynamicEnabled = radioButtonDynamic.Checked;
                txtposition_x1.Enabled = dynamicEnabled;
                if (dynamicEnabled)
                {
                    txtposition_R.Enabled = dynamicEnabled;
                    txtposition_Z1.Enabled = dynamicEnabled;
                }
                txtposition_y1.Enabled = dynamicEnabled;
                //txtpositionz1.Enabled = dynamicEnabled;

                txtposition_x2.Enabled = dynamicEnabled;
                txtposition_y2.Enabled = dynamicEnabled;
                //txtposition_Z2.Enabled = dynamicEnabled;
            }
            catch (Exception ex)
            {
                //Arulkumar Fixed random stoppage start
                Logger.WriteLog(Logger.LogType.Error, "Settings", "EnablePositionFields", ex.Message, ex.ToString());
                //Arulkumar Fixed random stoppage end
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void contextMenuStrip2_Opening_1(object sender, CancelEventArgs e)
        {

        }

        private void dgv_Nozzle_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        public DataTable AxisTable = new DataTable();
        public int FindSelectedIndex(string selectedValue)
        {
            try
            {
                if (AxisTable.Rows.Count > 0)
                {
                    DataRow row = AxisTable.AsEnumerable().
                        FirstOrDefault(x => string.Equals(x.Field<string>("Servo"), selectedValue, StringComparison.OrdinalIgnoreCase));

                    if (row != null)
                    {
                        return AxisTable.Rows.IndexOf(row);
                    }
                }
                return 0;
            }
            catch (Exception ex)
            {
                Logger.WriteLog(Logger.LogType.Error, "RecipieForm", "", ex.Message, ex.ToString());
                return 0;
            }
        }


        //ok
        private void btnYDec_MouseUp(object sender, MouseEventArgs e)
        {
            try
            {
                if (_jogAxis >= 0 && ObjectList.MotorObj.ContainsKey(_jogAxis))
                {
                    ServoAxis = ObjectList.MotorObj[_jogAxis];

                    if (cmbMoveMode.SelectedIndex == 1) // JOG
                    {
                        ServoAxis.StopJog();
                        ServoAxis.Stop();
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog(Logger.LogType.Error, "RecipieForm", "", ex.Message, ex.ToString());
            }
        }


        //ok
        private void btnYDec_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                int selAxis = -1;

                // 1️⃣ Get selected axis index
                if (cmbAxisMoveAbs.SelectedValue != null)
                {
                    if (cmbAxisMoveAbs.SelectedValue is int)
                        selAxis = (int)cmbAxisMoveAbs.SelectedValue;
                    else
                        int.TryParse(cmbAxisMoveAbs.SelectedValue.ToString(), out selAxis);
                }

                // 2️⃣ Fallback: SelectedItem.Key
                if (selAxis == -1 && cmbAxisMoveAbs.SelectedItem != null)
                {
                    try
                    {
                        selAxis = (int)((dynamic)cmbAxisMoveAbs.SelectedItem).Key;
                    }
                    catch
                    {
                        selAxis = -1;
                    }
                }

                // 3️⃣ Final fallback
                if (selAxis == -1)
                    selAxis = CurrentAxis != -1 ? CurrentAxis : Y_Index;

                CurrentAxis = selAxis;
                _jogAxis = selAxis;   // ✅ used for MouseUp

                // 4️⃣ Get ServoAxis
                ServoAxis = ObjectList.MotorObj.ContainsKey(selAxis)
                            ? ObjectList.MotorObj[selAxis]
                            : null;

                if (ServoAxis == null)
                    return;

                // 5️⃣ Validate speed
                if (!double.TryParse(txtetSpeedAbs.Text, out double speed))
                {
                    MessageBox.Show(
                        "Please enter a valid numeric Speed.",
                        "Invalid input",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return;
                }

                // 6️⃣ Get axis name safely
                string axisName = null;
                try
                {
                    axisName = ServoAxis?.motor_Params?.name
                               ?? ((dynamic)cmbAxisMoveAbs.SelectedItem).Name?.ToString();
                }
                catch
                {
                    axisName = null;
                }

                // 7️⃣ 🚫 Allow ONLY Servo_Y1 and Servo_Y2
                if (string.IsNullOrWhiteSpace(axisName) ||
                    !(axisName.Equals("Servo_Y1", StringComparison.OrdinalIgnoreCase) ||
                      axisName.Equals("Servo_Y2", StringComparison.OrdinalIgnoreCase)))
                {
                    MessageBox.Show(
                        "Only Servo_Y1 and Servo_Y2 are allowed for Y jog.",
                        "Axis Not Allowed",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    return;
                }

                // 8️⃣ Safety check (only for Servo_Y1 if required)
                if (axisName.Equals("Servo_Y1", StringComparison.OrdinalIgnoreCase))
                {
                    if (!NozzleSystem.nozzleZ1Z2Safe())
                        return;
                }

                // 9️⃣ Execute JOG (+ direction)
                if (cmbMoveMode.SelectedIndex == 1) // JOG mode
                {
                    ServoAxis.Jog(
                        1,          // +Y direction
                        speed,
                        GlobalVariable.g_lstAxisConfig[selAxis].Acc,
                        GlobalVariable.g_lstAxisConfig[selAxis].DeAcc);
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog(
                    Logger.LogType.Error,
                    "RecipieForm",
                    "",
                    ex.Message,
                    ex.ToString());
            }
        }


        //ok
        private void btnXDec_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                int selAxis = -1;

                // 1️⃣ Get selected axis
                if (cmbAxisMoveAbs.SelectedValue != null)
                {
                    if (cmbAxisMoveAbs.SelectedValue is int)
                        selAxis = (int)cmbAxisMoveAbs.SelectedValue;
                    else
                        int.TryParse(cmbAxisMoveAbs.SelectedValue.ToString(), out selAxis);
                }

                // 2️⃣ Fallback: SelectedItem.Key
                if (selAxis == -1 && cmbAxisMoveAbs.SelectedItem != null)
                {
                    try
                    {
                        selAxis = (int)((dynamic)cmbAxisMoveAbs.SelectedItem).Key;
                    }
                    catch
                    {
                        selAxis = -1;
                    }
                }

                // 3️⃣ Final fallback
                if (selAxis == -1)
                    selAxis = CurrentAxis != -1 ? CurrentAxis : X_Index;

                CurrentAxis = selAxis;
                _jogAxis = selAxis;   // ✅ store axis for MouseUp

                // 4️⃣ Get servo object
                ServoAxis = ObjectList.MotorObj.ContainsKey(selAxis)
                            ? ObjectList.MotorObj[selAxis]
                            : null;

                if (ServoAxis == null)
                    return;

                // 5️⃣ Validate speed
                if (!double.TryParse(txtetSpeedAbs.Text, out double speed))
                {
                    MessageBox.Show(
                        "Please enter a valid numeric Speed.",
                        "Invalid input",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return;
                }

                // 6️⃣ Get axis name
                string axisName = string.Empty;
                if (cmbAxisMoveAbs.SelectedItem != null)
                    axisName = ((dynamic)cmbAxisMoveAbs.SelectedItem).Name?.ToString();

                // 7️⃣ 🚫 Allow ONLY Servo_X1 and Servo_X2
                if (axisName != "Servo_X1" && axisName != "Servo_X2")
                {
                    MessageBox.Show(
                        "Only Servo_X1 and Servo_X2 are allowed.",
                        "Axis Not Allowed",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    return;
                }

                // 8️⃣ Safety check for Servo_X1
                if (axisName == "Servo_X1")
                {
                    if (!NozzleSystem.nozzleZ1Z2Safe())
                        return;
                }

                // 9️⃣ Execute JOG
                if (cmbMoveMode.SelectedIndex == 1) // JOG mode
                {
                    ServoAxis.Jog(
                        1,
                        speed,
                        GlobalVariable.g_lstAxisConfig[selAxis].Acc,
                        GlobalVariable.g_lstAxisConfig[selAxis].DeAcc);
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog(
                    Logger.LogType.Error,
                    "RecipieForm",
                    "",
                    ex.Message,
                    ex.ToString());
            }

        }



        //ok
        private void btnXDec_MouseUp(object sender, MouseEventArgs e)
        {
            try
            {
                if (_jogAxis >= 0 && ObjectList.MotorObj.ContainsKey(_jogAxis))
                {
                    ServoAxis = ObjectList.MotorObj[_jogAxis];

                    if (cmbMoveMode.SelectedIndex == 1) // JOG
                    {
                        ServoAxis.StopJog();
                        ServoAxis.Stop();
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog(Logger.LogType.Error, "RecipieForm", "", ex.Message, ex.ToString());
            }
        }


        //ok
        private void btnXAdd_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                int selAxis = -1;

                // 1️⃣ Get selected axis from SelectedValue
                if (cmbAxisMoveAbs.SelectedValue != null)
                {
                    if (cmbAxisMoveAbs.SelectedValue is int)
                        selAxis = (int)cmbAxisMoveAbs.SelectedValue;
                    else
                        int.TryParse(cmbAxisMoveAbs.SelectedValue.ToString(), out selAxis);
                }

                // 2️⃣ Fallback: try SelectedItem.Key
                if (selAxis == -1 && cmbAxisMoveAbs.SelectedItem != null)
                {
                    try
                    {
                        selAxis = (int)((dynamic)cmbAxisMoveAbs.SelectedItem).Key;
                    }
                    catch
                    {
                        selAxis = -1;
                    }
                }

                // 3️⃣ Final fallback
                if (selAxis == -1)
                    selAxis = CurrentAxis != -1 ? CurrentAxis : X_Index;

                CurrentAxis = selAxis;
                _jogAxis = selAxis; // store axis for MouseUp

                // 4️⃣ Get servo axis object
                ServoAxis = ObjectList.MotorObj.ContainsKey(selAxis)
                    ? ObjectList.MotorObj[selAxis]
                    : null;

                if (ServoAxis == null)
                    return;

                // 5️⃣ Validate speed
                if (!double.TryParse(txtetSpeedAbs.Text, out double speed))
                {
                    MessageBox.Show(
                        "Please enter a valid numeric Speed.",
                        "Invalid input",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return;
                }

                // 6️⃣ Get axis name safely
                string axisName = string.Empty;
                if (cmbAxisMoveAbs.SelectedItem != null)
                    axisName = ((dynamic)cmbAxisMoveAbs.SelectedItem).Name?.ToString();

                // 7️⃣ 🚫 Allow ONLY Servo_X1 and Servo_X2
                if (axisName != "Servo_X1" && axisName != "Servo_X2")
                {
                    MessageBox.Show(
                        "Only Servo_X1 and Servo_X2 are allowed for this operation.",
                        "Axis Not Allowed",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    return;
                }

                // 8️⃣ Safety check for Servo_X1
                if (axisName == "Servo_X1")
                {
                    if (!NozzleSystem.nozzleZ1Z2Safe())
                        return;
                }

                // 9️⃣ Execute JOG
                if (cmbMoveMode.SelectedIndex == 1) // JOG mode
                {
                    ServoAxis.Jog(
                        0,
                        speed,
                        GlobalVariable.g_lstAxisConfig[selAxis].Acc,
                        GlobalVariable.g_lstAxisConfig[selAxis].DeAcc);
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog(
                    Logger.LogType.Error,
                    "RecipieForm",
                    "",
                    ex.Message,
                    ex.ToString());
            }

        }


        //ok
        private void btnXAdd_MouseUp(object sender, MouseEventArgs e)
        {
            try
            {
                if (_jogAxis >= 0 && ObjectList.MotorObj.ContainsKey(_jogAxis))
                {
                    ServoAxis = ObjectList.MotorObj[_jogAxis];

                    if (cmbMoveMode.SelectedIndex == 1) // JOG
                    {
                        ServoAxis.StopJog();
                        ServoAxis.Stop();
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog(Logger.LogType.Error, "RecipieForm", "", ex.Message, ex.ToString());
            }
        }


        //ok
        private void btnYAdd_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                int selAxis = -1;

                // 1️⃣ Get selected axis index
                if (cmbAxisMoveAbs.SelectedValue != null)
                {
                    if (cmbAxisMoveAbs.SelectedValue is int)
                        selAxis = (int)cmbAxisMoveAbs.SelectedValue;
                    else
                        int.TryParse(cmbAxisMoveAbs.SelectedValue.ToString(), out selAxis);
                }

                // 2️⃣ Fallback: SelectedItem.Key
                if (selAxis == -1 && cmbAxisMoveAbs.SelectedItem != null)
                {
                    try
                    {
                        selAxis = (int)((dynamic)cmbAxisMoveAbs.SelectedItem).Key;
                    }
                    catch
                    {
                        selAxis = -1;
                    }
                }

                // 3️⃣ Final fallback
                if (selAxis == -1)
                    selAxis = CurrentAxis != -1 ? CurrentAxis : Y_Index;

                CurrentAxis = selAxis;
                _jogAxis = selAxis;   // ✅ used for MouseUp

                // 4️⃣ Get ServoAxis
                ServoAxis = ObjectList.MotorObj.ContainsKey(selAxis)
                            ? ObjectList.MotorObj[selAxis]
                            : null;

                if (ServoAxis == null)
                    return;

                // 5️⃣ Validate speed
                if (!double.TryParse(txtetSpeedAbs.Text, out double speed))
                {
                    MessageBox.Show(
                        "Please enter a valid numeric Speed.",
                        "Invalid input",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return;
                }

                // 6️⃣ Get axis name safely
                string axisName = null;
                try
                {
                    axisName = ServoAxis?.motor_Params?.name
                               ?? ((dynamic)cmbAxisMoveAbs.SelectedItem).Name?.ToString();
                }
                catch
                {
                    axisName = null;
                }

                // 7️⃣ 🚫 Allow ONLY Servo_Y1 and Servo_Y2
                if (string.IsNullOrWhiteSpace(axisName) ||
                    !(axisName.Equals("Servo_Y1", StringComparison.OrdinalIgnoreCase) ||
                      axisName.Equals("Servo_Y2", StringComparison.OrdinalIgnoreCase)))
                {
                    MessageBox.Show(
                        "Only Servo_Y1 and Servo_Y2 are allowed for Y jog.",
                        "Axis Not Allowed",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    return;
                }

                // 8️⃣ Safety check (only for Servo_Y1 if required)
                if (axisName.Equals("Servo_Y1", StringComparison.OrdinalIgnoreCase))
                {
                    if (!NozzleSystem.nozzleZ1Z2Safe())
                        return;
                }

                // 9️⃣ Execute JOG (+ direction)
                if (cmbMoveMode.SelectedIndex == 1) // JOG mode
                {
                    ServoAxis.Jog(
                        0,          // +Y direction
                        speed,
                        GlobalVariable.g_lstAxisConfig[selAxis].Acc,
                        GlobalVariable.g_lstAxisConfig[selAxis].DeAcc);
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog(
                    Logger.LogType.Error,
                    "RecipieForm",
                    "",
                    ex.Message,
                    ex.ToString());
            }
        }


        //ok
        private void btnYAdd_MouseUp(object sender, MouseEventArgs e)
        {
            try
            {
                if (_jogAxis >= 0 && ObjectList.MotorObj.ContainsKey(_jogAxis))
                {
                    ServoAxis = ObjectList.MotorObj[_jogAxis];

                    if (cmbMoveMode.SelectedIndex == 1) // JOG
                    {
                        ServoAxis.StopJog();
                        ServoAxis.Stop();
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog(Logger.LogType.Error, "RecipieForm", "", ex.Message, ex.ToString());
            }
        }

        #region Move and Teach
        private void moveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            XmlNodeList xmlNodes = null;
            try
            {

                double Xposition = 0;
                double Yposition = 0;
                double Z1position = 0;
                double Z2position = 0;
                double R1position = 0;
                double R2position = 0;
                int SelectedTab = tabCalib.SelectedIndex;
                if (SelectedTab == 1)
                {
                    int selectedRow = dgv_Nozzle.CurrentCell.RowIndex;
                    string selectedValue = dgv_Nozzle.CurrentCell.Value.ToString();

                    Xposition = Convert.ToDouble(dgv_Nozzle.Rows[selectedRow].Cells["col(X)"].Value);
                    Yposition = Convert.ToDouble(dgv_Nozzle.Rows[selectedRow].Cells["Row(Y)"].Value);
                    Z1position = GlobalVariable.SafePosition.PositionZ1;
                    Z2position = GlobalVariable.SafePosition.PositionZ2;

                    if (selectedValue.ToLower().Contains("safe"))
                    {
                        SafePrioritynode = Selectednode?.SelectSingleNode("SafePosition_Priority");
                        Operatingnode = SafePrioritynode;
                    }
                    else
                    {
                        Movementnode = Selectednode?.SelectSingleNode("MovementPriority");
                        Operatingnode = Movementnode;
                    }

                    // If an XML-based operating node is available use it, otherwise fall back to a default sequence
                    if (Operatingnode != null)
                    {
                        foreach (XmlNode node in Operatingnode.ChildNodes)
                        {

                            SelectedAxis = FindSelectedIndex(node.InnerText);

                            if (node.InnerText.ToLower().Contains("xaxis"))
                            {
                                MovePosition = Xposition;

                            }
                            else if (node.InnerText.ToLower().Contains("yaxis"))
                            {
                                MovePosition = Yposition;
                            }
                            else if (node.InnerText.ToLower().Contains("zaxis"))
                            {
                                MovePosition = Z1position;
                            }
                            else if (node.InnerText.ToLower().Contains("zaxis"))
                            {
                                MovePosition = Z2position;
                            }
                            else if (node.InnerText.ToLower().Contains("r1"))
                            {
                                MovePosition = R1position;
                            }
                            else if (node.InnerText.ToLower().Contains("r2"))
                            {
                                MovePosition = R2position;
                            }
                            CurrentAxisName = node.InnerText;


                            if (SelectedAxis != -1)
                            {
                                ServoAxis = ObjectList.MotorObj[SelectedAxis];

                                if (!ServoAxis.Move_Abs(MovePosition,
                                    GlobalVariable.g_lstAxisConfig[SelectedAxis].ManualSpeed,
                                    GlobalVariable.g_lstAxisConfig[SelectedAxis].Acc,
                                    GlobalVariable.g_lstAxisConfig[SelectedAxis].DeAcc, 5000))
                                {
                                    string err = node.InnerText + "_Move_cmd_Error";
                                    if (Enum.TryParse<ECode>(err, out var result))
                                    {
                                        GlobalVariable.AlarmTrigger(result, true, 1);
                                    }
                                }
                            }

                        }
                    }
                    else
                    {
                        // Fallback: perform a safe default move sequence: raise Z to safe, move X & Y, then move to target Z
                        try
                        {
                            // Raise Z to safe first (try Z1)
                            if (ObjectList.Servo_Z1 != null)
                            {
                                //ObjectList.Servo_Z1.Move_Abs(GlobalVariable.SafePosition.PositionZ1,
                                //GlobalVariable.g_lstAxisConfig[(int)DIO.DIDO.EAxis.Servo_Z1].ManualSpeed,
                                //GlobalVariable.g_lstAxisConfig[(int)DIO.DIDO.EAxis.Servo_Z1].Acc,
                                //GlobalVariable.g_lstAxisConfig[(int)DIO.DIDO.EAxis.Servo_Z1].DeAcc, 5000);
                                ObjectList.Servo_Z1.Move_Abs(GlobalVariable.SafePosition.PositionZ1, 200, 400, 400, 5000);
                            }

                            // Move X and Y together
                            Task t1 = Task.Run(() => { if (ObjectList.Servo_X1 != null) ObjectList.Servo_X1.Move_Abs(Xposition, 200, 1000, 1000, 10000); });
                            Task t2 = Task.Run(() => { if (ObjectList.Servo_Y1 != null) ObjectList.Servo_Y1.Move_Abs(Yposition, 200, 1000, 1000, 10000); });
                            Task.WaitAll(new Task[] { t1, t2 });

                            // Move Z to the target Z1 position (if specified in CSV use Z1position variable)
                            if (ObjectList.Servo_Z1 != null)
                            {
                                ObjectList.Servo_Z1.Move_Abs(Z1position, GlobalVariable.g_lstAxisConfig[(int)DIO.DIDO.EAxis.Servo_Z1].ManualSpeed, GlobalVariable.g_lstAxisConfig[(int)DIO.DIDO.EAxis.Servo_Z1].Acc, GlobalVariable.g_lstAxisConfig[(int)DIO.DIDO.EAxis.Servo_Z1].DeAcc, 5000);
                            }
                        }
                        catch (Exception ex)
                        {
                            Logger.WriteLog(Logger.LogType.Error, "ReceipeForm", "moveToolStripMenuItem_Click.Fallback", ex.Message, ex.ToString());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog(Logger.LogType.Error, "ReceipeForm", "", ex.Message, ex.ToString());
            }

        }

        private void cmbAxisMoveAbs_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void cmbAxisMoveAbs_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void txtetSpeedAbs_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && (e.KeyCode == Keys.C || e.KeyCode == Keys.V || e.KeyCode == Keys.X))
            {
                e.SuppressKeyPress = true;
            }
        }

        private void txtetSpeedAbs_KeyPress(object sender, KeyPressEventArgs e)
        {
            System.Windows.Forms.TextBox txt = sender as System.Windows.Forms.TextBox;
            GlobalVariable.ApplyTextBoxConfig(txt, "CrrCynSpeedLen", e, allowDecimal: true, allowMinus: false);
            if (txt.Text.Length == 0 && e.KeyChar == '0')
                e.Handled = true;
        }

        private void txtetSpeedAbs_MouseDown(object sender, MouseEventArgs e)
        {
            // Disable right-click context menu
            if (e.Button == MouseButtons.Right)
            {
                ((System.Windows.Forms.TextBox)sender).ContextMenu = new ContextMenu(); // Assign empty menu
                return;
            }
        }

        private void txtetSpeedAbs_MouseUp(object sender, MouseEventArgs e)
        {
            // Prevent paste via mouse right-click
            if (e.Button == MouseButtons.Right)
            {
                return;
            }
        }

        private void txtPositionAbs_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && (e.KeyCode == Keys.C || e.KeyCode == Keys.V || e.KeyCode == Keys.X))
            {
                e.SuppressKeyPress = true;
            }
        }

        private void txtPositionAbs_KeyPress(object sender, KeyPressEventArgs e)
        {
            System.Windows.Forms.TextBox txt = sender as System.Windows.Forms.TextBox;
            GlobalVariable.ApplyTextBoxConfig(txt, "CrrCynSpeedLen", e, allowDecimal: true, allowMinus: true);
        }

        private void txtPositionAbs_MouseDown(object sender, MouseEventArgs e)
        {
            // Disable right-click context menu
            if (e.Button == MouseButtons.Right)
            {
                ((System.Windows.Forms.TextBox)sender).ContextMenu = new ContextMenu(); // Assign empty menu
                return;
            }
        }

        private void txtPositionAbs_MouseUp(object sender, MouseEventArgs e)
        {
            // Prevent paste via mouse right-click
            if (e.Button == MouseButtons.Right)
            {
                return;
            }
        }

        private void timer2_Tick_1(object sender, EventArgs e)
        {
            try
            {
                // Z1Axis = ObjectList.Servo_Z1.GetCurrentPosition();
                //  XAxis = ObjectList.Servo_X1.GetCurrentPosition();
                //FlipperAxis = ObjectList.FlipperAxis.GetCurrentPosition();
                //txt_PrfPos_X1.Text = XAxis.ToString("F2");
                //txt_PrfPos_Y1.Text = FlipperAxis.ToString("F2");
                //txt_PrfPos_Z1.Text = ZAxis.ToString("F2");
                //CurrentAxis = (int)((dynamic)cmbAxisMoveAbs.SelectedItem).Key;
                // GlobalVariable.Loadcelchkbox = LoaddellChk.Checked ? true : false; // AK
                if (CurrentAxis != -1)
                {
                    TmrServoAxis = ObjectList.MotorObj[CurrentAxis];

                    double ActPos = 0;
                    double ActPvel = 0;
                    string actstatus = "";
                    ServoAxis.GetCurrentPos(out ActPos, out actstatus, out ActPvel);
                    bool[] ioStatusArray = TmrServoAxis.ToGetMotionIOStatus();

                    if (CurrentAxisName.Contains("Servo_X1") || CurrentAxisName.Contains("Servo_X2"))
                    {
                        txt_PrfPos_X1.Text = ActPos.ToString("F2");
                    }
                    else if (CurrentAxisName.Contains("Servo_Y1") || CurrentAxisName.Contains("Servo_Y2"))
                    {
                        txt_PrfPos_Y1.Text = ActPos.ToString("F2");
                    }
                    else if (CurrentAxisName.Contains("Servo_Z1"))
                    {
                        txt_PrfPos_Z1.Text = ActPos.ToString("F2");
                    }
                    else if (CurrentAxisName.Contains("Servo_Z2"))
                    {
                        txt_PrfPos_Z2.Text = ActPos.ToString("F2");
                    }
                    else if (CurrentAxisName.Contains("Servo_R2"))
                    {
                        txt_PrfPos_R2.Text = ActPos.ToString("F2");
                    }
                    else if (CurrentAxisName.Contains("Servo_R1"))
                    {
                        txt_PrfPos_R1.Text = ActPos.ToString("F2");
                    }



                }


            }
            catch (Exception ex)
            {
                Logger.WriteLog(Logger.LogType.Error, "RecipieForm", "", ex.Message, ex.ToString());
            }

        }

        private void tabCameraCali_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (tabCalib.SelectedIndex == 1)
                {
                    panel2.Visible = false;
                    btn_edit.Enabled = true;
                }
                else
                {
                    panel2.Visible = true;
                    var selectedTab = tabCalib.SelectedTab;
                    grpGantry.Text = (selectedTab.Text.ToLower() == "robot") ? "Robot" : "Gantry";
                    if (grpGantry.Text == "Gantry" & cmb_Nozzle.Text != "Select")
                    {
                        grpGantry.Text = cmb_Nozzle.Text;
                    }
                    cmbMoveMode.SelectedIndex = 0;
                    cmbAxisMoveAbs.SelectedIndex = 0;
                    txtetSpeedAbs.Text = "";
                    txtPositionAbs.Text = "";
                    txt_PrfPos_X1.Text = "0";
                    txt_PrfPos_Y1.Text = "0";
                    //txt_PrfPos_Z1.Text = "0";
                    //textBox62.Text = "0000";
                    //textBox63.Text = "0000";
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog(Logger.LogType.Error, "ReceipeForm", "", ex.Message, ex.ToString());
            }
        }

        //Servo_Z1 and Servo_z2
        private void btnZAdd_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                int selAxis = -1;

                // 1️⃣ Get selected axis
                if (cmbAxisMoveAbs.SelectedValue != null)
                {
                    if (cmbAxisMoveAbs.SelectedValue is int)
                        selAxis = (int)cmbAxisMoveAbs.SelectedValue;
                    else
                        int.TryParse(cmbAxisMoveAbs.SelectedValue.ToString(), out selAxis);
                }

                // 2️⃣ Fallback: SelectedItem.Key
                if (selAxis == -1 && cmbAxisMoveAbs.SelectedItem != null)
                {
                    try
                    {
                        selAxis = (int)((dynamic)cmbAxisMoveAbs.SelectedItem).Key;
                    }
                    catch
                    {
                        selAxis = -1;
                    }
                }

                // 3️⃣ Final fallback
                if (selAxis == -1)
                    selAxis = CurrentAxis != -1 ? CurrentAxis : Z_Index;

                CurrentAxis = selAxis;
                _jogAxis = selAxis;   // ✅ store axis for MouseUp

                // 4️⃣ Get servo object
                ServoAxis = ObjectList.MotorObj.ContainsKey(selAxis)
                            ? ObjectList.MotorObj[selAxis]
                            : null;

                if (ServoAxis == null)
                    return;

                // 5️⃣ Validate speed
                if (!double.TryParse(txtetSpeedAbs.Text, out double speed))
                {
                    MessageBox.Show(
                        "Please enter a valid numeric Speed.",
                        "Invalid input",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return;
                }

                // 6️⃣ Get axis name
                string axisName = string.Empty;
                if (cmbAxisMoveAbs.SelectedItem != null)
                    axisName = ((dynamic)cmbAxisMoveAbs.SelectedItem).Name?.ToString();

                // 7️⃣ 🚫 Allow ONLY Servo_Z1
                if (axisName != "Servo_Z1")
                {
                    MessageBox.Show(
                        "Only Servo_Z1 is allowed.",
                        "Axis Not Allowed",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    return;
                }

                // 8️⃣ Execute JOG (Z-axis)
                if (cmbMoveMode.SelectedIndex == 1) // JOG mode
                {
                    ServoAxis.Jog(
                        0, // direction +Z
                        speed,
                        GlobalVariable.g_lstAxisConfig[selAxis].Acc,
                        GlobalVariable.g_lstAxisConfig[selAxis].DeAcc);
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog(
                    Logger.LogType.Error,
                    "RecipieForm",
                    "",
                    ex.Message,
                    ex.ToString());
            }

        }

        private void btnZAdd_MouseUp(object sender, MouseEventArgs e)
        {
            try
            {
                if (_jogAxis >= 0 && ObjectList.MotorObj.ContainsKey(_jogAxis))
                {
                    ServoAxis = ObjectList.MotorObj[_jogAxis];

                    if (cmbMoveMode.SelectedIndex == 1) // JOG
                    {
                        ServoAxis.StopJog();
                        ServoAxis.Stop();
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog(Logger.LogType.Error, "RecipieForm", "", ex.Message, ex.ToString());
            }
        }

        private void btnZDec_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                int selAxis = -1;

                // 1️⃣ Get selected axis
                if (cmbAxisMoveAbs.SelectedValue != null)
                {
                    if (cmbAxisMoveAbs.SelectedValue is int)
                        selAxis = (int)cmbAxisMoveAbs.SelectedValue;
                    else
                        int.TryParse(cmbAxisMoveAbs.SelectedValue.ToString(), out selAxis);
                }

                // 2️⃣ Fallback: SelectedItem.Key
                if (selAxis == -1 && cmbAxisMoveAbs.SelectedItem != null)
                {
                    try
                    {
                        selAxis = (int)((dynamic)cmbAxisMoveAbs.SelectedItem).Key;
                    }
                    catch
                    {
                        selAxis = -1;
                    }
                }

                // 3️⃣ Final fallback
                if (selAxis == -1)
                    selAxis = CurrentAxis != -1 ? CurrentAxis : Z_Index;

                CurrentAxis = selAxis;
                _jogAxis = selAxis;   // ✅ store axis for MouseUp

                // 4️⃣ Get servo object
                ServoAxis = ObjectList.MotorObj.ContainsKey(selAxis)
                            ? ObjectList.MotorObj[selAxis]
                            : null;

                if (ServoAxis == null)
                    return;

                // 5️⃣ Validate speed
                if (!double.TryParse(txtetSpeedAbs.Text, out double speed))
                {
                    MessageBox.Show(
                        "Please enter a valid numeric Speed.",
                        "Invalid input",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return;
                }

                // 6️⃣ Get axis name
                string axisName = string.Empty;
                if (cmbAxisMoveAbs.SelectedItem != null)
                    axisName = ((dynamic)cmbAxisMoveAbs.SelectedItem).Name?.ToString();

                // 7️⃣ 🚫 Allow ONLY Servo_Z1
                if (axisName != "Servo_Z1")
                {
                    MessageBox.Show(
                        "Only Servo_Z1 is allowed.",
                        "Axis Not Allowed",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    return;
                }

                // 8️⃣ Execute JOG (Z-axis)
                if (cmbMoveMode.SelectedIndex == 1) // JOG mode
                {
                    ServoAxis.Jog(
                        1, // direction +Z
                        speed,
                        GlobalVariable.g_lstAxisConfig[selAxis].Acc,
                        GlobalVariable.g_lstAxisConfig[selAxis].DeAcc);
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog(
                    Logger.LogType.Error,
                    "RecipieForm",
                    "",
                    ex.Message,
                    ex.ToString());
            }
        }

        private void btnZDec_MouseUp(object sender, MouseEventArgs e)
        {
            try
            {
                if (_jogAxis >= 0 && ObjectList.MotorObj.ContainsKey(_jogAxis))
                {
                    ServoAxis = ObjectList.MotorObj[_jogAxis];

                    if (cmbMoveMode.SelectedIndex == 1) // JOG
                    {
                        ServoAxis.StopJog();
                        ServoAxis.Stop();
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog(Logger.LogType.Error, "RecipieForm", "", ex.Message, ex.ToString());
            }
        }
        //Servo_Z1 and Servo_Z2
        private void btnZ2Add_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                int selAxis = -1;

                // 1️⃣ Get selected axis
                if (cmbAxisMoveAbs.SelectedValue != null)
                {
                    if (cmbAxisMoveAbs.SelectedValue is int)
                        selAxis = (int)cmbAxisMoveAbs.SelectedValue;
                    else
                        int.TryParse(cmbAxisMoveAbs.SelectedValue.ToString(), out selAxis);
                }

                // 2️⃣ Fallback: SelectedItem.Key
                if (selAxis == -1 && cmbAxisMoveAbs.SelectedItem != null)
                {
                    try
                    {
                        selAxis = (int)((dynamic)cmbAxisMoveAbs.SelectedItem).Key;
                    }
                    catch
                    {
                        selAxis = -1;
                    }
                }

                // 3️⃣ Final fallback
                if (selAxis == -1)
                    selAxis = CurrentAxis != -1 ? CurrentAxis : Z_Index;

                CurrentAxis = selAxis;
                _jogAxis = selAxis;   // ✅ store axis for MouseUp

                // 4️⃣ Get servo object
                ServoAxis = ObjectList.MotorObj.ContainsKey(selAxis)
                            ? ObjectList.MotorObj[selAxis]
                            : null;

                if (ServoAxis == null)
                    return;

                // 5️⃣ Validate speed
                if (!double.TryParse(txtetSpeedAbs.Text, out double speed))
                {
                    MessageBox.Show(
                        "Please enter a valid numeric Speed.",
                        "Invalid input",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return;
                }

                // 6️⃣ Get axis name
                string axisName = string.Empty;
                if (cmbAxisMoveAbs.SelectedItem != null)
                    axisName = ((dynamic)cmbAxisMoveAbs.SelectedItem).Name?.ToString();

                // 7️⃣ 🚫 Allow ONLY Servo_Z1
                if (axisName != "Servo_Z2")
                {
                    MessageBox.Show(
                        "Only Servo_Z1 is allowed.",
                        "Axis Not Allowed",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    return;
                }

                // 8️⃣ Execute JOG (Z-axis)
                if (cmbMoveMode.SelectedIndex == 1) // JOG mode
                {
                    ServoAxis.Jog(
                        0, // direction +Z
                        speed,
                        GlobalVariable.g_lstAxisConfig[selAxis].Acc,
                        GlobalVariable.g_lstAxisConfig[selAxis].DeAcc);
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog(
                    Logger.LogType.Error,
                    "RecipieForm",
                    "",
                    ex.Message,
                    ex.ToString());
            }
        }

        private void btnZ2Add_MouseUp(object sender, MouseEventArgs e)
        {
            try
            {
                if (_jogAxis >= 0 && ObjectList.MotorObj.ContainsKey(_jogAxis))
                {
                    ServoAxis = ObjectList.MotorObj[_jogAxis];

                    if (cmbMoveMode.SelectedIndex == 1) // JOG
                    {
                        ServoAxis.StopJog();
                        ServoAxis.Stop();
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog(Logger.LogType.Error, "RecipieForm", "", ex.Message, ex.ToString());
            }
        }
        //Sero_Z2
        private void btnZ2Dec_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                int selAxis = -1;

                // 1️⃣ Get selected axis
                if (cmbAxisMoveAbs.SelectedValue != null)
                {
                    if (cmbAxisMoveAbs.SelectedValue is int)
                        selAxis = (int)cmbAxisMoveAbs.SelectedValue;
                    else
                        int.TryParse(cmbAxisMoveAbs.SelectedValue.ToString(), out selAxis);
                }

                // 2️⃣ Fallback: SelectedItem.Key
                if (selAxis == -1 && cmbAxisMoveAbs.SelectedItem != null)
                {
                    try
                    {
                        selAxis = (int)((dynamic)cmbAxisMoveAbs.SelectedItem).Key;
                    }
                    catch
                    {
                        selAxis = -1;
                    }
                }

                // 3️⃣ Final fallback
                if (selAxis == -1)
                    selAxis = CurrentAxis != -1 ? CurrentAxis : Z_Index;

                CurrentAxis = selAxis;
                _jogAxis = selAxis;   // ✅ store axis for MouseUp

                // 4️⃣ Get servo object
                ServoAxis = ObjectList.MotorObj.ContainsKey(selAxis)
                            ? ObjectList.MotorObj[selAxis]
                            : null;

                if (ServoAxis == null)
                    return;

                // 5️⃣ Validate speed
                if (!double.TryParse(txtetSpeedAbs.Text, out double speed))
                {
                    MessageBox.Show(
                        "Please enter a valid numeric Speed.",
                        "Invalid input",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return;
                }

                // 6️⃣ Get axis name
                string axisName = string.Empty;
                if (cmbAxisMoveAbs.SelectedItem != null)
                    axisName = ((dynamic)cmbAxisMoveAbs.SelectedItem).Name?.ToString();

                // 7️⃣ 🚫 Allow ONLY Servo_Z1
                if (axisName != "Servo_Z2")
                {
                    MessageBox.Show(
                        "Only Servo_Z1 is allowed.",
                        "Axis Not Allowed",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    return;
                }

                // 8️⃣ Execute JOG (Z-axis)
                if (cmbMoveMode.SelectedIndex == 1) // JOG mode
                {
                    ServoAxis.Jog(
                        1, // direction +Z
                        speed,
                        GlobalVariable.g_lstAxisConfig[selAxis].Acc,
                        GlobalVariable.g_lstAxisConfig[selAxis].DeAcc);
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog(
                    Logger.LogType.Error,
                    "RecipieForm",
                    "",
                    ex.Message,
                    ex.ToString());
            }
        }

        private void btnZ2Dec_MouseUp(object sender, MouseEventArgs e)
        {
            try
            {
                if (_jogAxis >= 0 && ObjectList.MotorObj.ContainsKey(_jogAxis))
                {
                    ServoAxis = ObjectList.MotorObj[_jogAxis];

                    if (cmbMoveMode.SelectedIndex == 1) // JOG
                    {
                        ServoAxis.StopJog();
                        ServoAxis.Stop();
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog(Logger.LogType.Error, "RecipieForm", "", ex.Message, ex.ToString());
            }
        }
        //R1
        private void btnR1Add_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                int selAxis = -1;

                // 1️⃣ Get selected axis
                if (cmbAxisMoveAbs.SelectedValue != null)
                {
                    if (cmbAxisMoveAbs.SelectedValue is int)
                        selAxis = (int)cmbAxisMoveAbs.SelectedValue;
                    else
                        int.TryParse(cmbAxisMoveAbs.SelectedValue.ToString(), out selAxis);
                }

                // 2️⃣ Fallback: SelectedItem.Key
                if (selAxis == -1 && cmbAxisMoveAbs.SelectedItem != null)
                {
                    try
                    {
                        selAxis = (int)((dynamic)cmbAxisMoveAbs.SelectedItem).Key;
                    }
                    catch
                    {
                        selAxis = -1;
                    }
                }

                // 3️⃣ Final fallback
                if (selAxis == -1)
                    selAxis = CurrentAxis != -1 ? CurrentAxis : Z_Index;

                CurrentAxis = selAxis;
                _jogAxis = selAxis;   // ✅ store axis for MouseUp

                // 4️⃣ Get servo object
                ServoAxis = ObjectList.MotorObj.ContainsKey(selAxis)
                            ? ObjectList.MotorObj[selAxis]
                            : null;

                if (ServoAxis == null)
                    return;

                // 5️⃣ Validate speed
                if (!double.TryParse(txtetSpeedAbs.Text, out double speed))
                {
                    MessageBox.Show(
                        "Please enter a valid numeric Speed.",
                        "Invalid input",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return;
                }

                // 6️⃣ Get axis name
                string axisName = string.Empty;
                if (cmbAxisMoveAbs.SelectedItem != null)
                    axisName = ((dynamic)cmbAxisMoveAbs.SelectedItem).Name?.ToString();

                // 7️⃣ 🚫 Allow ONLY Servo_Z1
                if (axisName != "Servo_R1")
                {
                    MessageBox.Show(
                        "Only Servo_Z1 is allowed.",
                        "Axis Not Allowed",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    return;
                }

                // 8️⃣ Execute JOG (Z-axis)
                if (cmbMoveMode.SelectedIndex == 1) // JOG mode
                {
                    ServoAxis.Jog(
                        0, // direction +Z
                        speed,
                        GlobalVariable.g_lstAxisConfig[selAxis].Acc,
                        GlobalVariable.g_lstAxisConfig[selAxis].DeAcc);
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog(
                    Logger.LogType.Error,
                    "RecipieForm",
                    "",
                    ex.Message,
                    ex.ToString());
            }
        }

        private void btnR1Add_MouseUp(object sender, MouseEventArgs e)
        {
            try
            {
                if (_jogAxis >= 0 && ObjectList.MotorObj.ContainsKey(_jogAxis))
                {
                    ServoAxis = ObjectList.MotorObj[_jogAxis];

                    if (cmbMoveMode.SelectedIndex == 1) // JOG
                    {
                        ServoAxis.StopJog();
                        ServoAxis.Stop();
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog(Logger.LogType.Error, "RecipieForm", "", ex.Message, ex.ToString());
            }
        }

        private void btnR1Dec_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                int selAxis = -1;

                // 1️⃣ Get selected axis
                if (cmbAxisMoveAbs.SelectedValue != null)
                {
                    if (cmbAxisMoveAbs.SelectedValue is int)
                        selAxis = (int)cmbAxisMoveAbs.SelectedValue;
                    else
                        int.TryParse(cmbAxisMoveAbs.SelectedValue.ToString(), out selAxis);
                }

                // 2️⃣ Fallback: SelectedItem.Key
                if (selAxis == -1 && cmbAxisMoveAbs.SelectedItem != null)
                {
                    try
                    {
                        selAxis = (int)((dynamic)cmbAxisMoveAbs.SelectedItem).Key;
                    }
                    catch
                    {
                        selAxis = -1;
                    }
                }

                // 3️⃣ Final fallback
                if (selAxis == -1)
                    selAxis = CurrentAxis != -1 ? CurrentAxis : Z_Index;

                CurrentAxis = selAxis;
                _jogAxis = selAxis;   // ✅ store axis for MouseUp

                // 4️⃣ Get servo object
                ServoAxis = ObjectList.MotorObj.ContainsKey(selAxis)
                            ? ObjectList.MotorObj[selAxis]
                            : null;

                if (ServoAxis == null)
                    return;

                // 5️⃣ Validate speed
                if (!double.TryParse(txtetSpeedAbs.Text, out double speed))
                {
                    MessageBox.Show(
                        "Please enter a valid numeric Speed.",
                        "Invalid input",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return;
                }

                // 6️⃣ Get axis name
                string axisName = string.Empty;
                if (cmbAxisMoveAbs.SelectedItem != null)
                    axisName = ((dynamic)cmbAxisMoveAbs.SelectedItem).Name?.ToString();

                // 7️⃣ 🚫 Allow ONLY Servo_Z1
                if (axisName != "Servo_R1")
                {
                    MessageBox.Show(
                        "Only Servo_Z1 is allowed.",
                        "Axis Not Allowed",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    return;
                }

                // 8️⃣ Execute JOG (Z-axis)
                if (cmbMoveMode.SelectedIndex == 1) // JOG mode
                {
                    ServoAxis.Jog(
                        1, // direction +Z
                        speed,
                        GlobalVariable.g_lstAxisConfig[selAxis].Acc,
                        GlobalVariable.g_lstAxisConfig[selAxis].DeAcc);
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog(
                    Logger.LogType.Error,
                    "RecipieForm",
                    "",
                    ex.Message,
                    ex.ToString());
            }
        }

        private void btnR1Dec_MouseUp(object sender, MouseEventArgs e)
        {
            try
            {
                if (_jogAxis >= 0 && ObjectList.MotorObj.ContainsKey(_jogAxis))
                {
                    ServoAxis = ObjectList.MotorObj[_jogAxis];

                    if (cmbMoveMode.SelectedIndex == 1) // JOG
                    {
                        ServoAxis.StopJog();
                        ServoAxis.Stop();
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog(Logger.LogType.Error, "RecipieForm", "", ex.Message, ex.ToString());
            }
        }
        //R1

        //R2
        private void btnR2Add_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                int selAxis = -1;

                // 1️⃣ Get selected axis
                if (cmbAxisMoveAbs.SelectedValue != null)
                {
                    if (cmbAxisMoveAbs.SelectedValue is int)
                        selAxis = (int)cmbAxisMoveAbs.SelectedValue;
                    else
                        int.TryParse(cmbAxisMoveAbs.SelectedValue.ToString(), out selAxis);
                }

                // 2️⃣ Fallback: SelectedItem.Key
                if (selAxis == -1 && cmbAxisMoveAbs.SelectedItem != null)
                {
                    try
                    {
                        selAxis = (int)((dynamic)cmbAxisMoveAbs.SelectedItem).Key;
                    }
                    catch
                    {
                        selAxis = -1;
                    }
                }

                // 3️⃣ Final fallback
                if (selAxis == -1)
                    selAxis = CurrentAxis != -1 ? CurrentAxis : Z_Index;

                CurrentAxis = selAxis;
                _jogAxis = selAxis;   // ✅ store axis for MouseUp

                // 4️⃣ Get servo object
                ServoAxis = ObjectList.MotorObj.ContainsKey(selAxis)
                            ? ObjectList.MotorObj[selAxis]
                            : null;

                if (ServoAxis == null)
                    return;

                // 5️⃣ Validate speed
                if (!double.TryParse(txtetSpeedAbs.Text, out double speed))
                {
                    MessageBox.Show(
                        "Please enter a valid numeric Speed.",
                        "Invalid input",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return;
                }

                // 6️⃣ Get axis name
                string axisName = string.Empty;
                if (cmbAxisMoveAbs.SelectedItem != null)
                    axisName = ((dynamic)cmbAxisMoveAbs.SelectedItem).Name?.ToString();

                // 7️⃣ 🚫 Allow ONLY Servo_Z1
                if (axisName != "Servo_R2")
                {
                    MessageBox.Show(
                        "Only Servo_Z1 is allowed.",
                        "Axis Not Allowed",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    return;
                }

                // 8️⃣ Execute JOG (Z-axis)
                if (cmbMoveMode.SelectedIndex == 1) // JOG mode
                {
                    ServoAxis.Jog(
                        0, // direction +Z
                        speed,
                        GlobalVariable.g_lstAxisConfig[selAxis].Acc,
                        GlobalVariable.g_lstAxisConfig[selAxis].DeAcc);
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog(
                    Logger.LogType.Error,
                    "RecipieForm",
                    "",
                    ex.Message,
                    ex.ToString());
            }
        }

        private void btnR2Add_MouseUp(object sender, MouseEventArgs e)
        {
            try
            {
                if (_jogAxis >= 0 && ObjectList.MotorObj.ContainsKey(_jogAxis))
                {
                    ServoAxis = ObjectList.MotorObj[_jogAxis];

                    if (cmbMoveMode.SelectedIndex == 1) // JOG
                    {
                        ServoAxis.StopJog();
                        ServoAxis.Stop();
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog(Logger.LogType.Error, "RecipieForm", "", ex.Message, ex.ToString());
            }
        }



        private void btnR2Dec_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                int selAxis = -1;

                // 1️⃣ Get selected axis
                if (cmbAxisMoveAbs.SelectedValue != null)
                {
                    if (cmbAxisMoveAbs.SelectedValue is int)
                        selAxis = (int)cmbAxisMoveAbs.SelectedValue;
                    else
                        int.TryParse(cmbAxisMoveAbs.SelectedValue.ToString(), out selAxis);
                }

                // 2️⃣ Fallback: SelectedItem.Key
                if (selAxis == -1 && cmbAxisMoveAbs.SelectedItem != null)
                {
                    try
                    {
                        selAxis = (int)((dynamic)cmbAxisMoveAbs.SelectedItem).Key;
                    }
                    catch
                    {
                        selAxis = -1;
                    }
                }

                // 3️⃣ Final fallback
                if (selAxis == -1)
                    selAxis = CurrentAxis != -1 ? CurrentAxis : Z_Index;

                CurrentAxis = selAxis;
                _jogAxis = selAxis;   // ✅ store axis for MouseUp

                // 4️⃣ Get servo object
                ServoAxis = ObjectList.MotorObj.ContainsKey(selAxis)
                            ? ObjectList.MotorObj[selAxis]
                            : null;

                if (ServoAxis == null)
                    return;

                // 5️⃣ Validate speed
                if (!double.TryParse(txtetSpeedAbs.Text, out double speed))
                {
                    MessageBox.Show(
                        "Please enter a valid numeric Speed.",
                        "Invalid input",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return;
                }

                // 6️⃣ Get axis name
                string axisName = string.Empty;
                if (cmbAxisMoveAbs.SelectedItem != null)
                    axisName = ((dynamic)cmbAxisMoveAbs.SelectedItem).Name?.ToString();

                // 7️⃣ 🚫 Allow ONLY Servo_Z1
                if (axisName != "Servo_R2")
                {
                    MessageBox.Show(
                        "Only Servo_Z1 is allowed.",
                        "Axis Not Allowed",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    return;
                }

                // 8️⃣ Execute JOG (Z-axis)
                if (cmbMoveMode.SelectedIndex == 1) // JOG mode
                {
                    ServoAxis.Jog(
                        1, // direction +Z
                        speed,
                        GlobalVariable.g_lstAxisConfig[selAxis].Acc,
                        GlobalVariable.g_lstAxisConfig[selAxis].DeAcc);
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog(
                    Logger.LogType.Error,
                    "RecipieForm",
                    "",
                    ex.Message,
                    ex.ToString());
            }
        }

        private void btnR2Dec_MouseUp(object sender, MouseEventArgs e)
        {
            try
            {
                if (_jogAxis >= 0 && ObjectList.MotorObj.ContainsKey(_jogAxis))
                {
                    ServoAxis = ObjectList.MotorObj[_jogAxis];

                    if (cmbMoveMode.SelectedIndex == 1) // JOG
                    {
                        ServoAxis.StopJog();
                        ServoAxis.Stop();
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog(Logger.LogType.Error, "RecipieForm", "", ex.Message, ex.ToString());
            }
        }

        private void rdoScanner1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private async void button4_Click(object sender, EventArgs e)
        {

            string SelectedScannerType;
            string ScannerTrigerdata;
            //if (!GlobalVariable.bhomeseq_running)
            //{
            //    MessageBox.Show("Please start the Homing process for Safe Purpose", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            //    return;
            //}
            if (!rdoScan1.Checked)
            {
                MessageBox.Show("Please Select the Any one Scanner", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int count;  //Handle Only Numeric values are valid keypress
            if (txtRepetabilityCountValue.Text.Trim() == "" || lblRuncountTimeVal.Text != "0" || lblRuncountTimeVal.Text.Trim() == "-")
            {
                MessageBox.Show("Please Enter the ValidScanner RepetabilityCountValue", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            count = Convert.ToInt32(txtRepetabilityCountValue.Text);

            //Bypass 
            //GlobalVariable.Scanner_Bypass = 

            if (GlobalVariable.Scanner_Bypass)
            {
                //Stop the Sequence call the stop Button
                MessageBox.Show("Not Configured the ScannerBypass ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (rdoScan1.Checked)
            {
                SelectedScannerType = rdoScan1.Text.ToString();
                if (ObjectList.Barcode_Scanner.Connect())
                {
                    MessageBox.Show("Connecting the LeftBarcodeScanner", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (ObjectList.Barcode_Scanner.IsConnected)
                    {
                        MessageBox.Show("Connected the LeftBarcodeScanner", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        if (ObjectList.Barcode_Scanner.CheckConnectStatus())
                        {
                            MessageBox.Show("Selected the ConnectStatus LeftBarcodeScanner", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            if (!GlobalVariable.Scanner_Bypass)
                            {
                                MessageBox.Show("Configured the ByPassScanner", "Confirmation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                for (int i = 0; i < count; i++)
                                {
                                    string countvalue = Convert.ToString((i + 1));
                                    lblRuncountTimeVal.Text = countvalue;
                                    ObjectList.Barcode_Scanner.Connect();
                                    SCANRepetability_Received_String.Clear();
                                    ObjectList.Barcode_Scanner.Send("READ");
                                    //Arulkumar Fixed Hung start
                                    await Task.Delay(200);
                                    //Arulkumar Fixed Hung end
                                    ScannerTrigerdata = ObjectList.Barcode_Scanner.Receive(600001).ToString()?.Trim() ?? "NOCODE";


                                    if (!string.IsNullOrEmpty(ScannerTrigerdata))
                                    {
                                        string Get_carrier = ScannerTrigerdata.Replace("\r", "").Replace("\n", "").Replace("READ", "").Trim();

                                        if (Get_carrier == "")
                                        {
                                            Get_carrier = "NOCODE";
                                        }
                                        string ProductionDATAFilePAth = "D:\\TEAL\\.";
                                        SCANRepetability_Received_String.Add(ScannerTrigerdata);
                                        string path = ProductionDATAFilePAth + @"\Static_Data_Scanner\";
                                        WriteDataToCSVScanStatic(path, SelectedScannerType, ScannerTrigerdata);

                                    }
                                }
                                MessageBox.Show("LeftBarcodeScanner Log  Datas are Stored in the ExcelFile", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }


                    }
                }
                else
                {
                    MessageBox.Show("LeftBarcodeScanner is not Connected", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                ObjectList.Barcode_Scanner.Disconnect();
                ObjectList.Barcode_Scanner.Dispose();
            }
        }


        public static void WriteDataToCSVScanStatic(string filepath, string SelectedScanner, string Scanner1Trigerdata)
        {
            StringBuilder sFilename = new StringBuilder();
            string pathLocation = filepath + DateTime.Now.ToString("dd_MM_yyyy_hh") + ".csv";
            Process[] processes = Process.GetProcessesByName("Excel");
            foreach (Process process in processes)
            {
                if (process.MainWindowTitle.Contains(pathLocation))
                {
                    //Arulkumar Fixed random stoppage start
                    try
                    {
                        process.Kill();
                        Thread.Sleep(100);
                    }
                    catch (Exception ex)
                    {
                        Logger.WriteLog(Logger.LogType.Error, "Settings", "WriteDataToCSVScanStatic.KillExcel", ex.Message, ex.ToString());
                    }
                    //Arulkumar Fixed random stoppage end
                }
            }

            if (!Directory.Exists(filepath))
            {
                Directory.CreateDirectory(filepath);
            }

            if (!File.Exists(pathLocation))
            {
                using (StreamWriter sw = new StreamWriter(pathLocation, true))
                {
                    sw.WriteLine("SelectedScannerType , Barcode , DateTime");
                }
            }
            using (StreamWriter sw = new StreamWriter(pathLocation, true))
            {
                string SelectedScannerType = SelectedScanner;
                string BarcodeValue = Scanner1Trigerdata;
                sw.WriteLine($" {SelectedScannerType},{Scanner1Trigerdata} ,{DateTime.Now.ToString("yyy_MM_dd hh:mm:ss:ffff tt")}");

                sw.Close();
                sw.Dispose();
            }
        }

        private void btnSveLod_Click(object sender, EventArgs e)
        {
            GlobalVariable.Loadcelchkbox = LoaddellChk.Checked ? true : false;

        }

        private void btnSveLod_MouseUp(object sender, MouseEventArgs e)
        {
            //LoaddellChk.Checked = false;
            //GlobalVariable.Loadcelchkbox = false;

        }


        //R2

        private void teachToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int SelectedTab = tabCalib.SelectedIndex;

            try
            {
                if (SelectedTab != 0)
                    return; // Only run on first tab

                if (dgv_Nozzle.ReadOnly)
                    return;

                var currentCell = dgv_Nozzle.CurrentCell;
                if (currentCell == null)
                    return;

                int selectedRow = currentCell.RowIndex;
                int selectedCol = currentCell.ColumnIndex;

                // Identify the clicked column robustly
                DataGridViewColumn selectedColumn = dgv_Nozzle.Columns[selectedCol];
                string colIdentifier = (selectedColumn.Name ?? string.Empty) + "|" +
                                       (selectedColumn.HeaderText ?? string.Empty) + "|" +
                                       (selectedColumn.DataPropertyName ?? string.Empty);

                // Parse the input values
                double parsedX = 0, parsedY = 0, parsedZ = 0, parsedR = 0;
                double.TryParse(txt_PrfPos_X1.Text, out parsedX);
                double.TryParse(txt_PrfPos_Y1.Text, out parsedY);
                double.TryParse(txt_PrfPos_Z1.Text, out parsedZ);
                double.TryParse(txt_PrfPos_R1.Text, out parsedR);

                bool IsXCol(string s)
                {
                    if (string.IsNullOrWhiteSpace(s)) return false;
                    s = s.ToLowerInvariant();
                    return s.Contains("col(x)") || s.Contains("cavityx") || s.Contains("(x)") || s.Contains("\bx\b") || s.Contains("x");
                }

                bool IsYCol(string s)
                {
                    if (string.IsNullOrWhiteSpace(s)) return false;
                    s = s.ToLowerInvariant();
                    return s.Contains("row(y)") || s.Contains("cavityy") || s.Contains("(y)") || s.Contains("\by\b") || s.Contains("y");
                }

                bool IsZCol(string s)
                {
                    if (string.IsNullOrWhiteSpace(s)) return false;
                    s = s.ToLowerInvariant();
                    return s.Contains("z") || s.Contains("(z)") || s.Contains("depth");
                }

                bool IsRCol(string s)
                {
                    if (string.IsNullOrWhiteSpace(s)) return false;
                    s = s.ToLowerInvariant();
                    return s.Contains("r") || s.Contains("rotation") || s.Contains("(r)");
                }

                // 1️⃣ Column-specific update
                if (IsXCol(colIdentifier) && !IsYCol(colIdentifier) && !IsZCol(colIdentifier) && !IsRCol(colIdentifier))
                {
                    dgv_Nozzle.Rows[selectedRow].Cells[selectedCol].Value = parsedX;
                    return;
                }

                if (IsYCol(colIdentifier) && !IsXCol(colIdentifier) && !IsZCol(colIdentifier) && !IsRCol(colIdentifier))
                {
                    dgv_Nozzle.Rows[selectedRow].Cells[selectedCol].Value = parsedY;
                    return;
                }

                if (IsZCol(colIdentifier) && !IsXCol(colIdentifier) && !IsYCol(colIdentifier) && !IsRCol(colIdentifier))
                {
                    dgv_Nozzle.Rows[selectedRow].Cells[selectedCol].Value = parsedZ;
                    return;
                }

                if (IsRCol(colIdentifier) && !IsXCol(colIdentifier) && !IsYCol(colIdentifier) && !IsZCol(colIdentifier))
                {
                    dgv_Nozzle.Rows[selectedRow].Cells[selectedCol].Value = parsedR;
                    return;
                }

                // 2️⃣ Fallback: use the currently active axis
                if (!string.IsNullOrWhiteSpace(CurrentAxisName))
                {
                    try
                    {
                        string axis = CurrentAxisName.ToUpperInvariant();

                        if (axis.StartsWith("SERVO_X"))
                        {
                            dgv_Nozzle.Rows[selectedRow].Cells[selectedCol].Value = parsedX;
                            return;
                        }

                        if (axis.StartsWith("SERVO_Y"))
                        {
                            dgv_Nozzle.Rows[selectedRow].Cells[selectedCol].Value = parsedY;
                            return;
                        }

                        if (axis.StartsWith("SERVO_Z"))
                        {
                            dgv_Nozzle.Rows[selectedRow].Cells[selectedCol].Value = parsedZ;
                            return;
                        }

                        if (axis.StartsWith("SERVO_R"))
                        {
                            dgv_Nozzle.Rows[selectedRow].Cells[selectedCol].Value = parsedR;
                            return;
                        }
                    }
                    catch (Exception ex)
                    {
                        Logger.WriteLog(Logger.LogType.Error, "ReceipeForm", "teachToolStripMenuItem_Click.AxisFallback", ex.Message, ex.ToString());
                    }
                }

                // 3️⃣ Conservative default: update selected cell with X
                dgv_Nozzle.Rows[selectedRow].Cells[selectedCol].Value = parsedX;
            }
            catch (Exception ex)
            {
                Logger.WriteLog(Logger.LogType.Error, "ReceipeForm", "teachToolStripMenuItem_Click", ex.Message, ex.ToString());
            }

        }
        #endregion Move and Teach
    }
}
