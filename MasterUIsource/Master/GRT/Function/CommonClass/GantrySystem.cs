using ExceptionLib;
using Advantech;
using DIO;
using GRT_BG1.Data;
using GRT_BG1.Function.DryRun;
using Master;
using Program;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static DIO.DIDO;
using GRT_BG1_V54.Function.CommonClass;

namespace GRT_BG1.Function.Calibration
{
    public static class GantrySystem
    {
        private static ManualResetEventSlim _pauseEvent = new ManualResetEventSlim(true);

        private static readonly CancellationTokenSource _cts = new CancellationTokenSource();
        public static bool IsPaused => !_pauseEvent.IsSet;

        public static bool IsCancelled => _cts.IsCancellationRequested;

        public static void Pause() => _pauseEvent.Reset();

        public static void Resume() => _pauseEvent.Set();

        public static void Cancel() => _cts.Cancel();

        public static void WaitIfPausedOrCancelled(CancellationToken token)

        {
            //Arulkumar Fixed random stoppage start
            try
            {
                _pauseEvent.Wait();
            }
            catch (ObjectDisposedException)
            {
                _pauseEvent = new ManualResetEventSlim(true);
            }
            //Arulkumar Fixed random stoppage end
            token.ThrowIfCancellationRequested();
        }
        public static async Task TraverseArray(Func<int, int, Task> action, int rows, int cols, CancellationToken token, (int row, int col)? resumePosition = null)
        {

            int row = resumePosition?.row ?? 0;

            int col = resumePosition?.col ?? 0;

            while (row < rows)

            {

                WaitIfPausedOrCancelled(token);

                int direction = row % 2; //0 = left right, 1

                switch (direction)

                {

                    case 0: // left → right

                        if (col < cols)

                        {

                            await action(row, col);

                            WaitIfPausedOrCancelled(token);

                            col++;
                        }
                        else

                        {

                            row++;
                            if (row < rows) col = (row % 2 == 0) ? 0 : cols - 1;

                        }

                        break;

                    case 1: // right → left

                        if (col >= 0)

                        {
                            await action(row, col);

                            WaitIfPausedOrCancelled(token);

                            col--;
                        }
                        else

                        {

                            row++;

                            if (row < rows)

                                col = (row % 2 == 0) ? 0 : cols - 1;



                        }
                        break;
                }
            }
        }


