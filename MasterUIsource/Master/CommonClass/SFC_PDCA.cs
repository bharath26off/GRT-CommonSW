using Master.Properties;
using Master;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


public class SFC_PDCA
    {

    public enum AE_Parameters
    {
        Start = -1,
        Active_Energy_cummulative,
        Active_energy_current_unit,
        Angle_sp_weight_I,
        Angle_sp_weight_P,
        Avg_Large_Dynamic_Press_Force,
        Avg_Robot_Press_Force,
        Avg_Small_Dynamic_Press_Force,
        B1,
        B15,
        B17,
        B19,
        B2,
        B20,
        B21,
        B3,
        B3I_T11_AOI_CATEGORY_REGION_9,
        B3I_T11_AOI_VERSION,
        B3I_T32_AOI_ALT_CATEGORY_REGION_1,
        B3I_T32_AOI_ALT_SCORE_REGION_VHB,
        B3I_T32_AOI_CATEGORY_REGION_1,
        B3I_T32_AOI_CATEGORY_REGION_VHB,
        B3I_T32_AOI_SCORE_REGION_VHB,
        B3I_T32_AOI_VERSION,
        B3I_T32_NORTH_ICE_Brightness,
        B3I_T32_NORTH_ICE_SHARPNESS,
        B3I_T32_SOUTH_ICE_Brightness,
        B3I_T32_SOUTH_ICE_SHARPNESS,
        B3I_T43_AOI_ALT_CATEGORY_REGION_1,
        B3I_T43_AOI_ALT_SCORE_REGION_1,
        B3I_T43_AOI_CATEGORY_REGION_1,
        B3I_T43_AOI_RESPONSE_TIME,
        B3I_T43_AOI_VERSION,
        B3I_T43_NORTH_ICE_Brightness,
        B3I_T43_SOUTH_ICE_Brightness,
        B4,
        Battery_Angle,
        Battery_Connector_X,
        Battery_LeftEar_Y,
        Battery_Length,
        Battery_RightEar_X,
        Battery_RightEar_Y,
        Battery_Tossing,
        Battery_Width_Mid,
        Battery_Width_Top,
        Calc_G1,
        Calc_G3,
        Calc_X1,
        Calc_X2,
        Close_Loop_Cycles,
        Cycle_Time,
        Delta_Angle,
        Delta_T4_T5_X2,
        Delta_T4_T5_X3,
        Delta_T4_T5_Y2,
        Delta_T4_T5_Y3,
        Delta_T45_T43_G2_Gap,
        Delta_T45_T43_G4_1_Gap,
        Delta_T45_T43_X2,
        Delta_T45_T43_X3,
        Dock_Flex_to_MLB_Dist,
        Dynamic_Rolling_Time,
        G1,
        G1_Target,
        G2,
        G3,
        G4,
        G5,
        G6,
        GANTRY_TO_BACKLIGHT_A,
        GANTRY_TO_BACKLIGHT_X,
        GANTRY_TO_BACKLIGHT_Y,
        H10,
        H11,
        H2,
        H3,
        H4,
        H5,
        H7,
        H8,
        H9,
        Housing_Tossing,
        Max_Large_Dynamic_Press_Force,
        Max_Robot_Pick_Force,
        Max_Robot_Press_Force,
        Max_Small_Dynamic_Press_Force,
        Min_Large_Dynamic_Press_Force,
        Min_Robot_Press_Force,
        Min_Small_Dynamic_Press_Force,
        MLB_BatReceptacleDist,
        MLB_Connector_Position_X,
        MLB_Connector_Position_Y,
        Normal_Unit,
        Operator_ID,
        Peak_Current,
        Priority,
        Robot_Angle_Offset,
        Robot_X_Offset,
        Robot_Y_Offset,
        ROBOTPICK_TO_BACKLIGHT_A,
        ROBOTPICK_TO_BACKLIGHT_X,
        ROBOTPICK_TO_BACKLIGHT_Y,
        ROLLER_MARK_A,
        ROLLER_MARK_X,
        ROLLER_MARK_Y,
        ROLLER_TARGET_A,
        ROLLER_TARGET_X,
        ROLLER_TARGET_Y,
        SFC_Mode,
        Smart_Placement_Enabled,
        SouthHub_BatReceptacleDist,
        T11_NORTH_ICE_Brightness,
        T11_NORTH_ICE_SHARPNESS,
        T11_SOUTH_ICE_Brightness,
        T11_SOUTH_ICE_SHARPNESS,
        T32_Battery_Toss_Count,
        T4_Angle_Offset,
        T4_X1_Offset,
        T4_X2,
        T4_Y2,
        T4_Y3,
        T41_HSG_Toss_Count,
        T43_IsFindScrew,
        T43_Sob_B2BVariance,
        T43_Sob_Variance,
        T44_Battery_delta_Angle,
        T44_Battery_delta_Y,
        T44_Battery_Toss_Count,
        T45_Battery_Toss_Count,
        T45_HSG_Toss_Count,
        T46_G1,
        T46_G3,
        T46_X1,
        T46_Y2,
        T46_Y3,
        T5_Retest,
        T5_X2,
        T5_X3,
        T5_Y3,
        Toss_Count_Total,
        VHB_Angle,
        VHB_Y,
        X1_sp_weight_I,
        X1_sp_weight_P,
        Y1_sp_weight_P,
        T5_Y2,
       End
    }

    public static string[] Live_PDCA_Values_Loading= new string[145];
    public static string[] Live_PDCA_Values_Working = new string[145];
    public static string[] Live_PDCA_Values_Rolling = new string[145];


    public static string[][] PDCA_Data_Prodution = new string[145][];
    public static string[][] PDCA_Data_CPK = new string[145][];
    public static string[][] PDCA_DATA_GRR = new string[145][];
    public static int S_No = 0;
    public static int Paremeter_Name = 1;
    public static int Min_Limit = 2;
    public static int Max_Limit = 3;
    public static int Unit = 4;



    public static bool Update_Parameters_to_Variables()
    {
        try
        {
            PDCA_Data_Prodution = XML.PDCA_DATA_TO_VARAIBLES(GlobalVariable.AE_Limits_Path_Production);
            PDCA_Data_CPK = XML.PDCA_DATA_TO_VARAIBLES(GlobalVariable.AE_Limits_Path_CPK);
            PDCA_DATA_GRR = XML.PDCA_DATA_TO_VARAIBLES(GlobalVariable.AE_Limits_Path_GRR);
            return true;
        }
        catch (Exception ex)
        {
            return false;
        }
    }

    public static bool Update_Blob_Images()
    {
        try
        {
            string file_path_blob = @"\\169.254.1.10\Public\blobs";
            string filename = string.Empty;
            int lastindex = 0;
                if (File.Exists(GlobalVariable.CCD_Image_Save_path[0]))
                {
                    lastindex = GlobalVariable.CCD_Image_Save_path[0].LastIndexOf("\\");
                    filename = GlobalVariable.CCD_Image_Save_path[0].Substring(lastindex);
                    File.Copy(GlobalVariable.CCD_Image_Save_path[0], file_path_blob + filename);
                }
                if (File.Exists(GlobalVariable.CCD_Image_Save_path[1]))
                {
                    lastindex = GlobalVariable.CCD_Image_Save_path[1].LastIndexOf("\\");
                    filename = GlobalVariable.CCD_Image_Save_path[1].Substring(lastindex);
                    File.Copy(GlobalVariable.CCD_Image_Save_path[1], file_path_blob + filename);
                }
            return true;
        }
        catch (Exception ex)
        {
            return false;
        }
    }


    public static bool Machine_Datalog()
    {
        try
        {
            Process[] processes = Process.GetProcessesByName("excel");
            foreach (Process process in processes)
            {
                if (process.MainWindowTitle.Contains(DateTime.Now.ToString("dd_MM_yyyy_HH") + ".csv"))
                {
                    process.Kill();
                }
            }
            string directorypath = "";
            if (GlobalVariable.SFC_PDCA_Bypass)
            {
             directorypath = @"D:\TEAL_Log_Data\Production_Data\Offline\";
            }
            else
            {
              directorypath = @"D:\TEAL_Log_Data\Production_Data\Online\";
            }
            
            string a = "";
            string b = "";
            if (!Directory.Exists(directorypath))
            {
                Directory.CreateDirectory(directorypath);
            }


            if (!File.Exists(directorypath + DateTime.Now.ToString("dd_MM_yyyy_HH") + ".csv"))
            {
                using (StreamWriter writer = File.CreateText(directorypath + DateTime.Now.ToString("dd_MM_yyyy_HH") + ".csv"))
                {
                    for (int i = 0; i < PDCA_Data_Prodution[Paremeter_Name].Length; i++)
                    {
                        if (i < 145)
                        {
                            a = a + PDCA_Data_Prodution[i] + ",";
                        }
                    }
                    writer.WriteLine("Date_Time,HSG_Barcode,WIP_SN,Battery_Barcode," + a);
                }
                using (StreamWriter writer = File.AppendText(directorypath + DateTime.Now.ToString("dd_MM_yyyy_HH") + ".csv"))
                {
                    for (int i = 0; i < PDCA_Data_Prodution[Paremeter_Name].Length; i++)
                    {
                        if (i < 145)
                        {
                            b = b + Live_PDCA_Values_Rolling[i] + ",";
                        }
                    }
                    writer.WriteLine(DateTime.Now.ToString("dd-MM-yyyy_hh:mm:ss") + "," + GlobalVariable.HSG_SN_Rolling + "," + GlobalVariable.WIP_SN_Rolling + "," + GlobalVariable.Battery_SN_Rolling + "," + b);
                }
                return true;

            }
            else
            {
                using (StreamWriter writer = File.AppendText(directorypath + DateTime.Now.ToString("dd_MM_yyyy_HH") + ".csv"))
                {
                    for (int i = 0; i < PDCA_Data_Prodution[Paremeter_Name].Length; i++)
                    {
                        if (i < 145)
                        {
                            b = b + Live_PDCA_Values_Rolling[i] + ",";
                        }
                    }
                    writer.WriteLine(DateTime.Now.ToString("dd-MM-yyyy_hh:mm:ss") + "," + GlobalVariable.HSG_SN_Rolling + "," + GlobalVariable.WIP_SN_Rolling + "," + GlobalVariable.Battery_SN_Rolling + "," + b);

                }
                return true;
            }
        }
        catch (Exception ex)
        {
            return false;
        }
        
    }


}

