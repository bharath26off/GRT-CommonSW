using Advantech;
using DynamicCylinders;
using DynamicVacuums;
using GRT_BG1.Data;
using Master;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DIO.DIDO;

namespace GRT_BG1.Function.Calibration
{


    public enum CalibrationStep
    {
        Homing,
        PlacePlateConveyor1,
        DetectCarrierConveyor1,
        MoveToConveyor2,
        StopConveyor2,
        DetectPalletConveyor2,
        LiftPlateConveyor2,
        StoppallServo,
        PutMylarCCD1,
        CCD1Capture,
        CCD1Calibrate,
        PutMylarAgain,
        Nozzle1Pick,
        CCD2Capture1,
        CCD2Calibrate1,
        Nozzle1Place,
        CCD1Trigger1,
        Nozzle1Done,
        Nozzle2Pick,
        CCD2Capture2,
        CCD2Calibrate2,
        Nozzle2Place,
        CCD1Trigger2,
        Nozzle2Done,
        UnloadPlate,
        PlacePlateConveyor1Again,
        MoveToConveyor3,
        DetectPalletConveyor3,
        LiftPlateConveyor3,
        PutMylarCCD3,
        CCD3Capture,
        CCD3GantryXY,
        CCD3Calibrate,
        Complete
    }

    // Simulated systems




    public class CalibrationController
    {
        public static int currentStepNozzle2 = 0;
        public static int currentStepNozzle1 = 0;
        public static int currentStepFinal = 0;
        VisionSystem camera = null;
        double x;
        double y;


        public async Task<bool> TrainNozzle(int nozzleno)
        {
            if (nozzleno == 1)
            {
                while (await move(GlobalVariable.TrainNozzle1))
                {
                    await Task.Delay(1000);
                    if (await Task.Run(() => NozzleSystem.Nozzle1MoveDown(GlobalVariable.TrainNozzle1)))
                    {
                    }
                    //ObjectList.Servo_R1.Move_Abs(Convert.ToDouble(GlobalVariable.TrainNozzle1.PositionR1), Convert.ToDouble(GlobalVariable.TrainNozzle1.RVel), Convert.ToDouble(GlobalVariable.TrainNozzle1.RAcc), Convert.ToDouble(GlobalVariable.TrainNozzle1.RDeAcc), 15000);
                    await GantrySystem.MoveR1(GlobalVariable.TrainNozzle1);
                   await Task.Delay(1000);
                        ObjectList.CCD1.Send("T10,1,"+GlobalVariable.TrainNozzle1.PositionX+","+ GlobalVariable.TrainNozzle1.PositionY+","+ GlobalVariable.TrainNozzle1.PositionR1);
                        await Task.Delay(1000);
                        if (await Task.Run(() => NozzleSystem.Nozzle1Moveup(GlobalVariable.TrainNozzle1)))
                        {
                            return true;
                        }
                    
                }

            }
            else
             if (nozzleno == 2)
            {
                while (await move(GlobalVariable.TrainNozzle2))
                {
                    await Task.Delay(1000);
                    if (await Task.Run(() => NozzleSystem.Nozzle2MoveDown(GlobalVariable.TrainNozzle2)))
                    { }
                    await GantrySystem.MoveR2(GlobalVariable.TrainNozzle2);
                   // ObjectList.Servo_R2.Move_Abs(Convert.ToDouble(GlobalVariable.TrainNozzle2.PositionR2), Convert.ToDouble(GlobalVariable.TrainNozzle2.RVel), Convert.ToDouble(GlobalVariable.TrainNozzle2.RAcc), Convert.ToDouble(GlobalVariable.TrainNozzle2.RDeAcc), 15000);

                    await Task.Delay(1000);
                        ObjectList.CCD1.Send("T10,2," + GlobalVariable.TrainNozzle2.PositionX + "," + GlobalVariable.TrainNozzle2.PositionY + "," + GlobalVariable.TrainNozzle2.PositionR2);
                    await Task.Delay(1000);
                        if (await Task.Run(() => NozzleSystem.Nozzle2Moveup(GlobalVariable.TrainNozzle2)))
                        {
                            return true;
                        }
                    
                }
            }

            return false;

        }

