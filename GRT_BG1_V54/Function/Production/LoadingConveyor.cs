using DynamicCylinders;
using ExceptionLib;
using GRT_BG1.Data;
using GRT_BG1.GlobalVar;
using Master;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DIO.DIDO;
using GRT_BG1.Function;
using GRT_BG1.Function.Classes;
using Advantech;
using GRT_BG1.Function.Calibration;
using MasterProject.GlobalClass;

namespace GRT_BG1.Function
{
    public class LoadingConveyor : IlodingConveyor
    {


       // SFC_PDCA.SFC sfc = new SFC_PDCA.SFC();
        ScannerSystem scnr = new ScannerSystem();
        PalletData PalletData;
        public int i_step = 0;
        int x = 3;
        int y = 4;


        public async Task LoadingConveyor_Seq()
        {
            switch (i_step)
            {
                case 0:
                    PalletData = new PalletData();// create pallet object
                    PalletData.PalletArr = new PartData[x, y];//pallet will contain each MLB object in 2D array
                    Variable.PalletQueue12.Enqueue(PalletData);// Enqeue the pallet
                    i_step = 10;

                    break;
                case 10:
                    // check ready signal to previous machineRun
                    await Logger.WriteLogasTask(Logger.LogType.Running, "Conveyor1", "Conveyor1", "Sending 'Ready to receive carrier' signal to previous machine.", "");
                    if (GlobalVariable.DI[(int)EInput.Previous_M_C_Ready_To_Send_Pallet])
                    {
                        i_step = 20;
                    }
                    else
                    {
                        await Task.Delay(100);
                        if (!GlobalVariable.DI[(int)EInput.Previous_M_C_Ready_To_Send_Pallet] )//&& !GlobalVariable.DI[(int)EInput.GBP_Rdy_to_Receive_Pallet])
                            GlobalVariable.AlarmTrigger(ECode.Belt1Conveyor_Timeout_Error, true, 0);

                    }
                    break;

                case 20:
                    // lift stopper
                    await Logger.WriteLogasTask(Logger.LogType.Running, "Conveyor1", "Conveyor1", "Waiting for carrier from previous machine and lifting stopper cylinders", "");
                    Cylinder_config.Cylinders_List[(int)Cylinder_config.Cylinders.Scan_Conv_Stopper_Cyl].Cylinder_Extend();
                       i_step = 30;
                    break;

                case 30:
                    //  Start conveyor-1 
                    await Logger.WriteLogasTask(Logger.LogType.Running, "Conveyor1", "Conveyor1", "Carrier detected. Starting conveyor .", "");
                    if ((GlobalVariable.DI[(int)EInput.Scan_Conv_Stopper_Cyl_Up]))
                   { if (await ConveyorSystem.EntryScanCnv())

                            i_step = 40;
                   }
                    else
                    {
                        await Task.Delay(100);
                        if (!(GlobalVariable.DI[(int)EInput.Scan_Conv_Stopper_Cyl_Up]))
                            GlobalVariable.AlarmTrigger(ECode.Belt1Conveyor_Timeout_Error, true, 0);

                    }
                     break;

                case 40:
                    //  Wait for pallet detection and stop conveyor
                    await Logger.WriteLogasTask(Logger.LogType.Running, "Conveyor1", "Conveyor1", "Carrier presence detected. Stopping conveyor.", "");
                    if (await ConveyorSystem.DetectCarrierScanCnv())
                    {
                        i_step = 50;
                    }
                    break;
                case 50:
                    //load all MLB postion from excel
                    await LoadPosition();
                    i_step = 60;
                    break;
                case 60:
                    //scan each MLB
                    await ScanBarcode();
                    i_step = 70;
                    break;
                case 70:
                    // Move gantry to home
                    await Logger.WriteLogasTask(Logger.LogType.Running, "Conveyor1", "Conveyor1", "Moving gantry back to home position.", "");
                    await GantrySystem.scanCnv_home();
                    await Task.Delay(1000);
                    i_step = 80;
                    break;

                case 80:
                    // Lower stopper and move carrier to Conveyor-2
                    if (!GlobalVariable.DI[(int)EInput.Work_Conv_1_Pallet_Inplace_Sen])
                    {
                        await Logger.WriteLogasTask(Logger.LogType.Running, "Conveyor1", "Conveyor1", "Lowering stopper and moving carrier to Conveyor-2.", "");
                        Cylinder_config.Cylinders_List[(int)Cylinder_config.Cylinders.Scan_Conv_Stopper_Cyl].Cylinder_Retract();
                    }

                    i_step = 90;
                    break;
                case 90:
                    if (GlobalVariable.DI[(int)EInput.Scan_Conv_Stopper_Cyl_Dn])
                    {
                        if (GlobalVariable.DI[(int)EInput.Work_Conv_1_Stopper_Cyl_Up])
                        {
                          
                            ConveyorSystem.MovePlate(new bool?[] {true,true });
                           await ConveyorSystem.EntryWk1Cnv();

                        }
                        else
                        {

                        }
                    }
                    i_step = 100;
                    break;

                case 100:
                    // Wait for carrier exit, then raise stopper
                    await Logger.WriteLogasTask(Logger.LogType.Running, "Conveyor1", "Conveyor1", "Carrier exited. Raising stopper for next carrier.", "");
                    if (await ConveyorSystem.DetectCarrierWk1Cnv())
                    {
                        
                        ConveyorSystem.MovePlate(new bool?[] { false, false });
                        Cylinder_config.Cylinders_List[(int)Cylinder_config.Cylinders.Scan_Conv_Stopper_Cyl].Cylinder_Extend();
                        i_step = 110;
                    }
                    
                    break;

                default:
                    i_step = 1;
                    break;

            }


        }


