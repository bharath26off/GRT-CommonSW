using Advantech;
using ExceptionLib;
using GRT_BG1.Function.Interface;
using HelperClassLib;
using Master;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GRT_BG1.Function.Calibration
{
    public  class VisionSystem: ICamera
    {
        public static void PlaceMylar(string ccd) => Console.WriteLine($"Placing mylar, CCD {ccd} must see it clearly.");
        public static void Trigger(string ccd) => Console.WriteLine($"CCD {ccd} triggered.");
        public static void Calibrate(string ccd)
        {
            Console.WriteLine($"Running calibration for {ccd}...");
            //SocketClient.ReceiveVisionData(ccd);
            //if (SocketClient.V_ReceiveData2.Contains($"{ccd}_OK"))
                Console.WriteLine($"{ccd} Calibration successful.");
        }
        
        public async Task<string> Trig_Camera(SocketClient Vision,string trigger)
        {
            string process = "";
            try
            {
                //trig Scanner

                if (true)//GlobalVariable.Camera_Bypass)
                {
                    return "bypass";
                }
                else
                {
                    process = await Vision.SendAndReceiveAsync(trigger);
                    return process;
                }
            }
            catch (Exception es)
            {
                await Logger.WriteLogasTask(Logger.LogType.Running, "Conveyor1", "Conveyor1", "Carrier exited. Raising stopper for next carrier.", "");
            }
            return process;
        }


    }

}
