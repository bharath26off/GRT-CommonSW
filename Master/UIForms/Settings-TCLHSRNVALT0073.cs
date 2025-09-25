
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Advantech;
using ExceptionLib;
using HelperClassLib;
using MasterProject.GlobalClass;


namespace UI
{
    public partial class Settings : Form
    {
        public Settings()
        {
            InitializeComponent();
            cmbCCD.SelectedIndex = 0;
            inputState1.InitSource();
            outputState1.InitSource();
            float xRatio = (float)Screen.PrimaryScreen.Bounds.Width / GlobalVariable.OrginalFormWidth;
            float yRatio = (float)Screen.PrimaryScreen.Bounds.Height / GlobalVariable.OrginalFormHeight;
            GlobalVariable.ResizeAllControls(this, xRatio, yRatio);

            txtposition_x1.KeyPress += GlobalVariable.AllowOnlyDecimal_TextBox;
            txtposition_y1.KeyPress += GlobalVariable.AllowOnlyDecimal_TextBox;
            txtpositionz1.KeyPress += GlobalVariable.AllowOnlyDecimal_TextBox;

            txtposition_x2.KeyPress += GlobalVariable.AllowOnlyDecimal_TextBox;
            txtposition_y2.KeyPress += GlobalVariable.AllowOnlyDecimal_TextBox;
            txtposition_Z2.KeyPress += GlobalVariable.AllowOnlyDecimal_TextBox;

            txtstaticposccd1_x.KeyPress += GlobalVariable.AllowOnlyDecimal_TextBox;
            txtstaticposccd1_y.KeyPress += GlobalVariable.AllowOnlyDecimal_TextBox;
            txtstaticposccd1_z.KeyPress += GlobalVariable.AllowOnlyDecimal_TextBox;

            txtspeed.KeyPress += GlobalVariable.AllowOnlyDecimal_TextBox;

            txtCounts.KeyPress += GlobalVariable.AllowOnlyNumber_TextBox;
        }

        string FilePath = Application.StartupPath + @"\Data\Motor_Param.csv";
        DataTable grddt = new DataTable();
        public void Create_Table_grid_data()
        {
            Axis_Config.DataSource = LoadCsvData(FilePath);

            // Apply smaller font size to all columns
            foreach (DataGridViewColumn column in Axis_Config.Columns)
            {
                column.DefaultCellStyle.Font = new Font("Segoe UI", 10); // Adjust size here
            }

            // Optional: reduce header font size as well
            Axis_Config.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 12, FontStyle.Bold);
        }


