//Class : DynamicCylinder
//Author: Saran Raj M
//Use   : Load Cylinder User control in Panel and Popup.

using CylinderHelperLib;
using Program;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using System.Xml.Linq;
using static DynamicCylinders.Cylinder_config;
namespace DynamicCylinders
{
    public partial class DynamicCylinder : Form
    {
        // Timer for periodic status update (currently not used)
        private System.Windows.Forms.Timer cylinderStatusTimer;
        public DynamicCylinder()
        {
            InitializeComponent();
            // Bind combo box and popup button events
            cmbCylinderList.SelectedIndexChanged += ComboBox1_SelectedIndexChanged;
            btnPopUp.Click += BtnPopup_Click;
        }

        //  // Custom combo box item holding a display name and associated UserControl
        public class ComboCylinderItem
        {
            public string DisplayName { get; set; }
            public UCCylinder Control { get; set; }

            public override string ToString()
            {
                return DisplayName;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            btnCloseAll.Enabled = false;
            cmbCylinderList.Items.Clear();
            // Adding Empty Cylinder
            cmbCylinderList.Items.Add(new ComboCylinderItem
            {
                DisplayName = "-- Select Cylinder --",
                Control = null
            });

            // Load cylinders from configuration file
            CylindersConfig();

            // set empty cylinder default
            cmbCylinderList.SelectedIndex = 0;
            //**devchange: uncomment after connected to machine
            InitializeCylinderStatusTimer();

        }


