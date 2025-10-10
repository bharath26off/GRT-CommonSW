using Advantech;
using DynamicCylinders;
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
    public static class NozzleSystem
    {
        public static int Curr_Nozzle_Pick = 1;
        public static int Curr_Nozzle_Up = 1;
        public static void Pick(string nozzle)
        {
            //start vaccum
            if (nozzle == "Nozzle1")
            {
               // Vaccum_config.Vaccums_List[(int)Vaccum_config.Vaccums.Vaccum1].Vaccum_On();
            }
            else
            if (nozzle == "Nozzle2")
            {
               // Vaccum_config.Vaccums_List[(int)Vaccum_config.Vaccums.Vaccum2].Vaccum_On();
            }
        }
        public static void Place(string nozzle)
        {
            // stop vaccum
            if (nozzle == "Nozzle1")
            {
              //  Vaccum_config.Vaccums_List[(int)Vaccum_config.Vaccums.Vaccum1].Both_Vaccum_and_Blow_Off();
            }
            else
             if (nozzle == "Nozzle2")
            {
               // Vaccum_config.Vaccums_List[(int)Vaccum_config.Vaccums.Vaccum2].Both_Vaccum_and_Blow_Off();
            }
        }


        public static void NozzleHoming(string nozzle)
        {

        }




        public static void MoveUp(string nozzle)
        {
            if (Curr_Nozzle_Up == 1)
            {
                if (ObjectList.RAxis1.Move_Abs(Convert.ToDouble(Variable.wk1_FeederPos.R1), GlobalVariable.g_lstAxisConfig[(int)EAxis.Servo_R1].AutoSpeed, GlobalVariable.g_lstAxisConfig[(int)EAxis.Servo_R1].Acc, GlobalVariable.g_lstAxisConfig[(int)EAxis.Servo_R1].DeAcc, 5000))
                {
                    if (ObjectList.ZAxis2.Move_Abs(Convert.ToDouble(Variable.wk1_FeederPos.z), GlobalVariable.g_lstAxisConfig[(int)EAxis.Servo_Z2].AutoSpeed, GlobalVariable.g_lstAxisConfig[(int)EAxis.Servo_Z2].Acc, GlobalVariable.g_lstAxisConfig[(int)EAxis.Servo_Z2].DeAcc, 5000))
                    {

                        Curr_Nozzle_Up++;
                    }
                }

            }
            else
               if (Curr_Nozzle_Up == 2)
            {

                if (ObjectList.RAxis2.Move_Abs(Convert.ToDouble(Variable.wk1_FeederPos.R2), GlobalVariable.g_lstAxisConfig[(int)EAxis.Servo_R2].AutoSpeed, GlobalVariable.g_lstAxisConfig[(int)EAxis.Servo_R2].Acc, GlobalVariable.g_lstAxisConfig[(int)EAxis.Servo_R2].DeAcc, 5000))
                {
                    if (ObjectList.ZAxis2.Move_Abs(Convert.ToDouble(Variable.wk1_FeederPos.z), GlobalVariable.g_lstAxisConfig[(int)EAxis.Servo_Z2].AutoSpeed, GlobalVariable.g_lstAxisConfig[(int)EAxis.Servo_Z2].Acc, GlobalVariable.g_lstAxisConfig[(int)EAxis.Servo_Z2].DeAcc, 5000))
                    {

                        Curr_Nozzle_Up = 1;
                    }
                }

            }
        }
        public static void MoveDown(string nozzle)
        {
            if (Curr_Nozzle_Pick == 1)
            {
                if (ObjectList.RAxis1.Move_Abs(Convert.ToDouble(Variable.wk1_FeederPos.R1), GlobalVariable.g_lstAxisConfig[(int)EAxis.Servo_R1].AutoSpeed, GlobalVariable.g_lstAxisConfig[(int)EAxis.Servo_R1].Acc, GlobalVariable.g_lstAxisConfig[(int)EAxis.Servo_R1].DeAcc, 5000))
                {
                    if (ObjectList.ZAxis2.Move_Abs(Convert.ToDouble(Variable.wk1_FeederPos.z), GlobalVariable.g_lstAxisConfig[(int)EAxis.Servo_Z2].AutoSpeed, GlobalVariable.g_lstAxisConfig[(int)EAxis.Servo_Z2].Acc, GlobalVariable.g_lstAxisConfig[(int)EAxis.Servo_Z2].DeAcc, 5000))
                    {

                        Curr_Nozzle_Pick++;
                    }
                }

            }
            else
                if (Curr_Nozzle_Pick == 2)
            {

                if (ObjectList.RAxis2.Move_Abs(Convert.ToDouble(Variable.wk1_FeederPos.R2), GlobalVariable.g_lstAxisConfig[(int)EAxis.Servo_R2].AutoSpeed, GlobalVariable.g_lstAxisConfig[(int)EAxis.Servo_R2].Acc, GlobalVariable.g_lstAxisConfig[(int)EAxis.Servo_R2].DeAcc, 5000))
                {
                    if (ObjectList.ZAxis2.Move_Abs(Convert.ToDouble(Variable.wk1_FeederPos.z), GlobalVariable.g_lstAxisConfig[(int)EAxis.Servo_Z2].AutoSpeed, GlobalVariable.g_lstAxisConfig[(int)EAxis.Servo_Z2].Acc, GlobalVariable.g_lstAxisConfig[(int)EAxis.Servo_Z2].DeAcc, 5000))
                    {

                        Curr_Nozzle_Pick = 1;
                    }
                }

            }
        }
    }
}
