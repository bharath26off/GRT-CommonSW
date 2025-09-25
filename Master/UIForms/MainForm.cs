using System;
using System.Drawing;
using System.Windows.Forms;
using Advantech;
using Master.UI;
using MasterProject.GlobalClass;
using UIForms;

namespace UI.UI_Forms
{
    public partial class MainForm : Form
    {
       
        public event EventHandler LoginSuccess;
        private Button currentActiveButton = null;
        public MainForm()
        {
            InitializeComponent();
            this.IsMdiContainer = true;
            float xRatio = (float)Screen.PrimaryScreen.Bounds.Width / GlobalVariable.OrginalFormWidth;
            float yRatio = (float)Screen.PrimaryScreen.Bounds.Height / GlobalVariable.OrginalFormHeight;
            GlobalVariable.ResizeAllControls(this, xRatio, yRatio);
            try
            {
                btn_home_Click(btn_home, EventArgs.Empty);
            }
            catch (Exception)
            {
            }
        }
        #region Enabling buttons
        public void Disablebuttons()
        {
            btn_home.Enabled = false;
            btn_alarm.Enabled = false;
            btn_manual.Enabled = false;
            btn_statistics.Enabled = false;
            btn_settings.Enabled = false;
            btn_database.Enabled = false;
        }

        #endregion

        #region enablebuttons
        public void enablebuttons()
        {
            btn_home.Enabled = true;
            btn_alarm.Enabled = true;
            btn_manual.Enabled = true;
            btn_statistics.Enabled = true;
            btn_settings.Enabled = true;
            btn_database.Enabled = true;


        }
        #endregion
        public void OpenChildForm(Form childForm)
        {

            if (ActiveMdiChild != null)
            {
                ActiveMdiChild.Close();
            }

            childForm.MdiParent = this;
            childForm.Location = new Point(1, 100);
            childForm.Show();
        }

