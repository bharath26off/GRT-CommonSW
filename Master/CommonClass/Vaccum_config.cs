

using VaccumHelperLib; // for Vaccum Class
using DIO; // for EOutput and EInput Enums
using ExceptionLib; // for Logging Error
using HelperClassLib; // for CSV file to Datatable
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace DynamicVaccums
{
    public static class Vaccum_config
    {
        #region List of all Vaccum
        // Make a Enum Vaccums List
        public enum Vaccums
        {
            Vaccum1,
            Vaccum2,


        }
        #endregion



        #region VAccum Initialization
        // Initialize a fixed-size list of Vaccum objects matching the Vaccums enum
        public static List<Vaccum> Vaccums_List = new List<Vaccum>(new Vaccum[Enum.GetNames(typeof(Vaccums)).Length]);

        static Vaccum_config()
        {
            try
            {
                // Load Vaccum configuration from CSV into a DataTable
                DataTable VaccumCSVdt = GetDataFromHelper.GetDataFromCSV(Path.Combine(Application.StartupPath, "Data", "Vaccums.csv"));
                // Validate that the CSV and Enum have the same number of entries
                if (Enum.GetNames(typeof(Vaccums)).Length != VaccumCSVdt.Rows.Count)
                {
                    MessageBox.Show("Total Number of Vaccums in Cofig file doesn't match with Vaccums Enum", "Vaccum Configuration Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);
                    return;
                }
                // For each Vaccum in the enum, find its config row and create an object
                foreach (Vaccums vac in Enum.GetValues(typeof(Vaccums)))
                {
                    DataRow foundRow = VaccumCSVdt.AsEnumerable().FirstOrDefault(row => string.Equals(row["VaccumConfig"].ToString().Trim(), vac.ToString().Trim(), StringComparison.OrdinalIgnoreCase));

                    if (foundRow != null)
                    {
                        // Local helper functions for clean column value retrieval
                        string GetString(string column) => foundRow[column]?.ToString()?.Trim();
                        int GetInt(string column) => Convert.ToInt32(foundRow[column]);

                        // Create a Vaccum object using config values from CSV
                        var Vaccum = new Vaccum(
                        GetString("VaccumName"),
                        (int)(DIDO.EInput)Enum.Parse(typeof(DIDO.EInput), GetString("VaccumFeedbackEnumName")),
                        GetString("VaccumFeedbackInputAddress"),
                        (int)(DIDO.EOutput)Enum.Parse(typeof(DIDO.EOutput), GetString("VaccumOnOffEnumName")),
                        GetString("VaccumOnOffOutputAddress"),
                        (int)(DIDO.EOutput)Enum.Parse(typeof(DIDO.EOutput), GetString("BlowOnOffEnumName")),
                        GetString("BlowOnOffOutputAddress"),
                        GetInt("TimeoutSec"),
                        GetInt("StableCountTime")
                    );
                        // Store the Vaccum in the list at the index matching its enum value
                        Vaccums_List[(int)vac] = Vaccum;
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog(Logger.LogType.Error, "Vaccum_Config", "VaccumCOnfigConstr", ex.Message, ex.StackTrace);
                //throw;
            }
        }
        #endregion

    }
}
