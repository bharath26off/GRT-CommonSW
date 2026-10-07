using System;
using System.Drawing;
using System.Windows.Forms;

namespace VacuumHelperLib
{
    public partial class UCVacuum : UserControl
    {
        public UCVacuum()
        {
            InitializeComponent();
        }

        #region Button Handlers

        public event EventHandler btn_vacuum_on_Clicked;
        public event EventHandler btn_blow_on_Clicked;
        public event EventHandler btn_off_Clicked;

        #endregion

        #region UI Handling Functions

        #region Group Box

        public void SetGroupBoxVacuumName(string text, string fontName = "Segoe UI", float fontSize = 12, FontStyle fontStyle = FontStyle.Bold)
        {
            groupBox_vacuum_gen_name.Text = text;
            groupBox_vacuum_gen_name.Font = new Font(fontName, fontSize, fontStyle);
        }

        #endregion

        #region Labels

        public void SetLabelVacuumOpAddress(string text, string fontName = "Microsoft Sans Serif", float fontSize = 8, FontStyle fontStyle = FontStyle.Regular)
        {
            label_vacuum_op_address.Text = text;
            label_vacuum_op_address.Font = new Font(fontName, fontSize, fontStyle);
        }

        public void SetLabelBlowOpAddress(string text, string fontName = "Microsoft Sans Serif", float fontSize = 8, FontStyle fontStyle = FontStyle.Regular)
        {
            label_blow_op_address.Text = text;
            label_blow_op_address.Font = new Font(fontName, fontSize, fontStyle);
        }

        public void SetLabelVacuumFeedbackAddress(string text, string fontName = "Microsoft Sans Serif", float fontSize = 8, FontStyle fontStyle = FontStyle.Regular)
        {
            label_vacuum_feedback_address.Text = text;
            label_vacuum_feedback_address.Font = new Font(fontName, fontSize, fontStyle);
        }

        #endregion

        #region Buttons

        #region Change Text and Font Styles

        public void SetVacuumOnButton(string text, string fontName = "Microsoft Sans Serif", float fontSize = 8, FontStyle fontStyle = FontStyle.Regular)
        {
            btn_vacuum_on.Text = text;
            btn_vacuum_on.Font = new Font(fontName, fontSize, fontStyle);
        }

        public void SetBlowOnButton(string text, string fontName = "Microsoft Sans Serif", float fontSize = 8, FontStyle fontStyle = FontStyle.Regular)
        {
            btn_blow_on.Text = text;
            btn_blow_on.Font = new Font(fontName, fontSize, fontStyle);
        }

        public void SetVacuumOffButton(string text, string fontName = "Microsoft Sans Serif", float fontSize = 8, FontStyle fontStyle = FontStyle.Regular)
        {
            btn_off.Text = text;
            btn_off.Font = new Font(fontName, fontSize, fontStyle);
        }

        #endregion

        #region Enable/Disable Buttons

        public void EnableVacuumOnButton(bool enable) => btn_vacuum_on.Enabled = enable;
        public void EnableBlowOnButton(bool enable) => btn_blow_on.Enabled = enable;
        public void EnableVacuumOffButton(bool enable) => btn_off.Enabled = enable;

        /// <summary>
        /// To disable all buttons used to send command in manual mode
        /// </summary>
        /// <param name="enable"></param>
        public void EnableAllButtons(bool enable)
        {
            btn_vacuum_on.Enabled = enable;
            btn_blow_on.Enabled = enable;
            btn_off.Enabled = enable;
        }

        #endregion

        #region Button Colors

        public void SetVacuumOnButtonColors(Color backColor, Color foreColor)
        {
            btn_vacuum_on.BackColor = backColor;
            btn_vacuum_on.ForeColor = foreColor;
        }

        public void SetBlowOnButtonColors(Color backColor, Color foreColor)
        {
            btn_blow_on.BackColor = backColor;
            btn_blow_on.ForeColor = foreColor;
        }

        public void SetVacuumOffButtonColors(Color backColor, Color foreColor)
        {
            btn_off.BackColor = backColor;
            btn_off.ForeColor = foreColor;
        }

        public void SetVacuumFeedbackButtonColors(Color backColor, Color foreColor)
        {
            btn_vacuum_feedback.BackColor = backColor;
            btn_vacuum_feedback.ForeColor = foreColor;
        }


        #endregion

        #endregion

        #endregion

        #region Event Handling Functions

        private void btn_vacuum_on_Click(object sender, EventArgs e)
        {
            btn_vacuum_on_Clicked?.Invoke(this, EventArgs.Empty);
        }

        private void btn_off_Click(object sender, EventArgs e)
        {
            btn_off_Clicked?.Invoke(this, EventArgs.Empty);
        }

        private void btn_blow_on_Click(object sender, EventArgs e)
        {
            btn_blow_on_Clicked?.Invoke(this, EventArgs.Empty);
        }

        #endregion
    }
}