        public static async Task<bool> move(Position p, double? x = null, double? y = null)
        {
            double Z1 = GlobalVariable.SafePosition.PositionZ1;
            double Z2 = GlobalVariable.SafePosition.PositionZ2;


            if (NozzleSystem.Nozzle2Moveup(GlobalVariable.SafePosition))
            {
                if (ObjectList.Servo_Z2.CheckDoneAxis_Agaibn(Z2 * ObjectList.Servo_Z2.Global_pulse, true) == 0)
                {
                    
                        if (NozzleSystem.Nozzle1Moveup(GlobalVariable.SafePosition))
                        {
                            if (ObjectList.Servo_Z1.CheckDoneAxis_Agaibn(Z1 * ObjectList.Servo_Z1.Global_pulse, true) == 0)
                            {
                                await Task.Delay(20);
                                if (ObjectList.Servo_Z2.GetSingleMotionIOBit(Advantech_PCIE.MotionIOBit.ORG))
                                {

                                    if (ObjectList.Servo_Z1.GetSingleMotionIOBit(Advantech_PCIE.MotionIOBit.ORG))
                                    {
                                        if (x == null && y == null)
                                        {
                                            Task T3 = Task.Run(async () => ObjectList.Servo_X1.Move_Abs(Convert.ToDouble(p.PositionX), Convert.ToDouble(p.XVel), Convert.ToDouble(p.XAcc), Convert.ToDouble(p.XDeAcc), 2000));

                                            Task T4 = Task.Run(async () => ObjectList.Servo_Y1.Move_Abs(Convert.ToDouble(p.PositionY), Convert.ToDouble(p.YVel), Convert.ToDouble(p.YAcc), Convert.ToDouble(p.YDeAcc), 2000));
                                            await Task.WhenAll(T3, T4);
                                            double currectpospick;
                                            double currectvelpick;
                                            string currentstatupick;
                                            ObjectList.Servo_X1.GetCurrentPos(out currectpospick, out currentstatupick, out currectvelpick);
                                            if (p.PositionX == currectpospick)
                                            {
                                                ObjectList.Servo_Y1.GetCurrentPos(out currectpospick, out currentstatupick, out currectvelpick);
                                                if (p.PositionY == currectpospick)
                                                {
                                                    return true;
                                                }
                                            }
                                            return false;
                                        }
                                        else
                                        {
                                            Task T3 = Task.Run(async () => ObjectList.Servo_X1.Move_Abs((double)x, Convert.ToDouble(p.XVel), Convert.ToDouble(p.XAcc), Convert.ToDouble(p.XDeAcc), 15000));

                                            Task T4 = Task.Run(async () => ObjectList.Servo_Y1.Move_Abs((double)y, Convert.ToDouble(p.YVel), Convert.ToDouble(p.YAcc), Convert.ToDouble(p.YDeAcc), 10000));
                                            await Task.WhenAll(T3, T4);
                                            double currectpospick;
                                            double currectvelpick;
                                            string currentstatupick;
                                            ObjectList.Servo_X1.GetCurrentPos(out currectpospick, out currentstatupick, out currectvelpick);
                                            if (Math.Round(x ?? 0.0, 3, MidpointRounding.AwayFromZero) == currectpospick)
                                            {
                                                ObjectList.Servo_Y1.GetCurrentPos(out currectpospick, out currentstatupick, out currectvelpick);
                                                if (Math.Round(y ?? 0.0, 3, MidpointRounding.AwayFromZero) >= currectpospick - 0.02 || Math.Round((double)y, 2) <= currectpospick + 0.02)
                                                {
                                                    return true;
                                                }
                                            }
                                            return false;

                                        }
                                    }
                                    else
                                    {
                                        await GlobalVariable.AlarmTriggerAsync(ECode.Servo_Z1_Not_Safe_Org, true, 1);

                                        GlobalVariable.current_MCStatus = GlobalVariable.MachineStatus.Stop;
                                        try
                                        {
                                            ConveyorSystem.Stop();

                                        }
                                        catch (Exception)
                                        {

                                            //throw;
                                        }
                                        GlobalVariable.b_gHomingDone = false;
                                        GlobalVariable.bhomeseq_running = false;
                                        GlobalVariable.pause = false; // AK
                                        GlobalVariable.b_gPause = false;

                                        GlobalVariable.New_Pallet_Only = false;

                                    }

                                }
                                else
                                {
                                    await GlobalVariable.AlarmTriggerAsync(ECode.Servo_Z2_Not_Safe_Org, true, 1);
                                    GlobalVariable.current_MCStatus = GlobalVariable.MachineStatus.Stop;
                                    try
                                    {
                                        ConveyorSystem.Stop();

                                    }
                                    catch (Exception)
                                    {

                                        //throw;
                                    }
                                    GlobalVariable.b_gHomingDone = false;
                                    GlobalVariable.bhomeseq_running = false;
                                    GlobalVariable.pause = false; // AK
                                    GlobalVariable.b_gPause = false;

                                    GlobalVariable.New_Pallet_Only = false;
                                }
                            }
                            else
                            {
                                await Task.Run(() => ObjectList.Servo_Z1.Move_Abs(Convert.ToDouble(GlobalVariable.SafePosition.PositionZ1), Convert.ToDouble(GlobalVariable.SafePosition.ZVel), Convert.ToDouble(GlobalVariable.SafePosition.ZAcc), Convert.ToDouble(GlobalVariable.SafePosition.ZDeAcc), 15000));

                            }
                            await Task.Delay(10);
                            
                        }
                }
                else
                {
                    await Task.Run(() => ObjectList.Servo_Z2.Move_Abs(Convert.ToDouble(GlobalVariable.SafePosition.PositionZ2), Convert.ToDouble(GlobalVariable.SafePosition.ZVel), Convert.ToDouble(GlobalVariable.SafePosition.ZAcc), Convert.ToDouble(GlobalVariable.SafePosition.ZDeAcc), 15000));
                }

            }

            return false;


        }

