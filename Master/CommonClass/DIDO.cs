using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Advantech;
using CardDLL;
using ExceptionLib;
using HCCard;
using MasterProject.GlobalClass;
using Program;


namespace DIO
{
    //Class created for whole Digital Input and Output module
    public class DIDO
    {               
        public static List<IInput> g_lstInput = new List<IInput>();
        public static List<IOutput> g_lstOutput = new List<IOutput>();

        public static List<HCAxis> g_lstAXIS = new List<HCAxis>();
        public static List<IAxis> g_lstIAxis = new List<IAxis>();

        

        

        /// <summary>
        /// Structure for the Input/Output Parameter
        /// </summary>
        public struct IOParam
        {
            public short iCardNo;
            public short iExCardNo;
            public short iBitNo;
            public string sBitName;
            public string sComment;
        }

        /// <summary>
        /// Structure for the Axis Parameter
        /// </summary>
        public struct AxisParam
        {
            public string sCardType;
            public short iCardNo;
            public short iAxisNo;
            public string sAxisName;
            public double PPR;
            public double pitch;
            public double pulse_mm;
            public double Acc; 
            public double DeAcc; 
            public double AutoSpeed; 
            public double ManualSpeed; 
            public double HomingSpeed; 
        }

        /// <summary>
        /// Enum Variable for Axis parameters
        /// </summary>
        public enum EAxis
        {
            Start = -1
         , X1
         , Y1
         , X2
         , Y2
         , Z2
         , X3
         , Y3
         , R1
         , R2
         , TotalAxis
        }

        #region Machine Specific Input's & Output's

        /// <summary>
        /// Enum Variable for the machine Input's
        /// </summary>
        public enum EInput
        {
            Start = -1,
            Spare_X0_00,
            Main_Air_Pressure_Fb,
            E_Stop_Button_Sfty_Fb,
            Spare_X0_03,
            Door_Switch_Sfty_Fb,
            Str_PB,
            Stop_PB,
            Reset_PB,
            Scan_Conv_Pallet_Inplace_Sen,
            Scan_Conv_Pallet_Exit_Sen,
            Scan_Conv_Stopper_Cyl_Up,
            Scan_Conv_Stopper_Cyl_Dn,
            Scan_Conv_Mtr_A_Alm_Sig,
            Scan_Conv_Mtr_B_Alm_Sig,
            Rej_Bin_Inplace_Sen,
            Rej_Bin_High_Level_Sen,
            Feed_Bed_Vacuum_1_Fb,
            Feed_Bed_Vacuum_2_Fb,
            Work_Conv_1_Pallet_Entry_Sen,
            Work_Conv_1_Pallet_Inplace_Sen,
            Work_Conv_1_Pallet_Lift_Cyl_Up,
            Work_Conv_1_Pallet_Lift_Cyl_Dn,
            Work_Conv_1_Stopper_Cyl_Up,
            Work_Conv_1_Stopper_Cyl_Dn,
            Work_Conv_1_Pallet_Exit_Sen,
            Work_Conv_1_Mtr_A_Alm_Sig,
            Work_Conv_1_Mtr_B_Alm_Sig,
            Work_Conv_2_Pallet_Entry_Sen,
            Work_Conv_2_Pallet_Inplace_Sen,
            Work_Conv_2_Pallet_Lift_Cyl_Up,
            Work_Conv_2_Pallet_Lift_Cyl_Dn,
            Work_Conv_2_Stopper_Cyl_Up,
            Work_Conv_2_Stopper_Cyl_Dn,
            Work_Conv_2_Pallet_Exit_Sen,
            Work_Conv_2_Mtr_A_Alm_Sig,
            Work_Conv_2_Mtr_B_Alm_Sig,
            Previous_M_C_Ready_To_Send_Pallet,
            GBP_Ready_To_Receive_Pallet,
            Feed_Film_Clmp_Cyl_Up,
            Feed_Film_Clmp_Cyl_Dn,
            Graphite_Inp_Detect_Sen_1,
            Graphite_Inp_Detect_Sen_2,
            Graphite_Inp_Detect_Sen_3,
            Graphite_Inp_Detect_Sen_4,
            Feed_Mtr_Alm_Sig,
            Spare_X2_13,
            Spare_X2_14,
            Spare_X2_15

            , End
        }

