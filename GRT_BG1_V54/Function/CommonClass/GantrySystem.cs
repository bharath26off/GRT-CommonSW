using Advantech;
using GRT_BG1.Data;
using GRT_BG1.GlobalVar;
using Master;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DIO.DIDO;

namespace GRT_BG1.Function.Calibration
{
    public static class GantrySystem
    {
        static PalletData PalletData;
        public static async Task TraversArray(Func<int, int, Task> action, int rows, int cols)
        {


            for (int col = 0; col < cols; col++)
            {
                if (col % 2 == 0)
                {
                    // Even column: top to bottom
                    for (int row = 0; row < rows; row++)
                    {
                        await action(row, col);
                    }
                }
                else
                {
                    // Odd column: bottom to top
                    for (int row = rows - 1; row >= 0; row--)
                    {
                        await action(row, col);
                    }
                }
            }
        }
        public static void MoveToPositions(int count, string ccd)
        {
            for (int i = 1; i <= count; i++)
                Console.WriteLine($"Gantry-{ccd} to position {i}, capturing image.");
        }

        public static async Task LoadPosition()
        {
            await TraversArray(CreatePart, PalletData.PalletArr.GetLength(0), PalletData.PalletArr.GetLength(1));
        }

        //create each MLB data object
        public static async Task CreatePart(int row, int col)
        {
            PalletData.PalletArr[row, col] = new PartData
            {
               // PositionX = GlobalVariable.posArray[row, col].x, //read position x
               // PositionY = GlobalVariable.posArray[row, col].y////read position y
            };

        }
        public static async Task scan()
        {
            await TraversArray(GantryMovement, PalletData.PalletArr.GetLength(0), PalletData.PalletArr.GetLength(1));

        }

        public static async Task GantryMovement(int row, int col)
        {

            if (ObjectList.YAxis1.Move_Abs(Convert.ToDouble(PalletData.PalletArr[row, col].PositionY), GlobalVariable.g_lstAxisConfig[(int)EAxis.Servo_Y1].AutoSpeed, GlobalVariable.g_lstAxisConfig[(int)EAxis.Servo_Y1].Acc, GlobalVariable.g_lstAxisConfig[(int)EAxis.Servo_Y1].DeAcc, 5000))
            {
                if (ObjectList.XAxis1.Move_Abs(Convert.ToDouble(PalletData.PalletArr[row, col].PositionX), GlobalVariable.g_lstAxisConfig[(int)EAxis.Servo_X1].AutoSpeed, GlobalVariable.g_lstAxisConfig[(int)EAxis.Servo_X1].Acc, GlobalVariable.g_lstAxisConfig[(int)EAxis.Servo_X1].DeAcc, 5000))
                {

                }

            }

        }

        public async static Task wk1_home()
        {
            if (ObjectList.YAxis1.Move_Abs(Convert.ToDouble(Variable.wk1_home.y), GlobalVariable.g_lstAxisConfig[(int)EAxis.Servo_Y1].AutoSpeed, GlobalVariable.g_lstAxisConfig[(int)EAxis.Servo_Y1].Acc, GlobalVariable.g_lstAxisConfig[(int)EAxis.Servo_Y1].DeAcc, 5000))
            {
                if (ObjectList.XAxis1.Move_Abs(Convert.ToDouble(Variable.wk1_home.x), GlobalVariable.g_lstAxisConfig[(int)EAxis.Servo_X1].AutoSpeed, GlobalVariable.g_lstAxisConfig[(int)EAxis.Servo_X1].Acc, GlobalVariable.g_lstAxisConfig[(int)EAxis.Servo_X1].DeAcc, 5000))
                {
                    await Task.Delay(1000);
                }

            }

        }
        public async static Task wk2_home()
        {
            if (ObjectList.YAxis1.Move_Abs(Convert.ToDouble(Variable.wk2_home.y), GlobalVariable.g_lstAxisConfig[(int)EAxis.Servo_Y3].AutoSpeed, GlobalVariable.g_lstAxisConfig[(int)EAxis.Servo_Y3].Acc, GlobalVariable.g_lstAxisConfig[(int)EAxis.Servo_Y3].DeAcc, 5000))
            {
                if (ObjectList.XAxis1.Move_Abs(Convert.ToDouble(Variable.wk2_home.x), GlobalVariable.g_lstAxisConfig[(int)EAxis.Servo_X3].AutoSpeed, GlobalVariable.g_lstAxisConfig[(int)EAxis.Servo_X3].Acc, GlobalVariable.g_lstAxisConfig[(int)EAxis.Servo_X3].DeAcc, 5000))
                {
                    await Task.Delay(1000);
                }

            }

        }

        public async static Task scanCnv_home()
        {
            if (ObjectList.YAxis1.Move_Abs(Convert.ToDouble(Variable.scan_home.y), GlobalVariable.g_lstAxisConfig[(int)EAxis.Servo_Y1].AutoSpeed, GlobalVariable.g_lstAxisConfig[(int)EAxis.Servo_Y1].Acc, GlobalVariable.g_lstAxisConfig[(int)EAxis.Servo_Y1].DeAcc, 5000))
            {
                if (ObjectList.XAxis1.Move_Abs(Convert.ToDouble(Variable.scan_home.x), GlobalVariable.g_lstAxisConfig[(int)EAxis.Servo_Y1].AutoSpeed, GlobalVariable.g_lstAxisConfig[(int)EAxis.Servo_Y1].Acc, GlobalVariable.g_lstAxisConfig[(int)EAxis.Servo_Y1].DeAcc, 5000))
                {
                    await Task.Delay(1000);
                   
                }
            }

        }

    }
}
