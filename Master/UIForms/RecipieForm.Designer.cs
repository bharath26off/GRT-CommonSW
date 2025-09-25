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
            this.grpGantry = new System.Windows.Forms.GroupBox();
            this.btnZDec = new System.Windows.Forms.Button();
            this.btnZAdd = new System.Windows.Forms.Button();
            this.lblZ_Position = new System.Windows.Forms.Label();
            this.txt_PrfPos_Z1 = new System.Windows.Forms.TextBox();
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
            this.cmbSelGantry = new System.Windows.Forms.ComboBox();
            this.lblSelGantry = new System.Windows.Forms.Label();
            this.dgv_PickGantry = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.moveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.teachToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Robot = new System.Windows.Forms.TabPage();
            this.btnSaveRobot = new System.Windows.Forms.Button();
            this.dgv_Robot = new System.Windows.Forms.DataGridView();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.lblMoveAbsPos = new System.Windows.Forms.Label();
            this.txtPositionAbs = new System.Windows.Forms.TextBox();
            this.lblMoveAbsSpeed = new System.Windows.Forms.Label();
            this.txtetSpeedAbs = new System.Windows.Forms.TextBox();
            this.lblServoX_TargetPosition = new System.Windows.Forms.Label();
            this.lblServoX_TargetSpeed = new System.Windows.Forms.Label();
            this.btnMove_X1 = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.lblMoveAbsSelectAxis = new System.Windows.Forms.Label();
            this.cmbAxisMoveAbs = new System.Windows.Forms.ComboBox();
            this.grpMoveAbsolute = new System.Windows.Forms.GroupBox();
            this.lblMoveRelPos = new System.Windows.Forms.Label();
            this.txt_Position_Relative = new System.Windows.Forms.TextBox();
            this.lblMoveRelSpeed = new System.Windows.Forms.Label();
            this.txt_Speed_Relative = new System.Windows.Forms.TextBox();
            this.lblPosition_Relative = new System.Windows.Forms.Label();
            this.lblSpeed_Relative = new System.Windows.Forms.Label();
            this.btnPTP_Positive = new System.Windows.Forms.Button();
            this.btnPTP_Negative = new System.Windows.Forms.Button();
            this.lblMoveRelSelectAxis = new System.Windows.Forms.Label();
            this.cmbAxisMoveRel = new System.Windows.Forms.ComboBox();
            this.grpMoveRelative = new System.Windows.Forms.GroupBox();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.textBox62 = new System.Windows.Forms.TextBox();
            this.label316 = new System.Windows.Forms.Label();
            this.label313 = new System.Windows.Forms.Label();
            this.label315 = new System.Windows.Forms.Label();
            this.label314 = new System.Windows.Forms.Label();
            this.textBox63 = new System.Windows.Forms.TextBox();
            this.RecipieTabPanel.SuspendLayout();
            this.pnlMain.SuspendLayout();
            this.panel2.SuspendLayout();
            this.grpGantry.SuspendLayout();
            this.grp_EditSave.SuspendLayout();
            this.tabRecipe.SuspendLayout();
            this.PickGantry.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_PickGantry)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.Robot.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Robot)).BeginInit();
            this.grpMoveAbsolute.SuspendLayout();
            this.grpMoveRelative.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.SuspendLayout();
            // 
            // RecipieTabPanel
            // 
            this.RecipieTabPanel.Controls.Add(this.pnlMain);
            this.RecipieTabPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RecipieTabPanel.Location = new System.Drawing.Point(0, 0);
            this.RecipieTabPanel.Name = "RecipieTabPanel";
            this.RecipieTabPanel.Size = new System.Drawing.Size(975, 620);
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
            this.pnlMain.Size = new System.Drawing.Size(975, 620);
            this.pnlMain.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.groupBox7);
            this.panel2.Controls.Add(this.grpMoveRelative);
            this.panel2.Controls.Add(this.grpMoveAbsolute);
            this.panel2.Controls.Add(this.grpGantry);
            this.panel2.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel2.Location = new System.Drawing.Point(21, 412);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(949, 208);
            this.panel2.TabIndex = 83;
            // 
            // grpGantry
            // 
            this.grpGantry.Controls.Add(this.btnZDec);
            this.grpGantry.Controls.Add(this.btnZAdd);
            this.grpGantry.Controls.Add(this.lblZ_Position);
            this.grpGantry.Controls.Add(this.txt_PrfPos_Z1);
            this.grpGantry.Controls.Add(this.lblY_Position);
            this.grpGantry.Controls.Add(this.txt_PrfPos_Y1);
            this.grpGantry.Controls.Add(this.btnXAdd);
            this.grpGantry.Controls.Add(this.btnYDec);
            this.grpGantry.Controls.Add(this.btnYAdd);
            this.grpGantry.Controls.Add(this.btnXDec);
            this.grpGantry.Controls.Add(this.lblX_Position);
            this.grpGantry.Controls.Add(this.txt_PrfPos_X1);
            this.grpGantry.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpGantry.Location = new System.Drawing.Point(640, 0);
            this.grpGantry.Name = "grpGantry";
            this.grpGantry.Size = new System.Drawing.Size(296, 196);
            this.grpGantry.TabIndex = 0;
            this.grpGantry.TabStop = false;
            this.grpGantry.Text = "Gantry";
            // 
            // btnZDec
            // 
            this.btnZDec.BackColor = System.Drawing.Color.Black;
            this.btnZDec.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnZDec.BackgroundImage")));
            this.btnZDec.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnZDec.Location = new System.Drawing.Point(28, 139);
            this.btnZDec.Name = "btnZDec";
            this.btnZDec.Size = new System.Drawing.Size(50, 50);
            this.btnZDec.TabIndex = 20;
            this.btnZDec.UseVisualStyleBackColor = false;
            this.btnZDec.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnZDec_MouseDown);
            this.btnZDec.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnZDec_MouseUp);
            // 
            // btnZAdd
            // 
            this.btnZAdd.BackColor = System.Drawing.Color.Black;
            this.btnZAdd.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnZAdd.BackgroundImage")));
            this.btnZAdd.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnZAdd.Location = new System.Drawing.Point(105, 139);
            this.btnZAdd.Name = "btnZAdd";
            this.btnZAdd.Size = new System.Drawing.Size(50, 50);
            this.btnZAdd.TabIndex = 19;
            this.btnZAdd.UseVisualStyleBackColor = false;
            this.btnZAdd.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnZAdd_MouseDown);
            this.btnZAdd.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnZAdd_MouseUp);
            // 
            // lblZ_Position
            // 
            this.lblZ_Position.AutoSize = true;
            this.lblZ_Position.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblZ_Position.Location = new System.Drawing.Point(187, 144);
            this.lblZ_Position.Name = "lblZ_Position";
            this.lblZ_Position.Size = new System.Drawing.Size(99, 13);
            this.lblZ_Position.TabIndex = 10;
            this.lblZ_Position.Text = "Z Position (mm)";
            // 
            // txt_PrfPos_Z1
            // 
            this.txt_PrfPos_Z1.Enabled = false;
            this.txt_PrfPos_Z1.Location = new System.Drawing.Point(195, 158);
            this.txt_PrfPos_Z1.Name = "txt_PrfPos_Z1";
            this.txt_PrfPos_Z1.Size = new System.Drawing.Size(83, 23);
            this.txt_PrfPos_Z1.TabIndex = 9;
            this.txt_PrfPos_Z1.Text = "0";
            this.txt_PrfPos_Z1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblY_Position
            // 
            this.lblY_Position.AutoSize = true;
            this.lblY_Position.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblY_Position.Location = new System.Drawing.Point(186, 83);
            this.lblY_Position.Name = "lblY_Position";
            this.lblY_Position.Size = new System.Drawing.Size(98, 13);
            this.lblY_Position.TabIndex = 14;
            this.lblY_Position.Text = "Y Position (mm)";
            // 
            // txt_PrfPos_Y1
            // 
            this.txt_PrfPos_Y1.Enabled = false;
            this.txt_PrfPos_Y1.Location = new System.Drawing.Point(194, 97);
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
            this.btnXAdd.Location = new System.Drawing.Point(117, 48);
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
            this.btnYDec.Location = new System.Drawing.Point(62, 12);
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
            this.btnYAdd.Location = new System.Drawing.Point(62, 80);
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
            this.btnXDec.Location = new System.Drawing.Point(7, 48);
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
            this.lblX_Position.Location = new System.Drawing.Point(186, 35);
            this.lblX_Position.Name = "lblX_Position";
            this.lblX_Position.Size = new System.Drawing.Size(99, 13);
            this.lblX_Position.TabIndex = 2;
            this.lblX_Position.Text = "X Position (mm)";
            // 
            // txt_PrfPos_X1
            // 
            this.txt_PrfPos_X1.Enabled = false;
            this.txt_PrfPos_X1.Location = new System.Drawing.Point(194, 49);
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
            this.tabRecipe.Controls.Add(this.Robot);
            this.tabRecipe.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabRecipe.Location = new System.Drawing.Point(3, 3);
            this.tabRecipe.Name = "tabRecipe";
            this.tabRecipe.SelectedIndex = 0;
            this.tabRecipe.Size = new System.Drawing.Size(925, 407);
            this.tabRecipe.TabIndex = 84;
            // 
            // PickGantry
            // 
            this.PickGantry.Controls.Add(this.cmbSelGantry);
            this.PickGantry.Controls.Add(this.lblSelGantry);
            this.PickGantry.Controls.Add(this.dgv_PickGantry);
            this.PickGantry.Location = new System.Drawing.Point(4, 27);
            this.PickGantry.Name = "PickGantry";
            this.PickGantry.Size = new System.Drawing.Size(917, 376);
            this.PickGantry.TabIndex = 5;
            this.PickGantry.Text = "GANTRY";
            this.PickGantry.UseVisualStyleBackColor = true;
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
            // dgv_PickGantry
            // 
            this.dgv_PickGantry.AllowUserToAddRows = false;
            this.dgv_PickGantry.AllowUserToDeleteRows = false;
            this.dgv_PickGantry.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_PickGantry.BackgroundColor = System.Drawing.Color.White;
            this.dgv_PickGantry.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_PickGantry.ContextMenuStrip = this.contextMenuStrip1;
            this.dgv_PickGantry.Location = new System.Drawing.Point(0, 56);
            this.dgv_PickGantry.Name = "dgv_PickGantry";
            this.dgv_PickGantry.RowHeadersWidth = 51;
            this.dgv_PickGantry.Size = new System.Drawing.Size(914, 320);
            this.dgv_PickGantry.TabIndex = 0;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.moveToolStripMenuItem,
            this.teachToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(106, 48);
            // 
            // moveToolStripMenuItem
            // 
            this.moveToolStripMenuItem.Name = "moveToolStripMenuItem";
            this.moveToolStripMenuItem.Size = new System.Drawing.Size(105, 22);
            this.moveToolStripMenuItem.Text = "Move";
            this.moveToolStripMenuItem.Click += new System.EventHandler(this.moveToolStripMenuItem_Click);
            // 
            // teachToolStripMenuItem
            // 
            this.teachToolStripMenuItem.Name = "teachToolStripMenuItem";
            this.teachToolStripMenuItem.Size = new System.Drawing.Size(105, 22);
            this.teachToolStripMenuItem.Text = "Teach";
            this.teachToolStripMenuItem.Click += new System.EventHandler(this.teachToolStripMenuItem_Click);
            // 
            // Robot
            // 
            this.Robot.Controls.Add(this.btnSaveRobot);
            this.Robot.Controls.Add(this.dgv_Robot);
            this.Robot.Location = new System.Drawing.Point(4, 27);
            this.Robot.Name = "Robot";
            this.Robot.Size = new System.Drawing.Size(688, 435);
            this.Robot.TabIndex = 7;
            this.Robot.Text = "ROBOT";
            this.Robot.UseVisualStyleBackColor = true;
            // 
            // btnSaveRobot
            // 
            this.btnSaveRobot.AutoSize = true;
            this.btnSaveRobot.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(94)))), ((int)(((byte)(133)))));
            this.btnSaveRobot.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSaveRobot.ForeColor = System.Drawing.Color.White;
            this.btnSaveRobot.Location = new System.Drawing.Point(569, 26);
            this.btnSaveRobot.Name = "btnSaveRobot";
            this.btnSaveRobot.Size = new System.Drawing.Size(137, 37);
            this.btnSaveRobot.TabIndex = 33;
            this.btnSaveRobot.Text = "Save Robot";
            this.btnSaveRobot.UseVisualStyleBackColor = false;
            this.btnSaveRobot.Click += new System.EventHandler(this.btnSaveRobot_Click);
            // 
            // dgv_Robot
            // 
            this.dgv_Robot.AllowUserToAddRows = false;
            this.dgv_Robot.BackgroundColor = System.Drawing.Color.White;
            this.dgv_Robot.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Robot.Location = new System.Drawing.Point(3, 2);
            this.dgv_Robot.Name = "dgv_Robot";
            this.dgv_Robot.RowHeadersWidth = 51;
            this.dgv_Robot.Size = new System.Drawing.Size(560, 433);
            this.dgv_Robot.TabIndex = 4;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // lblMoveAbsPos
            // 
            this.lblMoveAbsPos.AutoSize = true;
            this.lblMoveAbsPos.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMoveAbsPos.Location = new System.Drawing.Point(6, 49);
            this.lblMoveAbsPos.Name = "lblMoveAbsPos";
            this.lblMoveAbsPos.Size = new System.Drawing.Size(57, 14);
            this.lblMoveAbsPos.TabIndex = 73;
            this.lblMoveAbsPos.Text = "Position";
            // 
            // txtPositionAbs
            // 
            this.txtPositionAbs.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPositionAbs.Location = new System.Drawing.Point(85, 48);
            this.txtPositionAbs.Name = "txtPositionAbs";
            this.txtPositionAbs.Size = new System.Drawing.Size(73, 26);
            this.txtPositionAbs.TabIndex = 74;
            // 
            // lblMoveAbsSpeed
            // 
            this.lblMoveAbsSpeed.AutoSize = true;
            this.lblMoveAbsSpeed.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMoveAbsSpeed.Location = new System.Drawing.Point(6, 84);
            this.lblMoveAbsSpeed.Name = "lblMoveAbsSpeed";
            this.lblMoveAbsSpeed.Size = new System.Drawing.Size(45, 14);
            this.lblMoveAbsSpeed.TabIndex = 75;
            this.lblMoveAbsSpeed.Text = "Speed";
            // 
            // txtetSpeedAbs
            // 
            this.txtetSpeedAbs.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtetSpeedAbs.Location = new System.Drawing.Point(85, 79);
            this.txtetSpeedAbs.Name = "txtetSpeedAbs";
            this.txtetSpeedAbs.Size = new System.Drawing.Size(73, 26);
            this.txtetSpeedAbs.TabIndex = 76;
            // 
            // lblServoX_TargetPosition
            // 
            this.lblServoX_TargetPosition.AutoSize = true;
            this.lblServoX_TargetPosition.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblServoX_TargetPosition.Location = new System.Drawing.Point(164, 53);
            this.lblServoX_TargetPosition.Name = "lblServoX_TargetPosition";
            this.lblServoX_TargetPosition.Size = new System.Drawing.Size(37, 14);
            this.lblServoX_TargetPosition.TabIndex = 77;
            this.lblServoX_TargetPosition.Text = "(mm)";
            // 
            // lblServoX_TargetSpeed
            // 
            this.lblServoX_TargetSpeed.AutoSize = true;
            this.lblServoX_TargetSpeed.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblServoX_TargetSpeed.Location = new System.Drawing.Point(162, 88);
            this.lblServoX_TargetSpeed.Name = "lblServoX_TargetSpeed";
            this.lblServoX_TargetSpeed.Size = new System.Drawing.Size(47, 14);
            this.lblServoX_TargetSpeed.TabIndex = 78;
            this.lblServoX_TargetSpeed.Text = "(mm/s)";
            // 
            // btnMove_X1
            // 
            this.btnMove_X1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(94)))), ((int)(((byte)(133)))));
            this.btnMove_X1.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMove_X1.ForeColor = System.Drawing.Color.White;
            this.btnMove_X1.Location = new System.Drawing.Point(212, 21);
            this.btnMove_X1.Name = "btnMove_X1";
            this.btnMove_X1.Size = new System.Drawing.Size(83, 37);
            this.btnMove_X1.TabIndex = 79;
            this.btnMove_X1.Text = "Move";
            this.btnMove_X1.UseVisualStyleBackColor = false;
            this.btnMove_X1.Click += new System.EventHandler(this.btnMove_X1_Click);
            // 
            // btnStop
            // 
            this.btnStop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(94)))), ((int)(((byte)(133)))));
            this.btnStop.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStop.ForeColor = System.Drawing.Color.White;
            this.btnStop.Location = new System.Drawing.Point(212, 67);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(83, 37);
            this.btnStop.TabIndex = 80;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = false;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
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
            // cmbAxisMoveAbs
            // 
            this.cmbAxisMoveAbs.FormattingEnabled = true;
            this.cmbAxisMoveAbs.Items.AddRange(new object[] {
            "X",
            "Y",
            "Z"});
            this.cmbAxisMoveAbs.Location = new System.Drawing.Point(85, 18);
            this.cmbAxisMoveAbs.Name = "cmbAxisMoveAbs";
            this.cmbAxisMoveAbs.Size = new System.Drawing.Size(124, 24);
            this.cmbAxisMoveAbs.TabIndex = 82;
            this.cmbAxisMoveAbs.SelectedIndexChanged += new System.EventHandler(this.cmbAxisMoveAbs_SelectedIndexChanged);
            this.cmbAxisMoveAbs.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbAxisMoveAbs_KeyPress);
            // 
            // grpMoveAbsolute
            // 
            this.grpMoveAbsolute.BackColor = System.Drawing.Color.Silver;
            this.grpMoveAbsolute.Controls.Add(this.cmbAxisMoveAbs);
            this.grpMoveAbsolute.Controls.Add(this.lblMoveAbsSelectAxis);
            this.grpMoveAbsolute.Controls.Add(this.btnStop);
            this.grpMoveAbsolute.Controls.Add(this.btnMove_X1);
            this.grpMoveAbsolute.Controls.Add(this.lblServoX_TargetSpeed);
            this.grpMoveAbsolute.Controls.Add(this.lblServoX_TargetPosition);
            this.grpMoveAbsolute.Controls.Add(this.txtetSpeedAbs);
            this.grpMoveAbsolute.Controls.Add(this.lblMoveAbsSpeed);
            this.grpMoveAbsolute.Controls.Add(this.txtPositionAbs);
            this.grpMoveAbsolute.Controls.Add(this.lblMoveAbsPos);
            this.grpMoveAbsolute.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpMoveAbsolute.Location = new System.Drawing.Point(316, 2);
            this.grpMoveAbsolute.Name = "grpMoveAbsolute";
            this.grpMoveAbsolute.Size = new System.Drawing.Size(301, 114);
            this.grpMoveAbsolute.TabIndex = 84;
            this.grpMoveAbsolute.TabStop = false;
            this.grpMoveAbsolute.Text = "Move Absolute";
            // 
            // lblMoveRelPos
            // 
            this.lblMoveRelPos.AutoSize = true;
            this.lblMoveRelPos.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMoveRelPos.Location = new System.Drawing.Point(6, 50);
            this.lblMoveRelPos.Name = "lblMoveRelPos";
            this.lblMoveRelPos.Size = new System.Drawing.Size(57, 14);
            this.lblMoveRelPos.TabIndex = 73;
            this.lblMoveRelPos.Text = "Position";
            // 
            // txt_Position_Relative
            // 
            this.txt_Position_Relative.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Position_Relative.Location = new System.Drawing.Point(87, 49);
            this.txt_Position_Relative.Name = "txt_Position_Relative";
            this.txt_Position_Relative.Size = new System.Drawing.Size(73, 26);
            this.txt_Position_Relative.TabIndex = 74;
            // 
            // lblMoveRelSpeed
            // 
            this.lblMoveRelSpeed.AutoSize = true;
            this.lblMoveRelSpeed.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMoveRelSpeed.Location = new System.Drawing.Point(6, 85);
            this.lblMoveRelSpeed.Name = "lblMoveRelSpeed";
            this.lblMoveRelSpeed.Size = new System.Drawing.Size(45, 14);
            this.lblMoveRelSpeed.TabIndex = 75;
            this.lblMoveRelSpeed.Text = "Speed";
            // 
            // txt_Speed_Relative
            // 
            this.txt_Speed_Relative.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Speed_Relative.Location = new System.Drawing.Point(87, 80);
            this.txt_Speed_Relative.Name = "txt_Speed_Relative";
            this.txt_Speed_Relative.Size = new System.Drawing.Size(73, 26);
            this.txt_Speed_Relative.TabIndex = 76;
            // 
            // lblPosition_Relative
            // 
            this.lblPosition_Relative.AutoSize = true;
            this.lblPosition_Relative.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPosition_Relative.Location = new System.Drawing.Point(164, 54);
            this.lblPosition_Relative.Name = "lblPosition_Relative";
            this.lblPosition_Relative.Size = new System.Drawing.Size(37, 14);
            this.lblPosition_Relative.TabIndex = 77;
            this.lblPosition_Relative.Text = "(mm)";
            // 
            // lblSpeed_Relative
            // 
            this.lblSpeed_Relative.AutoSize = true;
            this.lblSpeed_Relative.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSpeed_Relative.Location = new System.Drawing.Point(162, 89);
            this.lblSpeed_Relative.Name = "lblSpeed_Relative";
            this.lblSpeed_Relative.Size = new System.Drawing.Size(47, 14);
            this.lblSpeed_Relative.TabIndex = 78;
            this.lblSpeed_Relative.Text = "(mm/s)";
            // 
            // btnPTP_Positive
            // 
            this.btnPTP_Positive.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(94)))), ((int)(((byte)(133)))));
            this.btnPTP_Positive.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPTP_Positive.ForeColor = System.Drawing.Color.White;
            this.btnPTP_Positive.Location = new System.Drawing.Point(213, 18);
            this.btnPTP_Positive.Name = "btnPTP_Positive";
            this.btnPTP_Positive.Size = new System.Drawing.Size(83, 37);
            this.btnPTP_Positive.TabIndex = 79;
            this.btnPTP_Positive.Text = "PTP+";
            this.btnPTP_Positive.UseVisualStyleBackColor = false;
            this.btnPTP_Positive.Click += new System.EventHandler(this.btnPTP_Positive_Click);
            // 
            // btnPTP_Negative
            // 
            this.btnPTP_Negative.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(94)))), ((int)(((byte)(133)))));
            this.btnPTP_Negative.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPTP_Negative.ForeColor = System.Drawing.Color.White;
            this.btnPTP_Negative.Location = new System.Drawing.Point(212, 70);
            this.btnPTP_Negative.Name = "btnPTP_Negative";
            this.btnPTP_Negative.Size = new System.Drawing.Size(83, 37);
            this.btnPTP_Negative.TabIndex = 80;
            this.btnPTP_Negative.Text = "PTP-";
            this.btnPTP_Negative.UseVisualStyleBackColor = false;
            this.btnPTP_Negative.Click += new System.EventHandler(this.btnPTP_Negative_Click);
            // 
            // lblMoveRelSelectAxis
            // 
            this.lblMoveRelSelectAxis.AutoSize = true;
            this.lblMoveRelSelectAxis.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMoveRelSelectAxis.Location = new System.Drawing.Point(6, 19);
            this.lblMoveRelSelectAxis.Name = "lblMoveRelSelectAxis";
            this.lblMoveRelSelectAxis.Size = new System.Drawing.Size(73, 14);
            this.lblMoveRelSelectAxis.TabIndex = 81;
            this.lblMoveRelSelectAxis.Text = "Select Axis";
            // 
            // cmbAxisMoveRel
            // 
            this.cmbAxisMoveRel.FormattingEnabled = true;
            this.cmbAxisMoveRel.Items.AddRange(new object[] {
            "X",
            "Y",
            "Z"});
            this.cmbAxisMoveRel.Location = new System.Drawing.Point(87, 19);
            this.cmbAxisMoveRel.Name = "cmbAxisMoveRel";
            this.cmbAxisMoveRel.Size = new System.Drawing.Size(120, 24);
            this.cmbAxisMoveRel.TabIndex = 83;
            this.cmbAxisMoveRel.SelectedIndexChanged += new System.EventHandler(this.cmbAxisMoveRel_SelectedIndexChanged);
            this.cmbAxisMoveRel.Enter += new System.EventHandler(this.cmbAxisMoveRel_Enter);
            this.cmbAxisMoveRel.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbAxisMoveRel_KeyPress);
            this.cmbAxisMoveRel.Leave += new System.EventHandler(this.cmbAxisMoveRel_Leave);
            // 
            // grpMoveRelative
            // 
            this.grpMoveRelative.BackColor = System.Drawing.Color.Silver;
            this.grpMoveRelative.Controls.Add(this.cmbAxisMoveRel);
            this.grpMoveRelative.Controls.Add(this.lblMoveRelSelectAxis);
            this.grpMoveRelative.Controls.Add(this.btnPTP_Negative);
            this.grpMoveRelative.Controls.Add(this.btnPTP_Positive);
            this.grpMoveRelative.Controls.Add(this.lblSpeed_Relative);
            this.grpMoveRelative.Controls.Add(this.lblPosition_Relative);
            this.grpMoveRelative.Controls.Add(this.txt_Speed_Relative);
            this.grpMoveRelative.Controls.Add(this.lblMoveRelSpeed);
            this.grpMoveRelative.Controls.Add(this.txt_Position_Relative);
            this.grpMoveRelative.Controls.Add(this.lblMoveRelPos);
            this.grpMoveRelative.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpMoveRelative.Location = new System.Drawing.Point(1, 2);
            this.grpMoveRelative.Name = "grpMoveRelative";
            this.grpMoveRelative.Size = new System.Drawing.Size(301, 111);
            this.grpMoveRelative.TabIndex = 85;
            this.grpMoveRelative.TabStop = false;
            this.grpMoveRelative.Text = "Move Relative";
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
            this.groupBox7.Location = new System.Drawing.Point(5, 117);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(234, 87);
            this.groupBox7.TabIndex = 86;
            this.groupBox7.TabStop = false;
            // 
            // textBox62
            // 
            this.textBox62.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox62.Location = new System.Drawing.Point(138, 48);
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
            this.label316.Location = new System.Drawing.Point(23, 54);
            this.label316.Name = "label316";
            this.label316.Size = new System.Drawing.Size(73, 13);
            this.label316.TabIndex = 14;
            this.label316.Text = "Loadcell 2";
            // 
            // label313
            // 
            this.label313.AutoSize = true;
            this.label313.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label313.Location = new System.Drawing.Point(203, 53);
            this.label313.Name = "label313";
            this.label313.Size = new System.Drawing.Size(22, 16);
            this.label313.TabIndex = 18;
            this.label313.Text = "kg";
            // 
            // label315
            // 
            this.label315.AutoSize = true;
            this.label315.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label315.Location = new System.Drawing.Point(23, 20);
            this.label315.Name = "label315";
            this.label315.Size = new System.Drawing.Size(73, 13);
            this.label315.TabIndex = 13;
            this.label315.Text = "Loadcell 1";
            // 
            // label314
            // 
            this.label314.AutoSize = true;
            this.label314.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label314.Location = new System.Drawing.Point(203, 18);
            this.label314.Name = "label314";
            this.label314.Size = new System.Drawing.Size(22, 16);
            this.label314.TabIndex = 17;
            this.label314.Text = "kg";
            // 
            // textBox63
            // 
            this.textBox63.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox63.Location = new System.Drawing.Point(138, 15);
            this.textBox63.Name = "textBox63";
            this.textBox63.Size = new System.Drawing.Size(60, 21);
            this.textBox63.TabIndex = 15;
            this.textBox63.Text = "0000";
            this.textBox63.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // RecipieForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(975, 620);
            this.Controls.Add(this.RecipieTabPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "RecipieForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "RecipieForm";
            this.Load += new System.EventHandler(this.RecipieForm_Load);
            this.RecipieTabPanel.ResumeLayout(false);
            this.pnlMain.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.grpGantry.ResumeLayout(false);
            this.grpGantry.PerformLayout();
            this.grp_EditSave.ResumeLayout(false);
            this.grp_EditSave.PerformLayout();
            this.tabRecipe.ResumeLayout(false);
            this.PickGantry.ResumeLayout(false);
            this.PickGantry.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_PickGantry)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.Robot.ResumeLayout(false);
            this.Robot.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Robot)).EndInit();
            this.grpMoveAbsolute.ResumeLayout(false);
            this.grpMoveAbsolute.PerformLayout();
            this.grpMoveRelative.ResumeLayout(false);
            this.grpMoveRelative.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
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
        private TabControl tabRecipe;
        private TabPage PickGantry;
        private DataGridView dgv_PickGantry;
        private TabPage Robot;
        private Button btnSaveRobot;
        private DataGridView dgv_Robot;
        private Button btnSave;
        private GroupBox grpGantry;
        private Button btnZDec;
        private Button btnZAdd;
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
        private Label lblSelGantry;
        private ComboBox cmbSelGantry;
        private Timer timer1;
        private GroupBox grpMoveRelative;
        private ComboBox cmbAxisMoveRel;
        private Label lblMoveRelSelectAxis;
        private Button btnPTP_Negative;
        private Button btnPTP_Positive;
        private Label lblSpeed_Relative;
        private Label lblPosition_Relative;
        private TextBox txt_Speed_Relative;
        private Label lblMoveRelSpeed;
        private TextBox txt_Position_Relative;
        private Label lblMoveRelPos;
        private GroupBox grpMoveAbsolute;
        private ComboBox cmbAxisMoveAbs;
        private Label lblMoveAbsSelectAxis;
        private Button btnStop;
        private Button btnMove_X1;
        private Label lblServoX_TargetSpeed;
        private Label lblServoX_TargetPosition;
        private TextBox txtetSpeedAbs;
        private Label lblMoveAbsSpeed;
        private TextBox txtPositionAbs;
        private Label lblMoveAbsPos;
        private GroupBox groupBox7;
        private TextBox textBox62;
        private Label label316;
        private Label label313;
        private Label label315;
        private Label label314;
        private TextBox textBox63;
        // private Button Btn_SavePos;
    }
}