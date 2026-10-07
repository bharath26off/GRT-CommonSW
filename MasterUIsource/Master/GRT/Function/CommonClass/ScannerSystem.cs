using ExceptionLib;
using GRT_BG1.Function.Interface;
using HelperClassLib;
using Master;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GRT_BG1.Function.Classes
{
    public class ScannerSystem
    {
        public static string ScnrResult = "";
        private static Stopwatch outscanMLBStopwatch = new Stopwatch();
        public static  string Trig_Scanner(SocketClient Vision, string trigger)
        {
            try
            {
                outscanMLBStopwatch.Restart();
                Vision.ClearRcvdDta2();
                Vision.ClearRcvdDta();
                if (Vision.Send(trigger))
                {
                    Vision.ClearRcvdDta2();
                    Vision.ClearRcvdDta();
                    //while (outscanMLBStopwatch.ElapsedMilliseconds < 5000)
                    

                    //while (outscanMLBStopwatch.ElapsedMilliseconds < GlobalVariable.scan_Delay)
                    while (outscanMLBStopwatch.ElapsedMilliseconds <GlobalVariable.Barcode_Scanner_Recevier_Delay)
                    {
                        ScnrResult = Vision.Receive(600001);
                        if (!string.IsNullOrEmpty(ScnrResult))
                        {
                            break;
                        }
                    }
                    outscanMLBStopwatch.Stop();


                }
            }
            catch (Exception es)
            {
                Logger.WriteLogasTask(Logger.LogType.Running, "Conveyor1", "Conveyor1", "Carrier exited. Raising stopper for next carrier.", "");

            }
            return ScnrResult;

        }

    }
}
