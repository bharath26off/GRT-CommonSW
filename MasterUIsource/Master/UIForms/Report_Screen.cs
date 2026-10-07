using ExceptionLib;
using Master;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Master.UI
{
    public partial class Report : Form
    {
        

        public Report()
        {
            InitializeComponent();
            lblBarCodePrdata.Visible = false;
            txtBarcodePrdata.Visible = false;
            float xRatio = (float)Screen.PrimaryScreen.Bounds.Width / GlobalVariable.OrginalFormWidth;
            float yRatio = (float)Screen.PrimaryScreen.Bounds.Height / GlobalVariable.OrginalFormHeight;
            GlobalVariable.ResizeAllControls(this, xRatio, yRatio);
            dtpFromDatePrdata.MinDate = Convert.ToDateTime("01-01-2000");
            //dtpFromDateMachStatus.MinDate = Convert.ToDateTime("01-01-2000");
            //dtpFromDateMacnHelth.MinDate = Convert.ToDateTime("01-01-2000");
            dtpToDatePrdata.MinDate = Convert.ToDateTime("01-01-2000");
            //dtpToDateMachStatus.MinDate = Convert.ToDateTime("01-01-2000");
            //dtpToDateMacnHelth.MinDate = Convert.ToDateTime("01-01-2000");
            dtpToDatePrdata.MaxDate = Convert.ToDateTime("01-01-2050");
            //dtpToDateMachStatus.MaxDate = Convert.ToDateTime("01-01-2050");
            //dtpToDateMacnHelth.MaxDate = Convert.ToDateTime("01-01-2050");  
            dtpFromDatePrdata.MaxDate = Convert.ToDateTime("01-01-2050");
            //dtpFromDateMachStatus.MaxDate = Convert.ToDateTime("01-01-2050");
            //dtpFromDateMacnHelth.MaxDate = Convert.ToDateTime("01-01-2050");
            dtpFromDatePrdata.Value = DateTime.Today;
            //dtpFromDateMachStatus.Value = DateTime.Today;
            //dtpFromDateMacnHelth.Value = DateTime.Today;
            dtpToDatePrdata.Value = DateTime.Today;
            //    dtpToDateMachStatus.Value = DateTime.Today;
            //    dtpToDateMacnHelth.Value = DateTime.Today;
            lblProductionHeader.Left = (tabProductionReport.ClientSize.Width - lblProductionHeader.Width) / 2;

            dgvProdData.ScrollBars = ScrollBars.Both;

        }
        public string MshHeader = "Production Report";
        private void dtpFromDatePrdata_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                // dtpToDatePrdata.MinDate = dtpFromDatePrdata.Value;
            }
            catch (Exception)
            {
            }
        }

        private void dtpFromDateMachStatus_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dtpFromDateMacnHelth_ValueChanged(object sender, EventArgs e)
        {

        }

        private void btnLoadPrdata_Click(object sender, EventArgs e)
        {
            try
            {
                //String shift = "";
                //if (dtpFromDatePrdata.Value > DateTime.Now.Date || dtpToDatePrdata.Value > DateTime.Now.Date)
                //{
                //    MessageBox.Show("Please Select valid Date", MshHeader, MessageBoxButtons.OK, MessageBoxIcon.Error);
                //    dtpToDatePrdata.Focus();
                //    return;
                //}
                //if (dtpFromDatePrdata.Value.Date > dtpToDatePrdata.Value.Date || dtpToDatePrdata.Value.Date < dtpFromDatePrdata.Value.Date)
                //{
                //    MessageBox.Show("Please Select valid Date", MshHeader, MessageBoxButtons.OK, MessageBoxIcon.Error);
                //    dtpToDatePrdata.Focus();
                //    return;
                //}
                //if (cmbShiftPrdata.SelectedItem != null)
                //{
                //    shift = cmbShiftPrdata.SelectedItem.ToString();
                //}

                //if (shift == string.Empty)
                //{
                //    MessageBox.Show("Please Select Shift", MshHeader, MessageBoxButtons.OK, MessageBoxIcon.Error);
                //    cmbShiftPrdata.Focus();
                //    return;
                //}

                //String BarCode = "";
                //BarCode = txtBarcodePrdata.Text.Trim();

                //if (BarCode == string.Empty || BarCode == "")
                //{
                //    MessageBox.Show("Please Enter Barcode", MshHeader, MessageBoxButtons.OK, MessageBoxIcon.Error);
                //    txtBarcodePrdata.Focus();
                //    return;
                //}
                try
                {
                    string From_Date = dtpFromDatePrdata.Value.ToString("dd_MM_yyyy");
                    string To_Date = dtpToDatePrdata.Value.ToString("dd_MM_yyyy");
                    string ProductionDATAFilePAth = "D:\\TEAL\\.";
                    LoadCsvLogsToGrid(From_Date, To_Date, ProductionDATAFilePAth + @"\Producation_Data\", dgvProdData, cmbShiftPrdata.Text.ToString());
                    dgvProdData.EnableHeadersVisualStyles = false;
                    dgvProdData.ColumnHeadersDefaultCellStyle.BackColor = Color.Beige;
                }
                catch (Exception ex)
                {
                    //Arulkumar Fixed random stoppage start
                    Logger.WriteLog(Logger.LogType.Error, "Report_Screen", "LoadProductionData", ex.Message, ex.ToString());
                    //Arulkumar Fixed random stoppage end
                }

                

            }
            catch (Exception ex)
            {
                //Arulkumar Fixed random stoppage start
                Logger.WriteLog(Logger.LogType.Error, "Report_Screen", "btnLoadPrdata_Click", ex.Message, ex.ToString());
                //Arulkumar Fixed random stoppage end
            }
        }

        public static void LoadCsvLogsToGrid(string fromDateTimeStr, string toDateTimeStr, string folderPath, DataGridView gridView, string shift)
        {
            DateTime fromDateTime;
            DateTime toDateTime;

            // Parse strings to DateTime
            if (!DateTime.TryParseExact(fromDateTimeStr, "dd_MM_yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out fromDateTime) ||
                !DateTime.TryParseExact(toDateTimeStr, "dd_MM_yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out toDateTime))
            {
                MessageBox.Show("Invalid date format. Use dd_MM_yyyy_HH (e.g., 06_09_2025_11)");
                return;
            }

            DataTable resultTable = new DataTable();
            bool columnsLoaded = false;

            if (!Directory.Exists(folderPath))
            {
                MessageBox.Show("Folder path does not exist.");
                return;
            }

            //var files = Directory.GetFiles(folderPath, "*_Log.csv");
            var files = Directory.GetFiles(folderPath, "*.csv");

            foreach (var file in files)
            {
                string fileName = Path.GetFileNameWithoutExtension(file); // e.g., 09_06_2025_12_Log
                string[] parts = fileName.Split('_');

                if (parts.Length >= 3 &&
                    int.TryParse(parts[0], out int day) &&
                    int.TryParse(parts[1], out int month) &&
                    int.TryParse(parts[2], out int year)) //&&
                   // int.TryParse(parts[3], out int hour))
                {
                    // Adjust if filename is MM_DD_YYYY_HH instead of DD_MM_YYYY_HH
                    DateTime fileDateTime = new DateTime(year, month, day, 0, 0, 0);
                    if (shift == "ALL")
                    {
                        if (fileDateTime >= fromDateTime && fileDateTime <= toDateTime)
                        {
                            string[] lines = File.ReadAllLines(file);
                            if (lines.Length == 0) continue;

                            // Load column headers
                            if (!columnsLoaded)
                            {
                                string[] headers = lines[0].Split(',');
                                for (int i = 0; i < headers.Length; i++)
                                {
                                    string header = headers[i].Trim();
                                    if (string.IsNullOrEmpty(header))
                                    {
                                        header = "Column" + i;
                                    }
                                    string colName = header;
                                    int suffix = 1;
                                    while (resultTable.Columns.Contains(colName))
                                    {
                                        colName = header + "_" + suffix.ToString();
                                        suffix++;
                                    }
                                    resultTable.Columns.Add(colName);
                                }
                                columnsLoaded = true;
                            }

                            // Load data rows
                            foreach (string line in lines.Skip(1))
                            {
                                string[] fields = line.TrimEnd(',').Split(',');
                                // Ensure we create a row matching the table's column count
                                object[] rowValues = new object[resultTable.Columns.Count];
                                for (int i = 0; i < resultTable.Columns.Count; i++)
                                {
                                    if (i < fields.Length)
                                    {
                                        rowValues[i] = fields[i];
                                    }
                                    else
                                    {
                                        rowValues[i] = null;
                                    }
                                }
                                resultTable.Rows.Add(rowValues);
                            }
                        }
                    }
                    else
                    {
                        if (fileDateTime >= fromDateTime && fileDateTime <= toDateTime && parts.Length > 4 && parts[4] == shift)
                        {
                            string[] lines = File.ReadAllLines(file);
                            if (lines.Length == 0) continue;

                            // Load column headers
                            if (!columnsLoaded)
                            {
                                string[] headers = lines[0].Split(',');
                                for (int i = 0; i < headers.Length; i++)
                                {
                                    string header = headers[i].Trim();
                                    if (string.IsNullOrEmpty(header))
                                    {
                                        header = "Column" + i;
                                    }
                                    string colName = header;
                                    int suffix = 1;
                                    while (resultTable.Columns.Contains(colName))
                                    {
                                        colName = header + "_" + suffix.ToString();
                                        suffix++;
                                    }
                                    resultTable.Columns.Add(colName);
                                }
                                columnsLoaded = true;
                            }

                            // Load data rows
                            foreach (string line in lines.Skip(1))
                            {
                                string[] fields = line.Split(',');
                                object[] rowValues = new object[resultTable.Columns.Count];
                                for (int i = 0; i < resultTable.Columns.Count; i++)
                                {
                                    if (i < fields.Length)
                                    {
                                        rowValues[i] = fields[i];
                                    }
                                    else
                                    {
                                        rowValues[i] = null;
                                    }
                                }
                                resultTable.Rows.Add(rowValues);
                            }
                        }

                    }
                }
            }

            // Bind to DataGridView
            gridView.DataSource = resultTable;
            if (resultTable.Rows.Count == 0)
            {
                MessageBox.Show("No Data To Display !");
            }

        }


        private void btnSavePrdata_Click(object sender, EventArgs e)
        {

            string From_Date = dtpFromDatePrdata.Value.ToString("dd_MM_yyyy_HH");
            string To_Date = dtpToDatePrdata.Value.ToString("dd_MM_yyyy_HH");
            string ProductionDATAFilePAth = "D:\\TEAL\\";
            SaveProdCsvFromGrid(From_Date, To_Date, ProductionDATAFilePAth + @"\Producation_Data\", dgvProdData, cmbShiftPrdata.Text.ToString());

        }
        public static void SaveProdCsvFromGrid(string fromDateTimeStr, string toDateTimeStr, string folderPath, DataGridView gridView, string shift)
        {

            DateTime fromDateTime;
            DateTime toDateTime;

            // Parse strings to DateTime
            if (!DateTime.TryParseExact(fromDateTimeStr, "dd_MM_yyyy_HH", CultureInfo.InvariantCulture, DateTimeStyles.None, out fromDateTime) ||
                !DateTime.TryParseExact(toDateTimeStr, "dd_MM_yyyy_HH", CultureInfo.InvariantCulture, DateTimeStyles.None, out toDateTime))
            {
                MessageBox.Show("Invalid date format. Use dd_MM_yyyy (e.g., 06_09_2025_11)");
                return;
            }

            DataTable resultTable = new DataTable();
            bool columnsLoaded = false;

            if (!Directory.Exists(folderPath))
            {
                MessageBox.Show("Folder path does not exist.");
                return;
            }

            //var files = Directory.GetFiles(folderPath, "*_Log.csv");
            var files = Directory.GetFiles(folderPath, "*.csv");

            foreach (var file in files)
            {
                string fileName = Path.GetFileNameWithoutExtension(file); // e.g., 09_06_2025_12_Log
                string[] parts = fileName.Split('_');

                if (parts.Length >= 4 &&
                    int.TryParse(parts[0], out int day) &&
                    int.TryParse(parts[1], out int month) &&
                    int.TryParse(parts[2], out int year) &&
                    int.TryParse(parts[3], out int hour))
                {
                    // Adjust if filename is MM_DD_YYYY_HH instead of DD_MM_YYYY_HH
                    DateTime fileDateTime = new DateTime(year, month, day, hour, 0, 0);
                    if (shift == "ALL")
                    {
                        if (fileDateTime >= fromDateTime && fileDateTime <= toDateTime)
                        {
                            string[] lines = File.ReadAllLines(file);
                            if (lines.Length == 0) continue;

                            // Load column headers
                            if (!columnsLoaded)
                            {
                                string[] headers = lines[0].Split(',');
                                foreach (string header in headers)
                                {
                                    resultTable.Columns.Add(header.Trim());
                                }
                                columnsLoaded = true;
                            }

                            // Load data rows
                            foreach (string line in lines.Skip(1))
                            {
                                string[] fields = line.TrimEnd(',').Split(',');
                                if (fields.Length == resultTable.Columns.Count)
                                {
                                    resultTable.Rows.Add(fields);
                                }
                            }
                        }
                    }
                    else
                    {
                        if (fileDateTime >= fromDateTime && fileDateTime <= toDateTime && parts[4] == shift)
                        {
                            string[] lines = File.ReadAllLines(file);
                            if (lines.Length == 0) continue;

                            // Load column headers
                            if (!columnsLoaded)
                            {
                                string[] headers = lines[0].Split(',');
                                foreach (string header in headers)
                                {
                                    resultTable.Columns.Add(header.Trim());
                                }
                                columnsLoaded = true;
                            }

                            // Load data rows
                            foreach (string line in lines.Skip(1))
                            {
                                if (string.IsNullOrWhiteSpace(line)) continue;

                                string[] fields = line.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                                if (fields.Length == resultTable.Columns.Count)
                                {
                                    resultTable.Rows.Add(fields);
                                }
                            }
                        }

                    }
                }
            }



            if (resultTable.Rows.Count > 0 && resultTable.Columns.Count > 0)
            {
                Thread t = new Thread((ThreadStart)(() =>
                {
                    var saveFileDialog1 = new SaveFileDialog();
                    saveFileDialog1.Filter = "csv files (*.csv)|*.csv";
                    saveFileDialog1.Title = "Alarm Report";
                    saveFileDialog1.FilterIndex = 2;
                    saveFileDialog1.ShowDialog();
                    saveFileDialog1.RestoreDirectory = true;
                    if (saveFileDialog1.FileName.Length > 0)
                    {
                        writeCSV(resultTable, saveFileDialog1.FileName.ToString());
                    }

                }));
                t.SetApartmentState(ApartmentState.STA);
                t.Start();
                t.Join();
            }
            else
            {
                MessageBox.Show("No Data Available", "Machine Health Report", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private static void writeCSV(DataTable paramDset, string fileName)
        {
            StreamWriter sw = new StreamWriter(fileName, false);
            for (int i = 0; i < paramDset.Columns.Count; i++)
            {
                sw.Write(paramDset.Columns[i]);
                if (i < paramDset.Columns.Count - 1)
                {
                    sw.Write(",");
                }
            }
            sw.Write(sw.NewLine);
            foreach (DataRow dr in paramDset.Rows)
            {
                for (int i = 0; i < paramDset.Columns.Count; i++)
                {
                    if (!Convert.IsDBNull(dr[i]))
                    {
                        string value = dr[i].ToString();
                        if (value.Contains(','))
                        {
                            value = String.Format("\"{0}\"", value);
                            sw.Write(value);
                        }
                        else
                        {
                            sw.Write(dr[i].ToString());
                        }
                    }
                    if (i < paramDset.Columns.Count - 1)
                    {
                        sw.Write(",");
                    }
                }
                sw.Write(sw.NewLine);
            }
            sw.Close();
        }



        private void btnResetPrdata_Click(object sender, EventArgs e)
        {
            try
            {

                if (cmbShiftPrdata.Items.Contains("All"))
                {
                    cmbShiftPrdata.SelectedItem = "All";
                }
                else if (cmbShiftPrdata.Items.Count > 0)
                {
                    cmbShiftPrdata.SelectedIndex = 0;
                }

                dtpFromDatePrdata.Value = DateTime.Today;
                dtpToDatePrdata.Value = DateTime.Today;
                //**devchange:uncomment this and need to bind data
                dgvProdData.DataSource = new DataTable();
                cmbShiftPrdata.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to reset fields:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLoadMachStatus_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    String shift = "";
            //    if (cmbShiftMachStatus.SelectedItem != null)
            //    {
            //        shift = cmbShiftMachStatus.SelectedItem.ToString();
            //    }

            //    if (shift == string.Empty)
            //    {
            //        MessageBox.Show("Please Select Shift", MshHeader, MessageBoxButtons.OK, MessageBoxIcon.Error);
            //        cmbShiftMachStatus.Focus();
            //        return;
            //    }
            //    MessageBox.Show("No Data Available", MshHeader, MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
            //catch (Exception)
            //{

            //    throw;
            //}
        }

        private void button10_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    String shift = "";
            //    if (cmbShiftMacnHelth.SelectedItem != null)
            //    {
            //        shift = cmbShiftMacnHelth.SelectedItem.ToString();                  
            //    }

            //    if (shift == string.Empty)
            //    {
            //        MessageBox.Show("Please Select Shift", MshHeader, MessageBoxButtons.OK, MessageBoxIcon.Error);
            //        cmbShiftMacnHelth.Focus();
            //        return;
            //    }
            //    MessageBox.Show("No Data Available", MshHeader, MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
            //catch (Exception)
            //{

            //    throw;
            //}
        }


    }
}
