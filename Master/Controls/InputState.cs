using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using Advantech;
using ExceptionLib;
using MasterProject.GlobalClass;
using static DIO.DIDO;

namespace FBI_D57
{
    
    using LANG = Test_EN.Transform_Language_Tool;    
    public partial class InputState : UserControl
    {
        List<System.Threading.Timer> ThreadTimer = new List<System.Threading.Timer>();
        public static bool Di_Input_read_lock = false;
        string value = string.Empty;
        static InputState()
        {
            lst_control = new List<InputState>();
        }
        public InputState()
        {
            try
            {
                InitializeComponent();
                lst_control.Add(this);
                //Plese uncommand bellow line when code run in MAchine because it will read the DIDO from MAchine in Time
                //ThreadTimer.Add(new System.Threading.Timer(new TimerCallback(Di_Input_read), null, 10, 20)); // reading input connection, 100,10
            }
            catch (Exception e)
            {
                MessageBox.Show(this.Name + "List Misatch:" + e.Message + "\n" + e.StackTrace);
            }
        }
        Image signal_on, signal_off;
        static List<InputState> lst_control;
        private void InputState_Load(object sender, EventArgs e)
        {
            value = ConfigurationManager.AppSettings["MotionCard"];             
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
                    GlobalVariable.DI = ObjectList.X1.DI_RefreshValue(GlobalVariable.DI.Length);
                    GlobalVariable.DO = ObjectList.X1.DO_RefreshValue(GlobalVariable.DO.Length);
                    Di_Input_read_lock = false;
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog(Logger.LogType.Error,"Input_read", "Di_Input_read()", "Input_read_Error", ex.ToString());
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
        public void InitSource()
        {
            lst_Input.Clear();
            signal_on = Image.FromFile(@"ICO\signal_on.png");
            signal_off = Image.FromFile(@"ICO\signal_off.png");

            if (g_lstInput.Count > 0)
            {
                #region Press in the point that needs to be displayed
                int index_start = 0, index_stop = 0, lenth = 0;
                EInput eInput_start, eInput_stop;
                if (input_start != "Start")
                {
                    Enum.TryParse<EInput>(input_start, out eInput_start);
                    index_start = (int)eInput_start;
                }
                Enum.TryParse<EInput>(input_stop, out eInput_stop);
                index_stop = (int)eInput_stop;
                if (input_stop == "End")
                {
                    index_stop = index_stop - 1;
                }
                lenth = index_stop - index_start + 1;
                for (int i = 0; i < lenth; i++)
                {
                    lst_Input.Add(g_lstInput[index_start + i]);
                }
                #endregion

                DataGridViewImageColumn btncell = new DataGridViewImageColumn();
                btncell.ImageLayout = DataGridViewImageCellLayout.Zoom;
                btncell.ReadOnly = true;
                DGV_Input.Columns.Add(btncell);
                DataGridViewColumn dc = new DataGridViewColumn();
                dc.CellTemplate = new DataGridViewTextBoxCell();
                DGV_Input.Columns.Add(dc);
                DataGridViewImageColumn btncell1 = new DataGridViewImageColumn();
                btncell1.ImageLayout = DataGridViewImageCellLayout.Zoom;
                DGV_Input.Columns.Add(btncell1);
                DataGridViewColumn dc1 = new DataGridViewColumn();
                dc1.CellTemplate = new DataGridViewTextBoxCell();
                DGV_Input.Columns.Add(dc1);
                DGV_Input.Columns[0].Width = 75;
                DGV_Input.Columns[2].Width = 75;
                DGV_Input.Columns[1].Width = (DGV_Input.Width - 80) / 2;
                DGV_Input.Columns[3].Width = (DGV_Input.Width - 80) / 2;
                DGV_Input.AllowUserToAddRows = false;
                for (int i = 0; i < (lst_Input.Count + 1) / 2; i++)
                {
                    DataGridViewRow dataGridViewRow = new DataGridViewRow();

                    int index = DGV_Input.Rows.Add(dataGridViewRow);

                    DGV_Input.Rows[index].Cells[1].Value = LANG.TL_MessageBox(lst_Input[2 * i].BitName);
                    if (2 * i + 1 <= lst_Input.Count - 1)
                        DGV_Input.Rows[index].Cells[3].Value = LANG.TL_MessageBox(lst_Input[2 * i + 1].BitName);
                }
                timer1.Start();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (value == "Inovance")
            {
                for (int i = 0; i < (lst_Input.Count + 1) / 2; i++)
                {
                    DGV_Input.Rows[i].Cells[0].Value = lst_Input[2 * i].ReadIn() ? signal_on : signal_off;
                    DGV_Input.Rows[i].Cells[1].Value = LANG.TL_MessageBox(lst_Input[2 * i].BitName);
                    if (2 * i + 1 <= lst_Input.Count - 1)
                    {
                        DGV_Input.Rows[i].Cells[2].Value = lst_Input[2 * i + 1].ReadIn() ? signal_on : signal_off;
                        DGV_Input.Rows[i].Cells[3].Value = LANG.TL_MessageBox(lst_Input[2 * i + 1].BitName);
                    }
                    else
                    {
                        DGV_Input.Rows[i].Cells[2].Value = signal_off;
                    }
                }
            }
            if (value == "Advantech")
            {
                for (int i = 0; i < (GlobalVariable.DI.Length +1)/2; i++)
                
                {                   
                    DGV_Input.Rows[i].Cells[0].Value = GlobalVariable.DI[2*i] ? signal_on : signal_off;
                    DGV_Input.Rows[i].Cells[1].Value = LANG.TL_MessageBox(lst_Input[2 * i].BitName);

                    if (2*i + 1 <= lst_Input.Count - 1)
                    {
                        DGV_Input.Rows[i].Cells[2].Value = GlobalVariable.DI[2*i+1] ? signal_on : signal_off;
                        DGV_Input.Rows[i].Cells[3].Value = LANG.TL_MessageBox(lst_Input[2 * i + 1].BitName);
                    }
                    else
                    {
                        DGV_Input.Rows[i].Cells[2].Value = signal_off;
                    }
                }
            }
        }

        private void DGV_Input_SelectionChanged(object sender, EventArgs e)
        {
            DGV_Input.ClearSelection();
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