        public async Task ScanBarcode()
        {
            await GantrySystem.TraversArray(GantryMovement, PalletData.PalletArr.GetLength(0), PalletData.PalletArr.GetLength(1));

        }

        //Move Gantry to each MLB and scan the barcode
        public async Task GantryMovement(int row, int col)
        {


            if (ObjectList.XAxis1.Move_Abs(Convert.ToDouble(PalletData.PalletArr[row, col].PositionX), GlobalVariable.g_lstAxisConfig[(int)EAxis.X1].AutoSpeed, GlobalVariable.g_lstAxisConfig[(int)EAxis.X1].Acc, GlobalVariable.g_lstAxisConfig[(int)EAxis.X1].DeAcc, 5000))
            {
                if (ObjectList.YAxis1.Move_Abs(Convert.ToDouble(PalletData.PalletArr[row, col].PositionY), GlobalVariable.g_lstAxisConfig[(int)EAxis.Y1].AutoSpeed, GlobalVariable.g_lstAxisConfig[(int)EAxis.Y1].Acc, GlobalVariable.g_lstAxisConfig[(int)EAxis.Y1].DeAcc, 5000))
                {
                    string CameraData = await scnr.Trig_Scanner();
                    PalletData.PalletArr[row, col].ScannerData = CameraData;

                    // Fire-and-forget SFC process
                    _ = Task.Run(async () =>
                    {
                       // var result = await sfc.SFC_Varification(CameraData);
                       // PalletData.PalletArr[row, col].OkNok = result;

                    });


                }

            }

        }






        //Load all MLB position From excel
        public async Task LoadPosition()
        {
            await GantrySystem.TraversArray(CreatePart, PalletData.PalletArr.GetLength(0), PalletData.PalletArr.GetLength(1));
        }

        //create each MLB data object
        private async Task CreatePart(int row, int col)
        {
            PalletData.PalletArr[row, col] = new PartData
            {
                //PositionX = GlobalVariable.pos[row, col].x, //read position x
                // PositionY = GlobalVariable.pos[row, col].y////read position y
            };

        }


    }
}
