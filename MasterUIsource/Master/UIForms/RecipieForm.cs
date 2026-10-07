using ExceptionLib;
using GRT_BG1.Function.Calibration;
using Master;
using Program;
using System;
using System.Configuration;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Xml;
using static DIO.DIDO;

namespace UI.UI_Forms
{
    

    public partial class RecipieForm : Form
    {
        public Advantech_PCIE ServoAxis;
        public Advantech_PCIE TmrServoAxis;

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
        public int Z1_Index = 0;
        public int Z2_Index = 0;
        public int R1_Index = 0;
        public int R2_Index = 0;

        int xCount = 0;
        int yCount = 0;
        int zCount = 0;
        int rCount = 0;


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
            lblselectPast.Enabled = false;
            chkbox_move.Enabled = false;
            checkvelocity.Enabled = false;
            lblmotorparam.Enabled = false;
            AxisTable.Columns.Add("Key", typeof(int));        // or typeof(DIDO.EAxis) if you want enum
            AxisTable.Columns.Add("Servo", typeof(string));   // keep same column name if you rely on "Servo"

            foreach (var kv in ObjectList.MotorObj)
            {
                AxisTable.Rows.Add((int)kv.Key, kv.Value.motor_Params.name);
            }

            var motorList = ObjectList.MotorObj
    .Select(kv => new
    {
        Key = kv.Key,
        Motor = kv.Value,
        Name = kv.Value.motor_Params.name
    })
    .ToList();


            cmbAxisMoveAbs.DataSource = motorList;
            cmbAxisMoveAbs.DisplayMember = "Name";
            cmbAxisMoveAbs.ValueMember = "Key";

            //cmbAxisMoveAbs.DataSource = GlobalV3riable.ServoRows.CopyToDataTable();
            //cmbAxisMoveAbs.DisplayMember = "Servo";
            //cmbAxisMoveAbs.ValueMember = "Servo";

            //cmbAxisMoveRel.DataSource = GlobalVariable.ServoRows.CopyToDataTable();
            //cmbAxisMoveRel.DisplayMember = "Servo";
            //cmbAxisMoveRel.ValueMember = "Servo";

            //AxisTable = GlobalVariable.ServoRows.CopyToDataTable();

            //cmbAxisMoveAbs.

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
           // txtPositionAbs.KeyPress += GlobalVariable.AllowOnlyDecimal_TextBox; 
            //txt_Position_Relative.KeyPress += GlobalVariable.AllowOnlyDecimal_TextBox;
            txtetSpeedAbs.KeyPress += GlobalVariable.AllowOnlyDecimal_TextBox;
            // txt_Speed_Relative.KeyPress += GlobalVariable.AllowOnlyDecimal_TextBox;
            ServoAxis = new Advantech_PCIE(0, "");
            btnEdit.Enabled = false;
            btnSave.Enabled = false;
            textBox62.Enabled = false;
            textBox63.Enabled = false;   
            textBox63.ReadOnly = true;  
            textBox62.ReadOnly = true;  


            //cmbAxisMoveAbs.Items.RemoveAt(3);
            //cmbAxisMoveAbs.Items.RemoveAt(4);
            //cmbAxisMoveAbs.Items.RemoveAt(5);
            //cmbAxisMoveAbs.Items.RemoveAt(6);

            foreach (DataGridViewColumn col in dgv_PickGantry.Columns)
            {
                col.DefaultCellStyle.Format = "N2";
            }

            dgv_PickGantry.ScrollBars = ScrollBars.Both;
            
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

        //private void cmbAxisMoveRel_Enter(object sender, EventArgs e)
        //{
        //    if (cmbAxisMoveRel.Text == "SELECT" && cmbAxisMoveRel.ForeColor == Color.Gray)
        //    {
        //        cmbAxisMoveRel.Text = "";
        //        cmbAxisMoveRel.ForeColor = Color.Black;
        //    }
        //}

        //private void cmbAxisMoveRel_Leave(object sender, EventArgs e)
        //{
        //    if (cmbAxisMoveRel.Text == "SELECT" && cmbAxisMoveRel.ForeColor == Color.Gray)
        //    {
        //        cmbAxisMoveRel.Text = "";
        //        cmbAxisMoveRel.ForeColor = Color.Black;
        //    }
        //}

        private void cmbAxisMoveAbs_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void cmbAxisMoveRel_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void cmbAxisMoveAbs_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmbSelGantry.SelectedIndex == 1)
                {
                    if (cmbAxisMoveAbs.SelectedIndex == 0)
                    {
                        cmbAxisMoveAbs.SelectedIndex = -1;
                        return;
                    }
                }
                else if (cmbSelGantry.SelectedIndex == 2)
                {
                    if (cmbAxisMoveAbs.SelectedIndex == 1 || cmbAxisMoveAbs.SelectedIndex == 2)
                    {
                        cmbAxisMoveAbs.SelectedIndex = -1;
                        return;
                    }
                }
                ServoAxis = ObjectList.MotorObj[(int)((dynamic)cmbAxisMoveAbs.SelectedItem).Key];
                if (((dynamic)cmbAxisMoveAbs.SelectedItem).Name.ToString() == "Servo_X1" || ((dynamic)cmbAxisMoveAbs.SelectedItem).Name.ToString() == "Servo_X2")
                {
                    getAxies();
                    Y_Index = -1;
                    Z1_Index = -1;
                    Z2_Index = -1;
                    R1_Index = -1;
                    R2_Index = -1;
                }
                else if (((dynamic)cmbAxisMoveAbs.SelectedItem).Name.ToString() == "Servo_Y1" || ((dynamic)cmbAxisMoveAbs.SelectedItem).Name.ToString() == "Servo_Y2")
                {
                    getAxies();
                    X_Index = -1;
                    Z1_Index = -1;
                    Z2_Index = -1;
                    R1_Index = -1;
                    R2_Index = -1;
                }
                else if (((dynamic)cmbAxisMoveAbs.SelectedItem).Name.ToString() == "Servo_Z1")
                {
                    getAxies();
                    X_Index = -1;
                    Y_Index = -1;
                    Z2_Index = -1;
                    R1_Index = -1;
                    R2_Index = -1;
                }
                else if (((dynamic)cmbAxisMoveAbs.SelectedItem).Name.ToString() == "Servo_Z2")
                {
                    getAxies();
                    X_Index = -1;
                    Y_Index = -1;
                    Z1_Index = -1;
                    R1_Index = -1;
                    R2_Index = -1;
                }
                else if (((dynamic)cmbAxisMoveAbs.SelectedItem).Name.ToString() == "Servo_R1")
                {
                    getAxies();
                    X_Index = -1;
                    Y_Index = -1;
                    Z2_Index = -1;
                    Z1_Index = -1;
                    R2_Index = -1;
                }
                else if (((dynamic)cmbAxisMoveAbs.SelectedItem).Name.ToString() == "Servo_R2")
                {
                    getAxies();
                    X_Index = -1;
                    Y_Index = -1;
                    Z2_Index = -1;
                    R1_Index = -1;
                    Z1_Index = -1;
                }
                //axisindex = cmbAxisMoveAbs.SelectedIndex;
                //ServoAxis = ObjectList.MotorObj[axisindex];

