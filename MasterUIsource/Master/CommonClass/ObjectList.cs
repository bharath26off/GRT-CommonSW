using DIO;
using HelperClassLib;
using Master;
using Master.CommonClass;
using Program;
using System;
using System.Collections.Generic;
using System.Windows.Forms;


public static class ObjectList
{
    public static bool globalblock = false;
    public static int CardServo_num = 0;
    public static int CardStepper_num = 1;

    #region AXIS OBJECT LIST
    /// <summary>
    /// way Create a object for Advantech PCI card connected Access.
    /// if Devices is connected in Series Axix will start from zero to List of Connected Devices.
    /// Stepper Drive Connected in Series card will consider as a Posistion of the Derive as a Axis.
    /// It start from "0".
    /// </summary>

    //public static Advantech_PCIE X1 = new Advantech_PCIE(0, "X1");
    //public static Advantech_PCIE X2 = new Advantech_PCIE(1, "X2");
    //public static Advantech_PCIE ZAxis2 = new Advantech_PCIE(0, "Z2");    //public static Advantech_PCIE YAxis1 = new Advantech_PCIE(0, "Y1");
    //public static Advantech_PCIE XAxis1 = new Advantech_PCIE(0, "X1");
    //public static Advantech_PCIE XAxis2 = new Advantech_PCIE(0, "X2");
    //public static Advantech_PCIE YAxis2 = new Advantech_PCIE(0, "Y2");
    //public static Advantech_PCIE YAxis3 = new Advantech_PCIE(0, "Y3");
    //public static Advantech_PCIE XAxis3 = new Advantech_PCIE(0, "X3");
    //public static Advantech_PCIE RAxis1 = new Advantech_PCIE(0, "R1");
    //public static Advantech_PCIE RAxis2 = new Advantech_PCIE(0, "R2");

    public static Advantech_PCIE.Motor_Properties axiesErrorCodes = new Advantech_PCIE.Motor_Properties
    {
        Positive_limit_error = (int)DIDO.ECode.PosLimit_Error,
        Negative_limit_error = (int)DIDO.ECode.NegLimit_Error,
        Disable_error = (int)DIDO.ECode.Disable_Error,
        TimeOut_error = (int)DIDO.ECode.MoveTimeout_Error,
        Driver_error = (int)DIDO.ECode.DriveError_Error,
    };    //For Servo
    //dummy
    public static Advantech_PCIE AX0 = new Advantech_PCIE((int)DIDO.EAxis.AX0, DIDO.EAxis.AX0.ToString(), GlobalVariable.g_lstAxisConfig[(int)DIDO.EAxis.AX0].pulse_mm, axiesErrorCodes);
    public static Advantech_PCIE AX1 = new Advantech_PCIE((int)DIDO.EAxis.AX1, DIDO.EAxis.AX1.ToString(), GlobalVariable.g_lstAxisConfig[(int)DIDO.EAxis.AX1].pulse_mm, axiesErrorCodes);
    public static Advantech_PCIE AX2 = new Advantech_PCIE((int)DIDO.EAxis.AX2, DIDO.EAxis.AX2.ToString(), GlobalVariable.g_lstAxisConfig[(int)DIDO.EAxis.AX2].pulse_mm, axiesErrorCodes);
    public static Advantech_PCIE AX3 = new Advantech_PCIE((int)DIDO.EAxis.AX3, DIDO.EAxis.AX3.ToString(), GlobalVariable.g_lstAxisConfig[(int)DIDO.EAxis.AX3].pulse_mm, axiesErrorCodes);

