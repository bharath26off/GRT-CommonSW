using Advantech;
using DynamicCylinders;
using GRT_BG1.Function.Calibration;
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
    public class StaticDynamic
    {

        private int step = 0;

        public async Task CCD1_Inspection()
        {
            while (step < 17)
            {
                switch (step)
                {
                    case 0:
                        ShowMessageBox("Setup and place MLB manually.");
                        step = 6;
                        break;

                    case 6:
                        Cylinder_config.Cylinders_List[(int)Cylinder_config.Cylinders.Scan_Conv_Stopper_Cyl].Cylinder_Extend();
                        step = 7;
                        break;

                    case 7:
                        // Scanning conveyor start.
                        await ConveyorSystem.EntryWk1Cnv();
                        break;

                    case 8:
                        //Carrier sensed, stopper down.
                        Cylinder_config.Cylinders_List[(int)Cylinder_config.Cylinders.Scan_Conv_Stopper_Cyl].Cylinder_Retract();
                        step = 9;
                        break;

                    case 9:
                        //Working conveyor-1 starts.
                       
                        Cylinder_config.Cylinders_List[(int)Cylinder_config.Cylinders.Work_Conv_1_Stopper_Cyl].Cylinder_Extend();
                        ConveyorSystem.MovePlate(new bool?[] { true, true, true, true, false, false });
                        step = 10;
                        break;

                    case 10:
                        //Carrier sensor detected, conveyor stops.
                        await ConveyorSystem.DetectCarrierWk1Cnv();

                        step = 11;
                        break;

                    case 11:
                       // Lift carrier.
                        Cylinder_config.Cylinders_List[(int)Cylinder_config.Cylinders.Work_Conv_1_pallet_Lift_Cyl].Cylinder_Extend();
                        step = 12;
                        break;

                    case 12:
                        //Gantry moves near MLB
                        await GantrySystem.GantryMovement(5,6);
                        step = 13;
                        break;

                    case 13:
                        //Trigger CCD1 100 times
                        for (int i = 0; i < 100; i++)
                        {
                            VisionSystem.Trigger("CCD1");
                            await Task.Delay(10);
                        }
                        step = 14;
                        break;

                    case 14:
                        //Gantry to origin.
                        step = 15;
                        break;

                    case 15:
                        //Gantry back to origin and re-trigger
                        for (int i = 0; i < 100; i++)
                        {
                            await GantrySystem.GantryMovement(5,6);
                            VisionSystem.Trigger("CCD1");
                            await Task.Delay(10);
                            //move to origin
                        }
                        step = 16;
                        break;

                    case 16:
                        //CCD1 Inspection complete
                        step = 17;
                        return;
                }
            }
        }

        public async Task CCD2_Inspection()
        {
            step = 0;
            int count = 0;
            while (step <= 10)
            {
                switch (step)
                {
                    case 0:
                        // Operator places graphite.
                        ShowMessageBox(" Operator places graphite");
                        step=1;
                        break;

                    case 1:
                        // Gantry moves to feeder.
                        if (ObjectList.XAxis2.Move_Abs(Convert.ToDouble(Variable.wk1_FeederPos.x), GlobalVariable.g_lstAxisConfig[(int)EAxis.Servo_X2].AutoSpeed, GlobalVariable.g_lstAxisConfig[(int)EAxis.Servo_X2].Acc, GlobalVariable.g_lstAxisConfig[(int)EAxis.Servo_X2].DeAcc, 5000))
                        {
                            if (ObjectList.YAxis2.Move_Abs(Convert.ToDouble(Variable.wk1_FeederPos.y), GlobalVariable.g_lstAxisConfig[(int)EAxis.Servo_Y2].AutoSpeed, GlobalVariable.g_lstAxisConfig[(int)EAxis.Servo_Y2].Acc, GlobalVariable.g_lstAxisConfig[(int)EAxis.Servo_Y2].DeAcc, 5000))
                            {
                                step=2;
                            }
                        }
                        break;

                    case 2:
                       // Pick material with Nozzle-1.
                        NozzleSystem.MoveDown("Nozzle-1");
                        NozzleSystem.Pick("Nozzle-1 CCD2");
                        step=3;
                        break;

                    case 3:
                        // Move to CCD2 position.
                        if (ObjectList.XAxis2.Move_Abs(Convert.ToDouble(Variable.wk1_CCD2Pos.x), GlobalVariable.g_lstAxisConfig[(int)EAxis.Servo_X2].AutoSpeed, GlobalVariable.g_lstAxisConfig[(int)EAxis.Servo_X2].Acc, GlobalVariable.g_lstAxisConfig[(int)EAxis.Servo_X2].DeAcc, 5000))
                        {
                            if (ObjectList.YAxis2.Move_Abs(Convert.ToDouble(Variable.wk1_CCD2Pos.y), GlobalVariable.g_lstAxisConfig[(int)EAxis.Servo_Y2].AutoSpeed, GlobalVariable.g_lstAxisConfig[(int)EAxis.Servo_Y2].Acc, GlobalVariable.g_lstAxisConfig[(int)EAxis.Servo_Y2].DeAcc, 5000))
                            {
                                step = 4;
                            }
                        }
                        break;

                    case 4:
                        //CCD2 triggers 100 times.
                        for (int i = 0; i < 100; i++)
                        {
                            VisionSystem.Trigger("CCD2");
                            await Task.Delay(10);
                        }
                        step++;
                        break;

                    case 5:
                       // Return to origin.
                        step=6;
                        break;

                    case 6:
                        // Start dynamic trigger loop
                        if (ObjectList.XAxis2.Move_Abs(Convert.ToDouble(Variable.wk1_CCD2Pos.x), GlobalVariable.g_lstAxisConfig[(int)EAxis.Servo_X2].AutoSpeed, GlobalVariable.g_lstAxisConfig[(int)EAxis.Servo_X2].Acc, GlobalVariable.g_lstAxisConfig[(int)EAxis.Servo_X2].DeAcc, 5000))
                        {
                            if (ObjectList.YAxis2.Move_Abs(Convert.ToDouble(Variable.wk1_CCD2Pos.y), GlobalVariable.g_lstAxisConfig[(int)EAxis.Servo_Y2].AutoSpeed, GlobalVariable.g_lstAxisConfig[(int)EAxis.Servo_Y2].Acc, GlobalVariable.g_lstAxisConfig[(int)EAxis.Servo_Y2].DeAcc, 5000))
                            {
                                step = 7;
                            }
                        }
                      
                        break;

                    case 7:
                        // CCD2 trigger once from origin.
                        VisionSystem.Trigger("CCD2");
                        if (count == 100)
                            step = 8;
                        else
                            step = 5;
                        break;


                    case 8:
                       //Move to initial position.
                        step++;
                        break;

                    case 10:
                       //CCD2 Inspection Complete
                        step = 0;
                        return;
                }
            }
        }

        public async Task CCD3_Inspection()
        {
            step = 0;int count3= 0;
            while (step <= 15)
            {
                switch (step)
                {
                    case 0:
                       //Lift down carrier
                        Cylinder_config.Cylinders_List[(int)Cylinder_config.Cylinders.Work_Conv_1_pallet_Lift_Cyl].Cylinder_Retract();
                        step++;
                        break;

                    case 1:
                        //Stopper down, conveyor starts.
                        Cylinder_config.Cylinders_List[(int)Cylinder_config.Cylinders.Work_Conv_1_Stopper_Cyl].Cylinder_Retract();
                        Cylinder_config.Cylinders_List[(int)Cylinder_config.Cylinders.Work_Conv_2_Stopper_Cyl].Cylinder_Extend();
                        step++;
                        break;

                    case 3:
                       // Carrier moves to CCD3 inspection.
                        ConveyorSystem.MovePlate(new bool?[] { false, false, true, true, true, true });
                        step++;
                        break;

                    case 4:
                        // Presence sensor stops conveyor.
                        ConveyorSystem.MovePlate(new bool?[] { false, false, false, false, false, false });
                        step++;
                        break;
                    case 5:
                        //Stopper cylinder lifts up.
                        Cylinder_config.Cylinders_List[(int)Cylinder_config.Cylinders.Work_Conv_1_Stopper_Cyl].Cylinder_Extend();
                        step++;
                        break;

                    case 6:
                       // Lift up carrier.
                        Cylinder_config.Cylinders_List[(int)Cylinder_config.Cylinders.Work_Conv_2_pallet_Lift_Cyl].Cylinder_Extend();
                        step++;
                        break;

                    case 7:
                        // Move gantry in Y direction.
                        if (ObjectList.YAxis3.Move_Abs(Convert.ToDouble(Variable.PalletQueue23.Peek().PalletArr[5, 6].PositionY), GlobalVariable.g_lstAxisConfig[(int)EAxis.Servo_Y3].AutoSpeed, GlobalVariable.g_lstAxisConfig[(int)EAxis.Servo_Y3].Acc, GlobalVariable.g_lstAxisConfig[(int)EAxis.Servo_Y3].DeAcc, 5000))

                            step++;
                        break;

                    case 8:
                        // CCD3 trigger 100 times.
                        for (int i = 0; i < 100; i++)
                        {
                            VisionSystem.Trigger("CCD3");
                            await Task.Delay(10);
                        }
                        step++;
                        break;

                    case 9:
                        //Gantry moves to origin.
                        step++;
                        break;

                    case 10:
                        //Move to MLB and trigger.
                        GantrySystem.MoveToPositions(1, "CCD3");
                        VisionSystem.Trigger("CCD3");
                        step++;
                        break;

                    case 11:
                        if(count3<100)
                        {
                            step = 9;
                        }
                        else
                        {
                            step = 12;
                        }

                            break;

                    case 12:
                        //Dynamic repeat complete.
                        step++;
                        break;

                    case 13:
                       // Stopper down, conveyor starts.
                        Cylinder_config.Cylinders_List[(int)Cylinder_config.Cylinders.Work_Conv_2_Stopper_Cyl].Cylinder_Retract();
                        ConveyorSystem.MovePlate(new bool?[] { false, false, false, false, true, true });
                        step++;
                        break;

                    case 14:
                        // Move to unloading station.
                        step++;
                        break;

                    case 15:
                        //CCD3 Inspection completed
                        break;
                }
            }
        }
    }
}

