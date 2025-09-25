using System.Collections.Generic;
using HelperClassLib;
using MasterProject.GlobalClass;
using Program;

namespace Advantech
{
    public static class ObjectList
    {
        public static bool globalblock = false;

        /// <summary>
        /// way Create a object for Advantech PCI card connected Access.
        /// if Devices is connected in Series Axix will start from zero to List of Connected Devices.
        /// Stepper Drive Connected in Series card will consider as a Posistion of the Derive as a Axis.
        /// It start from "0".
        /// </summary>
        /// 
    
        public static Advantech_PCIE X1 = new Advantech_PCIE(0, "X1");
        public static Advantech_PCIE X2 = new Advantech_PCIE(1, "X2");
        public static Advantech_PCIE ZAxis2 = new Advantech_PCIE(0, "Z2");
        public static Advantech_PCIE YAxis1 = new Advantech_PCIE(0, "Y1");
        public static Advantech_PCIE XAxis1 = new Advantech_PCIE(0, "X1");
        public static Advantech_PCIE XAxis2 = new Advantech_PCIE(0, "X2");
        public static Advantech_PCIE YAxis2 = new Advantech_PCIE(0, "Y2");
        public static Advantech_PCIE YAxis3 = new Advantech_PCIE(0, "Y3");
        public static Advantech_PCIE XAxis3 = new Advantech_PCIE(0, "X3");
        public static Advantech_PCIE RAxis1 = new Advantech_PCIE(0, "R1");
        public static Advantech_PCIE RAxis2 = new Advantech_PCIE(0, "R2");





        //For Stepper 
        // for this 5 will vary based on the Position of stepper Axis
        public static Advantech_PCIE Stepper_Axis0 = new Advantech_PCIE(2, "Stepper_Axis0");
        public static Advantech_PCIE Stepper_Axis1 = new Advantech_PCIE(3, "Stepper_Axis1");

        // for Mapping to Manual screen axis list need to map bellow with all motion axis like bellow
        public static Dictionary<int, Advantech_PCIE> MotorObj = new Dictionary<int, Advantech_PCIE>
        {
            { XAxis1.Read_Axishand, XAxis1 },
             { YAxis1.Read_Axishand, YAxis1 },
             { XAxis2.Read_Axishand, XAxis2 },
             { YAxis2.Read_Axishand, YAxis2 },
             { ZAxis2.Read_Axishand, ZAxis2 },
             { XAxis3.Read_Axishand, XAxis3 },
             { YAxis3.Read_Axishand, YAxis3 },
            { Stepper_Axis0.Read_Axishand, Stepper_Axis0 },
            { Stepper_Axis1.Read_Axishand, Stepper_Axis1 }
            
        };


        /// <summary>
        /// Way to create a TCPIP Object.       
        /// </summary>
        public static SocketClient Vision1 = new SocketClient("Vision1");
        public static SocketClient Vision2 = new SocketClient("Vision2");
        public static SocketClient Vision3 = new SocketClient("Vision3");
        public static SocketClient Vision4 = new SocketClient("Vision4");
        public static SocketClient Robot = new SocketClient("Robot");
        public static SocketClient Palet_Scanner = new SocketClient("Palet_Scanner");


        /// <summary>
        /// Way to create a SQLConnection.       
        /// </summary>
        //public static SqlHelper SQL_Helper = new SqlHelper(GlobalVariable.SQL_SqlConnectionString);

    }
}
