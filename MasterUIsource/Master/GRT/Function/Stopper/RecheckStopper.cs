using DynamicCylinders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static DIO.DIDO;

namespace Master.GRT.Function.Stopper
{
    public class RecheckStopper
    {
        private static CancellationTokenSource _cts;
        public static int RecheckStopper_Steep = 0;


        public static void Start()
        {
            _cts = new CancellationTokenSource();
            // Stop();
            Task.Run(() => RecheckStopperPro(_cts.Token));
        }

        public static void Stop()
        {
            if (_cts != null)
            {
                _cts.Cancel();
                RecheckStopper_Steep = 0;
            }
        }

        public static async Task RecheckStopperPro(CancellationToken token)
        {

            try
            {
                await Task.Delay(100);
                while (!token.IsCancellationRequested)
                {
                    if (GlobalVariable.RecheckStopper_Start)
                    {
                        switch (RecheckStopper_Steep)
                        {
                            case 0:
                                if (GlobalVariable.g_MachineIoChaged == "Yes" ?  !GlobalVariable.DI[(int)EInput.Work_Conv_2_Pallet_Exit_Sen] : !GlobalVariable.DI[(int)EInput.Work_Conv_2_Pallet_Exit_Sen])
                                {
                                    await Task.Delay(GlobalVariable.Stopper_Recheck_Time);
                                    RecheckStopper_Steep = 1;
                                }
                                break;
                            case 1:
                                if (GlobalVariable.g_MachineIoChaged == "Yes" ? !GlobalVariable.DI[(int)EInput_1.Work_Conv_2_Pallet_Inplace_Sen] : !GlobalVariable.DI[(int)EInput.Work_Conv_2_Pallet_Inplace_Sen] && 
                                    GlobalVariable.g_MachineIoChaged == "Yes" ? !GlobalVariable.DI[(int)EInput_1.Work_Conv_2_Pallet_Exit_Sen] : !GlobalVariable.DI[(int)EInput.Work_Conv_2_Pallet_Exit_Sen]) ;
                                {
                                    Cylinder_config.Cylinders_List[(int)Cylinder_config.Cylinders.Work_Conv_2_Stopper_Cyl]
                                          .Cylinder_Extend();
                                    RecheckStopper_Steep = 2;

                                }
                                break;
                            case 2:
                                GlobalVariable.RecheckStopper_Start = false;
                                RecheckStopper_Steep = 0;
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
