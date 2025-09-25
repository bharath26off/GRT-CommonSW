// Form1.cs
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Program;

namespace AutoIOTest
{
    public partial class AutoIOTesting : Form
    {
        /// <summary>
        /// Axis control and calibration tracking variables:       
        /// - totalAxes: Total number of axes to calibrate (static).
        /// - successCount: Count of axes successfully calibrated.
        /// - failCount: Count of axes failed during calibration.
        /// </summary>        
        private List<Axis> axisList = new List<Axis>();
        private static uint totalAxes;
        private int successCount = 0;
        private int failCount = 0;
        public static Advantech_PCIE TESTAxis;

        /// <summary>
        /// Initializes the AutoCalibration form, sets up the UI with default values,
        /// checks for available axes, and updates labels accordingly.
        /// </summary>
        public AutoIOTesting()
        {
            InitializeComponent();            
            
            totalAxes = Advantech_PCIE.m_ulAxisCount;            
            
            lblTotalAxes.Text = String.Format("Total Axes Found: {0}", totalAxes);
            lblIOTestStatus.Text = "Ready to start I/O test";    
        }

        /// <summary>
        /// Logs a message to the log list (ListBox), with thread-safe UI update support.
        /// </summary>
        /// <param name="message">The message to log.</param>
        private void Log(string message)
        {
            if (listBoxLog.InvokeRequired)
            {
                listBoxLog.Invoke(new Action(() =>
                {
                    listBoxLog.Items.Add(message);
                    listBoxLog.TopIndex = listBoxLog.Items.Count - 1; // Auto-scroll                   
                }));
            }
            else
            {
                listBoxLog.Items.Add(message);
                listBoxLog.TopIndex = listBoxLog.Items.Count - 1; // Auto-scroll               
            }
        }

        /// <summary>
        /// Handles the Start I/O Test button click event. 
        /// Initializes the axis list, clears previous logs, updates UI status, and begins the auto-calibration process asynchronously.
        /// </summary>
        /// <param name="sender">The event sender.</param>
        /// <param name="e">The event arguments.</param>
        private async void btnStartIOTest_Click(object sender, EventArgs e)
        {
            if (totalAxes <= 0)
            {
                MessageBox.Show("No Axis Was Found For Auto I/O Testing.", "Auto I/O Testing", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            axisList.Clear();
            listBoxLog.Items.Clear();
            lblIOTestStatus.Text = "Starting Auto I/O Test...";

            for (int i = 0; i < totalAxes; i++)
            {
                axisList.Add(new Axis($"Axis {i + 1}/{totalAxes}", "PCIE", Log, i));
            }    
            
            await RunIOSequenceTestAsync();  // ✅ Await this!       
        }

        /// <summary>
        /// Executes the auto calibration sequence asynchronously for all configured axes.
        /// Iterates through each axis, runs its full calibration sequence, logs the result,
        /// and updates the UI status accordingly. Maintains a count of successful and failed calibrations.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        private async Task RunIOSequenceTestAsync()
        {
            int count = axisList.Count;

            successCount = 0;
            failCount = 0;

            lblIOTestStatus.Text = "Auto I/O Testing Started...";
            Log("--- Auto I/O Test Sequence Started ---");
            Log("");

            for (int i = 0; i < count; i++)
            {
                var axis = axisList[i];
                Log($"Testing Axis {i + 1}/{count}");

                lblIOTestStatus.Text = $"Testing Axis {i + 1}/{count}...";

                TESTAxis = new Advantech_PCIE(i, "TESTAxis");

                bool isSuccess = await axis.RunFullSequenceAsync();

                if (isSuccess)
                {
                    successCount++;
                    Log($"Axis {i + 1}/{count} - Testing Successful ✅");
                }
                else
                {
                    failCount++;
                    Log($"Axis {i + 1}/{count} - Testing Failed ❌");
                }

                Log("");
                lblIOTestStatus.Text = $"Auto I/O Testing Completed {i + 1}/{count}";
            }

            Log("All Axis Tested ✅");
        }

        /// <summary>
        /// Displays the final calibration status summary including the number of successful and failed calibrations.
        /// Updates the calibration status label with the results.
        /// </summary>
        /// <param name="sender">The source of the event (View Status button).</param>
        /// <param name="e">Event data associated with the click event.</param>
        private void btnViewStatus_Click(object sender, EventArgs e)
        {
            if (successCount == 0 && failCount == 0)
            {
                lblIOTestStatus.Text = $"Auto I/O Testing has not started yet ⏳";
            }
            else
            {
                lblIOTestStatus.Text = $"Auto I/O Testing is Finished ✅ | Success: {successCount}, Failed: {failCount}";
            }
        }
    }
} // End of AutoCalibration.cs
