using IO_Stepper;
using Master;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DIO.DIDO;

namespace GRT_BG1.Function.Calibration
{
    public static class StepperSystem
    {
        private static bool[] motorInitialStates = new bool[6]; // Stores current states

        public static async Task<bool> EntryScanCnv()
        {

            if (GlobalVariable.DI[(int)EInput.Scan_Conv_Pallet_Inplace_Sen])
            {
                StepperSystem.MovePlate(new bool?[] { true, true });
                await Task.Delay(1000);
                return true;

            }

            return false;
        }

        public static async Task<bool> EntryWk1Cnv()
        {

            if (GlobalVariable.DI[(int)EInput.Work_Conv_1_Pallet_Entry_Sen])
            {
                StepperSystem.MovePlate(new bool?[] { null, null, true, null });
                await Task.Delay(1000);
                return true;

            }

            return false;
        }

        public static async Task<bool> EntryWk2Cnv()
        {

            if (GlobalVariable.g_MachineIoChaged == "Yes" ?  GlobalVariable.DI[(int)EInput_1.Work_Conv_2_Pallet_Entry_Sen] : GlobalVariable.DI[(int)EInput.Work_Conv_2_Pallet_Entry_Sen])
            {
                StepperSystem.MovePlate(new bool?[] { null, null, null, true });
                await Task.Delay(1000);
                return true;

            }

            return false;
        }


        public static async Task<bool> DetectCarrierScanCnv()
        {
            if (GlobalVariable.DI[(int)EInput.Scan_Conv_Pallet_Inplace_Sen])
            {
                StepperSystem.MovePlate(new bool?[] { false, false, null, null });
                await Task.Delay(10);
                return true;
            }
            else
            {
                await Task.Delay(100);
                if (!GlobalVariable.DI[(int)EInput.Scan_Conv_Pallet_Inplace_Sen])
                    GlobalVariable.AlarmTrigger(ECode.Button_Picking_Timeout_Error, true, 0);
                return false;

            }

        }
        public static async Task<bool> DetectCarrierWk1Cnv()
        {
            if (GlobalVariable.DI[(int)EInput.Work_Conv_1_Pallet_Inplace_Sen])
            {
                StepperSystem.MovePlate(new bool?[] { null, null, false, null });
                await Task.Delay(10);
                return true;
            }
            else
            {

                return false;
            }

        }
        public static async Task<bool> DetectCarrierWk2Cnv()
        {
            if (GlobalVariable.g_MachineIoChaged == "Yes" ?  GlobalVariable.DI[(int)EInput_1.Work_Conv_2_Pallet_Inplace_Sen] : GlobalVariable.DI[(int)EInput.Work_Conv_2_Pallet_Inplace_Sen])
            {
                StepperSystem.MovePlate(new bool?[] { null, null, null, false });
                await Task.Delay(10);
                return true;
            }
            else
            {

                return false;
            }

        }




