

using CylinderHelperLib; // for Cylinder Class
using DIO; // for EOutput and EInput Enums
using ExceptionLib; // for Logging Error
using MasterProject.GlobalClass;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Linq;

namespace DynamicCylinders
{
    public static class Cylinder_config
    {
        #region List of all cylinders
        // Make a Enum Cylinders List
        public enum Cylinders
        {
            Scan_Conv_Stopper_Cyl,
            Work_Conv_1_pallet_Lift_Cyl,
            Work_Conv_1_Stopper_Cyl,
            Work_Conv_2_pallet_Lift_Cyl,
            Work_Conv_2_Stopper_Cyl
        }
        #endregion


        #region Cylinder Initialization
        // Initialize a fixed-size list of Cylinder objects matching the Cylinders enum
        public static List<Cylinder> Cylinders_List = new List<Cylinder>(new Cylinder[Enum.GetNames(typeof(Cylinders)).Length]);

        static Cylinder_config()
        {
            try
            {

                #region With XML Config

                var doc = XDocument.Load(Path.Combine(Application.StartupPath, "Data", "cylinders.xml"));
                // Optional: Check count matches enum count
                var cylindersXml = doc.Descendants("Cylinder").ToList();
                if (cylindersXml.Count != Enum.GetNames(typeof(Cylinders)).Length)
                {
                    MessageBox.Show("Total Number of Cylinders in XML does not match Cylinders enum.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Assuming Cylinders_List is initialized like: Cylinder[] Cylinders_List = new Cylinder[Enum.GetNames(typeof(Cylinders)).Length];

                foreach (var cylEnum in Enum.GetValues(typeof(Cylinders)).Cast<Cylinders>())
                {
                    string cylName = cylEnum.ToString();

                    var elem = cylindersXml.FirstOrDefault(x =>
                        string.Equals(x.Attribute("CylinderConfig")?.Value.Trim(), cylName, StringComparison.OrdinalIgnoreCase));

                    if (elem == null)
                    {
                        // Optional: handle missing config
                        continue;
                    }

                    // Local helper to parse string and int from attributes
                    string GetAttr(string attrName) => elem.Attribute(attrName)?.Value?.Trim();
                    int GetAttrInt(string attrName) => int.TryParse(GetAttr(attrName), out var val) ? val : 0;

                    List<string> ParseStringList(string csv)
                    {
                        return string.IsNullOrWhiteSpace(csv)
                            ? new List<string>()
                            : new List<string>(csv.Split(',').Select(s => s.Trim()));
                    }

                    var cylinder = new Cylinder(
                        valve_type: GetAttrInt("ValveType"),
                        cylinder_name: GetAttr("CylinderName"),
                        sense_Extend: ParseEnumList<DIDO.EInput>(GetAttr("SenseExtendEnumName")),
                        sense_Extend_input_address: ParseStringList(GetAttr("SenseExtendInputAddress")),
                        sense_Retract: ParseEnumList<DIDO.EInput>(GetAttr("SenseRetractEnumName")),
                        sense_Retract_input_address: ParseStringList(GetAttr("SenseRetractInputAddress")),
                        valve_Extend: ParseEnumList<DIDO.EOutput>(GetAttr("ValveExtendEnumName")),
                        valve_Extend_output_address: ParseStringList(GetAttr("ValveExtendOutputAddress")),
                        valve_Retract: ParseEnumList<DIDO.EOutput>(GetAttr("ValveRetractEnumName")),
                        valve_Retract_output_address: ParseStringList(GetAttr("ValveRetractOutputAddress")),
                        timeout_sec: GetAttrInt("TimeoutSec"),
                        stableCount_time: GetAttrInt("StableCountTime"),
                        valve_action_time: GetAttrInt("ValveActionTime")
                    );

                    // Store in list at enum index
                    Cylinders_List[(int)cylEnum] = cylinder;
                    //Register the Delegates
                    Cylinders_List[(int)cylEnum].RegisterWriteOpsCallback(GlobalVariable.DIDO.WriteOPS); //Write_DO wrapper
                    Cylinders_List[(int)cylEnum].RegisterReadDICallback(GlobalVariable.DIDO.ReadDI); //DI_RefreshValue wrapper

                }

                #endregion
            }
            catch (Exception ex)
            {
                MessageBox.Show("Cylinder_Config_Error: " + ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Logger.WriteLog(Logger.LogType.Error, "Cylinder_Config", "CylinderConfig", ex.Message, ex.StackTrace);
                //throw;
            }
        }
       

        private static List<int> ParseEnumList<TEnum>(string csv) where TEnum : struct
        {
            var list = new List<int>();

            if (string.IsNullOrWhiteSpace(csv))
                return list;

            string[] items = csv.Split(',');
            foreach (string item in items)
            {
                string trimmed = item.Trim();
                TEnum enumVal;
                // Use generic TryParse with ignoreCase
                if (Enum.TryParse<TEnum>(trimmed, true, out enumVal))
                {
                    list.Add(Convert.ToInt32(enumVal));
                }
                // else ignore invalid entries
            }

            return list;
        }

        #endregion

    }
}