                //ServoAxis = ObjectList.MotorObj[(int)((dynamic)cmbAxisMoveAbs.SelectedItem).Key];
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

        //private void btnPTP_Positive_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        CurrentAxis = cmbAxisMoveRel.SelectedIndex;
        //        CurrentAxisName = cmbAxisMoveRel.SelectedValue.ToString();
        //        double dTargetPos = 0;
        //        if (txt_Position_Relative.Text.Trim() == "")
        //        {
        //            MessageBox.Show("Please Enter Position", "Manual Screen", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //            txt_Position_Relative.Focus();
        //            return;
        //        }
        //        if (txt_Speed_Relative.Text.Trim() == "")
        //        {
        //            MessageBox.Show("Please Enter Speed", "Manual Screen", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //            txt_Speed_Relative.Focus();
        //            return;
        //        }

        //        if (RelServoAxis != null)
        //        {
        //            if (!string.IsNullOrEmpty(txt_Position_Relative.Text))
        //            {
        //                dTargetPos = Convert.ToDouble(txt_Position_Relative.Text);
        //                if (double.TryParse(txt_Speed_Relative.Text, out double speedValue))
        //                {
        //                    btnPTP_Positive.Enabled = false;
        //                    if (!RelServoAxis.Move_Rel(dTargetPos, speedValue, GlobalVariable.g_lstAxisConfig[axisindex].Acc,
        //                        GlobalVariable.g_lstAxisConfig[axisindex].DeAcc, 5000))
        //                    {
        //                        //Logger.WriteLog("Device_Interface", "jogfrwrd()", "PCIE-1203_Interface", "Exception Error", es.ToString());
        //                    }
        //                    btnPTP_Positive.Enabled = true;
        //                }
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Logger.WriteLog(Logger.LogType.Error, "ReceipeForm", "", ex.Message, ex.ToString());
        //    }
        //}

        //private void btnPTP_Negative_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        CurrentAxis = cmbAxisMoveRel.SelectedIndex;
        //        CurrentAxisName = cmbAxisMoveRel.SelectedValue.ToString();
        //        double dTargetPos = 0;
        //        if (txt_Position_Relative.Text.Trim() == "")
        //        {
        //            MessageBox.Show("Please Enter Position", "Manual Screen", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //            txt_Position_Relative.Focus();
        //            return;
        //        }
        //        if (txt_Speed_Relative.Text.Trim() == "")
        //        {
        //            MessageBox.Show("Please Enter Speed", "Manual Screen", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //            txt_Speed_Relative.Focus();
        //            return;
        //        }

