namespace CylinderHelperLib
{
    partial class UCCylinder
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox_cylindername = new System.Windows.Forms.GroupBox();
            this.label_safe_to_retract = new System.Windows.Forms.Label();
            this.label_safe_to_extend = new System.Windows.Forms.Label();
            this.btn_safe_to_retract = new System.Windows.Forms.Button();
            this.btn_safe_to_extend = new System.Windows.Forms.Button();
            this.label_home_coil_address = new System.Windows.Forms.Label();
            this.label_work_coil_address = new System.Windows.Forms.Label();
            this.label_home_reed_address = new System.Windows.Forms.Label();
            this.label_work_reed_address = new System.Windows.Forms.Label();
            this.btn_retract_reed = new System.Windows.Forms.Button();
            this.btn_Retract_coil = new System.Windows.Forms.Button();
            this.btn_Extend_coil = new System.Windows.Forms.Button();
            this.btn_exttend_reed = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.groupBox_cylindername.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox_cylindername
            // 
            this.groupBox_cylindername.Controls.Add(this.label_safe_to_retract);
            this.groupBox_cylindername.Controls.Add(this.label_safe_to_extend);
            this.groupBox_cylindername.Controls.Add(this.btn_safe_to_retract);
            this.groupBox_cylindername.Controls.Add(this.btn_safe_to_extend);
            this.groupBox_cylindername.Controls.Add(this.label_home_coil_address);
            this.groupBox_cylindername.Controls.Add(this.label_work_coil_address);
            this.groupBox_cylindername.Controls.Add(this.label_home_reed_address);
            this.groupBox_cylindername.Controls.Add(this.label_work_reed_address);
            this.groupBox_cylindername.Controls.Add(this.btn_retract_reed);
            this.groupBox_cylindername.Controls.Add(this.btn_Retract_coil);
            this.groupBox_cylindername.Controls.Add(this.btn_Extend_coil);
            this.groupBox_cylindername.Controls.Add(this.btn_exttend_reed);
            this.groupBox_cylindername.Location = new System.Drawing.Point(20, 20);
            this.groupBox_cylindername.Name = "groupBox_cylindername";
            this.groupBox_cylindername.Size = new System.Drawing.Size(310, 135);
            this.groupBox_cylindername.TabIndex = 0;
            this.groupBox_cylindername.TabStop = false;
            this.groupBox_cylindername.Text = "Cylinder name";
            // 
            // label_safe_to_retract
            // 
            this.label_safe_to_retract.AutoSize = true;
            this.label_safe_to_retract.Location = new System.Drawing.Point(198, 105);
            this.label_safe_to_retract.Name = "label_safe_to_retract";
            this.label_safe_to_retract.Size = new System.Drawing.Size(74, 13);
            this.label_safe_to_retract.TabIndex = 11;
            this.label_safe_to_retract.Text = "Safe to retract";
            // 
            // label_safe_to_extend
            // 
            this.label_safe_to_extend.AutoSize = true;
            this.label_safe_to_extend.Location = new System.Drawing.Point(62, 105);
            this.label_safe_to_extend.Name = "label_safe_to_extend";
            this.label_safe_to_extend.Size = new System.Drawing.Size(76, 13);
            this.label_safe_to_extend.TabIndex = 10;
            this.label_safe_to_extend.Text = "Safe to extend";
            // 
            // btn_safe_to_retract
            // 
            this.btn_safe_to_retract.Location = new System.Drawing.Point(172, 101);
            this.btn_safe_to_retract.Name = "btn_safe_to_retract";
            this.btn_safe_to_retract.Size = new System.Drawing.Size(20, 20);
            this.btn_safe_to_retract.TabIndex = 9;
            this.btn_safe_to_retract.UseVisualStyleBackColor = true;
            // 
            // btn_safe_to_extend
            // 
            this.btn_safe_to_extend.Location = new System.Drawing.Point(36, 101);
            this.btn_safe_to_extend.Name = "btn_safe_to_extend";
            this.btn_safe_to_extend.Size = new System.Drawing.Size(20, 20);
            this.btn_safe_to_extend.TabIndex = 8;
            this.btn_safe_to_extend.UseVisualStyleBackColor = true;
            // 
            // label_home_coil_address
            // 
            this.label_home_coil_address.AutoSize = true;
            this.label_home_coil_address.Location = new System.Drawing.Point(173, 32);
            this.label_home_coil_address.Name = "label_home_coil_address";
            this.label_home_coil_address.Size = new System.Drawing.Size(32, 13);
            this.label_home_coil_address.TabIndex = 7;
            this.label_home_coil_address.Text = "Y_01";
            // 
            // label_work_coil_address
            // 
            this.label_work_coil_address.AutoSize = true;
            this.label_work_coil_address.Location = new System.Drawing.Point(102, 32);
            this.label_work_coil_address.Name = "label_work_coil_address";
            this.label_work_coil_address.Size = new System.Drawing.Size(32, 13);
            this.label_work_coil_address.TabIndex = 6;
            this.label_work_coil_address.Text = "Y_00";
            // 
            // label_home_reed_address
            // 
            this.label_home_reed_address.AutoSize = true;
            this.label_home_reed_address.Location = new System.Drawing.Point(244, 32);
            this.label_home_reed_address.Name = "label_home_reed_address";
            this.label_home_reed_address.Size = new System.Drawing.Size(32, 13);
            this.label_home_reed_address.TabIndex = 5;
            this.label_home_reed_address.Text = "X_01";
            // 
            // label_work_reed_address
            // 
            this.label_work_reed_address.AutoSize = true;
            this.label_work_reed_address.Location = new System.Drawing.Point(30, 32);
            this.label_work_reed_address.Name = "label_work_reed_address";
            this.label_work_reed_address.Size = new System.Drawing.Size(32, 13);
            this.label_work_reed_address.TabIndex = 4;
            this.label_work_reed_address.Text = "X_00";
            // 
            // btn_retract_reed
            // 
            this.btn_retract_reed.Location = new System.Drawing.Point(244, 57);
            this.btn_retract_reed.Name = "btn_retract_reed";
            this.btn_retract_reed.Size = new System.Drawing.Size(32, 32);
            this.btn_retract_reed.TabIndex = 3;
            this.btn_retract_reed.UseVisualStyleBackColor = true;
            // 
            // btn_Retract_coil
            // 
            this.btn_Retract_coil.Location = new System.Drawing.Point(157, 57);
            this.btn_Retract_coil.Name = "btn_Retract_coil";
            this.btn_Retract_coil.Size = new System.Drawing.Size(65, 32);
            this.btn_Retract_coil.TabIndex = 2;
            this.btn_Retract_coil.Text = "Home";
            this.btn_Retract_coil.UseVisualStyleBackColor = true;
            this.btn_Retract_coil.Click += new System.EventHandler(this.btn_Retract_coil_Click);
            // 
            // btn_Extend_coil
            // 
            this.btn_Extend_coil.Location = new System.Drawing.Point(86, 57);
            this.btn_Extend_coil.Name = "btn_Extend_coil";
            this.btn_Extend_coil.Size = new System.Drawing.Size(65, 32);
            this.btn_Extend_coil.TabIndex = 1;
            this.btn_Extend_coil.Text = "Work";
            this.btn_Extend_coil.UseVisualStyleBackColor = true;
            this.btn_Extend_coil.Click += new System.EventHandler(this.btn_Extend_coil_Click);
            // 
            // btn_exttend_reed
            // 
            this.btn_exttend_reed.Location = new System.Drawing.Point(30, 57);
            this.btn_exttend_reed.Name = "btn_exttend_reed";
            this.btn_exttend_reed.Size = new System.Drawing.Size(32, 32);
            this.btn_exttend_reed.TabIndex = 0;
            this.btn_exttend_reed.UseVisualStyleBackColor = true;
            // 
            // UCCylinder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox_cylindername);
            this.Name = "UCCylinder";
            this.Size = new System.Drawing.Size(350, 175);
            this.groupBox_cylindername.ResumeLayout(false);
            this.groupBox_cylindername.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox_cylindername;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Button btn_exttend_reed;
        private System.Windows.Forms.Label label_home_reed_address;
        private System.Windows.Forms.Label label_work_reed_address;
        private System.Windows.Forms.Button btn_retract_reed;
        private System.Windows.Forms.Button btn_Retract_coil;
        private System.Windows.Forms.Button btn_Extend_coil;
        private System.Windows.Forms.Label label_home_coil_address;
        private System.Windows.Forms.Label label_work_coil_address;
        private System.Windows.Forms.Button btn_safe_to_retract;
        private System.Windows.Forms.Button btn_safe_to_extend;
        private System.Windows.Forms.Label label_safe_to_retract;
        private System.Windows.Forms.Label label_safe_to_extend;
    }
}
