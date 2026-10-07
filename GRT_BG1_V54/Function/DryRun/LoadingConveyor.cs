
using Advantech;
using DynamicCylinders;
using ExceptionLib;
using GRT_BG1.Data;
using GRT_BG1.Function;
using GRT_BG1.Function.Calibration;
using GRT_BG1.Function.Classes;
using GRT_BG1.GlobalVar;
using Master;
using StreamlineProcess.BaseClass;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static DIO.DIDO;

namespace GRT_BG1.Function.DryRun
{
    public class LoadingConveyor : IlodingConveyor
    {


        // SFC_PDCA.SFC sfc = new SFC_PDCA.SFC();
        ScannerSystem scnr = new ScannerSystem();
        PalletData PalletData;
        public int i_step = 5;
       
        bool ScanCon_Seq_completed = true;
        Position[,] pos = null;

        public LoadingConveyor(Position[,] position)
        {
            pos = position;
        }




        public async Task Run(PalletData data)
        {
            var parallelbase = new Parallelbase();
            ScanCon_Seq_completed = true;
           // bool keepRunning = ScanCon_Seq_completed == true;

            await parallelbase.RunAsyncLoop(
                async token => await LoadingConveyor_Seq(token, data), // Pass the CancellationToken
                () => check(),
                delayMs: 50
            );

        }

        public bool check()
        {
            return ScanCon_Seq_completed == true;
        }


        public async Task LoadingConveyor_Seq(CancellationToken token, PalletData data)
        {
            switch (i_step)
            {
            //    case 0:
            //        await Logger.WriteLogasTask(Logger.LogType.Running, "Conveyor1", "Conveyor1", "i_step 1: stopper lifts up.", "");
            //        Cylinder_config.Cylinders_List[(int)Cylinder_config.Cylinders.Scan_Conv_Stopper_Cyl].Cylinder_Extend();
            //        await LoadPosition();
            //        i_step = 1;
            //        break;
            //    case 1:
            //        if (GlobalVariable.DI[(int)EInput.Scan_Conv_Stopper_Cyl_Up])
            //        {
            //            await Logger.WriteLogasTask(Logger.LogType.Running, "Conveyor1", "Conveyor1", "i_step 1: Conveyor-1 starts for 5s and stopper lifts up.", "");
            //            await ConveyorSystem.EntryScanCnv();
            //        }
            //        i_step = 2;
            //        break;

            //    case 2:
            //        await Logger.WriteLogasTask(Logger.LogType.Running, "Conveyor1", "Conveyor1", "i_step 2: Stopper down and up again.", "");
            //        Cylinder_config.Cylinders_List[(int)Cylinder_config.Cylinders.Scan_Conv_Stopper_Cyl].Cylinder_Retract();
            //        await Task.Delay(1000); // Adjust time as needed
            //        Cylinder_config.Cylinders_List[(int)Cylinder_config.Cylinders.Scan_Conv_Stopper_Cyl].Cylinder_Extend();
            //        await Task.Delay(1000); // Time for extend
            //        i_step = 3;
            //        break;

            //    case 3:
            //        await Logger.WriteLogasTask(Logger.LogType.Running, "Conveyor1", "Conveyor1", "i_step 3: Conveyor-1 stops rotating.", "");
            //        await ConveyorSystem.DetectCarrierScanCnv();
            //        i_step = 4;
            //        break;

            //    case 4:
            //        await Logger.WriteLogasTask(Logger.LogType.Running, "Conveyor1", "Conveyor1", "i_step 4:Load position Moving gantry to scanning position.", "");
            //        // Move to first scanning position — simulate or call GantryMoveToStart() scan_home
            //        await GantrySystem.scanCnv_home();

            //        break;

                case 5:
                    await Logger.WriteLogasTask(Logger.LogType.Running, "Conveyor1", "Conveyor1", "i_step 5: Scanning 12 MLBs.", "");
                    await ScanBarcode(); // Traverses array and scans
                    ScanCon_Seq_completed = false;
                    i_step = 6;
                    break;

                //case 6:
                //    await Logger.WriteLogasTask(Logger.LogType.Running, "Conveyor1", "Conveyor1", "i_step 6: Moving gantry to home position.", "");
                //    await GantrySystem.scanCnv_home();
                //    break;

                //case 7:
                //    await Logger.WriteLogasTask(Logger.LogType.Running, "Conveyor1", "Conveyor1", "i_step 7: Conveyor-1 starts again.", "");
                //    ConveyorSystem.MovePlate(new bool?[] { true, true });
                //    await ConveyorSystem.EntryWk1Cnv();
                //    i_step = 8;
                //    break;

                //case 8:
                //    await Logger.WriteLogasTask(Logger.LogType.Running, "Conveyor1", "Conveyor1", "i_step 8: Stopper down and up again.", "");
                //    Cylinder_config.Cylinders_List[(int)Cylinder_config.Cylinders.Work_Conv_1_Stopper_Cyl].Cylinder_Retract();
                //    await Task.Delay(1000);
                //    Cylinder_config.Cylinders_List[(int)Cylinder_config.Cylinders.Work_Conv_1_Stopper_Cyl].Cylinder_Extend();
                //    await Task.Delay(1000);
                //    i_step = 9;
                //    break;

                //case 9:
                //    await Logger.WriteLogasTask(Logger.LogType.Running, "Conveyor1", "Conveyor1", "i_step 9: Conveyor-1 stops rotating.", "");
                //    ConveyorSystem.MovePlate(new bool?[] { false, false });
                //    i_step = 100; // Done
                //    break;

                default:
                    i_step = 1;
                    break;
            }
        }



