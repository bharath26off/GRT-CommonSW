
namespace Master.UI
{
    partial class Report
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
            this.lblProductionHeader = new System.Windows.Forms.Label();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.dgvProdData = new System.Windows.Forms.DataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.cmbShiftPrdata = new System.Windows.Forms.ComboBox();
            this.lblShiftPrdata = new System.Windows.Forms.Label();
            this.txtBarcodePrdata = new System.Windows.Forms.TextBox();
            this.dtpToDatePrdata = new System.Windows.Forms.DateTimePicker();
            this.lblBarCodePrdata = new System.Windows.Forms.Label();
            this.btnResetPrdata = new System.Windows.Forms.Button();
            this.btnSavePrdata = new System.Windows.Forms.Button();
            this.dtpFromDatePrdata = new System.Windows.Forms.DateTimePicker();
            this.btnLoadPrdata = new System.Windows.Forms.Button();
            this.lblToDatePrdata = new System.Windows.Forms.Label();
            this.lblFromDatePrdata = new System.Windows.Forms.Label();
            this.tabProductionReport = new System.Windows.Forms.TabControl();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProdData)).BeginInit();
            this.panel2.SuspendLayout();
            this.tabProductionReport.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblProductionHeader
            // 
            this.lblProductionHeader.BackColor = System.Drawing.Color.White;
            this.lblProductionHeader.Font = new System.Drawing.Font("Verdana", 18F, System.Drawing.FontStyle.Bold);
            this.lblProductionHeader.Location = new System.Drawing.Point(337, 8);
            this.lblProductionHeader.Name = "lblProductionHeader";
            this.lblProductionHeader.Size = new System.Drawing.Size(311, 38);
            this.lblProductionHeader.TabIndex = 45;
            this.lblProductionHeader.Text = "PRODUCTION REPORT";
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.dgvProdData);
            this.tabPage1.Controls.Add(this.panel2);
            this.tabPage1.Location = new System.Drawing.Point(4, 27);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1011, 540);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Production Data";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // dgvProdData
            // 
            this.dgvProdData.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvProdData.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dgvProdData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProdData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvProdData.Location = new System.Drawing.Point(3, 50);
            this.dgvProdData.Margin = new System.Windows.Forms.Padding(4);
            this.dgvProdData.Name = "dgvProdData";
            this.dgvProdData.ReadOnly = true;
            this.dgvProdData.RowHeadersWidth = 51;
            this.dgvProdData.Size = new System.Drawing.Size(1005, 487);
            this.dgvProdData.TabIndex = 6;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.cmbShiftPrdata);
            this.panel2.Controls.Add(this.lblShiftPrdata);
            this.panel2.Controls.Add(this.txtBarcodePrdata);
            this.panel2.Controls.Add(this.dtpToDatePrdata);
            this.panel2.Controls.Add(this.lblBarCodePrdata);
            this.panel2.Controls.Add(this.btnResetPrdata);
            this.panel2.Controls.Add(this.btnSavePrdata);
            this.panel2.Controls.Add(this.dtpFromDatePrdata);
            this.panel2.Controls.Add(this.btnLoadPrdata);
            this.panel2.Controls.Add(this.lblToDatePrdata);
            this.panel2.Controls.Add(this.lblFromDatePrdata);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel2.ForeColor = System.Drawing.Color.Black;
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1005, 47);
            this.panel2.TabIndex = 1;
            // 
            // cmbShiftPrdata
            // 
            this.cmbShiftPrdata.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbShiftPrdata.FormattingEnabled = true;
            this.cmbShiftPrdata.Items.AddRange(new object[] {
            "ALL",
            "A",
            "B",
            "C"});
            this.cmbShiftPrdata.Location = new System.Drawing.Point(465, 10);
            this.cmbShiftPrdata.Name = "cmbShiftPrdata";
            this.cmbShiftPrdata.Size = new System.Drawing.Size(92, 24);
            this.cmbShiftPrdata.TabIndex = 7;
            // 
            // lblShiftPrdata
            // 
            this.lblShiftPrdata.AutoSize = true;
            this.lblShiftPrdata.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblShiftPrdata.Location = new System.Drawing.Point(419, 15);
            this.lblShiftPrdata.Name = "lblShiftPrdata";
            this.lblShiftPrdata.Size = new System.Drawing.Size(40, 16);
            this.lblShiftPrdata.TabIndex = 6;
            this.lblShiftPrdata.Text = "Shift";
            // 
            // txtBarcodePrdata
            // 
            this.txtBarcodePrdata.Location = new System.Drawing.Point(639, 12);
            this.txtBarcodePrdata.Name = "txtBarcodePrdata";
            this.txtBarcodePrdata.Size = new System.Drawing.Size(77, 23);
            this.txtBarcodePrdata.TabIndex = 2;
            // 
            // dtpToDatePrdata
            // 
            this.dtpToDatePrdata.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpToDatePrdata.Location = new System.Drawing.Point(291, 12);
            this.dtpToDatePrdata.MaxDate = new System.DateTime(2025, 5, 19, 9, 21, 46, 0);
            this.dtpToDatePrdata.Name = "dtpToDatePrdata";
            this.dtpToDatePrdata.Size = new System.Drawing.Size(124, 23);
            this.dtpToDatePrdata.TabIndex = 43;
            this.dtpToDatePrdata.Value = new System.DateTime(2025, 5, 9, 0, 0, 0, 0);
            // 
            // lblBarCodePrdata
            // 
            this.lblBarCodePrdata.AutoSize = true;
            this.lblBarCodePrdata.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBarCodePrdata.Location = new System.Drawing.Point(560, 15);
            this.lblBarCodePrdata.Name = "lblBarCodePrdata";
            this.lblBarCodePrdata.Size = new System.Drawing.Size(73, 16);
            this.lblBarCodePrdata.TabIndex = 48;
            this.lblBarCodePrdata.Text = "Bar Code";
            // 
            // btnResetPrdata
            // 
            this.btnResetPrdata.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(94)))), ((int)(((byte)(133)))));
            this.btnResetPrdata.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnResetPrdata.ForeColor = System.Drawing.Color.White;
            this.btnResetPrdata.Location = new System.Drawing.Point(918, 7);
            this.btnResetPrdata.Name = "btnResetPrdata";
            this.btnResetPrdata.Size = new System.Drawing.Size(79, 30);
            this.btnResetPrdata.TabIndex = 47;
            this.btnResetPrdata.Text = "Reset";
            this.btnResetPrdata.UseVisualStyleBackColor = false;
            this.btnResetPrdata.Click += new System.EventHandler(this.btnResetPrdata_Click);
            // 
            // btnSavePrdata
            // 
            this.btnSavePrdata.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(94)))), ((int)(((byte)(133)))));
            this.btnSavePrdata.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSavePrdata.ForeColor = System.Drawing.Color.White;
            this.btnSavePrdata.Location = new System.Drawing.Point(833, 6);
            this.btnSavePrdata.Name = "btnSavePrdata";
            this.btnSavePrdata.Size = new System.Drawing.Size(79, 30);
            this.btnSavePrdata.TabIndex = 46;
            this.btnSavePrdata.Text = "Save";
            this.btnSavePrdata.UseVisualStyleBackColor = false;
            this.btnSavePrdata.Click += new System.EventHandler(this.btnSavePrdata_Click);
            // 
            // dtpFromDatePrdata
            // 
            this.dtpFromDatePrdata.CustomFormat = "";
            this.dtpFromDatePrdata.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFromDatePrdata.Location = new System.Drawing.Point(91, 12);
            this.dtpFromDatePrdata.MaxDate = new System.DateTime(2025, 5, 19, 9, 21, 51, 0);
            this.dtpFromDatePrdata.Name = "dtpFromDatePrdata";
            this.dtpFromDatePrdata.Size = new System.Drawing.Size(126, 23);
            this.dtpFromDatePrdata.TabIndex = 3;
            this.dtpFromDatePrdata.Value = new System.DateTime(2025, 5, 9, 9, 44, 15, 0);
            this.dtpFromDatePrdata.ValueChanged += new System.EventHandler(this.dtpFromDatePrdata_ValueChanged);
            // 
            // btnLoadPrdata
            // 
            this.btnLoadPrdata.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(94)))), ((int)(((byte)(133)))));
            this.btnLoadPrdata.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLoadPrdata.ForeColor = System.Drawing.Color.White;
            this.btnLoadPrdata.Location = new System.Drawing.Point(748, 7);
            this.btnLoadPrdata.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnLoadPrdata.Name = "btnLoadPrdata";
            this.btnLoadPrdata.Size = new System.Drawing.Size(79, 30);
            this.btnLoadPrdata.TabIndex = 6;
            this.btnLoadPrdata.Text = "Load";
            this.btnLoadPrdata.UseVisualStyleBackColor = false;
            this.btnLoadPrdata.Click += new System.EventHandler(this.btnLoadPrdata_Click);
            // 
            // lblToDatePrdata
            // 
            this.lblToDatePrdata.AutoSize = true;
            this.lblToDatePrdata.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblToDatePrdata.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblToDatePrdata.Location = new System.Drawing.Point(223, 14);
            this.lblToDatePrdata.Name = "lblToDatePrdata";
            this.lblToDatePrdata.Size = new System.Drawing.Size(62, 16);
            this.lblToDatePrdata.TabIndex = 1;
            this.lblToDatePrdata.Text = "To Date";
            this.lblToDatePrdata.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblFromDatePrdata
            // 
            this.lblFromDatePrdata.AutoSize = true;
            this.lblFromDatePrdata.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFromDatePrdata.Location = new System.Drawing.Point(2, 15);
            this.lblFromDatePrdata.Name = "lblFromDatePrdata";
            this.lblFromDatePrdata.Size = new System.Drawing.Size(83, 16);
            this.lblFromDatePrdata.TabIndex = 0;
            this.lblFromDatePrdata.Text = "From Date";
            // 
            // tabProductionReport
            // 
            this.tabProductionReport.Controls.Add(this.tabPage1);
            this.tabProductionReport.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold);
            this.tabProductionReport.Location = new System.Drawing.Point(5, 49);
            this.tabProductionReport.Name = "tabProductionReport";
            this.tabProductionReport.SelectedIndex = 0;
            this.tabProductionReport.Size = new System.Drawing.Size(1019, 571);
            this.tabProductionReport.TabIndex = 47;
            // 
            // Report
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1024, 620);
            this.Controls.Add(this.tabProductionReport);
            this.Controls.Add(this.lblProductionHeader);
            this.Font = new System.Drawing.Font("Tahoma", 7.8F);
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Report";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Report";
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProdData)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.tabProductionReport.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label lblProductionHeader;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ComboBox cmbShiftPrdata;
        private System.Windows.Forms.Label lblShiftPrdata;
        private System.Windows.Forms.TextBox txtBarcodePrdata;
        private System.Windows.Forms.DateTimePicker dtpToDatePrdata;
        private System.Windows.Forms.Label lblBarCodePrdata;
        private System.Windows.Forms.Button btnResetPrdata;
        private System.Windows.Forms.Button btnSavePrdata;
        private System.Windows.Forms.DateTimePicker dtpFromDatePrdata;
        private System.Windows.Forms.Button btnLoadPrdata;
        private System.Windows.Forms.Label lblToDatePrdata;
        private System.Windows.Forms.Label lblFromDatePrdata;
        private System.Windows.Forms.TabControl tabProductionReport;
        private System.Windows.Forms.DataGridView dgvProdData;
    }
}