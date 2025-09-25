using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using DIO;
using MasterProject.GlobalClass;
using Program;
using DynamicCylinders;
using Advantech;
using DynamicVaccums;
using ExceptionLib;
using AutoIOTest;
using Advantech.Motion;
using static DIO.DIDO;


namespace UIForms
{

    public partial class ManualScreen : Form
    {
        public Advantech_PCIE ServoAxis;
        public string Stepper { get; set; }
        public string Servo { get; set; }
        int axisindex = 0;
        int stepperIndex = 0;
        public ManualScreen()
        {
            InitializeComponent();
            ServoAxis = new Advantech_PCIE(0,"ServoAxis");
            LoadMotorAxes();
            ErrorHandler.OnErrorRaised += HandleGlobalError;
            float xRatio = (float)Screen.PrimaryScreen.Bounds.Width / GlobalVariable.OrginalFormWidth;
            float yRatio = (float)Screen.PrimaryScreen.Bounds.Height / GlobalVariable.OrginalFormHeight;
            GlobalVariable.ResizeAllControls(this, xRatio, yRatio);
            
        }
        // <summary>
        /// Called when the form is about to close.
        /// Unsubscribes the HandleGlobalError method from the ErrorHandler.OnErrorRaised event
        /// to prevent event calls after the form is disposed.
        /// Then calls the base OnFormClosing to continue normal closing behavior.
        /// </summary>
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            ErrorHandler.OnErrorRaised -= HandleGlobalError;
            base.OnFormClosing(e);
        }