        public static async Task<bool> Premove(Position p, double? x = null, double? y = null)
        {

            double Z1 = GlobalVariable.SafePosition.PositionZ1;
            double Z2 = GlobalVariable.SafePosition.PositionZ2;


            if (NozzleSystem.Nozzle2Moveup(GlobalVariable.SafePosition))
            {
                if (ObjectList.Servo_Z2.CheckDoneAxis_Agaibn(Z2 * ObjectList.Servo_Z2.Global_pulse, true) == 0)
                {

                    if (NozzleSystem.Nozzle1Moveup(GlobalVariable.SafePosition))
                    {
                        if (ObjectList.Servo_Z1.CheckDoneAxis_Agaibn(Z1 * ObjectList.Servo_Z1.Global_pulse, true) == 0)
                        {
                            await Task.Delay(50);

                            if (ObjectList.Servo_Z2.GetSingleMotionIOBit(Advantech_PCIE.MotionIOBit.ORG))
                            {
                                if (ObjectList.Servo_Z1.GetSingleMotionIOBit(Advantech_PCIE.MotionIOBit.ORG))
                                {

                                    if (x == null && y == null)
                                    {
                                        Task T3 = Task.Run(async () => ObjectList.Servo_X1.Move_Abs(Convert.ToDouble(p.PositionX), Convert.ToDouble(p.PreXVel), Convert.ToDouble(p.PreXAcc), Convert.ToDouble(p.PreXDeAcc), 2000));

                                        Task T4 = Task.Run(async () => ObjectList.Servo_Y1.Move_Abs(Convert.ToDouble(p.PositionY), Convert.ToDouble(p.PreYVel), Convert.ToDouble(p.PreYAcc), Convert.ToDouble(p.PreYDeAcc), 2000));
                                        await Task.WhenAll(T3, T4);
                                        double currectpospick;
                                        double currectvelpick;
                                        string currentstatupick;
                                        ObjectList.Servo_X1.GetCurrentPos(out currectpospick, out currentstatupick, out currectvelpick);
                                        if (p.PositionX == currectpospick)
                                        {
                                            ObjectList.Servo_Y1.GetCurrentPos(out currectpospick, out currentstatupick, out currectvelpick);
                                            if (p.PositionY == currectpospick)
                                            {
                                                return true;
                                            }
                                        }
                                        return false;



                                    }
                                    else
                                    {
                                        Task T3 = Task.Run(async () => ObjectList.Servo_X1.Move_Abs((double)x, Convert.ToDouble(p.PreXVel), Convert.ToDouble(p.PreXAcc), Convert.ToDouble(p.PreXDeAcc), 15000));

                                        Task T4 = Task.Run(async () => ObjectList.Servo_Y1.Move_Abs((double)y, Convert.ToDouble(p.PreYVel), Convert.ToDouble(p.PreYAcc), Convert.ToDouble(p.PreYDeAcc), 10000));
                                        await Task.WhenAll(T3, T4);
                                        double currectpospick;
                                        double currectvelpick;
                                        string currentstatupick;
                                        ObjectList.Servo_X1.GetCurrentPos(out currectpospick, out currentstatupick, out currectvelpick);
                                        if (Math.Round(x ?? 0.0, 3, MidpointRounding.AwayFromZero) == currectpospick)
                                        {
                                            ObjectList.Servo_Y1.GetCurrentPos(out currectpospick, out currentstatupick, out currectvelpick);
                                            if (Math.Round(y ?? 0.0, 3, MidpointRounding.AwayFromZero) >= currectpospick - 0.02 || Math.Round((double)y, 2) <= currectpospick + 0.02)
                                            {
                                                return true;
                                            }
                                        }
                                        return false;

                                    }


                                }
                                else
                                {
                                    await GlobalVariable.AlarmTriggerAsync(ECode.Servo_Z1_Not_Safe_Org, true, 1);

                                    GlobalVariable.current_MCStatus = GlobalVariable.MachineStatus.Stop;
                                    try
                                    {
                                        ConveyorSystem.Stop();

                                    }
                                    catch (Exception)
                                    {

                                        //throw;
                                    }
                                    GlobalVariable.b_gHomingDone = false;
                                    GlobalVariable.bhomeseq_running = false;
                                    GlobalVariable.pause = false; // AK
                                    GlobalVariable.b_gPause = false;

                                    GlobalVariable.New_Pallet_Only = false;

                                }
                            }
                            else
                            {
                                await GlobalVariable.AlarmTriggerAsync(ECode.Servo_Z2_Not_Safe_Org, true, 1);

                                GlobalVariable.current_MCStatus = GlobalVariable.MachineStatus.Stop;
                                try
                                {
                                    ConveyorSystem.Stop();

                                }
                                catch (Exception)
                                {

                                    //throw;
                                }
                                GlobalVariable.b_gHomingDone = false;
                                GlobalVariable.bhomeseq_running = false;
                                GlobalVariable.pause = false; // AK
                                GlobalVariable.b_gPause = false;

                                GlobalVariable.New_Pallet_Only = false;

                            }

                        }
                        else
                        {

                            await Task.Run(() => ObjectList.Servo_Z1.Move_Abs(Convert.ToDouble(GlobalVariable.SafePosition.PositionZ1), Convert.ToDouble(GlobalVariable.SafePosition.ZVel), Convert.ToDouble(GlobalVariable.SafePosition.ZAcc), Convert.ToDouble(GlobalVariable.SafePosition.ZDeAcc), 15000));
                            return false;
                        }

                    }
                    else
                    {
                        return false;
                    }




                }
                else
                {
                    await Task.Run(() => ObjectList.Servo_Z2.Move_Abs(Convert.ToDouble(GlobalVariable.SafePosition.PositionZ2), Convert.ToDouble(GlobalVariable.SafePosition.ZVel), Convert.ToDouble(GlobalVariable.SafePosition.ZAcc), Convert.ToDouble(GlobalVariable.SafePosition.ZDeAcc), 15000));
                    return false;
                }

            }

            return false;


        }



