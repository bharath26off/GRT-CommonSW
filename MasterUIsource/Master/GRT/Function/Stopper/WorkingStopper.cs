using DynamicCylinders;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static DIO.DIDO;

namespace Master.GRT.Function.Stopper
{
    public class WorkingStopper
    {
        private static CancellationTokenSource _cts;
        public static int WorkingStopper_Steep = 0;
        

        public static void Start()
        {
            _cts = new CancellationTokenSource();
            // Stop();
            Task.Run(() => Working1StopperPro(_cts.Token));
        }

        public static void Stop()
        {
            if (_cts != null)
            {
                _cts.Cancel();
                WorkingStopper_Steep = 0;
            }
        }

        public static async Task Working1StopperPro(CancellationToken token)
        {

            try
            {
                await Task.Delay(100);
                while (!token.IsCancellationRequested)
                {
                    if (GlobalVariable.WorkingStopper_Start)
                    {
                        switch (WorkingStopper_Steep)
                        {
                            case 0:
                                if (!GlobalVariable.DI[(int)EInput.Work_Conv_1_Pallet_Exit_Sen])
                                {
                                    await Task.Delay(GlobalVariable.Stopper_Working_Time);
                                    WorkingStopper_Steep = 1;
                                }
                                break;
                            case 1:
                                if (!GlobalVariable.DI[(int)EInput.Work_Conv_1_Pallet_Exit_Sen])
                                {
                                    Cylinder_config.Cylinders_List[(int)Cylinder_config.Cylinders.Work_Conv_1_Stopper_Cyl].Cylinder_Extend();
                                    WorkingStopper_Steep = 2;
                                }
                                break;
                            case 2:
                                GlobalVariable.WorkingStopper_Start = false;
                                WorkingStopper_Steep = 0;
                                Stop();
                                break;
                        }
                    }

                }

            }
            catch
            {
            }
        }
    }
}