        public async Task Nozzle1_calib(double distance)
        {
            //CalibrationStep.Homing;
            // camera = new VisionSystem(GlobalVariable.WK1Positions);
            while (currentStepNozzle1 <= 120)
            {
                switch (currentStepNozzle1)
                {

                    case 0://CalibrationStep.PutMylarCCD1:
                        ShowMessageBox("Place The Mylar");
                        await move(GlobalVariable.Nozzle_loc_Z1, 0, 0);
                        currentStepNozzle1 = 10; // = CalibrationStep.CCD1Capture;
                        ObjectList.CCD1.Send("SC,3,1,1,11,5,1");
                        break;
                    case 10:
                        if (await move(GlobalVariable.Photo_Z1))
                        //ShowMessageBox("It reached Photo position");
                        {
                            //ObjectList.CCD1.Send("C3," + GlobalVariable.Photo_Z1.PositionX + "," + GlobalVariable.Photo_Z1.c + "," + GlobalVariable.Photo_Z1.PositionR1); 
                            ObjectList.CCD1.Send("C3," + GlobalVariable.pickup_loc_Z1.PositionX + "," + GlobalVariable.pickup_loc_Z1.PositionY + "," + GlobalVariable.pickup_loc_Z1.PositionR1);
                            await Task.Delay(1500);
                            currentStepNozzle1 = 20;
                        }
                        break;
                    case 20:

                        if (await move(GlobalVariable.pickup_loc_Z1))
                            // ShowMessageBox("it reach cavity position");
                            currentStepNozzle1 = 30;
                        break;
                    case 30:
                        ObjectList.Servo_R1.Move_Abs(Convert.ToDouble(GlobalVariable.pickup_loc_Z1.PositionR1), Convert.ToDouble(GlobalVariable.pickup_loc_Z1.RVel), Convert.ToDouble(GlobalVariable.pickup_loc_Z1.RAcc), Convert.ToDouble(GlobalVariable.pickup_loc_Z1.RDeAcc), 15000);
                        await Task.Delay(50);
                        if (await Task.Run(() => NozzleSystem.Nozzle1MoveDown(GlobalVariable.pickup_loc_Z1)))
                        {
                            Vacuum_config.Vacuums_List[(int)Vacuum_config.Vacuums.Vacuum1].Vacuum_On_without_Sense();
                            await Task.Delay(100);
                            if (await Task.Run(() => NozzleSystem.Nozzle1Moveup(GlobalVariable.pickup_loc_Z1)))
                            {
                                await Task.Delay(1000);
                                ObjectList.Servo_R1.Move_Abs(Convert.ToDouble(GlobalVariable.Nozzle_loc_Z1.PositionR1), Convert.ToDouble(GlobalVariable.Nozzle_loc_Z1.RVel), Convert.ToDouble(GlobalVariable.Nozzle_loc_Z1.RAcc), Convert.ToDouble(GlobalVariable.Nozzle_loc_Z1.RDeAcc), 15000);
                                currentStepNozzle1 = 40;
                            }
                        }
                        break;

                   
                   
                    case 40: //CalibrationStep.CCD1Calibrate:
                        x = Convert.ToDouble(GlobalVariable.Nozzle_loc_Z1.PositionX);
                        y = Convert.ToDouble(GlobalVariable.Nozzle_loc_Z1.PositionY);

                        if (await move(GlobalVariable.Nozzle_loc_Z1, x, y))
                            if (await Task.Run(() => NozzleSystem.Nozzle1MoveDown(GlobalVariable.Nozzle_loc_Z1)))
                                //ShowMessageBox("it reach calibration position");
                                currentStepNozzle1 = 50;  //CalibrationStep.Nozzle1Pick;
                        break;
                    case 50:
                        await moveDown(GlobalVariable.Nozzle_loc_Z1, x, y);// -48.48,-51.45
                        await Task.Delay(2000);
                        ObjectList.CCD1.Send("C1," + x + "," + y + "," + GlobalVariable.Nozzle_loc_Z1.PositionR1);//1   
                        await Task.Delay(2000);
                        y -= distance;
                        await moveDown(GlobalVariable.Nozzle_loc_Z1, x, y);// -48.48,-51.45
                        await Task.Delay(2000);
                        ObjectList.CCD1.Send("C1," + x + "," + y + "," + GlobalVariable.Nozzle_loc_Z1.PositionR1);//2
                        await Task.Delay(2000);
                        x-= distance;
                        await moveDown(GlobalVariable.Nozzle_loc_Z1, x, y);// -48.48,-51.45
                        await Task.Delay(2000);
                        ObjectList.CCD1.Send("C1," + x + "," + y + "," + GlobalVariable.Nozzle_loc_Z1.PositionR1);//3
                        await Task.Delay(2000);
                        y += distance;
                        await moveDown(GlobalVariable.Nozzle_loc_Z1, x, y);// -48.48,-51.45
                        await Task.Delay(2000);
                        ObjectList.CCD1.Send("C1," + x + "," + y + "," + GlobalVariable.Nozzle_loc_Z1.PositionR1);//4
                        await Task.Delay(2000);
                        y+= distance;
                        await moveDown(GlobalVariable.Nozzle_loc_Z1, x, y);// -48.48,-51.45
                        await Task.Delay(2000);
                        ObjectList.CCD1.Send("C1," + x + "," + y + "," + GlobalVariable.Nozzle_loc_Z1.PositionR1);//5
                        await Task.Delay(2000);
                        x += distance;
                        await moveDown(GlobalVariable.Nozzle_loc_Z1, x, y);// -48.48,-51.45
                        await Task.Delay(2000);
                        ObjectList.CCD1.Send("C1," + x + "," + y + "," + GlobalVariable.Nozzle_loc_Z1.PositionR1);//6
                        await Task.Delay(2000);
                        x += distance;
                        await moveDown(GlobalVariable.Nozzle_loc_Z1, x, y);// -48.48,-51.45
                        await Task.Delay(2000);
                        ObjectList.CCD1.Send("C1," + x + "," + y + "," + GlobalVariable.Nozzle_loc_Z1.PositionR1);//7
                        await Task.Delay(2000);
                        y -= distance;
                        await moveDown(GlobalVariable.Nozzle_loc_Z1, x, y);// -48.48,-51.45
                        await Task.Delay(2000);
                        ObjectList.CCD1.Send("C1," + x + "," + y + "," + GlobalVariable.Nozzle_loc_Z1.PositionR1);//8
                        await Task.Delay(2000);
                        y-= distance;
                        await moveDown(GlobalVariable.Nozzle_loc_Z1, x, y);// -48.48,-51.45
                        await Task.Delay(2000);
                        ObjectList.CCD1.Send("C1," + x + "," + y + "," + GlobalVariable.Nozzle_loc_Z1.PositionR1);//9
                        await Task.Delay(2000);
                        x -= distance;
                        y += distance;
                        await moveDown(GlobalVariable.Nozzle_loc_Z1, x, y);// -48.48,-51.45
                        await Task.Delay(2000);
                       
                        currentStepNozzle1 = 60;
                        break;
                    case 60:

                        await moveDown(GlobalVariable.Nozzle_loc_Z1, x, y);
                        ObjectList.Servo_R1.Move_Abs(Convert.ToDouble(15 + GlobalVariable.Nozzle_loc_Z1.PositionR1), Convert.ToDouble(GlobalVariable.Nozzle_loc_Z1.RVel), Convert.ToDouble(GlobalVariable.Nozzle_loc_Z1.RAcc), Convert.ToDouble(GlobalVariable.Nozzle_loc_Z1.RDeAcc), 15000);
                        await Task.Delay(2000);
                        ObjectList.CCD1.Send("C1," + x + "," + y + "," + Convert.ToDouble(15+GlobalVariable.Nozzle_loc_Z1.PositionR1));
                        await Task.Delay(2000);
                        currentStepNozzle1 = 70;
                        break;
                    case 70:

                        await moveDown(GlobalVariable.Nozzle_loc_Z1, x, y);
                        await Task.Delay(500);
                        ObjectList.Servo_R1.Move_Abs(Convert.ToDouble(-15 + GlobalVariable.Nozzle_loc_Z1.PositionR1), Convert.ToDouble(GlobalVariable.Nozzle_loc_Z1.RVel), Convert.ToDouble(GlobalVariable.Nozzle_loc_Z1.RAcc), Convert.ToDouble(GlobalVariable.Nozzle_loc_Z1.RDeAcc), 15000);
                        await Task.Delay(2000);
                        ObjectList.CCD1.Send("C1," + x + "," + y + "," + Convert.ToDouble(-15 + GlobalVariable.Nozzle_loc_Z1.PositionR1));
                        await Task.Delay(2000);
                        await Task.Run(() => NozzleSystem.Nozzle1Moveup(GlobalVariable.feddrop_loc_Z1));

                        currentStepNozzle1 = 80;

                        break;
                   
                    case 80:
                        ObjectList.Servo_R1.Move_Abs(Convert.ToDouble(GlobalVariable.feddrop_loc_Z1.PositionR1), Convert.ToDouble(GlobalVariable.feddrop_loc_Z1.RVel), Convert.ToDouble(GlobalVariable.feddrop_loc_Z1.RAcc), Convert.ToDouble(GlobalVariable.feddrop_loc_Z1.RDeAcc), 15000);
                        await Task.Delay(50);
                        if (await move(GlobalVariable.feddrop_loc_Z1))
                            //  ShowMessageBox("it reach feeder position");
                            currentStepNozzle1 = 90;
                        break;
                    case 90:
                        await Task.Delay(50);
                        if (await Task.Run(() => NozzleSystem.Nozzle1MoveDown(GlobalVariable.feddrop_loc_Z1)))
                        {
                            Vacuum_config.Vacuums_List[(int)Vacuum_config.Vacuums.Vacuum1].Both_Vacuum_and_Blow_Off();

                            await Task.Delay(500);
                            if (await Task.Run(() => NozzleSystem.Nozzle1Moveup(GlobalVariable.feddrop_loc_Z1)))
                            {
                                await Task.Delay(1000);
                                currentStepNozzle1 = 100;
                            }
                        }
                        break;
                  
                    case 100:
                        await Task.Delay(50);
                        await move(GlobalVariable.Nozzle_loc_Z1, 0, 0);
                        //  ShowMessageBox("it reach home position");
                        currentStepNozzle1 = 120;
                        break;
                    case 120:
                        ObjectList.CCD1.Send("C5," + GlobalVariable.feddrop_loc_Z1.PositionX + "," + GlobalVariable.feddrop_loc_Z1.PositionY + "," + GlobalVariable.feddrop_loc_Z1.PositionR1);
                        //ObjectList.CCD1.Send("C5," + GlobalVariable.feddrop_loc_Z1.PositionX + "," + GlobalVariable.feddrop_loc_Z1.PositionY + ",0");
                        await Task.Delay(5000);
                        ObjectList.CCD1.Send("SET,1," + GlobalVariable.Photo_Z1.PositionX + "," + GlobalVariable.Photo_Z1.PositionY + ",0");//+ GlobalVariable.Photo_Z1.PositionR1);
                       await Task.Delay(5000);
                        await Task.Delay(5000);



                        ObjectList.CCD1.Send("EC");

                        currentStepNozzle1 = 1000;
                        break;
                }
            }
        }

