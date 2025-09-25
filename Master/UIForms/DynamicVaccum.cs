//Class : DynamicVaccum
//Author: Saran Raj M
//Use   : Load Vaccum User control in Panel and Popup.

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using HelperClassLib;
using System.Data;
using VaccumHelperLib;
using System.Linq;
using Program;
using MasterProject.GlobalClass;
namespace DynamicVaccums
{
    public partial class DynamicVaccum : Form
    {
        // Timer for periodic status update (currently not used)
        private System.Windows.Forms.Timer VaccumStatusTimer;
        public DynamicVaccum()
        {

            InitializeComponent();
            // Bind combo box and popup button events
            cmbVaccumList.SelectedIndexChanged += ComboBox1_SelectedIndexChanged;
            btnPopUp.Click += BtnPopup_Click;
        }
        public class ComboVaccumItem
        {
            public string DisplayName { get; set; }
            public UCVaccum Control { get; set; }

            public override string ToString()
            {
                return DisplayName;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Initiate Vaccums to Combobox 
            cmbVaccumList.Items.Clear();
            // Adding Empty Vaccum
            cmbVaccumList.Items.Add(new ComboVaccumItem
            {
                DisplayName = "-- Select Vaccum --",
                Control = null
            });

            // Load Vaccums from CSV configuration
            VaccumsConfigFromCSV();

            // set empty Vaccum default
            cmbVaccumList.SelectedIndex = 0;
            InitializeVaccumStatusTimer();
        }


