using Advantech;
using DIO;
using ExceptionLib;
using HelperClassLib;
using MasterProject.GlobalClass;
using Program;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using static DIO.DIDO;

namespace UI.UI_Forms
{
    //
    public partial class RecipieForm : Form
    {
        public Advantech_PCIE ServoAxis;
        public Advantech_PCIE TmrServoAxis;
        public Advantech_PCIE RelServoAxis;
        int axisindex = 0;
        int axisindex2 = 0;
        int SelectedAxis = 0;
        int CurrentAxis = -1;
        string CurrentAxisName = "";
        double MovePosition = 0;
        XmlDocument xmlDoc = new XmlDocument();
        XmlNodeList xmlNode = null;
        XmlNode Selectednode = null;
        XmlNode Initnode = null;
        XmlNode SafePrioritynode = null;
        XmlNode Movementnode = null;
        XmlNode Operatingnode = null;

        public int X_Index = 0;
        public int Y_Index = 0;
        public int Z_Index = 0;

        public string SelectedXAxis = string.Empty;
        public string SelectedYAxis = string.Empty;
        public string SelectedZAxis = string.Empty;

        public string GantryStructure_FilePath = GlobalVariable.g_sAppPath + @"\Data\GantryStructure.xml";
        public string RoboReceipePath = GlobalVariable.g_sAppPath + @"\Data\RoboReceipe_Param.csv";
        public string Receipe_FilePath = GlobalVariable.g_sAppPath + @"\Data\Receipe_Param.csv";
        public string Teach_filepath = Environment.CurrentDirectory + @"\Data\";

        public DataTable AxisTable = new DataTable();

        public RecipieForm()
        {


            InitializeComponent();

            if (GlobalVariable.ServoRows != null)
            {

            }
            cmbAxisMoveAbs.DataSource = GlobalVariable.ServoRows.CopyToDataTable();
            cmbAxisMoveAbs.DisplayMember = "Servo";
            cmbAxisMoveAbs.ValueMember = "Servo";
            cmbAxisMoveRel.DataSource = GlobalVariable.ServoRows.CopyToDataTable();
            cmbAxisMoveRel.DisplayMember = "Servo";
            cmbAxisMoveRel.ValueMember = "Servo";

            AxisTable = GlobalVariable.ServoRows.CopyToDataTable();

            xmlDoc.Load(GantryStructure_FilePath);
            xmlNode = xmlDoc.DocumentElement.ChildNodes;

            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("Gantry"));
            foreach (XmlNode node in xmlNode)
            {
                DataRow dr = dt.NewRow();
                dr[0] = node.Name;
                dt.Rows.Add(dr);
            }
            cmbSelGantry.DataSource = dt;
            cmbSelGantry.DisplayMember = "Gantry";
            cmbSelGantry.ValueMember = "Gantry";

            float xRatio = (float)Screen.PrimaryScreen.Bounds.Width / GlobalVariable.OrginalFormWidth;
            float yRatio = (float)Screen.PrimaryScreen.Bounds.Height / GlobalVariable.OrginalFormHeight;
            GlobalVariable.ResizeAllControls(this, xRatio, yRatio);
            txtPositionAbs.KeyPress += GlobalVariable.AllowOnlyDecimal_TextBox;
            txt_Position_Relative.KeyPress += GlobalVariable.AllowOnlyDecimal_TextBox;
            txtetSpeedAbs.KeyPress += GlobalVariable.AllowOnlyDecimal_TextBox;
            txt_Speed_Relative.KeyPress += GlobalVariable.AllowOnlyDecimal_TextBox;
            ServoAxis = new Advantech_PCIE(0, "");

        }

