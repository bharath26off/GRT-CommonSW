using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using ExceptionLib;
using MasterProject;
using MasterProject.GlobalClass;

namespace Advantech
{
    public class ServoSequense
    {

        bool threadlock1 = false;
        bool threadlock2 = false;
        public static System.Threading.Timer Streamline_1 = null;
        int step1 = 1;
        int step2 = 1;
        private static ServoSequense instance = null;
        private static object locker = new object();

        double position = 0;
        double acc = 0;
        double deacc = 0;
        double speed =0;

        
        public static ServoSequense GetServoSequenceObj
        {
            get
            {
                if (instance == null)
                {
                    lock (locker)
                    {
                        if (instance == null)
                        {
                            instance = new ServoSequense();
                            //  instance.Avlbldvc();
                        }
                    }
                }
                return instance;
            }
        }
        public void Pause_Thread()
        {
            try
            {
                ObjectList.X1.PauseAxis();
                ObjectList.X2.PauseAxis();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Resume_Thread()
        {
            try
            {
                ObjectList.X1.ResumeAxis();
                ObjectList.X2.ResumeAxis();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void stop_Thread()
        {
            try
            {
                ObjectList.X1.Stop();
                ObjectList.X2.Stop();
            }
            catch (Exception)
            {

                throw;
            }
        }
        public void start_Thread(double posi, double Speed1, double acce, double deacce)
        {
            position = posi;
            acc = acce;
            deacc = deacce;
            speed = Speed1;
            //step1 = 1;
            //step2 = 1;
            Streamline_1 = new System.Threading.Timer(new TimerCallback(TimerCallback1), null, 200, 100);
        }

        public void TimerCallback1(object sender)
        {
            _ = TimerCallbackAutoSequence();
        }

        public async Task TimerCallbackAutoSequence()
        {
            var task1 = AutoSequence4ServoX1();
            var task2 = AutoSequence4ServoX2();
            await Task.WhenAll(task1, task2);
        }

        public async Task AutoSequence4ServoX1()
        {
            try

            {
                int errorcnt = 1;
                if (!threadlock1)
                {
                    await Task.Delay(1000);
                    threadlock1 = true;
                    switch (step1)
                    {
                        case 1:                        
                            #region Interlock
                            if (!ObjectList.globalblock)
                            #endregion
                            {
                                Task<bool> Log_task = Logger.WriteLogasTask(Logger.LogType.Running,"ServoSequense", "AutoSequence4ServoX1",  "", "Case 1 Move Abs Servo 1");
                                #region Action
                                if (ObjectList.X1.Move_Abs(position, speed, acc, deacc,50000))
                                #endregion
                                {
                                    #region TimedelayFor Sensor
                                    Task.Delay(1000);
                                    #endregion
                                    #region Sensor Feedback
                                    //Sensor feedback not needed here
                                    if (true)// Readin Sensor feedback here or keep true by default
                                    {
                                        #region TimedelayFor Action
                                        Task.Delay(1000);
                                        #endregion
                                        #region NextCase
                                        step1 = 1;
                                        goto case 2;
                                        #endregion
                                    }
                                    else
                                    {
                                        #region Sensor Feedback Error
                                        //Provid Alarm or error Message
                                        GlobalVariable.ShowAlarmMessage(01, "Case 1 Sensor Feedback Error");
                                        #endregion
                                    }
                                    #endregion
                                }
                                else
                                {
                                    #region FeedBack Retry
                                    if (errorcnt <= 3)
                                    {
                                        errorcnt = errorcnt + 1;
                                        step1 = 1;
                                        goto case 1;
                                    }
                                    else
                                    {
                                        errorcnt = 1;
                                    }
                                    #endregion
                                }
                            }
                            break;
                        case 2:
                            #region Interlock
                            if (!ObjectList.globalblock)
                            #endregion
                            {
                                //MessageBox.Show("Case 3 Move Rel Servo 1");
                                Task<bool> Log_task = Logger.WriteLogasTask(Logger.LogType.Running, "ServoSequense", "AutoSequence4ServoX1", "", "Case 2 Move Rel Servo 1");
                                #region Action
                                if (ObjectList.X1.Move_Rel(position, speed, acc, deacc,5000))
                                #endregion
                                {
                                    #region TimedelayFor Sensor
                                    Task.Delay(1000);
                                    #endregion
                                    #region Sensor Feedback
                                    //Sensor feedback not needed here
                                    if (true)// Readin Sensor feedback here or keep true by default
                                    {
                                        #region TimedelayFor Action
                                        Task.Delay(1000);
                                        #endregion
                                        #region NextCase
                                        step1 = 3;
                                        goto case 3;
                                        #endregion
                                    }
                                    else
                                    {
                                        #region Sensor Feedback Error
                                        //Provid Alarm or error Message
                                        GlobalVariable.ShowAlarmMessage(02, "Case 2 Sensor Feedback Error");
                                        #endregion
                                    }
                                    #endregion
                                }
                                else
                                {
                                    #region FeedBack Retry
                                    if (errorcnt <= 3)
                                    {
                                        errorcnt = errorcnt + 1;
                                        step1 = 2;
                                        goto case 2;
                                    }
                                    else
                                    {
                                        errorcnt = 1;
                                    }
                                    #endregion
                                }
                            }
                            break;
                        case 3:
                            #region Interlock
                            if (!ObjectList.globalblock)
                            #endregion
                            {
                                Task<bool> Log_task = Logger.WriteLogasTask(Logger.LogType.Running, "ServoSequense", "AutoSequence4ServoX1", "", "Case 3 Homming Servo 1");
                                MessageBox.Show("Case 5 Homming Servo 1");
                                #region Action
                                if (ObjectList.X1.Homing(1))
                                #endregion
                                {
                                    #region TimedelayFor Sensor
                                    Task.Delay(1000);
                                    #endregion
                                    #region Sensor Feedback
                                    //Sensor feedback not needed here
                                    if (true)// Readin Sensor feedback here or keep true by default
                                    {
                                        #region TimedelayFor Action
                                        Task.Delay(1000);
                                        #endregion
                                        #region NextCase
                                        step1 = 4;
                                        goto case 4;
                                        #endregion
                                    }
                                    else
                                    {
                                        #region Sensor Feedback Error
                                        //Provid Alarm or error Message
                                        GlobalVariable.ShowAlarmMessage(03, "Case 3 Sensor Feedback Error");
                                        #endregion
                                    }
                                    #endregion
                                }
                                else
                                {
                                    #region FeedBack Retry
                                    if (errorcnt <= 3)
                                    {
                                        errorcnt = errorcnt + 1;
                                        step1 = 3;
                                        goto case 3;
                                    }
                                    else
                                    {
                                        errorcnt = 1;
                                    }
                                    #endregion
                                }
                            }
                            break;
                        case 4:
                            #region Interlock
                            if (!ObjectList.globalblock)
                            #endregion
                            {
                                Task<bool> Log_task = Logger.WriteLogasTask(Logger.LogType.Running, "ServoSequense", "AutoSequence4ServoX1", "", "Case 4 Jog Reverwse Servo 1");
                                #region Action
                                if (ObjectList.X1.Jog(1, 10, 10, 10))
                                #endregion
                                {
                                    #region TimedelayFor Sensor
                                    Task.Delay(1000);
                                    #endregion
                                    #region Sensor Feedback
                                    //Sensor feedback not needed here
                                    if (true)// Readin Sensor feedback here or keep true by default
                                    {
                                        #region TimedelayFor Action
                                        Task.Delay(1000);
                                        #endregion
                                        #region NextCase
                                        step1 = 5;
                                        goto case 5;
                                        #endregion
                                    }
                                    else
                                    {
                                        #region Sensor Feedback Error
                                        //Provid Alarm or error Message
                                        GlobalVariable.ShowAlarmMessage(04, "Case 4 Sensor Feedback Error");
                                        #endregion
                                    }
                                    #endregion
                                }
                                else
                                {
                                    #region FeedBack Retry
                                    if (errorcnt <= 3)
                                    {
                                        errorcnt = errorcnt + 1;
                                        step1 = 4;
                                        goto case 4;
                                    }
                                    else
                                    {
                                        errorcnt = 1;
                                    }
                                    #endregion
                                }
                            }
                            break;
                        case 5:
                            #region Interlock
                            if (!ObjectList.globalblock)
                            #endregion
                            {
                                Task<bool> Log_task = Logger.WriteLogasTask(Logger.LogType.Running, "ServoSequense", "AutoSequence4ServoX1", "", "Case 5 Jog Forward Servo 1");
                                #region Action
                                if (ObjectList.X1.Jog(0, 10, 10, 10))
                                #endregion
                                {
                                    #region TimedelayFor Sensor
                                    Task.Delay(1000);
                                    #endregion
                                    #region Sensor Feedback
                                    //Sensor feedback not needed here
                                    if (true)// Readin Sensor feedback here or keep true by default
                                    {
                                        #region TimedelayFor Action
                                        Task.Delay(1000);
                                        #endregion
                                        #region NextCase
                                        step1 = 6;
                                        goto case 6;
                                        #endregion
                                    }
                                    else
                                    {
                                        #region Sensor Feedback Error
                                        //Provid Alarm or error Message
                                        GlobalVariable.ShowAlarmMessage(05, "Case 5 Sensor Feedback Error");
                                        #endregion
                                    }
                                    #endregion
                                }
                                else
                                {
                                    #region FeedBack Retry
                                    if (errorcnt <= 3)
                                    {
                                        errorcnt = errorcnt + 1;
                                        step1 = 5;
                                        goto case 5;
                                    }
                                    else
                                    {
                                        errorcnt = 1;
                                    }
                                    #endregion
                                }
                            }
                            break;
                        
                        case 6:
                            #region Interlock
                            if (!ObjectList.globalblock)
                            #endregion
                            {
                                Task<bool> Log_task = Logger.WriteLogasTask(Logger.LogType.Running, "ServoSequense", "AutoSequence4ServoX1", "", "Case 6 stop Servo 1");
                                #region Action
                                if (ObjectList.X1.Stop())
                                #endregion
                                {
                                    #region TimedelayFor Sensor
                                    Task.Delay(1000);
                                    #endregion
                                    #region Sensor Feedback
                                    //Sensor feedback not needed here
                                    if (true)// Readin Sensor feedback here or keep true by default
                                    {
                                        #region TimedelayFor Action
                                        Task.Delay(1000);
                                        #endregion
                                        #region NextCase
                                        step1 = 7;
                                        goto case 7;
                                        #endregion
                                    }
                                    else
                                    {
                                        #region Sensor Feedback Error
                                        //Provid Alarm or error Message
                                        GlobalVariable.ShowAlarmMessage(06, "Case 6 Sensor Feedback Error");
                                        #endregion
                                    }
                                    #endregion
                                }
                                else
                                {
                                    #region FeedBack Retry
                                    if (errorcnt <= 3)
                                    {
                                        errorcnt = errorcnt + 1;
                                        step1 = 6;
                                        goto case 6;
                                    }
                                    else
                                    {
                                        errorcnt = 1;
                                    }
                                    #endregion
                                }
                            }
                            break;
                        case 7:
                            #region Interlock
                            if (!ObjectList.globalblock)
                            #endregion
                            {
                                Task<bool> Log_task = Logger.WriteLogasTask(Logger.LogType.Running, "ServoSequense", "AutoSequence4ServoX1", "", "Case 6 Off Servo 1");
                                #region Action
                                if (ObjectList.X1.ServoOFF())
                                #endregion
                                {
                                    #region TimedelayFor Sensor
                                    Task.Delay(1000);
                                    #endregion
                                    #region Sensor Feedback
                                    //Sensor feedback not needed here
                                    if (true)// Readin Sensor feedback here or keep true by default
                                    {
                                        #region TimedelayFor Action
                                        Task.Delay(1000);
                                        #endregion
                                        #region NextCase
                                        step1 = 8;
                                        goto case 8;
                                        #endregion
                                    }
                                    else
                                    {
                                        #region Sensor Feedback Error
                                        //Provid Alarm or error Message
                                        GlobalVariable.ShowAlarmMessage(07, "Case 7 Sensor Feedback Error");
                                        #endregion
                                    }
                                    #endregion
                                }
                                else
                                {
                                    #region FeedBack Retry
                                    if (errorcnt <= 3)
                                    {
                                        errorcnt = errorcnt + 1;
                                        step1 = 6;
                                        goto case 7;
                                    }
                                    else
                                    {
                                        errorcnt = 1;
                                    }
                                    #endregion
                                }
                            }
                            break;
                        case 8:
                            #region Interlock
                            if (!ObjectList.globalblock)
                            #endregion
                            {
                                Task<bool> Log_task = Logger.WriteLogasTask(Logger.LogType.Running, "ServoSequense", "AutoSequence4ServoX1", "", "Case 6 Onn Servo 1");
                                #region Action
                                if (ObjectList.X1.ServoOn(true))
                                #endregion
                                {
                                    #region TimedelayFor Sensor
                                    Task.Delay(1000);
                                    #endregion
                                    #region Sensor Feedback
                                    //Sensor feedback not needed here
                                    if (true)// Readin Sensor feedback here or keep true by default
                                    {
                                        #region TimedelayFor Action
                                        Task.Delay(1000);
                                        #endregion
                                        #region NextCase
                                        step1 = 1;
                                        goto case 1;
                                        #endregion
                                    }
                                    else
                                    {
                                        #region Sensor Feedback Error
                                        //Provid Alarm or error Message
                                        GlobalVariable.ShowAlarmMessage(08, "Case 8 Sensor Feedback Error");
                                        #endregion
                                    }
                                    #endregion
                                }
                                else
                                {
                                    #region FeedBack Retry
                                    if (errorcnt <= 3)
                                    {
                                        errorcnt = errorcnt + 1;
                                        step1 = 8;
                                        goto case 8;
                                    }
                                    else
                                    {
                                        errorcnt = 1;
                                    }
                                    #endregion
                                }
                            }
                            break;
                        default:
                            break;
                    }
                    threadlock1=false;
                }


            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task AutoSequence4ServoX2()
        {
            try

            {
                int errorcnt = 1;
                if (!threadlock2)
                {
                    threadlock2 = true;
                    await Task.Delay(1000);
                    switch (step2)
                    {
                        case 1:
                            #region Interlock
                            if (!ObjectList.globalblock)
                            #endregion
                            {
                                Task<bool> Log_task = Logger.WriteLogasTask(Logger.LogType.Running, "ServoSequense", "AutoSequence4ServoX1", "", "Case 1 Move Abs Servo 2");
                                #region Action
                                if (ObjectList.X2.Move_Abs(position, speed, acc, deacc, 50000))
                                #endregion
                                {
                                    #region TimedelayFor Sensor
                                    Task.Delay(1000);
                                    #endregion
                                    #region Sensor Feedback
                                    //Sensor feedback not needed here
                                    if (true)// Readin Sensor feedback here or keep true by default
                                    {
                                        #region TimedelayFor Action
                                        Task.Delay(1000);
                                        #endregion
                                        #region NextCase
                                        step2 = 2;
                                        goto case 2;
                                        #endregion
                                    }
                                    else
                                    {
                                        #region Sensor Feedback Error
                                        //Provid Alarm or error Message
                                        GlobalVariable.ShowAlarmMessage(01, "Case 1 Sensor Feedback Error");
                                        #endregion
                                    }
                                    #endregion
                                }
                                else
                                {
                                    #region FeedBack Retry
                                    if (errorcnt <= 3)
                                    {
                                        errorcnt = errorcnt + 1;
                                        step2 = 1;
                                        goto case 1;
                                    }
                                    else
                                    {
                                        errorcnt = 1;
                                    }
                                    #endregion
                                }
                            }
                            break;
                        case 2:
                            #region Interlock
                            if (!ObjectList.globalblock)
                            #endregion
                            {
                                Task<bool> Log_task = Logger.WriteLogasTask(Logger.LogType.Running, "ServoSequense", "AutoSequence4ServoX1", "", "Case 2 Move Rel Servo 2");
                                #region Action
                                if (ObjectList.X2.Move_Rel(position, speed, acc, deacc, 50000))
                                #endregion
                                {
                                    #region TimedelayFor Sensor
                                    Task.Delay(1000);
                                    #endregion
                                    #region Sensor Feedback
                                    //Sensor feedback not needed here
                                    if (true)// Readin Sensor feedback here or keep true by default
                                    {
                                        #region TimedelayFor Action
                                        Task.Delay(1000);
                                        #endregion
                                        #region NextCase
                                        step2 = 3;
                                        goto case 3;
                                        #endregion
                                    }
                                    else
                                    {
                                        #region Sensor Feedback Error
                                        //Provid Alarm or error Message
                                        GlobalVariable.ShowAlarmMessage(02, "Case 2 Sensor Feedback Error");
                                        #endregion
                                    }
                                    #endregion
                                }
                                else
                                {
                                    #region FeedBack Retry
                                    if (errorcnt <= 3)
                                    {
                                        errorcnt = errorcnt + 1;
                                        step2 = 2;
                                        goto case 2;
                                    }
                                    else
                                    {
                                        errorcnt = 1;
                                    }
                                    #endregion
                                }
                            }
                            break;
                        case 3:
                            #region Interlock
                            if (!ObjectList.globalblock)
                            #endregion
                            {
                                Task<bool> Log_task = Logger.WriteLogasTask(Logger.LogType.Running, "ServoSequense", "AutoSequence4ServoX1", "", "Case 3 Homming Servo 2");
                                #region Action
                                if (ObjectList.X2.Homing(1))
                                #endregion
                                {
                                    #region TimedelayFor Sensor
                                    Task.Delay(1000);
                                    #endregion
                                    #region Sensor Feedback
                                    //Sensor feedback not needed here
                                    if (true)// Readin Sensor feedback here or keep true by default
                                    {
                                        #region TimedelayFor Action
                                        Task.Delay(1000);
                                        #endregion
                                        #region NextCase
                                        goto case 4;
                                        #endregion
                                    }
                                    else
                                    {
                                        #region Sensor Feedback Error
                                        //Provid Alarm or error Message
                                        GlobalVariable.ShowAlarmMessage(03, "Case 3 Sensor Feedback Error");
                                        #endregion
                                    }
                                    #endregion
                                }
                                else
                                {
                                    #region FeedBack Retry
                                    if (errorcnt <= 3)
                                    {
                                        errorcnt = errorcnt + 1;
                                        step2 = 3;
                                        goto case 3;
                                    }
                                    else
                                    {
                                        errorcnt = 1;
                                    }
                                    #endregion
                                }
                            }
                            break;
                        case 4:
                            #region Interlock
                            if (!ObjectList.globalblock)
                            #endregion
                            {
                                Task<bool> Log_task = Logger.WriteLogasTask(Logger.LogType.Running, "ServoSequense", "AutoSequence4ServoX1", "", "Case 4 Jog Reverse Servo 2");
                                #region Action
                                if (ObjectList.X2.Jog(1, 10, 10, 10))
                                #endregion
                                {
                                    #region TimedelayFor Sensor
                                    Task.Delay(1000);
                                    #endregion
                                    #region Sensor Feedback
                                    //Sensor feedback not needed here
                                    if (true)// Readin Sensor feedback here or keep true by default
                                    {
                                        #region TimedelayFor Action
                                        Task.Delay(1000);
                                        #endregion
                                        #region NextCase
                                        step2 = 5;
                                        goto case 5;
                                        #endregion
                                    }
                                    else
                                    {
                                        #region Sensor Feedback Error
                                        //Provid Alarm or error Message
                                        GlobalVariable.ShowAlarmMessage(04, "Case 4 Sensor Feedback Error");
                                        #endregion
                                    }
                                    #endregion
                                }
                                else
                                {
                                    #region FeedBack Retry
                                    if (errorcnt <= 3)
                                    {
                                        errorcnt = errorcnt + 1;
                                        step2 = 4;
                                        goto case 4;
                                    }
                                    else
                                    {
                                        errorcnt = 1;
                                    }
                                    #endregion
                                }
                            }
                            break;
                        case 5:
                            #region Interlock
                            if (!ObjectList.globalblock)
                            #endregion
                            {
                                Task<bool> Log_task = Logger.WriteLogasTask(Logger.LogType.Running, "ServoSequense", "AutoSequence4ServoX1", "", "Case 5 Jog Forward Servo 2");
                                #region Action
                                if (ObjectList.X2.Jog(0,10,10,10))
                                #endregion
                                {
                                    #region TimedelayFor Sensor
                                    Task.Delay(1000);
                                    #endregion
                                    #region Sensor Feedback
                                    //Sensor feedback not needed here
                                    if (true)// Readin Sensor feedback here or keep true by default
                                    {
                                        #region TimedelayFor Action
                                        Task.Delay(1000);
                                        #endregion
                                        #region NextCase
                                        step2 = 6;
                                        goto case 6;
                                        #endregion
                                    }
                                    else
                                    {
                                        #region Sensor Feedback Error
                                        //Provid Alarm or error Message
                                        GlobalVariable.ShowAlarmMessage(05, "Case 5 Sensor Feedback Error");
                                        #endregion
                                    }
                                    #endregion
                                }
                                else
                                {
                                    #region FeedBack Retry
                                    if (errorcnt <= 3)
                                    {
                                        errorcnt = errorcnt + 1;
                                        step2 = 5;
                                        goto case 5;
                                    }
                                    else
                                    {
                                        errorcnt = 1;
                                    }
                                    #endregion
                                }
                            }
                            break;
                        case 6:
                            #region Interlock
                            if (!ObjectList.globalblock)
                            #endregion
                            {
                                Task<bool> Log_task = Logger.WriteLogasTask(Logger.LogType.Running, "ServoSequense", "AutoSequence4ServoX1", "", "Case 6 Stop Servo 2");
                                #region Action
                                if (ObjectList.X2.Stop())
                                #endregion
                                {
                                    #region TimedelayFor Sensor
                                    Task.Delay(1000);
                                    #endregion
                                    #region Sensor Feedback
                                    //Sensor feedback not needed here
                                    if (true)// Readin Sensor feedback here or keep true by default
                                    {
                                        #region TimedelayFor Action
                                        Task.Delay(1000);
                                        #endregion
                                        #region NextCase
                                        step2 = 7;
                                        goto case 7;
                                        #endregion
                                    }
                                    else
                                    {
                                        #region Sensor Feedback Error
                                        //Provid Alarm or error Message
                                        GlobalVariable.ShowAlarmMessage(06, "Case 6 Sensor Feedback Error");
                                        #endregion
                                    }
                                    #endregion
                                }
                                else
                                {
                                    #region FeedBack Retry
                                    if (errorcnt <= 3)
                                    {
                                        errorcnt = errorcnt + 1;
                                        step2 = 6;
                                        goto case 6;
                                    }
                                    else
                                    {
                                        errorcnt = 1;
                                    }
                                    #endregion
                                }
                            }
                            break;
                        case 7:
                            #region Interlock
                            if (!ObjectList.globalblock)
                            #endregion
                            {
                                Task<bool> Log_task = Logger.WriteLogasTask(Logger.LogType.Running, "ServoSequense", "AutoSequence4ServoX1", "", "Case 7 OFF Servo 2");
                                #region Action
                                if (ObjectList.X2.ServoOFF())
                                #endregion
                                {
                                    #region TimedelayFor Sensor
                                    Task.Delay(1000);
                                    #endregion
                                    #region Sensor Feedback
                                    //Sensor feedback not needed here
                                    if (true)// Readin Sensor feedback here or keep true by default
                                    {
                                        #region TimedelayFor Action
                                        Task.Delay(1000);
                                        #endregion
                                        #region NextCase
                                        step2 = 8;
                                        goto case 8;
                                        #endregion
                                    }
                                    else
                                    {
                                        #region Sensor Feedback Error
                                        //Provid Alarm or error Message
                                        GlobalVariable.ShowAlarmMessage(07, "Case 7 Sensor Feedback Error");
                                        #endregion
                                    }
                                    #endregion
                                }
                                else
                                {
                                    #region FeedBack Retry
                                    if (errorcnt <= 3)
                                    {
                                        errorcnt = errorcnt + 1;
                                        step2 = 7;
                                        goto case 7;
                                    }
                                    else
                                    {
                                        errorcnt = 1;
                                    }
                                    #endregion
                                }
                            }
                            break;
                        case 8:
                            #region Interlock
                            if (!ObjectList.globalblock)
                            #endregion
                            {
                                Task<bool> Log_task = Logger.WriteLogasTask(Logger.LogType.Running, "ServoSequense", "AutoSequence4ServoX1", "", "Case 8 ON Servo 2");
                                #region Action
                                if (ObjectList.X2.ServoOn(true))
                                #endregion
                                {
                                    #region TimedelayFor Sensor
                                    Task.Delay(1000);
                                    #endregion
                                    #region Sensor Feedback
                                    //Sensor feedback not needed here
                                    if (true)// Readin Sensor feedback here or keep true by default
                                    {
                                        #region TimedelayFor Action
                                        Task.Delay(1000);
                                        #endregion
                                        #region NextCase
                                        step2 = 1;
                                        goto case 1;
                                        #endregion
                                    }
                                    else
                                    {
                                        #region Sensor Feedback Error
                                        //Provid Alarm or error Message
                                        GlobalVariable.ShowAlarmMessage(08, "Case 8 Sensor Feedback Error");
                                        #endregion
                                    }
                                    #endregion
                                }
                                else
                                {
                                    #region FeedBack Retry
                                    if (errorcnt <= 3)
                                    {
                                        errorcnt = errorcnt + 1;
                                        step2 = 8;
                                        goto case 8;
                                    }
                                    else
                                    {
                                        errorcnt = 1;
                                    }
                                    #endregion
                                }
                            }
                            break;
                        default:
                            break;
                    }
                    threadlock2 = false;
                }


            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