        private void CylindersConfig()
        {

            try
            {

                var doc = XDocument.Load(Path.Combine(Application.StartupPath, "Data", "cylinders.xml"));
                var cylindersXml = doc.Descendants("Cylinder").ToList();
                foreach (var elem in cylindersXml)
                {
                    var uc = new UCCylinder();

                    string enumName = elem.Attribute("CylinderConfig")?.Value.Trim();
                    if (string.IsNullOrEmpty(enumName)) continue;

                    Cylinders configEnum = (Cylinders)Enum.Parse(typeof(Cylinders), enumName);
                    uc.Tag = configEnum;

                    var cyl = Cylinders_List[(int)configEnum];

                    uc.SetGroupBoxCylinderName(elem.Attribute("CylinderName")?.Value.Trim());
                    uc.SetLabelWorkReedAddress(elem.Attribute("SenseExtendInputAddress")?.Value.Trim());
                    uc.SetLabelWorkCoilAddress(elem.Attribute("ValveExtendOutputAddress")?.Value.Trim());
                    uc.SetLabelHomeReedAddress(elem.Attribute("SenseRetractInputAddress")?.Value.Trim());
                    uc.SetLabelHomeCoilAddress(elem.Attribute("ValveRetractOutputAddress")?.Value.Trim());
                    uc.SetLabelSafetoExtend(elem.Attribute("LabelSafetoExtend")?.Value.Trim());
                    uc.SetLabelSafetoRetract(elem.Attribute("LabelSafetoRetract")?.Value.Trim());

                    uc.SetExtendReedButton(elem.Attribute("ExtendReedButton")?.Value.Trim());
                    uc.SetExtendCoilButton(elem.Attribute("ExtendCoilButton")?.Value.Trim());
                    uc.SetRetractCoilButton(elem.Attribute("RetractCoilButton")?.Value.Trim());
                    uc.SetRetractReedButton(elem.Attribute("RetractReedButton")?.Value.Trim());
                    uc.SetSafeToExtendButton(elem.Attribute("SafeToExtendButton")?.Value.Trim());
                    uc.SetSafeToRetractButton(elem.Attribute("SafeToRetractButton")?.Value.Trim());

                    bool ParseBool(string value) => !string.IsNullOrEmpty(value) && Convert.ToBoolean(value);

                    uc.EnableExtendReedButton(ParseBool(elem.Attribute("EnableExtendReedButton")?.Value.Trim()));
                    uc.EnableExtendCoilButton(ParseBool(elem.Attribute("EnableExtendCoilButton")?.Value.Trim()));
                    uc.EnableRetractCoilButton(ParseBool(elem.Attribute("EnableRetractCoilButton")?.Value.Trim()));
                    uc.EnableRetractReedButton(ParseBool(elem.Attribute("EnableRetractReedButton")?.Value.Trim()));
                    uc.EnableSafeToExtendButton(ParseBool(elem.Attribute("EnableSafeToExtendButton")?.Value.Trim()));
                    uc.EnableSafeToRetractButton(ParseBool(elem.Attribute("EnableSafeToRetractButton")?.Value.Trim()));
                    uc.EnableAllButtons(ParseBool(elem.Attribute("EnableAllButtons")?.Value.Trim()));

                    uc.SetSafeToExtendButtonColors(cyl.safe_to_extend ? Color.Green : Color.Red, Color.White);
                    uc.SetSafeToRetractButtonColors(cyl.safe_to_retract ? Color.Green : Color.Red, Color.White);

                    uc.btn_work_Clicked += Cylinder_btn_work_Clicked;
                    uc.btn_home_Clicked += Cylinder_btn_home_Clicked;

                    cmbCylinderList.Items.Add(new ComboCylinderItem
                    {
                        DisplayName = elem.Attribute("CylinderName")?.Value.Trim(),
                        Control = uc
                    });
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading cylinders: " + ex.Message);
            }
        }

        // Handle Work button (extend)
        private async void Cylinder_btn_work_Clicked(object sender, EventArgs e)
        {
            if (sender is UCCylinder uc && uc.Tag is Cylinders configEnum)
            {
                Cylinder advantechCylinder = Cylinders_List[(int)configEnum];
                if (await advantechCylinder.Cylinder_Extend_Manual_Mode())
                {
                    uc.SetExtendReedButtonColors(Color.Green, Color.White);
                    uc.SetRetractReedButtonColors(Color.Red, Color.White);
                }

            }

        }
        // Handle Home button (retract)
        private async void Cylinder_btn_home_Clicked(object sender, EventArgs e)
        {

            if (sender is UCCylinder uc && uc.Tag is Cylinders configEnum)
            {
                Cylinder advantechCylinder = Cylinders_List[(int)configEnum];
                if (await advantechCylinder.Cylinder_Retract_Manual_Mode())
                {
                    uc.SetExtendReedButtonColors(Color.White, Color.Red);
                    uc.SetRetractReedButtonColors(Color.Green, Color.Red);
                }
            }

        }

        // Dictionary to track which UCCylinders are shown in popups
        private Dictionary<Control, Form> controlPopupMap = new Dictionary<Control, Form>();

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Disable popup button if no valid cylinder selected
            btnPopUp.Enabled = (cmbCylinderList.SelectedItem is ComboCylinderItem selectedItem0 && selectedItem0.Control != null);

            pnlControl.Controls.Clear();

            if (cmbCylinderList.SelectedItem is ComboCylinderItem selectedItem && selectedItem.Control != null)
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
                // Update cylinder status on UI
                UpdateUICylinderStatus((Cylinders)selectedItem.Control.Tag, selectedItem.Control);

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
            if (cmbCylinderList.SelectedItem is ComboCylinderItem selectedItem && selectedItem.Control != null)
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
                    Owner = this,


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
                UpdateUICylinderStatus((Cylinders)selectedItem.Control.Tag, selectedItem.Control);
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
                MessageBox.Show("Select a valid cylinder.");
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

        private void InitializeCylinderStatusTimer()
        {
            cylinderStatusTimer = new System.Windows.Forms.Timer();
            cylinderStatusTimer.Interval = 1000; // update every 1 second
            cylinderStatusTimer.Tick += CylinderStatusTimer_Tick;
            cylinderStatusTimer.Start();
        }
        private void CylinderStatusTimer_Tick(object sender, EventArgs e)
        {
            // Refresh cylinder in panel
            if (cmbCylinderList.SelectedItem is ComboCylinderItem selectedItem && selectedItem.Control is UCCylinder panelUc)
            {
                if (panelUc.Tag is Cylinders configEnum)
                {
                    UpdateUICylinderStatus(configEnum, panelUc);
                }
            }

            // Refresh popup cylinders
            foreach (var kvp in controlPopupMap)
            {
                if (kvp.Key is UCCylinder uc && uc.Tag is Cylinders configEnum)
                {
                    UpdateUICylinderStatus(configEnum, uc);
                }
            }
        }




        private void UpdateUICylinderStatus(Cylinders configEnum, UCCylinder uc)
        {
            UpdateUICylinderSafeStatus(configEnum, uc);
            UpdateUICylinderInputStatus(configEnum, uc);
        }

        // Refresh safe-to-extend/retract status colors for UI
        private void UpdateUICylinderSafeStatus(Cylinders configEnum, UCCylinder uc)
        {
            var cylinder = Cylinders_List[(int)configEnum];
            var safeToExtendColor = cylinder.safe_to_extend ? Color.Green : Color.Red;
            var safeToRetractColor = cylinder.safe_to_retract ? Color.Green : Color.Red;

            uc.SetSafeToExtendButtonColors(safeToExtendColor, Color.Black);
            uc.SetSafeToRetractButtonColors(safeToRetractColor, Color.Black);
        }


        private void UpdateUICylinderInputStatus(Cylinders configEnum, UCCylinder uc)
        {
            var cylinder = Cylinders_List[(int)configEnum];

            var ExtendInputColor = cylinder.IsExtended ? Color.Green : Color.Red;
            var RetractInputColor = cylinder.IsRetracted ? Color.Green : Color.Red;

            uc.SetExtendReedButtonColors(ExtendInputColor, Color.Black);
            uc.SetRetractReedButtonColors(RetractInputColor, Color.Black);
        }


    }

}
