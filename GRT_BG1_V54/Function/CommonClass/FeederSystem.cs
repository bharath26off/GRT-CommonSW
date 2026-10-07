//using ExceptionLib;
//using GRT_BG1.Function.Calibration;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using static DIO.DIDO;

//namespace GRT_BG1_V54.Function.CommonClass
//{
//    public class FeederSystem
//    {
//        int i_step = 0;
//        FeederFunction F = new FeederFunction();

//        public async Task GraphiteFeeder_Seq()
//        {
//            switch (i_step)
//            {
//                case 0:
//                    await Logger.WriteLogasTask(Logger.LogType.Running, "GraphiteFeeder", "Feeder", "i_step 0: Initializing graphite feeder - loading reel and enabling motors.", "");
                  
//                    F.EnableFeederMotor(true);
//                    F.EnableStepperMotor(true);
//                    i_step = 1;
//                    break;

//                case 1:
//                    await Logger.WriteLogasTask(Logger.LogType.Running, "GraphiteFeeder", "Feeder", "i_step 1: Starting unwinding stepper motor.", "");
//                    F.StartStepperMotor();
//                    i_step = 2;
//                    break;

//                case 2:
//                    await Logger.WriteLogasTask(Logger.LogType.Running, "GraphiteFeeder", "Feeder", "i_step 2: Waiting for graphite to reach peeling knife platform.", "");
//                    if (F.IsGraphiteAtKnifePlatform())
//                        i_step = 3;
//                    break;

//                case 3:
//                    await Logger.WriteLogasTask(Logger.LogType.Running, "GraphiteFeeder", "Feeder", "i_step 3: Activating guide rollers.", "");
//                    F.ActivateGuideRollers();
//                    i_step = 4;
//                    break;

//                case 4:
//                    await Logger.WriteLogasTask(Logger.LogType.Running, "GraphiteFeeder", "Feeder", "i_step 4: Vacuum holder secures graphite in position.", "");
//                    F.ActivateVacuumHolder();
//                    i_step = 5;
//                    break;

//                case 5:
//                    await Logger.WriteLogasTask(Logger.LogType.Running, "GraphiteFeeder", "Feeder", "i_step 5: Feeding block moves graphite toward knife.", "");
//                    F.MoveMaterialFeeder();
//                    i_step = 6;
//                    break;

//                case 6:
//                    await Logger.WriteLogasTask(Logger.LogType.Running, "GraphiteFeeder", "Feeder", "i_step 6: Waiting for fiber optic sensors to detect graphite.", "");
//                    if (F.IsGraphiteInPosition())
//                        i_step = 7;
//                    break;

//                case 7:
//                    await Logger.WriteLogasTask(Logger.LogType.Running, "GraphiteFeeder", "Feeder", "i_step 7: Blowing cylinder moves down to press film.", "");
//                    F.MoveBlowingCylinderDown();
//                    i_step = 8;
//                    break;

//                case 8:
//                    await Logger.WriteLogasTask(Logger.LogType.Running, "GraphiteFeeder", "Feeder", "i_step 8: Stopping unwinding stepper motor.", "");
//                    F.StopStepperMotor();
//                    i_step = 9;
//                    break;

//                case 9:
//                    await Logger.WriteLogasTask(Logger.LogType.Running, "GraphiteFeeder", "Feeder", "i_step 9: Triggering CCD1 for graphite inspection.", "");
//                    F.CaptureCCD1();
//                    i_step = 10;
//                    break;

//                case 10:
//                    if (F.IsGraphiteValid())
//                    {
//                        await Logger.WriteLogasTask(Logger.LogType.Running, "GraphiteFeeder", "Feeder", "i_step 10: CCD1 confirms graphite. Moving gantry to feeder.", "");
//                        i_step = 11;
//                    }
//                    else if (F.IsGraphiteInvalid())
//                    {
//                        await Logger.WriteLogasTask(Logger.LogType.Error, "GraphiteFeeder", "Feeder", "i_step 10: CCD1 failed to detect graphite correctly. Triggering alarm.", "");
//                        //GlobalVariable.AlarmTrigger(ECode.GraphiteDetectionFailed, true, 0);
//                        i_step = 0; // Or send to error state
//                    }
//                    break;

