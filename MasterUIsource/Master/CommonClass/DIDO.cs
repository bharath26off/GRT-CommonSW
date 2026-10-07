using CardDLL;
using ExceptionLib;
using HCCard;
using Master;
using Program;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;


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
		/// 


		public enum EAxis
		{
			Start = -1,
			AX0,
			AX1,
			AX2,
			AX3,
			Servo_X1,
			Servo_Y1,
			Servo_Z1,
			Servo_Z2,
			Servo_R1,
			Servo_R2,
			Servo_X2,
			Servo_Y2,
			Stepper_1,
			Stepper_2,
			Scanning_Conveyor_A,
			Scanning_Conveyor_B,
			Working_Conveyor_A,
			Working_Conveyor,
			Recheck_Conveyor,
			Working_Conveyor_B,
			Recheck_Conveyor_A,
			Recheck_Conveyor_B,
			//Stepper_3,
			TotalAxis
		}

        #region Machine Specific Input's & Output's

        /// <summary>
        /// Enum Variable for the machine Input's
        /// </summary>
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
            Spare_X2_06,
            Spare_X2_07,
            Spare_X2_08,
            Feed_is_ready,
            Feed_In_Alm,
            Feed_knife_edge_Is_In_Places,
            Feed_knife_edge_Back_In_Places,
            Feed_Module_Cyl_Up_spare,
            Feed_Module_Cyl_Dn_spare,
            Spare_X2_15,
            Pick_Place_Z1_Axis_Vaccuum_Fb,
            Pick_Place_Z2_Axis_Vaccuum_Fb,
            Spare_X3_02,
            Spare_X3_03,
            Spare_X3_04,
            Spare_X3_05,
            Spare_X3_06,
            Spare_X3_07,
            Spare_X3_08,
            Spare_X3_09,
            Spare_X3_10,
            Spare_X3_11,
            Spare_X3_12,
            Spare_X3_13,
            Spare_X3_14,
            Spare_X3_15


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
            Feed_Pick_Up_The_Command,
            Feed_Recoils_Command,
            Spare,
            Pick_Place_Z1_Axis_Vaccuum_ON,
            Pick_Place_Z2_Axis_Vaccuum_ON,
            GRT_Ready_To_Receive_Pallet,
            GRT_Ready_To_Send_Pallet,
            Pick_Place_Z1_Axis_Vaccuum_Blow,
            Pick_Place_Z2_Axis_Vaccuum_Blow,
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
            Feed_Bed_1_Vacuum_ON,
            Feed_Bed_1_Vacuum_OFF,
            Feed_Bed_2_Vacuum_ON,
            Feed_Bed_2_Vacuum_OFF,
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
        /// Enum Variable for the machine Input's
        /// </summary>
        public enum EInput_1
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
			Spare_X0_12,
			Spare_X0_13,
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
			Spare_X1_09,
			Spare_X1_10,
			Spare_X1_11,
			Spare_X1_12,
			Spare_X1_13,
			Spare_X1_14,
			Spare_X1_15,
			Spare_X2_00,
			Spare_X2_01,
			Spare_X2_02,
			Spare_X2_03,
			Previous_M_C_Ready_To_Send_Pallet,
			GBP_Ready_To_Receive_Pallet,
			Spare_X2_06,
			Spare_X2_07,
			Spare_X2_08,
			Feed_is_ready,
			Feed_In_Alm,
			Feed_knife_edge_Is_In_Places,
			Feed_knife_edge_Back_In_Places,
			Spare_X2_13,
			Pick_Place_Z1_Axis_Vaccuum_Fb,
			Pick_Place_Z2_Axis_Vaccuum_Fb,
			Work_Conv_2_Pallet_Entry_Sen,
			Work_Conv_2_Pallet_Inplace_Sen,
			Work_Conv_2_Pallet_Lift_Cyl_Up,
			Work_Conv_2_Pallet_Lift_Cyl_Dn,
			Work_Conv_2_Stopper_Cyl_Up,
			Work_Conv_2_Stopper_Cyl_Dn,
			Work_Conv_2_Pallet_Exit_Sen,
			Spare_X3_07,
			Spare_X3_08,
			Spare_X3_09,
			Spare_X3_10,
			Spare_X3_11,
			Spare_X3_12,
			Spare_X3_13,
			Spare_X3_14,
			Spare_X3_15
			, End
		}

		/// <summary>
		/// Enum Variable for the machine Output's
		/// </summary>
		public enum EOutput_1
		{
			Start = -1,
			Spare_Y0_00,
			Spare_Y0_01,
			Spare_Y0_02,
			Spare_Y0_03,
			Spare_Y0_04,
			Spare_Y0_05,
			Spare_Y0_06,
			Spare_Y0_07,
			Spare_Y0_08,
			Spare_Y0_09,
			Spare_Y0_10,
			Spare_Y0_11,
			Spare_Y0_12,
			Spare_Y0_13,
			Spare_Y0_14,
			Spare_Y0_15,
			Spare_Y1_00,
			Spare_Y1_01,
			Spare_Y1_02,
			Spare_Y1_03,
			Spare_Y1_04,
			Spare_Y1_05,
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
			Feed_Pick_Up_The_Command,
			Feed_Recoils_Command,
			Spare,
			Pick_Place_Z1_Axis_Vaccuum_ON,
			Pick_Place_Z2_Axis_Vaccuum_ON,
			GRT_Ready_To_Receive_Pallet,
			GRT_Ready_To_Send_Pallet,
			Pick_Place_Z1_Axis_Vaccuum_Blow,
			Pick_Place_Z2_Axis_Vaccuum_Blow,
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
			Feed_Bed_1_Vacuum_ON,
			Feed_Bed_1_Vacuum_OFF,
			Feed_Bed_2_Vacuum_ON,
			Feed_Bed_2_Vacuum_OFF,
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


		#endregion
		public enum Analog_Input
		{
			Start = -1,

			Pick_Place_Z1_Axis_Force_Fb,
			Pick_Place_Z2_Axis_Force_Fb,
			End
		}
		/// <summary>
		/// Enum Variable for the machine ErrorCode
		/// </summary>
		public enum ECode
		{
			Start = -1,
			Invalid_Ecode,
			Cyl_Extend_Fail,
			Cyl_Retract_Fail,
			Cyl_Extend_Timeout,
			Cyl_Retract_Timeout,
			Cyl_UnSafe_Extend,
			Cyl_UnSafe_Retract,
			Cyl_Both_Sensor,
			Cyl_interlock_Fail,
			PosLimit_Error,
			NegLimit_Error,
			Disable_Error,
			MoveTimeout_Error,
			DriveError_Error,
			Emg_Pressed_Error,
			SafetyDoor_open_Error,
			MainAir_FB_Error,
			Homing_TimeOut_Error,
			ProgramException_Error,
			Motion_Time_out_Error,
			Motion_Card_not_open,
			Robot_Alarm_Error,
			Robot_Receive_TimeOut_Error,
			Vac_VacuumOnOffFail,
			Vac_BlowOnOffFail,
			Vac_TimeoutEcode,
			IO_Stepper_ForwardFail,
			IO_Stepper_ReverseFail,
			IO_Stepper_StopFail,
			IO_Stepper_AlarmResetFail,
			Button_Picking_Timeout_Error,
			Belt1Conveyor_Timeout_Error,
			queue_empty,
			InvalidServoCoordinate,
			loadcellZ1Overload,
			loadcellZ2Overload,
			Loading_Conveyor_Motor_Error,
			Wroking_Conveyor1_Motor_Error,
			Wroking_Conveyor2_Motor_Error,
			Homing_imeout,
			CCD1_Communication_Error,
			CCD2_Communication_Error,
			CCD3_Communication_Error,
			CCD4_Communication_Error,
			SFC_Communication_Error,
			Barcode_Scanner_Communication_Error,
			Servo_Z1_Not_Safe_Org,
			Servo_Z2_Not_Safe_Org,
			TotalAlarm,

		}

		public enum RobotInputs
		{
			RBT_Opr_Sigl = 68
			, RBT_Alm_Sigl = 69
			, RBT_Opr_Right_Signl
			, RBT_Prog_Select_Signl1
			, RBT_Prog_Select_Signl2
			, RBT_Prog_Select_Signl3
			, GPO6_Spare6
			, GPO7_Rbt_Vacuum_On
			, GPO8_Rbt_Vacuum_Off
			, GPO9_Peel_Vacuum_On
			, GP1O_Peel_Vacuum_Off
			, GP11_Peel_Clamp
			, GP12_Peel_Unclamp
			, GP13_Spare13
			, GP14_Spare14
			, GP15_Spare15

		}

		public enum RobotOutputs
		{
			RBT_EMG_Stp_Signl = 21
			, RBT_Rst_Signl = 22
			, RBT_Strt_Signl
			, RBT_Opr_Right_Signl
			, RBT_Alm_Rst_Signl
			, RBT_Prog_Selec_Signl1
			, RBT_Prog_Selec_Signl2
			, Spare_Y1_13
			, RBT_Prog_Selec_Signl3
			, M_GPI9_Rbt_Vacuum_On_Fb
			, M_GPI10_Rbt_Vacuum_Off_Fb
			, M_GPI11_Peel_Vacuum_On_Fb
			, M_GPI12_Peel_Vacuum_Off_Fb
			, M_GPI13_Peel_Clamp_Fb
			, M_GPI14_Peel_UnClamp_Fb
			, M_GPI15_Spare15
		}

		#endregion

		/// <summary>
		/// Selects which IO configuration CSV to load based on GlobalVariable.g_MachineIoChaged.
		/// "Yes" -> Data\Config_MachineChanged.csv , "No" -> Data\Config.csv (case-insensitive, trimmed).
		/// Called only during LoadConfig() (i.e. application/init time) - never mid-run.
		/// </summary>
		/// <returns>Full path to the selected CSV, or null if g_MachineIoChaged is neither Yes nor No.</returns>
		private string GetIOConfigPath()
		{
			string machineIoChanged = GlobalVariable.g_MachineIoChaged?.Trim();

			if (string.Equals(machineIoChanged, "Yes", StringComparison.OrdinalIgnoreCase))
			{
				return Path.Combine(Environment.CurrentDirectory, "Data", "Config_MachineChanged.csv");
			}

			if (string.Equals(machineIoChanged, "No", StringComparison.OrdinalIgnoreCase))
			{
				return Path.Combine(Environment.CurrentDirectory, "Data", "Config.csv");
			}

			return null;
		}

		/// <summary>
		/// Load the IO and Axis Configuration from File to the List.
		/// Load the IO parameter from the selected config CSV (Config.csv or Config_MachineChanged.csv,
		/// based on GlobalVariable.g_MachineIoChaged) and check the list with the Enum's declared
		/// </summary>
		/// <returns>Returns bool</returns>                
		public bool LoadConfig()
		{
			try
			{
				AxisLoad();

				string configPath = GetIOConfigPath();
				if (configPath == null)
				{
					Logger.WriteLog(Logger.LogType.Error, "DIO", "", "Invalid MachineIoChanged Value",
						"GlobalVariable.g_MachineIoChaged must be 'Yes' or 'No'. Current value: '" + GlobalVariable.g_MachineIoChaged + "'");
					MessageBox.Show("Invalid Machine IO Changed setting (expected Yes or No). IO configuration was not loaded.");
					return false;
				}

				if (!File.Exists(configPath))
				{
					Logger.WriteLog(Logger.LogType.Error, "DIO", "", "Config File Missing", configPath);
					MessageBox.Show("IO configuration file not found:\n" + configPath);
					return false;
				}

				Logger.WriteLog(Logger.LogType.Info, "DIO", "", "Machine IO Configuration Selection",
					"MachineIoChanged=" + GlobalVariable.g_MachineIoChaged + ", Selected Config=" + Path.GetFileName(configPath));

				List<string[]> ls = new List<string[]>();
				using (StreamReader sr = new StreamReader(configPath, System.Text.Encoding.UTF8))
				{
					string line = string.Empty;
					while (!sr.EndOfStream)
					{
						line = sr.ReadLine();
						if (line != null && line.Length > 0)
						{
							ls.Add(line.Split(','));
						}
					}
				}
				List<IOParam> inputTempList = new List<IOParam>();
				List<IOParam> outputTempList = new List<IOParam>();
				List<IOParam> analoginputTempList = new List<IOParam>();


				GlobalVariable.lstInputConfig.Clear();
				GlobalVariable.lstOutputConfig.Clear();
				GlobalVariable.lstAnalogIntputConfig.Clear();


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
							output.sBitName = ls[i][5];
							if (ls[i].Length >= 7)
								output.sComment = ls[i][6];

							outputTempList.Add(output);
						}

						if (ls[i][1].ToUpper().ToString() == "ANALOG_INPUT")
						{
							IOParam ANALOG_INPUT = new IOParam();
							ANALOG_INPUT.iCardNo = Convert.ToInt16(ls[i][2]);
							ANALOG_INPUT.iExCardNo = Convert.ToInt16(ls[i][3]);
							ANALOG_INPUT.iBitNo = Convert.ToInt16(ls[i][4]);
							ANALOG_INPUT.sBitName = ls[i][5];
							if (ls[i].Length >= 7)
								ANALOG_INPUT.sComment = ls[i][6];

							analoginputTempList.Add(ANALOG_INPUT);
						}
					}
				}

				#region Reorder by project enumeration definition total_IO and total Axis
				bool bFind = false;
				string sLackMsg = "";

				if (string.Equals(GlobalVariable.g_MachineIoChaged?.Trim(), "Yes", StringComparison.OrdinalIgnoreCase))
				{
					// YES: use EInput_1 and EOutput_1 only.
					GlobalVariable.lstInputConfig.Clear();
					for (int i = 0; i < ((int)EInput_1.End); i++)
					{
						bFind = false;
						for (int j = 0; j < inputTempList.Count; j++)
						{
							if (inputTempList[j].sBitName.Trim(' ') == (EInput_1.Start + i + 1).ToString())
							{
								GlobalVariable.lstInputConfig.Add(inputTempList[j]);
								bFind = true;
								break;
							}
						}

						if (!bFind)
						{
							sLackMsg += (EInput_1.Start + i + 1).ToString() + "\n";
						}
					}

					if (GlobalVariable.lstInputConfig.Count < ((int)EInput_1.End))
					{
						Logger.WriteLog(Logger.LogType.Error, "DIO", "", "Input Mismatch",
							"Total Number of Inputs doesn't match to Specified Inputs   \n" + sLackMsg);
						MessageBox.Show("Total Number of Inputs doesn't match to Specified Inputs");
						return false;
					}

					sLackMsg = "";
					GlobalVariable.lstOutputConfig.Clear();
					for (int i = 0; i < ((int)EOutput_1.End); i++)
					{
						bFind = false;
						for (int j = 0; j < outputTempList.Count; j++)
						{
							if (outputTempList[j].sBitName.Trim(' ') == (EOutput_1.Start + i + 1).ToString())
							{
								GlobalVariable.lstOutputConfig.Add(outputTempList[j]);
								bFind = true;
								break;
							}
						}

						if (!bFind)
						{
							sLackMsg += (EOutput_1.Start + i + 1).ToString() + "\n";
						}
					}

					if (GlobalVariable.lstOutputConfig.Count < ((int)EOutput_1.End))
					{
						Logger.WriteLog(Logger.LogType.Error, "DIO", "", "Output Mismatch",
							"Total Number of EOutput doesn't match to Specified Outputs  \n" + sLackMsg);
						MessageBox.Show("Total Number of EOutput doesn't match to Specified Outputs");
						return false;
					}
				}
				else
				{
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
						MessageBox.Show("Total Number of Inputs doesn't match to Specified Inputs");
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
					if (GlobalVariable.lstOutputConfig.Count < ((int)EOutput.End))
					{
						Logger.WriteLog(Logger.LogType.Error, "DIO", "", "Output Mismatch", "Total Number of EOutput doesn't match to Specified Outputs  \n" + sLackMsg);
						MessageBox.Show("Total Number of EOutput doesn't match to Specified Outputs");
						return false;
					}
				}

				sLackMsg = "";
				GlobalVariable.lstAnalogIntputConfig.Clear();
				GlobalVariable.Analog_Input_Names = new string[(int)Analog_Input.End];
				for (int i = 0; i < ((int)Analog_Input.End); i++)
				{
					bFind = false;
					for (int j = 0; j < analoginputTempList.Count; j++)
					{
						if (analoginputTempList[j].sBitName.Trim(' ') == (Analog_Input.Start + i + 1).ToString())
						{
							GlobalVariable.lstAnalogIntputConfig.Add(analoginputTempList[j]);
							GlobalVariable.Analog_Input_Names[j] = GlobalVariable.lstAnalogIntputConfig[j].sBitName;
							bFind = true;
							break;
						}
					}
					if (!bFind)
					{
						sLackMsg += (Analog_Input.Start + i + 1).ToString() + "\n";
					}
				}


				if (GlobalVariable.lstAnalogIntputConfig.Count < ((int)Analog_Input.End))
				{
					Logger.WriteLog(Logger.LogType.Error, "AIO", "", "Analog_Input Mismatch", "Total Number of Analog_Input doesn't match to Specified Inputs  \n" + sLackMsg);
					MessageBox.Show("Total Number of Analog_Input doesn't match to Specified Analog_Input");

					return false;
				}
				#endregion


				GlobalVariable.DI = new bool[GlobalVariable.lstInputConfig.Count];
				GlobalVariable.DO = new bool[GlobalVariable.lstOutputConfig.Count];
				GlobalVariable.AI = new double[GlobalVariable.lstAnalogIntputConfig.Count];

				Logger.WriteLog(Logger.LogType.Info, "DIO", "", "IO Configuration Loaded",
					"MachineIoChanged=" + GlobalVariable.g_MachineIoChaged +
					", Config=" + Path.GetFileName(configPath) +
					", Inputs=" + GlobalVariable.lstInputConfig.Count +
					", Outputs=" + GlobalVariable.lstOutputConfig.Count +
					", AnalogInputs=" + GlobalVariable.lstAnalogIntputConfig.Count);
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

				//using (StreamReader sr = new StreamReader(Environment.CurrentDirectory + @"\Data\Motor_Param.csv", System.Text.Encoding.UTF8))
				//{
				//    string line = string.Empty;
				//    while (!sr.EndOfStream)
				//    {
				//        line = sr.ReadLine();
				//        if (line != null && line.Length > 0)
				//        {
				//            lsaxis.Add(line.Split(','));
				//        }
				//    }
				//}

				lsaxis = XML.XML_Data_to_RowList(GlobalVariable.Axis_Parameter_Setting_Path);


				List<AxisParam> axisTempList = new List<AxisParam>();

				for (int i = 0; i < lsaxis.Count; i++)
				{
					// if (lsaxis[i][11].ToUpper().ToString() == "AXIS")
					{
						AxisParam axisParam = new AxisParam();
						axisParam.iCardNo = Convert.ToInt16(lsaxis[i][0]);
						axisParam.iAxisNo = Convert.ToInt16(lsaxis[i][1]);
						axisParam.sAxisName = lsaxis[i][2];
						axisParam.pitch = Convert.ToDouble(lsaxis[i][3]);
						axisParam.pulse_mm = Convert.ToDouble(lsaxis[i][4]);
						axisParam.PPR = Convert.ToDouble(lsaxis[i][5]);
						axisParam.Acc = Convert.ToDouble(lsaxis[i][6]);
						axisParam.DeAcc = Convert.ToDouble(lsaxis[i][7]);
						// axisParam.AutoSpeed = Convert.ToDouble(lsaxis[i][8]);
						//axisParam.ManualSpeed = Convert.ToDouble(lsaxis[i][8]);
						axisParam.HomingSpeed = Convert.ToDouble(lsaxis[i][8]);
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
					MessageBox.Show("Axis Mismatch: Check Axis Connection no.of Axis mismatch");
					return false;
				}

				//Homing_Param_Set();
			}
			catch (Exception ex)
			{
				Logger.WriteLog(Logger.LogType.Error, "DIO", "", ex.Message, ex.ToString());
				return false;
			}
			return true;
		}

		//public static void Homing_Param_Set()
		//{

		//    ObjectList.Servo_X1.Set_Home_Param(50, GlobalVariable.g_lstAxisConfig[(int)EAxis.Servo_X1].HomingSpeed, GlobalVariable.g_lstAxisConfig[(int)EAxis.Servo_X1].Acc, GlobalVariable.g_lstAxisConfig[(int)EAxis.Servo_X1].DeAcc);
		//    ObjectList.Servo_Y1.Set_Home_Param(50, GlobalVariable.g_lstAxisConfig[(int)EAxis.Servo_Y1].HomingSpeed, GlobalVariable.g_lstAxisConfig[(int)EAxis.Servo_Y1].Acc, GlobalVariable.g_lstAxisConfig[(int)EAxis.Servo_Y1].DeAcc);
		//    ObjectList.Servo_Z1.Set_Home_Param(50, GlobalVariable.g_lstAxisConfig[(int)EAxis.Servo_Z1].HomingSpeed, GlobalVariable.g_lstAxisConfig[(int)EAxis.Servo_Z1].Acc, GlobalVariable.g_lstAxisConfig[(int)EAxis.Servo_Z1].DeAcc);
		//    ObjectList.Servo_Z2.Set_Home_Param(50, GlobalVariable.g_lstAxisConfig[(int)EAxis.Servo_Z2].HomingSpeed, GlobalVariable.g_lstAxisConfig[(int)EAxis.Servo_Z2].Acc, GlobalVariable.g_lstAxisConfig[(int)EAxis.Servo_Z2].DeAcc);
		//    ObjectList.Servo_R1.Set_Home_Param(50, GlobalVariable.g_lstAxisConfig[(int)EAxis.Servo_R1].HomingSpeed, GlobalVariable.g_lstAxisConfig[(int)EAxis.Servo_R1].Acc, GlobalVariable.g_lstAxisConfig[(int)EAxis.Servo_R1].DeAcc);
		//    ObjectList.Servo_R2.Set_Home_Param(50, GlobalVariable.g_lstAxisConfig[(int)EAxis.Servo_R2].HomingSpeed, GlobalVariable.g_lstAxisConfig[(int)EAxis.Servo_R2].Acc, GlobalVariable.g_lstAxisConfig[(int)EAxis.Servo_R2].DeAcc);
		//    ObjectList.Servo_X2.Set_Home_Param(50, GlobalVariable.g_lstAxisConfig[(int)EAxis.Servo_X2].HomingSpeed, GlobalVariable.g_lstAxisConfig[(int)EAxis.Servo_X2].Acc, GlobalVariable.g_lstAxisConfig[(int)EAxis.Servo_X2].DeAcc);
		//    ObjectList.Servo_Y2.Set_Home_Param(50, GlobalVariable.g_lstAxisConfig[(int)EAxis.Servo_Y2].HomingSpeed, GlobalVariable.g_lstAxisConfig[(int)EAxis.Servo_Y2].Acc, GlobalVariable.g_lstAxisConfig[(int)EAxis.Servo_Y2].DeAcc);
		//    ObjectList.Stepper_1.Set_Home_Param(100, GlobalVariable.g_lstAxisConfig[(int)EAxis.Stepper_1].HomingSpeed, GlobalVariable.g_lstAxisConfig[(int)EAxis.Stepper_1].Acc, GlobalVariable.g_lstAxisConfig[(int)EAxis.Stepper_1].DeAcc);
		//    ObjectList.Stepper_2.Set_Home_Param(100, GlobalVariable.g_lstAxisConfig[(int)EAxis.Stepper_2].HomingSpeed, GlobalVariable.g_lstAxisConfig[(int)EAxis.Stepper_2].Acc, GlobalVariable.g_lstAxisConfig[(int)EAxis.Stepper_2].DeAcc);
		//}


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
				int port = ((int)Advantech_PCIE.DOChanNum / 8) - GlobalVariable.OutputPortCfg;
				bool process = false;

				if (value)
				{
					val = 2;

					process = GlobalVariable.ComObj.Write_DO(val, (ushort)(port * 8 + OpNum));

					//  Task.Run(() => Logger.WriteLog(Logger.LogType.Running, "DIO", "", "Success", "Write_DO method true value success"));
					return process;
				}
				else
				{
					val = 1;

					process = GlobalVariable.ComObj.Write_DO(val, (ushort)(port * 8 + OpNum));
					//Task.Run(() => Logger.WriteLog(Logger.LogType.Running, "DIO", "", "Success", "Write_DO method false value success"));
					return process;
				}
			}
			catch (Exception ex)
			{
				Logger.WriteLog(Logger.LogType.Error, "DIO", "", ex.Message, ex.ToString());
				return false;
			}
		}


		public bool[] ReadDI()
		{
			return GlobalVariable.ComObj.DI_RefreshValue(GlobalVariable.DI.Length, GlobalVariable.InputPortCfg);
		}


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

		//public static double[] AInput = new double[10];

		public static void ReadAIValue()
		{
			try
			{
				GlobalVariable.ComObj.RefreshAISetup(true);
				GlobalVariable.AI = GlobalVariable.ComObj.RefreshAIvalues();
			}
			catch (Exception ex)
			{
				Logger.WriteLog(Logger.LogType.Error, "DIO", "", ex.Message, ex.ToString());
			}
		}

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
