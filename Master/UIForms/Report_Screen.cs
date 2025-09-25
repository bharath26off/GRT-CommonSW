using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using MasterProject.GlobalClass;


namespace Master.UI
{
    public partial class Report : Form
    {
        public Report()
        {
            InitializeComponent();
            float xRatio = (float)Screen.PrimaryScreen.Bounds.Width / GlobalVariable.OrginalFormWidth;
            float yRatio = (float)Screen.PrimaryScreen.Bounds.Height / GlobalVariable.OrginalFormHeight;
            GlobalVariable.ResizeAllControls(this, xRatio, yRatio);
            dtpFromDatePrdata.MinDate = Convert.ToDateTime("01-01-2000");
            dtpFromDateMachStatus.MinDate = Convert.ToDateTime("01-01-2000");
            dtpFromDateMacnHelth.MinDate = Convert.ToDateTime("01-01-2000");
            dtpToDatePrdata.MinDate = Convert.ToDateTime("01-01-2000");
            dtpToDateMachStatus.MinDate = Convert.ToDateTime("01-01-2000");
            dtpToDateMacnHelth.MinDate = Convert.ToDateTime("01-01-2000");
            dtpToDatePrdata.MaxDate = DateTime.Today;
            dtpToDateMachStatus.MaxDate = DateTime.Today;
            dtpToDateMacnHelth.MaxDate = DateTime.Today;
            dtpFromDatePrdata.MaxDate = DateTime.Today;
            dtpFromDateMachStatus.MaxDate = DateTime.Today;
            dtpFromDateMacnHelth.MaxDate = DateTime.Today;
            dtpFromDatePrdata.Value = DateTime.Today;
            dtpFromDateMachStatus.Value = DateTime.Today;
            dtpFromDateMacnHelth.Value = DateTime.Today;
            dtpToDatePrdata.Value = DateTime.Today;
            dtpToDateMachStatus.Value = DateTime.Today;
            dtpToDateMacnHelth.Value = DateTime.Today;
        }
        public string MshHeader = "Production Report";
        private void dtpFromDatePrdata_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                dtpToDatePrdata.MinDate = dtpFromDatePrdata.Value;
            }
            catch (Exception)
            {
            }
        }

        private void dtpFromDateMachStatus_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                dtpToDateMachStatus.MinDate = dtpFromDateMachStatus.Value;
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void dtpFromDateMacnHelth_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                dtpToDateMacnHelth.MinDate = dtpFromDateMacnHelth.Value;
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void btnLoadPrdata_Click(object sender, EventArgs e)
        {
            try
            {
                String shift = "";
                if (cmbShiftPrdata.SelectedItem != null)
                {
                    shift = cmbShiftPrdata.SelectedItem.ToString();
                }

                if (shift == string.Empty)
                {
                    MessageBox.Show("Please Select Shift", MshHeader, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cmbShiftPrdata.Focus();
                    return;
                }

                String BarCode = "";
                BarCode = txtBarcodePrdata.Text.Trim();

                if (BarCode == string.Empty || BarCode == "")
                {
                    MessageBox.Show("Please Enter Barcode", MshHeader, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtBarcodePrdata.Focus();
                    return;
                }
                MessageBox.Show("No Data Available", MshHeader, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void btnSavePrdata_Click(object sender, EventArgs e)
        {
            MessageBox.Show("No Data Available", MshHeader, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnResetPrdata_Click(object sender, EventArgs e)
        {
            MessageBox.Show("No Data Available", MshHeader, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnLoadMachStatus_Click(object sender, EventArgs e)
        {
            try
            {
                String shift = "";
                if (cmbShiftMachStatus.SelectedItem != null)
                {
                    shift = cmbShiftMachStatus.SelectedItem.ToString();
                }

                if (shift == string.Empty)
                {
                    MessageBox.Show("Please Select Shift", MshHeader, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cmbShiftMachStatus.Focus();
                    return;
                }
                MessageBox.Show("No Data Available", MshHeader, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            try
            {
                String shift = "";
                if (cmbShiftMacnHelth.SelectedItem != null)
                {
                    shift = cmbShiftMacnHelth.SelectedItem.ToString();
                }

                if (shift == string.Empty)
                {
                    MessageBox.Show("Please Select Shift", MshHeader, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cmbShiftMacnHelth.Focus();
                    return;
                }
                MessageBox.Show("No Data Available", MshHeader, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
