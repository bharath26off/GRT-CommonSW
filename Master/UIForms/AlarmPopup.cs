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
using Advantech;
using MasterProject.GlobalClass;


namespace MasterProject
{
    public partial class AlarmPopup : Form
    {
        public static bool InvokeRequired = false;
        public static bool PopubActive = false;
        public static int _Error_code = 0;
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
        public AlarmPopup(int ErrCode, string Description,[Optional]DateTime OccuredDate)
        {
            
            InitializeComponent();
            _Error_code = ErrCode;
            Description_ = Description;
            _date= OccuredDate;
        }        
        
        private void Form2_Load(object sender, EventArgs e)
        {
            PopubActive = true;
            TxtDateTime.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss:fff").ToString();
            TxtErrorCode.Text = _Error_code.ToString();
            //DataRow Insert = _AlrmDescdt.Select($"{_Error_code} =error_code").SingleOrDefault();
            TxtDescription.Text = Description_; // Insert[5].ToString();
        }

        private void BtnAcknowledge_Click(object sender, EventArgs e)
        {
            try
            {
                GlobalVariable.InvokeRequired = false;
                this.Close();
                Thread.Sleep(300);
                GlobalVariable.PopubActive = false;
                GlobalVariable.AckTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss:fff");
                GlobalVariable.Ack_errcode = Convert.ToInt32(TxtErrorCode.Text);                
            }
            catch (Exception es)
            {

            }
        }
    }
}