        //        if (RelServoAxis != null)
        //        {
        //            if (!string.IsNullOrEmpty(txt_Position_Relative.Text))
        //            {
        //                dTargetPos = Convert.ToDouble(txt_Position_Relative.Text);
        //                if (double.TryParse(txt_Speed_Relative.Text, out double speedValue))
        //                {
        //                    btnPTP_Positive.Enabled = false;
        //                    if (!RelServoAxis.Move_Rel(-dTargetPos, speedValue, GlobalVariable.g_lstAxisConfig[axisindex].Acc,
        //                        GlobalVariable.g_lstAxisConfig[axisindex].DeAcc, 5000))
        //                    {
        //                        //Logger.WriteLog("Device_Interface", "jogfrwrd()", "PCIE-1203_Interface", "Exception Error", es.ToString());
        //                    }
        //                    btnPTP_Positive.Enabled = true;
        //                }
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Logger.WriteLog(Logger.LogType.Error, "ReceipeForm", "", ex.Message, ex.ToString());
        //    }
        //}

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                if((GlobalVariable.bautoseq_running && GlobalVariable.current_MCStatus == GlobalVariable.MachineStatus.Pause) || (GlobalVariable.current_MCStatus == GlobalVariable.MachineStatus.Stop || GlobalVariable.current_MCStatus == GlobalVariable.MachineStatus.EStop || GlobalVariable.current_MCStatus == GlobalVariable.MachineStatus.Pause || GlobalVariable.current_MCStatus == GlobalVariable.MachineStatus.Ideal))
                {
                    int selectedTabIndex = cmbSelGantry.SelectedIndex;

                    if (selectedTabIndex >= 0)
                    {
                        dgv_PickGantry.ReadOnly = false;
                        dgv_PickGantry.Enabled = true;
                        if (selectedTabIndex == 2)
                        {
                            lblselectPast.Enabled = true;
                            chkbox_move.Enabled = true;
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Auto Seq is running....!","Info",MessageBoxButtons.OK,MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);
                }
                

            }
            catch (Exception ex)
            {
                Logger.WriteLog(Logger.LogType.Error, "ReceipeForm", "", ex.Message, ex.ToString());
            }
        }
        public void AppendSelectedModuleToHistory(DataTable dt, string moduleName)
        {
            try
            {
                string dir = @"D:\\TEAL\\Recipie_SaveHistory";
                if (!Directory.Exists(dir))
                    Directory.CreateDirectory(dir);


                //string historyPath = Path.Combine(Environment.CurrentDirectory, "Data", "Save_History.csv");
                string historyPath = Path.Combine(dir, DateTime.Now.Date.ToString("dd_MM_yyyy") + ".csv");
                bool writeHeader = !File.Exists(historyPath);
                using (StreamWriter writer = new StreamWriter(historyPath, true))
                {
                    if (writeHeader)
                    {
                        writer.WriteLine("Module,DateTime");
                    }
                    int rowCount = dt.Rows.Count;
                    writer.WriteLine($"Module_Name : {moduleName.ToUpper()} ");
                    writer.WriteLine("Date&Time : " + DateTime.Now.ToString());

                    writer.WriteLine();
                    writer.WriteLine(string.Join(",", dt.Columns.Cast<DataColumn>().Select(c => c.ColumnName)));
                    foreach (DataRow row in dt.Rows)
                    {
                        {
                            writer.WriteLine(string.Join(",", row.ItemArray.Select(x => x.ToString())));
                        }
                    }
                    writer.WriteLine();
                    writer.WriteLine();
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog(Logger.LogType.Error, "Save_History", "", ex.Message, ex.ToString());
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if ((GlobalVariable.bautoseq_running && GlobalVariable.current_MCStatus == GlobalVariable.MachineStatus.Pause) || (GlobalVariable.current_MCStatus == GlobalVariable.MachineStatus.Stop || GlobalVariable.current_MCStatus == GlobalVariable.MachineStatus.EStop || GlobalVariable.current_MCStatus == GlobalVariable.MachineStatus.Pause || GlobalVariable.current_MCStatus == GlobalVariable.MachineStatus.Ideal))
            {
                DataTable dt = new DataTable();
                try
                {
                    dgv_PickGantry.Enabled = false;
                    chkbox_move.Enabled = false;
                    lblselectPast.Enabled = false;

                    DialogResult result = MessageBox.Show("Do you want to save the Data", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        if (tabRecipe.SelectedIndex == 0)
                        {
                            if (cmbSelGantry.SelectedValue.ToString().ToLower() != "select")
                            {
                                dt = (DataTable)dgv_PickGantry.DataSource;

                                WriteDataTableToCsv(dt, Teach_filepath + cmbSelGantry.SelectedValue + "Receipe_Param.csv");
                                GlobalVariable.LoadReceipe();


                                AppendSelectedModuleToHistory(dt, cmbSelGantry.SelectedValue.ToString());

                            }
                            else
                            {
                                MessageBox.Show("Select valid Gantry to save the Receipe_Param");
                                return;
                            }

                        }
                        else if (tabRecipe.SelectedIndex == 1)
                        {

                            WriteDataTableToCsv(dt, RoboReceipePath);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Logger.WriteLog(Logger.LogType.Error, "ReceipeForm", "", ex.Message, ex.ToString());
                }
            }
            else
            {
                MessageBox.Show("Auto Seq is running....!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);
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
                        //dt = (DataTable)dgv_Robot.DataSource;

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

                //dgv_Robot.DataSource = dtRobot;
                //dgv_Robot.Columns[0].Width = 400;


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
                    MessageBox.Show("Recipe Param File is missing", "Recipe Group Manager Software", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);
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
                double R1position = 0;
                double R2position = 0;
                double Z1position = 0;
                double Z2position = 0;
               
                int SelectedTab = tabRecipe.SelectedIndex;
                if (SelectedTab == 0)
                {
                    int selectedRow = dgv_PickGantry.CurrentCell.RowIndex;
                    string selectedValue = dgv_PickGantry.CurrentCell.Value.ToString();
                    if (chkbox_move.Checked)
                    {
                        Xposition = Convert.ToDouble(dgv_PickGantry.Rows[selectedRow].Cells["CavityX"].Value);
                        Yposition = Convert.ToDouble(dgv_PickGantry.Rows[selectedRow].Cells["CavityY"].Value);
                        //Z1position = Convert.ToDouble(dgv_PickGantry.Rows[selectedRow].Cells["Z1"].Value);
                        //Z2position = Convert.ToDouble(dgv_PickGantry.Rows[selectedRow].Cells["Z2"].Value);                       
                        Z1position = GlobalVariable.SafePosition.PositionZ1;
                        Z2position = GlobalVariable.SafePosition.PositionZ2;
                        R1position = Convert.ToDouble(dgv_PickGantry.Rows[selectedRow].Cells["R1"].Value);
                        R2position = Convert.ToDouble(dgv_PickGantry.Rows[selectedRow].Cells["R2"].Value);
                        Z1position = Convert.ToDouble(dgv_PickGantry.Rows[selectedRow].Cells["Z1"].Value);
                        Z2position = Convert.ToDouble(dgv_PickGantry.Rows[selectedRow].Cells["Z2"].Value);
                       
                    }
                    else
                    {
                        Xposition = Convert.ToDouble(dgv_PickGantry.Rows[selectedRow].Cells["col(X)"].Value);
                        Yposition = Convert.ToDouble(dgv_PickGantry.Rows[selectedRow].Cells["Row(Y)"].Value);
                        Z1position = GlobalVariable.SafePosition.PositionZ1;
                        Z2position = GlobalVariable.SafePosition.PositionZ2;
                        //Z1position = Convert.ToDouble(dgv_PickGantry.Rows[selectedRow].Cells["Z1"].Value);
                        //Z2position = Convert.ToDouble(dgv_PickGantry.Rows[selectedRow].Cells["Z2"].Value);
                        //R1position = Convert.ToDouble(dgv_PickGantry.Rows[selectedRow].Cells["R1"].Value);
                        //R2position = Convert.ToDouble(dgv_PickGantry.Rows[selectedRow].Cells["R2"].Value);
                    }

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

                            if (node.InnerText.Contains("Servo_X1") || node.InnerText.Contains("Stepper_1") || node.InnerText.Contains("Servo_X2"))
                            {
                                MovePosition = Xposition;

                            }
                            else if (node.InnerText.Contains("Servo_Y1") || node.InnerText.Contains("Stepper_2") || node.InnerText.Contains("Servo_Y2"))
                            {
                                MovePosition = Yposition;
                            }
                            else if (node.InnerText.Contains("Servo_R1"))
                            {
                                MovePosition = R1position;
                            }
                            else if (node.InnerText.Contains("Servo_R2"))
                            {
                                MovePosition = R2position;
                            }
                            else if (node.InnerText.Contains("Servo_Z1"))
                            {
                                MovePosition = Z1position;
                            }
                            else if (node.InnerText.Contains("Servo_Z2"))
                            {
                                MovePosition = Z2position;
                            }
                          
                            CurrentAxisName = node.InnerText;

                            double R1posval = R1position; // AK
                            double R2posval = R2position; // AK

                            if ((node.InnerText.Contains("Servo_X1") || node.InnerText.Contains("Servo_Y1")))
                            {                               

                                ObjectList.Servo_Z1.Move_Abs(GlobalVariable.SafePosition.PositionZ1,
                                   GlobalVariable.g_lstAxisConfig[SelectedAxis].ManualSpeed, 
                                   GlobalVariable.g_lstAxisConfig[SelectedAxis].Acc,
                                   GlobalVariable.g_lstAxisConfig[SelectedAxis].DeAcc, 5000);

                                if (chkbox_move.Checked) // AK
                                {
                                    ObjectList.Servo_R1.Move_Abs(R1posval,
                                  GlobalVariable.g_lstAxisConfig[SelectedAxis].ManualSpeed,
                                  GlobalVariable.g_lstAxisConfig[SelectedAxis].Acc,
                                  GlobalVariable.g_lstAxisConfig[SelectedAxis].DeAcc, 5000);
                                }
                                ObjectList.Servo_Z2.Move_Abs(GlobalVariable.SafePosition.PositionZ2,
                                   GlobalVariable.g_lstAxisConfig[SelectedAxis].ManualSpeed, 
                                   GlobalVariable.g_lstAxisConfig[SelectedAxis].Acc,
                                   GlobalVariable.g_lstAxisConfig[SelectedAxis].DeAcc, 5000);

                                if (chkbox_move.Checked) // AK
                                {
                                    ObjectList.Servo_R2.Move_Abs(R2posval,
                                  GlobalVariable.g_lstAxisConfig[SelectedAxis].ManualSpeed,
                                  GlobalVariable.g_lstAxisConfig[SelectedAxis].Acc,
                                  GlobalVariable.g_lstAxisConfig[SelectedAxis].DeAcc, 5000);
                                }

                            }
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
            DialogResult result = MessageBox.Show("Allowed To Edit confirmation", "TeachPosition", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (result == DialogResult.OK)
            {
                int SelectedTab = tabRecipe.SelectedIndex;
                try
                {
                    if (SelectedTab == 0)
                    {
                        if (dgv_PickGantry.ReadOnly == false)
                        {
                            int selectedRow = dgv_PickGantry.CurrentCell.RowIndex;
                            if (cmbSelGantry.SelectedIndex == 1)
                            {
                                dgv_PickGantry.Rows[selectedRow].Cells["col(X)"].Value = Convert.ToDouble(txt_PrfPos_X1.Text);//
                                dgv_PickGantry.Rows[selectedRow].Cells["Row(Y)"].Value = Convert.ToDouble(txt_PrfPos_Y1.Text);// 
                            }
                            else if (cmbSelGantry.SelectedIndex == 2)
                            {
                                if (!chkbox_move.Checked)
                                {
                                    dgv_PickGantry.Rows[selectedRow].Cells["col(X)"].Value = Convert.ToDouble(txt_PrfPos_X1.Text);//
                                    dgv_PickGantry.Rows[selectedRow].Cells["Row(Y)"].Value = Convert.ToDouble(txt_PrfPos_Y1.Text);// 
                                }
                                else
                                {
                                    dgv_PickGantry.Rows[selectedRow].Cells["CavityX"].Value = Convert.ToDouble(txt_PrfPos_X1.Text);//
                                    dgv_PickGantry.Rows[selectedRow].Cells["CavityY"].Value = Convert.ToDouble(txt_PrfPos_Y1.Text);// 
                                }
                                dgv_PickGantry.Rows[selectedRow].Cells["Z1"].Value = Convert.ToDouble(txt_PrfPos_Z1.Text);//
                                dgv_PickGantry.Rows[selectedRow].Cells["Z2"].Value = Convert.ToDouble(txt_PrfPos_Z2.Text);
                                dgv_PickGantry.Rows[selectedRow].Cells["R1"].Value = Convert.ToDouble(txt_PrfPos_R1.Text);//
                                dgv_PickGantry.Rows[selectedRow].Cells["R2"].Value = Convert.ToDouble(txt_PrfPos_R2.Text);//
                            }
                            if (cmbSelGantry.SelectedIndex == 3)
                            {
                                dgv_PickGantry.Rows[selectedRow].Cells["col(X)"].Value = Convert.ToDouble(txt_PrfPos_X1.Text);//
                                dgv_PickGantry.Rows[selectedRow].Cells["Row(Y)"].Value = Convert.ToDouble(txt_PrfPos_Y1.Text);// 
                            }
                        }
                    }

                }
                catch (Exception ex)
                {
                    Logger.WriteLog(Logger.LogType.Error, "ReceipeForm", "", ex.Message, ex.ToString());
                }
            }
            else if (result == DialogResult.Cancel)
            {
                return;
            }
        }

        private void cmbSelGantry_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();


            try
            {
                if (xmlNode != null)
                {
                    Selectednode = xmlNode.Cast<XmlNode>().FirstOrDefault(x => x.Name.ToLower() == cmbSelGantry.SelectedValue.ToString().ToLower());

                    if (Selectednode != null && Selectednode.Name.ToLower() != "select")
                    {
                        btnEdit.Enabled = true;
                        btnSave.Enabled = true;
                        chkbox_move.Enabled = false;
                        lblselectPast.Enabled = false;
                        checkvelocity.Enabled = true;
                        lblmotorparam.Enabled = true;
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

                        hideColumn(checkvelocity.Checked);

                        dgv_PickGantry.Columns[0].Width = 150;
                        dt = new DataTable();
                        dt.Columns.Add("Axis");

                        Initnode = Selectednode.SelectSingleNode("MovementPriority");
                        getAxies();
                        if (dt.Rows.Count > 0)
                        {
                            grpGantry.Visible = true;

                            btnXAdd.Enabled = true;
                            btnXDec.Enabled = true;
                            btnYAdd.Enabled = true;
                            btnYDec.Enabled = true;
                            btnZ1Add.Enabled = true;
                            btnZ1Dec.Enabled = true;

                            if (xCount == 0)
                            {
                                btnXAdd.Enabled = false;
                                btnXDec.Enabled = false;
                            }
                            if (yCount == 0)
                            {
                                btnYAdd.Enabled = false;
                                btnYDec.Enabled = false;
                            }
                            if (zCount == 0)
                            {
                                btnZ1Add.Enabled = false;
                                btnZ1Dec.Enabled = false;
                            }
                        }

                        grpGantry.Text = cmbSelGantry.Text;
                    }
                    else
                    {
                        btnEdit.Enabled = false;
                        btnSave.Enabled = false;
                        chkbox_move.Enabled = false;
                        lblselectPast.Enabled = false;
                        dgv_PickGantry.DataSource = dt;
                        grpGantry.Text = "Gantry";
                    }
                }

                foreach (DataGridViewColumn col in dgv_PickGantry.Columns)
                {
                    col.DefaultCellStyle.Format = "N2";
                    col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                }
            }
            catch (Exception ex)
            {

                Logger.WriteLog(Logger.LogType.Error, "ReceipeForm", "", ex.Message, ex.ToString());
            }
        }

        public void getAxies()
        {
            foreach (XmlNode node in Initnode.ChildNodes)
            {


                if (node.InnerText.Contains("Servo_X1") || node.InnerText.Contains("Servo_X2"))
                {
                    xCount = 1;

                    SelectedXAxis = node.InnerText;

                    X_Index = FindSelectedIndex(SelectedXAxis);
                }
                else if (node.InnerText.Contains("Servo_Y1") || node.InnerText.Contains("Servo_Y2"))
                {
                    yCount = 1;

                    SelectedYAxis = node.InnerText;

                    Y_Index = FindSelectedIndex(SelectedYAxis);
                }
                else if (node.InnerText.Contains("Servo_Z1"))
                {
                    zCount = 1;

                    SelectedZAxis = node.InnerText;

                    Z1_Index = FindSelectedIndex(SelectedZAxis);
                }
                else if (node.InnerText.Contains("Servo_Z2"))
                {
                    zCount = 1;

                    SelectedZAxis = node.InnerText;

                    Z2_Index = FindSelectedIndex(SelectedZAxis);
                }
                else if (node.InnerText.Contains("Servo_R1"))
                {
                    rCount = 1;

                    SelectedZAxis = node.InnerText;

                    R1_Index = FindSelectedIndex(SelectedZAxis);
                }
                else if (node.InnerText.Contains("Servo_R2"))
                {
                    rCount = 1;

                    SelectedZAxis = node.InnerText;

                    R2_Index = FindSelectedIndex(SelectedZAxis);
                }
            }
        }


        private void RecipieForm_Load(object sender, EventArgs e)
        {
            cmbSelGantry.SelectedIndex = 0;
            LoadReceipe();

            dgv_PickGantry.Enabled = false;
            //dgv_Robot.Enabled = false;

            //btnSaveRobot.Visible = false;
        }

        #region X Axis Jog Functions

        private void btnXDec_MouseUp(object sender, MouseEventArgs e)
        {
            try
            {
                ServoAxis = ObjectList.MotorObj[X_Index];

                if (ServoAxis != null)
                {
                    if (cmbMoveMode.SelectedIndex == 1)//JOG
                    {
                        ServoAxis.StopJog();
                        ServoAxis.Stop();
                    }
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
                CurrentAxisName = "Servo_X1 and Servo_X2";
                ServoAxis = ObjectList.MotorObj[X_Index];
                double Speed = Convert.ToDouble(txtetSpeedAbs.Text);
                if (ServoAxis != null)
                {
                    if (((dynamic)cmbAxisMoveAbs.SelectedItem).Name.ToString() == "Servo_X1")
                    {
                        if (!NozzleSystem.nozzleZ1Z2Safe())
                            return;
                    }
                    if (cmbMoveMode.SelectedIndex == 1)//JOG
                    {
                        ServoAxis.Jog(1, Speed,
                        GlobalVariable.g_lstAxisConfig[X_Index].Acc, GlobalVariable.g_lstAxisConfig[X_Index].DeAcc);
                    }
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
                    if (cmbMoveMode.SelectedIndex == 1)//JOG
                    {
                        ServoAxis.StopJog();
                        ServoAxis.Stop();
                    }
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
                CurrentAxisName = "Servo_X1 and Servo_X2";
                ServoAxis = ObjectList.MotorObj[X_Index];
                double Speed = Convert.ToDouble(txtetSpeedAbs.Text);
                if (ServoAxis != null)
                {
                    if (((dynamic)cmbAxisMoveAbs.SelectedItem).Name.ToString() == "Servo_X1")
                    {
                        if (!NozzleSystem.nozzleZ1Z2Safe())
                            return;
                    }
                    if (cmbMoveMode.SelectedIndex == 1)//JOG
                    {
                        ServoAxis.Jog(0, Speed,
                        GlobalVariable.g_lstAxisConfig[X_Index].Acc, GlobalVariable.g_lstAxisConfig[X_Index].DeAcc);
                    }
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
                CurrentAxisName = "Servo_Y1 and Servo_Y2";
                ServoAxis = ObjectList.MotorObj[Y_Index];
                double Speed = Convert.ToDouble(txtetSpeedAbs.Text);
                if (ServoAxis != null)
                {
                    if (((dynamic)cmbAxisMoveAbs.SelectedItem).Name.ToString() == "Servo_Y1")
                    {
                        if (!NozzleSystem.nozzleZ1Z2Safe())
                            return;
                    }
                    if (cmbMoveMode.SelectedIndex == 1)//JOG
                    {
                        ServoAxis.Jog(0, Speed,
                        GlobalVariable.g_lstAxisConfig[Y_Index].Acc, GlobalVariable.g_lstAxisConfig[Y_Index].DeAcc);
                    }
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
                    if (cmbMoveMode.SelectedIndex == 1)//JOG
                    {
                        ServoAxis.StopJog();
                        ServoAxis.Stop();
                    }
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
                    if (cmbMoveMode.SelectedIndex == 1)//JOG
                    {
                        ServoAxis.StopJog();
                        ServoAxis.Stop();
                    }
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
                CurrentAxisName = "Servo_Y1 and Servo_Y2";
                ServoAxis = ObjectList.MotorObj[Y_Index];
                double Speed = Convert.ToDouble(txtetSpeedAbs.Text);
                if (ServoAxis != null)
                {
                    if (((dynamic)cmbAxisMoveAbs.SelectedItem).Name.ToString() == "Servo_Y1")
                    {
                        if (!NozzleSystem.nozzleZ1Z2Safe())
                            return;
                    }
                    if (cmbMoveMode.SelectedIndex == 1)//JOG
                    {
                        ServoAxis.Jog(1, Speed,
                        GlobalVariable.g_lstAxisConfig[Y_Index].Acc, GlobalVariable.g_lstAxisConfig[Y_Index].DeAcc);
                    }
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
                ServoAxis = ObjectList.MotorObj[Z1_Index];

                if (ServoAxis != null)
                {
                    if (cmbMoveMode.SelectedIndex == 1)//JOG
                    {
                        ServoAxis.StopJog();
                        ServoAxis.Stop();
                    }
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
                CurrentAxis = Z1_Index;
                CurrentAxisName = "Servo_Z1";
                ServoAxis = ObjectList.MotorObj[Z1_Index];
                double Speed = Convert.ToDouble(txtetSpeedAbs.Text);
                if (ServoAxis != null)
                {
                    if (cmbMoveMode.SelectedIndex == 1)//JOG
                    {
                        ServoAxis.Jog(1, Speed,
                        GlobalVariable.g_lstAxisConfig[Z1_Index].Acc, GlobalVariable.g_lstAxisConfig[Z1_Index].DeAcc);
                    }
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
                ServoAxis = ObjectList.MotorObj[Z1_Index];

                if (ServoAxis != null)
                {
                    if (cmbMoveMode.SelectedIndex == 1)//JOG
                    {
                        ServoAxis.StopJog();
                        ServoAxis.Stop();
                    }
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
                CurrentAxis = Z1_Index;
                CurrentAxisName = "Servo_Z1";
                ServoAxis = ObjectList.MotorObj[Z1_Index];
                double Speed = Convert.ToDouble(txtetSpeedAbs.Text);
                if (ServoAxis != null)
                {
                    if (cmbMoveMode.SelectedIndex == 1)//JOG
                    {
                        ServoAxis.Jog(0, Speed,
                        GlobalVariable.g_lstAxisConfig[Z1_Index].Acc, GlobalVariable.g_lstAxisConfig[Z1_Index].DeAcc);
                    }
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
        double Z1Axis = 0;
        double XAxis = 0;
        double FlipperAxis = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                // Z1Axis = ObjectList.Servo_Z1.GetCurrentPosition();
                //  XAxis = ObjectList.Servo_X1.GetCurrentPosition();
                //FlipperAxis = ObjectList.FlipperAxis.GetCurrentPosition();
                //txt_PrfPos_X1.Text = XAxis.ToString("F2");
                //txt_PrfPos_Y1.Text = FlipperAxis.ToString("F2");
                //txt_PrfPos_Z1.Text = ZAxis.ToString("F2");
                //CurrentAxis = (int)((dynamic)cmbAxisMoveAbs.SelectedItem).Key;
                //while(GlobalVariable.loadconverz2 != 0)
                //{
                    textBox62.Text = GlobalVariable.loadconverz2.ToString();
                    textBox63.Text = GlobalVariable.loadconverz1.ToString();
                //}
                //for (int i = 0; i < 100; i++)
                //{
                //    textBox62.Text = i.ToString();
                //    textBox63.Text = i.ToString();
                //}
                    if (CurrentAxis != -1)
                {
                    TmrServoAxis = ObjectList.MotorObj[CurrentAxis];

                    double ActPos = 0;
                    double ActPvel = 0;
                    string actstatus = "";
                    ServoAxis.GetCurrentPos(out ActPos, out actstatus, out ActPvel);
                    bool[] ioStatusArray = TmrServoAxis.ToGetMotionIOStatus();

                    if (CurrentAxisName.Contains("Servo_X1") || CurrentAxisName.Contains("Servo_X2"))
                    {
                        txt_PrfPos_X1.Text = ActPos.ToString("F2");
                    }
                    else if (CurrentAxisName.Contains("Servo_Y1") || CurrentAxisName.Contains("Servo_Y2"))
                    {
                        txt_PrfPos_Y1.Text = ActPos.ToString("F2");
                    }
                    else if (CurrentAxisName.Contains("Servo_Z1"))
                    {
                        txt_PrfPos_Z1.Text = ActPos.ToString("F2");
                    }
                    else if (CurrentAxisName.Contains("Servo_Z2"))
                    {
                        txt_PrfPos_Z2.Text = ActPos.ToString("F2");
                    }
                    else if (CurrentAxisName.Contains("Servo_R2"))
                    {
                        txt_PrfPos_R2.Text = ActPos.ToString("F2");
                    }
                    else if (CurrentAxisName.Contains("Servo_R1"))
                    {
                        txt_PrfPos_R1.Text = ActPos.ToString("F2");
                    }



                }


            }
            catch (Exception ex)
            {
                Logger.WriteLog(Logger.LogType.Error, "RecipieForm", "", ex.Message, ex.ToString());
            }
        }

        //Arulkumar_27_11_2025 - 
        private void tabRecipe_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (tabRecipe.SelectedIndex == 1)
                {
                    panel2.Visible = false;
                    btnEdit.Enabled = true;
                }
                else
                {
                    panel2.Visible = true;
                    var selectedTab = tabRecipe.SelectedTab;
                    grpGantry.Text = (selectedTab.Text.ToLower() == "robot") ? "Robot" : "Gantry";
                    if (grpGantry.Text == "Gantry" & cmbSelGantry.Text != "Select")
                    {
                        grpGantry.Text = cmbSelGantry.Text;
                    }
                    cmbMoveMode.SelectedIndex = 0;
                    cmbAxisMoveAbs.SelectedIndex = 0;
                    txtetSpeedAbs.Text = "";
                    txtPositionAbs.Text = "";
                    txt_PrfPos_X1.Text = "0";
                    txt_PrfPos_Y1.Text = "0";
                    txt_PrfPos_Z1.Text = "0";
                    
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog(Logger.LogType.Error, "RecipieForm", "", ex.Message, ex.ToString());
            }
        }

        private void cmbMoveMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbMoveMode.SelectedIndex == 1)//JOG
            {
                ////Arulkumar_27_11_2025
                lblMoveAbsPos.Visible = true;
                txtPositionAbs.Visible = false;
                lblServoX_TargetPosition.Visible = false;
                btnMoveAbs.Visible = false;
                grpGantry.Enabled = true;
                grpGantry2.Enabled = true;
                //cmbAxisMoveAbs.Enabled = false;
                cmbAxisMoveAbs.Enabled = true;

                
                //lblMoveAbsPos.Visible = false;
                //txtPositionAbs.Visible = false;
                //lblServoX_TargetPosition.Visible = false;
                //btnMoveAbs.Visible = false;
                //grpGantry.Enabled = true;
                //cmbAxisMoveAbs.Enabled = false;
            }
            else
            {
                lblMoveAbsPos.Visible = true;
                txtPositionAbs.Visible = true;
                lblServoX_TargetPosition.Visible = true;
                btnMoveAbs.Visible = true;
                grpGantry.Enabled = false;
                grpGantry2.Enabled = false;
                cmbAxisMoveAbs.Enabled = true;
            }
        }

        private void btnMoveAbs_Click(object sender, EventArgs e)
        {
            try
            {
                //CurrentAxis = cmbAxisMoveAbs.SelectedIndex;
                //CurrentAxisName = cmbAxisMoveAbs.SelectedValue.ToString();
                if (txtPositionAbs.Text.Trim() == "")
                {
                    MessageBox.Show("Please Enter Position", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (txtetSpeedAbs.Text.Trim() == "")
                {
                    MessageBox.Show("Please Enter Speed", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                            if (!ServoAxis.Move_Abs(dTargetPos, speedValue, GlobalVariable.g_lstAxisConfig[axisindex].Acc,
                                GlobalVariable.g_lstAxisConfig[axisindex].DeAcc, 5000))
                            {
                                //Logger.WriteLog("Device_Interface", "jogfrwrd()", "PCIE-1203_Interface", "Exception Error", es.ToString());
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Kindly Enter the vaild TargetPosition ", "Receipe", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);
                    }
                }
                else
                {
                    MessageBox.Show("Axis is not selected ", "Receipe", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);

                }
            }
            catch (Exception ex)
            {
                //Arulkumar Fixed random stoppage start
                Logger.WriteLog(Logger.LogType.Error, "RecipieForm", "Recipe_Move_Handler", ex.Message, ex.ToString());
                //Arulkumar Fixed random stoppage end
            }
        }

        private void txtetSpeedAbs_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox txt = sender as TextBox;
            GlobalVariable.ApplyTextBoxConfig(txt, "CrrCynSpeedLen", e, allowDecimal: true, allowMinus: false);
            if (txt.Text.Length == 0 && e.KeyChar == '0')
                e.Handled = true;
        }


        

        private void contextMenuStrip1_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }

        private void btnYDec_Click(object sender, EventArgs e)
        {

        }

        #region Z2 Axis Jog Functions
        private void btnZ2Dec_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                CurrentAxis = Z2_Index;
                CurrentAxisName = "Servo_Z2";
                ServoAxis = ObjectList.MotorObj[Z2_Index];
                double Speed = Convert.ToDouble(txtetSpeedAbs.Text);
                if (ServoAxis != null)
                {
                    if (cmbMoveMode.SelectedIndex == 1)//JOG
                    {
                        ServoAxis.Jog(1, Speed,
                        GlobalVariable.g_lstAxisConfig[Z2_Index].Acc, GlobalVariable.g_lstAxisConfig[Z2_Index].DeAcc);
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog(Logger.LogType.Error, "RecipieForm", "", ex.Message, ex.ToString());
            }
        }

        private void btnZ2Dec_MouseUp(object sender, MouseEventArgs e)
        {
            try
            {
                ServoAxis = ObjectList.MotorObj[Z2_Index];

                if (ServoAxis != null)
                {
                    if (cmbMoveMode.SelectedIndex == 1)//JOG
                    {
                        ServoAxis.StopJog();
                        ServoAxis.Stop();
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog(Logger.LogType.Error, "RecipieForm", "", ex.Message, ex.ToString());
            }
        }

        private void btnZ2Add_MouseUp(object sender, MouseEventArgs e)
        {
            try
            {
                ServoAxis = ObjectList.MotorObj[Z2_Index];

                if (ServoAxis != null)
                {
                    if (cmbMoveMode.SelectedIndex == 1)//JOG
                    {
                        ServoAxis.StopJog();
                        ServoAxis.Stop();
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog(Logger.LogType.Error, "RecipieForm", "", ex.Message, ex.ToString());
            }
        }

        private void btnZ2Add_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                CurrentAxis = Z2_Index;
                CurrentAxisName = "Servo_Z2";
                ServoAxis = ObjectList.MotorObj[Z2_Index];
                double Speed = Convert.ToDouble(txtetSpeedAbs.Text);
                if (ServoAxis != null)
                {
                    if (cmbMoveMode.SelectedIndex == 1)//JOG
                    {
                        ServoAxis.Jog(0, Speed,
                        GlobalVariable.g_lstAxisConfig[Z2_Index].Acc, GlobalVariable.g_lstAxisConfig[Z2_Index].DeAcc);
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog(Logger.LogType.Error, "RecipieForm", "", ex.Message, ex.ToString());
            }
        }
        #endregion

        #region R1 Axis Jog Functions
        private void btnR1Dec_MouseUp(object sender, MouseEventArgs e)
        {
            try
            {
                ServoAxis = ObjectList.MotorObj[R1_Index];

                if (ServoAxis != null)
                {
                    if (cmbMoveMode.SelectedIndex == 1)//JOG
                    {
                        ServoAxis.StopJog();
                        ServoAxis.Stop();
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog(Logger.LogType.Error, "RecipieForm", "", ex.Message, ex.ToString());
            }
        }

        private void btnR1Dec_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                CurrentAxis = R1_Index;
                CurrentAxisName = "Servo_R1";
                ServoAxis = ObjectList.MotorObj[R1_Index];
                double Speed = Convert.ToDouble(txtetSpeedAbs.Text);
                if (ServoAxis != null)
                {
                    if (cmbMoveMode.SelectedIndex == 1)//JOG
                    {
                        ServoAxis.Jog(1, Speed,
                        GlobalVariable.g_lstAxisConfig[R1_Index].Acc, GlobalVariable.g_lstAxisConfig[R1_Index].DeAcc);
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog(Logger.LogType.Error, "RecipieForm", "", ex.Message, ex.ToString());
            }
        }

        private void btnR1Add_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                CurrentAxis = R1_Index;
                CurrentAxisName = "Servo_R1";
                ServoAxis = ObjectList.MotorObj[R1_Index];
                double Speed = Convert.ToDouble(txtetSpeedAbs.Text);
                if (ServoAxis != null)
                {
                    if (cmbMoveMode.SelectedIndex == 1)//JOG
                    {
                        ServoAxis.Jog(0, Speed,
                        GlobalVariable.g_lstAxisConfig[R1_Index].Acc, GlobalVariable.g_lstAxisConfig[R1_Index].DeAcc);
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog(Logger.LogType.Error, "RecipieForm", "", ex.Message, ex.ToString());
            }
        }


        private void btnR1Add_MouseUp(object sender, MouseEventArgs e)
        {
            try
            {
                ServoAxis = ObjectList.MotorObj[R1_Index];

                if (ServoAxis != null)
                {
                    if (cmbMoveMode.SelectedIndex == 1)//JOG
                    {
                        ServoAxis.StopJog();
                        ServoAxis.Stop();
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog(Logger.LogType.Error, "RecipieForm", "", ex.Message, ex.ToString());
            }
        }
        #endregion
        #region R2 Axis Jog Functions
        private void btnR2Dec_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                CurrentAxis = R2_Index;
                CurrentAxisName = "Servo_R2";
                ServoAxis = ObjectList.MotorObj[R2_Index];
                double Speed = Convert.ToDouble(txtetSpeedAbs.Text);
                if (ServoAxis != null)
                {
                    if (cmbMoveMode.SelectedIndex == 1)//JOG
                    {
                        ServoAxis.Jog(1, Speed,
                        GlobalVariable.g_lstAxisConfig[R2_Index].Acc, GlobalVariable.g_lstAxisConfig[R2_Index].DeAcc);
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog(Logger.LogType.Error, "RecipieForm", "", ex.Message, ex.ToString());
            }
        }

        private void btnR2Dec_MouseUp(object sender, MouseEventArgs e)
        {
            try
            {
                ServoAxis = ObjectList.MotorObj[R2_Index];

                if (ServoAxis != null)
                {
                    if (cmbMoveMode.SelectedIndex == 1)//JOG
                    {
                        ServoAxis.StopJog();
                        ServoAxis.Stop();
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog(Logger.LogType.Error, "RecipieForm", "", ex.Message, ex.ToString());
            }
        }


        private void btnR2Add_MouseUp(object sender, MouseEventArgs e)
        {
            try
            {
                ServoAxis = ObjectList.MotorObj[R2_Index];

                if (ServoAxis != null)
                {
                    if (cmbMoveMode.SelectedIndex == 1)//JOG
                    {
                        ServoAxis.StopJog();
                        ServoAxis.Stop();
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog(Logger.LogType.Error, "RecipieForm", "", ex.Message, ex.ToString());
            }
        }

        private void btnR2Add_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                CurrentAxis = R2_Index;
                CurrentAxisName = "Servo_R2";
                ServoAxis = ObjectList.MotorObj[R2_Index];
                double Speed = Convert.ToDouble(txtetSpeedAbs.Text);
                if (ServoAxis != null)
                {
                    if (cmbMoveMode.SelectedIndex == 1)//JOG
                    {
                        ServoAxis.Jog(0, Speed,
                        GlobalVariable.g_lstAxisConfig[R2_Index].Acc, GlobalVariable.g_lstAxisConfig[R2_Index].DeAcc);
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog(Logger.LogType.Error, "RecipieForm", "", ex.Message, ex.ToString());
            }
        }
        #endregion

        private void btnR1Add_Click(object sender, EventArgs e)
        {

        }

        private void hideColumn(bool check)
        {

            dgv_PickGantry.Columns["X-Vel (mm)"].Visible = check;
            dgv_PickGantry.Columns["X DeAcc"].Visible = check;
            dgv_PickGantry.Columns["X Acc (mm/s)"].Visible = check;
            dgv_PickGantry.Columns["Y-Vel (mm)"].Visible = check;
            dgv_PickGantry.Columns["Y DeAcc"].Visible = check;
            dgv_PickGantry.Columns["Y Acc (mm/s)"].Visible = check;
           

            dgv_PickGantry.Columns["col(X)"].Visible = !check;
            dgv_PickGantry.Columns["Row(Y)"].Visible = !check;
            if (dgv_PickGantry.Columns["CavityX"] != null)
            {
                dgv_PickGantry.Columns["Z-Vel (mm)"].Visible = check;
                dgv_PickGantry.Columns["Z Acc (mm/s)"].Visible = check;
                dgv_PickGantry.Columns["Z DeAcc"].Visible = check;
                dgv_PickGantry.Columns["R-Vel (mm)"].Visible = check;
                dgv_PickGantry.Columns["R Acc (mm/s)"].Visible = check;
                dgv_PickGantry.Columns["R DeAcc"].Visible = check;
                dgv_PickGantry.Columns["X-PreVel (mm)"].Visible = check;
                dgv_PickGantry.Columns["X PreDeAcc"].Visible = check;
                dgv_PickGantry.Columns["X PreAcc (mm/s)"].Visible = check;
                dgv_PickGantry.Columns["Y-PreVel (mm)"].Visible = check;
                dgv_PickGantry.Columns["Y PreDeAcc"].Visible = check;
                dgv_PickGantry.Columns["Y PreAcc (mm/s)"].Visible = check;
                dgv_PickGantry.Columns["Z1"].Visible = !check;
                dgv_PickGantry.Columns["Z2"].Visible = !check;
                dgv_PickGantry.Columns["R1"].Visible = !check;
                dgv_PickGantry.Columns["R2"].Visible = !check;
                dgv_PickGantry.Columns["CavityX"].Visible = !check;
                dgv_PickGantry.Columns["CavityY"].Visible = !check;
            }
        }


        private void checkvelocity_CheckedChanged(object sender, EventArgs e)
        {
            hideColumn(checkvelocity.Checked);
        }


        //Arulkumar_27_11_25
        //Recipe_Screen

        private void txtetSpeedAbs_MouseDown(object sender, MouseEventArgs e)
        {
            // Disable right-click context menu
            if (e.Button == MouseButtons.Right)
            {
                ((TextBox)sender).ContextMenu = new ContextMenu(); // Assign empty menu
                return;
            }
        }

        private void txtetSpeedAbs_MouseUp(object sender, MouseEventArgs e)
        {
            // Prevent paste via mouse right-click
            if (e.Button == MouseButtons.Right)
            {
                return;
            }
        }

        //===============Bug_ID_ FIX_60 Start =================
        private void txtetSpeedAbs_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && (e.KeyCode == Keys.C || e.KeyCode == Keys.V || e.KeyCode == Keys.X))
            {
                e.SuppressKeyPress = true;
            }

        }
        //===============Bug_ID_ FIX_60 Start =================

        


        //position  right-click context menu
        private void txtPositionAbs_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox txt = sender as TextBox;
            GlobalVariable.ApplyTextBoxConfig(txt, "CrrCynSpeedLen", e, allowDecimal: true, allowMinus: true);
        }

        //===============Bug_ID_ FIX_60 Start =================
        private void txtPositionAbs_MouseDown(object sender, MouseEventArgs e)
        {
            // Disable right-click context menu
            if (e.Button == MouseButtons.Right)
            {
                ((TextBox)sender).ContextMenu = new ContextMenu(); // Assign empty menu
                return;
            }
        }
        
        private void txtPositionAbs_MouseUp(object sender, MouseEventArgs e)
        {
            // Prevent paste via mouse right-click
            if (e.Button == MouseButtons.Right)
            {
                return;
            }
        }

        //===============Bug_ID_ FIX_60 Start =================

        private void txtPositionAbs_KeyDown(object sender, KeyEventArgs e)
        {
             if (e.Control && (e.KeyCode == Keys.C || e.KeyCode == Keys.V || e.KeyCode == Keys.X))
            {
                e.SuppressKeyPress = true;
            }
        }

    }
}
