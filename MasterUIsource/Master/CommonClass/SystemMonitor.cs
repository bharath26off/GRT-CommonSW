using Advantech;
using Advantech.Motion;
using DIO;
using ExceptionLib;
using GRT_BG1.Function.DryRun;
using GRT_BG1_V54.Function.CommonClass;
using HelperClassLib;
using Master;
using Program;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using UI.UI_Forms;
using UIForms;
using static DIO.DIDO;

namespace Master
{
	public class IOChecks
	{
		public int IOEInput { get; set; }
		public int IOECode { get; set; }
		public bool ShowPopup { get; set; }
		public bool NCCondition { get; set; }
		public string ErrDes { get; set; }
	}



	public static class SystemMonitor
	{
		public static bool active_sequence = false;
		public static bool autoseq_running = false;
		public static bool autoseq_pause = false;
		//public static bool tower_lamp_thread_lock = false;
		public static int tower_lamp_flickering_time = 3000; //in milli sec
		public static int tower_lamp_flickering_time1 = 3000; //in milli sec
		public static List<IOChecks> IOChecksList = new List<IOChecks>();
		//public static CancellationTokenSource _cts_Sequence;
		//private static List<Func<Task>> _methodsToRun;
		//private static readonly object _lock = new object();
		public static System.Threading.Timer System_Monitor_thread;
		public static System.Threading.Timer System_Monitor_thread1;
		public static bool System_Monitor_thread_lock = false;
		public static bool System_Monitor_thread_lock1 = false;
		public static ExceptionLib.ErrorManage er1 = new ExceptionLib.ErrorManage();
		public static bool refIO = false;
		public static bool AlarmInserted = false;
		public static bool CommunicationStatus = false;
		public static bool Start_Push_Pressed = false;
		public static Action<string> ShowMessage;
		public static Advantech_PCIE ServoAxis;
		public static bool IsFirstLogin = false; //MK
		static bool flag = false;
		//Arulkumar Fixed random stoppage start
		private static volatile bool _systemMonitor1Started = false;
		private static int _towerLampLock = 0;
		//Arulkumar Fixed random stoppage end

		public static async Task System_Monitor_IO()

		{
			try
			{
				while (true)
				{
					//Arulkumar Fixed random stoppage start
					if (GlobalVariable.b_gStop)
						break;
					//Arulkumar Fixed random stoppage end
					await Task.Delay(10);
					//Arulkumar Fixed Null start
					if (GlobalVariable.ComObj == null || GlobalVariable.DI == null || GlobalVariable.InputPortCfg <= 0)
					{
						await Task.Delay(100);
						continue;
					}
					//Arulkumar Fixed Null end
					GlobalVariable.DI = GlobalVariable.ComObj.DI_RefreshValueNew(GlobalVariable.DI.Length, GlobalVariable.InputPortCfg, ref GlobalVariable.DI);
					//GlobalVariable.DI = GlobalVariable.ComObj.DI_RefreshValue(GlobalVariable.DI.Length, GlobalVariable.InputPortCfg);
					//await Task.Delay(10);

					try
					{
						//Arulkumar Fixed Null start
						if (GlobalVariable.ComObj != null)
						{
							GlobalVariable.ComObj.RefreshAISetup(true);
							GlobalVariable.AI = GlobalVariable.ComObj.RefreshAIvalues();
						}
						//Arulkumar Fixed Null end
					}
					catch (Exception ex)
					{
						//Arulkumar Fixed random stoppage start
						Logger.WriteLog(Logger.LogType.Error, "SystemMonitor", "System_Monitor_IO", ex.Message, ex.StackTrace);
						//Arulkumar Fixed random stoppage end
					}
				}
			}
			catch (Exception ex)
			{
				//Arulkumar Fixed random stoppage start
				Logger.WriteLog(Logger.LogType.Error, "SystemMonitor", "System_Monitor_IO", ex.Message, ex.StackTrace);
				//Arulkumar Fixed random stoppage end
			}
		}


		public static async Task System_Monitor_AI()

		{
			try
			{
				while (true)
				{
					//Arulkumar Fixed random stoppage start
					if (GlobalVariable.b_gStop)
						break;
					//Arulkumar Fixed random stoppage end
					await Task.Delay(10);
					try
					{
						//Arulkumar Fixed Null start
						if (GlobalVariable.ComObj == null)
						{
							await Task.Delay(100);
							continue;
						}
						GlobalVariable.ComObj.RefreshAISetup(true);
						GlobalVariable.AI = GlobalVariable.ComObj.RefreshAIvalues();
						//Arulkumar Fixed Null end

						if (GlobalVariable.g_bAlarm != true)
						{
							//  if (Convert.ToDouble(GlobalVariable.AI[0].ToString()) >= 7)
							if (Convert.ToDouble(GlobalVariable.loadconverz1.ToString()) >= 8)
							{
								//MessageBox.Show("LoadCell1");
								//Arulkumar Fixed Null start
								ObjectList.Servo_Z1?.StopImmidiate();
								//Arulkumar Fixed Null end
								Task.Run(() => GlobalVariable.AlarmTriggerAsync(ECode.loadcellZ1Overload, true, 1, "Current Version: " + GlobalVariable.g_MachineVersion + ""));
								// ConveyorSystem.Stop();
								ConveyorSystem.Pause();
							}
							//Arulkumar Fixed Null start
							if (GlobalVariable.AI != null && GlobalVariable.AI.Length > 1)
							{
								var x = Convert.ToDouble(GlobalVariable.AI[1].ToString());
							}
							//Arulkumar Fixed Null end
							// if (Convert.ToDouble(GlobalVariable.AI[1].ToString()) >= 7)
							if (Convert.ToDouble(GlobalVariable.loadconverz2.ToString()) >= 8)
							{
								//MessageBox.Show("LoadCell2");
								//Arulkumar Fixed Null start
								ObjectList.Servo_Z2?.StopImmidiate();
								//Arulkumar Fixed Null end
								Task.Run(() => GlobalVariable.AlarmTriggerAsync(ECode.loadcellZ2Overload, true, 1, "", "Current Version: " + GlobalVariable.g_MachineVersion + ""));
								// ConveyorSystem.Stop();
								ConveyorSystem.Pause();
							}
						}
					}
					catch (Exception ex)
					{
						//Arulkumar Fixed random stoppage start
						Logger.WriteLog(Logger.LogType.Error, "SystemMonitor", "System_Monitor_AI", ex.Message, ex.StackTrace);
						//Arulkumar Fixed random stoppage end
					}
				}
			}
			catch (Exception ex)
			{
				//Arulkumar Fixed random stoppage start
				Logger.WriteLog(Logger.LogType.Error, "SystemMonitor", "System_Monitor_AI", ex.Message, ex.StackTrace);
				//Arulkumar Fixed random stoppage end
			}
		}

