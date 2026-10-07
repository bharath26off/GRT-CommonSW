using Advantech;
using DIO;
using ExceptionLib;
using Master;
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

    public class Robot
    {
        public enum InputFormat
        {
            /// <summary>
            /// Sequence number
            /// </summary>
            Seq_No,
            /// <summary>
            /// Start Bit
            /// </summary>
            Start_Bit,
            /// <summary>
            /// End Bit
            /// </summary>
            End_Bit,
            /// <summary>
            /// Camera Status
            /// </summary>
            Cam_Status,
            /// <summary>
            /// X value for Camera Input
            /// </summary>
            Cam_X,
            /// <summary>
            /// Y value for Camera Input
            /// </summary>
            Cam_Y,
            /// <summary>
            /// Angle value for Camera Input
            /// </summary>
            Cam_A,
            /// <summary>
            /// Data1
            /// </summary>
            Data1,
            /// <summary>
            /// Data 2
            /// </summary>
            Data2,
            /// <summary>
            /// Data3
            /// </summary>
            Data3,
            /// <summary>
            /// DateTime format dd/MM/yyyy_HH:mm:ss:ffff
            /// </summary>
            DateTime,
            /// <summary>
            /// Input Suffix String
            /// </summary>
            InputSuffix,
            /// <summary>
            /// End Status
            /// </summary>
            EndSts
        }

        public enum OutputFormat
        {
            /// <summary>
            /// Sequence number
            /// </summary>
            Seq_No,
            /// <summary>
            /// Start Bit
            /// </summary>
            Start_Bit,
            /// <summary>
            /// End Bit
            /// </summary>
            End_Bit,
            /// <summary>
            /// Camera Status
            /// </summary>
            Cam_Status,
            /// <summary>
            /// Robot X-Axis Value
            /// </summary>
            Rbt_X,
            /// <summary>
            /// Robot Y-Axis Value
            /// </summary>
            Rbt_Y,
            /// <summary>
            /// Robot Angle
            /// </summary>
            Rbt_Z,
            /// <summary>
            /// U Co-ordinate
            /// </summary>
            Rbt_U,
            /// <summary>
            /// V Co-ordinate
            /// </summary>
            Rbt_V,
            /// <summary>
            /// W Co-ordinate
            /// </summary>
            Rbt_W,
            /// <summary>
            /// DateTime format dd/MM/yyyy_HH:mm:ss:ffff
            /// </summary>
            DateTime,
            /// <summary>
            /// Output Suffix String
            /// </summary>
            OutputSuffix,
            /// <summary>
            /// End Status
            /// </summary>
            EndSts
        }

        /// <summary>
        /// Reset Robot Program to start SEQ from first
        /// </summary>
        /// <returns></returns>
        public static bool RbtResetProgram()
        {
            try
            {
                //if (GlobalVariable.DI[(int)DIDO.EInput.RBT_Alm_Sigl])
                //{
                //    GlobalVariable.DIDO.WriteOPS(true, (int)DIDO.EOutput.RBT_Alm_Rst_Signl);
                //}
                Thread.Sleep(500);
                //GlobalVariable.DIDO.WriteOPS(false, (int)DIDO.EOutput.RBT_Alm_Rst_Signl);
                //GlobalVariable.DIDO.WriteOPS(true, (int)DIDO.EOutput.RBT_Opr_Right_Signl);
                //GlobalVariable.DIDO.WriteOPS(false, (int)DIDO.EOutput.RBT_Strt_Signl);
                //GlobalVariable.DIDO.WriteOPS(true, (int)DIDO.EOutput.RBT_EMG_Stp_Signl);
                Thread.Sleep(500);
                //GlobalVariable.DIDO.WriteOPS(false, (int)DIDO.EOutput.RBT_EMG_Stp_Signl);
                Thread.Sleep(500);
                //GlobalVariable.DIDO.WriteOPS(true, (int)DIDO.EOutput.RBT_Rst_Signl);
                Thread.Sleep(500);
                //GlobalVariable.DIDO.WriteOPS(false, (int)DIDO.EOutput.RBT_Rst_Signl);
                Thread.Sleep(500);
                //GlobalVariable.DIDO.WriteOPS(true, (int)DIDO.EOutput.RBT_Strt_Signl);

                return true;
            }
            catch(Exception ex)
            {
                Logger.WriteLog(Logger.LogType.Error, "Robot", "", ex.Message, ex.ToString());
                return false;
            }
        }

        /// <summary>
        /// Robot Stop Program
        /// </summary>
        /// <returns></returns>
        public static bool RbtPauseProgram()
        {
            try
            {
                //GlobalVariable.DIDO.WriteOPS(true, (int)DIDO.EOutput.RBT_Opr_Right_Signl);
                //GlobalVariable.DIDO.WriteOPS(false, (int)DIDO.EOutput.RBT_Strt_Signl);
                //GlobalVariable.DIDO.WriteOPS(true, (int)DIDO.EOutput.RBT_EMG_Stp_Signl);
                //GlobalVariable.DIDO.WriteOPS(false, (int)DIDO.EOutput.RBT_Rst_Signl);
                return true;
            }
            catch (Exception ex)
            {
                Logger.WriteLog(Logger.LogType.Error, "Robot", "", ex.Message, ex.ToString());
                return false;
            }
        }

        /// <summary>
        /// Function to Start Robot
        /// </summary>
        /// <returns></returns>
        public static bool RbtStrtProgram()
        {
            try
            {
                //GlobalVariable.DIDO.WriteOPS(true, (int)DIDO.EOutput.RBT_Opr_Right_Signl);
                //GlobalVariable.DIDO.WriteOPS(false, (int)DIDO.EOutput.RBT_EMG_Stp_Signl);
                //GlobalVariable.DIDO.WriteOPS(false, (int)DIDO.EOutput.RBT_Rst_Signl);
                //GlobalVariable.DIDO.WriteOPS(true, (int)DIDO.EOutput.RBT_Strt_Signl);
                return true;
            }
            catch (Exception ex)
            {
                Logger.WriteLog(Logger.LogType.Error, "Robot", "", ex.Message, ex.ToString());
                return false;
            }
        }

        /// <summary>
        /// Used for Homing Robot
        /// </summary>
        /// <returns></returns>
        public static bool RobotHoming()
        {
            string _RobotCmd = string.Empty;
            string _RobotResult = string.Empty;

            try
            {
                //if (GlobalVariable.DI[(int)DIDO.EInput.GPO14_Rbt_In_Teach_Mode])
                //{
                //    Application.OpenForms[0].Invoke((MethodInvoker)delegate
                //    {
                //        MessageBox.Show("Check Robot is in Teach Mode.....", "Robot Connection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //    });
                //    GlobalVariable.AlarmTrigger(DIDO.ECode.Robot_Mode_Error, true, 1);
                //    return false;
                //}
                //_RobotCmd = $"INITIALIZATION_MODE,1,0,Initialization_mode_Selected,1,999.999,999.999,999.999," +
                //                        $"999.999,999.999,{DateTime.Now.ToString("dd/MM/yyyy_HH:mm:ss:ffff")},IN,END";

                ////_RobotResult = ObjectList.Robot.RobotSendandReceiveAsync(_RobotCmd, GlobalVariable.g_RobotretryCount).GetAwaiter().GetResult();
                //_RobotResult = ObjectList.Robot.RobotSendandReceivesync(_RobotCmd, GlobalVariable.g_RobotretryCount);

                //if (TCPCommon.ChkTCPError(_RobotResult) && _RobotResult.Split(',')[(int)Robot.OutputFormat.Start_Bit] == "0" &&
                //    _RobotResult.Split(',')[(int)Robot.OutputFormat.End_Bit] == "1" &&
                //    _RobotResult.Split(',')[(int)Robot.OutputFormat.Seq_No] == "INITIALIZATION_MODE")
                //{
                //    GlobalVariable.g_RobotResult = "1";
                //    GlobalVariable.LogSequence("Robot", "", "INITIALIZATION", "INITIALIZATION Completed");
                //}
                //else
                //{
                //    GlobalVariable.g_RobotResult = "0";
                //    GlobalVariable.LogSequence("Robot", "", "INITIALIZATION", "INITIALIZATION failed");
                //}

                return true;
            }
            catch (Exception ex)
            {
                Logger.WriteLog(Logger.LogType.Error, "Robot", "", ex.Message, ex.ToString());
                return false;
            }
        }

        /// <summary>
        /// Used to Set Auto Mode
        /// </summary>
        /// <returns></returns>
        public static bool RobotAutoMode()
        {
            string _RobotCmd = string.Empty;
            string _RobotResult = string.Empty;
            int RoboSelectionMode;
            try
            {
                //if (GlobalVariable.DI[(int)DIDO.EInput.GPO14_Rbt_In_Teach_Mode])
                //{
                //    Application.OpenForms[0].Invoke((MethodInvoker)delegate
                //    {
                //        MessageBox.Show("Check Robot is in Teach Mode.....", "Robot Connection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //    });
                //    GlobalVariable.AlarmTrigger(DIDO.ECode.Robot_Mode_Error, true, 1);
                //    return false;
                //}

                //if(GlobalVariable.g_bMachineMode == GlobalVariable.OperationMode.DryRun)
                //{
                //    RoboSelectionMode = 1;
                //}
                //else
                //{
                //    RoboSelectionMode = 0;
                //}

                //_RobotCmd = $"AUTO_MODE,1,0,Auto_mode_Selected,999.999,{RoboSelectionMode},999.999,999.999," +
                //        $"999.999,999.999,{DateTime.Now.ToString("dd/MM/yyyy_HH:mm:ss:ffff")},IN,END";

                ////_RobotResult = ObjectList.Robot.RobotSendandReceiveAsync(_RobotCmd, GlobalVariable.g_RobotretryCount).GetAwaiter().GetResult();
                //_RobotResult = ObjectList.Robot.RobotSendandReceivesync(_RobotCmd, GlobalVariable.g_RobotretryCount, false, true);

                //if (TCPCommon.ChkTCPError(_RobotResult) && _RobotResult.Split(',')[(int)Robot.OutputFormat.Seq_No] == "AUTO_MODE")
                //{
                //    GlobalVariable.LogSequence("Robot", "", "AUTOMODE", "AUTOMODE Completed");
                //}
                //else
                //{
                //    GlobalVariable.LogSequence("Robot", "", "AUTOMODE", "AUTOMODE failed");
                //}

                return true;
            }
            catch (Exception ex)
            {
                Logger.WriteLog(Logger.LogType.Error, "Robot", "", ex.Message, ex.ToString());
                return false;
            }
        }

        /// <summary>
        /// Used to Set Calibration Mode
        /// </summary>
        /// <returns></returns>
        public static bool RobotCalibMode()
        {
            string _RobotCmd = string.Empty;
            string _RobotResult = string.Empty;
            try
            {
                //if (GlobalVariable.DI[(int)DIDO.EInput.GPO14_Rbt_In_Teach_Mode])
                //{
                //    Application.OpenForms[0].Invoke((MethodInvoker)delegate
                //    {
                //        MessageBox.Show("Check Robot is in Teach Mode.....", "Robot Connection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //    });
                //    GlobalVariable.AlarmTrigger(DIDO.ECode.Robot_Mode_Error, true, 1);
                //    return false;
                //}

                //_RobotCmd = $"CALIBRATION_MODE,1,0,Calibration_mode_Selected,999.999,999.999,999.999,999.999," +
                //        $"999.999,999.999,{DateTime.Now.ToString("dd/MM/yyyy_HH:mm:ss:ffff")},IN,END";

                ////_RobotResult = ObjectList.Robot.RobotSendandReceiveAsync(_RobotCmd, GlobalVariable.g_RobotretryCount).GetAwaiter().GetResult();
                //_RobotResult = ObjectList.Robot.RobotSendandReceivesync(_RobotCmd, GlobalVariable.g_RobotretryCount, false, true);

                //if (TCPCommon.ChkTCPError(_RobotResult) && _RobotResult.Split(',')[(int)Robot.OutputFormat.Seq_No] == "CALIBRATION_MODE")
                //{
                //    GlobalVariable.LogSequence("Robot", "", "CALIBMODE", "Calibration Mode Completed");
                //}
                //else
                //{
                //    GlobalVariable.LogSequence("Robot", "", "CALIBMODE", "Calibration Mode failed");
                //}

                return true;
            }
            catch (Exception ex)
            {
                Logger.WriteLog(Logger.LogType.Error, "Robot", "", ex.Message, ex.ToString());
                return false;
            }
        }

        /// <summary>
        /// Used to set Speed, PickDelay & PlaceDelay for Robot
        /// </summary>
        /// <returns></returns>
        public static bool RobotReceipeMode()
        {
            string _RobotCmd = string.Empty;
            string _RobotResult = string.Empty;
            string _RobotErr = string.Empty;
            try
            {
                //if (GlobalVariable.DI[(int)DIDO.EInput.GPO14_Rbt_In_Teach_Mode])
                //{
                //    Application.OpenForms[0].Invoke((MethodInvoker)delegate
                //    {
                //        MessageBox.Show("Check Robot is in Teach Mode.....", "Robot Connection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //    });
                //    GlobalVariable.AlarmTrigger(DIDO.ECode.Robot_Mode_Error, true, 1);
                //    return false;
                //}

                //_RobotCmd = $"RECIPE_MODE,1,0,Recipe_mode_Selected,999.999,999.999,999.999,999.999," +
                //        $"999.999,999.999,{DateTime.Now.ToString("dd/MM/yyyy_HH:mm:ss:ffff")},IN,END";
                ////_RobotCmd = $"RECIPE_MODE,1,0,Recipe_mode_Selected,{GlobalVariable.Recipe_RoboSpeed}," +
                ////    $"{GlobalVariable.Recipe_RoboPickDelay},{GlobalVariable.Recipe_RoboplaceDelay},999.999," +
                ////        $"999.999,999.999,{DateTime.Now.ToString("dd/MM/yyyy_HH:mm:ss:ffff")},IN,END";

                ////_RobotResult = ObjectList.Robot.RobotSendandReceiveAsync(_RobotCmd, GlobalVariable.g_RobotretryCount).GetAwaiter().GetResult();
                //_RobotResult = ObjectList.Robot.RobotSendandReceivesync(_RobotCmd, GlobalVariable.g_RobotretryCount, false, true);
                //_RobotErr = ObjectList.RobotErr.Receive(600001);

                //_RobotCmd = $"{GlobalVariable.Recipe_RoboSpeed},1,1,999.999,999.999,999.999,999.999,999.999," +
                //        $"{DateTime.Now.ToString("dd/MM/yyyy_HH:mm:ss:ffff")},IN,END";
                ////_RobotCmd = $"{GlobalVariable.Recipe_RoboSpeed}," +
                ////    $"{GlobalVariable.Recipe_RoboPickDelay},{GlobalVariable.Recipe_RoboplaceDelay},999.999," +
                ////        $"999.999,999.999,{DateTime.Now.ToString("dd/MM/yyyy_HH:mm:ss:ffff")},IN,END";

                //_RobotResult = ObjectList.Robot.RobotSendandReceivesync(_RobotCmd, GlobalVariable.g_RobotretryCount);
                //_RobotErr = ObjectList.RobotErr.Receive(600001);

                //if (TCPCommon.ChkTCPError(_RobotResult) && _RobotResult.Split(',')[(int)Robot.OutputFormat.Seq_No] == "RECIPE_MODE")
                //{
                //    GlobalVariable.LogSequence("Robot", "", "RECIPEMODE", "Recipe Mode Completed");
                //}
                //else
                //{
                //    GlobalVariable.LogSequence("Robot", "", "RECIPEMODE", "Recipe Mode failed");
                //}

                return true;
            }
            catch (Exception ex)
            {
                Logger.WriteLog(Logger.LogType.Error, "Robot", "", ex.Message, ex.ToString());
                return false;
            }
        }

        /// <summary>
        /// Rejection Method for Robot
        /// </summary>
        /// <returns></returns>
        public static bool RobotTossingSeq()
        {
            string _RobotCmd = string.Empty;
            string _RobotResult = string.Empty;
            string _RobotErr = string.Empty;
            try
            {
                //_RobotCmd = $"SEQ_TOSS,1,0,NA,999.999,999.999,999.999,999.999,999.999,999.999," +
                //                    "$\"{DateTime.Now.ToString(\"dd/MM/yyyy_HH:mm:ss:ffff\")},IN,END";
                
                ////_RobotResult = ObjectList.Robot.RobotSendandReceiveAsync(_RobotCmd, GlobalVariable.g_RobotretryCount).GetAwaiter().GetResult();
                //_RobotResult = ObjectList.Robot.RobotSendandReceivesync(_RobotCmd, GlobalVariable.g_RobotretryCount);
                //_RobotErr = ObjectList.RobotErr.Receive(600001);

                //if (TCPCommon.ChkTCPError(_RobotResult) && _RobotResult.Split(',')[(int)Robot.OutputFormat.Start_Bit] == "0" &&
                //    _RobotResult.Split(',')[(int)Robot.OutputFormat.End_Bit] == "1" &&
                //    _RobotResult.Split(',')[(int)Robot.OutputFormat.Seq_No] == "SEQ_TOSS")
                //{
                //    GlobalVariable.g_RobotResult = "1";
                //    GlobalVariable.LogSequence("Robot", "", "Tossing Seq", "Tossing Sequence Completed");
                //}
                //else
                //{
                //    GlobalVariable.g_RobotResult = "0";
                //    GlobalVariable.LogSequence("Robot", "", "Tossing Seq", "Tossing Sequence failed");
                //}

                return true;
            }
            catch (Exception ex)
            {
                Logger.WriteLog(Logger.LogType.Error, "Robot", "", ex.Message, ex.ToString());
                return false;
            }
        }
    }