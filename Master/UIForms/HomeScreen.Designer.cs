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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HomeScreen));
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
            this.pnlMachineStatus = new System.Windows.Forms.Panel();
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
            this.tabLog = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.lstRunningLog = new System.Windows.Forms.ListBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.dgvAlarmlive = new System.Windows.Forms.DataGridView();
            this.Homing = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.imgMotionCardStatus = new System.Windows.Forms.Button();
            this.Motion_Card = new System.Windows.Forms.Label();
            this.imgScannerStatus = new System.Windows.Forms.Button();
            this.imgSFCStatus = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.panel7 = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.pnlMachineHealth.SuspendLayout();
            this.pnlMachineStatus.SuspendLayout();
            this.tabLog.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAlarmlive)).BeginInit();
            this.panel7.SuspendLayout();
            this.SuspendLayout();
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
            this.pnlMachineHealth.Location = new System.Drawing.Point(12, 12);
            this.pnlMachineHealth.Name = "pnlMachineHealth";
            this.pnlMachineHealth.Size = new System.Drawing.Size(580, 259);
            this.pnlMachineHealth.TabIndex = 41;
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.Blue;
            this.button3.FlatAppearance.BorderColor = System.Drawing.Color.Yellow;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Location = new System.Drawing.Point(12, 210);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(21, 23);
            this.button3.TabIndex = 89;
            this.button3.UseVisualStyleBackColor = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(164, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(224, 25);
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
            this.lblShift.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblShift.Location = new System.Drawing.Point(133, 51);
            this.lblShift.Name = "lblShift";
            this.lblShift.Size = new System.Drawing.Size(20, 18);
            this.lblShift.TabIndex = 90;
            this.lblShift.Text = "A";
            this.lblShift.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lblShift.TextChanged += new System.EventHandler(this.lblShift_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Gainsboro;
            this.label3.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(10, 51);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(112, 18);
            this.label3.TabIndex = 89;
            this.label3.Text = "Current Shift";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // button12
            // 
            this.button12.BackColor = System.Drawing.Color.Yellow;
            this.button12.FlatAppearance.BorderColor = System.Drawing.Color.Yellow;
            this.button12.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button12.Location = new System.Drawing.Point(12, 169);
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
            this.button13.Location = new System.Drawing.Point(12, 126);
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
            this.button14.Location = new System.Drawing.Point(12, 83);
            this.button14.Name = "button14";
            this.button14.Size = new System.Drawing.Size(21, 23);
            this.button14.TabIndex = 85;
            this.button14.UseVisualStyleBackColor = false;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.BackColor = System.Drawing.Color.Transparent;
            this.label14.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(220, 213);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(26, 18);
            this.label14.TabIndex = 42;
            this.label14.Text = "Hr";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.BackColor = System.Drawing.Color.Transparent;
            this.label17.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(220, 175);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(26, 18);
            this.label17.TabIndex = 41;
            this.label17.Text = "Hr";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.BackColor = System.Drawing.Color.Transparent;
            this.label20.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.Location = new System.Drawing.Point(220, 130);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(26, 18);
            this.label20.TabIndex = 39;
            this.label20.Text = "Hr";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.BackColor = System.Drawing.Color.Transparent;
            this.label21.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.Location = new System.Drawing.Point(220, 84);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(26, 18);
            this.label21.TabIndex = 38;
            this.label21.Text = "Hr";
            // 
            // lblTotaltime
            // 
            this.lblTotaltime.BackColor = System.Drawing.Color.Transparent;
            this.lblTotaltime.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotaltime.Location = new System.Drawing.Point(175, 213);
            this.lblTotaltime.Name = "lblTotaltime";
            this.lblTotaltime.Size = new System.Drawing.Size(40, 18);
            this.lblTotaltime.TabIndex = 37;
            this.lblTotaltime.Text = "0";
            // 
            // lblIdletime
            // 
            this.lblIdletime.BackColor = System.Drawing.Color.Transparent;
            this.lblIdletime.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIdletime.Location = new System.Drawing.Point(175, 175);
            this.lblIdletime.Name = "lblIdletime";
            this.lblIdletime.Size = new System.Drawing.Size(40, 18);
            this.lblIdletime.TabIndex = 36;
            this.lblIdletime.Text = "0";
            // 
            // lblDowntime
            // 
            this.lblDowntime.BackColor = System.Drawing.Color.Transparent;
            this.lblDowntime.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDowntime.Location = new System.Drawing.Point(175, 130);
            this.lblDowntime.Name = "lblDowntime";
            this.lblDowntime.Size = new System.Drawing.Size(40, 18);
            this.lblDowntime.TabIndex = 34;
            this.lblDowntime.Text = "0";
            // 
            // lblRunTime
            // 
            this.lblRunTime.BackColor = System.Drawing.Color.Transparent;
            this.lblRunTime.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRunTime.Location = new System.Drawing.Point(175, 84);
            this.lblRunTime.Name = "lblRunTime";
            this.lblRunTime.Size = new System.Drawing.Size(40, 18);
            this.lblRunTime.TabIndex = 33;
            this.lblRunTime.Text = "0";
            // 
            // label26
            // 
            this.label26.BackColor = System.Drawing.Color.Transparent;
            this.label26.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label26.Location = new System.Drawing.Point(38, 213);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(125, 20);
            this.label26.TabIndex = 32;
            this.label26.Text = "Total Time   :";
            this.label26.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label27
            // 
            this.label27.BackColor = System.Drawing.Color.Transparent;
            this.label27.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label27.Location = new System.Drawing.Point(38, 175);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(118, 16);
            this.label27.TabIndex = 31;
            this.label27.Text = "Idle Time    :";
            this.label27.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label28
            // 
            this.label28.BackColor = System.Drawing.Color.Transparent;
            this.label28.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label28.Location = new System.Drawing.Point(38, 130);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(119, 18);
            this.label28.TabIndex = 29;
            this.label28.Text = "Down Time  :";
            this.label28.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label29
            // 
            this.label29.BackColor = System.Drawing.Color.Transparent;
            this.label29.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label29.Location = new System.Drawing.Point(38, 86);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(117, 20);
            this.label29.TabIndex = 28;
            this.label29.Text = "Run Time    :";
            this.label29.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlMachineStatus
            // 
            this.pnlMachineStatus.BackColor = System.Drawing.Color.White;
            this.pnlMachineStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
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
            this.pnlMachineStatus.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.pnlMachineStatus.Location = new System.Drawing.Point(615, 13);
            this.pnlMachineStatus.Name = "pnlMachineStatus";
            this.pnlMachineStatus.Size = new System.Drawing.Size(397, 259);
            this.pnlMachineStatus.TabIndex = 42;
            // 
            // textBox7
            // 
            this.textBox7.BackColor = System.Drawing.Color.White;
            this.textBox7.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox7.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox7.Location = new System.Drawing.Point(183, 210);
            this.textBox7.Name = "textBox7";
            this.textBox7.ReadOnly = true;
            this.textBox7.Size = new System.Drawing.Size(26, 20);
            this.textBox7.TabIndex = 105;
            this.textBox7.Text = " :";
            // 
            // textBox6
            // 
            this.textBox6.BackColor = System.Drawing.Color.White;
            this.textBox6.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox6.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox6.Location = new System.Drawing.Point(184, 174);
            this.textBox6.Name = "textBox6";
            this.textBox6.ReadOnly = true;
            this.textBox6.Size = new System.Drawing.Size(26, 20);
            this.textBox6.TabIndex = 104;
            this.textBox6.Text = " :";
            // 
            // textBox5
            // 
            this.textBox5.BackColor = System.Drawing.Color.White;
            this.textBox5.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox5.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox5.Location = new System.Drawing.Point(184, 142);
            this.textBox5.Name = "textBox5";
            this.textBox5.ReadOnly = true;
            this.textBox5.Size = new System.Drawing.Size(26, 20);
            this.textBox5.TabIndex = 103;
            this.textBox5.Text = " :";
            // 
            // textBox4
            // 
            this.textBox4.BackColor = System.Drawing.Color.White;
            this.textBox4.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox4.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox4.Location = new System.Drawing.Point(183, 109);
            this.textBox4.Name = "textBox4";
            this.textBox4.ReadOnly = true;
            this.textBox4.Size = new System.Drawing.Size(26, 20);
            this.textBox4.TabIndex = 102;
            this.textBox4.Text = " :";
            // 
            // textBox3
            // 
            this.textBox3.BackColor = System.Drawing.Color.White;
            this.textBox3.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox3.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox3.Location = new System.Drawing.Point(183, 77);
            this.textBox3.Name = "textBox3";
            this.textBox3.ReadOnly = true;
            this.textBox3.Size = new System.Drawing.Size(26, 20);
            this.textBox3.TabIndex = 101;
            this.textBox3.Text = " :";
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.Color.White;
            this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox2.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox2.Location = new System.Drawing.Point(183, 48);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(26, 20);
            this.textBox2.TabIndex = 100;
            this.textBox2.Text = " :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(96, 6);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(222, 25);
            this.label4.TabIndex = 99;
            this.label4.Text = "MACHINE STATUS";
            // 
            // txtUph
            // 
            this.txtUph.BackColor = System.Drawing.Color.White;
            this.txtUph.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtUph.Enabled = false;
            this.txtUph.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUph.Location = new System.Drawing.Point(227, 213);
            this.txtUph.Name = "txtUph";
            this.txtUph.ReadOnly = true;
            this.txtUph.Size = new System.Drawing.Size(117, 20);
            this.txtUph.TabIndex = 98;
            this.txtUph.Text = "0";
            this.txtUph.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtCycletime
            // 
            this.txtCycletime.BackColor = System.Drawing.Color.White;
            this.txtCycletime.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtCycletime.Enabled = false;
            this.txtCycletime.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCycletime.Location = new System.Drawing.Point(227, 176);
            this.txtCycletime.Name = "txtCycletime";
            this.txtCycletime.ReadOnly = true;
            this.txtCycletime.Size = new System.Drawing.Size(117, 20);
            this.txtCycletime.TabIndex = 98;
            this.txtCycletime.Text = "0";
            this.txtCycletime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox17
            // 
            this.textBox17.BackColor = System.Drawing.Color.White;
            this.textBox17.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox17.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox17.Location = new System.Drawing.Point(30, 212);
            this.textBox17.Name = "textBox17";
            this.textBox17.ReadOnly = true;
            this.textBox17.Size = new System.Drawing.Size(137, 20);
            this.textBox17.TabIndex = 97;
            this.textBox17.Text = "UPH               ";
            // 
            // textBox16
            // 
            this.textBox16.BackColor = System.Drawing.Color.White;
            this.textBox16.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox16.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox16.Location = new System.Drawing.Point(30, 175);
            this.textBox16.Name = "textBox16";
            this.textBox16.ReadOnly = true;
            this.textBox16.Size = new System.Drawing.Size(137, 20);
            this.textBox16.TabIndex = 97;
            this.textBox16.Text = "Cycle Time      ";
            // 
            // txtyYeldcnt
            // 
            this.txtyYeldcnt.BackColor = System.Drawing.Color.White;
            this.txtyYeldcnt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtyYeldcnt.Enabled = false;
            this.txtyYeldcnt.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtyYeldcnt.Location = new System.Drawing.Point(227, 110);
            this.txtyYeldcnt.Name = "txtyYeldcnt";
            this.txtyYeldcnt.ReadOnly = true;
            this.txtyYeldcnt.Size = new System.Drawing.Size(117, 20);
            this.txtyYeldcnt.TabIndex = 96;
            this.txtyYeldcnt.Text = "0";
            this.txtyYeldcnt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtOverallcnt
            // 
            this.txtOverallcnt.BackColor = System.Drawing.Color.White;
            this.txtOverallcnt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtOverallcnt.Enabled = false;
            this.txtOverallcnt.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOverallcnt.Location = new System.Drawing.Point(227, 143);
            this.txtOverallcnt.Name = "txtOverallcnt";
            this.txtOverallcnt.ReadOnly = true;
            this.txtOverallcnt.Size = new System.Drawing.Size(117, 20);
            this.txtOverallcnt.TabIndex = 95;
            this.txtOverallcnt.Text = "0";
            this.txtOverallcnt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtFailcnt
            // 
            this.txtFailcnt.BackColor = System.Drawing.Color.White;
            this.txtFailcnt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtFailcnt.Enabled = false;
            this.txtFailcnt.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFailcnt.Location = new System.Drawing.Point(227, 78);
            this.txtFailcnt.Name = "txtFailcnt";
            this.txtFailcnt.ReadOnly = true;
            this.txtFailcnt.Size = new System.Drawing.Size(117, 20);
            this.txtFailcnt.TabIndex = 94;
            this.txtFailcnt.Text = "0";
            this.txtFailcnt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtPasscnt
            // 
            this.txtPasscnt.BackColor = System.Drawing.Color.White;
            this.txtPasscnt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtPasscnt.Enabled = false;
            this.txtPasscnt.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold);
            this.txtPasscnt.Location = new System.Drawing.Point(227, 50);
            this.txtPasscnt.Name = "txtPasscnt";
            this.txtPasscnt.ReadOnly = true;
            this.txtPasscnt.Size = new System.Drawing.Size(117, 20);
            this.txtPasscnt.TabIndex = 36;
            this.txtPasscnt.Text = "0";
            this.txtPasscnt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox13
            // 
            this.textBox13.BackColor = System.Drawing.Color.White;
            this.textBox13.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox13.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox13.Location = new System.Drawing.Point(30, 109);
            this.textBox13.Name = "textBox13";
            this.textBox13.ReadOnly = true;
            this.textBox13.Size = new System.Drawing.Size(137, 20);
            this.textBox13.TabIndex = 35;
            this.textBox13.Text = "Yield              ";
            // 
            // textBox12
            // 
            this.textBox12.BackColor = System.Drawing.Color.White;
            this.textBox12.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox12.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox12.Location = new System.Drawing.Point(30, 142);
            this.textBox12.Name = "textBox12";
            this.textBox12.ReadOnly = true;
            this.textBox12.Size = new System.Drawing.Size(149, 20);
            this.textBox12.TabIndex = 35;
            this.textBox12.Text = "Overall Count  ";
            // 
            // textBox11
            // 
            this.textBox11.BackColor = System.Drawing.Color.White;
            this.textBox11.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox11.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox11.Location = new System.Drawing.Point(30, 77);
            this.textBox11.Name = "textBox11";
            this.textBox11.ReadOnly = true;
            this.textBox11.Size = new System.Drawing.Size(129, 20);
            this.textBox11.TabIndex = 35;
            this.textBox11.Text = "Fail Count       ";
            // 
            // textBox8
            // 
            this.textBox8.BackColor = System.Drawing.Color.White;
            this.textBox8.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox8.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox8.Location = new System.Drawing.Point(30, 49);
            this.textBox8.Name = "textBox8";
            this.textBox8.ReadOnly = true;
            this.textBox8.Size = new System.Drawing.Size(129, 20);
            this.textBox8.TabIndex = 35;
            this.textBox8.Text = "Pass Count     ";
            // 
            // tabLog
            // 
            this.tabLog.Controls.Add(this.tabPage1);
            this.tabLog.Controls.Add(this.tabPage2);
            this.tabLog.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabLog.Location = new System.Drawing.Point(12, 273);
            this.tabLog.Name = "tabLog";
            this.tabLog.SelectedIndex = 0;
            this.tabLog.Size = new System.Drawing.Size(584, 307);
            this.tabLog.TabIndex = 43;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.lstRunningLog);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(576, 278);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Running Log";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // lstRunningLog
            // 
            this.lstRunningLog.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstRunningLog.FormattingEnabled = true;
            this.lstRunningLog.ItemHeight = 16;
            this.lstRunningLog.Location = new System.Drawing.Point(2, 1);
            this.lstRunningLog.Name = "lstRunningLog";
            this.lstRunningLog.Size = new System.Drawing.Size(572, 276);
            this.lstRunningLog.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.dgvAlarmlive);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(576, 278);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Alarm";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // dgvAlarmlive
            // 
            this.dgvAlarmlive.AllowUserToAddRows = false;
            this.dgvAlarmlive.BackgroundColor = System.Drawing.Color.Red;
            this.dgvAlarmlive.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAlarmlive.Location = new System.Drawing.Point(2, 3);
            this.dgvAlarmlive.Name = "dgvAlarmlive";
            this.dgvAlarmlive.ReadOnly = true;
            this.dgvAlarmlive.RowHeadersWidth = 51;
            this.dgvAlarmlive.Size = new System.Drawing.Size(572, 272);
            this.dgvAlarmlive.TabIndex = 51;
            // 
            // Homing
            // 
            this.Homing.BackColor = System.Drawing.Color.Yellow;
            this.Homing.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Homing.Location = new System.Drawing.Point(651, 575);
            this.Homing.Name = "Homing";
            this.Homing.Size = new System.Drawing.Size(165, 43);
            this.Homing.TabIndex = 93;
            this.Homing.Text = "System Reset / Homing";
            this.Homing.UseVisualStyleBackColor = false;
            this.Homing.Click += new System.EventHandler(this.Homing_Click);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // imgMotionCardStatus
            // 
            this.imgMotionCardStatus.BackColor = System.Drawing.Color.Transparent;
            this.imgMotionCardStatus.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("imgMotionCardStatus.BackgroundImage")));
            this.imgMotionCardStatus.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.imgMotionCardStatus.Enabled = false;
            this.imgMotionCardStatus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.imgMotionCardStatus.ForeColor = System.Drawing.Color.Transparent;
            this.imgMotionCardStatus.Location = new System.Drawing.Point(358, 580);
            this.imgMotionCardStatus.Margin = new System.Windows.Forms.Padding(2);
            this.imgMotionCardStatus.Name = "imgMotionCardStatus";
            this.imgMotionCardStatus.Size = new System.Drawing.Size(37, 34);
            this.imgMotionCardStatus.TabIndex = 133;
            this.imgMotionCardStatus.UseVisualStyleBackColor = false;
            // 
            // Motion_Card
            // 
            this.Motion_Card.AutoSize = true;
            this.Motion_Card.BackColor = System.Drawing.Color.Transparent;
            this.Motion_Card.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Motion_Card.Location = new System.Drawing.Point(254, 588);
            this.Motion_Card.Name = "Motion_Card";
            this.Motion_Card.Size = new System.Drawing.Size(99, 14);
            this.Motion_Card.TabIndex = 132;
            this.Motion_Card.Text = "Motion Card : ";
            // 
            // imgScannerStatus
            // 
            this.imgScannerStatus.BackColor = System.Drawing.Color.Transparent;
            this.imgScannerStatus.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("imgScannerStatus.BackgroundImage")));
            this.imgScannerStatus.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.imgScannerStatus.Enabled = false;
            this.imgScannerStatus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.imgScannerStatus.ForeColor = System.Drawing.Color.Transparent;
            this.imgScannerStatus.Location = new System.Drawing.Point(202, 581);
            this.imgScannerStatus.Margin = new System.Windows.Forms.Padding(2);
            this.imgScannerStatus.Name = "imgScannerStatus";
            this.imgScannerStatus.Size = new System.Drawing.Size(37, 34);
            this.imgScannerStatus.TabIndex = 131;
            this.imgScannerStatus.UseVisualStyleBackColor = false;
            // 
            // imgSFCStatus
            // 
            this.imgSFCStatus.BackColor = System.Drawing.Color.Transparent;
            this.imgSFCStatus.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("imgSFCStatus.BackgroundImage")));
            this.imgSFCStatus.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.imgSFCStatus.Enabled = false;
            this.imgSFCStatus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.imgSFCStatus.ForeColor = System.Drawing.Color.Transparent;
            this.imgSFCStatus.Location = new System.Drawing.Point(74, 580);
            this.imgSFCStatus.Margin = new System.Windows.Forms.Padding(2);
            this.imgSFCStatus.Name = "imgSFCStatus";
            this.imgSFCStatus.Size = new System.Drawing.Size(37, 34);
            this.imgSFCStatus.TabIndex = 130;
            this.imgSFCStatus.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(123, 588);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 14);
            this.label1.TabIndex = 129;
            this.label1.Text = "Scanner : ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(23, 588);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(46, 14);
            this.label5.TabIndex = 128;
            this.label5.Text = "SFC : ";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Transparent;
            this.button1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button1.BackgroundImage")));
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button1.Enabled = false;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.ForeColor = System.Drawing.Color.Transparent;
            this.button1.Location = new System.Drawing.Point(465, 580);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(37, 34);
            this.button1.TabIndex = 135;
            this.button1.UseVisualStyleBackColor = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(412, 588);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(48, 14);
            this.label6.TabIndex = 134;
            this.label6.Text = "CCD : ";
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Transparent;
            this.button2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button2.BackgroundImage")));
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button2.Enabled = false;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.ForeColor = System.Drawing.Color.Transparent;
            this.button2.Location = new System.Drawing.Point(577, 582);
            this.button2.Margin = new System.Windows.Forms.Padding(2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(37, 34);
            this.button2.TabIndex = 137;
            this.button2.UseVisualStyleBackColor = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(514, 589);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(58, 14);
            this.label7.TabIndex = 136;
            this.label7.Text = "Robot : ";
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.Color.Gainsboro;
            this.panel7.Controls.Add(this.label8);
            this.panel7.Location = new System.Drawing.Point(615, 299);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(397, 272);
            this.panel7.TabIndex = 138;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(121, 11);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(157, 18);
            this.label8.TabIndex = 338;
            this.label8.Text = "Tray Cavity Status";
            // 
            // HomeScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1024, 620);
            this.Controls.Add(this.panel7);
            this.Controls.Add(this.Homing);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.imgMotionCardStatus);
            this.Controls.Add(this.Motion_Card);
            this.Controls.Add(this.imgScannerStatus);
            this.Controls.Add(this.imgSFCStatus);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tabLog);
            this.Controls.Add(this.pnlMachineStatus);
            this.Controls.Add(this.pnlMachineHealth);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "HomeScreen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "HomeScreen";
            this.Load += new System.EventHandler(this.HomeScreen_Load);
            this.pnlMachineHealth.ResumeLayout(false);
            this.pnlMachineHealth.PerformLayout();
            this.pnlMachineStatus.ResumeLayout(false);
            this.pnlMachineStatus.PerformLayout();
            this.tabLog.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAlarmlive)).EndInit();
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Panel pnlMachineHealth;
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
        private TabControl tabLog;
        private TabPage tabPage1;
        private ListBox lstRunningLog;
        private TabPage tabPage2;
        private DataGridView dgvAlarmlive;
        private Button Homing;
        private Timer timer1;
        private Button imgMotionCardStatus;
        private Label Motion_Card;
        private Button imgScannerStatus;
        private Button imgSFCStatus;
        private Label label1;
        private Label label5;
        private Button button1;
        private Label label6;
        private Button button2;
        private Label label7;
        private TextBox textBox7;
        private TextBox textBox6;
        private TextBox textBox5;
        private TextBox textBox4;
        private TextBox textBox3;
        private TextBox textBox2;
        private Panel panel7;
        private Label label8;
        private Button button3;
    }
}