//Class : DynamicVacuum
//Author: Saran Raj M
//Use   : Load Vacuum User control in Panel and Popup.

using HelperClassLib;
using Master;
using Program;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Linq;
using VacuumHelperLib;
using static DynamicVacuums.Vacuum_config;
namespace DynamicVacuums
{
    public partial class DynamicVacuum : Form
    {
        // Timer for periodic status update (currently not used)
        private System.Windows.Forms.Timer VacuumStatusTimer;
        public DynamicVacuum()
        {

            InitializeComponent();
            // Bind combo box and popup button events
            cmbVacuumList.SelectedIndexChanged += ComboBox1_SelectedIndexChanged;
            btnPopUp.Click += BtnPopup_Click;
        }
        public class ComboVacuumItem
        {
            public string DisplayName { get; set; }
            public UCVacuum Control { get; set; }

            public override string ToString()
            {
                return DisplayName;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            btnCloseAll.Enabled = false;
            // Initiate Vacuums to Combobox 
            cmbVacuumList.Items.Clear();
            // Adding Empty Vacuum
            cmbVacuumList.Items.Add(new ComboVacuumItem
            {
                DisplayName = "-- Select Vacuum --",
                Control = null
            });

            // Load Vacuums from CSV configuration
            VacuumsConfigFromCSV();

            // set empty Vacuum default
            cmbVacuumList.SelectedIndex = 0;
            //**devchange: uncomment after connected to machine
            InitializeVacuumStatusTimer();
        }


        private void VacuumsConfigFromCSV()
        {

            try
            {
                 var doc = XDocument.Load(Path.Combine(Application.StartupPath, "Data", "Vacuums.xml"));
                var vaccumXml = doc.Descendants("Vacuum").ToList();

                foreach (var elem in vaccumXml)
                {
                    var uc = new UCVacuum();
                    string enumName = elem.Attribute("VacuumConfig")?.Value.Trim();
                    if (string.IsNullOrEmpty(enumName)) continue;

                    Vacuums configEnum = (Vacuums)Enum.Parse(typeof(Vacuums), enumName);
                    uc.Tag = configEnum;

                    var vcm = Vacuum_config.Vacuums_List[(int)configEnum];

                    uc.SetGroupBoxVacuumName(elem.Attribute("VacuumName")?.Value.Trim());
                    uc.SetLabelVacuumFeedbackAddress(elem.Attribute("VacuumFeedbackInputAddress")?.Value.Trim());
                    uc.SetLabelVacuumOpAddress(elem.Attribute("VacuumOnOffOutputAddress")?.Value.Trim());
                    uc.SetLabelBlowOpAddress(elem.Attribute("BlowOnOffOutputAddress")?.Value.Trim());


                    uc.SetVacuumOnButton((elem.Attribute("VacuumButton")?.Value.Trim()));
                    uc.SetBlowOnButton((elem.Attribute("BlowButton")?.Value.Trim()));
                    uc.SetVacuumOffButton((elem.Attribute("OffButton")?.Value.Trim()));


                    uc.EnableVacuumOnButton(Convert.ToBoolean(elem.Attribute("EnableVacuumButton")?.Value.Trim()));
                    uc.EnableBlowOnButton(Convert.ToBoolean(elem.Attribute("EnableBlowButton")?.Value.Trim()));
                    uc.EnableVacuumOffButton(Convert.ToBoolean(elem.Attribute("EnableOffButton")?.Value.Trim()));
                    uc.EnableAllButtons(Convert.ToBoolean(elem.Attribute("EnableAllButtons")?.Value.Trim()));

                    uc.btn_vacuum_on_Clicked += Vacuum_btn_VacuumOnClicked;
                    uc.btn_blow_on_Clicked += Vacuum_btn_BlowClicked;
                    uc.btn_off_Clicked += Vacuum_btn_OffClicked;

                    cmbVacuumList.Items.Add(new ComboVacuumItem
                    {
                        DisplayName = elem.Attribute("VacuumName")?.Value.Trim(),
                        Control = uc
                    });
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading Vacuums: " + ex.Message);
            }
        }

        // Handle Vacuum On button 
        private async void Vacuum_btn_VacuumOnClicked(object sender, EventArgs e)
        {
            if (sender is UCVacuum uc && uc.Tag is Vacuum_config.Vacuums configEnum)
            {
                Vacuum advantechVacuum = Vacuum_config.Vacuums_List[(int)configEnum];
                if (await advantechVacuum.Vacuum_On_Manual_Mode())
                {
                    UpdateUIVacuumInputStatus(configEnum, uc);
                }

            }

        }
        // Handle Blow On 
        private async void Vacuum_btn_BlowClicked(object sender, EventArgs e)
        {

            if (sender is UCVacuum uc && uc.Tag is Vacuum_config.Vacuums configEnum)
            {
                Vacuum advantechVacuum = Vacuum_config.Vacuums_List[(int)configEnum];
                if (await advantechVacuum.Blow_On_Manual_Mode())
                {
                    UpdateUIVacuumInputStatus(configEnum, uc);
                }
            }

        }

        // Handle Off
        private void Vacuum_btn_OffClicked(object sender, EventArgs e)
        {

            if (sender is UCVacuum uc && uc.Tag is Vacuum_config.Vacuums configEnum)
            {
                Vacuum advantechVacuum = Vacuum_config.Vacuums_List[(int)configEnum];
                if (advantechVacuum.Both_Vacuum_and_Blow_Off())
                {
                    UpdateUIVacuumInputStatus(configEnum, uc);
                }
            }

        }

        // Dictionary to track which UCVacuums are shown in popups
        private Dictionary<Control, Form> controlPopupMap = new Dictionary<Control, Form>();

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Disable popup button if no valid Vacuum selected
            btnPopUp.Enabled = (cmbVacuumList.SelectedItem is ComboVacuumItem selectedItem0 && selectedItem0.Control != null);

            pnlControl.Controls.Clear();

            if (cmbVacuumList.SelectedItem is ComboVacuumItem selectedItem && selectedItem.Control != null)
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
                // Update Vacuum status on UI
                UpdateUIVacuumInputStatus((Vacuum_config.Vacuums)selectedItem.Control.Tag, selectedItem.Control);

            }
        }
        // Last popup window position
        private Point? lastPopupPosition = null;

