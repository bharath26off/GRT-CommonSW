namespace MasterProject
{
    partial class AlarmPopup
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.BtnAcknowledge = new System.Windows.Forms.Button();
            this.TxtDateTime = new System.Windows.Forms.TextBox();
            this.TxtErrorCode = new System.Windows.Forms.TextBox();
            this.TxtDescription = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(58, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "DateTime :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(46, 116);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(118, 24);
            this.label2.TabIndex = 1;
            this.label2.Text = "ErrorCode :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(41, 183);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(123, 24);
            this.label3.TabIndex = 1;
            this.label3.Text = "Description :";
            // 
            // BtnAcknowledge
            // 
            this.BtnAcknowledge.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnAcknowledge.Location = new System.Drawing.Point(381, 264);
            this.BtnAcknowledge.Name = "BtnAcknowledge";
            this.BtnAcknowledge.Size = new System.Drawing.Size(125, 34);
            this.BtnAcknowledge.TabIndex = 2;
            this.BtnAcknowledge.Text = "Acknowledge";
            this.BtnAcknowledge.UseVisualStyleBackColor = true;
            this.BtnAcknowledge.Click += new System.EventHandler(this.BtnAcknowledge_Click);
            // 
            // TxtDateTime
            // 
            this.TxtDateTime.BackColor = System.Drawing.Color.LightCoral;
            this.TxtDateTime.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TxtDateTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtDateTime.Location = new System.Drawing.Point(170, 44);
            this.TxtDateTime.Multiline = true;
            this.TxtDateTime.Name = "TxtDateTime";
            this.TxtDateTime.ReadOnly = true;
            this.TxtDateTime.Size = new System.Drawing.Size(349, 42);
            this.TxtDateTime.TabIndex = 3;
            // 
            // TxtErrorCode
            // 
            this.TxtErrorCode.BackColor = System.Drawing.Color.LightCoral;
            this.TxtErrorCode.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TxtErrorCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtErrorCode.Location = new System.Drawing.Point(171, 117);
            this.TxtErrorCode.Multiline = true;
            this.TxtErrorCode.Name = "TxtErrorCode";
            this.TxtErrorCode.ReadOnly = true;
            this.TxtErrorCode.Size = new System.Drawing.Size(348, 42);
            this.TxtErrorCode.TabIndex = 4;
            // 
            // TxtDescription
            // 
            this.TxtDescription.BackColor = System.Drawing.Color.LightCoral;
            this.TxtDescription.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TxtDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtDescription.Location = new System.Drawing.Point(171, 187);
            this.TxtDescription.Multiline = true;
            this.TxtDescription.Name = "TxtDescription";
            this.TxtDescription.ReadOnly = true;
            this.TxtDescription.Size = new System.Drawing.Size(348, 42);
            this.TxtDescription.TabIndex = 5;
            // 
            // AlarmPopup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightCoral;
            this.ClientSize = new System.Drawing.Size(548, 322);
            this.Controls.Add(this.TxtDescription);
            this.Controls.Add(this.TxtErrorCode);
            this.Controls.Add(this.TxtDateTime);
            this.Controls.Add(this.BtnAcknowledge);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AlarmPopup";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button BtnAcknowledge;
        private System.Windows.Forms.TextBox TxtDateTime;
        private System.Windows.Forms.TextBox TxtErrorCode;
        private System.Windows.Forms.TextBox TxtDescription;
    }
}