        /// <summary>
        /// Enum Variable for the machine Output's
        /// </summary>
        public enum EOutput
        {
            Start = -1,
            Scan_Conv_Mtr_A_Fwd_Dir,
            Scan_Conv_Mtr_A_Rev_Dir,
            Scan_Conv_Mtr_A_Alm_reset,
            Scan_Conv_Mtr_B_Fwd_Dir,
            Scan_Conv_Mtr_B_Rev_Dir,
            Scan_Conv_Mtr_B_Alm_reset,
            Work_Conv_1_Mtr_A_Fwd_Dir,
            Work_Conv_1_Mtr_A_Rev_Dir,
            Work_Conv_1_Mtr_A_Alm_reset,
            Work_Conv_1_Mtr_B_Fwd_Dir,
            Work_Conv_1_Mtr_B_Rev_Dir,
            Work_Conv_1_Mtr_B_Alm_reset,
            Spare_Y0_12,
            Spare_Y0_13,
            Spare_Y0_14,
            Spare_Y0_15,
            Work_Conv_2_Mtr_A_Fwd_Dir,
            Work_Conv_2_Mtr_A_Rev_Dir,
            Work_Conv_2_Mtr_A_Alm_reset,
            Work_Conv_2_Mtr_B_Fwd_Dir,
            Work_Conv_2_Mtr_B_Rev_Dir,
            Work_Conv_2_Mtr_B_Alm_reset,
            M_C_Lamp_On_Sig,
            Safety_Bypass_On_Sig,
            Main_on_off_valve,
            Spare_Y1_09,
            Spare_Y1_10,
            Spare_Y1_11,
            Spare_Y1_12,
            Spare_Y1_13,
            Spare_Y1_14,
            Spare_Y1_15,
            Str_PB,
            Stop_PB,
            Reset_PB,
            Tower_Lamp_Green,
            Tower_Lamp_Yellow,
            Tower_Lamp_Red,
            Tower_Lamp_Buzzer,
            Feed_Mtr_Fwd_Dir,
            Feed_Mtr_Rev_Dir,
            Feed_Mtr_Alm_reset,
            Pick__Place_Z1_Axis_Vaccuum_Fb,
            Pick__Place_Z2_Axis_Vaccuum_Fb,
            GRT_Ready_To_Receive_Pallet,
            GRT_Ready_To_Send_Pallet,
            Spare_Y2_14,
            Spare_Y2_15,
            Scan_Conv_Stopper_Cyl_Up,
            Scan_Conv_Stopper_Cyl_Dn,
            Work_Conv_1_pallet_Lift_Cyl_Up,
            Work_Conv_1_pallet_Lift_Cyl_Dn,
            Work_Conv_1_Stopper_Cyl_Up,
            Work_Conv_1_Stopper_Cyl_Dn,
            Work_Conv_2_pallet_Lift_Cyl_Up,
            Work_Conv_2_pallet_Lift_Cyl_Dn,
            Work_Conv_2_Stopper_Cyl_Up,
            Work_Conv_2_Stopper_Cyl_Dn,
            Feed_Film_Clmp_Cyl_Up,
            Feed_Film_Clmp_Cyl_Dn,
            Spare_Y100_12,
            Spare_Y100_13,
            Spare_Y100_14,
            Spare_Y100_15,
            Spare_Y100_16,
            Spare_Y100_17,
            Spare_Y100_18,
            Spare_Y100_19,
            Spare_Y100_20,
            Spare_Y100_21,
            Spare_Y100_22,
            Spare_Y100_23,
            Spare_Y100_24,
            Spare_Y100_25,
            Spare_Y100_26,
            Spare_Y100_27,
            Spare_Y100_28,
            Spare_Y100_29,
            Spare_Y100_30,
            Spare_Y100_31,
            Feed_Bed_Vacuum_1_On,
            Feed_Bed_Vacuum_1_Break,
            Feed_Bed_Vacuum_2_On,
            Feed_Bed_Vacuum_2_Break,
            Spare_Y101_4,
            Spare_Y101_5,
            Spare_Y101_6,
            Spare_Y101_7,
            Spare_Y101_8,
            Spare_Y101_9,
            Spare_Y101_10,
            Spare_Y101_11,
            Spare_Y101_12,
            Spare_Y101_13,
            Spare_Y101_14,
            Spare_Y101_15,
            Spare_Y101_16,
            Spare_Y101_17,
            Spare_Y101_18,
            Spare_Y101_19,
            Spare_Y101_20,
            Spare_Y101_21,
            Spare_Y101_22,
            Spare_Y101_23,
            Spare_Y101_24,
            Spare_Y101_25,
            Spare_Y101_26,
            Spare_Y101_27,
            Spare_Y101_28,
            Spare_Y101_29,
            Spare_Y101_30,
            Spare_Y101_31