        private void BtnPopup_Click(object sender, EventArgs e)
        {
            btnCloseAll.Enabled = true;
            if (controlPopupMap.Count >= 3)
            {
                MessageBox.Show("Maximum 3 popups allowed.", "Limit Reached",
                    MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);
                return;
            }
            if (cmbVacuumList.SelectedItem is ComboVacuumItem selectedItem && selectedItem.Control != null)
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

                Size formSize = new Size(450, 250);
                var popupForm = new Form
                {
                    Text = $"Popup - {selectedItem.DisplayName}",
                    Size = formSize,
                    MinimumSize = formSize,
                    MaximumSize = formSize,
                    MaximizeBox = false,
                    MinimizeBox = false,
                    StartPosition = FormStartPosition.Manual,
                    Owner = this
                };

                // Calculate next popup position
                var screenBounds = Screen.FromControl(this).WorkingArea;
                int spacing = 10;
                int x, y;
                x = 50;
                y = 100;
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
                    //x = this.Right + spacing;
                    //y = this.Top + spacing;
                    x = 50;
                    y = 500;

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
                UpdateUIVacuumInputStatus((Vacuum_config.Vacuums)selectedItem.Control.Tag, selectedItem.Control);
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
                        btnCloseAll.Enabled = false;
                    }
                };
                popupForm.Show();
            }
            else
            {
                MessageBox.Show("Select a valid Vacuum.");
            }
        }

        public void btnCloseAll_Click(object sender, EventArgs e)
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
            btnCloseAll.Enabled = false;
        }



        private void InitializeVacuumStatusTimer()
        {
            VacuumStatusTimer = new System.Windows.Forms.Timer();
            VacuumStatusTimer.Interval = 1000; // update every 1 second
            VacuumStatusTimer.Tick += VacuumStatusTimer_Tick;
            VacuumStatusTimer.Start();
        }


        private void VacuumStatusTimer_Tick(object sender, EventArgs e)
        {
            // Refresh Vacuum in panel
            if (cmbVacuumList.SelectedItem is ComboVacuumItem selectedItem && selectedItem.Control is UCVacuum panelUc)
            {
                if (panelUc.Tag is Vacuum_config.Vacuums configEnum)
                {
                    UpdateUIVacuumInputStatus(configEnum, panelUc);
                }
            }

            // Refresh popup Vacuums
            foreach (var kvp in controlPopupMap)
            {
                if (kvp.Key is UCVacuum uc && uc.Tag is Vacuum_config.Vacuums configEnum)
                {
                    UpdateUIVacuumInputStatus(configEnum, uc);
                }
            }
        }


        private void UpdateUIVacuumInputStatus(Vacuum_config.Vacuums configEnum, UCVacuum uc)
        {
            var Vacuum = Vacuum_config.Vacuums_List[(int)configEnum];

            var VacuumOnColor = Vacuum.IsVacuumOn ? Color.Red : Color.Green;

            uc.SetVacuumFeedbackButtonColors(VacuumOnColor, Color.Black);
        }

    }
   

}
