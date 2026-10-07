using Advantech;
using DIO;
using ExceptionLib;
using GRT_BG1.Data;
using GRT_BG1_V54.Function.CommonClass;
using Master;
using Master.AutoSequences;
using Master.CommonClass;
using Master.UI;
using Program;
using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Reflection.Emit;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using UIForms;
using static DIO.DIDO;

namespace UI.UI_Forms
{


    public partial class MainForm : Form
    {
        static LoadingConveyor ld1 = null;
        public event EventHandler LoginSuccess;
        private Button currentActiveButton = null;
        //private bool pause = false;
        private bool stop = false;
        private bool homindone = false;
        public MainForm()
        {
            InitializeComponent();
            this.IsMdiContainer = true;
            float xRatio = (float)Screen.PrimaryScreen.Bounds.Width / GlobalVariable.OrginalFormWidth;
            float yRatio = (float)Screen.PrimaryScreen.Bounds.Height / GlobalVariable.OrginalFormHeight;
            GlobalVariable.ResizeAllControls(this, xRatio, yRatio);
            label1.Text = GlobalVariable.g_MachineName;
            label2.Text = GlobalVariable.g_MachineVersion;


            try
            {
                CommonAlarmHandler.OnErrorRaised += GlobalVariable.HandleGlobalError;

                //GlobalVariable.AlarmTrigger((ECode)ECode.Load_Conv_Stopper_Cyl_Up_TimeOut_Error, true, 1);
                GlobalVariable.barcodeViewld = new barcodeView[GlobalVariable.CavityRows, GlobalVariable.CavityCols];
                GlobalVariable.barcodeViewwk1 = new barcodeView[GlobalVariable.CavityRows, GlobalVariable.CavityCols];
                GlobalVariable.barcodeViewwk2 = new barcodeView[GlobalVariable.CavityRows, GlobalVariable.CavityCols];
                initialbarSN();
            }
            catch (Exception)
            {
            }
            try
            {
                btn_home_Click(btn_home, EventArgs.Empty);
            }
            catch (Exception)
            {
            }
            try
            {
                ConveyorSystem.OnbuttonStatusChanged += () => HandleButtonControl();
            }
            catch (Exception)
            {

                //throw;
            }

            //mk
            SystemMonitor.ShowMessage = (msg) =>
            {
                //Arulkumar Fixed Hung start
                try
                {
                    if (IsDisposed)
                    {
                        return;
                    }
                    if (InvokeRequired)
                    {
                        if (!IsHandleCreated)
                        {
                            return;
                        }
                        Invoke(new Action(() => MessageBox.Show(msg, "Info", MessageBoxButtons.OK, MessageBoxIcon.Information)));
                    }
                    else
                        MessageBox.Show(msg, "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (ObjectDisposedException)
                {
                }
                catch (InvalidOperationException)
                {
                }
                //Arulkumar Fixed Hung end
            };

        }
        public void initialbarSN()
        {
            for (int row = 0; row < GlobalVariable.CavityRows; row++)
            {
                for (int col = 0; col < GlobalVariable.CavityCols; col++)
                {
                    GlobalVariable.barcodeViewld[row, col] = new barcodeView();
                    GlobalVariable.barcodeViewwk1[row, col] = new barcodeView();
                    GlobalVariable.barcodeViewwk2[row, col] = new barcodeView();
                }
            }
        }


        public void OpenChildForm(Form childForm)
        {

            if (ActiveMdiChild != null)
            {
                ActiveMdiChild.Close();
            }

            childForm.MdiParent = this;
            childForm.Location = new Point(1, 100);
            childForm.Show();
        }

        //===============Bug_ID_73 FIX Start===============
        private void HighlightButton(Button clickedButton)
        {
            // Reset previous
            if (currentActiveButton != null)
            {
                currentActiveButton.FlatAppearance.BorderColor = SystemColors.Control;

            }

            clickedButton.FlatStyle = FlatStyle.Flat;
            clickedButton.UseVisualStyleBackColor = false;
            clickedButton.FlatAppearance.BorderColor = Color.Red;
            clickedButton.FlatAppearance.BorderSize = 2;
            currentActiveButton = clickedButton;
        }

        //===============Bug_ID_73 FIX End===================

        //private void HighlightButton(Button clickedButton)
        //{
        //    // Reset previous
        //    if (currentActiveButton != null)
        //    {
        //        currentActiveButton.FlatAppearance.BorderColor = SystemColors.Control;

        //    }


        //    clickedButton.FlatAppearance.BorderColor = Color.Red;
        //    clickedButton.FlatAppearance.BorderSize = 2;
        //    currentActiveButton = clickedButton;
        //}
        private async void btnClose_Click(object sender, EventArgs e)
        {
            // close application 
            try
            {
                DialogResult dialogResult = MessageBox.Show("Are you Sure Want to Close the Application?", "Confirmation Box", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dialogResult == DialogResult.Yes)
                {
                    GlobalVariable.current_MCStatus = GlobalVariable.MachineStatus.CloseApplication;
                    //Arulkumar Fixed Hung start
                    await Task.Delay(2000);
                    //Arulkumar Fixed Hung end

                    GlobalVariable.ComObj.ServoOFF_All_Axis();
                    GlobalVariable.ComObj1.ServoOFF_All_Axis();
                    //**devchange: uncomment and replace with actual Machine IOs
                    GlobalVariable.DIDO.WriteOPS(false, (int)EOutput.Tower_Lamp_Red);
                    GlobalVariable.DIDO.WriteOPS(false, (int)EOutput.Tower_Lamp_Green);
                    GlobalVariable.DIDO.WriteOPS(false, (int)EOutput.Tower_Lamp_Yellow);
                    GlobalVariable.DIDO.WriteOPS(false, (int)EOutput.Tower_Lamp_Buzzer);

                    GlobalVariable.DIDO.WriteOPS(false, (int)EOutput.Main_on_off_valve);

                    GlobalVariable.DIDO.WriteOPS(false, (int)DIO.DIDO.EOutput.Str_PB);
                    GlobalVariable.DIDO.WriteOPS(false, (int)DIO.DIDO.EOutput.Stop_PB);
                    GlobalVariable.DIDO.WriteOPS(false, (int)DIO.DIDO.EOutput.Reset_PB);

                    ConveyorSystem.HardButtons(false, false, false);
                    Application.Exit();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Application Didn't Close Properly : " + ex);
            }
        }

        private void btn_minimise_Click(object sender, EventArgs e)
        {
            // minimise application 
            try
            {
                this.WindowState = FormWindowState.Minimized;

                //this.WindowState = FormWindowState.Normal;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to minimise application : " + ex);
            }
        }

        private void btn_home_Click(object sender, EventArgs e)
        {
            HighlightButton(sender as Button);
            if (ActiveMdiChild != null)
            {
                ActiveMdiChild.Close();
            }
            //btn_home.BackgroundImage = MasterProject.Properties.Resources.HomeIcon_selection;
            //btn_home.BackColor = Color.AliceBlue;
            panelContents.Visible = false;
            Form form_home = new HomeScreen();
            form_home.MdiParent = this;
            form_home.StartPosition = FormStartPosition.Manual;
            form_home.Size = new Size(panelContents.Size.Width - 5, panelContents.Size.Height - 5);
            form_home.Show();

            ////panelContents.Controls.Clear();
            //Form form_home = new HomeScreen();
            //form_home.TopLevel = false;
            //form_home.FormBorderStyle = FormBorderStyle.None;
            ////panelContents.Controls.Add(form_home);
            //form_home.Show();
        }

        private void btn_alarm_Click(object sender, EventArgs e)
        {
            HighlightButton(sender as Button);
            if (ActiveMdiChild != null)
            {
                ActiveMdiChild.Close();
            }
            panelContents.Visible = false;
            Form form_alarm = new AlarmScreen();
            form_alarm.MdiParent = this;
            form_alarm.StartPosition = FormStartPosition.Manual;
            form_alarm.Size = new Size(panelContents.Size.Width - 5, panelContents.Size.Height - 5);
            form_alarm.Show();
        }

        private void btn_manual_Click(object sender, EventArgs e)
        {
            if ((GlobalVariable.bautoseq_running && GlobalVariable.current_MCStatus == GlobalVariable.MachineStatus.Pause) || (GlobalVariable.current_MCStatus == GlobalVariable.MachineStatus.Stop || GlobalVariable.current_MCStatus == GlobalVariable.MachineStatus.EStop || GlobalVariable.current_MCStatus == GlobalVariable.MachineStatus.Pause || GlobalVariable.current_MCStatus == GlobalVariable.MachineStatus.Ideal))
            {
                HighlightButton(sender as Button);
                if (ActiveMdiChild != null)
                {
                    ActiveMdiChild.Close();
                }
                panelContents.Visible = false;
                Form form_manual = new ManualScreen();
                form_manual.MdiParent = this;
                form_manual.StartPosition = FormStartPosition.Manual;
                form_manual.Size = new Size(panelContents.Size.Width - 5, panelContents.Size.Height - 5);
                form_manual.Show();

            }

            else
            {
                MessageBox.Show("Auto Seq is running....!");
            }

        }

        private void btn_settings_Click(object sender, EventArgs e)
        {
            if ((GlobalVariable.bautoseq_running && GlobalVariable.current_MCStatus == GlobalVariable.MachineStatus.Pause) || (GlobalVariable.current_MCStatus == GlobalVariable.MachineStatus.Stop || GlobalVariable.current_MCStatus == GlobalVariable.MachineStatus.EStop || GlobalVariable.current_MCStatus == GlobalVariable.MachineStatus.Pause || GlobalVariable.current_MCStatus == GlobalVariable.MachineStatus.Ideal))
            {
                HighlightButton(sender as Button);
                if (ActiveMdiChild != null)
                {
                    ActiveMdiChild.Close();
                }
                panelContents.Visible = false;
                Form form_settings = new Settings();
                form_settings.MdiParent = this;
                form_settings.StartPosition = FormStartPosition.Manual;
                form_settings.Size = new Size(panelContents.Size.Width - 5, panelContents.Size.Height - 5);
                form_settings.Show();

            }
            else
            {
                MessageBox.Show("Auto Seq is running....!");
            }

        }

        private void btn_database_Click(object sender, EventArgs e)
        {
            if ((GlobalVariable.bautoseq_running && GlobalVariable.current_MCStatus == GlobalVariable.MachineStatus.Pause) || (GlobalVariable.current_MCStatus == GlobalVariable.MachineStatus.Stop || GlobalVariable.current_MCStatus == GlobalVariable.MachineStatus.EStop || GlobalVariable.current_MCStatus == GlobalVariable.MachineStatus.Pause || GlobalVariable.current_MCStatus == GlobalVariable.MachineStatus.Ideal))
            {

                HighlightButton(sender as Button);
                if (ActiveMdiChild != null)
                {
                    ActiveMdiChild.Close();
                }
                panelContents.Visible = false;
                Form recipe = new RecipieForm();
                recipe.MdiParent = this;
                recipe.StartPosition = FormStartPosition.Manual;
                recipe.Size = new Size(panelContents.Size.Width - 5, panelContents.Size.Height - 5);
                recipe.Show();


            }
            else
            {
                MessageBox.Show("Auto Seq is running....!");
            }

        }
        /// <summary>
        /// Button Image Sellection
        /// </summary>
        /// <param name="btnname">Button Name need to given</param>
        /// <param name="Mode">0-Normal , 1- Selection</param>

        private void SetIcon(string btnname, int Mode)
        {
            if (Mode == 0)
            {
                if (btnname == "")
                {

                }
            }
            else
            {

            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            DateTime dateTime = DateTime.Now;
            TimerLabel.Text = dateTime.ToString();
            //if (ExceptionLib.Logger.RunningLog_lst.Count > 13)
            //{
            //    ExceptionLib.Logger.RunningLog_lst.Clear();
            //    ExceptionLib.Logger.RunningLog_lst.Add("TEST : " + TimerLabel.Text);
            //}
            //else
            //{
            //    ExceptionLib.Logger.RunningLog_lst.Add("TEST : " + TimerLabel.Text);
            //}

            //if(GlobalVariable.b_gHomingDone && !homindone)
            //{
            //    btn_start_auto_seq.Enabled = true;

            //    btn_pause_auto_seq.Enabled = true;
            //    btn_stop_auto_seq.Enabled = true;
            //    homindone =true;
            //}
            //else
            //if(!homindone)
            //{
            //    btn_start_auto_seq.Enabled = false;

            //    btn_pause_auto_seq.Enabled = false;
            //    btn_stop_auto_seq.Enabled = false;
            //}
            //   EnableButtons();

        }

        public void btn_pause_auto_seq_Click(object sender, EventArgs e)
        {
            try
            {

                //btn_start_auto_seq.Enabled = true;
                //btn_pause_auto_seq.Enabled = false;
                // Master.AutoSequences.GlobalAutoSequenceExecutor.Pause();
                if (!GlobalVariable.pause)
                {
                    Logger.WriteLog(Logger.LogType.Running, "Manual Pause", "Current Version:", GlobalVariable.g_MachineVersion, "");

                    GlobalVariable.pause = true;
                    GlobalVariable.b_gPause = true;
                    ConveyorSystem.Pause();

                }

            }
            catch (Exception ex)
            {
                //Arulkumar Fixed random stoppage start
                Logger.WriteLog(Logger.LogType.Error, "MainForm", "btn_pause_auto_seq_Click", ex.Message, ex.ToString());
                //Arulkumar Fixed random stoppage end
            }
        }
        private async void btn_start_auto_seq_Click(object sender, EventArgs e)
        {
            try
            {

                //btn_start_auto_seq.Enabled = false;
                //btn_pause_auto_seq.Enabled = true;
                //HandleButtonControl();
                if (GlobalVariable.pause)
                {
                    Logger.WriteLog(Logger.LogType.Running, "MainForm - Auto Sequence Resume", "Current Version:", GlobalVariable.g_MachineVersion, "");

                    var result = MessageBox.Show("Do you want to continue.", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if (result == DialogResult.No)
                    {
                        return;
                    }
                    GlobalVariable.pause = false; // AK
                    GlobalVariable.b_gPause = false;

                    //Arulkumar Servo Invalid Error Fixed Start
                    //Reason: Pause→Resume jerk
                    //Root Cause: Resume path called ConveyorSystem.Pause() again (PauseAxis + _pauseEvent.Reset) then delayed Resume.
                    //Re-pausing already-paused axes and releasing them after delay produced intermittent jerk on continue.
                    ConveyorSystem.Resume();
                    //Arulkumar Servo Invalid Error Fixed End

                    await Task.Run(() => ConveyorSystem.StartAutoSequnce1(ConveyorSystem._cts.Token));

                }
                else
                {
                    Logger.WriteLog(Logger.LogType.Running, "Auto Sequence Start", "Current Version:", GlobalVariable.g_MachineVersion, "");

                    await StartAutoSequence();
                }
            }
            catch (Exception ex)
            {
                //Arulkumar Fixed random stoppage start
                Logger.WriteLog(Logger.LogType.Error, "MainForm", "btn_start_auto_seq_Click", ex.Message, ex.ToString());
                //Arulkumar Fixed random stoppage end
            }
        }
        public static async Task StartAutoSequence()
        {
            try
            {
                SystemMonitor.Start_Push_Pressed = true;

                if (!GlobalVariable.b_gHomingDone)
                {
                    //Arulkumar Fixed Null start
                    Form uiForm = Application.OpenForms.Count > 0 ? Application.OpenForms[0] : null;
                    if (uiForm != null && !uiForm.IsDisposed)
                    {
                        if (uiForm.InvokeRequired)
                        {
                            uiForm.Invoke((MethodInvoker)delegate
                            {
                                System.Windows.Forms.MessageBox.Show(" Make sure homing is done properly ", " Unable to start Auto sequence ! ", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);
                            });
                        }
                        else
                        {
                            System.Windows.Forms.MessageBox.Show(" Make sure homing is done properly ", " Unable to start Auto sequence ! ", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);
                        }
                    }
                    //Arulkumar Fixed Null end
                    return;
                }
                DialogResult result = DialogResult.No;
                //if (GlobalVariable.current_MCStatus == GlobalVariable.MachineStatus.Pause)
                //{
                //    Application.OpenForms[0].Invoke((MethodInvoker)delegate
                //    {
                //        result = MessageBox.Show("Do you want to resume the auto sequence process.", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                //    });
                //}
                if (GlobalVariable.bautoseq_running)
                {

                    MessageBox.Show(" Auto Sequence Already Running.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);

                }
                else
                {
                    //Arulkumar Fixed Null start
                    Form uiForm = Application.OpenForms.Count > 0 ? Application.OpenForms[0] : null;
                    if (uiForm != null && !uiForm.IsDisposed)
                    {
                        if (uiForm.InvokeRequired)
                        {
                            uiForm.Invoke((MethodInvoker)delegate
                            {
                                result = MessageBox.Show("Do you want to start the auto sequence process.", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);
                            });
                        }
                        else
                        {
                            result = MessageBox.Show("Do you want to start the auto sequence process.", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);
                        }
                    }
                    //Arulkumar Fixed Null end
                }
                if (result == DialogResult.Yes)
                {
                    GlobalVariable.current_MCStatus = GlobalVariable.MachineStatus.Running;
                    GlobalVariable.bmachine_ReadytoStart = false;
                    GlobalVariable.bautoseq_running = true;

                    if (ConveyorSystem._cts == null)
                    {
                        ConveyorSystem._cts = new CancellationTokenSource();
                    }

                    ConveyorSystem.Start();
                    await Task.Run(() => ConveyorSystem.StartAutoSequnce(ConveyorSystem._cts.Token));
                    //Arulkumar Servo Invalid Error Fixed Start
                    //Reason: Start-up / first-motion jerk
                    //Root Cause: After StartAutoSequnce, code called Pause() then fire-and-forget Task.Delay(500) (not awaited) then Resume().
                    //Axes were PauseAxis'd and immediately ResumeAxis'd while sequence tasks were already issuing Move_Abs = intermittent jerk.
                    //Arulkumar Servo Invalid Error Fixed End

                    SystemMonitor.Start_Push_Pressed = false;
                }
                if (result == DialogResult.No)
                {
                    SystemMonitor.Start_Push_Pressed = false;
                    return;
                }
                //EnableButtons();
                if (GlobalVariable.current_MCStatus == GlobalVariable.MachineStatus.Pause)
                {

                    ConveyorSystem.Resume();
                    return;
                }

            }
            catch (Exception ex)
            {
                Logger.WriteLog(Logger.LogType.Error, "MainForm", "StartAutoSequence", "Exception Error", ex.ToString());

            }
        }
        private void btn_stop_auto_seq_Click(object sender, EventArgs e)
        {
            try
            {
                Logger.WriteLog(Logger.LogType.Running, "MainForm - Clicked Stop", "Current Version:", GlobalVariable.g_MachineVersion, "");
                GlobalVariable.current_MCStatus = GlobalVariable.MachineStatus.Stop;
                ConveyorSystem.Stop();
                GlobalVariable.b_gHomingDone = false;
                GlobalVariable.bhomeseq_running = false;
                GlobalVariable.pause = false; // AK
                GlobalVariable.b_gPause = false;

                GlobalVariable.New_Pallet_Only = false;

                //EnableButtons();
            }
            catch (Exception ex)
            {
                //Arulkumar Fixed random stoppage start
                Logger.WriteLog(Logger.LogType.Error, "MainForm", "btn_stop_auto_seq_Click", ex.Message, ex.ToString());
                //Arulkumar Fixed random stoppage end
            }
        }

        private void btn_statistics_Click(object sender, EventArgs e)
        {
            try
            {
                HighlightButton(sender as Button);
                if (ActiveMdiChild != null)
                {
                    ActiveMdiChild.Close();
                }
                panelContents.Visible = false;
                Form form_Report = new Report();
                form_Report.MdiParent = this;
                form_Report.StartPosition = FormStartPosition.Manual;
                form_Report.Size = new Size(panelContents.Size.Width - 5, panelContents.Size.Height - 5);
                form_Report.Show();
            }
            catch (Exception ex)
            {
                //Arulkumar Fixed random stoppage start
                Logger.WriteLog(Logger.LogType.Error, "MainForm", "btn_statistics_Click", ex.Message, ex.ToString());
                //Arulkumar Fixed random stoppage end
            }
        }

        private void btn_open_file_Click(object sender, EventArgs e)
        {
            try
            {
                if (GlobalVariable.RunningLogPath != string.Empty)
                {
                    if (!Directory.Exists(GlobalVariable.RunningLogPath))
                    {
                        MessageBox.Show($"Folder not found :\n {GlobalVariable.RunningLogPath}", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    System.Diagnostics.Process.Start("explorer.exe", GlobalVariable.RunningLogPath);
                }
                else
                {
                    MessageBox.Show("Running Log File Path Is Empty", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                //Arulkumar Fixed random stoppage start
                Logger.WriteLog(Logger.LogType.Error, "MainForm", "btn_open_file_Click", ex.Message, ex.ToString());
                //Arulkumar Fixed random stoppage end
            }
        }

        private async void btn_reset_alarm_Click(object sender, EventArgs e)
        {

            if (GlobalVariable.g_bAlarm || GlobalVariable.current_MCStatus == GlobalVariable.MachineStatus.Stop || GlobalVariable.current_MCStatus == GlobalVariable.MachineStatus.Pause || GlobalVariable.current_MCStatus == GlobalVariable.MachineStatus.Ideal)
            {
                Logger.WriteLog(Logger.LogType.Running, "MainForm - Auto Sequnce Running time Clicked Reset Btn", "Current Version:", GlobalVariable.g_MachineVersion, "");

                GlobalVariable.UIResetClicked = true;
                GlobalVariable.DIDO.WriteOPS(true, (int)DIDO.EOutput.Safety_Bypass_On_Sig);
                GlobalVariable.ComObj.ServoOn_All_Axis(true);
                GlobalVariable.ComObj1.ServoOn_All_Axis(true);
                GlobalVariable.ComObj.Init_BoardFunc();
                GlobalVariable.ComObj1.Init_BoardFunc();

            }
            else
            {
                Logger.WriteLog(Logger.LogType.Running, "MainForm - Auto Sequnce Running time Clicked Reset Btn", "Current Version:", GlobalVariable.g_MachineVersion, "");
                MessageBox.Show("There is no alarm and machine is currently running....", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);

            }

        }



        private void btn_user_login_Click(object sender, EventArgs e)
        {

        }

        public void HandleButtonControl()
        {
            if (InvokeRequired)
            {
                // Invoke(new Action(EnableButtons));
                return;
            }
            else
            {
                //  EnableButtons();
            }

        }
        public static async Task<bool> CheckHomingforAllAxis()
        {
            bool servo_x1CheckHome = false;
            bool servo_y1CheckHome = false;
            bool servo_z1CheckHome = false;
            bool servo_z2CheckHome = false;
            bool servo_r1CheckHome = false;
            bool servo_r2CheckHome = false;
            bool servo_x2CheckHome = false;
            bool servo_y2CheckHome = false;
            bool stepper_1CheckHome = false;
            bool stepper_2CheckHome = false;
            bool OverAllHoming = false;
            try
            {
                servo_x1CheckHome = await Task.Run(() => ObjectList.Servo_X1.CheckHome());
                servo_y1CheckHome = await Task.Run(() => ObjectList.Servo_Y1.CheckHome());
                servo_z1CheckHome = await Task.Run(() => ObjectList.Servo_Z1.CheckHome());
                servo_z2CheckHome = await Task.Run(() => ObjectList.Servo_Z2.CheckHome());
                servo_r1CheckHome = await Task.Run(() => ObjectList.Servo_R1.CheckHome());
                servo_r2CheckHome = await Task.Run(() => ObjectList.Servo_R2.CheckHome());
                servo_x2CheckHome = await Task.Run(() => ObjectList.Servo_X2.CheckHome());
                servo_y2CheckHome = await Task.Run(() => ObjectList.Servo_Y2.CheckHome());
                stepper_1CheckHome = await Task.Run(() => ObjectList.Stepper_1.CheckHome());
                stepper_2CheckHome = await Task.Run(() => ObjectList.Stepper_2.CheckHome());


                OverAllHoming = !servo_x1CheckHome ? true : false;
                OverAllHoming = !servo_y1CheckHome ? true : false;
                OverAllHoming = !servo_z1CheckHome ? true : false;
                OverAllHoming = !servo_z2CheckHome ? true : false;
                OverAllHoming = !servo_r1CheckHome ? true : false;
                OverAllHoming = !servo_r2CheckHome ? true : false;
                OverAllHoming = !servo_x2CheckHome ? true : false;
                OverAllHoming = !servo_y2CheckHome ? true : false;
                OverAllHoming = !stepper_1CheckHome ? true : false;
                OverAllHoming = !stepper_2CheckHome ? true : false;







                if (OverAllHoming)
                {
                    //Arulkumar Fixed Null start
                    Form uiForm = Application.OpenForms.Count > 0 ? Application.OpenForms[0] : null;
                    if (uiForm != null && !uiForm.IsDisposed)
                    {
                        if (uiForm.InvokeRequired)
                        {
                            uiForm.Invoke((MethodInvoker)delegate
                            {
                                System.Windows.Forms.MessageBox.Show(" Make sure homing is done properly ", " Unable to start Auto sequence ! ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            });
                        }
                        else
                        {
                            System.Windows.Forms.MessageBox.Show(" Make sure homing is done properly ", " Unable to start Auto sequence ! ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    //Arulkumar Fixed Null end
                    return false;
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog(Logger.LogType.Error, "MainForm", "CheckHomingforAllAxis", ex.Message, ex.ToString());
                //throw;
            }
            return true;
        }

        private void EnableButtons()
        {
            try
            {
                if (GlobalVariable.b_gHomingDone)
                {
                    //if (GlobalVariable.current_MCStatus == GlobalVariable.MachineStatus.Pause)
                    //{
                    //    btn_start_auto_seq.Enabled = true;
                    //    btn_pause_auto_seq.Enabled = false;
                    //    btn_stop_auto_seq.Enabled = true;

                    //    btn_manual.Enabled = true;
                    //    btn_settings.Enabled = true;
                    //    btn_database.Enabled = false;


                    //}
                    if (GlobalVariable.current_MCStatus == GlobalVariable.MachineStatus.Stop || GlobalVariable.current_MCStatus == GlobalVariable.MachineStatus.EStop)
                    {
                        btn_start_auto_seq.Enabled = true;
                        btn_pause_auto_seq.Enabled = false;
                        btn_stop_auto_seq.Enabled = false;

                        btn_alarm.Enabled = true;
                        btn_manual.Enabled = true;
                        btn_statistics.Enabled = true;
                        btn_settings.Enabled = true;
                        btn_database.Enabled = true;
                        btn_open_file.Enabled = true;
                    }
                    else if (GlobalVariable.bautoseq_running && GlobalVariable.current_MCStatus == GlobalVariable.MachineStatus.Pause)
                    {
                        btn_start_auto_seq.Enabled = true;
                        btn_pause_auto_seq.Enabled = false;
                        btn_stop_auto_seq.Enabled = true;

                        btn_alarm.Enabled = true;
                        btn_manual.Enabled = false; // AK
                        btn_statistics.Enabled = true;
                        btn_settings.Enabled = false;  // AK
                        btn_database.Enabled = true;
                        btn_open_file.Enabled = true;

                    }
                    else if (GlobalVariable.b_gHomingDone)
                    {
                        btn_start_auto_seq.Enabled = true;
                        btn_pause_auto_seq.Enabled = true;
                        btn_stop_auto_seq.Enabled = true;

                        btn_alarm.Enabled = true;
                        btn_manual.Enabled = true;
                        btn_statistics.Enabled = true;
                        btn_settings.Enabled = true;
                        btn_database.Enabled = true;
                        btn_open_file.Enabled = true;

                    }
                    else if (GlobalVariable.bautoseq_running)
                    {
                        btn_start_auto_seq.Enabled = false;
                        btn_pause_auto_seq.Enabled = true;
                        btn_stop_auto_seq.Enabled = true;

                        btn_alarm.Enabled = true;
                        btn_manual.Enabled = false;
                        btn_statistics.Enabled = true;
                        btn_settings.Enabled = false;
                        btn_database.Enabled = true;
                        btn_open_file.Enabled = true;  // AK


                    }


                    //else
                    //{
                    //    btn_start_auto_seq.Enabled = false;
                    //    btn_pause_auto_seq.Enabled = false;
                    //    btn_stop_auto_seq.Enabled = false;

                    //        btn_alarm.Enabled = true;
                    //        btn_manual.Enabled = true;
                    //        btn_statistics.Enabled = true;
                    //        btn_settings.Enabled = true;
                    //        btn_database.Enabled = true;
                    //        btn_open_file.Enabled = true;

                    //}
                }
                else if (GlobalVariable.bhomeseq_running)
                {
                    btn_start_auto_seq.Enabled = false;
                    btn_pause_auto_seq.Enabled = false;
                    btn_stop_auto_seq.Enabled = true;

                    btn_alarm.Enabled = true;
                    btn_manual.Enabled = false;
                    btn_statistics.Enabled = true;
                    btn_settings.Enabled = false;
                    btn_database.Enabled = false;
                    btn_open_file.Enabled = true;
                }
                //else
                //{
                //    btn_start_auto_seq.Enabled = false;
                //    btn_pause_auto_seq.Enabled = false;
                //    btn_stop_auto_seq.Enabled = false;

                //    btn_alarm.Enabled = true;
                //    btn_manual.Enabled = true;
                //    btn_statistics.Enabled = true;
                //    btn_settings.Enabled = true;
                //    btn_database.Enabled = true;
                //    btn_open_file.Enabled = true;

                //}
                //this.Refresh();
                //Application.DoEvents

                try
                {
                    if (GlobalVariable.current_MCStatus == GlobalVariable.MachineStatus.EStop || GlobalVariable.current_MCStatus == GlobalVariable.MachineStatus.Stop)
                    {
                        if (GlobalAutoSequenceExecutor._cts != null)
                        {
                            GlobalAutoSequenceExecutor._cts?.Cancel();
                            GlobalAutoSequenceExecutor._cts?.Dispose();
                            GlobalAutoSequenceExecutor._cts = null;
                            //Arulkumar Fixed random stoppage start
                            try
                            {
                                GlobalAutoSequenceExecutor._pauseEvent?.Set();
                                GlobalAutoSequenceExecutor._pauseEvent?.Dispose();
                            }
                            catch (Exception)
                            {
                            }
                            //Arulkumar Fixed random stoppage end
                            GlobalAutoSequenceExecutor._pauseEvent = new ManualResetEvent(true); // Or reset it for reuse
                        }

                    }
                }
                catch (Exception)
                {
                }

            }


            catch (Exception ex)
            {
                Logger.WriteLog(Logger.LogType.Error, "MainForm", "HandleButtonControl", "Exception Error", ex.ToString());
            }
        }




        private void button1_Click(object sender, EventArgs e)
        {
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

            var fourteen = ObjectList.AX3.ServoOn(true);
            GlobalVariable.AxisHomingStatus = new bool[(int)EAxis.TotalAxis];
            for (int i = 0; i < GlobalVariable.AxisHomingStatus.Length; i++)
            {
                GlobalVariable.AxisHomingStatus[i] = false;
            }
            GlobalVariable.g_DOChanNum = Advantech_PCIE.DOChanNum;
            GlobalVariable.g_DIChanNum = Advantech_PCIE.DIChanNum;

            Advantech_PCIE.AINumber = 1;

        }
    }


}