           , End
        }
        /// <summary>
        /// Enum Variable for the machine ErrorCode
        /// </summary>
        public enum ECode
        {
            Start = -1,
            Emg_Pressed_Error,
            SafetyDoor_open_Error,
            MainAir_FB_Error,
            X1_Move_cmd_Error,
            Y1_Move_cmd_Error,
            Z1_Move_cmd_Error,
            R1_Move_cmd_Error,
            T1_Move_cmd_Error,
            LhHSG_Move_cmd_Error,
            RhHSG_Move_cmd_Error,
            RhLoad_Move_cmd_Error,
            RhUnLoad_Move_cmd_Error,
            LhLoad_Move_cmd_Error,
            LhUnLoad_Move_cmd_Error,
            Homing_TimeOut_Error,
            Stopper1Cyl_Up_Timeout_Error,
            Stopper1Cyl_Dn_Timeout_Error,
            Stopper2Cyl_Up_Timeout_Error,
            Stopper2Cyl_Dn_Timeout_Error,
            Stopper3Cyl_Up_Timeout_Error,
            Stopper3Cyl_Dn_Timeout_Error,
            Stopper4Cyl_Up_Timeout_Error,
            Stopper4Cyl_Dn_Timeout_Error,
            Stopper5Cyl_Up_Timeout_Error,
            Stopper5Cyl_Dn_Timeout_Error,
            Locking1Cyl_Up_Timeout_Error,
            Locking1Cyl_Dn_Timeout_Error,
            Locking2Cyl_Up_Timeout_Error,
            Locking2Cyl_Dn_Timeout_Error,
            Locking3Cyl_Up_Timeout_Error,
            Locking3Cyl_Dn_Timeout_Error,
            Locking4Cyl_Up_Timeout_Error,
            Locking4Cyl_Dn_Timeout_Error,
            ScanCyl_Up_Timeout_Error,
            ScanCyl_Dn_Timeout_Error,
            X1_axis_movement_failed,
            Y1_axis_movement_failed,
            Z1_axis_movement_failed,
            R1_axis_movement_failed,
            T1_axis_movement_failed,
            LhHSG_axis_movement_failed,
            RhHSG_axis_movement_failed,
            RhLoad_axis_movement_failed,
            LhLoad_axis_movement_failed,
            RhUnLoad_axis_movement_failed,
            LhUnLoad_axis_movement_failed,
            X1_Positive_limit_Reached_Error,
            X1_Negative_limit_Reached_Error,
            Y1_Positive_limit_Reached_Error,
            Y1_Negative_limit_Reached_Error,
            Z1_Positive_limit_Reached_Error,
            Z1_Negative_limit_Reached_Error,
            X1_Maximum_MM_Reached_Error,
            X1_Minimum_MM_Reached_Error,
            Y1_Maximum_MM_Reached_Error,
            Y1_Minimum_MM_Reached_Error,
            Z1_Maximum_MM_Reached_Error,
            Z1_Minimum_MM_Reached_Error,
            R1_Maximum_deg_Reached_Error,
            R1_Minimum_deg_Reached_Error,
            ProgramException_Error,
            Motion_Time_out_Error,
            Loadcell1_range_excided,
            Loadcell2_range_excided,
            Loadcell3_range_excided,
            Feeder_Error,
            X1_Drive_Error,
            Y1_Drive_Error,
            Z1_Drive_Error,
            R1_Drive_Error,
            X_Homing_cmd_Error,
            Y_Homing_cmd_Error,
            Z_Homing_cmd_Error,
            R_Homing_cmd_Error,
            Z1_Homing_cmd_Error,
            Z2_Homing_cmd_Error,
            Z3_Homing_cmd_Error,
            Z4_Homing_cmd_Error,
            X_Servo_On_cmd_Error,
            Y_Servo_On_cmd_Error,
            Z_Servo_On_cmd_Error,
            R_Servo_On_cmd_Error,
            Z1_Servo_On_cmd_Error,
            Z2_Servo_On_cmd_Error,
            Z3_Servo_On_cmd_Error,
            Z4_Servo_On_cmd_Error,
            N1_PressForce_TooLarge,
            N1_PressForce_Reached_MaxLit,
            N1_PressForce_Reached_MinLit,
            CCD3camera_imagestorage_Command_returns_timeout,
            CCD2_camera_did_not_return_data_after_sending_the_vehicle_positioning_command,
            CCD1_camera_does_not_return_data_after_sending_nozzle_positioning_command,
            Trns_Fixture_locking_pressure_Reach_Max,
            Trns_Fixture_locking_pressure_Reach_Min,
            Trns_Fixture_Placing_pressure_Reach_Max,
            Trns_Fixture_Placing_pressure_Reach_Min,
            Trns_Fixture_loading_Errror,
            Trns_Fixture_Gantry_Position_cylinder_Time_out_Error,
            Trns_Fixture_Robot_Position_cylinder_Time_out_Error,
            CCD2_camera_does_not_return_data_after_sending_Cam2Locate_Button_Bore_command,
            CCD3_camera_does_not_return_data_after_sending_check_flex_tilt_angle_command,
            CCD4_camera_does_not_return_data_after_sending_Cam4_Locate_flextip_command,
            Tray_Input_Timeout_Error,
            PDCA_is_not_connected,
            Rotat_Unit_1_Pallet_Clamping_LH_Cyl_Unlock_X4_04_Time_out_error,
            Rotat_Unit_1_Pallet_Lifting_Cyl_Dwn_X4_08_Time_out_error,
            I10_Rotat_Unit_2_Pallet_Lifting_Cyl_Up_X4_16_Time_out_error,
            I10_Rotat_Unit_2_Pallet_Clamping_RH_Cyl_Unlock_X4_15_Time_out_error,
            I10_Rotat_Unit_2_Pallet_Lifting_Cyl_Dwn_X4_17_Time_out_error,
            I10_Rotat_Unit_1_Pallet_Lifting_Cyl_Up_X4_07_Time_out_error,
            Y_Axis_Not_Reaching_To_TrayPosition,
            Y_axis_and_X_Axis_Photo_Position_Reaching_Timeout_Error,
            Y_axis_and_X_Axis_ButtonPicking_Position_Reaching_Timeout_Error,
            NozzeGripper_Open_TimeoutError,
            NozzeGripper_Close_TimeoutError,
            Robot_Safe_CommandFailure,
            Send_RobotLH_SQ1_Send_Command_Failure,
            Send_RobotLH_SQ2_Send_Command_Failure,
            Send_RobotLH_SQ3_Send_Command_Failure,
            Send_RobotLH_SQ4_Send_Command_Failure,
            Send_RobotLH_SQ5_Send_Command_Failure,
            Send_RobotLH_SQ6_Send_Command_Failure,
            Send_RobotRH_SQ1_Send_Command_Failure,
            Send_RobotRH_SQ2_Send_Command_Failure,
            Send_RobotRH_SQ3_Send_Command_Failure,
            Send_RobotRH_SQ4_Send_Command_Failure,
            Send_RobotRH_SQ5_Send_Command_Failure,
            Send_RobotRH_SQ6_Send_Command_Failure,
            Robot_LH_SQ1_Receive_Command_Failure,
            Robot_LH_SQ2_Receive_Command_Failure,
            Robot_LH_SQ3_Receive_Command_Failure,
            Robot_LH_SQ4_Receive_Command_Failure,
            Robot_LH_SQ5_Receive_Command_Failure,
            Robot_LH_SQ6_Receive_Command_Failure,
            Robot_RH_SQ1_Receive_Command_Failure,
            Robot_RH_SQ2_Receive_Command_Failure,
            Robot_RH_SQ3_Receive_Command_Failure,
            Robot_RH_SQ4_Receive_Command_Failure,
            Robot_RH_SQ5_Receive_Command_Failure,
            Robot_RH_SQ6_Receive_Command_Failure,
            Robot_LH_TossingSQ_Receive_Command_Failure,
            Robot_LH_TossingSQ_Send_Command_Failure,
            Robot_RH_TossingSQ_Receive_Command_Failure,
            Robot_RH_TossingSQ_Send_Command_Failure,
            Ring_Light_Mov_Cyl_Work_Convy_2_Dwn_X5_08_DownPosition_Timeout_Error,
            Ring_Light_Mov_Cyl_Work_Convy_2_Dwn_X5_07_upPosition_Timeout_Error,
            I10_Robot_1_to_Ipc_Fb_X5_11_Feedback_Timeout_Error,
            I10_Tray_Trans_Slide_1_Position_load_Feed_1_X1_01_Feedback_Timeout_Error,
            I10_Tray_load_Feed_1_Tray_Pick_LH_Cyl_Dwn_X0_29_Feedback_Timeout_Error,
            I10_Tray_load_Feed_1_Tray_Pick_LH_Cyl_Up_X0_28_Feedback_Timeout_Error,
            I10_Tray_Trans_Slide_1_Position_Unload_Feed_1_X1_02_Feedback_Timeout_Error,
            I10_Tray_Unload_Feed_1_Tray_Pick_LH_Cyl_Up_X1_10_Feedback_Timeout_Error,
            I10_Tray_Unload_Feed_1_Tray_Pick_LH_Cyl_Dwn_X1_11_Feedback_Timeout_Error,
            I10_Tray_Trans_Slide_2_Position_Unload_Feed_2_X2_05_Feedback_Timeout_Error,
            I10_Tray_load_Feed_2_Tray_Pick_LH_Cyl_Up_X1_31_Feedback_Timeout_Error,
            I10_Tray_Trans_Slide_2_Position_load_Feed_2_X2_04_Feedback_Timeout_Error,
            I10_Tray_Unload_Feed_2_Tray_Pick_LH_Cyl_Up_X2_13_Feedback_Timeout_Error,
            I10_Tray_Unload_Feed_2_Tray_Pick_LH_Cyl_Dwn_X2_14_Feedback_Timeout_Error,
            I10_Tray_load_Feed_2_Tray_Pick_LH_Cyl_Dwn_X2_00_Feedback_Timeout_Error,
            I10_Tray_load_Feed_2_Draw_Lock_Cyl_Dwn_X1_22_Feedback_Timeout_Error,
            I10_Tray_Unload_Feed_2_Draw_Lock_Cyl_Dwn_X2_12_Timeout_Error,
            I10_Tray_load_Feed_1_Draw_Lock_Cyl_Dwn_X0_19_Timeout_Error,
            I10_Tray_Unload_Feed_1_Draw_Lock_Cyl_Dwn_X1_09_Timeout_Error,
            I10_Tray_load_Feed_2_Draw_Lock_Cyl_Up_X1_21_Feedback_Timeout_Error,
            I10_Tray_Unload_Feed_2_Draw_Lock_Cyl_Up_X2_11_Timeout_Error,
            I10_Tray_load_Feed_1_Draw_Lock_Cyl_Up_X0_18_Timeout_Error,
            I10_Tray_Unload_Feed_1_Draw_Lock_Cyl_Up_X1_08_Timeout_Error,
            I10_Ring_Light_Mov_Cyl_Work_Convy_1_Dwn_X5_06_Downposition_Timeout_Error,
            I10_Ring_Light_Mov_Cyl_Work_Convy_1_Dwn_X5_05_upposition_Timeout_Error,
            RH_ROBOT_FlipperFeedback_Ready_to_Place_command_TimeoutError,
            LH_ROBOT_FlipperFeedback_Ready_to_Place_command_TimeoutError,
            RH_Robot_Safecommand_Return_Failure,
            Waiting_For_Robot_Position_Timeout_Error,
            I10_Rotat_Unit_1_Pallet_Lifting_Cyl_Up_X4_07_UP_POSITION_Timeout_Error,
            I10_Rotat_Unit_1_Pallet_Lifting_Cyl_Down_X4_08_Down_POSITION_Timeout_Error,
            I10_Rotat_Unit_1_Pallet_Clamping_LH_Cyl_Unlock_X4_04_Timeout_Error,
            I10_Rotat_Unit_1_Pallet_Clamping_LH_Cyl_lock_X4_05_Timeout_Error,
            I10_Rotat_Unit_2_Pallet_Lifting_Cyl_Up_X4_16_Timeout_Error,
            I10_Rotat_Unit_2_Pallet_Lifting_Cyl_Down_X4_17_Timeout_Error,
            InspectionPosition_Reaching_TimeoutError,
            LH_Robot_AUTO_MODE_SendingFailure,
            LH_Robot_MANUAL_MODE_SendingFailure,
            LH_Robot_CALIBRATION_MODE_SendingFailure,
            LH_Robot_RECIPE_MOD_SendingFailure,
            LH_Robot_AUTOCOMPENSATION_MODE_SendingFailure,
            LH_Robot_INITIALIZATION_MODE_SendingFailure,
            RH_Robot_AUTO_MODE_SendingFailure,
            RH_Robot_MANUAL_MODE_SendingFailure,
            RH_Robot_CALIBRATION_MODE_SendingFailure,
            RH_Robot_RECIPE_MOD_SendingFailure,
            RH_Robot_AUTOCOMPENSATION_MODE_SendingFailure,
            RH_Robot_INITIALIZATION_MODE_SendingFailure,
            Button_Picking_Timeout_Error,
            Belt1Conveyor_Timeout_Error,

