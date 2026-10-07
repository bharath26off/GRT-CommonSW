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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.Calibration = new System.Windows.Forms.TabPage();
            this.CaliberationPanel = new System.Windows.Forms.Panel();
            this.tabCalib = new System.Windows.Forms.TabControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.grpCameraCalib = new System.Windows.Forms.GroupBox();
            this.lbl_z2 = new System.Windows.Forms.Label();
            this.txtposition_R = new System.Windows.Forms.TextBox();
            this.lbl_z1 = new System.Windows.Forms.Label();
            this.txtposition_Z1 = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.grpboxCamera = new System.Windows.Forms.GroupBox();
            this.checkCCD1 = new System.Windows.Forms.CheckBox();
            this.checkCCD4 = new System.Windows.Forms.CheckBox();
            this.checkCCD3 = new System.Windows.Forms.CheckBox();
            this.checkCCD2 = new System.Windows.Forms.CheckBox();
            this.label16 = new System.Windows.Forms.Label();
            this.lblStaticUnit = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label129 = new System.Windows.Forms.Label();
            this.txtstaticposccd1_y = new System.Windows.Forms.TextBox();
            this.txtstaticposccd1_x = new System.Windows.Forms.TextBox();
            this.lblStaticPos = new System.Windows.Forms.Label();
            this.btnccd1Browse = new System.Windows.Forms.Button();
            this.txtccd1path = new System.Windows.Forms.TextBox();
            this.label43 = new System.Windows.Forms.Label();
            this.txtCounts = new System.Windows.Forms.TextBox();
            this.label50 = new System.Windows.Forms.Label();
            this.txtspeed = new System.Windows.Forms.TextBox();
            this.label77 = new System.Windows.Forms.Label();
            this.txtposition_y2 = new System.Windows.Forms.TextBox();
            this.txtposition_y1 = new System.Windows.Forms.TextBox();
            this.label79 = new System.Windows.Forms.Label();
            this.label90 = new System.Windows.Forms.Label();
            this.txtposition_x2 = new System.Windows.Forms.TextBox();
            this.lblDynamicpos2 = new System.Windows.Forms.Label();
            this.txtposition_x1 = new System.Windows.Forms.TextBox();
            this.lblDynamicPos1 = new System.Windows.Forms.Label();
            this.lblRunningCount = new System.Windows.Forms.Label();
            this.label118 = new System.Windows.Forms.Label();
            this.txtTestMode = new System.Windows.Forms.TextBox();
            this.label119 = new System.Windows.Forms.Label();
            this.btnCamera_Stop = new System.Windows.Forms.Button();
            this.btnCamera_Start = new System.Windows.Forms.Button();
            this.tabPage7 = new System.Windows.Forms.TabPage();
            this.grpGantry2 = new System.Windows.Forms.GroupBox();
            this.txt_PrfPos_Z1 = new System.Windows.Forms.TextBox();
            this.lblZ_Position = new System.Windows.Forms.Label();
            this.btnZ1Add = new System.Windows.Forms.Button();
            this.btnR2Add = new System.Windows.Forms.Button();
            this.btnR2Dec = new System.Windows.Forms.Button();
            this.btnZ1Dec = new System.Windows.Forms.Button();
            this.txt_PrfPos_Z2 = new System.Windows.Forms.TextBox();
            this.txt_PrfPos_R2 = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.btnR1Add = new System.Windows.Forms.Button();
            this.txt_PrfPos_R1 = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.btnR1Dec = new System.Windows.Forms.Button();
            this.btnZ2Dec = new System.Windows.Forms.Button();
            this.btnZ2Add = new System.Windows.Forms.Button();
            this.grpGantry = new System.Windows.Forms.GroupBox();
            this.lblY_Position = new System.Windows.Forms.Label();
            this.txt_PrfPos_Y1 = new System.Windows.Forms.TextBox();
            this.btnXAdd = new System.Windows.Forms.Button();
            this.btnYDec = new System.Windows.Forms.Button();
            this.btnYAdd = new System.Windows.Forms.Button();
            this.btnXDec = new System.Windows.Forms.Button();
            this.lblX_Position = new System.Windows.Forms.Label();
            this.txt_PrfPos_X1 = new System.Windows.Forms.TextBox();
            this.grpMoveAbsolute = new System.Windows.Forms.GroupBox();
            this.btnMoveAbs = new System.Windows.Forms.Button();
            this.lblServoX_TargetSpeed = new System.Windows.Forms.Label();
            this.txtetSpeedAbs = new System.Windows.Forms.TextBox();
            this.lblMoveAbsSpeed = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbMoveMode = new System.Windows.Forms.ComboBox();
            this.cmbAxisMoveAbs = new System.Windows.Forms.ComboBox();
            this.lblMoveAbsSelectAxis = new System.Windows.Forms.Label();
            this.btnStop = new System.Windows.Forms.Button();
            this.lblServoX_TargetPosition = new System.Windows.Forms.Label();
            this.txtPositionAbs = new System.Windows.Forms.TextBox();
            this.lblMoveAbsPos = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtdistance = new System.Windows.Forms.TextBox();
            this.btn_stop = new System.Windows.Forms.Button();
            this.btn_start = new System.Windows.Forms.Button();
            this.grp_EditSave = new System.Windows.Forms.GroupBox();
            this.btn_save = new System.Windows.Forms.Button();
            this.btn_edit = new System.Windows.Forms.Button();
            this.lblSave = new System.Windows.Forms.Label();
            this.lblEdit = new System.Windows.Forms.Label();
            this.dgv_Nozzle = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.moveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.teachToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cmb_Nozzle = new System.Windows.Forms.ComboBox();
            this.lbl_Nozzle = new System.Windows.Forms.Label();
            this.tabRepeatability = new System.Windows.Forms.TabPage();
            this.grpScan = new System.Windows.Forms.GroupBox();
            this.lblchoosescanner = new System.Windows.Forms.Label();
            this.lblRuncountTimeVal = new System.Windows.Forms.Label();
            this.button5 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.lblRunningRepeatabilityCount = new System.Windows.Forms.Label();
            this.txtRepetabilityCountValue = new System.Windows.Forms.TextBox();
            this.lblRepeatabilityTotalCount = new System.Windows.Forms.Label();
            this.rdoScan1 = new System.Windows.Forms.RadioButton();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabControl5 = new System.Windows.Forms.TabControl();
            this.tabPage23 = new System.Windows.Forms.TabPage();
            this.button23 = new System.Windows.Forms.Button();
            this.button24 = new System.Windows.Forms.Button();
            this.AE_LIMITS = new System.Windows.Forms.DataGridView();
            this.tabPage8 = new System.Windows.Forms.TabPage();
            this.CPK_Save = new System.Windows.Forms.Button();
            this.CPK_Edit = new System.Windows.Forms.Button();
            this.CPK_dataGridView2 = new System.Windows.Forms.DataGridView();
            this.tabPage12 = new System.Windows.Forms.TabPage();
            this.button31 = new System.Windows.Forms.Button();
            this.button32 = new System.Windows.Forms.Button();
            this.GRR_dataGridView3 = new System.Windows.Forms.DataGridView();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.Table_Vision_Settings = new System.Windows.Forms.DataGridView();
            this.MotorDebug = new System.Windows.Forms.TabPage();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnedit = new System.Windows.Forms.Button();
            this.grbMotor = new System.Windows.Forms.GroupBox();
            this.Axis_Settings = new System.Windows.Forms.DataGridView();
            this.IODiagnostics = new System.Windows.Forms.TabPage();
            this.tabIO = new System.Windows.Forms.TabControl();
            this.btn_input = new System.Windows.Forms.TabPage();
            this.txtSearchForOutput = new System.Windows.Forms.TextBox();
            this.txtSearchForInput = new System.Windows.Forms.TextBox();
            this.label30 = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
            this.DGV_Output1 = new System.Windows.Forms.DataGridView();
            this.dataGridViewImageColumn1 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGV_Input1 = new System.Windows.Forms.DataGridView();
            this.InOnOff = new System.Windows.Forms.DataGridViewImageColumn();
            this.InputName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabPage10 = new System.Windows.Forms.TabPage();
            this.btnSveLod = new System.Windows.Forms.Button();
            this.LoaddellChk = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.dgvAI = new System.Windows.Forms.DataGridView();
            this.Device = new System.Windows.Forms.TabPage();
            this.DeviceSettingsPanel = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.Enable_4_3 = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.K_Model = new System.Windows.Forms.CheckBox();
            this.Nk_Model = new System.Windows.Forms.CheckBox();
            this.Four_Graphit = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Semimachk = new System.Windows.Forms.CheckBox();
            this.SFC_PDCA_Bypass = new System.Windows.Forms.CheckBox();
            this.Buzzer_Bypass = new System.Windows.Forms.CheckBox();
            this.Safety_door_bypass = new System.Windows.Forms.CheckBox();
            this.Barcode_scanner_bypass = new System.Windows.Forms.CheckBox();
            this.tabConnectionDetails = new System.Windows.Forms.TabControl();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.IP_Details_table = new System.Windows.Forms.DataGridView();
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.Serial_Comm_table = new System.Windows.Forms.DataGridView();
            this.btnEditSettings = new System.Windows.Forms.Button();
            this.btnSaveSettings = new System.Windows.Forms.Button();
            this.grpSystemSettings = new System.Windows.Forms.GroupBox();
            this.Dym_run = new System.Windows.Forms.RadioButton();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButtonDynamic = new System.Windows.Forms.RadioButton();
            this.radioButtonStatic = new System.Windows.Forms.RadioButton();
            this.radioButtoncpk = new System.Windows.Forms.RadioButton();
            this.radioButtondry = new System.Windows.Forms.RadioButton();
            this.radioButtonProd = new System.Windows.Forms.RadioButton();
            this.radioButtongrr = new System.Windows.Forms.RadioButton();
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
            this.lblrej = new System.Windows.Forms.Label();
            this.lbllife = new System.Windows.Forms.Label();
            this.lblsupdate = new System.Windows.Forms.Label();
            this.lblsrev = new System.Windows.Forms.Label();
            this.lbldat = new System.Windows.Forms.Label();
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
            this.tabControlSettings = new System.Windows.Forms.TabControl();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.dataGridViewImageColumn2 = new System.Windows.Forms.DataGridViewImageColumn();
            this.Calibration.SuspendLayout();
            this.CaliberationPanel.SuspendLayout();
            this.tabCalib.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.grpCameraCalib.SuspendLayout();
            this.grpboxCamera.SuspendLayout();
            this.tabPage7.SuspendLayout();
            this.grpGantry2.SuspendLayout();
            this.grpGantry.SuspendLayout();
            this.grpMoveAbsolute.SuspendLayout();
            this.grp_EditSave.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Nozzle)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.tabRepeatability.SuspendLayout();
            this.grpScan.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabControl5.SuspendLayout();
            this.tabPage23.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AE_LIMITS)).BeginInit();
            this.tabPage8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CPK_dataGridView2)).BeginInit();
            this.tabPage12.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GRR_dataGridView3)).BeginInit();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Table_Vision_Settings)).BeginInit();
            this.MotorDebug.SuspendLayout();
            this.panel2.SuspendLayout();
            this.grbMotor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Axis_Settings)).BeginInit();
            this.IODiagnostics.SuspendLayout();
            this.tabIO.SuspendLayout();
            this.btn_input.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_Output1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_Input1)).BeginInit();
            this.tabPage10.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAI)).BeginInit();
            this.Device.SuspendLayout();
            this.DeviceSettingsPanel.SuspendLayout();
            this.panel4.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabConnectionDetails.SuspendLayout();
            this.tabPage5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.IP_Details_table)).BeginInit();
            this.tabPage6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Serial_Comm_table)).BeginInit();
            this.grpSystemSettings.SuspendLayout();
            this.General.SuspendLayout();
            this.panel5.SuspendLayout();
            this.pnlShiftSettings.SuspendLayout();
            this.grpShiftSettings.SuspendLayout();
            this.pnlGeneral.SuspendLayout();
            this.pnlSupport.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.pnlInfo.SuspendLayout();
            this.tabControlSettings.SuspendLayout();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 50;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Calibration
            // 
            this.Calibration.Controls.Add(this.CaliberationPanel);
            this.Calibration.Location = new System.Drawing.Point(4, 40);
            this.Calibration.Name = "Calibration";
            this.Calibration.Size = new System.Drawing.Size(1016, 576);
            this.Calibration.TabIndex = 7;
            this.Calibration.Text = "Calibration";
            this.Calibration.UseVisualStyleBackColor = true;
            // 
            // CaliberationPanel
            // 
            this.CaliberationPanel.Controls.Add(this.tabCalib);
            this.CaliberationPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CaliberationPanel.Location = new System.Drawing.Point(0, 0);
            this.CaliberationPanel.Name = "CaliberationPanel";
            this.CaliberationPanel.Size = new System.Drawing.Size(1016, 576);
            this.CaliberationPanel.TabIndex = 0;
            // 
            // tabCalib
            // 
            this.tabCalib.Controls.Add(this.tabPage2);
            this.tabCalib.Controls.Add(this.tabPage7);
            this.tabCalib.Controls.Add(this.tabRepeatability);
            this.tabCalib.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabCalib.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabCalib.Location = new System.Drawing.Point(0, 0);
            this.tabCalib.Multiline = true;
            this.tabCalib.Name = "tabCalib";
            this.tabCalib.SelectedIndex = 0;
            this.tabCalib.Size = new System.Drawing.Size(1016, 576);
            this.tabCalib.TabIndex = 0;
            this.tabCalib.SelectedIndexChanged += new System.EventHandler(this.tabCameraCali_SelectedIndexChanged);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.grpCameraCalib);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3, 3, 3, 3);
            this.tabPage2.Size = new System.Drawing.Size(1008, 547);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Camera Static & Dynamic";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // grpCameraCalib
            // 
            this.grpCameraCalib.BackColor = System.Drawing.Color.WhiteSmoke;
            this.grpCameraCalib.Controls.Add(this.lbl_z2);
            this.grpCameraCalib.Controls.Add(this.txtposition_R);
            this.grpCameraCalib.Controls.Add(this.lbl_z1);
            this.grpCameraCalib.Controls.Add(this.txtposition_Z1);
            this.grpCameraCalib.Controls.Add(this.button3);
            this.grpCameraCalib.Controls.Add(this.grpboxCamera);
            this.grpCameraCalib.Controls.Add(this.label16);
            this.grpCameraCalib.Controls.Add(this.lblStaticUnit);
            this.grpCameraCalib.Controls.Add(this.label18);
            this.grpCameraCalib.Controls.Add(this.label129);
            this.grpCameraCalib.Controls.Add(this.txtstaticposccd1_y);
            this.grpCameraCalib.Controls.Add(this.txtstaticposccd1_x);
            this.grpCameraCalib.Controls.Add(this.lblStaticPos);
            this.grpCameraCalib.Controls.Add(this.btnccd1Browse);
            this.grpCameraCalib.Controls.Add(this.txtccd1path);
            this.grpCameraCalib.Controls.Add(this.label43);
            this.grpCameraCalib.Controls.Add(this.txtCounts);
            this.grpCameraCalib.Controls.Add(this.label50);
            this.grpCameraCalib.Controls.Add(this.txtspeed);
            this.grpCameraCalib.Controls.Add(this.label77);
            this.grpCameraCalib.Controls.Add(this.txtposition_y2);
            this.grpCameraCalib.Controls.Add(this.txtposition_y1);
            this.grpCameraCalib.Controls.Add(this.label79);
            this.grpCameraCalib.Controls.Add(this.label90);
            this.grpCameraCalib.Controls.Add(this.txtposition_x2);
            this.grpCameraCalib.Controls.Add(this.lblDynamicpos2);
            this.grpCameraCalib.Controls.Add(this.txtposition_x1);
            this.grpCameraCalib.Controls.Add(this.lblDynamicPos1);
            this.grpCameraCalib.Controls.Add(this.lblRunningCount);
            this.grpCameraCalib.Controls.Add(this.label118);
            this.grpCameraCalib.Controls.Add(this.txtTestMode);
            this.grpCameraCalib.Controls.Add(this.label119);
            this.grpCameraCalib.Controls.Add(this.btnCamera_Stop);
            this.grpCameraCalib.Controls.Add(this.btnCamera_Start);
            this.grpCameraCalib.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Bold);
            this.grpCameraCalib.Location = new System.Drawing.Point(221, 27);
            this.grpCameraCalib.Name = "grpCameraCalib";
            this.grpCameraCalib.Size = new System.Drawing.Size(543, 514);
            this.grpCameraCalib.TabIndex = 185;
            this.grpCameraCalib.TabStop = false;
            this.grpCameraCalib.Text = "CCD Calibration";
            // 
            // lbl_z2
            // 
            this.lbl_z2.AutoSize = true;
            this.lbl_z2.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_z2.Location = new System.Drawing.Point(451, 174);
            this.lbl_z2.Name = "lbl_z2";
            this.lbl_z2.Size = new System.Drawing.Size(15, 16);
            this.lbl_z2.TabIndex = 202;
            this.lbl_z2.Text = "R";
            // 
            // txtposition_R
            // 
            this.txtposition_R.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtposition_R.Location = new System.Drawing.Point(429, 202);
            this.txtposition_R.Name = "txtposition_R";
            this.txtposition_R.Size = new System.Drawing.Size(63, 23);
            this.txtposition_R.TabIndex = 201;
            // 
            // lbl_z1
            // 
            this.lbl_z1.AutoSize = true;
            this.lbl_z1.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_z1.Location = new System.Drawing.Point(451, 88);
            this.lbl_z1.Name = "lbl_z1";
            this.lbl_z1.Size = new System.Drawing.Size(16, 16);
            this.lbl_z1.TabIndex = 200;
            this.lbl_z1.Text = "Z";
            // 
            // txtposition_Z1
            // 
            this.txtposition_Z1.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtposition_Z1.Location = new System.Drawing.Point(429, 114);
            this.txtposition_Z1.Name = "txtposition_Z1";
            this.txtposition_Z1.Size = new System.Drawing.Size(63, 23);
            this.txtposition_Z1.TabIndex = 198;
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(94)))), ((int)(((byte)(133)))));
            this.button3.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.ForeColor = System.Drawing.Color.White;
            this.button3.Location = new System.Drawing.Point(429, 280);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(99, 35);
            this.button3.TabIndex = 196;
            this.button3.Text = "Reset";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // grpboxCamera
            // 
            this.grpboxCamera.BackColor = System.Drawing.Color.WhiteSmoke;
            this.grpboxCamera.Controls.Add(this.checkCCD1);
            this.grpboxCamera.Controls.Add(this.checkCCD4);
            this.grpboxCamera.Controls.Add(this.checkCCD3);
            this.grpboxCamera.Controls.Add(this.checkCCD2);
            this.grpboxCamera.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpboxCamera.Location = new System.Drawing.Point(61, 321);
            this.grpboxCamera.Name = "grpboxCamera";
            this.grpboxCamera.Size = new System.Drawing.Size(476, 87);
            this.grpboxCamera.TabIndex = 152;
            this.grpboxCamera.TabStop = false;
            this.grpboxCamera.Text = "Choose Camera";
            // 
            // checkCCD1
            // 
            this.checkCCD1.AutoSize = true;
            this.checkCCD1.Location = new System.Drawing.Point(52, 38);
            this.checkCCD1.Name = "checkCCD1";
            this.checkCCD1.Size = new System.Drawing.Size(66, 20);
            this.checkCCD1.TabIndex = 93;
            this.checkCCD1.Text = "CCD 1";
            this.checkCCD1.UseVisualStyleBackColor = true;
            // 
            // checkCCD4
            // 
            this.checkCCD4.AutoSize = true;
            this.checkCCD4.Location = new System.Drawing.Point(377, 38);
            this.checkCCD4.Name = "checkCCD4";
            this.checkCCD4.Size = new System.Drawing.Size(66, 20);
            this.checkCCD4.TabIndex = 92;
            this.checkCCD4.Text = "CCD 4";
            this.checkCCD4.UseVisualStyleBackColor = true;
            // 
            // checkCCD3
            // 
            this.checkCCD3.AutoSize = true;
            this.checkCCD3.Location = new System.Drawing.Point(273, 38);
            this.checkCCD3.Name = "checkCCD3";
            this.checkCCD3.Size = new System.Drawing.Size(66, 20);
            this.checkCCD3.TabIndex = 91;
            this.checkCCD3.Text = "CCD 3";
            this.checkCCD3.UseVisualStyleBackColor = true;
            // 
            // checkCCD2
            // 
            this.checkCCD2.AutoSize = true;
            this.checkCCD2.Location = new System.Drawing.Point(168, 38);
            this.checkCCD2.Name = "checkCCD2";
            this.checkCCD2.Size = new System.Drawing.Size(66, 20);
            this.checkCCD2.TabIndex = 90;
            this.checkCCD2.Text = "CCD 2";
            this.checkCCD2.UseVisualStyleBackColor = true;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(259, 248);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(50, 16);
            this.label16.TabIndex = 195;
            this.label16.Text = "(mm/s)";
            // 
            // lblStaticUnit
            // 
            this.lblStaticUnit.AutoSize = true;
            this.lblStaticUnit.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStaticUnit.Location = new System.Drawing.Point(340, 202);
            this.lblStaticUnit.Name = "lblStaticUnit";
            this.lblStaticUnit.Size = new System.Drawing.Size(39, 16);
            this.lblStaticUnit.TabIndex = 194;
            this.lblStaticUnit.Text = "(mm)";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(340, 159);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(39, 16);
            this.label18.TabIndex = 193;
            this.label18.Text = "(mm)";
            // 
            // label129
            // 
            this.label129.AutoSize = true;
            this.label129.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label129.Location = new System.Drawing.Point(340, 117);
            this.label129.Name = "label129";
            this.label129.Size = new System.Drawing.Size(39, 16);
            this.label129.TabIndex = 192;
            this.label129.Text = "(mm)";
            // 
            // txtstaticposccd1_y
            // 
            this.txtstaticposccd1_y.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtstaticposccd1_y.Location = new System.Drawing.Point(262, 199);
            this.txtstaticposccd1_y.Name = "txtstaticposccd1_y";
            this.txtstaticposccd1_y.Size = new System.Drawing.Size(63, 23);
            this.txtstaticposccd1_y.TabIndex = 191;
            // 
            // txtstaticposccd1_x
            // 
            this.txtstaticposccd1_x.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtstaticposccd1_x.Location = new System.Drawing.Point(177, 199);
            this.txtstaticposccd1_x.Name = "txtstaticposccd1_x";
            this.txtstaticposccd1_x.Size = new System.Drawing.Size(63, 23);
            this.txtstaticposccd1_x.TabIndex = 190;
            // 
            // lblStaticPos
            // 
            this.lblStaticPos.AutoSize = true;
            this.lblStaticPos.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStaticPos.Location = new System.Drawing.Point(65, 202);
            this.lblStaticPos.Name = "lblStaticPos";
            this.lblStaticPos.Size = new System.Drawing.Size(75, 16);
            this.lblStaticPos.TabIndex = 189;
            this.lblStaticPos.Text = "Static Pos";
            // 
            // btnccd1Browse
            // 
            this.btnccd1Browse.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(94)))), ((int)(((byte)(133)))));
            this.btnccd1Browse.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnccd1Browse.ForeColor = System.Drawing.Color.White;
            this.btnccd1Browse.Location = new System.Drawing.Point(394, 441);
            this.btnccd1Browse.Name = "btnccd1Browse";
            this.btnccd1Browse.Size = new System.Drawing.Size(83, 29);
            this.btnccd1Browse.TabIndex = 188;
            this.btnccd1Browse.Text = "Browse";
            this.btnccd1Browse.UseVisualStyleBackColor = false;
            // 
            // txtccd1path
            // 
            this.txtccd1path.Enabled = false;
            this.txtccd1path.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtccd1path.Location = new System.Drawing.Point(69, 444);
            this.txtccd1path.Name = "txtccd1path";
            this.txtccd1path.Size = new System.Drawing.Size(310, 23);
            this.txtccd1path.TabIndex = 187;
            // 
            // label43
            // 
            this.label43.AutoSize = true;
            this.label43.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label43.Location = new System.Drawing.Point(66, 413);
            this.label43.Name = "label43";
            this.label43.Size = new System.Drawing.Size(134, 16);
            this.label43.TabIndex = 186;
            this.label43.Text = "CSV File Save Path";
            // 
            // txtCounts
            // 
            this.txtCounts.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCounts.Location = new System.Drawing.Point(177, 283);
            this.txtCounts.Name = "txtCounts";
            this.txtCounts.Size = new System.Drawing.Size(63, 23);
            this.txtCounts.TabIndex = 185;
            // 
            // label50
            // 
            this.label50.AutoSize = true;
            this.label50.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label50.Location = new System.Drawing.Point(65, 286);
            this.label50.Name = "label50";
            this.label50.Size = new System.Drawing.Size(93, 16);
            this.label50.TabIndex = 184;
            this.label50.Text = "No of Counts";
            // 
            // txtspeed
            // 
            this.txtspeed.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtspeed.Location = new System.Drawing.Point(177, 241);
            this.txtspeed.Name = "txtspeed";
            this.txtspeed.Size = new System.Drawing.Size(63, 23);
            this.txtspeed.TabIndex = 183;
            // 
            // label77
            // 
            this.label77.AutoSize = true;
            this.label77.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label77.Location = new System.Drawing.Point(65, 244);
            this.label77.Name = "label77";
            this.label77.Size = new System.Drawing.Size(48, 16);
            this.label77.TabIndex = 182;
            this.label77.Text = "Speed";
            // 
            // txtposition_y2
            // 
            this.txtposition_y2.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtposition_y2.Location = new System.Drawing.Point(262, 156);
            this.txtposition_y2.Name = "txtposition_y2";
            this.txtposition_y2.Size = new System.Drawing.Size(63, 23);
            this.txtposition_y2.TabIndex = 181;
            // 
            // txtposition_y1
            // 
            this.txtposition_y1.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtposition_y1.Location = new System.Drawing.Point(262, 117);
            this.txtposition_y1.Name = "txtposition_y1";
            this.txtposition_y1.Size = new System.Drawing.Size(63, 23);
            this.txtposition_y1.TabIndex = 177;
            // 
            // label79
            // 
            this.label79.AutoSize = true;
            this.label79.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label79.Location = new System.Drawing.Point(285, 88);
            this.label79.Name = "label79";
            this.label79.Size = new System.Drawing.Size(16, 16);
            this.label79.TabIndex = 175;
            this.label79.Text = "Y";
            // 
            // label90
            // 
            this.label90.AutoSize = true;
            this.label90.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label90.Location = new System.Drawing.Point(200, 88);
            this.label90.Name = "label90";
            this.label90.Size = new System.Drawing.Size(16, 16);
            this.label90.TabIndex = 174;
            this.label90.Text = "X";
            // 
            // txtposition_x2
            // 
            this.txtposition_x2.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtposition_x2.Location = new System.Drawing.Point(177, 156);
            this.txtposition_x2.Name = "txtposition_x2";
            this.txtposition_x2.Size = new System.Drawing.Size(63, 23);
            this.txtposition_x2.TabIndex = 173;
            // 
            // lblDynamicpos2
            // 
            this.lblDynamicpos2.AutoSize = true;
            this.lblDynamicpos2.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDynamicpos2.Location = new System.Drawing.Point(65, 159);
            this.lblDynamicpos2.Name = "lblDynamicpos2";
            this.lblDynamicpos2.Size = new System.Drawing.Size(103, 16);
            this.lblDynamicpos2.TabIndex = 172;
            this.lblDynamicpos2.Text = "Dynamic Pos 2";
            // 
            // txtposition_x1
            // 
            this.txtposition_x1.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtposition_x1.Location = new System.Drawing.Point(177, 117);
            this.txtposition_x1.Name = "txtposition_x1";
            this.txtposition_x1.Size = new System.Drawing.Size(63, 23);
            this.txtposition_x1.TabIndex = 171;
            // 
            // lblDynamicPos1
            // 
            this.lblDynamicPos1.AutoSize = true;
            this.lblDynamicPos1.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDynamicPos1.Location = new System.Drawing.Point(65, 120);
            this.lblDynamicPos1.Name = "lblDynamicPos1";
            this.lblDynamicPos1.Size = new System.Drawing.Size(103, 16);
            this.lblDynamicPos1.TabIndex = 170;
            this.lblDynamicPos1.Text = "Dynamic Pos 1";
            // 
            // lblRunningCount
            // 
            this.lblRunningCount.AutoSize = true;
            this.lblRunningCount.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRunningCount.Location = new System.Drawing.Point(384, 290);
            this.lblRunningCount.Name = "lblRunningCount";
            this.lblRunningCount.Size = new System.Drawing.Size(15, 16);
            this.lblRunningCount.TabIndex = 169;
            this.lblRunningCount.Text = "0";
            // 
            // label118
            // 
            this.label118.AutoSize = true;
            this.label118.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label118.Location = new System.Drawing.Point(277, 290);
            this.label118.Name = "label118";
            this.label118.Size = new System.Drawing.Size(102, 16);
            this.label118.TabIndex = 168;
            this.label118.Text = "Running Count";
            // 
            // txtTestMode
            // 
            this.txtTestMode.Location = new System.Drawing.Point(211, 35);
            this.txtTestMode.Name = "txtTestMode";
            this.txtTestMode.Size = new System.Drawing.Size(232, 30);
            this.txtTestMode.TabIndex = 167;
            // 
            // label119
            // 
            this.label119.AutoSize = true;
            this.label119.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label119.Location = new System.Drawing.Point(129, 40);
            this.label119.Name = "label119";
            this.label119.Size = new System.Drawing.Size(76, 16);
            this.label119.TabIndex = 164;
            this.label119.Text = "Test Mode";
            // 
            // btnCamera_Stop
            // 
            this.btnCamera_Stop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(94)))), ((int)(((byte)(133)))));
            this.btnCamera_Stop.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCamera_Stop.ForeColor = System.Drawing.Color.White;
            this.btnCamera_Stop.Location = new System.Drawing.Point(303, 473);
            this.btnCamera_Stop.Name = "btnCamera_Stop";
            this.btnCamera_Stop.Size = new System.Drawing.Size(99, 35);
            this.btnCamera_Stop.TabIndex = 100;
            this.btnCamera_Stop.Text = "Stop";
            this.btnCamera_Stop.UseVisualStyleBackColor = false;
            this.btnCamera_Stop.Click += new System.EventHandler(this.btnCamera_Stop_Click);
            // 
            // btnCamera_Start
            // 
            this.btnCamera_Start.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(94)))), ((int)(((byte)(133)))));
            this.btnCamera_Start.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCamera_Start.ForeColor = System.Drawing.Color.White;
            this.btnCamera_Start.Location = new System.Drawing.Point(116, 473);
            this.btnCamera_Start.Name = "btnCamera_Start";
            this.btnCamera_Start.Size = new System.Drawing.Size(99, 35);
            this.btnCamera_Start.TabIndex = 100;
            this.btnCamera_Start.Text = "Start";
            this.btnCamera_Start.UseVisualStyleBackColor = false;
            this.btnCamera_Start.Click += new System.EventHandler(this.btnCamera_Start_Click);
            // 
            // tabPage7
            // 
            this.tabPage7.Controls.Add(this.grpGantry2);
            this.tabPage7.Controls.Add(this.grpGantry);
            this.tabPage7.Controls.Add(this.grpMoveAbsolute);
            this.tabPage7.Controls.Add(this.label2);
            this.tabPage7.Controls.Add(this.txtdistance);
            this.tabPage7.Controls.Add(this.btn_stop);
            this.tabPage7.Controls.Add(this.btn_start);
            this.tabPage7.Controls.Add(this.grp_EditSave);
            this.tabPage7.Controls.Add(this.dgv_Nozzle);
            this.tabPage7.Controls.Add(this.cmb_Nozzle);
            this.tabPage7.Controls.Add(this.lbl_Nozzle);
            this.tabPage7.Location = new System.Drawing.Point(4, 25);
            this.tabPage7.Name = "tabPage7";
            this.tabPage7.Size = new System.Drawing.Size(1010, 551);
            this.tabPage7.TabIndex = 4;
            this.tabPage7.Text = "Camera Calibration";
            this.tabPage7.UseVisualStyleBackColor = true;
            // 
            // grpGantry2
            // 
            this.grpGantry2.Controls.Add(this.txt_PrfPos_Z1);
            this.grpGantry2.Controls.Add(this.lblZ_Position);
            this.grpGantry2.Controls.Add(this.btnZ1Add);
            this.grpGantry2.Controls.Add(this.btnR2Add);
            this.grpGantry2.Controls.Add(this.btnR2Dec);
            this.grpGantry2.Controls.Add(this.btnZ1Dec);
            this.grpGantry2.Controls.Add(this.txt_PrfPos_Z2);
            this.grpGantry2.Controls.Add(this.txt_PrfPos_R2);
            this.grpGantry2.Controls.Add(this.label20);
            this.grpGantry2.Controls.Add(this.btnR1Add);
            this.grpGantry2.Controls.Add(this.txt_PrfPos_R1);
            this.grpGantry2.Controls.Add(this.label21);
            this.grpGantry2.Controls.Add(this.label23);
            this.grpGantry2.Controls.Add(this.btnR1Dec);
            this.grpGantry2.Controls.Add(this.btnZ2Dec);
            this.grpGantry2.Controls.Add(this.btnZ2Add);
            this.grpGantry2.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpGantry2.Location = new System.Drawing.Point(653, 328);
            this.grpGantry2.Name = "grpGantry2";
            this.grpGantry2.Size = new System.Drawing.Size(199, 201);
            this.grpGantry2.TabIndex = 92;
            this.grpGantry2.TabStop = false;
            this.grpGantry2.Text = "Gantry";
            // 
            // txt_PrfPos_Z1
            // 
            this.txt_PrfPos_Z1.Enabled = false;
            this.txt_PrfPos_Z1.Location = new System.Drawing.Point(97, 34);
            this.txt_PrfPos_Z1.Name = "txt_PrfPos_Z1";
            this.txt_PrfPos_Z1.Size = new System.Drawing.Size(83, 23);
            this.txt_PrfPos_Z1.TabIndex = 9;
            this.txt_PrfPos_Z1.Text = "0";
            this.txt_PrfPos_Z1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblZ_Position
            // 
            this.lblZ_Position.AutoSize = true;
            this.lblZ_Position.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblZ_Position.Location = new System.Drawing.Point(86, 18);
            this.lblZ_Position.Name = "lblZ_Position";
            this.lblZ_Position.Size = new System.Drawing.Size(106, 13);
            this.lblZ_Position.TabIndex = 10;
            this.lblZ_Position.Text = "Z1 Position (mm)";
            // 
            // btnZ1Add
            // 
            this.btnZ1Add.BackColor = System.Drawing.Color.Black;
            this.btnZ1Add.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnZ1Add.BackgroundImage")));
            this.btnZ1Add.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnZ1Add.Location = new System.Drawing.Point(47, 16);
            this.btnZ1Add.Name = "btnZ1Add";
            this.btnZ1Add.Size = new System.Drawing.Size(33, 43);
            this.btnZ1Add.TabIndex = 43;
            this.btnZ1Add.UseVisualStyleBackColor = false;
            this.btnZ1Add.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnZAdd_MouseDown);
            this.btnZ1Add.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnZAdd_MouseUp);
            // 
            // btnR2Add
            // 
            this.btnR2Add.BackColor = System.Drawing.Color.Black;
            this.btnR2Add.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnR2Add.BackgroundImage")));
            this.btnR2Add.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnR2Add.Location = new System.Drawing.Point(48, 156);
            this.btnR2Add.Name = "btnR2Add";
            this.btnR2Add.Size = new System.Drawing.Size(34, 46);
            this.btnR2Add.TabIndex = 24;
            this.btnR2Add.UseVisualStyleBackColor = false;
            this.btnR2Add.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnR2Add_MouseDown);
            this.btnR2Add.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnR2Add_MouseUp);
            // 
            // btnR2Dec
            // 
            this.btnR2Dec.BackColor = System.Drawing.Color.Black;
            this.btnR2Dec.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnR2Dec.BackgroundImage")));
            this.btnR2Dec.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnR2Dec.Location = new System.Drawing.Point(6, 158);
            this.btnR2Dec.Name = "btnR2Dec";
            this.btnR2Dec.Size = new System.Drawing.Size(39, 43);
            this.btnR2Dec.TabIndex = 23;
            this.btnR2Dec.UseVisualStyleBackColor = false;
            this.btnR2Dec.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnR2Dec_MouseDown);
            this.btnR2Dec.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnR2Dec_MouseUp);
            // 
            // btnZ1Dec
            // 
            this.btnZ1Dec.BackColor = System.Drawing.Color.Black;
            this.btnZ1Dec.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnZ1Dec.BackgroundImage")));
            this.btnZ1Dec.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnZ1Dec.Location = new System.Drawing.Point(6, 15);
            this.btnZ1Dec.Name = "btnZ1Dec";
            this.btnZ1Dec.Size = new System.Drawing.Size(39, 43);
            this.btnZ1Dec.TabIndex = 20;
            this.btnZ1Dec.UseVisualStyleBackColor = false;
            this.btnZ1Dec.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnZDec_MouseDown);
            this.btnZ1Dec.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnZDec_MouseUp);
            // 
            // txt_PrfPos_Z2
            // 
            this.txt_PrfPos_Z2.Enabled = false;
            this.txt_PrfPos_Z2.Location = new System.Drawing.Point(97, 77);
            this.txt_PrfPos_Z2.Name = "txt_PrfPos_Z2";
            this.txt_PrfPos_Z2.Size = new System.Drawing.Size(83, 23);
            this.txt_PrfPos_Z2.TabIndex = 9;
            this.txt_PrfPos_Z2.Text = "0";
            this.txt_PrfPos_Z2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txt_PrfPos_R2
            // 
            this.txt_PrfPos_R2.Enabled = false;
            this.txt_PrfPos_R2.Location = new System.Drawing.Point(97, 175);
            this.txt_PrfPos_R2.Name = "txt_PrfPos_R2";
            this.txt_PrfPos_R2.Size = new System.Drawing.Size(83, 23);
            this.txt_PrfPos_R2.TabIndex = 1;
            this.txt_PrfPos_R2.Text = "0";
            this.txt_PrfPos_R2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.Location = new System.Drawing.Point(87, 158);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(106, 13);
            this.label20.TabIndex = 2;
            this.label20.Text = "R2 Position (mm)";
            // 
            // btnR1Add
            // 
            this.btnR1Add.BackColor = System.Drawing.Color.Black;
            this.btnR1Add.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnR1Add.BackgroundImage")));
            this.btnR1Add.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnR1Add.Location = new System.Drawing.Point(47, 109);
            this.btnR1Add.Name = "btnR1Add";
            this.btnR1Add.Size = new System.Drawing.Size(34, 46);
            this.btnR1Add.TabIndex = 22;
            this.btnR1Add.UseVisualStyleBackColor = false;
            this.btnR1Add.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnR1Add_MouseDown);
            this.btnR1Add.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnR1Add_MouseUp);
            // 
            // txt_PrfPos_R1
            // 
            this.txt_PrfPos_R1.Enabled = false;
            this.txt_PrfPos_R1.Location = new System.Drawing.Point(97, 132);
            this.txt_PrfPos_R1.Name = "txt_PrfPos_R1";
            this.txt_PrfPos_R1.Size = new System.Drawing.Size(83, 23);
            this.txt_PrfPos_R1.TabIndex = 13;
            this.txt_PrfPos_R1.Text = "0";
            this.txt_PrfPos_R1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.Location = new System.Drawing.Point(87, 61);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(106, 13);
            this.label21.TabIndex = 10;
            this.label21.Text = "Z2 Position (mm)";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label23.Location = new System.Drawing.Point(87, 112);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(106, 13);
            this.label23.TabIndex = 14;
            this.label23.Text = "R1 Position (mm)";
            // 
            // btnR1Dec
            // 
            this.btnR1Dec.BackColor = System.Drawing.Color.Black;
            this.btnR1Dec.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnR1Dec.BackgroundImage")));
            this.btnR1Dec.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnR1Dec.Location = new System.Drawing.Point(6, 108);
            this.btnR1Dec.Name = "btnR1Dec";
            this.btnR1Dec.Size = new System.Drawing.Size(39, 47);
            this.btnR1Dec.TabIndex = 21;
            this.btnR1Dec.UseVisualStyleBackColor = false;
            this.btnR1Dec.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnR1Dec_MouseDown);
            this.btnR1Dec.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnR1Dec_MouseUp);
            // 
            // btnZ2Dec
            // 
            this.btnZ2Dec.BackColor = System.Drawing.Color.Black;
            this.btnZ2Dec.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnZ2Dec.BackgroundImage")));
            this.btnZ2Dec.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnZ2Dec.Location = new System.Drawing.Point(6, 61);
            this.btnZ2Dec.Name = "btnZ2Dec";
            this.btnZ2Dec.Size = new System.Drawing.Size(39, 43);
            this.btnZ2Dec.TabIndex = 20;
            this.btnZ2Dec.UseVisualStyleBackColor = false;
            this.btnZ2Dec.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnZ2Dec_MouseDown);
            this.btnZ2Dec.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnZ2Dec_MouseUp);
            // 
            // btnZ2Add
            // 
            this.btnZ2Add.BackColor = System.Drawing.Color.Black;
            this.btnZ2Add.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnZ2Add.BackgroundImage")));
            this.btnZ2Add.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnZ2Add.Location = new System.Drawing.Point(48, 61);
            this.btnZ2Add.Name = "btnZ2Add";
            this.btnZ2Add.Size = new System.Drawing.Size(33, 43);
            this.btnZ2Add.TabIndex = 19;
            this.btnZ2Add.UseVisualStyleBackColor = false;
            this.btnZ2Add.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnZ2Add_MouseDown);
            this.btnZ2Add.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnZ2Add_MouseUp);
            // 
            // grpGantry
            // 
            this.grpGantry.Controls.Add(this.lblY_Position);
            this.grpGantry.Controls.Add(this.txt_PrfPos_Y1);
            this.grpGantry.Controls.Add(this.btnXAdd);
            this.grpGantry.Controls.Add(this.btnYDec);
            this.grpGantry.Controls.Add(this.btnYAdd);
            this.grpGantry.Controls.Add(this.btnXDec);
            this.grpGantry.Controls.Add(this.lblX_Position);
            this.grpGantry.Controls.Add(this.txt_PrfPos_X1);
            this.grpGantry.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpGantry.Location = new System.Drawing.Point(345, 328);
            this.grpGantry.Name = "grpGantry";
            this.grpGantry.Size = new System.Drawing.Size(298, 196);
            this.grpGantry.TabIndex = 89;
            this.grpGantry.TabStop = false;
            this.grpGantry.Text = "Gantry";
            // 
            // lblY_Position
            // 
            this.lblY_Position.AutoSize = true;
            this.lblY_Position.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblY_Position.Location = new System.Drawing.Point(200, 93);
            this.lblY_Position.Name = "lblY_Position";
            this.lblY_Position.Size = new System.Drawing.Size(98, 13);
            this.lblY_Position.TabIndex = 14;
            this.lblY_Position.Text = "Y Position (mm)";
            // 
            // txt_PrfPos_Y1
            // 
            this.txt_PrfPos_Y1.Enabled = false;
            this.txt_PrfPos_Y1.Location = new System.Drawing.Point(207, 117);
            this.txt_PrfPos_Y1.Name = "txt_PrfPos_Y1";
            this.txt_PrfPos_Y1.Size = new System.Drawing.Size(83, 23);
            this.txt_PrfPos_Y1.TabIndex = 13;
            this.txt_PrfPos_Y1.Text = "0";
            this.txt_PrfPos_Y1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnXAdd
            // 
            this.btnXAdd.BackColor = System.Drawing.Color.Black;
            this.btnXAdd.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnXAdd.BackgroundImage")));
            this.btnXAdd.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnXAdd.Location = new System.Drawing.Point(126, 70);
            this.btnXAdd.Name = "btnXAdd";
            this.btnXAdd.Size = new System.Drawing.Size(50, 50);
            this.btnXAdd.TabIndex = 9;
            this.btnXAdd.UseVisualStyleBackColor = false;
            this.btnXAdd.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnXDec_MouseDown);
            this.btnXAdd.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnXDec_MouseUp);
            // 
            // btnYDec
            // 
            this.btnYDec.BackColor = System.Drawing.Color.Black;
            this.btnYDec.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnYDec.BackgroundImage")));
            this.btnYDec.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnYDec.Location = new System.Drawing.Point(75, 20);
            this.btnYDec.Name = "btnYDec";
            this.btnYDec.Size = new System.Drawing.Size(50, 50);
            this.btnYDec.TabIndex = 11;
            this.btnYDec.UseVisualStyleBackColor = false;
            this.btnYDec.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnYAdd_MouseDown);
            this.btnYDec.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnYAdd_MouseUp);
            // 
            // btnYAdd
            // 
            this.btnYAdd.BackColor = System.Drawing.Color.Black;
            this.btnYAdd.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnYAdd.BackgroundImage")));
            this.btnYAdd.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnYAdd.Location = new System.Drawing.Point(75, 125);
            this.btnYAdd.Name = "btnYAdd";
            this.btnYAdd.Size = new System.Drawing.Size(50, 50);
            this.btnYAdd.TabIndex = 10;
            this.btnYAdd.UseVisualStyleBackColor = false;
            this.btnYAdd.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnYDec_MouseDown);
            this.btnYAdd.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnYDec_MouseUp);
            // 
            // btnXDec
            // 
            this.btnXDec.BackColor = System.Drawing.Color.Black;
            this.btnXDec.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnXDec.BackgroundImage")));
            this.btnXDec.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnXDec.Location = new System.Drawing.Point(23, 72);
            this.btnXDec.Name = "btnXDec";
            this.btnXDec.Size = new System.Drawing.Size(50, 50);
            this.btnXDec.TabIndex = 12;
            this.btnXDec.UseVisualStyleBackColor = false;
            this.btnXDec.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnXAdd_MouseDown);
            this.btnXDec.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnXAdd_MouseUp);
            // 
            // lblX_Position
            // 
            this.lblX_Position.AutoSize = true;
            this.lblX_Position.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblX_Position.Location = new System.Drawing.Point(199, 37);
            this.lblX_Position.Name = "lblX_Position";
            this.lblX_Position.Size = new System.Drawing.Size(99, 13);
            this.lblX_Position.TabIndex = 2;
            this.lblX_Position.Text = "X Position (mm)";
            // 
            // txt_PrfPos_X1
            // 
            this.txt_PrfPos_X1.Enabled = false;
            this.txt_PrfPos_X1.Location = new System.Drawing.Point(207, 58);
            this.txt_PrfPos_X1.Name = "txt_PrfPos_X1";
            this.txt_PrfPos_X1.Size = new System.Drawing.Size(83, 23);
            this.txt_PrfPos_X1.TabIndex = 1;
            this.txt_PrfPos_X1.Text = "0";
            this.txt_PrfPos_X1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // grpMoveAbsolute
            // 
            this.grpMoveAbsolute.BackColor = System.Drawing.Color.Silver;
            this.grpMoveAbsolute.Controls.Add(this.btnMoveAbs);
            this.grpMoveAbsolute.Controls.Add(this.lblServoX_TargetSpeed);
            this.grpMoveAbsolute.Controls.Add(this.txtetSpeedAbs);
            this.grpMoveAbsolute.Controls.Add(this.lblMoveAbsSpeed);
            this.grpMoveAbsolute.Controls.Add(this.label1);
            this.grpMoveAbsolute.Controls.Add(this.cmbMoveMode);
            this.grpMoveAbsolute.Controls.Add(this.cmbAxisMoveAbs);
            this.grpMoveAbsolute.Controls.Add(this.lblMoveAbsSelectAxis);
            this.grpMoveAbsolute.Controls.Add(this.btnStop);
            this.grpMoveAbsolute.Controls.Add(this.lblServoX_TargetPosition);
            this.grpMoveAbsolute.Controls.Add(this.txtPositionAbs);
            this.grpMoveAbsolute.Controls.Add(this.lblMoveAbsPos);
            this.grpMoveAbsolute.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpMoveAbsolute.Location = new System.Drawing.Point(42, 328);
            this.grpMoveAbsolute.Name = "grpMoveAbsolute";
            this.grpMoveAbsolute.Size = new System.Drawing.Size(301, 196);
            this.grpMoveAbsolute.TabIndex = 91;
            this.grpMoveAbsolute.TabStop = false;
            // 
            // btnMoveAbs
            // 
            this.btnMoveAbs.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(94)))), ((int)(((byte)(133)))));
            this.btnMoveAbs.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMoveAbs.ForeColor = System.Drawing.Color.White;
            this.btnMoveAbs.Location = new System.Drawing.Point(212, 112);
            this.btnMoveAbs.Name = "btnMoveAbs";
            this.btnMoveAbs.Size = new System.Drawing.Size(83, 37);
            this.btnMoveAbs.TabIndex = 88;
            this.btnMoveAbs.Text = "Move";
            this.btnMoveAbs.UseVisualStyleBackColor = false;
            this.btnMoveAbs.Click += new System.EventHandler(this.btnMoveAbs_Click);
            // 
            // lblServoX_TargetSpeed
            // 
            this.lblServoX_TargetSpeed.AutoSize = true;
            this.lblServoX_TargetSpeed.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblServoX_TargetSpeed.Location = new System.Drawing.Point(162, 89);
            this.lblServoX_TargetSpeed.Name = "lblServoX_TargetSpeed";
            this.lblServoX_TargetSpeed.Size = new System.Drawing.Size(47, 14);
            this.lblServoX_TargetSpeed.TabIndex = 87;
            this.lblServoX_TargetSpeed.Text = "(mm/s)";
            // 
            // txtetSpeedAbs
            // 
            this.txtetSpeedAbs.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtetSpeedAbs.Location = new System.Drawing.Point(85, 80);
            this.txtetSpeedAbs.Name = "txtetSpeedAbs";
            this.txtetSpeedAbs.Size = new System.Drawing.Size(73, 26);
            this.txtetSpeedAbs.TabIndex = 86;
            this.txtetSpeedAbs.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtetSpeedAbs_KeyDown);
            this.txtetSpeedAbs.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtetSpeedAbs_KeyPress);
            this.txtetSpeedAbs.MouseDown += new System.Windows.Forms.MouseEventHandler(this.txtetSpeedAbs_MouseDown);
            this.txtetSpeedAbs.MouseUp += new System.Windows.Forms.MouseEventHandler(this.txtetSpeedAbs_MouseUp);
            // 
            // lblMoveAbsSpeed
            // 
            this.lblMoveAbsSpeed.AutoSize = true;
            this.lblMoveAbsSpeed.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMoveAbsSpeed.Location = new System.Drawing.Point(6, 84);
            this.lblMoveAbsSpeed.Name = "lblMoveAbsSpeed";
            this.lblMoveAbsSpeed.Size = new System.Drawing.Size(45, 14);
            this.lblMoveAbsSpeed.TabIndex = 85;
            this.lblMoveAbsSpeed.Text = "Speed";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 14);
            this.label1.TabIndex = 84;
            this.label1.Text = "Move Mode";
            // 
            // cmbMoveMode
            // 
            this.cmbMoveMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMoveMode.FormattingEnabled = true;
            this.cmbMoveMode.Items.AddRange(new object[] {
            "Absolute",
            "Jog"});
            this.cmbMoveMode.Location = new System.Drawing.Point(85, 46);
            this.cmbMoveMode.Name = "cmbMoveMode";
            this.cmbMoveMode.Size = new System.Drawing.Size(211, 24);
            this.cmbMoveMode.TabIndex = 83;
            this.cmbMoveMode.SelectedIndexChanged += new System.EventHandler(this.cmbMoveMode_SelectedIndexChanged);
            // 
            // cmbAxisMoveAbs
            // 
            this.cmbAxisMoveAbs.FormattingEnabled = true;
            this.cmbAxisMoveAbs.Items.AddRange(new object[] {
            "X",
            "Y",
            "Z"});
            this.cmbAxisMoveAbs.Location = new System.Drawing.Point(85, 18);
            this.cmbAxisMoveAbs.Name = "cmbAxisMoveAbs";
            this.cmbAxisMoveAbs.Size = new System.Drawing.Size(211, 24);
            this.cmbAxisMoveAbs.TabIndex = 82;
            this.cmbAxisMoveAbs.SelectedIndexChanged += new System.EventHandler(this.cmbAxisMoveAbs_SelectedIndexChanged);
            this.cmbAxisMoveAbs.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbAxisMoveAbs_KeyPress);
            // 
            // lblMoveAbsSelectAxis
            // 
            this.lblMoveAbsSelectAxis.AutoSize = true;
            this.lblMoveAbsSelectAxis.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMoveAbsSelectAxis.Location = new System.Drawing.Point(6, 20);
            this.lblMoveAbsSelectAxis.Name = "lblMoveAbsSelectAxis";
            this.lblMoveAbsSelectAxis.Size = new System.Drawing.Size(73, 14);
            this.lblMoveAbsSelectAxis.TabIndex = 81;
            this.lblMoveAbsSelectAxis.Text = "Select Axis";
            // 
            // btnStop
            // 
            this.btnStop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(94)))), ((int)(((byte)(133)))));
            this.btnStop.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStop.ForeColor = System.Drawing.Color.White;
            this.btnStop.Location = new System.Drawing.Point(212, 76);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(83, 37);
            this.btnStop.TabIndex = 80;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = false;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // lblServoX_TargetPosition
            // 
            this.lblServoX_TargetPosition.AutoSize = true;
            this.lblServoX_TargetPosition.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblServoX_TargetPosition.Location = new System.Drawing.Point(164, 125);
            this.lblServoX_TargetPosition.Name = "lblServoX_TargetPosition";
            this.lblServoX_TargetPosition.Size = new System.Drawing.Size(37, 14);
            this.lblServoX_TargetPosition.TabIndex = 77;
            this.lblServoX_TargetPosition.Text = "(mm)";
            // 
            // txtPositionAbs
            // 
            this.txtPositionAbs.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPositionAbs.Location = new System.Drawing.Point(85, 120);
            this.txtPositionAbs.Name = "txtPositionAbs";
            this.txtPositionAbs.Size = new System.Drawing.Size(73, 26);
            this.txtPositionAbs.TabIndex = 74;
            this.txtPositionAbs.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPositionAbs_KeyDown);
            this.txtPositionAbs.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPositionAbs_KeyPress);
            this.txtPositionAbs.MouseDown += new System.Windows.Forms.MouseEventHandler(this.txtPositionAbs_MouseDown);
            this.txtPositionAbs.MouseUp += new System.Windows.Forms.MouseEventHandler(this.txtPositionAbs_MouseUp);
            // 
            // lblMoveAbsPos
            // 
            this.lblMoveAbsPos.AutoSize = true;
            this.lblMoveAbsPos.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMoveAbsPos.Location = new System.Drawing.Point(6, 121);
            this.lblMoveAbsPos.Name = "lblMoveAbsPos";
            this.lblMoveAbsPos.Size = new System.Drawing.Size(57, 14);
            this.lblMoveAbsPos.TabIndex = 73;
            this.lblMoveAbsPos.Text = "Position";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(430, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 16);
            this.label2.TabIndex = 90;
            this.label2.Text = "Distance";
            // 
            // txtdistance
            // 
            this.txtdistance.Location = new System.Drawing.Point(516, 44);
            this.txtdistance.Name = "txtdistance";
            this.txtdistance.Size = new System.Drawing.Size(100, 23);
            this.txtdistance.TabIndex = 89;
            // 
            // btn_stop
            // 
            this.btn_stop.Location = new System.Drawing.Point(906, 417);
            this.btn_stop.Name = "btn_stop";
            this.btn_stop.Size = new System.Drawing.Size(75, 23);
            this.btn_stop.TabIndex = 0;
            this.btn_stop.Text = "Stop";
            this.btn_stop.UseVisualStyleBackColor = true;
            this.btn_stop.Click += new System.EventHandler(this.btn_stop_Click);
            // 
            // btn_start
            // 
            this.btn_start.Location = new System.Drawing.Point(906, 381);
            this.btn_start.Name = "btn_start";
            this.btn_start.Size = new System.Drawing.Size(75, 23);
            this.btn_start.TabIndex = 0;
            this.btn_start.Text = "Start";
            this.btn_start.UseVisualStyleBackColor = true;
            this.btn_start.Click += new System.EventHandler(this.btn_start_Click);
            // 
            // grp_EditSave
            // 
            this.grp_EditSave.BackColor = System.Drawing.SystemColors.Control;
            this.grp_EditSave.Controls.Add(this.btn_save);
            this.grp_EditSave.Controls.Add(this.btn_edit);
            this.grp_EditSave.Controls.Add(this.lblSave);
            this.grp_EditSave.Controls.Add(this.lblEdit);
            this.grp_EditSave.Location = new System.Drawing.Point(902, 129);
            this.grp_EditSave.Name = "grp_EditSave";
            this.grp_EditSave.Size = new System.Drawing.Size(79, 204);
            this.grp_EditSave.TabIndex = 86;
            this.grp_EditSave.TabStop = false;
            // 
            // btn_save
            // 
            this.btn_save.BackColor = System.Drawing.Color.LightGray;
            this.btn_save.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_save.BackgroundImage")));
            this.btn_save.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btn_save.Enabled = false;
            this.btn_save.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
            this.btn_save.Location = new System.Drawing.Point(13, 110);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(50, 50);
            this.btn_save.TabIndex = 61;
            this.btn_save.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btn_save.UseVisualStyleBackColor = false;
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // btn_edit
            // 
            this.btn_edit.BackColor = System.Drawing.Color.LightGray;
            this.btn_edit.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_edit.BackgroundImage")));
            this.btn_edit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btn_edit.Enabled = false;
            this.btn_edit.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
            this.btn_edit.Location = new System.Drawing.Point(13, 19);
            this.btn_edit.Name = "btn_edit";
            this.btn_edit.Size = new System.Drawing.Size(50, 50);
            this.btn_edit.TabIndex = 60;
            this.btn_edit.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btn_edit.UseVisualStyleBackColor = false;
            this.btn_edit.Click += new System.EventHandler(this.btn_edit_Click);
            // 
            // lblSave
            // 
            this.lblSave.AutoSize = true;
            this.lblSave.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSave.Location = new System.Drawing.Point(17, 172);
            this.lblSave.Name = "lblSave";
            this.lblSave.Size = new System.Drawing.Size(43, 16);
            this.lblSave.TabIndex = 2;
            this.lblSave.Text = "Save";
            // 
            // lblEdit
            // 
            this.lblEdit.AutoSize = true;
            this.lblEdit.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEdit.Location = new System.Drawing.Point(19, 80);
            this.lblEdit.Name = "lblEdit";
            this.lblEdit.Size = new System.Drawing.Size(35, 16);
            this.lblEdit.TabIndex = 2;
            this.lblEdit.Text = "Edit";
            // 
            // dgv_Nozzle
            // 
            this.dgv_Nozzle.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgv_Nozzle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Nozzle.ContextMenuStrip = this.contextMenuStrip1;
            this.dgv_Nozzle.Location = new System.Drawing.Point(42, 93);
            this.dgv_Nozzle.Name = "dgv_Nozzle";
            this.dgv_Nozzle.RowHeadersWidth = 51;
            this.dgv_Nozzle.Size = new System.Drawing.Size(829, 224);
            this.dgv_Nozzle.TabIndex = 2;
            this.dgv_Nozzle.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_Nozzle_CellContentClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.moveToolStripMenuItem,
            this.teachToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(105, 48);
            // 
            // moveToolStripMenuItem
            // 
            this.moveToolStripMenuItem.Name = "moveToolStripMenuItem";
            this.moveToolStripMenuItem.Size = new System.Drawing.Size(104, 22);
            this.moveToolStripMenuItem.Text = "Move";
            this.moveToolStripMenuItem.Click += new System.EventHandler(this.moveToolStripMenuItem_Click);
            // 
            // teachToolStripMenuItem
            // 
            this.teachToolStripMenuItem.Name = "teachToolStripMenuItem";
            this.teachToolStripMenuItem.Size = new System.Drawing.Size(104, 22);
            this.teachToolStripMenuItem.Text = "Teach";
            this.teachToolStripMenuItem.Click += new System.EventHandler(this.teachToolStripMenuItem_Click);
            // 
            // cmb_Nozzle
            // 
            this.cmb_Nozzle.FormattingEnabled = true;
            this.cmb_Nozzle.Items.AddRange(new object[] {
            "Nozzle1",
            "Nozzle2",
            "Nozzle1_Train",
            "Nozzle2_Train",
            "Final"});
            this.cmb_Nozzle.Location = new System.Drawing.Point(204, 41);
            this.cmb_Nozzle.Name = "cmb_Nozzle";
            this.cmb_Nozzle.Size = new System.Drawing.Size(121, 24);
            this.cmb_Nozzle.TabIndex = 1;
            this.cmb_Nozzle.SelectedIndexChanged += new System.EventHandler(this.cmb_Nozzle_SelectedIndexChanged);
            // 
            // lbl_Nozzle
            // 
            this.lbl_Nozzle.AutoSize = true;
            this.lbl_Nozzle.Location = new System.Drawing.Point(59, 41);
            this.lbl_Nozzle.Name = "lbl_Nozzle";
            this.lbl_Nozzle.Size = new System.Drawing.Size(104, 16);
            this.lbl_Nozzle.TabIndex = 0;
            this.lbl_Nozzle.Text = "Select Nozzle";
            // 
            // tabRepeatability
            // 
            this.tabRepeatability.Controls.Add(this.grpScan);
            this.tabRepeatability.Location = new System.Drawing.Point(4, 25);
            this.tabRepeatability.Name = "tabRepeatability";
            this.tabRepeatability.Size = new System.Drawing.Size(1010, 551);
            this.tabRepeatability.TabIndex = 5;
            this.tabRepeatability.Text = "Repeatability";
            this.tabRepeatability.UseVisualStyleBackColor = true;
            // 
            // grpScan
            // 
            this.grpScan.Controls.Add(this.lblchoosescanner);
            this.grpScan.Controls.Add(this.lblRuncountTimeVal);
            this.grpScan.Controls.Add(this.button5);
            this.grpScan.Controls.Add(this.button4);
            this.grpScan.Controls.Add(this.lblRunningRepeatabilityCount);
            this.grpScan.Controls.Add(this.txtRepetabilityCountValue);
            this.grpScan.Controls.Add(this.lblRepeatabilityTotalCount);
            this.grpScan.Controls.Add(this.rdoScan1);
            this.grpScan.Location = new System.Drawing.Point(130, 34);
            this.grpScan.Name = "grpScan";
            this.grpScan.Size = new System.Drawing.Size(369, 331);
            this.grpScan.TabIndex = 1;
            this.grpScan.TabStop = false;
            this.grpScan.Text = "Scanner Static Test";
            // 
            // lblchoosescanner
            // 
            this.lblchoosescanner.AutoSize = true;
            this.lblchoosescanner.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblchoosescanner.Location = new System.Drawing.Point(37, 76);
            this.lblchoosescanner.Name = "lblchoosescanner";
            this.lblchoosescanner.Size = new System.Drawing.Size(120, 16);
            this.lblchoosescanner.TabIndex = 192;
            this.lblchoosescanner.Text = "ChooseScanner :";
            // 
            // lblRuncountTimeVal
            // 
            this.lblRuncountTimeVal.AutoSize = true;
            this.lblRuncountTimeVal.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRuncountTimeVal.Location = new System.Drawing.Point(243, 188);
            this.lblRuncountTimeVal.Name = "lblRuncountTimeVal";
            this.lblRuncountTimeVal.Size = new System.Drawing.Size(15, 16);
            this.lblRuncountTimeVal.TabIndex = 191;
            this.lblRuncountTimeVal.Text = "0";
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(94)))), ((int)(((byte)(133)))));
            this.button5.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button5.ForeColor = System.Drawing.Color.White;
            this.button5.Location = new System.Drawing.Point(204, 256);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(99, 35);
            this.button5.TabIndex = 190;
            this.button5.Text = "Stop";
            this.button5.UseVisualStyleBackColor = false;
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(94)))), ((int)(((byte)(133)))));
            this.button4.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.ForeColor = System.Drawing.Color.White;
            this.button4.Location = new System.Drawing.Point(58, 256);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(99, 35);
            this.button4.TabIndex = 189;
            this.button4.Text = "Start";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // lblRunningRepeatabilityCount
            // 
            this.lblRunningRepeatabilityCount.AutoSize = true;
            this.lblRunningRepeatabilityCount.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRunningRepeatabilityCount.Location = new System.Drawing.Point(37, 187);
            this.lblRunningRepeatabilityCount.Name = "lblRunningRepeatabilityCount";
            this.lblRunningRepeatabilityCount.Size = new System.Drawing.Size(193, 16);
            this.lblRunningRepeatabilityCount.TabIndex = 187;
            this.lblRunningRepeatabilityCount.Text = "RunningRepeatabilityCount :";
            // 
            // txtRepetabilityCountValue
            // 
            this.txtRepetabilityCountValue.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRepetabilityCountValue.Location = new System.Drawing.Point(233, 129);
            this.txtRepetabilityCountValue.Name = "txtRepetabilityCountValue";
            this.txtRepetabilityCountValue.Size = new System.Drawing.Size(63, 23);
            this.txtRepetabilityCountValue.TabIndex = 186;
            // 
            // lblRepeatabilityTotalCount
            // 
            this.lblRepeatabilityTotalCount.AutoSize = true;
            this.lblRepeatabilityTotalCount.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRepeatabilityTotalCount.Location = new System.Drawing.Point(37, 130);
            this.lblRepeatabilityTotalCount.Name = "lblRepeatabilityTotalCount";
            this.lblRepeatabilityTotalCount.Size = new System.Drawing.Size(175, 16);
            this.lblRepeatabilityTotalCount.TabIndex = 185;
            this.lblRepeatabilityTotalCount.Text = "RepeatabilityTotalCount :";
            // 
            // rdoScan1
            // 
            this.rdoScan1.AutoSize = true;
            this.rdoScan1.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoScan1.Location = new System.Drawing.Point(178, 76);
            this.rdoScan1.Name = "rdoScan1";
            this.rdoScan1.Size = new System.Drawing.Size(87, 20);
            this.rdoScan1.TabIndex = 1;
            this.rdoScan1.TabStop = true;
            this.rdoScan1.Text = "Scanner1";
            this.rdoScan1.UseVisualStyleBackColor = true;
            this.rdoScan1.CheckedChanged += new System.EventHandler(this.rdoScanner1_CheckedChanged);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(32, 19);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.tabControl5);
            this.tabPage1.Location = new System.Drawing.Point(4, 40);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(1016, 576);
            this.tabPage1.TabIndex = 9;
            this.tabPage1.Text = "SFC & PDCA Settings";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabControl5
            // 
            this.tabControl5.Controls.Add(this.tabPage23);
            this.tabControl5.Controls.Add(this.tabPage8);
            this.tabControl5.Controls.Add(this.tabPage12);
            this.tabControl5.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl5.Location = new System.Drawing.Point(-3, 1);
            this.tabControl5.Name = "tabControl5";
            this.tabControl5.SelectedIndex = 0;
            this.tabControl5.Size = new System.Drawing.Size(1018, 579);
            this.tabControl5.TabIndex = 161;
            // 
            // tabPage23
            // 
            this.tabPage23.BackColor = System.Drawing.Color.White;
            this.tabPage23.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tabPage23.Controls.Add(this.button23);
            this.tabPage23.Controls.Add(this.button24);
            this.tabPage23.Controls.Add(this.AE_LIMITS);
            this.tabPage23.Location = new System.Drawing.Point(4, 26);
            this.tabPage23.Name = "tabPage23";
            this.tabPage23.Padding = new System.Windows.Forms.Padding(3, 3, 3, 3);
            this.tabPage23.Size = new System.Drawing.Size(1010, 549);
            this.tabPage23.TabIndex = 1;
            this.tabPage23.Text = "AE Limits (Production)";
            // 
            // button23
            // 
            this.button23.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(94)))), ((int)(((byte)(133)))));
            this.button23.Enabled = false;
            this.button23.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button23.ForeColor = System.Drawing.Color.White;
            this.button23.Location = new System.Drawing.Point(552, 502);
            this.button23.Name = "button23";
            this.button23.Size = new System.Drawing.Size(99, 35);
            this.button23.TabIndex = 161;
            this.button23.Text = "Save";
            this.button23.UseVisualStyleBackColor = false;
            this.button23.Click += new System.EventHandler(this.button23_Click);
            // 
            // button24
            // 
            this.button24.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(94)))), ((int)(((byte)(133)))));
            this.button24.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button24.ForeColor = System.Drawing.Color.White;
            this.button24.Location = new System.Drawing.Point(447, 502);
            this.button24.Name = "button24";
            this.button24.Size = new System.Drawing.Size(99, 35);
            this.button24.TabIndex = 160;
            this.button24.Text = "Edit";
            this.button24.UseVisualStyleBackColor = false;
            this.button24.Click += new System.EventHandler(this.button24_Click);
            // 
            // AE_LIMITS
            // 
            this.AE_LIMITS.AllowUserToAddRows = false;
            this.AE_LIMITS.AllowUserToDeleteRows = false;
            this.AE_LIMITS.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.AE_LIMITS.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.AE_LIMITS.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.AE_LIMITS.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.AE_LIMITS.DefaultCellStyle = dataGridViewCellStyle2;
            this.AE_LIMITS.EnableHeadersVisualStyles = false;
            this.AE_LIMITS.GridColor = System.Drawing.Color.Black;
            this.AE_LIMITS.Location = new System.Drawing.Point(2, 2);
            this.AE_LIMITS.Name = "AE_LIMITS";
            this.AE_LIMITS.RowHeadersVisible = false;
            this.AE_LIMITS.RowHeadersWidth = 51;
            this.AE_LIMITS.Size = new System.Drawing.Size(1002, 493);
            this.AE_LIMITS.TabIndex = 155;
            // 
            // tabPage8
            // 
            this.tabPage8.Controls.Add(this.CPK_Save);
            this.tabPage8.Controls.Add(this.CPK_Edit);
            this.tabPage8.Controls.Add(this.CPK_dataGridView2);
            this.tabPage8.Location = new System.Drawing.Point(4, 26);
            this.tabPage8.Name = "tabPage8";
            this.tabPage8.Size = new System.Drawing.Size(1010, 549);
            this.tabPage8.TabIndex = 2;
            this.tabPage8.Text = "AE Limits (CPK)";
            this.tabPage8.UseVisualStyleBackColor = true;
            // 
            // CPK_Save
            // 
            this.CPK_Save.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(94)))), ((int)(((byte)(133)))));
            this.CPK_Save.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CPK_Save.ForeColor = System.Drawing.Color.White;
            this.CPK_Save.Location = new System.Drawing.Point(547, 503);
            this.CPK_Save.Name = "CPK_Save";
            this.CPK_Save.Size = new System.Drawing.Size(99, 35);
            this.CPK_Save.TabIndex = 164;
            this.CPK_Save.Text = "Save";
            this.CPK_Save.UseVisualStyleBackColor = false;
            this.CPK_Save.Click += new System.EventHandler(this.CPK_Save_Click);
            // 
            // CPK_Edit
            // 
            this.CPK_Edit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(94)))), ((int)(((byte)(133)))));
            this.CPK_Edit.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CPK_Edit.ForeColor = System.Drawing.Color.White;
            this.CPK_Edit.Location = new System.Drawing.Point(442, 503);
            this.CPK_Edit.Name = "CPK_Edit";
            this.CPK_Edit.Size = new System.Drawing.Size(99, 35);
            this.CPK_Edit.TabIndex = 163;
            this.CPK_Edit.Text = "Edit";
            this.CPK_Edit.UseVisualStyleBackColor = false;
            // 
            // CPK_dataGridView2
            // 
            this.CPK_dataGridView2.AllowUserToAddRows = false;
            this.CPK_dataGridView2.AllowUserToDeleteRows = false;
            this.CPK_dataGridView2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.CPK_dataGridView2.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.CPK_dataGridView2.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.CPK_dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.CPK_dataGridView2.DefaultCellStyle = dataGridViewCellStyle4;
            this.CPK_dataGridView2.EnableHeadersVisualStyles = false;
            this.CPK_dataGridView2.GridColor = System.Drawing.Color.Black;
            this.CPK_dataGridView2.Location = new System.Drawing.Point(3, 3);
            this.CPK_dataGridView2.Name = "CPK_dataGridView2";
            this.CPK_dataGridView2.RowHeadersVisible = false;
            this.CPK_dataGridView2.RowHeadersWidth = 51;
            this.CPK_dataGridView2.Size = new System.Drawing.Size(1006, 493);
            this.CPK_dataGridView2.TabIndex = 162;
            // 
            // tabPage12
            // 
            this.tabPage12.Controls.Add(this.button31);
            this.tabPage12.Controls.Add(this.button32);
            this.tabPage12.Controls.Add(this.GRR_dataGridView3);
            this.tabPage12.Location = new System.Drawing.Point(4, 26);
            this.tabPage12.Name = "tabPage12";
            this.tabPage12.Size = new System.Drawing.Size(1010, 549);
            this.tabPage12.TabIndex = 3;
            this.tabPage12.Text = "AE Limits (GRR)";
            this.tabPage12.UseVisualStyleBackColor = true;
            // 
            // button31
            // 
            this.button31.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(94)))), ((int)(((byte)(133)))));
            this.button31.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button31.ForeColor = System.Drawing.Color.White;
            this.button31.Location = new System.Drawing.Point(541, 503);
            this.button31.Name = "button31";
            this.button31.Size = new System.Drawing.Size(99, 35);
            this.button31.TabIndex = 164;
            this.button31.Text = "Save";
            this.button31.UseVisualStyleBackColor = false;
            this.button31.Click += new System.EventHandler(this.button31_Click);
            // 
            // button32
            // 
            this.button32.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(94)))), ((int)(((byte)(133)))));
            this.button32.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button32.ForeColor = System.Drawing.Color.White;
            this.button32.Location = new System.Drawing.Point(436, 503);
            this.button32.Name = "button32";
            this.button32.Size = new System.Drawing.Size(99, 35);
            this.button32.TabIndex = 163;
            this.button32.Text = "Edit";
            this.button32.UseVisualStyleBackColor = false;
            // 
            // GRR_dataGridView3
            // 
            this.GRR_dataGridView3.AllowUserToAddRows = false;
            this.GRR_dataGridView3.AllowUserToDeleteRows = false;
            this.GRR_dataGridView3.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.GRR_dataGridView3.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.GRR_dataGridView3.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.GRR_dataGridView3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.GRR_dataGridView3.DefaultCellStyle = dataGridViewCellStyle6;
            this.GRR_dataGridView3.EnableHeadersVisualStyles = false;
            this.GRR_dataGridView3.GridColor = System.Drawing.Color.Black;
            this.GRR_dataGridView3.Location = new System.Drawing.Point(3, 3);
            this.GRR_dataGridView3.Name = "GRR_dataGridView3";
            this.GRR_dataGridView3.RowHeadersVisible = false;
            this.GRR_dataGridView3.RowHeadersWidth = 51;
            this.GRR_dataGridView3.Size = new System.Drawing.Size(1006, 493);
            this.GRR_dataGridView3.TabIndex = 162;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.button1);
            this.tabPage3.Controls.Add(this.button2);
            this.tabPage3.Controls.Add(this.Table_Vision_Settings);
            this.tabPage3.Location = new System.Drawing.Point(4, 40);
            this.tabPage3.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(1016, 576);
            this.tabPage3.TabIndex = 10;
            this.tabPage3.Text = "Vision Settings";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(94)))), ((int)(((byte)(133)))));
            this.button1.Enabled = false;
            this.button1.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(495, 525);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(99, 35);
            this.button1.TabIndex = 163;
            this.button1.Text = "Save";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(94)))), ((int)(((byte)(133)))));
            this.button2.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Location = new System.Drawing.Point(390, 525);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(99, 35);
            this.button2.TabIndex = 162;
            this.button2.Text = "Edit";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Table_Vision_Settings
            // 
            this.Table_Vision_Settings.AllowUserToAddRows = false;
            this.Table_Vision_Settings.AllowUserToDeleteRows = false;
            this.Table_Vision_Settings.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.Table_Vision_Settings.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Verdana", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Table_Vision_Settings.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.Table_Vision_Settings.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Verdana", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.Table_Vision_Settings.DefaultCellStyle = dataGridViewCellStyle8;
            this.Table_Vision_Settings.EnableHeadersVisualStyles = false;
            this.Table_Vision_Settings.GridColor = System.Drawing.Color.Black;
            this.Table_Vision_Settings.Location = new System.Drawing.Point(8, 18);
            this.Table_Vision_Settings.Name = "Table_Vision_Settings";
            this.Table_Vision_Settings.RowHeadersVisible = false;
            this.Table_Vision_Settings.RowHeadersWidth = 51;
            this.Table_Vision_Settings.Size = new System.Drawing.Size(1002, 493);
            this.Table_Vision_Settings.TabIndex = 156;
            this.Table_Vision_Settings.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.Table_Vision_Settings_CellMouseClick);
            // 
            // MotorDebug
            // 
            this.MotorDebug.Controls.Add(this.panel2);
            this.MotorDebug.Location = new System.Drawing.Point(4, 40);
            this.MotorDebug.Name = "MotorDebug";
            this.MotorDebug.Size = new System.Drawing.Size(1016, 576);
            this.MotorDebug.TabIndex = 8;
            this.MotorDebug.Text = "Axis Parameter Settings";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnSave);
            this.panel2.Controls.Add(this.btnedit);
            this.panel2.Controls.Add(this.grbMotor);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1016, 576);
            this.panel2.TabIndex = 0;
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(94)))), ((int)(((byte)(133)))));
            this.btnSave.Enabled = false;
            this.btnSave.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(538, 530);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(92, 35);
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
            this.btnedit.Location = new System.Drawing.Point(419, 530);
            this.btnedit.Name = "btnedit";
            this.btnedit.Size = new System.Drawing.Size(92, 35);
            this.btnedit.TabIndex = 72;
            this.btnedit.Text = "Edit";
            this.btnedit.UseVisualStyleBackColor = false;
            this.btnedit.Click += new System.EventHandler(this.btnedit_Click);
            // 
            // grbMotor
            // 
            this.grbMotor.Controls.Add(this.Axis_Settings);
            this.grbMotor.Location = new System.Drawing.Point(3, 4);
            this.grbMotor.Name = "grbMotor";
            this.grbMotor.Size = new System.Drawing.Size(1005, 521);
            this.grbMotor.TabIndex = 91;
            this.grbMotor.TabStop = false;
            // 
            // Axis_Settings
            // 
            this.Axis_Settings.AllowUserToAddRows = false;
            this.Axis_Settings.AllowUserToDeleteRows = false;
            this.Axis_Settings.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.Axis_Settings.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.Axis_Settings.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Verdana", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Axis_Settings.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.Axis_Settings.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Verdana", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.Axis_Settings.DefaultCellStyle = dataGridViewCellStyle10;
            this.Axis_Settings.EnableHeadersVisualStyles = false;
            this.Axis_Settings.Location = new System.Drawing.Point(0, 25);
            this.Axis_Settings.MultiSelect = false;
            this.Axis_Settings.Name = "Axis_Settings";
            this.Axis_Settings.RowHeadersVisible = false;
            this.Axis_Settings.RowHeadersWidth = 51;
            this.Axis_Settings.Size = new System.Drawing.Size(1003, 494);
            this.Axis_Settings.TabIndex = 90;
            this.Axis_Settings.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.Axis_Settings_CellMouseClick);
            this.Axis_Settings.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.Axis_Settings_EditingControlShowing);
            // 
            // IODiagnostics
            // 
            this.IODiagnostics.Controls.Add(this.tabIO);
            this.IODiagnostics.Location = new System.Drawing.Point(4, 40);
            this.IODiagnostics.Name = "IODiagnostics";
            this.IODiagnostics.Size = new System.Drawing.Size(1016, 576);
            this.IODiagnostics.TabIndex = 4;
            this.IODiagnostics.Text = "I/O Diagnostics";
            this.IODiagnostics.UseVisualStyleBackColor = true;
            // 
            // tabIO
            // 
            this.tabIO.Controls.Add(this.btn_input);
            this.tabIO.Controls.Add(this.tabPage10);
            this.tabIO.Dock = System.Windows.Forms.DockStyle.Top;
            this.tabIO.Font = new System.Drawing.Font("Verdana", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabIO.Location = new System.Drawing.Point(0, 0);
            this.tabIO.Name = "tabIO";
            this.tabIO.SelectedIndex = 0;
            this.tabIO.Size = new System.Drawing.Size(1016, 578);
            this.tabIO.TabIndex = 5;
            // 
            // btn_input
            // 
            this.btn_input.BackColor = System.Drawing.Color.White;
            this.btn_input.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.btn_input.Controls.Add(this.txtSearchForOutput);
            this.btn_input.Controls.Add(this.txtSearchForInput);
            this.btn_input.Controls.Add(this.label30);
            this.btn_input.Controls.Add(this.label29);
            this.btn_input.Controls.Add(this.DGV_Output1);
            this.btn_input.Controls.Add(this.DGV_Input1);
            this.btn_input.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_input.Location = new System.Drawing.Point(4, 25);
            this.btn_input.Name = "btn_input";
            this.btn_input.Size = new System.Drawing.Size(1008, 549);
            this.btn_input.TabIndex = 7;
            this.btn_input.Text = "Digital I/O";
            // 
            // txtSearchForOutput
            // 
            this.txtSearchForOutput.Location = new System.Drawing.Point(695, 16);
            this.txtSearchForOutput.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtSearchForOutput.Name = "txtSearchForOutput";
            this.txtSearchForOutput.Size = new System.Drawing.Size(250, 23);
            this.txtSearchForOutput.TabIndex = 10;
            this.txtSearchForOutput.TextChanged += new System.EventHandler(this.txtSearchForOutput_TextChanged);
            // 
            // txtSearchForInput
            // 
            this.txtSearchForInput.Location = new System.Drawing.Point(142, 14);
            this.txtSearchForInput.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtSearchForInput.Name = "txtSearchForInput";
            this.txtSearchForInput.Size = new System.Drawing.Size(250, 23);
            this.txtSearchForInput.TabIndex = 3;
            this.txtSearchForInput.TextChanged += new System.EventHandler(this.txtSearchForInput_TextChanged);
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Location = new System.Drawing.Point(582, 16);
            this.label30.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(111, 16);
            this.label30.TabIndex = 9;
            this.label30.Text = "Search Output";
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Location = new System.Drawing.Point(39, 16);
            this.label29.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(100, 16);
            this.label29.TabIndex = 8;
            this.label29.Text = "Search Input";
            // 
            // DGV_Output1
            // 
            this.DGV_Output1.AllowUserToAddRows = false;
            this.DGV_Output1.AllowUserToDeleteRows = false;
            this.DGV_Output1.AllowUserToResizeColumns = false;
            this.DGV_Output1.AllowUserToResizeRows = false;
            this.DGV_Output1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV_Output1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewImageColumn1,
            this.dataGridViewTextBoxColumn1});
            this.DGV_Output1.Location = new System.Drawing.Point(512, 47);
            this.DGV_Output1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.DGV_Output1.Name = "DGV_Output1";
            this.DGV_Output1.RowHeadersVisible = false;
            this.DGV_Output1.RowHeadersWidth = 51;
            this.DGV_Output1.RowTemplate.Height = 24;
            this.DGV_Output1.Size = new System.Drawing.Size(489, 496);
            this.DGV_Output1.TabIndex = 5;
            this.DGV_Output1.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DGV_Output1_CellMouseClick);
            // 
            // dataGridViewImageColumn1
            // 
            this.dataGridViewImageColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.dataGridViewImageColumn1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.dataGridViewImageColumn1.HeaderText = "On/Off";
            this.dataGridViewImageColumn1.MinimumWidth = 6;
            this.dataGridViewImageColumn1.Name = "dataGridViewImageColumn1";
            this.dataGridViewImageColumn1.ReadOnly = true;
            this.dataGridViewImageColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewImageColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dataGridViewImageColumn1.Width = 80;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn1.HeaderText = "Output Name";
            this.dataGridViewTextBoxColumn1.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // DGV_Input1
            // 
            this.DGV_Input1.AllowUserToAddRows = false;
            this.DGV_Input1.AllowUserToDeleteRows = false;
            this.DGV_Input1.AllowUserToResizeColumns = false;
            this.DGV_Input1.AllowUserToResizeRows = false;
            this.DGV_Input1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV_Input1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.InOnOff,
            this.InputName});
            this.DGV_Input1.Location = new System.Drawing.Point(10, 47);
            this.DGV_Input1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.DGV_Input1.Name = "DGV_Input1";
            this.DGV_Input1.RowHeadersVisible = false;
            this.DGV_Input1.RowHeadersWidth = 51;
            this.DGV_Input1.RowTemplate.Height = 24;
            this.DGV_Input1.Size = new System.Drawing.Size(489, 496);
            this.DGV_Input1.TabIndex = 4;
            // 
            // InOnOff
            // 
            this.InOnOff.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.InOnOff.HeaderText = "On/Off";
            this.InOnOff.Image = ((System.Drawing.Image)(resources.GetObject("InOnOff.Image")));
            this.InOnOff.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.InOnOff.MinimumWidth = 6;
            this.InOnOff.Name = "InOnOff";
            this.InOnOff.ReadOnly = true;
            this.InOnOff.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.InOnOff.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.InOnOff.Width = 80;
            // 
            // InputName
            // 
            this.InputName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.InputName.HeaderText = "Input Name";
            this.InputName.MinimumWidth = 6;
            this.InputName.Name = "InputName";
            this.InputName.ReadOnly = true;
            // 
            // tabPage10
            // 
            this.tabPage10.Controls.Add(this.btnSveLod);
            this.tabPage10.Controls.Add(this.LoaddellChk);
            this.tabPage10.Controls.Add(this.label4);
            this.tabPage10.Controls.Add(this.dgvAI);
            this.tabPage10.Location = new System.Drawing.Point(4, 25);
            this.tabPage10.Name = "tabPage10";
            this.tabPage10.Size = new System.Drawing.Size(1010, 549);
            this.tabPage10.TabIndex = 5;
            this.tabPage10.Text = "Analog I/O";
            this.tabPage10.UseVisualStyleBackColor = true;
            // 
            // btnSveLod
            // 
            this.btnSveLod.Location = new System.Drawing.Point(882, 432);
            this.btnSveLod.Name = "btnSveLod";
            this.btnSveLod.Size = new System.Drawing.Size(75, 36);
            this.btnSveLod.TabIndex = 29;
            this.btnSveLod.Text = "Save";
            this.btnSveLod.UseVisualStyleBackColor = true;
            this.btnSveLod.Click += new System.EventHandler(this.btnSveLod_Click);
            this.btnSveLod.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnSveLod_MouseUp);
            // 
            // LoaddellChk
            // 
            this.LoaddellChk.Appearance = System.Windows.Forms.Appearance.Button;
            this.LoaddellChk.AutoSize = true;
            this.LoaddellChk.FlatAppearance.CheckedBackColor = System.Drawing.Color.LimeGreen;
            this.LoaddellChk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LoaddellChk.Font = new System.Drawing.Font("Verdana", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LoaddellChk.Location = new System.Drawing.Point(880, 370);
            this.LoaddellChk.Name = "LoaddellChk";
            this.LoaddellChk.Size = new System.Drawing.Size(77, 28);
            this.LoaddellChk.TabIndex = 28;
            this.LoaddellChk.Text = "Loadcell";
            this.LoaddellChk.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(467, 57);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(105, 16);
            this.label4.TabIndex = 6;
            this.label4.Text = "Analog_Input";
            // 
            // dgvAI
            // 
            this.dgvAI.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle11.BackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Verdana", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle11.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvAI.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle11;
            this.dgvAI.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAI.EnableHeadersVisualStyles = false;
            this.dgvAI.Location = new System.Drawing.Point(280, 110);
            this.dgvAI.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dgvAI.Name = "dgvAI";
            this.dgvAI.RowHeadersVisible = false;
            this.dgvAI.RowHeadersWidth = 51;
            this.dgvAI.RowTemplate.Height = 24;
            this.dgvAI.Size = new System.Drawing.Size(522, 99);
            this.dgvAI.TabIndex = 4;
            // 
            // Device
            // 
            this.Device.Controls.Add(this.DeviceSettingsPanel);
            this.Device.Location = new System.Drawing.Point(4, 40);
            this.Device.Name = "Device";
            this.Device.Size = new System.Drawing.Size(967, 576);
            this.Device.TabIndex = 3;
            this.Device.Text = "Device Settings";
            this.Device.UseVisualStyleBackColor = true;
            // 
            // DeviceSettingsPanel
            // 
            this.DeviceSettingsPanel.Controls.Add(this.panel4);
            this.DeviceSettingsPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DeviceSettingsPanel.Location = new System.Drawing.Point(0, 0);
            this.DeviceSettingsPanel.Name = "DeviceSettingsPanel";
            this.DeviceSettingsPanel.Size = new System.Drawing.Size(967, 576);
            this.DeviceSettingsPanel.TabIndex = 0;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.White;
            this.panel4.Controls.Add(this.Enable_4_3);
            this.panel4.Controls.Add(this.groupBox2);
            this.panel4.Controls.Add(this.groupBox1);
            this.panel4.Controls.Add(this.tabConnectionDetails);
            this.panel4.Controls.Add(this.btnEditSettings);
            this.panel4.Controls.Add(this.btnSaveSettings);
            this.panel4.Controls.Add(this.grpSystemSettings);
            this.panel4.Controls.Add(this.radioButtongrr);
            this.panel4.Location = new System.Drawing.Point(3, 3);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1008, 571);
            this.panel4.TabIndex = 105;
            // 
            // Enable_4_3
            // 
            this.Enable_4_3.Appearance = System.Windows.Forms.Appearance.Button;
            this.Enable_4_3.AutoSize = true;
            this.Enable_4_3.FlatAppearance.CheckedBackColor = System.Drawing.Color.LimeGreen;
            this.Enable_4_3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Enable_4_3.Font = new System.Drawing.Font("Verdana", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Enable_4_3.Location = new System.Drawing.Point(23, 487);
            this.Enable_4_3.Name = "Enable_4_3";
            this.Enable_4_3.Size = new System.Drawing.Size(48, 28);
            this.Enable_4_3.TabIndex = 30;
            this.Enable_4_3.Text = "4X3";
            this.Enable_4_3.UseVisualStyleBackColor = true;
            this.Enable_4_3.Visible = false;
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.White;
            this.groupBox2.Controls.Add(this.K_Model);
            this.groupBox2.Controls.Add(this.Nk_Model);
            this.groupBox2.Controls.Add(this.Four_Graphit);
            this.groupBox2.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(481, 427);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(469, 86);
            this.groupBox2.TabIndex = 104;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Running ";
            // 
            // K_Model
            // 
            this.K_Model.Appearance = System.Windows.Forms.Appearance.Button;
            this.K_Model.AutoSize = true;
            this.K_Model.FlatAppearance.CheckedBackColor = System.Drawing.Color.LimeGreen;
            this.K_Model.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.K_Model.Font = new System.Drawing.Font("Verdana", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.K_Model.Location = new System.Drawing.Point(18, 29);
            this.K_Model.Name = "K_Model";
            this.K_Model.Size = new System.Drawing.Size(77, 28);
            this.K_Model.TabIndex = 30;
            this.K_Model.Text = "K Model";
            this.K_Model.UseVisualStyleBackColor = true;
            // 
            // Nk_Model
            // 
            this.Nk_Model.Appearance = System.Windows.Forms.Appearance.Button;
            this.Nk_Model.AutoSize = true;
            this.Nk_Model.FlatAppearance.CheckedBackColor = System.Drawing.Color.LimeGreen;
            this.Nk_Model.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Nk_Model.Font = new System.Drawing.Font("Verdana", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Nk_Model.Location = new System.Drawing.Point(102, 29);
            this.Nk_Model.Name = "Nk_Model";
            this.Nk_Model.Size = new System.Drawing.Size(88, 28);
            this.Nk_Model.TabIndex = 28;
            this.Nk_Model.Text = "NK Model";
            this.Nk_Model.UseVisualStyleBackColor = true;
            // 
            // Four_Graphit
            // 
            this.Four_Graphit.Appearance = System.Windows.Forms.Appearance.Button;
            this.Four_Graphit.AutoSize = true;
            this.Four_Graphit.FlatAppearance.CheckedBackColor = System.Drawing.Color.LimeGreen;
            this.Four_Graphit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Four_Graphit.Font = new System.Drawing.Font("Verdana", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Four_Graphit.Location = new System.Drawing.Point(196, 29);
            this.Four_Graphit.Name = "Four_Graphit";
            this.Four_Graphit.Size = new System.Drawing.Size(111, 28);
            this.Four_Graphit.TabIndex = 29;
            this.Four_Graphit.Text = "Four Graphit";
            this.Four_Graphit.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.White;
            this.groupBox1.Controls.Add(this.Semimachk);
            this.groupBox1.Controls.Add(this.SFC_PDCA_Bypass);
            this.groupBox1.Controls.Add(this.Buzzer_Bypass);
            this.groupBox1.Controls.Add(this.Safety_door_bypass);
            this.groupBox1.Controls.Add(this.Barcode_scanner_bypass);
            this.groupBox1.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(726, 76);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(219, 333);
            this.groupBox1.TabIndex = 103;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Bypass Settings";
            // 
            // Semimachk
            // 
            this.Semimachk.Appearance = System.Windows.Forms.Appearance.Button;
            this.Semimachk.AutoSize = true;
            this.Semimachk.FlatAppearance.CheckedBackColor = System.Drawing.Color.LimeGreen;
            this.Semimachk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Semimachk.Font = new System.Drawing.Font("Verdana", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Semimachk.Location = new System.Drawing.Point(24, 150);
            this.Semimachk.Name = "Semimachk";
            this.Semimachk.Size = new System.Drawing.Size(136, 28);
            this.Semimachk.TabIndex = 27;
            this.Semimachk.Text = "SEMIMA Bypass";
            this.Semimachk.UseVisualStyleBackColor = true;
            // 
            // SFC_PDCA_Bypass
            // 
            this.SFC_PDCA_Bypass.Appearance = System.Windows.Forms.Appearance.Button;
            this.SFC_PDCA_Bypass.AutoSize = true;
            this.SFC_PDCA_Bypass.FlatAppearance.CheckedBackColor = System.Drawing.Color.LimeGreen;
            this.SFC_PDCA_Bypass.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SFC_PDCA_Bypass.Font = new System.Drawing.Font("Verdana", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SFC_PDCA_Bypass.Location = new System.Drawing.Point(24, 113);
            this.SFC_PDCA_Bypass.Name = "SFC_PDCA_Bypass";
            this.SFC_PDCA_Bypass.Size = new System.Drawing.Size(157, 28);
            this.SFC_PDCA_Bypass.TabIndex = 26;
            this.SFC_PDCA_Bypass.Text = "SFC_PDCA Bypass";
            this.SFC_PDCA_Bypass.UseVisualStyleBackColor = true;
            // 
            // Buzzer_Bypass
            // 
            this.Buzzer_Bypass.Appearance = System.Windows.Forms.Appearance.Button;
            this.Buzzer_Bypass.AutoSize = true;
            this.Buzzer_Bypass.FlatAppearance.CheckedBackColor = System.Drawing.Color.LimeGreen;
            this.Buzzer_Bypass.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Buzzer_Bypass.Font = new System.Drawing.Font("Verdana", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Buzzer_Bypass.Location = new System.Drawing.Point(24, 80);
            this.Buzzer_Bypass.Name = "Buzzer_Bypass";
            this.Buzzer_Bypass.Size = new System.Drawing.Size(128, 28);
            this.Buzzer_Bypass.TabIndex = 25;
            this.Buzzer_Bypass.Text = "Buzzer Bypass";
            this.Buzzer_Bypass.UseVisualStyleBackColor = true;
            // 
            // Safety_door_bypass
            // 
            this.Safety_door_bypass.Appearance = System.Windows.Forms.Appearance.Button;
            this.Safety_door_bypass.AutoSize = true;
            this.Safety_door_bypass.BackColor = System.Drawing.Color.Transparent;
            this.Safety_door_bypass.FlatAppearance.CheckedBackColor = System.Drawing.Color.LimeGreen;
            this.Safety_door_bypass.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Safety_door_bypass.Font = new System.Drawing.Font("Verdana", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Safety_door_bypass.Location = new System.Drawing.Point(24, 41);
            this.Safety_door_bypass.Name = "Safety_door_bypass";
            this.Safety_door_bypass.Size = new System.Drawing.Size(166, 28);
            this.Safety_door_bypass.TabIndex = 24;
            this.Safety_door_bypass.Text = "Safety Door Bypass";
            this.Safety_door_bypass.UseVisualStyleBackColor = false;
            this.Safety_door_bypass.CheckedChanged += new System.EventHandler(this.Safety_door_bypass_CheckedChanged);
            // 
            // Barcode_scanner_bypass
            // 
            this.Barcode_scanner_bypass.Appearance = System.Windows.Forms.Appearance.Button;
            this.Barcode_scanner_bypass.AutoSize = true;
            this.Barcode_scanner_bypass.Enabled = false;
            this.Barcode_scanner_bypass.FlatAppearance.CheckedBackColor = System.Drawing.Color.LimeGreen;
            this.Barcode_scanner_bypass.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Barcode_scanner_bypass.Font = new System.Drawing.Font("Verdana", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Barcode_scanner_bypass.Location = new System.Drawing.Point(24, 184);
            this.Barcode_scanner_bypass.Name = "Barcode_scanner_bypass";
            this.Barcode_scanner_bypass.Size = new System.Drawing.Size(136, 28);
            this.Barcode_scanner_bypass.TabIndex = 23;
            this.Barcode_scanner_bypass.Text = "Scanner Bypass";
            this.Barcode_scanner_bypass.UseVisualStyleBackColor = true;
            // 
            // tabConnectionDetails
            // 
            this.tabConnectionDetails.Controls.Add(this.tabPage5);
            this.tabConnectionDetails.Controls.Add(this.tabPage6);
            this.tabConnectionDetails.Location = new System.Drawing.Point(36, 76);
            this.tabConnectionDetails.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabConnectionDetails.Name = "tabConnectionDetails";
            this.tabConnectionDetails.SelectedIndex = 0;
            this.tabConnectionDetails.Size = new System.Drawing.Size(417, 280);
            this.tabConnectionDetails.TabIndex = 107;
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.IP_Details_table);
            this.tabPage5.Location = new System.Drawing.Point(4, 26);
            this.tabPage5.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabPage5.Size = new System.Drawing.Size(409, 250);
            this.tabPage5.TabIndex = 0;
            this.tabPage5.Text = "TCP IP";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // IP_Details_table
            // 
            this.IP_Details_table.AllowUserToAddRows = false;
            this.IP_Details_table.AllowUserToDeleteRows = false;
            this.IP_Details_table.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.IP_Details_table.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.IP_Details_table.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle12.BackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Verdana", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle12.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.IP_Details_table.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle12;
            this.IP_Details_table.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle13.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle13.Font = new System.Drawing.Font("Verdana", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle13.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle13.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle13.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.IP_Details_table.DefaultCellStyle = dataGridViewCellStyle13;
            this.IP_Details_table.EnableHeadersVisualStyles = false;
            this.IP_Details_table.Location = new System.Drawing.Point(5, 8);
            this.IP_Details_table.MultiSelect = false;
            this.IP_Details_table.Name = "IP_Details_table";
            this.IP_Details_table.RowHeadersVisible = false;
            this.IP_Details_table.RowHeadersWidth = 51;
            this.IP_Details_table.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.IP_Details_table.Size = new System.Drawing.Size(400, 240);
            this.IP_Details_table.TabIndex = 92;
            this.IP_Details_table.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.IP_Details_table_EditingControlShowing);
            // 
            // tabPage6
            // 
            this.tabPage6.Controls.Add(this.Serial_Comm_table);
            this.tabPage6.Location = new System.Drawing.Point(4, 26);
            this.tabPage6.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabPage6.Size = new System.Drawing.Size(409, 250);
            this.tabPage6.TabIndex = 1;
            this.tabPage6.Text = "Serial Comm";
            this.tabPage6.UseVisualStyleBackColor = true;
            // 
            // Serial_Comm_table
            // 
            this.Serial_Comm_table.AllowUserToAddRows = false;
            this.Serial_Comm_table.AllowUserToDeleteRows = false;
            this.Serial_Comm_table.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.Serial_Comm_table.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.Serial_Comm_table.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle14.BackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle14.Font = new System.Drawing.Font("Verdana", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle14.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle14.SelectionBackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle14.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Serial_Comm_table.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle14;
            this.Serial_Comm_table.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle15.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle15.Font = new System.Drawing.Font("Verdana", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle15.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle15.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle15.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle15.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.Serial_Comm_table.DefaultCellStyle = dataGridViewCellStyle15;
            this.Serial_Comm_table.EnableHeadersVisualStyles = false;
            this.Serial_Comm_table.Location = new System.Drawing.Point(5, 6);
            this.Serial_Comm_table.MultiSelect = false;
            this.Serial_Comm_table.Name = "Serial_Comm_table";
            this.Serial_Comm_table.RowHeadersVisible = false;
            this.Serial_Comm_table.RowHeadersWidth = 51;
            this.Serial_Comm_table.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.Serial_Comm_table.Size = new System.Drawing.Size(400, 240);
            this.Serial_Comm_table.TabIndex = 93;
            this.Serial_Comm_table.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.Serial_Comm_table_CellMouseClick);
            this.Serial_Comm_table.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.Serial_Comm_table_EditingControlShowing);
            // 
            // btnEditSettings
            // 
            this.btnEditSettings.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(94)))), ((int)(((byte)(133)))));
            this.btnEditSettings.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditSettings.ForeColor = System.Drawing.Color.White;
            this.btnEditSettings.Location = new System.Drawing.Point(148, 396);
            this.btnEditSettings.Name = "btnEditSettings";
            this.btnEditSettings.Size = new System.Drawing.Size(110, 35);
            this.btnEditSettings.TabIndex = 105;
            this.btnEditSettings.Text = "Edit";
            this.btnEditSettings.UseVisualStyleBackColor = false;
            this.btnEditSettings.Click += new System.EventHandler(this.btnEditSettings_Click);
            // 
            // btnSaveSettings
            // 
            this.btnSaveSettings.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(94)))), ((int)(((byte)(133)))));
            this.btnSaveSettings.Enabled = false;
            this.btnSaveSettings.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveSettings.ForeColor = System.Drawing.Color.White;
            this.btnSaveSettings.Location = new System.Drawing.Point(292, 396);
            this.btnSaveSettings.Name = "btnSaveSettings";
            this.btnSaveSettings.Size = new System.Drawing.Size(110, 35);
            this.btnSaveSettings.TabIndex = 106;
            this.btnSaveSettings.Text = "Save";
            this.btnSaveSettings.UseVisualStyleBackColor = false;
            this.btnSaveSettings.Click += new System.EventHandler(this.btnSaveSettings_Click);
            // 
            // grpSystemSettings
            // 
            this.grpSystemSettings.BackColor = System.Drawing.Color.White;
            this.grpSystemSettings.Controls.Add(this.Dym_run);
            this.grpSystemSettings.Controls.Add(this.radioButton3);
            this.grpSystemSettings.Controls.Add(this.radioButton2);
            this.grpSystemSettings.Controls.Add(this.radioButton1);
            this.grpSystemSettings.Controls.Add(this.radioButtonDynamic);
            this.grpSystemSettings.Controls.Add(this.radioButtonStatic);
            this.grpSystemSettings.Controls.Add(this.radioButtoncpk);
            this.grpSystemSettings.Controls.Add(this.radioButtondry);
            this.grpSystemSettings.Controls.Add(this.radioButtonProd);
            this.grpSystemSettings.Enabled = false;
            this.grpSystemSettings.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpSystemSettings.Location = new System.Drawing.Point(481, 76);
            this.grpSystemSettings.Name = "grpSystemSettings";
            this.grpSystemSettings.Size = new System.Drawing.Size(239, 332);
            this.grpSystemSettings.TabIndex = 102;
            this.grpSystemSettings.TabStop = false;
            this.grpSystemSettings.Text = "System Settings";
            this.grpSystemSettings.Enter += new System.EventHandler(this.grpSystemSettings_Enter);
            // 
            // Dym_run
            // 
            this.Dym_run.Appearance = System.Windows.Forms.Appearance.Button;
            this.Dym_run.AutoSize = true;
            this.Dym_run.FlatAppearance.CheckedBackColor = System.Drawing.Color.LimeGreen;
            this.Dym_run.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Dym_run.Font = new System.Drawing.Font("Verdana", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Dym_run.Location = new System.Drawing.Point(31, 219);
            this.Dym_run.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Dym_run.Name = "Dym_run";
            this.Dym_run.Size = new System.Drawing.Size(112, 30);
            this.Dym_run.TabIndex = 42;
            this.Dym_run.Text = "Dummy Run";
            this.Dym_run.UseVisualStyleBackColor = true;
            // 
            // radioButton3
            // 
            this.radioButton3.Appearance = System.Windows.Forms.Appearance.Button;
            this.radioButton3.AutoSize = true;
            this.radioButton3.FlatAppearance.CheckedBackColor = System.Drawing.Color.LimeGreen;
            this.radioButton3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.radioButton3.Font = new System.Drawing.Font("Verdana", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButton3.Location = new System.Drawing.Point(31, 289);
            this.radioButton3.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(66, 30);
            this.radioButton3.TabIndex = 40;
            this.radioButton3.Text = "Offline";
            this.radioButton3.UseVisualStyleBackColor = true;
            this.radioButton3.Visible = false;
            // 
            // radioButton2
            // 
            this.radioButton2.Appearance = System.Windows.Forms.Appearance.Button;
            this.radioButton2.AutoSize = true;
            this.radioButton2.FlatAppearance.CheckedBackColor = System.Drawing.Color.LimeGreen;
            this.radioButton2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.radioButton2.Font = new System.Drawing.Font("Verdana", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButton2.Location = new System.Drawing.Point(31, 253);
            this.radioButton2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(65, 30);
            this.radioButton2.TabIndex = 39;
            this.radioButton2.Text = "Online";
            this.radioButton2.UseVisualStyleBackColor = true;
            this.radioButton2.Visible = false;
            // 
            // radioButton1
            // 
            this.radioButton1.Appearance = System.Windows.Forms.Appearance.Button;
            this.radioButton1.AutoSize = true;
            this.radioButton1.FlatAppearance.CheckedBackColor = System.Drawing.Color.LimeGreen;
            this.radioButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.radioButton1.Font = new System.Drawing.Font("Verdana", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButton1.Location = new System.Drawing.Point(101, 289);
            this.radioButton1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(92, 30);
            this.radioButton1.TabIndex = 38;
            this.radioButton1.Text = "CPK Audit";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.Visible = false;
            // 
            // radioButtonDynamic
            // 
            this.radioButtonDynamic.Appearance = System.Windows.Forms.Appearance.Button;
            this.radioButtonDynamic.AutoSize = true;
            this.radioButtonDynamic.FlatAppearance.CheckedBackColor = System.Drawing.Color.LimeGreen;
            this.radioButtonDynamic.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.radioButtonDynamic.Font = new System.Drawing.Font("Verdana", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButtonDynamic.Location = new System.Drawing.Point(31, 185);
            this.radioButtonDynamic.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.radioButtonDynamic.Name = "radioButtonDynamic";
            this.radioButtonDynamic.Size = new System.Drawing.Size(202, 30);
            this.radioButtonDynamic.TabIndex = 37;
            this.radioButtonDynamic.Text = "GRR Dynamic Test Mode";
            this.radioButtonDynamic.UseVisualStyleBackColor = true;
            // 
            // radioButtonStatic
            // 
            this.radioButtonStatic.Appearance = System.Windows.Forms.Appearance.Button;
            this.radioButtonStatic.AutoSize = true;
            this.radioButtonStatic.FlatAppearance.CheckedBackColor = System.Drawing.Color.LimeGreen;
            this.radioButtonStatic.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.radioButtonStatic.Font = new System.Drawing.Font("Verdana", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButtonStatic.Location = new System.Drawing.Point(31, 149);
            this.radioButtonStatic.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.radioButtonStatic.Name = "radioButtonStatic";
            this.radioButtonStatic.Size = new System.Drawing.Size(180, 30);
            this.radioButtonStatic.TabIndex = 36;
            this.radioButtonStatic.Text = "GRR Static Test Mode";
            this.radioButtonStatic.UseVisualStyleBackColor = true;
            // 
            // radioButtoncpk
            // 
            this.radioButtoncpk.Appearance = System.Windows.Forms.Appearance.Button;
            this.radioButtoncpk.AutoSize = true;
            this.radioButtoncpk.FlatAppearance.CheckedBackColor = System.Drawing.Color.LimeGreen;
            this.radioButtoncpk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.radioButtoncpk.Font = new System.Drawing.Font("Verdana", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButtoncpk.Location = new System.Drawing.Point(31, 113);
            this.radioButtoncpk.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.radioButtoncpk.Name = "radioButtoncpk";
            this.radioButtoncpk.Size = new System.Drawing.Size(96, 30);
            this.radioButtoncpk.TabIndex = 29;
            this.radioButtoncpk.Text = "CPK Mode";
            this.radioButtoncpk.UseVisualStyleBackColor = true;
            // 
            // radioButtondry
            // 
            this.radioButtondry.Appearance = System.Windows.Forms.Appearance.Button;
            this.radioButtondry.AutoSize = true;
            this.radioButtondry.FlatAppearance.CheckedBackColor = System.Drawing.Color.LimeGreen;
            this.radioButtondry.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.radioButtondry.Font = new System.Drawing.Font("Verdana", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButtondry.Location = new System.Drawing.Point(31, 78);
            this.radioButtondry.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.radioButtondry.Name = "radioButtondry";
            this.radioButtondry.Size = new System.Drawing.Size(79, 30);
            this.radioButtondry.TabIndex = 28;
            this.radioButtondry.Text = "Dry Run";
            this.radioButtondry.UseVisualStyleBackColor = true;
            // 
            // radioButtonProd
            // 
            this.radioButtonProd.Appearance = System.Windows.Forms.Appearance.Button;
            this.radioButtonProd.AutoCheck = false;
            this.radioButtonProd.AutoSize = true;
            this.radioButtonProd.FlatAppearance.CheckedBackColor = System.Drawing.Color.LimeGreen;
            this.radioButtonProd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.radioButtonProd.Font = new System.Drawing.Font("Verdana", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButtonProd.Location = new System.Drawing.Point(31, 44);
            this.radioButtonProd.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.radioButtonProd.Name = "radioButtonProd";
            this.radioButtonProd.Size = new System.Drawing.Size(132, 30);
            this.radioButtonProd.TabIndex = 27;
            this.radioButtonProd.Text = "Production Run";
            this.radioButtonProd.UseVisualStyleBackColor = true;
            // 
            // radioButtongrr
            // 
            this.radioButtongrr.Appearance = System.Windows.Forms.Appearance.Button;
            this.radioButtongrr.AutoSize = true;
            this.radioButtongrr.FlatAppearance.CheckedBackColor = System.Drawing.Color.LimeGreen;
            this.radioButtongrr.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.radioButtongrr.Font = new System.Drawing.Font("Verdana", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButtongrr.Location = new System.Drawing.Point(23, 454);
            this.radioButtongrr.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.radioButtongrr.Name = "radioButtongrr";
            this.radioButtongrr.Size = new System.Drawing.Size(98, 30);
            this.radioButtongrr.TabIndex = 35;
            this.radioButtongrr.TabStop = true;
            this.radioButtongrr.Text = "GRR Mode";
            this.radioButtongrr.UseVisualStyleBackColor = true;
            this.radioButtongrr.Visible = false;
            // 
            // General
            // 
            this.General.Controls.Add(this.panel5);
            this.General.Location = new System.Drawing.Point(4, 40);
            this.General.Name = "General";
            this.General.Size = new System.Drawing.Size(967, 576);
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
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(967, 576);
            this.panel5.TabIndex = 0;
            // 
            // pnlShiftSettings
            // 
            this.pnlShiftSettings.BackColor = System.Drawing.Color.Gainsboro;
            this.pnlShiftSettings.Controls.Add(this.grpShiftSettings);
            this.pnlShiftSettings.Location = new System.Drawing.Point(473, 3);
            this.pnlShiftSettings.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.pnlShiftSettings.Name = "pnlShiftSettings";
            this.pnlShiftSettings.Size = new System.Drawing.Size(460, 272);
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
            this.grpShiftSettings.Location = new System.Drawing.Point(10, 18);
            this.grpShiftSettings.Name = "grpShiftSettings";
            this.grpShiftSettings.Size = new System.Drawing.Size(443, 248);
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
            this.cmbShift.Location = new System.Drawing.Point(127, 57);
            this.cmbShift.Name = "cmbShift";
            this.cmbShift.Size = new System.Drawing.Size(112, 24);
            this.cmbShift.TabIndex = 56;
            this.cmbShift.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.cmbShift_DrawItem);
            // 
            // lblShift
            // 
            this.lblShift.BackColor = System.Drawing.Color.White;
            this.lblShift.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblShift.Location = new System.Drawing.Point(8, 58);
            this.lblShift.Name = "lblShift";
            this.lblShift.Size = new System.Drawing.Size(113, 18);
            this.lblShift.TabIndex = 55;
            this.lblShift.Text = "Shift          :";
            // 
            // lblEndTime
            // 
            this.lblEndTime.BackColor = System.Drawing.Color.White;
            this.lblEndTime.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEndTime.Location = new System.Drawing.Point(8, 140);
            this.lblEndTime.Name = "lblEndTime";
            this.lblEndTime.Size = new System.Drawing.Size(113, 18);
            this.lblEndTime.TabIndex = 54;
            this.lblEndTime.Text = "End Time   :";
            // 
            // dtpEndTime
            // 
            this.dtpEndTime.Enabled = false;
            this.dtpEndTime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpEndTime.Location = new System.Drawing.Point(127, 140);
            this.dtpEndTime.Name = "dtpEndTime";
            this.dtpEndTime.ShowUpDown = true;
            this.dtpEndTime.Size = new System.Drawing.Size(112, 27);
            this.dtpEndTime.TabIndex = 53;
            // 
            // lblStartTime
            // 
            this.lblStartTime.AutoSize = true;
            this.lblStartTime.BackColor = System.Drawing.Color.White;
            this.lblStartTime.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStartTime.Location = new System.Drawing.Point(8, 98);
            this.lblStartTime.Name = "lblStartTime";
            this.lblStartTime.Size = new System.Drawing.Size(106, 18);
            this.lblStartTime.TabIndex = 52;
            this.lblStartTime.Text = "Start Time :";
            // 
            // dtpStartTime
            // 
            this.dtpStartTime.Enabled = false;
            this.dtpStartTime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpStartTime.Location = new System.Drawing.Point(127, 95);
            this.dtpStartTime.Name = "dtpStartTime";
            this.dtpStartTime.ShowUpDown = true;
            this.dtpStartTime.Size = new System.Drawing.Size(112, 27);
            this.dtpStartTime.TabIndex = 51;
            // 
            // btnEditGeneral
            // 
            this.btnEditGeneral.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(94)))), ((int)(((byte)(133)))));
            this.btnEditGeneral.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditGeneral.ForeColor = System.Drawing.Color.White;
            this.btnEditGeneral.Location = new System.Drawing.Point(136, 199);
            this.btnEditGeneral.Name = "btnEditGeneral";
            this.btnEditGeneral.Size = new System.Drawing.Size(93, 30);
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
            this.btnSaveGeneral.Location = new System.Drawing.Point(236, 199);
            this.btnSaveGeneral.Name = "btnSaveGeneral";
            this.btnSaveGeneral.Size = new System.Drawing.Size(93, 30);
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
            this.pnlGeneral.Location = new System.Drawing.Point(2, 3);
            this.pnlGeneral.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.pnlGeneral.Name = "pnlGeneral";
            this.pnlGeneral.Size = new System.Drawing.Size(420, 546);
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
            this.pnlSupport.Location = new System.Drawing.Point(17, 252);
            this.pnlSupport.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.pnlSupport.Name = "pnlSupport";
            this.pnlSupport.Size = new System.Drawing.Size(383, 277);
            this.pnlSupport.TabIndex = 56;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(0, 39);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(108, 34);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 46;
            this.pictureBox2.TabStop = false;
            // 
            // label39
            // 
            this.label39.AutoSize = true;
            this.label39.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label39.Location = new System.Drawing.Point(8, 235);
            this.label39.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(342, 18);
            this.label39.TabIndex = 43;
            this.label39.Text = "Email: xxxxr@titan.co.in | www.titanteal.com";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(9, 203);
            this.label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(168, 18);
            this.label11.TabIndex = 43;
            this.label11.Text = "Mobile: +91xxxxxxxxx";
            // 
            // label38
            // 
            this.label38.AutoSize = true;
            this.label38.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label38.Location = new System.Drawing.Point(9, 174);
            this.label38.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(124, 18);
            this.label38.TabIndex = 43;
            this.label38.Text = "Hosur - 635126";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(8, 143);
            this.label12.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(218, 18);
            this.label12.TabIndex = 42;
            this.label12.Text = "SIPCOT Industrial Complex,";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(8, 110);
            this.label13.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(144, 18);
            this.label13.TabIndex = 41;
            this.label13.Text = "Unit - I, NO.27 & 28";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(8, 79);
            this.label14.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(319, 18);
            this.label14.TabIndex = 40;
            this.label14.Text = "Titan Engineering and Automation Limited";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Tahoma", 13F, System.Drawing.FontStyle.Bold);
            this.label17.Location = new System.Drawing.Point(7, 9);
            this.label17.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(115, 22);
            this.label17.TabIndex = 39;
            this.label17.Text = "For Support";
            // 
            // pnlInfo
            // 
            this.pnlInfo.BackColor = System.Drawing.Color.White;
            this.pnlInfo.Controls.Add(this.lblrej);
            this.pnlInfo.Controls.Add(this.lbllife);
            this.pnlInfo.Controls.Add(this.lblsupdate);
            this.pnlInfo.Controls.Add(this.lblsrev);
            this.pnlInfo.Controls.Add(this.lbldat);
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
            this.pnlInfo.Location = new System.Drawing.Point(17, 18);
            this.pnlInfo.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.pnlInfo.Name = "pnlInfo";
            this.pnlInfo.Size = new System.Drawing.Size(383, 217);
            this.pnlInfo.TabIndex = 55;
            // 
            // lblrej
            // 
            this.lblrej.AutoSize = true;
            this.lblrej.Location = new System.Drawing.Point(168, 170);
            this.lblrej.Name = "lblrej";
            this.lblrej.Size = new System.Drawing.Size(49, 18);
            this.lblrej.TabIndex = 52;
            this.lblrej.Text = "lblrej";
            // 
            // lbllife
            // 
            this.lbllife.AutoSize = true;
            this.lbllife.Location = new System.Drawing.Point(169, 141);
            this.lbllife.Name = "lbllife";
            this.lbllife.Size = new System.Drawing.Size(50, 18);
            this.lbllife.TabIndex = 51;
            this.lbllife.Text = "lbllife";
            // 
            // lblsupdate
            // 
            this.lblsupdate.AutoSize = true;
            this.lblsupdate.Location = new System.Drawing.Point(169, 106);
            this.lblsupdate.Name = "lblsupdate";
            this.lblsupdate.Size = new System.Drawing.Size(92, 18);
            this.lblsupdate.TabIndex = 50;
            this.lblsupdate.Text = "lblsupdate";
            // 
            // lblsrev
            // 
            this.lblsrev.AutoSize = true;
            this.lblsrev.Location = new System.Drawing.Point(173, 75);
            this.lblsrev.Name = "lblsrev";
            this.lblsrev.Size = new System.Drawing.Size(62, 18);
            this.lblsrev.TabIndex = 49;
            this.lblsrev.Text = "lblsrev";
            // 
            // lbldat
            // 
            this.lbldat.AutoSize = true;
            this.lbldat.Location = new System.Drawing.Point(173, 47);
            this.lbldat.Name = "lbldat";
            this.lbldat.Size = new System.Drawing.Size(53, 18);
            this.lbldat.TabIndex = 48;
            this.lbldat.Text = "lbldat";
            // 
            // lblTotalRejectVal
            // 
            this.lblTotalRejectVal.AutoSize = true;
            this.lblTotalRejectVal.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalRejectVal.Location = new System.Drawing.Point(168, 170);
            this.lblTotalRejectVal.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTotalRejectVal.Name = "lblTotalRejectVal";
            this.lblTotalRejectVal.Size = new System.Drawing.Size(0, 18);
            this.lblTotalRejectVal.TabIndex = 47;
            // 
            // lblTotalLifeCycleVal
            // 
            this.lblTotalLifeCycleVal.AutoSize = true;
            this.lblTotalLifeCycleVal.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalLifeCycleVal.Location = new System.Drawing.Point(168, 140);
            this.lblTotalLifeCycleVal.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTotalLifeCycleVal.Name = "lblTotalLifeCycleVal";
            this.lblTotalLifeCycleVal.Size = new System.Drawing.Size(0, 18);
            this.lblTotalLifeCycleVal.TabIndex = 46;
            // 
            // lblSWRevVal
            // 
            this.lblSWRevVal.AutoSize = true;
            this.lblSWRevVal.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSWRevVal.Location = new System.Drawing.Point(168, 75);
            this.lblSWRevVal.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblSWRevVal.Name = "lblSWRevVal";
            this.lblSWRevVal.Size = new System.Drawing.Size(0, 18);
            this.lblSWRevVal.TabIndex = 45;
            // 
            // lbSWUpdateVal
            // 
            this.lbSWUpdateVal.AutoSize = true;
            this.lbSWUpdateVal.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbSWUpdateVal.Location = new System.Drawing.Point(168, 106);
            this.lbSWUpdateVal.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbSWUpdateVal.Name = "lbSWUpdateVal";
            this.lbSWUpdateVal.Size = new System.Drawing.Size(0, 18);
            this.lbSWUpdateVal.TabIndex = 44;
            // 
            // lblBuildDateVal
            // 
            this.lblBuildDateVal.AutoSize = true;
            this.lblBuildDateVal.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBuildDateVal.Location = new System.Drawing.Point(168, 47);
            this.lblBuildDateVal.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblBuildDateVal.Name = "lblBuildDateVal";
            this.lblBuildDateVal.Size = new System.Drawing.Size(0, 18);
            this.lblBuildDateVal.TabIndex = 43;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(151, 170);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(13, 18);
            this.label10.TabIndex = 42;
            this.label10.Text = ":";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(151, 140);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(13, 18);
            this.label9.TabIndex = 41;
            this.label9.Text = ":";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(151, 106);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(13, 18);
            this.label8.TabIndex = 40;
            this.label8.Text = ":";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(151, 75);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(13, 18);
            this.label7.TabIndex = 39;
            this.label7.Text = ":";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(151, 47);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(13, 18);
            this.label6.TabIndex = 38;
            this.label6.Text = ":";
            // 
            // lblSwUpdated
            // 
            this.lblSwUpdated.AutoSize = true;
            this.lblSwUpdated.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSwUpdated.Location = new System.Drawing.Point(7, 106);
            this.lblSwUpdated.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblSwUpdated.Name = "lblSwUpdated";
            this.lblSwUpdated.Size = new System.Drawing.Size(90, 18);
            this.lblSwUpdated.TabIndex = 33;
            this.lblSwUpdated.Text = "SW Updated";
            // 
            // lblBuildDate
            // 
            this.lblBuildDate.AutoSize = true;
            this.lblBuildDate.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBuildDate.Location = new System.Drawing.Point(7, 47);
            this.lblBuildDate.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblBuildDate.Name = "lblBuildDate";
            this.lblBuildDate.Size = new System.Drawing.Size(73, 18);
            this.lblBuildDate.TabIndex = 28;
            this.lblBuildDate.Text = "Build Date";
            // 
            // lblSWRev
            // 
            this.lblSWRev.AutoSize = true;
            this.lblSWRev.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSWRev.Location = new System.Drawing.Point(7, 75);
            this.lblSWRev.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblSWRev.Name = "lblSWRev";
            this.lblSWRev.Size = new System.Drawing.Size(60, 18);
            this.lblSWRev.TabIndex = 29;
            this.lblSWRev.Text = "SW Rev";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Verdana", 13F, System.Drawing.FontStyle.Bold);
            this.label22.Location = new System.Drawing.Point(8, 15);
            this.label22.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(132, 22);
            this.label22.TabIndex = 32;
            this.label22.Text = "Information";
            // 
            // lblLifecycle
            // 
            this.lblLifecycle.AutoSize = true;
            this.lblLifecycle.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLifecycle.Location = new System.Drawing.Point(7, 140);
            this.lblLifecycle.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblLifecycle.Name = "lblLifecycle";
            this.lblLifecycle.Size = new System.Drawing.Size(119, 18);
            this.lblLifecycle.TabIndex = 35;
            this.lblLifecycle.Text = "Total Life Cycles ";
            // 
            // lblRejection
            // 
            this.lblRejection.AutoSize = true;
            this.lblRejection.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRejection.Location = new System.Drawing.Point(7, 170);
            this.lblRejection.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblRejection.Name = "lblRejection";
            this.lblRejection.Size = new System.Drawing.Size(121, 18);
            this.lblRejection.TabIndex = 37;
            this.lblRejection.Text = "Total Life Rejects";
            // 
            // tabControlSettings
            // 
            this.tabControlSettings.Controls.Add(this.General);
            this.tabControlSettings.Controls.Add(this.Device);
            this.tabControlSettings.Controls.Add(this.IODiagnostics);
            this.tabControlSettings.Controls.Add(this.MotorDebug);
            this.tabControlSettings.Controls.Add(this.tabPage3);
            this.tabControlSettings.Controls.Add(this.tabPage1);
            this.tabControlSettings.Controls.Add(this.Calibration);
            this.tabControlSettings.Dock = System.Windows.Forms.DockStyle.Top;
            this.tabControlSettings.Font = new System.Drawing.Font("Verdana", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControlSettings.Location = new System.Drawing.Point(0, 0);
            this.tabControlSettings.Name = "tabControlSettings";
            this.tabControlSettings.Padding = new System.Drawing.Point(15, 10);
            this.tabControlSettings.SelectedIndex = 0;
            this.tabControlSettings.Size = new System.Drawing.Size(975, 620);
            this.tabControlSettings.TabIndex = 47;
            // 
            // timer2
            // 
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick_1);
            // 
            // dataGridViewImageColumn2
            // 
            this.dataGridViewImageColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.dataGridViewImageColumn2.HeaderText = "On/Off";
            this.dataGridViewImageColumn2.Image = ((System.Drawing.Image)(resources.GetObject("dataGridViewImageColumn2.Image")));
            this.dataGridViewImageColumn2.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.dataGridViewImageColumn2.MinimumWidth = 6;
            this.dataGridViewImageColumn2.Name = "dataGridViewImageColumn2";
            this.dataGridViewImageColumn2.ReadOnly = true;
            this.dataGridViewImageColumn2.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewImageColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.dataGridViewImageColumn2.Width = 80;
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(975, 620);
            this.Controls.Add(this.tabControlSettings);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Settings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Settings";
            this.Load += new System.EventHandler(this.Settings_Load);
            this.Calibration.ResumeLayout(false);
            this.CaliberationPanel.ResumeLayout(false);
            this.tabCalib.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.grpCameraCalib.ResumeLayout(false);
            this.grpCameraCalib.PerformLayout();
            this.grpboxCamera.ResumeLayout(false);
            this.grpboxCamera.PerformLayout();
            this.tabPage7.ResumeLayout(false);
            this.tabPage7.PerformLayout();
            this.grpGantry2.ResumeLayout(false);
            this.grpGantry2.PerformLayout();
            this.grpGantry.ResumeLayout(false);
            this.grpGantry.PerformLayout();
            this.grpMoveAbsolute.ResumeLayout(false);
            this.grpMoveAbsolute.PerformLayout();
            this.grp_EditSave.ResumeLayout(false);
            this.grp_EditSave.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Nozzle)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.tabRepeatability.ResumeLayout(false);
            this.grpScan.ResumeLayout(false);
            this.grpScan.PerformLayout();
            this.tabPage1.ResumeLayout(false);
            this.tabControl5.ResumeLayout(false);
            this.tabPage23.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.AE_LIMITS)).EndInit();
            this.tabPage8.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.CPK_dataGridView2)).EndInit();
            this.tabPage12.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GRR_dataGridView3)).EndInit();
            this.tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Table_Vision_Settings)).EndInit();
            this.MotorDebug.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.grbMotor.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Axis_Settings)).EndInit();
            this.IODiagnostics.ResumeLayout(false);
            this.tabIO.ResumeLayout(false);
            this.btn_input.ResumeLayout(false);
            this.btn_input.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_Output1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_Input1)).EndInit();
            this.tabPage10.ResumeLayout(false);
            this.tabPage10.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAI)).EndInit();
            this.Device.ResumeLayout(false);
            this.DeviceSettingsPanel.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabConnectionDetails.ResumeLayout(false);
            this.tabPage5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.IP_Details_table)).EndInit();
            this.tabPage6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Serial_Comm_table)).EndInit();
            this.grpSystemSettings.ResumeLayout(false);
            this.grpSystemSettings.PerformLayout();
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
            this.tabControlSettings.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private Timer timer1;
        private TabPage Calibration;
        private Panel CaliberationPanel;
        private TabPage tabPage1;
        private TabControl tabControl5;
        private TabPage tabPage23;
        private Button button23;
        private Button button24;
        private DataGridView AE_LIMITS;
        private TabPage tabPage8;
        private Button CPK_Save;
        private Button CPK_Edit;
        private DataGridView CPK_dataGridView2;
        private TabPage tabPage12;
        private Button button31;
        private Button button32;
        private DataGridView GRR_dataGridView3;
        private TabPage tabPage3;
        private Button button1;
        private Button button2;
        private DataGridView Table_Vision_Settings;
        private TabPage MotorDebug;
        private Panel panel2;
        private Button btnSave;
        private Button btnedit;
        private GroupBox grbMotor;
        private TabPage IODiagnostics;
        private TabPage Device;
        private Panel DeviceSettingsPanel;
        private GroupBox groupBox1;
        private CheckBox SFC_PDCA_Bypass;
        private CheckBox Buzzer_Bypass;
        private CheckBox Safety_door_bypass;
        private CheckBox Barcode_scanner_bypass;
        private Panel panel4;
        private GroupBox grpSystemSettings;
        private TabPage General;
        private Panel panel5;
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
        private Panel pnlGeneral;
        private Panel pnlSupport;
        private PictureBox pictureBox2;
        private Label label39;
        private Label label11;
        private Label label38;
        private Label label12;
        private Label label13;
        private Label label14;
        private Label label17;
        private Panel pnlInfo;
        private Label lblTotalRejectVal;
        private Label lblTotalLifeCycleVal;
        private Label lblSWRevVal;
        private Label lbSWUpdateVal;
        private Label lblBuildDateVal;
        private Label label10;
        private Label label9;
        private Label label8;
        private Label label7;
        private Label label6;
        private Label lblSwUpdated;
        private Label lblBuildDate;
        private Label lblSWRev;
        private Label label22;
        private Label lblLifecycle;
        private Label lblRejection;
        private TabControl tabControlSettings;
        private RadioButton radioButtonProd;
        private RadioButton radioButtoncpk;
        private RadioButton radioButtondry;
        private RadioButton radioButtongrr;
        private RadioButton radioButtonDynamic;
        private RadioButton radioButtonStatic;
        private DataGridView Axis_Settings;
        private TabControl tabIO;
        private TabPage btn_input;
        private TextBox txtSearchForOutput;
        private TextBox txtSearchForInput;
        private Label label30;
        private Label label29;
        private DataGridView DGV_Output1;
        private DataGridViewButtonColumn dataGridViewImageColumn1;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridView DGV_Input1;
        private DataGridViewImageColumn InOnOff;
        private DataGridViewTextBoxColumn InputName;
        private TabPage tabPage10;
        private Label label4;
        private DataGridView dgvAI;
        private Timer timer2;
        private DataGridViewImageColumn dataGridViewImageColumn2;
        private Button btnEditSettings;
        private Button btnSaveSettings;
        private TabControl tabConnectionDetails;
        private TabPage tabPage5;
        private DataGridView IP_Details_table;
        private TabPage tabPage6;
        private DataGridView Serial_Comm_table;
        private CheckBox Semimachk;
        private CheckBox Nk_Model;
        private CheckBox Four_Graphit;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem moveToolStripMenuItem;
        private ToolStripMenuItem teachToolStripMenuItem;
        private ToolStripMenuItem toolStripMenuItem3;
        private TabControl tabCalib;
        private TabPage tabPage2;
        private GroupBox grpCameraCalib;
        private Button button3;
        private GroupBox grpboxCamera;
        private CheckBox checkCCD1;
        private CheckBox checkCCD4;
        private CheckBox checkCCD3;
        private CheckBox checkCCD2;
        private Label label16;
        private Label lblStaticUnit;
        private Label label18;
        private Label label129;
        public TextBox txtstaticposccd1_y;
        public TextBox txtstaticposccd1_x;
        private Label lblStaticPos;
        private Button btnccd1Browse;
        private TextBox txtccd1path;
        private Label label43;
        private TextBox txtCounts;
        private Label label50;
        private TextBox txtspeed;
        private Label label77;
        private TextBox txtposition_y2;
        private TextBox txtposition_y1;
        private Label label79;
        private Label label90;
        private TextBox txtposition_x2;
        private Label lblDynamicpos2;
        private TextBox txtposition_x1;
        private Label lblDynamicPos1;
        private Label lblRunningCount;
        private Label label118;
        private TextBox txtTestMode;
        private Label label119;
        private Button btnCamera_Stop;
        private Button btnCamera_Start;
        private TabPage tabPage7;
        private Label label2;
        private TextBox txtdistance;
        private Button btn_stop;
        private Button btn_start;
        private GroupBox grp_EditSave;
        private Button btn_save;
        private Button btn_edit;
        private Label lblSave;
        private Label lblEdit;
        private DataGridView dgv_Nozzle;
        private ComboBox cmb_Nozzle;
        private Label lbl_Nozzle;
        private GroupBox grpMoveAbsolute;
        private GroupBox grpGantry;
        private Label lblY_Position;
        private TextBox txt_PrfPos_Y1;
        private Button btnXAdd;
        private Button btnYDec;
        private Button btnYAdd;
        private Button btnXDec;
        private Label lblX_Position;
        private TextBox txt_PrfPos_X1;
        private Button btnMoveAbs;
        private Label lblServoX_TargetSpeed;
        private TextBox txtetSpeedAbs;
        private Label lblMoveAbsSpeed;
        private Label label1;
        private ComboBox cmbMoveMode;
        private ComboBox cmbAxisMoveAbs;
        private Label lblMoveAbsSelectAxis;
        private Button btnStop;
        private Label lblServoX_TargetPosition;
        private TextBox txtPositionAbs;
        private Label lblMoveAbsPos;
        private GroupBox grpGantry2;
        private TextBox txt_PrfPos_Z1;
        private Label lblZ_Position;
        private Button btnZ1Add;
        private Button btnR2Add;
        private Button btnR2Dec;
        private Button btnZ1Dec;
        private TextBox txt_PrfPos_Z2;
        private TextBox txt_PrfPos_R2;
        private Label label20;
        private Button btnR1Add;
        private TextBox txt_PrfPos_R1;
        private Label label21;
        private Label label23;
        private Button btnR1Dec;
        private Button btnZ2Dec;
        private Button btnZ2Add;
        private RadioButton radioButton3;
        private RadioButton radioButton2;
        private RadioButton radioButton1;
        private Label lblrej;
        private Label lbllife;
        private Label lblsupdate;
        private Label lblsrev;
        private Label lbldat;
        private RadioButton Dym_run;
        private TabPage tabRepeatability;
        private GroupBox grpScan;
        private RadioButton rdoScan1;
        private Button button5;
        private Button button4;
        private Label lblRunningRepeatabilityCount;
        private TextBox txtRepetabilityCountValue;
        private Label lblRepeatabilityTotalCount;
        private Label lblRuncountTimeVal;
        private Label lblchoosescanner;
        private Label lbl_z2;
        private TextBox txtposition_R;
        private Label lbl_z1;
        private TextBox txtposition_Z1;
        private CheckBox LoaddellChk;
        private Button btnSveLod;
        private CheckBox Enable_4_3;
        private GroupBox groupBox2;
        private CheckBox K_Model;
    }


}