using DIO;
using ExceptionLib;
using Master;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using static DIO.DIDO;

namespace FBI_D57
{
    using LANG = Test_EN.Transform_Language_Tool;
    public partial class RbtOutputState : UserControl
    {
        string value = string.Empty;
        static RbtOutputState()
        {
            lst_control = new List<RbtOutputState>();
        }
        public RbtOutputState()
        {
            try
            {
                InitializeComponent();
                lst_control.Add(this);
            }
            catch (Exception e)
            {
                MessageBox.Show(this.Name + "异常:" + e.Message + "\n" + e.StackTrace);
            }
        }

        private void InputState_Load(object sender, EventArgs e)
        {
            value = "Advantech";//ConfigurationManager.AppSettings["MotionCard"];

        }
        static List<RbtOutputState> lst_control;
        #region custom properties
        private string input_start = "start";
        [Browsable(true)]
        [Description("The first io name displayed, the default is 'Start'"), Category("Custom control properties"), DisplayName("The first output enumeration name displayed in the current table")]
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
        [Description("The last io name displayed, the default is 'Total'"), Category("Custom control properties"), DisplayName("The last output enumeration name displayed in the current table")]
        public string Input_stop
        {

            set
            {
                input_stop = value;
                if (input_stop == "Start")
                {
                    input_stop = "End";
                }
            }
            get { return input_stop; }
        }
        #endregion

        List<CardDLL.IOutput> lst_Output = new List<CardDLL.IOutput>();
        //private object g_lstOutput;

        //public void InitRoboOutputs()
        //{
        //    try
        //    {
        //        GlobalVariable.lst_RobotOutput = null;

        //        GlobalVariable.lst_RobotOutput = Enum.GetValues(typeof(DIDO.RobotOutputs)).Cast<DIDO.RobotOutputs>().ToList();

        //        if (GlobalVariable.lst_RobotOutput != null && GlobalVariable.lst_RobotOutput.Count > 0)
        //        {
        //            DataGridViewButtonColumn btncell = new DataGridViewButtonColumn();
        //            btncell.FlatStyle = FlatStyle.Popup;
        //            btncell.ReadOnly = true;
        //            DGV_Output.Columns.Add(btncell);
        //            DataGridViewColumn dc = new DataGridViewColumn();
        //            dc.CellTemplate = new DataGridViewTextBoxCell();
        //            DGV_Output.Columns.Add(dc);
        //            DGV_Output.Columns[0].Width = 15;
        //            DGV_Output.Columns[1].Width = (DGV_Output.Width - 30);
        //            DGV_Output.AllowUserToAddRows = false;
        //            for (int i = 0; i < GlobalVariable.lst_RobotOutput.Count; i++)
        //            {
        //                DataGridViewRow dataGridViewRow = new DataGridViewRow();

        //                int index = DGV_Output.Rows.Add(dataGridViewRow);

        //                DGV_Output.Rows[index].Cells[0].Tag = (int)DIDO.RobotOutputs.RBT_EMG_Stp_Signl + i;
        //                DGV_Output.Rows[index].Cells[1].Value = LANG.TL_MessageBox(GlobalVariable.lst_RobotOutput[i].ToString());

        //            }
        //        }
        //        timer1.Start();
        //    }
        //    catch (Exception ex)
        //    {
        //        Logger.WriteLogasTask(Logger.LogType.Error, "OutputState", "", ex.Message, ex.ToString());
        //    }
        //}

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (value == "Advantech")
            {
                //if (GlobalVariable.lst_RobotOutput.Count > 0)
                //{
                //    for (int i = 0; i < GlobalVariable.lst_RobotOutput.Count; i++)
                //    {
                //        DGV_Output.Rows[i].Cells[0].Style.BackColor =
                //            GlobalVariable.DO[(int)DIDO.RobotOutputs.RBT_EMG_Stp_Signl + i] ? Color.Lime : Color.LightGray;
                //        DGV_Output.Rows[i].Cells[1].Value = LANG.TL_MessageBox(GlobalVariable.lst_RobotOutput[i].ToString());
                //    }
                //}
            }
            else
            {
                for (int i = 0; i < (lst_Output.Count + 1) / 2; i++)
                {
                    DGV_Output.Rows[i].Cells[0].Style.BackColor = lst_Output[2 * i].CheckOut() ? Color.Lime : Color.LightGray;
                    DGV_Output.Rows[i].Cells[1].Value = LANG.TL_MessageBox(lst_Output[2 * i].BitName);
                    if (2 * i + 1 <= lst_Output.Count - 1)
                    {
                        DGV_Output.Rows[i].Cells[2].Style.BackColor = lst_Output[2 * i + 1].CheckOut() ? Color.Lime : Color.LightGray;
                        DGV_Output.Rows[i].Cells[3].Value = LANG.TL_MessageBox(lst_Output[2 * i + 1].BitName);
                    }
                    else
                    {
                        DGV_Output.Rows[i].Cells[2].Style.BackColor = Color.LightGray;
                    }
                }
            }
            
        }

        private void DGV_Output_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void DGV_Output_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0 && (e.ColumnIndex == 0 || e.ColumnIndex == 2))
            {
                var sd = sender as DataGridView;
                if (sd.Rows[e.RowIndex].Cells[e.ColumnIndex].Tag != null)
                {
                    var index = (int)sd.Rows[e.RowIndex].Cells[e.ColumnIndex].Tag;
                    if (DGV_Output.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor == Color.Lime)
                    {
                        bool Rtn_OutPutOn = GlobalVariable.DIDO.WriteOPS(false, index);
                        if (Rtn_OutPutOn)
                        {
                            DGV_Output.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = Color.LightGray;
                        }
                        else
                            DGV_Output.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = Color.Lime;
                    }
                    else
                    {
                        bool Rtn_OutPutOn = GlobalVariable.DIDO.WriteOPS(true, index);
                        if (Rtn_OutPutOn)
                        {
                            DGV_Output.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = Color.Lime;
                        }
                        else
                            DGV_Output.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = Color.LightGray;
                    }
                    sd.CurrentCell = sd.Rows[e.RowIndex].Cells[e.ColumnIndex + 1];
                }
            }
        }

        public static bool CheckSource()
        {
            EOutput eInput, eInput2;
            for (int i = 0; i < lst_control.Count; i++)
            {

                if (!Enum.TryParse<EOutput>(lst_control[i].input_start, out eInput))
                {
                    MessageBox.Show(lst_control[i].Name + "The first output of the control '" + lst_control[i].input_start + "': The system EOutput definition does not exist, please check whether there is an input error");
                    return false;
                }
                if (!Enum.TryParse<EOutput>(lst_control[i].input_stop, out eInput2))
                {
                    MessageBox.Show(lst_control[i].Name + "The last output of the control '" + lst_control[i].input_stop + "': The system EOutput definition does not exist, please check whether there is an input error");
                    return false;
                }
                if ((int)eInput2 < (int)eInput)
                {
                    MessageBox.Show(lst_control[i].Name + "The last output point of the control cannot be less than the order of the first output point");
                    return false;
                }
            }
            return true;
        }
    }
}