        public static async Task<bool> ldmove(Position p)
        {

            Task T1 = Task.Run(() => ObjectList.Stepper_1.Move_Abs(Convert.ToDouble(p.PositionX), Convert.ToDouble(p.XVel), Convert.ToDouble(p.XAcc), Convert.ToDouble(p.XDeAcc), 5000));

            Task T2 = Task.Run(() => ObjectList.Stepper_2.Move_Abs(Convert.ToDouble(p.PositionY), Convert.ToDouble(p.YVel), Convert.ToDouble(p.YAcc), Convert.ToDouble(p.YDeAcc), 5000));
            await Task.WhenAll(T1, T2);
            double currectpospick;
            double currectvelpick;
            string currentstatupick;
            ObjectList.Stepper_1.GetCurrentPos(out currectpospick, out currentstatupick, out currectvelpick);
            if (p.PositionX == currectpospick)
            {
                ObjectList.Stepper_2.GetCurrentPos(out currectpospick, out currentstatupick, out currectvelpick);
                if (p.PositionY == currectpospick)
                {
                    return true;
                }
            }
            return false;






        }

        public static async Task<bool> Wk2move(Position p)
        {

            Task T1 = Task.Run(() => ObjectList.Servo_X2.Move_Abs(Convert.ToDouble(p.PositionX), Convert.ToDouble(p.XVel), Convert.ToDouble(p.XAcc), Convert.ToDouble(p.XDeAcc), 5000));

            Task T2 = Task.Run(() => ObjectList.Servo_Y2.Move_Abs(Convert.ToDouble(p.PositionY), Convert.ToDouble(p.YVel), Convert.ToDouble(p.YAcc), Convert.ToDouble(p.YDeAcc), 5000));
            await Task.WhenAll(T1, T2);
            double currectpospick;
            double currectvelpick;
            string currentstatupick;
            ObjectList.Servo_X2.GetCurrentPos(out currectpospick, out currentstatupick, out currectvelpick);
            if (p.PositionX == currectpospick)
            {
                ObjectList.Servo_Y2.GetCurrentPos(out currectpospick, out currentstatupick, out currectvelpick);
                if (p.PositionY == currectpospick)
                {
                    return true;
                }
            }
            return false;






        }
        public static async Task GoWK1Z1FeedPos()
        {
            await move(GlobalVariable.Wk1_Z1FedPos);

        }
        public static double getcurrentpos(Advantech_PCIE obj)
        {
            double currectpos;
            double currectvel;
            string currentstatus;
            obj.GetCurrentPos(out currectpos, out currentstatus, out currectvel);
            return currectpos;
        }

