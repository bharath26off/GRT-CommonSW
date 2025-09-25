using System;
using System.Drawing;
using System.Windows.Forms;

namespace VaccumHelperLib
{
    public partial class UCVaccum : UserControl
    {
        public UCVaccum()
        {
            InitializeComponent();
        }

        #region Button Handlers

        public event EventHandler btn_vaccum_on_Clicked;
        public event EventHandler btn_blow_on_Clicked;
        public event EventHandler btn_off_Clicked;

        #endregion

        #region UI Handling Functions

        #region Group Box

        public void SetGroupBoxVaccumName(string text, string fontName = "Segoe UI", float fontSize = 12, FontStyle fontStyle = FontStyle.Bold)
        {
            groupBox_vaccum_gen_name.Text = text;
            groupBox_vaccum_gen_name.Font = new Font(fontName, fontSize, fontStyle);
        }

        #endregion

        #region Labels

        public void SetLabelVaccumOpAddress(string text, string fontName = "Microsoft Sans Serif", float fontSize = 8, FontStyle fontStyle = FontStyle.Regular)
        {
            label_vaccum_op_address.Text = text;
            label_vaccum_op_address.Font = new Font(fontName, fontSize, fontStyle);
        }

        public void SetLabelBlowOpAddress(string text, string fontName = "Microsoft Sans Serif", float fontSize = 8, FontStyle fontStyle = FontStyle.Regular)
        {
            label_blow_op_address.Text = text;
            label_blow_op_address.Font = new Font(fontName, fontSize, fontStyle);
        }

        public void SetLabelVaccumFeedbackAddress(string text, string fontName = "Microsoft Sans Serif", float fontSize = 8, FontStyle fontStyle = FontStyle.Regular)
        {
            label_vaccum_feedback_address.Text = text;
            label_vaccum_feedback_address.Font = new Font(fontName, fontSize, fontStyle);
        }

        #endregion

        #region Buttons

        #region Change Text and Font Styles

        public void SetVaccumOnButton(string text, string fontName = "Microsoft Sans Serif", float fontSize = 8, FontStyle fontStyle = FontStyle.Regular)
        {
            btn_vaccum_on.Text = text;
            btn_vaccum_on.Font = new Font(fontName, fontSize, fontStyle);
        }

        public void SetBlowOnButton(string text, string fontName = "Microsoft Sans Serif", float fontSize = 8, FontStyle fontStyle = FontStyle.Regular)
        {
            btn_blow_on.Text = text;
            btn_blow_on.Font = new Font(fontName, fontSize, fontStyle);
        }

        public void SetVaccumOffButton(string text, string fontName = "Microsoft Sans Serif", float fontSize = 8, FontStyle fontStyle = FontStyle.Regular)
        {
            btn_off.Text = text;
            btn_off.Font = new Font(fontName, fontSize, fontStyle);
        }

        #endregion

        #region Enable/Disable Buttons

        public void EnableVaccumOnButton(bool enable) => btn_vaccum_on.Enabled = enable;
        public void EnableBlowOnButton(bool enable) => btn_blow_on.Enabled = enable;
        public void EnableVaccumOffButton(bool enable) => btn_off.Enabled = enable;

        /// <summary>
        /// To disable all buttons used to send command in manual mode
        /// </summary>
        /// <param name="enable"></param>
        public void EnableAllButtons(bool enable)
        {
            btn_vaccum_on.Enabled = enable;
            btn_blow_on.Enabled = enable;
            btn_off.Enabled = enable;
        }

        #endregion

        #region Button Colors

        public void SetVaccumOnButtonColors(Color backColor, Color foreColor)
        {
            btn_vaccum_on.BackColor = backColor;
            btn_vaccum_on.ForeColor = foreColor;
        }

        public void SetBlowOnButtonColors(Color backColor, Color foreColor)
        {
            btn_blow_on.BackColor = backColor;
            btn_blow_on.ForeColor = foreColor;
        }

        public void SetVaccumOffButtonColors(Color backColor, Color foreColor)
        {
            btn_off.BackColor = backColor;
            btn_off.ForeColor = foreColor;
        }

        public void SetVaccumFeedbackButtonColors(Color backColor, Color foreColor)
        {
            btn_vaccum_feedback.BackColor = backColor;
            btn_vaccum_feedback.ForeColor = foreColor;
        }


        #endregion

        #endregion

        #endregion

        #region Event Handling Functions

        private void btn_vaccum_on_Click(object sender, EventArgs e)
        {
            btn_vaccum_on_Clicked?.Invoke(this, EventArgs.Empty);
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
