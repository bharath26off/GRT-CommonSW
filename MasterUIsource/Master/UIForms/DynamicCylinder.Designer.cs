namespace DynamicCylinders
{
    partial class DynamicCylinder
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
            this.cmbCylinderList = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnPopUp = new System.Windows.Forms.Button();
            this.pnlControl = new System.Windows.Forms.Panel();
            this.btnCloseAll = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cmbCylinderList
            // 
            this.cmbCylinderList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCylinderList.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbCylinderList.FormattingEnabled = true;
            this.cmbCylinderList.Location = new System.Drawing.Point(112, 18);
            this.cmbCylinderList.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmbCylinderList.Name = "cmbCylinderList";
            this.cmbCylinderList.Size = new System.Drawing.Size(400, 33);
            this.cmbCylinderList.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Cylinder: ";
            // 
            // btnPopUp
            // 
            this.btnPopUp.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPopUp.Location = new System.Drawing.Point(517, 18);
            this.btnPopUp.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnPopUp.Name = "btnPopUp";
            this.btnPopUp.Size = new System.Drawing.Size(111, 33);
            this.btnPopUp.TabIndex = 2;
            this.btnPopUp.Text = "Pop Up";
            this.btnPopUp.UseVisualStyleBackColor = true;
            // 
            // pnlControl
            // 
            this.pnlControl.BackColor = System.Drawing.SystemColors.ControlLight;
            this.pnlControl.Location = new System.Drawing.Point(19, 79);
            this.pnlControl.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pnlControl.Name = "pnlControl";
            this.pnlControl.Size = new System.Drawing.Size(812, 267);
            this.pnlControl.TabIndex = 3;
            // 
            // btnCloseAll
            // 
            this.btnCloseAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCloseAll.Location = new System.Drawing.Point(635, 18);
            this.btnCloseAll.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnCloseAll.Name = "btnCloseAll";
            this.btnCloseAll.Size = new System.Drawing.Size(196, 33);
            this.btnCloseAll.TabIndex = 4;
            this.btnCloseAll.Text = "Close All Popups";
            this.btnCloseAll.UseVisualStyleBackColor = true;
            this.btnCloseAll.Click += new System.EventHandler(this.btnCloseAll_Click);
            // 
            // DynamicCylinder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(845, 383);
            this.Controls.Add(this.btnCloseAll);
            this.Controls.Add(this.pnlControl);
            this.Controls.Add(this.btnPopUp);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbCylinderList);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "DynamicCylinder";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ComboBox cmbCylinderList;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnPopUp;
        private System.Windows.Forms.Panel pnlControl;
        private System.Windows.Forms.Button btnCloseAll;
    }
}