    public static Advantech_PCIE Servo_X1 = new Advantech_PCIE((int)DIDO.EAxis.Servo_X1, DIDO.EAxis.Servo_X1.ToString(), GlobalVariable.g_lstAxisConfig[(int)DIDO.EAxis.Servo_X1].pulse_mm, axiesErrorCodes);
    public static Advantech_PCIE Servo_Y1 = new Advantech_PCIE((int)DIDO.EAxis.Servo_Y1, DIDO.EAxis.Servo_Y1.ToString(), GlobalVariable.g_lstAxisConfig[(int)DIDO.EAxis.Servo_Y1].pulse_mm, axiesErrorCodes);
    public static Advantech_PCIE Servo_Z2 = new Advantech_PCIE((int)DIDO.EAxis.Servo_Z2, DIDO.EAxis.Servo_Z2.ToString(), GlobalVariable.g_lstAxisConfig[(int)DIDO.EAxis.Servo_Z2].pulse_mm, axiesErrorCodes);
    public static Advantech_PCIE Servo_Z1 = new Advantech_PCIE((int)DIDO.EAxis.Servo_Z1, DIDO.EAxis.Servo_Z1.ToString(), GlobalVariable.g_lstAxisConfig[(int)DIDO.EAxis.Servo_Z1].pulse_mm, axiesErrorCodes);

    public static Advantech_PCIE Servo_X2 = new Advantech_PCIE((int)DIDO.EAxis.Servo_X2, DIDO.EAxis.Servo_X2.ToString(), GlobalVariable.g_lstAxisConfig[(int)DIDO.EAxis.Servo_X2].pulse_mm, axiesErrorCodes);
    public static Advantech_PCIE Servo_Y2 = new Advantech_PCIE((int)DIDO.EAxis.Servo_Y2, DIDO.EAxis.Servo_Y2.ToString(), GlobalVariable.g_lstAxisConfig[(int)DIDO.EAxis.Servo_Y2].pulse_mm, axiesErrorCodes);
    public static Advantech_PCIE Servo_R1 = new Advantech_PCIE((int)DIDO.EAxis.Servo_R1, DIDO.EAxis.Servo_R1.ToString(), GlobalVariable.g_lstAxisConfig[(int)DIDO.EAxis.Servo_R1].pulse_mm, axiesErrorCodes);
    public static Advantech_PCIE Servo_R2 = new Advantech_PCIE((int)DIDO.EAxis.Servo_R2, DIDO.EAxis.Servo_R2.ToString(), GlobalVariable.g_lstAxisConfig[(int)DIDO.EAxis.Servo_R2].pulse_mm, axiesErrorCodes);


    //For Stepper  (if connected in Axis)
    public static Advantech_PCIE Stepper_1 = new Advantech_PCIE((int)DIDO.EAxis.Stepper_1, DIDO.EAxis.Stepper_1.ToString(), GlobalVariable.g_lstAxisConfig[(int)DIDO.EAxis.Stepper_1].pulse_mm, axiesErrorCodes);
    public static Advantech_PCIE Stepper_2 = new Advantech_PCIE((int)DIDO.EAxis.Stepper_2, DIDO.EAxis.Stepper_2.ToString(), GlobalVariable.g_lstAxisConfig[(int)DIDO.EAxis.Stepper_2].pulse_mm, axiesErrorCodes);

