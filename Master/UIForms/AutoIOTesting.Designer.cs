using System.Drawing;
using System.Windows.Forms;

namespace AutoIOTest
{
    partial class AutoIOTesting
    {      
        private System.Windows.Forms.Label lblTotalAxes;
        private System.Windows.Forms.Button btnStartIOTest;
        private System.Windows.Forms.Button btnViewStatus;
        private System.Windows.Forms.ListBox listBoxLog;
        private System.Windows.Forms.Label lblIOTestStatus;

        private void InitializeComponent()
        {
            this.lblTotalAxes = new System.Windows.Forms.Label();
            this.btnStartIOTest = new System.Windows.Forms.Button();
            this.btnViewStatus = new System.Windows.Forms.Button();
            this.listBoxLog = new System.Windows.Forms.ListBox();
            this.lblIOTestStatus = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblTotalAxes
            // 
            this.lblTotalAxes.AutoSize = true;
            this.lblTotalAxes.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblTotalAxes.Location = new System.Drawing.Point(20, 20);
            this.lblTotalAxes.Name = "lblTotalAxes";
            this.lblTotalAxes.Size = new System.Drawing.Size(99, 20);
            this.lblTotalAxes.TabIndex = 0;
            this.lblTotalAxes.Text = "Total Axes: 5";
            // 
            // btnStartIOTest
            // 
            this.btnStartIOTest.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(94)))), ((int)(((byte)(133)))));
            this.btnStartIOTest.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.btnStartIOTest.ForeColor = System.Drawing.Color.White;
            this.btnStartIOTest.Location = new System.Drawing.Point(20, 60);
            this.btnStartIOTest.Name = "btnStartIOTest";
            this.btnStartIOTest.Size = new System.Drawing.Size(170, 35);
            this.btnStartIOTest.TabIndex = 1;
            this.btnStartIOTest.Text = "Start I/O Test";
            this.btnStartIOTest.UseVisualStyleBackColor = false;
            this.btnStartIOTest.Click += new System.EventHandler(this.btnStartIOTest_Click);
            // 
            // btnViewStatus
            // 
            this.btnViewStatus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(94)))), ((int)(((byte)(133)))));
            this.btnViewStatus.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.btnViewStatus.ForeColor = System.Drawing.Color.White;
            this.btnViewStatus.Location = new System.Drawing.Point(200, 60);
            this.btnViewStatus.Name = "btnViewStatus";
            this.btnViewStatus.Size = new System.Drawing.Size(170, 35);
            this.btnViewStatus.TabIndex = 2;
            this.btnViewStatus.Text = "View Status";
            this.btnViewStatus.UseVisualStyleBackColor = false;
            this.btnViewStatus.Click += new System.EventHandler(this.btnViewStatus_Click);
            // 
            // listBoxLog
            // 
            this.listBoxLog.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.listBoxLog.ItemHeight = 17;
            this.listBoxLog.Location = new System.Drawing.Point(20, 100);
            this.listBoxLog.Name = "listBoxLog";
            this.listBoxLog.Size = new System.Drawing.Size(612, 548);
            this.listBoxLog.TabIndex = 3;
            // 
            // lblIOTestStatus
            // 
            this.lblIOTestStatus.AutoSize = true;
            this.lblIOTestStatus.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblIOTestStatus.ForeColor = System.Drawing.Color.DarkOrange;
            this.lblIOTestStatus.Location = new System.Drawing.Point(12, 667);
            this.lblIOTestStatus.Name = "lblIOTestStatus";
            this.lblIOTestStatus.Size = new System.Drawing.Size(220, 19);
            this.lblIOTestStatus.TabIndex = 4;
            this.lblIOTestStatus.Text = "Auto IO Test Status: Not Started";
            // 
            // AutoIOTesting
            // 
            this.ClientSize = new System.Drawing.Size(670, 706);
            this.Controls.Add(this.lblTotalAxes);
            this.Controls.Add(this.btnStartIOTest);
            this.Controls.Add(this.btnViewStatus);
            this.Controls.Add(this.listBoxLog);
            this.Controls.Add(this.lblIOTestStatus);
            this.Name = "AutoIOTesting";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Auto I/O Testing";
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
} // End of Designer