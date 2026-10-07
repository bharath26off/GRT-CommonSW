using ExceptionLib;
using Advantech;
using Advantech.Motion;
using DynamicCylinders;
using GRT_BG1.Data;
using GRT_BG1.Function.Calibration;
using GRT_BG1.Function.Interface;
using Master;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static DIO.DIDO;
using System.Windows.Forms;

namespace GRT_BG1.Function.Classes
{
    public class Feeding
    {
        private static int step = 1;

        private static int Curr_Nozzle_Pick = 1;
        public static  Stopwatch timeout = new Stopwatch();


        public static async Task Feed()
        {

            if (GlobalVariable.DI[(int)EInput.Feed_is_ready] && !GlobalVariable.DI[(int)EInput.Feed_In_Alm])
            {
                if (GlobalVariable.g_MachineIoChaged == "Yes")
                {
                    //GlobalVariable.DIDO.WriteOPS(true, (int)EOutput.Feed_Recoils_Command);
                    GlobalVariable.DIDO.WriteOPS(true, (int)EOutput.Feed_Bed_1_Vacuum_ON);
                    //GlobalVariable.DIDO.WriteOPS(false, (int)EOutput.Feed_Bed_1_Vacuum_OFF);

                    GlobalVariable.DIDO.WriteOPS(true, (int)EOutput.Feed_Bed_2_Vacuum_ON);
                    //GlobalVariable.DIDO.WriteOPS(false, (int)EOutput.Feed_Bed_2_Vacuum_OFF);
                    //await Task.Delay(100);
                    Thread.Sleep(100);
                    //GlobalVariable.DIDO.WriteOPS(false, (int)EOutput.Feed_Bed_2_Vacuum_ON);
                    //GlobalVariable.DIDO.WriteOPS(true, (int)EOutput.Feed_Bed_2_Vacuum_OFF);
                    //await Task.Delay(100);
                    Thread.Sleep(100);
                    GlobalVariable.DIDO.WriteOPS(true, (int)EOutput.Feed_Film_Clmp_Cyl_Up);
                    GlobalVariable.DIDO.WriteOPS(false, (int)EOutput.Feed_Film_Clmp_Cyl_Dn);

                    //await Task.Delay(100);
                    Thread.Sleep(100);
                    //GlobalVariable.DIDO.WriteOPS(false, (int)EOutput.Feed_Pick_Up_The_Command);
                    GlobalVariable.DIDO.WriteOPS(true, (int)EOutput.Feed_Pick_Up_The_Command);
                    Thread.Sleep(500);
                    GlobalVariable.DIDO.WriteOPS(false, (int)EOutput.Feed_Pick_Up_The_Command);
                    // await Task.Delay(500);
                    Thread.Sleep(300);
                    //Arulkumar Fixed Hung start
                    int feedReadyWaitMs = 0;
                    const int MAX_FEED_READY_WAIT_MS = 30000;
                    while (!GlobalVariable.DI[(int)EInput.Feed_is_ready])
                    {
                        await Task.Delay(10);
                        feedReadyWaitMs += 10;
                        if (feedReadyWaitMs >= MAX_FEED_READY_WAIT_MS)
                        {
                            Logger.WriteLog(Logger.LogType.Error, "Feeding", "Feed", "Feed_is_ready sensor timeout", "");
                            return;
                        }
                    }
                    //Arulkumar Fixed Hung end
                    GlobalVariable.DIDO.WriteOPS(true, (int)EOutput.Feed_Bed_1_Vacuum_ON);
                    GlobalVariable.DIDO.WriteOPS(false, (int)EOutput.Feed_Bed_1_Vacuum_OFF);

                    GlobalVariable.DIDO.WriteOPS(true, (int)EOutput.Feed_Bed_2_Vacuum_ON);
                    GlobalVariable.DIDO.WriteOPS(false, (int)EOutput.Feed_Bed_2_Vacuum_OFF);
                    //await Task.Delay(100);
                    Thread.Sleep(100);
                    //GlobalVariable.DIDO.WriteOPS(false, (int)EOutput.Feed_Bed_2_Vacuum_ON);
                    //GlobalVariable.DIDO.WriteOPS(false, (int)EOutput.Feed_Bed_2_Vacuum_OFF);
                    GlobalVariable.DIDO.WriteOPS(false, (int)EOutput.Feed_Pick_Up_The_Command);
                    //await Task.Delay(100);
                    Thread.Sleep(100);
                    GlobalVariable.DIDO.WriteOPS(false, (int)EOutput.Feed_Film_Clmp_Cyl_Dn);
                    GlobalVariable.DIDO.WriteOPS(true, (int)EOutput.Feed_Film_Clmp_Cyl_Up);
                }
                else
                {
                    //GlobalVariable.DIDO.WriteOPS(true, (int)EOutput.Feed_Recoils_Command);
                    GlobalVariable.DIDO.WriteOPS(true, (int)EOutput.Feed_Bed_1_Vacuum_ON);
                    GlobalVariable.DIDO.WriteOPS(false, (int)EOutput.Feed_Bed_1_Vacuum_OFF);
                    await Task.Delay(100);
                    GlobalVariable.DIDO.WriteOPS(true, (int)EOutput.Feed_Bed_2_Vacuum_ON);
                    GlobalVariable.DIDO.WriteOPS(false, (int)EOutput.Feed_Bed_2_Vacuum_OFF);
                    await Task.Delay(100);
                    GlobalVariable.DIDO.WriteOPS(true, (int)EOutput.Feed_Film_Clmp_Cyl_Up);
                    GlobalVariable.DIDO.WriteOPS(false, (int)EOutput.Feed_Film_Clmp_Cyl_Dn);

                    await Task.Delay(100);
                    //GlobalVariable.DIDO.WriteOPS(false, (int)EOutput.Feed_Pick_Up_The_Command);
                    GlobalVariable.DIDO.WriteOPS(true, (int)EOutput.Feed_Pick_Up_The_Command);
                    //GlobalVariable.DIDO.WriteOPS(false, (int)EOutput.Feed_Pick_Up_The_Command);
                    await Task.Delay(100);
                    //Arulkumar Fixed Hung start
                    // Bounded wait for feed-ready. Previously this loop had no timeout, so a feeder jam
                    // or a stuck "Feed_is_ready" sensor hung the auto sequence indefinitely. Exit after
                    // 30s so the sequence can continue / alarm instead of freezing.
                    var swFeedReady = System.Diagnostics.Stopwatch.StartNew();
                    while (!GlobalVariable.DI[(int)EInput.Feed_is_ready] && swFeedReady.ElapsedMilliseconds < 30000)
                    {
                        await Task.Delay(10);
                    }
                    //Arulkumar Fixed Hang end
                    GlobalVariable.DIDO.WriteOPS(true, (int)EOutput.Feed_Bed_1_Vacuum_ON);
                    GlobalVariable.DIDO.WriteOPS(false, (int)EOutput.Feed_Bed_1_Vacuum_OFF);
                    await Task.Delay(50);
                    GlobalVariable.DIDO.WriteOPS(true, (int)EOutput.Feed_Bed_2_Vacuum_ON);
                    GlobalVariable.DIDO.WriteOPS(false, (int)EOutput.Feed_Bed_2_Vacuum_OFF);
                    GlobalVariable.DIDO.WriteOPS(false, (int)EOutput.Feed_Pick_Up_The_Command);
                    await Task.Delay(50);
                    GlobalVariable.DIDO.WriteOPS(false, (int)EOutput.Feed_Film_Clmp_Cyl_Dn); // AK
                    GlobalVariable.DIDO.WriteOPS(true, (int)EOutput.Feed_Film_Clmp_Cyl_Up);
                }


            }

        }


    }
}
