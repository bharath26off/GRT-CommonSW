using Advantech;
using Advantech.Motion;
using DIO;
using ExceptionLib;
using Master;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static DIO.DIDO;


namespace Master
{
    public partial class AlarmPopup : Form
    {
        public static bool InvokeRequired = false;
        public static bool PopubActive = false;
        public static int _Error_code = 0;
        public static string _Error_code_String = "";
        public static string Description_ = string.Empty;
        private static AlarmPopup instance = null;
        private static object locker = new object();

        DateTime _date;
        //public static AlarmPopup ShowAlarmMessage
        //{
        //    get
        //    {
        //        if (instance == null)
        //        {
        //            lock (locker)
        //            {
        //                if (instance == null)
        //                {
        //                    instance = new AlarmPopup();
        //                    //  instance.Avlbldvc();
        //                }
        //            }
        //        }
        //        return instance;
        //    }
        //}
        public AlarmPopup(int ErrCode, string Description="")
        {
            InitializeComponent();
            _Error_code = ErrCode;
            _Error_code_String = GlobalVariable.g_lstAlarmInfo[_Error_code].AlarmCode;
            if(Description == "")
            {
                Description_ = GlobalVariable.g_lstAlarmInfo[_Error_code].AlarmMessage;
            }
            else
            {
                Description_ = Description;
            }
                
            _date= DateTime.Now;
        }        
        private void Form2_Load(object sender, EventArgs e)
        {
            PopubActive = true;
            TxtDateTime.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss:fff").ToString();
            TxtErrorCode.Text = _Error_code_String;
            //DataRow Insert = _AlrmDescdt.Select($"{_Error_code} =error_code").SingleOrDefault();
            TxtDescription.Text = Description_; // Insert[5].ToString();
        }

        private void BtnAcknowledge_Click(object sender, EventArgs e)
        {
            try
            {
                GlobalVariable.g_bAlarm = false;
                //GlobalVariable.b_gPause = false;

                //Arulkumar Automatic resume reduce 12/08/2026
                if (GlobalVariable.current_MCStatus != GlobalVariable.MachineStatus.Pause)
                {
                    GlobalVariable.b_gPause = false;
                }

                //GlobalVariable.InvokeRequired = false;
                this.Visible = false;
               // popup.close();                
                //Thread.Sleep(300);
               // GlobalVariable.PopubActive = false;
                GlobalVariable.AckTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss:fff");
                //GlobalVariable.Ack_errcode = Convert.ToInt32(TxtErrorCode.Text);
                GlobalVariable.Ack_errcode = TxtErrorCode.Text.ToString();
                Enum.TryParse<DIDO.ECode>(TxtErrorCode.Text, out var ecode);
                GlobalVariable.g_lstAlarmInfo[(int)ecode].AlarmHappen = false;

                this.Close();

            }
            catch (Exception es)
            {
                Logger.WriteLog(Logger.LogType.Error, "AlarmPopup", "BtnAcknowledge_Click", "Exception Error", es.ToString());
            }
        }
    }
}