        public static void MovePlate(bool?[] motorStates)
        {
            if (motorStates == null || motorStates.Length != 6)
            {
                throw new ArgumentException("motorStates must be an array of 6 nullable booleans.");
            }

            for (int i = 0; i < 6; i++)
            {
                if (motorStates[i].HasValue)
                {

                    switch (i)
                    {
                        case 0:
                            if (motorStates[i] == true)
                            {
                                if (GlobalVariable.ConveyorIO == "Yes")
                                {
                                    IO_Stepper_Config.ConvStepperMotorObj[IO_Stepper_Config.EConvStepper.LoadingConveyorA].Forward();

                                }
                                else
                                {
                                    ObjectList.Scanning_Conveyor_A.Jog(0, GlobalVariable.g_lstAxisConfig[(int)EAxis.Scanning_Conveyor_A].HomingSpeed, GlobalVariable.g_lstAxisConfig[(int)EAxis.Scanning_Conveyor_A].Acc, GlobalVariable.g_lstAxisConfig[(int)EAxis.Scanning_Conveyor_A].DeAcc);
                                }
                            }
                            else
                            {
                                if (GlobalVariable.ConveyorIO == "Yes")
                                {
                                    IO_Stepper_Config.ConvStepperMotorObj[IO_Stepper_Config.EConvStepper.LoadingConveyorA].Stop();

                                }
                                else
                                {
                                    ObjectList.Scanning_Conveyor_A.Stop();
                                }
                            }
                            break;
                        case 1:
                            if (motorStates[i] == true)
                            {
                                if (GlobalVariable.ConveyorIO == "Yes")
                                {
                                    IO_Stepper_Config.ConvStepperMotorObj[IO_Stepper_Config.EConvStepper.LoadingConveyorB].Forward();

                                }
                                else
                                {
                                    ObjectList.Scanning_Conveyor_B.Jog(0, GlobalVariable.g_lstAxisConfig[(int)EAxis.Scanning_Conveyor_B].HomingSpeed, GlobalVariable.g_lstAxisConfig[(int)EAxis.Scanning_Conveyor_B].Acc, GlobalVariable.g_lstAxisConfig[(int)EAxis.Scanning_Conveyor_B].DeAcc);
                                }
                            }
                            else
                            {
                                if (GlobalVariable.ConveyorIO == "Yes")
                                {
                                    IO_Stepper_Config.ConvStepperMotorObj[IO_Stepper_Config.EConvStepper.LoadingConveyorB].Stop();

                                }
                                else
                                {
                                    ObjectList.Scanning_Conveyor_B.Stop();
                                }
                            }


                            //ObjectList.Scanning_Conveyor_B.Jog(0, GlobalVariable.g_lstAxisConfig[(int)EAxis.Scanning_Conveyor_B].HomingSpeed, GlobalVariable.g_lstAxisConfig[(int)EAxis.Scanning_Conveyor_B].Acc, GlobalVariable.g_lstAxisConfig[(int)EAxis.Scanning_Conveyor_B].DeAcc);
                            //else
                            //    ObjectList.Scanning_Conveyor_B.Stop();

                            break;
                        case 2:
                            if (motorStates[i] == true)
                            {
                                if (GlobalVariable.ConveyorCount == 4)
                                {
                                    ObjectList.Working_Conveyor.Jog(0, GlobalVariable.g_lstAxisConfig[(int)EAxis.Working_Conveyor].HomingSpeed, GlobalVariable.g_lstAxisConfig[(int)EAxis.Working_Conveyor].Acc, GlobalVariable.g_lstAxisConfig[(int)EAxis.Working_Conveyor].DeAcc);
                                }
                                if (GlobalVariable.ConveyorCount == 6)
                                {
                                    if (GlobalVariable.ConveyorIO == "Yes")
                                    {
                                        IO_Stepper_Config.ConvStepperMotorObj[IO_Stepper_Config.EConvStepper.WorkingConveyor1A].Forward();
                                    }
                                    else
                                    {
                                        ObjectList.Working_Conveyor_A.Jog(0, GlobalVariable.g_lstAxisConfig[(int)EAxis.Working_Conveyor_A].HomingSpeed, GlobalVariable.g_lstAxisConfig[(int)EAxis.Working_Conveyor_A].Acc, GlobalVariable.g_lstAxisConfig[(int)EAxis.Working_Conveyor_A].DeAcc);
                                    }

                                }
                            }
                            else
                            {
                                if (GlobalVariable.ConveyorCount == 4)
                                {
                                    ObjectList.Working_Conveyor.Stop();
                                }
                                if (GlobalVariable.ConveyorCount == 6)
                                {
                                    if (GlobalVariable.ConveyorIO == "Yes")
                                    {
                                        IO_Stepper_Config.ConvStepperMotorObj[IO_Stepper_Config.EConvStepper.WorkingConveyor1A].Stop();
                                    }
                                    else
                                    {
                                        ObjectList.Working_Conveyor_A.Stop();
                                    }

                                }
                            }
                            break;

                        case 3:

                            if (motorStates[i] == true)
                            {
                                if (GlobalVariable.ConveyorCount == 4)
                                {
                                    ObjectList.Recheck_Conveyor.Jog(0, GlobalVariable.g_lstAxisConfig[(int)EAxis.Recheck_Conveyor].HomingSpeed, GlobalVariable.g_lstAxisConfig[(int)EAxis.Recheck_Conveyor].Acc, GlobalVariable.g_lstAxisConfig[(int)EAxis.Recheck_Conveyor].DeAcc);
                                }
                                if (GlobalVariable.ConveyorCount == 6)
                                {
                                    if (GlobalVariable.ConveyorIO == "Yes")
                                    {
                                        IO_Stepper_Config.ConvStepperMotorObj[IO_Stepper_Config.EConvStepper.WorkingConveyor1B].Forward();
                                    }
                                    else
                                    {
                                        ObjectList.Working_Conveyor_B.Jog(0, GlobalVariable.g_lstAxisConfig[(int)EAxis.Working_Conveyor_B].HomingSpeed, GlobalVariable.g_lstAxisConfig[(int)EAxis.Working_Conveyor_B].Acc, GlobalVariable.g_lstAxisConfig[(int)EAxis.Working_Conveyor_B].DeAcc);
                                    }

                                }
                            }
                            else
                            {
                                if (GlobalVariable.ConveyorCount == 4)
                                {
                                    ObjectList.Recheck_Conveyor.Stop();
                                }
                                if (GlobalVariable.ConveyorCount == 6)
                                {
                                    if (GlobalVariable.ConveyorIO == "Yes")
                                    {
                                        IO_Stepper_Config.ConvStepperMotorObj[IO_Stepper_Config.EConvStepper.WorkingConveyor1B].Stop();
                                    }
                                    else
                                    {
                                        ObjectList.Working_Conveyor_B.Stop();
                                    }

                                }
                            }


                            //if (motorStates[i] == true)
                            //    ObjectList.Working_Conveyor_B.Jog(0, GlobalVariable.g_lstAxisConfig[(int)EAxis.Working_Conveyor_B].HomingSpeed, GlobalVariable.g_lstAxisConfig[(int)EAxis.Working_Conveyor_B].Acc, GlobalVariable.g_lstAxisConfig[(int)EAxis.Working_Conveyor_B].DeAcc);
                            //else
                            //    ObjectList.Working_Conveyor_B.Stop();
                            break;
                        case 4:

                            if (motorStates[i] == true)
                            {
                                if (GlobalVariable.ConveyorIO == "Yes")
                                {
                                    IO_Stepper_Config.ConvStepperMotorObj[IO_Stepper_Config.EConvStepper.WorkingConveyor2A].Forward();

                                }
                                else
                                {
                                    ObjectList.Recheck_Conveyor_A.Jog(0, GlobalVariable.g_lstAxisConfig[(int)EAxis.Recheck_Conveyor_A].HomingSpeed, GlobalVariable.g_lstAxisConfig[(int)EAxis.Recheck_Conveyor_A].Acc, GlobalVariable.g_lstAxisConfig[(int)EAxis.Recheck_Conveyor_A].DeAcc);
                                }
                            }
                            else
                            {
                                if (GlobalVariable.ConveyorIO == "Yes")
                                {
                                    IO_Stepper_Config.ConvStepperMotorObj[IO_Stepper_Config.EConvStepper.WorkingConveyor2A].Stop();

                                }
                                else
                                {
                                    ObjectList.Recheck_Conveyor_A.Stop();
                                }
                            }

                            //if (motorStates[i] == true)
                            //    ObjectList.Recheck_Conveyor_A.Jog(0, GlobalVariable.g_lstAxisConfig[(int)EAxis.Recheck_Conveyor_A].HomingSpeed, GlobalVariable.g_lstAxisConfig[(int)EAxis.Recheck_Conveyor_A].Acc, GlobalVariable.g_lstAxisConfig[(int)EAxis.Recheck_Conveyor_A].DeAcc);
                            //else
                            //    ObjectList.Recheck_Conveyor_A.Stop();
                            break;
                        case 5:
                            if (motorStates[i] == true)
                            {
                                if (GlobalVariable.ConveyorIO == "Yes")
                                {
                                    IO_Stepper_Config.ConvStepperMotorObj[IO_Stepper_Config.EConvStepper.WorkingConveyor2B].Forward();

                                }
                                else
                                {
                                    ObjectList.Recheck_Conveyor_B.Jog(0, GlobalVariable.g_lstAxisConfig[(int)EAxis.Recheck_Conveyor_B].HomingSpeed, GlobalVariable.g_lstAxisConfig[(int)EAxis.Recheck_Conveyor_B].Acc, GlobalVariable.g_lstAxisConfig[(int)EAxis.Recheck_Conveyor_B].DeAcc);
                                }
                            }
                            else
                            {
                                if (GlobalVariable.ConveyorIO == "Yes")
                                {
                                    IO_Stepper_Config.ConvStepperMotorObj[IO_Stepper_Config.EConvStepper.WorkingConveyor2B].Stop();

                                }
                                else
                                {
                                    ObjectList.Recheck_Conveyor_B.Stop();
                                }
                            }
                            //if (motorStates[i] == true)
                            //    ObjectList.Recheck_Conveyor_B.Jog(0, GlobalVariable.g_lstAxisConfig[(int)EAxis.Recheck_Conveyor_B].HomingSpeed, GlobalVariable.g_lstAxisConfig[(int)EAxis.Recheck_Conveyor_B].Acc, GlobalVariable.g_lstAxisConfig[(int)EAxis.Recheck_Conveyor_B].DeAcc);
                            //else
                            //    ObjectList.Recheck_Conveyor_B.Stop();
                            break;
                        default:
                            throw new InvalidOperationException("Invalid motor index.");
                    }


                }
            }
        }

        public static bool CheckHome(int axisindex)
        {
            if (axisindex == 12)
                return ObjectList.Stepper_1.CheckHome();
            else
           if (axisindex == 13)
                return ObjectList.Stepper_2.CheckHome();

            return false;
        }

        public static void Stepper_1GoinitialPos()
        {

            ObjectList.Stepper_1.Move_Abs(Convert.ToDouble(GlobalVariable.scan_Carrier_Barcode.PositionX), Convert.ToDouble(GlobalVariable.scan_Carrier_Barcode.XVel), Convert.ToDouble(GlobalVariable.scan_Carrier_Barcode.XAcc), Convert.ToDouble(GlobalVariable.scan_Carrier_Barcode.XDeAcc), 5000);

        }
        public static void Stepper_2GoinitialPos()
        {
            ObjectList.Stepper_2.Move_Abs(Convert.ToDouble(GlobalVariable.scan_Carrier_Barcode.PositionY), Convert.ToDouble(GlobalVariable.scan_Carrier_Barcode.YVel), Convert.ToDouble(GlobalVariable.scan_Carrier_Barcode.YAcc), Convert.ToDouble(GlobalVariable.scan_Carrier_Barcode.YDeAcc), 5000);

        }


    }
}