    public static Advantech_PCIE_Stepper Scanning_Conveyor_A = new Advantech_PCIE_Stepper(CardStepper_num, 0, DIDO.EAxis.Scanning_Conveyor_A.ToString(), GlobalVariable.g_lstAxisConfig[(int)DIDO.EAxis.Scanning_Conveyor_A].pulse_mm);
    public static Advantech_PCIE_Stepper Scanning_Conveyor_B = new Advantech_PCIE_Stepper(CardStepper_num, 1, DIDO.EAxis.Scanning_Conveyor_B.ToString(), GlobalVariable.g_lstAxisConfig[(int)DIDO.EAxis.Scanning_Conveyor_B].pulse_mm);
    public static Advantech_PCIE_Stepper Working_Conveyor = new Advantech_PCIE_Stepper(CardStepper_num, 2, DIDO.EAxis.Working_Conveyor.ToString(), GlobalVariable.g_lstAxisConfig[(int)DIDO.EAxis.Working_Conveyor].pulse_mm);
    public static Advantech_PCIE_Stepper Recheck_Conveyor = new Advantech_PCIE_Stepper(CardStepper_num, 3, DIDO.EAxis.Recheck_Conveyor.ToString(), GlobalVariable.g_lstAxisConfig[(int)DIDO.EAxis.Recheck_Conveyor].pulse_mm);
    public static Advantech_PCIE_Stepper Working_Conveyor_A = new Advantech_PCIE_Stepper(CardStepper_num, 2, DIDO.EAxis.Working_Conveyor_A.ToString(), GlobalVariable.g_lstAxisConfig[(int)DIDO.EAxis.Working_Conveyor_A].pulse_mm);
    public static Advantech_PCIE_Stepper Working_Conveyor_B = new Advantech_PCIE_Stepper(CardStepper_num, 3, DIDO.EAxis.Working_Conveyor_B.ToString(), GlobalVariable.g_lstAxisConfig[(int)DIDO.EAxis.Working_Conveyor_B].pulse_mm);
    public static Advantech_PCIE_Stepper Recheck_Conveyor_A = new Advantech_PCIE_Stepper(CardStepper_num, 4, DIDO.EAxis.Recheck_Conveyor_A.ToString(), GlobalVariable.g_lstAxisConfig[(int)DIDO.EAxis.Recheck_Conveyor_A].pulse_mm);
    public static Advantech_PCIE_Stepper Recheck_Conveyor_B = new Advantech_PCIE_Stepper(CardStepper_num, 5, DIDO.EAxis.Recheck_Conveyor_B.ToString(), GlobalVariable.g_lstAxisConfig[(int)DIDO.EAxis.Recheck_Conveyor_B].pulse_mm);


    // public static Advantech_PCIE Stepper_3 = new Advantech_PCIE((int)DIDO.EAxis.Stepper_3, DIDO.EAxis.Stepper_3.ToString(), GlobalVariable.g_lstAxisConfig[(int)DIDO.EAxis.Stepper_3].pulse_mm, axiesErrorCodes);

    //**devchange: MUST ADD THE DICTIONARIY AFTER CREATING AN OBJECT (for needed only)
    // for Mapping to Manual screen axis list need to map bellow with all motion axis like bellow
    public static Dictionary<int, Advantech_PCIE> MotorObj = new Dictionary<int, Advantech_PCIE>
        {
            { (int)DIDO.EAxis.AX0, AX0 },
            { (int)DIDO.EAxis.AX1,AX1 },
            { (int)DIDO.EAxis.AX2, AX2 },
            { (int)DIDO.EAxis.AX3, AX3 },

            { (int)DIDO.EAxis.Servo_X1, Servo_X1 },
            { (int)DIDO.EAxis.Servo_Y1, Servo_Y1 },
            { (int)DIDO.EAxis.Servo_Z1, Servo_Z1 },
            { (int)DIDO.EAxis.Servo_Z2, Servo_Z2 },
            { (int)DIDO.EAxis.Servo_R1, Servo_R1 },
            { (int)DIDO.EAxis.Servo_R2, Servo_R2 },
            { (int)DIDO.EAxis.Servo_X2, Servo_X2 },
            { (int)DIDO.EAxis.Servo_Y2, Servo_Y2 },
            { (int)DIDO.EAxis.Stepper_1, Stepper_1 },
            { (int)DIDO.EAxis.Stepper_2, Stepper_2 },
            //{ (int)DIDO.EAxis.Stepper_3, Stepper_3 },

        };

    public static Dictionary<int, Advantech_PCIE_Stepper> MotorObjstepper = new Dictionary<int, Advantech_PCIE_Stepper>
        {


            { (int)DIDO.EAxis.Scanning_Conveyor_A, Scanning_Conveyor_A },
            { (int)DIDO.EAxis.Scanning_Conveyor_B, Scanning_Conveyor_B },
            { (int)DIDO.EAxis.Working_Conveyor_A, Working_Conveyor_A },
            { (int)DIDO.EAxis.Working_Conveyor_B, Working_Conveyor_B },
            { (int)DIDO.EAxis.Recheck_Conveyor_A, Recheck_Conveyor_A },
            { (int)DIDO.EAxis.Recheck_Conveyor_B, Recheck_Conveyor_B },

        };