            TotalAlarm
        }

        #endregion

        /// <summary>
        /// Load the IO and Axis Configuration from File to the List.
        /// Load the IO parameter from Config.csv file and check the list with the Enum's declared
        /// </summary>
        /// <returns>Returns bool</returns>                
        public bool LoadConfig()
        {
            try
            {
                AxisLoad();
                List<string[]> ls = new List<string[]>();
                using (StreamReader sr = new StreamReader(Environment.CurrentDirectory + @"\Data\Config.csv", System.Text.Encoding.UTF8))
                {
                    string line = string.Empty;
                    while (!sr.EndOfStream)
                    {
                        line = sr.ReadLine();
                        if(line != null && line.Length > 0)
                        {
                            ls.Add(line.Split(','));
                        }
                    }
                }
                List<IOParam> inputTempList = new List<IOParam>();
                List<IOParam> outputTempList = new List<IOParam>();

                GlobalVariable.lstInputConfig.Clear();
                GlobalVariable.lstOutputConfig.Clear();

                for (int i = 1; i < ls.Count; i++)
                {
                    if (ls[i].Length >= 6)
                    {
                        if (ls[i][1].ToUpper().ToString() == "INPUT")
                        {
                            IOParam input = new IOParam();
                            input.iCardNo = Convert.ToInt16(ls[i][2]);
                            input.iExCardNo = Convert.ToInt16(ls[i][3]);
                            input.iBitNo = Convert.ToInt16(ls[i][4]);
                            input.sBitName = ls[i][5];
                            if (ls[i].Length >= 7)
                                input.sComment = ls[i][6];

                            inputTempList.Add(input);
                        }

                        if (ls[i][1].ToUpper().ToString() == "OUTPUT")
                        {
                            IOParam output = new IOParam();
                            output.iCardNo = Convert.ToInt16(ls[i][2]);
                            output.iExCardNo = Convert.ToInt16(ls[i][3]);
                            output.iBitNo = Convert.ToInt16(ls[i][4]);
                            output.sBitName= ls[i][5];
                            if (ls[i].Length >= 7)
                                output.sComment = ls[i][6];

                            outputTempList.Add(output);
                        }
                    }
                }

                #region Reorder by project enumeration definition total_IO and total Axis
                bool bFind = false;
                string sLackMsg = "";
                sLackMsg = "";
                GlobalVariable.lstInputConfig.Clear();
                for (int i = 0; i < ((int)EInput.End); i++)
                {
                    bFind = false;
                    for (int j = 0; j < inputTempList.Count; j++)
                    {
                        string testi = (EInput.Start + i + 1).ToString();
                        if (inputTempList[j].sBitName.Trim(' ') == (EInput.Start + i + 1).ToString())
                        {
                            GlobalVariable.lstInputConfig.Add(inputTempList[j]);
                            bFind = true;
                            break;
                        }
                    }

                    if (!bFind)
                    {
                        sLackMsg += (EInput.Start + i + 1).ToString() + "\n";
                    }
                }

                if (GlobalVariable.lstInputConfig.Count < ((int)EInput.End))
                {
                    Logger.WriteLog(Logger.LogType.Error, "DIO", "", "Input Mismatch", "Total Number of Inputs doesn't match to Specified Inputs   \n" + sLackMsg);
                    return false;
                }

                sLackMsg = "";
                GlobalVariable.lstOutputConfig.Clear();
                for (int i = 0; i < ((int)EOutput.End); i++)
                {
                    bFind = false;
                    for (int j = 0; j < outputTempList.Count; j++)
                    {
                        if (outputTempList[j].sBitName.Trim(' ') == (EOutput.Start + i + 1).ToString())
                        {
                            GlobalVariable.lstOutputConfig.Add(outputTempList[j]);
                            bFind = true;
                            break;
                        }
                    }
                    if (!bFind)
                    {
                        sLackMsg += (EOutput.Start + i + 1).ToString() + "\n";
                    }
                }

                #endregion

                if (GlobalVariable.lstOutputConfig.Count < ((int)EOutput.End))
                {
                    Logger.WriteLog(Logger.LogType.Error, "DIO", "", "Output Mismatch", "Total Number of EOutput doesn't match to Specified Outputs  \n" + sLackMsg);
                    return false;
                }
                GlobalVariable.DI = new bool[GlobalVariable.lstInputConfig.Count];
                GlobalVariable.DO= new bool[GlobalVariable.lstOutputConfig.Count];
                Logger.WriteLog(Logger.LogType.Info, "DIO", "", "Success", "Successfully Completed");
            }
            catch (Exception ex)
            {
                Logger.WriteLog(Logger.LogType.Error, "DIO", "", ex.Message, ex.ToString());
                return false;
            }
            return true;
        }