        private void cmbAxisMoveAbs_Enter(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(cmbAxisMoveAbs.Text))
            {
                cmbAxisMoveAbs.Text = "SELECT";
                cmbAxisMoveAbs.ForeColor = Color.Gray;
            }
        }

        private void cmbAxisMoveAbs_Leave(object sender, EventArgs e)
        {
            if (cmbAxisMoveAbs.Text == "SELECT" && cmbAxisMoveAbs.ForeColor == Color.Gray)
            {
                cmbAxisMoveAbs.Text = "";
                cmbAxisMoveAbs.ForeColor = Color.Black;
            }
        }

        private void cmbAxisMoveRel_Enter(object sender, EventArgs e)
        {
            if (cmbAxisMoveRel.Text == "SELECT" && cmbAxisMoveRel.ForeColor == Color.Gray)
            {
                cmbAxisMoveRel.Text = "";
                cmbAxisMoveRel.ForeColor = Color.Black;
            }
        }

        private void cmbAxisMoveRel_Leave(object sender, EventArgs e)
        {
            if (cmbAxisMoveRel.Text == "SELECT" && cmbAxisMoveRel.ForeColor == Color.Gray)
            {
                cmbAxisMoveRel.Text = "";
                cmbAxisMoveRel.ForeColor = Color.Black;
            }
        }

        private void cmbAxisMoveAbs_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void cmbAxisMoveRel_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void btnMove_X1_Click(object sender, EventArgs e)
        {
            try
            {
                CurrentAxis = cmbAxisMoveAbs.SelectedIndex;
                CurrentAxisName = cmbAxisMoveAbs.SelectedValue.ToString();
                if (txtPositionAbs.Text.Trim() == "")
                {
                    MessageBox.Show("Please Enter Position", "Manual Screen", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (txtetSpeedAbs.Text.Trim() == "")
                {
                    MessageBox.Show("Please Enter Speed", "Manual Screen", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (ServoAxis != null)
                {
                    double dTargetPos = 0;
                    if (!string.IsNullOrEmpty(txtPositionAbs.Text))
                    {
                        dTargetPos = Convert.ToDouble(txtPositionAbs.Text);
                        if (double.TryParse(txtetSpeedAbs.Text, out double speedValue))
                        {
                            btnMove_X1.Enabled = false;
                            if (!ServoAxis.Move_Abs(dTargetPos, speedValue, GlobalVariable.g_lstAxisConfig[axisindex].Acc,
                                GlobalVariable.g_lstAxisConfig[axisindex].DeAcc, 5000))
                            {
                                //Logger.WriteLog("Device_Interface", "jogfrwrd()", "PCIE-1203_Interface", "Exception Error", es.ToString());
                            }
                            btnMove_X1.Enabled = true;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Kindly Enter the TargetPosition ", "Movement", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog(Logger.LogType.Error, "ReceipeForm", "", ex.Message, ex.ToString());
            }
        }

        private void cmbAxisMoveAbs_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                axisindex = cmbAxisMoveAbs.SelectedIndex;
                ServoAxis = ObjectList.MotorObj[axisindex];
            }
            catch (Exception ex)
            {
                Logger.WriteLog(Logger.LogType.Error, "ReceipeForm", "", ex.Message, ex.ToString());
            }
        }

        private void cmbAxisMoveRel_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                axisindex2 = cmbAxisMoveRel.SelectedIndex;
                RelServoAxis = ObjectList.MotorObj[axisindex2];
            }
            catch (Exception ex)
            {
                Logger.WriteLog(Logger.LogType.Error, "ReceipeForm", "", ex.Message, ex.ToString());
            }
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            try
            {
                if (ServoAxis != null)
                {
                    ServoAxis.Stop();
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog(Logger.LogType.Error, "ReceipeForm", "", ex.Message, ex.ToString());
            }
        }

        private void btnPTP_Positive_Click(object sender, EventArgs e)
        {
            try
            {
                CurrentAxis = cmbAxisMoveRel.SelectedIndex;
                CurrentAxisName = cmbAxisMoveRel.SelectedValue.ToString();
                double dTargetPos = 0;
                if (txt_Position_Relative.Text.Trim() == "")
                {
                    MessageBox.Show("Please Enter Position", "Manual Screen", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txt_Position_Relative.Focus();
                    return;
                }
                if (txt_Speed_Relative.Text.Trim() == "")
                {
                    MessageBox.Show("Please Enter Speed", "Manual Screen", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txt_Speed_Relative.Focus();
                    return;
                }

                if (RelServoAxis != null)
                {
                    if (!string.IsNullOrEmpty(txt_Position_Relative.Text))
                    {
                        dTargetPos = Convert.ToDouble(txt_Position_Relative.Text);
                        if (double.TryParse(txt_Speed_Relative.Text, out double speedValue))
                        {
                            btnPTP_Positive.Enabled = false;
                            if (!RelServoAxis.Move_Rel(dTargetPos, speedValue, GlobalVariable.g_lstAxisConfig[axisindex].Acc,
                                GlobalVariable.g_lstAxisConfig[axisindex].DeAcc, 5000))
                            {
                                //Logger.WriteLog("Device_Interface", "jogfrwrd()", "PCIE-1203_Interface", "Exception Error", es.ToString());
                            }
                            btnPTP_Positive.Enabled = true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog(Logger.LogType.Error, "ReceipeForm", "", ex.Message, ex.ToString());
            }
        }

        private void btnPTP_Negative_Click(object sender, EventArgs e)
        {
            try
            {
                CurrentAxis = cmbAxisMoveRel.SelectedIndex;
                CurrentAxisName = cmbAxisMoveRel.SelectedValue.ToString();
                double dTargetPos = 0;
                if (txt_Position_Relative.Text.Trim() == "")
                {
                    MessageBox.Show("Please Enter Position", "Manual Screen", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txt_Position_Relative.Focus();
                    return;
                }
                if (txt_Speed_Relative.Text.Trim() == "")
                {
                    MessageBox.Show("Please Enter Speed", "Manual Screen", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txt_Speed_Relative.Focus();
                    return;
                }

                if (RelServoAxis != null)
                {
                    if (!string.IsNullOrEmpty(txt_Position_Relative.Text))
                    {
                        dTargetPos = Convert.ToDouble(txt_Position_Relative.Text);
                        if (double.TryParse(txt_Speed_Relative.Text, out double speedValue))
                        {
                            btnPTP_Positive.Enabled = false;
                            if (!RelServoAxis.Move_Rel(-dTargetPos, speedValue, GlobalVariable.g_lstAxisConfig[axisindex].Acc,
                                GlobalVariable.g_lstAxisConfig[axisindex].DeAcc, 5000))
                            {
                                //Logger.WriteLog("Device_Interface", "jogfrwrd()", "PCIE-1203_Interface", "Exception Error", es.ToString());
                            }
                            btnPTP_Positive.Enabled = true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog(Logger.LogType.Error, "ReceipeForm", "", ex.Message, ex.ToString());
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                int selectedTabIndex = tabRecipe.SelectedIndex;

                if (selectedTabIndex == 0)
                {
                    dgv_PickGantry.ReadOnly = false;
                    dgv_PickGantry.Enabled = true;
                }
                else if (selectedTabIndex == 1)
                {
                    dgv_Robot.ReadOnly = false;
                    dgv_Robot.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog(Logger.LogType.Error, "ReceipeForm", "", ex.Message, ex.ToString());
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            try
            {
                dgv_PickGantry.Enabled = false;
                dgv_Robot.Enabled = false;

                DialogResult result = MessageBox.Show("Do you want to save the Data", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    if (tabRecipe.SelectedIndex == 0)
                    {
                        if (cmbSelGantry.SelectedValue.ToString().ToLower() != "select")
                        {
                            dt = (DataTable)dgv_PickGantry.DataSource;

                            WriteDataTableToCsv(dt, Teach_filepath + cmbSelGantry.SelectedValue + "Receipe_Param.csv");
                        }
                        else
                        {
                            MessageBox.Show("Select valid Gantry to save the Receipe_Param");
                            return;
                        }

                    }
                    else if (tabRecipe.SelectedIndex == 1)
                    {
                        dt = (DataTable)dgv_Robot.DataSource;
                        WriteDataTableToCsv(dt, RoboReceipePath);
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog(Logger.LogType.Error, "ReceipeForm", "", ex.Message, ex.ToString());
            }
        }

        private void btnSaveRobot_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            try
            {
                if (tabRecipe.SelectedTab.Name.ToUpper() == "ROBOT")
                {
                    DialogResult result = MessageBox.Show("Do you want to save the Data", "", MessageBoxButtons.YesNo);

                    if (result == DialogResult.Yes)
                    {
                        dt = (DataTable)dgv_Robot.DataSource;

                        if (dt.Rows.Count > 0)
                        {
                            try
                            {
                                WriteDataTableToCsv(dt, RoboReceipePath);
                            }
                            catch (Exception ex)
                            {
                                Logger.WriteLog(Logger.LogType.Error, "ReceipeForm", "", ex.Message, ex.ToString());
                                Logger.WriteLog(Logger.LogType.Error, "ReceipeForm", "", "File Save Failed", "Robot Receipe File Not Saved");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog(Logger.LogType.Error, "ReceipeForm", "", ex.Message, ex.ToString());
            }
        }

        private void LoadReceipe()
        {
            DataTable dt = new DataTable();
            DataTable dtRobot = new DataTable();

            try
            {
                //dt = GlobalVariable.LoadCsvData(Receipe_FilePath);

                //dgv_PickGantry.DataSource = dt;

                dtRobot = GlobalVariable.LoadCsvData(RoboReceipePath);

                dgv_Robot.DataSource = dtRobot;
                dgv_Robot.Columns[0].Width = 400;


                dgv_PickGantry.EnableHeadersVisualStyles = false;

                dgv_PickGantry.ColumnHeadersDefaultCellStyle.BackColor = Color.Beige;

            }
            catch (Exception ex)
            {
                Logger.WriteLog(Logger.LogType.Error, "ReceipeForm", "", ex.Message, ex.ToString());
            }
        }

        public void WriteDataTableToCsv(DataTable dataTable, string filePath)
        {
            try
            {
                if (tabRecipe.SelectedIndex == 0)
                {
                    GlobalVariable.LoadReceipeTables(dataTable, cmbSelGantry.SelectedValue.ToString().ToUpper());
                }
                else if (tabRecipe.SelectedIndex == 1)
                {
                    GlobalVariable.LoadReceipeTables(dataTable, "ROBOT");
                }
                // Create a StreamWriter to write to the CSV file
                if (File.Exists(filePath))
                {
                    using (StreamWriter writer = new StreamWriter(filePath))
                    {
                        // Write the column headers
                        for (int i = 0; i < dataTable.Columns.Count; i++)
                        {
                            writer.Write(dataTable.Columns[i].ColumnName);
                            if (i < dataTable.Columns.Count - 1)
                                writer.Write(',');
                        }
                        writer.WriteLine();

                        // Write the rows
                        foreach (DataRow row in dataTable.Rows)
                        {
                            for (int i = 0; i < dataTable.Columns.Count; i++)
                            {
                                writer.Write(row[i].ToString());
                                if (i < dataTable.Columns.Count - 1)
                                    writer.Write(',');
                            }
                            writer.WriteLine();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Recipe Param File is missing", "Recipe Group Manager Software", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog(Logger.LogType.Error, "ReceipeForm", "", ex.Message, ex.ToString());
            }
        }

        private void moveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            XmlNodeList xmlNodes = null;
            try
            {

                double Xposition = 0;
                double Yposition = 0;
                double Zposition = 0;
                int SelectedTab = tabRecipe.SelectedIndex;
                if (SelectedTab == 0)
                {
                    int selectedRow = dgv_PickGantry.CurrentCell.RowIndex;
                    string selectedValue = dgv_PickGantry.CurrentCell.Value.ToString();
                    Xposition = Convert.ToDouble(dgv_PickGantry.Rows[selectedRow].Cells["X"].Value);
                    Yposition = Convert.ToDouble(dgv_PickGantry.Rows[selectedRow].Cells["Y"].Value);
                    Zposition = Convert.ToDouble(dgv_PickGantry.Rows[selectedRow].Cells["Z"].Value);

                    if (selectedValue.ToLower().Contains("safe"))
                    {
                        SafePrioritynode = Selectednode.SelectSingleNode("SafePosition_Priority");
                        Operatingnode = SafePrioritynode;
                    }
                    else
                    {
                        Movementnode = Selectednode.SelectSingleNode("MovementPriority");
                        Operatingnode = Movementnode;
                    }
                    if (Operatingnode != null)
                    {
                        foreach (XmlNode node in Operatingnode.ChildNodes)
                        {

                            SelectedAxis = FindSelectedIndex(node.InnerText);

                            if (node.InnerText.ToLower().Contains("xaxis"))
                            {
                                MovePosition = Xposition;

                            }
                            else if (node.InnerText.ToLower().Contains("yaxis"))
                            {
                                MovePosition = Yposition;
                            }
                            else if (node.InnerText.ToLower().Contains("zaxis"))
                            {
                                MovePosition = Zposition;
                            }
                            CurrentAxisName = node.InnerText;


                            if (SelectedAxis != -1)
                            {
                                ServoAxis = ObjectList.MotorObj[SelectedAxis];

                                if (!ServoAxis.Move_Abs(MovePosition,
                                    GlobalVariable.g_lstAxisConfig[SelectedAxis].ManualSpeed,
                                    GlobalVariable.g_lstAxisConfig[SelectedAxis].Acc,
                                    GlobalVariable.g_lstAxisConfig[SelectedAxis].DeAcc, 5000))
                                {
                                    string err = node.InnerText + "_Move_cmd_Error";
                                    if (Enum.TryParse<ECode>(err, out var result))
                                    {
                                        GlobalVariable.AlarmTrigger(result, true, 1);
                                    }
                                }
                            }

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog(Logger.LogType.Error, "ReceipeForm", "", ex.Message, ex.ToString());
            }
        }

        private void teachToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int SelectedTab = tabRecipe.SelectedIndex;
            try
            {
                if (SelectedTab == 0)
                {
                    if (dgv_PickGantry.ReadOnly == false)
                    {
                        int selectedRow = dgv_PickGantry.CurrentCell.RowIndex;
                        dgv_PickGantry.Rows[selectedRow].Cells["X"].Value = Convert.ToDouble(txt_PrfPos_X1.Text);// / GlobalVariable.g_lstAxisConfig[X_Index].pulse_mm;
                        dgv_PickGantry.Rows[selectedRow].Cells["Y"].Value = Convert.ToDouble(txt_PrfPos_Y1.Text);// / GlobalVariable.g_lstAxisConfig[Y_Index].pulse_mm;
                        dgv_PickGantry.Rows[selectedRow].Cells["Z"].Value = Convert.ToDouble(txt_PrfPos_Z1.Text);// / GlobalVariable.g_lstAxisConfig[Z_Index].pulse_mm;
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog(Logger.LogType.Error, "ReceipeForm", "", ex.Message, ex.ToString());
            }
        }

        private void cmbSelGantry_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            int xCount = 0;
            int yCount = 0;
            int zCount = 0;

            try
            {
                if (xmlNode != null)
                {
                    Selectednode = xmlNode.Cast<XmlNode>().FirstOrDefault(x => x.Name.ToLower() == cmbSelGantry.SelectedValue.ToString().ToLower());

                    if (Selectednode != null && Selectednode.Name.ToLower() != "select")
                    {
                        xCount = 0;
                        yCount = 0;
                        zCount = 0;

                        if (!File.Exists(Teach_filepath + Selectednode.Name + "Receipe_Param.csv"))
                        {
                            MessageBox.Show("CSV file not found: " + Selectednode.Name + "Receipe_Param.csv");
                            dgv_PickGantry.DataSource = dt;
                            return;
                        }

                        dt = HelperClassLib.GetDataFromHelper.GetDataFromCSV(Teach_filepath + Selectednode.Name + "Receipe_Param.csv");
                        dgv_PickGantry.DataSource = dt;
                        dgv_PickGantry.Columns[0].Width = 150;
                        dt = new DataTable();
                        dt.Columns.Add("Axis");

                        Initnode = Selectednode.SelectSingleNode("MovementPriority");
                        foreach (XmlNode node in Initnode.ChildNodes)
                        {

                            DataRow dr = dt.NewRow();
                            dr[0] = node.InnerText;
                            dt.Rows.Add(dr);
                            if (node.InnerText.ToLower().Contains("xaxis"))
                            {
                                xCount = 1;

                                SelectedXAxis = node.InnerText;

                                X_Index = FindSelectedIndex(SelectedXAxis);
                            }
                            else if (node.InnerText.ToLower().Contains("yaxis"))
                            {
                                yCount = 1;

                                SelectedYAxis = node.InnerText;

                                Y_Index = FindSelectedIndex(SelectedYAxis);
                            }
                            else if (node.InnerText.ToLower().Contains("zaxis"))
                            {
                                zCount = 1;

                                SelectedZAxis = node.InnerText;

                                Z_Index = FindSelectedIndex(SelectedZAxis);
                            }
                        }

                        if (dt.Rows.Count > 0)
                        {
                            grpGantry.Visible = true;

                            if (xCount == 0)
                            {
                                btnXAdd.Enabled = false;
                                btnXDec.Enabled = false;
                            }
                            else if (yCount == 0)
                            {
                                btnYAdd.Enabled = false;
                                btnYDec.Enabled = false;
                            }
                            else if (zCount == 0)
                            {
                                btnZAdd.Enabled = false;
                                btnZDec.Enabled = false;
                            }
                        }
                    }
                    else
                    {
                        dgv_PickGantry.DataSource = dt;
                    }
                }
            }
            catch (Exception ex)
            {

                Logger.WriteLog(Logger.LogType.Error, "ReceipeForm", "", ex.Message, ex.ToString());
            }
        }

        private void RecipieForm_Load(object sender, EventArgs e)
        {
            cmbSelGantry.SelectedIndex = 0;
            LoadReceipe();

            dgv_PickGantry.Enabled = false;
            dgv_Robot.Enabled = false;

            btnSaveRobot.Visible = false;
        }

        #region X Axis Jog Functions

        private void btnXDec_MouseUp(object sender, MouseEventArgs e)
        {
            try
            {
                ServoAxis = ObjectList.MotorObj[X_Index];

                if (ServoAxis != null)
                {
                    ServoAxis.StopJog();
                    ServoAxis.Stop();
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog(Logger.LogType.Error, "RecipieForm", "", ex.Message, ex.ToString());
            }
        }

        private void btnXDec_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                CurrentAxis = X_Index;
                CurrentAxisName = "xaxis";
                ServoAxis = ObjectList.MotorObj[X_Index];

                if (ServoAxis != null)
                {
                    ServoAxis.Jog(1, GlobalVariable.g_lstAxisConfig[X_Index].ManualSpeed,
                        GlobalVariable.g_lstAxisConfig[X_Index].Acc, GlobalVariable.g_lstAxisConfig[X_Index].DeAcc);
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog(Logger.LogType.Error, "RecipieForm", "", ex.Message, ex.ToString());
            }
        }

        private void btnXAdd_MouseUp(object sender, MouseEventArgs e)
        {
            try
            {
                ServoAxis = ObjectList.MotorObj[X_Index];

                if (ServoAxis != null)
                {
                    ServoAxis.StopJog();
                    ServoAxis.Stop();
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog(Logger.LogType.Error, "RecipieForm", "", ex.Message, ex.ToString());
            }
        }

        private void btnXAdd_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                CurrentAxis = X_Index;
                CurrentAxisName = "xaxis";
                ServoAxis = ObjectList.MotorObj[X_Index];

                if (ServoAxis != null)
                {
                    ServoAxis.Jog(0, GlobalVariable.g_lstAxisConfig[X_Index].ManualSpeed,
                        GlobalVariable.g_lstAxisConfig[X_Index].Acc, GlobalVariable.g_lstAxisConfig[X_Index].DeAcc);
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog(Logger.LogType.Error, "RecipieForm", "", ex.Message, ex.ToString());
            }
        }
        #endregion

        #region Y Axis jog Functions

        private void btnYAdd_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                CurrentAxis = Y_Index;
                CurrentAxisName = "yaxis";
                ServoAxis = ObjectList.MotorObj[Y_Index];

                if (ServoAxis != null)
                {
                    ServoAxis.Jog(0, GlobalVariable.g_lstAxisConfig[Y_Index].ManualSpeed,
                        GlobalVariable.g_lstAxisConfig[Y_Index].Acc, GlobalVariable.g_lstAxisConfig[Y_Index].DeAcc);
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog(Logger.LogType.Error, "RecipieForm", "", ex.Message, ex.ToString());
            }
        }

        private void btnYAdd_MouseUp(object sender, MouseEventArgs e)
        {
            try
            {
                ServoAxis = ObjectList.MotorObj[Y_Index];

                if (ServoAxis != null)
                {
                    ServoAxis.StopJog();
                    ServoAxis.Stop();
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog(Logger.LogType.Error, "RecipieForm", "", ex.Message, ex.ToString());
            }
        }
        private void btnYDec_MouseUp(object sender, MouseEventArgs e)
        {
            try
            {
                ServoAxis = ObjectList.MotorObj[Y_Index];

                if (ServoAxis != null)
                {
                    ServoAxis.StopJog();
                    ServoAxis.Stop();
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog(Logger.LogType.Error, "RecipieForm", "", ex.Message, ex.ToString());
            }
        }

        private void btnYDec_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                CurrentAxis = Y_Index;
                CurrentAxisName = "yaxis";
                ServoAxis = ObjectList.MotorObj[Y_Index];

                if (ServoAxis != null)
                {
                    ServoAxis.Jog(1, GlobalVariable.g_lstAxisConfig[Y_Index].ManualSpeed,
                        GlobalVariable.g_lstAxisConfig[Y_Index].Acc, GlobalVariable.g_lstAxisConfig[Y_Index].DeAcc);
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog(Logger.LogType.Error, "RecipieForm", "", ex.Message, ex.ToString());
            }
        }
        #endregion

        #region Z Axis Jog Functions

        private void btnZDec_MouseUp(object sender, MouseEventArgs e)
        {
            try
            {
                ServoAxis = ObjectList.MotorObj[Z_Index];

                if (ServoAxis != null)
                {
                    ServoAxis.StopJog();
                    ServoAxis.Stop();
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog(Logger.LogType.Error, "RecipieForm", "", ex.Message, ex.ToString());
            }
        }

        private void btnZDec_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                CurrentAxis = Z_Index;
                CurrentAxisName = "zaxis";
                ServoAxis = ObjectList.MotorObj[Z_Index];

                if (ServoAxis != null)
                {
                    ServoAxis.Jog(1, GlobalVariable.g_lstAxisConfig[Z_Index].ManualSpeed,
                        GlobalVariable.g_lstAxisConfig[Z_Index].Acc, GlobalVariable.g_lstAxisConfig[Z_Index].DeAcc);
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog(Logger.LogType.Error, "RecipieForm", "", ex.Message, ex.ToString());
            }
        }

        private void btnZAdd_MouseUp(object sender, MouseEventArgs e)
        {
            try
            {
                ServoAxis = ObjectList.MotorObj[Z_Index];

                if (ServoAxis != null)
                {
                    ServoAxis.StopJog();
                    ServoAxis.Stop();
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog(Logger.LogType.Error, "RecipieForm", "", ex.Message, ex.ToString());
            }
        }

        private void btnZAdd_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                CurrentAxis = Z_Index;
                CurrentAxisName = "zaxis";
                ServoAxis = ObjectList.MotorObj[Z_Index];

                if (ServoAxis != null)
                {
                    ServoAxis.Jog(0, GlobalVariable.g_lstAxisConfig[Z_Index].ManualSpeed,
                        GlobalVariable.g_lstAxisConfig[Z_Index].Acc, GlobalVariable.g_lstAxisConfig[Z_Index].DeAcc);
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog(Logger.LogType.Error, "RecipieForm", "", ex.Message, ex.ToString());
            }
        }
        #endregion

        public int FindSelectedIndex(string selectedValue)
        {
            try
            {
                if (AxisTable.Rows.Count > 0)
                {
                    DataRow row = AxisTable.AsEnumerable().
                        FirstOrDefault(x => string.Equals(x.Field<string>("Servo"), selectedValue, StringComparison.OrdinalIgnoreCase));

                    if (row != null)
                    {
                        return AxisTable.Rows.IndexOf(row);
                    }
                }
                return 0;
            }
            catch (Exception ex)
            {
                Logger.WriteLog(Logger.LogType.Error, "RecipieForm", "", ex.Message, ex.ToString());
                return 0;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                if (CurrentAxis != -1)
                {
                    TmrServoAxis = ObjectList.MotorObj[CurrentAxis];

                    double ActPos = 0;
                    double ActPvel = 0;
                    string actstatus = "";
                    ServoAxis.GetCurrentPos(out ActPos, out actstatus, out ActPvel);
                    bool[] ioStatusArray = TmrServoAxis.ToGetMotionIOStatus();

                    if (CurrentAxisName.ToLower().Contains("xaxis"))
                    {
                        txt_PrfPos_X1.Text = ActPos.ToString("F2");
                    }
                    else if (CurrentAxisName.ToLower().Contains("yaxis"))
                    {
                        txt_PrfPos_Y1.Text = ActPos.ToString("F2");
                    }
                    else if (CurrentAxisName.ToLower().Contains("zaxis"))
                    {
                        txt_PrfPos_Z1.Text = ActPos.ToString("F2");
                    }

                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog(Logger.LogType.Error, "RecipieForm", "", ex.Message, ex.ToString());
            }
        }
    }
}
