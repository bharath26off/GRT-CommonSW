using System.Drawing;
using System.Windows.Forms;
using System.Web.UI.DataVisualization.Charting;

namespace UI.UI_Forms
{
    partial class HomeScreen
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
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.OfflinewithoutSFC = new System.Windows.Forms.Button();
            this.OnlinewithoutSFC = new System.Windows.Forms.Button();
            this.textBox21 = new System.Windows.Forms.TextBox();
            this.textBox20 = new System.Windows.Forms.TextBox();
            this.MachineLamp = new System.Windows.Forms.Button();
            this.MS_clear = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.conectionStatusGrid = new System.Windows.Forms.DataGridView();
            this.pnlMachineStatus = new System.Windows.Forms.Panel();
            this.textBox23 = new System.Windows.Forms.TextBox();
            this.txtMachineMode = new System.Windows.Forms.TextBox();
            this.textBox25 = new System.Windows.Forms.TextBox();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtUph = new System.Windows.Forms.TextBox();
            this.txtCycletime = new System.Windows.Forms.TextBox();
            this.textBox17 = new System.Windows.Forms.TextBox();
            this.textBox16 = new System.Windows.Forms.TextBox();
            this.txtyYeldcnt = new System.Windows.Forms.TextBox();
            this.txtOverallcnt = new System.Windows.Forms.TextBox();
            this.txtFailcnt = new System.Windows.Forms.TextBox();
            this.txtPasscnt = new System.Windows.Forms.TextBox();
            this.textBox13 = new System.Windows.Forms.TextBox();
            this.textBox12 = new System.Windows.Forms.TextBox();
            this.textBox11 = new System.Windows.Forms.TextBox();
            this.textBox8 = new System.Windows.Forms.TextBox();
            this.pnlMachineHealth = new System.Windows.Forms.Panel();
            this.button3 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.linkLabel2 = new System.Windows.Forms.LinkLabel();
            this.lblShift = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.button12 = new System.Windows.Forms.Button();
            this.button13 = new System.Windows.Forms.Button();
            this.button14 = new System.Windows.Forms.Button();
            this.label14 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.lblTotaltime = new System.Windows.Forms.Label();
            this.lblIdletime = new System.Windows.Forms.Label();
            this.lblDowntime = new System.Windows.Forms.Label();
            this.lblRunTime = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
            this.Homing = new System.Windows.Forms.Button();
            this.tabLog = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.txtonlypasting = new System.Windows.Forms.TextBox();
            this.txtout = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.lstRunningLog = new System.Windows.Forms.ListBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.dgvAlarmlive = new System.Windows.Forms.DataGridView();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.textBox19 = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.textBox18 = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.textBox15 = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.textBox14 = new System.Windows.Forms.TextBox();
            this.textBox10 = new System.Windows.Forms.TextBox();
            this.textBox9 = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.label62 = new System.Windows.Forms.Label();
            this.label61 = new System.Windows.Forms.Label();
            this.panel7_4 = new System.Windows.Forms.Panel();
            this.label58 = new System.Windows.Forms.Label();
            this.panel8_4 = new System.Windows.Forms.Panel();
            this.BN_WK2_4 = new System.Windows.Forms.Label();
            this.lblFI_12_4 = new System.Windows.Forms.Label();
            this.lblFI_1_4 = new System.Windows.Forms.Label();
            this.lblFI_11_4 = new System.Windows.Forms.Label();
            this.lblFI_2_4 = new System.Windows.Forms.Label();
            this.lblFI_10_4 = new System.Windows.Forms.Label();
            this.lblFI_3_4 = new System.Windows.Forms.Label();
            this.lblFI_9_4 = new System.Windows.Forms.Label();
            this.lblFI_4_4 = new System.Windows.Forms.Label();
            this.lblFI_8_4 = new System.Windows.Forms.Label();
            this.lblFI_5_4 = new System.Windows.Forms.Label();
            this.lblFI_7_4 = new System.Windows.Forms.Label();
            this.lblFI_6_4 = new System.Windows.Forms.Label();
            this.label59 = new System.Windows.Forms.Label();
            this.panel3_4 = new System.Windows.Forms.Panel();
            this.BN_wk1_4 = new System.Windows.Forms.Label();
            this.lblAS_12_4 = new System.Windows.Forms.Label();
            this.lblAS_1_4 = new System.Windows.Forms.Label();
            this.lblAS_11_4 = new System.Windows.Forms.Label();
            this.lblAS_2_4 = new System.Windows.Forms.Label();
            this.lblAS_10_4 = new System.Windows.Forms.Label();
            this.lblAS_3_4 = new System.Windows.Forms.Label();
            this.lblAS_9_4 = new System.Windows.Forms.Label();
            this.lblAS_4_4 = new System.Windows.Forms.Label();
            this.lblAS_8_4 = new System.Windows.Forms.Label();
            this.lblAS_5_4 = new System.Windows.Forms.Label();
            this.lblAS_7_4 = new System.Windows.Forms.Label();
            this.lblAS_6_4 = new System.Windows.Forms.Label();
            this.label60 = new System.Windows.Forms.Label();
            this.pnlScanner_4 = new System.Windows.Forms.Panel();
            this.lblSC_10_4 = new System.Windows.Forms.Label();
            this.lblSC_11_4 = new System.Windows.Forms.Label();
            this.lblSC_12_4 = new System.Windows.Forms.Label();
            this.lblSC_9_4 = new System.Windows.Forms.Label();
            this.lblSC_8_4 = new System.Windows.Forms.Label();
            this.lblSC_7_4 = new System.Windows.Forms.Label();
            this.lblSC_4_4 = new System.Windows.Forms.Label();
            this.lblSC_5_4 = new System.Windows.Forms.Label();
            this.lblSC_6_4 = new System.Windows.Forms.Label();
            this.CARRIER_SN_4 = new System.Windows.Forms.Label();
            this.lblSC_3_4 = new System.Windows.Forms.Label();
            this.lblSC_2_4 = new System.Windows.Forms.Label();
            this.lblSC_1_4 = new System.Windows.Forms.Label();
            this.panel7 = new System.Windows.Forms.Panel();
            this.label47 = new System.Windows.Forms.Label();
            this.panel8 = new System.Windows.Forms.Panel();
            this.BN_WK2 = new System.Windows.Forms.Label();
            this.lblFI_12 = new System.Windows.Forms.Label();
            this.lblFI_1 = new System.Windows.Forms.Label();
            this.lblFI_11 = new System.Windows.Forms.Label();
            this.lblFI_2 = new System.Windows.Forms.Label();
            this.lblFI_10 = new System.Windows.Forms.Label();
            this.lblFI_8 = new System.Windows.Forms.Label();
            this.lblFI_7 = new System.Windows.Forms.Label();
            this.lblFI_3 = new System.Windows.Forms.Label();
            this.lblFI_9 = new System.Windows.Forms.Label();
            this.lblFI_4 = new System.Windows.Forms.Label();
            this.lblFI_5 = new System.Windows.Forms.Label();
            this.lblFI_6 = new System.Windows.Forms.Label();
            this.label48 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.BN_wk1 = new System.Windows.Forms.Label();
            this.lblAS_12 = new System.Windows.Forms.Label();
            this.lblAS_8 = new System.Windows.Forms.Label();
            this.lblAS_7 = new System.Windows.Forms.Label();
            this.lblAS_1 = new System.Windows.Forms.Label();
            this.lblAS_11 = new System.Windows.Forms.Label();
            this.lblAS_2 = new System.Windows.Forms.Label();
            this.lblAS_10 = new System.Windows.Forms.Label();
            this.lblAS_3 = new System.Windows.Forms.Label();
            this.lblAS_9 = new System.Windows.Forms.Label();
            this.lblAS_4 = new System.Windows.Forms.Label();
            this.lblAS_5 = new System.Windows.Forms.Label();
            this.lblAS_6 = new System.Windows.Forms.Label();
            this.label49 = new System.Windows.Forms.Label();
            this.pnlScanner = new System.Windows.Forms.Panel();
            this.lblSC_10 = new System.Windows.Forms.Label();
            this.lblSC_11 = new System.Windows.Forms.Label();
            this.lblSC_12 = new System.Windows.Forms.Label();
            this.lblSC_9 = new System.Windows.Forms.Label();
            this.lblSC_8 = new System.Windows.Forms.Label();
            this.lblSC_7 = new System.Windows.Forms.Label();
            this.lblSC_4 = new System.Windows.Forms.Label();
            this.lblSC_5 = new System.Windows.Forms.Label();
            this.lblSC_6 = new System.Windows.Forms.Label();
            this.CARRIER_SN = new System.Windows.Forms.Label();
            this.lblSC_3 = new System.Windows.Forms.Label();
            this.lblSC_2 = new System.Windows.Forms.Label();
            this.lblSC_1 = new System.Windows.Forms.Label();
            this.label50 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.FinalRslt = new System.Windows.Forms.DataGridView();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.label38 = new System.Windows.Forms.Label();
            this.label34 = new System.Windows.Forms.Label();
            this.label37 = new System.Windows.Forms.Label();
            this.label33 = new System.Windows.Forms.Label();
            this.label36 = new System.Windows.Forms.Label();
            this.label30 = new System.Windows.Forms.Label();
            this.label35 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label32 = new System.Windows.Forms.Label();
            this.label31 = new System.Windows.Forms.Label();
            this.label42 = new System.Windows.Forms.Label();
            this.label39 = new System.Windows.Forms.Label();
            this.label40 = new System.Windows.Forms.Label();
            this.label41 = new System.Windows.Forms.Label();
            this.label43 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label46 = new System.Windows.Forms.Label();
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.tabPage13 = new System.Windows.Forms.TabPage();
            this.dgv_offset = new System.Windows.Forms.DataGridView();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.savebtn_offset = new System.Windows.Forms.Button();
            this.editbtn_offset = new System.Windows.Forms.Button();
            this.label55 = new System.Windows.Forms.Label();
            this.label56 = new System.Windows.Forms.Label();
            this.label57 = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.tabPage7 = new System.Windows.Forms.TabPage();
            this.dgv_offsetK = new System.Windows.Forms.DataGridView();
            this.groupBoxoffset = new System.Windows.Forms.GroupBox();
            this.savebtn_offsetK = new System.Windows.Forms.Button();
            this.editbtn_offsetK = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.lbl_ofset = new System.Windows.Forms.Label();
            this.offset = new System.Windows.Forms.Panel();
            this.tabPage9 = new System.Windows.Forms.TabPage();
            this.dgv_offsetNk = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.savebtn_offsetNk = new System.Windows.Forms.Button();
            this.editbtn_offsetNk = new System.Windows.Forms.Button();
            this.label13 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.tabPage8 = new System.Windows.Forms.TabPage();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label18 = new System.Windows.Forms.Label();
            this.savebtn_AE = new System.Windows.Forms.Button();
            this.label22 = new System.Windows.Forms.Label();
            this.editbtn_AE = new System.Windows.Forms.Button();
            this.label23 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.dgv_AE = new System.Windows.Forms.DataGridView();
            this.tabPage10 = new System.Windows.Forms.TabPage();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.savebtn_delay = new System.Windows.Forms.Button();
            this.editbtn_delay = new System.Windows.Forms.Button();
            this.label25 = new System.Windows.Forms.Label();
            this.label44 = new System.Windows.Forms.Label();
            this.label45 = new System.Windows.Forms.Label();
            this.dgv_delay = new System.Windows.Forms.DataGridView();
            this.tabPage11 = new System.Windows.Forms.TabPage();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.label51 = new System.Windows.Forms.Label();
            this.SFC_Save = new System.Windows.Forms.Button();
            this.label52 = new System.Windows.Forms.Label();
            this.SFC_Edit = new System.Windows.Forms.Button();
            this.SFCGridview = new System.Windows.Forms.DataGridView();
            this.tabPage12 = new System.Windows.Forms.TabPage();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.savebtn_feeder = new System.Windows.Forms.Button();
            this.editbtn_feeder = new System.Windows.Forms.Button();
            this.label53 = new System.Windows.Forms.Label();
            this.label54 = new System.Windows.Forms.Label();
            this.Feeder_Min_Max = new System.Windows.Forms.Label();
            this.dgv_Feeder_Min_Max = new System.Windows.Forms.DataGridView();
            this.M_C_Ready_to_Recive = new System.Windows.Forms.Label();
            this.Check_Semma = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.conectionStatusGrid)).BeginInit();
            this.pnlMachineStatus.SuspendLayout();
            this.pnlMachineHealth.SuspendLayout();
            this.tabLog.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAlarmlive)).BeginInit();
            this.tabPage5.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.panel7_4.SuspendLayout();
            this.panel8_4.SuspendLayout();
            this.panel3_4.SuspendLayout();
            this.pnlScanner_4.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel8.SuspendLayout();
            this.panel3.SuspendLayout();
            this.pnlScanner.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FinalRslt)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.tabPage6.SuspendLayout();
            this.tabControl2.SuspendLayout();
            this.tabPage13.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_offset)).BeginInit();
            this.groupBox7.SuspendLayout();
            this.tabPage7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_offsetK)).BeginInit();
            this.groupBoxoffset.SuspendLayout();
            this.tabPage9.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_offsetNk)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.tabPage8.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_AE)).BeginInit();
            this.tabPage10.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_delay)).BeginInit();
            this.tabPage11.SuspendLayout();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SFCGridview)).BeginInit();
            this.tabPage12.SuspendLayout();
            this.groupBox6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Feeder_Min_Max)).BeginInit();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Controls.Add(this.tabPage6);
            this.tabControl1.Controls.Add(this.tabPage8);
            this.tabControl1.Controls.Add(this.tabPage10);
            this.tabControl1.Controls.Add(this.tabPage11);
            this.tabControl1.Controls.Add(this.tabPage12);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(975, 620);
            this.tabControl1.TabIndex = 139;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.OfflinewithoutSFC);
            this.tabPage3.Controls.Add(this.OnlinewithoutSFC);
            this.tabPage3.Controls.Add(this.textBox21);
            this.tabPage3.Controls.Add(this.textBox20);
            this.tabPage3.Controls.Add(this.MachineLamp);
            this.tabPage3.Controls.Add(this.MS_clear);
            this.tabPage3.Controls.Add(this.panel1);
            this.tabPage3.Controls.Add(this.pnlMachineStatus);
            this.tabPage3.Controls.Add(this.pnlMachineHealth);
            this.tabPage3.Controls.Add(this.Homing);
            this.tabPage3.Controls.Add(this.tabLog);
            this.tabPage3.Location = new System.Drawing.Point(4, 27);
            this.tabPage3.Margin = new System.Windows.Forms.Padding(2);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(2);
            this.tabPage3.Size = new System.Drawing.Size(967, 589);
            this.tabPage3.TabIndex = 0;
            this.tabPage3.Text = "HOME SCREEN";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // OfflinewithoutSFC
            // 
            this.OfflinewithoutSFC.BackColor = System.Drawing.Color.GhostWhite;
            this.OfflinewithoutSFC.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OfflinewithoutSFC.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.OfflinewithoutSFC.Location = new System.Drawing.Point(710, 541);
            this.OfflinewithoutSFC.Name = "OfflinewithoutSFC";
            this.OfflinewithoutSFC.Size = new System.Drawing.Size(108, 31);
            this.OfflinewithoutSFC.TabIndex = 106;
            this.OfflinewithoutSFC.Text = "OFFLINE";
            this.OfflinewithoutSFC.UseVisualStyleBackColor = false;
            // 
            // OnlinewithoutSFC
            // 
            this.OnlinewithoutSFC.BackColor = System.Drawing.Color.GhostWhite;
            this.OnlinewithoutSFC.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OnlinewithoutSFC.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.OnlinewithoutSFC.Location = new System.Drawing.Point(596, 541);
            this.OnlinewithoutSFC.Name = "OnlinewithoutSFC";
            this.OnlinewithoutSFC.Size = new System.Drawing.Size(108, 31);
            this.OnlinewithoutSFC.TabIndex = 105;
            this.OnlinewithoutSFC.Text = "ONLINE";
            this.OnlinewithoutSFC.UseVisualStyleBackColor = false;
            // 
            // textBox21
            // 
            this.textBox21.BackColor = System.Drawing.Color.White;
            this.textBox21.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox21.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.textBox21.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox21.Location = new System.Drawing.Point(922, 555);
            this.textBox21.Name = "textBox21";
            this.textBox21.ReadOnly = true;
            this.textBox21.Size = new System.Drawing.Size(28, 17);
            this.textBox21.TabIndex = 104;
            this.textBox21.Text = "0  ";
            // 
            // textBox20
            // 
            this.textBox20.BackColor = System.Drawing.Color.White;
            this.textBox20.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox20.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.textBox20.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox20.Location = new System.Drawing.Point(847, 531);
            this.textBox20.Name = "textBox20";
            this.textBox20.ReadOnly = true;
            this.textBox20.Size = new System.Drawing.Size(117, 17);
            this.textBox20.TabIndex = 103;
            this.textBox20.Text = "Toss Graphite  ";
            // 
            // MachineLamp
            // 
            this.MachineLamp.BackColor = System.Drawing.Color.Lavender;
            this.MachineLamp.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MachineLamp.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.MachineLamp.Location = new System.Drawing.Point(230, 535);
            this.MachineLamp.Name = "MachineLamp";
            this.MachineLamp.Size = new System.Drawing.Size(165, 43);
            this.MachineLamp.TabIndex = 101;
            this.MachineLamp.Text = "Lamp ON / OFF";
            this.MachineLamp.UseVisualStyleBackColor = false;
            this.MachineLamp.Click += new System.EventHandler(this.MachineLamp_Click);
            // 
            // MS_clear
            // 
            this.MS_clear.BackColor = System.Drawing.Color.Lavender;
            this.MS_clear.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MS_clear.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.MS_clear.Location = new System.Drawing.Point(45, 535);
            this.MS_clear.Name = "MS_clear";
            this.MS_clear.Size = new System.Drawing.Size(165, 43);
            this.MS_clear.TabIndex = 100;
            this.MS_clear.Text = "Reset / Machine Status";
            this.MS_clear.UseVisualStyleBackColor = false;
            this.MS_clear.Click += new System.EventHandler(this.MS_clear_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.button5);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.conectionStatusGrid);
            this.panel1.Location = new System.Drawing.Point(597, 13);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(419, 263);
            this.panel1.TabIndex = 98;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.LimeGreen;
            this.button1.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold);
            this.button1.Location = new System.Drawing.Point(232, 233);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(149, 26);
            this.button1.TabIndex = 102;
            this.button1.Text = "Empty Nozzle";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.Color.LimeGreen;
            this.button5.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button5.Location = new System.Drawing.Point(55, 233);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(144, 26);
            this.button5.TabIndex = 101;
            this.button5.Text = "Feeder Feed";
            this.button5.UseVisualStyleBackColor = false;
            this.button5.Click += new System.EventHandler(this.button5_ClickAsync);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 13.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(118, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(245, 23);
            this.label1.TabIndex = 100;
            this.label1.Text = "CONNECTION STATUS";
            // 
            // conectionStatusGrid
            // 
            this.conectionStatusGrid.AllowUserToAddRows = false;
            this.conectionStatusGrid.BackgroundColor = System.Drawing.SystemColors.Control;
            this.conectionStatusGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.conectionStatusGrid.Location = new System.Drawing.Point(8, 37);
            this.conectionStatusGrid.Name = "conectionStatusGrid";
            this.conectionStatusGrid.ReadOnly = true;
            this.conectionStatusGrid.RowHeadersWidth = 51;
            this.conectionStatusGrid.Size = new System.Drawing.Size(404, 191);
            this.conectionStatusGrid.TabIndex = 98;
            // 
            // pnlMachineStatus
            // 
            this.pnlMachineStatus.BackColor = System.Drawing.Color.White;
            this.pnlMachineStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlMachineStatus.Controls.Add(this.textBox23);
            this.pnlMachineStatus.Controls.Add(this.txtMachineMode);
            this.pnlMachineStatus.Controls.Add(this.textBox25);
            this.pnlMachineStatus.Controls.Add(this.textBox7);
            this.pnlMachineStatus.Controls.Add(this.textBox6);
            this.pnlMachineStatus.Controls.Add(this.textBox5);
            this.pnlMachineStatus.Controls.Add(this.textBox4);
            this.pnlMachineStatus.Controls.Add(this.textBox3);
            this.pnlMachineStatus.Controls.Add(this.textBox2);
            this.pnlMachineStatus.Controls.Add(this.label4);
            this.pnlMachineStatus.Controls.Add(this.txtUph);
            this.pnlMachineStatus.Controls.Add(this.txtCycletime);
            this.pnlMachineStatus.Controls.Add(this.textBox17);
            this.pnlMachineStatus.Controls.Add(this.textBox16);
            this.pnlMachineStatus.Controls.Add(this.txtyYeldcnt);
            this.pnlMachineStatus.Controls.Add(this.txtOverallcnt);
            this.pnlMachineStatus.Controls.Add(this.txtFailcnt);
            this.pnlMachineStatus.Controls.Add(this.txtPasscnt);
            this.pnlMachineStatus.Controls.Add(this.textBox13);
            this.pnlMachineStatus.Controls.Add(this.textBox12);
            this.pnlMachineStatus.Controls.Add(this.textBox11);
            this.pnlMachineStatus.Controls.Add(this.textBox8);
            this.pnlMachineStatus.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.pnlMachineStatus.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.pnlMachineStatus.Location = new System.Drawing.Point(295, 12);
            this.pnlMachineStatus.Name = "pnlMachineStatus";
            this.pnlMachineStatus.Size = new System.Drawing.Size(297, 264);
            this.pnlMachineStatus.TabIndex = 96;
            // 
            // textBox23
            // 
            this.textBox23.BackColor = System.Drawing.Color.White;
            this.textBox23.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox23.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox23.Location = new System.Drawing.Point(130, 46);
            this.textBox23.Name = "textBox23";
            this.textBox23.ReadOnly = true;
            this.textBox23.Size = new System.Drawing.Size(15, 17);
            this.textBox23.TabIndex = 108;
            this.textBox23.Text = " :";
            // 
            // txtMachineMode
            // 
            this.txtMachineMode.BackColor = System.Drawing.Color.White;
            this.txtMachineMode.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtMachineMode.Enabled = false;
            this.txtMachineMode.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMachineMode.Location = new System.Drawing.Point(166, 46);
            this.txtMachineMode.Name = "txtMachineMode";
            this.txtMachineMode.ReadOnly = true;
            this.txtMachineMode.Size = new System.Drawing.Size(123, 17);
            this.txtMachineMode.TabIndex = 107;
            this.txtMachineMode.Text = "Dry Run";
            // 
            // textBox25
            // 
            this.textBox25.BackColor = System.Drawing.Color.White;
            this.textBox25.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox25.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.textBox25.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox25.Location = new System.Drawing.Point(10, 46);
            this.textBox25.Name = "textBox25";
            this.textBox25.ReadOnly = true;
            this.textBox25.Size = new System.Drawing.Size(117, 17);
            this.textBox25.TabIndex = 106;
            this.textBox25.Text = "Machine Mode";
            // 
            // textBox7
            // 
            this.textBox7.BackColor = System.Drawing.Color.White;
            this.textBox7.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox7.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox7.Location = new System.Drawing.Point(130, 232);
            this.textBox7.Name = "textBox7";
            this.textBox7.ReadOnly = true;
            this.textBox7.Size = new System.Drawing.Size(15, 17);
            this.textBox7.TabIndex = 105;
            this.textBox7.Text = " :";
            // 
            // textBox6
            // 
            this.textBox6.BackColor = System.Drawing.Color.White;
            this.textBox6.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox6.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox6.Location = new System.Drawing.Point(130, 197);
            this.textBox6.Name = "textBox6";
            this.textBox6.ReadOnly = true;
            this.textBox6.Size = new System.Drawing.Size(15, 17);
            this.textBox6.TabIndex = 104;
            this.textBox6.Text = " :";
            // 
            // textBox5
            // 
            this.textBox5.BackColor = System.Drawing.Color.White;
            this.textBox5.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox5.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox5.Location = new System.Drawing.Point(130, 167);
            this.textBox5.Name = "textBox5";
            this.textBox5.ReadOnly = true;
            this.textBox5.Size = new System.Drawing.Size(15, 17);
            this.textBox5.TabIndex = 103;
            this.textBox5.Text = " :";
            // 
            // textBox4
            // 
            this.textBox4.BackColor = System.Drawing.Color.White;
            this.textBox4.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox4.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox4.Location = new System.Drawing.Point(130, 137);
            this.textBox4.Name = "textBox4";
            this.textBox4.ReadOnly = true;
            this.textBox4.Size = new System.Drawing.Size(15, 17);
            this.textBox4.TabIndex = 102;
            this.textBox4.Text = " :";
            // 
            // textBox3
            // 
            this.textBox3.BackColor = System.Drawing.Color.White;
            this.textBox3.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox3.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox3.Location = new System.Drawing.Point(130, 106);
            this.textBox3.Name = "textBox3";
            this.textBox3.ReadOnly = true;
            this.textBox3.Size = new System.Drawing.Size(15, 17);
            this.textBox3.TabIndex = 101;
            this.textBox3.Text = " :";
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.Color.White;
            this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox2.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox2.Location = new System.Drawing.Point(130, 77);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(15, 17);
            this.textBox2.TabIndex = 100;
            this.textBox2.Text = " :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Verdana", 13.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(83, 6);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(203, 23);
            this.label4.TabIndex = 99;
            this.label4.Text = "MACHINE STATUS";
            // 
            // txtUph
            // 
            this.txtUph.BackColor = System.Drawing.Color.White;
            this.txtUph.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtUph.Enabled = false;
            this.txtUph.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUph.Location = new System.Drawing.Point(166, 232);
            this.txtUph.Name = "txtUph";
            this.txtUph.ReadOnly = true;
            this.txtUph.Size = new System.Drawing.Size(123, 17);
            this.txtUph.TabIndex = 98;
            this.txtUph.Text = "0";
            // 
            // txtCycletime
            // 
            this.txtCycletime.BackColor = System.Drawing.Color.White;
            this.txtCycletime.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtCycletime.Enabled = false;
            this.txtCycletime.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCycletime.Location = new System.Drawing.Point(166, 197);
            this.txtCycletime.Name = "txtCycletime";
            this.txtCycletime.ReadOnly = true;
            this.txtCycletime.Size = new System.Drawing.Size(123, 17);
            this.txtCycletime.TabIndex = 98;
            this.txtCycletime.Text = "0";
            // 
            // textBox17
            // 
            this.textBox17.BackColor = System.Drawing.Color.White;
            this.textBox17.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox17.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.textBox17.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox17.Location = new System.Drawing.Point(10, 232);
            this.textBox17.Name = "textBox17";
            this.textBox17.ReadOnly = true;
            this.textBox17.Size = new System.Drawing.Size(117, 17);
            this.textBox17.TabIndex = 97;
            this.textBox17.Text = "UPH               ";
            // 
            // textBox16
            // 
            this.textBox16.BackColor = System.Drawing.Color.White;
            this.textBox16.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox16.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.textBox16.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox16.Location = new System.Drawing.Point(10, 197);
            this.textBox16.Name = "textBox16";
            this.textBox16.ReadOnly = true;
            this.textBox16.Size = new System.Drawing.Size(117, 17);
            this.textBox16.TabIndex = 97;
            this.textBox16.Text = "Cycle Time      ";
            // 
            // txtyYeldcnt
            // 
            this.txtyYeldcnt.BackColor = System.Drawing.Color.White;
            this.txtyYeldcnt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtyYeldcnt.Enabled = false;
            this.txtyYeldcnt.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtyYeldcnt.Location = new System.Drawing.Point(166, 137);
            this.txtyYeldcnt.Name = "txtyYeldcnt";
            this.txtyYeldcnt.ReadOnly = true;
            this.txtyYeldcnt.Size = new System.Drawing.Size(123, 17);
            this.txtyYeldcnt.TabIndex = 96;
            this.txtyYeldcnt.Text = "0";
            // 
            // txtOverallcnt
            // 
            this.txtOverallcnt.BackColor = System.Drawing.Color.White;
            this.txtOverallcnt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtOverallcnt.Enabled = false;
            this.txtOverallcnt.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOverallcnt.Location = new System.Drawing.Point(166, 167);
            this.txtOverallcnt.Name = "txtOverallcnt";
            this.txtOverallcnt.ReadOnly = true;
            this.txtOverallcnt.Size = new System.Drawing.Size(123, 17);
            this.txtOverallcnt.TabIndex = 95;
            this.txtOverallcnt.Text = "0";
            // 
            // txtFailcnt
            // 
            this.txtFailcnt.BackColor = System.Drawing.Color.White;
            this.txtFailcnt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtFailcnt.Enabled = false;
            this.txtFailcnt.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFailcnt.Location = new System.Drawing.Point(166, 106);
            this.txtFailcnt.Name = "txtFailcnt";
            this.txtFailcnt.ReadOnly = true;
            this.txtFailcnt.Size = new System.Drawing.Size(123, 17);
            this.txtFailcnt.TabIndex = 94;
            this.txtFailcnt.Text = "0";
            // 
            // txtPasscnt
            // 
            this.txtPasscnt.BackColor = System.Drawing.Color.White;
            this.txtPasscnt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtPasscnt.Enabled = false;
            this.txtPasscnt.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPasscnt.Location = new System.Drawing.Point(166, 77);
            this.txtPasscnt.Name = "txtPasscnt";
            this.txtPasscnt.ReadOnly = true;
            this.txtPasscnt.Size = new System.Drawing.Size(123, 17);
            this.txtPasscnt.TabIndex = 36;
            this.txtPasscnt.Text = "0";
            // 
            // textBox13
            // 
            this.textBox13.BackColor = System.Drawing.Color.White;
            this.textBox13.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox13.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.textBox13.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox13.Location = new System.Drawing.Point(10, 137);
            this.textBox13.Name = "textBox13";
            this.textBox13.ReadOnly = true;
            this.textBox13.Size = new System.Drawing.Size(117, 17);
            this.textBox13.TabIndex = 35;
            this.textBox13.Text = "Yield              ";
            // 
            // textBox12
            // 
            this.textBox12.BackColor = System.Drawing.Color.White;
            this.textBox12.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox12.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.textBox12.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox12.Location = new System.Drawing.Point(10, 167);
            this.textBox12.Name = "textBox12";
            this.textBox12.ReadOnly = true;
            this.textBox12.Size = new System.Drawing.Size(117, 17);
            this.textBox12.TabIndex = 35;
            this.textBox12.Text = "Overall Count  ";
            // 
            // textBox11
            // 
            this.textBox11.BackColor = System.Drawing.Color.White;
            this.textBox11.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox11.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.textBox11.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox11.Location = new System.Drawing.Point(10, 106);
            this.textBox11.Name = "textBox11";
            this.textBox11.ReadOnly = true;
            this.textBox11.Size = new System.Drawing.Size(117, 17);
            this.textBox11.TabIndex = 35;
            this.textBox11.Text = "Fail Count       ";
            // 
            // textBox8
            // 
            this.textBox8.BackColor = System.Drawing.Color.White;
            this.textBox8.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox8.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.textBox8.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox8.Location = new System.Drawing.Point(10, 77);
            this.textBox8.Name = "textBox8";
            this.textBox8.ReadOnly = true;
            this.textBox8.Size = new System.Drawing.Size(117, 17);
            this.textBox8.TabIndex = 35;
            this.textBox8.Text = "Pass Count     ";
            // 
            // pnlMachineHealth
            // 
            this.pnlMachineHealth.BackColor = System.Drawing.Color.White;
            this.pnlMachineHealth.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlMachineHealth.Controls.Add(this.button3);
            this.pnlMachineHealth.Controls.Add(this.label2);
            this.pnlMachineHealth.Controls.Add(this.linkLabel2);
            this.pnlMachineHealth.Controls.Add(this.lblShift);
            this.pnlMachineHealth.Controls.Add(this.label3);
            this.pnlMachineHealth.Controls.Add(this.button12);
            this.pnlMachineHealth.Controls.Add(this.button13);
            this.pnlMachineHealth.Controls.Add(this.button14);
            this.pnlMachineHealth.Controls.Add(this.label14);
            this.pnlMachineHealth.Controls.Add(this.label17);
            this.pnlMachineHealth.Controls.Add(this.label20);
            this.pnlMachineHealth.Controls.Add(this.label21);
            this.pnlMachineHealth.Controls.Add(this.lblTotaltime);
            this.pnlMachineHealth.Controls.Add(this.lblIdletime);
            this.pnlMachineHealth.Controls.Add(this.lblDowntime);
            this.pnlMachineHealth.Controls.Add(this.lblRunTime);
            this.pnlMachineHealth.Controls.Add(this.label26);
            this.pnlMachineHealth.Controls.Add(this.label27);
            this.pnlMachineHealth.Controls.Add(this.label28);
            this.pnlMachineHealth.Controls.Add(this.label29);
            this.pnlMachineHealth.Location = new System.Drawing.Point(7, 13);
            this.pnlMachineHealth.Name = "pnlMachineHealth";
            this.pnlMachineHealth.Size = new System.Drawing.Size(282, 263);
            this.pnlMachineHealth.TabIndex = 95;
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.Blue;
            this.button3.FlatAppearance.BorderColor = System.Drawing.Color.Yellow;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.Location = new System.Drawing.Point(12, 232);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(21, 23);
            this.button3.TabIndex = 89;
            this.button3.UseVisualStyleBackColor = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 13.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(32, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(204, 23);
            this.label2.TabIndex = 93;
            this.label2.Text = "MACHINE HEALTH";
            // 
            // linkLabel2
            // 
            this.linkLabel2.Location = new System.Drawing.Point(0, 0);
            this.linkLabel2.Name = "linkLabel2";
            this.linkLabel2.Size = new System.Drawing.Size(99, 23);
            this.linkLabel2.TabIndex = 0;
            // 
            // lblShift
            // 
            this.lblShift.AutoSize = true;
            this.lblShift.BackColor = System.Drawing.Color.Transparent;
            this.lblShift.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblShift.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblShift.Location = new System.Drawing.Point(105, 51);
            this.lblShift.Name = "lblShift";
            this.lblShift.Size = new System.Drawing.Size(19, 17);
            this.lblShift.TabIndex = 90;
            this.lblShift.Text = "A";
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label3.Location = new System.Drawing.Point(10, 51);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 16);
            this.label3.TabIndex = 89;
            this.label3.Text = "Current Shift";
            // 
            // button12
            // 
            this.button12.BackColor = System.Drawing.Color.Yellow;
            this.button12.FlatAppearance.BorderColor = System.Drawing.Color.Yellow;
            this.button12.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button12.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button12.Location = new System.Drawing.Point(12, 185);
            this.button12.Name = "button12";
            this.button12.Size = new System.Drawing.Size(21, 23);
            this.button12.TabIndex = 88;
            this.button12.UseVisualStyleBackColor = false;
            // 
            // button13
            // 
            this.button13.BackColor = System.Drawing.Color.Red;
            this.button13.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.button13.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button13.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button13.Location = new System.Drawing.Point(12, 136);
            this.button13.Name = "button13";
            this.button13.Size = new System.Drawing.Size(21, 23);
            this.button13.TabIndex = 86;
            this.button13.UseVisualStyleBackColor = false;
            // 
            // button14
            // 
            this.button14.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.button14.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.button14.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button14.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button14.Location = new System.Drawing.Point(12, 88);
            this.button14.Name = "button14";
            this.button14.Size = new System.Drawing.Size(21, 23);
            this.button14.TabIndex = 85;
            this.button14.UseVisualStyleBackColor = false;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.BackColor = System.Drawing.Color.Transparent;
            this.label14.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(203, 236);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(26, 17);
            this.label14.TabIndex = 42;
            this.label14.Text = "Hr";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.BackColor = System.Drawing.Color.Transparent;
            this.label17.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(203, 188);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(26, 17);
            this.label17.TabIndex = 41;
            this.label17.Text = "Hr";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.BackColor = System.Drawing.Color.Transparent;
            this.label20.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.Location = new System.Drawing.Point(203, 140);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(26, 17);
            this.label20.TabIndex = 39;
            this.label20.Text = "Hr";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.BackColor = System.Drawing.Color.Transparent;
            this.label21.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.Location = new System.Drawing.Point(203, 91);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(26, 17);
            this.label21.TabIndex = 38;
            this.label21.Text = "Hr";
            // 
            // lblTotaltime
            // 
            this.lblTotaltime.BackColor = System.Drawing.Color.Transparent;
            this.lblTotaltime.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotaltime.Location = new System.Drawing.Point(158, 235);
            this.lblTotaltime.Name = "lblTotaltime";
            this.lblTotaltime.Size = new System.Drawing.Size(40, 18);
            this.lblTotaltime.TabIndex = 37;
            this.lblTotaltime.Text = "0";
            // 
            // lblIdletime
            // 
            this.lblIdletime.BackColor = System.Drawing.Color.Transparent;
            this.lblIdletime.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIdletime.Location = new System.Drawing.Point(158, 188);
            this.lblIdletime.Name = "lblIdletime";
            this.lblIdletime.Size = new System.Drawing.Size(40, 18);
            this.lblIdletime.TabIndex = 36;
            this.lblIdletime.Text = "0";
            // 
            // lblDowntime
            // 
            this.lblDowntime.BackColor = System.Drawing.Color.Transparent;
            this.lblDowntime.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDowntime.Location = new System.Drawing.Point(158, 139);
            this.lblDowntime.Name = "lblDowntime";
            this.lblDowntime.Size = new System.Drawing.Size(40, 18);
            this.lblDowntime.TabIndex = 34;
            this.lblDowntime.Text = "0";
            // 
            // lblRunTime
            // 
            this.lblRunTime.BackColor = System.Drawing.Color.Transparent;
            this.lblRunTime.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRunTime.Location = new System.Drawing.Point(158, 90);
            this.lblRunTime.Name = "lblRunTime";
            this.lblRunTime.Size = new System.Drawing.Size(40, 18);
            this.lblRunTime.TabIndex = 33;
            this.lblRunTime.Text = "0";
            // 
            // label26
            // 
            this.label26.BackColor = System.Drawing.Color.Transparent;
            this.label26.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label26.Location = new System.Drawing.Point(38, 234);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(111, 20);
            this.label26.TabIndex = 32;
            this.label26.Text = "Total Time   :";
            this.label26.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label27
            // 
            this.label27.BackColor = System.Drawing.Color.Transparent;
            this.label27.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label27.Location = new System.Drawing.Point(38, 188);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(104, 16);
            this.label27.TabIndex = 31;
            this.label27.Text = "Idle Time    :";
            this.label27.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label28
            // 
            this.label28.BackColor = System.Drawing.Color.Transparent;
            this.label28.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label28.Location = new System.Drawing.Point(38, 139);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(105, 18);
            this.label28.TabIndex = 29;
            this.label28.Text = "Down Time  :";
            this.label28.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label29
            // 
            this.label29.BackColor = System.Drawing.Color.Transparent;
            this.label29.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label29.Location = new System.Drawing.Point(38, 89);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(103, 20);
            this.label29.TabIndex = 28;
            this.label29.Text = "Run Time    :";
            this.label29.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Homing
            // 
            this.Homing.BackColor = System.Drawing.Color.Yellow;
            this.Homing.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Homing.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Homing.Location = new System.Drawing.Point(417, 535);
            this.Homing.Name = "Homing";
            this.Homing.Size = new System.Drawing.Size(165, 43);
            this.Homing.TabIndex = 94;
            this.Homing.Text = "System Reset / Homing";
            this.Homing.UseVisualStyleBackColor = false;
            this.Homing.Click += new System.EventHandler(this.Homing_Click);
            // 
            // tabLog
            // 
            this.tabLog.Controls.Add(this.tabPage1);
            this.tabLog.Controls.Add(this.tabPage2);
            this.tabLog.Controls.Add(this.tabPage5);
            this.tabLog.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabLog.Location = new System.Drawing.Point(7, 282);
            this.tabLog.Name = "tabLog";
            this.tabLog.SelectedIndex = 0;
            this.tabLog.Size = new System.Drawing.Size(1009, 247);
            this.tabLog.TabIndex = 46;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.txtonlypasting);
            this.tabPage1.Controls.Add(this.txtout);
            this.tabPage1.Controls.Add(this.button2);
            this.tabPage1.Controls.Add(this.lstRunningLog);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1001, 218);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Running Log";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // txtonlypasting
            // 
            this.txtonlypasting.BackColor = System.Drawing.Color.White;
            this.txtonlypasting.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtonlypasting.Enabled = false;
            this.txtonlypasting.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtonlypasting.Location = new System.Drawing.Point(623, 36);
            this.txtonlypasting.Name = "txtonlypasting";
            this.txtonlypasting.ReadOnly = true;
            this.txtonlypasting.Size = new System.Drawing.Size(123, 17);
            this.txtonlypasting.TabIndex = 99;
            this.txtonlypasting.Text = "0";
            // 
            // txtout
            // 
            this.txtout.BackColor = System.Drawing.Color.White;
            this.txtout.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtout.Enabled = false;
            this.txtout.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtout.Location = new System.Drawing.Point(876, 36);
            this.txtout.Name = "txtout";
            this.txtout.ReadOnly = true;
            this.txtout.Size = new System.Drawing.Size(123, 17);
            this.txtout.TabIndex = 100;
            this.txtout.Text = "0";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(295, 69);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 99;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Visible = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // lstRunningLog
            // 
            this.lstRunningLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstRunningLog.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstRunningLog.ForeColor = System.Drawing.Color.Black;
            this.lstRunningLog.FormattingEnabled = true;
            this.lstRunningLog.ItemHeight = 16;
            this.lstRunningLog.Location = new System.Drawing.Point(3, 3);
            this.lstRunningLog.Name = "lstRunningLog";
            this.lstRunningLog.Size = new System.Drawing.Size(995, 212);
            this.lstRunningLog.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.dgvAlarmlive);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1001, 218);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Alarm";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // dgvAlarmlive
            // 
            this.dgvAlarmlive.AllowUserToAddRows = false;
            this.dgvAlarmlive.BackgroundColor = System.Drawing.Color.Red;
            this.dgvAlarmlive.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAlarmlive.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvAlarmlive.Location = new System.Drawing.Point(3, 3);
            this.dgvAlarmlive.Name = "dgvAlarmlive";
            this.dgvAlarmlive.ReadOnly = true;
            this.dgvAlarmlive.RowHeadersWidth = 51;
            this.dgvAlarmlive.Size = new System.Drawing.Size(995, 212);
            this.dgvAlarmlive.TabIndex = 51;
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.textBox19);
            this.tabPage5.Controls.Add(this.label11);
            this.tabPage5.Controls.Add(this.textBox18);
            this.tabPage5.Controls.Add(this.label10);
            this.tabPage5.Controls.Add(this.textBox15);
            this.tabPage5.Controls.Add(this.label9);
            this.tabPage5.Controls.Add(this.textBox14);
            this.tabPage5.Controls.Add(this.textBox10);
            this.tabPage5.Controls.Add(this.textBox9);
            this.tabPage5.Controls.Add(this.label8);
            this.tabPage5.Controls.Add(this.label7);
            this.tabPage5.Controls.Add(this.label6);
            this.tabPage5.Controls.Add(this.textBox1);
            this.tabPage5.Controls.Add(this.label5);
            this.tabPage5.Location = new System.Drawing.Point(4, 25);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Size = new System.Drawing.Size(1001, 218);
            this.tabPage5.TabIndex = 2;
            this.tabPage5.Text = "current Step";
            this.tabPage5.UseVisualStyleBackColor = true;
            this.tabPage5.Click += new System.EventHandler(this.tabPage5_Click);
            // 
            // textBox19
            // 
            this.textBox19.Location = new System.Drawing.Point(397, 64);
            this.textBox19.Name = "textBox19";
            this.textBox19.Size = new System.Drawing.Size(100, 23);
            this.textBox19.TabIndex = 16;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(316, 67);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(65, 16);
            this.label11.TabIndex = 15;
            this.label11.Text = "Feeding";
            // 
            // textBox18
            // 
            this.textBox18.Location = new System.Drawing.Point(397, 31);
            this.textBox18.Name = "textBox18";
            this.textBox18.Size = new System.Drawing.Size(100, 23);
            this.textBox18.TabIndex = 14;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(316, 34);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(75, 16);
            this.label10.TabIndex = 13;
            this.label10.Text = "Rejection";
            // 
            // textBox15
            // 
            this.textBox15.Location = new System.Drawing.Point(133, 181);
            this.textBox15.Name = "textBox15";
            this.textBox15.Size = new System.Drawing.Size(100, 23);
            this.textBox15.TabIndex = 12;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(50, 184);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(77, 16);
            this.label9.TabIndex = 11;
            this.label9.Text = "working 2";
            // 
            // textBox14
            // 
            this.textBox14.Location = new System.Drawing.Point(133, 144);
            this.textBox14.Name = "textBox14";
            this.textBox14.Size = new System.Drawing.Size(100, 23);
            this.textBox14.TabIndex = 10;
            // 
            // textBox10
            // 
            this.textBox10.Location = new System.Drawing.Point(133, 64);
            this.textBox10.Name = "textBox10";
            this.textBox10.Size = new System.Drawing.Size(100, 23);
            this.textBox10.TabIndex = 9;
            // 
            // textBox9
            // 
            this.textBox9.Location = new System.Drawing.Point(133, 105);
            this.textBox9.Name = "textBox9";
            this.textBox9.Size = new System.Drawing.Size(100, 23);
            this.textBox9.TabIndex = 8;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(50, 147);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(77, 16);
            this.label8.TabIndex = 4;
            this.label8.Text = "working 1";
            this.label8.Click += new System.EventHandler(this.label8_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(58, 112);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(64, 16);
            this.label7.TabIndex = 3;
            this.label7.Text = "Loading";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(40, 67);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(91, 16);
            this.label6.TabIndex = 2;
            this.label6.Text = "Move Paste";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(133, 31);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 23);
            this.textBox1.TabIndex = 1;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(58, 31);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(63, 16);
            this.label5.TabIndex = 0;
            this.label5.Text = "Homing";
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.label62);
            this.tabPage4.Controls.Add(this.label61);
            this.tabPage4.Controls.Add(this.panel7_4);
            this.tabPage4.Controls.Add(this.panel7);
            this.tabPage4.Controls.Add(this.panel2);
            this.tabPage4.Location = new System.Drawing.Point(4, 27);
            this.tabPage4.Margin = new System.Windows.Forms.Padding(2);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(2);
            this.tabPage4.Size = new System.Drawing.Size(967, 589);
            this.tabPage4.TabIndex = 1;
            this.tabPage4.Text = "MACHINE DETAILS";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // label62
            // 
            this.label62.AutoSize = true;
            this.label62.BackColor = System.Drawing.Color.Transparent;
            this.label62.Font = new System.Drawing.Font("Verdana", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label62.Location = new System.Drawing.Point(412, 325);
            this.label62.Name = "label62";
            this.label62.Size = new System.Drawing.Size(169, 18);
            this.label62.TabIndex = 348;
            this.label62.Text = "Tray Cavity Status";
            // 
            // label61
            // 
            this.label61.AutoSize = true;
            this.label61.BackColor = System.Drawing.Color.Transparent;
            this.label61.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label61.Location = new System.Drawing.Point(390, 323);
            this.label61.Name = "label61";
            this.label61.Size = new System.Drawing.Size(0, 18);
            this.label61.TabIndex = 338;
            this.label61.Visible = false;
            // 
            // panel7_4
            // 
            this.panel7_4.BackColor = System.Drawing.Color.Gainsboro;
            this.panel7_4.Controls.Add(this.label58);
            this.panel7_4.Controls.Add(this.panel8_4);
            this.panel7_4.Controls.Add(this.label59);
            this.panel7_4.Controls.Add(this.panel3_4);
            this.panel7_4.Controls.Add(this.label60);
            this.panel7_4.Controls.Add(this.pnlScanner_4);
            this.panel7_4.Location = new System.Drawing.Point(23, 347);
            this.panel7_4.Name = "panel7_4";
            this.panel7_4.Size = new System.Drawing.Size(940, 234);
            this.panel7_4.TabIndex = 36;
            // 
            // label58
            // 
            this.label58.AutoSize = true;
            this.label58.BackColor = System.Drawing.Color.Transparent;
            this.label58.Font = new System.Drawing.Font("Verdana", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label58.Location = new System.Drawing.Point(727, 21);
            this.label58.Name = "label58";
            this.label58.Size = new System.Drawing.Size(131, 18);
            this.label58.TabIndex = 344;
            this.label58.Text = "Tray Cavity FI";
            // 
            // panel8_4
            // 
            this.panel8_4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel8_4.Controls.Add(this.BN_WK2_4);
            this.panel8_4.Controls.Add(this.lblFI_12_4);
            this.panel8_4.Controls.Add(this.lblFI_1_4);
            this.panel8_4.Controls.Add(this.lblFI_11_4);
            this.panel8_4.Controls.Add(this.lblFI_2_4);
            this.panel8_4.Controls.Add(this.lblFI_10_4);
            this.panel8_4.Controls.Add(this.lblFI_3_4);
            this.panel8_4.Controls.Add(this.lblFI_9_4);
            this.panel8_4.Controls.Add(this.lblFI_4_4);
            this.panel8_4.Controls.Add(this.lblFI_8_4);
            this.panel8_4.Controls.Add(this.lblFI_5_4);
            this.panel8_4.Controls.Add(this.lblFI_7_4);
            this.panel8_4.Controls.Add(this.lblFI_6_4);
            this.panel8_4.Location = new System.Drawing.Point(647, 32);
            this.panel8_4.Name = "panel8_4";
            this.panel8_4.Size = new System.Drawing.Size(291, 187);
            this.panel8_4.TabIndex = 347;
            // 
            // BN_WK2_4
            // 
            this.BN_WK2_4.BackColor = System.Drawing.Color.DarkGray;
            this.BN_WK2_4.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BN_WK2_4.Location = new System.Drawing.Point(51, 17);
            this.BN_WK2_4.Name = "BN_WK2_4";
            this.BN_WK2_4.Size = new System.Drawing.Size(180, 23);
            this.BN_WK2_4.TabIndex = 348;
            this.BN_WK2_4.Tag = "how to combine 2 labels in one Winforms UIhow to combine 2 labels in one Winforms" +
    " UI";
            this.BN_WK2_4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblFI_12_4
            // 
            this.lblFI_12_4.BackColor = System.Drawing.Color.DarkGray;
            this.lblFI_12_4.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFI_12_4.Location = new System.Drawing.Point(190, 151);
            this.lblFI_12_4.Name = "lblFI_12_4";
            this.lblFI_12_4.Size = new System.Drawing.Size(84, 23);
            this.lblFI_12_4.TabIndex = 35;
            this.lblFI_12_4.Tag = "how to combine 2 labels in one Winforms UIhow to combine 2 labels in one Winforms" +
    " UI";
            this.lblFI_12_4.Text = "12";
            this.lblFI_12_4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblFI_1_4
            // 
            this.lblFI_1_4.BackColor = System.Drawing.Color.DarkGray;
            this.lblFI_1_4.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFI_1_4.Location = new System.Drawing.Point(14, 54);
            this.lblFI_1_4.Name = "lblFI_1_4";
            this.lblFI_1_4.Size = new System.Drawing.Size(83, 23);
            this.lblFI_1_4.TabIndex = 24;
            this.lblFI_1_4.Tag = "how to combine 2 labels in one Winforms UIhow to combine 2 labels in one Winforms" +
    " UI";
            this.lblFI_1_4.Text = "1";
            this.lblFI_1_4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblFI_11_4
            // 
            this.lblFI_11_4.BackColor = System.Drawing.Color.DarkGray;
            this.lblFI_11_4.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFI_11_4.Location = new System.Drawing.Point(105, 151);
            this.lblFI_11_4.Name = "lblFI_11_4";
            this.lblFI_11_4.Size = new System.Drawing.Size(79, 23);
            this.lblFI_11_4.TabIndex = 34;
            this.lblFI_11_4.Tag = "how to combine 2 labels in one Winforms UIhow to combine 2 labels in one Winforms" +
    " UI";
            this.lblFI_11_4.Text = "11";
            this.lblFI_11_4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblFI_2_4
            // 
            this.lblFI_2_4.BackColor = System.Drawing.Color.DarkGray;
            this.lblFI_2_4.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFI_2_4.Location = new System.Drawing.Point(102, 54);
            this.lblFI_2_4.Name = "lblFI_2_4";
            this.lblFI_2_4.Size = new System.Drawing.Size(82, 23);
            this.lblFI_2_4.TabIndex = 25;
            this.lblFI_2_4.Tag = "how to combine 2 labels in one Winforms UIhow to combine 2 labels in one Winforms" +
    " UI";
            this.lblFI_2_4.Text = "2";
            this.lblFI_2_4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblFI_10_4
            // 
            this.lblFI_10_4.BackColor = System.Drawing.Color.DarkGray;
            this.lblFI_10_4.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFI_10_4.Location = new System.Drawing.Point(14, 151);
            this.lblFI_10_4.Name = "lblFI_10_4";
            this.lblFI_10_4.Size = new System.Drawing.Size(83, 23);
            this.lblFI_10_4.TabIndex = 33;
            this.lblFI_10_4.Tag = "how to combine 2 labels in one Winforms UIhow to combine 2 labels in one Winforms" +
    " UI";
            this.lblFI_10_4.Text = "10";
            this.lblFI_10_4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblFI_3_4
            // 
            this.lblFI_3_4.BackColor = System.Drawing.Color.DarkGray;
            this.lblFI_3_4.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFI_3_4.Location = new System.Drawing.Point(188, 54);
            this.lblFI_3_4.Name = "lblFI_3_4";
            this.lblFI_3_4.Size = new System.Drawing.Size(87, 23);
            this.lblFI_3_4.TabIndex = 26;
            this.lblFI_3_4.Tag = "how to combine 2 labels in one Winforms UIhow to combine 2 labels in one Winforms" +
    " UI";
            this.lblFI_3_4.Text = "3";
            this.lblFI_3_4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblFI_9_4
            // 
            this.lblFI_9_4.BackColor = System.Drawing.Color.DarkGray;
            this.lblFI_9_4.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFI_9_4.Location = new System.Drawing.Point(190, 119);
            this.lblFI_9_4.Name = "lblFI_9_4";
            this.lblFI_9_4.Size = new System.Drawing.Size(84, 23);
            this.lblFI_9_4.TabIndex = 32;
            this.lblFI_9_4.Tag = "how to combine 2 labels in one Winforms UIhow to combine 2 labels in one Winforms" +
    " UI";
            this.lblFI_9_4.Text = "9";
            this.lblFI_9_4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblFI_4_4
            // 
            this.lblFI_4_4.BackColor = System.Drawing.Color.DarkGray;
            this.lblFI_4_4.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFI_4_4.Location = new System.Drawing.Point(14, 86);
            this.lblFI_4_4.Name = "lblFI_4_4";
            this.lblFI_4_4.Size = new System.Drawing.Size(83, 23);
            this.lblFI_4_4.TabIndex = 27;
            this.lblFI_4_4.Tag = "how to combine 2 labels in one Winforms UIhow to combine 2 labels in one Winforms" +
    " UI";
            this.lblFI_4_4.Text = "4";
            this.lblFI_4_4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblFI_8_4
            // 
            this.lblFI_8_4.BackColor = System.Drawing.Color.DarkGray;
            this.lblFI_8_4.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFI_8_4.Location = new System.Drawing.Point(105, 119);
            this.lblFI_8_4.Name = "lblFI_8_4";
            this.lblFI_8_4.Size = new System.Drawing.Size(79, 23);
            this.lblFI_8_4.TabIndex = 31;
            this.lblFI_8_4.Tag = "how to combine 2 labels in one Winforms UIhow to combine 2 labels in one Winforms" +
    " UI";
            this.lblFI_8_4.Text = "8";
            this.lblFI_8_4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblFI_5_4
            // 
            this.lblFI_5_4.BackColor = System.Drawing.Color.DarkGray;
            this.lblFI_5_4.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFI_5_4.Location = new System.Drawing.Point(105, 86);
            this.lblFI_5_4.Name = "lblFI_5_4";
            this.lblFI_5_4.Size = new System.Drawing.Size(79, 23);
            this.lblFI_5_4.TabIndex = 28;
            this.lblFI_5_4.Tag = "how to combine 2 labels in one Winforms UIhow to combine 2 labels in one Winforms" +
    " UI";
            this.lblFI_5_4.Text = "5";
            this.lblFI_5_4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblFI_7_4
            // 
            this.lblFI_7_4.BackColor = System.Drawing.Color.DarkGray;
            this.lblFI_7_4.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFI_7_4.Location = new System.Drawing.Point(14, 119);
            this.lblFI_7_4.Name = "lblFI_7_4";
            this.lblFI_7_4.Size = new System.Drawing.Size(83, 23);
            this.lblFI_7_4.TabIndex = 30;
            this.lblFI_7_4.Tag = "how to combine 2 labels in one Winforms UIhow to combine 2 labels in one Winforms" +
    " UI";
            this.lblFI_7_4.Text = "7";
            this.lblFI_7_4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblFI_6_4
            // 
            this.lblFI_6_4.BackColor = System.Drawing.Color.DarkGray;
            this.lblFI_6_4.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFI_6_4.Location = new System.Drawing.Point(190, 86);
            this.lblFI_6_4.Name = "lblFI_6_4";
            this.lblFI_6_4.Size = new System.Drawing.Size(84, 23);
            this.lblFI_6_4.TabIndex = 29;
            this.lblFI_6_4.Tag = "how to combine 2 labels in one Winforms UIhow to combine 2 labels in one Winforms" +
    " UI";
            this.lblFI_6_4.Text = "6";
            this.lblFI_6_4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label59
            // 
            this.label59.AutoSize = true;
            this.label59.BackColor = System.Drawing.Color.Transparent;
            this.label59.Font = new System.Drawing.Font("Verdana", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label59.Location = new System.Drawing.Point(382, 22);
            this.label59.Name = "label59";
            this.label59.Size = new System.Drawing.Size(195, 18);
            this.label59.TabIndex = 343;
            this.label59.Text = "Tray Cavity Assembly";
            // 
            // panel3_4
            // 
            this.panel3_4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3_4.Controls.Add(this.BN_wk1_4);
            this.panel3_4.Controls.Add(this.lblAS_12_4);
            this.panel3_4.Controls.Add(this.lblAS_1_4);
            this.panel3_4.Controls.Add(this.lblAS_11_4);
            this.panel3_4.Controls.Add(this.lblAS_2_4);
            this.panel3_4.Controls.Add(this.lblAS_10_4);
            this.panel3_4.Controls.Add(this.lblAS_3_4);
            this.panel3_4.Controls.Add(this.lblAS_9_4);
            this.panel3_4.Controls.Add(this.lblAS_4_4);
            this.panel3_4.Controls.Add(this.lblAS_8_4);
            this.panel3_4.Controls.Add(this.lblAS_5_4);
            this.panel3_4.Controls.Add(this.lblAS_7_4);
            this.panel3_4.Controls.Add(this.lblAS_6_4);
            this.panel3_4.Location = new System.Drawing.Point(342, 32);
            this.panel3_4.Name = "panel3_4";
            this.panel3_4.Size = new System.Drawing.Size(299, 187);
            this.panel3_4.TabIndex = 346;
            // 
            // BN_wk1_4
            // 
            this.BN_wk1_4.BackColor = System.Drawing.Color.DarkGray;
            this.BN_wk1_4.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BN_wk1_4.Location = new System.Drawing.Point(54, 13);
            this.BN_wk1_4.Name = "BN_wk1_4";
            this.BN_wk1_4.Size = new System.Drawing.Size(180, 23);
            this.BN_wk1_4.TabIndex = 36;
            this.BN_wk1_4.Tag = "how to combine 2 labels in one Winforms UIhow to combine 2 labels in one Winforms" +
    " UI";
            this.BN_wk1_4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblAS_12_4
            // 
            this.lblAS_12_4.BackColor = System.Drawing.Color.DarkGray;
            this.lblAS_12_4.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAS_12_4.Location = new System.Drawing.Point(213, 152);
            this.lblAS_12_4.Name = "lblAS_12_4";
            this.lblAS_12_4.Size = new System.Drawing.Size(81, 23);
            this.lblAS_12_4.TabIndex = 23;
            this.lblAS_12_4.Tag = "how to combine 2 labels in one Winforms UIhow to combine 2 labels in one Winforms" +
    " UI";
            this.lblAS_12_4.Text = "12";
            this.lblAS_12_4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblAS_1_4
            // 
            this.lblAS_1_4.BackColor = System.Drawing.Color.DarkGray;
            this.lblAS_1_4.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAS_1_4.Location = new System.Drawing.Point(10, 54);
            this.lblAS_1_4.Name = "lblAS_1_4";
            this.lblAS_1_4.Size = new System.Drawing.Size(95, 23);
            this.lblAS_1_4.TabIndex = 12;
            this.lblAS_1_4.Tag = "how to combine 2 labels in one Winforms UIhow to combine 2 labels in one Winforms" +
    " UI";
            this.lblAS_1_4.Text = "1";
            this.lblAS_1_4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblAS_11_4
            // 
            this.lblAS_11_4.BackColor = System.Drawing.Color.DarkGray;
            this.lblAS_11_4.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAS_11_4.Location = new System.Drawing.Point(114, 152);
            this.lblAS_11_4.Name = "lblAS_11_4";
            this.lblAS_11_4.Size = new System.Drawing.Size(91, 23);
            this.lblAS_11_4.TabIndex = 22;
            this.lblAS_11_4.Tag = "how to combine 2 labels in one Winforms UIhow to combine 2 labels in one Winforms" +
    " UI";
            this.lblAS_11_4.Text = "11";
            this.lblAS_11_4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblAS_2_4
            // 
            this.lblAS_2_4.BackColor = System.Drawing.Color.DarkGray;
            this.lblAS_2_4.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAS_2_4.Location = new System.Drawing.Point(111, 54);
            this.lblAS_2_4.Name = "lblAS_2_4";
            this.lblAS_2_4.Size = new System.Drawing.Size(94, 23);
            this.lblAS_2_4.TabIndex = 13;
            this.lblAS_2_4.Tag = "how to combine 2 labels in one Winforms UIhow to combine 2 labels in one Winforms" +
    " UI";
            this.lblAS_2_4.Text = "2";
            this.lblAS_2_4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblAS_10_4
            // 
            this.lblAS_10_4.BackColor = System.Drawing.Color.DarkGray;
            this.lblAS_10_4.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAS_10_4.Location = new System.Drawing.Point(10, 152);
            this.lblAS_10_4.Name = "lblAS_10_4";
            this.lblAS_10_4.Size = new System.Drawing.Size(95, 23);
            this.lblAS_10_4.TabIndex = 21;
            this.lblAS_10_4.Tag = "how to combine 2 labels in one Winforms UIhow to combine 2 labels in one Winforms" +
    " UI";
            this.lblAS_10_4.Text = "10";
            this.lblAS_10_4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblAS_3_4
            // 
            this.lblAS_3_4.BackColor = System.Drawing.Color.DarkGray;
            this.lblAS_3_4.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAS_3_4.Location = new System.Drawing.Point(210, 54);
            this.lblAS_3_4.Name = "lblAS_3_4";
            this.lblAS_3_4.Size = new System.Drawing.Size(84, 23);
            this.lblAS_3_4.TabIndex = 14;
            this.lblAS_3_4.Tag = "how to combine 2 labels in one Winforms UIhow to combine 2 labels in one Winforms" +
    " UI";
            this.lblAS_3_4.Text = "3";
            this.lblAS_3_4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblAS_9_4
            // 
            this.lblAS_9_4.BackColor = System.Drawing.Color.DarkGray;
            this.lblAS_9_4.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAS_9_4.Location = new System.Drawing.Point(213, 119);
            this.lblAS_9_4.Name = "lblAS_9_4";
            this.lblAS_9_4.Size = new System.Drawing.Size(81, 23);
            this.lblAS_9_4.TabIndex = 20;
            this.lblAS_9_4.Tag = "how to combine 2 labels in one Winforms UIhow to combine 2 labels in one Winforms" +
    " UI";
            this.lblAS_9_4.Text = "9";
            this.lblAS_9_4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblAS_4_4
            // 
            this.lblAS_4_4.BackColor = System.Drawing.Color.DarkGray;
            this.lblAS_4_4.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAS_4_4.Location = new System.Drawing.Point(10, 86);
            this.lblAS_4_4.Name = "lblAS_4_4";
            this.lblAS_4_4.Size = new System.Drawing.Size(95, 23);
            this.lblAS_4_4.TabIndex = 15;
            this.lblAS_4_4.Tag = "how to combine 2 labels in one Winforms UIhow to combine 2 labels in one Winforms" +
    " UI";
            this.lblAS_4_4.Text = "4";
            this.lblAS_4_4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblAS_8_4
            // 
            this.lblAS_8_4.BackColor = System.Drawing.Color.DarkGray;
            this.lblAS_8_4.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAS_8_4.Location = new System.Drawing.Point(114, 119);
            this.lblAS_8_4.Name = "lblAS_8_4";
            this.lblAS_8_4.Size = new System.Drawing.Size(91, 23);
            this.lblAS_8_4.TabIndex = 19;
            this.lblAS_8_4.Tag = "how to combine 2 labels in one Winforms UIhow to combine 2 labels in one Winforms" +
    " UI";
            this.lblAS_8_4.Text = "8";
            this.lblAS_8_4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblAS_5_4
            // 
            this.lblAS_5_4.BackColor = System.Drawing.Color.DarkGray;
            this.lblAS_5_4.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAS_5_4.Location = new System.Drawing.Point(114, 86);
            this.lblAS_5_4.Name = "lblAS_5_4";
            this.lblAS_5_4.Size = new System.Drawing.Size(91, 23);
            this.lblAS_5_4.TabIndex = 16;
            this.lblAS_5_4.Tag = "how to combine 2 labels in one Winforms UIhow to combine 2 labels in one Winforms" +
    " UI";
            this.lblAS_5_4.Text = "5";
            this.lblAS_5_4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblAS_7_4
            // 
            this.lblAS_7_4.BackColor = System.Drawing.Color.DarkGray;
            this.lblAS_7_4.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAS_7_4.Location = new System.Drawing.Point(10, 119);
            this.lblAS_7_4.Name = "lblAS_7_4";
            this.lblAS_7_4.Size = new System.Drawing.Size(95, 23);
            this.lblAS_7_4.TabIndex = 18;
            this.lblAS_7_4.Tag = "how to combine 2 labels in one Winforms UIhow to combine 2 labels in one Winforms" +
    " UI";
            this.lblAS_7_4.Text = "7";
            this.lblAS_7_4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblAS_6_4
            // 
            this.lblAS_6_4.BackColor = System.Drawing.Color.DarkGray;
            this.lblAS_6_4.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAS_6_4.Location = new System.Drawing.Point(213, 86);
            this.lblAS_6_4.Name = "lblAS_6_4";
            this.lblAS_6_4.Size = new System.Drawing.Size(81, 23);
            this.lblAS_6_4.TabIndex = 17;
            this.lblAS_6_4.Tag = "how to combine 2 labels in one Winforms UIhow to combine 2 labels in one Winforms" +
    " UI";
            this.lblAS_6_4.Text = "6";
            this.lblAS_6_4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label60
            // 
            this.label60.AutoSize = true;
            this.label60.BackColor = System.Drawing.Color.Transparent;
            this.label60.Font = new System.Drawing.Font("Verdana", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label60.Location = new System.Drawing.Point(95, 21);
            this.label60.Name = "label60";
            this.label60.Size = new System.Drawing.Size(185, 18);
            this.label60.TabIndex = 342;
            this.label60.Text = "Tray Cavity Scanner";
            // 
            // pnlScanner_4
            // 
            this.pnlScanner_4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlScanner_4.Controls.Add(this.lblSC_10_4);
            this.pnlScanner_4.Controls.Add(this.lblSC_11_4);
            this.pnlScanner_4.Controls.Add(this.lblSC_12_4);
            this.pnlScanner_4.Controls.Add(this.lblSC_9_4);
            this.pnlScanner_4.Controls.Add(this.lblSC_8_4);
            this.pnlScanner_4.Controls.Add(this.lblSC_7_4);
            this.pnlScanner_4.Controls.Add(this.lblSC_4_4);
            this.pnlScanner_4.Controls.Add(this.lblSC_5_4);
            this.pnlScanner_4.Controls.Add(this.lblSC_6_4);
            this.pnlScanner_4.Controls.Add(this.CARRIER_SN_4);
            this.pnlScanner_4.Controls.Add(this.lblSC_3_4);
            this.pnlScanner_4.Controls.Add(this.lblSC_2_4);
            this.pnlScanner_4.Controls.Add(this.lblSC_1_4);
            this.pnlScanner_4.Location = new System.Drawing.Point(6, 32);
            this.pnlScanner_4.Name = "pnlScanner_4";
            this.pnlScanner_4.Size = new System.Drawing.Size(329, 187);
            this.pnlScanner_4.TabIndex = 345;
            // 
            // lblSC_10_4
            // 
            this.lblSC_10_4.BackColor = System.Drawing.Color.DarkGray;
            this.lblSC_10_4.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSC_10_4.Location = new System.Drawing.Point(220, 152);
            this.lblSC_10_4.Name = "lblSC_10_4";
            this.lblSC_10_4.Size = new System.Drawing.Size(103, 23);
            this.lblSC_10_4.TabIndex = 11;
            this.lblSC_10_4.Tag = "how to combine 2 labels in one Winforms UIhow to combine 2 labels in one Winforms" +
    " UI";
            this.lblSC_10_4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblSC_11_4
            // 
            this.lblSC_11_4.BackColor = System.Drawing.Color.DarkGray;
            this.lblSC_11_4.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSC_11_4.Location = new System.Drawing.Point(111, 152);
            this.lblSC_11_4.Name = "lblSC_11_4";
            this.lblSC_11_4.Size = new System.Drawing.Size(103, 23);
            this.lblSC_11_4.TabIndex = 10;
            this.lblSC_11_4.Tag = "how to combine 2 labels in one Winforms UIhow to combine 2 labels in one Winforms" +
    " UI";
            this.lblSC_11_4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblSC_12_4
            // 
            this.lblSC_12_4.BackColor = System.Drawing.Color.DarkGray;
            this.lblSC_12_4.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSC_12_4.Location = new System.Drawing.Point(2, 152);
            this.lblSC_12_4.Name = "lblSC_12_4";
            this.lblSC_12_4.Size = new System.Drawing.Size(103, 23);
            this.lblSC_12_4.TabIndex = 9;
            this.lblSC_12_4.Tag = "how to combine 2 labels in one Winforms UIhow to combine 2 labels in one Winforms" +
    " UI";
            this.lblSC_12_4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblSC_9_4
            // 
            this.lblSC_9_4.BackColor = System.Drawing.Color.DarkGray;
            this.lblSC_9_4.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSC_9_4.Location = new System.Drawing.Point(220, 119);
            this.lblSC_9_4.Name = "lblSC_9_4";
            this.lblSC_9_4.Size = new System.Drawing.Size(103, 23);
            this.lblSC_9_4.TabIndex = 8;
            this.lblSC_9_4.Tag = "how to combine 2 labels in one Winforms UIhow to combine 2 labels in one Winforms" +
    " UI";
            this.lblSC_9_4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblSC_8_4
            // 
            this.lblSC_8_4.BackColor = System.Drawing.Color.DarkGray;
            this.lblSC_8_4.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSC_8_4.Location = new System.Drawing.Point(111, 119);
            this.lblSC_8_4.Name = "lblSC_8_4";
            this.lblSC_8_4.Size = new System.Drawing.Size(103, 23);
            this.lblSC_8_4.TabIndex = 7;
            this.lblSC_8_4.Tag = "how to combine 2 labels in one Winforms UIhow to combine 2 labels in one Winforms" +
    " UI";
            this.lblSC_8_4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblSC_7_4
            // 
            this.lblSC_7_4.BackColor = System.Drawing.Color.DarkGray;
            this.lblSC_7_4.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSC_7_4.Location = new System.Drawing.Point(2, 119);
            this.lblSC_7_4.Name = "lblSC_7_4";
            this.lblSC_7_4.Size = new System.Drawing.Size(103, 23);
            this.lblSC_7_4.TabIndex = 6;
            this.lblSC_7_4.Tag = "how to combine 2 labels in one Winforms UIhow to combine 2 labels in one Winforms" +
    " UI";
            this.lblSC_7_4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblSC_4_4
            // 
            this.lblSC_4_4.BackColor = System.Drawing.Color.DarkGray;
            this.lblSC_4_4.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSC_4_4.Location = new System.Drawing.Point(220, 86);
            this.lblSC_4_4.Name = "lblSC_4_4";
            this.lblSC_4_4.Size = new System.Drawing.Size(103, 23);
            this.lblSC_4_4.TabIndex = 5;
            this.lblSC_4_4.Tag = "how to combine 2 labels in one Winforms UIhow to combine 2 labels in one Winforms" +
    " UI";
            this.lblSC_4_4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblSC_5_4
            // 
            this.lblSC_5_4.BackColor = System.Drawing.Color.DarkGray;
            this.lblSC_5_4.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSC_5_4.Location = new System.Drawing.Point(111, 86);
            this.lblSC_5_4.Name = "lblSC_5_4";
            this.lblSC_5_4.Size = new System.Drawing.Size(103, 23);
            this.lblSC_5_4.TabIndex = 4;
            this.lblSC_5_4.Tag = "how to combine 2 labels in one Winforms UIhow to combine 2 labels in one Winforms" +
    " UI";
            this.lblSC_5_4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblSC_6_4
            // 
            this.lblSC_6_4.BackColor = System.Drawing.Color.DarkGray;
            this.lblSC_6_4.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSC_6_4.Location = new System.Drawing.Point(2, 86);
            this.lblSC_6_4.Name = "lblSC_6_4";
            this.lblSC_6_4.Size = new System.Drawing.Size(103, 23);
            this.lblSC_6_4.TabIndex = 3;
            this.lblSC_6_4.Tag = "how to combine 2 labels in one Winforms UIhow to combine 2 labels in one Winforms" +
    " UI";
            this.lblSC_6_4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // CARRIER_SN_4
            // 
            this.CARRIER_SN_4.BackColor = System.Drawing.Color.DarkGray;
            this.CARRIER_SN_4.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CARRIER_SN_4.Location = new System.Drawing.Point(73, 13);
            this.CARRIER_SN_4.Name = "CARRIER_SN_4";
            this.CARRIER_SN_4.Size = new System.Drawing.Size(180, 23);
            this.CARRIER_SN_4.TabIndex = 2;
            this.CARRIER_SN_4.Tag = "how to combine 2 labels in one Winforms UIhow to combine 2 labels in one Winforms" +
    " UI";
            this.CARRIER_SN_4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblSC_3_4
            // 
            this.lblSC_3_4.BackColor = System.Drawing.Color.DarkGray;
            this.lblSC_3_4.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSC_3_4.Location = new System.Drawing.Point(220, 54);
            this.lblSC_3_4.Name = "lblSC_3_4";
            this.lblSC_3_4.Size = new System.Drawing.Size(103, 23);
            this.lblSC_3_4.TabIndex = 2;
            this.lblSC_3_4.Tag = "how to combine 2 labels in one Winforms UIhow to combine 2 labels in one Winforms" +
    " UI";
            this.lblSC_3_4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblSC_2_4
            // 
            this.lblSC_2_4.BackColor = System.Drawing.Color.DarkGray;
            this.lblSC_2_4.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSC_2_4.Location = new System.Drawing.Point(110, 54);
            this.lblSC_2_4.Name = "lblSC_2_4";
            this.lblSC_2_4.Size = new System.Drawing.Size(103, 23);
            this.lblSC_2_4.TabIndex = 1;
            this.lblSC_2_4.Tag = "how to combine 2 labels in one Winforms UIhow to combine 2 labels in one Winforms" +
    " UI";
            this.lblSC_2_4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblSC_1_4
            // 
            this.lblSC_1_4.BackColor = System.Drawing.Color.DarkGray;
            this.lblSC_1_4.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSC_1_4.Location = new System.Drawing.Point(2, 54);
            this.lblSC_1_4.Name = "lblSC_1_4";
            this.lblSC_1_4.Size = new System.Drawing.Size(103, 23);
            this.lblSC_1_4.TabIndex = 0;
            this.lblSC_1_4.Tag = "";
            this.lblSC_1_4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.Color.Gainsboro;
            this.panel7.Controls.Add(this.label47);
            this.panel7.Controls.Add(this.panel8);
            this.panel7.Controls.Add(this.label48);
            this.panel7.Controls.Add(this.panel3);
            this.panel7.Controls.Add(this.label49);
            this.panel7.Controls.Add(this.pnlScanner);
            this.panel7.Controls.Add(this.label50);
            this.panel7.Location = new System.Drawing.Point(23, 347);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(941, 234);
            this.panel7.TabIndex = 35;
            // 
            // label47
            // 
            this.label47.AutoSize = true;
            this.label47.BackColor = System.Drawing.Color.Transparent;
            this.label47.Font = new System.Drawing.Font("Verdana", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label47.Location = new System.Drawing.Point(727, 21);
            this.label47.Name = "label47";
            this.label47.Size = new System.Drawing.Size(131, 18);
            this.label47.TabIndex = 344;
            this.label47.Text = "Tray Cavity FI";
            // 
            // panel8
            // 
            this.panel8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel8.Controls.Add(this.BN_WK2);
            this.panel8.Controls.Add(this.lblFI_12);
            this.panel8.Controls.Add(this.lblFI_1);
            this.panel8.Controls.Add(this.lblFI_11);
            this.panel8.Controls.Add(this.lblFI_2);
            this.panel8.Controls.Add(this.lblFI_10);
            this.panel8.Controls.Add(this.lblFI_8);
            this.panel8.Controls.Add(this.lblFI_7);
            this.panel8.Controls.Add(this.lblFI_3);
            this.panel8.Controls.Add(this.lblFI_9);
            this.panel8.Controls.Add(this.lblFI_4);
            this.panel8.Controls.Add(this.lblFI_5);
            this.panel8.Controls.Add(this.lblFI_6);
            this.panel8.Location = new System.Drawing.Point(640, 32);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(284, 190);
            this.panel8.TabIndex = 347;
            // 
            // BN_WK2
            // 
            this.BN_WK2.BackColor = System.Drawing.Color.DarkGray;
            this.BN_WK2.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BN_WK2.Location = new System.Drawing.Point(51, 17);
            this.BN_WK2.Name = "BN_WK2";
            this.BN_WK2.Size = new System.Drawing.Size(180, 23);
            this.BN_WK2.TabIndex = 348;
            this.BN_WK2.Tag = "how to combine 2 labels in one Winforms UIhow to combine 2 labels in one Winforms" +
    " UI";
            this.BN_WK2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblFI_12
            // 
            this.lblFI_12.BackColor = System.Drawing.Color.DarkGray;
            this.lblFI_12.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFI_12.Location = new System.Drawing.Point(213, 142);
            this.lblFI_12.Name = "lblFI_12";
            this.lblFI_12.Size = new System.Drawing.Size(67, 39);
            this.lblFI_12.TabIndex = 35;
            this.lblFI_12.Tag = "how to combine 2 labels in one Winforms UIhow to combine 2 labels in one Winforms" +
    " UI";
            this.lblFI_12.Text = "12";
            this.lblFI_12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblFI_1
            // 
            this.lblFI_1.BackColor = System.Drawing.Color.DarkGray;
            this.lblFI_1.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFI_1.Location = new System.Drawing.Point(3, 52);
            this.lblFI_1.Name = "lblFI_1";
            this.lblFI_1.Size = new System.Drawing.Size(65, 37);
            this.lblFI_1.TabIndex = 24;
            this.lblFI_1.Tag = "how to combine 2 labels in one Winforms UIhow to combine 2 labels in one Winforms" +
    " UI";
            this.lblFI_1.Text = "1";
            this.lblFI_1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblFI_11
            // 
            this.lblFI_11.BackColor = System.Drawing.Color.DarkGray;
            this.lblFI_11.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFI_11.Location = new System.Drawing.Point(143, 142);
            this.lblFI_11.Name = "lblFI_11";
            this.lblFI_11.Size = new System.Drawing.Size(66, 39);
            this.lblFI_11.TabIndex = 34;
            this.lblFI_11.Tag = "how to combine 2 labels in one Winforms UIhow to combine 2 labels in one Winforms" +
    " UI";
            this.lblFI_11.Text = "11";
            this.lblFI_11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblFI_2
            // 
            this.lblFI_2.BackColor = System.Drawing.Color.DarkGray;
            this.lblFI_2.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFI_2.Location = new System.Drawing.Point(74, 52);
            this.lblFI_2.Name = "lblFI_2";
            this.lblFI_2.Size = new System.Drawing.Size(63, 37);
            this.lblFI_2.TabIndex = 25;
            this.lblFI_2.Tag = "how to combine 2 labels in one Winforms UIhow to combine 2 labels in one Winforms" +
    " UI";
            this.lblFI_2.Text = "2";
            this.lblFI_2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblFI_10
            // 
            this.lblFI_10.BackColor = System.Drawing.Color.DarkGray;
            this.lblFI_10.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFI_10.Location = new System.Drawing.Point(74, 142);
            this.lblFI_10.Name = "lblFI_10";
            this.lblFI_10.Size = new System.Drawing.Size(63, 39);
            this.lblFI_10.TabIndex = 33;
            this.lblFI_10.Tag = "how to combine 2 labels in one Winforms UIhow to combine 2 labels in one Winforms" +
    " UI";
            this.lblFI_10.Text = "10";
            this.lblFI_10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblFI_8
            // 
            this.lblFI_8.BackColor = System.Drawing.Color.DarkGray;
            this.lblFI_8.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFI_8.Location = new System.Drawing.Point(213, 95);
            this.lblFI_8.Name = "lblFI_8";
            this.lblFI_8.Size = new System.Drawing.Size(67, 41);
            this.lblFI_8.TabIndex = 31;
            this.lblFI_8.Tag = "how to combine 2 labels in one Winforms UIhow to combine 2 labels in one Winforms" +
    " UI";
            this.lblFI_8.Text = "8";
            this.lblFI_8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblFI_7
            // 
            this.lblFI_7.BackColor = System.Drawing.Color.DarkGray;
            this.lblFI_7.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFI_7.Location = new System.Drawing.Point(143, 94);
            this.lblFI_7.Name = "lblFI_7";
            this.lblFI_7.Size = new System.Drawing.Size(66, 41);
            this.lblFI_7.TabIndex = 30;
            this.lblFI_7.Tag = "how to combine 2 labels in one Winforms UIhow to combine 2 labels in one Winforms" +
    " UI";
            this.lblFI_7.Text = "7";
            this.lblFI_7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblFI_3
            // 
            this.lblFI_3.BackColor = System.Drawing.Color.DarkGray;
            this.lblFI_3.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFI_3.Location = new System.Drawing.Point(143, 52);
            this.lblFI_3.Name = "lblFI_3";
            this.lblFI_3.Size = new System.Drawing.Size(66, 37);
            this.lblFI_3.TabIndex = 26;
            this.lblFI_3.Tag = "how to combine 2 labels in one Winforms UIhow to combine 2 labels in one Winforms" +
    " UI";
            this.lblFI_3.Text = "3";
            this.lblFI_3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblFI_9
            // 
            this.lblFI_9.BackColor = System.Drawing.Color.DarkGray;
            this.lblFI_9.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFI_9.Location = new System.Drawing.Point(3, 142);
            this.lblFI_9.Name = "lblFI_9";
            this.lblFI_9.Size = new System.Drawing.Size(65, 39);
            this.lblFI_9.TabIndex = 32;
            this.lblFI_9.Tag = "how to combine 2 labels in one Winforms UIhow to combine 2 labels in one Winforms" +
    " UI";
            this.lblFI_9.Text = "9";
            this.lblFI_9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblFI_4
            // 
            this.lblFI_4.BackColor = System.Drawing.Color.DarkGray;
            this.lblFI_4.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFI_4.Location = new System.Drawing.Point(213, 52);
            this.lblFI_4.Name = "lblFI_4";
            this.lblFI_4.Size = new System.Drawing.Size(67, 37);
            this.lblFI_4.TabIndex = 27;
            this.lblFI_4.Tag = "how to combine 2 labels in one Winforms UIhow to combine 2 labels in one Winforms" +
    " UI";
            this.lblFI_4.Text = "4";
            this.lblFI_4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblFI_5
            // 
            this.lblFI_5.BackColor = System.Drawing.Color.DarkGray;
            this.lblFI_5.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFI_5.Location = new System.Drawing.Point(3, 95);
            this.lblFI_5.Name = "lblFI_5";
            this.lblFI_5.Size = new System.Drawing.Size(65, 41);
            this.lblFI_5.TabIndex = 28;
            this.lblFI_5.Tag = "how to combine 2 labels in one Winforms UIhow to combine 2 labels in one Winforms" +
    " UI";
            this.lblFI_5.Text = "5";
            this.lblFI_5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblFI_6
            // 
            this.lblFI_6.BackColor = System.Drawing.Color.DarkGray;
            this.lblFI_6.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFI_6.Location = new System.Drawing.Point(74, 96);
            this.lblFI_6.Name = "lblFI_6";
            this.lblFI_6.Size = new System.Drawing.Size(63, 40);
            this.lblFI_6.TabIndex = 29;
            this.lblFI_6.Tag = "how to combine 2 labels in one Winforms UIhow to combine 2 labels in one Winforms" +
    " UI";
            this.lblFI_6.Text = "6";
            this.lblFI_6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label48
            // 
            this.label48.AutoSize = true;
            this.label48.BackColor = System.Drawing.Color.Transparent;
            this.label48.Font = new System.Drawing.Font("Verdana", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label48.Location = new System.Drawing.Point(382, 22);
            this.label48.Name = "label48";
            this.label48.Size = new System.Drawing.Size(195, 18);
            this.label48.TabIndex = 343;
            this.label48.Text = "Tray Cavity Assembly";
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.BN_wk1);
            this.panel3.Controls.Add(this.lblAS_12);
            this.panel3.Controls.Add(this.lblAS_8);
            this.panel3.Controls.Add(this.lblAS_7);
            this.panel3.Controls.Add(this.lblAS_1);
            this.panel3.Controls.Add(this.lblAS_11);
            this.panel3.Controls.Add(this.lblAS_2);
            this.panel3.Controls.Add(this.lblAS_10);
            this.panel3.Controls.Add(this.lblAS_3);
            this.panel3.Controls.Add(this.lblAS_9);
            this.panel3.Controls.Add(this.lblAS_4);
            this.panel3.Controls.Add(this.lblAS_5);
            this.panel3.Controls.Add(this.lblAS_6);
            this.panel3.Location = new System.Drawing.Point(335, 32);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(299, 190);
            this.panel3.TabIndex = 346;
            // 
            // BN_wk1
            // 
            this.BN_wk1.BackColor = System.Drawing.Color.DarkGray;
            this.BN_wk1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BN_wk1.Location = new System.Drawing.Point(54, 13);
            this.BN_wk1.Name = "BN_wk1";
            this.BN_wk1.Size = new System.Drawing.Size(180, 23);
            this.BN_wk1.TabIndex = 36;
            this.BN_wk1.Tag = "how to combine 2 labels in one Winforms UIhow to combine 2 labels in one Winforms" +
    " UI";
            this.BN_wk1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblAS_12
            // 
            this.lblAS_12.BackColor = System.Drawing.Color.DarkGray;
            this.lblAS_12.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAS_12.Location = new System.Drawing.Point(222, 142);
            this.lblAS_12.Name = "lblAS_12";
            this.lblAS_12.Size = new System.Drawing.Size(70, 39);
            this.lblAS_12.TabIndex = 23;
            this.lblAS_12.Tag = "how to combine 2 labels in one Winforms UIhow to combine 2 labels in one Winforms" +
    " UI";
            this.lblAS_12.Text = "12";
            this.lblAS_12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblAS_8
            // 
            this.lblAS_8.BackColor = System.Drawing.Color.DarkGray;
            this.lblAS_8.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAS_8.Location = new System.Drawing.Point(222, 96);
            this.lblAS_8.Name = "lblAS_8";
            this.lblAS_8.Size = new System.Drawing.Size(70, 40);
            this.lblAS_8.TabIndex = 19;
            this.lblAS_8.Tag = "how to combine 2 labels in one Winforms UIhow to combine 2 labels in one Winforms" +
    " UI";
            this.lblAS_8.Text = "8";
            this.lblAS_8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblAS_7
            // 
            this.lblAS_7.BackColor = System.Drawing.Color.DarkGray;
            this.lblAS_7.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAS_7.Location = new System.Drawing.Point(146, 96);
            this.lblAS_7.Name = "lblAS_7";
            this.lblAS_7.Size = new System.Drawing.Size(70, 40);
            this.lblAS_7.TabIndex = 18;
            this.lblAS_7.Tag = "how to combine 2 labels in one Winforms UIhow to combine 2 labels in one Winforms" +
    " UI";
            this.lblAS_7.Text = "7";
            this.lblAS_7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblAS_1
            // 
            this.lblAS_1.BackColor = System.Drawing.Color.DarkGray;
            this.lblAS_1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAS_1.Location = new System.Drawing.Point(3, 52);
            this.lblAS_1.Name = "lblAS_1";
            this.lblAS_1.Size = new System.Drawing.Size(61, 37);
            this.lblAS_1.TabIndex = 12;
            this.lblAS_1.Tag = "how to combine 2 labels in one Winforms UIhow to combine 2 labels in one Winforms" +
    " UI";
            this.lblAS_1.Text = "1";
            this.lblAS_1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblAS_11
            // 
            this.lblAS_11.BackColor = System.Drawing.Color.DarkGray;
            this.lblAS_11.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAS_11.Location = new System.Drawing.Point(146, 142);
            this.lblAS_11.Name = "lblAS_11";
            this.lblAS_11.Size = new System.Drawing.Size(70, 39);
            this.lblAS_11.TabIndex = 22;
            this.lblAS_11.Tag = "how to combine 2 labels in one Winforms UIhow to combine 2 labels in one Winforms" +
    " UI";
            this.lblAS_11.Text = "11";
            this.lblAS_11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblAS_2
            // 
            this.lblAS_2.BackColor = System.Drawing.Color.DarkGray;
            this.lblAS_2.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAS_2.Location = new System.Drawing.Point(70, 52);
            this.lblAS_2.Name = "lblAS_2";
            this.lblAS_2.Size = new System.Drawing.Size(70, 36);
            this.lblAS_2.TabIndex = 13;
            this.lblAS_2.Tag = "how to combine 2 labels in one Winforms UIhow to combine 2 labels in one Winforms" +
    " UI";
            this.lblAS_2.Text = "2";
            this.lblAS_2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblAS_10
            // 
            this.lblAS_10.BackColor = System.Drawing.Color.DarkGray;
            this.lblAS_10.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAS_10.Location = new System.Drawing.Point(70, 142);
            this.lblAS_10.Name = "lblAS_10";
            this.lblAS_10.Size = new System.Drawing.Size(70, 39);
            this.lblAS_10.TabIndex = 21;
            this.lblAS_10.Tag = "how to combine 2 labels in one Winforms UIhow to combine 2 labels in one Winforms" +
    " UI";
            this.lblAS_10.Text = "10";
            this.lblAS_10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblAS_3
            // 
            this.lblAS_3.BackColor = System.Drawing.Color.DarkGray;
            this.lblAS_3.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAS_3.Location = new System.Drawing.Point(146, 52);
            this.lblAS_3.Name = "lblAS_3";
            this.lblAS_3.Size = new System.Drawing.Size(70, 36);
            this.lblAS_3.TabIndex = 14;
            this.lblAS_3.Tag = "how to combine 2 labels in one Winforms UIhow to combine 2 labels in one Winforms" +
    " UI";
            this.lblAS_3.Text = "3";
            this.lblAS_3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblAS_9
            // 
            this.lblAS_9.BackColor = System.Drawing.Color.DarkGray;
            this.lblAS_9.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAS_9.Location = new System.Drawing.Point(3, 142);
            this.lblAS_9.Name = "lblAS_9";
            this.lblAS_9.Size = new System.Drawing.Size(61, 39);
            this.lblAS_9.TabIndex = 20;
            this.lblAS_9.Tag = "how to combine 2 labels in one Winforms UIhow to combine 2 labels in one Winforms" +
    " UI";
            this.lblAS_9.Text = "9";
            this.lblAS_9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblAS_4
            // 
            this.lblAS_4.BackColor = System.Drawing.Color.DarkGray;
            this.lblAS_4.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAS_4.Location = new System.Drawing.Point(222, 52);
            this.lblAS_4.Name = "lblAS_4";
            this.lblAS_4.Size = new System.Drawing.Size(70, 36);
            this.lblAS_4.TabIndex = 15;
            this.lblAS_4.Tag = "how to combine 2 labels in one Winforms UIhow to combine 2 labels in one Winforms" +
    " UI";
            this.lblAS_4.Text = "4";
            this.lblAS_4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblAS_5
            // 
            this.lblAS_5.BackColor = System.Drawing.Color.DarkGray;
            this.lblAS_5.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAS_5.Location = new System.Drawing.Point(3, 95);
            this.lblAS_5.Name = "lblAS_5";
            this.lblAS_5.Size = new System.Drawing.Size(61, 41);
            this.lblAS_5.TabIndex = 16;
            this.lblAS_5.Tag = "how to combine 2 labels in one Winforms UIhow to combine 2 labels in one Winforms" +
    " UI";
            this.lblAS_5.Text = "5";
            this.lblAS_5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblAS_6
            // 
            this.lblAS_6.BackColor = System.Drawing.Color.DarkGray;
            this.lblAS_6.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAS_6.Location = new System.Drawing.Point(70, 96);
            this.lblAS_6.Name = "lblAS_6";
            this.lblAS_6.Size = new System.Drawing.Size(70, 40);
            this.lblAS_6.TabIndex = 17;
            this.lblAS_6.Tag = "how to combine 2 labels in one Winforms UIhow to combine 2 labels in one Winforms" +
    " UI";
            this.lblAS_6.Text = "6";
            this.lblAS_6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label49
            // 
            this.label49.AutoSize = true;
            this.label49.BackColor = System.Drawing.Color.Transparent;
            this.label49.Font = new System.Drawing.Font("Verdana", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label49.Location = new System.Drawing.Point(95, 21);
            this.label49.Name = "label49";
            this.label49.Size = new System.Drawing.Size(185, 18);
            this.label49.TabIndex = 342;
            this.label49.Text = "Tray Cavity Scanner";
            // 
            // pnlScanner
            // 
            this.pnlScanner.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlScanner.Controls.Add(this.lblSC_10);
            this.pnlScanner.Controls.Add(this.lblSC_11);
            this.pnlScanner.Controls.Add(this.lblSC_12);
            this.pnlScanner.Controls.Add(this.lblSC_9);
            this.pnlScanner.Controls.Add(this.lblSC_8);
            this.pnlScanner.Controls.Add(this.lblSC_7);
            this.pnlScanner.Controls.Add(this.lblSC_4);
            this.pnlScanner.Controls.Add(this.lblSC_5);
            this.pnlScanner.Controls.Add(this.lblSC_6);
            this.pnlScanner.Controls.Add(this.CARRIER_SN);
            this.pnlScanner.Controls.Add(this.lblSC_3);
            this.pnlScanner.Controls.Add(this.lblSC_2);
            this.pnlScanner.Controls.Add(this.lblSC_1);
            this.pnlScanner.Location = new System.Drawing.Point(6, 32);
            this.pnlScanner.Name = "pnlScanner";
            this.pnlScanner.Size = new System.Drawing.Size(318, 190);
            this.pnlScanner.TabIndex = 345;
            // 
            // lblSC_10
            // 
            this.lblSC_10.BackColor = System.Drawing.Color.DarkGray;
            this.lblSC_10.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSC_10.Location = new System.Drawing.Point(82, 142);
            this.lblSC_10.Name = "lblSC_10";
            this.lblSC_10.Size = new System.Drawing.Size(62, 39);
            this.lblSC_10.TabIndex = 11;
            this.lblSC_10.Tag = "how to combine 2 labels in one Winforms UIhow to combine 2 labels in one Winforms" +
    " UI";
            this.lblSC_10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblSC_11
            // 
            this.lblSC_11.BackColor = System.Drawing.Color.DarkGray;
            this.lblSC_11.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSC_11.Location = new System.Drawing.Point(162, 142);
            this.lblSC_11.Name = "lblSC_11";
            this.lblSC_11.Size = new System.Drawing.Size(61, 39);
            this.lblSC_11.TabIndex = 10;
            this.lblSC_11.Tag = "how to combine 2 labels in one Winforms UIhow to combine 2 labels in one Winforms" +
    " UI";
            this.lblSC_11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblSC_12
            // 
            this.lblSC_12.BackColor = System.Drawing.Color.DarkGray;
            this.lblSC_12.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSC_12.Location = new System.Drawing.Point(242, 142);
            this.lblSC_12.Name = "lblSC_12";
            this.lblSC_12.Size = new System.Drawing.Size(61, 39);
            this.lblSC_12.TabIndex = 9;
            this.lblSC_12.Tag = "how to combine 2 labels in one Winforms UIhow to combine 2 labels in one Winforms" +
    " UI";
            this.lblSC_12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblSC_9
            // 
            this.lblSC_9.BackColor = System.Drawing.Color.DarkGray;
            this.lblSC_9.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSC_9.Location = new System.Drawing.Point(1, 142);
            this.lblSC_9.Name = "lblSC_9";
            this.lblSC_9.Size = new System.Drawing.Size(62, 39);
            this.lblSC_9.TabIndex = 8;
            this.lblSC_9.Tag = "how to combine 2 labels in one Winforms UIhow to combine 2 labels in one Winforms" +
    " UI";
            this.lblSC_9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblSC_8
            // 
            this.lblSC_8.BackColor = System.Drawing.Color.DarkGray;
            this.lblSC_8.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSC_8.Location = new System.Drawing.Point(241, 94);
            this.lblSC_8.Name = "lblSC_8";
            this.lblSC_8.Size = new System.Drawing.Size(62, 41);
            this.lblSC_8.TabIndex = 7;
            this.lblSC_8.Tag = "how to combine 2 labels in one Winforms UIhow to combine 2 labels in one Winforms" +
    " UI";
            this.lblSC_8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblSC_7
            // 
            this.lblSC_7.BackColor = System.Drawing.Color.DarkGray;
            this.lblSC_7.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSC_7.Location = new System.Drawing.Point(160, 94);
            this.lblSC_7.Name = "lblSC_7";
            this.lblSC_7.Size = new System.Drawing.Size(62, 41);
            this.lblSC_7.TabIndex = 6;
            this.lblSC_7.Tag = "how to combine 2 labels in one Winforms UIhow to combine 2 labels in one Winforms" +
    " UI";
            this.lblSC_7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblSC_4
            // 
            this.lblSC_4.BackColor = System.Drawing.Color.DarkGray;
            this.lblSC_4.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSC_4.Location = new System.Drawing.Point(242, 52);
            this.lblSC_4.Name = "lblSC_4";
            this.lblSC_4.Size = new System.Drawing.Size(61, 37);
            this.lblSC_4.TabIndex = 5;
            this.lblSC_4.Tag = "how to combine 2 labels in one Winforms UIhow to combine 2 labels in one Winforms" +
    " UI";
            this.lblSC_4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblSC_5
            // 
            this.lblSC_5.BackColor = System.Drawing.Color.DarkGray;
            this.lblSC_5.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSC_5.Location = new System.Drawing.Point(2, 97);
            this.lblSC_5.Name = "lblSC_5";
            this.lblSC_5.Size = new System.Drawing.Size(61, 40);
            this.lblSC_5.TabIndex = 4;
            this.lblSC_5.Tag = "how to combine 2 labels in one Winforms UIhow to combine 2 labels in one Winforms" +
    " UI";
            this.lblSC_5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblSC_6
            // 
            this.lblSC_6.BackColor = System.Drawing.Color.DarkGray;
            this.lblSC_6.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSC_6.Location = new System.Drawing.Point(82, 97);
            this.lblSC_6.Name = "lblSC_6";
            this.lblSC_6.Size = new System.Drawing.Size(61, 40);
            this.lblSC_6.TabIndex = 3;
            this.lblSC_6.Tag = "how to combine 2 labels in one Winforms UIhow to combine 2 labels in one Winforms" +
    " UI";
            this.lblSC_6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblSC_6.Click += new System.EventHandler(this.lblSC_6_Click);
            // 
            // CARRIER_SN
            // 
            this.CARRIER_SN.BackColor = System.Drawing.Color.DarkGray;
            this.CARRIER_SN.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CARRIER_SN.Location = new System.Drawing.Point(73, 13);
            this.CARRIER_SN.Name = "CARRIER_SN";
            this.CARRIER_SN.Size = new System.Drawing.Size(180, 23);
            this.CARRIER_SN.TabIndex = 2;
            this.CARRIER_SN.Tag = "how to combine 2 labels in one Winforms UIhow to combine 2 labels in one Winforms" +
    " UI";
            this.CARRIER_SN.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblSC_3
            // 
            this.lblSC_3.BackColor = System.Drawing.Color.DarkGray;
            this.lblSC_3.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSC_3.Location = new System.Drawing.Point(162, 52);
            this.lblSC_3.Name = "lblSC_3";
            this.lblSC_3.Size = new System.Drawing.Size(61, 37);
            this.lblSC_3.TabIndex = 2;
            this.lblSC_3.Tag = "how to combine 2 labels in one Winforms UIhow to combine 2 labels in one Winforms" +
    " UI";
            this.lblSC_3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblSC_2
            // 
            this.lblSC_2.BackColor = System.Drawing.Color.DarkGray;
            this.lblSC_2.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSC_2.Location = new System.Drawing.Point(82, 52);
            this.lblSC_2.Name = "lblSC_2";
            this.lblSC_2.Size = new System.Drawing.Size(62, 37);
            this.lblSC_2.TabIndex = 1;
            this.lblSC_2.Tag = "how to combine 2 labels in one Winforms UIhow to combine 2 labels in one Winforms" +
    " UI";
            this.lblSC_2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblSC_1
            // 
            this.lblSC_1.BackColor = System.Drawing.Color.DarkGray;
            this.lblSC_1.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSC_1.Location = new System.Drawing.Point(3, 52);
            this.lblSC_1.Name = "lblSC_1";
            this.lblSC_1.Size = new System.Drawing.Size(61, 37);
            this.lblSC_1.TabIndex = 0;
            this.lblSC_1.Tag = "";
            this.lblSC_1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label50
            // 
            this.label50.AutoSize = true;
            this.label50.BackColor = System.Drawing.Color.Transparent;
            this.label50.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label50.Location = new System.Drawing.Point(391, 2);
            this.label50.Name = "label50";
            this.label50.Size = new System.Drawing.Size(157, 18);
            this.label50.TabIndex = 338;
            this.label50.Text = "Tray Cavity Status";
            this.label50.Visible = false;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.DarkGray;
            this.panel2.Controls.Add(this.FinalRslt);
            this.panel2.Controls.Add(this.linkLabel1);
            this.panel2.Controls.Add(this.label38);
            this.panel2.Controls.Add(this.label34);
            this.panel2.Controls.Add(this.label37);
            this.panel2.Controls.Add(this.label33);
            this.panel2.Controls.Add(this.label36);
            this.panel2.Controls.Add(this.label30);
            this.panel2.Controls.Add(this.label35);
            this.panel2.Controls.Add(this.label19);
            this.panel2.Controls.Add(this.label32);
            this.panel2.Controls.Add(this.label31);
            this.panel2.Controls.Add(this.label42);
            this.panel2.Controls.Add(this.label39);
            this.panel2.Controls.Add(this.label40);
            this.panel2.Controls.Add(this.label41);
            this.panel2.Controls.Add(this.label43);
            this.panel2.Controls.Add(this.groupBox1);
            this.panel2.ForeColor = System.Drawing.Color.Black;
            this.panel2.Location = new System.Drawing.Point(23, 17);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(924, 305);
            this.panel2.TabIndex = 34;
            // 
            // FinalRslt
            // 
            this.FinalRslt.BackgroundColor = System.Drawing.Color.Azure;
            this.FinalRslt.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.FinalRslt.Location = new System.Drawing.Point(28, 109);
            this.FinalRslt.Name = "FinalRslt";
            this.FinalRslt.RowHeadersWidth = 51;
            this.FinalRslt.Size = new System.Drawing.Size(870, 183);
            this.FinalRslt.TabIndex = 323;
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(897, 364);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(170, 18);
            this.linkLabel1.TabIndex = 34;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Goto Cavity Status";
            // 
            // label38
            // 
            this.label38.AutoSize = true;
            this.label38.BackColor = System.Drawing.Color.DarkGray;
            this.label38.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label38.ForeColor = System.Drawing.Color.Black;
            this.label38.Location = new System.Drawing.Point(218, 67);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(27, 13);
            this.label38.TabIndex = 33;
            this.label38.Text = "2.2";
            this.label38.Visible = false;
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.BackColor = System.Drawing.Color.DarkGray;
            this.label34.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label34.ForeColor = System.Drawing.Color.Black;
            this.label34.Location = new System.Drawing.Point(218, 32);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(27, 13);
            this.label34.TabIndex = 33;
            this.label34.Text = "0.7";
            this.label34.Visible = false;
            // 
            // label37
            // 
            this.label37.AutoSize = true;
            this.label37.BackColor = System.Drawing.Color.DarkGray;
            this.label37.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label37.ForeColor = System.Drawing.Color.Black;
            this.label37.Location = new System.Drawing.Point(218, 49);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(15, 13);
            this.label37.TabIndex = 33;
            this.label37.Text = "1";
            this.label37.Visible = false;
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.BackColor = System.Drawing.Color.DarkGray;
            this.label33.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label33.ForeColor = System.Drawing.Color.Black;
            this.label33.Location = new System.Drawing.Point(218, 15);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(27, 13);
            this.label33.TabIndex = 33;
            this.label33.Text = "0.7";
            this.label33.Visible = false;
            // 
            // label36
            // 
            this.label36.AutoSize = true;
            this.label36.BackColor = System.Drawing.Color.DarkGray;
            this.label36.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label36.ForeColor = System.Drawing.Color.Black;
            this.label36.Location = new System.Drawing.Point(159, 67);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(27, 13);
            this.label36.TabIndex = 33;
            this.label36.Text = "1.8";
            this.label36.Visible = false;
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.BackColor = System.Drawing.Color.DarkGray;
            this.label30.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label30.ForeColor = System.Drawing.Color.Black;
            this.label30.Location = new System.Drawing.Point(159, 32);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(27, 13);
            this.label30.TabIndex = 33;
            this.label30.Text = "0.3";
            this.label30.Visible = false;
            // 
            // label35
            // 
            this.label35.AutoSize = true;
            this.label35.BackColor = System.Drawing.Color.DarkGray;
            this.label35.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label35.ForeColor = System.Drawing.Color.Black;
            this.label35.Location = new System.Drawing.Point(159, 49);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(21, 13);
            this.label35.TabIndex = 33;
            this.label35.Text = "-1";
            this.label35.Visible = false;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.BackColor = System.Drawing.Color.DarkGray;
            this.label19.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.ForeColor = System.Drawing.Color.Black;
            this.label19.Location = new System.Drawing.Point(159, 15);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(27, 13);
            this.label19.TabIndex = 33;
            this.label19.Text = "0.3";
            this.label19.Visible = false;
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.BackColor = System.Drawing.Color.DarkGray;
            this.label32.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label32.ForeColor = System.Drawing.Color.Black;
            this.label32.Location = new System.Drawing.Point(7, 67);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(120, 13);
            this.label32.TabIndex = 28;
            this.label32.Text = "Press_Force (kg)";
            this.label32.Visible = false;
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.BackColor = System.Drawing.Color.DarkGray;
            this.label31.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label31.ForeColor = System.Drawing.Color.Black;
            this.label31.Location = new System.Drawing.Point(7, 49);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(84, 13);
            this.label31.TabIndex = 28;
            this.label31.Text = "Angle (deg)";
            this.label31.Visible = false;
            // 
            // label42
            // 
            this.label42.AutoSize = true;
            this.label42.BackColor = System.Drawing.Color.DarkGray;
            this.label42.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label42.ForeColor = System.Drawing.Color.Black;
            this.label42.Location = new System.Drawing.Point(7, 15);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(142, 13);
            this.label42.TabIndex = 28;
            this.label42.Text = "Bottom_Gap_Y (mm)";
            this.label42.Visible = false;
            // 
            // label39
            // 
            this.label39.AutoSize = true;
            this.label39.BackColor = System.Drawing.Color.DarkGray;
            this.label39.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label39.ForeColor = System.Drawing.Color.Black;
            this.label39.Location = new System.Drawing.Point(7, 32);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(121, 13);
            this.label39.TabIndex = 28;
            this.label39.Text = "Left_Gap_X (mm)";
            this.label39.Visible = false;
            // 
            // label40
            // 
            this.label40.AutoSize = true;
            this.label40.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.label40.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label40.ForeColor = System.Drawing.Color.Black;
            this.label40.Location = new System.Drawing.Point(218, 1);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(31, 13);
            this.label40.TabIndex = 28;
            this.label40.Text = "USL";
            this.label40.Visible = false;
            // 
            // label41
            // 
            this.label41.AutoSize = true;
            this.label41.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.label41.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label41.ForeColor = System.Drawing.Color.Black;
            this.label41.Location = new System.Drawing.Point(8, 1);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(143, 13);
            this.label41.TabIndex = 28;
            this.label41.Text = "Parameters               ";
            this.label41.Visible = false;
            // 
            // label43
            // 
            this.label43.AutoSize = true;
            this.label43.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.label43.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label43.ForeColor = System.Drawing.Color.Black;
            this.label43.Location = new System.Drawing.Point(159, 1);
            this.label43.Name = "label43";
            this.label43.Size = new System.Drawing.Size(29, 13);
            this.label43.TabIndex = 28;
            this.label43.Text = "LSL";
            this.label43.Visible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.groupBox1.Controls.Add(this.label46);
            this.groupBox1.ForeColor = System.Drawing.Color.LawnGreen;
            this.groupBox1.Location = new System.Drawing.Point(386, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(215, 72);
            this.groupBox1.TabIndex = 322;
            this.groupBox1.TabStop = false;
            // 
            // label46
            // 
            this.label46.AutoSize = true;
            this.label46.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.label46.Font = new System.Drawing.Font("Verdana", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label46.ForeColor = System.Drawing.Color.Black;
            this.label46.Location = new System.Drawing.Point(23, 17);
            this.label46.Name = "label46";
            this.label46.Size = new System.Drawing.Size(168, 42);
            this.label46.TabIndex = 28;
            this.label46.Text = "RESULT";
            // 
            // tabPage6
            // 
            this.tabPage6.Controls.Add(this.tabControl2);
            this.tabPage6.Location = new System.Drawing.Point(4, 27);
            this.tabPage6.Margin = new System.Windows.Forms.Padding(2);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Padding = new System.Windows.Forms.Padding(2);
            this.tabPage6.Size = new System.Drawing.Size(967, 589);
            this.tabPage6.TabIndex = 2;
            this.tabPage6.Text = "OFFSET";
            this.tabPage6.UseVisualStyleBackColor = true;
            // 
            // tabControl2
            // 
            this.tabControl2.Controls.Add(this.tabPage13);
            this.tabControl2.Controls.Add(this.tabPage7);
            this.tabControl2.Controls.Add(this.tabPage9);
            this.tabControl2.Location = new System.Drawing.Point(8, 5);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(1005, 565);
            this.tabControl2.TabIndex = 1;
            this.tabControl2.SelectedIndexChanged += new System.EventHandler(this.tabControl2_SelectedIndexChanged);
            // 
            // tabPage13
            // 
            this.tabPage13.Controls.Add(this.dgv_offset);
            this.tabPage13.Controls.Add(this.groupBox7);
            this.tabPage13.Controls.Add(this.label57);
            this.tabPage13.Controls.Add(this.panel6);
            this.tabPage13.Location = new System.Drawing.Point(4, 27);
            this.tabPage13.Margin = new System.Windows.Forms.Padding(2);
            this.tabPage13.Name = "tabPage13";
            this.tabPage13.Padding = new System.Windows.Forms.Padding(2);
            this.tabPage13.Size = new System.Drawing.Size(997, 534);
            this.tabPage13.TabIndex = 2;
            this.tabPage13.Text = "NORMAL OFFSET";
            this.tabPage13.UseVisualStyleBackColor = true;
            // 
            // dgv_offset
            // 
            this.dgv_offset.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_offset.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_offset.Location = new System.Drawing.Point(80, 67);
            this.dgv_offset.Name = "dgv_offset";
            this.dgv_offset.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            this.dgv_offset.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.dgv_offset.Size = new System.Drawing.Size(780, 414);
            this.dgv_offset.TabIndex = 91;
            // 
            // groupBox7
            // 
            this.groupBox7.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox7.Controls.Add(this.savebtn_offset);
            this.groupBox7.Controls.Add(this.editbtn_offset);
            this.groupBox7.Controls.Add(this.label55);
            this.groupBox7.Controls.Add(this.label56);
            this.groupBox7.Location = new System.Drawing.Point(868, 156);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(79, 204);
            this.groupBox7.TabIndex = 94;
            this.groupBox7.TabStop = false;
            // 
            // savebtn_offset
            // 
            this.savebtn_offset.BackColor = System.Drawing.Color.LightGray;
            this.savebtn_offset.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.savebtn_offset.Enabled = false;
            this.savebtn_offset.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
            this.savebtn_offset.Location = new System.Drawing.Point(13, 110);
            this.savebtn_offset.Name = "savebtn_offset";
            this.savebtn_offset.Size = new System.Drawing.Size(50, 50);
            this.savebtn_offset.TabIndex = 61;
            this.savebtn_offset.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.savebtn_offset.UseVisualStyleBackColor = false;
            this.savebtn_offset.Click += new System.EventHandler(this.savebtn_offset_Click);
            // 
            // editbtn_offset
            // 
            this.editbtn_offset.BackColor = System.Drawing.Color.LightGray;
            this.editbtn_offset.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.editbtn_offset.Enabled = false;
            this.editbtn_offset.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
            this.editbtn_offset.Location = new System.Drawing.Point(13, 19);
            this.editbtn_offset.Name = "editbtn_offset";
            this.editbtn_offset.Size = new System.Drawing.Size(50, 50);
            this.editbtn_offset.TabIndex = 60;
            this.editbtn_offset.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.editbtn_offset.UseVisualStyleBackColor = false;
            this.editbtn_offset.Click += new System.EventHandler(this.editbtn_offset_Click);
            // 
            // label55
            // 
            this.label55.AutoSize = true;
            this.label55.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label55.Location = new System.Drawing.Point(17, 172);
            this.label55.Name = "label55";
            this.label55.Size = new System.Drawing.Size(43, 16);
            this.label55.TabIndex = 2;
            this.label55.Text = "Save";
            // 
            // label56
            // 
            this.label56.AutoSize = true;
            this.label56.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label56.Location = new System.Drawing.Point(19, 80);
            this.label56.Name = "label56";
            this.label56.Size = new System.Drawing.Size(35, 16);
            this.label56.TabIndex = 2;
            this.label56.Text = "Edit";
            // 
            // label57
            // 
            this.label57.AutoSize = true;
            this.label57.Location = new System.Drawing.Point(31, 13);
            this.label57.Name = "label57";
            this.label57.Size = new System.Drawing.Size(158, 18);
            this.label57.TabIndex = 93;
            this.label57.Text = "NORMAL OFFSET";
            this.label57.Click += new System.EventHandler(this.label57_Click);
            // 
            // panel6
            // 
            this.panel6.Location = new System.Drawing.Point(76, 63);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(786, 421);
            this.panel6.TabIndex = 92;
            // 
            // tabPage7
            // 
            this.tabPage7.Controls.Add(this.dgv_offsetK);
            this.tabPage7.Controls.Add(this.groupBoxoffset);
            this.tabPage7.Controls.Add(this.lbl_ofset);
            this.tabPage7.Controls.Add(this.offset);
            this.tabPage7.Location = new System.Drawing.Point(4, 27);
            this.tabPage7.Name = "tabPage7";
            this.tabPage7.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage7.Size = new System.Drawing.Size(997, 534);
            this.tabPage7.TabIndex = 0;
            this.tabPage7.Text = "K OFFSET";
            this.tabPage7.UseVisualStyleBackColor = true;
            // 
            // dgv_offsetK
            // 
            this.dgv_offsetK.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_offsetK.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_offsetK.Location = new System.Drawing.Point(55, 67);
            this.dgv_offsetK.Name = "dgv_offsetK";
            this.dgv_offsetK.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            this.dgv_offsetK.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.dgv_offsetK.Size = new System.Drawing.Size(780, 414);
            this.dgv_offsetK.TabIndex = 0;
            this.dgv_offsetK.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_offsetK_CellContentClick);
            // 
            // groupBoxoffset
            // 
            this.groupBoxoffset.BackColor = System.Drawing.SystemColors.Control;
            this.groupBoxoffset.Controls.Add(this.savebtn_offsetK);
            this.groupBoxoffset.Controls.Add(this.editbtn_offsetK);
            this.groupBoxoffset.Controls.Add(this.label12);
            this.groupBoxoffset.Controls.Add(this.label15);
            this.groupBoxoffset.Location = new System.Drawing.Point(844, 157);
            this.groupBoxoffset.Name = "groupBoxoffset";
            this.groupBoxoffset.Size = new System.Drawing.Size(79, 204);
            this.groupBoxoffset.TabIndex = 90;
            this.groupBoxoffset.TabStop = false;
            // 
            // savebtn_offsetK
            // 
            this.savebtn_offsetK.BackColor = System.Drawing.Color.LightGray;
            this.savebtn_offsetK.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.savebtn_offsetK.Enabled = false;
            this.savebtn_offsetK.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
            this.savebtn_offsetK.Location = new System.Drawing.Point(13, 110);
            this.savebtn_offsetK.Name = "savebtn_offsetK";
            this.savebtn_offsetK.Size = new System.Drawing.Size(50, 50);
            this.savebtn_offsetK.TabIndex = 61;
            this.savebtn_offsetK.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.savebtn_offsetK.UseVisualStyleBackColor = false;
            this.savebtn_offsetK.Click += new System.EventHandler(this.savebtn_offsetK_Click);
            // 
            // editbtn_offsetK
            // 
            this.editbtn_offsetK.BackColor = System.Drawing.Color.LightGray;
            this.editbtn_offsetK.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.editbtn_offsetK.Enabled = false;
            this.editbtn_offsetK.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
            this.editbtn_offsetK.Location = new System.Drawing.Point(13, 19);
            this.editbtn_offsetK.Name = "editbtn_offsetK";
            this.editbtn_offsetK.Size = new System.Drawing.Size(50, 50);
            this.editbtn_offsetK.TabIndex = 60;
            this.editbtn_offsetK.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.editbtn_offsetK.UseVisualStyleBackColor = false;
            this.editbtn_offsetK.Click += new System.EventHandler(this.editbtn_offsetK_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(17, 172);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(43, 16);
            this.label12.TabIndex = 2;
            this.label12.Text = "Save";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(19, 80);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(35, 16);
            this.label15.TabIndex = 2;
            this.label15.Text = "Edit";
            // 
            // lbl_ofset
            // 
            this.lbl_ofset.AutoSize = true;
            this.lbl_ofset.Location = new System.Drawing.Point(6, 14);
            this.lbl_ofset.Name = "lbl_ofset";
            this.lbl_ofset.Size = new System.Drawing.Size(93, 18);
            this.lbl_ofset.TabIndex = 89;
            this.lbl_ofset.Text = "K OFFSET";
            // 
            // offset
            // 
            this.offset.Location = new System.Drawing.Point(52, 64);
            this.offset.Name = "offset";
            this.offset.Size = new System.Drawing.Size(786, 421);
            this.offset.TabIndex = 88;
            // 
            // tabPage9
            // 
            this.tabPage9.Controls.Add(this.dgv_offsetNk);
            this.tabPage9.Controls.Add(this.groupBox2);
            this.tabPage9.Controls.Add(this.label24);
            this.tabPage9.Controls.Add(this.panel4);
            this.tabPage9.Location = new System.Drawing.Point(4, 27);
            this.tabPage9.Name = "tabPage9";
            this.tabPage9.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage9.Size = new System.Drawing.Size(997, 534);
            this.tabPage9.TabIndex = 1;
            this.tabPage9.Text = "NK OFFSET";
            this.tabPage9.UseVisualStyleBackColor = true;
            // 
            // dgv_offsetNk
            // 
            this.dgv_offsetNk.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_offsetNk.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_offsetNk.Location = new System.Drawing.Point(96, 74);
            this.dgv_offsetNk.Name = "dgv_offsetNk";
            this.dgv_offsetNk.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            this.dgv_offsetNk.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.dgv_offsetNk.Size = new System.Drawing.Size(771, 431);
            this.dgv_offsetNk.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox2.Controls.Add(this.savebtn_offsetNk);
            this.groupBox2.Controls.Add(this.editbtn_offsetNk);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.label16);
            this.groupBox2.Location = new System.Drawing.Point(876, 161);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(79, 204);
            this.groupBox2.TabIndex = 93;
            this.groupBox2.TabStop = false;
            // 
            // savebtn_offsetNk
            // 
            this.savebtn_offsetNk.BackColor = System.Drawing.Color.LightGray;
            this.savebtn_offsetNk.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.savebtn_offsetNk.Enabled = false;
            this.savebtn_offsetNk.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
            this.savebtn_offsetNk.Location = new System.Drawing.Point(13, 110);
            this.savebtn_offsetNk.Name = "savebtn_offsetNk";
            this.savebtn_offsetNk.Size = new System.Drawing.Size(50, 50);
            this.savebtn_offsetNk.TabIndex = 61;
            this.savebtn_offsetNk.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.savebtn_offsetNk.UseVisualStyleBackColor = false;
            this.savebtn_offsetNk.Click += new System.EventHandler(this.savebtn_offsetNk_Click);
            // 
            // editbtn_offsetNk
            // 
            this.editbtn_offsetNk.BackColor = System.Drawing.Color.LightGray;
            this.editbtn_offsetNk.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.editbtn_offsetNk.Enabled = false;
            this.editbtn_offsetNk.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
            this.editbtn_offsetNk.Location = new System.Drawing.Point(13, 19);
            this.editbtn_offsetNk.Name = "editbtn_offsetNk";
            this.editbtn_offsetNk.Size = new System.Drawing.Size(50, 50);
            this.editbtn_offsetNk.TabIndex = 60;
            this.editbtn_offsetNk.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.editbtn_offsetNk.UseVisualStyleBackColor = false;
            this.editbtn_offsetNk.Click += new System.EventHandler(this.editbtn_offsetNk_Click);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(17, 172);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(43, 16);
            this.label13.TabIndex = 2;
            this.label13.Text = "Save";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(19, 80);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(35, 16);
            this.label16.TabIndex = 2;
            this.label16.Text = "Edit";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(6, 14);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(106, 18);
            this.label24.TabIndex = 92;
            this.label24.Text = "NK OFFSET";
            // 
            // panel4
            // 
            this.panel4.Location = new System.Drawing.Point(93, 71);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(777, 437);
            this.panel4.TabIndex = 91;
            // 
            // tabPage8
            // 
            this.tabPage8.Controls.Add(this.groupBox3);
            this.tabPage8.Controls.Add(this.label23);
            this.tabPage8.Controls.Add(this.panel5);
            this.tabPage8.Location = new System.Drawing.Point(4, 27);
            this.tabPage8.Margin = new System.Windows.Forms.Padding(2);
            this.tabPage8.Name = "tabPage8";
            this.tabPage8.Padding = new System.Windows.Forms.Padding(2);
            this.tabPage8.Size = new System.Drawing.Size(967, 589);
            this.tabPage8.TabIndex = 3;
            this.tabPage8.Text = "AE PARAMETER";
            this.tabPage8.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox3.Controls.Add(this.label18);
            this.groupBox3.Controls.Add(this.savebtn_AE);
            this.groupBox3.Controls.Add(this.label22);
            this.groupBox3.Controls.Add(this.editbtn_AE);
            this.groupBox3.Location = new System.Drawing.Point(824, 203);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(79, 204);
            this.groupBox3.TabIndex = 99;
            this.groupBox3.TabStop = false;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(17, 172);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(43, 16);
            this.label18.TabIndex = 2;
            this.label18.Text = "Save";
            // 
            // savebtn_AE
            // 
            this.savebtn_AE.BackColor = System.Drawing.Color.LightGray;
            this.savebtn_AE.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.savebtn_AE.Enabled = false;
            this.savebtn_AE.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
            this.savebtn_AE.Location = new System.Drawing.Point(10, 119);
            this.savebtn_AE.Name = "savebtn_AE";
            this.savebtn_AE.Size = new System.Drawing.Size(50, 50);
            this.savebtn_AE.TabIndex = 98;
            this.savebtn_AE.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.savebtn_AE.UseVisualStyleBackColor = false;
            this.savebtn_AE.Click += new System.EventHandler(this.savebtn_AE_Click);
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.Location = new System.Drawing.Point(19, 80);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(35, 16);
            this.label22.TabIndex = 2;
            this.label22.Text = "Edit";
            // 
            // editbtn_AE
            // 
            this.editbtn_AE.BackColor = System.Drawing.Color.LightGray;
            this.editbtn_AE.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.editbtn_AE.Enabled = false;
            this.editbtn_AE.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
            this.editbtn_AE.Location = new System.Drawing.Point(10, 26);
            this.editbtn_AE.Name = "editbtn_AE";
            this.editbtn_AE.Size = new System.Drawing.Size(50, 50);
            this.editbtn_AE.TabIndex = 97;
            this.editbtn_AE.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.editbtn_AE.UseVisualStyleBackColor = false;
            this.editbtn_AE.Click += new System.EventHandler(this.editbtn_AE_Click);
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(313, 132);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(131, 18);
            this.label23.TabIndex = 98;
            this.label23.Text = "AE Parameter";
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.dgv_AE);
            this.panel5.Location = new System.Drawing.Point(329, 165);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(426, 292);
            this.panel5.TabIndex = 97;
            // 
            // dgv_AE
            // 
            this.dgv_AE.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_AE.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_AE.Location = new System.Drawing.Point(0, 0);
            this.dgv_AE.Name = "dgv_AE";
            this.dgv_AE.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            this.dgv_AE.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.dgv_AE.Size = new System.Drawing.Size(422, 292);
            this.dgv_AE.TabIndex = 0;
            // 
            // tabPage10
            // 
            this.tabPage10.Controls.Add(this.groupBox4);
            this.tabPage10.Controls.Add(this.label45);
            this.tabPage10.Controls.Add(this.dgv_delay);
            this.tabPage10.Location = new System.Drawing.Point(4, 27);
            this.tabPage10.Margin = new System.Windows.Forms.Padding(2);
            this.tabPage10.Name = "tabPage10";
            this.tabPage10.Size = new System.Drawing.Size(967, 589);
            this.tabPage10.TabIndex = 4;
            this.tabPage10.Text = "DELAY";
            this.tabPage10.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            this.groupBox4.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox4.Controls.Add(this.savebtn_delay);
            this.groupBox4.Controls.Add(this.editbtn_delay);
            this.groupBox4.Controls.Add(this.label25);
            this.groupBox4.Controls.Add(this.label44);
            this.groupBox4.Location = new System.Drawing.Point(416, 411);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(235, 112);
            this.groupBox4.TabIndex = 97;
            this.groupBox4.TabStop = false;
            // 
            // savebtn_delay
            // 
            this.savebtn_delay.BackColor = System.Drawing.Color.LightGray;
            this.savebtn_delay.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.savebtn_delay.Enabled = false;
            this.savebtn_delay.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
            this.savebtn_delay.Location = new System.Drawing.Point(157, 17);
            this.savebtn_delay.Name = "savebtn_delay";
            this.savebtn_delay.Size = new System.Drawing.Size(50, 50);
            this.savebtn_delay.TabIndex = 61;
            this.savebtn_delay.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.savebtn_delay.UseVisualStyleBackColor = false;
            this.savebtn_delay.Click += new System.EventHandler(this.savebtn_delay_Click);
            // 
            // editbtn_delay
            // 
            this.editbtn_delay.BackColor = System.Drawing.Color.LightGray;
            this.editbtn_delay.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.editbtn_delay.Enabled = false;
            this.editbtn_delay.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
            this.editbtn_delay.Location = new System.Drawing.Point(13, 19);
            this.editbtn_delay.Name = "editbtn_delay";
            this.editbtn_delay.Size = new System.Drawing.Size(50, 50);
            this.editbtn_delay.TabIndex = 60;
            this.editbtn_delay.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.editbtn_delay.UseVisualStyleBackColor = false;
            this.editbtn_delay.Click += new System.EventHandler(this.editbtn_delay_Click);
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label25.Location = new System.Drawing.Point(161, 79);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(43, 16);
            this.label25.TabIndex = 2;
            this.label25.Text = "Save";
            // 
            // label44
            // 
            this.label44.AutoSize = true;
            this.label44.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label44.Location = new System.Drawing.Point(19, 80);
            this.label44.Name = "label44";
            this.label44.Size = new System.Drawing.Size(35, 16);
            this.label44.TabIndex = 2;
            this.label44.Text = "Edit";
            // 
            // label45
            // 
            this.label45.AutoSize = true;
            this.label45.Location = new System.Drawing.Point(244, 66);
            this.label45.Name = "label45";
            this.label45.Size = new System.Drawing.Size(57, 18);
            this.label45.TabIndex = 96;
            this.label45.Text = "Delay";
            // 
            // dgv_delay
            // 
            this.dgv_delay.AllowUserToAddRows = false;
            this.dgv_delay.AllowUserToDeleteRows = false;
            this.dgv_delay.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_delay.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_delay.ImeMode = System.Windows.Forms.ImeMode.Katakana;
            this.dgv_delay.Location = new System.Drawing.Point(248, 97);
            this.dgv_delay.Name = "dgv_delay";
            this.dgv_delay.ReadOnly = true;
            this.dgv_delay.RowHeadersWidth = 51;
            this.dgv_delay.Size = new System.Drawing.Size(723, 308);
            this.dgv_delay.TabIndex = 95;
            // 
            // tabPage11
            // 
            this.tabPage11.Controls.Add(this.groupBox5);
            this.tabPage11.Controls.Add(this.SFCGridview);
            this.tabPage11.Location = new System.Drawing.Point(4, 27);
            this.tabPage11.Margin = new System.Windows.Forms.Padding(2);
            this.tabPage11.Name = "tabPage11";
            this.tabPage11.Size = new System.Drawing.Size(967, 589);
            this.tabPage11.TabIndex = 5;
            this.tabPage11.Text = "SFC & PDCA";
            this.tabPage11.UseVisualStyleBackColor = true;
            // 
            // groupBox5
            // 
            this.groupBox5.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox5.Controls.Add(this.label51);
            this.groupBox5.Controls.Add(this.SFC_Save);
            this.groupBox5.Controls.Add(this.label52);
            this.groupBox5.Controls.Add(this.SFC_Edit);
            this.groupBox5.Location = new System.Drawing.Point(841, 158);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(79, 204);
            this.groupBox5.TabIndex = 100;
            this.groupBox5.TabStop = false;
            // 
            // label51
            // 
            this.label51.AutoSize = true;
            this.label51.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label51.Location = new System.Drawing.Point(17, 172);
            this.label51.Name = "label51";
            this.label51.Size = new System.Drawing.Size(43, 16);
            this.label51.TabIndex = 2;
            this.label51.Text = "Save";
            // 
            // SFC_Save
            // 
            this.SFC_Save.BackColor = System.Drawing.Color.LightGray;
            this.SFC_Save.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.SFC_Save.Enabled = false;
            this.SFC_Save.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
            this.SFC_Save.Location = new System.Drawing.Point(10, 119);
            this.SFC_Save.Name = "SFC_Save";
            this.SFC_Save.Size = new System.Drawing.Size(50, 50);
            this.SFC_Save.TabIndex = 98;
            this.SFC_Save.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.SFC_Save.UseVisualStyleBackColor = false;
            this.SFC_Save.Click += new System.EventHandler(this.SFC_Save_Click);
            // 
            // label52
            // 
            this.label52.AutoSize = true;
            this.label52.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label52.Location = new System.Drawing.Point(19, 80);
            this.label52.Name = "label52";
            this.label52.Size = new System.Drawing.Size(35, 16);
            this.label52.TabIndex = 2;
            this.label52.Text = "Edit";
            // 
            // SFC_Edit
            // 
            this.SFC_Edit.BackColor = System.Drawing.Color.LightGray;
            this.SFC_Edit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.SFC_Edit.Enabled = false;
            this.SFC_Edit.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
            this.SFC_Edit.Location = new System.Drawing.Point(10, 26);
            this.SFC_Edit.Name = "SFC_Edit";
            this.SFC_Edit.Size = new System.Drawing.Size(50, 50);
            this.SFC_Edit.TabIndex = 97;
            this.SFC_Edit.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.SFC_Edit.UseVisualStyleBackColor = false;
            this.SFC_Edit.Click += new System.EventHandler(this.SFC_Edit_Click);
            // 
            // SFCGridview
            // 
            this.SFCGridview.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.SFCGridview.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.SFCGridview.Location = new System.Drawing.Point(35, 27);
            this.SFCGridview.Name = "SFCGridview";
            this.SFCGridview.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            this.SFCGridview.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.SFCGridview.Size = new System.Drawing.Size(753, 481);
            this.SFCGridview.TabIndex = 99;
            // 
            // tabPage12
            // 
            this.tabPage12.Controls.Add(this.groupBox6);
            this.tabPage12.Controls.Add(this.Feeder_Min_Max);
            this.tabPage12.Controls.Add(this.dgv_Feeder_Min_Max);
            this.tabPage12.Controls.Add(this.M_C_Ready_to_Recive);
            this.tabPage12.Controls.Add(this.Check_Semma);
            this.tabPage12.Location = new System.Drawing.Point(4, 27);
            this.tabPage12.Name = "tabPage12";
            this.tabPage12.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage12.Size = new System.Drawing.Size(967, 589);
            this.tabPage12.TabIndex = 6;
            this.tabPage12.Text = "OTHER\'S";
            this.tabPage12.UseVisualStyleBackColor = true;
            // 
            // groupBox6
            // 
            this.groupBox6.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox6.Controls.Add(this.savebtn_feeder);
            this.groupBox6.Controls.Add(this.editbtn_feeder);
            this.groupBox6.Controls.Add(this.label53);
            this.groupBox6.Controls.Add(this.label54);
            this.groupBox6.Location = new System.Drawing.Point(395, 299);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(230, 96);
            this.groupBox6.TabIndex = 110;
            this.groupBox6.TabStop = false;
            // 
            // savebtn_feeder
            // 
            this.savebtn_feeder.BackColor = System.Drawing.Color.LightGray;
            this.savebtn_feeder.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.savebtn_feeder.Enabled = false;
            this.savebtn_feeder.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
            this.savebtn_feeder.Location = new System.Drawing.Point(157, 17);
            this.savebtn_feeder.Name = "savebtn_feeder";
            this.savebtn_feeder.Size = new System.Drawing.Size(50, 39);
            this.savebtn_feeder.TabIndex = 61;
            this.savebtn_feeder.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.savebtn_feeder.UseVisualStyleBackColor = false;
            this.savebtn_feeder.Click += new System.EventHandler(this.savebtn_feeder_Click);
            // 
            // editbtn_feeder
            // 
            this.editbtn_feeder.BackColor = System.Drawing.Color.LightGray;
            this.editbtn_feeder.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.editbtn_feeder.Enabled = false;
            this.editbtn_feeder.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
            this.editbtn_feeder.Location = new System.Drawing.Point(13, 19);
            this.editbtn_feeder.Name = "editbtn_feeder";
            this.editbtn_feeder.Size = new System.Drawing.Size(50, 37);
            this.editbtn_feeder.TabIndex = 60;
            this.editbtn_feeder.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.editbtn_feeder.UseVisualStyleBackColor = false;
            this.editbtn_feeder.Click += new System.EventHandler(this.editbtn_feeder_Click);
            // 
            // label53
            // 
            this.label53.AutoSize = true;
            this.label53.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label53.Location = new System.Drawing.Point(164, 59);
            this.label53.Name = "label53";
            this.label53.Size = new System.Drawing.Size(43, 16);
            this.label53.TabIndex = 2;
            this.label53.Text = "Save";
            // 
            // label54
            // 
            this.label54.AutoSize = true;
            this.label54.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label54.Location = new System.Drawing.Point(19, 59);
            this.label54.Name = "label54";
            this.label54.Size = new System.Drawing.Size(35, 16);
            this.label54.TabIndex = 2;
            this.label54.Text = "Edit";
            // 
            // Feeder_Min_Max
            // 
            this.Feeder_Min_Max.AutoSize = true;
            this.Feeder_Min_Max.Location = new System.Drawing.Point(382, 55);
            this.Feeder_Min_Max.Name = "Feeder_Min_Max";
            this.Feeder_Min_Max.Size = new System.Drawing.Size(70, 18);
            this.Feeder_Min_Max.TabIndex = 109;
            this.Feeder_Min_Max.Text = "Feeder";
            // 
            // dgv_Feeder_Min_Max
            // 
            this.dgv_Feeder_Min_Max.AllowUserToAddRows = false;
            this.dgv_Feeder_Min_Max.AllowUserToDeleteRows = false;
            this.dgv_Feeder_Min_Max.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_Feeder_Min_Max.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Feeder_Min_Max.ImeMode = System.Windows.Forms.ImeMode.Katakana;
            this.dgv_Feeder_Min_Max.Location = new System.Drawing.Point(382, 76);
            this.dgv_Feeder_Min_Max.Name = "dgv_Feeder_Min_Max";
            this.dgv_Feeder_Min_Max.ReadOnly = true;
            this.dgv_Feeder_Min_Max.RowHeadersWidth = 51;
            this.dgv_Feeder_Min_Max.Size = new System.Drawing.Size(533, 217);
            this.dgv_Feeder_Min_Max.TabIndex = 108;
            // 
            // M_C_Ready_to_Recive
            // 
            this.M_C_Ready_to_Recive.AutoSize = true;
            this.M_C_Ready_to_Recive.Location = new System.Drawing.Point(82, 55);
            this.M_C_Ready_to_Recive.Name = "M_C_Ready_to_Recive";
            this.M_C_Ready_to_Recive.Size = new System.Drawing.Size(211, 18);
            this.M_C_Ready_to_Recive.TabIndex = 107;
            this.M_C_Ready_to_Recive.Text = "M_C_Ready_to_Recive";
            // 
            // Check_Semma
            // 
            this.Check_Semma.BackColor = System.Drawing.Color.GhostWhite;
            this.Check_Semma.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Check_Semma.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Check_Semma.Location = new System.Drawing.Point(85, 76);
            this.Check_Semma.Name = "Check_Semma";
            this.Check_Semma.Size = new System.Drawing.Size(291, 70);
            this.Check_Semma.TabIndex = 106;
            this.Check_Semma.Text = "ONLINE";
            this.Check_Semma.UseVisualStyleBackColor = false;
            // 
            // HomeScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(975, 620);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "HomeScreen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "HomeScreen";
            this.Load += new System.EventHandler(this.HomeScreen_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.conectionStatusGrid)).EndInit();
            this.pnlMachineStatus.ResumeLayout(false);
            this.pnlMachineStatus.PerformLayout();
            this.pnlMachineHealth.ResumeLayout(false);
            this.pnlMachineHealth.PerformLayout();
            this.tabLog.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAlarmlive)).EndInit();
            this.tabPage5.ResumeLayout(false);
            this.tabPage5.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            this.panel7_4.ResumeLayout(false);
            this.panel7_4.PerformLayout();
            this.panel8_4.ResumeLayout(false);
            this.panel3_4.ResumeLayout(false);
            this.pnlScanner_4.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.panel8.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.pnlScanner.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FinalRslt)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabPage6.ResumeLayout(false);
            this.tabControl2.ResumeLayout(false);
            this.tabPage13.ResumeLayout(false);
            this.tabPage13.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_offset)).EndInit();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.tabPage7.ResumeLayout(false);
            this.tabPage7.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_offsetK)).EndInit();
            this.groupBoxoffset.ResumeLayout(false);
            this.groupBoxoffset.PerformLayout();
            this.tabPage9.ResumeLayout(false);
            this.tabPage9.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_offsetNk)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.tabPage8.ResumeLayout(false);
            this.tabPage8.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.panel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_AE)).EndInit();
            this.tabPage10.ResumeLayout(false);
            this.tabPage10.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_delay)).EndInit();
            this.tabPage11.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SFCGridview)).EndInit();
            this.tabPage12.ResumeLayout(false);
            this.tabPage12.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Feeder_Min_Max)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private Timer timer1;
        private TabControl tabControl1;
        private TabPage tabPage3;
        private TabPage tabPage4;
        private Button Homing;
        private TabControl tabLog;
        private TabPage tabPage1;
        private ListBox lstRunningLog;
        private TabPage tabPage2;
        private DataGridView dgvAlarmlive;
        private Panel pnlMachineHealth;
        private Button button3;
        private Label label2;
        private LinkLabel linkLabel2;
        private Label lblShift;
        private Label label3;
        private Button button12;
        private Button button13;
        private Button button14;
        private Label label14;
        private Label label17;
        private Label label20;
        private Label label21;
        private Label lblTotaltime;
        private Label lblIdletime;
        private Label lblDowntime;
        private Label lblRunTime;
        private Label label26;
        private Label label27;
        private Label label28;
        private Label label29;
        private Panel pnlMachineStatus;
        private TextBox textBox23;
        private TextBox txtMachineMode;
        private TextBox textBox25;
        private TextBox textBox7;
        private TextBox textBox6;
        private TextBox textBox5;
        private TextBox textBox4;
        private TextBox textBox3;
        private TextBox textBox2;
        private Label label4;
        private TextBox txtUph;
        private TextBox txtCycletime;
        private TextBox textBox17;
        private TextBox textBox16;
        private TextBox txtyYeldcnt;
        private TextBox txtOverallcnt;
        private TextBox txtFailcnt;
        private TextBox txtPasscnt;
        private TextBox textBox13;
        private TextBox textBox12;
        private TextBox textBox11;
        private TextBox textBox8;
        private Panel panel1;
        private DataGridView conectionStatusGrid;
        private Label label1;
        private Panel panel2;
        private LinkLabel linkLabel1;
        private Label label38;
        private Label label34;
        private Label label37;
        private Label label33;
        private Label label36;
        private Label label30;
        private Label label35;
        private Label label19;
        private Label label32;
        private Label label31;
        private Label label42;
        private Label label39;
        private Label label40;
        private Label label41;
        private Label label43;
        private GroupBox groupBox1;
        private Label label46;
        private Panel panel7;
        private Label label47;
        private Panel panel8;
        private Label lblFI_12;
        private Label lblFI_1;
        private Label lblFI_11;
        private Label lblFI_2;
        private Label lblFI_10;
        private Label lblFI_3;
        private Label lblFI_9;
        private Label lblFI_4;
        private Label lblFI_8;
        private Label lblFI_5;
        private Label lblFI_7;
        private Label lblFI_6;
        private Label label48;
        private Panel panel3;
        private Label lblAS_12;
        private Label lblAS_1;
        private Label lblAS_11;
        private Label lblAS_2;
        private Label lblAS_10;
        private Label lblAS_3;
        private Label lblAS_9;
        private Label lblAS_4;
        private Label lblAS_8;
        private Label lblAS_5;
        private Label lblAS_7;
        private Label lblAS_6;
        private Label label49;
        private Panel pnlScanner;
        private Label lblSC_10;
        private Label lblSC_11;
        private Label lblSC_12;
        private Label lblSC_9;
        private Label lblSC_8;
        private Label lblSC_7;
        private Label lblSC_4;
        private Label lblSC_5;
        private Label lblSC_6;
        private Label CARRIER_SN;
        private Label lblSC_3;
        private Label lblSC_2;
        private Label label50;
        private Label BN_WK2;
        private Label BN_wk1;
        private Label lblSC_1;
        private Button button5;
        private DataGridView FinalRslt;
        private Button button1;
        private Button button2;
        private Button MS_clear;
        private Button MachineLamp;
        private TabPage tabPage5;
        private TextBox textBox10;
        private TextBox textBox9;
        private Label label8;
        private Label label7;
        private Label label6;
        private TextBox textBox1;
        private Label label5;
        private TextBox textBox14;
        private Label label9;
        private TextBox textBox15;
        private TextBox textBox18;
        private Label label10;
        private Label label11;
        private TextBox textBox19;
        private TextBox txtonlypasting;
        private TextBox txtout;
        private TextBox textBox21;
        private TextBox textBox20;
        private Button OfflinewithoutSFC;
        private Button OnlinewithoutSFC;
        private TabPage tabPage6;
        private TabControl tabControl2;
        private TabPage tabPage7;
        private DataGridView dgv_offsetK;
        private GroupBox groupBoxoffset;
        private Button savebtn_offsetK;
        private Button editbtn_offsetK;
        private Label label12;
        private Label label15;
        private Label lbl_ofset;
        private Panel offset;
        private TabPage tabPage9;
        private DataGridView dgv_offsetNk;
        private GroupBox groupBox2;
        private Button savebtn_offsetNk;
        private Button editbtn_offsetNk;
        private Label label13;
        private Label label16;
        private Label label24;
        private Panel panel4;
        private TabPage tabPage8;
        private GroupBox groupBox3;
        private Label label18;
        private Button savebtn_AE;
        private Label label22;
        private Button editbtn_AE;
        private Label label23;
        private Panel panel5;
        private DataGridView dgv_AE;
        private TabPage tabPage10;
        private TabPage tabPage11;
        private GroupBox groupBox4;
        private Button savebtn_delay;
        private Button editbtn_delay;
        private Label label25;
        private Label label44;
        private Label label45;
        private DataGridView dgv_delay;
        private GroupBox groupBox5;
        private Label label51;
        private Button SFC_Save;
        private Label label52;
        private Button SFC_Edit;
        private DataGridView SFCGridview;
        private TabPage tabPage12;
        private Button Check_Semma;
        private GroupBox groupBox6;
        private Button savebtn_feeder;
        private Button editbtn_feeder;
        private Label label53;
        private Label label54;
        private Label Feeder_Min_Max;
        private DataGridView dgv_Feeder_Min_Max;
        private Label M_C_Ready_to_Recive;
        private TabPage tabPage13;
        private DataGridView dgv_offset;
        private GroupBox groupBox7;
        private Button savebtn_offset;
        private Button editbtn_offset;
        private Label label55;
        private Label label56;
        private Label label57;
        private Panel panel6;
        private Panel panel7_4;
        private Label label58;
        private Panel panel8_4;
        private Label BN_WK2_4;
        private Label lblFI_12_4;
        private Label lblFI_1_4;
        private Label lblFI_11_4;
        private Label lblFI_2_4;
        private Label lblFI_10_4;
        private Label lblFI_3_4;
        private Label lblFI_9_4;
        private Label lblFI_4_4;
        private Label lblFI_8_4;
        private Label lblFI_5_4;
        private Label lblFI_7_4;
        private Label lblFI_6_4;
        private Label label59;
        private Panel panel3_4;
        private Label BN_wk1_4;
        private Label lblAS_12_4;
        private Label lblAS_1_4;
        private Label lblAS_11_4;
        private Label lblAS_2_4;
        private Label lblAS_10_4;
        private Label lblAS_3_4;
        private Label lblAS_9_4;
        private Label lblAS_4_4;
        private Label lblAS_8_4;
        private Label lblAS_5_4;
        private Label lblAS_7_4;
        private Label lblAS_6_4;
        private Label label60;
        private Panel pnlScanner_4;
        private Label lblSC_10_4;
        private Label lblSC_11_4;
        private Label lblSC_12_4;
        private Label lblSC_9_4;
        private Label lblSC_8_4;
        private Label lblSC_7_4;
        private Label lblSC_4_4;
        private Label lblSC_5_4;
        private Label lblSC_6_4;
        private Label CARRIER_SN_4;
        private Label lblSC_3_4;
        private Label lblSC_2_4;
        private Label lblSC_1_4;
        private Label label61;
        private Label label62;
    }
}