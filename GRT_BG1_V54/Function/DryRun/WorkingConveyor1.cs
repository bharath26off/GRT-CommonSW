using Advantech;
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

namespace GRT_BG1.Function.DryRun
{
    public class WorkingConveyor1 : IWorkingConveyor
    {
        private static int step = 1;
        PalletData pallet;
        int okParts = 0;
        int nokParts = 0;
        public int nozzleno = 0;
        VisionSystem camera = new VisionSystem();

        int PreRow = 0; int PreCol = 0;

        public async Task WorkingCon_Seq()
        {
            switch (step)
            {
                case 1:
                    if (HasPalletData())
                        pallet = GetCurrentPallet();
                    break;

                case 10:
                    // Start conveyor-2 for 5 seconds and lift stopper
                    ConveyorSystem.MovePlate(new bool?[] { false, false, true, true, false, false });
                    Cylinder_config.Cylinders_List[(int)Cylinder_config.Cylinders.Work_Conv_2_Stopper_Cyl].Cylinder_Extend();
                    await Task.Delay(5000);
                    step = 11;
                    break;

                case 11:
                    // Stopper down and up
                    Cylinder_config.Cylinders_List[(int)Cylinder_config.Cylinders.Work_Conv_2_Stopper_Cyl].Cylinder_Retract();
                    await Task.Delay(1000);
                    Cylinder_config.Cylinders_List[(int)Cylinder_config.Cylinders.Work_Conv_2_Stopper_Cyl].Cylinder_Extend();
                    await Task.Delay(1000);
                    step = 12;
                    break;

                case 12:
                    // Stop conveyor
                    ConveyorSystem.MovePlate(new bool?[] { false, false, false, false, false, false });
                    step = 13;
                    break;

                case 13:
                    // Lift the pallet
                    Cylinder_config.Cylinders_List[(int)Cylinder_config.Cylinders.Work_Conv_2_pallet_Lift_Cyl].Cylinder_Extend();
                    step = 14;
                    break;

                case 14:
                    // Take CCD1 images
                    if (GlobalVariable.DI[(int)EInput.Work_Conv_1_Pallet_Lift_Cyl_Up])
                    {
                        await CameraScan();
                    }
                   
                    step = 15;
                    break;

                case 15:
                    // Move to feeder
                    await GoForPast();
                    break;

                case 27:
                    // Move gantry to home
                    await GantrySystem.wk1_home();
                    step = 28;
                    break;

                case 28:
                    // Lifter down
                    Cylinder_config.Cylinders_List[(int)Cylinder_config.Cylinders.Work_Conv_2_pallet_Lift_Cyl].Cylinder_Retract();
                    step = 29;
                    break;

                case 29:
                    // Stopper down and start conveyor
                    Cylinder_config.Cylinders_List[(int)Cylinder_config.Cylinders.Work_Conv_2_Stopper_Cyl].Cylinder_Retract();
                    ConveyorSystem.MovePlate(new bool?[] { false, false, true, true, true, true });
                    step = 30;
                    break;

                case 30:
                    // Stopper up and conveyor stops
                    Cylinder_config.Cylinders_List[(int)Cylinder_config.Cylinders.Work_Conv_2_Stopper_Cyl].Cylinder_Extend();
                    ConveyorSystem.MovePlate(new bool?[] { false, false, false, false, false, false });
                    step = 1; // Reset
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
            if (ObjectList.XAxis2.Move_Abs(Convert.ToDouble(pallet.PalletArr[row, col].PositionX), GlobalVariable.g_lstAxisConfig[(int)EAxis.X2].AutoSpeed, GlobalVariable.g_lstAxisConfig[(int)EAxis.X2].Acc, GlobalVariable.g_lstAxisConfig[(int)EAxis.X2].DeAcc, 5000))
            {
                if (ObjectList.YAxis2.Move_Abs(Convert.ToDouble(pallet.PalletArr[row, col].PositionY), GlobalVariable.g_lstAxisConfig[(int)EAxis.Y2].AutoSpeed, GlobalVariable.g_lstAxisConfig[(int)EAxis.Y2].Acc, GlobalVariable.g_lstAxisConfig[(int)EAxis.Y2].DeAcc, 5000))
                {
                    string cameraData = await camera.Trig_Camera(ObjectList.Vision3, "xyz");
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

            if (nozzleno == 0)
            {
                nozzleno++;
                PreCol = col; PreRow = row;
            }
            if (nozzleno == 1)
            {
                await Gotofeeder(row, col, PreRow, PreCol);
                await Pasting.PastingSeq(row, col, PreRow, PreCol, pallet.PalletArr);
                nozzleno = 0;
            }

        }

     
    }
}
