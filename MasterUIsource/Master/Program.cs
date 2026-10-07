using Advantech;
using ExceptionLib;
using GRT_BG1_V54.Function.CommonClass;
using HelperClassLib;
using Master;
using Master.GRT.Function.CommonClass;
using Program;
using System;
using System.Threading;
using System.Windows.Forms;
using UI_Forms;


namespace Master
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //Arulkumar Fixed random stoppage start
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
            Application.ThreadException += (sender, e) =>
            {
                RunningLogger.LogException(e.Exception);
                Logger.WriteLog(Logger.LogType.Error, "Program", "ThreadException", e.Exception.Message, e.Exception.ToString());
            };
            AppDomain.CurrentDomain.UnhandledException += (sender, e) =>
            {
                if (e.ExceptionObject is Exception ex)
                {
                    RunningLogger.LogException(ex);
                    Logger.WriteLog(Logger.LogType.Error, "Program", "UnhandledException", ex.Message, ex.ToString());
                }
            };
            //Arulkumar Fixed random stoppage end
            bool isNewInstance;
            using (Mutex mutex = new Mutex(true, "MyUniqueAppMutexName1", out isNewInstance))
            {
                ErrorManage errorManage = new ErrorManage();   
                if (isNewInstance)
                {
                    try
                    {
                        // start running log
                        RunningLogger.StartNewLog();
                        RunningLogger.Log("Application start - new instance detected", "Current Version: "+ GlobalVariable.Version+"");

                        Application.EnableVisualStyles();

                        // LOADING INITIAL CONFIGS
                        RunningLogger.Log("Loading machine details", "Current Version: "+ GlobalVariable.Version+"");
                        GlobalVariable.LoadMachineDetails(); //*****file from :\Data\Config.txt
                       // GlobalVariable.DIDO.Card_Init();
                        RunningLogger.Log("Loading DIDO config", "Current Version: "+ GlobalVariable.Version+"");
                        GlobalVariable.DIDO.LoadConfig();
                        GlobalVariable.DIDO.Card_Init();
                        GlobalVariable.DIDO.AxisLoad();
                        RunningLogger.Log("Loading alarm codes and initializing SQL", "Current Version: "+ GlobalVariable.Version+"");
                        GlobalVariable.LoadAlarmCode();
                        if(!string.IsNullOrWhiteSpace(GlobalVariable.SQL_ConnStr))
                        {
                            SqlUtility.Initialize(GlobalVariable.SQL_ConnStr);

                        }
                        //SqlUtility.Initialize(GlobalVariable.SQL_ConnStr); //cmd by arul

                        //**devchange: OBJECTLIST
                        RunningLogger.Log("Connecting object list and loading steppers", "Current Version: "+ GlobalVariable.Version+"");
                        ObjectList.ConnectAllObj();
                        IO_Stepper.IO_Stepper_Config.LoadConvSteppersFromXml();
                        GlobalVariable.Update_Settings();
                        I_O_Read.Start();
                        Application.SetCompatibleTextRenderingDefault(false);
                        RunningLogger.Log("Starting UI: Login form", "Current Version: "+ GlobalVariable.Version+"");
                        Application.Run(new Login());

                        RunningLogger.Log("Application exited normally", "Current Version: "+ GlobalVariable.Version+"");
                    }
                    catch (Exception ex)
                    {
                        RunningLogger.LogException(ex);
                        throw;
                    }
                }
                else
                {
                    RunningLogger.StartNewLog();
                    RunningLogger.Log("Another instance detected - exiting", "Current Version: "+ GlobalVariable.Version+"");
                    MessageBox.Show("Application is already running.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);
                }
            }
        }        
    }
}
