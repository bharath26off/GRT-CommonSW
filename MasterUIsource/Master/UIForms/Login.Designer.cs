using System.Drawing;
using System.Windows.Forms;

namespace UI_Forms
{
    partial class Login
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.cmbmodes = new System.Windows.Forms.ComboBox();
            this.txtusername = new System.Windows.Forms.TextBox();
            this.txtpass = new System.Windows.Forms.TextBox();
            this.btnlogin = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.CancelButton = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbmodes
            // 
            this.cmbmodes.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cmbmodes.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbmodes.BackColor = System.Drawing.Color.White;
            this.cmbmodes.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbmodes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbmodes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbmodes.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbmodes.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.cmbmodes.FormattingEnabled = true;
            this.cmbmodes.Items.AddRange(new object[] {
            "PRODUCTION",
            "ENGINEERING",
            "ADMIN"});
            this.cmbmodes.Location = new System.Drawing.Point(269, 52);
            this.cmbmodes.Margin = new System.Windows.Forms.Padding(2);
            this.cmbmodes.Name = "cmbmodes";
            this.cmbmodes.Size = new System.Drawing.Size(232, 27);
            this.cmbmodes.TabIndex = 0;
            this.cmbmodes.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.cmbmodes_DrawItem);
            this.cmbmodes.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbmodes_KeyPress);
            // 
            // txtusername
            // 
            this.txtusername.BackColor = System.Drawing.Color.White;
            this.txtusername.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtusername.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtusername.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.txtusername.Location = new System.Drawing.Point(271, 98);
            this.txtusername.Margin = new System.Windows.Forms.Padding(2);
            this.txtusername.Name = "txtusername";
            this.txtusername.Size = new System.Drawing.Size(228, 25);
            this.txtusername.TabIndex = 2;
            this.txtusername.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtusername.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtusername_KeyPress);
            // 
            // txtpass
            // 
            this.txtpass.BackColor = System.Drawing.Color.White;
            this.txtpass.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtpass.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtpass.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.txtpass.Location = new System.Drawing.Point(271, 139);
            this.txtpass.Margin = new System.Windows.Forms.Padding(2);
            this.txtpass.Name = "txtpass";
            this.txtpass.PasswordChar = '*';
            this.txtpass.Size = new System.Drawing.Size(228, 25);
            this.txtpass.TabIndex = 3;
            this.txtpass.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtpass.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtpass_KeyPress);
            // 
            // btnlogin
            // 
            this.btnlogin.BackColor = System.Drawing.Color.Aqua;
            this.btnlogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 17F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnlogin.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.btnlogin.Location = new System.Drawing.Point(268, 192);
            this.btnlogin.Margin = new System.Windows.Forms.Padding(2);
            this.btnlogin.Name = "btnlogin";
            this.btnlogin.Size = new System.Drawing.Size(237, 41);
            this.btnlogin.TabIndex = 4;
            this.btnlogin.Text = "Login";
            this.btnlogin.UseVisualStyleBackColor = false;
            this.btnlogin.Click += new System.EventHandler(this.btnlogin_Click_1);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.cmbmodes);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txtpass);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.pictureBox4);
            this.panel1.Controls.Add(this.pictureBox2);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.pictureBox3);
            this.panel1.Controls.Add(this.btnlogin);
            this.panel1.Controls.Add(this.txtusername);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.button3);
            this.panel1.Location = new System.Drawing.Point(31, 30);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(543, 249);
            this.panel1.TabIndex = 12;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Crimson;
            this.label2.Location = new System.Drawing.Point(236, 172);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(307, 18);
            this.label2.TabIndex = 19;
            this.label2.Text = "Before Login Press Reset Button For Initialize";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label1.Location = new System.Drawing.Point(321, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 25);
            this.label1.TabIndex = 17;
            this.label1.Text = "User Login";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Transparent;
            this.button1.Enabled = false;
            this.button1.Location = new System.Drawing.Point(266, 134);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(239, 35);
            this.button1.TabIndex = 15;
            this.button1.UseVisualStyleBackColor = false;
            // 
            // pictureBox4
            // 
            this.pictureBox4.BackgroundImage = global::Master.Properties.Resources.mode;
            this.pictureBox4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox4.Location = new System.Drawing.Point(200, 48);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(43, 34);
            this.pictureBox4.TabIndex = 14;
            this.pictureBox4.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackgroundImage = global::Master.Properties.Resources.padlock;
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox2.Location = new System.Drawing.Point(200, 137);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(43, 32);
            this.pictureBox2.TabIndex = 13;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::Master.Properties.Resources.user;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.Location = new System.Drawing.Point(200, 96);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(43, 27);
            this.pictureBox1.TabIndex = 12;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox3.BackgroundImage = global::Master.Properties.Resources.multiple_users_silhouette;
            this.pictureBox3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox3.Location = new System.Drawing.Point(24, 48);
            this.pictureBox3.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(134, 130);
            this.pictureBox3.TabIndex = 8;
            this.pictureBox3.TabStop = false;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Transparent;
            this.button2.Enabled = false;
            this.button2.Location = new System.Drawing.Point(266, 93);
            this.button2.Margin = new System.Windows.Forms.Padding(2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(239, 35);
            this.button2.TabIndex = 16;
            this.button2.UseVisualStyleBackColor = false;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(266, 48);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(239, 35);
            this.button3.TabIndex = 18;
            this.button3.UseVisualStyleBackColor = true;
            // 
            // CancelButton
            // 
            this.CancelButton.BackgroundImage = global::Master.Properties.Resources.cancel;
            this.CancelButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.CancelButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CancelButton.Location = new System.Drawing.Point(577, 2);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(25, 23);
            this.CancelButton.TabIndex = 13;
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(88)))), ((int)(((byte)(208)))));
            this.ClientSize = new System.Drawing.Size(609, 308);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Login";
            this.Text = "LOGIN";
            this.Load += new System.EventHandler(this.Login_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private PictureBox pictureBox3;
        private ComboBox cmbmodes;
        private TextBox txtusername;
        private TextBox txtpass;
        private Button btnlogin;
        private Panel panel1;
        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
        private PictureBox pictureBox4;
        private Button button2;
        private Button button1;
        private Label label1;
        private Button CancelButton;
        private Button button3;
        private Label label2;
    }
}