        public static async Task GoWK1Z1CCD2Pos()
        {
            await move(GlobalVariable.Wk1_Z1CCD2pos);

        }

        public static async Task GoWK1Z2CCD2Pos()
        {
            await move(GlobalVariable.Wk1_Z2CCD2pos);


        }

        public static async Task GoWK1Z2FeedPos()
        {
            await move(GlobalVariable.Wk1_Z2FedPos);

        }



        public async static Task wk1_homeX()
        {
            if (ObjectList.Servo_X1.Set_Home_Vel(GlobalVariable.g_lstAxisConfig[(int)DIDO.EAxis.Servo_X1].HomingSpeed, GlobalVariable.g_lstAxisConfig[(int)DIDO.EAxis.Servo_X1].Acc, GlobalVariable.g_lstAxisConfig[(int)DIDO.EAxis.Servo_X1].DeAcc))
            {
                ObjectList.Servo_X1.Homing(1);
                await Task.Delay(10);
            }

        }
        public async static Task wk1_homeR1()
        {
            //if (ObjectList.Servo_R1.Set_Home_Vel(GlobalVariable.g_lstAxisConfig[(int)DIDO.EAxis.Servo_R1].HomingSpeed, GlobalVariable.g_lstAxisConfig[(int)DIDO.EAxis.Servo_R1].Acc, GlobalVariable.g_lstAxisConfig[(int)DIDO.EAxis.Servo_R1].DeAcc))
            //{
            //    ObjectList.Servo_R1.Homing(0);
            //    await Task.Delay(10);
            //}


            if (ObjectList.Servo_R1.Set_Home_Vel(GlobalVariable.g_lstAxisConfig[(int)DIDO.EAxis.Servo_R2].HomingSpeed, GlobalVariable.g_lstAxisConfig[(int)DIDO.EAxis.Servo_R2].Acc, GlobalVariable.g_lstAxisConfig[(int)DIDO.EAxis.Servo_R2].DeAcc))
            {
                ObjectList.Servo_R1.Homing(0);
                await Task.Delay(10);
            }
            await Task.Delay(100);
            if (ObjectList.Servo_R1.GetSingleMotionIOBit(Advantech_PCIE.MotionIOBit.ORG))
            {
                if (ObjectList.Servo_R1.Set_Home_Vel(GlobalVariable.g_lstAxisConfig[(int)DIDO.EAxis.Servo_R2].HomingSpeed, GlobalVariable.g_lstAxisConfig[(int)DIDO.EAxis.Servo_R2].Acc, GlobalVariable.g_lstAxisConfig[(int)DIDO.EAxis.Servo_R2].DeAcc))
                {
                    ObjectList.Servo_R1.Homing(1);
                    await Task.Delay(10);
                }
            }
        }
        public async static Task wk1_homeR2()
        {
            if (ObjectList.Servo_R2.Set_Home_Vel(GlobalVariable.g_lstAxisConfig[(int)DIDO.EAxis.Servo_R2].HomingSpeed, GlobalVariable.g_lstAxisConfig[(int)DIDO.EAxis.Servo_R2].Acc, GlobalVariable.g_lstAxisConfig[(int)DIDO.EAxis.Servo_R2].DeAcc))
            {
                ObjectList.Servo_R2.Homing(0);
                await Task.Delay(10);
            }
            await Task.Delay(100);
            if (ObjectList.Servo_R2.GetSingleMotionIOBit(Advantech_PCIE.MotionIOBit.ORG))
            {
                if (ObjectList.Servo_R2.Set_Home_Vel(GlobalVariable.g_lstAxisConfig[(int)DIDO.EAxis.Servo_R2].HomingSpeed, GlobalVariable.g_lstAxisConfig[(int)DIDO.EAxis.Servo_R2].Acc, GlobalVariable.g_lstAxisConfig[(int)DIDO.EAxis.Servo_R2].DeAcc))
                {
                    ObjectList.Servo_R2.Homing(1);
                    await Task.Delay(10);
                }
            }
        }
        public async static Task wk1_homeY()
        {
            if (ObjectList.Servo_Y1.Set_Home_Vel(GlobalVariable.g_lstAxisConfig[(int)DIDO.EAxis.Servo_Y1].HomingSpeed, GlobalVariable.g_lstAxisConfig[(int)DIDO.EAxis.Servo_Y1].Acc, GlobalVariable.g_lstAxisConfig[(int)DIDO.EAxis.Servo_Y1].DeAcc))
            {
                ObjectList.Servo_Y1.Homing(0);
                await Task.Delay(10);
            }
            await Task.Delay(100);
            if (ObjectList.Servo_Y1.GetSingleMotionIOBit(Advantech_PCIE.MotionIOBit.ORG))
            {
                if (ObjectList.Servo_Y1.Set_Home_Vel(GlobalVariable.g_lstAxisConfig[(int)DIDO.EAxis.Servo_Y1].HomingSpeed, GlobalVariable.g_lstAxisConfig[(int)DIDO.EAxis.Servo_Y1].Acc, GlobalVariable.g_lstAxisConfig[(int)DIDO.EAxis.Servo_Y1].DeAcc))
                {
                    ObjectList.Servo_Y1.Homing(1);
                    await Task.Delay(10);
                }
            }
        }


