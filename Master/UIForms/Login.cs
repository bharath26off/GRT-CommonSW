
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using MasterProject.GlobalClass;
using Program;
using UI.UI_Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace UI_Forms
{
    public partial class Login : Form
    {
        private String txtUsername;
        private object txtPassword;
        public bool isDeveloperMode = true;
        public Login()
        {
            InitializeComponent();
            this.CenterToScreen();
            cmbmodes.SelectedIndex = -1;
            cmbmodes.Focus();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void cmbmodes_DrawItem(object sender, DrawItemEventArgs e)
        {
            ComboBox cb = sender as ComboBox;
            e.DrawBackground();

            string text = string.Empty;
            Brush brush = SystemBrushes.WindowText; // Default system text color

            if (e.Index >= 0)
            {
                text = cb.Items[e.Index].ToString();
                brush = new SolidBrush(cb.ForeColor); // Keep default color
            }
            else if (cb.SelectedIndex == -1 && !cb.DroppedDown)
            {
                text = "-- SELECT MODE --";
                brush = Brushes.White; // Placeholder in white
            }

            StringFormat sf = new StringFormat
            {
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center
            };

            e.Graphics.DrawString(text, cb.Font, brush, e.Bounds, sf);
            e.DrawFocusRectangle();
        }


        private void btnlogin_Click_1(object sender, EventArgs e)
        {

            
            string modeSelect = cmbmodes.Text;
            string user= txtusername.Text;
            string password = txtpass.Text;
            if (modeSelect == string.Empty)

            {
                MessageBox.Show("Please Select Mode", "Login", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbmodes.Focus();
                return;
            }
            else if (modeSelect == "ADMIN" || modeSelect == "PRODUCTION" || modeSelect == "ENGINEERING")
            {



             if (user == string.Empty)
                {
                    MessageBox.Show("Please Enter User Name", "Login", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtusername.Focus();
                    return;
                }
                else if (password == string.Empty)
                {
                    MessageBox.Show("Please Enter Password", "Login", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtpass.Focus();
                    return;
                }

                Dictionary<String, (string username, string password)> Logindata = new Dictionary<string, (string, string)>
            {
                {"PRODUCTION",("prouser"," propass")},
                {"ENGINEERING",("enguser","engpass")},
                {"ADMIN",("admin","admin") }

            };
                if (Logindata.ContainsKey(modeSelect))
                {
                    var (valid_Username, valid_Password) = Logindata[modeSelect];
                    if (user == valid_Username && password == valid_Password)
                    {
                        //MessageBox.Show("login successfull");
                        MainForm form = new MainForm();                        
                        var CH = GlobalVariable.ComObj.Init_BoardFunc();
                        GlobalVariable.LoadReceipe();
                        if ((!CH.isSuccess) && (CH.MethodCode == 1))
                        {
                            MessageBox.Show("Driver Version Mismatch.....!");
                            //Declare your Global Variable true or false based on your Requirment
                        }
                        else if ((!CH.isSuccess) && (CH.MethodCode == 2))
                        {
                            MessageBox.Show("FAiled to Read Available Device .....!");
                        }
                        else if ((!CH.isSuccess) && (CH.MethodCode == 3))
                        {
                            MessageBox.Show("Error!Failed To Open Control Board.....!");
                        }
                        else
                        {
                            MessageBox.Show("Control Board Connected Successfully......!");
                        }
                        this.Visible = false;
                        form.ShowDialog();
                        //form.enablebuttons();
                      
                        this.Close();
                        
                    }
                    else
                    {
                        MessageBox.Show("Invalid Login credentials", "Login", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        cmbmodes.SelectedIndex = -1;
                        txtusername.Clear();
                        txtpass.Clear();

                    }
                }

            }
            else
            {
                MessageBox.Show("select the mode", "Login", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btncancel_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmbmodes_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Convert.ToInt32(e.KeyChar) == 13)
            {
                SendKeys.Send("{Tab}");
            }
        }

        private void txtusername_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Convert.ToInt32(e.KeyChar) == 13)
            {
                SendKeys.Send("{Tab}");
            }
        }

        private void txtpass_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Convert.ToInt32(e.KeyChar) == 13)
            {
                SendKeys.Send("{Tab}");
            }
        }

        private void Login_Load(object sender, EventArgs e)
        {
            cmbmodes.SelectedIndex = -1;
        }
    }
}