        private void VaccumsConfigFromCSV()
        {

            try
            {

                DataTable VaccumCSVdt = GetDataFromHelper.GetDataFromCSV(Path.Combine(Application.StartupPath, "Data", "Vaccums.csv"));

                foreach (DataRow c in VaccumCSVdt.Rows)
                {
                    var uc = new UCVaccum();
                    string enumName = c["VaccumConfig"].ToString();
                    Vaccum_config.Vaccums configEnum = (Vaccum_config.Vaccums)Enum.Parse(typeof(Vaccum_config.Vaccums), enumName);
                    uc.Tag = configEnum;
                    var vcm = Vaccum_config.Vaccums_List[(int)configEnum];

                    uc.SetGroupBoxVaccumName(c["VaccumName"].ToString());
                    uc.SetLabelVaccumFeedbackAddress(c["VaccumFeedbackInputAddress"].ToString());
                    uc.SetLabelVaccumOpAddress(c["VaccumOnOffOutputAddress"].ToString());
                    uc.SetLabelBlowOpAddress(c["BlowOnOffOutputAddress"].ToString());


                    uc.SetVaccumOnButton((c["VaccumButton"].ToString()));
                    uc.SetBlowOnButton((c["BlowButton"].ToString()));
                    uc.SetVaccumOffButton((c["OffButton"].ToString()));


                    uc.EnableVaccumOnButton(Convert.ToBoolean(c["EnableVaccumButton"]));
                    uc.EnableBlowOnButton(Convert.ToBoolean(c["EnableBlowButton"]));
                    uc.EnableVaccumOffButton(Convert.ToBoolean(c["EnableOffButton"]));
                    uc.EnableAllButtons(Convert.ToBoolean(c["EnableAllButtons"]));

                    uc.btn_vaccum_on_Clicked += Vaccum_btn_VaccumOnClicked;
                    uc.btn_blow_on_Clicked += Vaccum_btn_BlowClicked;
                    uc.btn_off_Clicked += Vaccum_btn_OffClicked;

                    cmbVaccumList.Items.Add(new ComboVaccumItem
                    {
                        DisplayName = c["VaccumName"].ToString(),
                        Control = uc
                    });
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading Vaccums: " + ex.Message);
            }
        }

        // Handle Vaccum On button 
        private async void Vaccum_btn_VaccumOnClicked(object sender, EventArgs e)
        {
            if (sender is UCVaccum uc && uc.Tag is Vaccum_config.Vaccums configEnum)
            {
                Vaccum advantechVaccum = Vaccum_config.Vaccums_List[(int)configEnum];
                if (await advantechVaccum.Vaccum_On_Manual_Mode())
                {
                    UpdateUIVaccumInputStatus(configEnum, uc);
                }

            }

        }
        // Handle Blow On 
        private async void Vaccum_btn_BlowClicked(object sender, EventArgs e)
        {

            if (sender is UCVaccum uc && uc.Tag is Vaccum_config.Vaccums configEnum)
            {
                Vaccum advantechVaccum = Vaccum_config.Vaccums_List[(int)configEnum];
                if (await advantechVaccum.Blow_On_Manual_Mode())
                {
                    UpdateUIVaccumInputStatus(configEnum, uc);
                }
            }

        }

        // Handle Off
        private void Vaccum_btn_OffClicked(object sender, EventArgs e)
        {

            if (sender is UCVaccum uc && uc.Tag is Vaccum_config.Vaccums configEnum)
            {
                Vaccum advantechVaccum = Vaccum_config.Vaccums_List[(int)configEnum];
                if (advantechVaccum.Both_Vaccum_and_Blow_Off())
                {
                    UpdateUIVaccumInputStatus(configEnum, uc);
                }
            }

        }

        // Dictionary to track which UCVaccums are shown in popups
        private Dictionary<Control, Form> controlPopupMap = new Dictionary<Control, Form>();

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Disable popup button if no valid Vaccum selected
            btnPopUp.Enabled = (cmbVaccumList.SelectedItem is ComboVaccumItem selectedItem0 && selectedItem0.Control != null);

            pnlControl.Controls.Clear();

            if (cmbVaccumList.SelectedItem is ComboVaccumItem selectedItem && selectedItem.Control != null)
            {
                // Check if the control is already shown in a popup
                if (controlPopupMap.TryGetValue(selectedItem.Control, out var popup) && popup != null && !popup.IsDisposed)
                {
                    // Bring existing popup to front
                    popup.BringToFront();
                    popup.Focus();
                    return;
                }
                // Remove from previous parent if already in use
                selectedItem.Control.Parent?.Controls.Remove(selectedItem.Control);

                selectedItem.Control.Dock = DockStyle.Fill;
                pnlControl.Controls.Add(selectedItem.Control);
                // Update Vaccum status on UI
                UpdateUIVaccumInputStatus((Vaccum_config.Vaccums)selectedItem.Control.Tag, selectedItem.Control);

            }
        }
        // Last popup window position
        private Point? lastPopupPosition = null;

