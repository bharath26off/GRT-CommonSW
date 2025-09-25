using Advantech;
using Advantech.Motion;
using DynamicCylinders;
using GRT_BG1.Data;
using GRT_BG1.Function.Calibration;
using GRT_BG1.Function.Interface;
using GRT_BG1.GlobalVar;
using Master;
using MasterProject.GlobalClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DIO.DIDO;

namespace GRT_BG1.Function.Classes
{
    public class Feeding
    {
        private static int step = 1;
        private static VisionSystem camera = new VisionSystem();
        private static int Curr_Nozzle_Pick = 1;

        public static async Task Feed(int row, int col, int prevRow, int PrevCol, PartData[,] palletarr)
        {

            switch (step)
            {
                case 1: //move Gantry for pick the form
                    if (ObjectList.XAxis2.Move_Abs(Convert.ToDouble(Variable.wk1_FeederPos.x), GlobalVariable.g_lstAxisConfig[(int)EAxis.X2].AutoSpeed, GlobalVariable.g_lstAxisConfig[(int)EAxis.X2].Acc, GlobalVariable.g_lstAxisConfig[(int)EAxis.X2].DeAcc, 5000))
                    {
                        if (ObjectList.YAxis2.Move_Abs(Convert.ToDouble(Variable.wk1_FeederPos.y), GlobalVariable.g_lstAxisConfig[(int)EAxis.Y2].AutoSpeed, GlobalVariable.g_lstAxisConfig[(int)EAxis.Y2].Acc, GlobalVariable.g_lstAxisConfig[(int)EAxis.Y2].DeAcc, 5000))
                        {
                            NozzleSystem.MoveUp("Nozzle1");
                            NozzleSystem.MoveDown("Nozzle1");
                            NozzleSystem.Pick("Nozzle1");
                            NozzleSystem.MoveUp("Nozzle1");
                            NozzleSystem.MoveUp("Nozzle2");
                            NozzleSystem.MoveDown("Nozzle2");
                            NozzleSystem.Pick("Nozzle2");
                            NozzleSystem.MoveUp("Nozzle2");

                        }
                    }
                    break;
                case 2:
                    break;

                case 3:
                    ////move to CCD2 for inspection
                    if (ObjectList.XAxis2.Move_Abs(Convert.ToDouble(Variable.wk1_CCD2Pos.x), GlobalVariable.g_lstAxisConfig[(int)EAxis.X2].AutoSpeed, GlobalVariable.g_lstAxisConfig[(int)EAxis.X2].Acc, GlobalVariable.g_lstAxisConfig[(int)EAxis.X2].DeAcc, 5000))
                    {
                        if (ObjectList.YAxis2.Move_Abs(Convert.ToDouble(Variable.wk1_CCD2Pos.y), GlobalVariable.g_lstAxisConfig[(int)EAxis.Y2].AutoSpeed, GlobalVariable.g_lstAxisConfig[(int)EAxis.Y2].Acc, GlobalVariable.g_lstAxisConfig[(int)EAxis.Y2].DeAcc, 5000))
                        {
                            string cmd1 = "";//"T2,S,1,1," + Curr_Nozzle_Place.ToString() + "," + Pre_Cavity_num.ToString() + "," + dtm + "," + X2Y2_Nozzle1_Pos[1] + "," + X2Y2_Nozzle1_Pos[0].ToString() + ",0," + xposs.ToString() + "," + yposs.ToString() + ",0,0,0,0,1");
                            string data1 = await camera.Trig_Camera(ObjectList.Vision2,cmd1);

                            Variable.cCD2Data[1].OkNok = data1;//data from camera
                            Variable.cCD2Data[1].position = 4.5;//datafrom camera


                            string cmd2 = "";
                            string data2 = await camera.Trig_Camera(ObjectList.Vision2, cmd2);

                            Variable.cCD2Data[2].OkNok = data2;//data from camera
                            Variable.cCD2Data[2].position = 4.5;//datafrom camera

                            palletarr[prevRow, PrevCol].PositionX = Variable.cCD2Data[1].position;
                            palletarr[prevRow, PrevCol].PositionY = Variable.cCD2Data[1].position;
                            palletarr[row, col].PositionX = Variable.cCD2Data[2].position;
                            palletarr[row, col].PositionY = Variable.cCD2Data[2].position;

                            if (Variable.cCD2Data[1].OkNok == "nok" || Variable.cCD2Data[2].OkNok == "nok")
                                goto case 4;
                            else
                                goto case 5;
                        }
                    }

                    break;
                case 4://Go to rejection bin
                    if (ObjectList.XAxis2.Move_Abs(Convert.ToDouble(Variable.wk1_RejBin.x), GlobalVariable.g_lstAxisConfig[(int)EAxis.X2].AutoSpeed, GlobalVariable.g_lstAxisConfig[(int)EAxis.X2].Acc, GlobalVariable.g_lstAxisConfig[(int)EAxis.X2].DeAcc, 5000))
                    {
                        if (ObjectList.YAxis2.Move_Abs(Convert.ToDouble(Variable.wk1_RejBin.y), GlobalVariable.g_lstAxisConfig[(int)EAxis.Y2].AutoSpeed, GlobalVariable.g_lstAxisConfig[(int)EAxis.Y2].Acc, GlobalVariable.g_lstAxisConfig[(int)EAxis.Y2].DeAcc, 5000))
                        {
                            if (Variable.cCD2Data[1].OkNok == "nok")
                                NozzleSystem.Place("Nozzle1");
                            else

                            if (Variable.cCD2Data[2].OkNok == "nok")
                                NozzleSystem.Place("Nozzle2");

                        }
                    }

                    break;
                case 5:
                    break;

            }
        }


    }
}
