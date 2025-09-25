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
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DIO.DIDO;

namespace GRT_BG1.Function.DryRun
{
    public class WorkingConveyor3 : IWorkingConveyor2
    {
        public int i_step = 31;
        VisionSystem camera = new VisionSystem();

        public async Task WorkingCon2_Seq()
        {
            switch (i_step)
            {
                case 31:
                    // Start Conveyor-3 & lift stopper for 5 sec
                    ConveyorSystem.MovePlate(new bool?[] { false,false, false, false, true, true });
                    Cylinder_config.Cylinders_List[(int)Cylinder_config.Cylinders.Work_Conv_2_Stopper_Cyl].Cylinder_Extend();
                    await Task.Delay(5000);
                    i_step = 32;
                    break;

                case 32:
                    // Stopper down and up again
                    Cylinder_config.Cylinders_List[(int)Cylinder_config.Cylinders.Work_Conv_2_Stopper_Cyl].Cylinder_Retract();
                    await Task.Delay(1000);
                    Cylinder_config.Cylinders_List[(int)Cylinder_config.Cylinders.Work_Conv_2_Stopper_Cyl].Cylinder_Extend();
                    await Task.Delay(1000);
                    i_step = 33;
                    break;

                case 33:
                    // Stop conveyor
                    ConveyorSystem.MovePlate(new bool?[] { false, false, false, false, false, false });
                    i_step = 34;
                    break;

                case 34:
                    // Lift the carrier
                    Cylinder_config.Cylinders_List[(int)Cylinder_config.Cylinders.Work_Conv_2_pallet_Lift_Cyl].Cylinder_Extend();
                    i_step = 35;
                    break;

                case 35:
                    // CCD3 gantry moves to MLB-1 to MLB-12
                    if (GlobalVariable.DI[(int)EInput.Work_Conv_2_Pallet_Lift_Cyl_Up])
                    {
                        await CollectCCD3data(); // Traverse MLB 1–12 with camera
                        i_step = 37;
                    }
                    break;

                case 37:
                    // Lower the carrier
                    Cylinder_config.Cylinders_List[(int)Cylinder_config.Cylinders.Work_Conv_2_pallet_Lift_Cyl].Cylinder_Retract();
                    i_step = 38;
                    break;

                case 38:
                    // Stopper down & conveyor rotate
                    Cylinder_config.Cylinders_List[(int)Cylinder_config.Cylinders.Work_Conv_2_Stopper_Cyl].Cylinder_Retract();
                    ConveyorSystem.MovePlate(new bool?[] { false, false, false, false, true, true});
                    i_step = 39;
                    break;

                case 39:
                    // Stopper up & stop conveyor
                    Cylinder_config.Cylinders_List[(int)Cylinder_config.Cylinders.Work_Conv_2_Stopper_Cyl].Cylinder_Extend();
                    ConveyorSystem.MovePlate(new bool?[] { false, false, false, false, false, false });
                    i_step = 40;
                    break;

                case 40:
                        // machine stopped
                        i_step = 0;
                    
                    break;
            }
        }

        public async Task GantryMovement(int row, int col)
        {
            // MoveX(PalletArr[row, col].PositionX);
            // MoveY(PalletArr[row, col].PositionY);
            if (ObjectList.XAxis3.Move_Abs(Convert.ToDouble(Variable.PalletQueue23.Peek().PalletArr[row, col].PositionX), GlobalVariable.g_lstAxisConfig[(int)EAxis.X3].AutoSpeed, GlobalVariable.g_lstAxisConfig[(int)EAxis.X3].Acc, GlobalVariable.g_lstAxisConfig[(int)EAxis.X3].DeAcc, 5000))
            {
                if (ObjectList.YAxis3.Move_Abs(Convert.ToDouble(Variable.PalletQueue23.Peek().PalletArr[row, col].PositionY), GlobalVariable.g_lstAxisConfig[(int)EAxis.Y3].AutoSpeed, GlobalVariable.g_lstAxisConfig[(int)EAxis.Y3].Acc, GlobalVariable.g_lstAxisConfig[(int)EAxis.Y3].DeAcc, 5000))
                {
                    //string cameraData = await camera.Trig_Camera();
                    Variable.PalletQueue23.Peek().PalletArr[row, col].SNno = "xyz";//from scanner
                                                                                   //perform qualification
                    Variable.PalletQueue23.Peek().PalletArr[row, col].Qualify = true;


                }
            }
        }

        public async Task CollectCCD3data()
        {
            await GantrySystem.TraversArray(GantryMovement, Variable.PalletQueue23.Peek().PalletArr.GetLength(0), Variable.PalletQueue23.Peek().PalletArr.GetLength(1));
        }
    }

}

