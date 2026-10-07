using System;
using System.Drawing;
using System.Windows.Forms;

namespace CylinderHelperLib
{
    public partial class UCCylinder : UserControl
    {
        public UCCylinder()
        {
            InitializeComponent();
        }

        #region Button Handlers

        public event EventHandler btn_work_Clicked;
        public event EventHandler btn_home_Clicked;

        #endregion

        #region UI handling functions

        #region Group box 

        #region Name
        public void SetGroupBoxCylinderName(string text, string fontName = "Segoe UI", float fontSize = 12, FontStyle fontStyle = FontStyle.Bold)
        {
            groupBox_cylindername.Text = text;
            groupBox_cylindername.Font = new Font(fontName, fontSize, fontStyle);
        }
        #endregion

        #endregion

        #region Label

        public void SetLabelWorkReedAddress(string text, string fontName = "Microsoft Sans Serif", float fontSize = 8, FontStyle fontStyle = FontStyle.Regular)
        {
            label_work_reed_address.Text = text;
            label_work_reed_address.Font = new Font(fontName, fontSize, fontStyle);
        }

        public void SetLabelWorkCoilAddress(string text, string fontName = "Microsoft Sans Serif", float fontSize = 8, FontStyle fontStyle = FontStyle.Regular)
        {
            label_work_coil_address.Text = text;
            label_work_coil_address.Font = new Font(fontName, fontSize, fontStyle);
        }

        public void SetLabelHomeCoilAddress(string text, string fontName = "Microsoft Sans Serif", float fontSize = 8, FontStyle fontStyle = FontStyle.Regular)
        {
            label_home_coil_address.Text = text;
            label_home_coil_address.Font = new Font(fontName, fontSize, fontStyle);
        }

        public void SetLabelHomeReedAddress(string text, string fontName = "Microsoft Sans Serif", float fontSize = 8, FontStyle fontStyle = FontStyle.Regular)
        {
            label_home_reed_address.Text = text;
            label_home_reed_address.Font = new Font(fontName, fontSize, fontStyle);
        }

        public void SetLabelSafetoExtend(string text, string fontName = "Microsoft Sans Serif", float fontSize = 8, FontStyle fontStyle = FontStyle.Regular)
        {
            label_safe_to_extend.Text = text;
            label_safe_to_extend.Font = new Font(fontName, fontSize, fontStyle);
        }

        public void SetLabelSafetoRetract(string text, string fontName = "Microsoft Sans Serif", float fontSize = 8, FontStyle fontStyle = FontStyle.Regular)
        {
            label_safe_to_retract.Text = text;
            label_safe_to_retract.Font = new Font(fontName, fontSize, fontStyle);
        }


        #endregion

        #region Buttons

        #region Change text and font styles

        public void SetExtendReedButton(string text, string fontName = "Microsoft Sans Serif", float fontSize = 8, FontStyle fontStyle = FontStyle.Regular)
        {
            btn_exttend_reed.Text = text;
            btn_exttend_reed.Font = new Font(fontName, fontSize, fontStyle);
        }

        public void SetExtendCoilButton(string text, string fontName = "Microsoft Sans Serif", float fontSize = 8, FontStyle fontStyle = FontStyle.Regular)
        {
            btn_Extend_coil.Text = text;
            btn_Extend_coil.Font = new Font(fontName, fontSize, fontStyle);
        }

        public void SetRetractCoilButton(string text, string fontName = "Microsoft Sans Serif", float fontSize = 8, FontStyle fontStyle = FontStyle.Regular)
        {
            btn_Retract_coil.Text = text;
            btn_Retract_coil.Font = new Font(fontName, fontSize, fontStyle);
        }

        public void SetRetractReedButton(string text, string fontName = "Microsoft Sans Serif", float fontSize = 8, FontStyle fontStyle = FontStyle.Regular)
        {
            btn_retract_reed.Text = text;
            btn_retract_reed.Font = new Font(fontName, fontSize, fontStyle);
        }

        public void SetSafeToExtendButton(string text, string fontName = "Microsoft Sans Serif", float fontSize = 8, FontStyle fontStyle = FontStyle.Regular)
        {
            btn_safe_to_extend.Text = text;
            btn_safe_to_extend.Font = new Font(fontName, fontSize, fontStyle);
        }

        public void SetSafeToRetractButton(string text, string fontName = "Microsoft Sans Serif", float fontSize = 8, FontStyle fontStyle = FontStyle.Regular)
        {
            btn_safe_to_retract.Text = text;
            btn_safe_to_retract.Font = new Font(fontName, fontSize, fontStyle);
        }

        #endregion

        #region Enable disable buttons

        public void EnableExtendReedButton(bool enable) => btn_exttend_reed.Enabled = enable;
        public void EnableExtendCoilButton(bool enable) => btn_Extend_coil.Enabled = enable;
        public void EnableRetractCoilButton(bool enable) => btn_Retract_coil.Enabled = enable;
        public void EnableRetractReedButton(bool enable) => btn_retract_reed.Enabled = enable;
        public void EnableSafeToExtendButton(bool enable) => btn_safe_to_extend.Enabled = enable;
        public void EnableSafeToRetractButton(bool enable) => btn_safe_to_retract.Enabled = enable;

        /// <summary>
        /// To disable all buttons used to send command in manual mode
        /// </summary>
        /// <param name="enable"></param>
        public void EnableAllButtons(bool enable)
        {
            btn_Extend_coil.Enabled = enable;
            btn_Retract_coil.Enabled = enable;
        }