		//public static async Task System_Monitor_IO_Refresh()
		//{
		//    try
		//    {
		//        while (true)
		//        {
		//            try
		//            {
		//                //await Task.Delay(100);

		//                //GlobalVariable.AI = GlobalVariable.ComObj.RefreshAIvalues();

		//                //double Current = GlobalVariable.AI[0];
		//                //double Voltage = 5000 / 10; // (Current / 32767.0) * 10;
		//                //double weight = Current * Voltage;

		//                if (GlobalVariable.DI[(int)DIDO.EInput.Reset_PB])
		//                {
		//                    if (GlobalVariable.current_MCStatus == GlobalVariable.MachineStatus.Running)
		//                    {
		//                       ConveyorSystem.HardButtons(false, false, true);
		//                        ConveyorSystem.Pause();
		//                    }
		//                    else  if (GlobalVariable.current_MCStatus == GlobalVariable.MachineStatus.Pause)
		//                    {
		//                        ConveyorSystem.HardButtons(false, false, true);
		//                        GlobalVariable.current_MCStatus = GlobalVariable.MachineStatus.Pause;
		//                        if (GlobalVariable.g_bAlarm == true || GlobalVariable.b_EStop == true)
		//                        {
		//                            GlobalVariable.g_lstAlarmInfo.Where(a => a.alarmHappen).ToList().ForEach(a => a.alarmHappen = false);
		//                            GlobalVariable.g_bAlarm = false;
		//                            GlobalVariable.b_EStop = false;

		//                            //GlobalVariable.ComObj.ResetAxisError_All_Axis();
		//                            GlobalVariable.ComObj.ServoOn_All_Axis(true);
		//                            GlobalVariable.ComObj.ResetAxisError_All_Axis();
		//                            await Tower_Lamp_Handler(4);
		//                        }

		//                    }

		//                }

		//                //try
		//                //{
		//                //await Tower_Lamp_Handler();
		//                //}
		//                //catch (Exception)
		//                //{                           
		//                //    //throw;
		//                //}
		//            }
		//            catch (Exception)
		//            {

		//                //throw;
		//            }

		//        }

		//    }
		//    catch (Exception)
		//    {
		//    }
		//}


