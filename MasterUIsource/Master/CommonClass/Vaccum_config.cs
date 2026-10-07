

using CylinderHelperLib;
using DIO; // for EOutput and EInput Enums
using ExceptionLib; // for Logging Error
using HelperClassLib; // for CSV file to Datatable
using Master;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Linq;
using VacuumHelperLib; // for Vacuum Class

namespace DynamicVacuums
{
    public static class Vacuum_config
    {
        #region List of all Vacuum
        // Make a Enum Vacuums List
        public enum Vacuums
        {
            Vacuum1,
            Vacuum2,
            Vacuum3,
            Vacuum4


        }
        #endregion



        #region Vacuum Initialization
        // Initialize a fixed-size list of Vacuum objects matching the Vacuums enum
        public static List<Vacuum> Vacuums_List = new List<Vacuum>(new Vacuum[Enum.GetNames(typeof(Vacuums)).Length]);

        static Vacuum_config()
        {
            try
            {

                #region With XML Config

                var doc = XDocument.Load(Path.Combine(Application.StartupPath, "Data", "Vacuums.xml"));
                // Optional: Check count matches enum count
                var VacuumsXml = doc.Descendants("Vacuum").ToList();
                if (VacuumsXml.Count != Enum.GetNames(typeof(Vacuums)).Length)
                {
                    MessageBox.Show("Total Number of Vacuums in XML does not match Vacuums enum.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Assuming Cylinders_List is initialized like: Cylinder[] Cylinders_List = new Cylinder[Enum.GetNames(typeof(Cylinders)).Length];

                foreach (var vacEnum in Enum.GetValues(typeof(Vacuums)).Cast<Vacuums>())
                {
                    string cylName = vacEnum.ToString();

                    var elem = VacuumsXml.FirstOrDefault(x =>
                        string.Equals(x.Attribute("VacuumConfig")?.Value.Trim(), cylName, StringComparison.OrdinalIgnoreCase));

                    if (elem == null)
                    {
                        // Optional: handle missing config
                        continue;
                    }

                    // --- Vacuum Properties ---

                    var props = new VacuumProperties
                    {
                        vacuum_name = elem.Attribute("VacuumName").Value,
                        vacuum_feedback = GlobalVariable.g_MachineIoChaged == "Yes" ? (int)(DIDO.EInput_1)Enum.Parse(typeof(DIDO.EInput_1), elem.Attribute("VacuumFeedbackEnumName").Value) : (int)(DIDO.EInput)Enum.Parse(typeof(DIDO.EInput), elem.Attribute("VacuumFeedbackEnumName").Value),
                        vacuum_feedback_input_address = elem.Attribute("VacuumFeedbackInputAddress").Value,
                        vacuum_on_off = GlobalVariable.g_MachineIoChaged == "Yes" ? (int)(DIDO.EOutput_1)Enum.Parse(typeof(DIDO.EOutput_1), elem.Attribute("VacuumOnOffEnumName").Value) : (int)(DIDO.EOutput)Enum.Parse(typeof(DIDO.EOutput), elem.Attribute("VacuumOnOffEnumName").Value),
                        vacuum_on_off_output_address = elem.Attribute("VacuumOnOffOutputAddress").Value,
                        blow_on_off = GlobalVariable.g_MachineIoChaged == "Yes" ? (int)(DIDO.EOutput_1)Enum.Parse(typeof(DIDO.EOutput_1), elem.Attribute("BlowOnOffEnumName").Value) : (int)(DIDO.EOutput)Enum.Parse(typeof(DIDO.EOutput), elem.Attribute("BlowOnOffEnumName").Value),
                        blow_on_off_output_address = elem.Attribute("BlowOnOffOutputAddress").Value,
                        timeout_sec = Convert.ToInt32(elem.Attribute("TimeoutSec").Value),
                        stableCount_time = Convert.ToInt32(elem.Attribute("StableCountTime").Value)
                    };

                    // --- Vacuum Error Codes ---
                    var errorCodes = new VacuumErrorCodes
                    {
                        VacuumOnOffFailEcode = (int)DIDO.ECode.Vac_VacuumOnOffFail,
                        BlowOnOffFailEcode = (int)DIDO.ECode.Vac_BlowOnOffFail,
                        TimeoutEcode = (int)DIDO.ECode.Vac_TimeoutEcode
                    };
                    var vac = new Vacuum(props, errorCodes);
                    vac.RegisterWriteOpsCallback(GlobalVariable.DIDO.WriteOPS);
                    vac.RegisterReadDICallback(GlobalVariable.DIDO.ReadDI);
                    Vacuums_List[(int)vacEnum] = vac;

                }

                #endregion
            }
            catch (Exception ex)
            {
                Logger.WriteLog(Logger.LogType.Error, "Vacuum_Config", "VacuumCOnfigConstr", ex.Message, ex.StackTrace);
                MessageBox.Show("Vacuum_Config_Error: " + ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        #endregion

    }
}