        public async Task<bool> moveDown(Position p, double? x = null, double? y = null)  // AK
        {


            if (x == null && y == null)
            {
                Task T3 = Task.Run(async () => ObjectList.Servo_X1.Move_Abs(Convert.ToDouble(p.PositionX), Convert.ToDouble(p.XVel), Convert.ToDouble(p.XAcc), Convert.ToDouble(p.XDeAcc), 20000));

                Task T4 = Task.Run(async () => ObjectList.Servo_Y1.Move_Abs(Convert.ToDouble(p.PositionY), Convert.ToDouble(p.YVel), Convert.ToDouble(p.YAcc), Convert.ToDouble(p.YDeAcc), 20000));
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
                await Task.WhenAll(T3, T4);
                double currectpospick;
                double currectvelpick;
                string currentstatupick;
                ObjectList.Servo_X1.GetCurrentPos(out currectpospick, out currentstatupick, out currectvelpick);
                if (x == currectpospick)
                {
                    ObjectList.Servo_Y1.GetCurrentPos(out currectpospick, out currentstatupick, out currectvelpick);
                    if (y == currectpospick)
                    {
                        return true;
                    }
                }
                return false;

            }

        }

        public async Task<bool> move(Position p, double? x = null, double? y = null)
       {
            if (NozzleSystem.Nozzle2Moveup(GlobalVariable.SafePosition))
            {
                if (NozzleSystem.Nozzle1Moveup(GlobalVariable.SafePosition))
                {
                    if (x == null && y == null)
                    {
                        Task T3 = Task.Run(async () => ObjectList.Servo_X1.Move_Abs(Convert.ToDouble(p.PositionX), Convert.ToDouble(p.XVel), Convert.ToDouble(p.XAcc), Convert.ToDouble(p.XDeAcc), 20000));

                        Task T4 = Task.Run(async () => ObjectList.Servo_Y1.Move_Abs(Convert.ToDouble(p.PositionY), Convert.ToDouble(p.YVel), Convert.ToDouble(p.YAcc), Convert.ToDouble(p.YDeAcc), 20000));
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
                        await Task.WhenAll(T3, T4);
                        double currectpospick;
                        double currectvelpick;
                        string currentstatupick;
                        ObjectList.Servo_X1.GetCurrentPos(out currectpospick, out currentstatupick, out currectvelpick);
                        if (x == currectpospick)
                        {
                            ObjectList.Servo_Y1.GetCurrentPos(out currectpospick, out currentstatupick, out currectvelpick);
                            if (y == currectpospick)
                            {
                                return true;
                            }
                        }
                        return false;

                    }
                }
            }
            return false;
           
        }

