using System;
using System.Configuration;
using System.Threading;
using System.Timers;
using System.Windows.Forms;
using ExceptionLib;


namespace Master.UIForms
{
    public partial class TEsting : Form
    {
        HelperClassLib.SocketClient socketClient = new HelperClassLib.SocketClient("Vision1");        
        public static System.Threading.Timer Streamline_1 = null;
        string delimiter = ConfigurationManager.AppSettings["Delimiter"];        
        public bool Connectsucess = false;
        public bool SendSucess = false;
        public TEsting()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {              
                int o = socketClient.tcpQueue.Count;               
            }
            catch (Exception ex)
            {
            }
        }       
        private static System.Timers.Timer timer;
        public void StartQueueProcess(int intervalMs)
        {
            timer = new System.Timers.Timer(intervalMs);
            timer.Elapsed += (sender, e) => socketClient.AddDataInqueue(socketClient.Receive(600001));            
            timer.AutoReset = true;            
            timer.Start();           
        }
        private void BtnSend_Click(object sender, EventArgs e)
        {
            try
            {
                Connectsucess =  socketClient.Connect();                
                if (Connectsucess)
                {                    
                    SendSucess = socketClient.Send(txtSendData.Text);                        
                }
                else
                {
                    MessageBox.Show("Connection Failed");
                }
                StartQueueProcess(1);


            }
            catch (Exception ex)
            {
                //Logger.WriteLog(Logger.LogType.Error,"Met")
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string Dequer = socketClient.GetNextDatafromQueue();
            string[] Splittedcommand = Dequer.Split(new string[] { delimiter }, StringSplitOptions.None);
        }
    }
}
