using Advantech;
using GRT_BG1.Data;
using GRT_BG1.Function.Calibration;
using GRT_BG1.GlobalVar;
using Master;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DIO.DIDO;

namespace GRT_BG1.Function.Classes
{
    public class Pasting
    {

        private static int step = 1;
        VisionSystem camera = new VisionSystem();

        public static async Task PastingStabilization(int row, int col, int Prevrow, int Prevcol, PartData[,] palletarr)
        {
            await Past(row, col, palletarr);
            await Past(Prevrow, Prevcol, palletarr);
        }
        public static async Task Past(int row, int col, PartData[,] palletarr)
        {
            switch (step)
            {
                case 1:
                    if (ObjectList.XAxis2.Move_Abs(Convert.ToDouble(palletarr[row, col].PositionX), GlobalVariable.g_lstAxisConfig[(int)EAxis.Servo_X2].AutoSpeed, GlobalVariable.g_lstAxisConfig[(int)EAxis.Servo_X2].Acc, GlobalVariable.g_lstAxisConfig[(int)EAxis.Servo_X2].DeAcc, 5000))
                    {
                        if (ObjectList.YAxis2.Move_Abs(Convert.ToDouble(palletarr[row, col].PositionY), GlobalVariable.g_lstAxisConfig[(int)EAxis.Servo_Y2].AutoSpeed, GlobalVariable.g_lstAxisConfig[(int)EAxis.Servo_Y2].Acc, GlobalVariable.g_lstAxisConfig[(int)EAxis.Servo_Y2].DeAcc, 5000))
                        {
                            goto case 2;

                        }
                    }
                    break;
                case 2:

                    if (ObjectList.XAxis2.CheckDoneAxis(Convert.ToDouble(palletarr[row, col].PositionX), 50000, true) == 0 && ObjectList.XAxis2.CheckDoneAxis(Convert.ToDouble(palletarr[row, col].PositionY), 50000, true) == 0)
                    {

                        NozzleSystem.MoveDown("down");
                        NozzleSystem.Place("place");
                        NozzleSystem.MoveDown("up");
                        step = 1;

                    }
                    break;

            }
        }



    }
}
