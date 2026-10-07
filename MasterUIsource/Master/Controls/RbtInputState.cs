using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using Advantech;
using DIO;
using ExceptionLib;
using Master;
using static DIO.DIDO;

namespace FBI_D57
{

    using LANG = Test_EN.Transform_Language_Tool;
    public partial class RbtInputState : UserControl
    {
        List<System.Threading.Timer> ThreadTimer = new List<System.Threading.Timer>();
        public static bool Di_Input_read_lock = false;
        string value = string.Empty;
        static RbtInputState()
        {
            lst_control = new List<RbtInputState>();
        }
        public RbtInputState()
        {
            try
            {
                InitializeComponent();
                lst_control.Add(this);

                // if (GlobalVariable.g_CardInitSucc)
                {
                    //**devchange: uncomment after connected to machine
                    ThreadTimer.Add(new System.Threading.Timer(new TimerCallback(Di_Input_read), null, 10, 20)); // reading input connection, 100,10
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(this.Name + "List Misatch:" + e.Message + "\n" + e.StackTrace);
            }
        }
        Image signal_on, signal_off;
        static List<RbtInputState> lst_control;
        private void InputState_Load(object sender, EventArgs e)
        {
            value = "Advantech";//ConfigurationManager.AppSettings["MotionCard"];             
        }
        /// <summary>
        /// For Advantech to read the input
        /// </summary>
        private void Di_Input_read(object sender)
        {
            try
            {
                if (Di_Input_read_lock == false)
                {
                    Di_Input_read_lock = true;
                    GlobalVariable.DI = GlobalVariable.ComObj.DI_RefreshValue(GlobalVariable.DI.Length, GlobalVariable.InputPortCfg);
                    GlobalVariable.DO = GlobalVariable.ComObj.DO_RefreshValue(GlobalVariable.DO.Length, GlobalVariable.OutputPortCfg);
                    Di_Input_read_lock = false;
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog(Logger.LogType.Error, "Input_read", "Di_Input_read()", "Input_read_Error", ex.ToString());
                Di_Input_read_lock = false;
            }

        }

        #region custom properties
        private string input_start = "start";
        [Browsable(true)]
        [Description("The first io name displayed, the default is 'Start'"), Category("Custom control properties"), DisplayName("The first input enumeration name displayed in the current table")]
        public string Input_start
        {
            set
            {
                input_start = value;
                if (input_start == "End")
                {
                    input_start = "Start";
                }
            }
            get { return input_start; }
        }
        private string input_stop = "End";
        [Browsable(true)]
        [Description("The last io name displayed, the default is 'end'"), Category("Custom control properties"), DisplayName("The last input enumeration name displayed in the current table")]
        public string Input_stop
        {

            set
            {
                input_stop = value;
                if (input_stop == "start")
                {
                    input_stop = "End";
                }
            }
            get { return input_stop; }
        }
        #endregion
        List<CardDLL.IInput> lst_Input = new List<CardDLL.IInput>();   // need to check...HIGH priority

        //public void InitRoboInputs()
        //{
        //    try
        //    {
        //        signal_on = Image.FromFile(@"ICO\signal_on.png");
        //        signal_off = Image.FromFile(@"ICO\signal_off.png");

        //        GlobalVariable.lst_RobotInput = null;


        //        GlobalVariable.lst_RobotInput = Enum.GetValues(typeof(DIDO.RobotInputs)).Cast<DIDO.RobotInputs>().ToList();

        //        if (GlobalVariable.lst_RobotInput != null && GlobalVariable.lst_RobotInput.Count > 0)
        //        {
        //            DataGridViewImageColumn btncell = new DataGridViewImageColumn();
        //            btncell.ImageLayout = DataGridViewImageCellLayout.Zoom;
        //            btncell.ReadOnly = true;
        //            DGV_InputRbt.Columns.Add(btncell);
        //            DataGridViewColumn dc = new DataGridViewColumn();
        //            dc.CellTemplate = new DataGridViewTextBoxCell();
        //            DGV_InputRbt.Columns.Add(dc);
        //            DGV_InputRbt.Columns[0].Width = 15;
        //            DGV_InputRbt.Columns[1].Width = (DGV_InputRbt.Width - 30);
        //            DGV_InputRbt.AllowUserToAddRows = false;
        //            for (int i = 0; i < GlobalVariable.lst_RobotInput.Count; i++)
        //            {
        //                DataGridViewRow dataGridViewRow = new DataGridViewRow();

        //                int index = DGV_InputRbt.Rows.Add(dataGridViewRow);

        //                DGV_InputRbt.Rows[index].Cells[1].Value = LANG.TL_MessageBox(GlobalVariable.lst_RobotInput[i].ToString());

        //            }
        //        }
        //        timer1.Start();
        //    }
        //    catch (Exception ex)
        //    {
        //        Logger.WriteLogasTask(Logger.LogType.Error, "InputState", "", ex.Message, ex.ToString());
        //    }
        //}

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (value == "Adlink")
            {
                for (int i = 0; i < (lst_Input.Count + 1) / 2; i++)
                {
                    DGV_InputRbt.Rows[i].Cells[0].Value = lst_Input[2 * i].ReadIn() ? signal_on : signal_off;
                    DGV_InputRbt.Rows[i].Cells[1].Value = LANG.TL_MessageBox(lst_Input[2 * i].BitName);
                    if (2 * i + 1 <= lst_Input.Count - 1)
                    {
                        DGV_InputRbt.Rows[i].Cells[2].Value = lst_Input[2 * i + 1].ReadIn() ? signal_on : signal_off;
                        DGV_InputRbt.Rows[i].Cells[3].Value = LANG.TL_MessageBox(lst_Input[2 * i + 1].BitName);
                    }
                    else
                    {
                        DGV_InputRbt.Rows[i].Cells[2].Value = signal_off;
                    }
                }
            }
            if (value == "Advantech")
            {
                //if (GlobalVariable.lst_RobotInput.Count > 0)
                //{
                //    for (int i = 0; i < GlobalVariable.lst_RobotInput.Count; i++)
                //    {
                //        DGV_InputRbt.Rows[i].Cells[0].Value = GlobalVariable.DI[(int)DIDO.RobotInputs.RBT_Opr_Sigl + i] ? signal_on : signal_off;
                //        DGV_InputRbt.Rows[i].Cells[1].Value = LANG.TL_MessageBox(GlobalVariable.lst_RobotInput[i].ToString());
                //    }
                //}
            }

        }

        private void DGV_Input_SelectionChanged(object sender, EventArgs e)
        {
            DGV_InputRbt.ClearSelection();
        }

        public static bool CheckSource()
        {
            EInput eInput, eInput2;
            for (int i = 0; i < lst_control.Count; i++)
            {
                if (!Enum.TryParse<EInput>(lst_control[i].input_start, out eInput))
                {
                    MessageBox.Show(lst_control[i].Name + "The first input of the control '" + lst_control[i].input_start + "': The system EInput definition does not exist, please check whether there is an input error");
                    return false;
                }
                if (!Enum.TryParse<EInput>(lst_control[i].input_stop, out eInput2))
                {
                    MessageBox.Show(lst_control[i].Name + "The last input of the control '" + lst_control[i].input_stop + "': The system EInput definition does not exist, please check for input errors");
                    return false;
                }
                if ((int)eInput2 < (int)eInput)
                {
                    MessageBox.Show(lst_control[i].Name + "The last input point of the control cannot be less than the order of the first input point");
                    return false;
                }
            }
            return true;
        }
    }
}