        #endregion

        #region Button colour

        public void SetExtendReedButtonColors(Color backColor, Color foreColor)
        {
            btn_exttend_reed.BackColor = backColor;
            btn_exttend_reed.ForeColor = foreColor;
        }

        public void SetExtendCoilButtonColors(Color backColor, Color foreColor)
        {
            btn_Extend_coil.BackColor = backColor;
            btn_Extend_coil.ForeColor = foreColor;
        }

        public void SetRetractCoilButtonColors(Color backColor, Color foreColor)
        {
            btn_Retract_coil.BackColor = backColor;
            btn_Retract_coil.ForeColor = foreColor;
        }

        public void SetRetractReedButtonColors(Color backColor, Color foreColor)
        {
            btn_retract_reed.BackColor = backColor;
            btn_retract_reed.ForeColor = foreColor;
        }

        public void SetSafeToExtendButtonColors(Color backColor, Color foreColor)
        {
            btn_safe_to_extend.BackColor = backColor;
            btn_safe_to_extend.ForeColor = foreColor;
        }

        public void SetSafeToRetractButtonColors(Color backColor, Color foreColor)
        {
            btn_safe_to_retract.BackColor = backColor;
            btn_safe_to_retract.ForeColor = foreColor;
        }

        #endregion

        #endregion

        #endregion

        #region Event Handling functions

        #region Button click

        private void btn_Extend_coil_Click(object sender, EventArgs e)
        {
            // extend is taken as work
            btn_work_Clicked?.Invoke(this, EventArgs.Empty);
        }

        private void btn_Retract_coil_Click(object sender, EventArgs e)
        {
            // retract is taken as home
            btn_home_Clicked?.Invoke(this, EventArgs.Empty);
        }

        #endregion

        #endregion

    }
}

#region How to use function

//using System;
//using System.Drawing;
//using System.Windows.Forms;

//namespace trials
//{
//    public partial class Form1 : Form
//    {
//        public Form1()
//        {
//            InitializeComponent();
//        }

//        private void ucRobot1_Load(object sender, EventArgs e)
//        {
//            // You already handled robot setup elsewhere
//        }

//        private void ucCCD1_Load(object sender, EventArgs e)
//        {
//            // You already handled CCD setup elsewhere
//        }

//        private void ucCylinder1_Load(object sender, EventArgs e)
//        {
//            // Subscribe to events
//            ucCylinder1.btn_work_Clicked += UCCylinder_WorkClicked;
//            ucCylinder1.btn_home_Clicked += UCCylinder_HomeClicked;

//            // Set group box title
//            ucCylinder1.SetGroupBoxCylinderName("Cylinder A");

//            // Set label texts
//            ucCylinder1.SetLabelWorkReedAddress("X0");
//            ucCylinder1.SetLabelWorkCoilAddress("Y0");
//            ucCylinder1.SetLabelHomeReedAddress("X1");
//            ucCylinder1.SetLabelHomeCoilAddress("Y1");

//            // Set font styles for buttons
//            ucCylinder1.SetExtendReedButton("Extend Reed");
//            ucCylinder1.SetExtendCoilButton("Extend Coil");
//            ucCylinder1.SetRetractReedButton("Retract Reed");
//            ucCylinder1.SetRetractCoilButton("Retract Coil");
//            ucCylinder1.SetSafeToExtendButton("Safe to Extend");
//            ucCylinder1.SetSafeToRetractButton("Safe to Retract");

//            // Enable all buttons
//            ucCylinder1.EnableExtendReedButton(true);
//            ucCylinder1.EnableExtendCoilButton(true);
//            ucCylinder1.EnableRetractReedButton(true);
//            ucCylinder1.EnableRetractCoilButton(true);
//            ucCylinder1.EnableSafeToExtendButton(true);
//            ucCylinder1.EnableSafeToRetractButton(true);

//            // Set colors for testing visibility
//            ucCylinder1.SetExtendReedButtonColors(Color.LightBlue, Color.Black);
//            ucCylinder1.SetExtendCoilButtonColors(Color.LightGreen, Color.Black);
//            ucCylinder1.SetRetractReedButtonColors(Color.Orange, Color.White);
//            ucCylinder1.SetRetractCoilButtonColors(Color.LightCoral, Color.White);
//            ucCylinder1.SetSafeToExtendButtonColors(Color.LightYellow, Color.Black);
//            ucCylinder1.SetSafeToRetractButtonColors(Color.LightGray, Color.Black);
//        }

//        private void UCCylinder_WorkClicked(object sender, EventArgs e)
//        {
//            MessageBox.Show("Work (Extend) button clicked.", "Cylinder Action", MessageBoxButtons.OK, MessageBoxIcon.Information);
//            // Example: Disable extend, enable retract
//            ucCylinder1.EnableExtendCoilButton(false);
//            ucCylinder1.EnableRetractCoilButton(true);
//        }

//        private void UCCylinder_HomeClicked(object sender, EventArgs e)
//        {
//            MessageBox.Show("Home (Retract) button clicked.", "Cylinder Action", MessageBoxButtons.OK, MessageBoxIcon.Information);
//            // Example: Enable extend, disable retract
//            ucCylinder1.EnableExtendCoilButton(true);
//            ucCylinder1.EnableRetractCoilButton(false);
//        }
//    }
//}


#endregion