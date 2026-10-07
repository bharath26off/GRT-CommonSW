using ExceptionLib;
using HelperClassLib;
using Master;
using Master.CommonClass;
using Program;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using UI.UI_Forms;
using static DIO.DIDO;

namespace UI_Forms
{
    public partial class Login : Form
    {
        private class PlaceholderItem
        {
            public override string ToString() => "-- SELECT MODE --";
        }
        private readonly PlaceholderItem placeholder = new PlaceholderItem();
        private String txtUsername;
        private object txtPassword;
        public bool isDeveloperMode = true;
        //Arulkumar Fixed random stoppage start
        private static volatile bool _monitorThreadsStarted = false;
        //Arulkumar Fixed random stoppage end
        public Login()
        {
            InitializeComponent();
            GlobalVariable.ResetAllAlarms();
            GlobalVariable.ComObj.ResetAxisError_All_Axis();
            GlobalVariable.ComObj1.ResetAxisError_All_Axis();
            ObjectList.Servo_R1.ResetAxis();
            ObjectList.Servo_R2.ResetAxis();
            ObjectList.Servo_X1.ResetAxis();
            ObjectList.Servo_X2.ResetAxis();
            ObjectList.Servo_Y1.ResetAxis();
            ObjectList.Servo_Y2.ResetAxis();
            ObjectList.Servo_Z1.ResetAxis();
            ObjectList.Servo_Z2.ResetAxis();
            ObjectList.Stepper_1.ResetAxis();
            ObjectList.Stepper_1.ResetAxis();
            ObjectList.Stepper_2.ResetAxis();
            this.CenterToScreen();
            cmbmodes.SelectedIndex = -1;
            cmbmodes.Focus();
            if (isDeveloperMode)
            {
                cmbmodes.SelectedIndex = 2;
                txtusername.Text = "1";
                txtpass.Text = "1";
            }
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void cmbmodes_DrawItem(object sender, DrawItemEventArgs e)
        {
            ComboBox cb = sender as ComboBox;
            if (cb == null) return;
            Color bgColor = cb.BackColor;
            using (Brush bgBrush = new SolidBrush(bgColor))
            {
                e.Graphics.FillRectangle(bgBrush, e.Bounds);
            }
            string text;
            if (e.Index >= 0)
                text = cb.Items[e.Index].ToString();
            else
                text = "-- SELECT MODE --";
            TextRenderer.DrawText(
                e.Graphics,
                text,
                cb.Font,
                e.Bounds,
                cb.ForeColor,
                bgColor,
                TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);

            //ComboBox cb = sender as ComboBox;
            //e.DrawBackground();

            //string text = string.Empty;
            //Brush brush = SystemBrushes.WindowText; // Default system text color

            //if (e.Index >= 0)
            //{
            //    text = cb.Items[e.Index].ToString();
            //    brush = new SolidBrush(cb.ForeColor); // Keep default color
            //}
            //else if (cb.SelectedIndex == -1 && !cb.DroppedDown)
            //{
            //    text = "-- SELECT MODE --";
            //    brush = Brushes.White; // Placeholder in white
            //}

            //StringFormat sf = new StringFormat
            //{
            //    Alignment = StringAlignment.Center,
            //    LineAlignment = StringAlignment.Center
            //};

            //e.Graphics.DrawString(text, cb.Font, brush, e.Bounds, sf);
            //e.DrawFocusRectangle();
        }


        private async void btnlogin_Click_1(object sender, EventArgs e)
        {

            Logger.WriteLog(Logger.LogType.Running, "Login Click", "Current Version:",GlobalVariable.g_MachineVersion,"");
            string modeSelect = cmbmodes.Text;
            string user = txtusername.Text;
            string password = txtpass.Text;

            if(GlobalVariable.CavityRows == 4 && GlobalVariable.CavityCols == 3)
            {

            }
            else if(GlobalVariable.CavityRows == 3 && GlobalVariable.CavityCols == 4)
            {
            }
            else
            {
                MessageBox.Show("Please Check Cavity Rows and Cavity Columns in Config File", "Login", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            if (modeSelect == string.Empty || modeSelect == "-- SELECT MODE --")

            {
                MessageBox.Show("Please Select Mode", "Login", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbmodes.Focus();
                return;
            }
            if (user == string.Empty)
            {
                MessageBox.Show("Please Enter User Name", "Login", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtusername.Focus();
                return;
            }
            else if (password == string.Empty)
            {
                MessageBox.Show("Please Enter Password", "Login", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtpass.Focus();
                return;
            }

            bool result = await VerifyLoginAsync(user, password, modeSelect);
            if (result)
            {
                MainForm form = new MainForm();
                GlobalVariable.b_gCardInitSucc = false;
                await Task.Delay(1000);
                var CH = GlobalVariable.ComObj.Init_BoardFunc();
                var CH1 = GlobalVariable.ComObj1.Init_BoardFunc();


                if ((!CH.isSuccess) && (CH.MethodCode == 1))
                {
                    MessageBox.Show("Driver Version Mismatch.....!");
                    Logger.WriteLog(Logger.LogType.Running, "login", "Failure", "Driver Version Mismatch.....!", "");
                    //Declare your Global Variable true or false based on your Requirment
                }
                else if ((!CH.isSuccess) && (CH.MethodCode == 2))
                {
                    MessageBox.Show("Failed to Read Available Device .....!");
                    Logger.WriteLog(Logger.LogType.Running, "login", "Failure", "Failed to Read Available Device .....!", "");
                }
                else if ((!CH.isSuccess) && (CH.MethodCode == 3))
                {
                    MessageBox.Show("Error!Failed To Open Control Board.....!");
                    Logger.WriteLog(Logger.LogType.Running, "login", "Failure", "Error!Failed To Open Control Board.....!", "");
                }
                else
                {
                    MessageBox.Show("Control Board Connected Successfully......!","Info", MessageBoxButtons.OK, MessageBoxIcon.Information,MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);
                    Logger.WriteLog(Logger.LogType.Running, "login", "Success", "Control Board Connected Successfully......!", "");
                    GlobalVariable.b_gCardInitSucc = true;
                    GlobalVariable.g_CardInitSucc = true;
                   
                }
                GlobalVariable.ResetAllAlarms();
                GlobalVariable.ComObj.ResetAxisError_All_Axis(true);
                GlobalVariable.ComObj1.ResetAxisError_All_Axis(true);

                GlobalVariable.ComObj.ServoOn_All_Axis(true);
                GlobalVariable.ComObj1.ServoOn_All_Axis(true);
                GlobalVariable.AxisHomingStatus = new bool[(int)EAxis.TotalAxis];
                for (int i = 0; i < GlobalVariable.AxisHomingStatus.Length; i++)
                {
                    GlobalVariable.AxisHomingStatus[i] = false;
                }
                GlobalVariable.g_DOChanNum = Advantech_PCIE.DOChanNum;
                GlobalVariable.g_DIChanNum = Advantech_PCIE.DIChanNum;

                GlobalVariable.LoadReceipe();

                Advantech_PCIE.AINumber = 1;
                //**devchange: uncomment after connected to machine
            
                    //GlobalVariable.ComObj.ServoOn_All_Axis(true);
                
                
                //DialogResult _result = MessageBox.Show("Ready to Start", "Starting", MessageBoxButtons.OKCancel);
                //if (_result == DialogResult.OK)
                //{
                    //Arulkumar Fixed random stoppage start
                    if (!_monitorThreadsStarted)
                    {
                        _monitorThreadsStarted = true;
                        Task.Run(() => MachineHealthTracker.GetInstance().MonitorHealthStatus());
                        Task.Run(() => SystemMonitor.System_Monitor_IO());
                        await Task.Delay(100);
                        Task.Run(() => SystemMonitor.System_Monitor_AI());
                        await Task.Delay(300);
                        Task.Run(() => SystemMonitor.System_Monitor_BG_thread());
                        await Task.Delay(300);
                        Task.Run(() => SystemMonitor.System_Monitor1());
                    }
                    //Arulkumar Fixed random stoppage end
                //}

                ObjectList.Servo_R1.ResetAxis();
                ObjectList.Servo_R2.ResetAxis();
                ObjectList.Servo_X1.ResetAxis();
                ObjectList.Servo_X2.ResetAxis();
                ObjectList.Servo_Y1.ResetAxis();
                ObjectList.Servo_Y2.ResetAxis();
                ObjectList.Servo_Z1.ResetAxis();
                ObjectList.Servo_Z2.ResetAxis();
                ObjectList.Stepper_1.ResetAxis();
                ObjectList.Stepper_1.ResetAxis();
                ObjectList.Stepper_2.ResetAxis();
                var one = ObjectList.Servo_R1.ServoOn(true);
                var two = ObjectList.Servo_R2.ServoOn(true);
                var three = ObjectList.Servo_X1.ServoOn(true);
                var four = ObjectList.Servo_X2.ServoOn(true);
                var five = ObjectList.Servo_Y1.ServoOn(true);
                var six = ObjectList.Servo_Y2.ServoOn(true);
                var seven = ObjectList.Servo_Z1.ServoOn(true);
                var eight = ObjectList.Servo_Z2.ServoOn(true);
                var nine = ObjectList.Stepper_1.ServoOn(true);
                var ten = ObjectList.Stepper_2.ServoOn(true);

                var elevn = ObjectList.AX0.ServoOn(true);
                var twelve = ObjectList.AX1.ServoOn(true);
                var thirteen = ObjectList.AX2.ServoOn(true);

                var fourteen =ObjectList.AX3.ServoOn(true);
                //if(!one || !two || !three || !four || !five || !six || !seven ||!eight ||!nine ||!ten ||!elevn||!twelve||!thirteen || !fourteen)
                //{

                //    MessageBox.Show("Close the software press reset and open again");
                    
                //}
                try
                {
                    CommonAlarmHandler.OnErrorRaised += GlobalVariable.HandleGlobalError;
                }
                catch (Exception ex)
                {
                    //Arulkumar Fixed random stoppage start
                    Logger.WriteLog(Logger.LogType.Error, "Login", "OnErrorRaisedSubscribe", ex.Message, ex.ToString());
                    //Arulkumar Fixed random stoppage end
                }


                this.Visible = false;
                form.ShowDialog();
                //form.enablebuttons();
                this.Close();

            }
            else
            {
                MessageBox.Show("Invalid Login credentials", "Login", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //if (!cmbmodes.Items.Contains(placeholder))
                //    cmbmodes.Items.Insert(0, placeholder);
                cmbmodes.SelectedItem = placeholder;
                txtusername.Clear();
                txtpass.Clear();
                cmbmodes.Focus();
            }
        }


        public static async Task DIRefresh()
        {
            while (true)
            {
                //Arulkumar Fixed random stoppage start
                if (GlobalVariable.b_gStop || GlobalVariable.current_MCStatus == GlobalVariable.MachineStatus.CloseApplication)
                    break;
                //Arulkumar Fixed random stoppage end
                await Task.Delay(10);
                //GlobalVariable.DI = GlobalVariable.ComObj.DI_RefreshValue(GlobalVariable.DI.Length, GlobalVariable.InputPortCfg);
            }
        }
        private void btncancel_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmbmodes_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Convert.ToInt32(e.KeyChar) == 13)
            {
                SendKeys.Send("{Tab}");
            }
            cmbmodes.Text = "-- SELECT MODE --";
        }

        private void txtusername_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Convert.ToInt32(e.KeyChar) == 13)
            {
                SendKeys.Send("{Tab}");
            }
        }

        private void txtpass_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Convert.ToInt32(e.KeyChar) == 13)
            {
                SendKeys.Send("{Tab}");
            }
        }

        private async void Login_Load(object sender, EventArgs e)
        {
            //cmbmodes.SelectedIndex = -1;
            await LoadLoginModesAsync();
        }

        private async Task<bool> VerifyLoginAsync(string username, string password, string LoginMode)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@Username", username),
                new SqlParameter("@Password", password),
                new SqlParameter("@LoginMode", LoginMode),
            };

            object result = await SqlUtility.ExecuteScalarAsync("sp_VerifyUserLogin", parameters);
            return (result != null && Convert.ToInt32(result) == 1);
        }

        private async Task LoadLoginModesAsync()
        {
            DataTable dt = await SqlUtility.ExecuteQueryAsync("sp_GetDistinctLoginModes");

            cmbmodes.Items.Clear();
            foreach (DataRow row in dt.Rows)
            {
                cmbmodes.Items.Add(row["LoginMode"].ToString());
            }

            if (cmbmodes.Items.Count > 0)
                cmbmodes.SelectedIndex = 0;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