        public async Task ScanBarcode()
        {
            if (pos == null) return;

            
            int rows = pos.GetLength(0);
            int cols = pos.GetLength(1);

            //for (int i = 0; i < rows; i++)
            //{
            //    for (int j = 0; j < cols; j++)
            //    {
            //        double positionx = pos[i, j].PositionX;
            //        double positiony = pos[i, j].PositionY;
            //    }
            //}

            await GantrySystem.TraversArray(GantryMovement, rows, cols);
            

        }

        //Move Gantry to each MLB and scan the barcode
        public async Task GantryMovement(int row, int col)
        {


            if (ObjectList.Stepper_1.Move_Abs(Convert.ToDouble(pos[row, col].PositionX), Convert.ToDouble(pos[row, col].XVel), Convert.ToDouble(pos[row, col].XAcc), Convert.ToDouble(pos[row, col].XDeAcc), 5000))
            {
                if (ObjectList.Stepper_2.Move_Abs(Convert.ToDouble(pos[row, col].PositionY), Convert.ToDouble(pos[row, col].YVel), Convert.ToDouble(pos[row, col].YAcc), Convert.ToDouble(pos[row, col].YDeAcc), 5000))
                {
                    //string sacnerData = await scnr.Trig_Scanner();
                    //PalletData.PalletArr[row, col].ScannerData = sacnerData;

                    //// Fire-and-forget SFC process
                    //_ = Task.Run(async () =>
                    //{
                    //    //var result = await sfc.SFC_Varification(sacnerData);
                    //    //PalletData.PalletArr[row, col].OkNok = result;

                    //});


                }

            }

        }




        ////Load all MLB position From excel
        //public async Task LoadPosition()
        //{
        //    await GantrySystem.TraversArray(CreatePart, PalletData.PalletArr.GetLength(0), PalletData.PalletArr.GetLength(1));
        //}

        ////create each MLB data object
        //private async Task CreatePart(int row, int col)
        //{
        //    PalletData.PalletArr[row, col] = new PartData
        //    {
        //        //PositionX = GlobalVariable.pos[row, col].x, //read position x
        //        // PositionY = GlobalVariable.pos[row, col].y////read position y
        //        cavityNo = 1
        //    };

        //}


    }
}
