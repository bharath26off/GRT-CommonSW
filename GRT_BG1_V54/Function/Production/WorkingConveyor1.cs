using Advantech;
using Advantech.Motion;
using DynamicCylinders;
using GRT_BG1.Data;
using GRT_BG1.Function.Calibration;
using GRT_BG1.Function.Classes;
using GRT_BG1.Function.Interface;
using GRT_BG1.GlobalVar;
using Master;
using MasterProject.GlobalClass;
using System;
using System.Collections;
using System.Linq;
using System.Threading.Tasks;
using static DIO.DIDO;

namespace GRT_BG1.Function
{
    public class WorkingConveyor1 : IWorkingConveyor
    {
        private static int i_step = 1;
        PalletData pallet;
        int okParts = 0;
        int nokParts = 0;
        public int nozzleno = 0;
        VisionSystem camera = new VisionSystem();
        int PreRow = 0; int PreCol = 0;

        public async Task WorkingCon_Seq()
        {
            switch (i_step)
            {
                case 0:
                    if (HasPalletData())
                        pallet = GetCurrentPallet();
                    i_step = 10;
                    break;


                case 10:
                    // Carrier is lifted up with the help of lifter cylinder
                    Cylinder_config.Cylinders_List[(int)Cylinder_config.Cylinders.Work_Conv_2_pallet_Lift_Cyl].Cylinder_Extend();
                    i_step = 20;
                    break;

                case 20:
                    if (GlobalVariable.DI[(int)EInput.Work_Conv_1_Pallet_Lift_Cyl_Up])
                    {
                        await CameraScan();
                    }
                    else
                    {
                        await Task.Delay(100);
                        if (!GlobalVariable.DI[(int)EInput.Work_Conv_1_Pallet_Lift_Cyl_Up])
                            GlobalVariable.AlarmTrigger(ECode.Belt1Conveyor_Timeout_Error, true, 0);
                    }
                        i_step = 30;
                    break;

                case 30:
                    await GoForPast();
                    i_step = 40;
                    break;
                case 40:
                    await GantrySystem.wk1_home();
                    i_step = 50;
                    break;

                case 50:
                    // Pallet lifter cylinder moves down to conveyor position
                    Cylinder_config.Cylinders_List[(int)Cylinder_config.Cylinders.Work_Conv_1_pallet_Lift_Cyl].Cylinder_Retract();
                    i_step = 60;
                    break;

                case 60:
                    // Stopper cylinder moves down & when carrier sensor senses Conveyor 2 motor start rotates
                    if (GlobalVariable.DI[(int)EInput.Work_Conv_1_Pallet_Lift_Cyl_Dn])
                    {
                        ConveyorSystem.MovePlate(new bool?[] { null, null, true, true });
                        await ConveyorSystem.EntryWk2Cnv();
                        Cylinder_config.Cylinders_List[(int)Cylinder_config.Cylinders.Work_Conv_1_Stopper_Cyl].Cylinder_Retract();
                    }
                    else
                    {
                        await Task.Delay(100);
                        if (!GlobalVariable.DI[(int)EInput.Work_Conv_1_Pallet_Lift_Cyl_Dn])
                            GlobalVariable.AlarmTrigger(ECode.Belt1Conveyor_Timeout_Error, true, 0);

                    }
                        i_step = 70;
                    break;
                case 70:

                    if (GlobalVariable.DI[(int)EInput.Work_Conv_1_Stopper_Cyl_Dn] && GlobalVariable.DI[(int)EInput.Work_Conv_2_Stopper_Cyl_Up])
                    {
                       
                        if(await ConveyorSystem.DetectCarrierWk1Cnv())
                        i_step = 80;
                    }
                    else
                    {
                        await Task.Delay(100);
                    }
                    break;

                case 80:
                    // Based on feedback from pallet exit sensor, conveyor 3 motor start rotates
                    if (GlobalVariable.DI[(int)EInput.Work_Conv_2_Pallet_Inplace_Sen])
                    {

                        ConveyorSystem.MovePlate(new bool?[] { null, null,false, false });
                        Cylinder_config.Cylinders_List[(int)Cylinder_config.Cylinders.Work_Conv_1_Stopper_Cyl].Cylinder_Extend();
                        i_step = 90;
                    }
                    else
                    {
                        await Task.Delay(100);
                        if (!GlobalVariable.DI[(int)EInput.Work_Conv_2_Pallet_Inplace_Sen])
                            GlobalVariable.AlarmTrigger(ECode.Belt1Conveyor_Timeout_Error, true, 0);
                    }
                    break;

                case 90:
                    // Carrier moves to conveyor 2 to conveyor 3 for CCD3 inspection
                    Variable.PalletQueue23.Enqueue(Variable.PalletQueue12.Dequeue());
                    break;

                default:
                    i_step = 1; // Reset or idle
                    break;
            }
        }

