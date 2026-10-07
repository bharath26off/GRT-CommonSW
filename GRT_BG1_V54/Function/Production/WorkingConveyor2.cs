//using Advantech;
//using DynamicCylinders;
//using GRT_BG1.Data;
//using GRT_BG1.Function.Calibration;
//using GRT_BG1.Function.Interface;
//using GRT_BG1.GlobalVar;
//using Master;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using static DIO.DIDO;

//namespace GRT_BG1.Function
//{
//    public class WorkingConveyor2 : IWorkingConveyor2
//    {
//        public int i_step = 1;
//        VisionSystem camera = new VisionSystem();

//        public async Task WorkingCon2_Seq()
//        {

//            switch (i_step)
//            {

//                case 0:
//                    // Carrier lifting cylinder lifts the carrier
//                    Cylinder_config.Cylinders_List[(int)Cylinder_config.Cylinders.Work_Conv_2_pallet_Lift_Cyl].Cylinder_Extend();
//                    i_step = 10;
//                    break;

//                case 10:
//                    if (GlobalVariable.DI[(int)EInput.Work_Conv_2_Pallet_Lift_Cyl_Up])
//                    {
//                        // Gantry system moves to MLB-1 to MLB-12 positions and triggers camera
//                        await CollectCCD3data();
//                        i_step = 20;
//                    }
//                    break;


//                case 20:
//                    // Carrier lifter lowers the carrier
//                    Cylinder_config.Cylinders_List[(int)Cylinder_config.Cylinders.Work_Conv_2_pallet_Lift_Cyl].Cylinder_Retract();
//                    i_step = 30;
//                    break;

//                case 30:
//                    // Pallet ready signal sent to next machine

//                    if (GlobalVariable.DI[(int)EInput.Work_Conv_2_Pallet_Lift_Cyl_Dn])
//                        GlobalVariable.DIDO.WriteOPS(true, (int)EOutput.GRT_Ready_To_Send_Pallet);
//                    i_step = 40;
//                    break;

//                case 40:
//                    // Wait for feedback from next machine, then lower stopper
//                     if (GlobalVariable.DI[(int)EInput.GBP_Ready_To_Receive_Pallet])
//                    {
//                        Cylinder_config.Cylinders_List[(int)Cylinder_config.Cylinders.Work_Conv_2_Stopper_Cyl].Cylinder_Retract();
//                        i_step = 50;
//                    }
                   
//                    break;

//                case 50:
//                    // Carrier moves out to next machine
//                    if (GlobalVariable.DI[(int)EInput.Work_Conv_2_Stopper_Cyl_Dn])
//                    {
//                        ConveyorSystem.MovePlate(new bool?[] { null, null, null, null, true, true });
//                        await Task.Delay(1000);
//                        Cylinder_config.Cylinders_List[(int)Cylinder_config.Cylinders.Work_Conv_2_Stopper_Cyl].Cylinder_Extend();
//                        i_step = 60; // Or reset to 1 if process repeats
//                    }
//                    break;
//                case 60:
//                    //dequeue data from PalletQueue23 queue
//                   Variable.PalletQueue23.Dequeue();
                   
//                    break;

//            }
//        }


//        public async Task GantryMovement(int row, int col)
//        {
//            if (ObjectList.XAxis1.Move_Abs(Convert.ToDouble(Variable.PalletQueue23.Peek().PalletArr[row, col].PositionX), GlobalVariable.g_lstAxisConfig[(int)EAxis.Servo_X2].AutoSpeed, GlobalVariable.g_lstAxisConfig[(int)EAxis.Servo_X2].Acc, GlobalVariable.g_lstAxisConfig[(int)EAxis.Servo_X2].DeAcc, 5000))
//            {
//                if (ObjectList.YAxis1.Move_Abs(Convert.ToDouble(Variable.PalletQueue23.Peek().PalletArr[row, col].PositionY), GlobalVariable.g_lstAxisConfig[(int)EAxis.Servo_Y2].AutoSpeed, GlobalVariable.g_lstAxisConfig[(int)EAxis.Servo_Y2].Acc, GlobalVariable.g_lstAxisConfig[(int)EAxis.Servo_Y2].DeAcc, 5000))
//                {
//                    string cmd = ""; //("T2C,S,1,1," + Final_cavt_num.ToString() + "," + dtm + ",1"
//                    string cameraData = await camera.Trig_Camera(ObjectList.CCD4, cmd);
//                    Variable.PalletQueue23.Peek().PalletArr[row, col].SNno = "xyz";//from scanner
//                                                                                   //perform qualification
//                    Variable.PalletQueue23.Peek().PalletArr[row, col].Qualify = true;
//                }
//            }
//        }

//        public async Task CollectCCD3data()
//        {
//            await GantrySystem.TraversArray(GantryMovement, Variable.PalletQueue23.Peek().PalletArr.GetLength(0), Variable.PalletQueue23.Peek().PalletArr.GetLength(1));
//        }
//    }
//}
