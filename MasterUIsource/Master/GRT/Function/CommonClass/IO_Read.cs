using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Master.GRT.Function.CommonClass
{
    public class I_O_Read
    {
        private static CancellationTokenSource _cts;

        public static void Start()
        {
            _cts = new CancellationTokenSource();
            Task.Run(() => I_O_Read_Monitior(_cts.Token));
        }

        public static void Stop()
        {
            if (_cts != null)
            {
                _cts.Cancel();
            }
        }
        public static async Task I_O_Read_Monitior(CancellationToken token)
        {
            while (!token.IsCancellationRequested)
            {
                await Task.Delay(50);
                try
                {
                    if (GlobalVariable.g_CardInitSucc)
                    {
                        //GlobalVariable.DI = GlobalVariable.DI_DO_Read.DI_RefreshValue(GlobalVariable.DI.Length, GlobalVariable.InputPortCfg, GlobalVariable.DI);
                        GlobalVariable.DO = GlobalVariable.DI_DO_Read.DO_RefreshValue(GlobalVariable.DO.Length, GlobalVariable.OutputPortCfg, GlobalVariable.DO);
                    }
                }
                catch (Exception ex)
                {

                }
            }
        }


    }
}

