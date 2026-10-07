using DIO;
using DynamicVacuums;
using ExceptionLib;
using ExceptionLib;
using GRT_BG1.Data;
using GRT_BG1.Function.Calibration;
using GRT_BG1.Function.Classes;
using GRT_BG1.Function.DryRun;
using GRT_BG1.Function.Interface;
using GRT_BG1_V54.Function.CommonClass;
using Master;
using Program;
using StreamlineProcess.BaseClass;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web.UI.DataVisualization.Charting;
using System.Windows.Forms;
using System.Xml.Linq;
using static DIO.DIDO;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace UI.UI_Forms
{
    public partial class HomeScreen : Form
    {
        DateTime currentTime = DateTime.Now;

        public static string ShiftLAble;

        public string Teach_filepath = Environment.CurrentDirectory + @"\Data\";

        private static int[] List_precheck = new int[15];
        public static event Action clearwk1cavity;
        public static event Action clearwk2cavity;
        public static event Action clearcavity;
        private bool pause = false; // AK

        // track how many running log entries we have already saved to disk
        private int _runningLogSavedCount = 0;

        // track last saved alarm count to avoid repeated saves
        private int _lastAlarmSavedCount = -1;
        private bool _suppressOffsetTabChange = false;

        Image signal_on = Image.FromFile(@"ICO\signal_on.png");
        Image signal_off = Image.FromFile(@"ICO\signal_off.png");

        //List<string> logbuffer = new List<string>();//mk

        public HomeScreen()
        {

            InitializeComponent();
            float xRatio = (float)Screen.PrimaryScreen.Bounds.Width / GlobalVariable.OrginalFormWidth;
            float yRatio = (float)Screen.PrimaryScreen.Bounds.Height / GlobalVariable.OrginalFormHeight;
            GlobalVariable.ResizeAllControls(this, xRatio, yRatio);
            ShiftLAble = lblShift.Text;
            label2.Left = (pnlMachineHealth.ClientSize.Width - label2.Width) / 2;
            label4.Left = (pnlMachineStatus.ClientSize.Width - label4.Width) / 2;
            label1.Left = (panel1.ClientSize.Width - label1.Width) / 2;
            LoadingConveyor.updatecavity -= udateCavity;
            WorkingConveyor1.updatecavity -= udatewk1Cavity;
            WorkingConveyor2.updatecavity -= udatewk2Cavity;
            LoadingConveyor.clearcavity -= clearCavity;
            WorkingConveyor1.clearwk1cavity -= clearwk1Cavity;
            WorkingConveyor2.clearwk2cavity -= clearwk2Cavity;
            LoadingConveyor.updatecavity += udateCavity;
            WorkingConveyor1.updatecavity += udatewk1Cavity;
            WorkingConveyor2.updatecavity += udatewk2Cavity;
            LoadingConveyor.clearcavity += clearCavity;
            WorkingConveyor1.clearwk1cavity += clearwk1Cavity;
            WorkingConveyor2.clearwk2cavity += clearwk2Cavity;
            updateResult();
            ProductionDataSaver.Finalupdatehm += udateFinalresult;
            DryRunDataSaver.Finalupdatehm += udateFinalresult;
            ProductionDataSaver.Finalclear += ClearRows;
            DryRunDataSaver.Finalclear += ClearRows;





            //GlobalVariable.X_LSL = double.Parse(label19.Text);
            //GlobalVariable.Y_LSL = double.Parse(label30.Text);
            //GlobalVariable.A_LSl = double.Parse(label35.Text);
            //GlobalVariable.X_USL = double.Parse(label33.Text);
            //GlobalVariable.Y_USL = double.Parse(label34.Text);
            //GlobalVariable.A_USl = double.Parse(label37.Text);
            //GlobalVariable.F_USl = double.Parse(label38.Text);
            //GlobalVariable.F_LSl = double.Parse(label36.Text);


            button14.Enabled = false;
            button12.Enabled = false;
            button13.Enabled = false;
            button3.Enabled = false;

            textBox25.Enabled = false;
            textBox8.Enabled = false;
            textBox11.Enabled = false;
            textBox12.Enabled = false;
            textBox13.Enabled = false;
            textBox16.Enabled = false;
            textBox17.Enabled = false;

            textBox23.Enabled = false;
            textBox2.Enabled = false;
            textBox3.Enabled = false;
            textBox4.Enabled = false;
            textBox5.Enabled = false;
            textBox6.Enabled = false;
            textBox7.Enabled = false;
            //OfflinewithoutSFC.Enabled = false;
            //OnlinewithoutSFC.Enabled = false;

            savebtn_offset.Enabled = true;
            editbtn_offset.Enabled = true;

            savebtn_offsetK.Enabled = true;
            editbtn_offsetK.Enabled = true;

            savebtn_offsetNk.Enabled = true;
            editbtn_offsetNk.Enabled = true;

            editbtn_feeder.Enabled = true;
            savebtn_feeder.Enabled = true;

            SFC_Edit.Enabled = true;
            SFC_Save.Enabled = true;

            editbtn_AE.Enabled = true;
            savebtn_AE.Enabled = true;


            editbtn_delay.Enabled = true;
            savebtn_delay.Enabled = true;

            #region CONNECTION STATUS GRID
            conectionStatusGrid.AutoGenerateColumns = true; // or add manually
            conectionStatusGrid.DataSource = RefreshConnectionStatus();
            conectionStatusGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // GRID CUSTOMIZE
            conectionStatusGrid.Columns[0].FillWeight = 30; // 30%
            conectionStatusGrid.Columns[1].FillWeight = 50; // 50%
            conectionStatusGrid.Columns[2].FillWeight = 20; // 20%

            // Optional: ensure Status column is image column
            if (conectionStatusGrid.Columns["Status"] is DataGridViewImageColumn col)
            {
                col.ImageLayout = DataGridViewImageCellLayout.Zoom;
            }

            conectionStatusGrid.DefaultCellStyle.SelectionBackColor = conectionStatusGrid.DefaultCellStyle.BackColor;
            conectionStatusGrid.DefaultCellStyle.SelectionForeColor = conectionStatusGrid.DefaultCellStyle.ForeColor;
            #endregion

            //ofset value
            try
            {
                string filePath = Path.Combine(Teach_filepath, "OFFSET.csv");
                DataTable dt = HelperClassLib.GetDataFromHelper.GetDataFromCSV(filePath);

                // ✅ Bind data to grid
                dgv_offset.DataSource = dt;
            }
            catch (Exception) { }

            //ofsetK value
            try
            {
                string filePath = Path.Combine(Teach_filepath, "OFFSETK.csv");
                DataTable dt = HelperClassLib.GetDataFromHelper.GetDataFromCSV(filePath);

                // ✅ Bind data to grid
                dgv_offsetK.DataSource = dt;
            }
            catch (Exception) { }


            //Nk Offset value
            try
            {
                string filePath = Path.Combine(Teach_filepath, "OFFSETNK.csv");
                DataTable dt = HelperClassLib.GetDataFromHelper.GetDataFromCSV(filePath);

                // ✅ Bind data to grid
                dgv_offsetNk.DataSource = dt;
            }
            catch (Exception) { }

            //AEPARAMETER
            try
            {
                string filePath = Path.Combine(Teach_filepath, "AEPARAMETER.csv");
                DataTable dt = HelperClassLib.GetDataFromHelper.GetDataFromCSV(filePath);

                // ✅ Bind data to grid
                dgv_AE.DataSource = dt;
            }
            catch (Exception) { }

            //Delay value
            try
            {
                string filePath = Path.Combine(Teach_filepath, "DELAY.csv");
                DataTable dt = HelperClassLib.GetDataFromHelper.GetDataFromCSV(filePath);

                // ✅ Bind data to grid
                dgv_delay.DataSource = dt;
            }
            catch (Exception) { }

            //SFC_PDCA_Data
            try
            {
                string filePath = Path.Combine(Teach_filepath, "SFC_PDCA_Data.csv");
                DataTable dt = HelperClassLib.GetDataFromHelper.GetDataFromCSV(filePath);

                // ✅ Bind data to grid
                SFCGridview.DataSource = dt;
            }
            catch (Exception) { }

            //Max_Min
            try
            {
                string filePath = Path.Combine(Teach_filepath, "Feeder_Min_Max.csv");
                DataTable dt = HelperClassLib.GetDataFromHelper.GetDataFromCSV(filePath);

                // ✅ Bind data to grid
                dgv_Feeder_Min_Max.DataSource = dt;
            }
            catch (Exception) { }

            ApplyNkOffsetTabs();
        }


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
            Sequence_initialize();
            passScanner();
            passwkc1();
            passwkc2();
            UpdateMachineStatusLabels();
            ApplyNkOffsetTabs();

            if (GlobalVariable.CavityRows == 3 && GlobalVariable.CavityCols == 4)
            {
                panel7_4.Visible = false;
                panel7.Visible = true;
            }
            else if (GlobalVariable.CavityRows == 4 && GlobalVariable.CavityCols == 3)
            {
                panel7.Visible = false;
                panel7_4.Visible = true;
            }



            GlobalVariable.X_LSL = GlobalVariable.AEParameters[0].LSL;
            GlobalVariable.Y_LSL = GlobalVariable.AEParameters[1].LSL;
            GlobalVariable.A_LSl = GlobalVariable.AEParameters[2].LSL;
            GlobalVariable.F_LSl = GlobalVariable.AEParameters[3].LSL;

            GlobalVariable.Servo_Y1_Min_N1 = GlobalVariable.Feeder_MinMax[0].Y1_Min;
            GlobalVariable.Servo_X1_Min_N1 = GlobalVariable.Feeder_MinMax[0].X1_Min;
            GlobalVariable.Servo_X1_Max_N1 = GlobalVariable.Feeder_MinMax[0].X1_Max;

            GlobalVariable.Servo_Y1_Min_N2 = GlobalVariable.Feeder_MinMax[1].Y1_Min;
            GlobalVariable.Servo_X1_Max_N2 = GlobalVariable.Feeder_MinMax[1].X1_Min;
            GlobalVariable.Servo_X1_Max_N2 = GlobalVariable.Feeder_MinMax[1].X1_Max;

            GlobalVariable.X_USL = GlobalVariable.AEParameters[0].USL;
            GlobalVariable.Y_USL = GlobalVariable.AEParameters[1].USL;
            GlobalVariable.A_USl = GlobalVariable.AEParameters[2].USL;
            GlobalVariable.F_USl = GlobalVariable.AEParameters[3].USL;

            GlobalVariable.Z_Delay = (int)GlobalVariable.delay[0].Delay;
            GlobalVariable.Scanning_Exit_Sens_Delay = (int)GlobalVariable.delay[1].Delay;
            GlobalVariable.Working_Conv_1_Exit_Sens_Delay = (int)GlobalVariable.delay[2].Delay;
            GlobalVariable.Working_Conv_2_Exit_Sens_Delay = (int)GlobalVariable.delay[3].Delay;
            GlobalVariable.Stopper_loader_Time = (int)GlobalVariable.delay[4].Delay;
            GlobalVariable.Stopper_Working_Time = (int)GlobalVariable.delay[5].Delay;
            GlobalVariable.Stopper_Recheck_Time = (int)GlobalVariable.delay[6].Delay;
            GlobalVariable.Barcode_Scanner_Recevier_Delay = (int)GlobalVariable.delay[7].Delay;

            GlobalVariable.StationID = GlobalVariable.SFC_PDCA_Data[0].Station_Id;

        }
        public void passScanner()
        {
            if (GlobalVariable.CavityRows == 3 && GlobalVariable.CavityCols == 4)
            {
                if (GlobalVariable.cavitynum[List_precheck[0]] != null)
                {
                    CARRIER_SN.Text = GlobalVariable.cavitynum[List_precheck[0]];
                    //lblSC_1.BackColor = cavitynumcon[List_precheck[1]] ? Color.Yellow : Color.Red;
                }
                if (GlobalVariable.cavitynum[List_precheck[1]] != null)
                {
                    lblSC_1.Text = GlobalVariable.cavitynum[List_precheck[1]];
                    lblSC_1.BackColor = GlobalVariable.cavitynumcon[List_precheck[1]] ? Color.Yellow : Color.Red;
                }
                if (GlobalVariable.cavitynum[List_precheck[2]] != null)
                {
                    lblSC_2.Text = GlobalVariable.cavitynum[List_precheck[2]];
                    lblSC_2.BackColor = GlobalVariable.cavitynumcon[List_precheck[2]] ? Color.Yellow : Color.Red;
                }
                if (GlobalVariable.cavitynum[List_precheck[3]] != null)
                {
                    lblSC_3.Text = GlobalVariable.cavitynum[List_precheck[3]];
                    lblSC_3.BackColor = GlobalVariable.cavitynumcon[List_precheck[3]] ? Color.Yellow : Color.Red;
                }
                if (GlobalVariable.cavitynum[List_precheck[4]] != null)
                {
                    lblSC_4.Text = GlobalVariable.cavitynum[List_precheck[4]];
                    lblSC_4.BackColor = GlobalVariable.cavitynumcon[List_precheck[4]] ? Color.Yellow : Color.Red;
                }
                if (GlobalVariable.cavitynum[List_precheck[5]] != null)
                {
                    lblSC_5.Text = GlobalVariable.cavitynum[List_precheck[5]];
                    lblSC_5.BackColor = GlobalVariable.cavitynumcon[List_precheck[5]] ? Color.Yellow : Color.Red;
                }
                if (GlobalVariable.cavitynum[List_precheck[6]] != null)
                {
                    lblSC_6.Text = GlobalVariable.cavitynum[List_precheck[6]];
                    lblSC_6.BackColor = GlobalVariable.cavitynumcon[List_precheck[6]] ? Color.Yellow : Color.Red;
                }
                if (GlobalVariable.cavitynum[List_precheck[7]] != null)
                {
                    lblSC_7.Text = GlobalVariable.cavitynum[List_precheck[7]];
                    lblSC_7.BackColor = GlobalVariable.cavitynumcon[List_precheck[7]] ? Color.Yellow : Color.Red;
                }
                if (GlobalVariable.cavitynum[List_precheck[8]] != null)
                {
                    lblSC_8.Text = GlobalVariable.cavitynum[List_precheck[8]];
                    lblSC_8.BackColor = GlobalVariable.cavitynumcon[List_precheck[8]] ? Color.Yellow : Color.Red;
                }
                if (GlobalVariable.cavitynum[List_precheck[9]] != null)
                {
                    lblSC_9.Text = GlobalVariable.cavitynum[List_precheck[9]];
                    lblSC_9.BackColor = GlobalVariable.cavitynumcon[List_precheck[9]] ? Color.Yellow : Color.Red;
                }
                if (GlobalVariable.cavitynum[List_precheck[10]] != null)
                {
                    lblSC_10.Text = GlobalVariable.cavitynum[List_precheck[10]];
                    lblSC_10.BackColor = GlobalVariable.cavitynumcon[List_precheck[10]] ? Color.Yellow : Color.Red;
                }
                if (GlobalVariable.cavitynum[List_precheck[11]] != null)
                {
                    lblSC_11.Text = GlobalVariable.cavitynum[List_precheck[11]];
                    lblSC_11.BackColor = GlobalVariable.cavitynumcon[List_precheck[11]] ? Color.Yellow : Color.Red;
                }
                if (GlobalVariable.cavitynum[List_precheck[12]] != null)
                {
                    lblSC_12.Text = GlobalVariable.cavitynum[List_precheck[12]];
                    lblSC_12.BackColor = GlobalVariable.cavitynumcon[List_precheck[12]] ? Color.Yellow : Color.Red;
                }
            }
            else if (GlobalVariable.CavityRows == 4 && GlobalVariable.CavityCols == 3)
            {
                if (GlobalVariable.cavitynum[List_precheck[0]] != null)
                {
                    CARRIER_SN_4.Text = GlobalVariable.cavitynum[List_precheck[0]];
                    //lblSC_1.BackColor = cavitynumcon[List_precheck[1]] ? Color.Yellow : Color.Red;
                }
                if (GlobalVariable.cavitynum[List_precheck[1]] != null)
                {
                    lblSC_1_4.Text = GlobalVariable.cavitynum[List_precheck[1]];
                    lblSC_1_4.BackColor = GlobalVariable.cavitynumcon[List_precheck[1]] ? Color.Yellow : Color.Red;
                }
                if (GlobalVariable.cavitynum[List_precheck[2]] != null)
                {
                    lblSC_2_4.Text = GlobalVariable.cavitynum[List_precheck[2]];
                    lblSC_2_4.BackColor = GlobalVariable.cavitynumcon[List_precheck[2]] ? Color.Yellow : Color.Red;
                }
                if (GlobalVariable.cavitynum[List_precheck[3]] != null)
                {
                    lblSC_3_4.Text = GlobalVariable.cavitynum[List_precheck[3]];
                    lblSC_3_4.BackColor = GlobalVariable.cavitynumcon[List_precheck[3]] ? Color.Yellow : Color.Red;
                }
                if (GlobalVariable.cavitynum[List_precheck[4]] != null)
                {
                    lblSC_4_4.Text = GlobalVariable.cavitynum[List_precheck[4]];
                    lblSC_4_4.BackColor = GlobalVariable.cavitynumcon[List_precheck[4]] ? Color.Yellow : Color.Red;
                }
                if (GlobalVariable.cavitynum[List_precheck[5]] != null)
                {
                    lblSC_5_4.Text = GlobalVariable.cavitynum[List_precheck[5]];
                    lblSC_5_4.BackColor = GlobalVariable.cavitynumcon[List_precheck[5]] ? Color.Yellow : Color.Red;
                }
                if (GlobalVariable.cavitynum[List_precheck[6]] != null)
                {
                    lblSC_6_4.Text = GlobalVariable.cavitynum[List_precheck[6]];
                    lblSC_6_4.BackColor = GlobalVariable.cavitynumcon[List_precheck[6]] ? Color.Yellow : Color.Red;
                }
                if (GlobalVariable.cavitynum[List_precheck[7]] != null)
                {
                    lblSC_7_4.Text = GlobalVariable.cavitynum[List_precheck[7]];
                    lblSC_7_4.BackColor = GlobalVariable.cavitynumcon[List_precheck[7]] ? Color.Yellow : Color.Red;
                }
                if (GlobalVariable.cavitynum[List_precheck[8]] != null)
                {
                    lblSC_8_4.Text = GlobalVariable.cavitynum[List_precheck[8]];
                    lblSC_8_4.BackColor = GlobalVariable.cavitynumcon[List_precheck[8]] ? Color.Yellow : Color.Red;
                }
                if (GlobalVariable.cavitynum[List_precheck[9]] != null)
                {
                    lblSC_9_4.Text = GlobalVariable.cavitynum[List_precheck[9]];
                    lblSC_9_4.BackColor = GlobalVariable.cavitynumcon[List_precheck[9]] ? Color.Yellow : Color.Red;
                }
                if (GlobalVariable.cavitynum[List_precheck[10]] != null)
                {
                    lblSC_10_4.Text = GlobalVariable.cavitynum[List_precheck[10]];
                    lblSC_10_4.BackColor = GlobalVariable.cavitynumcon[List_precheck[10]] ? Color.Yellow : Color.Red;
                }
                if (GlobalVariable.cavitynum[List_precheck[11]] != null)
                {
                    lblSC_11_4.Text = GlobalVariable.cavitynum[List_precheck[11]];
                    lblSC_11_4.BackColor = GlobalVariable.cavitynumcon[List_precheck[11]] ? Color.Yellow : Color.Red;
                }
                if (GlobalVariable.cavitynum[List_precheck[12]] != null)
                {
                    lblSC_12_4.Text = GlobalVariable.cavitynum[List_precheck[12]];
                    lblSC_12_4.BackColor = GlobalVariable.cavitynumcon[List_precheck[12]] ? Color.Yellow : Color.Red;
                }
            }


        }
        public void passwkc1()
        {
            if (GlobalVariable.CavityRows == 3 && GlobalVariable.CavityCols == 4)
            {
                if (GlobalVariable.cavitynumwkt1[List_precheck[0]] != null)
                {
                    BN_wk1.Text = GlobalVariable.cavitynumwkt1[List_precheck[0]];
                    //lblSC_1.BackColor = cavitynumcon[List_precheck[1]] ? Color.Yellow : Color.Red;
                }
                if (GlobalVariable.cavitynumwkt1[List_precheck[1]] != null)
                {
                    lblAS_1.BackColor = GlobalVariable.cavitynumwkt1con[List_precheck[1]] == 1 ? Color.Yellow : (GlobalVariable.cavitynumwkt1con[List_precheck[1]] == 2 ? Color.Red : GlobalVariable.cavitynumwkt1con[List_precheck[1]] == 3 ? Color.Green : Color.DarkGray);
                    lblAS_1.Text = GlobalVariable.cavitynumwkt1[List_precheck[1]];
                }
                if (GlobalVariable.cavitynumwkt1[List_precheck[2]] != null)
                {
                    lblAS_2.BackColor = GlobalVariable.cavitynumwkt1con[List_precheck[2]] == 1 ? Color.Yellow : (GlobalVariable.cavitynumwkt1con[List_precheck[2]] == 2 ? Color.Red : GlobalVariable.cavitynumwkt1con[List_precheck[2]] == 3 ? Color.Green : Color.DarkGray);
                    lblAS_2.Text = GlobalVariable.cavitynumwkt1[List_precheck[2]];
                }
                if (GlobalVariable.cavitynumwkt1[List_precheck[3]] != null)
                {
                    lblAS_3.BackColor = GlobalVariable.cavitynumwkt1con[List_precheck[3]] == 1 ? Color.Yellow : (GlobalVariable.cavitynumwkt1con[List_precheck[3]] == 2 ? Color.Red : GlobalVariable.cavitynumwkt1con[List_precheck[3]] == 3 ? Color.Green : Color.DarkGray);
                    lblAS_3.Text = GlobalVariable.cavitynumwkt1[List_precheck[3]];
                }
                if (GlobalVariable.cavitynumwkt1[List_precheck[4]] != null)
                {
                    lblAS_4.BackColor = GlobalVariable.cavitynumwkt1con[List_precheck[4]] == 1 ? Color.Yellow : (GlobalVariable.cavitynumwkt1con[List_precheck[4]] == 2 ? Color.Red : GlobalVariable.cavitynumwkt1con[List_precheck[4]] == 3 ? Color.Green : Color.DarkGray);
                    lblAS_4.Text = GlobalVariable.cavitynumwkt1[List_precheck[4]];
                }
                if (GlobalVariable.cavitynumwkt1[List_precheck[5]] != null)
                {
                    lblAS_5.BackColor = GlobalVariable.cavitynumwkt1con[List_precheck[5]] == 1 ? Color.Yellow : (GlobalVariable.cavitynumwkt1con[List_precheck[5]] == 2 ? Color.Red : GlobalVariable.cavitynumwkt1con[List_precheck[5]] == 3 ? Color.Green : Color.DarkGray);
                    lblAS_5.Text = GlobalVariable.cavitynumwkt1[List_precheck[5]];
                }
                if (GlobalVariable.cavitynumwkt1[List_precheck[6]] != null)
                {
                    lblAS_6.BackColor = GlobalVariable.cavitynumwkt1con[List_precheck[6]] == 1 ? Color.Yellow : (GlobalVariable.cavitynumwkt1con[List_precheck[6]] == 2 ? Color.Red : GlobalVariable.cavitynumwkt1con[List_precheck[6]] == 3 ? Color.Green : Color.DarkGray);
                    lblAS_6.Text = GlobalVariable.cavitynumwkt1[List_precheck[6]];
                }
                if (GlobalVariable.cavitynumwkt1[List_precheck[7]] != null)
                {
                    lblAS_7.BackColor = GlobalVariable.cavitynumwkt1con[List_precheck[7]] == 1 ? Color.Yellow : (GlobalVariable.cavitynumwkt1con[List_precheck[7]] == 2 ? Color.Red : GlobalVariable.cavitynumwkt1con[List_precheck[7]] == 3 ? Color.Green : Color.DarkGray);
                    lblAS_7.Text = GlobalVariable.cavitynumwkt1[List_precheck[7]];
                }
                if (GlobalVariable.cavitynumwkt1[List_precheck[8]] != null)
                {
                    lblAS_8.BackColor = GlobalVariable.cavitynumwkt1con[List_precheck[8]] == 1 ? Color.Yellow : (GlobalVariable.cavitynumwkt1con[List_precheck[8]] == 2 ? Color.Red : GlobalVariable.cavitynumwkt1con[List_precheck[8]] == 3 ? Color.Green : Color.DarkGray);
                    lblAS_8.Text = GlobalVariable.cavitynumwkt1[List_precheck[8]];
                }
                if (GlobalVariable.cavitynumwkt1[List_precheck[9]] != null)
                {
                    lblAS_9.BackColor = GlobalVariable.cavitynumwkt1con[List_precheck[9]] == 1 ? Color.Yellow : (GlobalVariable.cavitynumwkt1con[List_precheck[9]] == 2 ? Color.Red : GlobalVariable.cavitynumwkt1con[List_precheck[9]] == 3 ? Color.Green : Color.DarkGray);
                    lblAS_9.Text = GlobalVariable.cavitynumwkt1[List_precheck[9]];
                }
                if (GlobalVariable.cavitynumwkt1[List_precheck[10]] != null)
                {
                    lblAS_10.BackColor = GlobalVariable.cavitynumwkt1con[List_precheck[10]] == 1 ? Color.Yellow : (GlobalVariable.cavitynumwkt1con[List_precheck[10]] == 2 ? Color.Red : GlobalVariable.cavitynumwkt1con[List_precheck[10]] == 3 ? Color.Green : Color.DarkGray);
                    lblAS_10.Text = GlobalVariable.cavitynumwkt1[List_precheck[10]];
                }
                if (GlobalVariable.cavitynumwkt1[List_precheck[11]] != null)
                {
                    lblAS_11.BackColor = GlobalVariable.cavitynumwkt1con[List_precheck[11]] == 1 ? Color.Yellow : (GlobalVariable.cavitynumwkt1con[List_precheck[11]] == 2 ? Color.Red : GlobalVariable.cavitynumwkt1con[List_precheck[11]] == 3 ? Color.Green : Color.DarkGray);
                    lblAS_11.Text = GlobalVariable.cavitynumwkt1[List_precheck[11]];
                }
                if (GlobalVariable.cavitynumwkt1[List_precheck[12]] != null)
                {
                    lblAS_12.BackColor = GlobalVariable.cavitynumwkt1con[List_precheck[12]] == 1 ? Color.Yellow : (GlobalVariable.cavitynumwkt1con[List_precheck[12]] == 2 ? Color.Red : GlobalVariable.cavitynumwkt1con[List_precheck[12]] == 3 ? Color.Green : Color.DarkGray);
                    lblAS_12.Text = GlobalVariable.cavitynumwkt1[List_precheck[12]];
                }
            }
            else if (GlobalVariable.CavityRows == 4 && GlobalVariable.CavityCols == 3)
            {

                if (GlobalVariable.cavitynumwkt1[List_precheck[0]] != null)
                {
                    BN_wk1.Text = GlobalVariable.cavitynumwkt1[List_precheck[0]];
                    //lblSC_1.BackColor = cavitynumcon[List_precheck[1]] ? Color.Yellow : Color.Red;
                }
                if (GlobalVariable.cavitynumwkt1[List_precheck[1]] != null)
                {
                    lblAS_1_4.BackColor = GlobalVariable.cavitynumwkt1con[List_precheck[1]] == 1 ? Color.Yellow : (GlobalVariable.cavitynumwkt1con[List_precheck[1]] == 2 ? Color.Red : GlobalVariable.cavitynumwkt1con[List_precheck[1]] == 3 ? Color.Green : Color.DarkGray);
                    lblAS_1_4.Text = GlobalVariable.cavitynumwkt1[List_precheck[1]];
                }
                if (GlobalVariable.cavitynumwkt1[List_precheck[2]] != null)
                {
                    lblAS_2_4.BackColor = GlobalVariable.cavitynumwkt1con[List_precheck[2]] == 1 ? Color.Yellow : (GlobalVariable.cavitynumwkt1con[List_precheck[2]] == 2 ? Color.Red : GlobalVariable.cavitynumwkt1con[List_precheck[2]] == 3 ? Color.Green : Color.DarkGray);
                    lblAS_2_4.Text = GlobalVariable.cavitynumwkt1[List_precheck[2]];
                }
                if (GlobalVariable.cavitynumwkt1[List_precheck[3]] != null)
                {
                    lblAS_3_4.BackColor = GlobalVariable.cavitynumwkt1con[List_precheck[3]] == 1 ? Color.Yellow : (GlobalVariable.cavitynumwkt1con[List_precheck[3]] == 2 ? Color.Red : GlobalVariable.cavitynumwkt1con[List_precheck[3]] == 3 ? Color.Green : Color.DarkGray);
                    lblAS_3_4.Text = GlobalVariable.cavitynumwkt1[List_precheck[3]];
                }
                if (GlobalVariable.cavitynumwkt1[List_precheck[4]] != null)
                {
                    lblAS_6_4.BackColor = GlobalVariable.cavitynumwkt1con[List_precheck[4]] == 1 ? Color.Yellow : (GlobalVariable.cavitynumwkt1con[List_precheck[4]] == 2 ? Color.Red : GlobalVariable.cavitynumwkt1con[List_precheck[4]] == 3 ? Color.Green : Color.DarkGray);
                    lblAS_6_4.Text = GlobalVariable.cavitynumwkt1[List_precheck[4]];
                }
                if (GlobalVariable.cavitynumwkt1[List_precheck[5]] != null)
                {
                    lblAS_5_4.BackColor = GlobalVariable.cavitynumwkt1con[List_precheck[5]] == 1 ? Color.Yellow : (GlobalVariable.cavitynumwkt1con[List_precheck[5]] == 2 ? Color.Red : GlobalVariable.cavitynumwkt1con[List_precheck[5]] == 3 ? Color.Green : Color.DarkGray);
                    lblAS_5_4.Text = GlobalVariable.cavitynumwkt1[List_precheck[5]];
                }
                if (GlobalVariable.cavitynumwkt1[List_precheck[6]] != null)
                {
                    lblAS_4_4.BackColor = GlobalVariable.cavitynumwkt1con[List_precheck[6]] == 1 ? Color.Yellow : (GlobalVariable.cavitynumwkt1con[List_precheck[6]] == 2 ? Color.Red : GlobalVariable.cavitynumwkt1con[List_precheck[6]] == 3 ? Color.Green : Color.DarkGray);
                    lblAS_4_4.Text = GlobalVariable.cavitynumwkt1[List_precheck[6]];
                }
                if (GlobalVariable.cavitynumwkt1[List_precheck[7]] != null)
                {
                    lblAS_7_4.BackColor = GlobalVariable.cavitynumwkt1con[List_precheck[7]] == 1 ? Color.Yellow : (GlobalVariable.cavitynumwkt1con[List_precheck[7]] == 2 ? Color.Red : GlobalVariable.cavitynumwkt1con[List_precheck[7]] == 3 ? Color.Green : Color.DarkGray);
                    lblAS_7_4.Text = GlobalVariable.cavitynumwkt1[List_precheck[7]];
                }
                if (GlobalVariable.cavitynumwkt1[List_precheck[8]] != null)
                {
                    lblAS_8_4.BackColor = GlobalVariable.cavitynumwkt1con[List_precheck[8]] == 1 ? Color.Yellow : (GlobalVariable.cavitynumwkt1con[List_precheck[8]] == 2 ? Color.Red : GlobalVariable.cavitynumwkt1con[List_precheck[8]] == 3 ? Color.Green : Color.DarkGray);
                    lblAS_8_4.Text = GlobalVariable.cavitynumwkt1[List_precheck[8]];
                }
                if (GlobalVariable.cavitynumwkt1[List_precheck[9]] != null)
                {
                    lblAS_9_4.BackColor = GlobalVariable.cavitynumwkt1con[List_precheck[9]] == 1 ? Color.Yellow : (GlobalVariable.cavitynumwkt1con[List_precheck[9]] == 2 ? Color.Red : GlobalVariable.cavitynumwkt1con[List_precheck[9]] == 3 ? Color.Green : Color.DarkGray);
                    lblAS_9_4.Text = GlobalVariable.cavitynumwkt1[List_precheck[9]];
                }
                if (GlobalVariable.cavitynumwkt1[List_precheck[10]] != null)
                {
                    lblAS_12_4.BackColor = GlobalVariable.cavitynumwkt1con[List_precheck[10]] == 1 ? Color.Yellow : (GlobalVariable.cavitynumwkt1con[List_precheck[10]] == 2 ? Color.Red : GlobalVariable.cavitynumwkt1con[List_precheck[10]] == 3 ? Color.Green : Color.DarkGray);
                    lblAS_12_4.Text = GlobalVariable.cavitynumwkt1[List_precheck[10]];
                }
                if (GlobalVariable.cavitynumwkt1[List_precheck[11]] != null)
                {
                    lblAS_11_4.BackColor = GlobalVariable.cavitynumwkt1con[List_precheck[11]] == 1 ? Color.Yellow : (GlobalVariable.cavitynumwkt1con[List_precheck[11]] == 2 ? Color.Red : GlobalVariable.cavitynumwkt1con[List_precheck[11]] == 3 ? Color.Green : Color.DarkGray);
                    lblAS_11_4.Text = GlobalVariable.cavitynumwkt1[List_precheck[11]];
                }
                if (GlobalVariable.cavitynumwkt1[List_precheck[12]] != null)
                {
                    lblAS_10_4.BackColor = GlobalVariable.cavitynumwkt1con[List_precheck[12]] == 1 ? Color.Yellow : (GlobalVariable.cavitynumwkt1con[List_precheck[12]] == 2 ? Color.Red : GlobalVariable.cavitynumwkt1con[List_precheck[12]] == 3 ? Color.Green : Color.DarkGray);
                    lblAS_10_4.Text = GlobalVariable.cavitynumwkt1[List_precheck[12]];
                }

            }

        }

        public void passwkc2()
        {
            if (GlobalVariable.CavityRows == 4 && GlobalVariable.CavityCols == 3)
            {
                if (GlobalVariable.cavitynumwkt2[List_precheck[0]] != null)
                {
                    BN_WK2.Text = GlobalVariable.cavitynumwkt2[List_precheck[0]];
                    //lblSC_1.BackColor = cavitynumcon[List_precheck[1]] ? Color.Yellow : Color.Red;
                }
                if (GlobalVariable.cavitynumwkt2[List_precheck[1]] != null)
                {
                    lblFI_1_4.BackColor = GlobalVariable.cavitynumwkt2con[List_precheck[1]] ? Color.Green : Color.Red;
                    lblFI_1_4.Text = GlobalVariable.cavitynumwkt2[List_precheck[1]];
                }
                if (GlobalVariable.cavitynumwkt2[List_precheck[2]] != null)
                {
                    lblFI_2_4.BackColor = GlobalVariable.cavitynumwkt2con[List_precheck[2]] ? Color.Green : Color.Red;
                    lblFI_2_4.Text = GlobalVariable.cavitynumwkt2[List_precheck[2]];
                }
                if (GlobalVariable.cavitynumwkt2[List_precheck[3]] != null)
                {
                    lblFI_3_4.BackColor = GlobalVariable.cavitynumwkt2con[List_precheck[3]] ? Color.Green : Color.Red;
                    lblFI_3_4.Text = GlobalVariable.cavitynumwkt2[List_precheck[3]];
                }
                if (GlobalVariable.cavitynumwkt2[List_precheck[4]] != null)
                {
                    lblFI_6_4.BackColor = GlobalVariable.cavitynumwkt2con[List_precheck[4]] ? Color.Green : Color.Red;
                    lblFI_6_4.Text = GlobalVariable.cavitynumwkt2[List_precheck[4]];
                }
                if (GlobalVariable.cavitynumwkt2[List_precheck[5]] != null)
                {
                    lblFI_5_4.BackColor = GlobalVariable.cavitynumwkt2con[List_precheck[5]] ? Color.Green : Color.Red;
                    lblFI_5_4.Text = GlobalVariable.cavitynumwkt2[List_precheck[5]];
                }
                if (GlobalVariable.cavitynumwkt2[List_precheck[6]] != null)
                {
                    lblFI_4_4.BackColor = GlobalVariable.cavitynumwkt2con[List_precheck[6]] ? Color.Green : Color.Red;
                    lblFI_4_4.Text = GlobalVariable.cavitynumwkt2[List_precheck[6]];
                }
                if (GlobalVariable.cavitynumwkt2[List_precheck[7]] != null)
                {
                    lblFI_7_4.BackColor = GlobalVariable.cavitynumwkt2con[List_precheck[7]] ? Color.Green : Color.Red;
                    lblFI_7_4.Text = GlobalVariable.cavitynumwkt2[List_precheck[7]];
                }
                if (GlobalVariable.cavitynumwkt2[List_precheck[8]] != null)
                {
                    lblFI_8_4.BackColor = GlobalVariable.cavitynumwkt2con[List_precheck[8]] ? Color.Green : Color.Red;
                    lblFI_8_4.Text = GlobalVariable.cavitynumwkt2[List_precheck[8]];
                }
                if (GlobalVariable.cavitynumwkt2[List_precheck[9]] != null)
                {
                    lblFI_9_4.BackColor = GlobalVariable.cavitynumwkt2con[List_precheck[9]] ? Color.Green : Color.Red;
                    lblFI_9_4.Text = GlobalVariable.cavitynumwkt2[List_precheck[9]];
                }
                if (GlobalVariable.cavitynumwkt2[List_precheck[10]] != null)
                {
                    lblFI_12_4.BackColor = GlobalVariable.cavitynumwkt2con[List_precheck[10]] ? Color.Green : Color.Red;
                    lblFI_12_4.Text = GlobalVariable.cavitynumwkt2[List_precheck[10]];
                }
                if (GlobalVariable.cavitynumwkt2[List_precheck[11]] != null)
                {
                    lblFI_11_4.BackColor = GlobalVariable.cavitynumwkt2con[List_precheck[11]] ? Color.Green : Color.Red;
                    lblFI_11_4.Text = GlobalVariable.cavitynumwkt2[List_precheck[11]];
                }
                if (GlobalVariable.cavitynumwkt2[List_precheck[12]] != null)
                {
                    lblFI_10_4.BackColor = GlobalVariable.cavitynumwkt2con[List_precheck[12]] ? Color.Green : Color.Red;
                    lblFI_10_4.Text = GlobalVariable.cavitynumwkt2[List_precheck[12]];
                }
            }
            else if (GlobalVariable.CavityRows == 3 && GlobalVariable.CavityCols == 4)
            {
                if (GlobalVariable.cavitynumwkt2[List_precheck[0]] != null)
                {
                    BN_WK2.Text = GlobalVariable.cavitynumwkt2[List_precheck[0]];
                    //lblSC_1.BackColor = cavitynumcon[List_precheck[1]] ? Color.Yellow : Color.Red;
                }
                if (GlobalVariable.cavitynumwkt2[List_precheck[1]] != null)
                {
                    lblFI_1.BackColor = GlobalVariable.cavitynumwkt2con[List_precheck[1]] ? Color.Green : Color.Red;
                    lblFI_1.Text = GlobalVariable.cavitynumwkt2[List_precheck[1]];
                }
                if (GlobalVariable.cavitynumwkt2[List_precheck[2]] != null)
                {
                    lblFI_2.BackColor = GlobalVariable.cavitynumwkt2con[List_precheck[2]] ? Color.Green : Color.Red;
                    lblFI_2.Text = GlobalVariable.cavitynumwkt2[List_precheck[2]];
                }
                if (GlobalVariable.cavitynumwkt2[List_precheck[3]] != null)
                {
                    lblFI_3.BackColor = GlobalVariable.cavitynumwkt2con[List_precheck[3]] ? Color.Green : Color.Red;
                    lblFI_3.Text = GlobalVariable.cavitynumwkt2[List_precheck[3]];
                }
                if (GlobalVariable.cavitynumwkt2[List_precheck[4]] != null)
                {
                    lblFI_4.BackColor = GlobalVariable.cavitynumwkt2con[List_precheck[4]] ? Color.Green : Color.Red;
                    lblFI_4.Text = GlobalVariable.cavitynumwkt2[List_precheck[4]];
                }
                if (GlobalVariable.cavitynumwkt2[List_precheck[5]] != null)
                {
                    lblFI_5.BackColor = GlobalVariable.cavitynumwkt2con[List_precheck[5]] ? Color.Green : Color.Red;
                    lblFI_5.Text = GlobalVariable.cavitynumwkt2[List_precheck[5]];
                }
                if (GlobalVariable.cavitynumwkt2[List_precheck[6]] != null)
                {
                    lblFI_6.BackColor = GlobalVariable.cavitynumwkt2con[List_precheck[6]] ? Color.Green : Color.Red;
                    lblFI_6.Text = GlobalVariable.cavitynumwkt2[List_precheck[6]];
                }
                if (GlobalVariable.cavitynumwkt2[List_precheck[7]] != null)
                {
                    lblFI_7.BackColor = GlobalVariable.cavitynumwkt2con[List_precheck[7]] ? Color.Green : Color.Red;
                    lblFI_7.Text = GlobalVariable.cavitynumwkt2[List_precheck[7]];
                }
                if (GlobalVariable.cavitynumwkt2[List_precheck[8]] != null)
                {
                    lblFI_8.BackColor = GlobalVariable.cavitynumwkt2con[List_precheck[8]] ? Color.Green : Color.Red;
                    lblFI_8.Text = GlobalVariable.cavitynumwkt2[List_precheck[8]];
                }
                if (GlobalVariable.cavitynumwkt2[List_precheck[9]] != null)
                {
                    lblFI_9.BackColor = GlobalVariable.cavitynumwkt2con[List_precheck[9]] ? Color.Green : Color.Red;
                    lblFI_9.Text = GlobalVariable.cavitynumwkt2[List_precheck[9]];
                }
                if (GlobalVariable.cavitynumwkt2[List_precheck[10]] != null)
                {
                    lblFI_10.BackColor = GlobalVariable.cavitynumwkt2con[List_precheck[10]] ? Color.Green : Color.Red;
                    lblFI_10.Text = GlobalVariable.cavitynumwkt2[List_precheck[10]];
                }
                if (GlobalVariable.cavitynumwkt2[List_precheck[11]] != null)
                {
                    lblFI_11.BackColor = GlobalVariable.cavitynumwkt2con[List_precheck[11]] ? Color.Green : Color.Red;
                    lblFI_11.Text = GlobalVariable.cavitynumwkt2[List_precheck[11]];
                }
                if (GlobalVariable.cavitynumwkt2[List_precheck[12]] != null)
                {
                    lblFI_12.BackColor = GlobalVariable.cavitynumwkt2con[List_precheck[12]] ? Color.Green : Color.Red;
                    lblFI_12.Text = GlobalVariable.cavitynumwkt2[List_precheck[12]];
                }
            }
        }

        private static void Sequence_initialize()
        {
            //if (GlobalVariable.chkSeq1)
            {
                List_precheck[0] = 0;
                List_precheck[1] = 1;
                List_precheck[2] = 2;
                List_precheck[3] = 3;
                List_precheck[4] = 4;
                List_precheck[5] = 5;
                List_precheck[6] = 6;
                List_precheck[7] = 7;
                List_precheck[8] = 8;
                List_precheck[9] = 9;
                List_precheck[10] = 10;
                List_precheck[11] = 11;
                List_precheck[12] = 12;
                List_precheck[13] = 13;
                List_precheck[14] = 14;
            }
        }


        public void loadSN()
        {
            for (int row = 0; row < GlobalVariable.CavityRows; row++)
            {
                for (int col = 0; col < GlobalVariable.CavityCols; col++)
                {
                    udateCavity2(row, col, GlobalVariable.barcodeViewld[row, col].SN, GlobalVariable.barcodeViewld[row, col].barcodde, GlobalVariable.barcodeViewld[row, col].Check);
                    udatewk1Cavity2(row, col, GlobalVariable.barcodeViewwk1[row, col].SN, GlobalVariable.barcodeViewwk1[row, col].check, GlobalVariable.barcodeViewwk1[row, col].barcodde);
                    udatewk2Cavity(row, col, GlobalVariable.barcodeViewwk2[row, col].SN, GlobalVariable.barcodeViewwk2[row, col].Check, GlobalVariable.barcodeViewwk2[row, col].barcodde);


                }
            }
        }


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
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private async void timer1_Tick(object sender, EventArgs e)
        {
            try
            {

                textBox1.Text = HomingCls.homingStep.ToString();
                textBox10.Text = WorkingConveyor1.currentState.ToString();
                textBox9.Text = LoadingConveyor.iLodingConStep.ToString();
                textBox14.Text = WorkingConveyor1.step.ToString();
                textBox15.Text = WorkingConveyor2.i_step.ToString();
                textBox18.Text = WorkingConveyor1.i_rejection.ToString();
                textBox19.Text = WorkingConveyor1.i_feed.ToString();
                textBox1.Enabled = false;
                textBox10.Enabled = false;
                textBox14.Enabled = false;
                textBox15.Enabled = false;
                textBox9.Enabled = false;
                textBox18.Enabled = false;
                textBox19.Enabled = false;
                UpdateRunningLog();
                UpdateLiveAlarmGrid();
                UpdateMachineStatusLabels();


                //conectionStatusGrid.DataSource = RefreshConnectionStatus();

                // to maintain the scroll position
                int scrollIndex = 0;
                if (conectionStatusGrid.FirstDisplayedScrollingRowIndex >= 0)
                    scrollIndex = conectionStatusGrid.FirstDisplayedScrollingRowIndex;



                conectionStatusGrid.DataSource = RefreshConnectionStatus();

                if (scrollIndex >= 0 && scrollIndex < conectionStatusGrid.Rows.Count)
                    conectionStatusGrid.FirstDisplayedScrollingRowIndex = scrollIndex;
                if (scrollIndex >= 0 && scrollIndex < conectionStatusGrid.Rows.Count)
                    conectionStatusGrid.FirstDisplayedScrollingRowIndex = scrollIndex;

                //lstRunningLog.DataSource = null;
                //lstRunningLog.DataSource = ExceptionLib.Logger.RunningLog_lst;
                //lstRunningLog.Refresh();

                if (GlobalVariable.current_MCStatus == GlobalVariable.MachineStatus.Running)
                {
                    Homing.Enabled = false;
                }
                else
                {
                    Homing.Enabled = true;
                }

                if (GlobalVariable.DI[(int)EInput.Previous_M_C_Ready_To_Send_Pallet])
                {
                    Check_Semma.Text = "Pallet Inplaced";
                    Check_Semma.BackColor = Color.LimeGreen;
                }
                else
                {
                    Check_Semma.Text = "Pallet Not Inplaced";

                    Check_Semma.BackColor = Color.Red;

                }


                if (GlobalVariable.SFC_PDCA_Bypass) //  AK
                {

                    OfflinewithoutSFC.BackColor = Color.Red;
                }
                else
                {
                    OnlinewithoutSFC.BackColor = Color.LimeGreen;
                }

                if (!GlobalVariable.g_lstAlarmInfo[(int)ECode.Emg_Pressed_Error].AlarmHappen && !GlobalVariable.DI[(int)DIDO.EInput.E_Stop_Button_Sfty_Fb])
                {
                    await Task.Delay(500);
                    if (!GlobalVariable.DI[(int)DIDO.EInput.E_Stop_Button_Sfty_Fb])
                    {

                        GlobalVariable.AlarmTrigger(ECode.Emg_Pressed_Error, true, 1);
                        GlobalVariable.current_MCStatus = GlobalVariable.MachineStatus.Stop;
                        ConveyorSystem.Stop();
                        ConveyorSystem.HardButtons(false, true, false);
                        GlobalVariable.b_gHomingDone = false;
                        GlobalVariable.bhomeseq_running = false;
                        GlobalVariable.pause = false;
                        GlobalVariable.b_gPause = false;

                        GlobalVariable.New_Pallet_Only = false;
                    }
                }
                if (!GlobalVariable.g_lstAlarmInfo[(int)ECode.MainAir_FB_Error].AlarmHappen && !GlobalVariable.DI[(int)DIDO.EInput.Main_Air_Pressure_Fb])
                {
                    GlobalVariable.AlarmTrigger(ECode.MainAir_FB_Error, true, 1);
                    GlobalVariable.current_MCStatus = GlobalVariable.MachineStatus.Stop;
                    ConveyorSystem.Stop();
                    ConveyorSystem.HardButtons(false, true, false);
                    GlobalVariable.b_gHomingDone = false;
                    GlobalVariable.bhomeseq_running = false;
                    GlobalVariable.pause = false;
                    GlobalVariable.New_Pallet_Only = false;
                }




            }
            catch (Exception ex)
            {
                //Arulkumar Fixed random stoppage start
                Logger.WriteLog(Logger.LogType.Error, "HomeScreen", "timer1_Tick", ex.Message, ex.ToString());
                //Arulkumar Fixed random stoppage end
            }
        }
        private void UpdateMachineStatusLabels()
        {
            try
            {
                txtMachineMode.Text = GlobalVariable.g_bMachineMode.ToString();
                txtPasscnt.Text = GlobalVariable.dGlobal_Pass_count.ToString();
                txtFailcnt.Text = GlobalVariable.dGlobal_Reject_count.ToString();
                txtOverallcnt.Text = GlobalVariable.dGlobal_Total_count.ToString();
                txtyYeldcnt.Text = Math.Round(GlobalVariable.dGlobal_Yield_Count, 2) + " %";
                textBox21.Text = GlobalVariable.dGlobal_GraphiteToss_Count.ToString();
                //txtCycletime.Text = GlobalVariable.dGlobal_Cycle_time.ToString("F2") + " S";


                txtCycletime.Text = GlobalVariable.dGlobal_Cycle_time.ToString("F2") + " S";
                txtonlypasting.Text = GlobalVariable.cycle_time.ToString("F2") + "  sec";

                // txtout.Text = GlobalVariable.cycle_time_out.ToString("F2") + "  sec";
                txtout.Text = GlobalVariable.PDCA_count_all_Updated.ToString();

                //txtCycletime.Text = GlobalVariable.cycle_time.ToString("F2") + "  sec";//Sathish
                txtUph.Text = "00";
                double uph = 0;
                if (GlobalVariable.cycle_time > 0)
                {
                    uph = (3600 / GlobalVariable.cycle_time); //GlobalVariable.dGlobal_Total_count / (GlobalVariable.dGlobal_Cycle_time / 60);
                }

                txtUph.Text = uph.ToString("0.00");

                lblShift.Text = GlobalVariable.CurrentShift;
                lblDowntime.Text = GlobalVariable.MachineDowntime.ToString("0.00");
                lblIdletime.Text = GlobalVariable.MachineIdletime.ToString("0.00");
                lblRunTime.Text = GlobalVariable.MachineRuntime.ToString("0.00");
                GlobalVariable.MachineTotaltime = GlobalVariable.MachineDowntime + GlobalVariable.MachineIdletime + GlobalVariable.MachineRuntime;
                lblTotaltime.Text = GlobalVariable.MachineTotaltime.ToString("0.00");
            }
            catch (Exception ex)
            {
                Logger.WriteLog(Logger.LogType.Error, "HomeScreen", "timer1_Tick", "Exception Error", ex.ToString());
                //throw;
            }
        }

        private void UpdateRunningLog()
        {
            //Arul_Running_log
            try
            {
                var runningList = ExceptionLib.Logger.RunningLog_lst;

                // save any new entries to file
                try
                {
                    if (runningList != null)
                    {
                        if (runningList.Count < _runningLogSavedCount)
                        {
                            // list was cleared or restarted - reset counter
                            _runningLogSavedCount = 0;
                        }

                        for (int i = _runningLogSavedCount; i < runningList.Count; i++)
                        {
                            try
                            {
                                //GRT_BG1_V54.Function.CommonClass.RunningLogger.Log(runningList[i]);
                                GRT_BG1_V54.Function.CommonClass.RunningLogger.Log(runningList[i], "Current Version: " + GlobalVariable.g_MachineVersion);
                            }
                            catch (Exception ex)
                            {
                                //Arulkumar Fixed random stoppage start
                                Logger.WriteLog(Logger.LogType.Error, "HomeScreen", "UpdateRunningLog", ex.Message, ex.ToString());
                                //Arulkumar Fixed random stoppage end
                            }
                        }

                        _runningLogSavedCount = runningList.Count;
                    }
                }
                catch (Exception ex)
                {
                    //Arulkumar Fixed random stoppage start
                    Logger.WriteLog(Logger.LogType.Error, "HomeScreen", "UpdateRunningLog", ex.Message, ex.ToString());
                    //Arulkumar Fixed random stoppage end
                }

                if (lstRunningLog.InvokeRequired)
                {
                    lstRunningLog.BeginInvoke(new Action(UpdateRunningLog));
                    return;
                }
                lstRunningLog.Items.Clear();
                if (runningList != null)
                {
                    foreach (string msg in runningList)
                    {
                        lstRunningLog.Items.Add(msg);
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog(Logger.LogType.Error, "HomeScreen", "", ex.Message, ex.ToString());
            }
        }

        bool isinserted = false;
        private void UpdateLiveAlarmGrid()
        {
            try
            {
                if (GlobalVariable.b_EStop && isinserted == false)
                {
                    isinserted = true;
                    GlobalVariable.AlarmTriggerAsync(ECode.Emg_Pressed_Error, true, 1, "Current Version: " + GlobalVariable.g_MachineVersion + "");
                }
                DataTable table = new DataTable();
                table.Columns.Add("Date And Time", typeof(string));
                table.Columns.Add("Code and Description", typeof(string));

                if (GlobalVariable.g_lstAlarmInfo.Any(a => a.alarmHappen))
                {
                    foreach (var alarm in GlobalVariable.g_lstAlarmInfo)
                    {
                        if (alarm.alarmHappen)
                        {
                            DataRow data = table.NewRow();
                            var cellValue = alarm.AlarmStartTime;
                            data[0] = cellValue.ToString();

                            string ErrorDes = "";
                            if (alarm.AlarmName != "")
                            {
                                ErrorDes = alarm.AlarmCode + "-" + alarm.AlarmName + " - " + alarm.AlarmMessage;

                            }
                            else
                                ErrorDes = alarm.AlarmCode + "-" + alarm.AlarmMessage;

                            var cellValue1 = ErrorDes;
                            data[1] = cellValue1.ToString();
                            table.Rows.Add(data);
                        }
                    }
                }

                dgvAlarmlive.DataSource = table;
                dgvAlarmlive.Columns[0].Width = 150;
                dgvAlarmlive.Columns[1].Width = 1000;

                //Arul_error_log
                // Save alarm table to disk when alarm list changes (avoids saving every tick)
                try
                {
                    int currentCount = table.Rows.Count;
                    if (currentCount > 0 && currentCount != _lastAlarmSavedCount)
                    {
                        GRT_BG1_V54.Function.CommonClass.AlarmLog.SaveDataTable(table);
                        _lastAlarmSavedCount = currentCount;
                    }
                    else if (currentCount == 0)
                    {
                        // reset marker when no alarms
                        _lastAlarmSavedCount = -1;
                    }
                }
                //Arulkumar Fixed random stoppage start
                catch (Exception saveEx)
                {
                    Logger.WriteLog(Logger.LogType.Error, "HomeScreen", "UpdateLiveAlarmGrid.SaveAlarmTable", saveEx.Message, saveEx.ToString());
                }
                //Arulkumar Fixed random stoppage end

            }
            catch (Exception ex)
            {
                //Arulkumar Fixed random stoppage start
                Logger.WriteLog(Logger.LogType.Error, "HomeScreen", "UpdateLiveAlarmGrid", ex.Message, ex.ToString());
                //Arulkumar Fixed random stoppage end
            }
        }

        private DataTable RefreshConnectionStatus()
        {
            var table = new DataTable();
            table.Columns.Add("Type");
            table.Columns.Add("Device");
            table.Columns.Add("Status", typeof(Image));

            foreach (var kv in ObjectList.ScnrObj)
            {
                table.Rows.Add("Scanner", $"{kv.Value.ConnectionStrName}",
                    kv.Value.IsConnected ? signal_on : signal_off);
            }
            // CCDs
            //foreach (var kv in ObjectList.CCDObj)
            //{
            //    if (!GlobalVariable.CCD1Needed && kv.Value.ConnectionStrName == "CCD1")
            //    {
            //        table.Rows.Add("CCD", $"{kv.Value.ConnectionStrName}",
            //        kv.Value..IsConnected ? signal_on : signal_off);
            //    }
            //    if (!GlobalVariable.CCD2Needed && kv.Value.ConnectionStrName == "CCD2")
            //    {
            //        table.Rows.Add("CCD", $"{kv.Value.ConnectionStrName}",
            //        kv.Value.CheckConnectStatus() ? signal_on : signal_off);
            //    }
            //    if (!GlobalVariable.CCD3Needed && kv.Value.ConnectionStrName == "CCD3")
            //    {
            //        table.Rows.Add("CCD", $"{kv.Value.ConnectionStrName}",
            //        kv.Value.CheckConnectStatus() ? signal_on : signal_off);
            //    }
            //    if (!GlobalVariable.CCD4Needed && kv.Value.ConnectionStrName == "CCD4")
            //    {
            //        table.Rows.Add("CCD", $"{kv.Value.ConnectionStrName}",
            //        kv.Value.CheckConnectStatus() ? signal_on : signal_off);
            //    }

            //}
            foreach (var kv in ObjectList.CCDObj)
            {
                table.Rows.Add("CCD", $"{kv.Value.ConnectionStrName}",
                    kv.Value.IsConnected ? signal_on : signal_off);
            }

            foreach (var kv in ObjectList.SFCPDCAObj)
            {
                table.Rows.Add("SFC", $"{kv.Value.ConnectionStrName}",
                    kv.Value.IsConnected ? signal_on : signal_off);
            }
            // Scanners


            //// Robos
            //foreach (var kv in ObjectList.RoboObj)
            //{
            //    table.Rows.Add("Robot", $"{kv.Value.ConnectionStrName}",
            //        kv.Value.IsConnected ? signal_on : signal_off);
            //}

            //// COMPORT

            //foreach (var kv in ObjectList.COMObj)
            //{
            //    table.Rows.Add("COM", $"{kv.Value.OPT_COM}",
            //        kv.Value.OPT_Connection_Status ? signal_on : signal_off);
            //}

            // MOTION CARD
            //**msraj: need to work
            bool motionCardConnectStatus = GlobalVariable.b_gCardInitSucc;
            table.Rows.Add("Motion Card", "Advantech",
                    motionCardConnectStatus ? signal_on : signal_off);

            //**devchange: Add extra rows as per needed

            return table;
        }
        public void udateFinalresult(PartData part)
        {

            if (this.InvokeRequired)
            {
                //Arulkumar Fixed Null start
                try
                {
                    if (!IsDisposed && IsHandleCreated)
                        this.Invoke(new Action(() => updateResultAddRow(part)));
                }
                catch (ObjectDisposedException) { }
                catch (InvalidOperationException) { }
                //Arulkumar Fixed Null end

            }
        }

        public void ClearRows()
        {

            if (this.InvokeRequired)
            {
                //Arulkumar Fixed Null start
                try
                {
                    if (!IsDisposed && IsHandleCreated)
                        this.Invoke(new Action(() => FinalRslt.Rows.Clear()));
                }
                catch (ObjectDisposedException) { }
                catch (InvalidOperationException) { }
                //Arulkumar Fixed Null end

            }
            else
            {
                FinalRslt.Rows.Clear();
            }
        }
        public void updateResultAddRow(PartData part)
        {
            FinalRslt.Rows.Add(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), part.CarrierBarcode, part.SNno, part.cavityNo, part.Gapx, part.Gapy, part.Angle, part.loadcellforce, part.OkNok);
        }

        public void updateResult()
        {
            FinalRslt.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            FinalRslt.AutoGenerateColumns = false;
            FinalRslt.Columns.Clear();
            FinalRslt.Columns.Add("DateTime", "DATE TIME");
            FinalRslt.Columns.Add("CarrierSN", "CARRIER SN");
            FinalRslt.Columns.Add("MLBSN", "MLB SN");
            FinalRslt.Columns.Add("Cavity", "CAVITY");
            FinalRslt.Columns.Add("GapX", "GAPX");
            FinalRslt.Columns.Add("GapY", "GAPY");
            FinalRslt.Columns.Add("Angle", "ANGLE");
            FinalRslt.Columns.Add("Force", "FORCE");
            FinalRslt.Columns.Add("Result", "RESULT");
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

        private async void Homing_Click(object sender, EventArgs e)
        {


            try
            {
                Logger.WriteLog(Logger.LogType.Running, "Homing Sequence", "Current Version:", GlobalVariable.g_MachineVersion, "");

                Homing.Enabled = false;


                HomingCls.homingStep = 10;

                WorkingConveyor1.Z1_Trigger_While = false;
                WorkingConveyor1.Z2_Trigger_While = false;

                //clearwk2Cavity1();
                //clearwk1Cavity1();

                WorkingConveyor1.ResetCavityWork();

                if (GlobalVariable.b_EStop)
                {
                    MessageBox.Show("Emergency Button Pressed, Unable do homing", "Homming", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                    return;
                }
                if (GlobalVariable.g_bAlarm)
                {
                    //Arulkumar Fixed Null start
                    System.Windows.Forms.MessageBox.Show(" Please Clear All Alarms ", " Unable do homing ! ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //Arulkumar Fixed Null end
                    return;
                }
                if (GlobalVariable.bhomeseq_running)
                {
                    //Homing.Enabled = false;
                    MessageBox.Show("Homing Sequence is already running.", "Homing", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                DialogResult result = MessageBox.Show("Do you want to start the Homing process", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);

                if (result != DialogResult.OK)
                {
                    return;
                }

                //Strat Homing
                GlobalVariable.DIDO.WriteOPS(false, (int)EOutput.Str_PB);
                GlobalVariable.DIDO.WriteOPS(false, (int)EOutput.Stop_PB);
                GlobalVariable.DIDO.WriteOPS(false, (int)EOutput.Reset_PB);

                GlobalVariable.bhomeseq_running = true;

                try
                {
                    GlobalVariable.b_gHomingDone = false;
                    HomingCls home = new HomingCls();
                    ConveyorSystem._cts = new CancellationTokenSource();
                    await home.StartHomingSequence(ConveyorSystem._cts.Token);
                    CARRIER_SN.Text = "";
                    BN_wk1.Text = "";
                    BN_WK2.Text = "";
                    CARRIER_SN_4.Text = "";
                    BN_wk1_4.Text = "";
                    BN_WK2_4.Text = "";
                    clearCavity1();
                    clearwk1Cavity1();
                    clearwk2Cavity1();

                    //if (!await Task.Run(() => MainForm.CheckHomingforAllAxis()))
                    //{
                    //    GlobalVariable.current_MCStatus = GlobalVariable.MachineStatus.Stop;
                    //    MessageBox.Show("Homing Process Not Completed", "Confirmation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //}

                    //else
                    //{
                    //    GlobalVariable.current_MCStatus = GlobalVariable.MachineStatus.Ideal;

                    //}


                    if (GlobalVariable.current_MCStatus != GlobalVariable.MachineStatus.Stop && GlobalVariable.current_MCStatus != GlobalVariable.MachineStatus.EStop)
                    {
                        GlobalVariable.b_gHomingDone = true;
                        //ConveyorSystem.Pause();
                        //await Task.Run(() => AllAxiesInitialPos.GoinitialPosition());
                        GlobalVariable.bmachine_ReadytoStart = true;
                        GlobalVariable.current_MCStatus = GlobalVariable.MachineStatus.Ideal;
                        GlobalVariable.bautoseq_running = false;
                        

                        #region Running Log
                        await Task.Run(() => Logger.WriteLogasTask(Logger.LogType.Running, "Homing", "OverAll Homing", "Homing Process Completed", ""));
                        #endregion
                    }
                }
                catch (Exception ex)
                {
                    //Arulkumar Fixed random stoppage start
                    Logger.WriteLog(Logger.LogType.Error, "HomeScreen", "Homing_Click", ex.Message, ex.ToString());
                    //Arulkumar Fixed random stoppage end
                }
                finally
                {
                    //Arulkumar Fixed Hung start
                    //Reason: After Homing, Start auto-seq looped in GoFeederPlace on b_gPause
                    //Root Cause: AlarmTriggerAsync during Homing set b_gPause=true and HomingPause(); Homing end never cleared b_gPause / HomingResume().
                    GlobalVariable.b_gPause = false;
                    //ConveyorSystem.HomingResume();
                    //Arulkumar Fixed Hung end
                    GlobalVariable.bhomeseq_running = false;
                    Homing.Enabled = true;
                }

            }
            finally
            {

            }

        }


        private void lblShift_TextChanged(object sender, EventArgs e)
        {
            ShiftLAble = lblShift.Text;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //ssObjectList.Stepper_1.Move_AbsStepper()
            check();
            // Gonegative
            //  NozzleSystem.Gonegative(6,"Nozzle1");
            // NozzleSystem.Gonegative(7, "Nozzle2");
            //GantrySystem.wk1_homeX();
            //GantrySystem.wk1_homeY();
            //GantrySystem.wk2_home();
            //GantrySystem.GoWK1XinitialPos();
            //GantrySystem.GoWK1YinitialPos();






        }

        public void updateFinal()
        {

        }
        public bool udateCavity(int row, int col, string sn, string bn, bool check)
        {
            if (this.InvokeRequired)
            {
                bool result = false;
                //Arulkumar Fixed Null start
                try
                {
                    if (!IsDisposed && IsHandleCreated)
                        this.Invoke(new Action(() => result = udateCavity2(row, col, sn, bn, check)));
                }
                catch (ObjectDisposedException) { }
                catch (InvalidOperationException) { }
                //Arulkumar Fixed Null end
                return result;
            }

            return udateCavity2(row, col, sn, bn, check);


        }
        public void tempupdateWWK1(string condition, string CarSn, string cavSn, int color)
        {
            if(GlobalVariable.CavityRows == 4 && GlobalVariable.CavityCols == 3)
            {
                GlobalVariable.cavitynumwkt1[0] = CarSn;
                if (condition == "00")
                {
                    GlobalVariable.cavitynumwkt1[1] = cavSn;
                    GlobalVariable.cavitynumwkt1con[1] = color;
                }
                if (condition == "01")
                {
                    GlobalVariable.cavitynumwkt1[2] = cavSn;
                    GlobalVariable.cavitynumwkt1con[2] = color;
                }
                if (condition == "02")
                {
                    GlobalVariable.cavitynumwkt1[3] = cavSn;
                    GlobalVariable.cavitynumwkt1con[3] = color;
                }
                if (condition == "12")
                {
                    GlobalVariable.cavitynumwkt1[6] = cavSn;
                    GlobalVariable.cavitynumwkt1con[6] = color;
                }
                if (condition == "11")
                {
                    GlobalVariable.cavitynumwkt1[5] = cavSn;
                    GlobalVariable.cavitynumwkt1con[5] = color;
                }
                if (condition == "10")
                {
                    GlobalVariable.cavitynumwkt1[4] = cavSn;
                    GlobalVariable.cavitynumwkt1con[4] = color;
                }
                if (condition == "20")
                {
                    GlobalVariable.cavitynumwkt1[7] = cavSn;
                    GlobalVariable.cavitynumwkt1con[7] = color;
                }
                if (condition == "21")
                {
                    GlobalVariable.cavitynumwkt1[8] = cavSn;
                    GlobalVariable.cavitynumwkt1con[8] = color;
                }
                if (condition == "22")
                {
                    GlobalVariable.cavitynumwkt1[9] = cavSn;
                    GlobalVariable.cavitynumwkt1con[9] = color;
                }
                if (condition == "32")
                {
                    GlobalVariable.cavitynumwkt1[12] = cavSn;
                    GlobalVariable.cavitynumwkt1con[12] = color;
                }
                if (condition == "31")
                {
                    GlobalVariable.cavitynumwkt1[11] = cavSn;
                    GlobalVariable.cavitynumwkt1con[11] = color;
                }
                if (condition == "30")
                {
                    GlobalVariable.cavitynumwkt1[10] = cavSn;
                    GlobalVariable.cavitynumwkt1con[10] = color;
                }
            }
            else if (GlobalVariable.CavityRows == 3 && GlobalVariable.CavityCols == 4)
            {
                GlobalVariable.cavitynumwkt1[0] = CarSn;
                if (condition == "00")
                {
                    GlobalVariable.cavitynumwkt1[1] = cavSn;
                    GlobalVariable.cavitynumwkt1con[1] = color;
                }
                if (condition == "01")
                {
                    GlobalVariable.cavitynumwkt1[2] = cavSn;
                    GlobalVariable.cavitynumwkt1con[2] = color;
                }
                if (condition == "02")
                {
                    GlobalVariable.cavitynumwkt1[3] = cavSn;
                    GlobalVariable.cavitynumwkt1con[3] = color;
                }
                if (condition == "03")
                {
                    GlobalVariable.cavitynumwkt1[4] = cavSn;
                    GlobalVariable.cavitynumwkt1con[4] = color;
                }
                if (condition == "13")
                {
                    GlobalVariable.cavitynumwkt1[5] = cavSn;
                    GlobalVariable.cavitynumwkt1con[5] = color;
                }
                if (condition == "12")
                {
                    GlobalVariable.cavitynumwkt1[6] = cavSn;
                    GlobalVariable.cavitynumwkt1con[6] = color;
                }
                if (condition == "11")
                {
                    GlobalVariable.cavitynumwkt1[7] = cavSn;
                    GlobalVariable.cavitynumwkt1con[7] = color;
                }
                if (condition == "10")
                {
                    GlobalVariable.cavitynumwkt1[8] = cavSn;
                    GlobalVariable.cavitynumwkt1con[8] = color;
                }
                if (condition == "20")
                {
                    GlobalVariable.cavitynumwkt1[9] = cavSn;
                    GlobalVariable.cavitynumwkt1con[9] = color;
                }
                if (condition == "21")
                {
                    GlobalVariable.cavitynumwkt1[10] = cavSn;
                    GlobalVariable.cavitynumwkt1con[10] = color;
                }
                if (condition == "22")
                {
                    GlobalVariable.cavitynumwkt1[11] = cavSn;
                    GlobalVariable.cavitynumwkt1con[11] = color;
                }
                if (condition == "23")
                {
                    GlobalVariable.cavitynumwkt1[12] = cavSn;
                    GlobalVariable.cavitynumwkt1con[12] = color;
                }
            }

        }
        public void tempupdate(string condition, string CarSn, string cavSn, bool color)
        {
            if(GlobalVariable.CavityRows == 4 && GlobalVariable.CavityCols == 3)
            {
                GlobalVariable.cavitynum[0] = CarSn;
                if (condition == "00")
                {
                    GlobalVariable.cavitynum[1] = cavSn;
                    GlobalVariable.cavitynumcon[1] = color;
                }
                if (condition == "01")
                {
                    GlobalVariable.cavitynum[2] = cavSn;
                    GlobalVariable.cavitynumcon[2] = color;
                }
                if (condition == "02")
                {
                    GlobalVariable.cavitynum[3] = cavSn;
                    GlobalVariable.cavitynumcon[3] = color;
                }
                if (condition == "12")
                {
                    GlobalVariable.cavitynum[6] = cavSn;
                    GlobalVariable.cavitynumcon[6] = color;
                }
                if (condition == "11")
                {
                    GlobalVariable.cavitynum[5] = cavSn;
                    GlobalVariable.cavitynumcon[5] = color;
                }
                if (condition == "10")
                {
                    GlobalVariable.cavitynum[4] = cavSn;
                    GlobalVariable.cavitynumcon[4] = color;
                }
                if (condition == "20")
                {
                    GlobalVariable.cavitynum[7] = cavSn;
                    GlobalVariable.cavitynumcon[7] = color;
                }
                if (condition == "21")
                {
                    GlobalVariable.cavitynum[8] = cavSn;
                    GlobalVariable.cavitynumcon[8] = color;
                }
                if (condition == "22")
                {
                    GlobalVariable.cavitynum[9] = cavSn;
                    GlobalVariable.cavitynumcon[9] = color;
                }
                if (condition == "32")
                {
                    GlobalVariable.cavitynum[12] = cavSn;
                    GlobalVariable.cavitynumcon[12] = color;
                }
                if (condition == "31")
                {
                    GlobalVariable.cavitynum[11] = cavSn;
                    GlobalVariable.cavitynumcon[11] = color;
                }
                if (condition == "30")
                {
                    GlobalVariable.cavitynum[10] = cavSn;
                    GlobalVariable.cavitynumcon[10] = color;
                }
            }
            else if (GlobalVariable.CavityRows == 3 && GlobalVariable.CavityCols == 4)
            {
                GlobalVariable.cavitynum[0] = CarSn;
                if (condition == "00")
                {
                    GlobalVariable.cavitynum[1] = cavSn;
                    GlobalVariable.cavitynumcon[1] = color;
                }
                if (condition == "01")
                {
                    GlobalVariable.cavitynum[2] = cavSn;
                    GlobalVariable.cavitynumcon[2] = color;
                }
                if (condition == "02")
                {
                    GlobalVariable.cavitynum[3] = cavSn;
                    GlobalVariable.cavitynumcon[3] = color;
                }
                if (condition == "03")
                {
                    GlobalVariable.cavitynum[4] = cavSn;
                    GlobalVariable.cavitynumcon[4] = color;
                }
                if (condition == "13")
                {
                    GlobalVariable.cavitynum[5] = cavSn;
                    GlobalVariable.cavitynumcon[5] = color;
                }
                if (condition == "12")
                {
                    GlobalVariable.cavitynum[6] = cavSn;
                    GlobalVariable.cavitynumcon[6] = color;
                }
                if (condition == "11")
                {
                    GlobalVariable.cavitynum[7] = cavSn;
                    GlobalVariable.cavitynumcon[7] = color;
                }
                if (condition == "10")
                {
                    GlobalVariable.cavitynum[8] = cavSn;
                    GlobalVariable.cavitynumcon[8] = color;
                }
                if (condition == "20")
                {
                    GlobalVariable.cavitynum[9] = cavSn;
                    GlobalVariable.cavitynumcon[9] = color;
                }
                if (condition == "21")
                {
                    GlobalVariable.cavitynum[10] = cavSn;
                    GlobalVariable.cavitynumcon[10] = color;
                }
                if (condition == "22")
                {
                    GlobalVariable.cavitynum[11] = cavSn;
                    GlobalVariable.cavitynumcon[11] = color;
                }
                if (condition == "23")
                {
                    GlobalVariable.cavitynum[12] = cavSn;
                    GlobalVariable.cavitynumcon[12] = color;
                }
            }

        }
        public void tempupdateWK2(string condition, string CarSn, string cavSn, bool color)
        {
            if (GlobalVariable.CavityRows == 4 && GlobalVariable.CavityCols == 3)
            {
                GlobalVariable.cavitynumwkt2[0] = CarSn;
                if (condition == "00")
                {
                    GlobalVariable.cavitynumwkt2[1] = cavSn;
                    GlobalVariable.cavitynumwkt2con[1] = color;
                }
                if (condition == "01")
                {
                    GlobalVariable.cavitynumwkt2[2] = cavSn;
                    GlobalVariable.cavitynumwkt2con[2] = color;
                }
                if (condition == "02")
                {
                    GlobalVariable.cavitynumwkt2[3] = cavSn;
                    GlobalVariable.cavitynumwkt2con[3] = color;
                }
                if (condition == "12")
                {
                    GlobalVariable.cavitynumwkt2[6] = cavSn;
                    GlobalVariable.cavitynumwkt2con[6] = color;
                }
                if (condition == "11")
                {
                    GlobalVariable.cavitynumwkt2[5] = cavSn;
                    GlobalVariable.cavitynumwkt2con[5] = color;
                }
                if (condition == "10")
                {
                    GlobalVariable.cavitynumwkt2[4] = cavSn;
                    GlobalVariable.cavitynumwkt2con[4] = color;
                }
                if (condition == "20")
                {
                    GlobalVariable.cavitynumwkt2[7] = cavSn;
                    GlobalVariable.cavitynumwkt2con[7] = color;
                }
                if (condition == "21")
                {
                    GlobalVariable.cavitynumwkt2[8] = cavSn;
                    GlobalVariable.cavitynumwkt2con[8] = color;
                }
                if (condition == "22")
                {
                    GlobalVariable.cavitynumwkt2[9] = cavSn;
                    GlobalVariable.cavitynumwkt2con[9] = color;
                }
                if (condition == "32")
                {
                    GlobalVariable.cavitynumwkt2[12] = cavSn;
                    GlobalVariable.cavitynumwkt2con[12] = color;
                }
                if (condition == "31")
                {
                    GlobalVariable.cavitynumwkt2[11] = cavSn;
                    GlobalVariable.cavitynumwkt2con[11] = color;
                }
                if (condition == "30")
                {
                    GlobalVariable.cavitynumwkt2[10] = cavSn;
                    GlobalVariable.cavitynumwkt2con[10] = color;
                }
            }
            else if (GlobalVariable.CavityRows == 3 && GlobalVariable.CavityCols == 4)
            {
                GlobalVariable.cavitynumwkt2[0] = CarSn;
                if (condition == "00")
                {
                    GlobalVariable.cavitynumwkt2[1] = cavSn;
                    GlobalVariable.cavitynumwkt2con[1] = color;
                }
                if (condition == "01")
                {
                    GlobalVariable.cavitynumwkt2[2] = cavSn;
                    GlobalVariable.cavitynumwkt2con[2] = color;
                }
                if (condition == "02")
                {
                    GlobalVariable.cavitynumwkt2[3] = cavSn;
                    GlobalVariable.cavitynumwkt2con[3] = color;
                }
                if (condition == "03")
                {
                    GlobalVariable.cavitynumwkt2[4] = cavSn;
                    GlobalVariable.cavitynumwkt2con[4] = color;
                }
                if (condition == "13")
                {
                    GlobalVariable.cavitynumwkt2[5] = cavSn;
                    GlobalVariable.cavitynumwkt2con[5] = color;
                }
                if (condition == "12")
                {
                    GlobalVariable.cavitynumwkt2[6] = cavSn;
                    GlobalVariable.cavitynumwkt2con[6] = color;
                }
                if (condition == "11")
                {
                    GlobalVariable.cavitynumwkt2[7] = cavSn;
                    GlobalVariable.cavitynumwkt2con[7] = color;
                }
                if (condition == "10")
                {
                    GlobalVariable.cavitynumwkt2[8] = cavSn;
                    GlobalVariable.cavitynumwkt2con[8] = color;
                }
                if (condition == "20")
                {
                    GlobalVariable.cavitynumwkt2[9] = cavSn;
                    GlobalVariable.cavitynumwkt2con[9] = color;
                }
                if (condition == "21")
                {
                    GlobalVariable.cavitynumwkt2[10] = cavSn;
                    GlobalVariable.cavitynumwkt2con[10] = color;
                }
                if (condition == "22")
                {
                    GlobalVariable.cavitynumwkt2[11] = cavSn;
                    GlobalVariable.cavitynumwkt2con[11] = color;
                }
                if (condition == "23")
                {
                    GlobalVariable.cavitynumwkt2[12] = cavSn;
                    GlobalVariable.cavitynumwkt2con[12] = color;
                }
            }
        }


        public bool udateCavity2(int row, int col, string sn, string bn, bool check)
        {
            CARRIER_SN.Text = bn;
            CARRIER_SN_4.Text = bn;
            string codition = row.ToString() + col.ToString();
            GlobalVariable.barcodeViewld[row, col].barcodde = bn;
            GlobalVariable.barcodeViewld[row, col].SN = sn;
            GlobalVariable.barcodeViewld[row, col].Check = check;

            tempupdate(codition, bn, sn, check);

            // if (this.InvokeRequired) { return (bool)this.Invoke(new Func<bool>(() => udateCavity(row, col, sn, bn, check))); };
            if (GlobalVariable.CavityRows == 4 && GlobalVariable.CavityCols == 3) // TESS
            {
                switch (codition)
                {
                    case "00":
                        lblSC_1_4.BackColor = check ? Color.Yellow : Color.Red;
                        lblSC_1_4.Text = sn;
                        break;
                    case "01":
                        lblSC_2_4.BackColor = check ? Color.Yellow : Color.Red;
                        lblSC_2_4.Text = sn;
                        break;
                    case "02":
                        lblSC_3_4.BackColor = check ? Color.Yellow : Color.Red;
                        lblSC_3_4.Text = sn;
                        break;
                    case "12":
                        lblSC_4_4.BackColor = check ? Color.Yellow : Color.Red;
                        lblSC_4_4.Text = sn;
                        break;
                    case "11":
                        lblSC_5_4.BackColor = check ? Color.Yellow : Color.Red;
                        lblSC_5_4.Text = sn;
                        break;
                    case "10":
                        lblSC_6_4.BackColor = check ? Color.Yellow : Color.Red;
                        lblSC_6_4.Text = sn;
                        break;
                    case "20":
                        lblSC_7_4.BackColor = check ? Color.Yellow : Color.Red;
                        lblSC_7_4.Text = sn;
                        break;
                    case "21":
                        lblSC_8_4.BackColor = check ? Color.Yellow : Color.Red;
                        lblSC_8_4.Text = sn;
                        break;
                    case "22":
                        lblSC_9_4.BackColor = check ? Color.Yellow : Color.Red;
                        lblSC_9_4.Text = sn;
                        break;
                    case "32":
                        lblSC_10_4.BackColor = check ? Color.Yellow : Color.Red;
                        lblSC_10_4.Text = sn;
                        break;
                    case "31":
                        lblSC_11_4.BackColor = check ? Color.Yellow : Color.Red;
                        lblSC_11_4.Text = sn;
                        break;
                    case "30":
                        lblSC_12_4.BackColor = check ? Color.Yellow : Color.Red;
                        lblSC_12_4.Text = sn;
                        break;
                }
            }
            else if (GlobalVariable.CavityRows == 3 && GlobalVariable.CavityCols == 4)  // TEHR
            {
                switch (codition)
                {
                    case "00":
                        lblSC_1.BackColor = check ? Color.Yellow : Color.Red;
                        lblSC_1.Text = sn;
                        break;
                    case "01":
                        lblSC_2.BackColor = check ? Color.Yellow : Color.Red;
                        lblSC_2.Text = sn;
                        break;
                    case "02":
                        lblSC_3.BackColor = check ? Color.Yellow : Color.Red;
                        lblSC_3.Text = sn;
                        break;
                    case "03":
                        lblSC_4.BackColor = check ? Color.Yellow : Color.Red;
                        lblSC_4.Text = sn;
                        break;
                    case "13":
                        lblSC_8.BackColor = check ? Color.Yellow : Color.Red;
                        lblSC_8.Text = sn;
                        break;
                    case "12":
                        lblSC_7.BackColor = check ? Color.Yellow : Color.Red;
                        lblSC_7.Text = sn;
                        break;
                    case "11":
                        lblSC_6.BackColor = check ? Color.Yellow : Color.Red;
                        lblSC_6.Text = sn;
                        break;
                    case "10":
                        lblSC_5.BackColor = check ? Color.Yellow : Color.Red;
                        lblSC_5.Text = sn;
                        break;
                    case "20":
                        lblSC_9.BackColor = check ? Color.Yellow : Color.Red;
                        lblSC_9.Text = sn;
                        break;
                    case "21":
                        lblSC_10.BackColor = check ? Color.Yellow : Color.Red;
                        lblSC_10.Text = sn;
                        break;
                    case "22":
                        lblSC_11.BackColor = check ? Color.Yellow : Color.Red;
                        lblSC_11.Text = sn;
                        break;
                    case "23":
                        lblSC_12.BackColor = check ? Color.Yellow : Color.Red;
                        lblSC_12.Text = sn;
                        break;
                }
            }
            else
            {
                MessageBox.Show("Cavity Rows and Columns are not set correctly. Please check the configuration.", "Configuration Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return true;

        }

        public void clearCavity()
        {
            if (this.InvokeRequired)
            {
                //Arulkumar Fixed Null start
                try
                {
                    if (!IsDisposed && IsHandleCreated)
                        this.Invoke(new Action(() => clearCavity1()));
                }
                catch (ObjectDisposedException) { }
                catch (InvalidOperationException) { }
                //Arulkumar Fixed Null end

            }


        }

        public void clearCavity1()
        {
            Array.Clear(GlobalVariable.cavitynum, 0, 13);
            Array.Clear(GlobalVariable.cavitynumcon, 0, 13);

            ///if (this.InvokeRequired) { this.Invoke(new Action(() => clearCavity()));return; } ;
            // GlobalVariable.barcodeViewld.SetValue(0, 0);

            if (GlobalVariable.CavityRows == 4 && GlobalVariable.CavityCols == 3) //TESS
            {
                lblSC_1_4.BackColor = Color.DarkGray;
                lblSC_2_4.BackColor = Color.DarkGray;
                lblSC_3_4.BackColor = Color.DarkGray;
                lblSC_4_4.BackColor = Color.DarkGray;
                lblSC_5_4.BackColor = Color.DarkGray;
                lblSC_6_4.BackColor = Color.DarkGray;
                lblSC_7_4.BackColor = Color.DarkGray;
                lblSC_8_4.BackColor = Color.DarkGray;
                lblSC_9_4.BackColor = Color.DarkGray;
                lblSC_10_4.BackColor = Color.DarkGray;
                lblSC_11_4.BackColor = Color.DarkGray;
                lblSC_12_4.BackColor = Color.DarkGray;
                lblSC_1_4.Text = "";
                lblSC_2_4.Text = "";
                lblSC_3_4.Text = "";
                lblSC_4_4.Text = "";
                lblSC_5_4.Text = "";
                lblSC_6_4.Text = "";
                lblSC_7_4.Text = "";
                lblSC_8_4.Text = "";
                lblSC_9_4.Text = "";
                lblSC_10_4.Text = "";
                lblSC_11_4.Text = "";
                lblSC_12_4.Text = "";
            }
            else if (GlobalVariable.CavityRows == 3 && GlobalVariable.CavityCols == 4) //TEHR
            {
                lblSC_1.BackColor = Color.DarkGray;
                lblSC_2.BackColor = Color.DarkGray;
                lblSC_3.BackColor = Color.DarkGray;
                lblSC_4.BackColor = Color.DarkGray;
                lblSC_5.BackColor = Color.DarkGray;
                lblSC_6.BackColor = Color.DarkGray;
                lblSC_7.BackColor = Color.DarkGray;
                lblSC_8.BackColor = Color.DarkGray;
                lblSC_9.BackColor = Color.DarkGray;
                lblSC_10.BackColor = Color.DarkGray;
                lblSC_11.BackColor = Color.DarkGray;
                lblSC_12.BackColor = Color.DarkGray;
                lblSC_1.Text = "";
                lblSC_2.Text = "";
                lblSC_3.Text = "";
                lblSC_4.Text = "";
                lblSC_5.Text = "";
                lblSC_6.Text = "";
                lblSC_7.Text = "";
                lblSC_8.Text = "";
                lblSC_9.Text = "";
                lblSC_10.Text = "";
                lblSC_11.Text = "";
                lblSC_12.Text = "";
            }
            else
            {
                MessageBox.Show("Cavity Rows and Columns are not set correctly. Please check the configuration.", "Configuration Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }



        }
        public bool udatewk1Cavity(int row, int col, string sn, int check, string bn)
        {
            if (this.InvokeRequired)
            {
                bool result = false;
                //Arulkumar Fixed Null start
                try
                {
                    if (!IsDisposed && IsHandleCreated)
                        this.Invoke(new Action(() => result = udatewk1Cavity2(row, col, sn, check, bn)));
                }
                catch (ObjectDisposedException) { }
                catch (InvalidOperationException) { }
                //Arulkumar Fixed Null end
                return result;
            }

            return udatewk1Cavity2(row, col, sn, check, bn);


        }

        public bool udatewk1Cavity2(int row, int col, string sn, int check, string bn)
        {
            BN_wk1.Text = bn;
            BN_wk1_4.Text = bn;
            string codition = row.ToString() + col.ToString();
            GlobalVariable.barcodeViewwk1[row, col].barcodde = bn;
            GlobalVariable.barcodeViewwk1[row, col].SN = sn;
            GlobalVariable.barcodeViewwk1[row, col].check = check;
            tempupdateWWK1(codition, bn, sn, check);
            if (GlobalVariable.CavityRows == 4 && GlobalVariable.CavityCols == 3) //TESS
            {
                switch (codition)
                {
                    case "00":
                        lblAS_1_4.BackColor = check == 1 ? Color.Yellow : (check == 2 ? Color.Red : check == 3 ? Color.Green : Color.DarkGray);
                        lblAS_1_4.Text = sn;
                        break;
                    case "01":
                        lblAS_2_4.BackColor = check == 1 ? Color.Yellow : (check == 2 ? Color.Red : check == 3 ? Color.Green : Color.DarkGray);
                        lblAS_2_4.Text = sn;
                        break;
                    case "02":
                        lblAS_3_4.BackColor = check == 1 ? Color.Yellow : (check == 2 ? Color.Red : check == 3 ? Color.Green : Color.DarkGray);
                        lblAS_3_4.Text = sn;
                        break;
                    case "12":
                        lblAS_6_4.BackColor = check == 1 ? Color.Yellow : (check == 2 ? Color.Red : check == 3 ? Color.Green : Color.DarkGray);
                        lblAS_6_4.Text = sn;
                        break;
                    case "11":
                        lblAS_5_4.BackColor = check == 1 ? Color.Yellow : (check == 2 ? Color.Red : check == 3 ? Color.Green : Color.DarkGray);
                        lblAS_5_4.Text = sn;
                        break;
                    case "10":
                        lblAS_4_4.BackColor = check == 1 ? Color.Yellow : (check == 2 ? Color.Red : check == 3 ? Color.Green : Color.DarkGray);
                        lblAS_4_4.Text = sn;
                        break;
                    case "20":
                        lblAS_7_4.BackColor = check == 1 ? Color.Yellow : (check == 2 ? Color.Red : check == 3 ? Color.Green : Color.DarkGray);
                        lblAS_7_4.Text = sn;
                        break;
                    case "21":
                        lblAS_8_4.BackColor = check == 1 ? Color.Yellow : (check == 2 ? Color.Red : check == 3 ? Color.Green : Color.DarkGray);
                        lblAS_8_4.Text = sn;
                        break;
                    case "22":
                        lblAS_9_4.BackColor = check == 1 ? Color.Yellow : (check == 2 ? Color.Red : check == 3 ? Color.Green : Color.DarkGray);
                        lblAS_9_4.Text = sn;
                        break;
                    case "32":
                        lblAS_12_4.BackColor = check == 1 ? Color.Yellow : (check == 2 ? Color.Red : check == 3 ? Color.Green : Color.DarkGray);
                        lblAS_12_4.Text = sn;
                        break;
                    case "31":
                        lblAS_11_4.BackColor = check == 1 ? Color.Yellow : (check == 2 ? Color.Red : check == 3 ? Color.Green : Color.DarkGray);
                        lblAS_11_4.Text = sn;
                        break;
                    case "30":
                        lblAS_10_4.BackColor = check == 1 ? Color.Yellow : (check == 2 ? Color.Red : check == 3 ? Color.Green : Color.DarkGray);
                        lblAS_10_4.Text = sn;
                        break;
                }
            }
            else if (GlobalVariable.CavityRows == 3 && GlobalVariable.CavityCols == 4) //TEHR
            {
                switch (codition)
                {
                    case "00":
                        lblAS_1.BackColor = check == 1 ? Color.Yellow : (check == 2 ? Color.Red : check == 3 ? Color.Green : Color.DarkGray);
                        lblAS_1.Text = sn;
                        break;
                    case "01":
                        lblAS_2.BackColor = check == 1 ? Color.Yellow : (check == 2 ? Color.Red : check == 3 ? Color.Green : Color.DarkGray);
                        lblAS_2.Text = sn;
                        break;
                    case "02":
                        lblAS_3.BackColor = check == 1 ? Color.Yellow : (check == 2 ? Color.Red : check == 3 ? Color.Green : Color.DarkGray);
                        lblAS_3.Text = sn;
                        break;
                    case "03":
                        lblAS_4.BackColor = check == 1 ? Color.Yellow : (check == 2 ? Color.Red : check == 3 ? Color.Green : Color.DarkGray);
                        lblAS_4.Text = sn;
                        break;
                    case "13":
                        lblAS_8.BackColor = check == 1 ? Color.Yellow : (check == 2 ? Color.Red : check == 3 ? Color.Green : Color.DarkGray);
                        lblAS_8.Text = sn;
                        break;
                    case "12":
                        lblAS_7.BackColor = check == 1 ? Color.Yellow : (check == 2 ? Color.Red : check == 3 ? Color.Green : Color.DarkGray);
                        lblAS_7.Text = sn;
                        break;
                    case "11":
                        lblAS_6.BackColor = check == 1 ? Color.Yellow : (check == 2 ? Color.Red : check == 3 ? Color.Green : Color.DarkGray);
                        lblAS_6.Text = sn;
                        break;
                    case "10":
                        lblAS_5.BackColor = check == 1 ? Color.Yellow : (check == 2 ? Color.Red : check == 3 ? Color.Green : Color.DarkGray);
                        lblAS_5.Text = sn;
                        break;
                    case "20":
                        lblAS_9.BackColor = check == 1 ? Color.Yellow : (check == 2 ? Color.Red : check == 3 ? Color.Green : Color.DarkGray);
                        lblAS_9.Text = sn;
                        break;
                    case "21":
                        lblAS_10.BackColor = check == 1 ? Color.Yellow : (check == 2 ? Color.Red : check == 3 ? Color.Green : Color.DarkGray);
                        lblAS_10.Text = sn;
                        break;
                    case "22":
                        lblAS_11.BackColor = check == 1 ? Color.Yellow : (check == 2 ? Color.Red : check == 3 ? Color.Green : Color.DarkGray);
                        lblAS_11.Text = sn;
                        break;
                    case "23":
                        lblAS_12.BackColor = check == 1 ? Color.Yellow : (check == 2 ? Color.Red : check == 3 ? Color.Green : Color.DarkGray);
                        lblAS_12.Text = sn;
                        break;
                }
            }
            else
            {
                MessageBox.Show("Cavity Rows and Columns are not set correctly. Please check the configuration.", "Configuration Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return true;

        }
        public void clearwk1Cavity()
        {
            if (this.InvokeRequired)
            {
                //Arulkumar Fixed Null start
                try
                {
                    if (!IsDisposed && IsHandleCreated)
                        this.Invoke(new Action(() => clearwk1Cavity1()));
                }
                catch (ObjectDisposedException) { }
                catch (InvalidOperationException) { }
                //Arulkumar Fixed Null end

            }


        }
        public void clearwk1Cavity1()
        {
            Array.Clear(GlobalVariable.cavitynumwkt1, 0, 13);
            Array.Clear(GlobalVariable.cavitynumwkt1con, 0, 13);
            // GlobalVariable.barcodeViewwk1.SetValue(0, 0);
            //if (this.InvokeRequired) { this.Invoke(new Action(() => clearwk1Cavity())); return; };
            if (GlobalVariable.CavityRows == 4 && GlobalVariable.CavityCols == 3) //TESS
            {

                lblAS_1_4.BackColor = Color.DarkGray;
                lblAS_4_4.BackColor = Color.DarkGray;
                lblAS_2_4.BackColor = Color.DarkGray;
                lblAS_5_4.BackColor = Color.DarkGray;
                lblAS_3_4.BackColor = Color.DarkGray;
                lblAS_6_4.BackColor = Color.DarkGray;
                lblAS_7_4.BackColor = Color.DarkGray;
                lblAS_10_4.BackColor = Color.DarkGray;
                lblAS_8_4.BackColor = Color.DarkGray;
                lblAS_11_4.BackColor = Color.DarkGray;
                lblAS_9_4.BackColor = Color.DarkGray;
                lblAS_12_4.BackColor = Color.DarkGray;
                lblAS_1_4.Text = "";
                lblAS_2_4.Text = "";
                lblAS_3_4.Text = "";
                lblAS_4_4.Text = "";
                lblAS_5_4.Text = "";
                lblAS_6_4.Text = "";
                lblAS_7_4.Text = "";
                lblAS_8_4.Text = "";
                lblAS_9_4.Text = "";
                lblAS_10_4.Text = "";
                lblAS_11_4.Text = "";
                lblAS_12_4.Text = "";
            }
            else if (GlobalVariable.CavityRows == 3 && GlobalVariable.CavityCols == 4) //TEHR
            {
                lblAS_1.BackColor = Color.DarkGray;
                lblAS_2.BackColor = Color.DarkGray;
                lblAS_3.BackColor = Color.DarkGray;
                lblAS_4.BackColor = Color.DarkGray;
                lblAS_5.BackColor = Color.DarkGray;
                lblAS_6.BackColor = Color.DarkGray;
                lblAS_7.BackColor = Color.DarkGray;
                lblAS_8.BackColor = Color.DarkGray;
                lblAS_9.BackColor = Color.DarkGray;
                lblAS_10.BackColor = Color.DarkGray;
                lblAS_11.BackColor = Color.DarkGray;
                lblAS_12.BackColor = Color.DarkGray;
                lblAS_1.Text = "";
                lblAS_2.Text = "";
                lblAS_3.Text = "";
                lblAS_4.Text = "";
                lblAS_5.Text = "";
                lblAS_6.Text = "";
                lblAS_7.Text = "";
                lblAS_8.Text = "";
                lblAS_9.Text = "";
                lblAS_10.Text = "";
                lblAS_11.Text = "";
                lblAS_12.Text = "";
            }



        }
        public bool udatewk2Cavity(int row, int col, string sn, bool check, string bn)
        {
            if (this.InvokeRequired)
            {
                bool result = false;
                //Arulkumar Fixed Null start
                try
                {
                    if (!IsDisposed && IsHandleCreated)
                        this.Invoke(new Action(() => result = udatewk2Cavity2(row, col, sn, check, bn)));
                }
                catch (ObjectDisposedException) { }
                catch (InvalidOperationException) { }
                //Arulkumar Fixed Null end
                return result;
            }

            return udatewk2Cavity2(row, col, sn, check, bn);


        }
        public bool udatewk2Cavity2(int row, int col, string sn, bool check, string bn)
        {
            BN_WK2.Text = bn;
            BN_WK2_4.Text = bn;
            string codition = row.ToString() + col.ToString();
            GlobalVariable.barcodeViewwk2[row, col].barcodde = bn;
            GlobalVariable.barcodeViewwk2[row, col].SN = sn;
            GlobalVariable.barcodeViewwk2[row, col].Check = check;
            tempupdateWK2(codition, bn, sn, check);
            if (GlobalVariable.CavityRows == 4 && GlobalVariable.CavityCols == 3) //TESS
            {
                switch (codition)
                {
                    case "00":
                        if (check == true)
                        {
                            lblFI_1_4.BackColor = Color.Green;
                            lblFI_1_4.Text = sn;
                        }
                        else
                        {
                            lblFI_1_4.BackColor = Color.Red;
                            lblFI_1_4.Text = sn;
                        }
                        break;
                    case "01":
                        if (check == true)
                        {
                            lblFI_2_4.BackColor = Color.Green;
                            lblFI_2_4.Text = sn;
                        }
                        else
                        {
                            lblFI_2_4.BackColor = Color.Red;
                            lblFI_2_4.Text = sn;
                        }
                        break;
                    case "02":
                        if (check == true)
                        {
                            lblFI_3_4.BackColor = Color.Green;
                            lblFI_3_4.Text = sn;
                        }
                        else
                        {
                            lblFI_3_4.BackColor = Color.Red;
                            lblFI_3_4.Text = sn;
                        }
                        break;
                    case "12":
                        if (check == true)
                        {
                            lblFI_6_4.BackColor = Color.Green;
                            lblFI_6_4.Text = sn;
                        }
                        else
                        {
                            lblFI_6_4.BackColor = Color.Red;
                            lblFI_6_4.Text = sn;
                        }
                        break;
                    case "11":
                        if (check == true)
                        {
                            lblFI_5_4.BackColor = Color.Green;
                            lblFI_5_4.Text = sn;
                        }
                        else
                        {
                            lblFI_5_4.BackColor = Color.Red;
                            lblFI_5_4.Text = sn;
                        }
                        break;
                    case "10":
                        if (check == true)
                        {
                            lblFI_4_4.BackColor = Color.Green;
                            lblFI_4_4.Text = sn;
                        }
                        else
                        {
                            lblFI_4_4.BackColor = Color.Red;
                            lblFI_4_4.Text = sn;
                        }
                        break;
                    case "20":
                        if (check == true)
                        {
                            lblFI_7_4.BackColor = Color.Green;
                            lblFI_7_4.Text = sn;
                        }
                        else
                        {
                            lblFI_7_4.BackColor = Color.Red;
                            lblFI_7_4.Text = sn;
                        }
                        break;
                    case "21":
                        if (check == true)
                        {
                            lblFI_8_4.BackColor = Color.Green;
                            lblFI_8_4.Text = sn;
                        }
                        else
                        {
                            lblFI_8_4.BackColor = Color.Red;
                            lblFI_8_4.Text = sn;
                        }
                        break;
                    case "22":
                        if (check == true)
                        {
                            lblFI_9_4.BackColor = Color.Green;
                            lblFI_9_4.Text = sn;
                        }
                        else
                        {
                            lblFI_9_4.BackColor = Color.Red;
                            lblFI_9_4.Text = sn;
                        }
                        break;
                    case "32":
                        if (check == true)
                        {
                            lblFI_12_4.BackColor = Color.Green;
                            lblFI_12_4.Text = sn;
                        }
                        else
                        {
                            lblFI_12_4.BackColor = Color.Red;
                            lblFI_12_4.Text = sn;
                        }
                        break;
                    case "31":
                        if (check == true)
                        {
                            lblFI_11_4.BackColor = Color.Green;
                            lblFI_11_4.Text = sn;
                        }
                        else
                        {
                            lblFI_11_4.BackColor = Color.Red;
                            lblFI_11_4.Text = sn;
                        }
                        break;
                    case "30":
                        //lblFI_10.BackColor = check ? Color.Green : Color.Red;
                        //lblFI_10.Text = sn;
                        if (check == true)
                        {
                            lblFI_10_4.BackColor = Color.Green;
                            lblFI_10_4.Text = sn;
                        }
                        else
                        {
                            lblFI_10_4.BackColor = Color.Red;
                            lblFI_10_4.Text = sn;
                        }
                        break;
                }
            }
            else if (GlobalVariable.CavityRows == 3 && GlobalVariable.CavityCols == 4) //TEHR
            {
                switch (codition)
                {
                    case "00":
                        lblFI_1.BackColor = check ? Color.Green : Color.Red;
                        lblFI_1.Text = sn;
                        break;
                    case "01":
                        lblFI_2.BackColor = check ? Color.Green : Color.Red;
                        lblFI_2.Text = sn;
                        break;
                    case "02":
                        lblFI_3.BackColor = check ? Color.Green : Color.Red;
                        lblFI_3.Text = sn;
                        break;
                    case "03":
                        lblFI_4.BackColor = check ? Color.Green : Color.Red;
                        lblFI_4.Text = sn;
                        break;
                    case "13":
                        lblFI_8.BackColor = check ? Color.Green : Color.Red;
                        lblFI_8.Text = sn;
                        break;
                    case "12":
                        lblFI_7.BackColor = check ? Color.Green : Color.Red;
                        lblFI_7.Text = sn;
                        break;
                    case "11":
                        lblFI_6.BackColor = check ? Color.Green : Color.Red;
                        lblFI_6.Text = sn;
                        break;
                    case "10":
                        lblFI_5.BackColor = check ? Color.Green : Color.Red;
                        lblFI_5.Text = sn;
                        break;
                    case "20":
                        lblFI_9.BackColor = check ? Color.Green : Color.Red;
                        lblFI_9.Text = sn;
                        break;
                    case "21":
                        lblFI_10.BackColor = check ? Color.Green : Color.Red;
                        lblFI_10.Text = sn;
                        break;
                    case "22":
                        lblFI_11.BackColor = check ? Color.Green : Color.Red;
                        lblFI_11.Text = sn;
                        break;
                    case "23":
                        lblFI_12.BackColor = check ? Color.Green : Color.Red;
                        lblFI_12.Text = sn;
                        break;
                }
            }
            else
            {
                MessageBox.Show("Cavity Rows and Columns are not set correctly. Please check the configuration.", "Configuration Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return true;

        }

        public void clearwk2Cavity()
        {
            if (this.InvokeRequired)
            {
                //Arulkumar Fixed Null start
                try
                {
                    if (!IsDisposed && IsHandleCreated)
                        this.Invoke(new Action(() => clearwk2Cavity1()));
                }
                catch (ObjectDisposedException) { }
                catch (InvalidOperationException) { }
                //Arulkumar Fixed Null end

            }


        }
        public void clearwk2Cavity1()
        {
            Array.Clear(GlobalVariable.cavitynumwkt2, 0, 13);
            Array.Clear(GlobalVariable.cavitynumwkt2con, 0, 13);
            //GlobalVariable.barcodeViewwk2.SetValue(0, 0);
            // if (this.InvokeRequired) { this.Invoke(new Action(() => clearwk2Cavity()));return; }
            if (GlobalVariable.CavityRows == 4 && GlobalVariable.CavityCols == 3) //TESS
            {
                lblFI_1_4.BackColor = Color.DarkGray;
                lblFI_4_4.BackColor = Color.DarkGray;
                lblFI_7_4.BackColor = Color.DarkGray;
                lblFI_10_4.BackColor = Color.DarkGray;
                lblFI_11_4.BackColor = Color.DarkGray;
                lblFI_8_4.BackColor = Color.DarkGray;
                lblFI_5_4.BackColor = Color.DarkGray;
                lblFI_2_4.BackColor = Color.DarkGray;
                lblFI_3_4.BackColor = Color.DarkGray;
                lblFI_6_4.BackColor = Color.DarkGray;
                lblFI_9_4.BackColor = Color.DarkGray;
                lblFI_12_4.BackColor = Color.DarkGray;
                lblFI_1_4.Text = "";
                lblFI_2_4.Text = "";
                lblFI_3_4.Text = "";
                lblFI_4_4.Text = "";
                lblFI_5_4.Text = "";
                lblFI_6_4.Text = "";
                lblFI_7_4.Text = "";
                lblFI_8_4.Text = "";
                lblFI_9_4.Text = "";
                lblFI_10_4.Text = "";
                lblFI_11_4.Text = "";
                lblFI_12_4.Text = "";

            }
            else if (GlobalVariable.CavityRows == 3 && GlobalVariable.CavityCols == 4) //TEHR
            {
                lblFI_1.BackColor = Color.DarkGray;
                lblFI_2.BackColor = Color.DarkGray;
                lblFI_3.BackColor = Color.DarkGray;
                lblFI_4.BackColor = Color.DarkGray;
                lblFI_5.BackColor = Color.DarkGray;
                lblFI_6.BackColor = Color.DarkGray;
                lblFI_7.BackColor = Color.DarkGray;
                lblFI_8.BackColor = Color.DarkGray;
                lblFI_9.BackColor = Color.DarkGray;
                lblFI_10.BackColor = Color.DarkGray;
                lblFI_11.BackColor = Color.DarkGray;
                lblFI_12.BackColor = Color.DarkGray;
                lblFI_1.Text = "";
                lblFI_2.Text = "";
                lblFI_3.Text = "";
                lblFI_4.Text = "";
                lblFI_5.Text = "";
                lblFI_6.Text = "";
                lblFI_7.Text = "";
                lblFI_8.Text = "";
                lblFI_9.Text = "";
                lblFI_10.Text = "";
                lblFI_11.Text = "";
                lblFI_12.Text = "";
            }
            else
            {
                MessageBox.Show("Cavity Rows and Columns are not set correctly. Please check the configuration.", "Configuration Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }



        }
        public async void check()
        {
            //Arulkumar Fixed random stoppage start
            try
            {
                PalletData[,] data1 = new PalletData[GlobalVariable.CavityRows, GlobalVariable.CavityCols];
                LoadingConveyor ld = new LoadingConveyor(GlobalVariable.scannerCnvPositions);
                // WorkingConveyor2 wk2 = new WorkingConveyor2(GlobalVariable.Wk2Positions);
                // WorkingConveyor1 wk1=new WorkingConveyor1(GlobalVariable.Wk2Positions);
                // await ld.Run(data1);
            }
            catch (Exception ex)
            {
                Logger.WriteLog(Logger.LogType.Error, "HomeScreen", "check", ex.Message, ex.ToString());
            }
            //Arulkumar Fixed random stoppage end
        }

        private void button5_ClickAsync(object sender, EventArgs e)
        {
            feder();

        }
        public async void feder()
        {
            //Arulkumar Fixed random stoppage start
            try
            {
                await Feeding.Feed();
            }
            catch (Exception ex)
            {
                Logger.WriteLog(Logger.LogType.Error, "HomeScreen", "feder", ex.Message, ex.ToString());
            }
            //Arulkumar Fixed random stoppage end
        }

        private async void button1_Click_1(object sender, EventArgs e)
        {
            if ((GlobalVariable.bautoseq_running && GlobalVariable.current_MCStatus == GlobalVariable.MachineStatus.Pause) || (GlobalVariable.current_MCStatus == GlobalVariable.MachineStatus.Stop || GlobalVariable.current_MCStatus == GlobalVariable.MachineStatus.EStop))
            {

                await Logger.WriteLogasTask(Logger.LogType.Running, " Homescreen", "button1_Click_1", "Empty nozzle clicked. Tossing graphite", "");
                int Graphite_TossCount = 0; // AK
                Task T1 = Task.Run(() => NozzleSystem.Nozzle1safe(GlobalVariable.SafePosition));
                Task T2 = Task.Run(() => NozzleSystem.Nozzle2safe(GlobalVariable.SafePosition));
                await Task.WhenAll(T1, T2);
                double Safe_pos = ObjectList.Servo_Z1.GetCurrentPosition();
                double Safe_pos2 = ObjectList.Servo_Z2.GetCurrentPosition();

                if (Safe_pos <= -17 && Safe_pos2 <= -17)
                {
                    Task T3 = Task.Run(() => ObjectList.Servo_X1.Move_Abs(Convert.ToDouble(GlobalVariable.WK1_initial.PositionX), Convert.ToDouble(GlobalVariable.WK1_initial.XVel), Convert.ToDouble(GlobalVariable.WK1_initial.XAcc), Convert.ToDouble(GlobalVariable.WK1_initial.XDeAcc), 15000));
                    Task T4 = Task.Run(() => ObjectList.Servo_Y1.Move_Abs(Convert.ToDouble(GlobalVariable.WK1_initial.PositionY), Convert.ToDouble(GlobalVariable.WK1_initial.YVel), Convert.ToDouble(GlobalVariable.WK1_initial.YAcc), Convert.ToDouble(GlobalVariable.WK1_initial.YDeAcc), 15000));
                    await Task.WhenAll(T3, T4);

                    if (!GlobalVariable.DI[(int)EInput.Pick_Place_Z1_Axis_Vaccuum_Fb] && !GlobalVariable.DI[(int)EInput.Pick_Place_Z2_Axis_Vaccuum_Fb])
                    {
                        Vacuum_config.Vacuums_List[(int)Vacuum_config.Vacuums.Vacuum1].Blow_On();
                        Vacuum_config.Vacuums_List[(int)Vacuum_config.Vacuums.Vacuum2].Blow_On();
                        await Task.Delay(100);
                        Vacuum_config.Vacuums_List[(int)Vacuum_config.Vacuums.Vacuum1].Both_Vacuum_and_Blow_Off();
                        Vacuum_config.Vacuums_List[(int)Vacuum_config.Vacuums.Vacuum2].Both_Vacuum_and_Blow_Off();

                        GlobalVariable.dGlobal_GraphiteToss_Count = GlobalVariable.dGlobal_GraphiteToss_Count + 2;
                        if (GlobalVariable.dGlobal_GraphiteToss_Count != 0)
                            ProductionDataSaver.TossingdataFile("2", GlobalVariable.dGlobal_GraphiteToss_Count);
                    }
                    else if (!GlobalVariable.DI[(int)EInput.Pick_Place_Z1_Axis_Vaccuum_Fb]) // 

                    {
                        Vacuum_config.Vacuums_List[(int)Vacuum_config.Vacuums.Vacuum1].Blow_On();
                        await Task.Delay(100);
                        Vacuum_config.Vacuums_List[(int)Vacuum_config.Vacuums.Vacuum1].Both_Vacuum_and_Blow_Off();

                        GlobalVariable.dGlobal_GraphiteToss_Count = GlobalVariable.dGlobal_GraphiteToss_Count + 1;
                        if (GlobalVariable.dGlobal_GraphiteToss_Count != 0)
                            ProductionDataSaver.TossingdataFile("1", GlobalVariable.dGlobal_GraphiteToss_Count);
                    }
                    else if (!GlobalVariable.DI[(int)EInput.Pick_Place_Z2_Axis_Vaccuum_Fb])
                    {
                        Vacuum_config.Vacuums_List[(int)Vacuum_config.Vacuums.Vacuum2].Blow_On();
                        await Task.Delay(100);
                        Vacuum_config.Vacuums_List[(int)Vacuum_config.Vacuums.Vacuum2].Both_Vacuum_and_Blow_Off();

                        GlobalVariable.dGlobal_GraphiteToss_Count = GlobalVariable.dGlobal_GraphiteToss_Count + 1;
                        if (GlobalVariable.dGlobal_GraphiteToss_Count != 0)
                            ProductionDataSaver.TossingdataFile("1", GlobalVariable.dGlobal_GraphiteToss_Count);
                    }

                }
                else
                {
                    MessageBox.Show("Nozzle 1 and Nozzle 2 not safe pos ensure both nozzle safe...!");
                }



                //await GantrySystem.move(GlobalVariable.Wk1_Z2FedPos, GlobalVariable.WK1_initial.PositionX, GlobalVariable.WK1_initial.PositionY);


            }
            else
            {
                MessageBox.Show("Auto Seq is running....!");
            }




        }

        private void button2_Click(object sender, EventArgs e)
        {
            //var result = Advantech.Motion.Motion.mAcm_DevGetSlaveInfo();




            Advantech_PCIE.Reopen();
        }

        private void MS_clear_Click(object sender, EventArgs e) // AK
        {

            GlobalVariable.dGlobal_Pass_count = 0;
            GlobalVariable.dGlobal_Pass_count = 0;
            GlobalVariable.dGlobal_Total_count = 0;
            GlobalVariable.dGlobal_Yield_Count = 0;
            GlobalVariable.dGlobal_Cycle_time = 0;
            GlobalVariable.Nozzletossing = 0;
            GlobalVariable.dGlobal_Reject_count = 0;
            GlobalVariable.dGlobal_GraphiteToss_Count = 0;
            GlobalVariable.cycle_time = 0;
            GlobalVariable.dGlobal_Cycle_time = 0;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //Random rand = new Random();
            //double randomOffset = rand.NextDouble();
            //string text = randomOffset.ToString("0.000");
            //double val1 = Convert.ToDouble(text);

        }

        private void MachineLamp_Click(object sender, EventArgs e) // AK
        {
            if (GlobalVariable.DO[(int)EOutput.M_C_Lamp_On_Sig])
            {
                GlobalVariable.DIDO.WriteOPS(false, (int)EOutput.M_C_Lamp_On_Sig);
                MachineLamp.BackColor = Color.White;
            }
            else
            {
                GlobalVariable.DIDO.WriteOPS(true, (int)EOutput.M_C_Lamp_On_Sig);
                MachineLamp.BackColor = Color.Green;
            }
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void tabPage5_Click(object sender, EventArgs e)
        {


        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        public void WriteDataTableToCsv(DataTable dataTable, string filePath)
        {
            try
            {


                // Create a StreamWriter to write to the CSV file
                if (File.Exists(filePath))
                {
                    using (StreamWriter writer = new StreamWriter(filePath))
                    {
                        // Write the column headers
                        for (int i = 0; i < dataTable.Columns.Count; i++)
                        {
                            writer.Write(dataTable.Columns[i].ColumnName);
                            if (i < dataTable.Columns.Count - 1)
                                writer.Write(',');
                        }
                        writer.WriteLine();

                        // Write the rows
                        foreach (DataRow row in dataTable.Rows)
                        {
                            for (int i = 0; i < dataTable.Columns.Count; i++)
                            {
                                writer.Write(row[i].ToString());
                                if (i < dataTable.Columns.Count - 1)
                                    writer.Write(',');
                            }
                            writer.WriteLine();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Recipe Param File is missing", "Recipe Group Manager Software", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog(Logger.LogType.Error, "ReceipeForm", "", ex.Message, ex.ToString());
            }
        }

        public void AppendSelectedModuleToOffsetHistory(DataTable dt, string moduleName)
        {
            try
            {

            
                string historyPath = "";
                bool writeHeader ;

                historyPath = @"D:\TEAL\Home_Screen\";
                if (!Directory.Exists(historyPath))
                {
                    Directory.CreateDirectory(historyPath);

                }

                //string historyPath = Path.Combine(Environment.CurrentDirectory, "Data", "Save_History.csv");
                if (tabControl1.SelectedTab == tabPage6)
                {
                    historyPath = @"D:\TEAL\Home_Screen\Offset_Pages";
                    if (!Directory.Exists(historyPath))
                    {
                        Directory.CreateDirectory(historyPath);


                    }

                    if (tabControl2.SelectedTab == tabPage13)
                    {
                        
                        historyPath = historyPath + "\\offset.csv";


                    }
                    if (tabControl2.SelectedTab == tabPage7)
                    {
                        historyPath = historyPath + "\\offsetK.csv";


                    }
                    if (tabControl2.SelectedTab == tabPage9)
                    {
                        historyPath = historyPath + "\\offsetNK.csv";

                    }

                }
                if (tabControl1.SelectedTab == tabPage8)
                {
                    historyPath = historyPath + "\\Ae_Parameter.csv";

                }
                if (tabControl1.SelectedTab == tabPage10)
                {
                    historyPath = historyPath + "\\Delay.csv";

                }
                if (tabControl1.SelectedTab == tabPage11)
                {
                    historyPath += "\\Sfc_Pdca.csv";

                }
                if (tabControl1.SelectedTab == tabPage12)
                {
                    historyPath = historyPath +"\\Feeder.csv";

                }

                 writeHeader = !File.Exists(historyPath);
                using (StreamWriter writer = new StreamWriter(historyPath, true))
                {
                    //if (writeHeader)
                    //{
                    //    writer.WriteLine("Module,DateTime");
                    //}
                    int rowCount = dt.Rows.Count;
                    writer.WriteLine($"Module_Name : {moduleName.ToUpper()} ");
                    writer.WriteLine("Date&Time : " + DateTime.Now.ToString());

                    writer.WriteLine();
                    writer.WriteLine(string.Join(",", dt.Columns.Cast<DataColumn>().Select(c => c.ColumnName)));
                    foreach (DataRow row in dt.Rows)
                    {
                        {
                            writer.WriteLine(string.Join(",", row.ItemArray.Select(x => x.ToString())));
                        }
                    }
                    writer.WriteLine();
                    writer.WriteLine();
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog(Logger.LogType.Error, "Save_History", "", ex.Message, ex.ToString());
            }
        }



        #region AE Parameter
        private void editbtn_AE_Click(object sender, EventArgs e)
        {
            dgv_AE.Enabled = true;
        }
        private void savebtn_AE_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            try
            {
                dgv_AE.Enabled = false;
                dgv_AE.Enabled = false;

                DialogResult result = MessageBox.Show("Do you want to save the Data", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    dt = (DataTable)dgv_AE.DataSource;

                    WriteDataTableToCsv(dt, Teach_filepath + "AEPARAMETER.csv");

                    GlobalVariable.LoadReceipe();
                    AppendSelectedModuleToOffsetHistory(dt, "AEPARAMETER");


                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog(Logger.LogType.Error, "HomeScreen", "", ex.Message, ex.ToString());
            }
        }
        #endregion

        #region DELAY
        private void editbtn_delay_Click(object sender, EventArgs e)
        {
            dgv_delay.Enabled = true;
            dgv_delay.ReadOnly = false;
        }

        private void savebtn_delay_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            try
            {
                dgv_delay.Enabled = false;
                dgv_delay.Enabled = false;

                DialogResult result = MessageBox.Show("Do you want to save the Data", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    dt = (DataTable)dgv_delay.DataSource;

                    WriteDataTableToCsv(dt, Teach_filepath + "DELAY.csv");

                    GlobalVariable.LoadReceipe();
                    AppendSelectedModuleToOffsetHistory(dt, "DELAY");



                }
                dgv_delay.ReadOnly = true;
            }
            catch (Exception ex)
            {
                Logger.WriteLog(Logger.LogType.Error, "HomeScreen", "", ex.Message, ex.ToString());
            }
        }
        #endregion

        #region SFC AND PDCA
        private void SFC_Edit_Click(object sender, EventArgs e)
        {
            SFCGridview.Enabled = true;
        }

        private void SFC_Save_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            try
            {
                SFCGridview.Enabled = false;
                SFCGridview.Enabled = false;

                DialogResult result = MessageBox.Show("Do you want to save the Data", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    dt = (DataTable)SFCGridview.DataSource;

                    WriteDataTableToCsv(dt, Teach_filepath + "SFC_PDCA_Data.csv");

                    GlobalVariable.LoadReceipe();
                    AppendSelectedModuleToOffsetHistory(dt, "SFC_PDCA_Data");


                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog(Logger.LogType.Error, "HomeScreen", "", ex.Message, ex.ToString());
            }
        }
        #endregion

        #region OFFSET
        private void editbtn_offset_Click(object sender, EventArgs e)
        {
            dgv_offset.Enabled = true;
        }
        private void savebtn_offset_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            try
            {
                dgv_offset.Enabled = false;
                dgv_offset.Enabled = false;

                DialogResult result = MessageBox.Show("Do you want to save the Data", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    dt = (DataTable)dgv_offset.DataSource;

                    WriteDataTableToCsv(dt, Teach_filepath + "OFFSET.csv");

                    GlobalVariable.LoadReceipe();
                    AppendSelectedModuleToOffsetHistory(dt, "OFFSET");


                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog(Logger.LogType.Error, "ReceipeForm", "", ex.Message, ex.ToString());
            }
        }
        #endregion

        #region OFFSET K

        private void editbtn_offsetK_Click(object sender, EventArgs e)
        {
            dgv_offsetK.Enabled = true;

        }

        private void savebtn_offsetK_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            try
            {
                dgv_offsetK.Enabled = false;
                dgv_offsetK.Enabled = false;

                DialogResult result = MessageBox.Show("Do you want to save the Data", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    dt = (DataTable)dgv_offsetK.DataSource;

                    WriteDataTableToCsv(dt, Teach_filepath + "OFFSETK.csv");

                    GlobalVariable.LoadReceipe();
                    AppendSelectedModuleToOffsetHistory(dt, "OFFSETK");


                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog(Logger.LogType.Error, "ReceipeForm", "", ex.Message, ex.ToString());
            }
        }

        #endregion

        #region OFFSE NK
        private void ApplyNkOffsetTabs()
        {
            _suppressOffsetTabChange = true;
            try
            {
                // Select the appropriate tab based on enabled flags
                //if (GlobalVariable.K_Enable)
                //{
                //    tabControl2.SelectedTab = tabPage7; // K Offset tab
                //}
                //else if (GlobalVariable.NK_Enable)
                //{
                //    tabControl2.SelectedTab = tabPage9; // NK Offset tab
                //}
                //else
                //{
                //    tabControl2.SelectedTab = tabPage13; // Default Offset tab
                //}

                tabControl2.SelectedTab = GlobalVariable.K_Enable ? tabPage7 : GlobalVariable.NK_Enable ? tabPage9 : tabPage13;
            }
            finally
            {
                _suppressOffsetTabChange = false;
            }
        }

        private void tabControl2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_suppressOffsetTabChange)
                return;

            // K_Enable: Only allow tabPage7 (K Offset)
            if (GlobalVariable.K_Enable)
            {
                if (tabControl2.SelectedTab != tabPage7)
                {
                    MessageBox.Show("Currently K Model is active.\nPlease use K OFFSET.", "Offset", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    _suppressOffsetTabChange = true;
                    try
                    {
                        tabControl2.SelectedTab = tabPage7;
                    }
                    finally
                    {
                        _suppressOffsetTabChange = false;
                    }
                }
            }
            // NK_Enable: Only allow tabPage9 (NK Offset)
            else if (GlobalVariable.NK_Enable)
            {
                if (tabControl2.SelectedTab != tabPage9)
                {
                    MessageBox.Show("Currently NK Model is active.\nPlease use NK OFFSET.", "Offset", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    _suppressOffsetTabChange = true;
                    try
                    {
                        tabControl2.SelectedTab = tabPage9;
                    }
                    finally
                    {
                        _suppressOffsetTabChange = false;
                    }
                }
            }
            // Neither enabled: Only allow tabPage13 (Default Offset)
            else
            {
                if (tabControl2.SelectedTab != tabPage13)
                {
                    MessageBox.Show("No specific model is active.\nPlease use the default OFFSET.", "Offset", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    _suppressOffsetTabChange = true;
                    try
                    {
                        tabControl2.SelectedTab = tabPage13;
                    }
                    finally
                    {
                        _suppressOffsetTabChange = false;
                    }
                }
            }
        }

        protected override void OnActivated(EventArgs e)
        {
            base.OnActivated(e);
            ApplyNkOffsetTabs();
        }

        private void editbtn_offsetNk_Click(object sender, EventArgs e)
        {
            dgv_offsetNk.Enabled = true;
        }
        private void savebtn_offsetNk_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            try
            {
                dgv_offsetNk.Enabled = false;
                dgv_offsetNk.Enabled = false;

                DialogResult result = MessageBox.Show("Do you want to save the Data", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    dt = (DataTable)dgv_offsetNk.DataSource;

                    WriteDataTableToCsv(dt, Teach_filepath + "OFFSETNK.csv");

                    GlobalVariable.LoadReceipe();
                    AppendSelectedModuleToOffsetHistory(dt, "OFFSETNK");


                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog(Logger.LogType.Error, "ReceipeForm", "", ex.Message, ex.ToString());
            }
        }
        #endregion

        private void SFC_Edit_Click_1(object sender, EventArgs e)
        {

        }

        private void editbtn_AE_Click_1(object sender, EventArgs e)
        {

        }

        private void lblSC_6_Click(object sender, EventArgs e)
        {

        }

        private void editbtn_feeder_Click(object sender, EventArgs e)
        {
            dgv_Feeder_Min_Max.Enabled = true;
            dgv_Feeder_Min_Max.ReadOnly = false;
        }

        private void savebtn_feeder_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            try
            {
                dgv_Feeder_Min_Max.Enabled = false;
                dgv_Feeder_Min_Max.Enabled = false;

                DialogResult result = MessageBox.Show("Do you want to save the Data", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    dt = (DataTable)dgv_Feeder_Min_Max.DataSource;

                    WriteDataTableToCsv(dt, Teach_filepath + "Feeder_Min_Max.csv");

                    GlobalVariable.LoadReceipe();
                    AppendSelectedModuleToOffsetHistory(dt, "Feeder_Min_Max");


                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog(Logger.LogType.Error, "HomeScreen", "", ex.Message, ex.ToString());
            }
        }

        private void dgv_offsetK_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label57_Click(object sender, EventArgs e)
        {

        }
    }
}
