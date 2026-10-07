using DIO;
using DynamicCylinders;
using DynamicVacuums;
using ExceptionLib;
using HelperClassLib;
using IO_Stepper;
using Master;
using Master.CommonClass;
using Program;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace UIForms
{

    public partial class ManualScreen : Form
    {


        public Advantech_PCIE ServoAxis;
        public Advantech_PCIE_Stepper StepperAxis;

        public string Stepper { get; set; }
        public string Servo { get; set; }
        int axisindex = 0;
        int StepperAxisIndex = 0;
        int stepperIndex = 0;
        public int PosLimit_Error = 0;


        #region TCP Connections

        //public string filePath = Environment.CurrentDirectory + @"\Data\AvailableDevices.Csv";
        //public EnumerableRowCollection<DataRow> AvblVision;
        //public EnumerableRowCollection<DataRow> AvblScanner;
        //public EnumerableRowCollection<DataRow> AvblOPT;
        public SocketClient TCPObj;
        public SocketClient scanObj;
        public Serial_Communication COMPortObj;

        public string RoboResult = string.Empty;

        #endregion

        //public string[] 
        public ManualScreen()
        {
            InitializeComponent();
            tabControl2.TabPages.Remove(tabPageRobot);
            tabControl2.TabPages.Remove(tabPageLightControl);
            ServoAxis = ObjectList.MotorObj[0];
            foreach (var obj in ObjectList.CCDObj)
                cmbCCD.Items.Add(obj.ToString());
            LoadMotorAxes();
            //rbtInputState1.InitRoboInputs();
            //rbtOutputState1.InitRoboOutputs();
            loadAvblDevices();
            if(GlobalVariable.ConveyorIO == "Yes")
            {
                LoadConveyorMotor();

            }
            float xRatio = (float)Screen.PrimaryScreen.Bounds.Width / GlobalVariable.OrginalFormWidth;
            float yRatio = (float)Screen.PrimaryScreen.Bounds.Height / GlobalVariable.OrginalFormHeight;
            GlobalVariable.ResizeAllControls(this, xRatio, yRatio);
            ErrorHandler.OnErrorRaised += HandleGlobalError;
            grpCCDConn.Left = (tabPageCamera.ClientSize.Width - grpCCDConn.Width) / 2;

            cmbRBTmodeselect.Left = (lblCmd.Right) + 10;
            lblConnStatus.Left = (lblrobotconnstatus.Left) - 90;
            cmbCCD.Left = (lblSelectCCD.Right) + 10;
            lblCCDConn.Left = (lblCCDConnStatus.Left) - 90;
            cmbCOMPort.Left = (label11.Right) + 10;
            label17.Left = (lblOPTConStatus.Left) - 90;
            cmbScanner.Left = (lblScannerSel.Right) + 10;
            lblScannerConn.Left = (lblScanrConStatus.Left) - 90;
            label14.Left = (lblSFCConStatus.Left) - 90;

            if (GlobalVariable.ConveyorIO == "Yes")
            {
                grp_IO_Conv_Stepper_1.Visible = false;
                grp_IO_Conv_Stepper_2.Visible = false;
                grp_IO_Conv.Visible = true;
                StepperAxisComb.Visible = false;
                groupBox15.Visible = false;
                cmbConveyorStepperCombo.Visible = true;

            }
            else
            {
                grp_IO_Conv.Visible = false;
                grp_IO_Conv_Stepper_1.Visible = true;
                grp_IO_Conv_Stepper_2.Visible = true;
                StepperAxisComb.Visible = true;
                groupBox15.Visible = true;
                cmbConveyorStepperCombo.Visible = false;

            }
        }

        public bool isstoped = false;

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            ErrorHandler.OnErrorRaised -= HandleGlobalError;
            base.OnFormClosing(e);
        }

        private void LoadMotorAxes()
        {
            try
            {
                if (GlobalVariable.ConveyorCount == 6 && GlobalVariable.ConveyorIO == "No")
                {
                    var StepperMotorList = ObjectList.MotorObjstepper.Select(kv => new
                    {
                        Key = kv.Key,
                        Motor = kv.Value,
                        Name = kv.Value.motor_Params.name
                    }).ToList();

                    StepperAxisComb.DataSource = StepperMotorList;
                    StepperAxisComb.DisplayMember = "Name";
                    StepperAxisComb.ValueMember = "Key";
                }
                else if (GlobalVariable.ConveyorCount == 4 && GlobalVariable.ConveyorIO == "No")
                {
                    var StepperMotorList_4 = ObjectList.MotorObjstepper_4.Select(kv => new
                    {
                        Key = kv.Key,
                        Motor = kv.Value,
                        Name = kv.Value.motor_Params.name
                    }).ToList();

                    StepperAxisComb.DataSource = StepperMotorList_4;
                    StepperAxisComb.DisplayMember = "Name";
                    StepperAxisComb.ValueMember = "Key";
                }
                else if (GlobalVariable.ConveyorCount == 6 && GlobalVariable.ConveyorIO == "Yes")
                {
                    var StepperMotorList_4 = ObjectList.MotorObjstepper_4.Select(kv => new
                    {
                        Key = kv.Key,
                        Motor = kv.Value,
                        Name = kv.Value.motor_Params.name
                    }).ToList();

                    StepperAxisComb.DataSource = StepperMotorList_4;
                    StepperAxisComb.DisplayMember = "Name";
                    StepperAxisComb.ValueMember = "Key";
                }

                // Loading the Motor Object from ObjectList.MotorObj Dictionary
                var motorList = ObjectList.MotorObj.Select(kv => new
                {
                    Key = kv.Key,
                    Motor = kv.Value,
                    Name = kv.Value.motor_Params.name
                }).ToList();

                //AxisSelectCombo.DataSource = GlobalVariable.ServoRows.CopyToDataTable();
                //AxisSelectCombo.DisplayMember = "Servo";
                //AxisSelectCombo.ValueMember = "Servo";                

                AxisSelectCombo.DataSource = motorList;
                AxisSelectCombo.DisplayMember = "Name";
                AxisSelectCombo.ValueMember = "Key";

            }
            catch (Exception ex)
            {
                Logger.WriteLog(Logger.LogType.Error, "Manual Screen", "LoadMotorAxes", "Exception Error", ex.ToString());

            }
        }

        private void loadAvblDevices()
        {
            try
            {
                cmbCCD.DataSource = null;
                cmbScanner.DataSource = null;
                cmbCOMPort.DataSource = null;

                // DataTable dt = new DataTable();
                // dt = HelperClassLib.GetDataFromHelper.GetDataFromCSV(filePath);
                // AvblVision = dt.AsEnumerable()
                // .Where(row => !string.IsNullOrWhiteSpace(row.Field<string>("Vision")));
                // AvblScanner = dt.AsEnumerable()
                //.Where(row => !string.IsNullOrWhiteSpace(row.Field<string>("Scanner")));
                // AvblOPT = dt.AsEnumerable()
                //     .Where(row => !string.IsNullOrWhiteSpace(row.Field<string>("OPT")));

                // cmbCCD.DataSource = AvblVision.CopyToDataTable();
                // cmbCCD.DisplayMember = "Vision";
                // cmbCCD.ValueMember = "Vision";

                // cmbScanner.DataSource = AvblScanner.CopyToDataTable();
                // cmbScanner.DisplayMember = "Scanner";
                // cmbScanner.ValueMember = "Scanner";

                // cmbCOMPort.DataSource = AvblOPT.CopyToDataTable();
                // cmbCOMPort.DisplayMember = "OPT";
                // cmbCOMPort.ValueMember = "OPT";

                // cmbScanner.SelectedIndex = 0;
                // cmbCCD.SelectedIndex = 0;
                // cmbCOMPort.SelectedIndex = 0;
                // cmbOPTSend.SelectedIndex = 0;

                // if (AvblScanner.Count() > 0)
                // {
                //     lblScannerSel.Visible = true;
                //     cmbScanner.Visible = true;

                // }
                // else
                // {
                //     lblScannerSel.Visible = false;
                //     cmbScanner.Visible = false;
                // }

                // cmbCCD.SelectedIndex = 0;
                // cmbScanner.SelectedIndex = 0;
                // cmbRBTmodeselect.SelectedIndex = 0;



                var ccdList = ObjectList.CCDObj
    .Select(kv => new
    {
        Key = kv.Key,
        CCD = kv.Value,
        Name = kv.Value.ConnectionStrName
    })
    .ToList();

                cmbCCD.DataSource = ccdList;
                cmbCCD.DisplayMember = "Name";
                cmbCCD.ValueMember = "Key";


                var scannerList = ObjectList.ScnrObj
    .Select(kv => new
    {
        Key = kv.Key,
        Scanner = kv.Value,
        Name = kv.Value.ConnectionStrName
    })
    .ToList();

                cmbScanner.DataSource = scannerList;
                cmbScanner.DisplayMember = "Name";
                cmbScanner.ValueMember = "Key";

                var optList = ObjectList.COMObj
    .Select(kv => new
    {
        Key = kv.Key,
        Scanner = kv.Value,
        Name = kv.Value.OPT_COM
    })
    .ToList();

                cmbCOMPort.DataSource = optList;
                cmbCOMPort.DisplayMember = "Name";
                cmbCOMPort.ValueMember = "Key";


                cmbScanner.SelectedIndex = 0;
                cmbCCD.SelectedIndex = 0;
                cmbCOMPort.SelectedIndex = 0;
                cmbOPTSend.SelectedIndex = 0;

                cmbRBTmodeselect.SelectedIndex = 0;





            }
            catch (Exception ex)
            {
                Logger.WriteLog(Logger.LogType.Error, "Settings", "", ex.Message, ex.ToString());
            }
        }

        private void AxisSelectCombo_SelectedIndexChanged(object sender, EventArgs e)
        {

            Advantech_PCIE selectedMotor = ((dynamic)AxisSelectCombo.SelectedItem).Motor;
            ServoAxis = ObjectList.MotorObj[(int)((dynamic)AxisSelectCombo.SelectedItem).Key];

            axisindex = AxisSelectCombo.SelectedIndex;
            //ServoAxis = ObjectList.MotorObj[axisindex];
            EnableControls();
        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e) //AK
        {
            if(GlobalVariable.ConveyorIO == "No")
            {
                Advantech_PCIE_Stepper selectedMotor = ((dynamic)StepperAxisComb.SelectedItem).Motor;

                if (GlobalVariable.ConveyorCount == 4)
                {
                    StepperAxis = ObjectList.MotorObjstepper_4[(int)((dynamic)StepperAxisComb.SelectedItem).Key];

                    StepperAxisIndex = StepperAxisComb.SelectedIndex;
                    stepperIndex = (int)((dynamic)StepperAxisComb.SelectedItem).Key;
                    EnableControls();
                }
                if (GlobalVariable.ConveyorCount == 6 && GlobalVariable.ConveyorIO == "No")
                {
                    StepperAxis = ObjectList.MotorObjstepper[(int)((dynamic)StepperAxisComb.SelectedItem).Key];
                    StepperAxisIndex = StepperAxisComb.SelectedIndex;
                    stepperIndex = (int)((dynamic)StepperAxisComb.SelectedItem).Key;
                    EnableControls();
                }
            }
            if (GlobalVariable.ConveyorIO == "Yes")
            {
                UpdateConvStepperStatus();

            }

            //if (GlobalVariable.ConveyorIO == "Yes" && GlobalVariable.ConveyorCount == 6)
            //{
            //    UpdateConvStepperStatus();

            //}



        }
        public void EnableControls()
        {
            if (axisindex > 11)
            {
                grbPTP.Enabled = true;
                groupBox8.Enabled = true;
                groupBox11.Enabled = true;
                groupBox10.Enabled = true;
                grbPTP.Enabled = true;
            }
            else
            {
                if (GlobalVariable.g_HomingDone || ServoAxis.Home_Done == true)
                {
                    grbPTP.Enabled = true;
                    groupBox8.Enabled = true;
                    groupBox11.Enabled = true;
                    groupBox10.Enabled = true;
                }
                else
                {
                    grbPTP.Enabled = true;
                    groupBox8.Enabled = true;
                    groupBox11.Enabled = true;
                    groupBox10.Enabled = true;
                }
            }

        }



        private void button45_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtJogSpeed.Text == "0")
                {
                    MessageBox.Show("The 0 is not vaild spped , Enter the <0", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (txtJogSpeed.Text == "0")
                {
                    MessageBox.Show("The Spped is empty please enter the value !", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    //ServoAxis.Jog(0);
                }

            }
            catch (Exception ex)
            {
                //Arulkumar Fixed random stoppage start
                Logger.WriteLog(Logger.LogType.Error, "ManualScreen", "Jog_Handler", ex.Message, ex.ToString());
                //Arulkumar Fixed random stoppage end
            }
        }

        private void button44_Click(object sender, EventArgs e)
        {
            try
            {
                //ServoAxis.Jog(1);
            }
            catch (Exception ex)
            {
                Logger.WriteLog(Logger.LogType.Error, "ManualScreen", "", ex.Message, ex.ToString());
            }
        }

        private void button51_Click(object sender, EventArgs e)
        {
            try
            {
                double Safe_pos = ObjectList.Servo_Z1.GetCurrentPosition();
                double Safe_pos2 = ObjectList.Servo_Z2.GetCurrentPosition();
                if (Safe_pos <= GlobalVariable.SafePosition.PositionZ1 && Safe_pos2 <= GlobalVariable.SafePosition.PositionZ2 && (AxisSelectCombo.SelectedIndex != 6 || AxisSelectCombo.SelectedIndex != 7))
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
                                    GlobalVariable.g_lstAxisConfig[axisindex].DeAcc, 15000, false))
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
                else if ((AxisSelectCombo.SelectedIndex == 6 || AxisSelectCombo.SelectedIndex == 7))
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
                                    GlobalVariable.g_lstAxisConfig[axisindex].DeAcc, 15000, false))
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
                else if ((AxisSelectCombo.SelectedIndex == 12 || AxisSelectCombo.SelectedIndex == 13))
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
                                    GlobalVariable.g_lstAxisConfig[axisindex].DeAcc, 15000, false))
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
                else
                {
                    MessageBox.Show("Move Z1 && Z2 SAfe Position...");
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
            catch (Exception ex)
            {
                Logger.WriteLog(Logger.LogType.Error, "ManualScreen", "", ex.Message, ex.ToString());
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
                double Safe_pos = ObjectList.Servo_Z1.GetCurrentPosition();
                double Safe_pos2 = ObjectList.Servo_Z2.GetCurrentPosition();
                if (Safe_pos <= GlobalVariable.SafePosition.PositionZ1 && Safe_pos2 <= GlobalVariable.SafePosition.PositionZ2)
                {

                    if (txtHome_Velocity.Text.Length == 0)
                    {
                        MessageBox.Show("Please Enter the Velocity for Homing ", "Homing", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    if (ServoAxis != null)
                    {
                        double speed = Convert.ToDouble(txtHome_Velocity.Text);
                        ServoAxis.Set_Home_Vel(speed, GlobalVariable.g_lstAxisConfig[axisindex].Acc, GlobalVariable.g_lstAxisConfig[axisindex].DeAcc);


                        Task.Run(() => ServoAxis.ManulHoming(1, speed));



                        // GlobalVariable.AxisHomingStatus[axisindex] = true;
                        EnableControls();
                    }
                }
                else if ((AxisSelectCombo.SelectedIndex == 6 || AxisSelectCombo.SelectedIndex == 7))
                {

                    if (txtHome_Velocity.Text.Length == 0)
                    {
                        MessageBox.Show("Please Enter the Velocity for Homing ", "Homing", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    if (ServoAxis != null)
                    {
                        double speed = Convert.ToDouble(txtHome_Velocity.Text);
                        ServoAxis.Set_Home_Vel(speed, GlobalVariable.g_lstAxisConfig[axisindex].Acc, GlobalVariable.g_lstAxisConfig[axisindex].DeAcc);


                        Task.Run(() => ServoAxis.ManulHoming(1, speed));



                        // GlobalVariable.AxisHomingStatus[axisindex] = true;
                        EnableControls();
                    }
                }

                else
                {
                    MessageBox.Show("Move Z1 && Z2 SAfe Position...");
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
                            if (!ServoAxis.Move_Abs(dTargetPos, speedValue, GlobalVariable.g_lstAxisConfig[axisindex].Acc, GlobalVariable.g_lstAxisConfig[axisindex].DeAcc, 5000, false))
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
                    bool[] ioStatusArray = ServoAxis.ToGetMotionIOStatus();


                    lbl_Servo_Actual_Position.Text = ActPos.ToString("F2");


                    ObjectList.Stepper_1.GetCurrentPos(out ActPos, out actstatus, out ActPvel);

                    //if (ServoAxis.GetSingleMotionIOBit(Advantech_PCIE.MotionIOBit.RDY))
                    //{
                    //    lblServoEnableColor.BackColor = Color.Green;
                    //    lblServoReadyColor.BackColor = Color.Green;
                    //}
                    //else
                    //{
                    //    lblServoEnableColor.BackColor = Color.Maroon;
                    //    lblServoReadyColor.BackColor = Color.Green;
                    //}
                    if (tabControl2.SelectedIndex == 0)
                    {
                        lblServoEnableColor.BackColor = ioStatusArray[(int)Advantech_PCIE.MotionIOBit.SVON] ? Color.Green : Color.Maroon;
                        //lblServoReadyColor.BackColor = ioStatusArray[(int)Advantech_PCIE.MotionIOBit.SVON] ? Color.Green : Color.Maroon;
                        lblServoHomedColor.BackColor = ServoAxis.Home_Done ? Color.Green : Color.Maroon;
                        lblServoErrorColor.BackColor = ioStatusArray[(int)Advantech_PCIE.MotionIOBit.ALM] ? Color.Green : Color.Maroon;
                        lblNegLimitColor.BackColor = ioStatusArray[(int)Advantech_PCIE.MotionIOBit.LMT_N] ? Color.Green : Color.Maroon;
                        lblPosLimColor.BackColor = ioStatusArray[(int)Advantech_PCIE.MotionIOBit.LMT_P] ? Color.Green : Color.Maroon;
                        lblServoHomeColor.BackColor = ioStatusArray[(int)Advantech_PCIE.MotionIOBit.ORG] ? Color.Green : Color.Maroon;
                    }

                    string str = ServoAxis.ToGetStatus();
                    if (str.Contains("ERROR_STOP"))
                    {
                        lblServoErrorColor.BackColor = Color.Green;
                    }
                    else
                    {
                        lblServoErrorColor.BackColor = Color.Maroon;
                    }
                    //double dActSpeed = 0;

                    //ServoAxis.GetActualVelocity(out dActSpeed);
                    //lbl_Servo_TargetPosition.Text = dActSpeed.ToString();
                    //if (actstatus.ToUpper().Contains("DISABLE"))
                    //{
                    //    lblServoDisableColor.BackColor = Color.Green;
                    //}
                    //else
                    //{
                    //    lblServoDisableColor.BackColor = Color.Maroon;
                    //}

                    //if (actstatus.ToUpper().Contains("HOMING"))
                    //{
                    //    lblServoHomeColor.BackColor = Color.Green;
                    //}
                    //else
                    //{
                    //    lblServoHomeColor.BackColor = Color.Maroon;
                    //}

                    //if (actstatus.ToUpper().Contains("ERROR"))
                    //{
                    //    lblServoErrorColor.BackColor = Color.Green;
                    //}
                    //else
                    //{
                    //    lblServoErrorColor.BackColor = Color.Maroon;
                    //}

                    if (actstatus.ToUpper().Contains("MOTION"))
                    {
                        lblServoRunningColor.BackColor = Color.Green;
                    }
                    else
                    {
                        lblServoRunningColor.BackColor = Color.Maroon;
                    }

                    ChkDeviceConStatus();
                    ChkScannerConStatus();
                    ChkSFCConStatus();
                    #region CONVEYOR STEPPER
                    if (tabControl2.SelectedIndex == 2) // FOR STEPPER CONVEYOR TAB
                    {
                        UpdateConvStepperStatus();
                    }

                    #endregion
                }
                if(GlobalVariable.ConveyorIO == "No")
                {
                    if (StepperAxis != null)
                    {
                        double ActPos = 0;
                        double ActPvel = 0;
                        string actstatus = "";
                        StepperAxis.GetCurrentPos(out ActPos, out actstatus, out ActPvel);
                        bool[] ioStatusArray = StepperAxis.ToGetMotionIOStatus();


                        //Actualpos_Stp.Text = ActPos.ToString("F2");


                        ObjectList.Stepper_1.GetCurrentPos(out ActPos, out actstatus, out ActPvel);


                        if (tabControl2.SelectedIndex == 1)
                        {
                            lblServoEnableColor_Stp.BackColor = ioStatusArray[(int)Advantech_PCIE_Stepper.MotionIOBit.SVON] ? Color.Green : Color.Maroon;
                            //lblServoReadyColor.BackColor = ioStatusArray[(int)Advantech_PCIE.MotionIOBit.SVON] ? Color.Green : Color.Maroon;
                            //lblServoHomedColor_Stp.BackColor = StepperAxis.Home_Done ? Color.Green : Color.Maroon;
                            lblServoErrorColor_Stp.BackColor = ioStatusArray[(int)Advantech_PCIE_Stepper.MotionIOBit.ALM] ? Color.Green : Color.Maroon;
                            //lblNegLimitColor_Stp.BackColor = ioStatusArray[(int)Advantech_PCIE_Stepper.MotionIOBit.LMT_N] ? Color.Green : Color.Maroon;
                            //lblPosLimColor_Stp.BackColor = ioStatusArray[(int)Advantech_PCIE_Stepper.MotionIOBit.LMT_P] ? Color.Green : Color.Maroon;
                            //lblServoHomeColor_Stp.BackColor = ioStatusArray[(int)Advantech_PCIE_Stepper.MotionIOBit.ORG] ? Color.Green : Color.Maroon;
                            //lblServoRunningColor_Stp.BackColor = ioStatusArray[(int)Advantech_PCIE_Stepper.MotionIOBit.]
                        }

                        string str = StepperAxis.ToGetStatus();
                        if (str.Contains("ERROR_STOP"))
                        {
                            lblServoErrorColor_Stp.BackColor = Color.Green;
                        }
                        else
                        {
                            lblServoErrorColor_Stp.BackColor = Color.Maroon;
                        }


                        //if (actstatus.ToUpper().Contains("MOTION"))
                        //{
                        //    //lblServoRunningColor_Stp.BackColor = Color.Green;
                        //    lblServoRunningColor_Stp.BackColor = Color.Maroon;
                        //}
                        //else
                        //{
                        //    //lblServoRunningColor_Stp.BackColor = Color.Maroon;
                        //    lblServoRunningColor_Stp.BackColor = Color.Green;
                        //}

                        ChkDeviceConStatus();
                        #region CONVEYOR STEPPER
                        if (tabControl2.SelectedIndex == 2) // FOR STEPPER CONVEYOR TAB
                        {

                            UpdateConvStepperStatus();


                        }

                        #endregion
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
            catch (Exception ex)
            {
                Logger.WriteLog(Logger.LogType.Error, "ManualScreen", "", ex.Message, ex.ToString());
            }
        }



        private void btnWorkConStart_Click(object sender, EventArgs e)
        {

        }
        DynamicVacuum VacForm = new DynamicVacuum();
        DynamicCylinder CylForm = new DynamicCylinder();

        private void ManualScreen_Load(object sender, EventArgs e)
        {
            try
            {
                // GlobalVariable.g_lstAlarmInfo[(int)DIDO.ECode.Button_Picking_Timeout_Error].AlarmHappen = true;
                if (ServoAxis != null)
                {
                    ServoAxis = ObjectList.MotorObj[0];
                }
                //txtServoX_Targetposition.KeyPress += GlobalVariable.AllowOnlyDecimal_TextBox;
                //txtServoX_Targetspeed.KeyPress += GlobalVariable.AllowOnlyDecimal_TextBox;
                //txtHome_Velocity.KeyPress += GlobalVariable.AllowOnlyDecimal_TextBox;
                //txtptppositionx.KeyPress += GlobalVariable.AllowOnlyDecimal_TextBox;
                //txtptpspeedx.KeyPress += GlobalVariable.AllowOnlyDecimal_TextBox;

                CylForm.TopLevel = false;
                CylForm.FormBorderStyle = FormBorderStyle.None;
                CylForm.Dock = DockStyle.Fill;
                PnlCylinderMain.Controls.Add(CylForm);
                CylForm.Show();

                VacForm.TopLevel = false;
                VacForm.FormBorderStyle = FormBorderStyle.None;
                VacForm.Dock = DockStyle.Fill;
                PnlVacuumMain.Controls.Add(VacForm);
                VacForm.Show();
            }
            catch (Exception ex)
            {
                Logger.WriteLog(Logger.LogType.Error, "ManualScreen", "", ex.Message, ex.ToString());
            }
        }

        private void btnConDryrun_Click(object sender, EventArgs e)
        {

        }

        private void label57_Click(object sender, EventArgs e)
        {

        }

        private void label55_Click(object sender, EventArgs e)
        {

        }

        private void btnConStop_Click(object sender, EventArgs e)
        {

        }

        private void btnWorkConStop_Click(object sender, EventArgs e)
        {

        }

        //private void btnptpplusx_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        double dTargetPos = 0;
        //        if (txtptppositionx.Text.Trim() == "")
        //        {
        //            MessageBox.Show("Please Enter Position", "Manual Screen", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //            return;
        //        }
        //        if (txtptpspeedx.Text.Trim() == "")
        //        {
        //            MessageBox.Show("Please Enter Speed", "Manual Screen", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //            return;
        //        }

        //        if (ServoAxis != null)
        //        {
        //            if (!string.IsNullOrEmpty(txtptppositionx.Text))
        //            {
        //                dTargetPos = Convert.ToDouble(txtptppositionx.Text);
        //                if (double.TryParse(txtptpspeedx.Text, out double speedValue))
        //                {
        //                    btnptpplusx.Enabled = false;
        //                    if (!ServoAxis.Move_Rel(dTargetPos, speedValue, GlobalVariable.g_lstAxisConfig[axisindex].Acc, 
        //                        GlobalVariable.g_lstAxisConfig[axisindex].DeAcc, 5000, false))
        //                    {
        //                        //Logger.WriteLog("Device_Interface", "jogfrwrd()", "PCIE-1203_Interface", "Exception Error", es.ToString());
        //                    }
        //                    lbl_Servo_TargetPosition.Text = dTargetPos.ToString();
        //                    btnptpplusx.Enabled = true;
        //                }
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Logger.WriteLog(Logger.LogType.Error, "ManualScreen", "", ex.Message, ex.ToString());
        //    }
        //}

        //private void btnptpminx_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        double dTargetPos = 0;
        //        if (txtptppositionx.Text.Trim() == "")
        //        {
        //            MessageBox.Show("Please Enter Position", "Manual Screen", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //            return;
        //        }
        //        if (txtptpspeedx.Text.Trim() == "")
        //        {
        //            MessageBox.Show("Please Enter Speed", "Manual Screen", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //            return;
        //        }

        //        if (ServoAxis != null)
        //        {
        //            if (!string.IsNullOrEmpty(txtptppositionx.Text))
        //            {
        //                dTargetPos = Convert.ToDouble(txtptppositionx.Text);
        //                if (double.TryParse(txtptpspeedx.Text, out double speedValue))
        //                {
        //                    btnptpplusx.Enabled = false;
        //                    if (!ServoAxis.Move_Rel(- dTargetPos, speedValue, GlobalVariable.g_lstAxisConfig[axisindex].Acc, 
        //                        GlobalVariable.g_lstAxisConfig[axisindex].DeAcc, 5000, false))
        //                    {
        //                        //Logger.WriteLog("Device_Interface", "jogfrwrd()", "PCIE-1203_Interface", "Exception Error", es.ToString());
        //                    }
        //                    lbl_Servo_TargetPosition.Text = dTargetPos.ToString();
        //                    btnptpplusx.Enabled = true;
        //                }
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Logger.WriteLog(Logger.LogType.Error, "ManualScreen", "", ex.Message, ex.ToString());
        //    }
        //}


        private void btnJogForward_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                double Safe_pos = ObjectList.Servo_R1.GetCurrentPosition();
                double Safe_pos2 = ObjectList.Servo_R2.GetCurrentPosition();


                if (AxisSelectCombo.SelectedIndex == 8)
                {
                    if (Safe_pos <= 120)
                    {
                        ServoAxis.Jog(0, Convert.ToDouble(txtJogSpeed.Text), GlobalVariable.g_lstAxisConfig[axisindex].Acc, GlobalVariable.g_lstAxisConfig[axisindex].DeAcc);
                    }
                    else
                    {
                        MessageBox.Show("Servo R1 Reached Safe Limit", "hint", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else if (AxisSelectCombo.SelectedIndex == 9)
                {
                    if (Safe_pos2 <= 120)
                    {
                        ServoAxis.Jog(0, Convert.ToDouble(txtJogSpeed.Text), GlobalVariable.g_lstAxisConfig[axisindex].Acc, GlobalVariable.g_lstAxisConfig[axisindex].DeAcc);
                    }
                    else
                    {
                        MessageBox.Show("Servo R2 Reached Safe Limit", "hint", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);
                    }
                }

                else
                if (
                    AxisSelectCombo.SelectedIndex == 4 ||
                    AxisSelectCombo.SelectedIndex == 5 ||
                    AxisSelectCombo.SelectedIndex == 6 ||
                    AxisSelectCombo.SelectedIndex == 7 ||
                    AxisSelectCombo.SelectedIndex == 10 ||
                    AxisSelectCombo.SelectedIndex == 11 ||
                    AxisSelectCombo.SelectedIndex == 12 ||
                    AxisSelectCombo.SelectedIndex == 13
                    )
                {
                    ServoAxis.Jog(0, Convert.ToDouble(txtJogSpeed.Text), GlobalVariable.g_lstAxisConfig[axisindex].Acc, GlobalVariable.g_lstAxisConfig[axisindex].DeAcc);
                }
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
                if (ServoAxis != null)
                {
                    ServoAxis.StopJog();
                    ServoAxis.Stop();
                }
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
                double Safe_pos = ObjectList.Servo_R1.GetCurrentPosition();
                double Safe_pos2 = ObjectList.Servo_R2.GetCurrentPosition();


                if (AxisSelectCombo.SelectedIndex == 8)
                {
                    if (Safe_pos <= -120)
                    {
                        ServoAxis.Jog(1, Convert.ToDouble(txtJogSpeed.Text), GlobalVariable.g_lstAxisConfig[axisindex].Acc, GlobalVariable.g_lstAxisConfig[axisindex].DeAcc);
                    }
                    else
                    {
                        MessageBox.Show("Servo R1 Reached Safe Limit", "hint", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);
                    }
                }
                else if (AxisSelectCombo.SelectedIndex == 9)
                {
                    if (Safe_pos2 <= -120)
                    {
                        ServoAxis.Jog(1, Convert.ToDouble(txtJogSpeed.Text), GlobalVariable.g_lstAxisConfig[axisindex].Acc, GlobalVariable.g_lstAxisConfig[axisindex].DeAcc);
                    }
                    else
                    {
                        MessageBox.Show("Servo R2 Reached Safe Limit", "hint", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                if (
                    AxisSelectCombo.SelectedIndex == 4 ||
                    AxisSelectCombo.SelectedIndex == 5 ||
                    AxisSelectCombo.SelectedIndex == 6 ||
                    AxisSelectCombo.SelectedIndex == 7 ||
                    AxisSelectCombo.SelectedIndex == 10 ||
                    AxisSelectCombo.SelectedIndex == 11 ||
                    AxisSelectCombo.SelectedIndex == 12 ||
                    AxisSelectCombo.SelectedIndex == 13
                    )
                {
                    if (ServoAxis != null)
                    {
                        ServoAxis.Jog(1, Convert.ToDouble(txtJogSpeed.Text), GlobalVariable.g_lstAxisConfig[axisindex].Acc, GlobalVariable.g_lstAxisConfig[axisindex].DeAcc);
                    }
                }
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
                if (ServoAxis != null)
                {
                    ServoAxis.StopJog();
                    ServoAxis.Stop();
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog(Logger.LogType.Error, "ManualScreen", "", ex.Message, ex.ToString());
            }
        }

        private void PnlVacuumMain_Paint(object sender, PaintEventArgs e)
        {

        }

        private void HandleGlobalError(ErrorInfo info)
        {
            richTextBoxStatus.Clear();
            richTextBoxStatus.ReadOnly = true;
            richTextBoxStatus.BorderStyle = BorderStyle.None;



            if (info.Exception != null)
            {
                AppendText("Function Name: ", info.FunctionName);
                AppendText("\nI/O Name: ", info.IOName);
                AppendText("\nException: ", info.Message);
            }
            else if (info.ErrorCode != "0")
            {
                AppendText("Function Name: ", info.FunctionName);
                AppendText("\nI/O Name: ", info.IOName);
                AppendText("\nMessage: ", info.Message);
                AppendText("\nError Code: ", info.ErrorCode);
            }
        }

        void AppendText(string stsHeader, string stsMessage)
        {
            richTextBoxStatus.SelectionColor = Color.Blue;
            richTextBoxStatus.SelectionFont = new Font(richTextBoxStatus.Font, FontStyle.Bold);
            richTextBoxStatus.AppendText(stsHeader);
            //richTextBoxStatus.SelectionColor = (info.ErrorCode == "0") ? Color.Black : Color.Red;
            richTextBoxStatus.SelectionFont = new Font(richTextBoxStatus.Font, FontStyle.Regular);
            richTextBoxStatus.AppendText(stsMessage);
        }

        private void tabControl2_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (tabControl2.SelectedIndex == 1)
                {
                    //ServoAxis = ObjectList.MotorObj[stepperIndex + GlobalVariable.ServoRows.Count()];
                }


                if (tabControl2.SelectedTab != tabPageVacuum)
                {
                    VacForm.btnCloseAll_Click(null, null);
                }

                if (tabControl2.SelectedTab != tabPageCylinder)
                {
                    CylForm.btnCloseAll_Click(null, null);
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog(Logger.LogType.Error, "ManualScreen", "", ex.Message, ex.ToString());
            }
        }

        private void btnPTP_Move_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtPTP_Start.Text.Trim() == "")
                {
                    MessageBox.Show("Please enter start position", "Manual Screen", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (txtPTP_End.Text.Trim() == "")
                {
                    MessageBox.Show("Please enter end position", "Manual Screen", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (ServoAxis != null)
                {
                    Task.Run(() => MovePTP());
                }

            }
            catch (Exception ex)
            {
                //Arulkumar Fixed random stoppage start
                Logger.WriteLog(Logger.LogType.Error, "ManualScreen", "btnPTP_Start_Click", ex.Message, ex.ToString());
                //Arulkumar Fixed random stoppage end
            }
        }

        public async Task MovePTP()
        {
            try
            {
                double dTargetstart = 0;
                double dTargetend = 0;
                double speedValue = 0;
                int iteration = Convert.ToInt32(txtIteration.Text.Trim());
                int waittime = Convert.ToInt32(txtWait.Text.Trim());

                for (int i = 0; i < iteration; i++)
                {
                    if (isstoped)
                    {
                        isstoped = false;
                        return;
                    }
                    dTargetstart = Convert.ToDouble(txtPTP_Start.Text);
                    speedValue = Convert.ToDouble(txtPTP_Speed.Text);
                    if (ServoAxis.Move_Abs(dTargetstart, speedValue, GlobalVariable.g_lstAxisConfig[axisindex].Acc, GlobalVariable.g_lstAxisConfig[axisindex].DeAcc, 15000, true))
                    {
                        //lbl_Servo_TargetPosition.Text = dTargetstart.ToString();
                    }
                    else
                    {
                        return;
                    }


                    await Task.Delay(waittime * 1000);


                    dTargetend = Convert.ToDouble(txtPTP_End.Text);
                    speedValue = Convert.ToDouble(txtPTP_Speed.Text);

                    if (ServoAxis.Move_Abs(dTargetend, speedValue, GlobalVariable.g_lstAxisConfig[axisindex].Acc, GlobalVariable.g_lstAxisConfig[axisindex].DeAcc, 15000, true))
                    {
                        //lbl_Servo_TargetPosition.Text = dTargetstart.ToString();
                    }
                    else
                    {
                        return;
                    }

                    await Task.Delay(waittime * 1000);

                }

                MessageBox.Show("Point To Point Process Completed", "Manual Screen", MessageBoxButtons.OK, MessageBoxIcon.Information);



            }
            catch (Exception ex)
            {
                //Arulkumar Fixed random stoppage start
                Logger.WriteLog(Logger.LogType.Error, "ManualScreen", "MovePTP", ex.Message, ex.ToString());
                //Arulkumar Fixed random stoppage end
            }
        }

        private void btnPTP_Stop_Click(object sender, EventArgs e)
        {
            try
            {
                isstoped = true;
                ServoAxis.Stop();
            }
            catch (Exception ex)
            {
                //Arulkumar Fixed random stoppage start
                Logger.WriteLog(Logger.LogType.Error, "ManualScreen", "btnPTP_Stop_Click", ex.Message, ex.ToString());
                //Arulkumar Fixed random stoppage end
            }
        }

        private void ChkDeviceConStatus()
        {
            try
            {
                TCPObj = ObjectList.CCDObj[cmbCCD.SelectedIndex];
                if (TCPObj != null && TCPObj.IsConnected)
                {
                    lblCCDConnStatus.BackColor = Color.Lime;
                    btnCCDConnect.Enabled = false;
                }
                else
                {
                    lblCCDConnStatus.BackColor = Color.Maroon;
                    btnCCDConnect.Enabled = true;
                    btnCCDTrigger.Enabled = false;
                    //   btnCamDisConnect.Enabled = false;
                    btnCamDisConnect.Enabled = true;
                }
            }
            catch (Exception e)
            {
                Task.Run(() => Logger.WriteLog(Logger.LogType.Error, "Manual Screen", "", e.Message, e.ToString()));
            }
        }

        private void ChkScannerConStatus()
        {
            try
            {
                if (!ObjectList.Barcode_Scanner.CheckConnectStatus())
                {
                    if (ObjectList.Barcode_Scanner.Connect())
                    {
                        lblScanrConStatus.BackColor = Color.Lime;
                    }
                    else
                    {
                        lblScanrConStatus.BackColor = Color.Maroon;
                    }
                }
                else
                {
                    lblScanrConStatus.BackColor = Color.Lime;
                }
            }
            catch (Exception e)
            {
                Task.Run(() => Logger.WriteLog(Logger.LogType.Error, "Manual Screen", "", e.Message, e.ToString()));
            }
        }
        private void ChkSFCConStatus()
        {
            try
            {
                if (!ObjectList.SFC.CheckConnectStatus())
                {
                    if (ObjectList.SFC.Connect())
                    {
                        lblSFCConStatus.BackColor = Color.Lime;
                    }
                    else
                    {
                        lblSFCConStatus.BackColor = Color.Maroon;
                    }
                }
                else
                {
                    lblSFCConStatus.BackColor = Color.Lime;
                }
            }
            catch (Exception e)
            {
                Task.Run(() => Logger.WriteLog(Logger.LogType.Error, "Manual Screen", "", e.Message, e.ToString()));
            }
        }

        #region Robot Functions

        private void cmbRBTmodeselect_SelectedIndexChanged(object sender, EventArgs e)
        {
            int RoboSelectionMode;
            try
            {
                if (GlobalVariable.g_bMachineMode == GlobalVariable.OperationMode.DryRun)
                {
                    RoboSelectionMode = 1;
                }
                else
                {
                    RoboSelectionMode = 0;
                }
                if (cmbRBTmodeselect.SelectedIndex == 0)
                {
                    txtsendrobotcommand.Text = $"AUTO_MODE,1,0,Auto_mode_Selected,999.999,{RoboSelectionMode},999.999,999.999," +
                        $"999.999,999.999,{DateTime.Now.ToString("dd/MM/yyyy_HH:mm:ss:ffff")},IN,END";
                }
                else if (cmbRBTmodeselect.SelectedIndex == 1)
                {
                    txtsendrobotcommand.Text = $"MANUAL_MODE,1,0,Manual_mode_Selected,999.999,999.999,999.999,999.999," +
                        $"999.999,999.999,{DateTime.Now.ToString("dd/MM/yyyy_HH:mm:ss:ffff")},IN,END";
                }
                else if (cmbRBTmodeselect.SelectedIndex == 2)
                {
                    txtsendrobotcommand.Text = $"INITIALIZATION_MODE,1,0,Initialization_mode_Selected,1,999.999,999.999,999.999," +
                        $"999.999,999.999,{DateTime.Now.ToString("dd/MM/yyyy_HH:mm:ss:ffff")},IN,END";
                }
                else if (cmbRBTmodeselect.SelectedIndex == 3)
                {
                    txtsendrobotcommand.Text = $"CALIBRATION_MODE,1,0,Calibration_mode_Selected,999.999,999.999,999.999,999.999," +
                        $"999.999,999.999,{DateTime.Now.ToString("dd/MM/yyyy_HH:mm:ss:ffff")},IN,END";
                }
                else if (cmbRBTmodeselect.SelectedIndex == 4)
                {
                    txtsendrobotcommand.Text = $"RECIPE_MODE,1,0,Recipe_mode_Selected,999.999,999.999,999.999,999.999," +
                        $"999.999,999.999,{DateTime.Now.ToString("dd/MM/yyyy_HH:mm:ss:ffff")},IN,END";
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog(Logger.LogType.Error, "ManualScreen", "", ex.Message, ex.ToString());
            }
        }

        private void btnconnect_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    Robot.RbtResetProgram();

            //    if (!ObjectList.Robot.CheckConnectStatus())
            //    {
            //        if (ObjectList.Robot.Connect() && ObjectList.RobotSts.Connect() && ObjectList.RobotErr.Connect())
            //        {
            //            lblrobotconnstatus.BackColor = Color.Lime;
            //        }
            //        else
            //        {
            //            lblrobotconnstatus.BackColor = Color.Maroon;
            //        }
            //    }
            //    else
            //    {
            //        lblrobotconnstatus.BackColor = Color.Lime;
            //    }

            //}
            //catch (Exception ex)
            //{
            //    Logger.WriteLog(Logger.LogType.Error, "ManualScreen", "", ex.Message, ex.ToString());
            //}
        }

        private void btnRBTtrigger_Click(object sender, EventArgs e)
        {
            //try
            //{

            //    if (cmbRBTmodeselect.SelectedIndex == 2)
            //    {
            //        RoboResult = ObjectList.Robot.RobotSendandReceivesync(txtsendrobotcommand.Text, GlobalVariable.g_RobotretryCount);
            //    }
            //    else
            //    {
            //        RoboResult = ObjectList.Robot.RobotSendandReceivesync(txtsendrobotcommand.Text, GlobalVariable.g_RobotretryCount, false, true);

            //    }

            //    if (!string.IsNullOrEmpty(RoboResult))
            //    {
            //        if (RoboResult.ToLower() == "timeout")
            //        {
            //            GlobalVariable.AlarmTrigger(DIO.DIDO.ECode.Robot_Receive_TimeOut_Error, true, 1);
            //            return;
            //        }
            //        else if (RoboResult.ToLower() == "alarm")
            //        {
            //            GlobalVariable.AlarmTrigger(DIDO.ECode.Robot_Alarm_Error, true, 1);
            //            return;
            //        }
            //        //if (RoboResult.Split(',')[0].ToUpper() == cmbRBTmodeselect.SelectedValue.ToString().ToUpper())
            //        {
            //            txtreceivecommnd.Text = RoboResult;
            //        }
            //    }
            //}
            //catch (Exception ex)
            //{
            //    Logger.WriteLog(Logger.LogType.Error, "ManualScreen", "", ex.Message, ex.ToString());
            //}
        }

        private void btnDisConnect_Click(object sender, EventArgs e)
        {
            try
            {
                //ObjectList.Robot.Disconnect();
                //ObjectList.RobotSts.Disconnect();
                //ObjectList.RobotErr.Disconnect();
            }
            catch (Exception ex)
            {
                Logger.WriteLog(Logger.LogType.Error, "ManualScreen", "", ex.Message, ex.ToString());
            }
        }
        #endregion

        #region Vision Functions

        /// <summary>
        /// Connect CCD
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCCDConnect_Click(object sender, EventArgs e)
        {
            try
            {
                TCPObj = ObjectList.CCDObj[cmbCCD.SelectedIndex];

                //if (TCPObj.CheckConnectStatus())
                if (!TCPObj.IsConnected)
                {
                    if (TCPObj.Connect())
                    {
                        lblCCDConnStatus.BackColor = Color.Lime;
                    }
                    else
                    {
                        lblCCDConnStatus.BackColor = Color.Maroon;
                    }
                }
                else
                {
                    lblCCDConnStatus.BackColor = Color.Lime;
                }
                btnconnect.Enabled = true;
                btnCCDTrigger.Enabled = true;
                btnCamDisConnect.Enabled = true;


                //if (cmbCCD.SelectedItem != null)
                //{
                //    TCPObj = ObjectList.CCDObj[(int)((dynamic)cmbCCD.SelectedItem).Key];
                //}
                //else
                //{
                //    MessageBox.Show("can't connect !. selected item is empty");
                //    return;
                //}

                //if (TCPObj.CheckConnectStatus())
                //{
                //    if (TCPObj.Connect())
                //    {
                //        lblCCDConnStatus.BackColor = Color.Lime;
                //    }
                //    else
                //    {
                //        lblCCDConnStatus.BackColor = Color.Maroon;
                //    }
                //}
                //else
                //{
                //    lblCCDConnStatus.BackColor = Color.Lime;
                //}

            }
            catch (Exception ex)
            {
                Logger.WriteLog(Logger.LogType.Error, "ManualScreen", "", ex.Message, ex.ToString());
            }
        }

        /// <summary>
        /// Trigger CCD Commands
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void btnCCDTrigger_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtSendCmd.Text))
                {
                    txtRecivdCmd.Text = "";

                    if (TCPObj.Send(txtSendCmd.Text.Trim()))
                    {
                        await Task.Delay(1000);
                        string ScnrResult = TCPObj.Receive(600001);
                        txtRecivdCmd.Text = ScnrResult;
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog(Logger.LogType.Error, "ManualScreen", "", ex.Message, ex.ToString());
            }
        }

        private void btnCamDisConnect_Click(object sender, EventArgs e)
        {
            TCPObj.Disconnect();

            //===========Bug_Id_48 start
            btnCCDConnect.Enabled = true;
            btnCCDTrigger.Enabled = false;
            lblCCDConnStatus.BackColor = Color.Maroon;

            //===========Bug_Id_48 end

        }
        #endregion

        #region Scanner Functions

        /// <summary>
        /// Connect Scanner
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnScannerConnect_Click(object sender, EventArgs e)
        {
            try
            {
                //TCPObj = ObjectList.ScnrObj[cmbScanner.SelectedIndex];

                if (cmbScanner.SelectedItem != null)
                {
                    scanObj = ObjectList.ScnrObj[(int)((dynamic)cmbScanner.SelectedItem).Key];
                }
                else
                {
                    MessageBox.Show("can't connect !. selected item is empty");
                    return;
                }

                if (!scanObj.CheckConnectStatus())
                {
                    if (scanObj.Connect())
                    {
                        lblScanrConStatus.BackColor = Color.Lime;
                    }
                    else
                    {
                        lblScanrConStatus.BackColor = Color.Maroon;
                    }
                }
                else
                {
                    lblScanrConStatus.BackColor = Color.Lime;
                }

            }
            catch (Exception ex)
            {
                Logger.WriteLog(Logger.LogType.Error, "ManualScreen", "", ex.Message, ex.ToString());
            }
        }

        /// <summary>
        /// Trigger Scanner
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnScannerTrigger_Click(object sender, EventArgs e)
        {
            try
            {
                txtScannerRecieve.Text = "";

                if (scanObj.Send(txtScannerSend.Text.Trim()))
                {
                    string ScnrResult = scanObj.Receive(600001);
                    txtScannerRecieve.Text = ScnrResult;
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog(Logger.LogType.Error, "ManualScreen", "", ex.Message, ex.ToString());
            }
        }

        private void btnScnrDisconnect_Click(object sender, EventArgs e)
        {
            try
            {
                scanObj.Disconnect();
            }
            catch (Exception ex)
            {
                Logger.WriteLog(Logger.LogType.Error, "ManualScreen", "", ex.Message, ex.ToString());
            }
        }
        #endregion

        #region OPT Related Functions

        private void btnOPTConnect_Click(object sender, EventArgs e)
        {
            try
            {
                COMPortObj = ObjectList.COMObj[cmbCOMPort.SelectedIndex];

                if (COMPortObj != null && !COMPortObj.Connect_OPT())
                {
                    MessageBox.Show("opt Controller Connection Failed !", "OPT Connection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    lblOPTConStatus.BackColor = Color.Maroon;
                }
                lblOPTConStatus.BackColor = Color.Lime;
                btnOPTConnect.Enabled = false;

                //if (cmbCOMPort.SelectedItem != null)
                //{
                //    COMPortObj = ObjectList.COMObj[(int)((dynamic)cmbCOMPort.SelectedItem).Key];
                //}
                //else
                //{
                //    MessageBox.Show("can't connect !. selected item is empty");
                //    return;
                //}

                //if (COMPortObj != null && !COMPortObj.Connect_OPT())
                //{
                //    MessageBox.Show("OPT Controller Connection Failed !", "OPT Connection", MessageBoxButtons.OK,
                //        MessageBoxIcon.Warning);
                //}
            }
            catch (Exception ex)
            {
                Logger.WriteLog(Logger.LogType.Error, "ManualScreen", "", ex.Message, ex.ToString());
            }
        }

        private void btnOPTTrigger_Click(object sender, EventArgs e)
        {
            try
            {
                //COMPortObj = ObjectList.COMObj[cmbCOMPort.SelectedIndex];

                if (COMPortObj != null && COMPortObj.Write_OPT(cmbOPTSend.SelectedItem.ToString()))
                {
                    MessageBox.Show("opt Controller Send Failed !", "OPT Connection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                //if (COMPortObj != null && !COMPortObj.Write_OPT(cmbOPTSend.SelectedValue.ToString()))
                //{
                //    MessageBox.Show("OPT Controller Send Failed !", "OPT Connection", MessageBoxButtons.OK,
                //        MessageBoxIcon.Warning);
                //}
            }
            catch (Exception ex)
            {
                Logger.WriteLog(Logger.LogType.Error, "ManualScreen", "", ex.Message, ex.ToString());
            }
        }

        private void btnOPTDisconnect_Click(object sender, EventArgs e)
        {
            try
            {
                COMPortObj = ObjectList.COMObj[cmbCOMPort.SelectedIndex];

                if (COMPortObj != null && !COMPortObj.Disconnect_OPT())
                {
                    MessageBox.Show("OPT Controller Connection Failed !", "OPT Connection", MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                }
                lblOPTConStatus.BackColor = Color.Maroon;
                btnOPTConnect.Enabled = true;
            }
            catch (Exception ex)
            {
                Logger.WriteLog(Logger.LogType.Error, "ManualScreen", "", ex.Message, ex.ToString());
            }
        }

        private void cmbOPTSend_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        #endregion

        #region SFC & PDCA Functions

        private void btnSFCConnect_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ObjectList.SFC.CheckConnectStatus())
                {
                    if (ObjectList.SFC.Connect())
                    {
                        lblSFCConStatus.BackColor = Color.Lime;
                    }
                    else
                    {
                        lblSFCConStatus.BackColor = Color.Maroon;
                    }
                }
                else
                {
                    lblSFCConStatus.BackColor = Color.Lime;
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog(Logger.LogType.Error, "ManualScreen", "", ex.Message, ex.ToString());
            }
        }

        private void btnSFCTrigger_Click(object sender, EventArgs e)
        {
            try
            {
                Stopwatch sw = new Stopwatch();
                ObjectList.SFC.Send(rtSendSFC.Text.Trim());
                sw.Restart();
                string a;
                while (sw.ElapsedMilliseconds < 2000)
                {
                    a = ObjectList.SFC.Receive();
                    if (a != null)
                    {
                        rtReceiveSFC.Text = a;
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog(Logger.LogType.Error, "ManualScreen", "", ex.Message, ex.ToString());
            }
        }

        private async void btnPDCATrigger_Click(object sender, EventArgs e)
        {
            try
            {
                Stopwatch sw = new Stopwatch();

                sw.Restart();

                const int MAX_ALLOWED_SNS = 100; // Maximum allowed SNs

                string allSNs = rtSendSFC.Text.Trim();

                string Pdca_result;

                if (string.IsNullOrEmpty(allSNs))
                {
                    MessageBox.Show("Please enter MLB SN(s) in the text box.\n\nOne SN per line.\n\nExample:\nMLB123456789\nMLB987654321\nMLB111222333", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Split by line breaks to get individual SNs
                string[] snArray = allSNs.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.RemoveEmptyEntries);

                // Remove empty and whitespace entries
                snArray = snArray.Where(sn => !string.IsNullOrWhiteSpace(sn)).Select(sn => sn.Trim()).ToArray();

                if (snArray.Length == 0)
                {
                    MessageBox.Show("No valid MLB SNs found.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Check maximum limit
                if (snArray.Length > MAX_ALLOWED_SNS)
                {
                    MessageBox.Show($"Too many MLB SNs entered!\n\nMaximum allowed: {MAX_ALLOWED_SNS}\nYou entered: {snArray.Length}\n\nPlease reduce the number of SNs.",
                        "Limit Exceeded", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int totalCount = snArray.Length;
                int successCount = 0;
                int failCount = 0;
                StringBuilder resultLog = new StringBuilder();

                resultLog.AppendLine($"Processing {totalCount} MLB SN(s)...\n");

                Random rand = new Random();

                // Process each SN one by one
                for (int i = 0; i < snArray.Length; i++)
                {
                    sw.Restart();
                    string mlbSN = snArray[i].Trim();

                    try
                    {
                        // Validate MLB SN is not empty
                        if (string.IsNullOrEmpty(mlbSN))
                        {
                            failCount++;
                            resultLog.AppendLine($"✗ [{i + 1}/{totalCount}] Empty line - SKIPPED\n");
                            continue;
                        }

                        // Generate different random values for each SN
                        double randomGapX = GlobalVariable.X_LSL + rand.NextDouble() * (GlobalVariable.X_USL - GlobalVariable.X_LSL);
                        double randomGapY = GlobalVariable.Y_LSL + rand.NextDouble() * (GlobalVariable.Y_USL - GlobalVariable.Y_LSL);
                        double randomAngle = GlobalVariable.A_LSl + rand.NextDouble() * (GlobalVariable.A_USl - GlobalVariable.A_LSl);
                        double randomForce = GlobalVariable.F_LSl + rand.NextDouble() * (GlobalVariable.F_USl - GlobalVariable.F_LSl);
                        double randomCT = 10 + rand.NextDouble() * 5; // Random cycle time between 10-15 seconds

                        // Random cavity number between 1-12
                        int randomCavity = rand.Next(1, 13);

                        // Send PDCA data with MLB SN (Carrier_sn same as MLB SN)
                        await S_Pdca.Final_Data_Send_PDCA(
                            mlbSN,                              // Carrier_sn (same as MLB SN)
                            mlbSN,                              // barcode (MLB SN)
                            randomCavity.ToString(),            // cavity_no
                            randomGapX.ToString("F3"),          // left_gap
                            randomAngle.ToString("F3"),         // angle
                            randomCT.ToString("F2"),            // ct (cycle time)
                            randomGapY.ToString("F3"),          // bottom_gap
                            randomForce.ToString("F3")          // press_force
                        );

                        while (sw.ElapsedMilliseconds < 2000)
                        {
                            Pdca_result = ObjectList.SFC.Receive();
                            if (Pdca_result != null)
                            {
                                rtReceivePDCA.Text = Pdca_result;
                                break;
                            }
                        }

                        Pdca_result = ObjectList.SFC.Receive();
                        rtReceivePDCA.Text = Pdca_result;

                        successCount++;
                        resultLog.AppendLine($"✓ [{i + 1}/{totalCount}] {mlbSN} - SUCCESS");
                        resultLog.AppendLine($"   Cavity: {randomCavity}, GapX: {randomGapX:F3}, GapY: {randomGapY:F3}, Angle: {randomAngle:F3}, Force: {randomForce:F3}\n");

                        // Small delay between sends to avoid server overload
                        if (i < snArray.Length - 1)
                        {
                            await Task.Delay(500); // 500ms delay between each SN
                        }



                    }
                    catch (Exception ex)
                    {
                        failCount++;
                        resultLog.AppendLine($"✗ [{i + 1}/{totalCount}] {mlbSN} - FAILED");
                        resultLog.AppendLine($"   Error: {ex.Message}\n");
                        Logger.WriteLog(Logger.LogType.Error, "ManualScreen", "btnPDCATrigger_Click", $"Failed for SN: {mlbSN}", ex.ToString());
                    }
                }

                // Show final summary
                resultLog.AppendLine("─────────────────────────────────");
                resultLog.AppendLine($"SUMMARY:");
                resultLog.AppendLine($"Total: {totalCount} | Success: {successCount} | Failed: {failCount}");

                MessageBoxIcon icon = failCount == 0 ? MessageBoxIcon.Information : MessageBoxIcon.Warning;
                MessageBox.Show(resultLog.ToString(), "PDCA Batch Send Result", MessageBoxButtons.OK, icon);
            }
            catch (Exception ex)
            {
                Logger.WriteLog(Logger.LogType.Error, "ManualScreen", "btnPDCATrigger_Click", ex.Message, ex.ToString());
                MessageBox.Show($"Error processing PDCA batch: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);
            }
        }


        private void btnSFCDisConnect_Click(object sender, EventArgs e)
        {
            try
            {
                ObjectList.SFC.Disconnect();
            }
            catch (Exception ex)
            {
                Logger.WriteLog(Logger.LogType.Error, "ManualScreen", "", ex.Message, ex.ToString());
            }
        }

        #endregion




        #region CONVEYOR STEPPER 


        public void LoadConveyorMotor()
        {

            cmbConveyorStepperCombo.SelectedIndexChanged -= cmbConveyorStepperCombo_SelectedIndexChanged;

            var motorList = IO_Stepper_Config.ConvStepperMotorObj
    .Select(kv => new
    {
        Key = kv.Key,
        Motor = kv.Value,
        Name = kv.Value.MotorName,
    })
    .ToList();

            if (motorList != null && motorList.Count != 0)
            {
                cmbConveyorStepperCombo.DataSource = motorList;
                cmbConveyorStepperCombo.DisplayMember = "Name";
                cmbConveyorStepperCombo.ValueMember = "Key";

                cmbConveyorStepperCombo.SelectedIndex = 0; // select first item
                cmbConveyorStepperCombo_SelectedIndexChanged(cmbConveyorStepperCombo, EventArgs.Empty);
                cmbConveyorStepperCombo.SelectedIndexChanged += cmbConveyorStepperCombo_SelectedIndexChanged;
            }
        }

        private void cmbConveyorStepperCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateConvStepperStatus();
        }

        private void Conv_Forward_Click(object sender, EventArgs e)
        {
            var stepper = GetSelectedStepper();
            if (stepper != null)
            {
                bool success = stepper.Forward();
                if (!success)
                    MessageBox.Show("Forward failed!");
            }
        }

        private void Conv_Reverse_Click(object sender, EventArgs e)
        {
            var stepper = GetSelectedStepper();
            if (stepper != null)
            {
                bool success = stepper.Reverse();
                if (!success)
                    MessageBox.Show("Reverse failed!");
            }
        }

        private void Conv_Stop_Click(object sender, EventArgs e)
        {
            var stepper = GetSelectedStepper();
            if (stepper != null)
            {
                bool success = stepper.Stop();
                if (!success)
                    MessageBox.Show("Stop failed!");
            }
        }

        private void Conv_Reset_Click(object sender, EventArgs e)
        {
            var stepper = GetSelectedStepper();
            if (stepper != null)
            {
                bool success = stepper.AlarmReset();
                if (!success)
                    MessageBox.Show("Alarm reset failed!");
            }
        }

        private IO_Stepper.IO_Stepper GetSelectedStepper()
        {
            var selectedItem = cmbConveyorStepperCombo.SelectedItem;
            if (selectedItem != null)
            {
                // Your DataSource is an anonymous type: { Key, MotorName, Stepper }
                dynamic item = selectedItem;
                return item.Motor;
            }
            return null;
        }
        private void UpdateConvStepperStatus()
        {
            if(GlobalVariable.ConveyorIO =="No")
            {
                if (StepperAxisComb.SelectedItem is object selected)
                {
                    var stepper = ((dynamic)selected).Motor;

                    bool alarm = stepper.AlarmHappen;

                    Conv_Status.BackColor = alarm ? Color.Maroon : Color.Lime;
                    Conv_Status.ForeColor = Color.Black;
                    Conv_Status.Text = alarm ? "Alarm !" : "Ready";
                }
            }
            else
            {
                if (cmbConveyorStepperCombo.SelectedItem is object selected)
                {
                    var stepper = ((dynamic)selected).Motor;

                    bool alarm = stepper.AlarmHappen;

                    Conv_Status.BackColor = alarm ? Color.Maroon : Color.Lime;
                    Conv_Status.ForeColor = Color.Black;
                    Conv_Status.Text = alarm ? "Alarm !" : "Ready";
                }
            }
        }
        

        #endregion

        private void txtServoX_Targetposition_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox txt = sender as TextBox;
            GlobalVariable.ApplyTextBoxConfig(txt, "MCpositionLen", e, allowDecimal: true, allowMinus: true);
        }

        private void txtServoX_Targetspeed_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox txt = sender as TextBox;
            GlobalVariable.ApplyTextBoxConfig(txt, "MCSpeedLen", e, allowDecimal: false, allowMinus: false);
            if (txt.Text.Length == 0 && e.KeyChar == '0')
                e.Handled = true;
        }

        private void txtHome_Velocity_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox txt = sender as TextBox;
            GlobalVariable.ApplyTextBoxConfig(txt, "HCVelocityLen", e, allowDecimal: false, allowMinus: false);
            if (txt.Text.Length == 0 && e.KeyChar == '0')
                e.Handled = true;
        }

        private void txtJogSpeed_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox txt = sender as TextBox;
            GlobalVariable.ApplyTextBoxConfig(txt, "JCSpeedLenLen", e, allowDecimal: false, allowMinus: false);
            if (txt.Text.Length == 0 && e.KeyChar == '0')
                e.Handled = true;
        }

        private void txtPTP_Start_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox txt = sender as TextBox;
            GlobalVariable.ApplyTextBoxConfig(txt, "PPCStartPositionLen", e, allowDecimal: true, allowMinus: true);

        }

        private void txtPTP_End_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox txt = sender as TextBox;
            GlobalVariable.ApplyTextBoxConfig(txt, "PPCEndPositionLen", e, allowDecimal: true, allowMinus: true);
        }

        private void txtPTP_Speed_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox txt = sender as TextBox;
            GlobalVariable.ApplyTextBoxConfig(txt, "PPCSpeedLen", e, allowDecimal: false, allowMinus: false);
            if (txt.Text.Length == 0 && e.KeyChar == '0')
                e.Handled = true;


        }

        private void txtWait_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox txt = sender as TextBox;
            GlobalVariable.ApplyTextBoxConfig(txt, "PPCWaitLen", e, allowDecimal: false, allowMinus: false);
        }

        private void txtIteration_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox txt = sender as TextBox;
            GlobalVariable.ApplyTextBoxConfig(txt, "PPCIterationLen", e, allowDecimal: false, allowMinus: false);
        }

        private void txtSpeed_CrrCny1_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox txt = sender as TextBox;
            GlobalVariable.ApplyTextBoxConfig(txt, "CrrCynSpeedLen", e, allowDecimal: false, allowMinus: false);
        }

        private void cmbCCD_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbCCD.SelectedItem.ToString() == "CCD1")
            {
                // ObjectList.CCDObj[0].co
            }
        }


        //28_11_25
        //27_11_25
        private void txtServoX_Targetspeed_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && (e.KeyCode == Keys.C || e.KeyCode == Keys.V || e.KeyCode == Keys.X))
            {
                e.SuppressKeyPress = true;
            }
            //if ((e.KeyCode == Keys.D0 && !e.Shift) || e.KeyCode == Keys.NumPad0)
            //{
            //    e.SuppressKeyPress = true;
            //}
        }

        private void txtServoX_Targetspeed_MouseDown(object sender, MouseEventArgs e)
        {
            // Disable right-click context menu
            if (e.Button == MouseButtons.Right)
            {
                ((TextBox)sender).ContextMenu = new ContextMenu(); // Assign empty menu
                return;
            }
        }

        private void txtServoX_Targetspeed_MouseUp(object sender, MouseEventArgs e)
        {
            // Prevent paste via mouse right-click
            if (e.Button == MouseButtons.Right)
            {
                return;
            }
        }

        //27_11_25
        private void txtHome_Velocity_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && (e.KeyCode == Keys.C || e.KeyCode == Keys.V || e.KeyCode == Keys.X))
            {
                e.SuppressKeyPress = true;
            }
            //if ((e.KeyCode == Keys.D0 && !e.Shift) || e.KeyCode == Keys.NumPad0)
            //{
            //    e.SuppressKeyPress = true;
            //}
        }

        private void txtHome_Velocity_MouseUp(object sender, MouseEventArgs e)
        {
            // Prevent paste via mouse right-click
            if (e.Button == MouseButtons.Right)
            {
                return;
            }

        }

        private void txtHome_Velocity_MouseDown(object sender, MouseEventArgs e)
        {
            // Disable right-click context menu
            if (e.Button == MouseButtons.Right)
            {
                ((TextBox)sender).ContextMenu = new ContextMenu(); // Assign empty menu
                return;
            }
        }

        //27_11_25
        private void txtJogSpeed_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && (e.KeyCode == Keys.C || e.KeyCode == Keys.V || e.KeyCode == Keys.X))
            {
                e.SuppressKeyPress = true;
            }
            //if ((e.KeyCode == Keys.D0 && !e.Shift) || e.KeyCode == Keys.NumPad0)
            //{
            //    e.SuppressKeyPress = true;
            //}
        }

        private void txtJogSpeed_MouseUp(object sender, MouseEventArgs e)
        {
            // Prevent paste via mouse right-click
            if (e.Button == MouseButtons.Right)
            {
                return;
            }
        }

        private void txtJogSpeed_MouseDown(object sender, MouseEventArgs e)
        {
            // Disable right-click context menu
            if (e.Button == MouseButtons.Right)
            {
                ((TextBox)sender).ContextMenu = new ContextMenu(); // Assign empty menu
                return;
            }
        }

        //27_11_25
        private void txtPTP_Speed_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && (e.KeyCode == Keys.C || e.KeyCode == Keys.V || e.KeyCode == Keys.X))
            {
                e.SuppressKeyPress = true;
            }
            //if ((e.KeyCode == Keys.D0 && !e.Shift) || e.KeyCode == Keys.NumPad0)
            //{
            //    e.SuppressKeyPress = true;
            //}
        }

        private void txtPTP_Speed_MouseDown(object sender, MouseEventArgs e)
        {
            // Disable right-click context menu
            if (e.Button == MouseButtons.Right)
            {
                ((TextBox)sender).ContextMenu = new ContextMenu(); // Assign empty menu
                return;
            }
        }

        private void txtPTP_Speed_MouseUp(object sender, MouseEventArgs e)
        {
            // Prevent paste via mouse right-click
            if (e.Button == MouseButtons.Right)
            {
                return;
            }
        }

        //27_11_25
        private void txtServoX_Targetposition_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && (e.KeyCode == Keys.C || e.KeyCode == Keys.V || e.KeyCode == Keys.X))
            {
                e.SuppressKeyPress = true;
            }
            //if ((e.KeyCode == Keys.D0 && !e.Shift) || e.KeyCode == Keys.NumPad0)
            //{
            //    e.SuppressKeyPress = true;
            //}
        }

        private void txtServoX_Targetposition_MouseDown(object sender, MouseEventArgs e)
        {
            // Disable right-click context menu
            if (e.Button == MouseButtons.Right)
            {
                ((TextBox)sender).ContextMenu = new ContextMenu(); // Assign empty menu
                return;
            }
        }

        private void txtServoX_Targetposition_MouseUp(object sender, MouseEventArgs e)
        {
            // Prevent paste via mouse right-click
            if (e.Button == MouseButtons.Right)
            {
                return;
            }
        }


        //========= Bug_id_41 ========
        private void txtPTP_Start_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && (e.KeyCode == Keys.C || e.KeyCode == Keys.V || e.KeyCode == Keys.X))
            {
                e.SuppressKeyPress = true;
            }
        }

        private void txtPTP_Start_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                ((TextBox)sender).ContextMenu = new ContextMenu(); // Assign empty menu
                return;
            }
        }

        private void txtPTP_Start_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                return;
            }
        }

        //==== Bug_Id_41 ====
        private void txtPTP_End_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && (e.KeyCode == Keys.C || e.KeyCode == Keys.V || e.KeyCode == Keys.X))
            {
                e.SuppressKeyPress = true;
            }
        }

        private void txtPTP_End_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                ((TextBox)sender).ContextMenu = new ContextMenu(); // Assign empty menu
                return;
            }
        }

        private void txtPTP_End_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                return;
            }
        }


        //==== Bug_Id_41 ====
        private void txtWait_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && (e.KeyCode == Keys.C || e.KeyCode == Keys.V || e.KeyCode == Keys.X))
            {
                e.SuppressKeyPress = true;
            }
        }

        private void txtWait_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                ((TextBox)sender).ContextMenu = new ContextMenu(); // Assign empty menu
                return;
            }
        }

        private void txtWait_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                return;
            }
        }

        //==== Bug_Id_41 ====
        private void txtIteration_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && (e.KeyCode == Keys.C || e.KeyCode == Keys.V || e.KeyCode == Keys.X))
            {
                e.SuppressKeyPress = true;
            }
        }

        private void txtIteration_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                ((TextBox)sender).ContextMenu = new ContextMenu(); // Assign empty menu
                return;
            }
        }

        private void txtIteration_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                return;
            }
        }

        private void button36_Click(object sender, EventArgs e)
        {
            try
            {
                if (StepperAxis != null)
                {
                    StepperAxis.ServoOn(true);
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog(Logger.LogType.Error, "ManualScreen", "", ex.Message, ex.ToString());
            }
        }

        private void button38_Click(object sender, EventArgs e)
        {
            try
            {
                if (StepperAxis != null)
                {
                    StepperAxis.ServoOFF();
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog(Logger.LogType.Error, "ManualScreen", "", ex.Message, ex.ToString());
            }
        }

        private void label33_Click(object sender, EventArgs e)
        {

        }

        //private void button48_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        if (txtHome_Velocity_Stp.Text.Length == 0)
        //        {
        //            MessageBox.Show("Please Enter the Velocity for Homing ", "Homing", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //            return;
        //        }
        //        if (StepperAxis != null)
        //        {
        //            double speed = Convert.ToDouble(txtHome_Velocity_Stp.Text);

        //            Task.Run(() => StepperAxis.ManulHoming(1, speed));



        //            // GlobalVariable.AxisHomingStatus[axisindex] = true;
        //            EnableControls();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Logger.WriteLog(Logger.LogType.Error, "ManualScreen", "", ex.Message, ex.ToString());
        //    }
        //}

        private void button46_Click(object sender, EventArgs e)
        {
            try
            {
                if (StepperAxis != null)
                {
                    StepperAxis.Stop();
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog(Logger.LogType.Error, "ManualScreen", "", ex.Message, ex.ToString());
            }
        }

        private void button44_MouseUp(object sender, MouseEventArgs e)
        {

        }

        private void button37_Click(object sender, EventArgs e)
        {
            try
            {
                if (StepperAxis != null)
                {
                    StepperAxis.ResetAxis();
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog(Logger.LogType.Error, "ManualScreen", "", ex.Message, ex.ToString());
            }
        }



        //private void button50_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        if (StepperAxis != null)
        //        {
        //            StepperAxis.Stop();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Logger.WriteLog(Logger.LogType.Error, "ManualScreen", "", ex.Message, ex.ToString());
        //    }
        //}


        private void Froward_Cmd(object sender, EventArgs e)
        {
            Task.Run(() =>
            {
                try
                {
                    if (StepperAxis != null)
                    {
                        StepperAxis.Jog(0, Convert.ToDouble(stp_Text.Text), GlobalVariable.g_lstAxisConfig[stepperIndex].Acc, GlobalVariable.g_lstAxisConfig[stepperIndex].DeAcc);
                    }
                }
                catch (Exception ex)
                {
                    Logger.WriteLog(Logger.LogType.Error, "ManualScreen", "", ex.Message, ex.ToString());
                }
            });

        }

        private void BackWord_Cmd(object sender, EventArgs e)
        {
            Task.Run(() =>
            {
                try
                {
                    if (StepperAxis != null)
                    {
                        StepperAxis.Jog(1, Convert.ToDouble(stp_Text.Text), GlobalVariable.g_lstAxisConfig[stepperIndex].Acc, GlobalVariable.g_lstAxisConfig[stepperIndex].DeAcc);
                    }
                }
                catch (Exception ex)
                {
                    Logger.WriteLog(Logger.LogType.Error, "ManualScreen", "", ex.Message, ex.ToString());
                }
            });
        }

        private void Stop_Cmd(object sender, EventArgs e)
        {
            Task.Run(() =>
            {
                try
                {
                    if (StepperAxis != null)
                    {
                        StepperAxis.StopJog();
                    }
                }
                catch (Exception ex)
                {
                    Logger.WriteLog(Logger.LogType.Error, "ManualScreen", "", ex.Message, ex.ToString());
                }
            });
        }

        private void rtSendSFC_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.V)
            {
                e.SuppressKeyPress = true;
                string plaintext = Clipboard.GetText(TextDataFormat.Text);
                int selectionstart = rtSendSFC.SelectionStart;
                rtSendSFC.Text = rtSendSFC.Text.Insert(selectionstart, plaintext);
                rtSendSFC.SelectionStart = selectionstart + plaintext.Length;
            }
        }

    }
}
