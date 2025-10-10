using Advantech;
using Advantech.Motion;
using DynamicCylinders;
using GRT_BG1.Data;
using GRT_BG1.Function.Calibration;
using GRT_BG1.Function.Classes;
using GRT_BG1.GlobalVar;
using Master;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UI.UI_Forms;
using static DIO.DIDO;

namespace GRT_BG1.Function.DryRun
{
    public class Feeding
    {
        private static int step = 1;
        private static  VisionSystem camera = new VisionSystem();
        private static int Curr_Nozzle_Pick = 1;

        public static async Task Feed(int row, int col,int prevRow,int PrevCol, PartData[,] palletarr)
        {

            switch (step)
            {
                case 1: //move Gantry for pick the form
                    if (ObjectList.XAxis2.Move_Abs(Convert.ToDouble(Variable.wk1_FeederPos.x), GlobalVariable.g_lstAxisConfig[(int)EAxis.Servo_X2].AutoSpeed, GlobalVariable.g_lstAxisConfig[(int)EAxis.Servo_X2].Acc, GlobalVariable.g_lstAxisConfig[(int)EAxis.Servo_X2].DeAcc, 5000))
                    {
                        if (ObjectList.YAxis2.Move_Abs(Convert.ToDouble(Variable.wk1_FeederPos.y), GlobalVariable.g_lstAxisConfig[(int)EAxis.Servo_Y2].AutoSpeed, GlobalVariable.g_lstAxisConfig[(int)EAxis.Servo_Y2].Acc, GlobalVariable.g_lstAxisConfig[(int)EAxis.Servo_Y2].DeAcc, 5000))
                        {
                            NozzleSystem.MoveUp("Nozzle1");
                            NozzleSystem.MoveDown("Nozzle1");
                            NozzleSystem.Pick("Nozzle1");
                            NozzleSystem.MoveUp("Nozzle1");
                            NozzleSystem.MoveUp("Nozzle2");
                            NozzleSystem.MoveDown("Nozzle2");
                            NozzleSystem.Pick("Nozzle2");
                            NozzleSystem.MoveUp("Nozzle2");
                            step = 2;

                        }
                    }
                    break;
              
                case 2:
                    ////move to CCD2 for inspection
                    if (ObjectList.XAxis2.Move_Abs(Convert.ToDouble(Variable.wk1_CCD2Pos.x), GlobalVariable.g_lstAxisConfig[(int)EAxis.Servo_X2].AutoSpeed, GlobalVariable.g_lstAxisConfig[(int)EAxis.Servo_X2].Acc, GlobalVariable.g_lstAxisConfig[(int)EAxis.Servo_X2].DeAcc, 5000))
                    {
                        if (ObjectList.YAxis2.Move_Abs(Convert.ToDouble(Variable.wk1_CCD2Pos.y), GlobalVariable.g_lstAxisConfig[(int)EAxis.Servo_Y2].AutoSpeed, GlobalVariable.g_lstAxisConfig[(int)EAxis.Servo_Y2].Acc, GlobalVariable.g_lstAxisConfig[(int)EAxis.Servo_Y2].DeAcc, 5000))
                        {

                            NozzleSystem.MoveDown("Nozzle1");
                            NozzleSystem.MoveUp("Nozzle1");
                            NozzleSystem.MoveDown("Nozzle1");
                            NozzleSystem.MoveUp("Nozzle1");

                        }
                    }

                    break;
               

            }
        }


    }
}
