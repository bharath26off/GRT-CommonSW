
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
            this.tabProductionReport = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
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
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.panel3 = new System.Windows.Forms.Panel();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.btnLoadMachStatus = new System.Windows.Forms.Button();
            this.dtpToDateMachStatus = new System.Windows.Forms.DateTimePicker();
            this.dtpFromDateMachStatus = new System.Windows.Forms.DateTimePicker();
            this.cmbShiftMachStatus = new System.Windows.Forms.ComboBox();
            this.lblShiftMachStatus = new System.Windows.Forms.Label();
            this.lblToDateMachStatus = new System.Windows.Forms.Label();
            this.lblFromDateMachStatus = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.panel4 = new System.Windows.Forms.Panel();
            this.button8 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.button10 = new System.Windows.Forms.Button();
            this.dtpToDateMacnHelth = new System.Windows.Forms.DateTimePicker();
            this.dtpFromDateMacnHelth = new System.Windows.Forms.DateTimePicker();
            this.cmbShiftMacnHelth = new System.Windows.Forms.ComboBox();
            this.lblShiftMacnHelth = new System.Windows.Forms.Label();
            this.lblToDateMacnHelth = new System.Windows.Forms.Label();
            this.lblFromDateMacnHelth = new System.Windows.Forms.Label();
            this.tabProductionReport.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.panel4.SuspendLayout();
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
            // tabProductionReport
            // 
            this.tabProductionReport.Controls.Add(this.tabPage1);
            this.tabProductionReport.Controls.Add(this.tabPage2);
            this.tabProductionReport.Controls.Add(this.tabPage3);
            this.tabProductionReport.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold);
            this.tabProductionReport.Location = new System.Drawing.Point(5, 49);
            this.tabProductionReport.Name = "tabProductionReport";
            this.tabProductionReport.SelectedIndex = 0;
            this.tabProductionReport.Size = new System.Drawing.Size(1019, 571);
            this.tabProductionReport.TabIndex = 47;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.panel2);
            this.tabPage1.Location = new System.Drawing.Point(4, 27);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1011, 540);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Production Data";
            this.tabPage1.UseVisualStyleBackColor = true;
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
            this.panel2.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel2.ForeColor = System.Drawing.Color.Black;
            this.panel2.Location = new System.Drawing.Point(5, 7);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1003, 47);
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
            this.lblToDatePrdata.Location = new System.Drawing.Point(223, 14);
            this.lblToDatePrdata.Name = "lblToDatePrdata";
            this.lblToDatePrdata.Size = new System.Drawing.Size(62, 16);
            this.lblToDatePrdata.TabIndex = 1;
            this.lblToDatePrdata.Text = "To Date";
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
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.panel3);
            this.tabPage2.Location = new System.Drawing.Point(4, 27);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1011, 540);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Machine Status";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.button5);
            this.panel3.Controls.Add(this.button6);
            this.panel3.Controls.Add(this.btnLoadMachStatus);
            this.panel3.Controls.Add(this.dtpToDateMachStatus);
            this.panel3.Controls.Add(this.dtpFromDateMachStatus);
            this.panel3.Controls.Add(this.cmbShiftMachStatus);
            this.panel3.Controls.Add(this.lblShiftMachStatus);
            this.panel3.Controls.Add(this.lblToDateMachStatus);
            this.panel3.Controls.Add(this.lblFromDateMachStatus);
            this.panel3.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel3.ForeColor = System.Drawing.Color.Black;
            this.panel3.Location = new System.Drawing.Point(6, 7);
            this.panel3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1002, 47);
            this.panel3.TabIndex = 2;
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(94)))), ((int)(((byte)(133)))));
            this.button5.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button5.ForeColor = System.Drawing.Color.White;
            this.button5.Location = new System.Drawing.Point(1368, 7);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(93, 30);
            this.button5.TabIndex = 50;
            this.button5.Text = "Reset";
            this.button5.UseVisualStyleBackColor = false;
            // 
            // button6
            // 
            this.button6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(94)))), ((int)(((byte)(133)))));
            this.button6.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button6.ForeColor = System.Drawing.Color.White;
            this.button6.Location = new System.Drawing.Point(1258, 7);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(93, 30);
            this.button6.TabIndex = 49;
            this.button6.Text = "Save";
            this.button6.UseVisualStyleBackColor = false;
            // 
            // btnLoadMachStatus
            // 
            this.btnLoadMachStatus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(94)))), ((int)(((byte)(133)))));
            this.btnLoadMachStatus.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLoadMachStatus.ForeColor = System.Drawing.Color.White;
            this.btnLoadMachStatus.Location = new System.Drawing.Point(903, 8);
            this.btnLoadMachStatus.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnLoadMachStatus.Name = "btnLoadMachStatus";
            this.btnLoadMachStatus.Size = new System.Drawing.Size(93, 30);
            this.btnLoadMachStatus.TabIndex = 48;
            this.btnLoadMachStatus.Text = "Load";
            this.btnLoadMachStatus.UseVisualStyleBackColor = false;
            this.btnLoadMachStatus.Click += new System.EventHandler(this.btnLoadMachStatus_Click);
            // 
            // dtpToDateMachStatus
            // 
            this.dtpToDateMachStatus.CustomFormat = "dd-MM-yyyy";
            this.dtpToDateMachStatus.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpToDateMachStatus.Location = new System.Drawing.Point(304, 10);
            this.dtpToDateMachStatus.Name = "dtpToDateMachStatus";
            this.dtpToDateMachStatus.Size = new System.Drawing.Size(126, 23);
            this.dtpToDateMachStatus.TabIndex = 43;
            this.dtpToDateMachStatus.Value = new System.DateTime(2025, 3, 19, 11, 5, 0, 0);
            // 
            // dtpFromDateMachStatus
            // 
            this.dtpFromDateMachStatus.CustomFormat = "";
            this.dtpFromDateMachStatus.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFromDateMachStatus.Location = new System.Drawing.Point(99, 10);
            this.dtpFromDateMachStatus.Name = "dtpFromDateMachStatus";
            this.dtpFromDateMachStatus.Size = new System.Drawing.Size(130, 23);
            this.dtpFromDateMachStatus.TabIndex = 3;
            this.dtpFromDateMachStatus.Value = new System.DateTime(2025, 3, 19, 11, 5, 0, 0);
            this.dtpFromDateMachStatus.ValueChanged += new System.EventHandler(this.dtpFromDateMachStatus_ValueChanged);
            // 
            // cmbShiftMachStatus
            // 
            this.cmbShiftMachStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbShiftMachStatus.FormattingEnabled = true;
            this.cmbShiftMachStatus.Items.AddRange(new object[] {
            "A",
            "B",
            "C"});
            this.cmbShiftMachStatus.Location = new System.Drawing.Point(485, 11);
            this.cmbShiftMachStatus.Name = "cmbShiftMachStatus";
            this.cmbShiftMachStatus.Size = new System.Drawing.Size(87, 24);
            this.cmbShiftMachStatus.TabIndex = 5;
            // 
            // lblShiftMachStatus
            // 
            this.lblShiftMachStatus.AutoSize = true;
            this.lblShiftMachStatus.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblShiftMachStatus.Location = new System.Drawing.Point(439, 14);
            this.lblShiftMachStatus.Name = "lblShiftMachStatus";
            this.lblShiftMachStatus.Size = new System.Drawing.Size(40, 16);
            this.lblShiftMachStatus.TabIndex = 2;
            this.lblShiftMachStatus.Text = "Shift";
            // 
            // lblToDateMachStatus
            // 
            this.lblToDateMachStatus.AutoSize = true;
            this.lblToDateMachStatus.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblToDateMachStatus.Location = new System.Drawing.Point(236, 14);
            this.lblToDateMachStatus.Name = "lblToDateMachStatus";
            this.lblToDateMachStatus.Size = new System.Drawing.Size(62, 16);
            this.lblToDateMachStatus.TabIndex = 1;
            this.lblToDateMachStatus.Text = "To Date";
            // 
            // lblFromDateMachStatus
            // 
            this.lblFromDateMachStatus.AutoSize = true;
            this.lblFromDateMachStatus.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFromDateMachStatus.Location = new System.Drawing.Point(6, 14);
            this.lblFromDateMachStatus.Name = "lblFromDateMachStatus";
            this.lblFromDateMachStatus.Size = new System.Drawing.Size(83, 16);
            this.lblFromDateMachStatus.TabIndex = 0;
            this.lblFromDateMachStatus.Text = "From Date";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.panel4);
            this.tabPage3.Location = new System.Drawing.Point(4, 27);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(1011, 540);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Machine Health";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // panel4
            // 
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.button8);
            this.panel4.Controls.Add(this.button9);
            this.panel4.Controls.Add(this.button10);
            this.panel4.Controls.Add(this.dtpToDateMacnHelth);
            this.panel4.Controls.Add(this.dtpFromDateMacnHelth);
            this.panel4.Controls.Add(this.cmbShiftMacnHelth);
            this.panel4.Controls.Add(this.lblShiftMacnHelth);
            this.panel4.Controls.Add(this.lblToDateMacnHelth);
            this.panel4.Controls.Add(this.lblFromDateMacnHelth);
            this.panel4.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel4.ForeColor = System.Drawing.Color.Black;
            this.panel4.Location = new System.Drawing.Point(5, 7);
            this.panel4.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1002, 47);
            this.panel4.TabIndex = 3;
            // 
            // button8
            // 
            this.button8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(94)))), ((int)(((byte)(133)))));
            this.button8.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button8.ForeColor = System.Drawing.Color.White;
            this.button8.Location = new System.Drawing.Point(1368, 7);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(93, 30);
            this.button8.TabIndex = 50;
            this.button8.Text = "Reset";
            this.button8.UseVisualStyleBackColor = false;
            // 
            // button9
            // 
            this.button9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(94)))), ((int)(((byte)(133)))));
            this.button9.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button9.ForeColor = System.Drawing.Color.White;
            this.button9.Location = new System.Drawing.Point(1258, 7);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(93, 30);
            this.button9.TabIndex = 49;
            this.button9.Text = "Save";
            this.button9.UseVisualStyleBackColor = false;
            // 
            // button10
            // 
            this.button10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(94)))), ((int)(((byte)(133)))));
            this.button10.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button10.ForeColor = System.Drawing.Color.White;
            this.button10.Location = new System.Drawing.Point(903, 8);
            this.button10.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(93, 30);
            this.button10.TabIndex = 48;
            this.button10.Text = "Load";
            this.button10.UseVisualStyleBackColor = false;
            this.button10.Click += new System.EventHandler(this.button10_Click);
            // 
            // dtpToDateMacnHelth
            // 
            this.dtpToDateMacnHelth.CustomFormat = "dd-MM-yyyy";
            this.dtpToDateMacnHelth.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpToDateMacnHelth.Location = new System.Drawing.Point(295, 12);
            this.dtpToDateMacnHelth.Name = "dtpToDateMacnHelth";
            this.dtpToDateMacnHelth.Size = new System.Drawing.Size(124, 23);
            this.dtpToDateMacnHelth.TabIndex = 43;
            this.dtpToDateMacnHelth.Value = new System.DateTime(2025, 3, 19, 11, 5, 0, 0);
            // 
            // dtpFromDateMacnHelth
            // 
            this.dtpFromDateMacnHelth.CustomFormat = "";
            this.dtpFromDateMacnHelth.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFromDateMacnHelth.Location = new System.Drawing.Point(97, 12);
            this.dtpFromDateMacnHelth.Name = "dtpFromDateMacnHelth";
            this.dtpFromDateMacnHelth.Size = new System.Drawing.Size(124, 23);
            this.dtpFromDateMacnHelth.TabIndex = 3;
            this.dtpFromDateMacnHelth.Value = new System.DateTime(2025, 3, 19, 11, 5, 0, 0);
            this.dtpFromDateMacnHelth.ValueChanged += new System.EventHandler(this.dtpFromDateMacnHelth_ValueChanged);
            // 
            // cmbShiftMacnHelth
            // 
            this.cmbShiftMacnHelth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbShiftMacnHelth.FormattingEnabled = true;
            this.cmbShiftMacnHelth.Items.AddRange(new object[] {
            "A",
            "B",
            "C"});
            this.cmbShiftMacnHelth.Location = new System.Drawing.Point(482, 12);
            this.cmbShiftMacnHelth.Name = "cmbShiftMacnHelth";
            this.cmbShiftMacnHelth.Size = new System.Drawing.Size(79, 24);
            this.cmbShiftMacnHelth.TabIndex = 5;
            // 
            // lblShiftMacnHelth
            // 
            this.lblShiftMacnHelth.AutoSize = true;
            this.lblShiftMacnHelth.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblShiftMacnHelth.Location = new System.Drawing.Point(436, 17);
            this.lblShiftMacnHelth.Name = "lblShiftMacnHelth";
            this.lblShiftMacnHelth.Size = new System.Drawing.Size(40, 16);
            this.lblShiftMacnHelth.TabIndex = 2;
            this.lblShiftMacnHelth.Text = "Shift";
            // 
            // lblToDateMacnHelth
            // 
            this.lblToDateMacnHelth.AutoSize = true;
            this.lblToDateMacnHelth.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblToDateMacnHelth.Location = new System.Drawing.Point(227, 15);
            this.lblToDateMacnHelth.Name = "lblToDateMacnHelth";
            this.lblToDateMacnHelth.Size = new System.Drawing.Size(62, 16);
            this.lblToDateMacnHelth.TabIndex = 1;
            this.lblToDateMacnHelth.Text = "To Date";
            // 
            // lblFromDateMacnHelth
            // 
            this.lblFromDateMacnHelth.AutoSize = true;
            this.lblFromDateMacnHelth.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFromDateMacnHelth.Location = new System.Drawing.Point(8, 15);
            this.lblFromDateMacnHelth.Name = "lblFromDateMacnHelth";
            this.lblFromDateMacnHelth.Size = new System.Drawing.Size(83, 16);
            this.lblFromDateMacnHelth.TabIndex = 0;
            this.lblFromDateMacnHelth.Text = "From Date";
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
            this.tabProductionReport.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label lblProductionHeader;
        private System.Windows.Forms.TabControl tabProductionReport;
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
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button btnLoadMachStatus;
        private System.Windows.Forms.DateTimePicker dtpToDateMachStatus;
        private System.Windows.Forms.DateTimePicker dtpFromDateMachStatus;
        private System.Windows.Forms.ComboBox cmbShiftMachStatus;
        private System.Windows.Forms.Label lblShiftMachStatus;
        private System.Windows.Forms.Label lblToDateMachStatus;
        private System.Windows.Forms.Label lblFromDateMachStatus;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.DateTimePicker dtpToDateMacnHelth;
        private System.Windows.Forms.DateTimePicker dtpFromDateMacnHelth;
        private System.Windows.Forms.ComboBox cmbShiftMacnHelth;
        private System.Windows.Forms.Label lblShiftMacnHelth;
        private System.Windows.Forms.Label lblToDateMacnHelth;
        private System.Windows.Forms.Label lblFromDateMacnHelth;
    }
}