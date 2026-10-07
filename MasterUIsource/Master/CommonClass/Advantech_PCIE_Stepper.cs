using Advantech.Motion;
using ExceptionLib;
using System;
using System.Data;
using System.Diagnostics;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Program
{
    public class Advantech_PCIE_Stepper
    {
        public enum MotorType
        {
            Servo,
            Stepper
        }
        //Advantech PCIE - 1203 \             
        public static int Axiscount = 0; //To store the required Access count.
        public static int DIchannelnum = 0; // To Store the Port number.
        public int cardno = 0;
        public int Read_Axishand { get; } // get the Axis Value only
        public double Global_pulse { get; } // get the Axis Value only

        public int InputOffsetPort = 0;
        public int OutputOffsetPort = 0;
        public int _CardIndex = 0;
        public bool Home_Done = false;
        public IntPtr[] grpHandle = new IntPtr[2];

        public static IntPtr grp_Handle = IntPtr.Zero;
        /// <summary>
        /// Initialize Motor Parameter properties class
        /// </summary>
        public Motor_Properties motor_Params { get; set; } = new Motor_Properties();
        public MotorType Type { get; set; }

        public Advantech_PCIE_Stepper(int cardIndex, int Axis, string motor_name, double pulse = 1, Motor_Properties eCodeParams = null)
        {
            _CardIndex = cardIndex;
            Read_Axishand = Axis; // Pass the axis from Created Obj to Local Var.
            Global_pulse = pulse;
            this.motor_Params.name = motor_name;
            // If error code mapping is passed, use it; else assign defaults
            if (eCodeParams != null)
            {
                motor_Params.Positive_limit_error = eCodeParams.Positive_limit_error;
                motor_Params.Negative_limit_error = eCodeParams.Negative_limit_error;
                motor_Params.Driver_error = eCodeParams.Driver_error;
                motor_Params.TimeOut_error = eCodeParams.TimeOut_error;
                motor_Params.Disable_error = eCodeParams.Disable_error;
            }

            //VersionIsOk = GetDevCfgDllDrvVer(); // To check the Dll version 
            //Avlbldvc(); // To get the Available Devices
            //OpenBoard(); // To open the Boad the Get all the Devices.
            //GetHome_methods(); //call the  Method for set the Homming after open the Board.
        }

        public Advantech_PCIE_Stepper(int Axis, string motor_name, double pulse = 1, Motor_Properties eCodeParams = null, int cdno = 0)
        {
            Read_Axishand = Axis; // Pass the axis from Created Obj to Local Var.
            Global_pulse = pulse;
            this.motor_Params.name = motor_name;
            // If error code mapping is passed, use it; else assign defaults
            if (eCodeParams != null)
            {
                motor_Params.Positive_limit_error = eCodeParams.Positive_limit_error;
                motor_Params.Negative_limit_error = eCodeParams.Negative_limit_error;
                motor_Params.Driver_error = eCodeParams.Driver_error;
                motor_Params.TimeOut_error = eCodeParams.TimeOut_error;
                motor_Params.Disable_error = eCodeParams.Disable_error;

            }

            this.cardno = cdno;

            VersionIsOk = GetDevCfgDllDrvVer(); // To check the Dll version 
            Avlbldvc(); // To get the Available Devices
            OpenBoard(); // To open the Boad the Get all the Devices.
            GetHome_methods(); //call the  Method for set the Homming after open the Board.
        }

        /// <summary>
        /// Represents initialization error codes.
        /// </summary>
        public enum InitStatus
        {
            OK,
            DLLVERSION_MISMATCH,
            DEVICE_UNAVAILABLE,
            OPEN_FAIL
        }

        /// <summary>
        /// Initializes the hardware board by performing a series of checks:
        /// - Verifies the DLL driver version.
        /// - Checks for available devices.
        /// - Attempts to open the board.
        /// Returns a status code indicating success or the type of failure encountered.
        /// </summary>
        /// <returns>
        /// An <see cref="InitStatus"/> value indicating the result of the initialization:
        /// - <c>OK</c>: Initialization succeeded.
        /// - <c>DLLVERSION_MISMATCH</c>: DLL version check failed.
        /// - <c>DEVICE_UNAVAILABLE</c>: No device available or accessible.
        /// - <c>OPEN_FAIL</c>: Failed to open the device.
        /// </returns>
        public InitStatus InitBoard_Updated()
        {
            if (!GetDevCfgDllDrvVer())
            {
                return InitStatus.DLLVERSION_MISMATCH;
            }
            if (!Avlbldvc())
            {
                return InitStatus.DEVICE_UNAVAILABLE;
            }
            if (!OpenBoard())
            {
                return InitStatus.OPEN_FAIL;
            }
            return InitStatus.OK;
        }

        public (bool isSuccess, int MethodCode) Init_BoardFunc()
        {
            try
            {
                VersionIsOk = GetDevCfgDllDrvVer();
                if (!VersionIsOk)
                {
                    return (false, 1);
                }
                if (!Avlbldvc())
                {
                    return (false, 2);
                }
                if (!OpenBoard())
                {
                    return (false, 3);
                }
                return (true, 4);
            }
            catch (Exception ex)
            {
                Task<bool> Log_task = Logger.WriteLogasTask(Logger.LogType.Info, "Advantech_PCIE", "Init_BoardFunc()", "", ex.Message);
                return (false, 0);
            }

        }

        /// <summary>
        /// To Set the Axis if required from the Code.
        /// </summary>
        //public void SetAxis(int Axis)
        //{
        //    Read_Axishand = Axis;
        //}

        public bool[] DI_RefreshValue(int len, int InputPort, bool[] DI)
        {
            if (!Inp)
            {
                Inp = true;
                try
                {
                    DiValues = DI;
                    if (m_DeviceHandle != IntPtr.Zero)
                    {
                        uint num = DIChanNum / 8;
                        int num2 = 0;
                        int num3 = 0;
                        byte ByteData = 0;
                        InputOffsetPort = InputPort;
                        for (int i = (int)(num - InputPort); i < num; i++)
                        {
                            if (Motion.mAcm_DaqDiGetByte(m_DeviceHandle, (ushort)i, ref ByteData) != 0)
                            {
                                continue;
                            }

                            for (int j = 0; j < 8 - m_InvalidBitCount; j++)
                            {
                                if (((ByteData >> j) & 1) == 1)
                                {
                                    DiValues[num3] = true;
                                }
                                else
                                {
                                    DiValues[num3] = false;
                                }

                                num3++;
                                num2++;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Logger.WriteLog(Logger.LogType.Error, "Advantech_PCIE", "DI Refresh Values()", "Exception Error", ex.ToString(), default(DateTime), "DI_RefreshValue", 632);
                }

                Inp = false;
                return DiValues;
            }

            return DiValues;
        }

        public bool[] DO_RefreshValue(int len, int OutputPort, bool[] DO)
        {
            if (!Out)
            {
                Out = true;
                try
                {
                    DOValues = DO;
                    if (m_DeviceHandle != IntPtr.Zero)
                    {
                        byte ByteData = 0;
                        uint num = DOChanNum / 8;
                        int num2 = 0;
                        int num3 = 0;
                        for (int i = (int)(num - OutputPort); i < num; i++)
                        {
                            if (Motion.mAcm_DaqDoGetByte(m_DeviceHandle, (ushort)i, ref ByteData) != 0)
                            {
                                continue;
                            }

                            for (int j = 0; j < 8 - m_InvalidBitCount; j++)
                            {
                                if (((ByteData >> j) & 1) == 1)
                                {
                                    DOValues[num2] = true;
                                }
                                else
                                {
                                    DOValues[num2] = false;
                                }

                                num2++;
                            }
                        }
                    }

                    Out = false;
                }
                catch (Exception ex)
                {
                    Logger.WriteLog(Logger.LogType.Error, "Advantech_PCIE", "DO Refresh Values()", "Exception Error", ex.ToString(), default(DateTime), "DO_RefreshValue", 700);
                    Out = false;
                }

                Out = false;
                return DOValues;
            }

            return DOValues;
        }






        #region "Initialization_Startup"

        public static bool DisConnect_Err_bit = false; // To check connection Event
        public static uint IO_DevEnableEvt = 2; // Enbale Event Check passing Parametter
        public static uint Motion_DevEnableEvt = 1; // Enbale Event Check passing Parametter
        public static int DevMotRingDisCnt = 0; // for check connection Event 
        public static int DevIORingDisCnt = 0; // for check connection Event to increase

        public static DEV_LIST[] CurAvailableDevs = new DEV_LIST[Motion.MAX_DEVICES]; // to get the list of current available Devices.
        public static uint deviceCount = 0; // To Store the Available total Available dev Count.
        public uint DeviceNum = 0; // To Pass the DeviceCount to open the Board.
        public static Boolean VersionIsOk = false; // if this is True then for Version is ok then read the available dev.
        public static bool m_bInit = false; // When Open Board Done it will get true based on this we do all other functions.
        public static IntPtr m_DeviceHandle = IntPtr.Zero; // To pass the Value as a Ref

        public static IntPtr[] m_Axishand = new IntPtr[64]; // To pass the Axis and store the Value.
        public static uint m_ulAxisCount = 0; //TO store the Total Axis Count.
        public static String[] Axes = new string[24]; //For store the Axis in OpenBoard //Arul
        public static String[] JogPAssgn = new string[1000];
        public static String[] JogNAssgn = new string[1000];

        public static uint DIChanNum = 0; // To get the Input in Board pass as a ref.
        public static uint DOChanNum = 128; // To get the Output in Board pass as a ref

        #endregion

        #region "Initialization_Board"

        public static int m_InvalidBitCount = 0; // To Pass the Zero Count for For Loop
        public static bool m_bServoOn = false; // this will true when sero is on other wise its false
        public static IntPtr m_GpHand = IntPtr.Zero; // for interpolation        
        public static uint AxCountInGp = 0; // For interpolation
        public static uint[] AxisArray = new uint[64]; // Add lsit of interpolation Axis                
        public static bool m_IsGpOpen = false; // Add_Axis_For_Interpoll result sucess it will get true.
        public static string[] grpvelparam = new string[10]; // To Return the Group Vel Param.        
        public static string[] cur_pos_N = new string[4]; // to read the CurrentPos_Nozzle
        public static double[] cur_posG = new double[2];   // To Get CurrentPos_Gantry        
        public static bool[] DiValues; // To Read the DI Value and Stored in Array
        public static bool[] DOValues; // To Read the DO Value and Stored in Array
        public static uint AINumber = 0; // For store the AI list number.
        public static double[] Aivalues = new double[5]; // Refresh the AI setup and store the value
        public static bool m_SelectedDI = false;

        #endregion

        #region "Board_Configuration"

        /// <summary>
        /// This method checks the version of the ADVMOT.dll located in the system directory.
        /// </summary>
        /// <returns>If the version is valid, it returns true. Otherwise, it returns false.</returns>
        public Boolean GetDevCfgDllDrvVer()
        {
            // This method checks the version of the ADVMOT.dll located in the system directory.
            // If the driver version is lower than 2.0.0.0, it logs a message indicating the driver is outdated
            // and suggests updating it to version 2.0.0.0 or higher.
            // If the version is valid, it returns true. Otherwise, it returns false.
            // Any exceptions encountered during the process are logged, and the method returns false.

            try
            {
                string fileName = "";
                FileVersionInfo myFileVersionInfo;
                string FileVersion = "";
                fileName = Environment.SystemDirectory + "\\ADVMOT.dll";//SystemDirectory指System32 
                myFileVersionInfo = FileVersionInfo.GetVersionInfo(fileName);
                FileVersion = myFileVersionInfo.FileVersion;
                string DetailMessage;
                string[] strSplit = FileVersion.Split(',');

                if (Convert.ToUInt16(strSplit[0]) < 2)
                {
                    DetailMessage = "The Driver Version  Is Too Low" + "\r\nYou can update the driver through the driver installation package ";
                    DetailMessage = DetailMessage + "\r\nThe Current Driver Version Number is " + FileVersion;
                    DetailMessage = DetailMessage + "\r\nYou need to update the driver to 2.0.0.0 version and above";
                    Task<bool> Log_task = Logger.WriteLogasTask(Logger.LogType.Info, "Advantech_PCIE", "GetDevCfgDllDrvVer()", "", DetailMessage);
                    ExceptionLib.ErrorManage s = new ExceptionLib.ErrorManage();
                    s.AlarmHappen = true;
                    return false;

                }
                VersionIsOk = true;
                return true;
            }
            catch (Exception es)
            {
                Logger.WriteLog(Logger.LogType.Error, "Advantech_PCIE", "GetDevCfgDllDrvVer()", "Exception Error", es.ToString());
                return false;
            }

        }
        /// <summary>
        /// enable the Device Connections 
        /// </summary>
        /// <returns></returns>
        public bool Enable_check_Device_Connection()
        {
            bool process = false;
            uint Result = 0;
            try
            {
                Result = Motion.mAcm_DevEnableEvent(m_DeviceHandle, (uint)PropertyID.FT_DaqDiMaxChan);
                if (Result != (uint)ErrorCode.SUCCESS)
                {
                    string strTemp = "Enable Device check Event Failed With Error Code[0x" + Convert.ToString(Result, 16) + "]";
                    Logger.ShowMessages(strTemp, Result, "Enable_check_Device_Connection()");
                }
                else
                {
                    process = true;
                }
                return process;
            }
            catch (Exception es)
            {
                Logger.WriteLog(Logger.LogType.Error, "Advantech_PCIE", "Enable_check_Device_Connection()", "Exception Error", es.ToString());
                // AdvanTechPCIE.WriteLog("Device_Interface", "Enable_check_Device_Connection", "PCIE-1203_Interface", "Exception Error", es.ToString());
                return process;
            }

        }
        /// <summary>
        /// This method for check the device connection 
        /// </summary>
        /// <returns>If the version is valid, it returns true. Otherwise, it returns false.</returns>
        public void check_Device_Connection(object sender)
        {
            bool process = false;
            uint Result = 0;
            try
            {
                uint checkevent = (uint)PropertyID.FT_DaqDiMaxChan;
                Result = Motion.mAcm_DevCheckEvent(m_DeviceHandle, ref checkevent, 10);

                if (Result != (uint)ErrorCode.SUCCESS)
                {
                    string strTemp = "Check Device Connection Failed With Error Code[0x" + Convert.ToString(Result, 16) + "]";
                    Logger.ShowMessages(strTemp, Result, "check_Device_Connection()");
                }
                else
                {
                    process = true;

                }
            }
            catch (Exception es)
            {
                Logger.WriteLog(Logger.LogType.Error, "Advantech_PCIE", "check_Device_Connection()", "Exception Error", es.ToString());
                //AdvanTechPCIE.WriteLog("Device_Interface", "check_Device_Connection()", "PCIE-1203_Interface", "Exception Error", es.ToString());
                return;
            }

            return;
        }
        /// <summary>
        /// Checks if the driver version is valid and retrieves available motion devices.
        /// </summary>
        /// <returns>Return true, when procees completed other wise false</returns>
        public bool Avlbldvc1()
        {
            // Checks if the driver version is valid and retrieves available motion devices.

            try
            {
                int Result;
                string strTemp;
                if (VersionIsOk == false)
                {
                    return false;
                }
                // Get the list of available device numbers and names of devices, of which driver has been loaded successfully 
                //If you have two/more board,the device list(m_avaDevs) may be changed when the slot of the boards changed,for example:m_avaDevs[0].szDeviceName to PCI-1245
                //m_avaDevs[1].szDeviceName to PCI-1245L,changing the slot，Perhaps the opposite
                Result = Motion.mAcm_GetAvailableDevs(CurAvailableDevs, Motion.MAX_DEVICES, ref deviceCount);
                if (Result != (int)ErrorCode.SUCCESS)
                {
                    strTemp = "Get Device Numbers Failed With Error Code: [0x" + Convert.ToString(Result, 16) + "]";
                    // ShowMessages(strTemp, (uint)Result);
                    Logger.ShowMessages(strTemp, (uint)Result, "Onload()");
                    return false;
                }
                //If you want to get the device number of fixed equipment，you also can achieve it By adding the API:GetDevNum(UInt32 DevType, UInt32 BoardID, UInt32 MasterRingNo, UInt32 SlaveBoardID),
                //The API is defined and illustrates the way of using in this example,but it is not called,you can copy it to your program and
                //don't need to call Motion.mAcm_GetAvailableDevs(CurAvailableDevs, Motion.MAX_DEVICES, ref deviceCount)
                //GetDevNum(UInt32 DevType, UInt32 BoardID, UInt32 MasterRingNo, UInt32 SlaveBoardID) API Variables are stated below:
                //UInt32 DevType : Set Device Type ID of your motion card plug in PC. (Definition is in ..\Public\AdvMotDev.h)
                //UInt32 BoardID : Set Hardware Board-ID of your motion card plug in PC,you can get it from Utility
                //UInt32 MasterRingNo: PCI-Motion card, Always set to 0
                //UInt32 SlaveBoardID : PCI-Motion card,Always set to 0

                if (deviceCount > 0)
                {
                    DeviceNum = CurAvailableDevs[cardno].DeviceNum;
                }
                //Task<bool> Log_task = Logger.WriteLogasTask(Logger.LogType.Error, "Advantech_PCIE", "ServoOFF_All_Axis()", "Successfull", "No error");
                return true;
            }
            catch (Exception es)
            {
                Logger.WriteLog(Logger.LogType.Error, "Advantech_PCIE", "Avlbldvc()", "Exception Error", es.ToString());
                //AdvanTechPCIE.WriteLog("Device_Interface", "Avlbldvc()", "PCIE-1203_Interface", "Exception Error", es.ToString());
                return false;
            }
        }

        //public static DEV_LIST[] CurAvailableDevs = new DEV_LIST[Motion.MAX_DEVICES]; // to get the list of current available Devices.

        public bool Avlbldvc()
        {
            // Checks if the driver version is valid and retrieves available motion devices.

            try
            {
                int Result;
                string strTemp;
                if (VersionIsOk == false)
                {
                    return false;
                }
                // Get the list of available device numbers and names of devices, of which driver has been loaded successfully 
                //If you have two/more board,the device list(m_avaDevs) may be changed when the slot of the boards changed,for example:m_avaDevs[0].szDeviceName to PCI-1245
                //m_avaDevs[1].szDeviceName to PCI-1245L,changing the slot，Perhaps the opposite
                Result = Motion.mAcm_GetAvailableDevs(CurAvailableDevs, Motion.MAX_DEVICES, ref deviceCount);
                if (Result != (int)ErrorCode.SUCCESS)
                {
                    strTemp = "Get Device Numbers Failed With Error Code: [0x" + Convert.ToString(Result, 16) + "]";
                    // ShowMessages(strTemp, (uint)Result);
                    Logger.ShowMessages(strTemp, (uint)Result, "Onload()");
                    return false;
                }
                //If you want to get the device number of fixed equipment，you also can achieve it By adding the API:GetDevNum(UInt32 DevType, UInt32 BoardID, UInt32 MasterRingNo, UInt32 SlaveBoardID),
                //The API is defined and illustrates the way of using in this example,but it is not called,you can copy it to your program and
                //don't need to call Motion.mAcm_GetAvailableDevs(CurAvailableDevs, Motion.MAX_DEVICES, ref deviceCount)
                //GetDevNum(UInt32 DevType, UInt32 BoardID, UInt32 MasterRingNo, UInt32 SlaveBoardID) API Variables are stated below:
                //UInt32 DevType : Set Device Type ID of your motion card plug in PC. (Definition is in ..\Public\AdvMotDev.h)
                //UInt32 BoardID : Set Hardware Board-ID of your motion card plug in PC,you can get it from Utility
                //UInt32 MasterRingNo: PCI-Motion card, Always set to 0
                //UInt32 SlaveBoardID : PCI-Motion card,Always set to 0

                if (_CardIndex <= deviceCount)
                {
                    DeviceNum = CurAvailableDevs[_CardIndex].DeviceNum;
                }
                Task<bool> Log_task = Logger.WriteLogasTask(Logger.LogType.Error, "Advantech_PCIE", "ServoOFF_All_Axis()", "Successfull", "No error");
                return true;
            }
            catch (Exception es)
            {
                Logger.WriteLog(Logger.LogType.Error, "Advantech_PCIE", "Avlbldvc()", "Exception Error", es.ToString());
                //AdvanTechPCIE.WriteLog("Device_Interface", "Avlbldvc()", "PCIE-1203_Interface", "Exception Error", es.ToString());
                return false;
            }
        }
        /// <summary>
        /// Opens the motion control board and initializes device, axes, and I/O channels.
        /// </summary>
        /// <returns></returns>
        /// 

        public bool OpenBoard()
        {
            // Opens the motion control board and initializes device, axes, and I/O channels.

            try
            {
                uint Result;
                int i = 0;
                uint retry = 0, SlaveOnRing0 = 0, SlaveOnRing1 = 0;
                bool rescan = false;
                uint AxesPerDev = new uint();
                string strTemp;

                //Open a specified device to get device handle
                //you can call GetDevNum() API to get the devcie number of fixed equipment in this,as follow
                //DeviceNum = GetDevNum((uint)DevTypeID.PCI1285, 15, 0, 0);
                do
                {

                    Result = Motion.mAcm_DevOpen(DeviceNum, ref m_DeviceHandle);


                    if (Result != (uint)ErrorCode.SUCCESS)
                    {
                        strTemp = "Open Device Failed With Error Code[0x" + Convert.ToString(Result, 16) + "]";
                        Logger.ShowMessages(strTemp, Result, "OpenBoard()");

                        retry++;
                        rescan = true;
                        if (retry > 10)
                            return false;
                    }
                    else
                    {
                        //User must check the slave count on each ring match the actual connection.
                        //We recommend using following code that was marked to check connection status.
                        //The example expect there is one slave on Motion ring and user does not connect any slave on IO ring.
                        rescan = false;
                        /*Result = Motion.mAcm_GetU32Property(m_DeviceHandle, (uint)PropertyID.FT_MasCyclicCnt_R0, ref SlaveOnRing0);
                        Result = Motion.mAcm_GetU32Property(m_DeviceHandle, (uint)PropertyID.FT_MasCyclicCnt_R1, ref SlaveOnRing1);
                        if (SlaveOnRing0 != 1 || SlaveOnRing1 != 0)
                        {
                            strTemp = "Retrieved the slave states do not match the actual connection.";
                            ShowMessages(strTemp, Result);
                            Motion.mAcm_DevReOpen(m_DeviceHandle);
                            Motion.mAcm_DevClose(ref m_DeviceHandle);
                            System.Threading.Thread.Sleep(1000);
                            retry = 0;
                            rescan = true;
                        }*/
                    }
                } while (rescan == true);
                //Load Mapping Table
                //Result = Motion.mAcm_DevLoadMapFile(m_DeviceHandle, System.IO.Directory.GetCurrentDirectory() +
                //    @"/Data/MappingTable.xml");
                //if (Result != (uint)ErrorCode.SUCCESS)
                //{
                //    strTemp = "Load Mapping Table Failed With Error Code: [0x" + Convert.ToString(Result, 16) + "]";
                //    Task<bool> Log_task = Logger.WriteLogasTask(Logger.LogType.Error, "Advantech_PCIE", "OpenBoard()", "Execution Error", strTemp);

                //    return false;
                //}
                //FT_DevAxesCount:Get axis number of this device.
                //if you device is fixed(for example: PCI-1245),You can not get FT_DevAxesCount property value
                //This step is not necessary
                //You can also use the old API: Motion.mAcm_GetProperty(m_DeviceHandle, (uint)PropertyID.FT_DevAxesCount, ref AxesPerDev, ref BufferLength);
                // UInt32 BufferLength;
                //BufferLength =4;  buffer size for the property
                Result = Motion.mAcm_GetU32Property(m_DeviceHandle, (uint)PropertyID.FT_DevAxesCount, ref AxesPerDev);
                if (Result != (uint)ErrorCode.SUCCESS)
                {
                    strTemp = "Get Axis Number Failed With Error Code: [0x" + Convert.ToString(Result, 16) + "]";
                    //ShowMessages(strTemp, Result);
                    Task<bool> Log_task = Logger.WriteLogasTask(Logger.LogType.Error, "Advantech_PCIE", "OpenBoard()", "Execution Error", strTemp);

                    return false;
                }
                m_ulAxisCount = AxesPerDev;
                Axiscount = (int)m_ulAxisCount;
                for (i = 0; i < m_ulAxisCount; i++)
                {
                    //Open every Axis and get the each Axis Handle
                    //And Initial property for each Axis 		
                    // Open Axis. The second parameter is the position of this axis.
                    // The first axis is 0, the second one is 1 and so on.
                    Result = Motion.mAcm_AxOpen(m_DeviceHandle, (UInt16)i, ref m_Axishand[i]);
                    // Another way to open axis is "Motion.mAcm_AxOpenbyID" . 
                    // The second parameter of mAcm_AxOpenbyID is the EtherCAT Slave ID
                    if (Result != (uint)ErrorCode.SUCCESS)
                    {
                        strTemp = "Open Axis Failed With Error Code: [0x" + Convert.ToString(Result, 16) + "]";
                        //   ShowMessages(strTemp, Result);
                        Logger.ShowMessages("ServoProcess", Result, "OpenBoard()");

                        return false;
                    }
                    //CmbAxes.Items.Add(String.Format("{0:d}-Axis", i));
                    Axes[i] = String.Format("{0:d}-Axis", i);

                    //Reset Command Counter
                    //double cmdPosition = new double();
                    //cmdPosition = 0;
                    //Set command position for the specified axis
                    //Motion.mAcm_AxSetCmdPosition(m_Axishand[i], cmdPosition);

                }

                //Get DI maximum number of channel
                Result = Motion.mAcm_GetU32Property(m_DeviceHandle, (uint)PropertyID.FT_DaqDiMaxChan, ref DIChanNum);
                if (Result != (uint)ErrorCode.SUCCESS)
                {
                    strTemp = "Get Property FT_DaqDiMaxChan Failed With Error Code: [0x" + Convert.ToString(Result, 16) + "]";
                    Task<bool> Log_task = Logger.WriteLogasTask(Logger.LogType.Error, "Advantech_PCIE", "OpenBoard()", "Execution Error", strTemp);

                    return false;
                }
                DIchannelnum = (int)DIChanNum;
                for (i = 0; i < DIChanNum; i++)
                {
                    JogPAssgn[i] = i.ToString();
                    JogNAssgn[i] = i.ToString();
                }
                Result = Motion.mAcm_GetU32Property(m_DeviceHandle, (uint)PropertyID.FT_DaqDoMaxChan, ref DOChanNum);
                if (Result != (uint)ErrorCode.SUCCESS)
                {
                    strTemp = "Get Property FT_DaqDOMaxChan Failed With Error Code: [0x" + Convert.ToString(Result, 16) + "]";
                    Task<bool> Log_task = Logger.WriteLogasTask(Logger.LogType.Error, "Advantech_PCIE", "OpenBoard()", "Execution Error", strTemp);
                    return false;
                }

                //if (DIChanNum > 0)
                //{

                //}
                m_bInit = true;
                //ResetError();
                //  ServoOn();
                // Interface.Interpol_Axis();
                //CmbAxes.SelectedIndex = 0;

                GetHome_methods();
                return true;
            }
            catch (Exception es)
            {
                Logger.WriteLog(Logger.LogType.Error, "Advantech_PCIE", "OpenBoard()", "Exception Error", es.ToString());
                // AdvanTechPCIE.WriteLog("Device_Interface", "OpenBoard()", "PCIE-1203_Interface", "Exception Error", es.ToString());
                return false;
            }

            // timer1.Enabled = true;
        }
        //public bool OpenBoard()
        //{
        //    // Opens the motion control board and initializes device, axes, and I/O channels.

        //    try
        //    {
        //        uint Result;
        //        int i = 0;
        //        uint retry = 0, SlaveOnRing0 = 0, SlaveOnRing1 = 0;
        //        bool rescan = false;
        //        uint AxesPerDev = new uint();
        //        string strTemp;

        //        //Open a specified device to get device handle
        //        //you can call GetDevNum() API to get the devcie number of fixed equipment in this,as follow
        //        //DeviceNum = GetDevNum((uint)DevTypeID.PCI1285, 15, 0, 0);
        //        do
        //        {
        //            Result = Motion.mAcm_DevOpen(DeviceNum[cardno], ref m_DeviceHandle);

        //            if (Result != (uint)ErrorCode.SUCCESS)
        //            {
        //                strTemp = "Open Device Failed With Error Code[0x" + Convert.ToString(Result, 16) + "]";
        //                Logger.ShowMessages(strTemp, Result, "OpenBoard()");

        //                retry++;
        //                rescan = true;
        //                if (retry > 10)
        //                    return false;
        //            }
        //            else
        //            {
        //                //User must check the slave count on each ring match the actual connection.
        //                //We recommend using following code that was marked to check connection status.
        //                //The example expect there is one slave on Motion ring and user does not connect any slave on IO ring.
        //                rescan = false;
        //                /*Result = Motion.mAcm_GetU32Property(m_DeviceHandle, (uint)PropertyID.FT_MasCyclicCnt_R0, ref SlaveOnRing0);
        //                Result = Motion.mAcm_GetU32Property(m_DeviceHandle, (uint)PropertyID.FT_MasCyclicCnt_R1, ref SlaveOnRing1);
        //                if (SlaveOnRing0 != 1 || SlaveOnRing1 != 0)
        //                {
        //                    strTemp = "Retrieved the slave states do not match the actual connection.";
        //                    ShowMessages(strTemp, Result);
        //                    Motion.mAcm_DevReOpen(m_DeviceHandle);
        //                    Motion.mAcm_DevClose(ref m_DeviceHandle);
        //                    System.Threading.Thread.Sleep(1000);
        //                    retry = 0;
        //                    rescan = true;
        //                }*/
        //            }
        //        } while (rescan == true);
        //        //Load Mapping Table
        //        //Result = Motion.mAcm_DevLoadMapFile(m_DeviceHandle, System.IO.Directory.GetCurrentDirectory() +
        //        //    @"/Data/MappingTable.xml");
        //        //if (Result != (uint)ErrorCode.SUCCESS)
        //        //{
        //        //    strTemp = "Load Mapping Table Failed With Error Code: [0x" + Convert.ToString(Result, 16) + "]";
        //        //    Task<bool> Log_task = Logger.WriteLogasTask(Logger.LogType.Error, "Advantech_PCIE", "OpenBoard()", "Execution Error", strTemp);

        //        //    return false;
        //        //}
        //        //FT_DevAxesCount:Get axis number of this device.
        //        //if you device is fixed(for example: PCI-1245),You can not get FT_DevAxesCount property value
        //        //This step is not necessary
        //        //You can also use the old API: Motion.mAcm_GetProperty(m_DeviceHandle, (uint)PropertyID.FT_DevAxesCount, ref AxesPerDev, ref BufferLength);
        //        // UInt32 BufferLength;
        //        //BufferLength =4;  buffer size for the property
        //        Result = Motion.mAcm_GetU32Property(m_DeviceHandle, (uint)PropertyID.FT_DevAxesCount, ref AxesPerDev);
        //        if (Result != (uint)ErrorCode.SUCCESS)
        //        {
        //            strTemp = "Get Axis Number Failed With Error Code: [0x" + Convert.ToString(Result, 16) + "]";
        //            //ShowMessages(strTemp, Result);
        //            Task<bool> Log_task = Logger.WriteLogasTask(Logger.LogType.Error, "Advantech_PCIE", "OpenBoard()", "Execution Error", strTemp);

        //            return false;
        //        }
        //        m_ulAxisCount = AxesPerDev;
        //        Axiscount = (int)m_ulAxisCount;
        //        for (i = 0; i < m_ulAxisCount; i++)
        //        {
        //            //Open every Axis and get the each Axis Handle
        //            //And Initial property for each Axis 		
        //            // Open Axis. The second parameter is the position of this axis.
        //            // The first axis is 0, the second one is 1 and so on.
        //            Result = Motion.mAcm_AxOpen(m_DeviceHandle, (UInt16)i, ref m_Axishand[i]);
        //            // Another way to open axis is "Motion.mAcm_AxOpenbyID" . 
        //            // The second parameter of mAcm_AxOpenbyID is the EtherCAT Slave ID
        //            if (Result != (uint)ErrorCode.SUCCESS)
        //            {
        //                strTemp = "Open Axis Failed With Error Code: [0x" + Convert.ToString(Result, 16) + "]";
        //                //   ShowMessages(strTemp, Result);
        //                Logger.ShowMessages("ServoProcess", Result, "OpenBoard()");

        //                return false;
        //            }
        //            //CmbAxes.Items.Add(String.Format("{0:d}-Axis", i));
        //            Axes[i] = String.Format("{0:d}-Axis", i);

        //            //Reset Command Counter
        //            //double cmdPosition = new double();
        //            //cmdPosition = 0;
        //            //Set command position for the specified axis
        //            //Motion.mAcm_AxSetCmdPosition(m_Axishand[i], cmdPosition);

        //        }

        //        //Get DI maximum number of channel
        //        Result = Motion.mAcm_GetU32Property(m_DeviceHandle, (uint)PropertyID.FT_DaqDiMaxChan, ref DIChanNum);
        //        if (Result != (uint)ErrorCode.SUCCESS)
        //        {
        //            strTemp = "Get Property FT_DaqDiMaxChan Failed With Error Code: [0x" + Convert.ToString(Result, 16) + "]";
        //            Task<bool> Log_task = Logger.WriteLogasTask(Logger.LogType.Error, "Advantech_PCIE", "OpenBoard()", "Execution Error", strTemp);

        //            return false;
        //        }
        //        DIchannelnum = (int)DIChanNum;
        //        for (i = 0; i < DIChanNum; i++)
        //        {
        //            JogPAssgn[i] = i.ToString();
        //            JogNAssgn[i] = i.ToString();
        //        }
        //        Result = Motion.mAcm_GetU32Property(m_DeviceHandle, (uint)PropertyID.FT_DaqDoMaxChan, ref DOChanNum);
        //        if (Result != (uint)ErrorCode.SUCCESS)
        //        {
        //            strTemp = "Get Property FT_DaqDOMaxChan Failed With Error Code: [0x" + Convert.ToString(Result, 16) + "]";
        //            Task<bool> Log_task = Logger.WriteLogasTask(Logger.LogType.Error, "Advantech_PCIE", "OpenBoard()", "Execution Error", strTemp);
        //            return false;
        //        }

        //        //if (DIChanNum > 0)
        //        //{

        //        //}
        //        m_bInit = true;
        //        //ResetError();
        //        //  ServoOn();
        //        // Interface.Interpol_Axis();
        //        //CmbAxes.SelectedIndex = 0;

        //        GetHome_methods();
        //        return true;
        //    }
        //    catch (Exception es)
        //    {
        //        Logger.WriteLog(Logger.LogType.Error, "Advantech_PCIE", "OpenBoard()", "Exception Error", es.ToString());
        //        // AdvanTechPCIE.WriteLog("Device_Interface", "OpenBoard()", "PCIE-1203_Interface", "Exception Error", es.ToString());
        //        return false;
        //    }

        //    // timer1.Enabled = true;
        //}
        /// <summary>
        /// Call this function to close a device
        /// </summary>
        /// <returns>Its Return Bool if device closed means its return true otherwise false</returns>
        public bool CloseBoard()
        {
            try
            {
                if (m_bInit)
                {
                    //Close a device

                    Motion.mAcm_DevClose(ref m_DeviceHandle);

                    m_bInit = false;
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception es)
            {
                Logger.WriteLog(Logger.LogType.Error, "Advantech_PCIE", "CloseBoard()", "Exception Error", es.ToString());
                //AdvanTechPCIE.WriteLog("Device_Interface", "CloseBoard()", "PCIE-1203_Interface", "Exception Error", es.ToString());
                return false;
            }

        }

        #endregion


        //bool s = false;
        //ReadSelectedDI(0, ref s);
        public bool ReadSelectedDI(ushort DIBit, ref bool Status)
        {
            if (!Inp)
            {
                Inp = true;
                try
                {
                    byte BItData = 0;
                    if (m_DeviceHandle != IntPtr.Zero)
                    {
                        uint DIPortNumber = (uint)(DIChanNum / 8 - InputOffsetPort);

                        DIBit = (ushort)(DIPortNumber * 8 + DIBit);

                        uint Result = Motion.mAcm_DaqDiGetBit(m_DeviceHandle, DIBit, ref BItData);
                        if (Result == (uint)ErrorCode.SUCCESS)
                        {
                            Status = Convert.ToBoolean(BItData);
                        }
                        else
                        {
                            Status = Convert.ToBoolean(Result);
                        }

                    }

                }
                catch (Exception ex)
                {
                    return false;
                }
                return Status;
            }
            return Status;
        }

        static bool Inp = false;
        static bool Out = false;
        public bool[] DI_RefreshValueNew(int len, int InputPort, ref bool[] DiValues)
        {
            if (!Inp)
            {
                Inp = true;
                try
                {
                    if (m_DeviceHandle != IntPtr.Zero)
                    {
                        uint num = DIChanNum / 8;
                        int num2 = 0;
                        int num3 = 0;
                        byte ByteData = 0;
                        InputOffsetPort = InputPort;
                        for (int i = (int)(num - InputPort); i < num; i++)
                        {
                            if (Motion.mAcm_DaqDiGetByte(m_DeviceHandle, (ushort)i, ref ByteData) != 0)
                            {
                                continue;
                            }

                            for (int j = 0; j < 8 - m_InvalidBitCount; j++)
                            {
                                if (((ByteData >> j) & 1) == 1)
                                {
                                    DiValues[num3] = true;
                                }
                                else
                                {
                                    DiValues[num3] = false;
                                }

                                num3++;
                                num2++;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Logger.WriteLog(Logger.LogType.Error, "Advantech_PCIE", "DI Refresh Values()", "Exception Error", ex.ToString(), default(DateTime), "DI_RefreshValueNew", 726);
                }

                Inp = false;
                return DiValues;
            }

            return DiValues;
        }


        #region "DI"
        /// <summary>
        /// Read the DI From Machine Via Motion Card in particular time interval.
        /// </summary>
        /// <returns>Its Return Bool if device closed means its return true otherwise false</returns>
        public bool[] DI_RefreshValue(int len, int InputPort)
        {
            if (!Inp)
            {
                Inp = true;
                try
                {
                    DiValues = new bool[len];
                    if (m_DeviceHandle != IntPtr.Zero)
                    {
                        uint DIPortNumber = DIChanNum / 8;

                        int k = 0;
                        int l = 0;
                        byte DiStatus = 0;

                        InputOffsetPort = InputPort;

                        //for (int j = (int)(DIPortNumber - 8); j < DIPortNumber; j++)//j=17 - check why read only 8 ports
                        for (int j = (int)(DIPortNumber - InputPort); j < DIPortNumber; j++)//j=17 - check why read only 8 ports
                        //for (int j = 0; j < DIPortNumber; j++)//j=17 - check why read only 8 ports
                        {
                            uint Result = Motion.mAcm_DaqDiGetByte(m_DeviceHandle, (ushort)j, ref DiStatus);
                            if (Result == (uint)ErrorCode.SUCCESS)
                            {
                                for (int i = 0; i < 8 - m_InvalidBitCount; i++)
                                {
                                    // if (k > 128)//ADD 33 FOR EVERY SERVO NOW 4 SERVOS 128
                                    // {
                                    if (((DiStatus >> i) & 0x01) == 1)
                                    {
                                        DiValues[l] = true;
                                    }
                                    else
                                    {
                                        DiValues[l] = false;
                                    }
                                    l = l + 1;
                                    // }

                                    k = k + 1;
                                }
                            }
                        }
                    }

                }
                catch (Exception es)
                {
                    Logger.WriteLog(Logger.LogType.Error, "Advantech_PCIE", "DI Refresh Values()", "Exception Error", es.ToString());
                    //AdvanTechPCIE.WriteLog("Device_Interface", "DI Refresh Values()", "PCIE-1203_Interface", "Exception Error", es.ToString());                    
                }
                Inp = false;
                return DiValues;
            }

            return DiValues;

        }


        #endregion

        #region "DO"
        /// <summary>
        /// Read the DO From Machine Via Motion Card in particular time interval.
        /// </summary>
        /// <returns>Its Return Bool if device closed means its return true otherwise false</returns>
        public bool[] DO_RefreshValue(int len, int OutputPort)
        {
            if (!Out)
            {
                Out = true;
                try
                {
                    DOValues = new bool[len];
                    if (m_DeviceHandle != IntPtr.Zero)
                    {
                        byte DOStatus = 0;
                        uint DOPortNumber = DOChanNum / 8;
                        int k = 0;
                        int l = 0;


                        for (int j = (int)(DOPortNumber - OutputPort); j < DOPortNumber; j++) // - check why read only 8 ports
                        //for (int j = 0; j < DOPortNumber; j++) // - check why read only 8 ports
                        {
                            uint Result = Motion.mAcm_DaqDoGetByte(m_DeviceHandle, (ushort)j, ref DOStatus);
                            if (Result == (uint)ErrorCode.SUCCESS)
                            {
                                for (int i = 0; i < 8 - m_InvalidBitCount; i++)
                                {
                                    if (((DOStatus >> i) & 0x01) == 1)
                                    {
                                        DOValues[k] = true;
                                        //Set Mark
                                        //((PictureBox)DOLedArray[i]).BorderStyle = BorderStyle.Fixed3D;    //BorderStyle
                                    }
                                    else
                                    {
                                        //BorderStyle
                                        DOValues[k] = false;
                                    }
                                    k = k + 1;

                                }

                            }
                        }
                    }
                    Out = false;

                }

                catch (Exception es)
                {
                    Logger.WriteLog(Logger.LogType.Error, "Advantech_PCIE", "DO Refresh Values()", "Exception Error", es.ToString());
                    //AdvanTechPCIE.WriteLog("Device_Interface", "DO Refresh Values()", "PCIE-1203_Interface", "Exception Error", es.ToString());
                    Out = false;
                    //  return DOValues;
                }
                Out = false;
                return DOValues;
            }

            return DOValues;

        }
        /// <summary>
        ///  Switch on the Required Out to get the Input from WriteOps.
        /// </summary>
        /// <returns>Its Return Bool if device closed means its return true otherwise false</returns>
        public bool Write_DO(int value, ushort DOChannel)
        {
            //   WriteDo(values1, (ushort)(1 * 8 + opnum));
            try
            {
                UInt32 Result;
                byte DoValue;
                uint DOHex;
                if (value == 0)
                    return false;
                if ((uint)value == 1)
                {
                    DoValue = 0;
                }
                else
                {
                    DoValue = 1;
                }

                Result = Motion.mAcm_DaqDoSetBit(m_DeviceHandle, DOChannel, DoValue);
                if (Result != (uint)ErrorCode.SUCCESS)
                {
                    StringBuilder ErrorMsg = new StringBuilder("", 100);
                    Boolean res = Motion.mAcm_GetErrorMessage(Result, ErrorMsg, 100);
                    string ErrorMessage = "";
                    if (res)
                        ErrorMessage = ErrorMsg.ToString();
                    int m_Port = DOChannel / 8;
                    int m_Bit = DOChannel % 8;
                    string msg = "Set Port" + m_Port.ToString() + " Bit" + m_Bit.ToString() + " DO Failed with Error Code=[0x" + Convert.ToString(Result, 16) + "]:" + ErrorMessage;
                    Logger.WriteLog(Logger.LogType.Error, "Advantech_PCIE", "Write_DO()", "Execution Error", msg);
                    //AdvanTechPCIE.WriteLog("Device_Interface", "Write_DO()", "PCIE-1203_Interface", "Execution Error", msg);
                    return false;
                }

                return true;
            }
            catch (Exception es)
            {
                Logger.WriteLog(Logger.LogType.Error, "Advantech_PCIE", "Write_DO()", "Exception Error", es.ToString());
                //AdvanTechPCIE.WriteLog("Device_Interface", "Write_DO()", "PCIE-1203_Interface", "Exception Error", es.ToString());
                return false;
            }

        }
        #endregion

        #region "AI"
        static bool AI_ref = false;
        /// <summary>
        ///  RefreshAISetup
        /// </summary>        
        /// <returns>Its Return Bool Value</returns>
        public bool RefreshAISetup(bool IsInitial)
        {
            if (!AI_ref)
            {
                try
                {
                    string[] subItems = new string[4];
                    uint Ret = 0;
                    double m_AiEnable = 0;
                    double m_AiRange = 0;
                    double m_AiIntTime = 0;
                    float m_AiValue = 0;
                    string strAiRange = "";
                    string strAiIntTime = "";
                    string ErrorMessage = "";
                    uint m_FtAiMaxChan = 0;

                    Ret = Motion.mAcm_GetU32Property(m_DeviceHandle, (uint)PropertyID.FT_DaqAiMaxDiffChan, ref m_FtAiMaxChan);
                    AINumber = m_FtAiMaxChan;
                    if (IsInitial)
                    {
                        for (int i = 0; i < AINumber; i++)
                        {
                            subItems[0] = "CH-" + i.ToString();
                        }
                    }
                    for (int i = 0; i < AINumber; i++)
                    {

                        Ret = Motion.mAcm_GetChannelProperty(m_DeviceHandle, (uint)i, (uint)PropertyID.CFG_CH_DaqAiEnable, ref m_AiEnable);
                        /*if (Ret != (uint)ErrorCode.SUCCESS)
                        {
                            ErrorMessage = GlobalVarr.GetErrorMessage(Ret);
                            MessageBox.Show("Channel " + i.ToString() + " Get AiEnable Property failed with Error Code=[0x" + Convert.ToString(Ret, 16) + "]:" + ErrorMessage, "Advantech Common Motion Utility", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                           //return;
                        }*/
                        Ret = Motion.mAcm_GetChannelProperty(m_DeviceHandle, (uint)i, (uint)PropertyID.CFG_CH_DaqAiRange, ref m_AiRange);
                        if (Ret != (uint)ErrorCode.SUCCESS)
                        {
                            Logger.ShowMessages("", Ret, "RefreshAISetup()");
                            // MessageBox.Show("Channel " + i.ToString() + " Get AiRange Property failed with Error Code=[0x" + Convert.ToString(Ret, 16) + "]:" + ErrorMessage, "Advantech Common Motion Utility", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                            //  return false;
                        }
                        Ret = Motion.mAcm_GetChannelProperty(m_DeviceHandle, (uint)i, (uint)PropertyID.CFG_CH_DaqAiIntegrationTime, ref m_AiIntTime);
                        /*if (Ret != (uint)ErrorCode.SUCCESS)
                        {
                            ErrorMessage = GlobalVarr.GetErrorMessage(Ret);
                            MessageBox.Show("Channel " + i.ToString() + " Get AiIntegrationTime Property failed with Error Code=[0x" + Convert.ToString(Ret, 16) + "]:" + ErrorMessage, "Advantech Common Motion Utility", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                           // return;
                        }*/

                        m_AiRange = (uint)AiRange.AI_NEG_0_TO_10V;


                        Ret = Motion.mAcm_SetChannelProperty(m_DeviceHandle, (uint)i, (uint)PropertyID.CFG_CH_DaqAiRange, m_AiRange);
                        if (Ret != (uint)ErrorCode.SUCCESS)
                        {
                            Logger.ShowMessages("", Ret, "RefreshAISetup()");
                            // MessageBox.Show("Channel " + i.ToString() + " Get AiRange Property failed with Error Code=[0x" + Convert.ToString(Ret, 16) + "]:" + ErrorMessage, "Advantech Common Motion Utility", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                            // return false;
                        }
                        Ret = Motion.mAcm_GetChannelProperty(m_DeviceHandle, (uint)i, (uint)PropertyID.CFG_CH_DaqAiRange, ref m_AiRange);
                        if (Ret != (uint)ErrorCode.SUCCESS)
                        {
                            Logger.ShowMessages("", Ret, "RefreshAISetup()");
                            // MessageBox.Show("Channel " + i.ToString() + " Get AiRange Property failed with Error Code=[0x" + Convert.ToString(Ret, 16) + "]:" + ErrorMessage, "Advantech Common Motion Utility", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                            //   return false;
                        }
                        if (m_AiRange > 15)//Current
                        {
                            Ret = Motion.mAcm_DaqAiGetCurrData(m_DeviceHandle, (ushort)i, ref m_AiValue);
                        }
                        else           //Voltage
                        {
                            Ret = Motion.mAcm_DaqAiGetVoltData(m_DeviceHandle, (ushort)i, ref m_AiValue);
                        }
                        if (Ret != (uint)ErrorCode.SUCCESS)
                        {
                            Logger.ShowMessages("", Ret, "RefreshAISetup()");
                            //MessageBox.Show("Channel " + i.ToString() + " Get AI Data failed with Error Code=[0x" + Convert.ToString(Ret, 16) + "]:" + ErrorMessage, "Advantech Common Motion Utility", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                            //  return false;
                        }

                        switch ((uint)m_AiRange)
                        {
                            case (uint)AiRange.AI_NEG_10V_TO_10V:
                                strAiRange = "+/-10V";
                                break;
                            case (uint)AiRange.AI_NEG_5V_TO_5V:
                                strAiRange = "+/-5V";
                                break;
                            case (uint)AiRange.AI_NEG_2500MV_TO_2500MV:
                                strAiRange = "+/-2.5V";
                                break;
                            case (uint)AiRange.AI_NEG_1250MV_TO_1250MV:
                                strAiRange = "+/-1.25V";
                                break;
                            case (uint)AiRange.AI_NEG_1V_TO_1V:
                                strAiRange = "+/-1V";
                                break;
                            case (uint)AiRange.AI_NEG_625MV_TO_625MV:
                                strAiRange = "+/-625mV";
                                break;
                            case (uint)AiRange.AI_NEG_500MV_TO_500MV:
                                strAiRange = "+/-500mV";
                                break;
                            case (uint)AiRange.AI_NEG_150MV_TO_150MV:
                                strAiRange = "+/-150mV";
                                break;
                            case (uint)AiRange.AI_NEG_0_TO_10V:
                                strAiRange = "0~10V";
                                break;
                            case (uint)AiRange.AI_NEG_0_TO_500MV:
                                strAiRange = "0~500mV";
                                break;
                            case (uint)AiRange.AI_0MA_TO_20MA:
                                strAiRange = "0~20mA";
                                break;
                            case (uint)AiRange.AI_4MA_TO_20MA:
                                strAiRange = "4~20mA";
                                break;
                            case (uint)AiRange.AI_NEG_20MA_TO_20MA:
                                strAiRange = "+/-20mA";
                                break;
                            default:
                                strAiRange = "+/-10V";
                                break;
                        }

                        switch ((uint)m_AiIntTime)
                        {
                            case 0:
                                strAiIntTime = "60HZ";
                                break;
                            case 1:
                                strAiIntTime = "50HZ";
                                break;
                            default:
                                strAiIntTime = "60HZ";
                                break;
                        }
                        subItems[1] = m_AiValue.ToString("0.000");
                        subItems[2] = strAiRange;
                        subItems[3] = strAiIntTime;


                        Array.Resize(ref Aivalues, (int)AINumber);
                    }
                    // return true;

                }
                catch (Exception es)
                {
                    Logger.WriteLog(Logger.LogType.Error, "Advantech_PCIE", "RefreshAISetup()", "Exception Error", es.ToString());
                    // AdvanTechPCIE.WriteLog("Device_Interface", "RefreshAISetup()", "PCIE-1203_Interface", "Exception Error", es.ToString());
                    //  return false;
                }
                AI_ref = true;
            }
            return false;
        }
        /// <summary>
        /// RefreshAIvalues
        /// </summary>        
        /// <returns>Its Return Double Value</returns>
        public double[] RefreshAIvalues()
        {
            try
            {
                float m_AiValue = 0;
                double m_AiRange = 0;
                uint Ret = 0;

                // lv_AIValue.BeginUpdate();
                for (int i = 0; i < AINumber; i++)
                {
                    string strPreValue = Aivalues[i].ToString();
                    Ret = Motion.mAcm_GetChannelProperty(m_DeviceHandle, (uint)i, (uint)PropertyID.CFG_CH_DaqAiRange, ref m_AiRange);
                    if (Ret == (uint)ErrorCode.SUCCESS)
                    {
                        if (m_AiRange > 15)//Current
                        {
                            Ret = Motion.mAcm_DaqAiGetCurrData(m_DeviceHandle, (ushort)i, ref m_AiValue);
                        }
                        else           //Voltage
                        {
                            Ret = Motion.mAcm_DaqAiGetVoltData(m_DeviceHandle, (ushort)i, ref m_AiValue);
                        }
                        if (Ret == (uint)ErrorCode.SUCCESS)
                        {
                            if (strPreValue != m_AiValue.ToString("0.000"))
                                Aivalues[i] = Convert.ToDouble(m_AiValue.ToString("0.000"));
                        }
                    }
                }
                return Aivalues;
            }
            catch (Exception es)
            {
                Logger.WriteLog(Logger.LogType.Error, "Advantech_PCIE", "RefreshAIvalues()", "Exception Error", es.ToString());
                //AdvanTechPCIE.WriteLog("Device_Interface", "RefreshAIvalues()", "PCIE-1203_Interface", "Exception Error", es.ToString());
                return Aivalues;
            }
        }

        #endregion

        #region "Set Position"
        /// <summary>
        ///  Set the Encoder Value to Zero.
        /// </summary>
        /// <param name="axis">Pass the Axis - true</param>
        /// <returns>Its Return Bool if encoder value is set zero means its return true otherwise false</returns>
        public bool Set_Zero_Pos()
        {
            double cmdPosition = new double();
            uint Result;
            string strTemp;
            cmdPosition = 0;
            bool process = false;
            try
            {
                if (Advantech_PCIE.m_bInit == true)
                {
                    //Set command position for the specified axis
                    Result = Motion.mAcm_AxSetCmdPosition(Advantech_PCIE.m_Axishand[Read_Axishand], cmdPosition);
                    if (Result != (uint)ErrorCode.SUCCESS)
                    {
                        process = false;
                        strTemp = "Set axis's command position failed with error code: [0x" + Convert.ToString(Result, 16) + "]";
                        Logger.ShowMessages(strTemp, Result, "Reset_Home_Pos()");

                        return process;
                    }
                    else
                    {
                        process = true;
                    }
                    Result = Motion.mAcm_AxSetActualPosition(Advantech_PCIE.m_Axishand[Read_Axishand], cmdPosition);
                    if (Result != (uint)ErrorCode.SUCCESS)
                    {
                        process = false;
                        strTemp = "Set axis's command position failed with error code: [0x" + Convert.ToString(Result, 16) + "]";
                        Logger.ShowMessages(strTemp, Result, "Reset_Home_Pos()");

                        return process;
                    }
                    else
                    {
                        process = true;
                    }
                }
                return process;
            }
            catch (Exception es)
            {
                Logger.WriteLog(Logger.LogType.Error, "Advantech_PCIE", "Set_Zero_Pos()", "Exception Error", es.ToString());
                //AdvanTechPCIE.WriteLog("Device_Interface", "Set_Zero_Pos()", "PCIE-1203_Interface", "Exception Error", es.ToString());
                return false;
            }

        }
        /// <summary>
        /// Availabe All Servo Enable
        /// </summary>
        /// <param name="axis">Pass the Axis - true</param>
        /// <param name="cmdPosition">Pas the Position- true</param>
        /// <returns>set servo encoder value means its retun true otherwise false</returns>
        public bool Set_Act_Pos_TO_card(int axis, double cmdPosition)
        {
            uint Result;
            string strTemp;

            bool process = false;
            try
            {
                if (Advantech_PCIE.m_bInit == true)
                {
                    //Set command position for the specified axis
                    Result = Motion.mAcm_AxSetCmdPosition(Advantech_PCIE.m_Axishand[axis], cmdPosition);
                    if (Result != (uint)ErrorCode.SUCCESS)
                    {
                        process = false;
                        strTemp = "Set axis's command position failed with error code: [0x" + Convert.ToString(Result, 16) + "]";
                        Logger.ShowMessages(strTemp, Result, "Reset_Home_Pos()");

                        return process;
                    }
                    else
                    {
                        process = true;
                    }
                    Result = Motion.mAcm_AxSetActualPosition(Advantech_PCIE.m_Axishand[axis], cmdPosition);
                    if (Result != (uint)ErrorCode.SUCCESS)
                    {
                        process = false;
                        strTemp = "Set axis's command position failed with error code: [0x" + Convert.ToString(Result, 16) + "]";
                        Logger.ShowMessages(strTemp, Result, "Reset_Home_Pos()");

                        return process;
                    }
                    else
                    {
                        process = true;
                    }
                }
                return process;
            }
            catch (Exception es)
            {
                Logger.WriteLog(Logger.LogType.Error, "Advantech_PCIE", "Set_Act_Pos_TO_card()", "Exception Error", es.ToString());
                // AdvanTechPCIE.WriteLog("Device_Interface", "Set_Act_Pos_TO_card()", "PCIE-1203_Interface", "Exception Error", es.ToString());
                return false;
            }
        }

        #endregion

        #region "Servo"


        // use it for Acm_AxGetMotionIO API
        public enum MotionIOBit
        {
            RDY = 0,        // RDY pin input
            ALM = 1,        // Alarm signal input
            LMT_P = 2,      // Limit switch positive (LMT+)
            LMT_N = 3,      // Limit switch negative (LMT-)
            ORG = 4,        // Origin switch
            DIR = 5,        // Direction output
            EMG = 6,        // Emergency signal input
            PCS = 7,        // PCS signal
            ERC = 8,        // Output deflection counter clear (OUT7)
            EZ = 9,         // Encoder Z signal
            CLR = 10,       // Clear position counter input
            LTC = 11,       // Latch signal input
            SD = 12,        // Slow down signal input
            INP = 13,       // In-position signal input
            SVON = 14,      // Servo ON status (OUT6)
            ALRM = 15,      // Alarm reset output status
            SLMT_P = 16,    // Software limit positive
            SLMT_N = 17,    // Software limit negative
            CMP = 18,       // Compare signal output (OUT5)
            CAMDO = 19      // Position window DO (OUT4)
        }
        /// <summary>
        /// Availabe All Servo Enable
        /// </summary>
        /// <param name="safety">Mandatory to pass bool - true</param>
        /// <returns>All servo enable means its retun true otherwise false</returns>
        public bool ServoOn_All_Axis(bool safety)
        {
            try
            {
                UInt32 AxisNum;
                UInt32 Result = 0;
                string strTemp;
                uint sts = new uint();
                m_bServoOn = false;
                //Check the servoOno flag to decide if turn on or turn off the ServoOn output.
                if (m_bServoOn == false)
                {

                    if (m_bInit != true)
                    {
                        return false;
                    }
                    if (m_bServoOn == false)
                    {
                        //ResetAxisError();
                        for (AxisNum = 0; AxisNum < m_ulAxisCount; AxisNum++)
                        {

                            Result = Motion.mAcm_AxSetSvOn(m_Axishand[AxisNum], 1);

                            sts = 0;
                            // Result = Motion.mAcm_AxGetMotionStatus(m_Axishand[AxisNum], ref sts);
                        }
                        // Set servo Driver ON,1: On
                        if (Result != (uint)ErrorCode.SUCCESS)
                        {
                            strTemp = "Servo On Failed With Error Code: [0x" + Convert.ToString(Result, 16) + "]";
                            Task.Run(() => Logger.ShowMessages(strTemp, (uint)Result, "Servoon()"));
                            // return false;
                        }
                        m_bServoOn = true;
                        Task.Run(() => Logger.WriteLog(Logger.LogType.Info, "Advantech_PCIE", "ServoOn_All_Axis()", "SUCCESS", "SERVO ON ALL AXIS"));
                        //AdvanTechPCIE.WriteLog("Device_Interface", "ServoOn()", "PCIE-1203_Interface", "SUCCESS", "SERVO ON");


                    }
                    else
                    {
                        for (AxisNum = 0; AxisNum < m_ulAxisCount; AxisNum++)
                        {
                            // Set servo Driver OFF,0: Off
                            Result = Motion.mAcm_AxSetSvOn(m_Axishand[AxisNum], 0);

                            //Result = Motion.mAcm_AxGetMotionStatus(m_Axishand[AxisNum], ref sts);
                            if (Result != (uint)ErrorCode.SUCCESS)
                            {
                                strTemp = "Servo Off Failed With Error Code: [0x" + Convert.ToString(Result, 16) + "]";
                                Task.Run(() => Logger.WriteLog(Logger.LogType.Error, "Advantech_PCIE", "ServoOn_All_Axis()", "Execution Error", strTemp));
                                //AdvanTechPCIE.WriteLog("Device_Interface", "ServoOn()", "PCIE-1203_Interface", "Execution Error", strTemp);
                                return false;
                            }

                            //  m_bServoOn = false;
                            Task<bool> Log_task = Logger.WriteLogasTask(Logger.LogType.Error, "Advantech_PCIE", "ServoOn()", "Successfull", "ServoOFF");
                        }
                    }
                }
                return true;
            }
            catch (Exception es)
            {
                Task.Run(() => Logger.WriteLog(Logger.LogType.Error, "Advantech_PCIE", "ServoOn_All_Axis()", "Exception Error", es.ToString()));
                //AdvanTechPCIE.WriteLog("Device_Interface", "ServoOn()", "PCIE-1203_Interface", "Exception Error", es.ToString());
                return false;
            }

        }
        /// <summary>
        /// Current Servo Enable
        /// </summary>
        /// <param name="safety">Mandatory to pass bool - true</param>
        /// <returns>Current servo enable means its retun true otherwise false</returns>
        public bool ServoOn(bool safety)
        {
            try
            {
                UInt32 Result = 0;
                string strTemp;

                if (m_bInit != true)
                {
                    // is card  not open
                    return false;
                }
                else
                {
                    // is card open
                    // Set servo Driver ON,1: On
                    Result = Motion.mAcm_AxSetSvOn(m_Axishand[Read_Axishand], 1);

                    
                    if (Result != (uint)ErrorCode.SUCCESS)
                    {
                        strTemp = "Servo Axis index " + Read_Axishand.ToString() + " Servo On Failed With Error Code: [0x" + Convert.ToString(Result, 16) + "]";
                        Logger.ShowMessages(strTemp, (uint)Result, "ServoOn()");
                        return false;
                    }
                    Logger.WriteLog(Logger.LogType.Info, "Advantech_PCIE", "ServoOn() index" + Read_Axishand.ToString(), "SUCCESS", "SERVO ON");
                    //AdvanTechPCIE.WriteLog("Device_Interface", "ServoOn() index " + Read_Axishand.ToString(), "PCIE -1203_Interface", "SUCCESS", "SERVO ON");
                    return true;
                }
            }
            catch (Exception es)
            {
                Logger.WriteLog(Logger.LogType.Error, "Advantech_PCIE", "ServoOn() issue in axis" + Read_Axishand.ToString(), "Exception Error", es.ToString());
                //AdvanTechPCIE.WriteLog("Device_Interface", "ServoOn() issue in axis" + Read_Axishand.ToString(), "PCIE-1203_Interface", "Exception Error", es.ToString());
                return false;
            }
        }
        /// <summary>
        /// Availabe All Servo Disable
        /// </summary>
        /// <returns>All servo disable means its retun true otherwise false</returns>
        /// 

        public bool ServoOFF_All_Axis()
        {
            try
            {
                UInt32 AxisNum;
                UInt32 Result;
                string strTemp;
                uint sts = new uint();
                //Check the servoOn flag to decide if turn on or turn off the ServoOn output.
                if (m_bServoOn == true)
                {

                    if (m_bInit != true)
                    {
                        return false;
                    }


                    for (AxisNum = 0; AxisNum < m_ulAxisCount; AxisNum++)
                    {
                        // Set servo Driver OFF,0: Off

                        Result = Motion.mAcm_AxSetSvOn(m_Axishand[AxisNum], 0);

                        //Result = Motion.mAcm_AxGetMotionStatus(m_Axishand[AxisNum], ref sts);
                        if (Result != (uint)ErrorCode.SUCCESS)
                        {
                            strTemp = "Servo Off Failed With Error Code: [0x" + Convert.ToString(Result, 16) + "]";
                            Task<bool> Log_task1 = Logger.WriteLogasTask(Logger.LogType.Error, "Advantech_PCIE", "ServoOFF_All_Axis()", "Execution Error", strTemp);
                            return false;
                        }
                        m_bServoOn = false;
                        Logger.WriteLog(Logger.LogType.Info, "Advantech_PCIE", "ServoOFF_All_Axis()", "SUCCESS", "ServoOFF_All_Axis DONE");
                        //AdvanTechPCIE.WriteLog("Device_Interface", "ServoOFF()", "PCIE-1203_Interface", "SUCCESS", "SERVO OFF");
                    }

                }
                return true;
            }
            catch (Exception es)
            {
                Logger.WriteLog(Logger.LogType.Error, "Advantech_PCIE", "ServoOFF_All_Axis()", "Exception Error", es.ToString());
                //AdvanTechPCIE.WriteLog("Device_Interface", "ServoOFF()", "PCIE-1203_Interface", "Exception Error", es.ToString());
                return false;
            }
        }
        /// <summary>
        /// Current Servo Disable
        /// </summary>
        /// <returns>Current servo Disable means its retun true otherwise false</returns>
        public bool ServoOFF()
        {
            UInt32 Result;
            string strTemp;

            try
            {
                if (m_bInit != true)
                {
                    return false;
                }
                int attempt = 0;
                bool success = false;

                // turn of individual servo
                Result = Motion.mAcm_AxSetSvOn(m_Axishand[Read_Axishand], 0);

                if (Result == (uint)ErrorCode.SUCCESS)
                {
                    Logger.WriteLog(Logger.LogType.Info, "Advantech_PCIE", "ServoOFF() for Axis index " + Read_Axishand.ToString(), "SUCCESS", "SERVO OFF");
                    //AdvanTechPCIE.WriteLog("Device_Interface", "ServoOFF() for Axis index " + Read_Axishand.ToString() , "PCIE -1203_Interface", "SUCCESS", "SERVO OFF");
                    ////ErrorHandler.HandleError(Result, "ServoOn_All_Axis()", this.motor_Params.name);
                    return true;
                }
                else
                {
                    strTemp = "Servo Off Failed for Axis index " + Read_Axishand.ToString() + " With Error Code: [0x" + Convert.ToString(Result, 16) + "]";
                    Task<bool> Log_task1 = Logger.WriteLogasTask(Logger.LogType.Error, "Advantech_PCIE", "ServoOff()", "Exception Error", strTemp);
                    ////ErrorHandler.HandleError(Result, "ServoOn_All_Axis()", this.motor_Params.name);
                    while (attempt < 3 && !success)
                    {
                        Result = Motion.mAcm_AxSetSvOn(m_Axishand[Read_Axishand], 0);
                        if (Result != (uint)ErrorCode.SUCCESS)
                        {
                            strTemp = "Servo Off Failed for Axis index " + Read_Axishand.ToString() + " With Error Code: [0x" + Convert.ToString(Result, 16) + "]";
                            Task<bool> Log_task2 = Logger.WriteLogasTask(Logger.LogType.Error, "Advantech_PCIE", "ServoOff()", "Exception Error", strTemp);
                            ////ErrorHandler.HandleError(Result, "ServoOn_All_Axis()", this.motor_Params.name);
                            attempt++;
                            if (attempt < 3)
                                Thread.Sleep(100); // Wait before retry 
                        }
                        else
                        {
                            Logger.WriteLog(Logger.LogType.Info, "Advantech_PCIE", "ServoOFF() for Axis index " + Read_Axishand.ToString(), "SUCCESS", "SERVO OFF");
                            //AdvanTechPCIE.WriteLog("Device_Interface", "ServoOFF() for Axis index " + Read_Axishand.ToString() , "PCIE -1203_Interface", "SUCCESS", "SERVO OFF");
                            ////ErrorHandler.HandleError(Result, "ServoOn_All_Axis()", this.motor_Params.name);
                            return true;
                        }
                    }
                    ErrorManage errorManager = new ErrorManage();
                    errorManager.AlarmCode = "SERVO_OFF"; // Set appropriate alarm code
                    errorManager.AlarmMessage = this.motor_Params.name + "--->" + "Servo motor is turned off unexpectedly.";
                    errorManager.AlarmGroup = "Servo";
                    errorManager.AlarmHappen = true;// 
                    return false;
                }

            }
            catch (Exception es)
            {
                Logger.WriteLog(Logger.LogType.Error, "Advantech_PCIE", "ServoOFF()", "Exception Error", es.ToString());
                //AdvanTechPCIE.WriteLog("Device_Interface", "ServoOFF() for Axis index " + Read_Axishand.ToString(), "PCIE-1203_Interface", "Exception Error", es.ToString());
                //ErrorHandler.HandleException(es, "ServoOn_All_Axis()", this.motor_Params.name);
                return false;
            }
        }

        /// <summary>
        /// All Servo Error Reset 
        /// </summary>
        /// <param name="safety">Mandatory to pass safety - true</param>
        /// <returns>Process complete means its return true</returns>
        public bool ResetAxisError_All_Axis(bool safety)
        {
            try
            {
                UInt32 Result;
                string strTemp;
                int AxisNum;
                if (!safety)
                {
                    return false;
                }
                //Reset the axis' state. If the axis is in ErrorStop state, the state will
                //be changed to Ready after calling this function.
                if (m_ulAxisCount > 0)
                {


                    for (AxisNum = 4; AxisNum < m_ulAxisCount; AxisNum++)
                    {

                        Result = Motion.mAcm_AxResetError(m_Axishand[AxisNum]);
                        if (Result != (uint)ErrorCode.SUCCESS)
                        {
                            strTemp = "Reset axis's error failed With Error Code: [0x" + Convert.ToString(Result, 16) + "]";
                            Logger.WriteLog(Logger.LogType.Info, "Advantech_PCIE", "ResetAxisError_All_Axis()", "Execution Error", strTemp);
                            //AdvanTechPCIE.WriteLog("Device_Interface", "ResetError()", "PCIE-1203_Interface", "Execution Error", strTemp);
                            return false;
                        }



                    }
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception es)
            {
                Logger.WriteLog(Logger.LogType.Error, "Advantech_PCIE", "ResetAxisError_All_Axis()", "Exception Error", es.ToString());
                // AdvanTechPCIE.WriteLog("Device_Interface", "ResetError()", "PCIE-1203_Interface", "Exception Error", es.ToString());
                return false;
            }

        }
        /// <summary>
        /// All Servo Error Reset 
        /// </summary>
        /// <returns>Process complete means its return true</returns>
        public bool ResetAxisError_All_Axis()
        {

            try
            {
                UInt32 Result;
                string strTemp;
                int AxisNum;

                //Reset the axis' state. If the axis is in ErrorStop state, the state will
                //be changed to Ready after calling this function.
                if (m_ulAxisCount > 0)
                {


                    for (AxisNum = 4; AxisNum < m_ulAxisCount; AxisNum++)
                    {

                        Result = Motion.mAcm_AxResetError(m_Axishand[AxisNum]);
                        if (Result != (uint)ErrorCode.SUCCESS)
                        {
                            strTemp = "Reset axis's error failed With Error Code: [0x" + Convert.ToString(Result, 16) + "]";
                            Logger.WriteLog(Logger.LogType.Error, "Advantech_PCIE", "ResetAxisError_All_Axis()", "Execution Error", strTemp);
                            //AdvanTechPCIE.WriteLog("Device_Interface", "ResetError()", "PCIE-1203_Interface", "Execution Error", strTemp);
                            // return false;
                        }



                    }
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception es)
            {
                Logger.WriteLog(Logger.LogType.Error, "Advantech_PCIE", "ResetAxisError_All_Axis()", "Exception Error", es.ToString());
                // AdvanTechPCIE.WriteLog("Device_Interface", "ResetError()", "PCIE-1203_Interface", "Exception Error", es.ToString());
                return false;
            }

        }
        /// <summary>
        /// Current Servo Error Reset 
        /// </summary>
        /// <returns>Process complete means its return true</returns>
        public bool ResetAxis()
        {
            try
            {
                UInt32 Result;
                string strTemp;

                Result = Motion.mAcm_AxResetError(m_Axishand[Read_Axishand]);
                if (Result != (uint)ErrorCode.SUCCESS)
                {
                    strTemp = "Reset axiss error failed axis index " + Read_Axishand.ToString() + " With Error Code: [0x" + Convert.ToString(Result, 16) + "]";
                    Logger.WriteLog(Logger.LogType.Error, "Advantech_PCIE", "ResetAxis()", "Execution Error", strTemp);
                    //AdvanTechPCIE.WriteLog("Device_Interface", "ResetError()", "PCIE-1203_Interface", "Execution Error", strTemp);
                    return false;
                }
                return true;
            }
            catch (Exception es)
            {
                Logger.WriteLog(Logger.LogType.Error, "Advantech_PCIE", "ResetAxis()", "Exception Error", es.ToString());
                //AdvanTechPCIE.WriteLog("Device_Interface", "ResetError() axis index " + Read_Axishand.ToString(), "PCIE -1203_Interface", "Exception Error", es.ToString());
                return false;
            }
        }
        /// <summary>
        /// Servo Movement Purpose, Need to Set Velocity, Acceleration, Deacceleration
        /// </summary>
        /// <param name="vel">Need to Pass Velocity (Speed) of servo</param>
        /// <param name="Acc">Acceleration of Servo</param>
        /// <param name="DeAcc">Deacceleration of Servo</param>
        /// <returns>Process complete means its return true otherwise return false</returns>        
        public bool SetVel(double vel, double Acc, double DeAcc)
        {
            try
            {
                UInt32 Result;
                double axJogVelLow;
                double axJogVelHigh;
                double axJogAcc;
                double axJogDec;
                UInt32 axJogVLTime;
                string strTemp;
                string[] velparam = new string[10];
                axJogVelLow = 0;
                //Set low velocity (start velocity) of this axis (Unit: PPU/S).
                //This property value must be smaller than or equal to PAR_AxVelHigh
                //You can also use the old API:Motion.mAcm_SetProperty(m_Axishand[CmbAxes.SelectedIndex], (uint)PropertyID.PAR_AxVelLow, ref AxVelLow, BufferLength);
                // UInt32  BufferLength;
                //BufferLength =8; buffer size for the property
                Result = Motion.mAcm_SetF64Property(m_Axishand[Read_Axishand], (uint)PropertyID.PAR_AxVelLow, axJogVelLow);
                if (Result != (uint)ErrorCode.SUCCESS)
                {
                    strTemp = "Set low velocity failed with error code: [0x" + Convert.ToString(Result, 16) + "]";
                    Logger.ShowMessages(strTemp, (uint)Result, "Setvel()");
                    return false;
                }
                axJogVelHigh = Convert.ToDouble(vel) * Global_pulse;
                // Set high velocity (driving velocity) of this axis (Unit: PPU/s).
                //This property value must be smaller than CFG_AxMaxVel and greater than PAR_AxVelLow
                //You can also use the old API:Motion.mAcm_SetProperty(m_Axishand[CmbAxes.SelectedIndex], (uint)PropertyID.PAR_AxVelHigh,ref AxVelHigh,BufferLength)
                // UInt32  BufferLength;
                //BufferLength =8; buffer size for the property
                Result = Motion.mAcm_SetF64Property(m_Axishand[Read_Axishand], (uint)PropertyID.PAR_AxVelHigh, axJogVelHigh);
                if (Result != (uint)ErrorCode.SUCCESS)
                {
                    strTemp = "Set high velocity failed with error code: [0x" + Convert.ToString(Result, 16) + "]";
                    Logger.ShowMessages(strTemp, (uint)Result, "Setvel()");

                    return false;
                }
                axJogAcc = Math.Round(Convert.ToDouble(Acc)) * Global_pulse;
                //axJogAcc = 20000;
                // Set acceleration of this axis (Unit: PPU/s2).
                //This property value must be smaller than or equal to CFG_AxMaxAcc
                //You can also use the old API:Motion.mAcm_SetProperty(m_Axishand[CmbAxes.SelectedIndex], (uint)PropertyID.PAR_AxAcc,ref AxAcc,BufferLength)
                // UInt32  BufferLength;
                //BufferLength =8; buffer size for the property
                Result = Motion.mAcm_SetF64Property(m_Axishand[Read_Axishand], (uint)PropertyID.PAR_AxAcc, axJogAcc);
                if (Result != (uint)ErrorCode.SUCCESS)
                {
                    strTemp = "Set acceleration failed with error code: [0x" + Convert.ToString(Result, 16) + "]";
                    Logger.ShowMessages(strTemp, (uint)Result, "Setvel()");

                    return false;
                }
                axJogDec = Math.Round(Convert.ToDouble(DeAcc)) * Global_pulse;
                //axJogDec =20000;
                //Set deceleration of this axis (Unit: PPU/s2).
                //This property value must be smaller than or equal to CFG_AxMaxDec
                //You can also use the old API:Motion.mAcm_SetProperty(m_Axishand[CmbAxes.SelectedIndex], (uint)PropertyID.PAR_AxDcc,ref AxDec,BufferLength)
                // UInt32  BufferLength;
                //BufferLength =8; buffer size for the property
                Result = Motion.mAcm_SetF64Property(m_Axishand[Read_Axishand], (uint)PropertyID.PAR_AxDec, axJogDec);
                if (Result != (uint)ErrorCode.SUCCESS)
                {
                    strTemp = "Set deceleration failed with error code: [0x" + Convert.ToString(Result, 16) + "]";
                    Logger.ShowMessages(strTemp, (uint)Result, "Setvel()");

                    return false;
                }

                Result = Motion.mAcm_SetF64Property(m_Axishand[Read_Axishand], (uint)PropertyID.PAR_AxJerk, 1);
                if (Result != (uint)ErrorCode.SUCCESS)
                {
                    strTemp = "Set Jerk failed with error code: [0x" + Convert.ToString(Result, 16) + "]";
                    Logger.ShowMessages(strTemp, (uint)Result, "Setvel()");

                    return false;
                }
                //axJogVLTime = Convert.ToUInt32(200);
                //Result = Motion.mAcm_SetU32Property(m_Axishand[AxisIndex], (uint)PropertyID.CFG_AxJogVLTime, axJogVLTime);
                //if (Result != (uint)ErrorCode.SUCCESS)
                //{
                //    strTemp = "Set jog velocity low time failed with error code: [0x" + Convert.ToString(Result, 16) + "]";
                //    Task<bool> Log_task = Logger.WriteLog_1("ServoProcess", "setvel()", "", "Exception Error", strTemp);

                //    return false;
                //}

                // 
                return true;
            }
            catch (Exception es)
            {
                //Logger.WriteLog(Logger.LogType.Error, "Advantech_PCIE", "SetVel()", "Exception Error", es.ToString());
                //AdvanTechPCIE.WriteLog("Device_Interface", "SetVel()", "PCIE-1203_Interface", "Exception Error", es.ToString());
                return false;
            }

        }
        /// <summary>
        /// Jog Movement Purpose, Need to Set Velocity, Acceleration, Deacceleration
        /// </summary>
        /// <param name="vel">Need to Pass Velocity (Speed) of servo</param>
        /// <param name="Acc">Acceleration of Servo</param>
        /// <param name="DeAcc">Deacceleration of Servo</param>
        /// <returns>Process complete means its return true otherwise return false</returns>
        public bool SetVel_jog(double vel, double Acc, double DeAcc)
        {
            try
            {
                UInt32 Result;
                double axJogVelLow;
                double axJogVelHigh;
                double axJogAcc;
                double axJogDec;
                UInt32 axJogVLTime;
                string strTemp;
                string[] velparam = new string[10];
                //axJogVelLow = 20000;
                axJogVelLow = 1000;
                //Set low velocity (start velocity) of this axis (Unit: PPU/S).
                //This property value must be smaller than or equal to PAR_AxVelHigh
                //You can also use the old API:Motion.mAcm_SetProperty(m_Axishand[CmbAxes.SelectedIndex], (uint)PropertyID.PAR_AxVelLow, ref AxVelLow, BufferLength);
                // UInt32  BufferLength;
                //BufferLength =8; buffer size for the property
                Result = Motion.mAcm_SetF64Property(m_Axishand[Read_Axishand], (uint)PropertyID.CFG_AxJogVelLow, axJogVelLow);
                if (Result != (uint)ErrorCode.SUCCESS)
                {
                    strTemp = "Set low velocity failed with error code: [0x" + Convert.ToString(Result, 16) + "]";
                    Logger.ShowMessages(strTemp, (uint)Result, "SetvelJog()");
                    return false;
                }
                //  axJogVelHigh =200000;
                axJogVelHigh = vel * Global_pulse;
                // Set high velocity (driving velocity) of this axis (Unit: PPU/s).
                //This property value must be smaller than CFG_AxMaxVel and greater than PAR_AxVelLow
                //You can also use the old API:Motion.mAcm_SetProperty(m_Axishand[CmbAxes.SelectedIndex], (uint)PropertyID.PAR_AxVelHigh,ref AxVelHigh,BufferLength)
                // UInt32  BufferLength;
                //BufferLength =8; buffer size for the property
                Result = Motion.mAcm_SetF64Property(m_Axishand[Read_Axishand], (uint)PropertyID.CFG_AxJogVelHigh, axJogVelHigh);
                if (Result != (uint)ErrorCode.SUCCESS)
                {
                    strTemp = "Set high velocity failed with error code: [0x" + Convert.ToString(Result, 16) + "]";
                    Logger.ShowMessages(strTemp, (uint)Result, "SetvelJog()");
                    return false;
                }
                axJogAcc = Acc * Global_pulse;
                // axJogAcc = 40000;
                // Set acceleration of this axis (Unit: PPU/s2).
                //This property value must be smaller than or equal to CFG_AxMaxAcc
                //You can also use the old API:Motion.mAcm_SetProperty(m_Axishand[CmbAxes.SelectedIndex], (uint)PropertyID.PAR_AxAcc,ref AxAcc,BufferLength)
                // UInt32  BufferLength;
                //BufferLength =8; buffer size for the property
                Result = Motion.mAcm_SetF64Property(m_Axishand[Read_Axishand], (uint)PropertyID.CFG_AxJogAcc, axJogAcc);
                if (Result != (uint)ErrorCode.SUCCESS)
                {
                    strTemp = "Set acceleration failed with error code: [0x" + Convert.ToString(Result, 16) + "]";
                    Logger.ShowMessages(strTemp, (uint)Result, "SetvelJog()");

                    return false;
                }
                axJogDec = DeAcc * Global_pulse;
                // axJogDec =40000;
                //Set deceleration of this axis (Unit: PPU/s2).
                //This property value must be smaller than or equal to CFG_AxMaxDec
                //You can also use the old API:Motion.mAcm_SetProperty(m_Axishand[CmbAxes.SelectedIndex], (uint)PropertyID.PAR_AxDcc,ref AxDec,BufferLength)
                // UInt32  BufferLength;
                //BufferLength =8; buffer size for the property
                Result = Motion.mAcm_SetF64Property(m_Axishand[Read_Axishand], (uint)PropertyID.CFG_AxJogDec, axJogDec);
                if (Result != (uint)ErrorCode.SUCCESS)
                {
                    strTemp = "Set deceleration failed with error code: [0x" + Convert.ToString(Result, 16) + "]";
                    Logger.ShowMessages(strTemp, (uint)Result, "SetvelJog()");

                    return false;
                }

                //Result = Motion.mAcm_SetF64Property(m_Axishand[AxisIndex], (uint)PropertyID.PAR_AxJogJerk, 1);
                //if (Result != (uint)ErrorCode.SUCCESS)
                //{
                //    strTemp = "Set jerk failed with error code: [0x" + Convert.ToString(Result, 16) + "]";
                //    Task<bool> Log_task = Logger.WriteLog_1("ServoProcess", "setvel()", "", "Exception Error", strTemp);

                //    return false;
                //}
                //axJogVLTime = 5000;
                axJogVLTime = 100;
                Result = Motion.mAcm_SetU32Property(m_Axishand[Read_Axishand], (uint)PropertyID.CFG_AxJogVLTime, axJogVLTime);
                if (Result != (uint)ErrorCode.SUCCESS)
                {
                    strTemp = "Set jog velocity low time failed with error code: [0x" + Convert.ToString(Result, 16) + "]";
                    Logger.ShowMessages(strTemp, (uint)Result, "SetvelJog()");

                    return false;
                }

                // 
                return true;
            }
            catch (Exception es)
            {
                Logger.WriteLog(Logger.LogType.Error, "Advantech_PCIE", "SetVel_jog()", "Exception Error", es.ToString());
                //AdvanTechPCIE.WriteLog("Device_Interface", "SetVelJog()", "PCIE-1203_Interface", "Exception Error", es.ToString());
                return false;
            }

        }
        /// <summary>
        /// Get the Axis param of a string
        /// </summary>
        /// <returns>Its return String</returns>
        public string[] GetAxisVelParam()
        {
            string[] velparam = new string[10];
            try
            {
                double axJogVelLow = new double();
                double axJogVelHight = new double();
                double axJogAcc = new double();
                double axJogDec = new double();
                UInt32 axJogVLTime = new UInt32();
                UInt32 Result;
                string strTemp = "";

                //Get low velocity (start velocity) of this axis (Unit: PPU/S).
                //You can also use the old API:  Acm_GetProperty(m_Axishand[CmbAxes.SelectedIndex], (uint)PropertyID.PAR_AxVelLow, ref axvellow,ref BufferLength);
                // uint BufferLength;
                // BufferLength = 8; buffer size for the property
                Result = Motion.mAcm_GetF64Property(m_Axishand[Read_Axishand], (uint)PropertyID.CFG_AxJogVelLow, ref axJogVelLow);
                if (Result != (uint)ErrorCode.SUCCESS)
                {
                    strTemp = "Get low velocity failed with error code: [0x" + Convert.ToString(Result, 16) + "]";
                    Logger.ShowMessages(strTemp, (uint)Result, "GetAxisVelParam()");
                    Array.Clear(velparam, 0, velparam.Length);
                    return velparam;
                }
                velparam[0] = Convert.ToString(axJogVelLow);
                //get high velocity (driving velocity) of this axis (Unit: PPU/s).
                //You can also use the old API:  Acm_GetProperty(m_Axishand[CmbAxes.SelectedIndex], (uint)PropertyID.PAR_AxVelHigh, ref axvelhigh,ref BufferLength);
                // uint BufferLength;
                // BufferLength = 8; buffer size for the property
                Result = Motion.mAcm_GetF64Property(m_Axishand[Read_Axishand], (uint)PropertyID.CFG_AxJogVelHigh, ref axJogVelHight);
                if (Result != (uint)ErrorCode.SUCCESS)
                {
                    strTemp = "Get High velocity failed with error code: [0x" + Convert.ToString(Result, 16) + "]";
                    Logger.ShowMessages(strTemp, (uint)Result, "GetAxisVelParam()");
                    Array.Clear(velparam, 0, velparam.Length);
                    return velparam;
                }
                velparam[1] = Convert.ToString(axJogVelHight);
                //get acceleration of this axis (Unit: PPU/s2).
                //You can also use the old API:  Acm_GetProperty(m_Axishand[CmbAxes.SelectedIndex], (uint)PropertyID.PAR_AxAcc, ref axacc,ref BufferLength);
                // uint BufferLength;
                // BufferLength = 8; buffer size for the property
                Result = Motion.mAcm_GetF64Property(m_Axishand[Read_Axishand], (uint)PropertyID.CFG_AxJogAcc, ref axJogAcc);
                if (Result != (uint)ErrorCode.SUCCESS)
                {
                    strTemp = "Get acceleration  failed with error code: [0x" + Convert.ToString(Result, 16) + "]";
                    Logger.ShowMessages(strTemp, (uint)Result, "GetAxisVelParam()");
                    Array.Clear(velparam, 0, velparam.Length);
                    return velparam;
                }
                velparam[2] = Convert.ToString(axJogAcc);
                //get deceleration of this axis (Unit: PPU/s2).
                //You can also use the old API: Motion.mAcm_GetProperty(m_Axishand[CmbAxes.SelectedIndex], (uint)PropertyID.PAR_AxDec, ref axdec, ref BufferLength);
                // uint BufferLength;
                // BufferLength = 8; buffer size for the property
                Result = Motion.mAcm_GetF64Property(m_Axishand[Read_Axishand], (uint)PropertyID.CFG_AxJogDec, ref axJogDec);
                if (Result != (uint)ErrorCode.SUCCESS)
                {
                    strTemp = "Get deceleration  failed with error code: [0x" + Convert.ToString(Result, 16) + "]";
                    Logger.ShowMessages(strTemp, (uint)Result, "GetAxisVelParam()");
                    Array.Clear(velparam, 0, velparam.Length);
                    return velparam;
                }
                velparam[3] = Convert.ToString(axJogDec);
                Result = Motion.mAcm_GetU32Property(m_Axishand[Read_Axishand], (uint)PropertyID.CFG_AxJogVLTime, ref axJogVLTime);
                if (Result != (uint)ErrorCode.SUCCESS)
                {
                    strTemp = "Get jog VH time  failed with error code: [0x" + Convert.ToString(Result, 16) + "]";
                    Logger.ShowMessages(strTemp, (uint)Result, "GetAxisVelParam()");
                    Array.Clear(velparam, 0, velparam.Length);
                    return velparam;
                }
                velparam[4] = Convert.ToString(axJogVLTime);
                return velparam;
            }
            catch (Exception es)
            {
                Logger.WriteLog(Logger.LogType.Error, "Advantech_PCIE", "GetAxisVelParam()", "Exception Error", es.ToString());
                //AdvanTechPCIE.WriteLog("Device_Interface", "GetAxisVelParam()", "PCIE-1203_Interface", "Exception Error", es.ToString());
                return velparam;
            }

        }
        /// <summary>
        /// Enable or disable external drive mode.Setting 1 is jog mode.
        /// </summary>
        /// <returns>Process Complete means its return true</returns>
        public bool StartJog()
        {
            try
            {
                UInt32 result;
                string strTemp;
                //Enable or disable external drive mode.Setting 1 is jog mode.
                result = Motion.mAcm_AxSetExtDrive(m_Axishand[Read_Axishand], 1);

                if (result != (uint)ErrorCode.SUCCESS)
                {
                    strTemp = "Start jog mode failed with error code: [0x" + Convert.ToString(result, 16) + "]";
                    Logger.ShowMessages(strTemp, (uint)result, "Startjog()");
                    return false;
                }
                return true;
            }
            catch (Exception es)
            {
                //Logger.WriteLog(Logger.LogType.Error, "Advantech_PCIE", "startJog()", "Exception Error", es.ToString());
                //AdvanTechPCIE.WriteLog("Device_Interface", "startJog()", "PCIE-1203_Interface", "Exception Error", es.ToString());
                return false; ;
            }
        }
        /// <summary>
        /// Disable jog mode.
        /// </summary>
        /// <returns>Process Complete means its return true</returns>
        public bool StopJog()
        {
            try
            {
                UInt32 result;
                string strTemp;
                //Disable jog mode.
                result = Motion.mAcm_AxSetExtDrive(m_Axishand[Read_Axishand], 0);
                if (result != (uint)ErrorCode.SUCCESS)
                {

                    strTemp = "Stop jog mode failed with error code: [0x" + Convert.ToString(result, 16) + "]";
                    Task<bool> Log_task = Logger.WriteLogasTask(Logger.LogType.Error, "Advantech_PCIE", "stopjog()", "Execution Error", strTemp);
                    return false;
                }
                return true;
            }
            catch (Exception es)
            {
                Logger.WriteLog(Logger.LogType.Error, "Advantech_PCIE", "StopJog()", "Exception Error", es.ToString());
                //AdvanTechPCIE.WriteLog("Device_Interface", "StopJog()", "PCIE-1203_Interface", "Exception Error", es.ToString());
                return false;
            }
        }

        /// <summary>
        /// Jog Movement Purpose, Need to Set Velocity, Acceleration, Deacceleration and rotate the Servo
        /// </summary>
        /// <param name="jogMove">Need to Pass jogMove 0-forward or 1-rev servo</param>
        /// <param name="velocity">set the speed of Servo</param>
        /// <param name="acceleration">set the acceleration speed of Servo</param>
        /// <param name="deacceleration">Deacceleration of Servo</param>
        /// <returns>Process complete means its return true otherwise return false</returns>
        public bool Jog(ushort jogMove, double velocity, double acceleration, double deacceleration)
        {
            try
            {
                string strTemp;
                //if (jogMove != 0 && jogMove != 1)
                //{
                //    strTemp = "JogMove Direction Invalid";
                //    Task<bool> Log_task = Logger.WriteLog_1("ServoProcess", "Jog()", "", "Exception Error", strTemp);
                //    return false;
                //}
                IntPtr Axishand = Get_AxisHand(Read_Axishand);
                UInt32 result;
                SetVel_jog(velocity, acceleration, deacceleration);
                StartJog();
                //jogMove 0 - Forward. 1 - Reverse
                //Start software jog motion.
                result = Motion.mAcm_AxJog(Axishand, jogMove);


                //   result = Motion.mAcm_AxJog(Axishand, 0);
                if (result != (uint)ErrorCode.SUCCESS)
                {
                    strTemp = "Software jog motion Failed With Error Code: [0x" + Convert.ToString(result, 16) + "]";
                    Task<bool> Log_task = Logger.WriteLogasTask(Logger.LogType.Error, "Advantech_PCIE", "Jog()", "Execution Error", strTemp);
                    return false;
                }
                return true;

            }
            catch (Exception es)
            {
                Logger.WriteLog(Logger.LogType.Error, "Advantech_PCIE", "Jog()", "Exception Error", es.ToString());
                //AdvanTechPCIE.WriteLog("Device_Interface", "jogfrwrd()", "PCIE-1203_Interface", "Exception Error", es.ToString());
                return false;
            }
        }
        /// <summary>
        /// Jog Stop
        /// </summary>
        /// <returns>Return Bool</returns>
        public bool JogStop()
        {
            try
            {
                IntPtr Axishand = Get_AxisHand(Read_Axishand);
                UInt32 result;
                string strTemp;
                //Stop axis motion.
                result = Motion.mAcm_AxStopDec(Axishand);
                if (result != (uint)ErrorCode.SUCCESS)
                {
                    strTemp = "Stop motion Failed With Error Code: [0x" + Convert.ToString(result, 16) + "]";
                    Task<bool> Log_task = Logger.WriteLogasTask(Logger.LogType.Error, "Advantech_PCIE", "JogStop()", "Execution Error", strTemp);
                    return false;
                }
                return true;
            }
            catch (Exception es)
            {
                Logger.WriteLog(Logger.LogType.Error, "Advantech_PCIE", "JogStop()", "Exception Error", es.ToString());
                //AdvanTechPCIE.WriteLog("Device_Interface", "jogfrwrdstop()", "PCIE-1203_Interface", "Exception Error", es.ToString());
                return false;
            }
        }


        /// <summary>
        /// Get Servo Axis Index
        /// </summary>
        /// <param name="Index">Servo Index</param>
        /// <returns>Retun IntPtr as axis index</returns>
        public IntPtr Get_AxisHand(int Index)
        {
            IntPtr Axishand = new IntPtr();
            try
            {

                Axishand = m_Axishand[Index];
                return Axishand;
            }
            catch (Exception es)
            {
                Logger.WriteLog(Logger.LogType.Error, "Advantech_PCIE", "Get_AxisHand()", "Exception Error", es.ToString());
                //AdvanTechPCIE.WriteLog("Device_Interface", "Get_AxisHand()", "PCIE-1203_Interface", "Exception Error", es.ToString());
                return Axishand;
            }
        }
        /// <summary>
        /// Set command position for the specified axis
        /// </summary>
        /// <returns>retun bool</returns>
        public bool ResetPosition()
        {
            try
            {
                double cmdPosition = new double();
                uint Result;
                string strTemp;
                UInt32 AxisNum;
                cmdPosition = 0;
                if (m_bInit == true)
                {
                    for (AxisNum = 0; AxisNum < m_ulAxisCount; AxisNum++)
                    {
                        //Set command position for the specified axis
                        Result = Motion.mAcm_AxSetCmdPosition(m_Axishand[AxisNum], cmdPosition);
                        if (Result != (uint)ErrorCode.SUCCESS)
                        {
                            strTemp = "Set axis's command position failed with error code: [0x" + Convert.ToString(Result, 16) + "]";
                            Logger.ShowMessages(strTemp, Result, "ResetPosition()");
                            return false;
                        }
                    }

                }
                return true;
            }
            catch (Exception es)
            {
                Logger.WriteLog(Logger.LogType.Error, "Advantech_PCIE", "ResetPosition()", "Exception Error", es.ToString());
                //AdvanTechPCIE.WriteLog("Device_Interface", "ResetPosition()", "PCIE-1203_Interface", "Exception Error", es.ToString());
                return false;
            }
        }


        public bool StopImmidiate()
        {
            try
            {
                uint Result;
                string strTemp;
                if (m_bInit)
                {
                    //To command axis to decelerate to stop.
                    Result = Motion.mAcm_AxStopEmg(m_Axishand[Read_Axishand]);

                    //Result = Motion.mAcm_AxStopEmg(m_Axishand[Axis]);
                    if (Result != (uint)ErrorCode.SUCCESS)
                    {
                        strTemp = "Axis To decelerate Stop Failed With Error Code: [0x" + Convert.ToString(Result, 16) + "]";
                        Logger.ShowMessages(strTemp, Result, "Stop()");
                        //return false;
                    }
                }
                return true;

            }
            catch (Exception es)
            {
                Logger.WriteLog(Logger.LogType.Error, "Advantech_PCIE", "stop()", "Exception Error", es.ToString());
                //AdvanTechPCIE.WriteLog("Device_Interface", "Stop()", "PCIE-1203_Interface", "Exception Error", es.ToString());
                return false;
            }
        }

        /// <summary>
        /// Checking Particular axis Moved or Not
        /// </summary>
        /// <param name="_pos">Destination Position</param>
        /// <param name="_overtime">Over time</param>
        /// <param name="_pauseStop">Based on Emergency Stop</param>
        /// <returns></returns>
        public int CheckDoneAxis(double _pos, double _overtime, bool _pauseStop = true)
        {
            System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
            //System.Diagnostics.Stopwatch sw_Stop = new System.Diagnostics.Stopwatch();
            double dOffset = 0.2;
            sw.Start();
            while (true)
            {
                string currstate = string.Empty;
                double Act_Vel = 0.0;
                double Act_pos = 0.0;
                GetCurrentPos(out Act_pos, out currstate, out Act_Vel);

                if (!ServoAlarmTrigger())
                {
                    return 1;
                }

                if (!ToGetStatus().ToUpper().Contains("STA_AX_PTP_MOT"))
                {
                    if (ToGetStatus().ToUpper().Contains("READY") && Math.Abs(_pos / Global_pulse - Act_pos) < dOffset)
                    {
                        return 0;
                    }
                }
                //if (sw.ElapsedMilliseconds > _overtime)
                if (sw.ElapsedMilliseconds > 3000000)
                {
                    Stop();
                    CommonAlarmHandler.HandleError(this.motor_Params.TimeOut_error, this.motor_Params.name);
                    return 1;
                }
                //if (_pauseStop)
                //{
                //    Stop();//Stop the axis during pause
                //    return 2;
                //}
            }
            //return 0;
        }

        public bool ServoAlarmTrigger()
        {
            try
            {
                if (GetSingleMotionIOBit(MotionIOBit.LMT_N))
                {
                    CommonAlarmHandler.HandleError(this.motor_Params.Negative_limit_error, this.motor_Params.name);
                    return false;
                }
                if (GetSingleMotionIOBit(MotionIOBit.LMT_P))
                {
                    CommonAlarmHandler.HandleError(this.motor_Params.Positive_limit_error, this.motor_Params.name);
                    return false;
                }

                if (ToGetStatus().Contains("ERROR_STOP"))
                {
                    CommonAlarmHandler.HandleError(this.motor_Params.Driver_error, this.motor_Params.name);
                    return false;
                }

                if (!GetSingleMotionIOBit(MotionIOBit.SVON))
                {
                    CommonAlarmHandler.HandleError(this.motor_Params.Disable_error, this.motor_Params.name);
                    return false;
                }


                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> Move_AbsStepper(double position, double speed, double acceleration, double deacceleration, double _MaxTime)
        {
            try
            {
                UInt32 Result;
                string strTemp;
                if (m_bInit)
                {
                    //Check Servo is Not Enable Means, Enabled Servo in below
                    if (!ToGetStatus().ToUpper().Contains("READY"))
                    {
                        ServoOn(true);
                    }
                    // Set Servo Velocity, Acc, Deacc
                    SetVel(speed, acceleration, deacceleration);
                    //Start single axis's absolute position motion
                    Result = Motion.mAcm_AxMoveAbs(m_Axishand[Read_Axishand], position);

                    if (Result != (uint)ErrorCode.SUCCESS)
                    {
                        strTemp = "PTP Move Failed With Error Code[0x" + Convert.ToString(Result, 16) + "]";
                        Logger.ShowMessages(strTemp, Result, "MoveAbs()");
                        return false;
                    }

                    if (CheckDoneAxis(position, _MaxTime, true) != 0)
                    {
                        Logger.WriteLog(Logger.LogType.Error, "Advantech_PCIE", "Move_Abs()", "Execution Error", "Actual Position Not Moved");
                        //AdvanTechPCIE.WriteLog("Device_Interface", "Move_Abs()", "PCIE-1203_Interface", "", "Actual Position Not Moved");
                        return false;
                    }
                }
                return true;
            }
            catch (Exception es)
            {
                Logger.WriteLog(Logger.LogType.Error, "Advantech_PCIE", "Move_Abs()", "Exception Error", es.ToString());
                //AdvanTechPCIE.WriteLog("Device_Interface", "Move_Abs()", "PCIE-1203_Interface", "Exception Error", es.ToString());
                return false;
            }
        }
        /// <summary>
        /// Servo Move Based on absolute values
        /// </summary>
        /// <param name="position">Destination Position</param>
        /// <param name="speed">Speed of Servo Movement</param>
        /// <param name="acceleration">Acceleration of Servo</param>
        /// <param name="deacceleration">Deacceleration of servo</param>
        /// /// <param name="_MaxTime">PAss the Max Time Duration(In Milisec) for checkdoneAxis</param>
        /// <returns>Its Return true</returns>
        public bool Move_Abs(double position, double speed, double acceleration, double deacceleration, double _MaxTime, bool isNeedCheckDone = true)
        {
            try
            {
                UInt32 Result;
                string strTemp;
                if (m_bInit)
                {


                    if (!ServoAlarmTrigger())
                    {
                        return false;
                    }
                    //Check Servo is Not Enable Means, Enabled Servo in below
                    if (!GetSingleMotionIOBit(MotionIOBit.SVON))
                    {
                        ServoOn(true);
                    }
                    // Set Servo Velocity, Acc, Deacc
                    SetVel(speed, acceleration, deacceleration);
                    //SetVel(speed, acceleration, deacceleration);
                    position = position * Global_pulse;
                    //Start single axis's absolute position motion
                    Result = Motion.mAcm_AxMoveAbs(m_Axishand[Read_Axishand], position);

                    if (Result != (uint)ErrorCode.SUCCESS)
                    {
                        strTemp = "PTP Move Failed With Error Code[0x" + Convert.ToString(Result, 16) + "]";
                        Logger.ShowMessages(strTemp, Result, "MoveAbs()");
                        return false;
                    }

                    if (isNeedCheckDone)
                    {
                        if (CheckDoneAxis(position, _MaxTime, true) != 0)
                        {
                            Logger.WriteLog(Logger.LogType.Error, "Advantech_PCIE", "Move_Abs()", "Execution Error", "Actual Position Not Moved");
                            //AdvanTechPCIE.WriteLog("Device_Interface", "Move_Abs()", "PCIE-1203_Interface", "", "Actual Position Not Moved");
                            return false;
                        }
                    }
                }
                return true;
            }
            catch (Exception es)
            {
                Logger.WriteLog(Logger.LogType.Error, "Advantech_PCIE", "Move_Abs()", "Exception Error", es.ToString());
                //AdvanTechPCIE.WriteLog("Device_Interface", "Move_Abs()", "PCIE-1203_Interface", "Exception Error", es.ToString());
                return false;
            }
        }
        /// <summary>
        /// Servo Move Based on Relative values (Incremental), Current Position to increement position
        /// </summary>
        /// <param name="position">Increment Position</param>
        /// <param name="speed">Speed of Servo Movement</param>
        /// <param name="acceleration">Acceleration of Servo</param>
        /// <param name="deacceleration">Deacceleration of servo</param>
        /// <param name="_MaxTime">PAss the Max Time Duration(In Milisec) for checkdoneAxis</param>
        /// <returns>Its Return true</returns>
        public bool Move_Rel(double position, double speed, double acceleration, double deacceleration, double _MaxTime, bool isNeedCheckDone = true)
        {
            try
            {
                UInt32 Result;
                string strTemp;
                if (m_bInit)
                {
                    //Check Servo is Not Enable Means, Enabled Servo in below
                    if (!ToGetStatus().ToUpper().Contains("READY"))
                    {
                        ServoOn(true);
                    }
                    // Set Servo Velocity, Acc, Deacc
                    SetVel(speed, acceleration, deacceleration);
                    position = position * Global_pulse;
                    //Start single axis's absolute position motion
                    //Start single axis's absolute position motion
                    Result = Motion.mAcm_AxMoveRel(m_Axishand[Read_Axishand], position);

                    if (Result != (uint)ErrorCode.SUCCESS)
                    {
                        strTemp = "PTP Move Failed With Error Code[0x" + Convert.ToString(Result, 16) + "]";
                        Logger.ShowMessages(strTemp, Result, "Move_Rel()");
                        return false;
                    }
                    string currstate = string.Empty;
                    double Act_Vel = 0.0;
                    double Act_pos = 0.0;
                    GetCurrentPos(out Act_pos, out currstate, out Act_Vel);

                    if (isNeedCheckDone)
                    {
                        if (CheckDoneAxis(Act_pos + position, _MaxTime, true) != 0)
                        {
                            Logger.WriteLog(Logger.LogType.Error, "Advantech_PCIE", "Move_Rel()", "Execution Error", "Actual Position Not Moved");
                            // AdvanTechPCIE.WriteLog("Device_Interface", "Move_Rel()", "PCIE-1203_Interface", "", "Actual Position Not Moved");
                            return false;
                        }
                    }
                }
                return true;
            }
            catch (Exception es)
            {
                Logger.WriteLog(Logger.LogType.Error, "Advantech_PCIE", "Move_Rel()", "Exception Error", es.ToString());
                //AdvanTechPCIE.WriteLog("Device_Interface", "Move_Rel()", "PCIE-1203_Interface", "Exception Error", es.ToString());
                return false;
            }
        }
        /// <summary>
        /// Particular Servo Stop
        /// </summary>
        /// <returns>Process Complete its return true</returns>
        public bool Stop()
        {
            try
            {
                uint Result;
                string strTemp;
                if (m_bInit)
                {
                    //To command axis to decelerate to stop.
                    Result = Motion.mAcm_AxStopDec(m_Axishand[Read_Axishand]);

                    //Result = Motion.mAcm_AxStopEmg(m_Axishand[Axis]);
                    if (Result != (uint)ErrorCode.SUCCESS)
                    {
                        strTemp = "Axis To decelerate Stop Failed With Error Code: [0x" + Convert.ToString(Result, 16) + "]";
                        Logger.ShowMessages(strTemp, Result, "Stop()");
                        //return false;
                    }
                }
                return true;

            }
            catch (Exception es)
            {
                Logger.WriteLog(Logger.LogType.Error, "Advantech_PCIE", "stop()", "Exception Error", es.ToString());
                //AdvanTechPCIE.WriteLog("Device_Interface", "Stop()", "PCIE-1203_Interface", "Exception Error", es.ToString());
                return false;
            }
        }
        /// <summary>
        /// Try to get motion I/O
        /// </summary>
        /// <returns>0-19 = I/O bits, 20 = success status wether using apiis sucess or not</returns>
        public bool[] ToGetMotionIOStatus()
        {
            bool[] ioStates = new bool[21]; // 0-19 = I/O bits, 20 = success status wether using apiis sucess or not

            try
            {
                if (m_bInit)
                {
                    uint ioStatus = 0;

                    // Try to get motion I/O
                    uint result = Motion.mAcm_AxGetMotionIO(m_Axishand[Read_Axishand], ref ioStatus);

                    if (result == (uint)ErrorCode.SUCCESS)
                    {
                        for (int i = 0; i < 20; i++)
                        {
                            ioStates[i] = (ioStatus & (1u << i)) != 0;
                            // logic
                            //uint ioStatus = 0b_0000_1000; // Step 1: Assume bit 3 is set
                            //int i = 3; // Step 2: We want to check bit 3
                            //bool isBitSet = (ioStatus & (1u << i)) != 0;
                            //// Step 3: (1u << i) shifts 1 to the left by i → 1 << 3 = 0b_0000_1000
                            //// Step 4: ioStatus & (0b_0000_1000) = 0b_0000_1000 → isolates bit 3
                            //// Step 5: Result is not zero → bit 3 is ON → expression returns true

                        }

                        ioStates[20] = true; //  success
                    }
                    else
                    {
                        Logger.WriteLog(Logger.LogType.Error, "Advantech_PCIE", "ToGetMotionIOStatus()", "MotionIO Error", $"Error Code: {result}");
                        //AdvanTechPCIE.WriteLog("Device_Interface", "ToGetMotionIOStatus()", "PCIE-1203_Interface", "MotionIO Error", $"Error Code: {result}");
                        ioStates[20] = false; //  failure
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog(Logger.LogType.Error, "Advantech_PCIE", "ToGetMotionIOStatus()", "Exception Error", ex.ToString());
                //AdvanTechPCIE.WriteLog("Device_Interface", "ToGetMotionIOStatus()", "PCIE-1203_Interface", "Exception Error", ex.ToString());
                ioStates[20] = false; //  failure due to exception
            }

            return ioStates;
        }
        /// <summary>
        /// Get all I/O statuses including the success flag at index 20
        /// </summary>
        /// <param name="bit">Pass Bit</param>
        /// <returns>check if API call was successful return  the specific bit status</returns>
        public bool GetSingleMotionIOBit(MotionIOBit bit)
        {
            try
            {
                // Get all I/O statuses including the success flag at index 20
                bool[] ioStatusArray = ToGetMotionIOStatus();

                // check if API call was successful
                if (ioStatusArray != null && ioStatusArray.Length == 21)// && ioStatusArray[20])
                {
                    return ioStatusArray[(int)bit];  // Return the specific bit status
                }
                else
                {
                    Logger.WriteLog(Logger.LogType.Error, "Advantech_PCIE", "GetSingleMotionIOBit()", "MotionIO Status Failed", "API call failed or invalid array length.");
                    // AdvanTechPCIE.WriteLog("Device_Interface", "GetSingleMotionIOBit()", "PCIE-1203_Interface",
                    // "MotionIO Status Failed", "API call failed or invalid array length.");
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog(Logger.LogType.Error, "Advantech_PCIE", "GetSingleMotionIOBit()", "Exception Error", ex.ToString());
                //AdvanTechPCIE.WriteLog("Device_Interface", "GetSingleMotionIOBit()", "PCIE-1203_Interface",
                //  "Exception Error", ex.ToString());
            }

            // return false if failed
            return false;
        }

        /// <summary>
        /// To Pass the selected Servo Function
        /// </summary>
        public bool PauseAxis()
        {
            try
            {
                string strTemp;
                uint Result;
                Result = Motion.mAcm_AxPauseMotion(m_Axishand[Read_Axishand]);
                if (Result != (uint)ErrorCode.SUCCESS)
                {
                    strTemp = "Axis Pass Function Failed With Error Code: [0x" + Convert.ToString(Result, 16) + "]";
                    Logger.ShowMessages(strTemp, Result, "Stop()");
                }
                return true;

            }
            catch (Exception ex)
            {
                Logger.WriteLog(Logger.LogType.Error, "Advantech_PCIE", "PauseAxis()", "Exception Error", ex.ToString());
                return false;
            }
        }
        public bool ResumeAxis()
        {
            try
            {
                string strTemp;
                uint Result;
                Result = Motion.mAcm_AxResumeMotion(m_Axishand[Read_Axishand]);
                if (Result != (uint)ErrorCode.SUCCESS)
                {
                    strTemp = "Axis Resume Function Failed With Error Code: [0x" + Convert.ToString(Result, 16) + "]";
                    Logger.ShowMessages(strTemp, Result, "Stop()");
                }
                return true;

            }
            catch (Exception ex)
            {
                Logger.WriteLog(Logger.LogType.Error, "Advantech_PCIE", "PauseAxis()", "Exception Error", ex.ToString());
                return false;
            }
        }

        public double GetCurrentPosition()
        {
            try
            {
                double CurPos = new double();
                double Actpos = 0.0;
                UInt16 AxState = new UInt16();
                UInt32 Result;
                UInt32 IOStatus = new UInt32();
                if (m_bInit)
                {
                    //Get current actual position of the specified axis
                    Motion.mAcm_AxGetActualPosition(m_Axishand[Read_Axishand], ref CurPos);
                    Actpos = CurPos / Global_pulse;
                }
                return Actpos;
            }
            catch (Exception es)
            {
                Logger.WriteLog(Logger.LogType.Error, "Advantech_PCIE", "ToGetCurrentPos()", "Exception Error", es.ToString());
                return 0;
            }

        }

        #region "Interpolation"


        public IntPtr[] Grphand = new IntPtr[10];
        /// <summary>
        /// add the Add_Axis_For_Interpoll
        /// </summary>
        /// <param name="axis">Output as current positions</param>
        /// <param name="Interpolation_index">output asCurrent status</param>        
        public IntPtr Add_Axis_For_Interpoll(int Interpolation_index)
        {
            uint Result;
            string strTemp;
            ushort State = 0;

            try
            {
                if (m_bInit != true)
                {
                    return Grphand[Interpolation_index];
                }
                //Add an axis to the specified group

                Result = Motion.mAcm_GpAddAxis(ref Grphand[Interpolation_index], m_Axishand[Read_Axishand]);
                // Result = Motion.mAcm_GpRemAxis(m_GpHand, m_Axishand[axis]);
                // Result = Motion.mAcm_GpGetState(m_GpHand, ref State);
                if (Result != (uint)ErrorCode.SUCCESS)
                {
                    strTemp = "Add Axis To Group Failed With Error Code: [0x" + Convert.ToString(Result, 16) + "]";
                    Logger.ShowMessages(strTemp, Result, "Add_Axis_For_Interpol()");
                    // return false;
                }
                else//add axis success
                {
                    //  CmbOperateAxis.Items.Add(CmbAxes.Items[CmbAxes.SelectedIndex]);
                    // CmbOperateAxis.SelectedIndex = (int)AxCountInGp;
                    AxisArray[AxCountInGp] = (uint)Read_Axishand;
                    AxCountInGp++;
                    // list1.Add((string)CmbAxes.Items[CmbAxes.SelectedIndex]);
                    m_IsGpOpen = true;
                }
                return Grphand[Interpolation_index];
            }
            catch (Exception es)
            {
                Logger.WriteLog(Logger.LogType.Error, "Advantech_PCIE", "Add_Axis_For_Interpoll()", "Exception Error", es.ToString());
                // AdvanTechPCIE.WriteLog("Device_Interface", "Add_Axis_For_Interpoll()", "PCIE-1203_Interface", "Exception Error", es.ToString());
                return Grphand[Interpolation_index];
            }
            //Sort listBoxAxesInGp
        }
        /// <summary>
        /// Remove the Axis interpolation
        /// </summary>
        /// <param name="axis">Output as current positions</param>
        public void Rem_Axis_Interpol()
        {
            try
            {
                uint Result = Motion.mAcm_GpRemAxis(m_GpHand, m_Axishand[Read_Axishand]);
            }
            catch (Exception es)
            {

            }
        }
        /// <summary>
        /// Set the Linear Linear_interpol_speed
        /// </summary>
        /// <param name="gtvelprm"> array string</param>
        /// <param name="Grphand"> Input Parameter</param>
        public bool Linear_interpol_speed(string[] gtvelprm, IntPtr Grphand)
        {
            try
            {
                UInt32 Result;
                double GpVelLow;
                double GpVelHigh;
                double GpAcc;
                double GpDec;
                double GpJerk;
                string strTemp;
                // GetGroupVelocityParam();

                //GpVelLow = Convert.ToDouble(gtvelprm[0])/12;
                GpVelLow = 0.0;
                // Set low velocity (start velocity) of this group (Unit: PPU/s). 
                // This property value must be smaller than or equal to Par_GpVelHigh .
                // The default value is the first added axis' PAR_AxVelLow
                //You  can also use the old API:Motion.mAcm_SetProperty(m_GpHand,(uint)PropertyID.PAR_GpVelLow,ref GpVelLow,BufferLength)
                //uint BufferLength;
                //BufferLength =8; buffer size for the property
                Result = Motion.mAcm_SetF64Property(Grphand, (uint)PropertyID.PAR_GpVelLow, GpVelLow);
                if (Result != (uint)ErrorCode.SUCCESS)
                {
                    strTemp = "Set PAR_GpVelLow Property Failed: [0x" + Convert.ToString(Result, 16) + "]";
                    Logger.ShowMessages(strTemp, Result, "Linear_interpol_speed()");
                    return false;
                }
                GpVelHigh = Convert.ToDouble(gtvelprm[1]);
                //Set high velocity (driving velocity) of this group (Unit: PPU/s).
                //This property value must be smaller than first added axis'
                //CFG_AxMaxVel and greater than Par_GpVelLow. The default value is the first added axis' PAR_AxVelHigh
                //You  can also use the old API:Motion.mAcm_SetProperty(m_GpHand,(uint)PropertyID.PAR_GpVelHigh,ref  GpVelHigh,BufferLength)
                //uint BufferLength;
                //BufferLength =8; buffer size for the property
                Result = Motion.mAcm_SetF64Property(Grphand, (uint)PropertyID.PAR_GpVelHigh, GpVelHigh);
                if (Result != (uint)ErrorCode.SUCCESS)
                {
                    strTemp = "Set PAR_GpVelHigh Property Failed: [0x" + Convert.ToString(Result, 16) + "]";
                    Logger.ShowMessages(strTemp, Result, "Linear_interpol_speed()");
                    return false;
                }
                GpAcc = Convert.ToDouble(gtvelprm[2]);
                //Set acceleration of this group (Unit: PPU/s2). This property value
                //must be smaller than or equal to first added axis' CFG_AxMaxAcc.
                //The default value is the first added axis' PAR_AxAcc.    
                //You  can also use the old API:Motion.mAcm_SetProperty(m_GpHand,(uint)PropertyID.PAR_GpAcc,ref GpAcc,BufferLength)
                //uint BufferLength;
                //BufferLength =8; buffer size for the property
                Result = Motion.mAcm_SetF64Property(Grphand, (uint)PropertyID.PAR_GpAcc, GpAcc);
                if (Result != (uint)ErrorCode.SUCCESS)
                {
                    strTemp = "Set PAR_GpAcc Property Failed: [0x" + Convert.ToString(Result, 16) + "]";
                    Logger.ShowMessages(strTemp, Result, "Linear_interpol_speed()");
                    return false;
                }
                GpDec = Convert.ToDouble(gtvelprm[3]);
                //Set deceleration of this group (Unit: PPU/s2). This property value
                //must be smaller than or equal to first added axis' CFG_AxMaxDec.
                //The default value is the first added axis' PAR_AxDec
                //You  can also use the old API:Motion.mAcm_SetProperty(m_GpHand,(uint)PropertyID.PAR_GpDec,ref GpDec,BufferLength)
                //uint BufferLength;
                //BufferLength =8; buffer size for the property
                Result = Motion.mAcm_SetF64Property(Grphand, (uint)PropertyID.PAR_GpDec, GpDec);
                if (Result != (uint)ErrorCode.SUCCESS)
                {
                    strTemp = "Set PAR_GpDec Property Failed: [0x" + Convert.ToString(Result, 16) + "]";
                    Logger.ShowMessages(strTemp, Result, "Linear_interpol_speed()");
                    return false;
                }
                //if (formgroupparamset.rdb_T.Checked)
                //{
                //  GpJerk = 0;
                //}
                //else
                //{
                GpJerk = 1;//s-curve
                           //}
                           //Set the type of velocity profile: t-curve or s-curve
                           //You  can also use the old API:Motion.mAcm_SetProperty(m_GpHand,(uint)PropertyID.PAR_GpJerk,ref GpJerk,BufferLength)
                           //uint BufferLength;
                           //BufferLength =8; buffer size for the property
                Result = Motion.mAcm_SetF64Property(Grphand, (uint)PropertyID.PAR_GpJerk, GpJerk);
                if (Result != (uint)ErrorCode.SUCCESS)
                {
                    strTemp = "Set PAR_GpJerk Property Failed: [0x" + Convert.ToString(Result, 16) + "]";
                    Logger.ShowMessages(strTemp, Result, "Linear_interpol_speed()");
                    return false;
                }
                return true;
            }
            catch (Exception es)
            {
                Logger.WriteLog(Logger.LogType.Error, "Advantech_PCIE", "Linear_interpol_speed(Gantry)", "Exception Error", es.ToString());
                return false;
            }
        }
        /// <summary>
        /// Set the Linear Linear_interpol_speed
        /// </summary>        
        /// <param name="Grphand"> Input Parameter</param>
        public string[] GetGroupVelocityParam(IntPtr Grphand)
        {
            try
            {
                UInt32 Result;
                double GpVelLow = 0;
                double GpVelHigh = 0;
                double GpAcc = 0;
                double GpDec = 0;
                string strTemp;
                // FormGroupParamSet formgroupparamset = new FormGroupParamSet();
                // Get low velocity (start velocity) of this group (Unit: PPU/s). 
                //You can also use the old API:  Motion.mAcm_GetProperty(m_GpHand,(uint)PropertyID.PAR_GpVelLow, ref GpVelLow,ref BufferLen);
                //uint BufferLength;
                //BufferLength =8; buffer size for the property
                Result = Motion.mAcm_GetF64Property(Grphand, (uint)PropertyID.PAR_GpVelLow, ref GpVelLow);
                if (Result != (uint)ErrorCode.SUCCESS)
                {
                    strTemp = "Get PAR_GpVelLow Property Failed With Error Code: [0x" + Convert.ToString(Result, 16) + "]";
                    Logger.ShowMessages(strTemp, Result, "GetGroupVelocityParam()");
                    return grpvelparam;
                }
                grpvelparam[0] = Convert.ToString(GpVelLow);
                // Get high velocity (driving velocity) of this group (Unit: PPU/s).
                //You can also use the old API:  Motion.mAcm_GetProperty(m_GpHand,(uint)PropertyID.PAR_GpVelHigh, ref GpVelHigh,ref BufferLen);
                //uint BufferLength;
                //BufferLength =8; buffer size for the property
                Result = Motion.mAcm_GetF64Property(Grphand, (uint)PropertyID.PAR_GpVelHigh, ref GpVelHigh);
                if (Result != (uint)ErrorCode.SUCCESS)
                {
                    strTemp = "Get PAR_GpVelHigh Property Failed With Error Code: [0x" + Convert.ToString(Result, 16) + "]";
                    Logger.ShowMessages(strTemp, Result, "GetGroupVelocityParam()");
                    return grpvelparam;
                }
                grpvelparam[1] = Convert.ToString(GpVelHigh);
                //Get acceleration of this group (Unit: PPU/s2).
                //You can also use the old API:  Motion.mAcm_GetProperty(m_GpHand,(uint)PropertyID.PAR_GpAcc, ref GpAcc,ref BufferLen);
                //uint BufferLength;
                //BufferLength =8; buffer size for the property
                Result = Motion.mAcm_GetF64Property(Grphand, (uint)PropertyID.PAR_GpAcc, ref GpAcc);
                if (Result != (uint)ErrorCode.SUCCESS)
                {
                    strTemp = "Get PAR_GpAcc Property Failed With Error Code: [0x" + Convert.ToString(Result, 16) + "]";
                    Logger.ShowMessages(strTemp, Result, "GetGroupVelocityParam()");
                    return grpvelparam;
                }
                grpvelparam[2] = Convert.ToString(GpAcc);
                //Get deceleration of this group (Unit: PPU/s2).
                //You can also use the old API:  Motion.mAcm_GetProperty(m_GpHand,(uint)PropertyID.PAR_GpDec, ref GpDec,ref BufferLen);
                //uint BufferLength;
                //BufferLength =8; buffer size for the property
                Result = Motion.mAcm_GetF64Property(Grphand, (uint)PropertyID.PAR_GpDec, ref GpDec);
                if (Result != (uint)ErrorCode.SUCCESS)
                {
                    strTemp = "Get PAR_GpDec Property Failed With Error Code: [0x" + Convert.ToString(Result, 16) + "]";
                    Logger.ShowMessages(strTemp, Result, "GetGroupVelocityParam()");
                    return grpvelparam;
                }
                grpvelparam[3] = Convert.ToString(GpDec);
                return grpvelparam;
            }
            catch (Exception es)
            {
                Logger.WriteLog(Logger.LogType.Error, "Advantech_PCIE", "GetGroupVelocityParam(Gantry)", "Exception Error", es.ToString());
                return grpvelparam;
            }
        }
        /// <summary>
        /// Set the Linear Linear_interpol_speed
        /// </summary>        
        /// <param name="Grphand"> Input Parameter</param>
        public bool interpol_movement(string Abs, double[] Distance, IntPtr GrpHand)
        {
            try
            {
                uint Result;
                uint AxisNum = new uint();
                string strTemp;
                AxisNum = AxCountInGp;
                if (Abs.ToUpper() != "ABS")
                {
                    //Command group to execute relative line interpolation
                    Result = Motion.mAcm_GpMoveLinearRel(GrpHand, Distance, ref AxisNum);
                }
                else
                {
                    //Command group to execute absolute line interpolation
                    Result = Motion.mAcm_GpMoveLinearAbs(GrpHand, Distance, ref AxisNum);
                }
                if (Result != (uint)ErrorCode.SUCCESS)
                {
                    strTemp = "Move Failed With Error Code[0x" + Convert.ToString(Result, 16) + "]";
                    Logger.ShowMessages(strTemp, Result, "interpol_movement");
                    return false;
                }
                return true;
            }
            catch (Exception es)
            {
                Logger.WriteLog(Logger.LogType.Error, "Advantech_PCIE", "interpol_movement(gantry)", "Exception Error", es.ToString());
                return false;
            }
        }
        /// <summary>
        /// Set the Linear Linear_interpol_speed
        /// </summary>        
        /// <param name="Grphand"> Input Parameter</param>
        public bool interpol_movement_ARC(string Abs, double[] Distance_center, double[] Distance_End)
        {
            try
            {
                uint Result = 0;
                uint AxisNum = new uint();
                string strTemp;
                AxisNum = AxCountInGp;
                if (Abs.ToUpper() != "ABS")
                {
                    //Command group to execute relative line interpolation
                    // Result = Motion.mAcm_GpMoveLinearRel(m_GpHand, Distance, ref AxisNum);
                }
                else
                {
                    //Command group to execute absolute line interpolation
                    // Result = Motion.mAcm_GpMoveLinearAbs(m_GpHand, Distance, ref AxisNum);
                    Result = Motion.mAcm_GpMoveCircularAbs_3P(m_GpHand, Distance_center, Distance_End, 1);
                    // Result = Motion.mAcm_GpMoveCircularAbs(m_GpHand, Distance_center, Distance_End,1);
                    // Result = Motion.mAcm_GpMoveEllipticalAbs(m_GpHand,Distance_center, Distance_End, 1,);
                }
                if (Result != (uint)ErrorCode.SUCCESS)
                {
                    strTemp = "Move Failed With Error Code[0x" + Convert.ToString(Result, 16) + "]";
                    Logger.ShowMessages(strTemp, Result, "interpol_movement");
                    return false;
                }
                return true;
            }
            catch (Exception es)
            {
                Logger.WriteLog(Logger.LogType.Error, "Advantech_PCIE", "interpol_movement_ARC()", "Exception Error", es.ToString());
                return false;
            }
        }
        /// <summary>
        /// Set the Linear Linear_interpol_speed
        /// </summary>        
        /// <param name="Grphand"> Input Parameter</param>
        public bool interpol_movement_ARC(string Abs, double[] Distance_center, double[] Distance_End, IntPtr GrpHand)
        {
            try
            {
                uint Result = 0;
                uint AxisNum = new uint();
                string strTemp;
                AxisNum = AxCountInGp;
                if (Abs.ToUpper() != "ABS")
                {
                    //Command group to execute relative line interpolation
                    // Result = Motion.mAcm_GpMoveLinearRel(m_GpHand, Distance, ref AxisNum);
                }
                else
                {
                    //Command group to execute absolute line interpolation
                    // Result = Motion.mAcm_GpMoveLinearAbs(m_GpHand, Distance, ref AxisNum);
                    Result = Motion.mAcm_GpMoveCircularAbs_3P(GrpHand, Distance_center, Distance_End, 1);
                    // Result = Motion.mAcm_GpMoveCircularAbs(m_GpHand, Distance_center, Distance_End,1);
                    // Result = Motion.mAcm_GpMoveEllipticalAbs(m_GpHand,Distance_center, Distance_End, 1,);
                }
                if (Result != (uint)ErrorCode.SUCCESS)
                {
                    strTemp = "Move Failed With Error Code[0x" + Convert.ToString(Result, 16) + "]";
                    Logger.ShowMessages(strTemp, Result, "interpol_movement");
                    return false;
                }
                return true;
            }
            catch (Exception es)
            {
                Logger.WriteLog(Logger.LogType.Error, "Advantech_PCIE", "interpol_movement_ARC(Gantry)", "Exception Error", es.ToString());
                return false;
            }
        }
        public void InterpolationMove(int Axis1, int Axis2, double Xdis, double Ydis, bool isNeedCheckDone)
        {
            try
            {
                ushort inter_state = 0;
                double[] positionArray = new double[2] { Xdis, Ydis };
                Motion.mAcm_GpAddAxis(ref grpHandle[0], m_Axishand[Axis1]);
                Motion.mAcm_GpAddAxis(ref grpHandle[0], m_Axishand[Axis2]);

                UInt32 ret;
                ret = Motion.mAcm_SetF64Property(grpHandle[0], (uint)PropertyID.PAR_GpVelLow, 10 * Global_pulse);
                ret = Motion.mAcm_SetF64Property(grpHandle[0], (uint)PropertyID.PAR_GpVelHigh, 100 * Global_pulse);
                ret = Motion.mAcm_SetF64Property(grpHandle[0], (uint)PropertyID.PAR_GpAcc, 5000 * Global_pulse);
                ret = Motion.mAcm_SetF64Property(grpHandle[0], (uint)PropertyID.PAR_GpDec, 5000 * Global_pulse);
                ret = Motion.mAcm_SetF64Property(grpHandle[0], (uint)PropertyID.PAR_GpJerk, 0);




                // Motion.mAcm_GpChangeVel(grpHandle[0], 20 * Global_pulse);
                Motion.mAcm_GpMoveLinearAbs(grpHandle[0], positionArray);

                //Arulkumar Fixed Hung start
                System.Diagnostics.Stopwatch gpSw = new System.Diagnostics.Stopwatch();
                gpSw.Start();
                while (true)
                {
                    Motion.mAcm_GpGetState(grpHandle[0], ref inter_state);
                    if (inter_state == 1)
                    {
                        break;
                    }
                    if (gpSw.ElapsedMilliseconds > 15000)
                    {
                        break;
                    }
                }
                //Arulkumar Fixed Hung end

            }
            //Arulkumar Fixed random stoppage start
            catch (Exception ex)
            {
                Logger.WriteLog(Logger.LogType.Error, "Advantech_PCIE_Stepper", "GpMoveLinearAbs", ex.Message, ex.ToString());
            }
            //Arulkumar Fixed random stoppage end
        }

        #endregion
        /// <summary>
        /// Get current position, Status of the specified axis
        /// </summary>
        /// <param name="Actpos">Output as current positions</param>
        /// <param name="Act_status">output asCurrent status</param>
        /// <param name="Act_Vel">Get current velocity</param>
        public void GetCurrentPos(out double Actpos, out string Act_status, out double Act_Vel)
        {
            try
            {
                double CurCmd = new double();
                double CurPos = new double();
                double CurrVel = new double();
                Actpos = 0.0;
                Act_Vel = 0.0;
                Act_status = "";
                UInt16 AxState = new UInt16();
                UInt32 Result;
                UInt32 IOStatus = new UInt32();
                if (m_bInit)
                {
                    //Get current command position of the specified axis
                    Motion.mAcm_AxGetActualPosition(m_Axishand[Read_Axishand], ref CurCmd);
                    //Get current actual position of the specified axis
                    Motion.mAcm_AxGetActualPosition(m_Axishand[Read_Axishand], ref CurPos);
                    Actpos = CurPos / Global_pulse;
                    //  Motion.mAcm_AxGetCmdPosition(m_Axishand[Axis], ref CurCmd);
                    Motion.mAcm_AxGetCmdVelocity(m_Axishand[Read_Axishand], ref CurrVel);
                    Act_Vel = CurrVel;
                    //Get the Axis's current state
                    Motion.mAcm_AxGetState(m_Axishand[Read_Axishand], ref AxState);
                    Act_status = ((AxisState)AxState).ToString();

                }

            }
            catch (Exception es)
            {
                Logger.WriteLog(Logger.LogType.Error, "Advantech_PCIE", "ToGetCurrentPos()", "Exception Error", es.ToString());
                Actpos = 0.0;
                Act_Vel = 0.0;
                Act_status = "";
            }
        }
        /// <summary>
        /// To Get Current Servo Status 
        /// </summary>
        /// <returns>Its Retun Servo Status 0 - STA_AX_DISABLE , 1- STA_AX_READY, 2 - STA_AX_STOPPING, 3 - STA_AX_ERROR_STOP, 4- STA_AX_HOMING, 5 - STA_AX_PTP_MOT, 6 - STA_AX_CONTI_MOT, 7 - STA_AX_SYNC_MOT, 8 - STA_AX_EXT_JOG, 9 - STA_AX_EXT_MPG</returns>
        public string ToGetStatus()
        {
            string Status = string.Empty;
            try
            {

                UInt16 AxState = new UInt16();
                if (m_bInit)
                {
                    //Get current command position of the specified axis
                    //Get the Axis's current state
                    // 0 - Disable, 1 - Ready, 2 - Stopping, 3 - Error_Stop, 4 - Homming, 5 - Motion moving
                    Motion.mAcm_AxGetState(m_Axishand[Read_Axishand], ref AxState);
                    Status = ((AxisState)AxState).ToString();


                }
                return Status;
            }
            catch (Exception es)
            {
                Logger.WriteLog(Logger.LogType.Error, "Advantech_PCIE", "ToGetCurrentPos_sts_Nozzle()", "Exception Error", es.ToString());
                return Status;
            }
        }

        public void GetActualVelocity(out double Act_Vel)
        {
            try
            {
                double CurrVel = new double();
                Act_Vel = 0.0;
                Motion.mAcm_AxGetCmdVelocity(m_Axishand[Read_Axishand], ref CurrVel);
                Act_Vel = CurrVel;
            }
            catch (Exception es)
            {
                Logger.WriteLog(Logger.LogType.Error, "Advantech_PCIE", "", "Exception Error", es.ToString());
                Act_Vel = 0.0;
            }
        }

        /// <summary>
        /// To Get ToGetCurrentPos_Nozzle
        /// </summary>
        /// <returns></returns>

        public string[] ToGetCurrentPos_Nozzle()
        {
            try
            {
                double CurCmd = new double();
                double CurPos = new double();

                UInt16 AxState = new UInt16();
                UInt32 Result;
                UInt32 IOStatus = new UInt32();
                if (m_bInit)
                {
                    //Get current command position of the specified axis

                    //Get current actual position of the specified axis
                    Motion.mAcm_AxGetActualPosition(m_Axishand[0], ref CurPos);
                    cur_pos_N[0] = Convert.ToString(CurPos);
                    Motion.mAcm_AxGetActualPosition(m_Axishand[1], ref CurPos);
                    cur_pos_N[1] = Convert.ToString(CurPos);
                    Motion.mAcm_AxGetActualPosition(m_Axishand[2], ref CurPos);
                    cur_pos_N[2] = Convert.ToString(CurPos);
                    Motion.mAcm_AxGetActualPosition(m_Axishand[3], ref CurPos);
                    cur_pos_N[3] = Convert.ToString(CurPos);

                }
                return cur_pos_N;
            }
            catch (Exception es)
            {
                Logger.WriteLog(Logger.LogType.Error, "ToGetCurrentPos_Nozzle()", "PCIE-1203_Interface", "Exception Error", es.ToString());
                return cur_pos_N;
            }

        }

        /// <summary>
        /// Write_Cur_pos_To_Amax3285IO to the Board 
        /// </summary>
        /// <returns></returns>
        public void Write_Cur_pos_To_Amax3285IO(int Refaxis1, int Refaxis2, int Setaxis1, int Setaxis2)
        {
            try
            {
                double[] pos = ToGetCurrentPos_Gantry(Refaxis1, Refaxis2);
                Set_Act_Pos_TO_card(Setaxis1, pos[0]);
                Set_Act_Pos_TO_card(Setaxis2, pos[1]);
            }
            catch (Exception es)
            {
                Logger.WriteLog(Logger.LogType.Error, "Write_Cur_pos_TO_Amax3285IO()", "PCIE-1203_Interface", "Exception Error", es.ToString());

            }


        }
        /// <summary>
        /// ToGetCurrentPos_Gantry position of Gantry 
        /// </summary>
        /// <returns>to Return Duble Array Data</returns>
        public double[] ToGetCurrentPos_Gantry(int Axis1, int Axis2)
        {
            try
            {
                double CurPos = new double();

                if (m_bInit)
                {

                    Motion.mAcm_AxGetActualPosition(m_Axishand[Axis1], ref CurPos);
                    cur_posG[0] = CurPos;
                    Motion.mAcm_AxGetActualPosition(m_Axishand[Axis2], ref CurPos);
                    cur_posG[1] = CurPos;


                }
                return cur_posG;
            }
            catch (Exception es)
            {
                Logger.WriteLog(Logger.LogType.Error, "ToGetCurrentPos_Gantry()", "PCIE-1203_Interface", "Exception Error", es.ToString());
                return cur_posG;
            }


        }
        /// <summary>
        /// ToGetCurrentPos_sts_gantry 
        /// </summary>
        /// <returns>to Return the String</returns>
        public string[] ToGetCurrentPos_sts_gantry(int Axis1, int Axis2)
        {
            string[] Status = new string[2];
            try
            {
                UInt16 AxState = new UInt16();

                if (m_bInit)
                {
                    //Get current command position of the specified axis
                    //Get the Axis's current state
                    Motion.mAcm_AxGetState(m_Axishand[Axis1], ref AxState);
                    Status[0] = ((AxisState)AxState).ToString();
                    Motion.mAcm_AxGetState(m_Axishand[Axis2], ref AxState);
                    Status[1] = ((AxisState)AxState).ToString();

                }
                return Status;
            }
            catch (Exception es)
            {
                Logger.WriteLog(Logger.LogType.Error, "ToGetCurrentPos_sts_gantry()", "PCIE-1203_Interface", "Exception Error", es.ToString());
                return Status;
            }

        }
        /// <summary>
        /// To Get the Nozzle Current Position
        /// </summary>
        /// <returns>to Return the String</returns>
        public string ToGetCurrentPos_sts_Nozzle()
        {
            string Status = string.Empty;
            try
            {

                UInt16 AxState = new UInt16();
                if (m_bInit)
                {
                    //Get current command position of the specified axis
                    //Get the Axis's current state
                    Motion.mAcm_AxGetState(m_Axishand[Read_Axishand], ref AxState);
                    Status = ((AxisState)AxState).ToString();


                }
                return Status;
            }
            catch (Exception es)
            {
                Logger.WriteLog(Logger.LogType.Error, "ToGetCurrentPos_sts_Nozzle()", "PCIE-1203_Interface", "Exception Error", es.ToString());
                return Status;
            }
        }

        #endregion
        /// <summary>
        /// To enable the EventCheck
        /// </summary>
        /// <returns>REturn Bool</returns>
        public bool EnableEventCheck()
        {
            try
            {
                bool process = false;
                uint Result;
                string strTemp;
                Result = Motion.mAcm_DevEnableEvent(m_DeviceHandle, IO_DevEnableEvt);
                if (Result != (uint)ErrorCode.SUCCESS)
                {
                    strTemp = "DevEnableEvent Failed With Error Code[0x" + Convert.ToString(Result, 16) + "]";
                    Logger.ShowMessages(strTemp, Result, "EnableEventCheck_IO()");
                    return false;
                }
                Result = Motion.mAcm_DevEnableEvent(m_DeviceHandle, Motion_DevEnableEvt);
                if (Result != (uint)ErrorCode.SUCCESS)
                {
                    strTemp = "DevEnableEvent Failed With Error Code[0x" + Convert.ToString(Result, 16) + "]";
                    Logger.ShowMessages(strTemp, Result, "EnableEventCheck_Motion()");
                    return false;
                }
                return process;
            }
            catch (Exception es)
            {
                Logger.WriteLog(Logger.LogType.Error, "Advantech_PCIE", "EnableEventCheck()", "Exception Error", es.ToString());
                return false;
            }
        }
        /// <summary>
        /// To check the Connection Event when we recieve the Error
        /// </summary>
        /// <param name="Axis_Error">pass the error which we recieved</param>
        /// <param name="IO_Error">pass the IO error Code</param>
        /// <returns></returns>
        public void CheckConnectionEvent(out int Axis_Error, out int IO_Error)
        {
            try
            {
                bool process = false;
                uint result;
                if (!DisConnect_Err_bit)
                {
                    uint DevEvtStatus = 0;
                    uint DevEvtStatus_Motion = 0;
                    result = Motion.mAcm_DevCheckEvent(m_DeviceHandle, ref DevEvtStatus, 10);
                    if (result == (uint)ErrorCode.SUCCESS)
                    {
                        if ((DevEvtStatus & (uint)EventType.EVT_DEV_DISCONNET) > 0)
                        {
                            DevMotRingDisCnt++;
                        }
                        if ((DevEvtStatus & (uint)EventType.EVT_DEV_IO_DISCONNET) > 0)
                        {
                            DevIORingDisCnt++;
                        }
                    }
                }
                if (!DisConnect_Err_bit && DevMotRingDisCnt > 0)
                {

                    DisConnect_Err_bit = true;
                    DevMotRingDisCnt = 0;
                    Axis_Error = 1;

                }
                else
                {

                    Axis_Error = 0;
                }
                if (!DisConnect_Err_bit && DevIORingDisCnt > 0)
                {

                    DisConnect_Err_bit = true;
                    DevIORingDisCnt = 0;
                    IO_Error = 1;
                }
                else
                {
                    IO_Error = 0;
                }
            }
            catch (Exception es)
            {
                IO_Error = 0;
                Axis_Error = 0;
                Logger.WriteLog(Logger.LogType.Error, "Advantech_PCIE", "CheckConnectionEvent()", "Exception Error", es.ToString());
                return;
            }
        }
        /// <summary>
        /// To Stop all axis Servo Motions 
        /// </summary>
        /// <returns></returns>
        public void Kill_All_Motions()
        {
            try
            {
                for (int AxisNum = 0; AxisNum < Axiscount; AxisNum++)
                {
                    if (AxisNum < 10)
                    {
                        // Stop(AxisNum);
                        try
                        {
                            uint Result;
                            string strTemp;
                            if (m_bInit)
                            {
                                //To command axis to decelerate to stop.
                                Result = Motion.mAcm_AxStopDec(m_Axishand[AxisNum]);

                                //Result = Motion.mAcm_AxStopEmg(m_Axishand[Axis]);
                                if (Result != (uint)ErrorCode.SUCCESS)
                                {
                                    strTemp = "Axis To decelerate Stop Failed With Error Code: [0x" + Convert.ToString(Result, 16) + "]";
                                    Logger.ShowMessages(strTemp, Result, "Stop()");
                                    //return false;
                                }
                            }
                            // return true;

                        }
                        catch (Exception es)
                        {
                            Logger.WriteLog(Logger.LogType.Error, "Advantech_PCIE", "Kill_All_Motions_Stop()", "Exception Error", es.ToString());
                            //return false;
                        }
                    }




                }


            }
            catch (Exception es)
            {
                Logger.WriteLog(Logger.LogType.Error, "Advantech_PCIE", "Kill_All_Motions()", "Exception Error", es.ToString());
                return;
            }
            //Ethercat
        }

        #region "Homing"

        static string[] hmemode = new string[100];
        static UInt32[] Uint_hmemode = new UInt32[100];

        /// <summary>
        /// To Get Home_methods
        /// </summary>
        /// <returns>THome Methods </returns>
        public void GetHome_methods()
        {
            // Retrieves and stores all available home modes from two enums: HomeMode and Cia402HomeMode.
            // Converts them to string and unsigned int arrays for later use.
            try
            {
                int j = 0;
                foreach (HomeMode i in Enum.GetValues(typeof(HomeMode)))
                {

                    hmemode[j] = i.ToString();
                    Uint_hmemode[j] = (UInt32)i;
                    j++;
                }
                foreach (Cia402HomeMode i in Enum.GetValues(typeof(Cia402HomeMode)))
                {

                    hmemode[j] = i.ToString();
                    Uint_hmemode[j] = (UInt32)i;
                    j++;
                }
            }
            catch (Exception es)
            {
                Logger.WriteLog(Logger.LogType.Error, "Advantech_PCIE", "GetHome_methods()", "Exception Error", es.ToString());
                return;
            }
        }
        /// <summary>
        /// when Press Home to set the Homming Parametter
        /// </summary>
        /// <param name="Axis">To Pass the selected Axis for Homming</param>
        /// <param name="vel">pass the Vel</param>
        /// <param name="Acc">Pass the accelaration</param>
        /// <param name="DeAcc">Pass the De-accelaration</param>
        /// <returns>Return Bool </returns>
        public bool Set_Home_Vel(double vel, double Acc, double DeAcc)
        {
            bool process = false;
            try
            {
                UInt32 Result;
                double axHomeVelLow;
                double axHomeVelHigh;
                double axHomeAcc;
                double axHomeDec;
                double axHomeJerk;
                string strTemp;
                //axHomeVelLow = 1 * Global_pulse;
                axHomeVelLow = 100;
                //Set low velocity (start velocity) of this axis (Unit: PPU/S).
                //This property value must be smaller than or equal to PAR_AxVelHigh
                //You can also use the old API:Motion.mAcm_SetProperty(m_Axishand[CmbAxes.SelectedIndex], (uint)PropertyID.PAR_AxVelLow, ref AxVelLow, BufferLength);
                // UInt32  BufferLength;
                //BufferLength =8; buffer size for the property
                Result = Motion.mAcm_SetF64Property(m_Axishand[Read_Axishand], (uint)PropertyID.PAR_AxHomeVelLow, axHomeVelLow);
                if (Result != (uint)ErrorCode.SUCCESS)
                {
                    strTemp = "Set low velocity failed with error code: [0x" + Convert.ToString(Result, 16) + "]";
                    Logger.ShowMessages(strTemp, Result, "Set_Home_Vel()");
                    return process;
                }
                axHomeVelHigh = vel * Global_pulse;
                // Set high velocity (driving velocity) of this axis (Unit: PPU/s).
                //This property value must be smaller than CFG_AxMaxVel and greater than PAR_AxVelLow
                //You can also use the old API:Motion.mAcm_SetProperty(m_Axishand[CmbAxes.SelectedIndex], (uint)PropertyID.PAR_AxVelHigh,ref AxVelHigh,BufferLength)
                // UInt32  BufferLength;
                //BufferLength =8; buffer size for the property
                Result = Motion.mAcm_SetF64Property(m_Axishand[Read_Axishand], (uint)PropertyID.PAR_AxHomeVelHigh, axHomeVelHigh);
                if (Result != (uint)ErrorCode.SUCCESS)
                {
                    strTemp = "Set high velocity failed with error code: [0x" + Convert.ToString(Result, 16) + "]";
                    Logger.ShowMessages(strTemp, Result, "Set_Home_Vel()");
                    return process;
                }
                axHomeAcc = Acc * Global_pulse;
                // Set acceleration of this axis (Unit: PPU/s2).
                //This property value must be smaller than or equal to CFG_AxMaxAcc
                //You can also use the old API:Motion.mAcm_SetProperty(m_Axishand[CmbAxes.SelectedIndex], (uint)PropertyID.PAR_AxAcc,ref AxAcc,BufferLength)
                // UInt32  BufferLength;
                //BufferLength =8; buffer size for the property
                Result = Motion.mAcm_SetF64Property(m_Axishand[Read_Axishand], (uint)PropertyID.PAR_AxHomeAcc, axHomeAcc);
                if (Result != (uint)ErrorCode.SUCCESS)
                {
                    strTemp = "Set acceleration failed with error code: [0x" + Convert.ToString(Result, 16) + "]";
                    Logger.ShowMessages(strTemp, Result, "Set_Home_Vel()");
                    return process;
                }
                axHomeDec = DeAcc * Global_pulse;
                //Set deceleration of this axis (Unit: PPU/s2).
                //This property value must be smaller than or equal to CFG_AxMaxDec
                //You can also use the old API:Motion.mAcm_SetProperty(m_Axishand[CmbAxes.SelectedIndex], (uint)PropertyID.PAR_AxDcc,ref AxDec,BufferLength)
                // UInt32  BufferLength;
                //BufferLength =8; buffer size for the property
                Result = Motion.mAcm_SetF64Property(m_Axishand[Read_Axishand], (uint)PropertyID.PAR_AxHomeDec, axHomeDec);
                if (Result != (uint)ErrorCode.SUCCESS)
                {
                    strTemp = "Set deceleration failed with error code: [0x" + Convert.ToString(Result, 16) + "]";
                    Logger.ShowMessages(strTemp, Result, "Set_Home_Vel()");
                    return process;
                }

                axHomeJerk = 0;

                //Set the type of velocity profile: t-curve or s-curve
                //You can also use the old API:Motion.mAcm_SetProperty(m_Axishand[CmbAxes.SelectedIndex], (uint)PropertyID.PAR_AxJerk,ref AxJerk,BufferLength)
                // UInt32  BufferLength;
                //BufferLength =8; buffer size for the property
                Result = Motion.mAcm_SetF64Property(m_Axishand[Read_Axishand], (uint)PropertyID.PAR_AxHomeJerk, axHomeJerk);
                if (Result != (uint)ErrorCode.SUCCESS)
                {
                    strTemp = "Set the type of velocity profile failed with error code: [0x" + Convert.ToString(Result, 16) + "]";
                    Logger.ShowMessages(strTemp, Result, "Set_Home_Vel()");
                    return process;
                }
                process = true;
                return process;
            }
            catch (Exception es)
            {
                return process;
            }
        }


        double HOM_Vel_Low = 50;
        double HOM_Acc = 0;
        double HOM_Dec = 0;
        double HOM_Vel_High = 0;


        public bool Set_Home_Param(double VelLow, double VelHigh, double Acc, double Dec)
        {
            //VelHigh = VelHigh * 10000;
            HOM_Vel_Low = VelLow * Global_pulse;
            HOM_Acc = Acc * Global_pulse;
            HOM_Dec = Dec * Global_pulse;
            HOM_Vel_High = VelHigh * Global_pulse;

            return true;
        }



        /// <summary>
        /// Homming
        /// </summary>
        /// <param name="dir">Homming Directions</param>
        /// <returns>Retuns bool</returns>
        public bool Homing(uint dir)
        {
            bool process = false;
            try
            {
                // ✅ Add Homing Speed Parameters (VelLow, VelHigh, Acc, Dec)

                string strTemp;
                UInt32 Result;
                //UInt32 PropertyVal = new UInt32();
                double CrossDistance = new double();

                //Check Axis Status
                ushort statusWord = 0;
                Result = Motion.mAcm_AxGetState(m_Axishand[Read_Axishand], ref statusWord);
                if (Result != (ushort)ErrorCode.SUCCESS)
                {
                    strTemp = "Faild To Get Axis State With Error Code: [0x" + Convert.ToString(Result, 16) + "]";
                    Logger.ShowMessages(strTemp, Result, "Axes_Homing()");
                    return false;
                }
                UInt32 sts = 0;
                Result = Motion.mAcm_AxGetMotionStatus(m_Axishand[Read_Axishand], ref sts);
                if (Result != (ushort)ErrorCode.SUCCESS)
                {
                    strTemp = "Faild To Get Motion Status With Error Code: [0x" + Convert.ToString(Result, 16) + "]";
                    Logger.ShowMessages(strTemp, Result, "Axes_Homing()");
                    return false;
                }

                Motion.mAcm_SetF64Property(m_Axishand[Read_Axishand], (uint)PropertyID.PAR_AxHomeVelLow, HOM_Vel_Low);
                Motion.mAcm_SetF64Property(m_Axishand[Read_Axishand], (uint)PropertyID.PAR_AxHomeVelHigh, HOM_Vel_High);
                Motion.mAcm_SetF64Property(m_Axishand[Read_Axishand], (uint)PropertyID.PAR_AxHomeAcc, HOM_Acc);
                Motion.mAcm_SetF64Property(m_Axishand[Read_Axishand], (uint)PropertyID.PAR_AxHomeDec, HOM_Dec);
                bool isbusy = (sts & (1 << 0)) != 0;

                //PropertyVal = (UInt32)comboBoxSwitchMode.SelectedIndex;
                //Setting the stopping condition of Acm_AxHomeEx
                //You can also use the old API: Motion.mAcm_SetProperty(m_Axishand[CmbAxes.SelectedIndex], (uint)PropertyID.PAR_AxHomeExSwitchMode, ref PropertyVal, (uint)Marshal.SizeOf(typeof(UInt32)));
                //Result = Motion.mAcm_SetU32Property(m_Axishand[CmbAxes.SelectedIndex], (uint)PropertyID.PAR_AxHomeExSwitchMode, PropertyVal);
                //if (Result != (uint)ErrorCode.SUCCESS)
                //{
                //    strTemp = "Set Property-PAR_AxHomeExSwitchMode Failed With Error Code: [0x" + Convert.ToString(Result, 16) + "]";
                //    ShowMessages(strTemp, Result);
                //    return;
                //}
                CrossDistance = 100000;
                //Set the home cross distance (Unit: PPU). This property must be greater than 0. The default value is 10000
                //You can also use the old API: Motion.mAcm_SetProperty(m_Axishand[CmbAxes.SelectedIndex], (uint)PropertyID.PAR_AxHomeCrossDistance, ref CrossDistance, (uint)Marshal.SizeOf(typeof(double)));
                Result = Motion.mAcm_SetF64Property(m_Axishand[Read_Axishand], (uint)PropertyID.PAR_AxHomeCrossDistance, CrossDistance);
                if (Result != (uint)ErrorCode.SUCCESS)
                {
                    strTemp = "Set Property-AxHomeCrossDistance Failed With Error Code: [0x" + Convert.ToString(Result, 16) + "]";
                    Logger.ShowMessages(strTemp, Result, "Axes_Homing()");
                    return false;
                }
                //To command axis to start typical home motion. The 15 types of typical
                //home motion are composed of extended home
                Result = Motion.mAcm_AxMoveHome(m_Axishand[Read_Axishand], (UInt32)6, (UInt32)dir);
                if (Result != (uint)ErrorCode.SUCCESS)
                {
                    strTemp = "AxHome Failed With Error Code: [0x" + Convert.ToString(Result, 16) + "]";
                    Logger.ShowMessages(strTemp, Result, "Axes_Homing()");
                    return false;
                }

                //Task.Run(() =>
                //{
                //    while (ToGetStatus().ToUpper().Contains("HOMING"))
                //    {

                //    }
                //}
                //);
                while (ToGetStatus().ToUpper().Contains("HOMING"))
                {

                }
                //Thread.Sleep(5000);
                //if (ToGetStatus().ToUpper().Contains("HOMING"))
                //{
                //    Stop();
                //}
                //ResetAxis();
                Set_Zero_Pos();
                process = true;
                Home_Done = true;
                return process;

            }
            catch (Exception es)
            {
                Logger.WriteLog(Logger.LogType.Error, "Advantech_PCIE", "Axes_Homing()", "Exception Error", es.ToString());
                return process;
            }
        }




        public async Task<bool> ManulHoming(int dir, double HomingSpeed)
        {
            bool process = false;
            try
            {
                string strTemp;
                UInt32 Result;

                double CrossDistance = 100000; // Must be > 0

                // ✅ Set Homing Cross Distance
                Result = Motion.mAcm_SetF64Property(m_Axishand[Read_Axishand],
                (uint)PropertyID.PAR_AxHomeCrossDistance, CrossDistance);
                if (Result != (uint)ErrorCode.SUCCESS)
                {
                    strTemp = "Set Property - AxHomeCrossDistance Failed, Error: 0x" + Convert.ToString(Result, 16);
                    Logger.ShowMessages(strTemp, Result, "Axes_Homing()");
                    return false;
                }

                // ✅ Add Homing Speed Parameters (VelLow, VelHigh, Acc, Dec)


                double VelHigh = HomingSpeed * Global_pulse;   // Max speed (in PPU/sec)


                // Set all properties          
                Motion.mAcm_SetF64Property(m_Axishand[Read_Axishand], (uint)PropertyID.PAR_AxHomeVelLow, HOM_Vel_Low);
                Motion.mAcm_SetF64Property(m_Axishand[Read_Axishand], (uint)PropertyID.PAR_AxHomeVelHigh, VelHigh);
                Motion.mAcm_SetF64Property(m_Axishand[Read_Axishand], (uint)PropertyID.PAR_AxHomeAcc, HOM_Acc);
                Motion.mAcm_SetF64Property(m_Axishand[Read_Axishand], (uint)PropertyID.PAR_AxHomeDec, HOM_Dec);

                // ✅ Start Homing
                Result = Motion.mAcm_AxMoveHome(m_Axishand[Read_Axishand], (UInt32)6, (UInt32)dir);
                if (Result != (uint)ErrorCode.SUCCESS)
                {
                    strTemp = "AxHome Failed, Error Code: 0x" + Convert.ToString(Result, 16);
                    Logger.ShowMessages(strTemp, Result, "Axes_Homing()");
                    return false;
                }

                // ✅ Wait until homing completes
                while (ToGetStatus().ToUpper().Contains("HOMING"))
                {
                    await Task.Delay(50);
                }

                Set_Zero_Pos();  // Your zero position function
                process = true;
                Home_Done = true;

                return process;
            }
            catch (Exception ex)
            {
                Logger.WriteLog(Logger.LogType.Error, "Advantech_PCIE", "Axes_Homing()", "Exception Error", ex.ToString());
                return process;
            }
        }



        /// <summary>
        /// To Read Homming status for the selected axis is reached the Homming or not
        /// </summary>
        /// <param name="Axis">pass the Required servo to Homming </param>
        /// <returns>Retuns bool</returns>
        public bool[] Get_Axes_Home_status()
        {
            bool[] process = new bool[4];
            try
            {
                UInt32 Result;
                double CurCmd = new double();
                double ActCmd = new double();
                UInt16 AxState = new UInt16();
                UInt32 IOStatus = new UInt32();
                string strTemp = "";
                if (m_bInit)
                {
                    //Get the motion I/O status of the axis.
                    Result = Motion.mAcm_AxGetMotionIO(m_Axishand[Read_Axishand], ref IOStatus);
                    if (Result == (uint)ErrorCode.SUCCESS)
                    {
                        process = GetMotionIOStatus(IOStatus);
                    }

                }
                return process;
            }
            catch (Exception es)
            {
                return process;
            }
        }

        public bool CheckHome()
        {

            try
            {
                bool[] ioStatusArray = ToGetMotionIOStatus();
                return ioStatusArray[(int)MotionIOBit.ORG];
            }
            catch (Exception es)
            {
                return false;
            }
        }

        /// <summary>
        /// To Read Homming status for the selected axis is reached the Homming or not
        /// </summary>
        /// <param name="IOStatus">pass the IOStatus to read the servo reached the Limit or not</param>
        /// <returns>return Bool Array</returns>
        public bool[] GetMotionIOStatus(uint IOStatus)
        {
            bool[] process = new bool[4];
            if ((IOStatus & (uint)Ax_Motion_IO.AX_MOTION_IO_EZ) > 0)//ALM
            {
                process[0] = true;
            }
            else
            {
                process[0] = false;
            }

            if ((IOStatus & (uint)Ax_Motion_IO.AX_MOTION_IO_ORG) > 0)//ORG
            {
                process[1] = true;
            }
            else
            {
                process[1] = false;
            }

            if ((IOStatus & (uint)Ax_Motion_IO.AX_MOTION_IO_LMTP) > 0)//+EL
            {
                process[2] = true;
            }
            else
            {
                process[2] = false;
            }

            if ((IOStatus & (uint)Ax_Motion_IO.AX_MOTION_IO_LMTN) > 0)//-EL
            {
                process[3] = true;
            }
            else
            {
                process[3] = false;
            }
            return process;
        }

        #endregion

        #region "MultiCompare"
        /// <summary>
        /// Auto Compare the ppu which we given
        /// </summary>
        /// <param name="Start">Start Pulse</param>
        /// <param name="End">End Pulse</param>
        /// <param name="Interval">Interval</param>
        /// <param name="Cmp_Axis">which axis need to compare</param>
        /// <param name="PPR">PPR</param>
        /// <param name="pitch">Pitch</param>
        /// <returns>Return Bool</returns>
        public bool Compare_Auto(double Start, double End, double Interval, int Cmp_Axis, int PPR, double pitch)
        {
            bool process = false;
            try
            {
                uint Result;
                string strTemp;
                double Start_PPU1 = (Start * PPR) / pitch;
                double End_PPU2 = (End * PPR) / pitch;
                double Interval_PPU3 = (Interval * PPR) / pitch;
                Result = Motion.mAcm_AxSetCmpAuto(m_Axishand[Cmp_Axis], Start_PPU1, End_PPU2, Interval_PPU3);
                if (Result != (uint)ErrorCode.SUCCESS)
                {
                    strTemp = "AxSetCmpAuto Failed With Error Code[0x" + Convert.ToString(Result, 16) + "]";
                    Logger.ShowMessages(strTemp, Result, "Compare_Auto(Gantry)");
                    //ShowMessages(strTemp, Result);
                }
                process = true;
            }
            catch (Exception es)
            {
                Logger.WriteLog(Logger.LogType.Error, "Advantech_PCIE", "Compare_Auto(Gantry)", "Exception Error", es.ToString());
                process = false;
            }
            return process;
        }
        /// <summary>
        /// Set_cmpare
        /// </summary>
        /// <param name="pulse_mode">Pulse Mode</param>
        /// <param name="pulselogic">End Pulse</param>
        /// <param name="Cmpmethod">how to compare</param>
        /// <param name="Cmp_Axis">which axis need to compare</param>       
        /// <returns></returns>
        public void Set_cmpare(int pulse_mode, int pulselogic, uint Cmpmethod, int Cmp_Axis)
        {
            try
            {
                uint Result;
                string strTemp;
                uint PropertyVal;
                PropertyVal = (uint)pulse_mode;
                //set compare PulseMode.
                //You can also use the old API: Motion.mAcm_SetProperty(m_Axishand[CmbAxes.SelectedIndex], (uint)PropertyIDCFG_AxCmpPulseMode,ref PropertyVal,BufferLength)
                // UInt32  BufferLength;
                //BufferLength =4; buffer size for the property

                // the pulse_mode should set to 0.
                Result = Motion.mAcm_SetU32Property(m_Axishand[Cmp_Axis], (uint)PropertyID.CFG_AxCmpPulseMode, PropertyVal);
                if (Result != (uint)ErrorCode.SUCCESS)
                {
                    strTemp = "Set Property-CFG_AxCmpPulseMode Failed With Error Code[0x" + Convert.ToString(Result, 16) + "]";
                    Logger.ShowMessages(strTemp, Result, "Set_compare()");
                    //ShowMessages(strTemp, Result);
                    //return;
                }

                PropertyVal = (uint)pulselogic;
                // the pulselogic set to 0:means active_low.

                //set compare PulseLogic.
                //You can also use the old API: Motion.mAcm_SetProperty(m_Axishand[CmbAxes.SelectedIndex], (uint)PropertyIDCFG_AxCmpPulseLogic,ref PropertyVal,BufferLength)
                // UInt32  BufferLength;
                //BufferLength =4; buffer size for the property
                Result = Motion.mAcm_SetU32Property(m_Axishand[Cmp_Axis], (uint)PropertyID.CFG_AxCmpPulseLogic, PropertyVal);
                if (Result != (uint)ErrorCode.SUCCESS)
                {
                    strTemp = "Set Property-CFG_AxCmpPulseLogic Failed With Error Code[0x" + Convert.ToString(Result, 16) + "]";
                    Logger.ShowMessages(strTemp, Result, "Set_compare()");
                    // ShowMessages(strTemp, Result);
                    // return;
                }

                //set compare PulseWidth.
                //You can also use the old API: Motion.mAcm_SetProperty(m_Axishand[CmbAxes.SelectedIndex], (uint)PropertyIDCFG_CFG_AxCmpPulseWidth,ref PropertyVal,BufferLength)
                // UInt32  BufferLength;
                //BufferLength =4; buffer size for the property                                                                       //500000
                Result = Motion.mAcm_SetU32Property(m_Axishand[Cmp_Axis], (uint)PropertyID.CFG_AxCmpPulseWidthEx, 50000);
                if (Result != (uint)ErrorCode.SUCCESS)
                {
                    strTemp = "Set Property-CFG_CFG_AxCmpPulseWidth Failed With Error Code[0x" + Convert.ToString(Result, 16) + "]";
                    Logger.ShowMessages(strTemp, Result, "Set_compare()");
                    // ShowMessages(strTemp, Result);
                    // return;
                }

                PropertyVal = 1; // current setting is compare to Actual position.

                //set compare source.
                //You can also use the old API: Motion.mAcm_SetProperty(m_Axishand[CmbAxes.SelectedIndex], (uint)PropertyID.CFG_AxCmpSrc,ref PropertyVal,BufferLength)
                // UInt32  BufferLength;
                //BufferLength =4; buffer size for the property
                Result = Motion.mAcm_SetU32Property(m_Axishand[Cmp_Axis], (uint)PropertyID.CFG_AxCmpSrc, PropertyVal);
                if (Result != (uint)ErrorCode.SUCCESS)
                {
                    strTemp = "Set Property-CFG_AxCmpSrc Failed With Error Code[0x" + Convert.ToString(Result, 16) + "]";
                    Logger.ShowMessages(strTemp, Result, "Set_compare()");
                    //ShowMessages(strTemp, Result);
                    // return;
                }
                PropertyVal = Cmpmethod;
                //Set compare method
                //You can also use the old API: Motion.mAcm_SetProperty(m_Axishand[CmbAxes.SelectedIndex], (uint)PropertyID.CFG_AxCmpMethod,ref PropertyVal,BufferLength)
                // UInt32  BufferLength;
                //BufferLength =4; buffer size for the property
                Result = Motion.mAcm_SetU32Property(m_Axishand[Cmp_Axis], (uint)PropertyID.CFG_AxCmpMethod, PropertyVal);
                if (Result != (uint)ErrorCode.SUCCESS)
                {
                    strTemp = "Set Property-AxCmpMethod Failed With Error Code[0x" + Convert.ToString(Result, 16) + "]";
                    Logger.ShowMessages(strTemp, Result, "Set_compare()");
                    // ShowMessages(strTemp, Result);
                    // return;
                }

                PropertyVal = 1;
                //Enable/disable axis compare function.
                //You can also use the old API: Motion.mAcm_SetProperty(m_Axishand[CmbAxes.SelectedIndex], (uint)PropertyID.CFG_AxCmpEnable,ref PropertyVal,BufferLength)
                // UInt32  BufferLength;
                //BufferLength =4; buffer size for the property
                Result = Motion.mAcm_SetU32Property(m_Axishand[Cmp_Axis], (uint)PropertyID.CFG_AxCmpEnable, PropertyVal);
                if (Result != (uint)ErrorCode.SUCCESS)
                {
                    strTemp = "Set Property-AxCmpEnable Failed With Error Code[0x" + Convert.ToString(Result, 16) + "]";
                    Logger.ShowMessages(strTemp, Result, "Set_compare()");
                    // ShowMessages(strTemp, Result);
                    // return;
                }
            }
            catch (Exception es)
            {
                Logger.WriteLog(Logger.LogType.Error, "Advantech_PCIE", "Set_cmpare(Gantry)", "Exception Error", es.ToString());
                return;
            }
        }
        /// <summary>
        /// Disable the Comparision
        /// </summary>
        /// <param name="Cmp_Axis">Cmp_Axis</param>            
        /// <returns></returns>
        public void comp_disable()
        {
            try
            {
                uint PropertyVal = 0;
                uint Result = 0;
                string strTemp = string.Empty;
                //Enable/disable axis compare function.
                //You can also use the old API: Motion.mAcm_SetProperty(m_Axishand[CmbAxes.SelectedIndex], (uint)PropertyID.CFG_AxCmpEnable,ref PropertyVal,BufferLength)
                // UInt32  BufferLength;
                //BufferLength =4; buffer size for the property
                Result = Motion.mAcm_SetU32Property(m_Axishand[Read_Axishand], (uint)PropertyID.CFG_AxCmpEnable, PropertyVal);
                if (Result != (uint)ErrorCode.SUCCESS)
                {
                    strTemp = "Set Property-AxCmpEnable Failed With Error Code[0x" + Convert.ToString(Result, 16) + "]";
                    Logger.ShowMessages(strTemp, Result, "comp_disable(Gantry)");
                    // ShowMessages(strTemp, Result);
                    // return;
                }
            }
            catch (Exception es)
            {
                Logger.WriteLog(Logger.LogType.Error, "Advantech_PCIE", "comp_disable(Gantry)", "Exception Error", es.ToString());
                return;
            }
        }
        /// <summary>
        /// Onfly_load
        /// </summary>
        /// <param name="Cmp_Axis">Cmp_Axis</param>            
        /// <returns></returns>
        public void Onfly_load()
        {
            try
            {
                UInt32 Result;
                Result = Motion.mAcm_SetU32Property(m_Axishand[Read_Axishand], (uint)PropertyID.CFG_AxPulseInMaxFreq, 3);
                //  Motion.mAcm_SetU32Property(axis, (uint)PropertyID.CFG_AxAlmEnable, (uint)AlarmEnable.ALM_DIS);
                if (Result != (uint)ErrorCode.SUCCESS)
                {
                    string strTemp = "Set Property-CFG_AxPulseInMaxFreq Failed With Error Code[0x" + Convert.ToString(Result, 16) + "]";
                    Logger.ShowMessages(strTemp, Result, "Onfly_load()");
                    //ShowMessages(strTemp, Result);
                    // return;
                }
                Result = Motion.mAcm_SetU32Property(m_Axishand[Read_Axishand], (uint)PropertyID.CFG_AxPulseInMaxFreq, 3);
                //  Motion.mAcm_SetU32Property(axis, (uint)PropertyID.CFG_AxAlmEnable, (uint)AlarmEnable.ALM_DIS);
                if (Result != (uint)ErrorCode.SUCCESS)
                {
                    string strTemp = "Set Property-CFG_AxPulseInMaxFreq Failed With Error Code[0x" + Convert.ToString(Result, 16) + "]";
                    Logger.ShowMessages(strTemp, Result, "Onfly_load()");
                    //ShowMessages(strTemp, Result);
                    // return;
                }
                Result = Motion.mAcm_SetU32Property(m_Axishand[Read_Axishand], (uint)PropertyID.CFG_AxAlmEnable, (uint)AlarmEnable.ALM_DIS);
                //  Motion.mAcm_SetU32Property(axis, (uint)PropertyID.CFG_AxAlmEnable, (uint)AlarmEnable.ALM_DIS);
                if (Result != (uint)ErrorCode.SUCCESS)
                {
                    string strTemp = "Set Property-CFG_AxCmpPulseMode Failed With Error Code[0x" + Convert.ToString(Result, 16) + "]";
                    Logger.ShowMessages(strTemp, Result, "Onfly_load()");
                    //ShowMessages(strTemp, Result);
                    // return;
                }

                Result = Motion.mAcm_SetU32Property(m_Axishand[Read_Axishand], (uint)PropertyID.CFG_AxAlmEnable, (uint)AlarmEnable.ALM_DIS);
                if (Result != (uint)ErrorCode.SUCCESS)
                {
                    string strTemp = "Set Property-CFG_AxCmpPulseMode Failed With Error Code[0x" + Convert.ToString(Result, 16) + "]";
                    Logger.ShowMessages(strTemp, Result, "Onfly_load()");
                    //return;
                }
                Result = Motion.mAcm_SetU32Property(m_Axishand[Read_Axishand], (uint)PropertyID.CFG_AxElEnable, (uint)HLmtEnable.HLMT_DIS);
                if (Result != (uint)ErrorCode.SUCCESS)
                {
                    string strTemp = "Set Property-CFG_AxCmpPulseMode Failed With Error Code[0x" + Convert.ToString(Result, 16) + "]";
                    //ShowMessages(strTemp, Result);
                    Logger.ShowMessages(strTemp, Result, "Onfly_load()");
                }
                Result = Motion.mAcm_SetU32Property(m_Axishand[Read_Axishand], (uint)PropertyID.CFG_AxElEnable, (uint)HLmtEnable.HLMT_DIS);
                if (Result != (uint)ErrorCode.SUCCESS)
                {
                    string strTemp = "Set Property-CFG_AxCmpPulseMode Failed With Error Code[0x" + Convert.ToString(Result, 16) + "]";
                    //ShowMessages(strTemp, Result);
                    Logger.ShowMessages(strTemp, Result, "Onfly_load()");
                }
                Result = Motion.mAcm_SetU32Property(m_DeviceHandle, (uint)PropertyID.CFG_DevEmgLogic, (uint)EmgLogic.EMG_ACT_LOW);
                if (Result != (uint)ErrorCode.SUCCESS)
                {
                    string strTemp = "Set Property-CFG_AxCmpPulseMode Failed With Error Code[0x" + Convert.ToString(Result, 16) + "]";
                    //ShowMessages(strTemp, Result);
                    Logger.ShowMessages(strTemp, Result, "Onfly_load()");
                }
            }
            catch (Exception es)
            {
                Logger.WriteLog(Logger.LogType.Error, "Advantech_PCIE", "Onfly_load(Gantry)", "Exception Error", es.ToString());
                return;
            }
        }

        #endregion

        public class Motor_Properties
        {
            #region Input params
            public int index { get; set; }                         // axis index   
            public string name { get; set; }                      // axis name
            public double pulse { get; set; }                     // pulse per rotation
            public double negative_limit { get; set; }            // axis soft limit 
            public double positive_limit { get; set; }            // axis soft limit 
            public double min_velocity { get; set; }              // min velocity
            public double max_velocity { get; set; }              // max velocity
            public double min_acceleration { get; set; }          // min acceleration
            public double max_acceleration { get; set; }          // max acceleration
            public double min_deceleration { get; set; }         // min deaccleration
            public double max_deceleration { get; set; }         // max deaccleration        
            public int timeout_sec { get; set; }                 // timeout for travel reaching a position
            public int Positive_limit_error { get; set; }
            public int Negative_limit_error { get; set; }
            public int Disable_error { get; set; }
            public int TimeOut_error { get; set; }
            public int Driver_error { get; set; }

            #endregion
        }
    }

    /// <summary>
    /// Error Info Class
    /// </summary>
    

    /// <summary>
    ///Error Handler
    /// </summary>
   
}