        public async static Task wk2_homeX()
        {

            if (ObjectList.Servo_X2.Set_Home_Vel(GlobalVariable.g_lstAxisConfig[(int)DIDO.EAxis.Servo_X2].HomingSpeed, GlobalVariable.g_lstAxisConfig[(int)DIDO.EAxis.Servo_X2].Acc, GlobalVariable.g_lstAxisConfig[(int)DIDO.EAxis.Servo_X2].DeAcc))
            {
                ObjectList.Servo_X2.Homing(1);

            }
        }

        public async static Task wk2_homeY()
        {
            if (ObjectList.Servo_Y2.Set_Home_Vel(GlobalVariable.g_lstAxisConfig[(int)DIDO.EAxis.Servo_Y2].HomingSpeed, GlobalVariable.g_lstAxisConfig[(int)DIDO.EAxis.Servo_Y2].Acc, GlobalVariable.g_lstAxisConfig[(int)DIDO.EAxis.Servo_Y2].DeAcc))
            {
                ObjectList.Servo_Y2.Homing(1);

            }

        }

        public async static Task MoveR1(Position p, double? position = null)
        {
            if (WorkingConveyor1.SafeR(100, position ?? 0.0))
            {
                //Arulkumar Fixed Hung start
                const int MAX_R_MOVE_RETRIES = 100;
                int rMoveRetries = 0;
                //Arulkumar Fixed Hung end
                if (position == null)
                {
                    double currectpospick;
                    double currectvelpick;
                    string currentstatupick;
                    ObjectList.Servo_R1.GetCurrentPos(out currectpospick, out currentstatupick, out currectvelpick);
                    while (Math.Round(p.PositionR1, 3, MidpointRounding.AwayFromZero) != currectpospick)
                    {
                        //Arulkumar Fixed Hung start
                        rMoveRetries++;
                        if (rMoveRetries > MAX_R_MOVE_RETRIES)
                        {
                            Logger.WriteLog(Logger.LogType.Error, "GantrySystem", "MoveR1", "R1 move exceeded max retries", p.PositionR1.ToString());
                            break;
                        }
                        //Arulkumar Fixed Hung end
                        ObjectList.Servo_R1.Move_Abs(Convert.ToDouble(p.PositionR1), Convert.ToDouble(p.RVel), Convert.ToDouble(p.RAcc), Convert.ToDouble(p.RDeAcc), 15000);
                        ObjectList.Servo_R1.GetCurrentPos(out currectpospick, out currentstatupick, out currectvelpick);
                    }
                }
                else
                {
                    double currectpospick;
                    double currectvelpick;
                    string currentstatupick;
                    ObjectList.Servo_R1.GetCurrentPos(out currectpospick, out currentstatupick, out currectvelpick);
                    while (Math.Round(position ?? 0.0, 3, MidpointRounding.AwayFromZero) != currectpospick)
                    {
                        //Arulkumar Fixed Hung start
                        rMoveRetries++;
                        if (rMoveRetries > MAX_R_MOVE_RETRIES)
                        {
                            Logger.WriteLog(Logger.LogType.Error, "GantrySystem", "MoveR1", "R1 move exceeded max retries", (position ?? 0.0).ToString());
                            break;
                        }
                        //Arulkumar Fixed Hung end
                        ObjectList.Servo_R1.Move_Abs(Convert.ToDouble(position), Convert.ToDouble(p.RVel), Convert.ToDouble(p.RAcc), Convert.ToDouble(p.RDeAcc), 15000);
                        ObjectList.Servo_R1.GetCurrentPos(out currectpospick, out currentstatupick, out currectvelpick);
                    }
                }

            }
        }