		public static async Task System_Monitor_BG_thread()
		{
			GlobalVariable.LoadReceipe(); // Add by Arulkumar 24-07-2026
			GlobalVariable.DIDO.WriteOPS(true, (int)EOutput.M_C_Lamp_On_Sig);
			GlobalVariable.DIDO.WriteOPS(true, (int)EOutput.Main_on_off_valve);
			GlobalVariable.DIDO.WriteOPS(true, (int)EOutput.Stop_PB);
			GetIOChecksList();
			GlobalVariable.ComObj.ResetAxisError_All_Axis(true);
			GlobalVariable.ResetAllAlarms();
			GlobalVariable.ComObj1.ResetAxisError_All_Axis(true);
			GlobalVariable.ResetAllAlarms();

			while (true)
			{
				//Arulkumar Fixed random stoppage start
				if (GlobalVariable.b_gStop)
					break;
				//Arulkumar Fixed random stoppage end
				try
				{
					await Task.Delay(50);
					//if (!GlobalVariable.Safety_door_Bypass)
					//{
					//    var x = !GlobalVariable.g_lstAlarmInfo[(int)ECode.SafetyDoor_open_Error].AlarmHappen;
					//    var y = GlobalVariable.DI[(int)EInput.Door_Switch_Sfty_Fb];
					//    if (!GlobalVariable.g_lstAlarmInfo[(int)ECode.SafetyDoor_open_Error].AlarmHappen && !GlobalVariable.DI[(int)EInput.Door_Switch_Sfty_Fb])
					//    {
					//        Task.Run(() => GlobalVariable.AlarmTriggerAsync(ECode.SafetyDoor_open_Error, true, 1, "X0_00"));
					//        ConveyorSystem.Stop();
					//        ConveyorSystem.HardButtons(false, true, false);
					//    }
					//}

					if (GlobalVariable.current_MCStatus == GlobalVariable.MachineStatus.Running)
					{
						if (ObjectList.Servo_X1.ToGetStatus() != "Error")
						{
							if (!ObjectList.Servo_X1.GetSingleMotionIOBit(Advantech_PCIE.MotionIOBit.SVON))
							{
								_ = Task.Run(() => GlobalVariable.AlarmTriggerAsync(ECode.Disable_Error, true, 1, DIDO.EAxis.Servo_X1.ToString(), GlobalVariable.g_MachineVersion + ""));
								ConveyorSystem.Stop();
								GlobalVariable.b_gHomingDone = false;
								GlobalVariable.g_HomingDone = false;
								MessageBox.Show("Close TEAL Application Don't Reset and Start.....!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);
							}
						}
						else
						{
							_ = Task.Run(() => GlobalVariable.AlarmTriggerAsync(ECode.DriveError_Error, true, 1, DIDO.EAxis.Servo_X1.ToString(), GlobalVariable.g_MachineVersion + ""));
							ConveyorSystem.Stop();
							GlobalVariable.b_gHomingDone = false;
							GlobalVariable.g_HomingDone = false;
							MessageBox.Show("Close TEAL Application Don't Reset and Start.....!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);

						}

						if (ObjectList.Servo_Y1.ToGetStatus() != "Error")
						{
							if (!ObjectList.Servo_Y1.GetSingleMotionIOBit(Advantech_PCIE.MotionIOBit.SVON))
							{
								_ = Task.Run(() => GlobalVariable.AlarmTriggerAsync(ECode.Disable_Error, true, 1, DIDO.EAxis.Servo_Y1.ToString(), GlobalVariable.g_MachineVersion + ""));
								ConveyorSystem.Stop();
								GlobalVariable.b_gHomingDone = false;
								GlobalVariable.g_HomingDone = false;
								MessageBox.Show("Close TEAL Application Don't Reset and Start.....!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);

							}
						}
						else
						{
							_ = Task.Run(() => GlobalVariable.AlarmTriggerAsync(ECode.DriveError_Error, true, 1, DIDO.EAxis.Servo_Y1.ToString(), GlobalVariable.g_MachineVersion + ""));
							ConveyorSystem.Stop();
							GlobalVariable.b_gHomingDone = false;
							GlobalVariable.g_HomingDone = false;
							MessageBox.Show("Close TEAL Application Don't Reset and Start.....!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);

						}

						if (ObjectList.Servo_Z1.ToGetStatus() != "Error")
						{
							if (!ObjectList.Servo_Z1.GetSingleMotionIOBit(Advantech_PCIE.MotionIOBit.SVON))
							{
								_ = Task.Run(() => GlobalVariable.AlarmTriggerAsync(ECode.Disable_Error, true, 1, DIDO.EAxis.Servo_Z1.ToString(), GlobalVariable.g_MachineVersion + ""));
								ConveyorSystem.Stop();
								GlobalVariable.b_gHomingDone = false;
								GlobalVariable.g_HomingDone = false;
								MessageBox.Show("Close TEAL Application Don't Reset and Start.....!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);

							}
						}
						else
						{
							_ = Task.Run(() => GlobalVariable.AlarmTriggerAsync(ECode.DriveError_Error, true, 1, DIDO.EAxis.Servo_Z1.ToString(), GlobalVariable.g_MachineVersion + ""));
							ConveyorSystem.Stop();
							GlobalVariable.b_gHomingDone = false;
							GlobalVariable.g_HomingDone = false;
							MessageBox.Show("Close TEAL Application Don't Reset and Start.....!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);

						}

						if (ObjectList.Servo_Z2.ToGetStatus() != "Error")
						{
							if (!ObjectList.Servo_Z2.GetSingleMotionIOBit(Advantech_PCIE.MotionIOBit.SVON))
							{
								_ = Task.Run(() => GlobalVariable.AlarmTriggerAsync(ECode.Disable_Error, true, 1, DIDO.EAxis.Servo_Z2.ToString(), GlobalVariable.g_MachineVersion + ""));
								ConveyorSystem.Stop();
								GlobalVariable.b_gHomingDone = false;
								GlobalVariable.g_HomingDone = false;
								MessageBox.Show("Close TEAL Application Don't Reset and Start.....!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);

							}
						}
						else
						{
							_ = Task.Run(() => GlobalVariable.AlarmTriggerAsync(ECode.DriveError_Error, true, 1, DIDO.EAxis.Servo_Z2.ToString(), GlobalVariable.g_MachineVersion + ""));
							ConveyorSystem.Stop();
							GlobalVariable.b_gHomingDone = false;
							GlobalVariable.g_HomingDone = false;
							MessageBox.Show("Close TEAL Application Don't Reset and Start.....!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);

						}

						if (ObjectList.Servo_R1.ToGetStatus() != "Error")
						{
							if (!ObjectList.Servo_R1.GetSingleMotionIOBit(Advantech_PCIE.MotionIOBit.SVON))
							{
								_ = Task.Run(() => GlobalVariable.AlarmTriggerAsync(ECode.Disable_Error, true, 1, DIDO.EAxis.Servo_R1.ToString(), GlobalVariable.g_MachineVersion + ""));
								ConveyorSystem.Stop();
								GlobalVariable.b_gHomingDone = false;
								GlobalVariable.g_HomingDone = false;
								MessageBox.Show("Close TEAL Application Don't Reset and Start.....!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);

							}
						}
						else
						{
							_ = Task.Run(() => GlobalVariable.AlarmTriggerAsync(ECode.DriveError_Error, true, 1, DIDO.EAxis.Servo_R1.ToString(), GlobalVariable.g_MachineVersion + ""));
							ConveyorSystem.Stop();
							GlobalVariable.b_gHomingDone = false;
							GlobalVariable.g_HomingDone = false;
							MessageBox.Show("Close TEAL Application Don't Reset and Start.....!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);

						}

						if (ObjectList.Servo_R2.ToGetStatus() != "Error")
						{
							if (!ObjectList.Servo_R2.GetSingleMotionIOBit(Advantech_PCIE.MotionIOBit.SVON))
							{
								_ = Task.Run(() => GlobalVariable.AlarmTriggerAsync(ECode.Disable_Error, true, 1, DIDO.EAxis.Servo_R2.ToString(), GlobalVariable.g_MachineVersion + ""));
								ConveyorSystem.Stop();
								GlobalVariable.b_gHomingDone = false;
								GlobalVariable.g_HomingDone = false;
								MessageBox.Show("Close TEAL Application Don't Reset and Start.....!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);

							}
						}
						else
						{
							_ = Task.Run(() => GlobalVariable.AlarmTriggerAsync(ECode.DriveError_Error, true, 1, DIDO.EAxis.Servo_R2.ToString(), GlobalVariable.g_MachineVersion + ""));
							ConveyorSystem.Stop();
							GlobalVariable.b_gHomingDone = false;
							GlobalVariable.g_HomingDone = false;
							MessageBox.Show("Close TEAL Application Don't Reset and Start.....!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);

						}

						if (ObjectList.Servo_X2.ToGetStatus() != "Error")
						{
							if (!ObjectList.Servo_X2.GetSingleMotionIOBit(Advantech_PCIE.MotionIOBit.SVON))
							{
								_ = Task.Run(() => GlobalVariable.AlarmTriggerAsync(ECode.Disable_Error, true, 1, DIDO.EAxis.Servo_X2.ToString(), GlobalVariable.g_MachineVersion + ""));
								ConveyorSystem.Stop();
								GlobalVariable.b_gHomingDone = false;
								GlobalVariable.g_HomingDone = false;
								MessageBox.Show("Close TEAL Application Don't Reset and Start.....!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);

							}
						}
						else
						{
							_ = Task.Run(() => GlobalVariable.AlarmTriggerAsync(ECode.DriveError_Error, true, 1, DIDO.EAxis.Servo_X2.ToString(), GlobalVariable.g_MachineVersion + ""));
							ConveyorSystem.Stop();
							GlobalVariable.b_gHomingDone = false;
							GlobalVariable.g_HomingDone = false;
							MessageBox.Show("Close TEAL Application Don't Reset and Start.....!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);

						}

						if (ObjectList.Servo_Y2.ToGetStatus() != "Error")
						{
							if (!ObjectList.Servo_Y2.GetSingleMotionIOBit(Advantech_PCIE.MotionIOBit.SVON))
							{
								_ = Task.Run(() => GlobalVariable.AlarmTriggerAsync(ECode.Disable_Error, true, 1, DIDO.EAxis.Servo_Y2.ToString(), GlobalVariable.g_MachineVersion + ""));
								ConveyorSystem.Stop();
								GlobalVariable.b_gHomingDone = false;
								GlobalVariable.g_HomingDone = false;
								MessageBox.Show("Close TEAL Application Don't Reset and Start.....!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);

							}
						}
						else
						{
							_ = Task.Run(() => GlobalVariable.AlarmTriggerAsync(ECode.DriveError_Error, true, 1, DIDO.EAxis.Servo_Y2.ToString(), GlobalVariable.g_MachineVersion + ""));
							ConveyorSystem.Stop();
							GlobalVariable.b_gHomingDone = false;
							GlobalVariable.g_HomingDone = false;
							MessageBox.Show("Close TEAL Application Don't Reset and Start.....!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);

						}

						if (ObjectList.Stepper_1.ToGetStatus() != "Error")
						{
							if (!ObjectList.Stepper_1.GetSingleMotionIOBit(Advantech_PCIE.MotionIOBit.SVON))
							{
								_ = Task.Run(() => GlobalVariable.AlarmTriggerAsync(ECode.Disable_Error, true, 1, DIDO.EAxis.Stepper_1.ToString(), GlobalVariable.g_MachineVersion + ""));
								ConveyorSystem.Stop();
								GlobalVariable.b_gHomingDone = false;
								GlobalVariable.g_HomingDone = false;
								MessageBox.Show("Close TEAL Application Don't Reset and Start.....!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);

							}
						}
						else
						{
							_ = Task.Run(() => GlobalVariable.AlarmTriggerAsync(ECode.DriveError_Error, true, 1, DIDO.EAxis.Stepper_1.ToString(), GlobalVariable.g_MachineVersion + ""));
							ConveyorSystem.Stop();
							GlobalVariable.b_gHomingDone = false;
							GlobalVariable.g_HomingDone = false;
							MessageBox.Show("Close TEAL Application Don't Reset and Start.....!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);

						}

						if (ObjectList.Stepper_2.ToGetStatus() != "Error")
						{
							if (!ObjectList.Stepper_2.GetSingleMotionIOBit(Advantech_PCIE.MotionIOBit.SVON))
							{
								_ = Task.Run(() => GlobalVariable.AlarmTriggerAsync(ECode.Disable_Error, true, 1, DIDO.EAxis.Stepper_2.ToString(), GlobalVariable.g_MachineVersion + ""));
								ConveyorSystem.Stop();
								GlobalVariable.b_gHomingDone = false;
								GlobalVariable.g_HomingDone = false;
								MessageBox.Show("Close TEAL Application Don't Reset and Start.....!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);

							}
						}
						else
						{
							_ = Task.Run(() => GlobalVariable.AlarmTriggerAsync(ECode.DriveError_Error, true, 1, DIDO.EAxis.Stepper_2.ToString(), GlobalVariable.g_MachineVersion + ""));
							ConveyorSystem.Stop();
							GlobalVariable.b_gHomingDone = false;
							GlobalVariable.g_HomingDone = false;
							MessageBox.Show("Close TEAL Application Don't Reset and Start.....!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);

						}
					}


					if (ObjectList.CCD1 != null && !ObjectList.CCD1.IsConnected)
					{
						//Arulkumar Fixed Null start
						if (GlobalVariable.g_lstAlarmInfo != null && (int)ECode.CCD1_Communication_Error < GlobalVariable.g_lstAlarmInfo.Count && !GlobalVariable.g_lstAlarmInfo[(int)ECode.CCD1_Communication_Error].AlarmHappen)
						//Arulkumar Fixed Null end
						{
							await Task.Run(() => GlobalVariable.AlarmTriggerAsync(ECode.CCD1_Communication_Error, true, 1, "Current Version: " + GlobalVariable.g_MachineVersion + ""));
							ConveyorSystem.Pause();
						}
					}
					if (ObjectList.CCD2 != null && !ObjectList.CCD2.IsConnected)
					{
						//Arulkumar Fixed Null start
						if (GlobalVariable.g_lstAlarmInfo != null && (int)ECode.CCD2_Communication_Error < GlobalVariable.g_lstAlarmInfo.Count && !GlobalVariable.g_lstAlarmInfo[(int)ECode.CCD2_Communication_Error].AlarmHappen)
						//Arulkumar Fixed Null end
						{
							await Task.Run(() => GlobalVariable.AlarmTriggerAsync(ECode.CCD2_Communication_Error, true, 1, "", "Current Version: " + GlobalVariable.g_MachineVersion + ""));
							ConveyorSystem.Pause();
						}
					}

					if (ObjectList.CCD3 != null && !ObjectList.CCD3.IsConnected)
					{
						//Arulkumar Fixed Null start
						if (GlobalVariable.g_lstAlarmInfo != null && (int)ECode.CCD3_Communication_Error < GlobalVariable.g_lstAlarmInfo.Count && !GlobalVariable.g_lstAlarmInfo[(int)ECode.CCD3_Communication_Error].AlarmHappen)
						//Arulkumar Fixed Null end
						{
							await Task.Run(() => GlobalVariable.AlarmTriggerAsync(ECode.CCD3_Communication_Error, true, 1, "", "Current Version: " + GlobalVariable.g_MachineVersion + ""));
							ConveyorSystem.Pause();
						}
					}
					if (ObjectList.CCD4 != null && !ObjectList.CCD4.IsConnected)
					{
						//Arulkumar Fixed Null start
						if (GlobalVariable.g_lstAlarmInfo != null && (int)ECode.CCD4_Communication_Error < GlobalVariable.g_lstAlarmInfo.Count && !GlobalVariable.g_lstAlarmInfo[(int)ECode.CCD4_Communication_Error].AlarmHappen)
						//Arulkumar Fixed Null end
						{
							await Task.Run(() => GlobalVariable.AlarmTriggerAsync(ECode.CCD4_Communication_Error, true, 1, "", "Current Version: " + GlobalVariable.g_MachineVersion + ""));
							ConveyorSystem.Pause();
						}
					}
					if (ObjectList.SFC != null && !ObjectList.SFC.IsConnected)
					{
						//Arulkumar Fixed Null start
						if (GlobalVariable.g_lstAlarmInfo != null && (int)ECode.SFC_Communication_Error < GlobalVariable.g_lstAlarmInfo.Count && !GlobalVariable.g_lstAlarmInfo[(int)ECode.SFC_Communication_Error].AlarmHappen)
						//Arulkumar Fixed Null end
						{
							await Task.Run(() => GlobalVariable.AlarmTriggerAsync(ECode.SFC_Communication_Error, true, 1, "", "Current Version: " + GlobalVariable.g_MachineVersion + ""));
							ConveyorSystem.Pause();
						}
					}
					if (ObjectList.Barcode_Scanner != null && !ObjectList.Barcode_Scanner.IsConnected)
					{
						//Arulkumar Fixed Null start
						if (GlobalVariable.g_lstAlarmInfo != null && (int)ECode.Barcode_Scanner_Communication_Error < GlobalVariable.g_lstAlarmInfo.Count && !GlobalVariable.g_lstAlarmInfo[(int)ECode.Barcode_Scanner_Communication_Error].AlarmHappen)
						//Arulkumar Fixed Null end
						{
							await Task.Run(() => GlobalVariable.AlarmTriggerAsync(ECode.Barcode_Scanner_Communication_Error, true, 1, "", "Current Version: " + GlobalVariable.g_MachineVersion + ""));
							ConveyorSystem.Pause();
						}
					}
					
					if (!GlobalVariable.Safety_door_Bypass) 
					{

						//Arulkumar Fixed Null start
						if (GlobalVariable.DI != null && GlobalVariable.DI.Length > (int)EInput.Door_Switch_Sfty_Fb && GlobalVariable.g_lstAlarmInfo != null && (int)ECode.SafetyDoor_open_Error < GlobalVariable.g_lstAlarmInfo.Count && !GlobalVariable.g_lstAlarmInfo[(int)ECode.SafetyDoor_open_Error].AlarmHappen && !GlobalVariable.DI[(int)EInput.Door_Switch_Sfty_Fb])
						//Arulkumar Fixed Null end
						{

                            await Task.Run(() => GlobalVariable.AlarmTriggerAsync(ECode.SafetyDoor_open_Error, true, 1, "X0_00", "Current Version: " + GlobalVariable.g_MachineVersion + ""));
							GlobalVariable.current_MCStatus = GlobalVariable.MachineStatus.Stop;
							GlobalVariable.AlarmTrigger(ECode.SafetyDoor_open_Error, true, 1);
						}
                        GlobalVariable.DIDO.WriteOPS(false, (int)EOutput.Safety_Bypass_On_Sig);

                    }
                    else
                    {
                        GlobalVariable.DIDO.WriteOPS(true, (int)EOutput.Safety_Bypass_On_Sig);
                    }

                    if (!ObjectList.Servo_R1.GetSingleMotionIOBit(Advantech_PCIE.MotionIOBit.LMT_P))
					{

					}
					else
					{
						_ = Task.Run(() => GlobalVariable.AlarmTriggerAsync(ECode.NegLimit_Error, true, 1, DIDO.EAxis.Servo_R1.ToString(), GlobalVariable.g_MachineVersion + ""));
					}
					if (!ObjectList.Servo_R2.GetSingleMotionIOBit(Advantech_PCIE.MotionIOBit.LMT_P))
					{

					}
					else
					{
						_ = Task.Run(() => GlobalVariable.AlarmTriggerAsync(ECode.NegLimit_Error, true, 1, DIDO.EAxis.Servo_R2.ToString(), GlobalVariable.g_MachineVersion + ""));
					}

					//try
					//{
					//	//Arulkumar Fixed Null start
					//	if (GlobalVariable.DI == null || GlobalVariable.DI.Length <= (int)DIDO.EInput.Stop_PB)
					//	{
					//		continue;
					//	}
					//	//Arulkumar Fixed Null end
					//	bool isStop = !GlobalVariable.DI[(int)DIDO.EInput.Stop_PB];
					//	bool Stop_Presssd = GlobalVariable.stop_pb ? isStop : !isStop;
					//	if (isStop)
					//	{
					//		isStop = !GlobalVariable.DI[(int)DIDO.EInput.Stop_PB];
					//		bool Stop_Presssd_now = GlobalVariable.stop_pb ? isStop : !isStop;
					//		if (Stop_Presssd_now)
					//		{
					//			await Task.Delay(100);
					//			if (!GlobalVariable.DI[(int)DIDO.EInput.Stop_PB])
					//			{
					//				ConveyorSystem.Pause();
					//				ConveyorSystem.HardButtons(false, true, false);
					//				GlobalVariable.current_MCStatus = GlobalVariable.MachineStatus.Pause;
					//			}
					//			////else
					//			////{
					//			//    ConveyorSystem.Resume();
					//			////}

					//		}
					//	}
					//}
					//catch
					//{

					//}


					try
					{
						await Tower_Lamp_Handler();
					}
					catch (Exception)
					{
					}

					if (!GlobalVariable.b_gCardInitSucc)
					{
						await GlobalVariable.AlarmTriggerAsync(ECode.Motion_Card_not_open, true, 1, "", "Current Version: " + GlobalVariable.g_MachineVersion + "");
						System_Monitor_thread_lock = false;
						return;
					}

				}
				catch (Exception)
				{
				}


			}
		}
		public static async Task<bool[]> DIrefresh1()
		{
			//await Task.Delay(50);
			return GlobalVariable.ComObj.DI_RefreshValue(GlobalVariable.DI.Length, GlobalVariable.InputPortCfg);
			//return true;
		}

		public static async Task System_Monitor1()
		{
			try
			{
				while (true)
				{
					//Arulkumar Fixed random stoppage start
					if (GlobalVariable.b_gStop)
						break;
					//Arulkumar Fixed random stoppage end
					try
					{

						await Task.Delay(100);

						if (GlobalVariable.UIResetClicked == true || GlobalVariable.g_MachineIoChaged == "Yes" ? GlobalVariable.DI[(int)DIDO.EInput_1.Reset_PB] : GlobalVariable.DI[(int)DIDO.EInput.Reset_PB])
						{
							GlobalVariable.UIResetClicked = false;


                            if (GlobalVariable.g_bAlarm || GlobalVariable.current_MCStatus == GlobalVariable.MachineStatus.Stop || GlobalVariable.current_MCStatus == GlobalVariable.MachineStatus.Pause || GlobalVariable.current_MCStatus == GlobalVariable.MachineStatus.Ideal)
							{
								GlobalVariable.current_MCStatus = GlobalVariable.MachineStatus.Pause;

								if(GlobalVariable.g_bAlarm == true || GlobalVariable.b_EStop == true)
								{
                                    _ = Task.Run(() => ResetErrors());

                                }

								//GlobalVariable.DIDO.WriteOPS(false, (int)DIDO.EOutput.Safety_Bypass_On_Sig);

								GlobalVariable.ComObj.ServoOn(true);
								GlobalVariable.ComObj1.ServoOn(true);

                                ObjectList.Scanning_Conveyor_A.ResetAxis();
								ObjectList.Scanning_Conveyor_B.ResetAxis();
								ObjectList.Working_Conveyor_A.ResetAxis();
								ObjectList.Working_Conveyor_B.ResetAxis();
								ObjectList.Recheck_Conveyor_A.ResetAxis();
								ObjectList.Recheck_Conveyor_B.ResetAxis();

								ObjectList.Scanning_Conveyor_A.ServoOn(true);
								ObjectList.Scanning_Conveyor_B.ServoOn(true);
								ObjectList.Working_Conveyor_A.ServoOn(true);
								ObjectList.Working_Conveyor_B.ServoOn(true);
								ObjectList.Recheck_Conveyor_A.ServoOn(true);
								ObjectList.Recheck_Conveyor_B.ServoOn(true);
								GlobalVariable.ComObj.ServoOn_All_Axis(true);
								GlobalVariable.ComObj1.ServoOn_All_Axis(true);
                                GlobalVariable.ComObj.Init_BoardFunc();
                                GlobalVariable.ComObj1.Init_BoardFunc();



                                if (GlobalVariable.g_bAlarm == true || GlobalVariable.b_EStop == true)
								{
									ConveyorSystem.HardButtons(false, false, false);
									GlobalVariable.current_MCStatus = GlobalVariable.MachineStatus.Pause;

									if (ObjectList.Servo_X1.GetSingleMotionIOBit(Advantech_PCIE.MotionIOBit.ALM) ||
										!ObjectList.Servo_X1.GetSingleMotionIOBit(Advantech_PCIE.MotionIOBit.SVON) || ObjectList.Servo_Y1.GetSingleMotionIOBit(Advantech_PCIE.MotionIOBit.ALM) ||
										!ObjectList.Servo_Y1.GetSingleMotionIOBit(Advantech_PCIE.MotionIOBit.SVON) || ObjectList.Servo_Z1.GetSingleMotionIOBit(Advantech_PCIE.MotionIOBit.ALM) ||
										!ObjectList.Servo_Z1.GetSingleMotionIOBit(Advantech_PCIE.MotionIOBit.SVON) || ObjectList.Servo_R1.GetSingleMotionIOBit(Advantech_PCIE.MotionIOBit.ALM) ||
										!ObjectList.Servo_R1.GetSingleMotionIOBit(Advantech_PCIE.MotionIOBit.SVON) || ObjectList.Servo_R2.GetSingleMotionIOBit(Advantech_PCIE.MotionIOBit.ALM) ||
										!ObjectList.Servo_R2.GetSingleMotionIOBit(Advantech_PCIE.MotionIOBit.SVON) || ObjectList.Servo_Z2.GetSingleMotionIOBit(Advantech_PCIE.MotionIOBit.ALM) ||
										!ObjectList.Servo_Z2.GetSingleMotionIOBit(Advantech_PCIE.MotionIOBit.SVON) || ObjectList.Stepper_1.GetSingleMotionIOBit(Advantech_PCIE.MotionIOBit.ALM) ||
										!ObjectList.Stepper_1.GetSingleMotionIOBit(Advantech_PCIE.MotionIOBit.SVON) || ObjectList.Stepper_2.GetSingleMotionIOBit(Advantech_PCIE.MotionIOBit.ALM) ||
										!ObjectList.Stepper_2.GetSingleMotionIOBit(Advantech_PCIE.MotionIOBit.SVON))

									{
										await Task.Run(() =>
										{
											ObjectList.Servo_X1.ResetAxis();
											ObjectList.Servo_X2.ResetAxis();
											ObjectList.Servo_Y1.ResetAxis();
											ObjectList.Servo_Y2.ResetAxis();
											ObjectList.Servo_R1.ResetAxis();
											ObjectList.Servo_R2.ResetAxis();
											ObjectList.Servo_Z1.ResetAxis();
											ObjectList.Servo_Z2.ResetAxis();
											ObjectList.Stepper_1.ResetAxis();
											ObjectList.Stepper_2.ResetAxis();

											ObjectList.AX0.ServoOn(true);
											ObjectList.AX1.ServoOn(true);
											ObjectList.AX2.ServoOn(true);
											ObjectList.AX3.ServoOn(true);

											ObjectList.Servo_R1.ServoOn(true);
											ObjectList.Servo_R2.ServoOn(true);
											ObjectList.Servo_X1.ServoOn(true);
											ObjectList.Servo_X2.ServoOn(true);
											ObjectList.Servo_Y1.ServoOn(true);
											ObjectList.Servo_Y2.ServoOn(true);
											ObjectList.Servo_Z1.ServoOn(true);
											ObjectList.Servo_Z2.ServoOn(true);
											ObjectList.Stepper_1.ServoOn(true);
											ObjectList.Stepper_2.ServoOn(true);
                                            GlobalVariable.ResetAllAlarms();
                                            GlobalVariable.ComObj.ServoOn_All_Axis(true);
                                            GlobalVariable.ComObj1.ServoOn_All_Axis(true);



                                        });

									}
								}
							}
							else
							{
								Logger.WriteLog(Logger.LogType.Running, "MainForm - Auto Sequnce Running time Clicked Reset Hard Btn", "Current Version:", GlobalVariable.g_MachineVersion, "");
								MessageBox.Show("There is no alarm and machine is currently running....", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);
							}

						}
						#region Only for IO Conveyor - Enable
						if (GlobalVariable.DI[(int)DIDO.EInput.Scan_Conv_Mtr_A_Alm_Sig] || GlobalVariable.DI[(int)DIDO.EInput.Scan_Conv_Mtr_B_Alm_Sig])
						{
							if (!GlobalVariable.g_lstAlarmInfo[(int)ECode.Loading_Conveyor_Motor_Error].AlarmHappen)
							{
								{

									await GlobalVariable.AlarmTriggerAsync(ECode.Loading_Conveyor_Motor_Error, true, 1, "X0_12,X0_13");
								}
							}
						}
						if (GlobalVariable.DI[(int)DIDO.EInput.Work_Conv_1_Mtr_A_Alm_Sig] || GlobalVariable.DI[(int)DIDO.EInput.Work_Conv_1_Mtr_B_Alm_Sig])
						{
							if (!GlobalVariable.g_lstAlarmInfo[(int)ECode.Wroking_Conveyor1_Motor_Error].AlarmHappen)
							{
								{
									await GlobalVariable.AlarmTriggerAsync(ECode.Wroking_Conveyor1_Motor_Error, true, 1, "X1_09,X_10");
								}
							}
						}
						if (GlobalVariable.DI[(int)DIDO.EInput.Work_Conv_2_Mtr_A_Alm_Sig] || GlobalVariable.DI[(int)DIDO.EInput.Work_Conv_1_Mtr_B_Alm_Sig])
						{
							if (!GlobalVariable.g_lstAlarmInfo[(int)ECode.Wroking_Conveyor2_Motor_Error].AlarmHappen)
							{
								{
									await GlobalVariable.AlarmTriggerAsync(ECode.Wroking_Conveyor2_Motor_Error, true, 1, "X2_04,X2_05");
								}
							}
						}
						#endregion

						if (GlobalVariable.DI[(int)DIDO.EInput.Str_PB])
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

									MainForm.StartAutoSequence();
								}
							}
							catch (Exception ex)
							{
								//Arulkumar Fixed random stoppage start
								Logger.WriteLog(Logger.LogType.Error, "MainForm", "btn_start_auto_seq_Click", ex.Message, ex.ToString());
								//Arulkumar Fixed random stoppage end
							}


						}

						if (!GlobalVariable.DI[(int)DIDO.EInput.Stop_PB])
						{
							if (!GlobalVariable.pause)
							{
								Logger.WriteLog(Logger.LogType.Running, "Manual Pause", "Current Version:", GlobalVariable.g_MachineVersion, "");

								GlobalVariable.pause = true;
								GlobalVariable.b_gPause = true;
								ConveyorSystem.Pause();

							}
						}

                        if (!GlobalVariable.DI[(int)DIDO.EInput.Stop_PB])
                        {
                            ConveyorSystem.Pause();
                            ConveyorSystem.HardButtons(false, true, false);
                            GlobalVariable.current_MCStatus = GlobalVariable.MachineStatus.Pause;
                        }
                    }

					catch (Exception)
					{

						//throw;
					}

				}

			}
			catch (Exception)
			{

			}
		}





		//MK
		public static void InitializeAllAxesEnabled()
		{
			try
			{

				// Collect all servos using safe enumeration with null-conditional
				var servos = new[]
				{
					 ObjectList.Servo_X1, ObjectList.Servo_X2,
					 ObjectList.Servo_Y1, ObjectList.Servo_Y2,
					 ObjectList.Servo_R1, ObjectList.Servo_R2,
					 ObjectList.Servo_Z1, ObjectList.Servo_Z2
				};

				// Enable all AX motion components safely
				foreach (var servo in servos)
				{
					servo?.ServoOn(true);
				}

				// Stepper axes are separate; enable explicitly with null check
				foreach (var stepper in new[] { ObjectList.Stepper_1, ObjectList.Stepper_2 })
				{
					stepper?.ServoOn(true);
				}

				//Arulkumar Fixed random stoppage start
				if (!_systemMonitor1Started)
				{
					_systemMonitor1Started = true;
					Task.Run(() => System_Monitor1());
				}
				//Arulkumar Fixed random stoppage end

			}
			catch (Exception ex)
			{
				var fullMessage = $"Failed to enable servos and steppers: {ex.ToString()}";
				Logger.WriteLog(Logger.LogType.Error, "Failed to enable servos and steppers", "Fail",
					"Failed to initialize all axes due to an exception", fullMessage);
				Logger.WriteLog(Logger.LogType.Error, "InitializeAllAxesEnabled", "AxesEnabled",
					"Failed to initialize all axes due to an exception", fullMessage);
				Logger.WriteLogasTask(Logger.LogType.Running, "InitializeAllAxesEnabled", "AxesEnabled",
					"Failed to initialize all axes due to an exception", fullMessage);
			}
		}



		public static async Task ResetErrors()
		{
			try
			{
				GlobalVariable.ResetAllAlarms();
				GlobalVariable.b_EStop = false;
				GlobalVariable.g_lstAlarmInfo.Where(a => a.alarmHappen).ToList().ForEach(a => a.alarmHappen = false);

				await Task.Run(() =>
				{
					GlobalVariable.ComObj.ResetAxisError_All_Axis();
					GlobalVariable.ComObj.ServoOn_All_Axis(true);
					GlobalVariable.ComObj.ResetAxisError_All_Axis();

					GlobalVariable.ComObj1.ResetAxisError_All_Axis();
					GlobalVariable.ComObj1.ServoOn_All_Axis(true);
					GlobalVariable.ComObj1.ResetAxisError_All_Axis();
					ObjectList.ConnectAllObj();
				});
				ObjectList.ConnectAllObj();

				AlarmInserted = false;
			}
			catch (Exception)
			{

				// throw;
			}
		}

		private static void GetIOChecksList()
		{
			try
			{
				string filePath = Environment.CurrentDirectory + "\\Data\\IOChecks.csv";

				string[] csvLines;

				if (File.Exists(filePath))
				{
					csvLines = File.ReadAllLines(filePath);

					if (csvLines.Length > 0)
					{
						//Arulkumar Fixed random stoppage start
						for (int i = 1; i < csvLines.Length; i++)
						{
							if (string.IsNullOrWhiteSpace(csvLines[i]))
							{
								continue;
							}
							string[] data = csvLines[i].Split(',');
							if (data == null || data.Length < 5)
							{
								continue;
							}
							//Arulkumar Fixed random stoppage end
							Task.Delay(100);
							var IOs = new IOChecks
							{
								IOEInput = (int)(DIDO.EInput)Enum.Parse(typeof(DIDO.EInput), Convert.ToString(data[0])),
								IOECode = (int)(DIDO.ECode)Enum.Parse(typeof(DIDO.ECode), Convert.ToString(data[1])),
								ShowPopup = Convert.ToBoolean(Convert.ToInt16(data[2])),
								NCCondition = Convert.ToBoolean(Convert.ToInt16(data[3])),
								ErrDes = Convert.ToString(data[4])
							};

							IOChecksList.Add(IOs);
						}
					}
				}
			}
			catch (Exception ex)
			{
				Logger.WriteLog(Logger.LogType.Error, "SystemMonitor", "GetIOChecksList", ex.Message, ex.StackTrace);
			}
		}


		public static bool AnyActiveAlarms()
		{
			return GlobalVariable.g_lstAlarmInfo.Any(a => a.AlarmHappen);
		}

		public static async Task<int> Machine_Status()
		{


			if (GlobalVariable.g_bAlarm == true)
				return 1; //Red with Bu

			//GlobalVariable.DI = GlobalVariable.ComObj.DI_RefreshValue(GlobalVariable.DI.Length, GlobalVariable.InputPortCfg);





			//Arulkumar Fixed Null start
			if (GlobalVariable.DI != null && GlobalVariable.DI.Length > (int)DIDO.EInput.Reset_PB && GlobalVariable.DI[(int)DIDO.EInput.Reset_PB])
			//Arulkumar Fixed Null end
			{
				//GlobalVariable.ComObj.ServoOFF_All_Axis();
				//Arulkumar Automatic resume reduce 12/08/2026

				//if (GlobalVariable.bautoseq_running)
				//{
				//    ConveyorSystem.Resume();
				//}

				GlobalVariable.ComObj.ResetAxisError_All_Axis();
				GlobalVariable.ComObj1.ResetAxisError_All_Axis();
				GlobalVariable.ResetAllAlarms();
				return 4;       //  Yellow
			}
			if (GlobalVariable.VbUOP_ProcessFail || GlobalVariable.Recheck_NG || GlobalVariable.CCD4_Trigger_Fail || GlobalVariable.Working_Pallet_NotMoves)
			{

				return 1;//Red with Bu
			}

			if (GlobalVariable.bhomeseq_running)
				return 5;        // Yellow - Blinking

			if (GlobalVariable.bmachine_ReadytoStart)
				return 4;        // Yellow - steady - Machine ready

			if (GlobalVariable.current_MCStatus == GlobalVariable.MachineStatus.Running)
				return 3; // Green

			if (GlobalVariable.g_bAlarm == true)
				return 1; //Red with Bu

			if (GlobalVariable.current_MCStatus == GlobalVariable.MachineStatus.Pause || GlobalVariable.current_MCStatus == GlobalVariable.MachineStatus.Stop)
				return 4; // yellow
						  //if (GlobalVariable.bautoseq_running)
						  //    return 3;        //  Green

			if (!GlobalVariable.b_gHomingDone)
				return 2;        //  Red




			return -1;
		}

		public static async Task Tower_Lamp_Handler(int machine_status = 0)
		{
			//int machine_status = 1;
			//string machine_status = "";
			try
			{
				//Arulkumar Fixed random stoppage start
				if (Interlocked.CompareExchange(ref _towerLampLock, 1, 0) != 0)
				{
					return;
				}
				try
				{
					await Task.Delay(100);
					machine_status = await Machine_Status();
					//Arulkumar Fixed random stoppage end

					switch (machine_status)
					{
						case 1:  // Red with Buzzer
								 //GlobalVariable.DIDO.WriteOPS(true, (int)EOutput.Tower_Lmp_Rd);
								 //GlobalVariable.DIDO.WriteOPS(false, (int)EOutput.Tower_Lmp_Gn);
								 //GlobalVariable.DIDO.WriteOPS(false, (int)EOutput.Tower_Lmp_YE);
								 //GlobalVariable.DIDO.WriteOPS(true, (int)EOutput.Tower_Lmp_Buzz);
							if (!GlobalVariable.Buzzer_Bypass)
							{
								CommonTowerLamp(true, false, false, true);
							}
							else
							{
								CommonTowerLamp(true, false, false, false);
							}

							await Task.Delay(tower_lamp_flickering_time);
							//Thread.Sleep(tower_lamp_flickering_time);
							GlobalVariable.DIDO.WriteOPS(false, (int)EOutput.Tower_Lamp_Buzzer);
							await Task.Delay(tower_lamp_flickering_time);
							GlobalVariable.DIDO.WriteOPS(true, (int)EOutput.Tower_Lamp_Buzzer);
							break;
						case 2: // Red
								//GlobalVariable.DIDO.WriteOPS(true, (int)EOutput.Tower_Lmp_Rd);
								//GlobalVariable.DIDO.WriteOPS(false, (int)EOutput.Tower_Lmp_Gn);
								//GlobalVariable.DIDO.WriteOPS(false, (int)EOutput.Tower_Lmp_YE);
								//GlobalVariable.DIDO.WriteOPS(false, (int)EOutput.Tower_Lmp_Buzz);
							CommonTowerLamp(true, false, false, false);
							break;
						case 3: // Green
								//GlobalVariable.DIDO.WriteOPS(false, (int)EOutput.Tower_Lmp_Rd);
								//GlobalVariable.DIDO.WriteOPS(true, (int)EOutput.Tower_Lmp_Gn);
								//GlobalVariable.DIDO.WriteOPS(false, (int)EOutput.Tower_Lmp_YE);
								//GlobalVariable.DIDO.WriteOPS(false, (int)EOutput.Tower_Lmp_Buzz);
							CommonTowerLamp(false, true, false, false);
							break;
						case 4: // Yellow
								//GlobalVariable.DIDO.WriteOPS(false, (int)EOutput.Tower_Lmp_Rd);
								//GlobalVariable.DIDO.WriteOPS(false, (int)EOutput.Tower_Lmp_Gn);
								//GlobalVariable.DIDO.WriteOPS(true, (int)EOutput.Tower_Lmp_YE);
								//GlobalVariable.DIDO.WriteOPS(false, (int)EOutput.Tower_Lmp_Buzz);
							CommonTowerLamp(false, false, true, false);
							break;
						case 5: // Yellow Blinking
							CommonTowerLamp(false, false, true, false);
							//GlobalVariable.DIDO.WriteOPS(true, (int)EOutput.Tower_Lmp_YE);
							await Task.Delay(tower_lamp_flickering_time1);
							GlobalVariable.DIDO.WriteOPS(false, (int)EOutput.Tower_Lamp_Yellow);
							//GlobalVariable.DIDO.WriteOPS(false, (int)EOutput.Tower_Lmp_Gn);
							//GlobalVariable.DIDO.WriteOPS(false, (int)EOutput.Tower_Lmp_Rd);
							//GlobalVariable.DIDO.WriteOPS(false, (int)EOutput.Tower_Lmp_Buzz);
							break;
					}
				}
				finally
				{
					//Arulkumar Fixed random stoppage start
					Interlocked.Exchange(ref _towerLampLock, 0);
					//Arulkumar Fixed random stoppage end
				}

			}
			catch (Exception ex)
			{
				//Arulkumar Fixed random stoppage start
				Interlocked.Exchange(ref _towerLampLock, 0);
				Logger.WriteLog(Logger.LogType.Error, "SystemMonitor", "Tower_Lamp_Handler", ex.Message, ex.StackTrace);
				//Arulkumar Fixed random stoppage end
			}
		}

		private static void CommonTowerLamp(bool red, bool green, bool yellow, bool buzzer)
		{
			try
			{
				//** devchange : change the Enum according to the specific Machine
				GlobalVariable.DIDO.WriteOPS(red, (int)EOutput.Tower_Lamp_Red);
				GlobalVariable.DIDO.WriteOPS(green, (int)EOutput.Tower_Lamp_Green);
				GlobalVariable.DIDO.WriteOPS(yellow, (int)EOutput.Tower_Lamp_Yellow);

				GlobalVariable.DIDO.WriteOPS(buzzer, (int)EOutput.Tower_Lamp_Buzzer);

			}
			catch (Exception)
			{

				//throw;
			}
		}


		public static DataSet GetDatasets(CommandType cmdType, string cmdText, params SqlParameter[] commandParameters)
		{
			DataSet objDs = default;
			try
			{
				//Arulkumar Fixed random stoppage start
				using (var db = new SqlConnection(GlobalVariable.SQL_ConnStr))
				{
					var cmd = new SqlCommand();
					cmd.CommandTimeout = 120;
					SqlDataAdapter objAdap;

					PrepareCommands(cmd, db, default, cmdType, cmdText, commandParameters);
					objAdap = new SqlDataAdapter(cmd);
					objDs = new DataSet();
					objDs.Clear();
					objAdap.Fill(objDs);
				}
				//Arulkumar Fixed random stoppage end
				return objDs;
			}
			catch (Exception ex)
			{
				Logger.WriteLog(Logger.LogType.Error, "SystemMonitor", "GetDatasets", ex.Message, ex.StackTrace);
				return objDs;
				// throw ex;
			}

		}




		private static void PrepareCommands(SqlCommand cmd, SqlConnection conn, SqlTransaction trans, CommandType cmdType, string cmdText, SqlParameter[] cmdParms)
		{
			if (conn.State != ConnectionState.Open)
			{
				conn.Open();
			}

			cmd.Connection = conn;
			cmd.CommandText = cmdText;
			if (trans != null)
			{
				cmd.Transaction = trans;
			}

			cmd.CommandType = cmdType;
			if (cmdParms != null)
			{
				foreach (SqlParameter parm in cmdParms)
				{
					if (parm != null)
					{
						cmd.Parameters.Add(parm);
					}
				}
			}
		}
	}
}