        private void BtnPopup_Click(object sender, EventArgs e)
        {
            if (cmbVaccumList.SelectedItem is ComboVaccumItem selectedItem && selectedItem.Control != null)
            {
                // If popup already exists for this control, do nothing or bring to front
                if (controlPopupMap.ContainsKey(selectedItem.Control))
                {
                    var existingPopup = controlPopupMap[selectedItem.Control];
                    if (existingPopup != null && !existingPopup.IsDisposed)
                    {
                        existingPopup.BringToFront();
                        return;
                    }
                    else
                    {
                        controlPopupMap.Remove(selectedItem.Control);
                    }
                }

                Size formSize = new Size(500, 250);
                var popupForm = new Form
                {
                    Text = $"Popup - {selectedItem.DisplayName}",
                    Size = formSize,
                    MinimumSize = formSize,
                    MaximumSize = formSize,
                    MaximizeBox = false,
                    MinimizeBox = false,
                    StartPosition = FormStartPosition.Manual
                };

                // Calculate next popup position
                var screenBounds = Screen.FromControl(this).WorkingArea;
                int spacing = 10;
                int x, y;

                if (lastPopupPosition.HasValue)
                {
                    // Try placing next to the last popup
                    x = lastPopupPosition.Value.X + formSize.Width + spacing;
                    y = lastPopupPosition.Value.Y;

                    // If it goes off screen horizontally, wrap to next row
                    if (x + formSize.Width > screenBounds.Right)
                    {
                        x = screenBounds.Left;
                        y += formSize.Height + spacing;
                    }

                    // If it goes off screen vertically, reset to top-left
                    if (y + formSize.Height > screenBounds.Bottom)
                    {
                        x = screenBounds.Left;
                        y = screenBounds.Top;
                    }
                }
                else
                {
                    // First popup position
                    x = this.Right + spacing;
                    y = this.Top + spacing;

                    // Ensure it fits on screen
                    if (x + formSize.Width > screenBounds.Right)
                    {
                        x = screenBounds.Right - formSize.Width;
                    }
                    if (y + formSize.Height > screenBounds.Bottom)
                    {
                        y = screenBounds.Bottom - formSize.Height;
                    }
                }

                popupForm.Location = new Point(x, y);
                lastPopupPosition = popupForm.Location;

                selectedItem.Control.Parent?.Controls.Remove(selectedItem.Control);

                selectedItem.Control.Dock = DockStyle.Fill;
                popupForm.Controls.Add(selectedItem.Control);
                UpdateUIVaccumInputStatus((Vaccum_config.Vaccums)selectedItem.Control.Tag, selectedItem.Control);
                controlPopupMap[selectedItem.Control] = popupForm;

                var control = selectedItem.Control;
                popupForm.FormClosing += (s, args) =>
                {
                    if (control.Parent == popupForm)
                    {
                        popupForm.Controls.Remove(control);
                    }
                };
                popupForm.FormClosed += (s, args) =>
                {
                    controlPopupMap.Remove(control);
                    ComboBox1_SelectedIndexChanged(null, null);
                    if (controlPopupMap.Count == 0)
                    {
                        lastPopupPosition = null;
                    }
                };
                popupForm.Show();
            }
            else
            {
                MessageBox.Show("Select a valid Vaccum.");
            }
        }

        private void btnCloseAll_Click(object sender, EventArgs e)
        {

            foreach (var popup in controlPopupMap.Values.ToList())
            {
                if (popup != null && !popup.IsDisposed)
                {
                    popup.Close();
                }
            }

            controlPopupMap.Clear();
            lastPopupPosition = null;
        }



        private void InitializeVaccumStatusTimer()
        {
            VaccumStatusTimer = new System.Windows.Forms.Timer();
            VaccumStatusTimer.Interval = 1000; // update every 1 second
            VaccumStatusTimer.Tick += VaccumStatusTimer_Tick;
            VaccumStatusTimer.Start();
        }
        private void VaccumStatusTimer_Tick(object sender, EventArgs e)
        {
            // Refresh Vaccum in panel
            if (cmbVaccumList.SelectedItem is ComboVaccumItem selectedItem && selectedItem.Control is UCVaccum panelUc)
            {
                if (panelUc.Tag is Vaccum_config.Vaccums configEnum)
                {
                    UpdateUIVaccumInputStatus(configEnum, panelUc);
                }
            }

            // Refresh popup Vaccums
            foreach (var kvp in controlPopupMap)
            {
                if (kvp.Key is UCVaccum uc && uc.Tag is Vaccum_config.Vaccums configEnum)
                {
                    UpdateUIVaccumInputStatus(configEnum, uc);
                }
            }
        }


        // Initialize Advantech PCIE card
        Advantech_PCIE PCIE = new Advantech_PCIE(0, "PCIE");
        private void UpdateUIVaccumInputStatus(Vaccum_config.Vaccums configEnum, UCVaccum uc)
        {
            var Vaccum = Vaccum_config.Vaccums_List[(int)configEnum];
            bool[] inputStates = PCIE.DI_RefreshValue(GlobalVariable.DI.Length);
            bool extendvalue = false;
            extendvalue = inputStates[Vaccum.vaccum_feedback];
            var ExtendInputColor = extendvalue ? Color.Green : Color.Red;

            uc.SetVaccumFeedbackButtonColors(ExtendInputColor, Color.Black);
        }



    }

    // Comment this or remove this on Actual Release
   

}