        public async Task X2Y2move(Position p)
        {


            Task T3 = Task.Run(async () => ObjectList.Servo_X2.Move_Abs(Convert.ToDouble(p.PositionX), Convert.ToDouble(p.XVel), Convert.ToDouble(p.XAcc), Convert.ToDouble(p.XDeAcc), 15000));

            Task T4 = Task.Run(async () => ObjectList.Servo_Y2.Move_Abs(Convert.ToDouble(p.PositionY), Convert.ToDouble(p.YVel), Convert.ToDouble(p.YAcc), Convert.ToDouble(p.YDeAcc), 10000));
            await Task.WhenAll(T3, T4);




        }
        public async Task Nozzle2_calib(double distance)
        {
            //CalibrationStep.Homing;
            // camera = new VisionSystem(GlobalVariable.WK1Positions);
            while (currentStepNozzle2 <= 120)
            {
                switch (currentStepNozzle2)
                {


                    case 0://CalibrationStep.PutMylarCCD1:
                        ShowMessageBox("Place The Mylar");
                        await move(GlobalVariable.Nozzle_loc_Z2, 0, 0);
                        currentStepNozzle2 = 10; // = CalibrationStep.CCD1Capture;
                        ObjectList.CCD1.Send("SC,4,1,2,11,6,1");
                        break;
                    case 10:
                        if (await move(GlobalVariable.Photo_z2))
                        //ShowMessageBox("It reached Photo position");
                        {
                            ObjectList.CCD1.Send("C4," + GlobalVariable.pickup_loc_Z2.PositionX + "," + GlobalVariable.pickup_loc_Z2.PositionY + ","+ GlobalVariable.pickup_loc_Z2.PositionR2);
                            await Task.Delay(1500);
                            currentStepNozzle2 = 20;
                        }
                        break;
                    case 20:

                        if (await move(GlobalVariable.pickup_loc_Z2))
                            // ShowMessageBox("it reach cavity position");
                            currentStepNozzle2 = 30;
                        break;
                    case 30:
                        ObjectList.Servo_R2.Move_Abs(Convert.ToDouble(GlobalVariable.pickup_loc_Z2.PositionR2), Convert.ToDouble(GlobalVariable.pickup_loc_Z2.RVel), Convert.ToDouble(GlobalVariable.pickup_loc_Z2.RAcc), Convert.ToDouble(GlobalVariable.pickup_loc_Z2.RDeAcc), 15000);
                        await Task.Delay(50);
                        if (await Task.Run(() => NozzleSystem.Nozzle2MoveDown(GlobalVariable.pickup_loc_Z2)))
                        {
                            Vacuum_config.Vacuums_List[(int)Vacuum_config.Vacuums.Vacuum2].Vacuum_On_without_Sense();

                            await Task.Delay(50);
                            if (await Task.Run(() => NozzleSystem.Nozzle2Moveup(GlobalVariable.pickup_loc_Z2)))
                            {
                                await Task.Delay(1000);
                                ObjectList.Servo_R2.Move_Abs(Convert.ToDouble(GlobalVariable.Nozzle_loc_Z2.PositionR2), Convert.ToDouble(GlobalVariable.Nozzle_loc_Z2.RVel), Convert.ToDouble(GlobalVariable.Nozzle_loc_Z2.RAcc), Convert.ToDouble(GlobalVariable.Nozzle_loc_Z2.RDeAcc), 15000);

                                currentStepNozzle2 = 40;
                            }
                        }

                        break;
                    case 40: //CalibrationStep.CCD1Calibrate:
                        x = Convert.ToDouble(GlobalVariable.Nozzle_loc_Z2.PositionX);
                        y = Convert.ToDouble(GlobalVariable.Nozzle_loc_Z2.PositionY);

                        if (await move(GlobalVariable.Nozzle_loc_Z2, x, y))
                            if (await Task.Run(() => NozzleSystem.Nozzle2MoveDown(GlobalVariable.Nozzle_loc_Z2)))
                                //ShowMessageBox("it reach calibration position");
                                currentStepNozzle2 = 50;  //CalibrationStep.Nozzle1Pick;
                        break;
                    case 50:
                        // y -= distance;
                        await moveDown(GlobalVariable.Nozzle_loc_Z2, x, y);//-48.48,-51.45
                        await Task.Delay(2000);
                        ObjectList.CCD1.Send("C2," + x + "," + y + "," + GlobalVariable.Nozzle_loc_Z2.PositionR2);//1   
                        await Task.Delay(2000);
                        y -= distance;
                        await moveDown(GlobalVariable.Nozzle_loc_Z2, x, y);// -48.48,-51.45
                        await Task.Delay(2000);
                        ObjectList.CCD1.Send("C2," + x + "," + y + "," + GlobalVariable.Nozzle_loc_Z2.PositionR2);//2
                        await Task.Delay(2000);
                        x -= distance;
                        await moveDown(GlobalVariable.Nozzle_loc_Z2, x, y);// -48.48,-51.45
                        await Task.Delay(2000);
                        ObjectList.CCD1.Send("C2," + x + "," + y + "," + GlobalVariable.Nozzle_loc_Z2.PositionR2);//3
                        await Task.Delay(2000);
                        y += distance;
                        await moveDown(GlobalVariable.Nozzle_loc_Z2, x, y);// -48.48,-51.45
                        await Task.Delay(2000);
                        ObjectList.CCD1.Send("C2," + x + "," + y + "," + GlobalVariable.Nozzle_loc_Z2.PositionR2);//4
                        await Task.Delay(2000);
                        y += distance;
                        await moveDown(GlobalVariable.Nozzle_loc_Z2, x, y);//-43.48,-46.45
                        await Task.Delay(2000);
                        ObjectList.CCD1.Send("C2," + x + "," + y + "," + GlobalVariable.Nozzle_loc_Z2.PositionR2);//5
                        await Task.Delay(2000);
                        x += distance;
                        await moveDown(GlobalVariable.Nozzle_loc_Z2, x, y);//-48.48,-46.45
                        await Task.Delay(2000);
                        ObjectList.CCD1.Send("C2," + x + "," + y + "," + GlobalVariable.Nozzle_loc_Z2.PositionR2);//6
                        await Task.Delay(2000);
                        x += distance;
                        await moveDown(GlobalVariable.Nozzle_loc_Z2, x, y);//-53.48,-46.45
                        await Task.Delay(2000);
                        ObjectList.CCD1.Send("C2," + x + "," + y + "," + GlobalVariable.Nozzle_loc_Z2.PositionR2);//7
                        await Task.Delay(2000);
                        y -= distance;
                        await moveDown(GlobalVariable.Nozzle_loc_Z2, x, y);//-53.48,-53.45
                        await Task.Delay(2000);
                        ObjectList.CCD1.Send("C2," + x + "," + y + "," + GlobalVariable.Nozzle_loc_Z2.PositionR2);//8
                        await Task.Delay(2000);
                        y -= distance;
                        //x = Convert.ToDouble(GlobalVariable.Nozzle_loc_Z2.PositionX);
                        //y = Convert.ToDouble(GlobalVariable.Nozzle_loc_Z2.PositionY);
                        await moveDown(GlobalVariable.Nozzle_loc_Z2, x, y);//-53.48,-58.45
                        await Task.Delay(2000);
                        ObjectList.CCD1.Send("C2," + x + "," + y + "," + GlobalVariable.Nozzle_loc_Z2.PositionR2);//9
                        await Task.Delay(2000);
                        x -= distance;
                        y += distance;
                        await moveDown(GlobalVariable.Nozzle_loc_Z2, x, y);//-7.76,-66.7
                        await Task.Delay(2000);
                        currentStepNozzle2 = 60;
                        break;
                    case 60:

                        await moveDown(GlobalVariable.Nozzle_loc_Z2, x, y);
                        ObjectList.Servo_R2.Move_Abs(Convert.ToDouble(15 + GlobalVariable.Nozzle_loc_Z2.PositionR2), Convert.ToDouble(GlobalVariable.Nozzle_loc_Z2.RVel), Convert.ToDouble(GlobalVariable.Nozzle_loc_Z2.RAcc), Convert.ToDouble(GlobalVariable.Nozzle_loc_Z2.RDeAcc), 15000);
                        await Task.Delay(2000);
                        ObjectList.CCD1.Send("C2," + x + "," + y + "," + Convert.ToDouble(15 + GlobalVariable.Nozzle_loc_Z2.PositionR2));
                        await Task.Delay(2000);
                        currentStepNozzle2 = 70;
                        break;
                    case 70:

                        await moveDown(GlobalVariable.Nozzle_loc_Z2, x, y);
                        await Task.Delay(500);
                        ObjectList.Servo_R2.Move_Abs(Convert.ToDouble(-15 + GlobalVariable.Nozzle_loc_Z2.PositionR2), Convert.ToDouble(GlobalVariable.Nozzle_loc_Z2.RVel), Convert.ToDouble(GlobalVariable.Nozzle_loc_Z2.RAcc), Convert.ToDouble(GlobalVariable.Nozzle_loc_Z2.RDeAcc), 15000);
                        await Task.Delay(2000);
                        ObjectList.CCD1.Send("C2," + x + "," + y + "," + Convert.ToDouble(-15 + GlobalVariable.Nozzle_loc_Z2.PositionR2));
                        await Task.Delay(2000);
                        await Task.Run(() => NozzleSystem.Nozzle2Moveup(GlobalVariable.feddrop_loc_Z2));

                        currentStepNozzle2 = 80;

                        break;

                    case 80:
                        ObjectList.Servo_R2.Move_Abs(Convert.ToDouble(GlobalVariable.feddrop_loc_Z2.PositionR2), Convert.ToDouble(GlobalVariable.Nozzle_loc_Z2.RVel), Convert.ToDouble(GlobalVariable.feddrop_loc_Z2.RAcc), Convert.ToDouble(GlobalVariable.feddrop_loc_Z2.RDeAcc), 15000);
                        await Task.Delay(50);
                        if (await move(GlobalVariable.feddrop_loc_Z2))
                            //  ShowMessageBox("it reach feeder position");
                            currentStepNozzle2 = 90;
                        break;
                    case 90:
                        await Task.Delay(50);
                        if (await Task.Run(() => NozzleSystem.Nozzle2MoveDown(GlobalVariable.feddrop_loc_Z2)))
                        {
                            Vacuum_config.Vacuums_List[(int)Vacuum_config.Vacuums.Vacuum2].Both_Vacuum_and_Blow_Off();

                            await Task.Delay(50);
                            if (await Task.Run(() => NozzleSystem.Nozzle2Moveup(GlobalVariable.feddrop_loc_Z2)))
                            {
                                await Task.Delay(1000);
                                currentStepNozzle2 = 100;
                            }
                        }
                        break;
                
                    case 100:
                        await Task.Delay(50);
                        await move(GlobalVariable.Nozzle_loc_Z2, 0, 0);
                        //  ShowMessageBox("it reach home position");
                        currentStepNozzle2 = 110;
                        break;
                    case 110:
                        ObjectList.CCD1.Send("C6," + GlobalVariable.feddrop_loc_Z2.PositionX + "," + GlobalVariable.feddrop_loc_Z2.PositionY + "," + GlobalVariable.feddrop_loc_Z2.PositionR2);
                        await Task.Delay(5000);
                        ObjectList.CCD1.Send("SET,2," + GlobalVariable.Photo_z2.PositionX + "," + GlobalVariable.Photo_z2.PositionY + ",0");// + GlobalVariable.Photo_z2.PositionR2);
                        await Task.Delay(5000);
                        await Task.Delay(5000);
                        ObjectList.CCD1.Send("EC");

                        currentStepNozzle2 = 1000;
                        break;

                }
            }
        }


