namespace VaccumHelperLib
{
    partial class UCVaccum
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
            this.groupBox_vaccum_gen_name = new System.Windows.Forms.GroupBox();
            this.btn_vaccum_on = new System.Windows.Forms.Button();
            this.label_blow_op_address = new System.Windows.Forms.Label();
            this.label_vaccum_op_address = new System.Windows.Forms.Label();
            this.label_vaccum_feedback_address = new System.Windows.Forms.Label();
            this.btn_blow_on = new System.Windows.Forms.Button();
            this.btn_off = new System.Windows.Forms.Button();
            this.btn_vaccum_feedback = new System.Windows.Forms.Button();
            this.groupBox_vaccum_gen_name.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox_vaccum_gen_name
            // 
            this.groupBox_vaccum_gen_name.Controls.Add(this.btn_vaccum_on);
            this.groupBox_vaccum_gen_name.Controls.Add(this.label_blow_op_address);
            this.groupBox_vaccum_gen_name.Controls.Add(this.label_vaccum_op_address);
            this.groupBox_vaccum_gen_name.Controls.Add(this.label_vaccum_feedback_address);
            this.groupBox_vaccum_gen_name.Controls.Add(this.btn_blow_on);
            this.groupBox_vaccum_gen_name.Controls.Add(this.btn_off);
            this.groupBox_vaccum_gen_name.Controls.Add(this.btn_vaccum_feedback);
            this.groupBox_vaccum_gen_name.Location = new System.Drawing.Point(10, 9);
            this.groupBox_vaccum_gen_name.Name = "groupBox_vaccum_gen_name";
            this.groupBox_vaccum_gen_name.Size = new System.Drawing.Size(328, 111);
            this.groupBox_vaccum_gen_name.TabIndex = 1;
            this.groupBox_vaccum_gen_name.TabStop = false;
            this.groupBox_vaccum_gen_name.Text = "Vaccum name";
            // 
            // btn_vaccum_on
            // 
            this.btn_vaccum_on.Location = new System.Drawing.Point(56, 54);
            this.btn_vaccum_on.Name = "btn_vaccum_on";
            this.btn_vaccum_on.Size = new System.Drawing.Size(65, 32);
            this.btn_vaccum_on.TabIndex = 8;
            this.btn_vaccum_on.Text = "Vaccum";
            this.btn_vaccum_on.UseVisualStyleBackColor = true;
            this.btn_vaccum_on.Click += new System.EventHandler(this.btn_vaccum_on_Click);
            // 
            // label_blow_op_address
            // 
            this.label_blow_op_address.AutoSize = true;
            this.label_blow_op_address.Location = new System.Drawing.Point(269, 64);
            this.label_blow_op_address.Name = "label_blow_op_address";
            this.label_blow_op_address.Size = new System.Drawing.Size(32, 13);
            this.label_blow_op_address.TabIndex = 7;
            this.label_blow_op_address.Text = "Y_01";
            // 
            // label_vaccum_op_address
            // 
            this.label_vaccum_op_address.AutoSize = true;
            this.label_vaccum_op_address.Location = new System.Drawing.Point(12, 64);
            this.label_vaccum_op_address.Name = "label_vaccum_op_address";
            this.label_vaccum_op_address.Size = new System.Drawing.Size(32, 13);
            this.label_vaccum_op_address.TabIndex = 6;
            this.label_vaccum_op_address.Text = "Y_00";
            // 
            // label_vaccum_feedback_address
            // 
            this.label_vaccum_feedback_address.AutoSize = true;
            this.label_vaccum_feedback_address.Location = new System.Drawing.Point(12, 33);
            this.label_vaccum_feedback_address.Name = "label_vaccum_feedback_address";
            this.label_vaccum_feedback_address.Size = new System.Drawing.Size(32, 13);
            this.label_vaccum_feedback_address.TabIndex = 4;
            this.label_vaccum_feedback_address.Text = "X_00";
            // 
            // btn_blow_on
            // 
            this.btn_blow_on.Location = new System.Drawing.Point(198, 54);
            this.btn_blow_on.Name = "btn_blow_on";
            this.btn_blow_on.Size = new System.Drawing.Size(65, 32);
            this.btn_blow_on.TabIndex = 2;
            this.btn_blow_on.Text = "Blow";
            this.btn_blow_on.UseVisualStyleBackColor = true;
            this.btn_blow_on.Click += new System.EventHandler(this.btn_blow_on_Click);
            // 
            // btn_off
            // 
            this.btn_off.Location = new System.Drawing.Point(127, 54);
            this.btn_off.Name = "btn_off";
            this.btn_off.Size = new System.Drawing.Size(65, 32);
            this.btn_off.TabIndex = 1;
            this.btn_off.Text = "Off";
            this.btn_off.UseVisualStyleBackColor = true;
            this.btn_off.Click += new System.EventHandler(this.btn_off_Click);
            // 
            // btn_vaccum_feedback
            // 
            this.btn_vaccum_feedback.Location = new System.Drawing.Point(56, 28);
            this.btn_vaccum_feedback.Name = "btn_vaccum_feedback";
            this.btn_vaccum_feedback.Size = new System.Drawing.Size(65, 22);
            this.btn_vaccum_feedback.TabIndex = 0;
            this.btn_vaccum_feedback.UseVisualStyleBackColor = true;
            // 
            // UCVaccum
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox_vaccum_gen_name);
            this.Name = "UCVaccum";
            this.Size = new System.Drawing.Size(350, 131);
            this.groupBox_vaccum_gen_name.ResumeLayout(false);
            this.groupBox_vaccum_gen_name.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox_vaccum_gen_name;
        private System.Windows.Forms.Button btn_vaccum_on;
        private System.Windows.Forms.Label label_blow_op_address;
        private System.Windows.Forms.Label label_vaccum_op_address;
        private System.Windows.Forms.Label label_vaccum_feedback_address;
        private System.Windows.Forms.Button btn_blow_on;
        private System.Windows.Forms.Button btn_off;
        private System.Windows.Forms.Button btn_vaccum_feedback;
    }
}
