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
    public class LoadingStopper
    {

        private static CancellationTokenSource _cts;
        public static int Loadingstopper = 0;
        public static Stopwatch UnLoading_Timer = new Stopwatch();

        public static void Start()
        {
            _cts = new CancellationTokenSource();
            // Stop();
            Task.Run(() => LoadingStopperPro(_cts.Token));
        }

        public static void Stop()
        {
            if (_cts != null)
            {
                _cts.Cancel();
                Loadingstopper = 0;
            }
        }


        public static async Task LoadingStopperPro(CancellationToken token)
        {

            try
            {
                await Task.Delay(100);
                while (!token.IsCancellationRequested)
                {
                    if (GlobalVariable.LoadingStopper_Start)
                    {
                        switch (Loadingstopper)
                        {
                            case 0:
                                if (!GlobalVariable.DI[(int)EInput.Scan_Conv_Pallet_Exit_Sen])
                                {
                                    await Task.Delay(GlobalVariable.Stopper_loading_Time);
                                    Loadingstopper = 1;
                                }
                                break;
                            case 1:
                                if (!GlobalVariable.DI[(int)EInput.Scan_Conv_Pallet_Exit_Sen])
                                {
                                    Cylinder_config.Cylinders_List[(int)Cylinder_config.Cylinders.Scan_Conv_Stopper_Cyl]
                                          .Cylinder_Extend();
                                    Loadingstopper = 2;

                                }
                                break;
                            case 2:
                                GlobalVariable.LoadingStopper_Start = false;
                                Loadingstopper = 0;
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
