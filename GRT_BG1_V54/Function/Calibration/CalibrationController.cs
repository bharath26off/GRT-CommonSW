//using Advantech;
//using DynamicCylinders;
//using GRT_BG1.Data;
//using GRT_BG1.GlobalVar;
//using Master;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using static DIO.DIDO;

//namespace GRT_BG1.Function.Calibration
//{

//    public enum CalibrationStep
//    {
//        Homing,
//        PlacePlateConveyor1,
//        DetectCarrierConveyor1,
//        MoveToConveyor2,
//        StopConveyor2,
//        DetectPalletConveyor2,
//        LiftPlateConveyor2,
//        StoppallServo,
//        PutMylarCCD1,
//        CCD1Capture,
//        CCD1Calibrate,
//        PutMylarAgain,
//        Nozzle1Pick,
//        CCD2Capture1,
//        CCD2Calibrate1,
//        Nozzle1Place,
//        CCD1Trigger1,
//        Nozzle1Done,
//        Nozzle2Pick,
//        CCD2Capture2,
//        CCD2Calibrate2,
//        Nozzle2Place,
//        CCD1Trigger2,
//        Nozzle2Done,
//        UnloadPlate,
//        PlacePlateConveyor1Again,
//        MoveToConveyor3,
//        DetectPalletConveyor3,
//        LiftPlateConveyor3,
//        PutMylarCCD3,
//        CCD3Capture,
//        CCD3GantryXY,
//        CCD3Calibrate,
//        Complete
//    }

//    // Simulated systems
  

   

//    public class CalibrationController
//    {
//        public async Task CCD1_calib()
//        {
//            CalibrationStep currentStep = CalibrationStep.Homing;

//            while (currentStep != CalibrationStep.Complete)
//            {
//                switch (currentStep)
//                {
//                    case CalibrationStep.Homing:
//                        Console.WriteLine("Homing process... Stopper lifts up.");
//                        currentStep = CalibrationStep.PlacePlateConveyor1;
//                        break;

//                    case CalibrationStep.PlacePlateConveyor1:
//                        if(await ConveyorSystem.EntryScanCnv())
//                            currentStep = CalibrationStep.DetectCarrierConveyor1;
//                        else
//                            currentStep = CalibrationStep.PlacePlateConveyor1;
//                        break;

//                    case CalibrationStep.DetectCarrierConveyor1:
                        
//                        currentStep = CalibrationStep.MoveToConveyor2;
//                        break;

//                    case CalibrationStep.MoveToConveyor2:
//                        if (!GlobalVariable.DI[(int)EInput.Work_Conv_1_Pallet_Inplace_Sen])
//                        {
//                            // await Logger.WriteLogasTask(Logger.LogType.Running, "Conveyor1", "Conveyor1", "Lowering stopper and moving carrier to Conveyor-2.", "");
//                            Cylinder_config.Cylinders_List[(int)Cylinder_config.Cylinders.Scan_Conv_Stopper_Cyl].Cylinder_Retract();
//                            Cylinder_config.Cylinders_List[(int)Cylinder_config.Cylinders.Work_Conv_1_Stopper_Cyl].Cylinder_Extend();

//                        }
//                        currentStep = CalibrationStep.DetectPalletConveyor2;
//                        break;

//                    case CalibrationStep.DetectPalletConveyor2:
//                        if (!GlobalVariable.DI[(int)EInput.Scan_Conv_Stopper_Cyl_Dn] && GlobalVariable.DI[(int)EInput.Work_Conv_1_Stopper_Cyl_Up])
//                        {
//                            ConveyorSystem.MovePlate(new bool?[] {true,true,true,true,false,false});
//                           currentStep = CalibrationStep.LiftPlateConveyor2;
//                        }
//                        break;
//                    case CalibrationStep.StoppallServo:
//                        if (GlobalVariable.DI[(int)EInput.Work_Conv_1_Pallet_Inplace_Sen])
//                        {
//                            ConveyorSystem.MovePlate(new bool?[] { false, false, false, false, false, false });
//                            Cylinder_config.Cylinders_List[(int)Cylinder_config.Cylinders.Scan_Conv_Stopper_Cyl].Cylinder_Extend();
//                            currentStep = CalibrationStep.LiftPlateConveyor2;
//                        }
                        