        public async static Task MoveR2(Position p, double? position = null)
        {
            if (WorkingConveyor1.SafeR(100, position ?? 0.0))
            {
                //Arulkumar Fixed Hung start
                const int MAX_R_MOVE_RETRIES = 100;
                int rMoveRetries = 0;
                //Arulkumar Fixed Hung end
                if (position == null)
                {
                    double currectpospick;
                    double currectvelpick;
                    string currentstatupick;
                    ObjectList.Servo_R2.GetCurrentPos(out currectpospick, out currentstatupick, out currectvelpick);
                    while (Math.Round(p.PositionR2, 3, MidpointRounding.AwayFromZero) != currectpospick)
                    {
                        //Arulkumar Fixed Hung start
                        rMoveRetries++;
                        if (rMoveRetries > MAX_R_MOVE_RETRIES)
                        {
                            Logger.WriteLog(Logger.LogType.Error, "GantrySystem", "MoveR2", "R2 move exceeded max retries", p.PositionR2.ToString());
                            break;
                        }
                        //Arulkumar Fixed Hung end
                        ObjectList.Servo_R2.Move_Abs(Convert.ToDouble(p.PositionR2), Convert.ToDouble(p.RVel), Convert.ToDouble(p.RAcc), Convert.ToDouble(p.RDeAcc), 15000);
                        ObjectList.Servo_R2.GetCurrentPos(out currectpospick, out currentstatupick, out currectvelpick);
                    }
                }
                else
                {
                    double currectpospick;
                    double currectvelpick;
                    string currentstatupick;
                    ObjectList.Servo_R2.GetCurrentPos(out currectpospick, out currentstatupick, out currectvelpick);
                    while (Math.Round(position ?? 0.0, 3, MidpointRounding.AwayFromZero) != currectpospick)
                    {
                        //Arulkumar Fixed Hung start
                        rMoveRetries++;
                        if (rMoveRetries > MAX_R_MOVE_RETRIES)
                        {
                            Logger.WriteLog(Logger.LogType.Error, "GantrySystem", "MoveR2", "R2 move exceeded max retries", (position ?? 0.0).ToString());
                            break;
                        }
                        //Arulkumar Fixed Hung end
                        ObjectList.Servo_R2.Move_Abs(Convert.ToDouble(position), Convert.ToDouble(p.RVel), Convert.ToDouble(p.RAcc), Convert.ToDouble(p.RDeAcc), 15000);
                        ObjectList.Servo_R2.GetCurrentPos(out currectpospick, out currentstatupick, out currectvelpick);
                    }

                }

            }
        }