        string[] csvLines;
        private DataTable LoadCsvData(string filePath)
        {
            DataTable dataTable = new DataTable();
            try
            {
                if (File.Exists(filePath))
                {
                    csvLines = File.ReadAllLines(filePath);

                    if (csvLines.Length > 0)
                    {
                        string[] headers = csvLines[0].Split(',');
                        foreach (string header in headers)
                        {
                            dataTable.Columns.Add(header);

                        }
                        for (int i = 1; i < csvLines.Length; i++)
                        {
                            string[] data = csvLines[i].Split(',');
                            dataTable.Rows.Add(data);
                        }
                        if (dataTable.Columns.Contains("Column1"))
                        {
                            dataTable.Columns.Remove("Column1");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Motor Param File is missing", "Recipe Group Manager Software", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {

            }
            return dataTable;
        }

        private void Settings_Load(object sender, EventArgs e)
        {
            try
            {
                Axis_Config.Enabled = false;
                Create_Table_grid_data();
                cmbShift.SelectedIndex = 0;
                cmbRBTmodeselect.SelectedIndex = 0;
                cmbCCD.SelectedIndex = 0;
                cmbLoadcellMode.SelectedIndex = 0;
                cmbTriggerCmd.SelectedIndex = 0;
                comboScanner.SelectedIndex = 0;
                cmbRoboTrigger.SelectedIndex = 0;
                txtvisioncalib.SelectedIndex = 0;
                cmbCamera.SelectedIndex = 0;
                cmbTestMode.SelectedIndex = 0;
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void btnedit_Click(object sender, EventArgs e)
        {
            try
            {
                Axis_Config.Enabled = true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Write_value_to_CSV(Axis_Config);
            //GlobClass.Write_Parameter_to_Axis();
            Axis_Config.Enabled = false;
        }

        private void Write_value_to_CSV(DataGridView dataGridView1)
        {
            try
            {
                DataTable dt1 = new DataTable();
                int rowCount = dataGridView1.Rows.Count;
                int colCount = dataGridView1.Columns.Count;
                dt1.Columns.Add("Card ID", typeof(string));
                dt1.Columns.Add("ID", typeof(string));
                dt1.Columns.Add("AxisName", typeof(string));
                dt1.Columns.Add("Pitch (mm)", typeof(string));
                dt1.Columns.Add("PPR", typeof(string));
                dt1.Columns.Add("Pulses/mm", typeof(string));
                dt1.Columns.Add("Acc (mm/s2)", typeof(string));
                dt1.Columns.Add("DeAcc (mm/s2)", typeof(string));
                dt1.Columns.Add("AutoSpeed (mm/s)", typeof(string));
                dt1.Columns.Add("ManualSpeed (mm/s)", typeof(string));
                dt1.Columns.Add("HomingSpeed (mm/s)", typeof(string));
                dt1.Columns.Add("Content", typeof(string));
                for (int row = 0; row < 2; row++)
                {
                    DataRow dataRow = dt1.NewRow();
                    for (int col = 0; col < 12; col++)
                    {
                        // Access the cell value
                        var cellValue = dataGridView1.Rows[row].Cells[col].Value;

                        if (cellValue != null)
                            dataRow[col] = cellValue.ToString();
                        else
                            dataRow[col] = "";
                    }
                    dt1.Rows.Add(dataRow);
                }
                if (dt1.Rows.Count > 0)
                {
                    WriteDataTableToCsv(dt1, FilePath);
                    GlobalVariable.DIDO.AxisLoad(); //Doubt
                    MessageBox.Show("Data has been saved successfully.", "Recipe Group Manager Software", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //Fill_Model_Info("");

                }
            }
            catch (Exception ex)
            {

            }
        }
        static void WriteDataTableToCsv(DataTable dataTable, string filePath)
        {
            try
            {
                // Create a StreamWriter to write to the CSV file
                if (File.Exists(filePath))
                {
                    using (StreamWriter writer = new StreamWriter(filePath))
                    {
                        // Write the column headers
                        foreach (DataColumn column in dataTable.Columns)
                        {
                            writer.Write(column.ColumnName);
                            writer.Write(",");
                        }
                        writer.WriteLine();

                        // Write the rows
                        foreach (DataRow row in dataTable.Rows)
                        {
                            foreach (var item in row.ItemArray)
                            {
                                writer.Write(item);
                                writer.Write(",");
                            }
                            writer.WriteLine();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Motor Param File is missing", "Recipe Group Manager Software", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {

            }
        }
       
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) &&
                !char.IsDigit(e.KeyChar) &&
                (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void richTextBox3_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void btnLoadCell_Start_Click(object sender, EventArgs e)
        {
            string mode= cmbLoadcellMode.Text;
            var index = cmbLoadcellMode.Items[0].ToString();
            if (mode == index)
            {
                MessageBox.Show("select the caliberation mode ");
            }
        }

        private void ChkdCCD1_CheckedChanged(object sender, EventArgs e)
        {
            //if (ChkdCCD1.Checked)
            //{
            //    label9.Text = " CCD1";
            //}

            //else
            //{
            //    label9.Text = "";
            //}
        }

        private void ChkdCCD5_CheckedChanged(object sender, EventArgs e)
        {
            //if (ChkdCCD5.Checked)
            //{
            //    label9.Text = " CCD5";
            //}


            //else
            //{
            //    label9.Text = "";
            //}
        }

        private void btnEditGeneral_Click(object sender, EventArgs e)
        {
            
            if (cmbShift.SelectedIndex == -1|| !dtpStartTime.Checked || !dtpStartTime.Checked)
            {
                MessageBox.Show("please fill the data");
            }
            cmbShift.Enabled = true;
            dtpEndTime.Enabled = true;  
            dtpStartTime.Enabled = true;    
        }

        private void btnSaveGeneral_Click(object sender, EventArgs e)
        {
            if (cmbShift.SelectedIndex == -1 || !dtpStartTime.Checked || !dtpStartTime.Checked)
            {
                MessageBox.Show("please fill the data");
            }
            cmbShift.Enabled = false;
            dtpEndTime.Enabled = false;
            dtpStartTime.Enabled = false;
        }

        private void cmbShift_DrawItem(object sender, DrawItemEventArgs e)
        {
            ComboBox cb = sender as ComboBox;
            e.DrawBackground();

            string text = string.Empty;
            Brush brush = SystemBrushes.WindowText; // Default system text color

            if (e.Index >= 0)
            {
                text = cb.Items[e.Index].ToString();
                brush = new SolidBrush(cb.ForeColor); // Keep default color
            }
            else if (cb.SelectedIndex == -1 )
            {
                text = "-- SELECT MODE --";
                brush = Brushes.White; // Placeholder in white
            }

            StringFormat sf = new StringFormat
            {
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center
            };

            e.Graphics.DrawString(text, cb.Font, brush, e.Bounds, sf);
            e.DrawFocusRectangle();
        }

        private void btnEditSettings_Click(object sender, EventArgs e)
        {
            try
            {
                dryrun.Enabled = false;
                productionmode.Enabled = false;
                onlinemode.Enabled = false;
                offlinemode.Enabled = false;
                scannerbypass.Enabled = false;
                safetydoorbypass.Enabled = false;
                SFCbypass.Enabled = false;
                PDCAbypass.Enabled = false;
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void btnSaveSettings_Click(object sender, EventArgs e)
        {
            try
            {
                dryrun.Enabled = true;
                productionmode.Enabled = true;
                onlinemode.Enabled = true;
                offlinemode.Enabled = true;
                scannerbypass.Enabled = true;
                safetydoorbypass.Enabled = true;
                SFCbypass.Enabled = true;
                PDCAbypass.Enabled = true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void btnccd1Browse_Click(object sender, EventArgs e)
        {
            try
            {
                try
                {
                    using (FolderBrowserDialog Fbd = new FolderBrowserDialog())
                    {
                        Fbd.Description = "Select a folder";
                        if (Fbd.ShowDialog() == DialogResult.OK)
                        {
                            txtccd1path.Text = Fbd.SelectedPath;
                        }
                    }
                }
                catch (Exception)
                {

                    throw;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void cmbTestMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmbTestMode.Text == "Static")
                {
                    txtstaticposccd1_x.Enabled = true;
                    txtstaticposccd1_y.Enabled = true;
                    txtstaticposccd1_z.Enabled = true;

                    txtposition_x1.Enabled = false;
                    txtposition_y1.Enabled = false;
                    txtpositionz1.Enabled = false;
                    txtposition_x2.Enabled = false;
                    txtposition_y2.Enabled = false;
                    txtposition_Z2.Enabled = false;
                }
                else
                {
                    txtstaticposccd1_x.Enabled = false;
                    txtstaticposccd1_y.Enabled = false;
                    txtstaticposccd1_z.Enabled = false;

                    txtposition_x1.Enabled = true;
                    txtposition_y1.Enabled = true;
                    txtpositionz1.Enabled = true;
                    txtposition_x2.Enabled = true;
                    txtposition_y2.Enabled = true;
                    txtposition_Z2.Enabled = true;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void btnCCD_start_Click(object sender, EventArgs e)
        {
            try
            {

                if (cmbTestMode.Text == "Static")
                {

                    if (txtstaticposccd1_x.Text.Trim() == "")
                    {
                        MessageBox.Show("Please Enter X position");
                        txtstaticposccd1_x.Focus();
                        return;
                    }
                    if (txtstaticposccd1_y.Text.Trim() == "")
                    {
                        MessageBox.Show("Please Enter Y position");
                        txtstaticposccd1_y.Focus();
                        return;
                    }
                    if (txtstaticposccd1_z.Text.Trim() == "")
                    {
                        MessageBox.Show("Please Enter Z position");
                        txtstaticposccd1_z.Focus();
                        return;
                    }

                    if (txtspeed.Text.Trim() == "")
                    {
                        MessageBox.Show("Please Enter Speed");
                        txtCounts.Focus();
                        return;
                    }

                    if (txtCounts.Text.Trim() == "")
                    {
                        MessageBox.Show("Please Enter count");
                        txtCounts.Focus();
                        return;
                    }
                    if (txtccd1path.Text.Trim() == "")
                    {
                        MessageBox.Show("Please Select CSV path");
                        txtccd1path.Focus();
                        return;
                    }
                    //VisionCalibration.csv_path = txtccd1path.Text;
                    //VisionCalibration.Instance.start_Thread_Static_calib(txtCounts.Text, txtstaticposccd1_x.Text, txtstaticposccd1_y.Text, txtstaticposccd1_z.Text, txtspeed.Text);
                }
                else
                {
                    if (txtposition_x1.Text.Trim() == "")
                    {
                        MessageBox.Show("Please Enter X1 position");
                        txtposition_x1.Focus();
                        return;
                    }
                    if (txtposition_y1.Text.Trim() == "")
                    {
                        MessageBox.Show("Please Enter Y1 position");
                        txtposition_y1.Focus();
                        return;
                    }
                    if (txtpositionz1.Text.Trim() == "")
                    {
                        MessageBox.Show("Please Enter Z1 position");
                        txtpositionz1.Focus();
                        return;
                    }
                    if (txtposition_x2.Text.Trim() == "")
                    {
                        MessageBox.Show("Please Enter X2 position");
                        txtposition_x2.Focus();
                        return;
                    }
                    if (txtposition_y2.Text.Trim() == "")
                    {
                        MessageBox.Show("Please Enter Y2 position");
                        txtposition_y2.Focus();
                        return;
                    }
                    if (txtposition_Z2.Text.Trim() == "")
                    {
                        MessageBox.Show("Please Enter Z2 position");
                        txtposition_Z2.Focus();
                        return;
                    }

                    if (txtspeed.Text.Trim() == "")
                    {
                        MessageBox.Show("Please Enter Speed");
                        txtCounts.Focus();
                        return;
                    }


                    if (txtCounts.Text.Trim() == "")
                    {
                        MessageBox.Show("Please Enter count");
                        txtCounts.Focus();
                        return;
                    }
                    if (txtccd1path.Text.Trim() == "")
                    {
                        MessageBox.Show("Please Select CSV path");
                        txtccd1path.Focus();
                        return;
                    }
                    //VisionCalibration.csv_path = txtccd1path.Text;
                    //VisionCalibration.Instance.start_Thread_Dynamic_calib(txtCounts.Text, txtposition_x1.Text, txtposition_y1.Text, txtpositionz1.Text, txtposition_x2.Text, txtposition_y2.Text, txtposition_Z2.Text, txtspeed.Text);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }        
    }
}
