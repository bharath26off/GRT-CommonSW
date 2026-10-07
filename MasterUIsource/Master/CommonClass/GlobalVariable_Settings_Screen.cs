using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UI;

namespace Master
{
    public partial class GlobalVariable
    {
        public static string[] Analog_Input_Names;
        public static string[] Analog_Input_Units = { "kg", "kg", "kg" };


        public static string AE_Limits_Path_Production = Path.Combine(Environment.CurrentDirectory, "Data", "Settings", "AE_LIMITS_PRODUCTION.xml");
        public static string AE_Limits_Path_CPK = Path.Combine(Environment.CurrentDirectory, "Data", "Settings", "AE_LIMITS_CPK.xml");
        public static string AE_Limits_Path_GRR = Path.Combine(Environment.CurrentDirectory, "Data", "Settings", "AE_LIMITS_GRR.xml");
        public static string Vision_Setting_Path = Path.Combine(Environment.CurrentDirectory, "Data", "Settings", "Vision_Settings.xml");
        public static string TCP_IP_Setting_Path = Path.Combine(Environment.CurrentDirectory, "Data", "Settings", "TCPIP_Settings.xml");
        public static string Serial_Comm_Setting_Path = Path.Combine(Environment.CurrentDirectory, "Data", "", "OPT.xml");
        public static string Axis_Parameter_Setting_Path = Path.Combine(Environment.CurrentDirectory, "Data", "Settings", "Axis_Parameters.xml");


        public static string AE_Limits_Path_Production_Edit = Path.Combine(Environment.CurrentDirectory, "Data", "SFC_PDCA", "AE_LIMITS_PRODUCTION.csv");
        public static string AE_Limits_Path_CPK_Edit = Path.Combine(Environment.CurrentDirectory, "Data", "SFC_PDCA", "AE_LIMITS_CPK.csv");
        public static string AE_Limits_Path_GRR_Edit = Path.Combine(Environment.CurrentDirectory, "Data", "SFC_PDCA", "AE_LIMITS_GRR.csv");

        public static string[] CCD_Image_Save_path = new string[3];
        public static string WIP_SN_Loading = "";
        public static string WIP_SN_Working = "";
        public static string WIP_SN_Rolling = "";

        public static string HSG_SN_Loading = "";
        public static string HSG_SN_Working = "";
        public static string HSG_SN_Rolling = "";
        public static string Material = "";
        public static string SN = "";
        public static string Toss_X = "";
        public static string Toss_Y = "";
        public static string Toss_angle = "";

        public static string Battery_SN_Working = "";
        public static string Battery_SN_Rolling = "";

        public static void Update_Settings()
        {
            TCPIP.XML_To_Variables();
            Settings.Axis_Parameter_settings = XML.XML_Data_to_Varaiables_Column_String(GlobalVariable.Axis_Parameter_Setting_Path);
            Settings.Vision_settings = XML.XML_Data_to_Varaiables_Row(GlobalVariable.Vision_Setting_Path);
            SFC_PDCA.PDCA_Data_Prodution = XML.PDCA_DATA_TO_VARAIBLES(GlobalVariable.AE_Limits_Path_Production);
            SFC_PDCA.PDCA_DATA_GRR = XML.PDCA_DATA_TO_VARAIBLES(GlobalVariable.AE_Limits_Path_GRR);
            SFC_PDCA.PDCA_Data_CPK = XML.PDCA_DATA_TO_VARAIBLES(GlobalVariable.AE_Limits_Path_CPK);

        }
    }
}