        public async static Task scanCnv_home()
        {
            _ = Task.Run(async () =>
            {
                if (ObjectList.Stepper_1.Set_Home_Vel(GlobalVariable.g_lstAxisConfig[(int)DIDO.EAxis.Stepper_1].HomingSpeed, GlobalVariable.g_lstAxisConfig[(int)DIDO.EAxis.Stepper_1].Acc, GlobalVariable.g_lstAxisConfig[(int)DIDO.EAxis.Stepper_1].DeAcc))
                {
                    await ObjectList.Stepper_1.ManulHoming(1, (GlobalVariable.g_lstAxisConfig[(int)DIDO.EAxis.Stepper_1].HomingSpeed));

                }
            });
            _ = Task.Run(async () =>
            {
                if (ObjectList.Stepper_2.Set_Home_Vel(GlobalVariable.g_lstAxisConfig[(int)DIDO.EAxis.Stepper_2].HomingSpeed, GlobalVariable.g_lstAxisConfig[(int)DIDO.EAxis.Stepper_2].Acc, GlobalVariable.g_lstAxisConfig[(int)DIDO.EAxis.Stepper_2].DeAcc))
                {
                    await ObjectList.Stepper_2.ManulHoming(1, (GlobalVariable.g_lstAxisConfig[(int)DIDO.EAxis.Stepper_1].HomingSpeed));


                }
            });

        }
        public static void GoWK1XinitialPos()
        {
            //if (NozzleSystem.Nozzle1safe(GlobalVariable.SafePosition))
            //{
            //    if (NozzleSystem.Nozzle1safe(GlobalVariable.SafePosition))
            //    {
            ObjectList.Servo_X1.Move_Abs(Convert.ToDouble(GlobalVariable.WK1_initial.PositionX), Convert.ToDouble(GlobalVariable.WK1_initial.XVel), Convert.ToDouble(GlobalVariable.WK1_initial.XAcc), Convert.ToDouble(GlobalVariable.WK1_initial.XDeAcc), 15000);
            //    }
            //}
        }
        public static void GoWK1YinitialPos()
        {

            ObjectList.Servo_Y1.Move_Abs(Convert.ToDouble(GlobalVariable.WK1_initial.PositionY), Convert.ToDouble(GlobalVariable.WK1_initial.YVel), Convert.ToDouble(GlobalVariable.WK1_initial.YAcc), Convert.ToDouble(GlobalVariable.WK1_initial.YDeAcc), 15000);

        }
        public static void GoWK2XinitialPos()
        {
            ObjectList.Servo_X2.Move_Abs(Convert.ToDouble(GlobalVariable.Wk2_initial.PositionX), Convert.ToDouble(GlobalVariable.Wk2_initial.XVel), Convert.ToDouble(GlobalVariable.Wk2_initial.XAcc), Convert.ToDouble(GlobalVariable.Wk2_initial.XDeAcc), 15000);

        }
        public static void GoWK2YinitialPos()
        {
            ObjectList.Servo_Y2.Move_Abs(Convert.ToDouble(GlobalVariable.Wk2_initial.PositionY), Convert.ToDouble(GlobalVariable.Wk2_initial.YVel), Convert.ToDouble(GlobalVariable.Wk2_initial.YAcc), Convert.ToDouble(GlobalVariable.Wk2_initial.YDeAcc), 15000);


        }
        public static void GoZ1initialPos()
        {
            ObjectList.Servo_Z1.Move_Abs(Convert.ToDouble(GlobalVariable.WK1_initial.PositionZ1), Convert.ToDouble(GlobalVariable.WK1_initial.ZVel), Convert.ToDouble(GlobalVariable.WK1_initial.ZAcc), Convert.ToDouble(GlobalVariable.WK1_initial.ZDeAcc), 15000);

        }
        public static void GoZ2initialPos()
        {
            ObjectList.Servo_Z2.Move_Abs(Convert.ToDouble(GlobalVariable.WK1_initial.PositionZ2), Convert.ToDouble(GlobalVariable.WK1_initial.ZVel), Convert.ToDouble(GlobalVariable.WK1_initial.ZAcc), Convert.ToDouble(GlobalVariable.WK1_initial.ZDeAcc), 15000);

        }
        public static void GoR1initialPos()
        {
            ObjectList.Servo_R1.Move_Abs(Convert.ToDouble(GlobalVariable.WK1_initial.PositionR1), Convert.ToDouble(GlobalVariable.WK1_initial.RVel), Convert.ToDouble(GlobalVariable.WK1_initial.RAcc), Convert.ToDouble(GlobalVariable.WK1_initial.ZDeAcc), 15000);

        }
        public static void GoR2initialPos()
        {
            ObjectList.Servo_R2.Move_Abs(Convert.ToDouble(GlobalVariable.WK1_initial.PositionR2), Convert.ToDouble(GlobalVariable.WK1_initial.RVel), Convert.ToDouble(GlobalVariable.WK1_initial.RAcc), Convert.ToDouble(GlobalVariable.WK1_initial.ZDeAcc), 15000);

        }


        public static bool CheckHome(int axisindex)
        {
            if (axisindex == 4)
                return ObjectList.Servo_X1.CheckHome();
            else
           if (axisindex == 5)
                return ObjectList.Servo_Y1.CheckHome();
            else if (axisindex == 10)
                return ObjectList.Servo_X2.CheckHome();
            else if (axisindex == 11)
                return ObjectList.Servo_Y2.CheckHome();
            return false;
        }

    }
}