//                case 11:
//                    await Logger.WriteLogasTask(Logger.LogType.Running, "GraphiteFeeder", "Feeder", "i_step 11: PnP gantry moving to graphite feeder.", "");
//                    await F.MoveGantryToFeeder();
//                    i_step = 12;
//                    break;

//                case 12:
//                    await Logger.WriteLogasTask(Logger.LogType.Running, "GraphiteFeeder", "Feeder", "i_step 12: Picking graphite and placing it (Refer Working Conveyor sequence).", "");
//                    await F.PickAndPlace();
//                    i_step = 13;
//                    break;

//                case 13:
//                    await Logger.WriteLogasTask(Logger.LogType.Running, "GraphiteFeeder", "Feeder", "i_step 13: Blowing cylinder moves up.", "");
//                    F.MoveBlowingCylinderUp();
//                    i_step = 14;
//                    break;

//                case 14:
//                    await Logger.WriteLogasTask(Logger.LogType.Running, "GraphiteFeeder", "Feeder", "i_step 14: Restarting stepper motor for next section.", "");
//                    F.StartStepperMotor();
//                    i_step = 1; // Loop again from feeding start
//                    break;

//                default:
//                    i_step = 0;
//                    break;
//            }
//        }
//    }

//    public class FeederFunction
//    {
//        public void LoadGraphiteReel()
//        {
//            // Code to load graphite reel, or assumed manual
//        }

//        public void EnableFeederMotor(bool enable)
//        {
//            // Code to enable feeder motor
//        }

//        public void EnableStepperMotor(bool enable)
//        {
//            // Code to enable stepper motor power
//        }

//        public void StartStepperMotor()
//        {
//            // Code to start the stepper motor unwinding
//        }

//        public void StopStepperMotor()
//        {
//            // Code to stop the stepper motor
//        }

//        public bool IsGraphiteAtKnifePlatform()
//        {
//            // Return true if graphite reached peeling knife platform
//            return true;// Sensors.GraphiteAtKnifePlatform();
//        }

//        public void ActivateGuideRollers()
//        {
//            // Code to activate guide rollers
//            //GuideRollerSystem.Activate();
//        }

//        public void ActivateVacuumHolder()
//        {
//            // Code to activate vacuum holder
//           // VacuumHolder.Activate();
//        }

//        public void MoveMaterialFeeder()
//        {
//            // Code to move material feeding block toward knife
//           // MaterialFeeder.Move();
//        }

//        public bool IsGraphiteInPosition()
//        {
//            // Return true if fiber optic sensors detect graphite in position
//            return true;// Sensors.IsGraphiteInPosition();
//        }

//        public void MoveBlowingCylinderDown()
//        {
//            // Code to move blowing cylinder down
//           // BlowingCylinder.MoveDown();
//        }

//        public void MoveBlowingCylinderUp()
//        {
//            // Code to move blowing cylinder up
//           // BlowingCylinder.MoveUp();
//        }

//        public void CaptureCCD1()
//        {
//            // Trigger CCD1 camera to capture graphite presence
//            //VisionSystem.CaptureCCD1();
//        }

//        public bool IsGraphiteValid()
//        {
//            // Return true if CCD1 validation successful
//            return true; // VisionSystem.IsGraphiteValid();
//        }

//        public bool IsGraphiteInvalid()
//        {
//            // Return true if CCD1 validation failed
//            return true;// VisionSystem.IsGraphiteInvalid();
//        }

//        public async Task MoveGantryToFeeder()
//        {
//            // Async call to move PnP gantry to graphite feeder
//           // await GantrySystem.MoveToFeeder();
//        }

//        public async Task PickAndPlace()
//        {
//            // Async call for picking graphite and placing it
//           // await GantrySystem.PickAndPlace();
//        }
//    }

//}
