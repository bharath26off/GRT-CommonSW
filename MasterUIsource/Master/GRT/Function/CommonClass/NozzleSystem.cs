using Advantech;
using DIO;
using DynamicCylinders;
using GRT_BG1.Data;
using Master;
using Program;
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
        public static bool runing = false;
        


        public static void Nozzle1Homing()
        {
            ResetNozzle();
            ObjectList.Servo_Z1.ResetAxis();

            if (ObjectList.Servo_Z1.Set_Home_Vel(GlobalVariable.g_lstAxisConfig[(int)DIDO.EAxis.Servo_Z1].HomingSpeed, GlobalVariable.g_lstAxisConfig[(int)DIDO.EAxis.Servo_Z1].Acc, GlobalVariable.g_lstAxisConfig[(int)DIDO.EAxis.Servo_Z1].DeAcc))
            {
                ObjectList.Servo_Z1.Homing(1);

            }

        }
        public static void Nozzle2Homing()
        {
            ResetNozzle();
            ObjectList.Servo_Z2.ResetAxis();

            if (ObjectList.Servo_Z2.Set_Home_Vel(GlobalVariable.g_lstAxisConfig[(int)DIDO.EAxis.Servo_Z2].HomingSpeed, GlobalVariable.g_lstAxisConfig[(int)DIDO.EAxis.Servo_Z2].Acc, GlobalVariable.g_lstAxisConfig[(int)DIDO.EAxis.Servo_Z2].DeAcc))
            {
                ObjectList.Servo_Z2.Homing(1);

            }

        }




        public static void ResetNozzle()
        {
            ObjectList.Servo_Z1.ResetAxis();
            ObjectList.Servo_Z2.ResetAxis();
           // ObjectList.Servo_Z1.ResetAxisError_All_Axis();
            ObjectList.Servo_Z1.StopJog();


        }

        public static void Nozzle1Gonegative(int axisindex)
        {
            ObjectList.Servo_Z1.ResetAxis();
            if (ObjectList.Servo_Z1.Jog(1, Convert.ToDouble(GlobalVariable.g_lstAxisConfig[axisindex].HomingSpeed), GlobalVariable.g_lstAxisConfig[axisindex].Acc, GlobalVariable.g_lstAxisConfig[axisindex].DeAcc))
            {
                Task.Delay(500);

            }

        }

        public static void Nozzle12Gonegative(int axisindex)
        {

            ObjectList.Servo_Z2.ResetAxis();
            if (ObjectList.Servo_Z2.Jog(1, Convert.ToDouble(GlobalVariable.g_lstAxisConfig[axisindex].HomingSpeed), GlobalVariable.g_lstAxisConfig[axisindex].Acc, GlobalVariable.g_lstAxisConfig[axisindex].DeAcc))
            {
                Task.Delay(500);

            }



        }

        public static void Gonpositive(int axisindex, string nozzle)
        {
            ResetNozzle();
            if (nozzle == "Nozzle1")
                ObjectList.Servo_Z1.Jog(0, Convert.ToDouble(10), GlobalVariable.g_lstAxisConfig[axisindex].Acc, GlobalVariable.g_lstAxisConfig[axisindex].DeAcc);
            else
             if (nozzle == "Nozzle2")
                ObjectList.Servo_Z2.Jog(0, Convert.ToDouble(10), GlobalVariable.g_lstAxisConfig[axisindex].Acc, GlobalVariable.g_lstAxisConfig[axisindex].DeAcc);
        }
        public static bool CheckHome(int axisindex, string nozzle)
        {
            if (nozzle == "Nozzle1")
                return ObjectList.Servo_Z1.CheckHome();
            else
            if (nozzle == "Nozzle2")
                return ObjectList.Servo_Z2.CheckHome();
            return false;
        }
        public static bool CheckNegative(string nozzle)
        {

            bool[] ioStatusArray = ObjectList.Servo_Z1.ToGetMotionIOStatus();
            bool[] ioStatusArray2 = ObjectList.Servo_Z2.ToGetMotionIOStatus();
            if (nozzle == "Nozzle1")
            {
                if (ioStatusArray[(int)Advantech_PCIE.MotionIOBit.LMT_N])
                {
                    ObjectList.Servo_Z1.StopJog();
                    return true;
                }
            }
            else
            {
                if (ioStatusArray2[(int)Advantech_PCIE.MotionIOBit.LMT_N])
                {
                    ObjectList.Servo_Z2.StopJog();
                    return true;
                }
            }
            return false;
        }


        public static bool Nozzle1MoveDown(Position p1,double? position=null)
        {
            double currectpos;
            double currectvel;
            string currentstatus;
            if (position == null)
            {
                ObjectList.Servo_Z1.Move_Abs(Convert.ToDouble(p1.PositionZ1), Convert.ToDouble(p1.ZVel), Convert.ToDouble(p1.ZAcc), Convert.ToDouble(p1.ZDeAcc), 5000);
                ObjectList.Servo_Z1.GetCurrentPos(out currectpos, out currentstatus, out currectvel);
                if (currectpos >= p1.PositionZ1-0.002 || currectpos <= p1.PositionZ1 +0.002)
                    return true;
            }
            else
            {
                ObjectList.Servo_Z1.Move_Abs(Convert.ToDouble(position), Convert.ToDouble(p1.ZVel), Convert.ToDouble(p1.ZAcc), Convert.ToDouble(p1.ZDeAcc), 5000);
                ObjectList.Servo_Z1.GetCurrentPos(out currectpos, out currentstatus, out currectvel);
                if (currectpos == position)
                    return true;

            }
                return false;

        }
        public static bool nozzleZ1Z2Safe()
        {
            double currectpospickZ1;
            double currectvelpickZ1;
            string currentstatupickZ1;
            ObjectList.Servo_Z1.GetCurrentPos(out currectpospickZ1, out currentstatupickZ1, out currectvelpickZ1);
            if (GlobalVariable.SafePosition.PositionZ1 == currectpospickZ1)
            {
                ObjectList.Servo_Z2.GetCurrentPos(out currectpospickZ1, out currentstatupickZ1, out currectvelpickZ1);
                if (GlobalVariable.SafePosition.PositionZ2 == currectpospickZ1)
                {
                    
                    return true;
                }
            }
            Nozzle1Moveup(GlobalVariable.SafePosition);
            Nozzle2Moveup(GlobalVariable.SafePosition);
            return false;
         }

        public static bool Nozzle2MoveDown(Position p2, double? position = null)
        {
            if (position == null)
            {
                double currectpos;
                double currectvel;
                string currentstatus;
                ObjectList.Servo_Z2.Move_Abs(Convert.ToDouble(p2.PositionZ2), Convert.ToDouble(p2.ZVel), Convert.ToDouble(p2.ZAcc), Convert.ToDouble(p2.ZDeAcc), 5000);
                ObjectList.Servo_Z2.GetCurrentPos(out currectpos, out currentstatus, out currectvel);
                if (currectpos >= p2.PositionZ1 - 0.002 || currectpos <= p2.PositionZ1 + 0.002)
                    return true;
            }
            else
            {
                double currectpos;
                double currectvel;
                string currentstatus;

                ObjectList.Servo_Z2.Move_Abs(Convert.ToDouble(position), Convert.ToDouble(p2.ZVel), Convert.ToDouble(p2.ZAcc), Convert.ToDouble(p2.ZDeAcc), 5000);
                ObjectList.Servo_Z2.GetCurrentPos(out currectpos, out currentstatus, out currectvel);
                if (currectpos == position)
                    return true;

            }
                return false;
        }
        public static bool Nozzle1Moveup(Position p1)
        {
            double currectpospickZ1;
            double currectvelpickZ1;
            string currentstatupickZ1;
            //  ObjectList.Servo_Z1.Move_Abs(Convert.ToDouble(GlobalVariable.TrainNozzle1.PositionZ1), Convert.ToDouble(p1.ZVel), Convert.ToDouble(p1.ZAcc), Convert.ToDouble(p1.ZDeAcc), 5000);
            ObjectList.Servo_Z1.Move_Abs(Convert.ToDouble(GlobalVariable.SafePosition.PositionZ1), Convert.ToDouble(p1.ZVel), Convert.ToDouble(p1.ZAcc), Convert.ToDouble(p1.ZDeAcc), 5000);
            ObjectList.Servo_Z1.GetCurrentPos(out currectpospickZ1, out currentstatupickZ1, out currectvelpickZ1);
            //if (GlobalVariable.WK1_initial.PositionZ1 > currectpospickZ1 - 0.02 && GlobalVariable.WK1_initial.PositionZ1 < currectpospickZ1 + 0.02)
            // AK
            Task.Delay(300);
            if (GlobalVariable.SafePosition.PositionZ1 > currectpospickZ1 - 0.10 && GlobalVariable.SafePosition.PositionZ1 < currectpospickZ1 + 0.10)
            {
                return true;
            }
            return false; 
        }
        public static bool Nozzle2Moveup(Position p2)
        {
            double currectpospickZ2;
            double currectvelpickZ2;
            string currentstatupickZ2;

            // ObjectList.Servo_Z2.Move_Abs(Convert.ToDouble(GlobalVariable.TrainNozzle2.PositionZ2), Convert.ToDouble(p2.ZVel), Convert.ToDouble(p2.ZAcc), Convert.ToDouble(p2.ZDeAcc), 5000);
            ObjectList.Servo_Z2.Move_Abs(Convert.ToDouble(GlobalVariable.SafePosition.PositionZ2), Convert.ToDouble(p2.ZVel), Convert.ToDouble(p2.ZAcc), Convert.ToDouble(p2.ZDeAcc), 5000);
            ObjectList.Servo_Z2.GetCurrentPos(out currectpospickZ2, out currentstatupickZ2, out currectvelpickZ2);
            // AK
            Task.Delay(300);
            if (GlobalVariable.SafePosition.PositionZ2 > currectpospickZ2 - 0.10 && GlobalVariable.SafePosition.PositionZ2 < currectpospickZ2 + 0.10)
            {
                return true;
            }
            return false; ;
        }

        public static bool Nozzle1safe(Position p1) // AK
        {
            double currectpospickZ1;
            double currectvelpickZ1;
            string currentstatupickZ1;
            //Arul
            //ObjectList.Servo_Z1.Move_Abs(Convert.ToDouble(GlobalVariable.Wk1_Z1FedPos.PositionZ1),Convert.ToDouble(p1.ZVel), Convert.ToDouble(p1.ZAcc), Convert.ToDouble(p1.ZDeAcc), 5000);

            ObjectList.Servo_Z1.Move_Abs(Convert.ToDouble(GlobalVariable.WK1_initial.PositionZ1), Convert.ToDouble(p1.ZVel), Convert.ToDouble(p1.ZAcc), Convert.ToDouble(p1.ZDeAcc), 5000);


            ObjectList.Servo_Z1.GetCurrentPos(out currectpospickZ1, out currentstatupickZ1, out currectvelpickZ1);
            if (GlobalVariable.WK1_initial.PositionZ1 > currectpospickZ1 - 0.5 && GlobalVariable.WK1_initial.PositionZ1 < currectpospickZ1 + 0.5)
            {
                return true;
            }
            return false;
        }
        public static bool Nozzle2safe(Position p2) // AK
        {
            double currectpospickZ2;
            double currectvelpickZ2;
            string currentstatupickZ2;
            //Arul
            ObjectList.Servo_Z2.Move_Abs(Convert.ToDouble(GlobalVariable.WK1_initial.PositionZ2), Convert.ToDouble(p2.ZVel), Convert.ToDouble(p2.ZAcc), Convert.ToDouble(p2.ZDeAcc), 5000);

            ObjectList.Servo_Z2.GetCurrentPos(out currectpospickZ2, out currentstatupickZ2, out currectvelpickZ2);
            if (GlobalVariable.WK1_initial.PositionZ1 > currectpospickZ2 - 0.5 && GlobalVariable.WK1_initial.PositionZ1 < currectpospickZ2 + 0.5)
            {
                return true;
            }
            return false;
        }
    }
}