        private static readonly string filePath = Path.Combine(Environment.CurrentDirectory,"Data","AxisList.Csv");
        private void LoadMotorAxes()
        {
            try
            {
                DataTable ds = new DataTable();
                ds = HelperClassLib.GetDataFromHelper.GetDataFromCSV(filePath);
                cmbStepperCombo.DataSource = ds;
                cmbStepperCombo.DisplayMember = "Stepper";
                cmbStepperCombo.ValueMember = "Stepper";

                AxisSelectCombo.DataSource = ds.Copy();
                AxisSelectCombo.DisplayMember = "Servo";
                AxisSelectCombo.ValueMember = "Servo";

            }
            catch (Exception ex)
            {
            }
        }        
        private void StepperCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                //cmbStepperCombo.Text = cmbStepperCombo.SelectedValue.ToString();
                //stepperIndex = cmbStepperCombo.SelectedIndex;
                //ServoAxis = ObjectList.MotorObj[stepperIndex + AxisSelectCombo.Items.Count];
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        private void AxisSelectCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
           // axisindex = AxisSelectCombo.SelectedIndex;
           // ServoAxis = ObjectList.MotorObj[axisindex];
        }

        private void StepperCombo_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                groupBox13.Text = cmbStepperCombo.SelectedValue.ToString();
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void ServoBasedFunctionality()
        {
            try
            {
                if (ServoAxis != null)
                {
                    ServoAxis.ServoOn(true);
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog(Logger.LogType.Error, "ManualScreen", "", ex.Message, ex.ToString());
            }
        }

        
        private void button44_Click(object sender, EventArgs e)
        {
            try
            {
                //ServoAxis.Jog(1);
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void button51_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtServoX_Targetposition.Text.Trim() == "")
                {
                    MessageBox.Show("Please Enter Position", "Manual Screen", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (txtServoX_Targetspeed.Text.Trim() == "")
                {
                    MessageBox.Show("Please Enter Speed", "Manual Screen", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (ServoAxis != null)
                {
                    double dTargetPos = 0;
                    if (!string.IsNullOrEmpty(txtServoX_Targetposition.Text))
                    {
                        dTargetPos = Convert.ToDouble(txtServoX_Targetposition.Text);
                        if (double.TryParse(txtServoX_Targetspeed.Text, out double speedValue))
                        {
                            btnMove.Enabled = false;
                            if (!ServoAxis.Move_Abs(dTargetPos, speedValue, GlobalVariable.g_lstAxisConfig[axisindex].Acc,
                                GlobalVariable.g_lstAxisConfig[axisindex].DeAcc, 5000))
                            {
                                //Logger.WriteLog("Device_Interface", "jogfrwrd()", "PCIE-1203_Interface", "Exception Error", es.ToString());
                            }
                            lbl_Servo_TargetPosition.Text = dTargetPos.ToString();
                            btnMove.Enabled = true;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Kindly Enter the TargetPosition ", "Movement", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog(Logger.LogType.Error, "ManualScreen", "", ex.Message, ex.ToString());
            }
        }

        private void btnServoEnable_Click(object sender, EventArgs e)
        {
            try
            {
                if (ServoAxis != null)
                {
                    ServoAxis.ServoOn(true);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void btnServoDisable_Click(object sender, EventArgs e)
        {
            try
            {
                if (ServoAxis != null)
                {
                    ServoAxis.ServoOFF();
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog(Logger.LogType.Error, "ManualScreen", "", ex.Message, ex.ToString());
            }
        }

        private void btnServoClear_Click(object sender, EventArgs e)
        {
            try
            {
                if (ServoAxis != null)
                {
                    ServoAxis.ResetAxis();
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog(Logger.LogType.Error, "ManualScreen", "", ex.Message, ex.ToString());
            }
        }

        private void btnMoveStop_Click(object sender, EventArgs e)
        {
            try
            {
                if (ServoAxis != null)
                {
                    ServoAxis.Stop();
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog(Logger.LogType.Error, "ManualScreen", "", ex.Message, ex.ToString());
            }
        }

        private void btnHomeStop_Click(object sender, EventArgs e)
        {
            try
            {
                if (ServoAxis != null)
                {
                    ServoAxis.Stop();
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog(Logger.LogType.Error, "ManualScreen", "", ex.Message, ex.ToString());
            }
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            try
            {
                if (ServoAxis != null)
                {
                    ServoAxis.Homing(0);
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog(Logger.LogType.Error, "ManualScreen", "", ex.Message, ex.ToString());
            }
        }

        private void btnptpMove_Click(object sender, EventArgs e)
        {
            try
            {
                if (ServoAxis != null)
                {
                    double dTargetPos = 0;
                    if (!string.IsNullOrEmpty(txtServoX_Targetposition.Text))
                    {
                        dTargetPos = Convert.ToDouble(txtServoX_Targetposition.Text);
                        if (double.TryParse(txtServoX_Targetspeed.Text, out double speedValue))
                        {
                            btnMove.Enabled = false;
                            if (!ServoAxis.Move_Abs(dTargetPos, speedValue, GlobalVariable.g_lstAxisConfig[axisindex].Acc,
                                GlobalVariable.g_lstAxisConfig[axisindex].DeAcc, 5000))
                            {
                                //Logger.WriteLog("Device_Interface", "jogfrwrd()", "PCIE-1203_Interface", "Exception Error", es.ToString());
                            }
                            lbl_Servo_TargetPosition.Text = dTargetPos.ToString();
                            btnMove.Enabled = true;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Kindly Enter the TargetPosition ", "Movement", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog(Logger.LogType.Error, "ManualScreen", "", ex.Message, ex.ToString());
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                if (ServoAxis != null)
                {
                    double ActPos = 0;
                    double ActPvel = 0;
                    string actstatus = "";
                    ServoAxis.GetCurrentPos(out ActPos, out actstatus, out ActPvel);

                    if (tabControl2.SelectedTab.ToString().ToUpper() == "SERVO")
                    {
                        lbl_Servo_Actual_Position.Text = ActPos.ToString("F2");

                        //if (ServoAxis.GetSingleMotionIOBit(Advantech_PCIE.MotionIOBit.RDY))
                        if (actstatus.ToUpper().Equals("STA_AX_READY"))
                        {
                            lblServoEnableColor.BackColor = Color.Green;
                            lblServoReadyColor.BackColor = Color.Green;
                        }
                        else
                        {
                            lblServoEnableColor.BackColor = Color.Maroon;
                            lblServoReadyColor.BackColor = Color.Green;
                        }

                        if (actstatus.ToUpper().Contains("DISABLE"))
                        {
                            lblServoDisableColor.BackColor = Color.Green;
                        }
                        else
                        {
                            lblServoDisableColor.BackColor = Color.Maroon;
                        }

                        if (actstatus.ToUpper().Contains("HOMING"))
                        {
                            lblServoHomeColor.BackColor = Color.Green;
                        }
                        else
                        {
                            lblServoHomeColor.BackColor = Color.Maroon;
                        }

                        if (actstatus.ToUpper().Contains("ERROR"))
                        {
                            lblServoErrorColor.BackColor = Color.Green;
                        }
                        else
                        {
                            lblServoErrorColor.BackColor = Color.Maroon;
                        }

                        if (actstatus.ToUpper().Contains("MOTION"))
                        {
                            lblServoRunningColor.BackColor = Color.Green;
                        }
                        else
                        {
                            lblServoRunningColor.BackColor = Color.Maroon;
                        }
                    }
                    else if (tabControl2.SelectedTab.ToString().ToUpper() == "STEPPER")
                    {
                        if (actstatus.ToUpper().Equals("STA_AX_READY"))
                        {
                            lbl_Cny1Enable_Status.BackColor = Color.Green;
                        }
                        else
                        {
                            lbl_Cny1Enable_Status.BackColor = Color.Maroon;
                        }

                        if (actstatus.ToUpper().Contains("DISABLE"))
                        {
                            lbl_Cny1Disable_Status.BackColor = Color.Green;
                        }
                        else
                        {
                            lbl_Cny1Disable_Status.BackColor = Color.Maroon;
                        }

                        if (actstatus.ToUpper().Contains("ERROR"))
                        {
                            lbl_Cny1Error_Status.BackColor = Color.Green;
                            lbl_Cny1Error_Code.Text = "eRROR";
                        }
                        else
                        {
                            lbl_Cny1Error_Status.BackColor = Color.Maroon;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog(Logger.LogType.Error, "ManualScreen", "", ex.Message, ex.ToString());
            }

        }

        private void btnptpStop_Click(object sender, EventArgs e)
        {
            try
            {
                if (ServoAxis != null)
                {
                    ServoAxis.Stop();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        private void ManualScreen_Load(object sender, EventArgs e)
        {
            try
            {
                if (ServoAxis != null)
                {
                    ServoAxis = new Advantech_PCIE(0,"ServoAxis");
                }
                txtServoX_Targetposition.KeyPress += GlobalVariable.AllowOnlyDecimal_TextBox;
                txtServoX_Targetspeed.KeyPress += GlobalVariable.AllowOnlyDecimal_TextBox;
                txtHome_Velocity.KeyPress += GlobalVariable.AllowOnlyDecimal_TextBox;
                txtptppositionx.KeyPress += GlobalVariable.AllowOnlyDecimal_TextBox;
                txtptpspeedx.KeyPress += GlobalVariable.AllowOnlyDecimal_TextBox;

                DynamicCylinder SForm = new DynamicCylinder();
                SForm.TopLevel = false;
                SForm.FormBorderStyle = FormBorderStyle.None;
                SForm.Dock = DockStyle.Fill;
                PnlCylinderMain.Controls.Add(SForm);
                SForm.Show();

                DynamicVaccum VacForm = new DynamicVaccum();
                VacForm.TopLevel = false;
                VacForm.FormBorderStyle = FormBorderStyle.None;
                VacForm.Dock = DockStyle.Fill;
                PnlVaccumMain.Controls.Add(VacForm);
                VacForm.Show();
                
                AutoIOTesting IOForm = new AutoIOTesting();
                IOForm.TopLevel = false;
                IOForm.FormBorderStyle = FormBorderStyle.None;
                IOForm.Dock = DockStyle.Fill;
                pnlAutoIOTesting.Controls.Add(IOForm);
                IOForm.Show();

               // GlobalVariable.AlarmTrigger(DIO.DIDO.ECode.Emg_Pressed_Error, true, 0);
            }
            catch (Exception ex)
            {
                Logger.WriteLog(Logger.LogType.Error, "ManualScreen", "", ex.Message, ex.ToString());
            }
        }

        private void btnptpplusx_Click(object sender, EventArgs e)
        {
            try
            {
                double dTargetPos = 0;
                if (txtptppositionx.Text.Trim() == "")
                {
                    MessageBox.Show("Please Enter Position", "Manual Screen", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (txtptpspeedx.Text.Trim() == "")
                {
                    MessageBox.Show("Please Enter Speed", "Manual Screen", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (ServoAxis != null)
                {
                    if (!string.IsNullOrEmpty(txtptppositionx.Text))
                    {
                        dTargetPos = Convert.ToDouble(txtptppositionx.Text);
                        if (double.TryParse(txtptpspeedx.Text, out double speedValue))
                        {
                            btnptpplusx.Enabled = false;
                            if (!ServoAxis.Move_Rel(dTargetPos, speedValue, GlobalVariable.g_lstAxisConfig[axisindex].Acc,
                                GlobalVariable.g_lstAxisConfig[axisindex].DeAcc, 5000))
                            {
                                //Logger.WriteLog("Device_Interface", "jogfrwrd()", "PCIE-1203_Interface", "Exception Error", es.ToString());
                            }
                            lbl_Servo_TargetPosition.Text = dTargetPos.ToString();
                            btnptpplusx.Enabled = true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog(Logger.LogType.Error, "ManualScreen", "", ex.Message, ex.ToString());
            }
        }

        private void btnptpminx_Click(object sender, EventArgs e)
        {
            try
            {
                double dTargetPos = 0;
                if (txtptppositionx.Text.Trim() == "")
                {
                    MessageBox.Show("Please Enter Position", "Manual Screen", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (txtptpspeedx.Text.Trim() == "")
                {
                    MessageBox.Show("Please Enter Speed", "Manual Screen", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (ServoAxis != null)
                {
                    if (!string.IsNullOrEmpty(txtptppositionx.Text))
                    {
                        dTargetPos = Convert.ToDouble(txtptppositionx.Text);
                        if (double.TryParse(txtptpspeedx.Text, out double speedValue))
                        {
                            btnptpplusx.Enabled = false;
                            if (!ServoAxis.Move_Rel(-dTargetPos, speedValue, GlobalVariable.g_lstAxisConfig[axisindex].Acc,
                                GlobalVariable.g_lstAxisConfig[axisindex].DeAcc, 5000))
                            {
                                //Logger.WriteLog("Device_Interface", "jogfrwrd()", "PCIE-1203_Interface", "Exception Error", es.ToString());
                            }
                            lbl_Servo_TargetPosition.Text = dTargetPos.ToString();
                            btnptpplusx.Enabled = true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog(Logger.LogType.Error, "ManualScreen", "", ex.Message, ex.ToString());
            }
        }

        private void btnJogForward_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                ServoAxis?.Jog(0, 200, 10000, 10000);
            }
            catch (Exception ex)
            {
                Logger.WriteLog(Logger.LogType.Error, "ManualScreen", "", ex.Message, ex.ToString());
            }
        }

        private void btnJogForward_MouseUp(object sender, MouseEventArgs e)
        {
            try
            {
                ServoAxis?.Stop();
            }
            catch (Exception ex)
            {
                Logger.WriteLog(Logger.LogType.Error, "ManualScreen", "", ex.Message, ex.ToString());
            }
        }

        private void btnJogReverse_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                ServoAxis?.Jog(1, 200, 10000, 10000);
            }
            catch (Exception ex)
            {
                Logger.WriteLog(Logger.LogType.Error, "ManualScreen", "", ex.Message, ex.ToString());
            }
        }

        private void btnJogReverse_MouseUp(object sender, MouseEventArgs e)
        {
            try
            {
                ServoAxis?.Stop();
            }
            catch (Exception ex)
            {
                Logger.WriteLog(Logger.LogType.Error, "ManualScreen", "", ex.Message, ex.ToString());
            }
        }

        private void btn_Cny1Start_Click(object sender, EventArgs e)
        {
            try
            {
                ServoAxis?.Jog(0, Convert.ToDouble(txtSpeed_CrrCny1.Text), 10000, 10000);
            }
            catch (Exception ex)
            {
                Logger.WriteLog(Logger.LogType.Error, "ManualScreen", "", ex.Message, ex.ToString());
            }
        }

        private void btn_Cny1Stop_Click(object sender, EventArgs e)
        {
            try
            {
                ServoAxis?.Stop();
            }
            catch (Exception ex)
            {
                Logger.WriteLog(Logger.LogType.Error, "ManualScreen", "", ex.Message, ex.ToString());
            }
        }
        /// <summary>
        /// Handles global errors by updating the status label with error details.
        /// If an exception exists, displays the function name and message.
        /// Otherwise, displays the function name, message, and formatted error code.
        /// Changes the label text color to red for non-zero or null error codes,
        /// otherwise sets it to black.
        /// </summary>
        private void HandleGlobalError(ErrorInfo info)
        {
            //int errorcode = Convert.ToInt16(info.ErrorCode);
           // GlobalVariable.AlarmTrigger((ECode)errorcode, true, 1);

            richTextBoxStatus.Clear();
            richTextBoxStatus.ReadOnly = true;
            richTextBoxStatus.BorderStyle = BorderStyle.None;

            void AppendText(string stsHeader, string stsMessage)
            {
                richTextBoxStatus.SelectionColor = Color.Blue;
                richTextBoxStatus.SelectionFont = new Font(richTextBoxStatus.Font, FontStyle.Bold);
                richTextBoxStatus.AppendText(stsHeader);
                richTextBoxStatus.SelectionColor = (info.ErrorCode == "0") ? Color.Black : Color.Red;
                richTextBoxStatus.SelectionFont = new Font(richTextBoxStatus.Font, FontStyle.Regular);
                richTextBoxStatus.AppendText(stsMessage);
            }

            if (info.Exception != null)
            {
                AppendText("Function Name: ", info.FunctionName);
                AppendText("\nI/O Name: ", info.IOName);
                AppendText("\nException: ", info.Message);
            }
            else if(info.ErrorCode != "0")
            {
                AppendText("Function Name: ", info.FunctionName);
                AppendText("\nI/O Name: ", info.IOName);
                AppendText("\nMessage: ", info.Message);
                AppendText("\nError Code: ", info.ErrorCode);
            }
        }
    }
}
