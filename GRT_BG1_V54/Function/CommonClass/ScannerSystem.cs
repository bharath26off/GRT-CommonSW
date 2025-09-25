using ExceptionLib;
using GRT_BG1.Function.Interface;
using HelperClassLib;
using Master;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GRT_BG1.Function.Classes
{
    public class ScannerSystem : IScanner
    {
        //  public static SocketClient LoadingScanner = new SocketClient("LoadingScanner");
        SocketClient scanner = new SocketClient("LoadingScanner");
        public async Task<string> Trig_Scanner()
        {
            string process = "";
            try
            {
                //trig Scanner

                if (true)//GlobalVariable.Scanner_Bypass)
                {
                    return "bypass";
                }
                else
                {
                    process = await scanner.SendAndReceiveAsync("+\r");
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
