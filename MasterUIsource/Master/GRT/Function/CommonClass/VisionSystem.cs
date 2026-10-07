using Advantech;
using ExceptionLib;
using GRT_BG1.Data;
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
        string ScnrResult = "";


        public async Task<string> Trig_Camera(SocketClient Vision,string trigger)
        {
            

            try
            {
                ScnrResult = "";
                Vision.ClearRcvdDta2();
                Vision.ClearRcvdDta();

                if (Vision == null)
                {
                    return "";
                }

                if (Vision.Send(trigger))
                {
                    await Task.Delay(450);
                    ScnrResult = Vision.Receive(600001);
                    Vision.ClearRcvdDta2();
                    Vision.ClearRcvdDta();
                }
            }
            catch (Exception es)
            {
                await Logger.WriteLogasTask(Logger.LogType.Running, "Conveyor1", "Conveyor1", "Carrier exited. Raising stopper for next carrier.", "");
            }
            return ScnrResult;
        }


    }

}
