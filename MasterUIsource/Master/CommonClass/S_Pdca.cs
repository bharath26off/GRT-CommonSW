using ExceptionLib;
using GRT_BG1.Data;
using GRT_BG1.Function.Classes;
using HelperClassLib;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Master.CommonClass
{
    internal class S_Pdca
    {

        public static Stopwatch Stop;
        public static Stopwatch stop;
        public static Stopwatch stop_1;
        static PartData[,] data = new PartData[3, 5];
        public static PartData[,] CurrentData => data;
        public static string carrierbar = "";
        ScannerSystem scanner = new ScannerSystem();
        private static string Result = "";
        public static string Final_Result = "";
        public static bool Barcode_Data_Send_SFC(string barcode)
        {
            try
            {
                //sfc_post@test_head_id=&p=unit_process_check&c=QUERY_RECORD&sw_version=&tsid=TEHR_B01-GFPD-04_1_AE-2&sn=J85HBF0001300008LH&fixture_id=
                Stopwatch OutBScan = new Stopwatch();

                int STEP = 10;
                //Arulkumar Fixed Hung start
                int sfcLoopRetryCount = 0;
                const int MAX_SFC_LOOP_RETRIES = 200;
                //Arulkumar Fixed Hung end

                while (true)
                {
                    //Arulkumar Fixed Hung start
                    if (GlobalVariable.SFC_PDCA_Bypass)
                    {
                        Logger.WriteLog(Logger.LogType.Info, "S_Pdca", "Barcode_Data_Send_SFC", "SFC_PDCA_Bypass enabled - skipping SFC send", barcode);
                        return true;
                    }
                    sfcLoopRetryCount++;
                    if (sfcLoopRetryCount > MAX_SFC_LOOP_RETRIES)
                    {
                        Logger.WriteLog(Logger.LogType.Error, "S_Pdca", "Barcode_Data_Send_SFC", "SFC send exceeded max retry loops", barcode);
                        GlobalVariable.SFC_Mcmini_Wait = false;
                        return false;
                    }
                    //Arulkumar Fixed Hung end
                    if (!GlobalVariable.SFC_PDCA_Bypass) //  AK
                    {
                        string querysend = "";
                        switch (STEP)
                        {

                            case 10:
                                if (!GlobalVariable.SFC_Mcmini_Wait)
                                {

                                    Task.Run(()=> SfcClient.commonLOG("Before Query"));
                                    querysend = "sfc_post@test_head_id=&p=unit_process_check&c=QUERY_RECORD&sw_version=&tsid=TENP_B01-2FMBP-01_1_AE-1&sn=" + barcode + "&fixture_id=";

                                    if (GlobalVariable.g_MachineSite == "TESS" )
                                    {
                                        querysend = "sfc_post@test_head_id=&p=unit_process_check&c=QUERY_RECORD&sw_version=&tsid="+GlobalVariable.StationID +"&sn=" + barcode + "&fixture_id=";

                                    }
                                    else if(GlobalVariable.g_MachineSite == "TEHR")
                                    {
                                        querysend = "sfc_post@c=QUERY_RECORD&sn=" + barcode + "&p=unit_process_check&tsid=" + GlobalVariable.StationID;

                                    }
                                    else
                                    {
                                        MessageBox.Show("Invalid Machine Site Name ", "", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);
                                    }
                                    SfcClient.StoreSfcData(querysend);
                                    Task.Run(() => SfcClient.commonLOG("after Query"));
                                    // Result = ScannerSystem.Trig_Scanner(ObjectList.SFC, querysend);
                                    //Result =  ScannerSystem.SFCsendData(ObjectList.SFC, querysend);
                                    OutBScan.Restart();
                                    ObjectList.SFC.Send(querysend);
                                    GlobalVariable.SFC_Mcmini_Wait = true;
                                    while (OutBScan.ElapsedMilliseconds < 3000)
                                    {
                                        Result = ObjectList.SFC.Receive(600001);
                                        if (!string.IsNullOrEmpty(Result))
                                        {
                                            GlobalVariable.SFC_Mcmini_Wait = false;
                                            break;
                                        }

                                    }
                                    OutBScan.Stop();
                                    Task.Run(() => SfcClient.commonLOG(Result));
                                    if(Result == null)
                                    {
                                        STEP = 10;
                                    }
                                    else if (!Result.Contains("ok@{unit_status"))
                                    {
                                        SfcClient.StoreSfcData(Result);
                                    }
                                    //GlobalVariable.SFC_Mcmini_Wait = false;
                                    Task.Run(() => SfcClient.commonLOG("False"));
                                    Stop = Stopwatch.StartNew();
                                    STEP = 20;
                                }

                                break;
                            case 20:
                                if (Result == null)
                                {
                                    SfcClient.StoreSfcData("NOT OK NULL Received");
                                    //GlobalVariable.SFC_Mcmini_Wait = false;
                                    STEP = 0;
                                    return false;
                                }

                                //if (Result.Contains("ok@{0 SFC_OK\ntsid::TENP_B01-2FMBP-01_1_AE-1::unit_process_check=OK}@"))
                                if (Result.Contains("ok@{0 SFC_OK\ntsid::"+GlobalVariable.StationID+"::unit_process_check=OK}@"))
                                {
                                    SfcClient.StoreSfcData("SFC_OK");
                                    //X1Y1.SFC_Station1_Log(ScannerSystem.Trig_Scanner());
                                    STEP = 0;
                                    //GlobalVariable.SFC_Mcmini_Wait = false;
                                    return true;
                                }
                                //else
                                //{
                                //    SfcClient.StoreSfcData("SFC_NOT_OK");
                                //    return false;
                                //}
                                else
                                {
                                    if (Stop.Elapsed.TotalSeconds > 5)
                                    {
                                        Stop.Stop();
                                        // STEP = 10;
                                        SfcClient.StoreSfcData("Nothing Received  FROM  SFC DATA");
                                        STEP = 0;
                                        GlobalVariable.SFC_Mcmini_Wait = false;
                                        return false;
                                    }
                                    else if (Result.Contains("bad@{"))
                                    {
                                        SfcClient.StoreSfcData("Bad_Command");
                                        //GlobalVariable.SFC_Mcmini_Wait = false;
                                        return false;
                                    }
                                    else if (Result.Contains("err@{"))
                                    {
                                        SfcClient.StoreSfcData("SFC_NOT_OK");
                                        //GlobalVariable.SFC_Mcmini_Wait = false;
                                        return false;
                                    }
                                    else if (Result.Contains("already Closed"))
                                    {
                                        SfcClient.StoreSfcData("Error Not OK Already CLosed");
                                        //GlobalVariable.SFC_Mcmini_Wait = false;
                                        return false;
                                    }

                                    // else if (Result.Contains("ok@{0 SFC_OK\ntsid::TENP_B01-2FMBP-02_1_AE-1::unit_process_check=UNIT OUT OF PROCESS; ASSY INPUT NO PASS Record(1). Go to ASSY INPUT.}@"))
                                    //else if (Result.Contains("ok@{0 SFC_OK\ntsid::TENP_B01-2FMBP-01_1_AE-1::unit_process_check=UNIT OUT OF PROCESS"))
                                    else if (Result.Contains("ok@{0 SFC_OK\ntsid::"+GlobalVariable.StationID+"::unit_process_check=UNIT OUT OF PROCESS"))
                                    {
                                        SfcClient.StoreSfcData("UNIT OUT OF PROCESS");
                                        //GlobalVariable.SFC_Mcmini_Wait = false;
                                        return false;
                                    }
                                    else if (Result.Contains("ok@{}@"))
                                    {
                                        Thread.Sleep(50);
                                        STEP = 10;
                                    }
                                    else if (Result.Contains("ok@{unit_status"))
                                    {
                                        Thread.Sleep(50);
                                        STEP = 10;
                                    }
                                    else
                                    {
                                        Thread.Sleep(50);
                                        //GlobalVariable.SFC_Mcmini_Wait = false;
                                        STEP = 10;

                                    }
                                }


                                bool? sendResult = null;
                                break;
                        }
                    }
                    //Arulkumar Fixed Hung start
                    Thread.Sleep(10);
                    //Arulkumar Fixed Hung end
                }
            }
            catch (Exception)
            {

                throw;
            }
            
        }
        public static string ks;
        public static string ks1;
        public static int PDCA_step = 0;
        public static bool PDCA_while = false;
        public static async Task<string> Final_Data_Send_PDCA(string Carrier_sn, string barcode, string cavity_no, string left_gap, string angle, string ct, string bottom_gap, string press_force)
        {
            try
            {
                Stopwatch OutBScan2 = new Stopwatch();
                SfcClient.commonLOG("PDCA DATALOG START");

                bool Graphite = GlobalVariable.Four_Graphit;
                string querysend = "";

                if(GlobalVariable.g_MachineSite == "TEHR")
                {
                    if (GlobalVariable.g_MachineName == "BOT-GRT")
                    {
                        querysend = barcode + "@start\r\n"
                         + barcode + "@attr@BALI Version@V1.0\r\n"
                         + barcode + "@attr@MLB_SN@" + barcode + "\r\n"
                         + barcode + "@attr@Machine_ID@BOT-GRT\r\n"
                         + barcode + "@attr@Carrier_SN@" + Carrier_sn + "\r\n"
                         + barcode + "@attr@graphite_PKG_ID@NA\r\n"
                         + barcode + "@attr@graphite_DC@NA\r\n"
                         + barcode + "@attr@graphite_LC@NA\r\n"
                         + barcode + "@pdata@" + ((!Graphite) ? "graphite_vendor" : "graphite_vendor") + "@0\r\n"
                         + barcode + "@pdata@pallet_number@0\r\n"
                         + barcode + "@pdata@cavity_number@" + cavity_no + "\r\n"
                         + barcode + "@pdata@" + ((!Graphite) ? "Gap_Y" : "Top_Gap_Y") + "@" + bottom_gap + "@0.1@0.4@mm\r\n"
                         + barcode + "@pdata@angle@" + angle + "@-1@1@degres\r\n"
                         + barcode + "@pdata@Gap_X@" + left_gap + "@0.1@0.4@mm\r\n"
                         + barcode + "@pdata@press_force@" + press_force + "@1.8@2.2@Kgf\r\n"
                         + barcode + "@pdata@press_time@0.5@0.5@0.5@S\r\n"
                         + barcode + "@pdata@tossing@0\r\n"
                         + barcode + "@pdata@cycle_time@" + ct + "@0@NA@S\r\n"
                         + barcode + "@pdata@cm_vendor@1\r\n"
                         + barcode + "@pdata@Operator_ID@1\r\n"
                         + barcode + "@pdata@Mode@0\r\n"
                         + barcode + "@pdata@TestSeriesID@0\r\n"
                         + barcode + "@pdata@Priority@0\r\n"
                         + barcode + "@pdata@Online@0\r\n"
                         + barcode + "@submit@Botgrt\r\n";
                    }
                    else if (GlobalVariable.g_MachineName == "TOP-GRT")
                    {
                        querysend = barcode + "@start\r\n"
                        + barcode + "@attr@BALI Version@V1.0\r\n"
                        + barcode + "@attr@MLB_SN@" + barcode + "\r\n"
                        + barcode + "@attr@Machine_ID@BOT-GRT\r\n"
                        + barcode + "@attr@Carrier_SN@" + Carrier_sn + "\r\n"
                        + barcode + "@attr@graphite_PKG_ID@NA\r\n"
                        + barcode + "@attr@graphite_DC@NA\r\n"
                        + barcode + "@attr@graphite_LC@NA\r\n"
                        + barcode + "@pdata@" + ((!Graphite) ? "graphite_vendor" : "graphite_vendor") + "@0\r\n"
                        + barcode + "@pdata@pallet_number@0\r\n"
                        + barcode + "@pdata@cavity_number@" + cavity_no + "\r\n"
                        + barcode + "@pdata@" + ((!Graphite) ? "Bottom_Gap_Y" : "Bottom_Gap_Y") + "@" + bottom_gap + "@0.1@0.4@mm\r\n"
                        + barcode + "@pdata@angle@" + angle + "@-1@1@degres\r\n"
                        + barcode + "@pdata@Left_Gap_X@" + left_gap + "@0.1@0.4@mm\r\n"
                        + barcode + "@pdata@press_force@" + press_force + "@1.8@2.2@Kgf\r\n"
                        + barcode + "@pdata@press_time@0.5@0.5@0.5@S\r\n"
                        + barcode + "@pdata@tossing@0\r\n"
                        + barcode + "@pdata@cycle_time@" + ct + "@0@NA@S\r\n"
                        + barcode + "@pdata@cm_vendor@1\r\n"
                        + barcode + "@pdata@Operator_ID@1\r\n"
                        + barcode + "@pdata@Mode@0\r\n"
                        + barcode + "@pdata@TestSeriesID@0\r\n"
                        + barcode + "@pdata@Priority@0\r\n"
                        + barcode + "@pdata@Online@0\r\n"
                        + barcode + "@submit@Bottomgrt\r\n";
                    }
                    else
                    {
                        MessageBox.Show("Invalid Machine Name ", "", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);
                    }
                }
                else if(GlobalVariable.g_MachineSite == "TESS")
                {
                    if(GlobalVariable.g_MachineName == "BOT-GRT")
                    {
                        querysend = barcode + "@start\r\n"
                                                + barcode + "@pdata@Mode@0\r\n"
                                + barcode + "@pdata@angle@" + angle + "@-1@1@degres\r\n"
                                + barcode + "@pdata@Priority@0\r\n"
                                + barcode + "@pdata@cycle_time@" + ct + "@0@NA@S\r\n"
                                + barcode + "@pdata@bottom_gap_y@" + bottom_gap + "@0.3@0.7@mm\r\n"
                                + barcode + "@pdata@cavity@" + cavity_no + "\r\n"
                                + barcode + "@pdata@left_gap_x@" + left_gap + "@0.3@0.7@mm\r\n"
                                 + barcode + "@pdata@TestSeriesID@0\r\n"
                                     + barcode + "@pdata@graphite_vendor@1\r\n"
                                + barcode + "@pdata@tossing@0\r\n"
                                + barcode + "@pdata@Operator_ID@0\r\n"
                                + barcode + "@pdata@press_force@" + press_force + "@1.8@2.2@Kgf\r\n"
                                + barcode + "@pdata@press_time@0.5@0.5@0.5@S\r\n"
                                + barcode + "@attr@cm_vendor@TEAL\r\n"
                                + barcode + "@attr@machine_id@Bot_Grt\r\n"
                                + barcode + "@attr@graphite_lc@1000\r\n"
                                + barcode + "@attr@graphite_dc@051922\r\n"
                                + barcode + "@attr@mlb_sn@" + barcode + "\r\n"
                                + barcode + "@attr@graphite_pkg_id@L876042032522005S1\r\n"
                                + barcode + "@attr@carrier_sn@" + Carrier_sn + "\r\n"
                                + barcode + "@attr@bali_version@v4.14.5\r\n"
                                + barcode + "@submit@OJAS_TEAL_BOT_GRT_v1.0";

                    }
                    else
                    {
                        MessageBox.Show("Invalid Machine Name ", "", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);
                    }
                }
                else
                {
                    MessageBox.Show("Invalid Machine Site Name ", "", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);
                }


                PDCA_while = false;
                //Arulkumar Fixed Hung start
                OutBScan2.Restart();
                const int MAX_PDCA_RECEIVE_MS = 30000;
                //Arulkumar Fixed Hung end

                while (!PDCA_while)
                {
                    //Arulkumar Fixed Hung start
                    if (OutBScan2.ElapsedMilliseconds > MAX_PDCA_RECEIVE_MS)
                    {
                        Logger.WriteLog(Logger.LogType.Error, "S_Pdca", "Final_Data_Send_PDCA", "PDCA receive exceeded timeout", barcode);
                        GlobalVariable.SFC_Mcmini_Wait = false;
                        PDCA_step = 0;
                        break;
                    }
                    //Arulkumar Fixed Hung end

                    switch (PDCA_step)
                    {
                        case 0:
                            if (!GlobalVariable.SFC_Mcmini_Wait)
                            {
                                GlobalVariable.SFC_Mcmini_Wait = true;
                                OutBScan2.Restart();
                                ObjectList.SFC.Send(querysend);
                                PdcaClient.PDCA_data_log("Send:  " + querysend, cavity_no);
                                await Logger.WriteLogasTask(Logger.LogType.Running, "PDCA_dDATA", "PDCA_SENT_TO_MACMINI", barcode + "cavity_no: " + cavity_no, "");
                                PDCA_step = 1;
                                Thread.Sleep(2);

                            }
                            break;

                        case 1:
                            ks = ObjectList.SFC.Receive(600001);
                            if (ks == null || ks == "" || ks == "null")
                            {
                                break;
                            }
                            if (ks != null)
                            {
                                PDCA_step = 2;
                                break;
                            }

                            break;
                        case 2:
                            if (ks.Contains("ok@{}@"))
                            {
                                GlobalVariable.PDCA_count_all_Updated = GlobalVariable.PDCA_count_all_Updated + 1;
                                ks = "ok@{}@";
                                PdcaClient.PDCA_data_log("Receive: " + ks, cavity_no);
                                await Logger.WriteLogasTask(Logger.LogType.Running, "PDCA", "PDCA_RECEIVE_FROM_MACMINI", barcode + "cavity_no: " + cavity_no + "Receive: " + ks, "");
                                OutBScan2.Stop();
                                GlobalVariable.SFC_Mcmini_Wait = false;
                                PDCA_while = true;
                                ObjectList.SFC.ClearRcvdDta();
                                PDCA_step = 0;

                            }
                            else
                            {
                                PDCA_step = 1;
                                break;
                            }

                            break;


                    }

                }

                bool? sendResult = null;
                return Final_Result;
            }
            catch (Exception)
            {

                throw;
            }
            

        }
    }
}
