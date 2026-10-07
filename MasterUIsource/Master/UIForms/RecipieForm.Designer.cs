using System;
using System.Drawing;
using System.Windows.Forms;

namespace UI.UI_Forms
{
    partial class RecipieForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RecipieForm));
            this.RecipieTabPanel = new System.Windows.Forms.Panel();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.grpGantry2 = new System.Windows.Forms.GroupBox();
            this.txt_PrfPos_Z1 = new System.Windows.Forms.TextBox();
            this.lblZ_Position = new System.Windows.Forms.Label();
            this.btnZ1Add = new System.Windows.Forms.Button();
            this.btnR2Add = new System.Windows.Forms.Button();
            this.btnR2Dec = new System.Windows.Forms.Button();
            this.btnZ1Dec = new System.Windows.Forms.Button();
            this.txt_PrfPos_Z2 = new System.Windows.Forms.TextBox();
            this.txt_PrfPos_R2 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnR1Add = new System.Windows.Forms.Button();
            this.txt_PrfPos_R1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnR1Dec = new System.Windows.Forms.Button();
            this.btnZ2Dec = new System.Windows.Forms.Button();
            this.btnZ2Add = new System.Windows.Forms.Button();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.textBox62 = new System.Windows.Forms.TextBox();
            this.label316 = new System.Windows.Forms.Label();
            this.label313 = new System.Windows.Forms.Label();
            this.label315 = new System.Windows.Forms.Label();
            this.label314 = new System.Windows.Forms.Label();
            this.textBox63 = new System.Windows.Forms.TextBox();
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
            this.grpGantry = new System.Windows.Forms.GroupBox();
            this.lblY_Position = new System.Windows.Forms.Label();
            this.txt_PrfPos_Y1 = new System.Windows.Forms.TextBox();
            this.btnXAdd = new System.Windows.Forms.Button();
            this.btnYDec = new System.Windows.Forms.Button();
            this.btnYAdd = new System.Windows.Forms.Button();
            this.btnXDec = new System.Windows.Forms.Button();
            this.lblX_Position = new System.Windows.Forms.Label();
            this.txt_PrfPos_X1 = new System.Windows.Forms.TextBox();
            this.grp_EditSave = new System.Windows.Forms.GroupBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.lblSave = new System.Windows.Forms.Label();
            this.lblEdit = new System.Windows.Forms.Label();
            this.tabRecipe = new System.Windows.Forms.TabControl();
            this.PickGantry = new System.Windows.Forms.TabPage();
            this.checkvelocity = new System.Windows.Forms.CheckBox();
            this.lblmotorparam = new System.Windows.Forms.Label();
            this.lblselectPast = new System.Windows.Forms.Label();
            this.chkbox_move = new System.Windows.Forms.CheckBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dgv_PickGantry = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.moveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.teachToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cmbSelGantry = new System.Windows.Forms.ComboBox();
            this.lblSelGantry = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.RecipieTabPanel.SuspendLayout();
            this.pnlMain.SuspendLayout();
            this.panel2.SuspendLayout();
            this.grpGantry2.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.grpMoveAbsolute.SuspendLayout();
            this.grpGantry.SuspendLayout();
            this.grp_EditSave.SuspendLayout();
            this.tabRecipe.SuspendLayout();
            this.PickGantry.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_PickGantry)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // RecipieTabPanel
            // 
            this.RecipieTabPanel.Controls.Add(this.pnlMain);
            this.RecipieTabPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RecipieTabPanel.Location = new System.Drawing.Point(0, 0);
            this.RecipieTabPanel.Name = "RecipieTabPanel";
            this.RecipieTabPanel.Size = new System.Drawing.Size(1135, 620);
            this.RecipieTabPanel.TabIndex = 0;
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.panel2);
            this.pnlMain.Controls.Add(this.grp_EditSave);
            this.pnlMain.Controls.Add(this.tabRecipe);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(1135, 620);
            this.pnlMain.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.grpGantry2);
            this.panel2.Controls.Add(this.groupBox7);
            this.panel2.Controls.Add(this.grpMoveAbsolute);
            this.panel2.Controls.Add(this.grpGantry);
            this.panel2.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel2.Location = new System.Drawing.Point(21, 412);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(992, 208);
            this.panel2.TabIndex = 83;
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
            this.grpGantry2.Controls.Add(this.label4);
            this.grpGantry2.Controls.Add(this.btnR1Add);
            this.grpGantry2.Controls.Add(this.txt_PrfPos_R1);
            this.grpGantry2.Controls.Add(this.label2);
            this.grpGantry2.Controls.Add(this.label3);
            this.grpGantry2.Controls.Add(this.btnR1Dec);
            this.grpGantry2.Controls.Add(this.btnZ2Dec);
            this.grpGantry2.Controls.Add(this.btnZ2Add);
            this.grpGantry2.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpGantry2.Location = new System.Drawing.Point(615, 6);
            this.grpGantry2.Name = "grpGantry2";
            this.grpGantry2.Size = new System.Drawing.Size(199, 201);
            this.grpGantry2.TabIndex = 87;
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
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(87, 158);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(106, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "R2 Position (mm)";
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
            this.btnR1Add.Click += new System.EventHandler(this.btnR1Add_Click);
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
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(87, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(106, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Z2 Position (mm)";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(87, 112);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(106, 13);
            this.label3.TabIndex = 14;
            this.label3.Text = "R1 Position (mm)";
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
            // groupBox7
            // 
            this.groupBox7.BackColor = System.Drawing.Color.White;
            this.groupBox7.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.groupBox7.Controls.Add(this.textBox62);
            this.groupBox7.Controls.Add(this.label316);
            this.groupBox7.Controls.Add(this.label313);
            this.groupBox7.Controls.Add(this.label315);
            this.groupBox7.Controls.Add(this.label314);
            this.groupBox7.Controls.Add(this.textBox63);
            this.groupBox7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox7.Location = new System.Drawing.Point(814, 11);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(173, 196);
            this.groupBox7.TabIndex = 86;
            this.groupBox7.TabStop = false;
            // 
            // textBox62
            // 
            this.textBox62.Enabled = false;
            this.textBox62.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox62.Location = new System.Drawing.Point(85, 53);
            this.textBox62.Name = "textBox62";
            this.textBox62.Size = new System.Drawing.Size(60, 21);
            this.textBox62.TabIndex = 16;
            this.textBox62.Text = "0000";
            this.textBox62.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label316
            // 
            this.label316.AutoSize = true;
            this.label316.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label316.Location = new System.Drawing.Point(6, 56);
            this.label316.Name = "label316";
            this.label316.Size = new System.Drawing.Size(73, 13);
            this.label316.TabIndex = 14;
            this.label316.Text = "Loadcell 2";
            // 
            // label313
            // 
            this.label313.AutoSize = true;
            this.label313.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label313.Location = new System.Drawing.Point(151, 56);
            this.label313.Name = "label313";
            this.label313.Size = new System.Drawing.Size(22, 16);
            this.label313.TabIndex = 18;
            this.label313.Text = "kg";
            // 
            // label315
            // 
            this.label315.AutoSize = true;
            this.label315.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label315.Location = new System.Drawing.Point(6, 24);
            this.label315.Name = "label315";
            this.label315.Size = new System.Drawing.Size(73, 13);
            this.label315.TabIndex = 13;
            this.label315.Text = "Loadcell 1";
            // 
            // label314
            // 
            this.label314.AutoSize = true;
            this.label314.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label314.Location = new System.Drawing.Point(151, 24);
            this.label314.Name = "label314";
            this.label314.Size = new System.Drawing.Size(22, 16);
            this.label314.TabIndex = 17;
            this.label314.Text = "kg";
            // 
            // textBox63
            // 
            this.textBox63.Enabled = false;
            this.textBox63.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox63.Location = new System.Drawing.Point(85, 21);
            this.textBox63.Name = "textBox63";
            this.textBox63.Size = new System.Drawing.Size(60, 21);
            this.textBox63.TabIndex = 15;
            this.textBox63.Text = "0000";
            this.textBox63.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
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
            this.grpMoveAbsolute.Location = new System.Drawing.Point(3, 6);
            this.grpMoveAbsolute.Name = "grpMoveAbsolute";
            this.grpMoveAbsolute.Size = new System.Drawing.Size(301, 196);
            this.grpMoveAbsolute.TabIndex = 84;
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
            this.grpGantry.Location = new System.Drawing.Point(310, 6);
            this.grpGantry.Name = "grpGantry";
            this.grpGantry.Size = new System.Drawing.Size(298, 196);
            this.grpGantry.TabIndex = 0;
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
            this.btnXAdd.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnXAdd_MouseDown);
            this.btnXAdd.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnXAdd_MouseUp);
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
            this.btnYDec.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnYDec_MouseDown);
            this.btnYDec.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnYDec_MouseUp);
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
            this.btnYAdd.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnYAdd_MouseDown);
            this.btnYAdd.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnYAdd_MouseUp);
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
            this.btnXDec.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnXDec_MouseDown);
            this.btnXDec.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnXDec_MouseUp);
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
            // grp_EditSave
            // 
            this.grp_EditSave.BackColor = System.Drawing.SystemColors.Control;
            this.grp_EditSave.Controls.Add(this.btnSave);
            this.grp_EditSave.Controls.Add(this.btnEdit);
            this.grp_EditSave.Controls.Add(this.lblSave);
            this.grp_EditSave.Controls.Add(this.lblEdit);
            this.grp_EditSave.Location = new System.Drawing.Point(934, 125);
            this.grp_EditSave.Name = "grp_EditSave";
            this.grp_EditSave.Size = new System.Drawing.Size(79, 204);
            this.grp_EditSave.TabIndex = 85;
            this.grp_EditSave.TabStop = false;
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.LightGray;
            this.btnSave.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSave.BackgroundImage")));
            this.btnSave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSave.Enabled = false;
            this.btnSave.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnSave.Location = new System.Drawing.Point(13, 110);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(50, 50);
            this.btnSave.TabIndex = 61;
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.BackColor = System.Drawing.Color.LightGray;
            this.btnEdit.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnEdit.BackgroundImage")));
            this.btnEdit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnEdit.Enabled = false;
            this.btnEdit.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnEdit.Location = new System.Drawing.Point(13, 19);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(50, 50);
            this.btnEdit.TabIndex = 60;
            this.btnEdit.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnEdit.UseVisualStyleBackColor = false;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
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
            // tabRecipe
            // 
            this.tabRecipe.Controls.Add(this.PickGantry);
            this.tabRecipe.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabRecipe.Location = new System.Drawing.Point(3, 3);
            this.tabRecipe.Name = "tabRecipe";
            this.tabRecipe.SelectedIndex = 0;
            this.tabRecipe.Size = new System.Drawing.Size(861, 407);
            this.tabRecipe.TabIndex = 84;
            this.tabRecipe.SelectedIndexChanged += new System.EventHandler(this.tabRecipe_SelectedIndexChanged);
            // 
            // PickGantry
            // 
            this.PickGantry.Controls.Add(this.checkvelocity);
            this.PickGantry.Controls.Add(this.lblmotorparam);
            this.PickGantry.Controls.Add(this.lblselectPast);
            this.PickGantry.Controls.Add(this.chkbox_move);
            this.PickGantry.Controls.Add(this.panel1);
            this.PickGantry.Controls.Add(this.cmbSelGantry);
            this.PickGantry.Controls.Add(this.lblSelGantry);
            this.PickGantry.Location = new System.Drawing.Point(4, 27);
            this.PickGantry.Name = "PickGantry";
            this.PickGantry.Size = new System.Drawing.Size(853, 376);
            this.PickGantry.TabIndex = 5;
            this.PickGantry.Text = "GANTRY";
            this.PickGantry.UseVisualStyleBackColor = true;
            // 
            // checkvelocity
            // 
            this.checkvelocity.AccessibleRole = System.Windows.Forms.AccessibleRole.Window;
            this.checkvelocity.AutoSize = true;
            this.checkvelocity.Location = new System.Drawing.Point(795, 23);
            this.checkvelocity.Name = "checkvelocity";
            this.checkvelocity.Size = new System.Drawing.Size(15, 14);
            this.checkvelocity.TabIndex = 9;
            this.checkvelocity.UseVisualStyleBackColor = true;
            this.checkvelocity.CheckedChanged += new System.EventHandler(this.checkvelocity_CheckedChanged);
            // 
            // lblmotorparam
            // 
            this.lblmotorparam.AutoSize = true;
            this.lblmotorparam.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblmotorparam.Location = new System.Drawing.Point(651, 21);
            this.lblmotorparam.Name = "lblmotorparam";
            this.lblmotorparam.Size = new System.Drawing.Size(138, 16);
            this.lblmotorparam.TabIndex = 8;
            this.lblmotorparam.Text = "Motor Parameters";
            // 
            // lblselectPast
            // 
            this.lblselectPast.AutoSize = true;
            this.lblselectPast.Location = new System.Drawing.Point(419, 19);
            this.lblselectPast.Name = "lblselectPast";
            this.lblselectPast.Size = new System.Drawing.Size(205, 18);
            this.lblselectPast.TabIndex = 5;
            this.lblselectPast.Text = "Select Pasting Position";
            // 
            // chkbox_move
            // 
            this.chkbox_move.AutoSize = true;
            this.chkbox_move.Location = new System.Drawing.Point(630, 23);
            this.chkbox_move.Name = "chkbox_move";
            this.chkbox_move.Size = new System.Drawing.Size(15, 14);
            this.chkbox_move.TabIndex = 4;
            this.chkbox_move.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dgv_PickGantry);
            this.panel1.Location = new System.Drawing.Point(0, 48);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(850, 325);
            this.panel1.TabIndex = 3;
            // 
            // dgv_PickGantry
            // 
            this.dgv_PickGantry.AllowUserToAddRows = false;
            this.dgv_PickGantry.AllowUserToDeleteRows = false;
            this.dgv_PickGantry.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_PickGantry.BackgroundColor = System.Drawing.Color.White;
            this.dgv_PickGantry.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_PickGantry.ContextMenuStrip = this.contextMenuStrip1;
            this.dgv_PickGantry.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_PickGantry.ImeMode = System.Windows.Forms.ImeMode.Katakana;
            this.dgv_PickGantry.Location = new System.Drawing.Point(0, 0);
            this.dgv_PickGantry.Name = "dgv_PickGantry";
            this.dgv_PickGantry.RowHeadersWidth = 51;
            this.dgv_PickGantry.Size = new System.Drawing.Size(850, 325);
            this.dgv_PickGantry.TabIndex = 0;
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
            // cmbSelGantry
            // 
            this.cmbSelGantry.FormattingEnabled = true;
            this.cmbSelGantry.Location = new System.Drawing.Point(163, 16);
            this.cmbSelGantry.Name = "cmbSelGantry";
            this.cmbSelGantry.Size = new System.Drawing.Size(176, 26);
            this.cmbSelGantry.TabIndex = 2;
            this.cmbSelGantry.SelectedIndexChanged += new System.EventHandler(this.cmbSelGantry_SelectedIndexChanged);
            // 
            // lblSelGantry
            // 
            this.lblSelGantry.AutoSize = true;
            this.lblSelGantry.Location = new System.Drawing.Point(22, 19);
            this.lblSelGantry.Name = "lblSelGantry";
            this.lblSelGantry.Size = new System.Drawing.Size(126, 18);
            this.lblSelGantry.TabIndex = 1;
            this.lblSelGantry.Text = "Select Gantry";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // RecipieForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1135, 620);
            this.Controls.Add(this.RecipieTabPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "RecipieForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "RecipieForm";
            this.Load += new System.EventHandler(this.RecipieForm_Load);
            this.RecipieTabPanel.ResumeLayout(false);
            this.pnlMain.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.grpGantry2.ResumeLayout(false);
            this.grpGantry2.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.grpMoveAbsolute.ResumeLayout(false);
            this.grpMoveAbsolute.PerformLayout();
            this.grpGantry.ResumeLayout(false);
            this.grpGantry.PerformLayout();
            this.grp_EditSave.ResumeLayout(false);
            this.grp_EditSave.PerformLayout();
            this.tabRecipe.ResumeLayout(false);
            this.PickGantry.ResumeLayout(false);
            this.PickGantry.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_PickGantry)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        private void cmbAxisMoveAbs_DropDownClosed(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(cmbAxisMoveAbs.Text) || !cmbAxisMoveAbs.Items.Contains(cmbAxisMoveAbs.Text))
            {
                cmbAxisMoveAbs.Text = "SELECT";
                cmbAxisMoveAbs.ForeColor = Color.Gray;
            }
        }

        private void cmbAxisMoveAbs_DropDown(object sender, EventArgs e)
        {
            if (cmbAxisMoveAbs.Text == "SELECT" && cmbAxisMoveAbs.ForeColor == Color.Gray)
            {
                cmbAxisMoveAbs.Text = "";
                cmbAxisMoveAbs.ForeColor = Color.Black;
            }
        }

        private void cmbAxisMoveRel_DropDownClosed(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(cmbAxisMoveAbs.Text) || !cmbAxisMoveAbs.Items.Contains(cmbAxisMoveAbs.Text))
            {
                cmbAxisMoveAbs.Text = "SELECT";
                cmbAxisMoveAbs.ForeColor = Color.Gray;
            }
        }

        private void cmbAxisMoveRel_DropDown(object sender, EventArgs e)
        {
            if (cmbAxisMoveAbs.Text == "SELECT" && cmbAxisMoveAbs.ForeColor == Color.Gray)
            {
                cmbAxisMoveAbs.Text = "";
                cmbAxisMoveAbs.ForeColor = Color.Black;
            }
        }






        #endregion

        private Panel RecipieTabPanel;
        private Panel pnlMain;
        private Panel panel2;
        private GroupBox grp_EditSave;
        private Label lblSave;
        private Label lblEdit;
        private Button btnEdit;
        private Button btnSave;
        private GroupBox grpGantry;
        private Button btnZ1Dec;
        private Button btnZ1Add;
        private Label lblZ_Position;
        private TextBox txt_PrfPos_Z1;
        private Label lblY_Position;
        private TextBox txt_PrfPos_Y1;
        private Button btnXAdd;
        private Button btnYDec;
        private Button btnYAdd;
        private Button btnXDec;
        private Label lblX_Position;
        private TextBox txt_PrfPos_X1;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem moveToolStripMenuItem;
        private ToolStripMenuItem teachToolStripMenuItem;
        private Timer timer1;
        private GroupBox grpMoveAbsolute;
        private ComboBox cmbAxisMoveAbs;
        private Label lblMoveAbsSelectAxis;
        private Button btnStop;
        private Label lblServoX_TargetPosition;
        private TextBox txtPositionAbs;
        private Label lblMoveAbsPos;
        private GroupBox groupBox7;
        private TextBox textBox62;
        private Label label316;
        private Label label313;
        private Label label315;
        private Label label314;
        private TextBox textBox63;
        private ComboBox cmbMoveMode;
        private Label label1;
        private Label lblServoX_TargetSpeed;
        private TextBox txtetSpeedAbs;
        private Label lblMoveAbsSpeed;
        private Button btnMoveAbs;
        private GroupBox grpGantry2;
        private Button btnR2Add;
        private Button btnR2Dec;
        private TextBox txt_PrfPos_Z2;
        private Button btnR1Add;
        private Label label2;
        private Button btnR1Dec;
        private Button btnZ2Dec;
        private Button btnZ2Add;
        private Label label4;
        private TextBox txt_PrfPos_R1;
        private Label label3;
        private TextBox txt_PrfPos_R2;

        private TabControl tabRecipe;

        private TabPage PickGantry;
        private Label lblselectPast;
        private CheckBox chkbox_move;
        private Panel panel1;
        private DataGridView dgv_PickGantry;
        private ComboBox cmbSelGantry;
        private Label lblSelGantry;
        private CheckBox checkvelocity;
        private Label lblmotorparam;
        // private Button Btn_SavePos;
    }
}