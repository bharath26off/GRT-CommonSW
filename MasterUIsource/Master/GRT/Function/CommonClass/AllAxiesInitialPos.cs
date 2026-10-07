using DynamicVacuums;
using ExceptionLib;
using GRT_BG1.Function.Calibration;
using Master;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static DIO.DIDO;

namespace GRT_BG1_V54.Function.CommonClass
{
    public class AllAxiesInitialPos
    {
        public static async void GoinitialPosition()
        {
            await Task.Run(() => Logger.WriteLogasTask(Logger.LogType.Running, "Homing", "AllAxiesInitialPos", "Gantray Moving initial position", "", default(DateTime), "GoinitialPosition", 16));
            if (NozzleSystem.CheckHome(6, "Nozzle1") && NozzleSystem.CheckHome(7, "Nozzle2"))
            {
               // await Task.Run(() => NozzleSystem.Nozzle1safe(GlobalVariable.SafePosition));
               // await Task.Run(() => NozzleSystem.Nozzle2safe(GlobalVariable.SafePosition));
                Task T3 = Task.Run(() => NozzleSystem.Nozzle1safe(GlobalVariable.SafePosition));
                Task T4 = Task.Run(() => NozzleSystem.Nozzle2safe(GlobalVariable.SafePosition));
                Task.WaitAll(T3, T4);
                double Safe_pos = ObjectList.Servo_Z1.GetCurrentPosition();
                double Safe_pos2 = ObjectList.Servo_Z2.GetCurrentPosition();
                if (Safe_pos <=  GlobalVariable.SafePosition.PositionZ1 && Safe_pos2 <= GlobalVariable.SafePosition.PositionZ2)
                {
                    Task T16 = Task.Run(delegate
                    {
                        GantrySystem.GoZ1initialPos();
                    });
                    Task T17 = Task.Run(delegate
                    {
                        GantrySystem.GoZ2initialPos();
                    });
                    Task T18 = Task.Run(delegate
                    {
                        GantrySystem.GoR1initialPos();
                    });
                    Task T19 = Task.Run(delegate
                    {
                        GantrySystem.GoR2initialPos();
                    });
                    Task T11 = Task.Run(delegate
                {
                    StepperSystem.Stepper_1GoinitialPos();
                });
                    Task T12 = Task.Run(delegate
                    {
                        StepperSystem.Stepper_2GoinitialPos();
                    });
                    Task T13 = Task.Run(delegate
                    {
                        GantrySystem.GoWK1XinitialPos();
                    });
                    Task T14 = Task.Run(delegate
                    {
                        GantrySystem.GoWK1YinitialPos();
                    });
                    Task T15 = Task.Run(delegate
                    {
                        GantrySystem.GoWK2XinitialPos();
                    });
                    Task T10 = Task.Run(delegate
                    {
                        GantrySystem.GoWK2YinitialPos();
                    });
                    await Task.WhenAll(T16,T17,T18,T19,T11, T12, T13, T14, T15, T10);

                    await Task.Delay(300);

                    GlobalVariable.DIDO.WriteOPS(false, (int)EOutput.Pick_Place_Z1_Axis_Vaccuum_ON);
                    GlobalVariable.DIDO.WriteOPS(false, (int)EOutput.Pick_Place_Z2_Axis_Vaccuum_ON);
                    await Task.Delay(200);
                    GlobalVariable.DIDO.WriteOPS(true, (int)EOutput.Pick_Place_Z1_Axis_Vaccuum_Blow);
                    GlobalVariable.DIDO.WriteOPS(true, (int)EOutput.Pick_Place_Z2_Axis_Vaccuum_Blow);
                    await Task.Delay(3000);
                    GlobalVariable.DIDO.WriteOPS(false, (int)EOutput.Pick_Place_Z1_Axis_Vaccuum_Blow);
                    GlobalVariable.DIDO.WriteOPS(false, (int)EOutput.Pick_Place_Z2_Axis_Vaccuum_Blow);


                    MessageBox.Show("Homing Process Completed", "Confirmation", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);


                }
            }
            else
            {
                Task T3 = Task.Run(() => NozzleSystem.Nozzle1Homing());
                Task T4 = Task.Run(() => NozzleSystem.Nozzle2Homing());
                Task.WaitAll(T3, T4);
                GoinitialPosition();

            }
        }
    }
}
