using Advantech;
using DynamicCylinders;
using GRT_BG1.Data;
using GRT_BG1.Function.Calibration;
using GRT_BG1.Function.Classes;
using GRT_BG1.Function.Interface;
using GRT_BG1.GlobalVar;
using Master;
using StreamlineProcess.BaseClass;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading;
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
        bool WorkingCon_Seq_completed = false;
        Position[,] pos = null;

        public WorkingConveyor1(Position[,] position)
        {
            pos = position;
        }




        public async Task Run(PalletData data)
        {
            var parallelbase = new Parallelbase();
            bool keepRunning = WorkingCon_Seq_completed==true;

            await parallelbase.RunAsyncLoop(
                async token => await WorkingCon_Seq(token, data), // Pass the CancellationToken
                () => keepRunning,
                delayMs: 50
            );

        }

        public async Task WorkingCon_Seq(CancellationToken token, PalletData data)
        {
            switch (step)
            {
                case 1:
                    if (HasPalletData())
                        pallet = GetCurrentPallet();
                    break;

                case 10:
                    // Start conveyor-2 for 5 seconds and lift stopper
                    StepperSystem.MovePlate(new bool?[] { false, false, true, true, false, false });
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
                    StepperSystem.MovePlate(new bool?[] { false, false, false, false, false, false });
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
                    StepperSystem.MovePlate(new bool?[] { false, false, true, true, true, true });
                    step = 30;
                    break;

                case 30:
                    // Stopper up and conveyor stops
                    Cylinder_config.Cylinders_List[(int)Cylinder_config.Cylinders.Work_Conv_2_Stopper_Cyl].Cylinder_Extend();
                    StepperSystem.MovePlate(new bool?[] { false, false, false, false, false, false });
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
            if (ObjectList.Servo_X1.Move_Abs(Convert.ToDouble(pos[row, col].PositionX), GlobalVariable.g_lstAxisConfig[(int)EAxis.Servo_X1].AutoSpeed, GlobalVariable.g_lstAxisConfig[(int)EAxis.Servo_X1].Acc, GlobalVariable.g_lstAxisConfig[(int)EAxis.Servo_X1].DeAcc, 5000))
            {
                if (ObjectList.Servo_Y1.Move_Abs(Convert.ToDouble(pos[row, col].PositionY), GlobalVariable.g_lstAxisConfig[(int)EAxis.Servo_Y1].AutoSpeed, GlobalVariable.g_lstAxisConfig[(int)EAxis.Servo_Y1].Acc, GlobalVariable.g_lstAxisConfig[(int)EAxis.Servo_Y1].DeAcc, 5000))
                {
                    string cameraData = await camera.Trig_Camera(ObjectList.CCD3, "xyz");
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
                Pasting pasting = new Pasting(pos);
                await Gotofeeder(row, col, PreRow, PreCol);
                await pasting.PastingSeq(row, col, PreRow, PreCol, pallet.PalletArr);
                nozzleno = 0;
            }

        }


    }
}