        public async Task CameraScan()
        {
            if (pallet == null) return;

            int rows = pallet.PalletArr.GetLength(0);
            int cols = pallet.PalletArr.GetLength(1);

            await GantrySystem.TraversArray(ScanCameraData, rows, cols);
        }

        private async Task ScanCameraData(int row, int col)
        {
            var pallet = GetCurrentPallet();
            if (pallet == null) return;
            if (ObjectList.XAxis1.Move_Abs(Convert.ToDouble(pallet.PalletArr[row, col].PositionX), GlobalVariable.g_lstAxisConfig[(int)EAxis.X2].AutoSpeed, GlobalVariable.g_lstAxisConfig[(int)EAxis.X2].Acc, GlobalVariable.g_lstAxisConfig[(int)EAxis.X2].DeAcc, 5000))
            {
                if (ObjectList.YAxis1.Move_Abs(Convert.ToDouble(pallet.PalletArr[row, col].PositionY), GlobalVariable.g_lstAxisConfig[(int)EAxis.Y2].AutoSpeed, GlobalVariable.g_lstAxisConfig[(int)EAxis.Y2].Acc, GlobalVariable.g_lstAxisConfig[(int)EAxis.Y2].DeAcc, 5000))
                {
                    string dtm = DateTime.Now.ToString("dd_MM_yy_HH_mm_ss");
                    //double Xpos = Motion.GetActPos(GlobClass.Axis.X2);
                    //double Ypos = Motion.GetActPos(GlobClass.Axis.Y2);
                    //double A1 = Motion.GetActPos(GlobClass.Axis.R1);
                    string cmd = "T1,S,1,1,1," + pallet.PalletArr[row, col].cavityNo.ToString() + "," + dtm + "," + pallet.PalletArr[row, col].PositionX.ToString() + "," + pallet.PalletArr[row, col].PositionY.ToString() + "," + pallet.PalletArr[row, col].PositionR.ToString() + ",";// + Photo_pos_fly_trig_X[Assm_Cavity_Number - 1] + "," + Photo_pos_fly_trig_Y[Assm_Cavity_Number - 1] + ",0,0,0");//T1 cmnd to be edit
                    string cameraData = await camera.Trig_Camera(ObjectList.Vision3,cmd);
                    pallet.PalletArr[row, col].cameraData = cameraData;
                    pallet.PalletArr[row, col].OkNok = cameraData;
                    pallet.Datas.Add(pallet.PalletArr[row, col].OkNok, pallet.PalletArr[row, col]);
                }
            }
        }

        private bool HasPalletData()
        {
            return Variable.PalletQueue12.Count > 0 && Variable.PalletQueue12.Peek() != null;
        }

        private PalletData GetCurrentPallet()
        {
            return HasPalletData() ? Variable.PalletQueue12.Peek() : null;
        }

        private async Task Gotofeeder(int row, int col, int prvrow, int prvcol)
        {
            await Feeding.Feed(row, col, prvrow, prvcol, pallet.PalletArr);
        }

        public async Task GoForPast()
        {
            if (pallet == null) return;

            int rows = pallet.PalletArr.GetLength(0);
            int cols = pallet.PalletArr.GetLength(1);

            await GantrySystem.TraversArray(MoveAndPast, rows, cols);
        }

        private async Task MoveAndPast(int row, int col)
        {
            if (pallet == null) return;

            if (pallet.PalletArr[row, col].OkNok == "Nok" || pallet.PalletArr[row, col].pastingcmplt)
                return;

            if (nozzleno == 0)
            {
                nozzleno++;
                PreCol = col; PreRow = row;
            }
            if (nozzleno == 1)
            {
                await Gotofeeder(row, col, PreRow, PreCol);
                await Pasting.PastingStabilization(row, col, PreRow, PreCol, pallet.PalletArr);
                nozzleno = 0;
            }

        }
    }
}