//                        break;

//                    case CalibrationStep.LiftPlateConveyor2:
//                        if (GlobalVariable.DI[(int)EInput.Scan_Conv_Stopper_Cyl_Up] && GlobalVariable.DI[(int)EInput.Work_Conv_1_Pallet_Inplace_Sen])
//                        {
//                            Cylinder_config.Cylinders_List[(int)Cylinder_config.Cylinders.Work_Conv_1_pallet_Lift_Cyl].Cylinder_Extend();
//                        }
//                        currentStep = CalibrationStep.StoppallServo;
//                        break;
//                    case CalibrationStep.PutMylarCCD1:
//                        ShowMessageBox("Place The Mylar");
//                        currentStep = CalibrationStep.CCD1Capture;
//                        break;

//                    case CalibrationStep.CCD1Capture:
//                        GantrySystem.MoveToPositions(11, "CCD1");
//                        currentStep = CalibrationStep.CCD1Calibrate;
//                        break;

//                    case CalibrationStep.CCD1Calibrate:
//                        VisionSystem.Calibrate("CCD1");
//                        currentStep = CalibrationStep.Nozzle1Pick;
//                        break;
//                } } }


//        public async Task CCD2_calib()
//        {
//            CalibrationStep currentStep = CalibrationStep.Homing;

//            while (currentStep != CalibrationStep.Complete)
//            {
//                switch (currentStep)
//                {
//                    case CalibrationStep.PutMylarAgain:
//                        ShowMessageBox("Put Mylar Again");
//                        currentStep = CalibrationStep.Nozzle1Pick;
//                        break;
//                    case CalibrationStep.Nozzle1Pick:
//                        NozzleSystem.MoveDown("Nozzle-1");
//                        NozzleSystem.Pick("Nozzle-1");
//                        currentStep = CalibrationStep.CCD2Capture1;
//                        break;

//                    case CalibrationStep.CCD2Capture1:
//                        GantrySystem.MoveToPositions(11, "CCD2");
//                        currentStep = CalibrationStep.CCD2Calibrate1;
//                        break;

//                    case CalibrationStep.CCD2Calibrate1:
//                        VisionSystem.Calibrate("CCD2");
//                        currentStep = CalibrationStep.Nozzle1Place;
//                        break;

//                    case CalibrationStep.Nozzle1Place:
//                        NozzleSystem.MoveUp("Nozzle-1");
//                        NozzleSystem.Place("Nozzle-1");
//                        currentStep = CalibrationStep.CCD1Trigger1;
//                        break;

//                    case CalibrationStep.CCD1Trigger1:
//                        VisionSystem.Trigger("CCD1");
//                        currentStep = CalibrationStep.Nozzle1Done;
//                        break;

//                    case CalibrationStep.Nozzle1Done:
//                        Console.WriteLine("Nozzle-1 calibration complete.");
//                        currentStep = CalibrationStep.Nozzle2Pick;
//                        break;

//                    case CalibrationStep.Nozzle2Pick:
//                        NozzleSystem.MoveDown("Nozzle-2");
//                        NozzleSystem.Pick("Nozzle-2");
//                        currentStep = CalibrationStep.CCD2Capture2;
//                        break;

//                    case CalibrationStep.CCD2Capture2:
//                        GantrySystem.MoveToPositions(11, "CCD2");
//                        currentStep = CalibrationStep.CCD2Calibrate2;
//                        break;

//                    case CalibrationStep.CCD2Calibrate2:
//                        VisionSystem.Calibrate("CCD2");
//                        currentStep = CalibrationStep.Nozzle2Place;
//                        break;

//                    case CalibrationStep.Nozzle2Place:
//                        NozzleSystem.MoveUp("Nozzle-2");
//                        NozzleSystem.Place("Nozzle-2");
//                        currentStep = CalibrationStep.CCD1Trigger2;
//                        break;