    public static Dictionary<int, Advantech_PCIE_Stepper> MotorObjstepper_4 = new Dictionary<int, Advantech_PCIE_Stepper>
        {


            { (int)DIDO.EAxis.Scanning_Conveyor_A, Scanning_Conveyor_A },
            { (int)DIDO.EAxis.Scanning_Conveyor_B, Scanning_Conveyor_B },
            { (int)DIDO.EAxis.Working_Conveyor, Working_Conveyor},
            { (int)DIDO.EAxis.Recheck_Conveyor, Recheck_Conveyor }

        };

    #endregion


    #region TCPIP OBJECT LIST
    /// <summary>
    /// Way to create a TCPIP Object.       
    /// </summary>
    public static SocketClient CCD1 = new SocketClient("CCD1");
    public static SocketClient CCD2 = new SocketClient("CCD2");
    public static SocketClient CCD3 = new SocketClient("CCD3");
    public static SocketClient CCD4 = new SocketClient("CCD4");
    public static SocketClient SFC = new SocketClient("SFC_PDCA");

    public static SocketClient Barcode_Scanner = new SocketClient("Barcode_Scanner");

    //public static SocketClient Robot = new SocketClient("Robot");
    //public static SocketClient RobotSts = new SocketClient("Robot_Auto");
    //public static SocketClient RobotErr = new SocketClient("RobotError");

    public static Serial_Communication OPT = new Serial_Communication("COM5");
    public static Serial_Communication OPT2 = new Serial_Communication("OPT2");

    //**devchange: MUST ADD THE DICTIONARIY AFTER CREATING AN OBJECT (for needed only)

    #region INIT OBJECT DICTIONARIES
    public static Dictionary<int, SocketClient> CCDObj = new Dictionary<int, SocketClient>()
    {
         { 0, CCD1 },
         { 1, CCD2},
         { 2, CCD3 },
         { 3, CCD4 },
    };
    public static Dictionary<int, SocketClient> ScnrObj = new Dictionary<int, SocketClient>()
    {
         { 0, Barcode_Scanner }

    };

    public static Dictionary<int, SocketClient> SFCPDCAObj = new Dictionary<int, SocketClient>()
    {
         { 0, SFC }

    };
    //public static Dictionary<int, SocketClient> RoboObj = new Dictionary<int, SocketClient>()
    //{
    //    { 0, Robot },
    //    { 1, RobotSts },
    //    { 2, RobotErr },
    //};
    public static Dictionary<int, Serial_Communication> COMObj = new Dictionary<int, Serial_Communication>
        {
            { 0, OPT},
            { 1, OPT2},
        };
    #endregion

    public static void ConnectAllObj()
    {
        // Connect all CCD objects
        foreach (var kvp in CCDObj)
        {
            try
            {
                kvp.Value.ConnectAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to connect CCD {kvp.Key}: {ex.Message}");
            }
        }

        // Connect all Scanner objects
        foreach (var kvp in ScnrObj)
        {
            try
            {
                kvp.Value.ConnectAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to connect Scanner {kvp.Key}: {ex.Message}");
            }
        }

        // Connect all Robo objects
        //foreach (var kvp in RoboObj)
        //{
        //    try
        //    {
        //        kvp.Value.ConnectAsync();
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine($"Failed to connect Robo {kvp.Key}: {ex.Message}");
        //    }
        //}


        foreach (var kvp in COMObj)
        {
            try
            {
                kvp.Value.Connect_OPT();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to connect COMPORT {kvp.Key}: {ex.Message}");
            }
        }


        foreach (var kvp in SFCPDCAObj)
        {
            try
            {
                kvp.Value.ConnectAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to connect SFCA {kvp.Key}: {ex.Message}");
            }
        }





    }

    #endregion




    /// <summary>
    /// Way to create a SQLConnection.       
    /// </summary>
    //public static SqlHelper SQL_Helper = new SqlHelper(GlobalVariable.SQL_SqlConnectionString);

}