        private void HighlightButton(Button clickedButton)
        {
            // Reset previous
            if (currentActiveButton != null)
            {
                currentActiveButton.FlatAppearance.BorderColor = SystemColors.Control;

            }


            clickedButton.FlatAppearance.BorderColor = Color.Red;
            clickedButton.FlatAppearance.BorderSize = 2;
            currentActiveButton = clickedButton;
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            // close application 
            try
            {
                DialogResult dialogResult = MessageBox.Show("Are you Sure Want to Close the Application?", "Confirmation Box", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dialogResult == DialogResult.Yes)
                {
                    Application.Exit();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Application Didn't Close Properly : " + ex);
            }
        }

        private void btn_minimise_Click(object sender, EventArgs e)
        {
            // minimise application 
            try
            {
                this.WindowState = FormWindowState.Minimized;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to minimise application : " + ex);
            }
        }

        private void btn_home_Click(object sender, EventArgs e)
        {
            HighlightButton(sender as Button);
            if (ActiveMdiChild != null)
            {
                ActiveMdiChild.Close();
            }
            //btn_home.BackgroundImage = MasterProject.Properties.Resources.HomeIcon_selection;
            //btn_home.BackColor = Color.AliceBlue;
            panelContents.Visible = false;
            Form form_home = new HomeScreen();
            form_home.MdiParent = this;
            form_home.StartPosition = FormStartPosition.Manual;
            form_home.Size = new Size(panelContents.Size.Width - 5, panelContents.Size.Height - 5); 
            form_home.Show();

            ////panelContents.Controls.Clear();
            //Form form_home = new HomeScreen();
            //form_home.TopLevel = false;
            //form_home.FormBorderStyle = FormBorderStyle.None;
            ////panelContents.Controls.Add(form_home);
            //form_home.Show();
        }

        private void btn_alarm_Click(object sender, EventArgs e)
        {
            HighlightButton(sender as Button);
            if (ActiveMdiChild != null)
            {
                ActiveMdiChild.Close();
            }
            panelContents.Visible= false;
            Form form_alarm = new AlarmScreen();
            form_alarm.MdiParent = this;
            form_alarm.StartPosition = FormStartPosition.Manual;
            form_alarm.Size = new Size(panelContents.Size.Width - 5, panelContents.Size.Height - 5);
            form_alarm.Show();
        }

        private void btn_manual_Click(object sender, EventArgs e)
        {
            HighlightButton(sender as Button);
            if (ActiveMdiChild != null)
            {
                ActiveMdiChild.Close();
            }
            panelContents.Visible = false;
            Form form_manual = new ManualScreen();
            form_manual.MdiParent = this;
            form_manual.StartPosition = FormStartPosition.Manual;
            form_manual.Size = new Size(panelContents.Size.Width - 5, panelContents.Size.Height - 5);
            form_manual.Show();
        }

        private void btn_settings_Click(object sender, EventArgs e)
        {
            HighlightButton(sender as Button);
            if (ActiveMdiChild != null)
            {
                ActiveMdiChild.Close();
            }
            panelContents.Visible = false;
            Form form_settings = new Settings();
            form_settings.MdiParent = this;
            form_settings.StartPosition = FormStartPosition.Manual;
            form_settings.Size = new Size(panelContents.Size.Width - 5, panelContents.Size.Height - 5);
            form_settings.Show();
        }

        private void btn_database_Click(object sender, EventArgs e)
        {
            HighlightButton(sender as Button);
            if (ActiveMdiChild != null)
            {
                ActiveMdiChild.Close();
            }
            panelContents.Visible = false;
            Form recipe = new RecipieForm();
            recipe.MdiParent = this;
            recipe.StartPosition = FormStartPosition.Manual;
            recipe.Size = new Size(panelContents.Size.Width - 5, panelContents.Size.Height - 5);
            recipe.Show();
        }
        /// <summary>
        /// Button Image Sellection
        /// </summary>
        /// <param name="btnname">Button Name need to given</param>
        /// <param name="Mode">0-Normal , 1- Selection</param>

        private void SetIcon(string btnname, int Mode)
        {
            if (Mode == 0)
            {
                if (btnname =="")
                {

                }
            }
            else
            {

            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            DateTime dateTime = DateTime.Now;
            TimerLabel.Text = dateTime.ToString();
            //if (ExceptionLib.Logger.RunningLog_lst.Count > 13)
            //{
            //    ExceptionLib.Logger.RunningLog_lst.Clear();
            //    ExceptionLib.Logger.RunningLog_lst.Add("TEST : " + TimerLabel.Text);
            //}
            //else
            //{
            //    ExceptionLib.Logger.RunningLog_lst.Add("TEST : " + TimerLabel.Text);
            //}
            

        }

        private void btn_pause_auto_seq_Click(object sender, EventArgs e)
        {
            try
            {
                MessageBox.Show("Machine Not Connected");
                return;
                ServoSequense.GetServoSequenceObj.Pause_Thread();
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void btn_start_auto_seq_Click(object sender, EventArgs e)
        {
            try
            {
                MessageBox.Show("Machine Not Connected");
                return;
                ServoSequense.GetServoSequenceObj.Resume_Thread();
                ServoSequense.GetServoSequenceObj.start_Thread(1000, 10000, 1000, 1000);
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void btn_stop_auto_seq_Click(object sender, EventArgs e)
        {
            try
            {
                MessageBox.Show("Machine Not Connected");
                return;
                ServoSequense.GetServoSequenceObj.stop_Thread();
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void btn_statistics_Click(object sender, EventArgs e)
        {
            try
            {
                HighlightButton(sender as Button);
                if (ActiveMdiChild != null)
                {
                    ActiveMdiChild.Close();
                }
                panelContents.Visible = false;
                Form form_Report = new Report();
                form_Report.MdiParent = this;
                form_Report.StartPosition = FormStartPosition.Manual;
                form_Report.Size = new Size(panelContents.Size.Width - 5, panelContents.Size.Height - 5);
                form_Report.Show();
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void btn_open_file_Click(object sender, EventArgs e)
        {
            try
            {
                if(GlobalVariable.RunningLogPath == string.Empty)
                {
                    System.Diagnostics.Process.Start("explorer.exe", GlobalVariable.RunningLogPath);
                }
                else
                {
                    MessageBox.Show("Running Log File Path Is Empty", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