        public async Task X2Y2Final()
        {
            currentStepFinal = 0;
            while (currentStepFinal <= 120)
            {
                switch (currentStepFinal)
                {

                    case 0:
                        ShowMessageBox("Place The Mylar");
                        ObjectList.CCD1.Send("SC,7,12");
                        await X2Y2move(GlobalVariable.Wk2CalibPositions[0, 0]);
                        await Task.Delay(1000);
                        ObjectList.CCD1.Send("C7," + GlobalVariable.Wk2CalibPositions[0, 0].PositionX + "," + GlobalVariable.Wk2CalibPositions[0, 0].PositionY + ",1");
                        await Task.Delay(2000);
                        currentStepFinal = 10;
                        break;
                    case 10:
                        await X2Y2move(GlobalVariable.Wk2CalibPositions[0, 1]);
                        await Task.Delay(1000);
                        ObjectList.CCD1.Send("C7," + GlobalVariable.Wk2CalibPositions[0, 1].PositionX + "," + GlobalVariable.Wk2CalibPositions[0, 1].PositionY + ",1");
                        await Task.Delay(2000);
                        currentStepFinal = 20;
                        break;
                    case 20:
                        await X2Y2move(GlobalVariable.Wk2CalibPositions[0, 2]);
                        await Task.Delay(1000);
                        ObjectList.CCD1.Send("C7," + GlobalVariable.Wk2CalibPositions[0, 2].PositionX + "," + GlobalVariable.Wk2CalibPositions[0, 2].PositionY + ",1");
                        await Task.Delay(2000);
                        currentStepFinal = 30;
                        break;
                    case 30:
                        await X2Y2move(GlobalVariable.Wk2CalibPositions[1, 2]);
                        await Task.Delay(1000);
                        ObjectList.CCD1.Send("C7," + GlobalVariable.Wk2CalibPositions[1, 2].PositionX + "," + GlobalVariable.Wk2CalibPositions[1, 2].PositionY + ",1");
                        await Task.Delay(2000);
                        currentStepFinal = 40;
                        break;
                    case 40:
                        await X2Y2move(GlobalVariable.Wk2CalibPositions[1, 1]);
                        await Task.Delay(1000);
                        ObjectList.CCD1.Send("C7," + GlobalVariable.Wk2CalibPositions[1, 1].PositionX + "," + GlobalVariable.Wk2CalibPositions[1, 1].PositionY + ",1");
                        await Task.Delay(2000);
                        currentStepFinal = 50;
                        break;
                    case 50:
                        await X2Y2move(GlobalVariable.Wk2CalibPositions[1, 0]);
                        await Task.Delay(1000);
                        ObjectList.CCD1.Send("C7," + GlobalVariable.Wk2CalibPositions[1, 0].PositionX + "," + GlobalVariable.Wk2CalibPositions[1, 0].PositionY + ",1");
                        await Task.Delay(2000);
                        currentStepFinal = 60;
                        break;
                    case 60:
                        await X2Y2move(GlobalVariable.Wk2CalibPositions[2, 0]);
                        await Task.Delay(1000);
                        ObjectList.CCD1.Send("C7," + GlobalVariable.Wk2CalibPositions[2, 0].PositionX + "," + GlobalVariable.Wk2CalibPositions[2, 0].PositionY + ",1");
                        await Task.Delay(2000);
                        currentStepFinal = 70;
                        break;
                    case 70:
                        await X2Y2move(GlobalVariable.Wk2CalibPositions[2, 1]);
                        await Task.Delay(1000);
                        ObjectList.CCD1.Send("C7," + GlobalVariable.Wk2CalibPositions[2, 1].PositionX + "," + GlobalVariable.Wk2CalibPositions[2, 1].PositionY + ",1");
                        await Task.Delay(2000);
                        currentStepFinal = 80;
                        break;
                    case 80:
                        await X2Y2move(GlobalVariable.Wk2CalibPositions[2, 2]);
                        await Task.Delay(1000);
                        ObjectList.CCD1.Send("C7," + GlobalVariable.Wk2CalibPositions[2, 2].PositionX + "," + GlobalVariable.Wk2CalibPositions[2, 2].PositionY + ",1");
                        await Task.Delay(2000);
                        currentStepFinal = 90;
                        break;
                    case 90:
                        await X2Y2move(GlobalVariable.Wk2CalibPositions[3, 2]);
                        await Task.Delay(1000);
                        ObjectList.CCD1.Send("C7," + GlobalVariable.Wk2CalibPositions[3, 2].PositionX + "," + GlobalVariable.Wk2CalibPositions[3, 2].PositionY + ",1");
                        await Task.Delay(2000);
                        currentStepFinal = 100;
                        break;
                    case 100:
                        await X2Y2move(GlobalVariable.Wk2CalibPositions[3, 1]);
                        await Task.Delay(1000);
                        ObjectList.CCD1.Send("C7," + GlobalVariable.Wk2CalibPositions[3, 1].PositionX + "," + GlobalVariable.Wk2CalibPositions[3, 1].PositionY + ",1");
                        await Task.Delay(2000);
                        currentStepFinal = 110;
                        break;
                    case 110:
                        await X2Y2move(GlobalVariable.Wk2CalibPositions[3, 0]);
                        await Task.Delay(1000);
                        ObjectList.CCD1.Send("C7," + GlobalVariable.Wk2CalibPositions[3, 0].PositionX + "," + GlobalVariable.Wk2CalibPositions[3, 0].PositionY + ",1");
                        await Task.Delay(2000);
                        currentStepFinal = 140;
                        await Task.Delay(1000);
                        ObjectList.CCD1.Send("EC");
                        break;

                }
            }
        }


    }
}
