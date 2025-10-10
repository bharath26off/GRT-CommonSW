using Master;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DIO.DIDO;

namespace GRT_BG1.Function.Calibration
{
    public static class ConveyorSystem
    {
        private static bool[] motorInitialStates = new bool[6]; // Stores current states

        public static async Task<bool> EntryScanCnv()
        {

            if (GlobalVariable.DI[(int)EInput.Scan_Conv_Pallet_Inplace_Sen])
            {
                ConveyorSystem.MovePlate(new bool?[] { true, true});
                await Task.Delay(1000);
                return true;

            }

            return false;
        }

        public static async Task<bool> EntryWk1Cnv()
        {

            if (GlobalVariable.DI[(int)EInput.Work_Conv_1_Pallet_Entry_Sen])
            {
                ConveyorSystem.MovePlate(new bool?[] { null,null, true, true, null, null });
                await Task.Delay(1000);
                return true;

            }

            return false;
        }

        public static async Task<bool> EntryWk2Cnv()
        {

            if (GlobalVariable.DI[(int)EInput.Work_Conv_2_Pallet_Entry_Sen])
            {
                ConveyorSystem.MovePlate(new bool?[] { null, null, null, null, true, true });
                await Task.Delay(1000);
                return true;

            }

            return false;
        }


        public static async Task<bool> DetectCarrierScanCnv()
        {
            if (GlobalVariable.DI[(int)EInput.Scan_Conv_Pallet_Inplace_Sen])
            {
                ConveyorSystem.MovePlate(new bool?[] { false, false, null, null, null, null });
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
                ConveyorSystem.MovePlate(new bool?[] { null, null, false,false, null, null });
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
            if (GlobalVariable.DI[(int)EInput.Work_Conv_2_Pallet_Inplace_Sen])
            {
                ConveyorSystem.MovePlate(new bool?[] { null, null, null, null, false, false });
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
                    bool newState = motorStates[i].Value;
                    motorInitialStates[i] = newState;

                    EOutput output;
                    switch (i)
                    {
                        case 0:
                            output = EOutput.Work_Conv_2_Mtr_A_Fwd_Dir;
                            break;
                        case 1:
                            output = EOutput.Work_Conv_2_Mtr_B_Fwd_Dir;
                            break;
                        case 2:
                            output = EOutput.Work_Conv_1_Mtr_A_Fwd_Dir;
                            break;
                        case 3:
                            output = EOutput.Work_Conv_2_Mtr_A_Fwd_Dir;
                            break;
                        case 4:
                            output = EOutput.Scan_Conv_Mtr_A_Fwd_Dir;
                            break;
                        case 5:
                            output = EOutput.Scan_Conv_Mtr_B_Fwd_Dir;
                            break;
                        default:
                            throw new InvalidOperationException("Invalid motor index.");
                    }

                    GlobalVariable.DIDO.WriteOPS(newState, (int)output);
                }
            }
        }




    }
}