        /// <summary>
        /// Load the Axis parameter from MotorParam.csv file and check the list in Enum
        /// </summary>
        /// <returns>Returns bool</returns>
        public bool AxisLoad()
        {
            try
            {
                List<string[]> lsaxis = new List<string[]>();

                using (StreamReader sr = new StreamReader(Environment.CurrentDirectory + @"\Data\Motor_Param.csv", System.Text.Encoding.UTF8))
                {
                    string line = string.Empty;
                    while (!sr.EndOfStream)
                    {
                        line = sr.ReadLine();
                        if (line != null && line.Length > 0)
                        {
                            lsaxis.Add(line.Split(','));
                        }
                    }
                }

                List<AxisParam> axisTempList = new List<AxisParam>();

                for (int i = 0; i < lsaxis.Count; i++)
                {
                    if (lsaxis[i][11].ToUpper().ToString() == "AXIS")
                    {
                        AxisParam axisParam = new AxisParam();
                        axisParam.iCardNo = Convert.ToInt16(lsaxis[i][0]);
                        axisParam.iAxisNo = Convert.ToInt16(lsaxis[i][1]);
                        axisParam.sAxisName = lsaxis[i][2];
                        axisParam.pitch = Convert.ToDouble(lsaxis[i][3]);
                        axisParam.PPR = Convert.ToDouble(lsaxis[i][4]);
                        axisParam.pulse_mm = Convert.ToDouble(lsaxis[i][5]);
                        axisParam.Acc = Convert.ToDouble(lsaxis[i][6]);
                        axisParam.DeAcc = Convert.ToDouble(lsaxis[i][7]);
                        axisParam.AutoSpeed = Convert.ToDouble(lsaxis[i][8]);
                        axisParam.ManualSpeed = Convert.ToDouble(lsaxis[i][9]);
                        axisParam.HomingSpeed = Convert.ToDouble(lsaxis[i][10]);
                        axisTempList.Add(axisParam);
                    }
                }

                bool bFind = false;
                string sLackMsg = "";

                GlobalVariable.g_lstAxisConfig.Clear();
                for (int i = 0; i < ((int)EAxis.TotalAxis); i++)
                {
                    bFind = false;
                    for (int j = 0; j < axisTempList.Count; j++)
                    {
                        string test = (EAxis.Start + i + 1).ToString();
                        if (axisTempList[j].sAxisName == (EAxis.Start + i + 1).ToString())
                        {
                            GlobalVariable.g_lstAxisConfig.Add(axisTempList[j]);
                            bFind = true;
                            break;
                        }
                    }
                    if (bFind)
                    {
                        sLackMsg += (EAxis.Start + i + 1).ToString() + "\n";
                    }
                }

                if (GlobalVariable.g_lstAxisConfig.Count < ((int)EAxis.TotalAxis))
                {
                    
                    Logger.WriteLog(Logger.LogType.AlarmError, "DIO", "", "Axis Mismatch", "Check Axis Connection no.of Axis mismatch \n" + sLackMsg);
                    return false;
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog(Logger.LogType.Error, "DIO", "", ex.Message, ex.ToString());
                return false;
            }
            return true;
        }

        /// <summary>
        /// To perform the specified operation for all the components either On/Off or Open/Close
        /// </summary>
        /// <param name="value">True/False to perform the required operation</param>
        /// <param name="OpNum">Pass the required enum value</param>
        /// <returns>Returns bool</returns>
        public bool WriteOPS(bool value, int OpNum)
        {
            try
            {                
                int val = 0;
                int port = ((int)Advantech_PCIE.DOChanNum / 8) - 8;
                bool process = false;

                if (value)
                {
                    val = 2;

                    process = ObjectList.X1.Write_DO(val, (ushort)(port * 8 + OpNum));

                    Task.Run(()=> Logger.WriteLog(Logger.LogType.Running, "DIO", "", "Success", "Write_DO method true value success"));
                    return process;
                }
                else
                {
                    val = 1;

                    process = ObjectList.X1.Write_DO(val, (ushort)(port * 8 + OpNum));
                    Task.Run(()=> Logger.WriteLog(Logger.LogType.Running, "DIO", "", "Success", "Write_DO method false value success"));
                    return process;
                }
            }
            catch(Exception ex)
            {
                Logger.WriteLog(Logger.LogType.Error, "DIO", "", ex.Message, ex.ToString());
                return false;
            }
        }


        public bool[] ReadDI()
        {
          //  return GlobalVariable.ComObj.DI_RefreshValue(GlobalVariable.DI.Length);
          return new bool[0];
        }

        #region TowerLamp Outputs

        /// <summary>
        /// To On or Off the Tower Lamp & Push Button Lamps
        /// </summary>
        /// <param name="eOutput"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool OperateLamp(EOutput eOutput, bool value)
        {
            try
            {
                WriteOPS(value, (int)eOutput);

                if (eOutput.ToString().ToLower().Contains("red"))
                {
                   // WriteOPS(value, (int)EOutput.Flipping_rotary_cyl_0);
                }
                return true;
            }
            catch (Exception ex)
            {
                Logger.WriteLog(Logger.LogType.Error, "DIO", "", ex.Message, ex.ToString());
                return false;
            }
        }

        #endregion

        #region Only use this block when using Innovance Motion Card

        /// <summary>
        ///GlobClass input list
        /// </summary>       
        /// <summary>
        /// For instantiated axes, use this list to use the axis in programming // If you use other cards, temporarily modify the types in the List.
        /// </summary>        
        /// <summary>
        /// Call this function Only when using Innovance Motion Card
        /// </summary>
        public void Card_Init()
        {
            try
            {
                g_lstIAxis.Clear();
                for (int i = 0; i < GlobalVariable.g_lstAxisConfig.Count; i++)
                {
                    HCAxis Axis = new HCAxis(GlobalVariable.g_lstAxisConfig[i].iCardNo, GlobalVariable.g_lstAxisConfig[i].iAxisNo, GlobalVariable.g_lstAxisConfig[i].sAxisName, g_lstIAxis);
                    g_lstAXIS.Add(Axis);
                }

                g_lstInput.Clear();
                for (int i = 0; i < GlobalVariable.lstInputConfig.Count; i++)
                {
                    HCInput Input = new HCInput(GlobalVariable.lstInputConfig[i].iCardNo, GlobalVariable.lstInputConfig[i].iBitNo, GlobalVariable.lstInputConfig[i].sComment + "_" + GlobalVariable.lstInputConfig[i].sBitName, g_lstInput);
                }

                g_lstOutput.Clear();
                for (int i = 0; i < GlobalVariable.lstOutputConfig.Count; i++)
                {
                    HCOutput Output = new HCOutput(GlobalVariable.lstOutputConfig[i].iCardNo, GlobalVariable.lstOutputConfig[i].iBitNo, GlobalVariable.lstOutputConfig[i].sComment + "_" + GlobalVariable.lstOutputConfig[i].sBitName, g_lstOutput);
                }

            }
            catch (Exception ex)
            {
                Logger.WriteLog(Logger.LogType.Error, "DIO", "", ex.Message, ex.ToString());
                Logger.WriteLog(Logger.LogType.Info, "DIO", "", "Hint", "Control card initialization exception");
            }
        }
        #endregion
        public static void ShowMessageBox(string message)
        {

            Form MsgForm = new Form()
            {
                Size = new Size(400, 200),
                BackColor = Color.Teal, // Background
                Text = "Message",
                StartPosition = FormStartPosition.CenterScreen,
                FormBorderStyle = FormBorderStyle.FixedDialog,
            };

            Label label = new Label()
            {
                Text = $"{message}",
                ForeColor = Color.White, // White text
                Font = new Font("Arial", 12, FontStyle.Bold),
                AutoSize = false,
                Size = new Size(360, 80),
                TextAlign = ContentAlignment.MiddleLeft,
                Location = new Point(20, 20)
            };

            Button closeButton = new Button()
            {
                Text = "OK",
                ForeColor = Color.Black,
                BackColor = Color.White,
                Size = new Size(100, 30),
                Location = new Point(150, 110),
                DialogResult = DialogResult.OK
            };

            closeButton.Click += (sender, e) => MsgForm.Close(); // Close on button click

            MsgForm.Controls.Add(label);
            MsgForm.Controls.Add(closeButton);
            MsgForm.AcceptButton = closeButton;
            MsgForm.ShowDialog();

            // **Show the form in a new thread (Non-Blocking)**
            //Task.Run(() => errorForm.ShowDialog());
        }

    }
}
