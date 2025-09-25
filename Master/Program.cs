using System;
using System.Threading;
using System.Windows.Forms;
using ExceptionLib;
using MasterProject.GlobalClass;
using Program;
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
            bool isNewInstance;
            using (Mutex mutex = new Mutex(true, "MyUniqueAppMutexName", out isNewInstance))
            {
                ErrorManage errorManage = new ErrorManage();   
                if (isNewInstance)
                {                    
                    Application.EnableVisualStyles();
                    var CH = GlobalVariable.ComObj.Init_BoardFunc();
                    if((!CH.isSuccess)&&(CH.MethodCode==1))
                    {
                        MessageBox.Show("Driver Version Mismatch.....!");
                        //Declare your Global Variable true or false based on your Requirment
                    }
                    else if((!CH.isSuccess)&&(CH.MethodCode == 2))
                    {
                        MessageBox.Show("FAiled to Read Available Device .....!");
                    }
                    else if((!CH.isSuccess)&&(CH.MethodCode==3))
                    {
                        MessageBox.Show("Error!Failed To Open Control Board.....!");
                    }
                    else
                    {
                        MessageBox.Show("Control Board Connected Successfully......!");
                    }

                    GlobalVariable.DIDO.LoadConfig();
                    GlobalVariable.DIDO.Card_Init();
                    GlobalVariable.DIDO.AxisLoad();
                    GlobalVariable.LoadAlarmCode();
                    GlobalVariable.LoadAxes();
                    Application.SetCompatibleTextRenderingDefault(false);
                    Application.Run(new Login());
                }
                else
                {
                    MessageBox.Show("Application is already running.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }        
    }
}
