using System.Drawing;
using System.Windows.Forms;

namespace UI.UI_Forms
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.panel5 = new System.Windows.Forms.Panel();
            this.TimerLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_minimise = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_reset_alarm = new System.Windows.Forms.Button();
            this.btn_open_file = new System.Windows.Forms.Button();
            this.btn_database = new System.Windows.Forms.Button();
            this.btn_home = new System.Windows.Forms.Button();
            this.btn_user_login = new System.Windows.Forms.Button();
            this.btn_alarm = new System.Windows.Forms.Button();
            this.btn_stop_auto_seq = new System.Windows.Forms.Button();
            this.btn_manual = new System.Windows.Forms.Button();
            this.btn_pause_auto_seq = new System.Windows.Forms.Button();
            this.btn_statistics = new System.Windows.Forms.Button();
            this.btn_start_auto_seq = new System.Windows.Forms.Button();
            this.btn_settings = new System.Windows.Forms.Button();
            this.panelContents = new System.Windows.Forms.Panel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.Black;
            this.panel5.Controls.Add(this.label2);
            this.panel5.Controls.Add(this.TimerLabel);
            this.panel5.Controls.Add(this.label1);
            this.panel5.Controls.Add(this.btn_minimise);
            this.panel5.Controls.Add(this.btnClose);
            this.panel5.Controls.Add(this.pictureBox1);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(975, 40);
            this.panel5.TabIndex = 56;
            // 
            // TimerLabel
            // 
            this.TimerLabel.AutoSize = true;
            this.TimerLabel.BackColor = System.Drawing.Color.Black;
            this.TimerLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TimerLabel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.TimerLabel.Location = new System.Drawing.Point(734, 12);
            this.TimerLabel.Name = "TimerLabel";
            this.TimerLabel.Size = new System.Drawing.Size(195, 20);
            this.TimerLabel.TabIndex = 50;
            this.TimerLabel.Text = "DD:MM:YY  HH:MM:SS";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label1.Location = new System.Drawing.Point(419, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(141, 35);
            this.label1.TabIndex = 49;
            this.label1.Text = "GRT-G1";
            // 
            // btn_minimise
            // 
            this.btn_minimise.BackColor = System.Drawing.Color.White;
            this.btn_minimise.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_minimise.Location = new System.Drawing.Point(935, 3);
            this.btn_minimise.Name = "btn_minimise";
            this.btn_minimise.Size = new System.Drawing.Size(41, 34);
            this.btn_minimise.TabIndex = 48;
            this.btn_minimise.Text = "_";
            this.toolTip1.SetToolTip(this.btn_minimise, "Minimize");
            this.btn_minimise.UseVisualStyleBackColor = false;
            this.btn_minimise.Click += new System.EventHandler(this.btn_minimise_Click);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.Red;
            this.btnClose.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(978, 3);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(41, 34);
            this.btnClose.TabIndex = 46;
            this.btnClose.Text = "X";
            this.toolTip1.SetToolTip(this.btnClose, "Close\r\n");
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, -3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(163, 49);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 45;
            this.pictureBox1.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.btn_reset_alarm);
            this.panel1.Controls.Add(this.btn_open_file);
            this.panel1.Controls.Add(this.btn_database);
            this.panel1.Controls.Add(this.btn_home);
            this.panel1.Controls.Add(this.btn_user_login);
            this.panel1.Controls.Add(this.btn_alarm);
            this.panel1.Controls.Add(this.btn_stop_auto_seq);
            this.panel1.Controls.Add(this.btn_manual);
            this.panel1.Controls.Add(this.btn_pause_auto_seq);
            this.panel1.Controls.Add(this.btn_statistics);
            this.panel1.Controls.Add(this.btn_start_auto_seq);
            this.panel1.Controls.Add(this.btn_settings);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 40);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(975, 104);
            this.panel1.TabIndex = 57;
            // 
            // btn_reset_alarm
            // 
            this.btn_reset_alarm.BackColor = System.Drawing.Color.Transparent;
            this.btn_reset_alarm.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_reset_alarm.BackgroundImage")));
            this.btn_reset_alarm.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_reset_alarm.ForeColor = System.Drawing.Color.Transparent;
            this.btn_reset_alarm.Location = new System.Drawing.Point(638, 16);
            this.btn_reset_alarm.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_reset_alarm.Name = "btn_reset_alarm";
            this.btn_reset_alarm.Size = new System.Drawing.Size(70, 70);
            this.btn_reset_alarm.TabIndex = 11;
            this.toolTip1.SetToolTip(this.btn_reset_alarm, "Reset Alarm");
            this.btn_reset_alarm.UseVisualStyleBackColor = false;
            this.btn_reset_alarm.Click += new System.EventHandler(this.btn_reset_alarm_Click);
            // 
            // btn_open_file
            // 
            this.btn_open_file.BackColor = System.Drawing.Color.Transparent;
            this.btn_open_file.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_open_file.BackgroundImage")));
            this.btn_open_file.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_open_file.ForeColor = System.Drawing.Color.Transparent;
            this.btn_open_file.Location = new System.Drawing.Point(469, 16);
            this.btn_open_file.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_open_file.Name = "btn_open_file";
            this.btn_open_file.Size = new System.Drawing.Size(70, 70);
            this.btn_open_file.TabIndex = 10;
            this.toolTip1.SetToolTip(this.btn_open_file, "Log Folder");
            this.btn_open_file.UseVisualStyleBackColor = false;
            this.btn_open_file.Click += new System.EventHandler(this.btn_open_file_Click);
            // 
            // btn_database
            // 
            this.btn_database.BackColor = System.Drawing.Color.Transparent;
            this.btn_database.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_database.BackgroundImage")));
            this.btn_database.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_database.ForeColor = System.Drawing.Color.Transparent;
            this.btn_database.Location = new System.Drawing.Point(393, 16);
            this.btn_database.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_database.Name = "btn_database";
            this.btn_database.Size = new System.Drawing.Size(70, 70);
            this.btn_database.TabIndex = 9;
            this.toolTip1.SetToolTip(this.btn_database, "Recipie");
            this.btn_database.UseVisualStyleBackColor = false;
            this.btn_database.Click += new System.EventHandler(this.btn_database_Click);
            // 
            // btn_home
            // 
            this.btn_home.BackColor = System.Drawing.Color.Transparent;
            this.btn_home.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_home.BackgroundImage")));
            this.btn_home.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_home.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btn_home.ForeColor = System.Drawing.Color.Transparent;
            this.btn_home.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btn_home.Location = new System.Drawing.Point(15, 16);
            this.btn_home.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_home.Name = "btn_home";
            this.btn_home.Size = new System.Drawing.Size(70, 70);
            this.btn_home.TabIndex = 0;
            this.toolTip1.SetToolTip(this.btn_home, "Home");
            this.btn_home.UseVisualStyleBackColor = false;
            this.btn_home.Click += new System.EventHandler(this.btn_home_Click);
            // 
            // btn_user_login
            // 
            this.btn_user_login.BackColor = System.Drawing.Color.Transparent;
            this.btn_user_login.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_user_login.BackgroundImage")));
            this.btn_user_login.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_user_login.ForeColor = System.Drawing.Color.Transparent;
            this.btn_user_login.Location = new System.Drawing.Point(943, 16);
            this.btn_user_login.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_user_login.Name = "btn_user_login";
            this.btn_user_login.Size = new System.Drawing.Size(70, 70);
            this.btn_user_login.TabIndex = 8;
            this.btn_user_login.Text = "User";
            this.btn_user_login.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.toolTip1.SetToolTip(this.btn_user_login, "User");
            this.btn_user_login.UseVisualStyleBackColor = false;
            this.btn_user_login.Click += new System.EventHandler(this.btn_user_login_Click);
            // 
            // btn_alarm
            // 
            this.btn_alarm.BackColor = System.Drawing.Color.Transparent;
            this.btn_alarm.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_alarm.BackgroundImage")));
            this.btn_alarm.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_alarm.ForeColor = System.Drawing.Color.Transparent;
            this.btn_alarm.Location = new System.Drawing.Point(90, 16);
            this.btn_alarm.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_alarm.Name = "btn_alarm";
            this.btn_alarm.Size = new System.Drawing.Size(70, 70);
            this.btn_alarm.TabIndex = 1;
            this.toolTip1.SetToolTip(this.btn_alarm, "Alarm Report");
            this.btn_alarm.UseVisualStyleBackColor = false;
            this.btn_alarm.Click += new System.EventHandler(this.btn_alarm_Click);
            // 
            // btn_stop_auto_seq
            // 
            this.btn_stop_auto_seq.BackColor = System.Drawing.Color.Transparent;
            this.btn_stop_auto_seq.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_stop_auto_seq.BackgroundImage")));
            this.btn_stop_auto_seq.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_stop_auto_seq.ForeColor = System.Drawing.Color.Transparent;
            this.btn_stop_auto_seq.Location = new System.Drawing.Point(867, 16);
            this.btn_stop_auto_seq.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_stop_auto_seq.Name = "btn_stop_auto_seq";
            this.btn_stop_auto_seq.Size = new System.Drawing.Size(70, 70);
            this.btn_stop_auto_seq.TabIndex = 7;
            this.toolTip1.SetToolTip(this.btn_stop_auto_seq, "Stop");
            this.btn_stop_auto_seq.UseVisualStyleBackColor = false;
            this.btn_stop_auto_seq.Click += new System.EventHandler(this.btn_stop_auto_seq_Click);
            // 
            // btn_manual
            // 
            this.btn_manual.BackColor = System.Drawing.Color.Transparent;
            this.btn_manual.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_manual.BackgroundImage")));
            this.btn_manual.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_manual.ForeColor = System.Drawing.Color.Transparent;
            this.btn_manual.Location = new System.Drawing.Point(165, 16);
            this.btn_manual.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_manual.Name = "btn_manual";
            this.btn_manual.Size = new System.Drawing.Size(70, 70);
            this.btn_manual.TabIndex = 2;
            this.toolTip1.SetToolTip(this.btn_manual, "Manual Screen");
            this.btn_manual.UseVisualStyleBackColor = false;
            this.btn_manual.Click += new System.EventHandler(this.btn_manual_Click);
            // 
            // btn_pause_auto_seq
            // 
            this.btn_pause_auto_seq.BackColor = System.Drawing.Color.Transparent;
            this.btn_pause_auto_seq.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_pause_auto_seq.BackgroundImage")));
            this.btn_pause_auto_seq.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_pause_auto_seq.ForeColor = System.Drawing.Color.Transparent;
            this.btn_pause_auto_seq.Location = new System.Drawing.Point(792, 16);
            this.btn_pause_auto_seq.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_pause_auto_seq.Name = "btn_pause_auto_seq";
            this.btn_pause_auto_seq.Size = new System.Drawing.Size(70, 70);
            this.btn_pause_auto_seq.TabIndex = 6;
            this.toolTip1.SetToolTip(this.btn_pause_auto_seq, "Pause");
            this.btn_pause_auto_seq.UseVisualStyleBackColor = false;
            this.btn_pause_auto_seq.Click += new System.EventHandler(this.btn_pause_auto_seq_Click);
            // 
            // btn_statistics
            // 
            this.btn_statistics.BackColor = System.Drawing.Color.Transparent;
            this.btn_statistics.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_statistics.BackgroundImage")));
            this.btn_statistics.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_statistics.ForeColor = System.Drawing.Color.Transparent;
            this.btn_statistics.Location = new System.Drawing.Point(241, 16);
            this.btn_statistics.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_statistics.Name = "btn_statistics";
            this.btn_statistics.Size = new System.Drawing.Size(70, 70);
            this.btn_statistics.TabIndex = 3;
            this.toolTip1.SetToolTip(this.btn_statistics, "Production Report");
            this.btn_statistics.UseVisualStyleBackColor = false;
            this.btn_statistics.Click += new System.EventHandler(this.btn_statistics_Click);
            // 
            // btn_start_auto_seq
            // 
            this.btn_start_auto_seq.BackColor = System.Drawing.Color.Transparent;
            this.btn_start_auto_seq.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_start_auto_seq.BackgroundImage")));
            this.btn_start_auto_seq.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_start_auto_seq.ForeColor = System.Drawing.Color.Transparent;
            this.btn_start_auto_seq.Location = new System.Drawing.Point(716, 16);
            this.btn_start_auto_seq.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_start_auto_seq.Name = "btn_start_auto_seq";
            this.btn_start_auto_seq.Size = new System.Drawing.Size(70, 70);
            this.btn_start_auto_seq.TabIndex = 5;
            this.toolTip1.SetToolTip(this.btn_start_auto_seq, "Start");
            this.btn_start_auto_seq.UseVisualStyleBackColor = false;
            this.btn_start_auto_seq.Click += new System.EventHandler(this.btn_start_auto_seq_Click);
            // 
            // btn_settings
            // 
            this.btn_settings.BackColor = System.Drawing.Color.Transparent;
            this.btn_settings.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_settings.BackgroundImage")));
            this.btn_settings.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_settings.ForeColor = System.Drawing.Color.Transparent;
            this.btn_settings.Location = new System.Drawing.Point(317, 16);
            this.btn_settings.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_settings.Name = "btn_settings";
            this.btn_settings.Size = new System.Drawing.Size(70, 70);
            this.btn_settings.TabIndex = 4;
            this.toolTip1.SetToolTip(this.btn_settings, "Settings");
            this.btn_settings.UseVisualStyleBackColor = false;
            this.btn_settings.Click += new System.EventHandler(this.btn_settings_Click);
            // 
            // panelContents
            // 
            this.panelContents.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.panelContents.Location = new System.Drawing.Point(0, 144);
            this.panelContents.Name = "panelContents";
            this.panelContents.Size = new System.Drawing.Size(1024, 624);
            this.panelContents.TabIndex = 59;
            this.panelContents.Visible = false;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label2.Location = new System.Drawing.Point(554, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(130, 35);
            this.label2.TabIndex = 51;
            this.label2.Text = "V 1.0.0";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(975, 666);
            this.Controls.Add(this.panelContents);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel5);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btn_open_file;
        private System.Windows.Forms.Button btn_database;
        private System.Windows.Forms.Button btn_home;
        private System.Windows.Forms.Button btn_user_login;
        private System.Windows.Forms.Button btn_alarm;
        public System.Windows.Forms.Button btn_stop_auto_seq;
        private System.Windows.Forms.Button btn_manual;
        public System.Windows.Forms.Button btn_pause_auto_seq;
        private System.Windows.Forms.Button btn_statistics;
        public System.Windows.Forms.Button btn_start_auto_seq;
        private System.Windows.Forms.Button btn_settings;
        private System.Windows.Forms.Button btn_minimise;
        private Panel panelContents;
        private Label label1;
        private Label TimerLabel;
        private Timer timer1;
        private ToolTip toolTip1;
        private Button btn_reset_alarm;
        private Label label2;
    }
}