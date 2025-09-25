using System;
using System.Data;
using System.Threading.Tasks;
using System.Web.UI.DataVisualization.Charting;
using System.Windows.Forms;
using ExceptionLib;
using MasterProject.GlobalClass;

namespace UI.UI_Forms
{
    public partial class HomeScreen : Form
    {
        DateTime currentTime = DateTime.Now;

        public static string ShiftLAble;

        

        public HomeScreen()
        {
            InitializeComponent();
            float xRatio = (float)Screen.PrimaryScreen.Bounds.Width / GlobalVariable.OrginalFormWidth;
            float yRatio = (float)Screen.PrimaryScreen.Bounds.Height / GlobalVariable.OrginalFormHeight;
            GlobalVariable.ResizeAllControls(this, xRatio, yRatio);
            ShiftLAble = lblShift.Text;
            LoadCharts();
        }

        //Bug- DEFECT_ID_10-19/06/2025

        /// <summary>
        /// Home load function contain the things which needs to show at the time of form loading
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HomeScreen_Load(object sender, EventArgs e)
        {
            //date.MaxDate = DateTime.Now;
            //date.Value = DateTime.Today;
            //comboShift.SelectedIndex = 0;            
            string shift = GetShift(currentTime);
            lblShift.Text = $" {shift}";
            GlobalVariable.CurrentShift = shift.Trim();

            //GlobalVariable.AlarmTrigger(DIO.DIDO.ECode.Button_Picking_Timeout_Error, true, 0);
            //GlobalVariable.AlarmTrigger(DIO.DIDO.ECode.CCD1_camera_does_not_return_data_after_sending_nozzle_positioning_command, true, 1);
            //GlobalVariable.AlarmTrigger(DIO.DIDO.ECode.Button_Picking_Timeout_Error, true, 1);

        }
        //Bug- DEFECT_ID_10-19/06/2025

        //Bug- DEFECT_ID_11-19/06/2025

        /// <summary>
        /// Function to get shift according to the current time
        /// </summary>
        /// <param name="currentTime"></param>
        /// <returns></returns>
        private string GetShift(DateTime currentTime)
        {
            if (currentTime.Hour >= 0 && currentTime.Hour <= 8)
            {
                return $"A";
            }
            else if (currentTime.Hour >= 8 && currentTime.Hour < 16)
            {
                return $"B";
            }
            else
            {
                return $"C";
            }
        }
        //Bug- DEFECT_ID_11-19/06/2025
       
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                lstRunningLog.DataSource = null;
                lstRunningLog.DataSource = ExceptionLib.Logger.RunningLog_lst;
                Application.DoEvents();

                DataTable table = new DataTable();
                table.Columns.Add("Date And Time", typeof(string));
                table.Columns.Add("Code and Discription", typeof(string));
                if (GlobalVariable.g_bAlarm)
                {
                    DataRow data = table.NewRow();
                    var cellValue = AlarmErrorType.TimeStamp;
                    data[0] = cellValue.ToString();
                    var cellValue1 = AlarmErrorType.Alarm;
                    data[1] = cellValue1.ToString();
                    table.Rows.Add(data);
                }
                dgvAlarmlive.DataSource = table;
                dgvAlarmlive.Columns[0].Width = 150;
                dgvAlarmlive.Columns[1].Width = 1000;
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            //string shift = comboShift.Text;
            //if (comboShift.SelectedIndex > -1)
            //{


            //    if (shift == comboShift.Items[0].ToString())
            //    {
            //        MessageBox.Show("Invalid Shift","HomeScreen", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    }
            //    else
            //    {
            //        labelShift.Text = shift;
            //    }
            //}
            
        }

        //Bug - DEFECT_ID_11 - 19/06/2025
        /// <summary>
        /// while clicking reset button needs to reset  selected fields
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReset_Click(object sender, EventArgs e)
        {
        
            string shift = GetShift(currentTime);
            lblShift.Text = $" {shift}";
            //date.MaxDate = DateTime.Today;
            //date.MinDate = new DateTime(2000, 1, 1); 
            //date.Value = DateTime.Today;
            //comboShift.SelectedIndex = 0;
        }

        private void btnUnitSearch_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void Homing_Click(object sender, EventArgs e)
        {
            try
            {
                MessageBox.Show("No Functionallity Included");
            }
            catch (Exception)
            {
                throw;
            }
        }


        public void LoadCharts()
        {
            //try
            //{
            //    chart1.Series.Clear();
            //    chart1.ChartAreas.Clear();

            //    // Create a chart area
            //    ChartArea chartArea = new ChartArea("MainArea");
            //    chart1.ChartAreas.Add(chartArea);

            //    // Optional: Configure axes (to display blank gridlines or a fixed range)
            //    chartArea.AxisX.Minimum = 0;
            //    chartArea.AxisX.Maximum = 10;
            //    chartArea.AxisY.Minimum = 0;
            //    chartArea.AxisY.Maximum = 10;

            //    // Optional: Customize appearance
            //    chartArea.AxisX.Title = "Hours";
            //    chartArea.AxisY.Title = "Total Count";

            //    // Add an empty series (optional if you want to show legend or axis markers)
            //    Series emptySeries = new Series("Products")
            //    {
            //        ChartType = SeriesChartType.Line,
            //        IsVisibleInLegend = true
            //    };
            //    chart1.Series.Add(emptySeries);
            //}
            //catch (Exception)
            //{

            //    throw;
            //}
        }

        private void lblShift_TextChanged(object sender, EventArgs e)
        {
            ShiftLAble = lblShift.Text;
        }

        //Bug- DEFECT_ID_11-19/06/2025
    }
}
