using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using HelperClassLib;
using MasterProject.GlobalClass;

namespace UI.UI_Forms
{
    public partial class AlarmScreen : Form
    {
        public AlarmScreen()
        {
            InitializeComponent();


            cmbShift.SelectedIndex = 0;
            // Set minimum and maximum allowed dates
            dtpStartDate.MinDate = new DateTime(2000, 1, 1);
            dtpStartDate.MaxDate = DateTime.Today;
            dtpEndDate.MinDate = new DateTime(2000, 1, 1);
            dtpEndDate.MaxDate = DateTime.Today;

            dtpStartDate.Margin = new Padding(0);
            dtpEndDate.Margin = new Padding(0);
            dtpStartDate.Padding = new Padding(0);
            dtpEndDate.Padding = new Padding(0);

            //value change events to ensure start <= end
            dtpStartDate.ValueChanged += Dt_Start_ValueChanged;
            dtpEndDate.ValueChanged += Dt_End_ValueChanged;
            float xRatio = (float)Screen.PrimaryScreen.Bounds.Width / GlobalVariable.OrginalFormWidth;
            float yRatio = (float)Screen.PrimaryScreen.Bounds.Height / GlobalVariable.OrginalFormHeight;
            GlobalVariable.ResizeAllControls(this, xRatio, yRatio);
            cmbShift.SelectedIndex = 0;
        }



        private void Dt_End_ValueChanged(object sender, EventArgs e)
        {
            if (dtpEndDate.Value < dtpStartDate.Value)
            {
                dtpStartDate.Value = dtpEndDate.Value;
            }
        }

        private void Dt_Start_ValueChanged(object sender, EventArgs e)
        {
            if (dtpStartDate.Value > dtpEndDate.Value)
            {
                dtpEndDate.Value = dtpStartDate.Value;
            }
        }

        private void AlarmScreen_ (object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void btnloadAlarm_Click(object sender, EventArgs e)
        {
            try
            {
                loadalarmgrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unexpected error while loading alarm data:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void loadalarmgrid()
        {
            try
            {
                String shift = "";
                if (cmbShift.SelectedItem != null)
                {
                    shift = cmbShift.SelectedItem.ToString();
                }

                if (shift == string.Empty || shift == "Select")
                {
                    MessageBox.Show("Please Select Shift", "Alarm Report", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //cmbShift.Focus();
                    return;
                }

                DateTime start_time = Convert.ToDateTime(StartdateTime.Text);
                DateTime end_time = Convert.ToDateTime(EnddateTime.Text);
                string connString = string.Empty;
                SqlHelper helper = new SqlHelper(connString);

                if (helper.OpenConnection())
                {

                    //string SqlQuery = "select start_time,Error_Code,Error_description from Alarm_error_transactions where start_Time between'" + start_time + "'  and  '" + end_time + "'ORDER BY start_Time ASC";
                    string SqlQuery1 = @"
                    SELECT *
                    FROM ALARM_ERROR_TRANSACTION
                    WHERE SHIFT = @Shift
                    AND START_TIME BETWEEN @StartTime AND @EndTime
                    ORDER BY start_time ASC";

                    string SqlQuery2 = @"
                    SELECT *
                    FROM ALARM_ERROR_TRANSACTION
                    WHERE START_TIME BETWEEN @StartTime AND @EndTime
                    ORDER BY start_time ASC";

                    SqlParameter[] parameters = new SqlParameter[]
                    {
                    new SqlParameter("@Shift", shift),
                    new SqlParameter("@StartTime", start_time),
                    new SqlParameter("@EndTime", end_time)
                    };

                    if (shift == "All")
                    {
                        DataTable dt = helper.GetDataTable(SqlQuery2, CommandType.Text, parameters);
                        if (dt.Rows.Count > 0)
                        {
                            dgvAlramReport.DataSource = dt.DefaultView;
                        }
                        else
                        {
                            dgvAlramReport.DataSource = null;
                            MessageBox.Show("No Data Available", "Alarm Report", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        DataTable dt = helper.GetDataTable(SqlQuery1, CommandType.Text, parameters);
                        if (dt.Rows.Count > 0)
                        {
                            dgvAlramReport.DataSource = dt.DefaultView;
                        }
                        else
                        {
                            dgvAlramReport.DataSource = null;
                            MessageBox.Show("No Data Available", "Alarm Report", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                //Logger.WriteLog(Logger.LogType.Error, "Alarm Report", "", ex.Message, ex.ToString());
                MessageBox.Show("Failed to Load alarm report:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void btnSaveAlarm_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvAlramReport.DataSource != null)
                {

                    DataTable dt = ((DataView)dgvAlramReport.DataSource).Table;
                    if (dt.Rows.Count > 0)
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
                                writeCSV(dt, saveFileDialog1.FileName.ToString());
                            }

                        }));
                        t.SetApartmentState(ApartmentState.STA);
                        t.Start();
                        t.Join();
                    }
                    else
                    {
                        MessageBox.Show("No Data Available", "Alarm Report", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("No Data Available", "Alarm Report", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to save alarm report");
            }
        }

        private void writeCSV(DataTable paramDset, string fileName)
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

        private void btnReset_Click(object sender, EventArgs e)
        {
            try
            {
               
                if (cmbShift.Items.Contains("All"))
                {
                    cmbShift.SelectedItem = "All";
                }
                else if (cmbShift.Items.Count > 0)
                {
                    cmbShift.SelectedIndex = 0;
                }

                // Reset date pickers to today's date
                dtpStartDate.Value = DateTime.Today;
                dtpEndDate.Value = DateTime.Today;

                // Clear the DataGridView
                dgvAlramReport.DataSource = null;

               
                cmbShift.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to reset fields:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void cmbShift_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if(e.KeyChar != (char)Keys.Enter)
            //{
            //    e.Handled = true;
            //}
        }

        private void cmbShift_KeyDown(object sender, KeyEventArgs e)
        {
           // e.SuppressKeyPress = true;
        }
    }
}