//                    case CalibrationStep.CCD1Trigger2:
//                        VisionSystem.Trigger("CCD1");
//                        currentStep = CalibrationStep.Nozzle2Done;
//                        break;

//                    case CalibrationStep.Nozzle2Done:
//                        Console.WriteLine("Nozzle-2 calibration complete.");
//                        currentStep = CalibrationStep.UnloadPlate;
//                        break;

//                    case CalibrationStep.UnloadPlate:
//                        Console.WriteLine("Move plate to unloading station & manually unload.");
//                        currentStep = CalibrationStep.PlacePlateConveyor1Again;
//                        break;
//                } } }


//        public async Task CCD3_calib()
//        {
//            CalibrationStep currentStep = CalibrationStep.Homing;

//            while (currentStep != CalibrationStep.Complete)
//            {
//                switch (currentStep)
//                {
//                    case CalibrationStep.PlacePlateConveyor1Again:
//                        if (await ConveyorSystem.EntryScanCnv())
//                        {
//                            if (await ConveyorSystem.DetectCarrierScanCnv())
//                            {
//                                currentStep = CalibrationStep.MoveToConveyor2;
//                                break;
//                            } 
//                        }
//                        else
//                            currentStep = CalibrationStep.PlacePlateConveyor1Again;
//                        break;
//                    case CalibrationStep.MoveToConveyor2:
//                        Cylinder_config.Cylinders_List[(int)Cylinder_config.Cylinders.Scan_Conv_Stopper_Cyl].Cylinder_Retract();
//                        Cylinder_config.Cylinders_List[(int)Cylinder_config.Cylinders.Work_Conv_1_Stopper_Cyl].Cylinder_Retract();
//                        Cylinder_config.Cylinders_List[(int)Cylinder_config.Cylinders.Work_Conv_2_Stopper_Cyl].Cylinder_Extend();
//                        currentStep = CalibrationStep.MoveToConveyor3;
//                        break;

//                    case CalibrationStep.MoveToConveyor3:
//                        ConveyorSystem.MovePlate(new bool?[] { true, true, true, true, true, true });
//                        currentStep = CalibrationStep.DetectPalletConveyor3;
//                        break;

//                    case CalibrationStep.DetectPalletConveyor3:
//                        if (GlobalVariable.DI[(int)EInput.Work_Conv_2_Pallet_Inplace_Sen])
//                        {
//                            ConveyorSystem.MovePlate(new bool?[] { false, false,false,false,false,false });
//                            Cylinder_config.Cylinders_List[(int)Cylinder_config.Cylinders.Scan_Conv_Stopper_Cyl].Cylinder_Extend();
//                            Cylinder_config.Cylinders_List[(int)Cylinder_config.Cylinders.Work_Conv_1_Stopper_Cyl].Cylinder_Extend();
//                        }
//                            currentStep = CalibrationStep.LiftPlateConveyor3;
//                        break;

//                    case CalibrationStep.LiftPlateConveyor3:
//                        {
//                            Cylinder_config.Cylinders_List[(int)Cylinder_config.Cylinders.Work_Conv_2_pallet_Lift_Cyl].Cylinder_Extend();
//                        }
//                        currentStep = CalibrationStep.PutMylarCCD3;
//                        break;

//                    case CalibrationStep.PutMylarCCD3:
//                        ShowMessageBox("Place The Mylar");
//                        currentStep = CalibrationStep.CCD3Capture;
//                        break;

//                    case CalibrationStep.CCD3Capture:
//                        await GantrySystem.LoadPosition();
//                        currentStep = CalibrationStep.CCD3GantryXY;
//                        break;

//                    case CalibrationStep.CCD3GantryXY:
//                        await GantrySystem.scan();
//                        currentStep = CalibrationStep.CCD3Calibrate;
//                        break;

//                    case CalibrationStep.CCD3Calibrate:
//                        VisionSystem.Calibrate("CCD3");
//                        currentStep = CalibrationStep.Complete;
//                        break;

//                    default:
//                        Console.WriteLine("Invalid step.");
//                        return;
//                }
//            }

//            //   Console.WriteLine(" Calibration Process Completed.");
       
//        }
//    }
//}

