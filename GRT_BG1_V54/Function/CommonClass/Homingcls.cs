using Advantech;
using DynamicCylinders;
using ExceptionLib;
using GRT_BG1.Data;
using GRT_BG1.Function.Calibration;
using Master;
using StreamlineProcess.BaseClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static DIO.DIDO;

namespace GRT_BG1.Function.DryRun
{

    public class HomingCls
    {
        int homingStep = 10;
        bool palletPresent = false;
        string StationName = "Servo Homing Station";

        public int start = 90;

        public async Task Run()
        {
            var parallelbase = new Parallelbase();
           

            await parallelbase.RunAsyncLoop(
                async token => await ServoHomingModeSeq(token), // Pass the CancellationToken
                () => check(),
                delayMs: 50 
            );

        }

        public bool check()
        {
            return start > homingStep;
        }

        public async Task ServoHomingModeSeq(CancellationToken token )
        {
            try
            {
                
                    switch (homingStep)
                    {
                        case 10:
                            await Logger.WriteLogasTask(Logger.LogType.Running, "Homing", StationName, "Operator selected Servo Homing mode", "");
                            homingStep = 20;
                            break;

                        case 20:
                            await Logger.WriteLogasTask(Logger.LogType.Running, "Homing", StationName, "Moving Z1, Z2 to negative limit sensor", "");

                            //if (ServoList.ZAxis2.MotionIOBit.LMT_N)
                            {
                                // Move Z1, Z2 in negative direction
                                NozzleSystem.NozzleHoming("Nozzle1");
                                NozzleSystem.NozzleHoming("Nozzle2");
                                //await Task.Delay(1000);
                            }
                            //  else
                            {
                                homingStep = 30;
                            }
                            break;

                        case 30:
                            //await Logger.WriteLogasTask(Logger.LogType.Running, "Homing", StationName, "Moving X1~R2 servos to home", "");
                            //GlobalVariable.DIDO.WriteOPS(true, (int)EOutput.Servo_HomeStart);
                            //await Task.Delay(2000);

                            //if (GlobalVariable.DI[(int)EInput.Servo_HomeSensor_All])
                            //{
                            await GantrySystem.wk1_home();
                            await GantrySystem.scanCnv_home();
                            await GantrySystem.wk2_home();

                             homingStep = 40;
                            //}
                            break;

                        case 40:
                            await Logger.WriteLogasTask(Logger.LogType.Running, "Homing", StationName, "Lowering all stopper and lift cylinders", "");
                            Cylinder_config.Cylinders_List[(int)Cylinder_config.Cylinders.Scan_Conv_Stopper_Cyl].Cylinder_Retract();
                            Cylinder_config.Cylinders_List[(int)Cylinder_config.Cylinders.Work_Conv_1_Stopper_Cyl].Cylinder_Retract();
                            Cylinder_config.Cylinders_List[(int)Cylinder_config.Cylinders.Work_Conv_1_pallet_Lift_Cyl].Cylinder_Retract();
                            Cylinder_config.Cylinders_List[(int)Cylinder_config.Cylinders.Work_Conv_2_pallet_Lift_Cyl].Cylinder_Retract();
                            Cylinder_config.Cylinders_List[(int)Cylinder_config.Cylinders.Work_Conv_2_Stopper_Cyl].Cylinder_Retract();
                            await Task.Delay(1000);
                            homingStep = 50;
                            break;

                        case 50:
                            if (GlobalVariable.DI[(int)EInput.Scan_Conv_Stopper_Cyl_Dn] &&
                                GlobalVariable.DI[(int)EInput.Work_Conv_1_Pallet_Lift_Cyl_Dn] &&
                                GlobalVariable.DI[(int)EInput.Work_Conv_1_Stopper_Cyl_Dn] &&
                                GlobalVariable.DI[(int)EInput.Work_Conv_2_Pallet_Lift_Cyl_Dn] &&
                                GlobalVariable.DI[(int)EInput.Work_Conv_2_Stopper_Cyl_Dn])
                            {
                                palletPresent = GlobalVariable.DI[(int)EInput.Scan_Conv_Pallet_Inplace_Sen] 
                                                ||
                                                GlobalVariable.DI[(int)EInput.Work_Conv_2_Pallet_Inplace_Sen] ||
                                                GlobalVariable.DI[(int)EInput.Work_Conv_1_Pallet_Inplace_Sen] ||
                                                GlobalVariable.DI[(int)EInput.Scan_Conv_Pallet_Exit_Sen] ||
                                                GlobalVariable.DI[(int)EInput.Work_Conv_1_Pallet_Entry_Sen] ||
                                                GlobalVariable.DI[(int)EInput.Work_Conv_1_Pallet_Exit_Sen] ||
                                                GlobalVariable.DI[(int)EInput.Work_Conv_2_Pallet_Entry_Sen] ||
                                                GlobalVariable.DI[(int)EInput.Work_Conv_2_Pallet_Exit_Sen];

                                await Logger.WriteLogasTask(Logger.LogType.Running, "Homing", StationName, $"Pallet presence: {palletPresent}", "");
                                homingStep = 60;
                            }
                            break;

                        case 60:
                            if (palletPresent)
                            {
                                await Logger.WriteLogasTask(Logger.LogType.Running, "Homing", StationName, "Pallet detected – starting conveyors", "");
                                StepperSystem.MovePlate(new bool?[] { true, true, true, true, true, true });
                            }
                            else
                            {
                                await Logger.WriteLogasTask(Logger.LogType.Running, "Homing", StationName, "No pallet – conveyors stopped", "");
                                StepperSystem.MovePlate(new bool?[] { false, false, false, false, false, false });
                            }
                            homingStep = 70;
                            break;

                        case 70:
                            await Logger.WriteLogasTask(Logger.LogType.Running, "Homing", StationName, "Lifting all stoppers", "");
                            StepperSystem.MovePlate(new bool?[] { false, false, false, false, false, false });
                            Cylinder_config.Cylinders_List[(int)Cylinder_config.Cylinders.Scan_Conv_Stopper_Cyl].Cylinder_Extend();
                            Cylinder_config.Cylinders_List[(int)Cylinder_config.Cylinders.Work_Conv_1_Stopper_Cyl].Cylinder_Extend();
                            Cylinder_config.Cylinders_List[(int)Cylinder_config.Cylinders.Work_Conv_2_Stopper_Cyl].Cylinder_Extend();
                            await Task.Delay(1000);
                            homingStep = 80;
                            break;

                        case 80:
                            await Logger.WriteLogasTask(Logger.LogType.Running, "Homing", StationName, "Moving Z1,Z2 axis to home", "");
                            //GlobalVariable.DIDO.WriteOPS(true, (int)EOutput.Z1Z2_Gantry_MoveHome);
                            //await Task.Delay(1000);

                            //if (GlobalVariable.DI[(int)EInput.Z1_HomeSensor] && GlobalVariable.DI[(int)EInput.Z2_HomeSensor])
                            //{
                            //    GlobalVariable.DIDO.WriteOPS(false, (int)EOutput.Z1Z2_Gantry_MoveHome);
                            //    homingStep = 90;
                            //}

                            // await GantrySystem.NozzleHoming("Nozzle1");
                            homingStep = 100;
                            break;
                           

                        case 90:
                            await Logger.WriteLogasTask(Logger.LogType.Running, "Homing", StationName, "Homing sequence completed", "");
                           // homingStep = 100; // Reset
                            break;

                        default:
                            homingStep = 10;
                            break;
                    }
                }
            
            catch (Exception e)
            {
                await Logger.WriteLogasTask(Logger.LogType.Error, "Homing", "Servo Homing Station", e.Message, e.ToString());
            }
        }
    

    }

}
