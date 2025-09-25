using System.Drawing;
using System.Windows.Forms;

namespace UI
{
    partial class Settings
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }
     

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Settings));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tabControlSettings = new System.Windows.Forms.TabControl();
            this.General = new System.Windows.Forms.TabPage();
            this.panel5 = new System.Windows.Forms.Panel();
            this.pnlShiftSettings = new System.Windows.Forms.Panel();
            this.grpShiftSettings = new System.Windows.Forms.GroupBox();
            this.cmbShift = new System.Windows.Forms.ComboBox();
            this.lblShift = new System.Windows.Forms.Label();
            this.lblEndTime = new System.Windows.Forms.Label();
            this.dtpEndTime = new System.Windows.Forms.DateTimePicker();
            this.lblStartTime = new System.Windows.Forms.Label();
            this.dtpStartTime = new System.Windows.Forms.DateTimePicker();
            this.btnEditGeneral = new System.Windows.Forms.Button();
            this.btnSaveGeneral = new System.Windows.Forms.Button();
            this.pnlGeneral = new System.Windows.Forms.Panel();
            this.pnlSupport = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label39 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label38 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.pnlInfo = new System.Windows.Forms.Panel();
            this.lblTotalRejectVal = new System.Windows.Forms.Label();
            this.lblTotalLifeCycleVal = new System.Windows.Forms.Label();
            this.lblSWRevVal = new System.Windows.Forms.Label();
            this.lbSWUpdateVal = new System.Windows.Forms.Label();
            this.lblBuildDateVal = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblSwUpdated = new System.Windows.Forms.Label();
            this.lblBuildDate = new System.Windows.Forms.Label();
            this.lblSWRev = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.lblLifecycle = new System.Windows.Forms.Label();
            this.lblRejection = new System.Windows.Forms.Label();
            this.Device = new System.Windows.Forms.TabPage();
            this.DeviceSettingsPanel = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.SFC_PDCA_Bypass = new System.Windows.Forms.CheckBox();
            this.Buzzer_Bypass = new System.Windows.Forms.CheckBox();
            this.Safety_door_bypass = new System.Windows.Forms.CheckBox();
            this.Barcode_scanner_bypass = new System.Windows.Forms.CheckBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.grpDeviceIP = new System.Windows.Forms.GroupBox();
            this.IP_Details_table = new System.Windows.Forms.DataGridView();
            this.label15 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.lblRobot = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.lblPDCA = new System.Windows.Forms.Label();
            this.lblSFC = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.lblScanner = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
            this.lblCCD4 = new System.Windows.Forms.Label();
            this.lblCCD3 = new System.Windows.Forms.Label();
            this.lblcam2 = new System.Windows.Forms.Label();
            this.lblCam1 = new System.Windows.Forms.Label();
            this.lblCCD4IP = new System.Windows.Forms.Label();
            this.lblRoboIP = new System.Windows.Forms.Label();
            this.lblCCD3IP = new System.Windows.Forms.Label();
            this.lblCCD2IP = new System.Windows.Forms.Label();
            this.lblPDCAIP = new System.Windows.Forms.Label();
            this.lblSFCIP = new System.Windows.Forms.Label();
            this.lblScannerIP = new System.Windows.Forms.Label();
            this.lblCCD1IP = new System.Windows.Forms.Label();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.grpSystemSettings = new System.Windows.Forms.GroupBox();
            this.radioButtonDynamic = new System.Windows.Forms.RadioButton();
            this.radioButtonStatic = new System.Windows.Forms.RadioButton();
            this.radioButtongrr = new System.Windows.Forms.RadioButton();
            this.radioButtoncpk = new System.Windows.Forms.RadioButton();
            this.radioButtondry = new System.Windows.Forms.RadioButton();
            this.radioButtonProd = new System.Windows.Forms.RadioButton();
            this.btnEditSettings = new System.Windows.Forms.Button();
            this.btnSaveSettings = new System.Windows.Forms.Button();
            this.ConnectChk = new System.Windows.Forms.TabPage();
            this.tabConnectionCheck = new System.Windows.Forms.TabControl();
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.grpRoboConn = new System.Windows.Forms.GroupBox();
            this.btnDisConnect = new System.Windows.Forms.Button();
            this.lblCmd = new System.Windows.Forms.Label();
            this.cmbRBTmodeselect = new System.Windows.Forms.ComboBox();
            this.btnRBTselectCMD = new System.Windows.Forms.Button();
            this.lblrobotconnstatus = new System.Windows.Forms.Label();
            this.lblConnStatus = new System.Windows.Forms.Label();
            this.btnconnect = new System.Windows.Forms.Button();
            this.txtsendrobotcommand = new System.Windows.Forms.RichTextBox();
            this.txtreceivecommnd = new System.Windows.Forms.RichTextBox();
            this.label374 = new System.Windows.Forms.Label();
            this.btnRBTtrigger = new System.Windows.Forms.Button();
            this.label376 = new System.Windows.Forms.Label();
            this.tabPage7 = new System.Windows.Forms.TabPage();
            this.grpCCDConn = new System.Windows.Forms.GroupBox();
            this.lblSelectCCD = new System.Windows.Forms.Label();
            this.cmbCCD = new System.Windows.Forms.ComboBox();
            this.lblCCDConnStatus = new System.Windows.Forms.Label();
            this.btnCCDConnect = new System.Windows.Forms.Button();
            this.txtSendCmd = new System.Windows.Forms.RichTextBox();
            this.txtRecivdCmd = new System.Windows.Forms.RichTextBox();
            this.label372 = new System.Windows.Forms.Label();
            this.btnCCDTrigger = new System.Windows.Forms.Button();
            this.lblCCDConn = new System.Windows.Forms.Label();
            this.label378 = new System.Windows.Forms.Label();
            this.tabPage8 = new System.Windows.Forms.TabPage();
            this.grpScanner = new System.Windows.Forms.GroupBox();
            this.lblScanrConStatus = new System.Windows.Forms.Label();
            this.btnScannerConnect = new System.Windows.Forms.Button();
            this.txtScannerSend = new System.Windows.Forms.RichTextBox();
            this.txtScannerRecieve = new System.Windows.Forms.RichTextBox();
            this.label380 = new System.Windows.Forms.Label();
            this.btnScannerTrigger = new System.Windows.Forms.Button();
            this.lblScannerConn = new System.Windows.Forms.Label();
            this.label382 = new System.Windows.Forms.Label();
            this.tabPage9 = new System.Windows.Forms.TabPage();
            this.grpAtlas = new System.Windows.Forms.GroupBox();
            this.rdoAtlas2 = new System.Windows.Forms.RadioButton();
            this.rdoAtlas1 = new System.Windows.Forms.RadioButton();
            this.txtReceiveMsg = new System.Windows.Forms.TextBox();
            this.label31 = new System.Windows.Forms.Label();
            this.ClearReceiveMsg = new System.Windows.Forms.Button();
            this.label37 = new System.Windows.Forms.Label();
            this.txtSendMsg = new System.Windows.Forms.TextBox();
            this.IODiagnostics = new System.Windows.Forms.TabPage();
            this.tabIO = new System.Windows.Forms.TabControl();
            this.btn_input = new System.Windows.Forms.TabPage();
            this.inputState1 = new FBI_D57.InputState();
            this.btn_output = new System.Windows.Forms.TabPage();
            this.IOPanel = new System.Windows.Forms.Panel();
            this.outputState1 = new FBI_D57.OutputState();
            this.tabPage10 = new System.Windows.Forms.TabPage();
            this.tabPage11 = new System.Windows.Forms.TabPage();
            this.Calibration = new System.Windows.Forms.TabPage();
            this.CaliberationPanel = new System.Windows.Forms.Panel();
            this.tabCalib = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.grpLoadcell = new System.Windows.Forms.GroupBox();
            this.btnLoadCellStop = new System.Windows.Forms.Button();
            this.lblCalibSelect = new System.Windows.Forms.Label();
            this.btnLoadCellStart = new System.Windows.Forms.Button();
            this.cmbLoadcellMode = new System.Windows.Forms.ComboBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.grpCameraCalib = new System.Windows.Forms.GroupBox();
            this.grpboxCamera = new System.Windows.Forms.GroupBox();
            this.chkCCD5 = new System.Windows.Forms.CheckBox();
            this.chkCCD4 = new System.Windows.Forms.CheckBox();
            this.chkCCD3 = new System.Windows.Forms.CheckBox();
            this.chkCCD1 = new System.Windows.Forms.CheckBox();
            this.richTextBox_Calib = new System.Windows.Forms.RichTextBox();
            this.lblCameraConn = new System.Windows.Forms.Label();
            this.lblCamConnStatus = new System.Windows.Forms.Label();
            this.label54 = new System.Windows.Forms.Label();
            this.label55 = new System.Windows.Forms.Label();
            this.btnCamera_Stop = new System.Windows.Forms.Button();
            this.txtRunningStep = new System.Windows.Forms.TextBox();
            this.btnCamera_Start = new System.Windows.Forms.Button();
            this.grpCameraConn = new System.Windows.Forms.GroupBox();
            this.btnCalTrigger = new System.Windows.Forms.Button();
            this.btnCalConnect = new System.Windows.Forms.Button();
            this.lblCameraConnectionSts = new System.Windows.Forms.Label();
            this.lblCameraCon = new System.Windows.Forms.Label();
            this.lblRcvData = new System.Windows.Forms.Label();
            this.txtRecieveData = new System.Windows.Forms.RichTextBox();
            this.lblTriggerDelayTime = new System.Windows.Forms.Label();
            this.textDelay = new System.Windows.Forms.TextBox();
            this.lblTriggercmd = new System.Windows.Forms.Label();
            this.cmbTriggerCmd = new System.Windows.Forms.ComboBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.comboScanner = new System.Windows.Forms.ComboBox();
            this.label61 = new System.Windows.Forms.Label();
            this.Scanner_Delay_textBox = new System.Windows.Forms.TextBox();
            this.btn_Cali_Scan_Connect = new System.Windows.Forms.Button();
            this.Scanner_Consts = new System.Windows.Forms.Label();
            this.label49 = new System.Windows.Forms.Label();
            this.label51 = new System.Windows.Forms.Label();
            this.RecieveData_Scanner = new System.Windows.Forms.RichTextBox();
            this.label52 = new System.Windows.Forms.Label();
            this.btn_Cali_Scan_Trigger = new System.Windows.Forms.Button();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.btn_Cali_Rob_Connect = new System.Windows.Forms.Button();
            this.btn_Cali_Rob_Trigger = new System.Windows.Forms.Button();
            this.label44 = new System.Windows.Forms.Label();
            this.label45 = new System.Windows.Forms.Label();
            this.label46 = new System.Windows.Forms.Label();
            this.RecieveDataRobo = new System.Windows.Forms.RichTextBox();
            this.label47 = new System.Windows.Forms.Label();
            this.Robo_textBox = new System.Windows.Forms.TextBox();
            this.label48 = new System.Windows.Forms.Label();
            this.cmbRoboTrigger = new System.Windows.Forms.ComboBox();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.label32 = new System.Windows.Forms.Label();
            this.btnCalibRun = new System.Windows.Forms.Button();
            this.txtvisioncalib = new System.Windows.Forms.ComboBox();
            this.MotorDebug = new System.Windows.Forms.TabPage();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnedit = new System.Windows.Forms.Button();
            this.grbMotor = new System.Windows.Forms.GroupBox();
            this.Axis_Config = new System.Windows.Forms.DataGridView();
            this.SOP = new System.Windows.Forms.TabPage();
            this.panel3 = new System.Windows.Forms.Panel();
            this.grpBoxCCD1 = new System.Windows.Forms.GroupBox();
            this.cmbTestMode = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label36 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label129 = new System.Windows.Forms.Label();
            this.txtstaticposccd1_y = new System.Windows.Forms.TextBox();
            this.txtstaticposccd1_x = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnccd1Browse = new System.Windows.Forms.Button();
            this.txtccd1path = new System.Windows.Forms.TextBox();
            this.lblactualpos_ccd1_y = new System.Windows.Forms.Label();
            this.lblactualpos_ccd1_x = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label41 = new System.Windows.Forms.Label();
            this.label42 = new System.Windows.Forms.Label();
            this.label43 = new System.Windows.Forms.Label();
            this.btnCCD_start = new System.Windows.Forms.Button();
            this.btnCCD_stop = new System.Windows.Forms.Button();
            this.txtCounts = new System.Windows.Forms.TextBox();
            this.label50 = new System.Windows.Forms.Label();
            this.txtspeed = new System.Windows.Forms.TextBox();
            this.label77 = new System.Windows.Forms.Label();
            this.txtposition_y2 = new System.Windows.Forms.TextBox();
            this.txtstaticposccd1_z = new System.Windows.Forms.TextBox();
            this.txtposition_Z2 = new System.Windows.Forms.TextBox();
            this.txtpositionz1 = new System.Windows.Forms.TextBox();
            this.txtposition_y1 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label79 = new System.Windows.Forms.Label();
            this.label90 = new System.Windows.Forms.Label();
            this.txtposition_x2 = new System.Windows.Forms.TextBox();
            this.label91 = new System.Windows.Forms.Label();
            this.txtposition_x1 = new System.Windows.Forms.TextBox();
            this.label117 = new System.Windows.Forms.Label();
            this.lblRunningCount = new System.Windows.Forms.Label();
            this.label118 = new System.Windows.Forms.Label();
            this.label119 = new System.Windows.Forms.Label();
            this.groupBox18 = new System.Windows.Forms.GroupBox();
            this.cmbCamera = new System.Windows.Forms.ComboBox();
            this.label40 = new System.Windows.Forms.Label();
            this.AxisZeroSetting = new System.Windows.Forms.TabPage();
            this.panel9 = new System.Windows.Forms.Panel();
            this.groupBox16 = new System.Windows.Forms.GroupBox();
            this.label99 = new System.Windows.Forms.Label();
            this.label100 = new System.Windows.Forms.Label();
            this.label101 = new System.Windows.Forms.Label();
            this.label102 = new System.Windows.Forms.Label();
            this.label103 = new System.Windows.Forms.Label();
            this.label104 = new System.Windows.Forms.Label();
            this.label105 = new System.Windows.Forms.Label();
            this.label106 = new System.Windows.Forms.Label();
            this.label107 = new System.Windows.Forms.Label();
            this.label108 = new System.Windows.Forms.Label();
            this.label109 = new System.Windows.Forms.Label();
            this.label110 = new System.Windows.Forms.Label();
            this.btnStopRHFeeder = new System.Windows.Forms.Button();
            this.label111 = new System.Windows.Forms.Label();
            this.label112 = new System.Windows.Forms.Label();
            this.btnHomeRHUnloader = new System.Windows.Forms.Button();
            this.btnZeroRHUnloader = new System.Windows.Forms.Button();
            this.btnHomeRHLoader = new System.Windows.Forms.Button();
            this.btnZeroRHLoader = new System.Windows.Forms.Button();
            this.label113 = new System.Windows.Forms.Label();
            this.label114 = new System.Windows.Forms.Label();
            this.textBox12 = new System.Windows.Forms.TextBox();
            this.label115 = new System.Windows.Forms.Label();
            this.label116 = new System.Windows.Forms.Label();
            this.textBox13 = new System.Windows.Forms.TextBox();
            this.groupBox13 = new System.Windows.Forms.GroupBox();
            this.button11 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.label18 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.label62 = new System.Windows.Forms.Label();
            this.label63 = new System.Windows.Forms.Label();
            this.label64 = new System.Windows.Forms.Label();
            this.label69 = new System.Windows.Forms.Label();
            this.label70 = new System.Windows.Forms.Label();
            this.label71 = new System.Windows.Forms.Label();
            this.label65 = new System.Windows.Forms.Label();
            this.label66 = new System.Windows.Forms.Label();
            this.label67 = new System.Windows.Forms.Label();
            this.label73 = new System.Windows.Forms.Label();
            this.label74 = new System.Windows.Forms.Label();
            this.label75 = new System.Windows.Forms.Label();
            this.btnStopLHFeeder = new System.Windows.Forms.Button();
            this.label68 = new System.Windows.Forms.Label();
            this.label72 = new System.Windows.Forms.Label();
            this.btnHomeLHUnloader = new System.Windows.Forms.Button();
            this.btnZeroLHUnloader = new System.Windows.Forms.Button();
            this.btnHomeLHLoader = new System.Windows.Forms.Button();
            this.btnZeroLHLoader = new System.Windows.Forms.Button();
            this.label76 = new System.Windows.Forms.Label();
            this.textBox10 = new System.Windows.Forms.TextBox();
            this.label78 = new System.Windows.Forms.Label();
            this.textBox11 = new System.Windows.Forms.TextBox();
            this.groupBox14 = new System.Windows.Forms.GroupBox();
            this.label80 = new System.Windows.Forms.Label();
            this.lblRHhomeSts = new System.Windows.Forms.Label();
            this.label82 = new System.Windows.Forms.Label();
            this.label83 = new System.Windows.Forms.Label();
            this.btnAllAxesZero = new System.Windows.Forms.Button();
            this.lblLHhomeSts = new System.Windows.Forms.Label();
            this.lblXYhomeSts = new System.Windows.Forms.Label();
            this.groupBox15 = new System.Windows.Forms.GroupBox();
            this.btnZeroZ = new System.Windows.Forms.Button();
            this.lblMinX = new System.Windows.Forms.Label();
            this.btnStopGantry = new System.Windows.Forms.Button();
            this.label84 = new System.Windows.Forms.Label();
            this.label85 = new System.Windows.Forms.Label();
            this.label86 = new System.Windows.Forms.Label();
            this.label87 = new System.Windows.Forms.Label();
            this.label88 = new System.Windows.Forms.Label();
            this.label89 = new System.Windows.Forms.Label();
            this.label92 = new System.Windows.Forms.Label();
            this.lblOrgY = new System.Windows.Forms.Label();
            this.lblMaxY = new System.Windows.Forms.Label();
            this.lblMinY = new System.Windows.Forms.Label();
            this.label93 = new System.Windows.Forms.Label();
            this.lblOrgX = new System.Windows.Forms.Label();
            this.btnHomeY = new System.Windows.Forms.Button();
            this.lblMaxX = new System.Windows.Forms.Label();
            this.btnZeroY = new System.Windows.Forms.Button();
            this.btnHomeX = new System.Windows.Forms.Button();
            this.btnZeroX = new System.Windows.Forms.Button();
            this.label94 = new System.Windows.Forms.Label();
            this.label95 = new System.Windows.Forms.Label();
            this.txtYhme = new System.Windows.Forms.TextBox();
            this.label96 = new System.Windows.Forms.Label();
            this.label97 = new System.Windows.Forms.Label();
            this.txtXhme = new System.Windows.Forms.TextBox();
            this.label98 = new System.Windows.Forms.Label();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.Add = new System.Windows.Forms.ToolStripMenuItem();
            this.Delete = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControlSettings.SuspendLayout();
            this.General.SuspendLayout();
            this.panel5.SuspendLayout();
            this.pnlShiftSettings.SuspendLayout();
            this.grpShiftSettings.SuspendLayout();
            this.pnlGeneral.SuspendLayout();
            this.pnlSupport.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.pnlInfo.SuspendLayout();
            this.Device.SuspendLayout();
            this.DeviceSettingsPanel.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.grpDeviceIP.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.IP_Details_table)).BeginInit();
            this.grpSystemSettings.SuspendLayout();
            this.ConnectChk.SuspendLayout();
            this.tabConnectionCheck.SuspendLayout();
            this.tabPage6.SuspendLayout();
            this.panel1.SuspendLayout();
            this.grpRoboConn.SuspendLayout();
            this.tabPage7.SuspendLayout();
            this.grpCCDConn.SuspendLayout();
            this.tabPage8.SuspendLayout();
            this.grpScanner.SuspendLayout();
            this.tabPage9.SuspendLayout();
            this.grpAtlas.SuspendLayout();
            this.IODiagnostics.SuspendLayout();
            this.tabIO.SuspendLayout();
            this.btn_input.SuspendLayout();
            this.btn_output.SuspendLayout();
            this.IOPanel.SuspendLayout();
            this.Calibration.SuspendLayout();
            this.CaliberationPanel.SuspendLayout();
            this.tabCalib.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.grpLoadcell.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.grpCameraCalib.SuspendLayout();
            this.grpboxCamera.SuspendLayout();
            this.grpCameraConn.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.tabPage5.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.MotorDebug.SuspendLayout();
            this.panel2.SuspendLayout();
            this.grbMotor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Axis_Config)).BeginInit();
            this.SOP.SuspendLayout();
            this.panel3.SuspendLayout();
            this.grpBoxCCD1.SuspendLayout();
            this.groupBox18.SuspendLayout();
            this.AxisZeroSetting.SuspendLayout();
            this.panel9.SuspendLayout();
            this.groupBox16.SuspendLayout();
            this.groupBox13.SuspendLayout();
            this.groupBox14.SuspendLayout();
            this.groupBox15.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControlSettings
            // 
            this.tabControlSettings.Controls.Add(this.General);
            this.tabControlSettings.Controls.Add(this.Device);
            this.tabControlSettings.Controls.Add(this.ConnectChk);
            this.tabControlSettings.Controls.Add(this.IODiagnostics);
            this.tabControlSettings.Controls.Add(this.Calibration);
            this.tabControlSettings.Controls.Add(this.MotorDebug);
            this.tabControlSettings.Controls.Add(this.SOP);
            this.tabControlSettings.Controls.Add(this.AxisZeroSetting);
            this.tabControlSettings.Dock = System.Windows.Forms.DockStyle.Top;
            this.tabControlSettings.Font = new System.Drawing.Font("Verdana", 13.1F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControlSettings.Location = new System.Drawing.Point(0, 0);
            this.tabControlSettings.Margin = new System.Windows.Forms.Padding(4);
            this.tabControlSettings.Name = "tabControlSettings";
            this.tabControlSettings.Padding = new System.Drawing.Point(15, 10);
            this.tabControlSettings.SelectedIndex = 0;
            this.tabControlSettings.Size = new System.Drawing.Size(1365, 763);
            this.tabControlSettings.TabIndex = 47;
            // 
            // General
            // 
            this.General.Controls.Add(this.panel5);
            this.General.Location = new System.Drawing.Point(4, 49);
            this.General.Margin = new System.Windows.Forms.Padding(4);
            this.General.Name = "General";
            this.General.Size = new System.Drawing.Size(1357, 710);
            this.General.TabIndex = 5;
            this.General.Text = "General";
            this.General.UseVisualStyleBackColor = true;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.pnlShiftSettings);
            this.panel5.Controls.Add(this.pnlGeneral);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Margin = new System.Windows.Forms.Padding(4);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(1357, 710);
            this.panel5.TabIndex = 0;
            // 
            // pnlShiftSettings
            // 
            this.pnlShiftSettings.BackColor = System.Drawing.Color.Gainsboro;
            this.pnlShiftSettings.Controls.Add(this.grpShiftSettings);
            this.pnlShiftSettings.Location = new System.Drawing.Point(631, 4);
            this.pnlShiftSettings.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pnlShiftSettings.Name = "pnlShiftSettings";
            this.pnlShiftSettings.Size = new System.Drawing.Size(613, 335);
            this.pnlShiftSettings.TabIndex = 64;
            // 
            // grpShiftSettings
            // 
            this.grpShiftSettings.BackColor = System.Drawing.Color.White;
            this.grpShiftSettings.Controls.Add(this.cmbShift);
            this.grpShiftSettings.Controls.Add(this.lblShift);
            this.grpShiftSettings.Controls.Add(this.lblEndTime);
            this.grpShiftSettings.Controls.Add(this.dtpEndTime);
            this.grpShiftSettings.Controls.Add(this.lblStartTime);
            this.grpShiftSettings.Controls.Add(this.dtpStartTime);
            this.grpShiftSettings.Controls.Add(this.btnEditGeneral);
            this.grpShiftSettings.Controls.Add(this.btnSaveGeneral);
            this.grpShiftSettings.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold);
            this.grpShiftSettings.Location = new System.Drawing.Point(13, 22);
            this.grpShiftSettings.Margin = new System.Windows.Forms.Padding(4);
            this.grpShiftSettings.Name = "grpShiftSettings";
            this.grpShiftSettings.Padding = new System.Windows.Forms.Padding(4);
            this.grpShiftSettings.Size = new System.Drawing.Size(591, 305);
            this.grpShiftSettings.TabIndex = 52;
            this.grpShiftSettings.TabStop = false;
            this.grpShiftSettings.Text = "Shift Settings";
            // 
            // cmbShift
            // 
            this.cmbShift.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbShift.Enabled = false;
            this.cmbShift.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbShift.FormattingEnabled = true;
            this.cmbShift.Items.AddRange(new object[] {
            "A",
            "B",
            "C"});
            this.cmbShift.Location = new System.Drawing.Point(169, 70);
            this.cmbShift.Margin = new System.Windows.Forms.Padding(4);
            this.cmbShift.Name = "cmbShift";
            this.cmbShift.Size = new System.Drawing.Size(148, 28);
            this.cmbShift.TabIndex = 56;
            this.cmbShift.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.cmbShift_DrawItem);
            // 
            // lblShift
            // 
            this.lblShift.BackColor = System.Drawing.Color.White;
            this.lblShift.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblShift.Location = new System.Drawing.Point(11, 71);
            this.lblShift.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblShift.Name = "lblShift";
            this.lblShift.Size = new System.Drawing.Size(151, 22);
            this.lblShift.TabIndex = 55;
            this.lblShift.Text = "Shift           :";
            // 
            // lblEndTime
            // 
            this.lblEndTime.BackColor = System.Drawing.Color.White;
            this.lblEndTime.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEndTime.Location = new System.Drawing.Point(11, 172);
            this.lblEndTime.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblEndTime.Name = "lblEndTime";
            this.lblEndTime.Size = new System.Drawing.Size(151, 22);
            this.lblEndTime.TabIndex = 54;
            this.lblEndTime.Text = "End Time   :";
            // 
            // dtpEndTime
            // 
            this.dtpEndTime.Enabled = false;
            this.dtpEndTime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpEndTime.Location = new System.Drawing.Point(169, 172);
            this.dtpEndTime.Margin = new System.Windows.Forms.Padding(4);
            this.dtpEndTime.Name = "dtpEndTime";
            this.dtpEndTime.ShowUpDown = true;
            this.dtpEndTime.Size = new System.Drawing.Size(148, 32);
            this.dtpEndTime.TabIndex = 53;
            // 
            // lblStartTime
            // 
            this.lblStartTime.AutoSize = true;
            this.lblStartTime.BackColor = System.Drawing.Color.White;
            this.lblStartTime.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStartTime.Location = new System.Drawing.Point(11, 121);
            this.lblStartTime.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblStartTime.Name = "lblStartTime";
            this.lblStartTime.Size = new System.Drawing.Size(139, 23);
            this.lblStartTime.TabIndex = 52;
            this.lblStartTime.Text = "Start Time :";
            // 
            // dtpStartTime
            // 
            this.dtpStartTime.Enabled = false;
            this.dtpStartTime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpStartTime.Location = new System.Drawing.Point(169, 117);
            this.dtpStartTime.Margin = new System.Windows.Forms.Padding(4);
            this.dtpStartTime.Name = "dtpStartTime";
            this.dtpStartTime.ShowUpDown = true;
            this.dtpStartTime.Size = new System.Drawing.Size(148, 32);
            this.dtpStartTime.TabIndex = 51;
            // 
            // btnEditGeneral
            // 
            this.btnEditGeneral.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(94)))), ((int)(((byte)(133)))));
            this.btnEditGeneral.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditGeneral.ForeColor = System.Drawing.Color.White;
            this.btnEditGeneral.Location = new System.Drawing.Point(305, 245);
            this.btnEditGeneral.Margin = new System.Windows.Forms.Padding(4);
            this.btnEditGeneral.Name = "btnEditGeneral";
            this.btnEditGeneral.Size = new System.Drawing.Size(124, 37);
            this.btnEditGeneral.TabIndex = 50;
            this.btnEditGeneral.Text = "Edit";
            this.btnEditGeneral.UseVisualStyleBackColor = false;
            this.btnEditGeneral.Click += new System.EventHandler(this.btnEditGeneral_Click);
            // 
            // btnSaveGeneral
            // 
            this.btnSaveGeneral.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(94)))), ((int)(((byte)(133)))));
            this.btnSaveGeneral.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveGeneral.ForeColor = System.Drawing.Color.White;
            this.btnSaveGeneral.Location = new System.Drawing.Point(437, 245);
            this.btnSaveGeneral.Margin = new System.Windows.Forms.Padding(4);
            this.btnSaveGeneral.Name = "btnSaveGeneral";
            this.btnSaveGeneral.Size = new System.Drawing.Size(124, 37);
            this.btnSaveGeneral.TabIndex = 49;
            this.btnSaveGeneral.Text = "Save";
            this.btnSaveGeneral.UseVisualStyleBackColor = false;
            this.btnSaveGeneral.Click += new System.EventHandler(this.btnSaveGeneral_Click);
            // 
            // pnlGeneral
            // 
            this.pnlGeneral.BackColor = System.Drawing.Color.Gainsboro;
            this.pnlGeneral.Controls.Add(this.pnlSupport);
            this.pnlGeneral.Controls.Add(this.pnlInfo);
            this.pnlGeneral.Location = new System.Drawing.Point(3, 4);
            this.pnlGeneral.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pnlGeneral.Name = "pnlGeneral";
            this.pnlGeneral.Size = new System.Drawing.Size(560, 672);
            this.pnlGeneral.TabIndex = 63;
            // 
            // pnlSupport
            // 
            this.pnlSupport.BackColor = System.Drawing.Color.White;
            this.pnlSupport.Controls.Add(this.pictureBox2);
            this.pnlSupport.Controls.Add(this.label39);
            this.pnlSupport.Controls.Add(this.label11);
            this.pnlSupport.Controls.Add(this.label38);
            this.pnlSupport.Controls.Add(this.label12);
            this.pnlSupport.Controls.Add(this.label13);
            this.pnlSupport.Controls.Add(this.label14);
            this.pnlSupport.Controls.Add(this.label17);
            this.pnlSupport.Location = new System.Drawing.Point(23, 310);
            this.pnlSupport.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pnlSupport.Name = "pnlSupport";
            this.pnlSupport.Size = new System.Drawing.Size(511, 341);
            this.pnlSupport.TabIndex = 56;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(0, 48);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(144, 42);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 46;
            this.pictureBox2.TabStop = false;
            // 
            // label39
            // 
            this.label39.AutoSize = true;
            this.label39.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label39.Location = new System.Drawing.Point(11, 289);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(420, 24);
            this.label39.TabIndex = 43;
            this.label39.Text = "Email: xxxxr@titan.co.in | www.titanteal.com";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(12, 250);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(218, 24);
            this.label11.TabIndex = 43;
            this.label11.Text = "Mobile: +91xxxxxxxxx";
            // 
            // label38
            // 
            this.label38.AutoSize = true;
            this.label38.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label38.Location = new System.Drawing.Point(12, 214);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(151, 24);
            this.label38.TabIndex = 43;
            this.label38.Text = "Hosur - 635126";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(11, 176);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(269, 24);
            this.label12.TabIndex = 42;
            this.label12.Text = "SIPCOT Industrial Complex,";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(11, 135);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(175, 24);
            this.label13.TabIndex = 41;
            this.label13.Text = "Unit - I, NO.27 & 28";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(11, 97);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(402, 24);
            this.label14.TabIndex = 40;
            this.label14.Text = "Titan Engineering and Automation Limited";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Tahoma", 13F, System.Drawing.FontStyle.Bold);
            this.label17.Location = new System.Drawing.Point(9, 11);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(144, 27);
            this.label17.TabIndex = 39;
            this.label17.Text = "For Support";
            // 
            // pnlInfo
            // 
            this.pnlInfo.BackColor = System.Drawing.Color.White;
            this.pnlInfo.Controls.Add(this.lblTotalRejectVal);
            this.pnlInfo.Controls.Add(this.lblTotalLifeCycleVal);
            this.pnlInfo.Controls.Add(this.lblSWRevVal);
            this.pnlInfo.Controls.Add(this.lbSWUpdateVal);
            this.pnlInfo.Controls.Add(this.lblBuildDateVal);
            this.pnlInfo.Controls.Add(this.label10);
            this.pnlInfo.Controls.Add(this.label9);
            this.pnlInfo.Controls.Add(this.label8);
            this.pnlInfo.Controls.Add(this.label7);
            this.pnlInfo.Controls.Add(this.label6);
            this.pnlInfo.Controls.Add(this.lblSwUpdated);
            this.pnlInfo.Controls.Add(this.lblBuildDate);
            this.pnlInfo.Controls.Add(this.lblSWRev);
            this.pnlInfo.Controls.Add(this.label22);
            this.pnlInfo.Controls.Add(this.lblLifecycle);
            this.pnlInfo.Controls.Add(this.lblRejection);
            this.pnlInfo.Location = new System.Drawing.Point(23, 22);
            this.pnlInfo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pnlInfo.Name = "pnlInfo";
            this.pnlInfo.Size = new System.Drawing.Size(511, 267);
            this.pnlInfo.TabIndex = 55;
            // 
            // lblTotalRejectVal
            // 
            this.lblTotalRejectVal.AutoSize = true;
            this.lblTotalRejectVal.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Bold);
            this.lblTotalRejectVal.Location = new System.Drawing.Point(224, 209);
            this.lblTotalRejectVal.Name = "lblTotalRejectVal";
            this.lblTotalRejectVal.Size = new System.Drawing.Size(0, 23);
            this.lblTotalRejectVal.TabIndex = 47;
            // 
            // lblTotalLifeCycleVal
            // 
            this.lblTotalLifeCycleVal.AutoSize = true;
            this.lblTotalLifeCycleVal.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Bold);
            this.lblTotalLifeCycleVal.Location = new System.Drawing.Point(224, 172);
            this.lblTotalLifeCycleVal.Name = "lblTotalLifeCycleVal";
            this.lblTotalLifeCycleVal.Size = new System.Drawing.Size(0, 23);
            this.lblTotalLifeCycleVal.TabIndex = 46;
            // 
            // lblSWRevVal
            // 
            this.lblSWRevVal.AutoSize = true;
            this.lblSWRevVal.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Bold);
            this.lblSWRevVal.Location = new System.Drawing.Point(224, 92);
            this.lblSWRevVal.Name = "lblSWRevVal";
            this.lblSWRevVal.Size = new System.Drawing.Size(0, 23);
            this.lblSWRevVal.TabIndex = 45;
            // 
            // lbSWUpdateVal
            // 
            this.lbSWUpdateVal.AutoSize = true;
            this.lbSWUpdateVal.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Bold);
            this.lbSWUpdateVal.Location = new System.Drawing.Point(224, 130);
            this.lbSWUpdateVal.Name = "lbSWUpdateVal";
            this.lbSWUpdateVal.Size = new System.Drawing.Size(0, 23);
            this.lbSWUpdateVal.TabIndex = 44;
            // 
            // lblBuildDateVal
            // 
            this.lblBuildDateVal.AutoSize = true;
            this.lblBuildDateVal.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Bold);
            this.lblBuildDateVal.Location = new System.Drawing.Point(224, 58);
            this.lblBuildDateVal.Name = "lblBuildDateVal";
            this.lblBuildDateVal.Size = new System.Drawing.Size(0, 23);
            this.lblBuildDateVal.TabIndex = 43;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Bold);
            this.label10.Location = new System.Drawing.Point(201, 209);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(17, 23);
            this.label10.TabIndex = 42;
            this.label10.Text = ":";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Bold);
            this.label9.Location = new System.Drawing.Point(201, 172);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(17, 23);
            this.label9.TabIndex = 41;
            this.label9.Text = ":";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Bold);
            this.label8.Location = new System.Drawing.Point(201, 130);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(17, 23);
            this.label8.TabIndex = 40;
            this.label8.Text = ":";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Bold);
            this.label7.Location = new System.Drawing.Point(201, 92);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(17, 23);
            this.label7.TabIndex = 39;
            this.label7.Text = ":";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Bold);
            this.label6.Location = new System.Drawing.Point(201, 58);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(17, 23);
            this.label6.TabIndex = 38;
            this.label6.Text = ":";
            // 
            // lblSwUpdated
            // 
            this.lblSwUpdated.AutoSize = true;
            this.lblSwUpdated.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Bold);
            this.lblSwUpdated.Location = new System.Drawing.Point(9, 130);
            this.lblSwUpdated.Name = "lblSwUpdated";
            this.lblSwUpdated.Size = new System.Drawing.Size(128, 23);
            this.lblSwUpdated.TabIndex = 33;
            this.lblSwUpdated.Text = "SW Updated";
            // 
            // lblBuildDate
            // 
            this.lblBuildDate.AutoSize = true;
            this.lblBuildDate.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Bold);
            this.lblBuildDate.Location = new System.Drawing.Point(9, 58);
            this.lblBuildDate.Name = "lblBuildDate";
            this.lblBuildDate.Size = new System.Drawing.Size(109, 23);
            this.lblBuildDate.TabIndex = 28;
            this.lblBuildDate.Text = "Build Date";
            // 
            // lblSWRev
            // 
            this.lblSWRev.AutoSize = true;
            this.lblSWRev.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Bold);
            this.lblSWRev.Location = new System.Drawing.Point(9, 92);
            this.lblSWRev.Name = "lblSWRev";
            this.lblSWRev.Size = new System.Drawing.Size(84, 23);
            this.lblSWRev.TabIndex = 29;
            this.lblSWRev.Text = "SW Rev";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Verdana", 13F, System.Drawing.FontStyle.Bold);
            this.label22.Location = new System.Drawing.Point(11, 18);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(162, 26);
            this.label22.TabIndex = 32;
            this.label22.Text = "Information";
            // 
            // lblLifecycle
            // 
            this.lblLifecycle.AutoSize = true;
            this.lblLifecycle.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Bold);
            this.lblLifecycle.Location = new System.Drawing.Point(9, 172);
            this.lblLifecycle.Name = "lblLifecycle";
            this.lblLifecycle.Size = new System.Drawing.Size(173, 23);
            this.lblLifecycle.TabIndex = 35;
            this.lblLifecycle.Text = "Total Life Cycles ";
            // 
            // lblRejection
            // 
            this.lblRejection.AutoSize = true;
            this.lblRejection.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Bold);
            this.lblRejection.Location = new System.Drawing.Point(9, 209);
            this.lblRejection.Name = "lblRejection";
            this.lblRejection.Size = new System.Drawing.Size(177, 23);
            this.lblRejection.TabIndex = 37;
            this.lblRejection.Text = "Total Life Rejects";
            // 
            // Device
            // 
            this.Device.Controls.Add(this.DeviceSettingsPanel);
            this.Device.Location = new System.Drawing.Point(4, 49);
            this.Device.Margin = new System.Windows.Forms.Padding(4);
            this.Device.Name = "Device";
            this.Device.Size = new System.Drawing.Size(1357, 710);
            this.Device.TabIndex = 3;
            this.Device.Text = "Device Settings";
            this.Device.UseVisualStyleBackColor = true;
            // 
            // DeviceSettingsPanel
            // 
            this.DeviceSettingsPanel.Controls.Add(this.groupBox1);
            this.DeviceSettingsPanel.Controls.Add(this.panel4);
            this.DeviceSettingsPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DeviceSettingsPanel.Location = new System.Drawing.Point(0, 0);
            this.DeviceSettingsPanel.Margin = new System.Windows.Forms.Padding(4);
            this.DeviceSettingsPanel.Name = "DeviceSettingsPanel";
            this.DeviceSettingsPanel.Size = new System.Drawing.Size(1357, 710);
            this.DeviceSettingsPanel.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.White;
            this.groupBox1.Controls.Add(this.SFC_PDCA_Bypass);
            this.groupBox1.Controls.Add(this.Buzzer_Bypass);
            this.groupBox1.Controls.Add(this.Safety_door_bypass);
            this.groupBox1.Controls.Add(this.Barcode_scanner_bypass);
            this.groupBox1.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(963, 98);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(292, 336);
            this.groupBox1.TabIndex = 103;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Bypass Settings";
            // 
            // SFC_PDCA_Bypass
            // 
            this.SFC_PDCA_Bypass.Appearance = System.Windows.Forms.Appearance.Button;
            this.SFC_PDCA_Bypass.FlatAppearance.CheckedBackColor = System.Drawing.Color.Red;
            this.SFC_PDCA_Bypass.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SFC_PDCA_Bypass.Font = new System.Drawing.Font("Verdana", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SFC_PDCA_Bypass.Location = new System.Drawing.Point(32, 176);
            this.SFC_PDCA_Bypass.Margin = new System.Windows.Forms.Padding(4);
            this.SFC_PDCA_Bypass.Name = "SFC_PDCA_Bypass";
            this.SFC_PDCA_Bypass.Size = new System.Drawing.Size(185, 32);
            this.SFC_PDCA_Bypass.TabIndex = 26;
            this.SFC_PDCA_Bypass.Text = "SFC_PDCA Bypass";
            this.SFC_PDCA_Bypass.UseVisualStyleBackColor = true;
            // 
            // Buzzer_Bypass
            // 
            this.Buzzer_Bypass.Appearance = System.Windows.Forms.Appearance.Button;
            this.Buzzer_Bypass.FlatAppearance.CheckedBackColor = System.Drawing.Color.Red;
            this.Buzzer_Bypass.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Buzzer_Bypass.Font = new System.Drawing.Font("Verdana", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Buzzer_Bypass.Location = new System.Drawing.Point(32, 134);
            this.Buzzer_Bypass.Margin = new System.Windows.Forms.Padding(4);
            this.Buzzer_Bypass.Name = "Buzzer_Bypass";
            this.Buzzer_Bypass.Size = new System.Drawing.Size(185, 32);
            this.Buzzer_Bypass.TabIndex = 25;
            this.Buzzer_Bypass.Text = "Buzzer Bypass";
            this.Buzzer_Bypass.UseVisualStyleBackColor = true;
            // 
            // Safety_door_bypass
            // 
            this.Safety_door_bypass.Appearance = System.Windows.Forms.Appearance.Button;
            this.Safety_door_bypass.BackColor = System.Drawing.Color.Transparent;
            this.Safety_door_bypass.FlatAppearance.CheckedBackColor = System.Drawing.Color.Red;
            this.Safety_door_bypass.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Safety_door_bypass.Font = new System.Drawing.Font("Verdana", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Safety_door_bypass.Location = new System.Drawing.Point(32, 50);
            this.Safety_door_bypass.Margin = new System.Windows.Forms.Padding(4);
            this.Safety_door_bypass.Name = "Safety_door_bypass";
            this.Safety_door_bypass.Size = new System.Drawing.Size(185, 32);
            this.Safety_door_bypass.TabIndex = 24;
            this.Safety_door_bypass.Text = "Safety Door Bypass";
            this.Safety_door_bypass.UseVisualStyleBackColor = false;
            // 
            // Barcode_scanner_bypass
            // 
            this.Barcode_scanner_bypass.Appearance = System.Windows.Forms.Appearance.Button;
            this.Barcode_scanner_bypass.FlatAppearance.CheckedBackColor = System.Drawing.Color.Red;
            this.Barcode_scanner_bypass.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Barcode_scanner_bypass.Font = new System.Drawing.Font("Verdana", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Barcode_scanner_bypass.Location = new System.Drawing.Point(32, 92);
            this.Barcode_scanner_bypass.Margin = new System.Windows.Forms.Padding(4);
            this.Barcode_scanner_bypass.Name = "Barcode_scanner_bypass";
            this.Barcode_scanner_bypass.Size = new System.Drawing.Size(185, 32);
            this.Barcode_scanner_bypass.TabIndex = 23;
            this.Barcode_scanner_bypass.Text = "Scanner Bypass";
            this.Barcode_scanner_bypass.UseVisualStyleBackColor = true;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.White;
            this.panel4.Controls.Add(this.grpDeviceIP);
            this.panel4.Controls.Add(this.grpSystemSettings);
            this.panel4.Controls.Add(this.btnEditSettings);
            this.panel4.Controls.Add(this.btnSaveSettings);
            this.panel4.Location = new System.Drawing.Point(4, 4);
            this.panel4.Margin = new System.Windows.Forms.Padding(4);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1344, 703);
            this.panel4.TabIndex = 105;
            // 
            // grpDeviceIP
            // 
            this.grpDeviceIP.BackColor = System.Drawing.Color.White;
            this.grpDeviceIP.Controls.Add(this.IP_Details_table);
            this.grpDeviceIP.Controls.Add(this.label15);
            this.grpDeviceIP.Controls.Add(this.label19);
            this.grpDeviceIP.Controls.Add(this.label16);
            this.grpDeviceIP.Controls.Add(this.label27);
            this.grpDeviceIP.Controls.Add(this.label25);
            this.grpDeviceIP.Controls.Add(this.label24);
            this.grpDeviceIP.Controls.Add(this.label23);
            this.grpDeviceIP.Controls.Add(this.label20);
            this.grpDeviceIP.Controls.Add(this.lblRobot);
            this.grpDeviceIP.Controls.Add(this.label21);
            this.grpDeviceIP.Controls.Add(this.lblPDCA);
            this.grpDeviceIP.Controls.Add(this.lblSFC);
            this.grpDeviceIP.Controls.Add(this.label28);
            this.grpDeviceIP.Controls.Add(this.lblScanner);
            this.grpDeviceIP.Controls.Add(this.label29);
            this.grpDeviceIP.Controls.Add(this.lblCCD4);
            this.grpDeviceIP.Controls.Add(this.lblCCD3);
            this.grpDeviceIP.Controls.Add(this.lblcam2);
            this.grpDeviceIP.Controls.Add(this.lblCam1);
            this.grpDeviceIP.Controls.Add(this.lblCCD4IP);
            this.grpDeviceIP.Controls.Add(this.lblRoboIP);
            this.grpDeviceIP.Controls.Add(this.lblCCD3IP);
            this.grpDeviceIP.Controls.Add(this.lblCCD2IP);
            this.grpDeviceIP.Controls.Add(this.lblPDCAIP);
            this.grpDeviceIP.Controls.Add(this.lblSFCIP);
            this.grpDeviceIP.Controls.Add(this.lblScannerIP);
            this.grpDeviceIP.Controls.Add(this.lblCCD1IP);
            this.grpDeviceIP.Controls.Add(this.linkLabel1);
            this.grpDeviceIP.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpDeviceIP.Location = new System.Drawing.Point(72, 94);
            this.grpDeviceIP.Margin = new System.Windows.Forms.Padding(4);
            this.grpDeviceIP.Name = "grpDeviceIP";
            this.grpDeviceIP.Padding = new System.Windows.Forms.Padding(4);
            this.grpDeviceIP.Size = new System.Drawing.Size(531, 336);
            this.grpDeviceIP.TabIndex = 103;
            this.grpDeviceIP.TabStop = false;
            this.grpDeviceIP.Text = "Device IP Settings";
            // 
            // IP_Details_table
            // 
            this.IP_Details_table.AllowUserToAddRows = false;
            this.IP_Details_table.AllowUserToDeleteRows = false;
            this.IP_Details_table.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.IP_Details_table.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.IP_Details_table.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.IP_Details_table.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.IP_Details_table.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.IP_Details_table.DefaultCellStyle = dataGridViewCellStyle2;
            this.IP_Details_table.EnableHeadersVisualStyles = false;
            this.IP_Details_table.Location = new System.Drawing.Point(7, 38);
            this.IP_Details_table.Margin = new System.Windows.Forms.Padding(4);
            this.IP_Details_table.MultiSelect = false;
            this.IP_Details_table.Name = "IP_Details_table";
            this.IP_Details_table.RowHeadersVisible = false;
            this.IP_Details_table.RowHeadersWidth = 51;
            this.IP_Details_table.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.IP_Details_table.Size = new System.Drawing.Size(516, 295);
            this.IP_Details_table.TabIndex = 91;
            this.IP_Details_table.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.IP_Details_table_CellMouseClick);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Enabled = false;
            this.label15.Font = new System.Drawing.Font("Verdana", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(243, 404);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(18, 22);
            this.label15.TabIndex = 54;
            this.label15.Text = ":";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Enabled = false;
            this.label19.Font = new System.Drawing.Font("Verdana", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.Location = new System.Drawing.Point(41, 404);
            this.label19.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(112, 22);
            this.label19.TabIndex = 53;
            this.label19.Text = "SFC_PDCA ";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Enabled = false;
            this.label16.Font = new System.Drawing.Font("Verdana", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(290, 404);
            this.label16.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(112, 22);
            this.label16.TabIndex = 52;
            this.label16.Text = "IP Address ";
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Enabled = false;
            this.label27.Font = new System.Drawing.Font("Verdana", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label27.Location = new System.Drawing.Point(243, 224);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(18, 22);
            this.label27.TabIndex = 51;
            this.label27.Text = ":";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Enabled = false;
            this.label25.Font = new System.Drawing.Font("Verdana", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label25.Location = new System.Drawing.Point(243, 269);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(18, 22);
            this.label25.TabIndex = 50;
            this.label25.Text = ":";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Enabled = false;
            this.label24.Font = new System.Drawing.Font("Verdana", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label24.Location = new System.Drawing.Point(243, 314);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(18, 22);
            this.label24.TabIndex = 49;
            this.label24.Text = ":";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Enabled = false;
            this.label23.Font = new System.Drawing.Font("Verdana", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label23.Location = new System.Drawing.Point(243, 359);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(18, 22);
            this.label23.TabIndex = 48;
            this.label23.Text = ":";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Enabled = false;
            this.label20.Font = new System.Drawing.Font("Verdana", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.Location = new System.Drawing.Point(243, 179);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(18, 22);
            this.label20.TabIndex = 47;
            this.label20.Text = ":";
            // 
            // lblRobot
            // 
            this.lblRobot.AutoSize = true;
            this.lblRobot.Enabled = false;
            this.lblRobot.Font = new System.Drawing.Font("Verdana", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRobot.Location = new System.Drawing.Point(41, 359);
            this.lblRobot.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblRobot.Name = "lblRobot";
            this.lblRobot.Size = new System.Drawing.Size(174, 22);
            this.lblRobot.TabIndex = 37;
            this.lblRobot.Text = "Barcode Scanner  ";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Enabled = false;
            this.label21.Font = new System.Drawing.Font("Verdana", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.Location = new System.Drawing.Point(243, 134);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(18, 22);
            this.label21.TabIndex = 46;
            this.label21.Text = ":";
            // 
            // lblPDCA
            // 
            this.lblPDCA.AutoSize = true;
            this.lblPDCA.Enabled = false;
            this.lblPDCA.Font = new System.Drawing.Font("Verdana", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPDCA.Location = new System.Drawing.Point(41, 314);
            this.lblPDCA.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPDCA.Name = "lblPDCA";
            this.lblPDCA.Size = new System.Drawing.Size(145, 22);
            this.lblPDCA.TabIndex = 36;
            this.lblPDCA.Text = "Robot Error     ";
            // 
            // lblSFC
            // 
            this.lblSFC.AutoSize = true;
            this.lblSFC.Enabled = false;
            this.lblSFC.Font = new System.Drawing.Font("Verdana", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSFC.Location = new System.Drawing.Point(41, 269);
            this.lblSFC.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSFC.Name = "lblSFC";
            this.lblSFC.Size = new System.Drawing.Size(110, 22);
            this.lblSFC.TabIndex = 35;
            this.lblSFC.Text = "Robot Auto";
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Enabled = false;
            this.label28.Font = new System.Drawing.Font("Verdana", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label28.Location = new System.Drawing.Point(243, 89);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(18, 22);
            this.label28.TabIndex = 44;
            this.label28.Text = ":";
            // 
            // lblScanner
            // 
            this.lblScanner.AutoSize = true;
            this.lblScanner.Enabled = false;
            this.lblScanner.Font = new System.Drawing.Font("Verdana", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblScanner.Location = new System.Drawing.Point(41, 224);
            this.lblScanner.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblScanner.Name = "lblScanner";
            this.lblScanner.Size = new System.Drawing.Size(63, 22);
            this.lblScanner.TabIndex = 34;
            this.lblScanner.Text = "Robot";
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Enabled = false;
            this.label29.Font = new System.Drawing.Font("Verdana", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label29.Location = new System.Drawing.Point(243, 44);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(18, 22);
            this.label29.TabIndex = 43;
            this.label29.Text = ":";
            // 
            // lblCCD4
            // 
            this.lblCCD4.AutoSize = true;
            this.lblCCD4.Enabled = false;
            this.lblCCD4.Font = new System.Drawing.Font("Verdana", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCCD4.Location = new System.Drawing.Point(41, 179);
            this.lblCCD4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCCD4.Name = "lblCCD4";
            this.lblCCD4.Size = new System.Drawing.Size(97, 22);
            this.lblCCD4.TabIndex = 33;
            this.lblCCD4.Text = "CCD4      ";
            // 
            // lblCCD3
            // 
            this.lblCCD3.AutoSize = true;
            this.lblCCD3.Enabled = false;
            this.lblCCD3.Font = new System.Drawing.Font("Verdana", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCCD3.Location = new System.Drawing.Point(41, 134);
            this.lblCCD3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCCD3.Name = "lblCCD3";
            this.lblCCD3.Size = new System.Drawing.Size(97, 22);
            this.lblCCD3.TabIndex = 33;
            this.lblCCD3.Text = "CCD3      ";
            // 
            // lblcam2
            // 
            this.lblcam2.AutoSize = true;
            this.lblcam2.Enabled = false;
            this.lblcam2.Font = new System.Drawing.Font("Verdana", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblcam2.Location = new System.Drawing.Point(41, 89);
            this.lblcam2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblcam2.Name = "lblcam2";
            this.lblcam2.Size = new System.Drawing.Size(97, 22);
            this.lblcam2.TabIndex = 32;
            this.lblcam2.Text = "CCD2      ";
            // 
            // lblCam1
            // 
            this.lblCam1.AutoSize = true;
            this.lblCam1.Enabled = false;
            this.lblCam1.Font = new System.Drawing.Font("Verdana", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCam1.Location = new System.Drawing.Point(41, 44);
            this.lblCam1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCam1.Name = "lblCam1";
            this.lblCam1.Size = new System.Drawing.Size(97, 22);
            this.lblCam1.TabIndex = 30;
            this.lblCam1.Text = "CCD1      ";
            // 
            // lblCCD4IP
            // 
            this.lblCCD4IP.AutoSize = true;
            this.lblCCD4IP.Enabled = false;
            this.lblCCD4IP.Font = new System.Drawing.Font("Verdana", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCCD4IP.Location = new System.Drawing.Point(290, 179);
            this.lblCCD4IP.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCCD4IP.Name = "lblCCD4IP";
            this.lblCCD4IP.Size = new System.Drawing.Size(112, 22);
            this.lblCCD4IP.TabIndex = 26;
            this.lblCCD4IP.Text = "IP Address ";
            // 
            // lblRoboIP
            // 
            this.lblRoboIP.AutoSize = true;
            this.lblRoboIP.Enabled = false;
            this.lblRoboIP.Font = new System.Drawing.Font("Verdana", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRoboIP.Location = new System.Drawing.Point(290, 359);
            this.lblRoboIP.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblRoboIP.Name = "lblRoboIP";
            this.lblRoboIP.Size = new System.Drawing.Size(112, 22);
            this.lblRoboIP.TabIndex = 28;
            this.lblRoboIP.Text = "IP Address ";
            // 
            // lblCCD3IP
            // 
            this.lblCCD3IP.AutoSize = true;
            this.lblCCD3IP.Enabled = false;
            this.lblCCD3IP.Font = new System.Drawing.Font("Verdana", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCCD3IP.Location = new System.Drawing.Point(290, 134);
            this.lblCCD3IP.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCCD3IP.Name = "lblCCD3IP";
            this.lblCCD3IP.Size = new System.Drawing.Size(112, 22);
            this.lblCCD3IP.TabIndex = 26;
            this.lblCCD3IP.Text = "IP Address ";
            // 
            // lblCCD2IP
            // 
            this.lblCCD2IP.AutoSize = true;
            this.lblCCD2IP.Enabled = false;
            this.lblCCD2IP.Font = new System.Drawing.Font("Verdana", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCCD2IP.Location = new System.Drawing.Point(290, 89);
            this.lblCCD2IP.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCCD2IP.Name = "lblCCD2IP";
            this.lblCCD2IP.Size = new System.Drawing.Size(112, 22);
            this.lblCCD2IP.TabIndex = 24;
            this.lblCCD2IP.Text = "IP Address ";
            // 
            // lblPDCAIP
            // 
            this.lblPDCAIP.AutoSize = true;
            this.lblPDCAIP.Enabled = false;
            this.lblPDCAIP.Font = new System.Drawing.Font("Verdana", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPDCAIP.Location = new System.Drawing.Point(290, 314);
            this.lblPDCAIP.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPDCAIP.Name = "lblPDCAIP";
            this.lblPDCAIP.Size = new System.Drawing.Size(112, 22);
            this.lblPDCAIP.TabIndex = 20;
            this.lblPDCAIP.Text = "IP Address ";
            // 
            // lblSFCIP
            // 
            this.lblSFCIP.AutoSize = true;
            this.lblSFCIP.Enabled = false;
            this.lblSFCIP.Font = new System.Drawing.Font("Verdana", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSFCIP.Location = new System.Drawing.Point(290, 269);
            this.lblSFCIP.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSFCIP.Name = "lblSFCIP";
            this.lblSFCIP.Size = new System.Drawing.Size(112, 22);
            this.lblSFCIP.TabIndex = 19;
            this.lblSFCIP.Text = "IP Address ";
            // 
            // lblScannerIP
            // 
            this.lblScannerIP.AutoSize = true;
            this.lblScannerIP.Enabled = false;
            this.lblScannerIP.Font = new System.Drawing.Font("Verdana", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblScannerIP.Location = new System.Drawing.Point(290, 224);
            this.lblScannerIP.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblScannerIP.Name = "lblScannerIP";
            this.lblScannerIP.Size = new System.Drawing.Size(112, 22);
            this.lblScannerIP.TabIndex = 18;
            this.lblScannerIP.Text = "IP Address ";
            // 
            // lblCCD1IP
            // 
            this.lblCCD1IP.AutoSize = true;
            this.lblCCD1IP.Enabled = false;
            this.lblCCD1IP.Font = new System.Drawing.Font("Verdana", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCCD1IP.Location = new System.Drawing.Point(288, 44);
            this.lblCCD1IP.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCCD1IP.Name = "lblCCD1IP";
            this.lblCCD1IP.Size = new System.Drawing.Size(112, 22);
            this.lblCCD1IP.TabIndex = 17;
            this.lblCCD1IP.Text = "IP Address ";
            // 
            // linkLabel1
            // 
            this.linkLabel1.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabel1.Location = new System.Drawing.Point(73, 463);
            this.linkLabel1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(377, 24);
            this.linkLabel1.TabIndex = 16;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Note: For Changing device IP click on this link!";
            // 
            // grpSystemSettings
            // 
            this.grpSystemSettings.BackColor = System.Drawing.Color.White;
            this.grpSystemSettings.Controls.Add(this.radioButtonDynamic);
            this.grpSystemSettings.Controls.Add(this.radioButtonStatic);
            this.grpSystemSettings.Controls.Add(this.radioButtongrr);
            this.grpSystemSettings.Controls.Add(this.radioButtoncpk);
            this.grpSystemSettings.Controls.Add(this.radioButtondry);
            this.grpSystemSettings.Controls.Add(this.radioButtonProd);
            this.grpSystemSettings.Enabled = false;
            this.grpSystemSettings.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpSystemSettings.Location = new System.Drawing.Point(641, 94);
            this.grpSystemSettings.Margin = new System.Windows.Forms.Padding(4);
            this.grpSystemSettings.Name = "grpSystemSettings";
            this.grpSystemSettings.Padding = new System.Windows.Forms.Padding(4);
            this.grpSystemSettings.Size = new System.Drawing.Size(295, 336);
            this.grpSystemSettings.TabIndex = 102;
            this.grpSystemSettings.TabStop = false;
            this.grpSystemSettings.Text = "System Settings";
            // 
            // radioButtonDynamic
            // 
            this.radioButtonDynamic.Appearance = System.Windows.Forms.Appearance.Button;
            this.radioButtonDynamic.FlatAppearance.CheckedBackColor = System.Drawing.Color.Lime;
            this.radioButtonDynamic.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.radioButtonDynamic.Font = new System.Drawing.Font("Verdana", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButtonDynamic.Location = new System.Drawing.Point(49, 269);
            this.radioButtonDynamic.Name = "radioButtonDynamic";
            this.radioButtonDynamic.Size = new System.Drawing.Size(197, 34);
            this.radioButtonDynamic.TabIndex = 37;
            this.radioButtonDynamic.TabStop = true;
            this.radioButtonDynamic.Text = "Dynamic Test Mode";
            this.radioButtonDynamic.UseVisualStyleBackColor = true;
            // 
            // radioButtonStatic
            // 
            this.radioButtonStatic.Appearance = System.Windows.Forms.Appearance.Button;
            this.radioButtonStatic.FlatAppearance.CheckedBackColor = System.Drawing.Color.Lime;
            this.radioButtonStatic.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.radioButtonStatic.Font = new System.Drawing.Font("Verdana", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButtonStatic.Location = new System.Drawing.Point(49, 226);
            this.radioButtonStatic.Name = "radioButtonStatic";
            this.radioButtonStatic.Size = new System.Drawing.Size(197, 34);
            this.radioButtonStatic.TabIndex = 36;
            this.radioButtonStatic.TabStop = true;
            this.radioButtonStatic.Text = "Static Test Mode";
            this.radioButtonStatic.UseVisualStyleBackColor = true;
            // 
            // radioButtongrr
            // 
            this.radioButtongrr.Appearance = System.Windows.Forms.Appearance.Button;
            this.radioButtongrr.FlatAppearance.CheckedBackColor = System.Drawing.Color.Lime;
            this.radioButtongrr.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.radioButtongrr.Font = new System.Drawing.Font("Verdana", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButtongrr.Location = new System.Drawing.Point(49, 183);
            this.radioButtongrr.Name = "radioButtongrr";
            this.radioButtongrr.Size = new System.Drawing.Size(197, 34);
            this.radioButtongrr.TabIndex = 35;
            this.radioButtongrr.TabStop = true;
            this.radioButtongrr.Text = "GRR Mode";
            this.radioButtongrr.UseVisualStyleBackColor = true;
            // 
            // radioButtoncpk
            // 
            this.radioButtoncpk.Appearance = System.Windows.Forms.Appearance.Button;
            this.radioButtoncpk.FlatAppearance.CheckedBackColor = System.Drawing.Color.Lime;
            this.radioButtoncpk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.radioButtoncpk.Font = new System.Drawing.Font("Verdana", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButtoncpk.Location = new System.Drawing.Point(49, 140);
            this.radioButtoncpk.Name = "radioButtoncpk";
            this.radioButtoncpk.Size = new System.Drawing.Size(197, 34);
            this.radioButtoncpk.TabIndex = 29;
            this.radioButtoncpk.TabStop = true;
            this.radioButtoncpk.Text = "CPK Mode";
            this.radioButtoncpk.UseVisualStyleBackColor = true;
            // 
            // radioButtondry
            // 
            this.radioButtondry.Appearance = System.Windows.Forms.Appearance.Button;
            this.radioButtondry.FlatAppearance.CheckedBackColor = System.Drawing.Color.Lime;
            this.radioButtondry.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.radioButtondry.Font = new System.Drawing.Font("Verdana", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButtondry.Location = new System.Drawing.Point(49, 97);
            this.radioButtondry.Name = "radioButtondry";
            this.radioButtondry.Size = new System.Drawing.Size(197, 34);
            this.radioButtondry.TabIndex = 28;
            this.radioButtondry.TabStop = true;
            this.radioButtondry.Text = "Dry Run";
            this.radioButtondry.UseVisualStyleBackColor = true;
            // 
            // radioButtonProd
            // 
            this.radioButtonProd.Appearance = System.Windows.Forms.Appearance.Button;
            this.radioButtonProd.FlatAppearance.CheckedBackColor = System.Drawing.Color.Lime;
            this.radioButtonProd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.radioButtonProd.Font = new System.Drawing.Font("Verdana", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButtonProd.Location = new System.Drawing.Point(49, 54);
            this.radioButtonProd.Name = "radioButtonProd";
            this.radioButtonProd.Size = new System.Drawing.Size(197, 34);
            this.radioButtonProd.TabIndex = 27;
            this.radioButtonProd.TabStop = true;
            this.radioButtonProd.Text = "Production Run";
            this.radioButtonProd.UseVisualStyleBackColor = true;
            // 
            // btnEditSettings
            // 
            this.btnEditSettings.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(94)))), ((int)(((byte)(133)))));
            this.btnEditSettings.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditSettings.ForeColor = System.Drawing.Color.White;
            this.btnEditSettings.Location = new System.Drawing.Point(548, 518);
            this.btnEditSettings.Margin = new System.Windows.Forms.Padding(4);
            this.btnEditSettings.Name = "btnEditSettings";
            this.btnEditSettings.Size = new System.Drawing.Size(147, 43);
            this.btnEditSettings.TabIndex = 100;
            this.btnEditSettings.Text = "Edit";
            this.btnEditSettings.UseVisualStyleBackColor = false;
            this.btnEditSettings.Click += new System.EventHandler(this.btnEditSettings_Click);
            // 
            // btnSaveSettings
            // 
            this.btnSaveSettings.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(94)))), ((int)(((byte)(133)))));
            this.btnSaveSettings.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveSettings.ForeColor = System.Drawing.Color.White;
            this.btnSaveSettings.Location = new System.Drawing.Point(749, 518);
            this.btnSaveSettings.Margin = new System.Windows.Forms.Padding(4);
            this.btnSaveSettings.Name = "btnSaveSettings";
            this.btnSaveSettings.Size = new System.Drawing.Size(147, 43);
            this.btnSaveSettings.TabIndex = 100;
            this.btnSaveSettings.Text = "Save";
            this.btnSaveSettings.UseVisualStyleBackColor = false;
            this.btnSaveSettings.Click += new System.EventHandler(this.btnSaveSettings_Click);
            // 
            // ConnectChk
            // 
            this.ConnectChk.Controls.Add(this.tabConnectionCheck);
            this.ConnectChk.Location = new System.Drawing.Point(4, 49);
            this.ConnectChk.Margin = new System.Windows.Forms.Padding(4);
            this.ConnectChk.Name = "ConnectChk";
            this.ConnectChk.Size = new System.Drawing.Size(1357, 710);
            this.ConnectChk.TabIndex = 6;
            this.ConnectChk.Text = "Connection Check";
            this.ConnectChk.UseVisualStyleBackColor = true;
            // 
            // tabConnectionCheck
            // 
            this.tabConnectionCheck.Controls.Add(this.tabPage6);
            this.tabConnectionCheck.Controls.Add(this.tabPage7);
            this.tabConnectionCheck.Controls.Add(this.tabPage8);
            this.tabConnectionCheck.Controls.Add(this.tabPage9);
            this.tabConnectionCheck.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabConnectionCheck.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabConnectionCheck.Location = new System.Drawing.Point(0, 0);
            this.tabConnectionCheck.Margin = new System.Windows.Forms.Padding(4);
            this.tabConnectionCheck.Name = "tabConnectionCheck";
            this.tabConnectionCheck.SelectedIndex = 0;
            this.tabConnectionCheck.Size = new System.Drawing.Size(1357, 710);
            this.tabConnectionCheck.TabIndex = 0;
            // 
            // tabPage6
            // 
            this.tabPage6.Controls.Add(this.panel1);
            this.tabPage6.Location = new System.Drawing.Point(4, 29);
            this.tabPage6.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Padding = new System.Windows.Forms.Padding(4);
            this.tabPage6.Size = new System.Drawing.Size(1349, 677);
            this.tabPage6.TabIndex = 0;
            this.tabPage6.Text = "Robot";
            this.tabPage6.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.grpRoboConn);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(4, 4);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1341, 669);
            this.panel1.TabIndex = 1;
            // 
            // grpRoboConn
            // 
            this.grpRoboConn.Controls.Add(this.btnDisConnect);
            this.grpRoboConn.Controls.Add(this.lblCmd);
            this.grpRoboConn.Controls.Add(this.cmbRBTmodeselect);
            this.grpRoboConn.Controls.Add(this.btnRBTselectCMD);
            this.grpRoboConn.Controls.Add(this.lblrobotconnstatus);
            this.grpRoboConn.Controls.Add(this.lblConnStatus);
            this.grpRoboConn.Controls.Add(this.btnconnect);
            this.grpRoboConn.Controls.Add(this.txtsendrobotcommand);
            this.grpRoboConn.Controls.Add(this.txtreceivecommnd);
            this.grpRoboConn.Controls.Add(this.label374);
            this.grpRoboConn.Controls.Add(this.btnRBTtrigger);
            this.grpRoboConn.Controls.Add(this.label376);
            this.grpRoboConn.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpRoboConn.Location = new System.Drawing.Point(219, 116);
            this.grpRoboConn.Margin = new System.Windows.Forms.Padding(4);
            this.grpRoboConn.Name = "grpRoboConn";
            this.grpRoboConn.Padding = new System.Windows.Forms.Padding(4);
            this.grpRoboConn.Size = new System.Drawing.Size(860, 406);
            this.grpRoboConn.TabIndex = 168;
            this.grpRoboConn.TabStop = false;
            this.grpRoboConn.Text = "Robot";
            // 
            // btnDisConnect
            // 
            this.btnDisConnect.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(94)))), ((int)(((byte)(133)))));
            this.btnDisConnect.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDisConnect.ForeColor = System.Drawing.Color.White;
            this.btnDisConnect.Location = new System.Drawing.Point(341, 325);
            this.btnDisConnect.Margin = new System.Windows.Forms.Padding(4);
            this.btnDisConnect.Name = "btnDisConnect";
            this.btnDisConnect.Size = new System.Drawing.Size(147, 43);
            this.btnDisConnect.TabIndex = 176;
            this.btnDisConnect.Text = "Disconnect";
            this.btnDisConnect.UseVisualStyleBackColor = false;
            // 
            // lblCmd
            // 
            this.lblCmd.AutoSize = true;
            this.lblCmd.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCmd.Location = new System.Drawing.Point(8, 41);
            this.lblCmd.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCmd.Name = "lblCmd";
            this.lblCmd.Size = new System.Drawing.Size(128, 20);
            this.lblCmd.TabIndex = 175;
            this.lblCmd.Text = "Select Cmd :";
            // 
            // cmbRBTmodeselect
            // 
            this.cmbRBTmodeselect.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRBTmodeselect.FormattingEnabled = true;
            this.cmbRBTmodeselect.Items.AddRange(new object[] {
            "AUTO_MODE",
            "MANUAL_MODE",
            "CALIBRATION_MODE",
            "INITIALIZATION_MODE",
            "RECIPE_MODE"});
            this.cmbRBTmodeselect.Location = new System.Drawing.Point(147, 34);
            this.cmbRBTmodeselect.Margin = new System.Windows.Forms.Padding(4);
            this.cmbRBTmodeselect.Name = "cmbRBTmodeselect";
            this.cmbRBTmodeselect.Size = new System.Drawing.Size(300, 31);
            this.cmbRBTmodeselect.TabIndex = 174;
            // 
            // btnRBTselectCMD
            // 
            this.btnRBTselectCMD.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(94)))), ((int)(((byte)(133)))));
            this.btnRBTselectCMD.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRBTselectCMD.ForeColor = System.Drawing.Color.White;
            this.btnRBTselectCMD.Location = new System.Drawing.Point(480, 26);
            this.btnRBTselectCMD.Margin = new System.Windows.Forms.Padding(4);
            this.btnRBTselectCMD.Name = "btnRBTselectCMD";
            this.btnRBTselectCMD.Size = new System.Drawing.Size(147, 43);
            this.btnRBTselectCMD.TabIndex = 173;
            this.btnRBTselectCMD.Text = "Select";
            this.btnRBTselectCMD.UseVisualStyleBackColor = false;
            // 
            // lblrobotconnstatus
            // 
            this.lblrobotconnstatus.BackColor = System.Drawing.Color.Maroon;
            this.lblrobotconnstatus.Location = new System.Drawing.Point(768, 27);
            this.lblrobotconnstatus.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblrobotconnstatus.Name = "lblrobotconnstatus";
            this.lblrobotconnstatus.Size = new System.Drawing.Size(35, 32);
            this.lblrobotconnstatus.TabIndex = 171;
            // 
            // lblConnStatus
            // 
            this.lblConnStatus.AutoSize = true;
            this.lblConnStatus.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblConnStatus.Location = new System.Drawing.Point(657, 25);
            this.lblConnStatus.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblConnStatus.Name = "lblConnStatus";
            this.lblConnStatus.Size = new System.Drawing.Size(91, 36);
            this.lblConnStatus.TabIndex = 165;
            this.lblConnStatus.Text = "Connection\r\n Status";
            this.lblConnStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnconnect
            // 
            this.btnconnect.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(94)))), ((int)(((byte)(133)))));
            this.btnconnect.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnconnect.ForeColor = System.Drawing.Color.White;
            this.btnconnect.Location = new System.Drawing.Point(79, 325);
            this.btnconnect.Margin = new System.Windows.Forms.Padding(4);
            this.btnconnect.Name = "btnconnect";
            this.btnconnect.Size = new System.Drawing.Size(147, 43);
            this.btnconnect.TabIndex = 166;
            this.btnconnect.Text = "Connect";
            this.btnconnect.UseVisualStyleBackColor = false;
            // 
            // txtsendrobotcommand
            // 
            this.txtsendrobotcommand.AccessibleName = "";
            this.txtsendrobotcommand.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtsendrobotcommand.Location = new System.Drawing.Point(41, 129);
            this.txtsendrobotcommand.Margin = new System.Windows.Forms.Padding(4);
            this.txtsendrobotcommand.Name = "txtsendrobotcommand";
            this.txtsendrobotcommand.Size = new System.Drawing.Size(364, 168);
            this.txtsendrobotcommand.TabIndex = 169;
            this.txtsendrobotcommand.Text = "";
            // 
            // txtreceivecommnd
            // 
            this.txtreceivecommnd.AccessibleName = "";
            this.txtreceivecommnd.BackColor = System.Drawing.Color.White;
            this.txtreceivecommnd.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtreceivecommnd.Location = new System.Drawing.Point(437, 129);
            this.txtreceivecommnd.Margin = new System.Windows.Forms.Padding(4);
            this.txtreceivecommnd.Name = "txtreceivecommnd";
            this.txtreceivecommnd.ReadOnly = true;
            this.txtreceivecommnd.Size = new System.Drawing.Size(372, 168);
            this.txtreceivecommnd.TabIndex = 170;
            this.txtreceivecommnd.Text = "";
            // 
            // label374
            // 
            this.label374.AutoSize = true;
            this.label374.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label374.Location = new System.Drawing.Point(168, 90);
            this.label374.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label374.Name = "label374";
            this.label374.Size = new System.Drawing.Size(53, 21);
            this.label374.TabIndex = 167;
            this.label374.Text = "Send";
            // 
            // btnRBTtrigger
            // 
            this.btnRBTtrigger.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(94)))), ((int)(((byte)(133)))));
            this.btnRBTtrigger.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRBTtrigger.ForeColor = System.Drawing.Color.White;
            this.btnRBTtrigger.Location = new System.Drawing.Point(624, 325);
            this.btnRBTtrigger.Margin = new System.Windows.Forms.Padding(4);
            this.btnRBTtrigger.Name = "btnRBTtrigger";
            this.btnRBTtrigger.Size = new System.Drawing.Size(147, 43);
            this.btnRBTtrigger.TabIndex = 164;
            this.btnRBTtrigger.Text = "Trigger";
            this.btnRBTtrigger.UseVisualStyleBackColor = false;
            // 
            // label376
            // 
            this.label376.AutoSize = true;
            this.label376.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label376.Location = new System.Drawing.Point(560, 90);
            this.label376.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label376.Name = "label376";
            this.label376.Size = new System.Drawing.Size(87, 21);
            this.label376.TabIndex = 168;
            this.label376.Text = "Received";
            // 
            // tabPage7
            // 
            this.tabPage7.Controls.Add(this.grpCCDConn);
            this.tabPage7.Location = new System.Drawing.Point(4, 29);
            this.tabPage7.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage7.Name = "tabPage7";
            this.tabPage7.Padding = new System.Windows.Forms.Padding(4);
            this.tabPage7.Size = new System.Drawing.Size(1349, 677);
            this.tabPage7.TabIndex = 1;
            this.tabPage7.Text = "CCD";
            this.tabPage7.UseVisualStyleBackColor = true;
            // 
            // grpCCDConn
            // 
            this.grpCCDConn.Controls.Add(this.lblSelectCCD);
            this.grpCCDConn.Controls.Add(this.cmbCCD);
            this.grpCCDConn.Controls.Add(this.lblCCDConnStatus);
            this.grpCCDConn.Controls.Add(this.btnCCDConnect);
            this.grpCCDConn.Controls.Add(this.txtSendCmd);
            this.grpCCDConn.Controls.Add(this.txtRecivdCmd);
            this.grpCCDConn.Controls.Add(this.label372);
            this.grpCCDConn.Controls.Add(this.btnCCDTrigger);
            this.grpCCDConn.Controls.Add(this.lblCCDConn);
            this.grpCCDConn.Controls.Add(this.label378);
            this.grpCCDConn.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpCCDConn.Location = new System.Drawing.Point(225, 146);
            this.grpCCDConn.Margin = new System.Windows.Forms.Padding(4);
            this.grpCCDConn.Name = "grpCCDConn";
            this.grpCCDConn.Padding = new System.Windows.Forms.Padding(4);
            this.grpCCDConn.Size = new System.Drawing.Size(781, 390);
            this.grpCCDConn.TabIndex = 170;
            this.grpCCDConn.TabStop = false;
            this.grpCCDConn.Text = "CCD";
            // 
            // lblSelectCCD
            // 
            this.lblSelectCCD.AutoSize = true;
            this.lblSelectCCD.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSelectCCD.Location = new System.Drawing.Point(20, 37);
            this.lblSelectCCD.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSelectCCD.Name = "lblSelectCCD";
            this.lblSelectCCD.Size = new System.Drawing.Size(124, 20);
            this.lblSelectCCD.TabIndex = 159;
            this.lblSelectCCD.Text = "Select CCD :";
            // 
            // cmbCCD
            // 
            this.cmbCCD.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCCD.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbCCD.FormattingEnabled = true;
            this.cmbCCD.Items.AddRange(new object[] {
            "CCD1",
            "CCD2",
            "CCD3",
            "CCD4"});
            this.cmbCCD.Location = new System.Drawing.Point(155, 34);
            this.cmbCCD.Margin = new System.Windows.Forms.Padding(4);
            this.cmbCCD.Name = "cmbCCD";
            this.cmbCCD.Size = new System.Drawing.Size(219, 26);
            this.cmbCCD.TabIndex = 158;
            // 
            // lblCCDConnStatus
            // 
            this.lblCCDConnStatus.BackColor = System.Drawing.Color.Maroon;
            this.lblCCDConnStatus.Location = new System.Drawing.Point(720, 37);
            this.lblCCDConnStatus.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCCDConnStatus.Name = "lblCCDConnStatus";
            this.lblCCDConnStatus.Size = new System.Drawing.Size(35, 32);
            this.lblCCDConnStatus.TabIndex = 157;
            // 
            // btnCCDConnect
            // 
            this.btnCCDConnect.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(94)))), ((int)(((byte)(133)))));
            this.btnCCDConnect.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCCDConnect.ForeColor = System.Drawing.Color.White;
            this.btnCCDConnect.Location = new System.Drawing.Point(132, 308);
            this.btnCCDConnect.Margin = new System.Windows.Forms.Padding(4);
            this.btnCCDConnect.Name = "btnCCDConnect";
            this.btnCCDConnect.Size = new System.Drawing.Size(147, 43);
            this.btnCCDConnect.TabIndex = 100;
            this.btnCCDConnect.Text = "Connect";
            this.btnCCDConnect.UseVisualStyleBackColor = false;
            // 
            // txtSendCmd
            // 
            this.txtSendCmd.AccessibleName = "";
            this.txtSendCmd.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSendCmd.Location = new System.Drawing.Point(24, 121);
            this.txtSendCmd.Margin = new System.Windows.Forms.Padding(4);
            this.txtSendCmd.Name = "txtSendCmd";
            this.txtSendCmd.Size = new System.Drawing.Size(344, 149);
            this.txtSendCmd.TabIndex = 154;
            this.txtSendCmd.Text = "";
            // 
            // txtRecivdCmd
            // 
            this.txtRecivdCmd.AccessibleName = "";
            this.txtRecivdCmd.BackColor = System.Drawing.Color.White;
            this.txtRecivdCmd.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRecivdCmd.Location = new System.Drawing.Point(423, 121);
            this.txtRecivdCmd.Margin = new System.Windows.Forms.Padding(4);
            this.txtRecivdCmd.Name = "txtRecivdCmd";
            this.txtRecivdCmd.ReadOnly = true;
            this.txtRecivdCmd.Size = new System.Drawing.Size(331, 149);
            this.txtRecivdCmd.TabIndex = 154;
            this.txtRecivdCmd.Text = "";
            // 
            // label372
            // 
            this.label372.AutoSize = true;
            this.label372.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label372.Location = new System.Drawing.Point(151, 100);
            this.label372.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label372.Name = "label372";
            this.label372.Size = new System.Drawing.Size(45, 18);
            this.label372.TabIndex = 152;
            this.label372.Text = "Send";
            // 
            // btnCCDTrigger
            // 
            this.btnCCDTrigger.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(94)))), ((int)(((byte)(133)))));
            this.btnCCDTrigger.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCCDTrigger.ForeColor = System.Drawing.Color.White;
            this.btnCCDTrigger.Location = new System.Drawing.Point(516, 308);
            this.btnCCDTrigger.Margin = new System.Windows.Forms.Padding(4);
            this.btnCCDTrigger.Name = "btnCCDTrigger";
            this.btnCCDTrigger.Size = new System.Drawing.Size(147, 43);
            this.btnCCDTrigger.TabIndex = 100;
            this.btnCCDTrigger.Text = "Trigger";
            this.btnCCDTrigger.UseVisualStyleBackColor = false;
            // 
            // lblCCDConn
            // 
            this.lblCCDConn.AutoSize = true;
            this.lblCCDConn.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCCDConn.Location = new System.Drawing.Point(609, 32);
            this.lblCCDConn.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCCDConn.Name = "lblCCDConn";
            this.lblCCDConn.Size = new System.Drawing.Size(91, 36);
            this.lblCCDConn.TabIndex = 152;
            this.lblCCDConn.Text = "Connection\r\nStatus";
            this.lblCCDConn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label378
            // 
            this.label378.AutoSize = true;
            this.label378.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label378.Location = new System.Drawing.Point(535, 100);
            this.label378.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label378.Name = "label378";
            this.label378.Size = new System.Drawing.Size(77, 18);
            this.label378.TabIndex = 152;
            this.label378.Text = "Received";
            // 
            // tabPage8
            // 
            this.tabPage8.Controls.Add(this.grpScanner);
            this.tabPage8.Location = new System.Drawing.Point(4, 29);
            this.tabPage8.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage8.Name = "tabPage8";
            this.tabPage8.Size = new System.Drawing.Size(1349, 677);
            this.tabPage8.TabIndex = 2;
            this.tabPage8.Text = "Scanner";
            this.tabPage8.UseVisualStyleBackColor = true;
            // 
            // grpScanner
            // 
            this.grpScanner.Controls.Add(this.lblScanrConStatus);
            this.grpScanner.Controls.Add(this.btnScannerConnect);
            this.grpScanner.Controls.Add(this.txtScannerSend);
            this.grpScanner.Controls.Add(this.txtScannerRecieve);
            this.grpScanner.Controls.Add(this.label380);
            this.grpScanner.Controls.Add(this.btnScannerTrigger);
            this.grpScanner.Controls.Add(this.lblScannerConn);
            this.grpScanner.Controls.Add(this.label382);
            this.grpScanner.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpScanner.Location = new System.Drawing.Point(216, 146);
            this.grpScanner.Margin = new System.Windows.Forms.Padding(4);
            this.grpScanner.Name = "grpScanner";
            this.grpScanner.Padding = new System.Windows.Forms.Padding(4);
            this.grpScanner.Size = new System.Drawing.Size(813, 379);
            this.grpScanner.TabIndex = 171;
            this.grpScanner.TabStop = false;
            this.grpScanner.Text = "Scanner";
            // 
            // lblScanrConStatus
            // 
            this.lblScanrConStatus.BackColor = System.Drawing.Color.Maroon;
            this.lblScanrConStatus.Location = new System.Drawing.Point(735, 32);
            this.lblScanrConStatus.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblScanrConStatus.Name = "lblScanrConStatus";
            this.lblScanrConStatus.Size = new System.Drawing.Size(35, 32);
            this.lblScanrConStatus.TabIndex = 157;
            // 
            // btnScannerConnect
            // 
            this.btnScannerConnect.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(94)))), ((int)(((byte)(133)))));
            this.btnScannerConnect.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnScannerConnect.ForeColor = System.Drawing.Color.White;
            this.btnScannerConnect.Location = new System.Drawing.Point(145, 306);
            this.btnScannerConnect.Margin = new System.Windows.Forms.Padding(4);
            this.btnScannerConnect.Name = "btnScannerConnect";
            this.btnScannerConnect.Size = new System.Drawing.Size(132, 43);
            this.btnScannerConnect.TabIndex = 100;
            this.btnScannerConnect.Text = "Connect";
            this.btnScannerConnect.UseVisualStyleBackColor = false;
            // 
            // txtScannerSend
            // 
            this.txtScannerSend.AccessibleName = "";
            this.txtScannerSend.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtScannerSend.Location = new System.Drawing.Point(43, 130);
            this.txtScannerSend.Margin = new System.Windows.Forms.Padding(4);
            this.txtScannerSend.Name = "txtScannerSend";
            this.txtScannerSend.Size = new System.Drawing.Size(345, 149);
            this.txtScannerSend.TabIndex = 154;
            this.txtScannerSend.Text = "";
            this.txtScannerSend.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.richTextBox3_KeyPress);
            // 
            // txtScannerRecieve
            // 
            this.txtScannerRecieve.AccessibleName = "";
            this.txtScannerRecieve.BackColor = System.Drawing.Color.White;
            this.txtScannerRecieve.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtScannerRecieve.Location = new System.Drawing.Point(423, 130);
            this.txtScannerRecieve.Margin = new System.Windows.Forms.Padding(4);
            this.txtScannerRecieve.Name = "txtScannerRecieve";
            this.txtScannerRecieve.ReadOnly = true;
            this.txtScannerRecieve.Size = new System.Drawing.Size(345, 149);
            this.txtScannerRecieve.TabIndex = 154;
            this.txtScannerRecieve.Text = "";
            // 
            // label380
            // 
            this.label380.AutoSize = true;
            this.label380.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label380.Location = new System.Drawing.Point(156, 96);
            this.label380.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label380.Name = "label380";
            this.label380.Size = new System.Drawing.Size(45, 18);
            this.label380.TabIndex = 152;
            this.label380.Text = "Send";
            // 
            // btnScannerTrigger
            // 
            this.btnScannerTrigger.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(94)))), ((int)(((byte)(133)))));
            this.btnScannerTrigger.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnScannerTrigger.ForeColor = System.Drawing.Color.White;
            this.btnScannerTrigger.Location = new System.Drawing.Point(535, 306);
            this.btnScannerTrigger.Margin = new System.Windows.Forms.Padding(4);
            this.btnScannerTrigger.Name = "btnScannerTrigger";
            this.btnScannerTrigger.Size = new System.Drawing.Size(132, 43);
            this.btnScannerTrigger.TabIndex = 100;
            this.btnScannerTrigger.Text = "Trigger";
            this.btnScannerTrigger.UseVisualStyleBackColor = false;
            // 
            // lblScannerConn
            // 
            this.lblScannerConn.AutoSize = true;
            this.lblScannerConn.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblScannerConn.Location = new System.Drawing.Point(645, 32);
            this.lblScannerConn.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblScannerConn.Name = "lblScannerConn";
            this.lblScannerConn.Size = new System.Drawing.Size(87, 34);
            this.lblScannerConn.TabIndex = 152;
            this.lblScannerConn.Text = "Connection\r\nStatus";
            this.lblScannerConn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label382
            // 
            this.label382.AutoSize = true;
            this.label382.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label382.Location = new System.Drawing.Point(531, 96);
            this.label382.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label382.Name = "label382";
            this.label382.Size = new System.Drawing.Size(77, 18);
            this.label382.TabIndex = 152;
            this.label382.Text = "Received";
            // 
            // tabPage9
            // 
            this.tabPage9.Controls.Add(this.grpAtlas);
            this.tabPage9.Location = new System.Drawing.Point(4, 29);
            this.tabPage9.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage9.Name = "tabPage9";
            this.tabPage9.Size = new System.Drawing.Size(1349, 677);
            this.tabPage9.TabIndex = 3;
            this.tabPage9.Text = "Atlas";
            this.tabPage9.UseVisualStyleBackColor = true;
            // 
            // grpAtlas
            // 
            this.grpAtlas.Controls.Add(this.rdoAtlas2);
            this.grpAtlas.Controls.Add(this.rdoAtlas1);
            this.grpAtlas.Controls.Add(this.txtReceiveMsg);
            this.grpAtlas.Controls.Add(this.label31);
            this.grpAtlas.Controls.Add(this.ClearReceiveMsg);
            this.grpAtlas.Controls.Add(this.label37);
            this.grpAtlas.Controls.Add(this.txtSendMsg);
            this.grpAtlas.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpAtlas.Location = new System.Drawing.Point(277, 165);
            this.grpAtlas.Margin = new System.Windows.Forms.Padding(4);
            this.grpAtlas.Name = "grpAtlas";
            this.grpAtlas.Padding = new System.Windows.Forms.Padding(4);
            this.grpAtlas.Size = new System.Drawing.Size(751, 332);
            this.grpAtlas.TabIndex = 172;
            this.grpAtlas.TabStop = false;
            this.grpAtlas.Text = "Atlas ";
            // 
            // rdoAtlas2
            // 
            this.rdoAtlas2.AutoSize = true;
            this.rdoAtlas2.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoAtlas2.Location = new System.Drawing.Point(624, 26);
            this.rdoAtlas2.Margin = new System.Windows.Forms.Padding(4);
            this.rdoAtlas2.Name = "rdoAtlas2";
            this.rdoAtlas2.Size = new System.Drawing.Size(81, 22);
            this.rdoAtlas2.TabIndex = 56;
            this.rdoAtlas2.TabStop = true;
            this.rdoAtlas2.Text = "Atlas 2";
            this.rdoAtlas2.UseVisualStyleBackColor = true;
            // 
            // rdoAtlas1
            // 
            this.rdoAtlas1.AutoSize = true;
            this.rdoAtlas1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoAtlas1.Location = new System.Drawing.Point(525, 26);
            this.rdoAtlas1.Margin = new System.Windows.Forms.Padding(4);
            this.rdoAtlas1.Name = "rdoAtlas1";
            this.rdoAtlas1.Size = new System.Drawing.Size(81, 22);
            this.rdoAtlas1.TabIndex = 55;
            this.rdoAtlas1.TabStop = true;
            this.rdoAtlas1.Text = "Atlas 1";
            this.rdoAtlas1.UseVisualStyleBackColor = true;
            // 
            // txtReceiveMsg
            // 
            this.txtReceiveMsg.Enabled = false;
            this.txtReceiveMsg.Location = new System.Drawing.Point(12, 207);
            this.txtReceiveMsg.Margin = new System.Windows.Forms.Padding(4);
            this.txtReceiveMsg.Multiline = true;
            this.txtReceiveMsg.Name = "txtReceiveMsg";
            this.txtReceiveMsg.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtReceiveMsg.Size = new System.Drawing.Size(701, 99);
            this.txtReceiveMsg.TabIndex = 48;
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label31.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label31.Location = new System.Drawing.Point(9, 186);
            this.label31.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(77, 18);
            this.label31.TabIndex = 47;
            this.label31.Text = "Received";
            // 
            // ClearReceiveMsg
            // 
            this.ClearReceiveMsg.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.ClearReceiveMsg.Location = new System.Drawing.Point(513, 423);
            this.ClearReceiveMsg.Margin = new System.Windows.Forms.Padding(4);
            this.ClearReceiveMsg.Name = "ClearReceiveMsg";
            this.ClearReceiveMsg.Size = new System.Drawing.Size(124, 58);
            this.ClearReceiveMsg.TabIndex = 54;
            this.ClearReceiveMsg.Text = "Recieve";
            this.ClearReceiveMsg.UseVisualStyleBackColor = true;
            // 
            // label37
            // 
            this.label37.AutoSize = true;
            this.label37.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label37.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label37.Location = new System.Drawing.Point(12, 46);
            this.label37.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(45, 18);
            this.label37.TabIndex = 49;
            this.label37.Text = "Send";
            // 
            // txtSendMsg
            // 
            this.txtSendMsg.BackColor = System.Drawing.Color.White;
            this.txtSendMsg.Location = new System.Drawing.Point(13, 65);
            this.txtSendMsg.Margin = new System.Windows.Forms.Padding(4);
            this.txtSendMsg.Multiline = true;
            this.txtSendMsg.Name = "txtSendMsg";
            this.txtSendMsg.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtSendMsg.Size = new System.Drawing.Size(700, 102);
            this.txtSendMsg.TabIndex = 50;
            // 
            // IODiagnostics
            // 
            this.IODiagnostics.Controls.Add(this.tabIO);
            this.IODiagnostics.Location = new System.Drawing.Point(4, 49);
            this.IODiagnostics.Margin = new System.Windows.Forms.Padding(4);
            this.IODiagnostics.Name = "IODiagnostics";
            this.IODiagnostics.Size = new System.Drawing.Size(1357, 710);
            this.IODiagnostics.TabIndex = 4;
            this.IODiagnostics.Text = "IO";
            this.IODiagnostics.UseVisualStyleBackColor = true;
            // 
            // tabIO
            // 
            this.tabIO.Controls.Add(this.btn_input);
            this.tabIO.Controls.Add(this.btn_output);
            this.tabIO.Controls.Add(this.tabPage10);
            this.tabIO.Controls.Add(this.tabPage11);
            this.tabIO.Dock = System.Windows.Forms.DockStyle.Top;
            this.tabIO.Font = new System.Drawing.Font("Verdana", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabIO.Location = new System.Drawing.Point(0, 0);
            this.tabIO.Margin = new System.Windows.Forms.Padding(4);
            this.tabIO.Name = "tabIO";
            this.tabIO.SelectedIndex = 0;
            this.tabIO.Size = new System.Drawing.Size(1357, 711);
            this.tabIO.TabIndex = 5;
            // 
            // btn_input
            // 
            this.btn_input.BackColor = System.Drawing.Color.White;
            this.btn_input.Controls.Add(this.inputState1);
            this.btn_input.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_input.Location = new System.Drawing.Point(4, 27);
            this.btn_input.Margin = new System.Windows.Forms.Padding(4);
            this.btn_input.Name = "btn_input";
            this.btn_input.Size = new System.Drawing.Size(1349, 680);
            this.btn_input.TabIndex = 0;
            this.btn_input.Text = "Digital Input";
            // 
            // inputState1
            // 
            this.inputState1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.inputState1.Input_start = "start";
            this.inputState1.Input_stop = "End";
            this.inputState1.Location = new System.Drawing.Point(0, 0);
            this.inputState1.Margin = new System.Windows.Forms.Padding(5);
            this.inputState1.Name = "inputState1";
            this.inputState1.Size = new System.Drawing.Size(1349, 680);
            this.inputState1.TabIndex = 0;
            // 
            // btn_output
            // 
            this.btn_output.Controls.Add(this.IOPanel);
            this.btn_output.Location = new System.Drawing.Point(4, 27);
            this.btn_output.Margin = new System.Windows.Forms.Padding(4);
            this.btn_output.Name = "btn_output";
            this.btn_output.Size = new System.Drawing.Size(1349, 680);
            this.btn_output.TabIndex = 4;
            this.btn_output.Text = "Digital Output";
            this.btn_output.UseVisualStyleBackColor = true;
            // 
            // IOPanel
            // 
            this.IOPanel.Controls.Add(this.outputState1);
            this.IOPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.IOPanel.Location = new System.Drawing.Point(0, 0);
            this.IOPanel.Margin = new System.Windows.Forms.Padding(4);
            this.IOPanel.Name = "IOPanel";
            this.IOPanel.Size = new System.Drawing.Size(1349, 680);
            this.IOPanel.TabIndex = 0;
            // 
            // outputState1
            // 
            this.outputState1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.outputState1.Input_start = "start";
            this.outputState1.Input_stop = "End";
            this.outputState1.Location = new System.Drawing.Point(0, 0);
            this.outputState1.Margin = new System.Windows.Forms.Padding(5);
            this.outputState1.Name = "outputState1";
            this.outputState1.Size = new System.Drawing.Size(1349, 680);
            this.outputState1.TabIndex = 0;
            // 
            // tabPage10
            // 
            this.tabPage10.Location = new System.Drawing.Point(4, 27);
            this.tabPage10.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage10.Name = "tabPage10";
            this.tabPage10.Size = new System.Drawing.Size(1349, 680);
            this.tabPage10.TabIndex = 5;
            this.tabPage10.Text = "Analog Input";
            this.tabPage10.UseVisualStyleBackColor = true;
            // 
            // tabPage11
            // 
            this.tabPage11.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPage11.Location = new System.Drawing.Point(4, 27);
            this.tabPage11.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage11.Name = "tabPage11";
            this.tabPage11.Size = new System.Drawing.Size(1349, 680);
            this.tabPage11.TabIndex = 6;
            this.tabPage11.Text = "Analog Output";
            this.tabPage11.UseVisualStyleBackColor = true;
            // 
            // Calibration
            // 
            this.Calibration.Controls.Add(this.CaliberationPanel);
            this.Calibration.Location = new System.Drawing.Point(4, 49);
            this.Calibration.Margin = new System.Windows.Forms.Padding(4);
            this.Calibration.Name = "Calibration";
            this.Calibration.Size = new System.Drawing.Size(1357, 710);
            this.Calibration.TabIndex = 7;
            this.Calibration.Text = "Calibration";
            this.Calibration.UseVisualStyleBackColor = true;
            // 
            // CaliberationPanel
            // 
            this.CaliberationPanel.Controls.Add(this.tabCalib);
            this.CaliberationPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CaliberationPanel.Location = new System.Drawing.Point(0, 0);
            this.CaliberationPanel.Margin = new System.Windows.Forms.Padding(4);
            this.CaliberationPanel.Name = "CaliberationPanel";
            this.CaliberationPanel.Size = new System.Drawing.Size(1357, 710);
            this.CaliberationPanel.TabIndex = 0;
            // 
            // tabCalib
            // 
            this.tabCalib.Controls.Add(this.tabPage1);
            this.tabCalib.Controls.Add(this.tabPage2);
            this.tabCalib.Controls.Add(this.tabPage3);
            this.tabCalib.Controls.Add(this.tabPage4);
            this.tabCalib.Controls.Add(this.tabPage5);
            this.tabCalib.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabCalib.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabCalib.Location = new System.Drawing.Point(0, 0);
            this.tabCalib.Margin = new System.Windows.Forms.Padding(4);
            this.tabCalib.Multiline = true;
            this.tabCalib.Name = "tabCalib";
            this.tabCalib.SelectedIndex = 0;
            this.tabCalib.Size = new System.Drawing.Size(1357, 710);
            this.tabCalib.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.grpLoadcell);
            this.tabPage1.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold);
            this.tabPage1.Location = new System.Drawing.Point(4, 27);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(4);
            this.tabPage1.Size = new System.Drawing.Size(1349, 679);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Load Cell";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // grpLoadcell
            // 
            this.grpLoadcell.BackColor = System.Drawing.Color.WhiteSmoke;
            this.grpLoadcell.Controls.Add(this.btnLoadCellStop);
            this.grpLoadcell.Controls.Add(this.lblCalibSelect);
            this.grpLoadcell.Controls.Add(this.btnLoadCellStart);
            this.grpLoadcell.Controls.Add(this.cmbLoadcellMode);
            this.grpLoadcell.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Bold);
            this.grpLoadcell.Location = new System.Drawing.Point(456, 201);
            this.grpLoadcell.Margin = new System.Windows.Forms.Padding(4);
            this.grpLoadcell.Name = "grpLoadcell";
            this.grpLoadcell.Padding = new System.Windows.Forms.Padding(4);
            this.grpLoadcell.Size = new System.Drawing.Size(395, 223);
            this.grpLoadcell.TabIndex = 177;
            this.grpLoadcell.TabStop = false;
            this.grpLoadcell.Text = "Load Cell";
            // 
            // btnLoadCellStop
            // 
            this.btnLoadCellStop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(94)))), ((int)(((byte)(133)))));
            this.btnLoadCellStop.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLoadCellStop.ForeColor = System.Drawing.Color.White;
            this.btnLoadCellStop.Location = new System.Drawing.Point(232, 121);
            this.btnLoadCellStop.Margin = new System.Windows.Forms.Padding(4);
            this.btnLoadCellStop.Name = "btnLoadCellStop";
            this.btnLoadCellStop.Size = new System.Drawing.Size(132, 43);
            this.btnLoadCellStop.TabIndex = 100;
            this.btnLoadCellStop.Text = "Stop";
            this.btnLoadCellStop.UseVisualStyleBackColor = false;
            // 
            // lblCalibSelect
            // 
            this.lblCalibSelect.AutoSize = true;
            this.lblCalibSelect.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCalibSelect.Location = new System.Drawing.Point(24, 65);
            this.lblCalibSelect.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCalibSelect.Name = "lblCalibSelect";
            this.lblCalibSelect.Size = new System.Drawing.Size(135, 18);
            this.lblCalibSelect.TabIndex = 93;
            this.lblCalibSelect.Text = "Calibration Mode";
            // 
            // btnLoadCellStart
            // 
            this.btnLoadCellStart.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(94)))), ((int)(((byte)(133)))));
            this.btnLoadCellStart.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLoadCellStart.ForeColor = System.Drawing.Color.White;
            this.btnLoadCellStart.Location = new System.Drawing.Point(29, 121);
            this.btnLoadCellStart.Margin = new System.Windows.Forms.Padding(4);
            this.btnLoadCellStart.Name = "btnLoadCellStart";
            this.btnLoadCellStart.Size = new System.Drawing.Size(132, 43);
            this.btnLoadCellStart.TabIndex = 100;
            this.btnLoadCellStart.Text = "Start";
            this.btnLoadCellStart.UseVisualStyleBackColor = false;
            // 
            // cmbLoadcellMode
            // 
            this.cmbLoadcellMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLoadcellMode.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbLoadcellMode.FormattingEnabled = true;
            this.cmbLoadcellMode.Items.AddRange(new object[] {
            "Mode_1",
            "Mode_2"});
            this.cmbLoadcellMode.Location = new System.Drawing.Point(185, 60);
            this.cmbLoadcellMode.Margin = new System.Windows.Forms.Padding(4);
            this.cmbLoadcellMode.Name = "cmbLoadcellMode";
            this.cmbLoadcellMode.Size = new System.Drawing.Size(177, 26);
            this.cmbLoadcellMode.TabIndex = 92;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.grpCameraCalib);
            this.tabPage2.Controls.Add(this.grpCameraConn);
            this.tabPage2.Location = new System.Drawing.Point(4, 27);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(4);
            this.tabPage2.Size = new System.Drawing.Size(1349, 679);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Camera";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // grpCameraCalib
            // 
            this.grpCameraCalib.BackColor = System.Drawing.Color.WhiteSmoke;
            this.grpCameraCalib.Controls.Add(this.grpboxCamera);
            this.grpCameraCalib.Controls.Add(this.richTextBox_Calib);
            this.grpCameraCalib.Controls.Add(this.lblCameraConn);
            this.grpCameraCalib.Controls.Add(this.lblCamConnStatus);
            this.grpCameraCalib.Controls.Add(this.label54);
            this.grpCameraCalib.Controls.Add(this.label55);
            this.grpCameraCalib.Controls.Add(this.btnCamera_Stop);
            this.grpCameraCalib.Controls.Add(this.txtRunningStep);
            this.grpCameraCalib.Controls.Add(this.btnCamera_Start);
            this.grpCameraCalib.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Bold);
            this.grpCameraCalib.Location = new System.Drawing.Point(24, 350);
            this.grpCameraCalib.Margin = new System.Windows.Forms.Padding(4);
            this.grpCameraCalib.Name = "grpCameraCalib";
            this.grpCameraCalib.Padding = new System.Windows.Forms.Padding(4);
            this.grpCameraCalib.Size = new System.Drawing.Size(989, 315);
            this.grpCameraCalib.TabIndex = 185;
            this.grpCameraCalib.TabStop = false;
            this.grpCameraCalib.Text = "Vision Calibration";
            // 
            // grpboxCamera
            // 
            this.grpboxCamera.BackColor = System.Drawing.Color.WhiteSmoke;
            this.grpboxCamera.Controls.Add(this.chkCCD5);
            this.grpboxCamera.Controls.Add(this.chkCCD4);
            this.grpboxCamera.Controls.Add(this.chkCCD3);
            this.grpboxCamera.Controls.Add(this.chkCCD1);
            this.grpboxCamera.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpboxCamera.Location = new System.Drawing.Point(19, 137);
            this.grpboxCamera.Margin = new System.Windows.Forms.Padding(4);
            this.grpboxCamera.Name = "grpboxCamera";
            this.grpboxCamera.Padding = new System.Windows.Forms.Padding(4);
            this.grpboxCamera.Size = new System.Drawing.Size(411, 107);
            this.grpboxCamera.TabIndex = 152;
            this.grpboxCamera.TabStop = false;
            this.grpboxCamera.Text = "Choose Camera";
            // 
            // chkCCD5
            // 
            this.chkCCD5.AutoSize = true;
            this.chkCCD5.Location = new System.Drawing.Point(303, 47);
            this.chkCCD5.Margin = new System.Windows.Forms.Padding(4);
            this.chkCCD5.Name = "chkCCD5";
            this.chkCCD5.Size = new System.Drawing.Size(85, 24);
            this.chkCCD5.TabIndex = 90;
            this.chkCCD5.Text = "CCD 4";
            this.chkCCD5.UseVisualStyleBackColor = true;
            // 
            // chkCCD4
            // 
            this.chkCCD4.AutoSize = true;
            this.chkCCD4.Location = new System.Drawing.Point(208, 47);
            this.chkCCD4.Margin = new System.Windows.Forms.Padding(4);
            this.chkCCD4.Name = "chkCCD4";
            this.chkCCD4.Size = new System.Drawing.Size(85, 24);
            this.chkCCD4.TabIndex = 89;
            this.chkCCD4.Text = "CCD 3";
            this.chkCCD4.UseVisualStyleBackColor = true;
            // 
            // chkCCD3
            // 
            this.chkCCD3.AutoSize = true;
            this.chkCCD3.Location = new System.Drawing.Point(113, 47);
            this.chkCCD3.Margin = new System.Windows.Forms.Padding(4);
            this.chkCCD3.Name = "chkCCD3";
            this.chkCCD3.Size = new System.Drawing.Size(85, 24);
            this.chkCCD3.TabIndex = 88;
            this.chkCCD3.Text = "CCD 2";
            this.chkCCD3.UseVisualStyleBackColor = true;
            // 
            // chkCCD1
            // 
            this.chkCCD1.AutoSize = true;
            this.chkCCD1.Location = new System.Drawing.Point(19, 47);
            this.chkCCD1.Margin = new System.Windows.Forms.Padding(4);
            this.chkCCD1.Name = "chkCCD1";
            this.chkCCD1.Size = new System.Drawing.Size(85, 24);
            this.chkCCD1.TabIndex = 87;
            this.chkCCD1.Text = "CCD 1";
            this.chkCCD1.UseVisualStyleBackColor = true;
            // 
            // richTextBox_Calib
            // 
            this.richTextBox_Calib.BackColor = System.Drawing.Color.White;
            this.richTextBox_Calib.Location = new System.Drawing.Point(437, 32);
            this.richTextBox_Calib.Margin = new System.Windows.Forms.Padding(4);
            this.richTextBox_Calib.Name = "richTextBox_Calib";
            this.richTextBox_Calib.ReadOnly = true;
            this.richTextBox_Calib.Size = new System.Drawing.Size(512, 276);
            this.richTextBox_Calib.TabIndex = 144;
            this.richTextBox_Calib.Text = "";
            // 
            // lblCameraConn
            // 
            this.lblCameraConn.AutoSize = true;
            this.lblCameraConn.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCameraConn.Location = new System.Drawing.Point(157, 34);
            this.lblCameraConn.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCameraConn.Name = "lblCameraConn";
            this.lblCameraConn.Size = new System.Drawing.Size(204, 18);
            this.lblCameraConn.TabIndex = 60;
            this.lblCameraConn.Text = "Camera Connection Status";
            // 
            // lblCamConnStatus
            // 
            this.lblCamConnStatus.BackColor = System.Drawing.Color.Maroon;
            this.lblCamConnStatus.Location = new System.Drawing.Point(389, 25);
            this.lblCamConnStatus.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCamConnStatus.Name = "lblCamConnStatus";
            this.lblCamConnStatus.Size = new System.Drawing.Size(35, 32);
            this.lblCamConnStatus.TabIndex = 61;
            // 
            // label54
            // 
            this.label54.AutoSize = true;
            this.label54.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label54.Location = new System.Drawing.Point(13, 80);
            this.label54.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label54.Name = "label54";
            this.label54.Size = new System.Drawing.Size(160, 18);
            this.label54.TabIndex = 85;
            this.label54.Text = "Running Steps          :";
            // 
            // label55
            // 
            this.label55.AutoSize = true;
            this.label55.Font = new System.Drawing.Font("Tahoma", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label55.Location = new System.Drawing.Point(15, 116);
            this.label55.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label55.Name = "label55";
            this.label55.Size = new System.Drawing.Size(145, 18);
            this.label55.TabIndex = 143;
            this.label55.Text = "Vision Calibration ";
            // 
            // btnCamera_Stop
            // 
            this.btnCamera_Stop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(94)))), ((int)(((byte)(133)))));
            this.btnCamera_Stop.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCamera_Stop.ForeColor = System.Drawing.Color.White;
            this.btnCamera_Stop.Location = new System.Drawing.Point(277, 258);
            this.btnCamera_Stop.Margin = new System.Windows.Forms.Padding(4);
            this.btnCamera_Stop.Name = "btnCamera_Stop";
            this.btnCamera_Stop.Size = new System.Drawing.Size(132, 43);
            this.btnCamera_Stop.TabIndex = 100;
            this.btnCamera_Stop.Text = "Stop";
            this.btnCamera_Stop.UseVisualStyleBackColor = false;
            // 
            // txtRunningStep
            // 
            this.txtRunningStep.BackColor = System.Drawing.Color.White;
            this.txtRunningStep.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRunningStep.Location = new System.Drawing.Point(231, 74);
            this.txtRunningStep.Margin = new System.Windows.Forms.Padding(4);
            this.txtRunningStep.Name = "txtRunningStep";
            this.txtRunningStep.ReadOnly = true;
            this.txtRunningStep.Size = new System.Drawing.Size(192, 30);
            this.txtRunningStep.TabIndex = 142;
            // 
            // btnCamera_Start
            // 
            this.btnCamera_Start.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(94)))), ((int)(((byte)(133)))));
            this.btnCamera_Start.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCamera_Start.ForeColor = System.Drawing.Color.White;
            this.btnCamera_Start.Location = new System.Drawing.Point(44, 258);
            this.btnCamera_Start.Margin = new System.Windows.Forms.Padding(4);
            this.btnCamera_Start.Name = "btnCamera_Start";
            this.btnCamera_Start.Size = new System.Drawing.Size(132, 43);
            this.btnCamera_Start.TabIndex = 100;
            this.btnCamera_Start.Text = "Start";
            this.btnCamera_Start.UseVisualStyleBackColor = false;
            // 
            // grpCameraConn
            // 
            this.grpCameraConn.BackColor = System.Drawing.Color.WhiteSmoke;
            this.grpCameraConn.Controls.Add(this.btnCalTrigger);
            this.grpCameraConn.Controls.Add(this.btnCalConnect);
            this.grpCameraConn.Controls.Add(this.lblCameraConnectionSts);
            this.grpCameraConn.Controls.Add(this.lblCameraCon);
            this.grpCameraConn.Controls.Add(this.lblRcvData);
            this.grpCameraConn.Controls.Add(this.txtRecieveData);
            this.grpCameraConn.Controls.Add(this.lblTriggerDelayTime);
            this.grpCameraConn.Controls.Add(this.textDelay);
            this.grpCameraConn.Controls.Add(this.lblTriggercmd);
            this.grpCameraConn.Controls.Add(this.cmbTriggerCmd);
            this.grpCameraConn.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpCameraConn.Location = new System.Drawing.Point(24, 2);
            this.grpCameraConn.Margin = new System.Windows.Forms.Padding(4);
            this.grpCameraConn.Name = "grpCameraConn";
            this.grpCameraConn.Padding = new System.Windows.Forms.Padding(4);
            this.grpCameraConn.Size = new System.Drawing.Size(421, 347);
            this.grpCameraConn.TabIndex = 184;
            this.grpCameraConn.TabStop = false;
            this.grpCameraConn.Text = "Camera ";
            // 
            // btnCalTrigger
            // 
            this.btnCalTrigger.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(94)))), ((int)(((byte)(133)))));
            this.btnCalTrigger.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCalTrigger.ForeColor = System.Drawing.Color.White;
            this.btnCalTrigger.Location = new System.Drawing.Point(12, 295);
            this.btnCalTrigger.Margin = new System.Windows.Forms.Padding(4);
            this.btnCalTrigger.Name = "btnCalTrigger";
            this.btnCalTrigger.Size = new System.Drawing.Size(132, 43);
            this.btnCalTrigger.TabIndex = 100;
            this.btnCalTrigger.Text = "Trigger";
            this.btnCalTrigger.UseVisualStyleBackColor = false;
            // 
            // btnCalConnect
            // 
            this.btnCalConnect.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(94)))), ((int)(((byte)(133)))));
            this.btnCalConnect.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCalConnect.ForeColor = System.Drawing.Color.White;
            this.btnCalConnect.Location = new System.Drawing.Point(12, 245);
            this.btnCalConnect.Margin = new System.Windows.Forms.Padding(4);
            this.btnCalConnect.Name = "btnCalConnect";
            this.btnCalConnect.Size = new System.Drawing.Size(132, 43);
            this.btnCalConnect.TabIndex = 100;
            this.btnCalConnect.Text = "Connect";
            this.btnCalConnect.UseVisualStyleBackColor = false;
            // 
            // lblCameraConnectionSts
            // 
            this.lblCameraConnectionSts.BackColor = System.Drawing.Color.Maroon;
            this.lblCameraConnectionSts.Location = new System.Drawing.Point(371, 26);
            this.lblCameraConnectionSts.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCameraConnectionSts.Name = "lblCameraConnectionSts";
            this.lblCameraConnectionSts.Size = new System.Drawing.Size(35, 32);
            this.lblCameraConnectionSts.TabIndex = 152;
            // 
            // lblCameraCon
            // 
            this.lblCameraCon.AutoSize = true;
            this.lblCameraCon.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCameraCon.Location = new System.Drawing.Point(137, 33);
            this.lblCameraCon.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCameraCon.Name = "lblCameraCon";
            this.lblCameraCon.Size = new System.Drawing.Size(204, 18);
            this.lblCameraCon.TabIndex = 152;
            this.lblCameraCon.Text = "Camera Connection Status";
            // 
            // lblRcvData
            // 
            this.lblRcvData.AutoSize = true;
            this.lblRcvData.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.lblRcvData.Location = new System.Drawing.Point(9, 128);
            this.lblRcvData.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblRcvData.Name = "lblRcvData";
            this.lblRcvData.Size = new System.Drawing.Size(116, 18);
            this.lblRcvData.TabIndex = 155;
            this.lblRcvData.Text = "Received Data";
            // 
            // txtRecieveData
            // 
            this.txtRecieveData.AccessibleName = "RecivedDataCamera";
            this.txtRecieveData.BackColor = System.Drawing.Color.White;
            this.txtRecieveData.Location = new System.Drawing.Point(12, 158);
            this.txtRecieveData.Margin = new System.Windows.Forms.Padding(4);
            this.txtRecieveData.Name = "txtRecieveData";
            this.txtRecieveData.ReadOnly = true;
            this.txtRecieveData.Size = new System.Drawing.Size(396, 82);
            this.txtRecieveData.TabIndex = 154;
            this.txtRecieveData.Text = "";
            // 
            // lblTriggerDelayTime
            // 
            this.lblTriggerDelayTime.AutoSize = true;
            this.lblTriggerDelayTime.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTriggerDelayTime.Location = new System.Drawing.Point(156, 283);
            this.lblTriggerDelayTime.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTriggerDelayTime.Name = "lblTriggerDelayTime";
            this.lblTriggerDelayTime.Size = new System.Drawing.Size(150, 18);
            this.lblTriggerDelayTime.TabIndex = 151;
            this.lblTriggerDelayTime.Text = "Trigger Delay Time";
            // 
            // textDelay
            // 
            this.textDelay.BackColor = System.Drawing.Color.White;
            this.textDelay.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textDelay.Enabled = false;
            this.textDelay.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textDelay.Location = new System.Drawing.Point(321, 277);
            this.textDelay.Margin = new System.Windows.Forms.Padding(4);
            this.textDelay.Name = "textDelay";
            this.textDelay.ReadOnly = true;
            this.textDelay.Size = new System.Drawing.Size(87, 30);
            this.textDelay.TabIndex = 150;
            // 
            // lblTriggercmd
            // 
            this.lblTriggercmd.AutoSize = true;
            this.lblTriggercmd.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTriggercmd.Location = new System.Drawing.Point(8, 62);
            this.lblTriggercmd.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTriggercmd.Name = "lblTriggercmd";
            this.lblTriggercmd.Size = new System.Drawing.Size(188, 18);
            this.lblTriggercmd.TabIndex = 147;
            this.lblTriggercmd.Text = "Select Trigger command";
            // 
            // cmbTriggerCmd
            // 
            this.cmbTriggerCmd.BackColor = System.Drawing.Color.White;
            this.cmbTriggerCmd.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTriggerCmd.Font = new System.Drawing.Font("Verdana", 11.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbTriggerCmd.FormattingEnabled = true;
            this.cmbTriggerCmd.Items.AddRange(new object[] {
            "CCD1",
            "CCD2",
            "CCD3",
            "CCD4"});
            this.cmbTriggerCmd.Location = new System.Drawing.Point(12, 87);
            this.cmbTriggerCmd.Margin = new System.Windows.Forms.Padding(4);
            this.cmbTriggerCmd.Name = "cmbTriggerCmd";
            this.cmbTriggerCmd.Size = new System.Drawing.Size(396, 33);
            this.cmbTriggerCmd.TabIndex = 86;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.groupBox8);
            this.tabPage3.Location = new System.Drawing.Point(4, 27);
            this.tabPage3.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(1349, 679);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Scanner";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // groupBox8
            // 
            this.groupBox8.BackColor = System.Drawing.Color.WhiteSmoke;
            this.groupBox8.Controls.Add(this.comboScanner);
            this.groupBox8.Controls.Add(this.label61);
            this.groupBox8.Controls.Add(this.Scanner_Delay_textBox);
            this.groupBox8.Controls.Add(this.btn_Cali_Scan_Connect);
            this.groupBox8.Controls.Add(this.Scanner_Consts);
            this.groupBox8.Controls.Add(this.label49);
            this.groupBox8.Controls.Add(this.label51);
            this.groupBox8.Controls.Add(this.RecieveData_Scanner);
            this.groupBox8.Controls.Add(this.label52);
            this.groupBox8.Controls.Add(this.btn_Cali_Scan_Trigger);
            this.groupBox8.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Bold);
            this.groupBox8.Location = new System.Drawing.Point(436, 135);
            this.groupBox8.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox8.Size = new System.Drawing.Size(420, 361);
            this.groupBox8.TabIndex = 181;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "Scanner";
            // 
            // comboScanner
            // 
            this.comboScanner.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboScanner.Font = new System.Drawing.Font("Verdana", 11.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboScanner.FormattingEnabled = true;
            this.comboScanner.Items.AddRange(new object[] {
            "CMD_1",
            "CMD_2",
            "CMD_3",
            "CMD_4"});
            this.comboScanner.Location = new System.Drawing.Point(13, 82);
            this.comboScanner.Margin = new System.Windows.Forms.Padding(4);
            this.comboScanner.Name = "comboScanner";
            this.comboScanner.Size = new System.Drawing.Size(380, 33);
            this.comboScanner.TabIndex = 159;
            // 
            // label61
            // 
            this.label61.AutoSize = true;
            this.label61.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label61.Location = new System.Drawing.Point(9, 62);
            this.label61.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label61.Name = "label61";
            this.label61.Size = new System.Drawing.Size(188, 18);
            this.label61.TabIndex = 158;
            this.label61.Text = "Select Trigger command";
            // 
            // Scanner_Delay_textBox
            // 
            this.Scanner_Delay_textBox.BackColor = System.Drawing.Color.White;
            this.Scanner_Delay_textBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Scanner_Delay_textBox.ForeColor = System.Drawing.Color.Transparent;
            this.Scanner_Delay_textBox.Location = new System.Drawing.Point(307, 277);
            this.Scanner_Delay_textBox.Margin = new System.Windows.Forms.Padding(4);
            this.Scanner_Delay_textBox.Name = "Scanner_Delay_textBox";
            this.Scanner_Delay_textBox.ReadOnly = true;
            this.Scanner_Delay_textBox.Size = new System.Drawing.Size(103, 29);
            this.Scanner_Delay_textBox.TabIndex = 157;
            // 
            // btn_Cali_Scan_Connect
            // 
            this.btn_Cali_Scan_Connect.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(94)))), ((int)(((byte)(133)))));
            this.btn_Cali_Scan_Connect.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Cali_Scan_Connect.ForeColor = System.Drawing.Color.White;
            this.btn_Cali_Scan_Connect.Location = new System.Drawing.Point(8, 250);
            this.btn_Cali_Scan_Connect.Margin = new System.Windows.Forms.Padding(4);
            this.btn_Cali_Scan_Connect.Name = "btn_Cali_Scan_Connect";
            this.btn_Cali_Scan_Connect.Size = new System.Drawing.Size(132, 43);
            this.btn_Cali_Scan_Connect.TabIndex = 152;
            this.btn_Cali_Scan_Connect.Text = "Connect";
            this.btn_Cali_Scan_Connect.UseVisualStyleBackColor = false;
            // 
            // Scanner_Consts
            // 
            this.Scanner_Consts.BackColor = System.Drawing.Color.Maroon;
            this.Scanner_Consts.Location = new System.Drawing.Point(201, 30);
            this.Scanner_Consts.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Scanner_Consts.Name = "Scanner_Consts";
            this.Scanner_Consts.Size = new System.Drawing.Size(28, 25);
            this.Scanner_Consts.TabIndex = 152;
            // 
            // label49
            // 
            this.label49.AutoSize = true;
            this.label49.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label49.Location = new System.Drawing.Point(9, 33);
            this.label49.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label49.Name = "label49";
            this.label49.Size = new System.Drawing.Size(162, 18);
            this.label49.TabIndex = 152;
            this.label49.Text = "Scanner Conn Status";
            // 
            // label51
            // 
            this.label51.AutoSize = true;
            this.label51.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label51.Location = new System.Drawing.Point(9, 128);
            this.label51.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label51.Name = "label51";
            this.label51.Size = new System.Drawing.Size(116, 18);
            this.label51.TabIndex = 155;
            this.label51.Text = "Received Data";
            // 
            // RecieveData_Scanner
            // 
            this.RecieveData_Scanner.AccessibleName = "";
            this.RecieveData_Scanner.BackColor = System.Drawing.Color.White;
            this.RecieveData_Scanner.Location = new System.Drawing.Point(8, 158);
            this.RecieveData_Scanner.Margin = new System.Windows.Forms.Padding(4);
            this.RecieveData_Scanner.Name = "RecieveData_Scanner";
            this.RecieveData_Scanner.ReadOnly = true;
            this.RecieveData_Scanner.Size = new System.Drawing.Size(396, 82);
            this.RecieveData_Scanner.TabIndex = 154;
            this.RecieveData_Scanner.Text = "";
            // 
            // label52
            // 
            this.label52.AutoSize = true;
            this.label52.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label52.Location = new System.Drawing.Point(145, 288);
            this.label52.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label52.Name = "label52";
            this.label52.Size = new System.Drawing.Size(150, 18);
            this.label52.TabIndex = 151;
            this.label52.Text = "Trigger Delay Time";
            // 
            // btn_Cali_Scan_Trigger
            // 
            this.btn_Cali_Scan_Trigger.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(94)))), ((int)(((byte)(133)))));
            this.btn_Cali_Scan_Trigger.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Cali_Scan_Trigger.ForeColor = System.Drawing.Color.White;
            this.btn_Cali_Scan_Trigger.Location = new System.Drawing.Point(8, 298);
            this.btn_Cali_Scan_Trigger.Margin = new System.Windows.Forms.Padding(4);
            this.btn_Cali_Scan_Trigger.Name = "btn_Cali_Scan_Trigger";
            this.btn_Cali_Scan_Trigger.Size = new System.Drawing.Size(132, 43);
            this.btn_Cali_Scan_Trigger.TabIndex = 144;
            this.btn_Cali_Scan_Trigger.Text = "Trigger";
            this.btn_Cali_Scan_Trigger.UseVisualStyleBackColor = false;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.groupBox7);
            this.tabPage4.Location = new System.Drawing.Point(4, 27);
            this.tabPage4.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(1349, 679);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Robot";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // groupBox7
            // 
            this.groupBox7.BackColor = System.Drawing.Color.WhiteSmoke;
            this.groupBox7.Controls.Add(this.btn_Cali_Rob_Connect);
            this.groupBox7.Controls.Add(this.btn_Cali_Rob_Trigger);
            this.groupBox7.Controls.Add(this.label44);
            this.groupBox7.Controls.Add(this.label45);
            this.groupBox7.Controls.Add(this.label46);
            this.groupBox7.Controls.Add(this.RecieveDataRobo);
            this.groupBox7.Controls.Add(this.label47);
            this.groupBox7.Controls.Add(this.Robo_textBox);
            this.groupBox7.Controls.Add(this.label48);
            this.groupBox7.Controls.Add(this.cmbRoboTrigger);
            this.groupBox7.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Bold);
            this.groupBox7.Location = new System.Drawing.Point(476, 137);
            this.groupBox7.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox7.Size = new System.Drawing.Size(411, 396);
            this.groupBox7.TabIndex = 182;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Robot";
            // 
            // btn_Cali_Rob_Connect
            // 
            this.btn_Cali_Rob_Connect.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(94)))), ((int)(((byte)(133)))));
            this.btn_Cali_Rob_Connect.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Cali_Rob_Connect.ForeColor = System.Drawing.Color.White;
            this.btn_Cali_Rob_Connect.Location = new System.Drawing.Point(8, 251);
            this.btn_Cali_Rob_Connect.Margin = new System.Windows.Forms.Padding(4);
            this.btn_Cali_Rob_Connect.Name = "btn_Cali_Rob_Connect";
            this.btn_Cali_Rob_Connect.Size = new System.Drawing.Size(132, 43);
            this.btn_Cali_Rob_Connect.TabIndex = 100;
            this.btn_Cali_Rob_Connect.Text = "Connect";
            this.btn_Cali_Rob_Connect.UseVisualStyleBackColor = false;
            // 
            // btn_Cali_Rob_Trigger
            // 
            this.btn_Cali_Rob_Trigger.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(94)))), ((int)(((byte)(133)))));
            this.btn_Cali_Rob_Trigger.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Cali_Rob_Trigger.ForeColor = System.Drawing.Color.White;
            this.btn_Cali_Rob_Trigger.Location = new System.Drawing.Point(8, 299);
            this.btn_Cali_Rob_Trigger.Margin = new System.Windows.Forms.Padding(4);
            this.btn_Cali_Rob_Trigger.Name = "btn_Cali_Rob_Trigger";
            this.btn_Cali_Rob_Trigger.Size = new System.Drawing.Size(132, 43);
            this.btn_Cali_Rob_Trigger.TabIndex = 100;
            this.btn_Cali_Rob_Trigger.Text = "Trigger";
            this.btn_Cali_Rob_Trigger.UseVisualStyleBackColor = false;
            // 
            // label44
            // 
            this.label44.BackColor = System.Drawing.Color.Maroon;
            this.label44.Location = new System.Drawing.Point(180, 30);
            this.label44.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label44.Name = "label44";
            this.label44.Size = new System.Drawing.Size(28, 25);
            this.label44.TabIndex = 152;
            // 
            // label45
            // 
            this.label45.AutoSize = true;
            this.label45.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label45.Location = new System.Drawing.Point(8, 33);
            this.label45.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label45.Name = "label45";
            this.label45.Size = new System.Drawing.Size(145, 18);
            this.label45.TabIndex = 152;
            this.label45.Text = "Robot Conn Status";
            // 
            // label46
            // 
            this.label46.AutoSize = true;
            this.label46.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label46.Location = new System.Drawing.Point(15, 128);
            this.label46.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label46.Name = "label46";
            this.label46.Size = new System.Drawing.Size(116, 18);
            this.label46.TabIndex = 155;
            this.label46.Text = "Received Data";
            // 
            // RecieveDataRobo
            // 
            this.RecieveDataRobo.AccessibleName = "";
            this.RecieveDataRobo.BackColor = System.Drawing.Color.White;
            this.RecieveDataRobo.Location = new System.Drawing.Point(12, 151);
            this.RecieveDataRobo.Margin = new System.Windows.Forms.Padding(4);
            this.RecieveDataRobo.Name = "RecieveDataRobo";
            this.RecieveDataRobo.ReadOnly = true;
            this.RecieveDataRobo.Size = new System.Drawing.Size(396, 82);
            this.RecieveDataRobo.TabIndex = 154;
            this.RecieveDataRobo.Text = "";
            // 
            // label47
            // 
            this.label47.AutoSize = true;
            this.label47.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label47.Location = new System.Drawing.Point(144, 283);
            this.label47.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label47.Name = "label47";
            this.label47.Size = new System.Drawing.Size(150, 18);
            this.label47.TabIndex = 151;
            this.label47.Text = "Trigger Delay Time";
            // 
            // Robo_textBox
            // 
            this.Robo_textBox.BackColor = System.Drawing.Color.White;
            this.Robo_textBox.Enabled = false;
            this.Robo_textBox.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Robo_textBox.Location = new System.Drawing.Point(301, 277);
            this.Robo_textBox.Margin = new System.Windows.Forms.Padding(4);
            this.Robo_textBox.Name = "Robo_textBox";
            this.Robo_textBox.ReadOnly = true;
            this.Robo_textBox.Size = new System.Drawing.Size(87, 30);
            this.Robo_textBox.TabIndex = 150;
            // 
            // label48
            // 
            this.label48.AutoSize = true;
            this.label48.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label48.Location = new System.Drawing.Point(4, 62);
            this.label48.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label48.Name = "label48";
            this.label48.Size = new System.Drawing.Size(188, 18);
            this.label48.TabIndex = 147;
            this.label48.Text = "Select Trigger command";
            // 
            // cmbRoboTrigger
            // 
            this.cmbRoboTrigger.BackColor = System.Drawing.Color.White;
            this.cmbRoboTrigger.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRoboTrigger.Font = new System.Drawing.Font("Verdana", 11.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbRoboTrigger.FormattingEnabled = true;
            this.cmbRoboTrigger.Items.AddRange(new object[] {
            "Command_1",
            "Command_2",
            "Command_3"});
            this.cmbRoboTrigger.Location = new System.Drawing.Point(8, 87);
            this.cmbRoboTrigger.Margin = new System.Windows.Forms.Padding(4);
            this.cmbRoboTrigger.Name = "cmbRoboTrigger";
            this.cmbRoboTrigger.Size = new System.Drawing.Size(380, 33);
            this.cmbRoboTrigger.TabIndex = 86;
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.groupBox6);
            this.tabPage5.Location = new System.Drawing.Point(4, 27);
            this.tabPage5.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Size = new System.Drawing.Size(1349, 679);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "Vision";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.label32);
            this.groupBox6.Controls.Add(this.btnCalibRun);
            this.groupBox6.Controls.Add(this.txtvisioncalib);
            this.groupBox6.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Bold);
            this.groupBox6.Location = new System.Drawing.Point(455, 222);
            this.groupBox6.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox6.Size = new System.Drawing.Size(395, 244);
            this.groupBox6.TabIndex = 183;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Vision";
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label32.Location = new System.Drawing.Point(23, 73);
            this.label32.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(135, 18);
            this.label32.TabIndex = 95;
            this.label32.Text = "Calibration Mode";
            // 
            // btnCalibRun
            // 
            this.btnCalibRun.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(94)))), ((int)(((byte)(133)))));
            this.btnCalibRun.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCalibRun.ForeColor = System.Drawing.Color.White;
            this.btnCalibRun.Location = new System.Drawing.Point(131, 167);
            this.btnCalibRun.Margin = new System.Windows.Forms.Padding(4);
            this.btnCalibRun.Name = "btnCalibRun";
            this.btnCalibRun.Size = new System.Drawing.Size(132, 43);
            this.btnCalibRun.TabIndex = 100;
            this.btnCalibRun.Text = "Run";
            this.btnCalibRun.UseVisualStyleBackColor = false;
            // 
            // txtvisioncalib
            // 
            this.txtvisioncalib.BackColor = System.Drawing.Color.White;
            this.txtvisioncalib.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.txtvisioncalib.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtvisioncalib.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtvisioncalib.FormattingEnabled = true;
            this.txtvisioncalib.Items.AddRange(new object[] {
            "ROBOT_CONVEYOR_1_CCD6_7",
            "ROBOT_CONVEYOR_1_CCD4_5",
            "SCREW_GANTRY_CONVEYOR_1_CCD5_12",
            "SCREW_GANTRY_CONVEYOR_2_CCD4_12",
            "PICK_GANTRY_CCD1",
            "ROBOT_CONVEYOR_2_CCD10_11",
            "ROBOT_CONVEYOR_2_CCD8_9",
            "SCREW_GANTRY_CONVEYOR_1_CCD9_12",
            "SCREW_GANTRY_CONVEYOR_1_CCD8_12"});
            this.txtvisioncalib.Location = new System.Drawing.Point(24, 106);
            this.txtvisioncalib.Margin = new System.Windows.Forms.Padding(4);
            this.txtvisioncalib.Name = "txtvisioncalib";
            this.txtvisioncalib.Size = new System.Drawing.Size(332, 28);
            this.txtvisioncalib.TabIndex = 0;
            // 
            // MotorDebug
            // 
            this.MotorDebug.Controls.Add(this.panel2);
            this.MotorDebug.Location = new System.Drawing.Point(4, 49);
            this.MotorDebug.Margin = new System.Windows.Forms.Padding(4);
            this.MotorDebug.Name = "MotorDebug";
            this.MotorDebug.Size = new System.Drawing.Size(1357, 710);
            this.MotorDebug.TabIndex = 8;
            this.MotorDebug.Text = "Motor Debug";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnSave);
            this.panel2.Controls.Add(this.btnedit);
            this.panel2.Controls.Add(this.grbMotor);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1357, 710);
            this.panel2.TabIndex = 0;
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(94)))), ((int)(((byte)(133)))));
            this.btnSave.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(1219, 654);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(123, 43);
            this.btnSave.TabIndex = 92;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnedit
            // 
            this.btnedit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(94)))), ((int)(((byte)(133)))));
            this.btnedit.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnedit.ForeColor = System.Drawing.Color.White;
            this.btnedit.Location = new System.Drawing.Point(1060, 654);
            this.btnedit.Margin = new System.Windows.Forms.Padding(4);
            this.btnedit.Name = "btnedit";
            this.btnedit.Size = new System.Drawing.Size(123, 43);
            this.btnedit.TabIndex = 72;
            this.btnedit.Text = "Edit";
            this.btnedit.UseVisualStyleBackColor = false;
            this.btnedit.Click += new System.EventHandler(this.btnedit_Click);
            // 
            // grbMotor
            // 
            this.grbMotor.Controls.Add(this.Axis_Config);
            this.grbMotor.Location = new System.Drawing.Point(4, 5);
            this.grbMotor.Margin = new System.Windows.Forms.Padding(4);
            this.grbMotor.Name = "grbMotor";
            this.grbMotor.Padding = new System.Windows.Forms.Padding(4);
            this.grbMotor.Size = new System.Drawing.Size(1340, 641);
            this.grbMotor.TabIndex = 91;
            this.grbMotor.TabStop = false;
            this.grbMotor.Text = "Motor Parameter Setting";
            // 
            // Axis_Config
            // 
            this.Axis_Config.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.Axis_Config.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.Axis_Config.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.Axis_Config.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Axis_Config.Location = new System.Drawing.Point(0, 31);
            this.Axis_Config.Margin = new System.Windows.Forms.Padding(4);
            this.Axis_Config.Name = "Axis_Config";
            this.Axis_Config.RowHeadersWidth = 51;
            this.Axis_Config.Size = new System.Drawing.Size(1337, 608);
            this.Axis_Config.TabIndex = 90;
            // 
            // SOP
            // 
            this.SOP.Controls.Add(this.panel3);
            this.SOP.Location = new System.Drawing.Point(4, 49);
            this.SOP.Margin = new System.Windows.Forms.Padding(4);
            this.SOP.Name = "SOP";
            this.SOP.Padding = new System.Windows.Forms.Padding(4);
            this.SOP.Size = new System.Drawing.Size(1357, 710);
            this.SOP.TabIndex = 0;
            this.SOP.Text = "SOP";
            this.SOP.UseVisualStyleBackColor = true;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.grpBoxCCD1);
            this.panel3.Controls.Add(this.groupBox18);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(4, 4);
            this.panel3.Margin = new System.Windows.Forms.Padding(4);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1349, 702);
            this.panel3.TabIndex = 0;
            // 
            // grpBoxCCD1
            // 
            this.grpBoxCCD1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.grpBoxCCD1.Controls.Add(this.cmbTestMode);
            this.grpBoxCCD1.Controls.Add(this.label1);
            this.grpBoxCCD1.Controls.Add(this.label36);
            this.grpBoxCCD1.Controls.Add(this.label2);
            this.grpBoxCCD1.Controls.Add(this.label129);
            this.grpBoxCCD1.Controls.Add(this.txtstaticposccd1_y);
            this.grpBoxCCD1.Controls.Add(this.txtstaticposccd1_x);
            this.grpBoxCCD1.Controls.Add(this.label3);
            this.grpBoxCCD1.Controls.Add(this.btnccd1Browse);
            this.grpBoxCCD1.Controls.Add(this.txtccd1path);
            this.grpBoxCCD1.Controls.Add(this.lblactualpos_ccd1_y);
            this.grpBoxCCD1.Controls.Add(this.lblactualpos_ccd1_x);
            this.grpBoxCCD1.Controls.Add(this.label4);
            this.grpBoxCCD1.Controls.Add(this.label41);
            this.grpBoxCCD1.Controls.Add(this.label42);
            this.grpBoxCCD1.Controls.Add(this.label43);
            this.grpBoxCCD1.Controls.Add(this.btnCCD_start);
            this.grpBoxCCD1.Controls.Add(this.btnCCD_stop);
            this.grpBoxCCD1.Controls.Add(this.txtCounts);
            this.grpBoxCCD1.Controls.Add(this.label50);
            this.grpBoxCCD1.Controls.Add(this.txtspeed);
            this.grpBoxCCD1.Controls.Add(this.label77);
            this.grpBoxCCD1.Controls.Add(this.txtposition_y2);
            this.grpBoxCCD1.Controls.Add(this.txtstaticposccd1_z);
            this.grpBoxCCD1.Controls.Add(this.txtposition_Z2);
            this.grpBoxCCD1.Controls.Add(this.txtpositionz1);
            this.grpBoxCCD1.Controls.Add(this.txtposition_y1);
            this.grpBoxCCD1.Controls.Add(this.label5);
            this.grpBoxCCD1.Controls.Add(this.label79);
            this.grpBoxCCD1.Controls.Add(this.label90);
            this.grpBoxCCD1.Controls.Add(this.txtposition_x2);
            this.grpBoxCCD1.Controls.Add(this.label91);
            this.grpBoxCCD1.Controls.Add(this.txtposition_x1);
            this.grpBoxCCD1.Controls.Add(this.label117);
            this.grpBoxCCD1.Controls.Add(this.lblRunningCount);
            this.grpBoxCCD1.Controls.Add(this.label118);
            this.grpBoxCCD1.Controls.Add(this.label119);
            this.grpBoxCCD1.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpBoxCCD1.Location = new System.Drawing.Point(23, 121);
            this.grpBoxCCD1.Margin = new System.Windows.Forms.Padding(4);
            this.grpBoxCCD1.Name = "grpBoxCCD1";
            this.grpBoxCCD1.Padding = new System.Windows.Forms.Padding(4);
            this.grpBoxCCD1.Size = new System.Drawing.Size(679, 575);
            this.grpBoxCCD1.TabIndex = 136;
            this.grpBoxCCD1.TabStop = false;
            this.grpBoxCCD1.Text = "CCD Repetability test setup";
            // 
            // cmbTestMode
            // 
            this.cmbTestMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTestMode.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbTestMode.FormattingEnabled = true;
            this.cmbTestMode.Items.AddRange(new object[] {
            "Dynamic",
            "Static"});
            this.cmbTestMode.Location = new System.Drawing.Point(187, 42);
            this.cmbTestMode.Margin = new System.Windows.Forms.Padding(4);
            this.cmbTestMode.Name = "cmbTestMode";
            this.cmbTestMode.Size = new System.Drawing.Size(204, 26);
            this.cmbTestMode.TabIndex = 111;
            this.cmbTestMode.SelectedIndexChanged += new System.EventHandler(this.cmbTestMode_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(296, 341);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 21);
            this.label1.TabIndex = 110;
            this.label1.Text = "(mm/s)";
            // 
            // label36
            // 
            this.label36.AutoSize = true;
            this.label36.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label36.Location = new System.Drawing.Point(511, 289);
            this.label36.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(52, 21);
            this.label36.TabIndex = 109;
            this.label36.Text = "(mm)";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(511, 235);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 21);
            this.label2.TabIndex = 108;
            this.label2.Text = "(mm)";
            // 
            // label129
            // 
            this.label129.AutoSize = true;
            this.label129.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label129.Location = new System.Drawing.Point(511, 183);
            this.label129.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label129.Name = "label129";
            this.label129.Size = new System.Drawing.Size(52, 21);
            this.label129.TabIndex = 107;
            this.label129.Text = "(mm)";
            // 
            // txtstaticposccd1_y
            // 
            this.txtstaticposccd1_y.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtstaticposccd1_y.Location = new System.Drawing.Point(300, 281);
            this.txtstaticposccd1_y.Margin = new System.Windows.Forms.Padding(4);
            this.txtstaticposccd1_y.Name = "txtstaticposccd1_y";
            this.txtstaticposccd1_y.Size = new System.Drawing.Size(83, 27);
            this.txtstaticposccd1_y.TabIndex = 84;
            // 
            // txtstaticposccd1_x
            // 
            this.txtstaticposccd1_x.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtstaticposccd1_x.Location = new System.Drawing.Point(187, 281);
            this.txtstaticposccd1_x.Margin = new System.Windows.Forms.Padding(4);
            this.txtstaticposccd1_x.Name = "txtstaticposccd1_x";
            this.txtstaticposccd1_x.Size = new System.Drawing.Size(83, 27);
            this.txtstaticposccd1_x.TabIndex = 83;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(37, 284);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(94, 20);
            this.label3.TabIndex = 82;
            this.label3.Text = "Static Pos";
            // 
            // btnccd1Browse
            // 
            this.btnccd1Browse.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(94)))), ((int)(((byte)(133)))));
            this.btnccd1Browse.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnccd1Browse.ForeColor = System.Drawing.Color.White;
            this.btnccd1Browse.Location = new System.Drawing.Point(476, 464);
            this.btnccd1Browse.Margin = new System.Windows.Forms.Padding(4);
            this.btnccd1Browse.Name = "btnccd1Browse";
            this.btnccd1Browse.Size = new System.Drawing.Size(111, 36);
            this.btnccd1Browse.TabIndex = 81;
            this.btnccd1Browse.Text = "Browse";
            this.btnccd1Browse.UseVisualStyleBackColor = false;
            this.btnccd1Browse.Click += new System.EventHandler(this.btnccd1Browse_Click);
            // 
            // txtccd1path
            // 
            this.txtccd1path.Enabled = false;
            this.txtccd1path.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtccd1path.Location = new System.Drawing.Point(43, 468);
            this.txtccd1path.Margin = new System.Windows.Forms.Padding(4);
            this.txtccd1path.Name = "txtccd1path";
            this.txtccd1path.Size = new System.Drawing.Size(412, 27);
            this.txtccd1path.TabIndex = 80;
            // 
            // lblactualpos_ccd1_y
            // 
            this.lblactualpos_ccd1_y.AutoSize = true;
            this.lblactualpos_ccd1_y.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblactualpos_ccd1_y.Location = new System.Drawing.Point(581, 108);
            this.lblactualpos_ccd1_y.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblactualpos_ccd1_y.Name = "lblactualpos_ccd1_y";
            this.lblactualpos_ccd1_y.Size = new System.Drawing.Size(20, 20);
            this.lblactualpos_ccd1_y.TabIndex = 79;
            this.lblactualpos_ccd1_y.Text = "0";
            // 
            // lblactualpos_ccd1_x
            // 
            this.lblactualpos_ccd1_x.AutoSize = true;
            this.lblactualpos_ccd1_x.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblactualpos_ccd1_x.Location = new System.Drawing.Point(511, 108);
            this.lblactualpos_ccd1_x.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblactualpos_ccd1_x.Name = "lblactualpos_ccd1_x";
            this.lblactualpos_ccd1_x.Size = new System.Drawing.Size(20, 20);
            this.lblactualpos_ccd1_x.TabIndex = 78;
            this.lblactualpos_ccd1_x.Text = "0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(581, 69);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(19, 20);
            this.label4.TabIndex = 77;
            this.label4.Text = "Y";
            // 
            // label41
            // 
            this.label41.AutoSize = true;
            this.label41.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label41.Location = new System.Drawing.Point(511, 69);
            this.label41.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(21, 20);
            this.label41.TabIndex = 76;
            this.label41.Text = "X";
            // 
            // label42
            // 
            this.label42.AutoSize = true;
            this.label42.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label42.Location = new System.Drawing.Point(369, 108);
            this.label42.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(136, 20);
            this.label42.TabIndex = 75;
            this.label42.Text = "Actual Position";
            // 
            // label43
            // 
            this.label43.AutoSize = true;
            this.label43.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label43.Location = new System.Drawing.Point(39, 430);
            this.label43.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label43.Name = "label43";
            this.label43.Size = new System.Drawing.Size(173, 20);
            this.label43.TabIndex = 74;
            this.label43.Text = "CSV File Save Path";
            // 
            // btnCCD_start
            // 
            this.btnCCD_start.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(94)))), ((int)(((byte)(133)))));
            this.btnCCD_start.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCCD_start.ForeColor = System.Drawing.Color.White;
            this.btnCCD_start.Location = new System.Drawing.Point(43, 512);
            this.btnCCD_start.Margin = new System.Windows.Forms.Padding(4);
            this.btnCCD_start.Name = "btnCCD_start";
            this.btnCCD_start.Size = new System.Drawing.Size(111, 46);
            this.btnCCD_start.TabIndex = 73;
            this.btnCCD_start.Text = "Start";
            this.btnCCD_start.UseVisualStyleBackColor = false;
            this.btnCCD_start.Click += new System.EventHandler(this.btnCCD_start_Click);
            // 
            // btnCCD_stop
            // 
            this.btnCCD_stop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(94)))), ((int)(((byte)(133)))));
            this.btnCCD_stop.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCCD_stop.ForeColor = System.Drawing.Color.White;
            this.btnCCD_stop.Location = new System.Drawing.Point(188, 512);
            this.btnCCD_stop.Margin = new System.Windows.Forms.Padding(4);
            this.btnCCD_stop.Name = "btnCCD_stop";
            this.btnCCD_stop.Size = new System.Drawing.Size(111, 46);
            this.btnCCD_stop.TabIndex = 72;
            this.btnCCD_stop.Text = "Stop";
            this.btnCCD_stop.UseVisualStyleBackColor = false;
            // 
            // txtCounts
            // 
            this.txtCounts.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCounts.Location = new System.Drawing.Point(187, 384);
            this.txtCounts.Margin = new System.Windows.Forms.Padding(4);
            this.txtCounts.Name = "txtCounts";
            this.txtCounts.Size = new System.Drawing.Size(83, 27);
            this.txtCounts.TabIndex = 15;
            // 
            // label50
            // 
            this.label50.AutoSize = true;
            this.label50.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label50.Location = new System.Drawing.Point(37, 388);
            this.label50.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label50.Name = "label50";
            this.label50.Size = new System.Drawing.Size(120, 20);
            this.label50.TabIndex = 14;
            this.label50.Text = "No of Counts";
            // 
            // txtspeed
            // 
            this.txtspeed.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtspeed.Location = new System.Drawing.Point(187, 332);
            this.txtspeed.Margin = new System.Windows.Forms.Padding(4);
            this.txtspeed.Name = "txtspeed";
            this.txtspeed.Size = new System.Drawing.Size(83, 27);
            this.txtspeed.TabIndex = 13;
            // 
            // label77
            // 
            this.label77.AutoSize = true;
            this.label77.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label77.Location = new System.Drawing.Point(37, 336);
            this.label77.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label77.Name = "label77";
            this.label77.Size = new System.Drawing.Size(63, 20);
            this.label77.TabIndex = 12;
            this.label77.Text = "Speed";
            // 
            // txtposition_y2
            // 
            this.txtposition_y2.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtposition_y2.Location = new System.Drawing.Point(300, 228);
            this.txtposition_y2.Margin = new System.Windows.Forms.Padding(4);
            this.txtposition_y2.Name = "txtposition_y2";
            this.txtposition_y2.Size = new System.Drawing.Size(83, 27);
            this.txtposition_y2.TabIndex = 11;
            // 
            // txtstaticposccd1_z
            // 
            this.txtstaticposccd1_z.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtstaticposccd1_z.Location = new System.Drawing.Point(407, 281);
            this.txtstaticposccd1_z.Margin = new System.Windows.Forms.Padding(4);
            this.txtstaticposccd1_z.Name = "txtstaticposccd1_z";
            this.txtstaticposccd1_z.Size = new System.Drawing.Size(83, 27);
            this.txtstaticposccd1_z.TabIndex = 10;
            // 
            // txtposition_Z2
            // 
            this.txtposition_Z2.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtposition_Z2.Location = new System.Drawing.Point(407, 226);
            this.txtposition_Z2.Margin = new System.Windows.Forms.Padding(4);
            this.txtposition_Z2.Name = "txtposition_Z2";
            this.txtposition_Z2.Size = new System.Drawing.Size(83, 27);
            this.txtposition_Z2.TabIndex = 10;
            // 
            // txtpositionz1
            // 
            this.txtpositionz1.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtpositionz1.Location = new System.Drawing.Point(407, 180);
            this.txtpositionz1.Margin = new System.Windows.Forms.Padding(4);
            this.txtpositionz1.Name = "txtpositionz1";
            this.txtpositionz1.Size = new System.Drawing.Size(83, 27);
            this.txtpositionz1.TabIndex = 10;
            // 
            // txtposition_y1
            // 
            this.txtposition_y1.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtposition_y1.Location = new System.Drawing.Point(300, 180);
            this.txtposition_y1.Margin = new System.Windows.Forms.Padding(4);
            this.txtposition_y1.Name = "txtposition_y1";
            this.txtposition_y1.Size = new System.Drawing.Size(83, 27);
            this.txtposition_y1.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(435, 144);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(21, 20);
            this.label5.TabIndex = 9;
            this.label5.Text = "Z";
            // 
            // label79
            // 
            this.label79.AutoSize = true;
            this.label79.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label79.Location = new System.Drawing.Point(331, 144);
            this.label79.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label79.Name = "label79";
            this.label79.Size = new System.Drawing.Size(19, 20);
            this.label79.TabIndex = 9;
            this.label79.Text = "Y";
            // 
            // label90
            // 
            this.label90.AutoSize = true;
            this.label90.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label90.Location = new System.Drawing.Point(217, 144);
            this.label90.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label90.Name = "label90";
            this.label90.Size = new System.Drawing.Size(21, 20);
            this.label90.TabIndex = 8;
            this.label90.Text = "X";
            // 
            // txtposition_x2
            // 
            this.txtposition_x2.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtposition_x2.Location = new System.Drawing.Point(187, 228);
            this.txtposition_x2.Margin = new System.Windows.Forms.Padding(4);
            this.txtposition_x2.Name = "txtposition_x2";
            this.txtposition_x2.Size = new System.Drawing.Size(83, 27);
            this.txtposition_x2.TabIndex = 7;
            // 
            // label91
            // 
            this.label91.AutoSize = true;
            this.label91.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label91.Location = new System.Drawing.Point(37, 231);
            this.label91.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label91.Name = "label91";
            this.label91.Size = new System.Drawing.Size(136, 20);
            this.label91.TabIndex = 6;
            this.label91.Text = "Dynamic Pos 2";
            // 
            // txtposition_x1
            // 
            this.txtposition_x1.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtposition_x1.Location = new System.Drawing.Point(187, 180);
            this.txtposition_x1.Margin = new System.Windows.Forms.Padding(4);
            this.txtposition_x1.Name = "txtposition_x1";
            this.txtposition_x1.Size = new System.Drawing.Size(83, 27);
            this.txtposition_x1.TabIndex = 5;
            // 
            // label117
            // 
            this.label117.AutoSize = true;
            this.label117.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label117.Location = new System.Drawing.Point(37, 183);
            this.label117.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label117.Name = "label117";
            this.label117.Size = new System.Drawing.Size(136, 20);
            this.label117.TabIndex = 4;
            this.label117.Text = "Dynamic Pos 1";
            // 
            // lblRunningCount
            // 
            this.lblRunningCount.AutoSize = true;
            this.lblRunningCount.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRunningCount.Location = new System.Drawing.Point(180, 108);
            this.lblRunningCount.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblRunningCount.Name = "lblRunningCount";
            this.lblRunningCount.Size = new System.Drawing.Size(20, 20);
            this.lblRunningCount.TabIndex = 3;
            this.lblRunningCount.Text = "0";
            // 
            // label118
            // 
            this.label118.AutoSize = true;
            this.label118.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label118.Location = new System.Drawing.Point(37, 108);
            this.label118.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label118.Name = "label118";
            this.label118.Size = new System.Drawing.Size(138, 20);
            this.label118.TabIndex = 2;
            this.label118.Text = "Running Count";
            // 
            // label119
            // 
            this.label119.AutoSize = true;
            this.label119.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label119.Location = new System.Drawing.Point(37, 46);
            this.label119.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label119.Name = "label119";
            this.label119.Size = new System.Drawing.Size(94, 20);
            this.label119.TabIndex = 0;
            this.label119.Text = "Test Mode";
            // 
            // groupBox18
            // 
            this.groupBox18.BackColor = System.Drawing.Color.WhiteSmoke;
            this.groupBox18.Controls.Add(this.cmbCamera);
            this.groupBox18.Controls.Add(this.label40);
            this.groupBox18.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox18.Location = new System.Drawing.Point(23, 1);
            this.groupBox18.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox18.Name = "groupBox18";
            this.groupBox18.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox18.Size = new System.Drawing.Size(679, 118);
            this.groupBox18.TabIndex = 135;
            this.groupBox18.TabStop = false;
            this.groupBox18.Text = "Choose Camera";
            // 
            // cmbCamera
            // 
            this.cmbCamera.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCamera.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbCamera.FormattingEnabled = true;
            this.cmbCamera.Items.AddRange(new object[] {
            "CCD1",
            "CCD2",
            "CCD3",
            "CCD4"});
            this.cmbCamera.Location = new System.Drawing.Point(187, 54);
            this.cmbCamera.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmbCamera.Name = "cmbCamera";
            this.cmbCamera.Size = new System.Drawing.Size(237, 26);
            this.cmbCamera.TabIndex = 3;
            // 
            // label40
            // 
            this.label40.AutoSize = true;
            this.label40.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label40.Location = new System.Drawing.Point(20, 58);
            this.label40.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(113, 20);
            this.label40.TabIndex = 2;
            this.label40.Text = "Select Mode";
            // 
            // AxisZeroSetting
            // 
            this.AxisZeroSetting.Controls.Add(this.panel9);
            this.AxisZeroSetting.Location = new System.Drawing.Point(4, 49);
            this.AxisZeroSetting.Margin = new System.Windows.Forms.Padding(4);
            this.AxisZeroSetting.Name = "AxisZeroSetting";
            this.AxisZeroSetting.Size = new System.Drawing.Size(1357, 710);
            this.AxisZeroSetting.TabIndex = 8;
            this.AxisZeroSetting.Text = "Axis Zero Setting";
            this.AxisZeroSetting.UseVisualStyleBackColor = true;
            // 
            // panel9
            // 
            this.panel9.Controls.Add(this.groupBox16);
            this.panel9.Controls.Add(this.groupBox13);
            this.panel9.Controls.Add(this.groupBox14);
            this.panel9.Controls.Add(this.groupBox15);
            this.panel9.Controls.Add(this.label98);
            this.panel9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel9.Location = new System.Drawing.Point(0, 0);
            this.panel9.Margin = new System.Windows.Forms.Padding(4);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(1357, 710);
            this.panel9.TabIndex = 0;
            // 
            // groupBox16
            // 
            this.groupBox16.BackColor = System.Drawing.Color.WhiteSmoke;
            this.groupBox16.Controls.Add(this.label99);
            this.groupBox16.Controls.Add(this.label100);
            this.groupBox16.Controls.Add(this.label101);
            this.groupBox16.Controls.Add(this.label102);
            this.groupBox16.Controls.Add(this.label103);
            this.groupBox16.Controls.Add(this.label104);
            this.groupBox16.Controls.Add(this.label105);
            this.groupBox16.Controls.Add(this.label106);
            this.groupBox16.Controls.Add(this.label107);
            this.groupBox16.Controls.Add(this.label108);
            this.groupBox16.Controls.Add(this.label109);
            this.groupBox16.Controls.Add(this.label110);
            this.groupBox16.Controls.Add(this.btnStopRHFeeder);
            this.groupBox16.Controls.Add(this.label111);
            this.groupBox16.Controls.Add(this.label112);
            this.groupBox16.Controls.Add(this.btnHomeRHUnloader);
            this.groupBox16.Controls.Add(this.btnZeroRHUnloader);
            this.groupBox16.Controls.Add(this.btnHomeRHLoader);
            this.groupBox16.Controls.Add(this.btnZeroRHLoader);
            this.groupBox16.Controls.Add(this.label113);
            this.groupBox16.Controls.Add(this.label114);
            this.groupBox16.Controls.Add(this.textBox12);
            this.groupBox16.Controls.Add(this.label115);
            this.groupBox16.Controls.Add(this.label116);
            this.groupBox16.Controls.Add(this.textBox13);
            this.groupBox16.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox16.Location = new System.Drawing.Point(45, 497);
            this.groupBox16.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox16.Name = "groupBox16";
            this.groupBox16.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox16.Size = new System.Drawing.Size(1204, 197);
            this.groupBox16.TabIndex = 137;
            this.groupBox16.TabStop = false;
            this.groupBox16.Text = "Feeder Axis Setting";
            // 
            // label99
            // 
            this.label99.BackColor = System.Drawing.Color.Maroon;
            this.label99.Location = new System.Drawing.Point(496, 149);
            this.label99.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label99.Name = "label99";
            this.label99.Size = new System.Drawing.Size(35, 32);
            this.label99.TabIndex = 169;
            // 
            // label100
            // 
            this.label100.AutoSize = true;
            this.label100.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label100.Location = new System.Drawing.Point(609, 129);
            this.label100.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label100.Name = "label100";
            this.label100.Size = new System.Drawing.Size(26, 18);
            this.label100.TabIndex = 168;
            this.label100.Text = "EL";
            // 
            // label101
            // 
            this.label101.AutoSize = true;
            this.label101.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label101.Location = new System.Drawing.Point(541, 129);
            this.label101.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label101.Name = "label101";
            this.label101.Size = new System.Drawing.Size(42, 18);
            this.label101.TabIndex = 167;
            this.label101.Text = "ORG";
            // 
            // label102
            // 
            this.label102.AutoSize = true;
            this.label102.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label102.Location = new System.Drawing.Point(492, 129);
            this.label102.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label102.Name = "label102";
            this.label102.Size = new System.Drawing.Size(29, 18);
            this.label102.TabIndex = 166;
            this.label102.Text = "NL";
            // 
            // label103
            // 
            this.label103.BackColor = System.Drawing.Color.Maroon;
            this.label103.Location = new System.Drawing.Point(553, 150);
            this.label103.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label103.Name = "label103";
            this.label103.Size = new System.Drawing.Size(35, 32);
            this.label103.TabIndex = 165;
            // 
            // label104
            // 
            this.label104.BackColor = System.Drawing.Color.Maroon;
            this.label104.Location = new System.Drawing.Point(613, 150);
            this.label104.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label104.Name = "label104";
            this.label104.Size = new System.Drawing.Size(35, 32);
            this.label104.TabIndex = 164;
            // 
            // label105
            // 
            this.label105.BackColor = System.Drawing.Color.Maroon;
            this.label105.Location = new System.Drawing.Point(149, 150);
            this.label105.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label105.Name = "label105";
            this.label105.Size = new System.Drawing.Size(35, 32);
            this.label105.TabIndex = 163;
            // 
            // label106
            // 
            this.label106.AutoSize = true;
            this.label106.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label106.Location = new System.Drawing.Point(268, 129);
            this.label106.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label106.Name = "label106";
            this.label106.Size = new System.Drawing.Size(26, 18);
            this.label106.TabIndex = 162;
            this.label106.Text = "EL";
            // 
            // label107
            // 
            this.label107.AutoSize = true;
            this.label107.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label107.Location = new System.Drawing.Point(201, 129);
            this.label107.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label107.Name = "label107";
            this.label107.Size = new System.Drawing.Size(42, 18);
            this.label107.TabIndex = 161;
            this.label107.Text = "ORG";
            // 
            // label108
            // 
            this.label108.AutoSize = true;
            this.label108.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label108.Location = new System.Drawing.Point(152, 129);
            this.label108.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label108.Name = "label108";
            this.label108.Size = new System.Drawing.Size(29, 18);
            this.label108.TabIndex = 160;
            this.label108.Text = "NL";
            // 
            // label109
            // 
            this.label109.BackColor = System.Drawing.Color.Maroon;
            this.label109.Location = new System.Drawing.Point(211, 150);
            this.label109.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label109.Name = "label109";
            this.label109.Size = new System.Drawing.Size(35, 32);
            this.label109.TabIndex = 159;
            // 
            // label110
            // 
            this.label110.BackColor = System.Drawing.Color.Maroon;
            this.label110.Location = new System.Drawing.Point(271, 150);
            this.label110.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label110.Name = "label110";
            this.label110.Size = new System.Drawing.Size(35, 32);
            this.label110.TabIndex = 158;
            // 
            // btnStopRHFeeder
            // 
            this.btnStopRHFeeder.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(94)))), ((int)(((byte)(133)))));
            this.btnStopRHFeeder.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStopRHFeeder.ForeColor = System.Drawing.Color.White;
            this.btnStopRHFeeder.Location = new System.Drawing.Point(1020, 76);
            this.btnStopRHFeeder.Margin = new System.Windows.Forms.Padding(4);
            this.btnStopRHFeeder.Name = "btnStopRHFeeder";
            this.btnStopRHFeeder.Size = new System.Drawing.Size(147, 43);
            this.btnStopRHFeeder.TabIndex = 100;
            this.btnStopRHFeeder.Text = "Stop";
            this.btnStopRHFeeder.UseVisualStyleBackColor = false;
            // 
            // label111
            // 
            this.label111.AutoSize = true;
            this.label111.Font = new System.Drawing.Font("Tahoma", 10F);
            this.label111.Location = new System.Drawing.Point(351, 158);
            this.label111.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label111.Name = "label111";
            this.label111.Size = new System.Drawing.Size(112, 21);
            this.label111.TabIndex = 156;
            this.label111.Text = "Unloader Axis";
            // 
            // label112
            // 
            this.label112.AutoSize = true;
            this.label112.Font = new System.Drawing.Font("Tahoma", 10F);
            this.label112.Location = new System.Drawing.Point(28, 158);
            this.label112.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label112.Name = "label112";
            this.label112.Size = new System.Drawing.Size(96, 21);
            this.label112.TabIndex = 155;
            this.label112.Text = "Loader Axis";
            // 
            // btnHomeRHUnloader
            // 
            this.btnHomeRHUnloader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(94)))), ((int)(((byte)(133)))));
            this.btnHomeRHUnloader.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHomeRHUnloader.ForeColor = System.Drawing.Color.White;
            this.btnHomeRHUnloader.Location = new System.Drawing.Point(480, 76);
            this.btnHomeRHUnloader.Margin = new System.Windows.Forms.Padding(4);
            this.btnHomeRHUnloader.Name = "btnHomeRHUnloader";
            this.btnHomeRHUnloader.Size = new System.Drawing.Size(265, 43);
            this.btnHomeRHUnloader.TabIndex = 154;
            this.btnHomeRHUnloader.Text = "Set Home Pos_Unloader";
            this.btnHomeRHUnloader.UseVisualStyleBackColor = false;
            // 
            // btnZeroRHUnloader
            // 
            this.btnZeroRHUnloader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(94)))), ((int)(((byte)(133)))));
            this.btnZeroRHUnloader.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnZeroRHUnloader.ForeColor = System.Drawing.Color.White;
            this.btnZeroRHUnloader.Location = new System.Drawing.Point(747, 76);
            this.btnZeroRHUnloader.Margin = new System.Windows.Forms.Padding(4);
            this.btnZeroRHUnloader.Name = "btnZeroRHUnloader";
            this.btnZeroRHUnloader.Size = new System.Drawing.Size(265, 43);
            this.btnZeroRHUnloader.TabIndex = 153;
            this.btnZeroRHUnloader.Text = "Set Zero Pos_Unloader";
            this.btnZeroRHUnloader.UseVisualStyleBackColor = false;
            // 
            // btnHomeRHLoader
            // 
            this.btnHomeRHLoader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(94)))), ((int)(((byte)(133)))));
            this.btnHomeRHLoader.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHomeRHLoader.ForeColor = System.Drawing.Color.White;
            this.btnHomeRHLoader.Location = new System.Drawing.Point(480, 22);
            this.btnHomeRHLoader.Margin = new System.Windows.Forms.Padding(4);
            this.btnHomeRHLoader.Name = "btnHomeRHLoader";
            this.btnHomeRHLoader.Size = new System.Drawing.Size(265, 43);
            this.btnHomeRHLoader.TabIndex = 152;
            this.btnHomeRHLoader.Text = "Set Home Pos_Loader";
            this.btnHomeRHLoader.UseVisualStyleBackColor = false;
            // 
            // btnZeroRHLoader
            // 
            this.btnZeroRHLoader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(94)))), ((int)(((byte)(133)))));
            this.btnZeroRHLoader.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnZeroRHLoader.ForeColor = System.Drawing.Color.White;
            this.btnZeroRHLoader.Location = new System.Drawing.Point(747, 22);
            this.btnZeroRHLoader.Margin = new System.Windows.Forms.Padding(4);
            this.btnZeroRHLoader.Name = "btnZeroRHLoader";
            this.btnZeroRHLoader.Size = new System.Drawing.Size(265, 43);
            this.btnZeroRHLoader.TabIndex = 151;
            this.btnZeroRHLoader.Text = "Set Zero Pos_Loader";
            this.btnZeroRHLoader.UseVisualStyleBackColor = false;
            // 
            // label113
            // 
            this.label113.AutoSize = true;
            this.label113.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label113.Location = new System.Drawing.Point(399, 95);
            this.label113.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label113.Name = "label113";
            this.label113.Size = new System.Drawing.Size(52, 21);
            this.label113.TabIndex = 150;
            this.label113.Text = "(mm)";
            // 
            // label114
            // 
            this.label114.AutoSize = true;
            this.label114.Font = new System.Drawing.Font("Tahoma", 10F);
            this.label114.Location = new System.Drawing.Point(32, 90);
            this.label114.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label114.Name = "label114";
            this.label114.Size = new System.Drawing.Size(204, 21);
            this.label114.TabIndex = 149;
            this.label114.Text = "Unloader Z axis Home Pos";
            // 
            // textBox12
            // 
            this.textBox12.Enabled = false;
            this.textBox12.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox12.Location = new System.Drawing.Point(260, 81);
            this.textBox12.Margin = new System.Windows.Forms.Padding(4);
            this.textBox12.Name = "textBox12";
            this.textBox12.Size = new System.Drawing.Size(119, 30);
            this.textBox12.TabIndex = 148;
            // 
            // label115
            // 
            this.label115.AutoSize = true;
            this.label115.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label115.Location = new System.Drawing.Point(399, 38);
            this.label115.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label115.Name = "label115";
            this.label115.Size = new System.Drawing.Size(52, 21);
            this.label115.TabIndex = 147;
            this.label115.Text = "(mm)";
            // 
            // label116
            // 
            this.label116.AutoSize = true;
            this.label116.Font = new System.Drawing.Font("Tahoma", 10F);
            this.label116.Location = new System.Drawing.Point(35, 39);
            this.label116.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label116.Name = "label116";
            this.label116.Size = new System.Drawing.Size(188, 21);
            this.label116.TabIndex = 146;
            this.label116.Text = "Loader Z axis Home Pos";
            // 
            // textBox13
            // 
            this.textBox13.Enabled = false;
            this.textBox13.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox13.Location = new System.Drawing.Point(260, 32);
            this.textBox13.Margin = new System.Windows.Forms.Padding(4);
            this.textBox13.Name = "textBox13";
            this.textBox13.Size = new System.Drawing.Size(119, 30);
            this.textBox13.TabIndex = 145;
            // 
            // groupBox13
            // 
            this.groupBox13.BackColor = System.Drawing.Color.WhiteSmoke;
            this.groupBox13.Controls.Add(this.button11);
            this.groupBox13.Controls.Add(this.button1);
            this.groupBox13.Controls.Add(this.label18);
            this.groupBox13.Controls.Add(this.label26);
            this.groupBox13.Controls.Add(this.label62);
            this.groupBox13.Controls.Add(this.label63);
            this.groupBox13.Controls.Add(this.label64);
            this.groupBox13.Controls.Add(this.label69);
            this.groupBox13.Controls.Add(this.label70);
            this.groupBox13.Controls.Add(this.label71);
            this.groupBox13.Controls.Add(this.label65);
            this.groupBox13.Controls.Add(this.label66);
            this.groupBox13.Controls.Add(this.label67);
            this.groupBox13.Controls.Add(this.label73);
            this.groupBox13.Controls.Add(this.label74);
            this.groupBox13.Controls.Add(this.label75);
            this.groupBox13.Controls.Add(this.btnStopLHFeeder);
            this.groupBox13.Controls.Add(this.label68);
            this.groupBox13.Controls.Add(this.label72);
            this.groupBox13.Controls.Add(this.btnHomeLHUnloader);
            this.groupBox13.Controls.Add(this.btnZeroLHUnloader);
            this.groupBox13.Controls.Add(this.btnHomeLHLoader);
            this.groupBox13.Controls.Add(this.btnZeroLHLoader);
            this.groupBox13.Controls.Add(this.label76);
            this.groupBox13.Controls.Add(this.textBox10);
            this.groupBox13.Controls.Add(this.label78);
            this.groupBox13.Controls.Add(this.textBox11);
            this.groupBox13.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox13.Location = new System.Drawing.Point(45, 255);
            this.groupBox13.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox13.Name = "groupBox13";
            this.groupBox13.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox13.Size = new System.Drawing.Size(1204, 234);
            this.groupBox13.TabIndex = 136;
            this.groupBox13.TabStop = false;
            this.groupBox13.Text = "Gantry2 Axis Setting";
            // 
            // button11
            // 
            this.button11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(94)))), ((int)(((byte)(133)))));
            this.button11.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button11.ForeColor = System.Drawing.Color.White;
            this.button11.Location = new System.Drawing.Point(729, 123);
            this.button11.Margin = new System.Windows.Forms.Padding(4);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(243, 43);
            this.button11.TabIndex = 148;
            this.button11.Text = "Set Zero Pos_Y2";
            this.button11.UseVisualStyleBackColor = false;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(94)))), ((int)(((byte)(133)))));
            this.button1.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(480, 73);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(243, 43);
            this.button1.TabIndex = 147;
            this.button1.Text = "Set Home Pos_X3";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Tahoma", 10F);
            this.label18.Location = new System.Drawing.Point(28, 95);
            this.label18.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(133, 21);
            this.label18.TabIndex = 146;
            this.label18.Text = "Y axis Home Pos";
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Font = new System.Drawing.Font("Tahoma", 10F);
            this.label26.Location = new System.Drawing.Point(32, 37);
            this.label26.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(133, 21);
            this.label26.TabIndex = 145;
            this.label26.Text = "X axis Home Pos";
            // 
            // label62
            // 
            this.label62.BackColor = System.Drawing.Color.Maroon;
            this.label62.Location = new System.Drawing.Point(492, 193);
            this.label62.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label62.Name = "label62";
            this.label62.Size = new System.Drawing.Size(35, 32);
            this.label62.TabIndex = 144;
            // 
            // label63
            // 
            this.label63.AutoSize = true;
            this.label63.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label63.Location = new System.Drawing.Point(615, 172);
            this.label63.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label63.Name = "label63";
            this.label63.Size = new System.Drawing.Size(26, 18);
            this.label63.TabIndex = 143;
            this.label63.Text = "EL";
            // 
            // label64
            // 
            this.label64.AutoSize = true;
            this.label64.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label64.Location = new System.Drawing.Point(547, 172);
            this.label64.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label64.Name = "label64";
            this.label64.Size = new System.Drawing.Size(42, 18);
            this.label64.TabIndex = 142;
            this.label64.Text = "ORG";
            // 
            // label69
            // 
            this.label69.AutoSize = true;
            this.label69.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label69.Location = new System.Drawing.Point(497, 172);
            this.label69.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label69.Name = "label69";
            this.label69.Size = new System.Drawing.Size(29, 18);
            this.label69.TabIndex = 141;
            this.label69.Text = "NL";
            // 
            // label70
            // 
            this.label70.BackColor = System.Drawing.Color.Maroon;
            this.label70.Location = new System.Drawing.Point(553, 193);
            this.label70.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label70.Name = "label70";
            this.label70.Size = new System.Drawing.Size(35, 32);
            this.label70.TabIndex = 140;
            // 
            // label71
            // 
            this.label71.BackColor = System.Drawing.Color.Maroon;
            this.label71.Location = new System.Drawing.Point(613, 193);
            this.label71.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label71.Name = "label71";
            this.label71.Size = new System.Drawing.Size(35, 32);
            this.label71.TabIndex = 139;
            // 
            // label65
            // 
            this.label65.BackColor = System.Drawing.Color.Maroon;
            this.label65.Location = new System.Drawing.Point(149, 193);
            this.label65.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label65.Name = "label65";
            this.label65.Size = new System.Drawing.Size(35, 32);
            this.label65.TabIndex = 138;
            // 
            // label66
            // 
            this.label66.AutoSize = true;
            this.label66.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label66.Location = new System.Drawing.Point(273, 172);
            this.label66.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label66.Name = "label66";
            this.label66.Size = new System.Drawing.Size(26, 18);
            this.label66.TabIndex = 137;
            this.label66.Text = "EL";
            // 
            // label67
            // 
            this.label67.AutoSize = true;
            this.label67.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label67.Location = new System.Drawing.Point(204, 172);
            this.label67.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label67.Name = "label67";
            this.label67.Size = new System.Drawing.Size(42, 18);
            this.label67.TabIndex = 136;
            this.label67.Text = "ORG";
            // 
            // label73
            // 
            this.label73.AutoSize = true;
            this.label73.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label73.Location = new System.Drawing.Point(156, 172);
            this.label73.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label73.Name = "label73";
            this.label73.Size = new System.Drawing.Size(29, 18);
            this.label73.TabIndex = 135;
            this.label73.Text = "NL";
            // 
            // label74
            // 
            this.label74.BackColor = System.Drawing.Color.Maroon;
            this.label74.Location = new System.Drawing.Point(211, 193);
            this.label74.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label74.Name = "label74";
            this.label74.Size = new System.Drawing.Size(35, 32);
            this.label74.TabIndex = 134;
            // 
            // label75
            // 
            this.label75.BackColor = System.Drawing.Color.Maroon;
            this.label75.Location = new System.Drawing.Point(271, 193);
            this.label75.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label75.Name = "label75";
            this.label75.Size = new System.Drawing.Size(35, 32);
            this.label75.TabIndex = 133;
            // 
            // btnStopLHFeeder
            // 
            this.btnStopLHFeeder.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(94)))), ((int)(((byte)(133)))));
            this.btnStopLHFeeder.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStopLHFeeder.ForeColor = System.Drawing.Color.White;
            this.btnStopLHFeeder.Location = new System.Drawing.Point(1020, 124);
            this.btnStopLHFeeder.Margin = new System.Windows.Forms.Padding(4);
            this.btnStopLHFeeder.Name = "btnStopLHFeeder";
            this.btnStopLHFeeder.Size = new System.Drawing.Size(147, 43);
            this.btnStopLHFeeder.TabIndex = 100;
            this.btnStopLHFeeder.Text = "Stop";
            this.btnStopLHFeeder.UseVisualStyleBackColor = false;
            // 
            // label68
            // 
            this.label68.AutoSize = true;
            this.label68.Font = new System.Drawing.Font("Tahoma", 10F);
            this.label68.Location = new System.Drawing.Point(351, 201);
            this.label68.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label68.Name = "label68";
            this.label68.Size = new System.Drawing.Size(112, 21);
            this.label68.TabIndex = 120;
            this.label68.Text = "Unloader Axis";
            // 
            // label72
            // 
            this.label72.AutoSize = true;
            this.label72.Font = new System.Drawing.Font("Tahoma", 10F);
            this.label72.Location = new System.Drawing.Point(28, 201);
            this.label72.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label72.Name = "label72";
            this.label72.Size = new System.Drawing.Size(96, 21);
            this.label72.TabIndex = 116;
            this.label72.Text = "Loader Axis";
            // 
            // btnHomeLHUnloader
            // 
            this.btnHomeLHUnloader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(94)))), ((int)(((byte)(133)))));
            this.btnHomeLHUnloader.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHomeLHUnloader.ForeColor = System.Drawing.Color.White;
            this.btnHomeLHUnloader.Location = new System.Drawing.Point(477, 123);
            this.btnHomeLHUnloader.Margin = new System.Windows.Forms.Padding(4);
            this.btnHomeLHUnloader.Name = "btnHomeLHUnloader";
            this.btnHomeLHUnloader.Size = new System.Drawing.Size(243, 43);
            this.btnHomeLHUnloader.TabIndex = 90;
            this.btnHomeLHUnloader.Text = "Set Home Pos_Y2";
            this.btnHomeLHUnloader.UseVisualStyleBackColor = false;
            // 
            // btnZeroLHUnloader
            // 
            this.btnZeroLHUnloader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(94)))), ((int)(((byte)(133)))));
            this.btnZeroLHUnloader.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnZeroLHUnloader.ForeColor = System.Drawing.Color.White;
            this.btnZeroLHUnloader.Location = new System.Drawing.Point(729, 73);
            this.btnZeroLHUnloader.Margin = new System.Windows.Forms.Padding(4);
            this.btnZeroLHUnloader.Name = "btnZeroLHUnloader";
            this.btnZeroLHUnloader.Size = new System.Drawing.Size(243, 43);
            this.btnZeroLHUnloader.TabIndex = 89;
            this.btnZeroLHUnloader.Text = "Set Zero Pos_X3";
            this.btnZeroLHUnloader.UseVisualStyleBackColor = false;
            // 
            // btnHomeLHLoader
            // 
            this.btnHomeLHLoader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(94)))), ((int)(((byte)(133)))));
            this.btnHomeLHLoader.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHomeLHLoader.ForeColor = System.Drawing.Color.White;
            this.btnHomeLHLoader.Location = new System.Drawing.Point(477, 21);
            this.btnHomeLHLoader.Margin = new System.Windows.Forms.Padding(4);
            this.btnHomeLHLoader.Name = "btnHomeLHLoader";
            this.btnHomeLHLoader.Size = new System.Drawing.Size(243, 43);
            this.btnHomeLHLoader.TabIndex = 88;
            this.btnHomeLHLoader.Text = "Set Home Pos_X2";
            this.btnHomeLHLoader.UseVisualStyleBackColor = false;
            // 
            // btnZeroLHLoader
            // 
            this.btnZeroLHLoader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(94)))), ((int)(((byte)(133)))));
            this.btnZeroLHLoader.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnZeroLHLoader.ForeColor = System.Drawing.Color.White;
            this.btnZeroLHLoader.Location = new System.Drawing.Point(728, 21);
            this.btnZeroLHLoader.Margin = new System.Windows.Forms.Padding(4);
            this.btnZeroLHLoader.Name = "btnZeroLHLoader";
            this.btnZeroLHLoader.Size = new System.Drawing.Size(243, 43);
            this.btnZeroLHLoader.TabIndex = 87;
            this.btnZeroLHLoader.Text = "Set Zero Pos_X2";
            this.btnZeroLHLoader.UseVisualStyleBackColor = false;
            // 
            // label76
            // 
            this.label76.AutoSize = true;
            this.label76.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label76.Location = new System.Drawing.Point(339, 96);
            this.label76.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label76.Name = "label76";
            this.label76.Size = new System.Drawing.Size(52, 21);
            this.label76.TabIndex = 86;
            this.label76.Text = "(mm)";
            // 
            // textBox10
            // 
            this.textBox10.Enabled = false;
            this.textBox10.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox10.Location = new System.Drawing.Point(200, 82);
            this.textBox10.Margin = new System.Windows.Forms.Padding(4);
            this.textBox10.Name = "textBox10";
            this.textBox10.Size = new System.Drawing.Size(119, 30);
            this.textBox10.TabIndex = 84;
            // 
            // label78
            // 
            this.label78.AutoSize = true;
            this.label78.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label78.Location = new System.Drawing.Point(339, 39);
            this.label78.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label78.Name = "label78";
            this.label78.Size = new System.Drawing.Size(52, 21);
            this.label78.TabIndex = 83;
            this.label78.Text = "(mm)";
            // 
            // textBox11
            // 
            this.textBox11.Enabled = false;
            this.textBox11.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox11.Location = new System.Drawing.Point(200, 33);
            this.textBox11.Margin = new System.Windows.Forms.Padding(4);
            this.textBox11.Name = "textBox11";
            this.textBox11.Size = new System.Drawing.Size(119, 30);
            this.textBox11.TabIndex = 35;
            // 
            // groupBox14
            // 
            this.groupBox14.BackColor = System.Drawing.Color.WhiteSmoke;
            this.groupBox14.Controls.Add(this.label80);
            this.groupBox14.Controls.Add(this.lblRHhomeSts);
            this.groupBox14.Controls.Add(this.label82);
            this.groupBox14.Controls.Add(this.label83);
            this.groupBox14.Controls.Add(this.btnAllAxesZero);
            this.groupBox14.Controls.Add(this.lblLHhomeSts);
            this.groupBox14.Controls.Add(this.lblXYhomeSts);
            this.groupBox14.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox14.Location = new System.Drawing.Point(1379, 245);
            this.groupBox14.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox14.Name = "groupBox14";
            this.groupBox14.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox14.Size = new System.Drawing.Size(315, 347);
            this.groupBox14.TabIndex = 135;
            this.groupBox14.TabStop = false;
            this.groupBox14.Text = "Homing Status";
            // 
            // label80
            // 
            this.label80.AutoSize = true;
            this.label80.Font = new System.Drawing.Font("Tahoma", 10F);
            this.label80.Location = new System.Drawing.Point(35, 276);
            this.label80.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label80.Name = "label80";
            this.label80.Size = new System.Drawing.Size(89, 21);
            this.label80.TabIndex = 140;
            this.label80.Text = "Feeder Sts";
            // 
            // lblRHhomeSts
            // 
            this.lblRHhomeSts.BackColor = System.Drawing.Color.Maroon;
            this.lblRHhomeSts.Location = new System.Drawing.Point(247, 268);
            this.lblRHhomeSts.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblRHhomeSts.Name = "lblRHhomeSts";
            this.lblRHhomeSts.Size = new System.Drawing.Size(35, 32);
            this.lblRHhomeSts.TabIndex = 139;
            // 
            // label82
            // 
            this.label82.AutoSize = true;
            this.label82.Font = new System.Drawing.Font("Tahoma", 10F);
            this.label82.Location = new System.Drawing.Point(35, 214);
            this.label82.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label82.Name = "label82";
            this.label82.Size = new System.Drawing.Size(157, 21);
            this.label82.TabIndex = 138;
            this.label82.Text = "Gantry2 Homing Sts";
            // 
            // label83
            // 
            this.label83.AutoSize = true;
            this.label83.Font = new System.Drawing.Font("Tahoma", 10F);
            this.label83.Location = new System.Drawing.Point(35, 154);
            this.label83.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label83.Name = "label83";
            this.label83.Size = new System.Drawing.Size(157, 21);
            this.label83.TabIndex = 133;
            this.label83.Text = "Gantry1 Homing Sts";
            // 
            // btnAllAxesZero
            // 
            this.btnAllAxesZero.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(94)))), ((int)(((byte)(133)))));
            this.btnAllAxesZero.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAllAxesZero.ForeColor = System.Drawing.Color.White;
            this.btnAllAxesZero.Location = new System.Drawing.Point(19, 68);
            this.btnAllAxesZero.Margin = new System.Windows.Forms.Padding(4);
            this.btnAllAxesZero.Name = "btnAllAxesZero";
            this.btnAllAxesZero.Size = new System.Drawing.Size(273, 43);
            this.btnAllAxesZero.TabIndex = 101;
            this.btnAllAxesZero.Text = "Initialize all Axes";
            this.btnAllAxesZero.UseVisualStyleBackColor = false;
            // 
            // lblLHhomeSts
            // 
            this.lblLHhomeSts.BackColor = System.Drawing.Color.Maroon;
            this.lblLHhomeSts.Location = new System.Drawing.Point(247, 207);
            this.lblLHhomeSts.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblLHhomeSts.Name = "lblLHhomeSts";
            this.lblLHhomeSts.Size = new System.Drawing.Size(35, 32);
            this.lblLHhomeSts.TabIndex = 134;
            // 
            // lblXYhomeSts
            // 
            this.lblXYhomeSts.BackColor = System.Drawing.Color.Maroon;
            this.lblXYhomeSts.Location = new System.Drawing.Point(247, 146);
            this.lblXYhomeSts.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblXYhomeSts.Name = "lblXYhomeSts";
            this.lblXYhomeSts.Size = new System.Drawing.Size(35, 32);
            this.lblXYhomeSts.TabIndex = 133;
            // 
            // groupBox15
            // 
            this.groupBox15.BackColor = System.Drawing.Color.WhiteSmoke;
            this.groupBox15.Controls.Add(this.btnZeroZ);
            this.groupBox15.Controls.Add(this.lblMinX);
            this.groupBox15.Controls.Add(this.btnStopGantry);
            this.groupBox15.Controls.Add(this.label84);
            this.groupBox15.Controls.Add(this.label85);
            this.groupBox15.Controls.Add(this.label86);
            this.groupBox15.Controls.Add(this.label87);
            this.groupBox15.Controls.Add(this.label88);
            this.groupBox15.Controls.Add(this.label89);
            this.groupBox15.Controls.Add(this.label92);
            this.groupBox15.Controls.Add(this.lblOrgY);
            this.groupBox15.Controls.Add(this.lblMaxY);
            this.groupBox15.Controls.Add(this.lblMinY);
            this.groupBox15.Controls.Add(this.label93);
            this.groupBox15.Controls.Add(this.lblOrgX);
            this.groupBox15.Controls.Add(this.btnHomeY);
            this.groupBox15.Controls.Add(this.lblMaxX);
            this.groupBox15.Controls.Add(this.btnZeroY);
            this.groupBox15.Controls.Add(this.btnHomeX);
            this.groupBox15.Controls.Add(this.btnZeroX);
            this.groupBox15.Controls.Add(this.label94);
            this.groupBox15.Controls.Add(this.label95);
            this.groupBox15.Controls.Add(this.txtYhme);
            this.groupBox15.Controls.Add(this.label96);
            this.groupBox15.Controls.Add(this.label97);
            this.groupBox15.Controls.Add(this.txtXhme);
            this.groupBox15.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox15.Location = new System.Drawing.Point(45, 49);
            this.groupBox15.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox15.Name = "groupBox15";
            this.groupBox15.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox15.Size = new System.Drawing.Size(1204, 198);
            this.groupBox15.TabIndex = 134;
            this.groupBox15.TabStop = false;
            this.groupBox15.Text = "Gantry1 Axis Setting";
            // 
            // btnZeroZ
            // 
            this.btnZeroZ.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(94)))), ((int)(((byte)(133)))));
            this.btnZeroZ.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnZeroZ.ForeColor = System.Drawing.Color.White;
            this.btnZeroZ.Location = new System.Drawing.Point(731, 129);
            this.btnZeroZ.Margin = new System.Windows.Forms.Padding(4);
            this.btnZeroZ.Name = "btnZeroZ";
            this.btnZeroZ.Size = new System.Drawing.Size(204, 43);
            this.btnZeroZ.TabIndex = 133;
            this.btnZeroZ.Text = "Set Zero Pos_Z1";
            this.btnZeroZ.UseVisualStyleBackColor = false;
            // 
            // lblMinX
            // 
            this.lblMinX.BackColor = System.Drawing.Color.Maroon;
            this.lblMinX.Location = new System.Drawing.Point(135, 159);
            this.lblMinX.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMinX.Name = "lblMinX";
            this.lblMinX.Size = new System.Drawing.Size(35, 32);
            this.lblMinX.TabIndex = 132;
            // 
            // btnStopGantry
            // 
            this.btnStopGantry.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(94)))), ((int)(((byte)(133)))));
            this.btnStopGantry.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStopGantry.ForeColor = System.Drawing.Color.White;
            this.btnStopGantry.Location = new System.Drawing.Point(1020, 130);
            this.btnStopGantry.Margin = new System.Windows.Forms.Padding(4);
            this.btnStopGantry.Name = "btnStopGantry";
            this.btnStopGantry.Size = new System.Drawing.Size(147, 43);
            this.btnStopGantry.TabIndex = 100;
            this.btnStopGantry.Text = "Stop";
            this.btnStopGantry.UseVisualStyleBackColor = false;
            // 
            // label84
            // 
            this.label84.AutoSize = true;
            this.label84.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label84.Location = new System.Drawing.Point(573, 138);
            this.label84.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label84.Name = "label84";
            this.label84.Size = new System.Drawing.Size(26, 18);
            this.label84.TabIndex = 129;
            this.label84.Text = "EL";
            // 
            // label85
            // 
            this.label85.AutoSize = true;
            this.label85.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label85.Location = new System.Drawing.Point(503, 138);
            this.label85.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label85.Name = "label85";
            this.label85.Size = new System.Drawing.Size(42, 18);
            this.label85.TabIndex = 128;
            this.label85.Text = "ORG";
            // 
            // label86
            // 
            this.label86.AutoSize = true;
            this.label86.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label86.Location = new System.Drawing.Point(455, 138);
            this.label86.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label86.Name = "label86";
            this.label86.Size = new System.Drawing.Size(29, 18);
            this.label86.TabIndex = 127;
            this.label86.Text = "NL";
            // 
            // label87
            // 
            this.label87.AutoSize = true;
            this.label87.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label87.Location = new System.Drawing.Point(256, 138);
            this.label87.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label87.Name = "label87";
            this.label87.Size = new System.Drawing.Size(26, 18);
            this.label87.TabIndex = 126;
            this.label87.Text = "EL";
            // 
            // label88
            // 
            this.label88.AutoSize = true;
            this.label88.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label88.Location = new System.Drawing.Point(185, 138);
            this.label88.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label88.Name = "label88";
            this.label88.Size = new System.Drawing.Size(42, 18);
            this.label88.TabIndex = 125;
            this.label88.Text = "ORG";
            // 
            // label89
            // 
            this.label89.AutoSize = true;
            this.label89.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label89.Location = new System.Drawing.Point(140, 138);
            this.label89.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label89.Name = "label89";
            this.label89.Size = new System.Drawing.Size(29, 18);
            this.label89.TabIndex = 124;
            this.label89.Text = "NL";
            // 
            // label92
            // 
            this.label92.AutoSize = true;
            this.label92.Font = new System.Drawing.Font("Tahoma", 10F);
            this.label92.Location = new System.Drawing.Point(351, 159);
            this.label92.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label92.Name = "label92";
            this.label92.Size = new System.Drawing.Size(56, 21);
            this.label92.TabIndex = 120;
            this.label92.Text = "Y Axis";
            // 
            // lblOrgY
            // 
            this.lblOrgY.BackColor = System.Drawing.Color.Maroon;
            this.lblOrgY.Location = new System.Drawing.Point(507, 159);
            this.lblOrgY.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblOrgY.Name = "lblOrgY";
            this.lblOrgY.Size = new System.Drawing.Size(35, 32);
            this.lblOrgY.TabIndex = 123;
            // 
            // lblMaxY
            // 
            this.lblMaxY.BackColor = System.Drawing.Color.Maroon;
            this.lblMaxY.Location = new System.Drawing.Point(565, 159);
            this.lblMaxY.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMaxY.Name = "lblMaxY";
            this.lblMaxY.Size = new System.Drawing.Size(35, 32);
            this.lblMaxY.TabIndex = 122;
            // 
            // lblMinY
            // 
            this.lblMinY.BackColor = System.Drawing.Color.Maroon;
            this.lblMinY.Location = new System.Drawing.Point(448, 159);
            this.lblMinY.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMinY.Name = "lblMinY";
            this.lblMinY.Size = new System.Drawing.Size(35, 32);
            this.lblMinY.TabIndex = 121;
            // 
            // label93
            // 
            this.label93.AutoSize = true;
            this.label93.Font = new System.Drawing.Font("Tahoma", 10F);
            this.label93.Location = new System.Drawing.Point(32, 159);
            this.label93.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label93.Name = "label93";
            this.label93.Size = new System.Drawing.Size(56, 21);
            this.label93.TabIndex = 116;
            this.label93.Text = "X Axis";
            // 
            // lblOrgX
            // 
            this.lblOrgX.BackColor = System.Drawing.Color.Maroon;
            this.lblOrgX.Location = new System.Drawing.Point(195, 159);
            this.lblOrgX.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblOrgX.Name = "lblOrgX";
            this.lblOrgX.Size = new System.Drawing.Size(35, 32);
            this.lblOrgX.TabIndex = 119;
            // 
            // btnHomeY
            // 
            this.btnHomeY.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(94)))), ((int)(((byte)(133)))));
            this.btnHomeY.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHomeY.ForeColor = System.Drawing.Color.White;
            this.btnHomeY.Location = new System.Drawing.Point(477, 81);
            this.btnHomeY.Margin = new System.Windows.Forms.Padding(4);
            this.btnHomeY.Name = "btnHomeY";
            this.btnHomeY.Size = new System.Drawing.Size(209, 43);
            this.btnHomeY.TabIndex = 90;
            this.btnHomeY.Text = "Set Home Pos_Y1";
            this.btnHomeY.UseVisualStyleBackColor = false;
            // 
            // lblMaxX
            // 
            this.lblMaxX.BackColor = System.Drawing.Color.Maroon;
            this.lblMaxX.Location = new System.Drawing.Point(255, 159);
            this.lblMaxX.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMaxX.Name = "lblMaxX";
            this.lblMaxX.Size = new System.Drawing.Size(35, 32);
            this.lblMaxX.TabIndex = 118;
            // 
            // btnZeroY
            // 
            this.btnZeroY.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(94)))), ((int)(((byte)(133)))));
            this.btnZeroY.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnZeroY.ForeColor = System.Drawing.Color.White;
            this.btnZeroY.Location = new System.Drawing.Point(729, 76);
            this.btnZeroY.Margin = new System.Windows.Forms.Padding(4);
            this.btnZeroY.Name = "btnZeroY";
            this.btnZeroY.Size = new System.Drawing.Size(204, 43);
            this.btnZeroY.TabIndex = 89;
            this.btnZeroY.Text = "Set Zero Pos_Y1";
            this.btnZeroY.UseVisualStyleBackColor = false;
            // 
            // btnHomeX
            // 
            this.btnHomeX.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(94)))), ((int)(((byte)(133)))));
            this.btnHomeX.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHomeX.ForeColor = System.Drawing.Color.White;
            this.btnHomeX.Location = new System.Drawing.Point(477, 23);
            this.btnHomeX.Margin = new System.Windows.Forms.Padding(4);
            this.btnHomeX.Name = "btnHomeX";
            this.btnHomeX.Size = new System.Drawing.Size(209, 43);
            this.btnHomeX.TabIndex = 88;
            this.btnHomeX.Text = "Set Home Pos_X1";
            this.btnHomeX.UseVisualStyleBackColor = false;
            // 
            // btnZeroX
            // 
            this.btnZeroX.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(94)))), ((int)(((byte)(133)))));
            this.btnZeroX.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnZeroX.ForeColor = System.Drawing.Color.White;
            this.btnZeroX.Location = new System.Drawing.Point(728, 22);
            this.btnZeroX.Margin = new System.Windows.Forms.Padding(4);
            this.btnZeroX.Name = "btnZeroX";
            this.btnZeroX.Size = new System.Drawing.Size(204, 43);
            this.btnZeroX.TabIndex = 87;
            this.btnZeroX.Text = "Set Zero Pos_X1";
            this.btnZeroX.UseVisualStyleBackColor = false;
            // 
            // label94
            // 
            this.label94.AutoSize = true;
            this.label94.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label94.Location = new System.Drawing.Point(339, 103);
            this.label94.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label94.Name = "label94";
            this.label94.Size = new System.Drawing.Size(46, 18);
            this.label94.TabIndex = 86;
            this.label94.Text = "(mm)";
            // 
            // label95
            // 
            this.label95.AutoSize = true;
            this.label95.Font = new System.Drawing.Font("Tahoma", 10F);
            this.label95.Location = new System.Drawing.Point(28, 98);
            this.label95.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label95.Name = "label95";
            this.label95.Size = new System.Drawing.Size(133, 21);
            this.label95.TabIndex = 85;
            this.label95.Text = "Y axis Home Pos";
            // 
            // txtYhme
            // 
            this.txtYhme.Enabled = false;
            this.txtYhme.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtYhme.Location = new System.Drawing.Point(200, 90);
            this.txtYhme.Margin = new System.Windows.Forms.Padding(4);
            this.txtYhme.Name = "txtYhme";
            this.txtYhme.Size = new System.Drawing.Size(119, 30);
            this.txtYhme.TabIndex = 84;
            // 
            // label96
            // 
            this.label96.AutoSize = true;
            this.label96.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label96.Location = new System.Drawing.Point(339, 38);
            this.label96.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label96.Name = "label96";
            this.label96.Size = new System.Drawing.Size(46, 18);
            this.label96.TabIndex = 83;
            this.label96.Text = "(mm)";
            // 
            // label97
            // 
            this.label97.AutoSize = true;
            this.label97.Font = new System.Drawing.Font("Tahoma", 10F);
            this.label97.Location = new System.Drawing.Point(32, 41);
            this.label97.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label97.Name = "label97";
            this.label97.Size = new System.Drawing.Size(133, 21);
            this.label97.TabIndex = 82;
            this.label97.Text = "X axis Home Pos";
            // 
            // txtXhme
            // 
            this.txtXhme.Enabled = false;
            this.txtXhme.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtXhme.Location = new System.Drawing.Point(200, 32);
            this.txtXhme.Margin = new System.Windows.Forms.Padding(4);
            this.txtXhme.Name = "txtXhme";
            this.txtXhme.Size = new System.Drawing.Size(119, 30);
            this.txtXhme.TabIndex = 35;
            // 
            // label98
            // 
            this.label98.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label98.AutoSize = true;
            this.label98.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold);
            this.label98.Location = new System.Drawing.Point(444, 11);
            this.label98.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label98.Name = "label98";
            this.label98.Size = new System.Drawing.Size(481, 25);
            this.label98.TabIndex = 133;
            this.label98.Text = "AXIS ZERO SETTING AND HOME SETTING";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Add,
            this.Delete});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(123, 52);
            // 
            // Add
            // 
            this.Add.Name = "Add";
            this.Add.Size = new System.Drawing.Size(122, 24);
            this.Add.Text = "Add";
            this.Add.Click += new System.EventHandler(this.Add_Click_1);
            // 
            // Delete
            // 
            this.Delete.Name = "Delete";
            this.Delete.Size = new System.Drawing.Size(122, 24);
            this.Delete.Text = "Delete";
            this.Delete.Click += new System.EventHandler(this.Delete_Click);
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1365, 763);
            this.Controls.Add(this.tabControlSettings);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Settings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Settings";
            this.Load += new System.EventHandler(this.Settings_Load);
            this.tabControlSettings.ResumeLayout(false);
            this.General.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.pnlShiftSettings.ResumeLayout(false);
            this.grpShiftSettings.ResumeLayout(false);
            this.grpShiftSettings.PerformLayout();
            this.pnlGeneral.ResumeLayout(false);
            this.pnlSupport.ResumeLayout(false);
            this.pnlSupport.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.pnlInfo.ResumeLayout(false);
            this.pnlInfo.PerformLayout();
            this.Device.ResumeLayout(false);
            this.DeviceSettingsPanel.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.grpDeviceIP.ResumeLayout(false);
            this.grpDeviceIP.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.IP_Details_table)).EndInit();
            this.grpSystemSettings.ResumeLayout(false);
            this.ConnectChk.ResumeLayout(false);
            this.tabConnectionCheck.ResumeLayout(false);
            this.tabPage6.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.grpRoboConn.ResumeLayout(false);
            this.grpRoboConn.PerformLayout();
            this.tabPage7.ResumeLayout(false);
            this.grpCCDConn.ResumeLayout(false);
            this.grpCCDConn.PerformLayout();
            this.tabPage8.ResumeLayout(false);
            this.grpScanner.ResumeLayout(false);
            this.grpScanner.PerformLayout();
            this.tabPage9.ResumeLayout(false);
            this.grpAtlas.ResumeLayout(false);
            this.grpAtlas.PerformLayout();
            this.IODiagnostics.ResumeLayout(false);
            this.tabIO.ResumeLayout(false);
            this.btn_input.ResumeLayout(false);
            this.btn_output.ResumeLayout(false);
            this.IOPanel.ResumeLayout(false);
            this.Calibration.ResumeLayout(false);
            this.CaliberationPanel.ResumeLayout(false);
            this.tabCalib.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.grpLoadcell.ResumeLayout(false);
            this.grpLoadcell.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.grpCameraCalib.ResumeLayout(false);
            this.grpCameraCalib.PerformLayout();
            this.grpboxCamera.ResumeLayout(false);
            this.grpboxCamera.PerformLayout();
            this.grpCameraConn.ResumeLayout(false);
            this.grpCameraConn.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.tabPage5.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.MotorDebug.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.grbMotor.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Axis_Config)).EndInit();
            this.SOP.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.grpBoxCCD1.ResumeLayout(false);
            this.grpBoxCCD1.PerformLayout();
            this.groupBox18.ResumeLayout(false);
            this.groupBox18.PerformLayout();
            this.AxisZeroSetting.ResumeLayout(false);
            this.panel9.ResumeLayout(false);
            this.panel9.PerformLayout();
            this.groupBox16.ResumeLayout(false);
            this.groupBox16.PerformLayout();
            this.groupBox13.ResumeLayout(false);
            this.groupBox13.PerformLayout();
            this.groupBox14.ResumeLayout(false);
            this.groupBox14.PerformLayout();
            this.groupBox15.ResumeLayout(false);
            this.groupBox15.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControlSettings;
        private System.Windows.Forms.TabPage General;
        private System.Windows.Forms.TabPage ConnectChk;
        private System.Windows.Forms.TabPage Device;
        private System.Windows.Forms.TabPage IODiagnostics;
        private System.Windows.Forms.TabControl tabIO;
        private System.Windows.Forms.TabPage btn_input;
        private System.Windows.Forms.TabPage btn_output;
        private System.Windows.Forms.TabPage Calibration;
        private System.Windows.Forms.TabPage MotorDebug;
        private System.Windows.Forms.TabPage SOP;
        private System.Windows.Forms.TabPage AxisZeroSetting;
        private Panel IOPanel;
        private Panel CaliberationPanel;
        private Panel panel2;
        private Panel panel3;
        private Panel panel9;
        private GroupBox groupBox16;
        private Label label99;
        private Label label100;
        private Label label101;
        private Label label102;
        private Label label103;
        private Label label104;
        private Label label105;
        private Label label106;
        private Label label107;
        private Label label108;
        private Label label109;
        private Label label110;
        private Button btnStopRHFeeder;
        private Label label111;
        private Label label112;
        private Button btnHomeRHUnloader;
        private Button btnZeroRHUnloader;
        private Button btnHomeRHLoader;
        private Button btnZeroRHLoader;
        private Label label113;
        private Label label114;
        private TextBox textBox12;
        private Label label115;
        private Label label116;
        private TextBox textBox13;
        private GroupBox groupBox13;
        private Button button11;
        private Button button1;
        private Label label18;
        private Label label26;
        private Label label62;
        private Label label63;
        private Label label64;
        private Label label69;
        private Label label70;
        private Label label71;
        private Label label65;
        private Label label66;
        private Label label67;
        private Label label73;
        private Label label74;
        private Label label75;
        private Button btnStopLHFeeder;
        private Label label68;
        private Label label72;
        private Button btnHomeLHUnloader;
        private Button btnZeroLHUnloader;
        private Button btnHomeLHLoader;
        private Button btnZeroLHLoader;
        private Label label76;
        private TextBox textBox10;
        private Label label78;
        private TextBox textBox11;
        private GroupBox groupBox14;
        private Label label80;
        private Label lblRHhomeSts;
        private Label label82;
        private Label label83;
        private Button btnAllAxesZero;
        private Label lblLHhomeSts;
        private Label lblXYhomeSts;
        private GroupBox groupBox15;
        private Button btnZeroZ;
        private Label lblMinX;
        private Button btnStopGantry;
        private Label label84;
        private Label label85;
        private Label label86;
        private Label label87;
        private Label label88;
        private Label label89;
        private Label label92;
        private Label lblOrgY;
        private Label lblMaxY;
        private Label lblMinY;
        private Label label93;
        private Label lblOrgX;
        private Button btnHomeY;
        private Label lblMaxX;
        private Button btnZeroY;
        private Button btnHomeX;
        private Button btnZeroX;
        private Label label94;
        private Label label95;
        private TextBox txtYhme;
        private Label label96;
        private Label label97;
        private TextBox txtXhme;
        private Label label98;
        private TabControl tabCalib;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private TabPage tabPage3;
        private TabPage tabPage4;
        private TabPage tabPage5;
        private TabControl tabConnectionCheck;
        private TabPage tabPage6;
        private Panel panel1;
        private GroupBox grpRoboConn;
        private Button btnDisConnect;
        private Label lblCmd;
        private ComboBox cmbRBTmodeselect;
        private Button btnRBTselectCMD;
        private Label lblrobotconnstatus;
        private Label lblConnStatus;
        private Button btnconnect;
        public RichTextBox txtsendrobotcommand;
        public RichTextBox txtreceivecommnd;
        private Label label374;
        private Button btnRBTtrigger;
        private Label label376;
        private TabPage tabPage7;
        private TabPage tabPage8;
        private TabPage tabPage9;
        private GroupBox grpCCDConn;
        private Label lblSelectCCD;
        private ComboBox cmbCCD;
        private Label lblCCDConnStatus;
        private Button btnCCDConnect;
        public RichTextBox txtSendCmd;
        public RichTextBox txtRecivdCmd;
        private Label label372;
        private Button btnCCDTrigger;
        private Label lblCCDConn;
        private Label label378;
        private GroupBox grpScanner;
        private Label lblScanrConStatus;
        private Button btnScannerConnect;
        public RichTextBox txtScannerSend;
        public RichTextBox txtScannerRecieve;
        private Label label380;
        private Button btnScannerTrigger;
        private Label lblScannerConn;
        private Label label382;
        private GroupBox grpAtlas;
        private RadioButton rdoAtlas2;
        private RadioButton rdoAtlas1;
        private TextBox txtReceiveMsg;
        private Label label31;
        private Button ClearReceiveMsg;
        private Label label37;
        private TextBox txtSendMsg;
        private TabPage tabPage10;
        private TabPage tabPage11;
        private GroupBox grbMotor;
        private DataGridView Axis_Config;
        private Button btnSave;
        private Button btnedit;
        private Panel panel5;
        private Panel pnlGeneral;
        private Panel pnlSupport;
        private Label label39;
        private Label label11;
        private Label label38;
        private Label label12;
        private Label label13;
        private Label label14;
        private Label label17;
        private Panel pnlInfo;
        private Label lblSwUpdated;
        private Label lblBuildDate;
        private Label lblSWRev;
        private Label label22;
        private Label lblLifecycle;
        private Label lblRejection;
        private GroupBox grpLoadcell;
        private Button btnLoadCellStop;
        private Label lblCalibSelect;
        private Button btnLoadCellStart;
        private ComboBox cmbLoadcellMode;
        private GroupBox grpCameraCalib;
        private GroupBox grpboxCamera;
        private CheckBox chkCCD5;
        private CheckBox chkCCD4;
        private CheckBox chkCCD3;
        private CheckBox chkCCD1;
        private RichTextBox richTextBox_Calib;
        private Label lblCameraConn;
        private Label lblCamConnStatus;
        private Label label54;
        private Label label55;
        private Button btnCamera_Stop;
        private TextBox txtRunningStep;
        private Button btnCamera_Start;
        private GroupBox grpCameraConn;
        private Button btnCalTrigger;
        private Button btnCalConnect;
        private Label lblCameraConnectionSts;
        private Label lblCameraCon;
        private Label lblRcvData;
        public RichTextBox txtRecieveData;
        private Label lblTriggerDelayTime;
        public TextBox textDelay;
        private Label lblTriggercmd;
        private ComboBox cmbTriggerCmd;
        private GroupBox groupBox8;
        private ComboBox comboScanner;
        private Label label61;
        private TextBox Scanner_Delay_textBox;
        private Button btn_Cali_Scan_Connect;
        private Label Scanner_Consts;
        private Label label49;
        private Label label51;
        public RichTextBox RecieveData_Scanner;
        private Label label52;
        private Button btn_Cali_Scan_Trigger;
        private GroupBox groupBox7;
        private Button btn_Cali_Rob_Connect;
        private Button btn_Cali_Rob_Trigger;
        private Label label44;
        private Label label45;
        private Label label46;
        public RichTextBox RecieveDataRobo;
        private Label label47;
        public TextBox Robo_textBox;
        private Label label48;
        private ComboBox cmbRoboTrigger;
        private GroupBox groupBox6;
        private Label label32;
        private Button btnCalibRun;
        private ComboBox txtvisioncalib;
        private PictureBox pictureBox2;
        private Panel pnlShiftSettings;
        private GroupBox grpShiftSettings;
        private ComboBox cmbShift;
        private Label lblShift;
        private Label lblEndTime;
        private DateTimePicker dtpEndTime;
        private Label lblStartTime;
        private DateTimePicker dtpStartTime;
        private Button btnEditGeneral;
        private Button btnSaveGeneral;
        private GroupBox grpBoxCCD1;
        private ComboBox cmbTestMode;
        private Label label1;
        private Label label36;
        private Label label2;
        private Label label129;
        public TextBox txtstaticposccd1_y;
        public TextBox txtstaticposccd1_x;
        private Label label3;
        private Button btnccd1Browse;
        private TextBox txtccd1path;
        private Label lblactualpos_ccd1_y;
        private Label lblactualpos_ccd1_x;
        private Label label4;
        private Label label41;
        private Label label42;
        private Label label43;
        private Button btnCCD_start;
        private Button btnCCD_stop;
        private TextBox txtCounts;
        private Label label50;
        private TextBox txtspeed;
        private Label label77;
        private TextBox txtposition_y2;
        private TextBox txtstaticposccd1_z;
        private TextBox txtposition_Z2;
        private TextBox txtpositionz1;
        private TextBox txtposition_y1;
        private Label label5;
        private Label label79;
        private Label label90;
        private TextBox txtposition_x2;
        private Label label91;
        private TextBox txtposition_x1;
        private Label label117;
        private Label lblRunningCount;
        private Label label118;
        private Label label119;
        private GroupBox groupBox18;
        private ComboBox cmbCamera;
        private Label label40;
        private Label label10;
        private Label label9;
        private Label label8;
        private Label label7;
        private Label label6;
        private Label lblBuildDateVal;
        private Label lblTotalRejectVal;
        private Label lblTotalLifeCycleVal;
        private Label lblSWRevVal;
        private Label lbSWUpdateVal;
        private FBI_D57.InputState inputState1;
        private FBI_D57.OutputState outputState1;
        private Panel DeviceSettingsPanel;
        private GroupBox groupBox1;
        private CheckBox SFC_PDCA_Bypass;
        private CheckBox Buzzer_Bypass;
        private CheckBox Safety_door_bypass;
        private CheckBox Barcode_scanner_bypass;
        private Panel panel4;
        private GroupBox grpDeviceIP;
        private DataGridView IP_Details_table;
        private Label label15;
        private Label label19;
        private Label label16;
        private Label label27;
        private Label label25;
        private Label label24;
        private Label label23;
        private Label label20;
        private Label lblRobot;
        private Label label21;
        private Label lblPDCA;
        private Label lblSFC;
        private Label label28;
        private Label lblScanner;
        private Label label29;
        private Label lblCCD4;
        private Label lblCCD3;
        private Label lblcam2;
        private Label lblCam1;
        private Label lblCCD4IP;
        private Label lblRoboIP;
        private Label lblCCD3IP;
        private Label lblCCD2IP;
        private Label lblPDCAIP;
        private Label lblSFCIP;
        private Label lblScannerIP;
        private Label lblCCD1IP;
        private LinkLabel linkLabel1;
        private GroupBox grpSystemSettings;
        private RadioButton radioButtonDynamic;
        private RadioButton radioButtonStatic;
        private RadioButton radioButtongrr;
        private RadioButton radioButtoncpk;
        private RadioButton radioButtondry;
        private RadioButton radioButtonProd;
        private Button btnEditSettings;
        private Button btnSaveSettings;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem Add;
        private ToolStripMenuItem Delete;
    }

 
}