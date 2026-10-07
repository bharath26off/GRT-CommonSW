using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;


public class XML
{
    #region for TCP_IP
    public static bool Save_IP_To_XML(DataGridView table, string xmlFilePath)
    {
        
        XElement root = new XElement("TCP_IP_Details");

        foreach (DataGridViewRow row in table.Rows)
        {
            // Skip the new row
            if (row.IsNewRow) continue;

            string serverName = row.Cells["Server_Name"].Value?.ToString();
            string ipAddress = row.Cells["IP_Address"].Value?.ToString();
            string portStr = row.Cells["Port"].Value?.ToString();

            if (!string.IsNullOrEmpty(serverName) &&
                !string.IsNullOrEmpty(ipAddress) &&
                int.TryParse(portStr, out int port))
            {
                XElement serverElement = new XElement("Server",
                    new XElement("Name", serverName),
                    new XElement("IP", ipAddress),
                    new XElement("Port", port)
                );
                root.Add(serverElement);
            }
        }
        root.Save(xmlFilePath);
        //TCPIP.XML_To_Variables();
        return true;
    }
    public static bool XML_To_Data_Grid(DataGridView table, string xmlFilePath)
    {

        if (!System.IO.File.Exists(xmlFilePath))
        {
            MessageBox.Show("XML file not found.");
            return false;
        }

        XElement root = XElement.Load(xmlFilePath);

        table.Rows.Clear(); // Clear existing rows
        table.Columns.Add("Server_Name", "Server_Name");
        table.Columns.Add("IP_Address", "IP_Address");
        table.Columns.Add("Port", "Port");

        table.Columns["Server_Name"].SortMode = DataGridViewColumnSortMode.NotSortable;
        table.Columns["IP_Address"].SortMode = DataGridViewColumnSortMode.NotSortable;
        table.Columns["Port"].SortMode = DataGridViewColumnSortMode.NotSortable;

        foreach (XElement server in root.Elements("Server"))
        {
            string serverName = server.Element("Name")?.Value;
            string ip = server.Element("IP")?.Value;
            string port = server.Element("Port")?.Value;


            table.Rows.Add(serverName, ip, port);
        }
        return true;
    }
    #endregion


    public static bool SaveGridToXml(DataGridView gridView, string filePath, string tablename)
    {
        try
        {
            DataTable dt = new DataTable();

            // Create columns
            foreach (DataGridViewColumn column in gridView.Columns)
            {
                dt.Columns.Add(column.HeaderText);
            }

            // Add rows
            foreach (DataGridViewRow row in gridView.Rows)
            {
                if (!row.IsNewRow)
                {
                    DataRow dr = dt.NewRow();
                    for (int i = 0; i < gridView.Columns.Count; i++)
                    {
                        dr[i] = row.Cells[i].Value?.ToString() ?? "";
                    }
                    dt.Rows.Add(dr);
                }
            }

            // Write to XML
            dt.TableName = tablename;
            dt.WriteXml(filePath);
            return true;
        }
        catch (Exception ex)
        {
            return false;
        }
    }

    public static bool SaveGridToXml1(DataGridView gridView, string filePath, string tableName, string rowElementName = "Row")
    {
        try
        {
            XElement root = new XElement(tableName);

            foreach (DataGridViewRow row in gridView.Rows)
            {
                if (!row.IsNewRow)
                {
                    // Use custom row element name
                    XElement rowElement = new XElement(rowElementName);

                    for (int i = 0; i < gridView.Columns.Count; i++)
                    {
                        string columnName = gridView.Columns[i].HeaderText;
                        string cellValue = row.Cells[i].Value?.ToString() ?? "";
                        rowElement.SetAttributeValue(columnName, cellValue);
                    }

                    root.Add(rowElement);
                }
            }

            root.Save(filePath);
            return true;
        }
        catch
        {
            return false;
        }
    }


    public static bool Load_Xml_to_Grid_View(DataGridView gridView, string filePath)
    {
        try
        {
            DataSet ds = new DataSet();
            ds.ReadXml(filePath);
            gridView.DataSource = ds.Tables[0];
            return true;
        }
        catch (Exception ex)
        {
            return false;
        }
    }

    public static string[][] PDCA_DATA_TO_VARAIBLES(string filePath)
    {
        try
        {
            DataSet ds = new DataSet();
            ds.ReadXml(filePath);

            DataTable dt = ds.Tables[0];

            string[][] columnArrays = new string[dt.Columns.Count][];

            for (int col = 0; col < dt.Columns.Count; col++)
            {
                columnArrays[col] = new string[dt.Rows.Count];
                for (int row = 0; row < dt.Rows.Count; row++)
                {
                    columnArrays[col][row] = dt.Rows[row][col].ToString();
                }
            }
            return columnArrays;
        }
        catch (Exception ex)
        {
            return null;
        }
    } //column [0] = first column values in array

    public static string[][] XML_Data_to_Varaiables_Column_String(string filePath)
    {
        try
        {
            DataSet ds = new DataSet();
            ds.ReadXml(filePath);

            DataTable dt = ds.Tables[0];

            // Skip the first column → start from index 1
            int columnCount = dt.Columns.Count - 1;

            if (columnCount <= 0)
                return new string[0][]; // No columns left after removing the first one

            string[][] columnArrays = new string[columnCount][];

            for (int col = 1; col < dt.Columns.Count; col++) // Start from 1
            {
                columnArrays[col - 1] = new string[dt.Rows.Count];

                for (int row = 0; row < dt.Rows.Count; row++)
                {
                    columnArrays[col - 1][row] = dt.Rows[row][col]?.ToString() ?? string.Empty;
                }
            }

            return columnArrays;
        }
        catch (Exception ex)
        {
            return null;
        }
    }
    public static double[][] XML_Data_to_Variables_Column(string filePath)
    {
        try
        {
            DataSet ds = new DataSet();
            ds.ReadXml(filePath);

            DataTable dt = ds.Tables[0];

            // Skip the first column → start from index 1
            int columnCount = dt.Columns.Count - 1;

            if (columnCount <= 0)
                return new double[0][]; // No columns left after removing the first one

            double[][] columnArrays = new double[columnCount][];

            for (int col = 1; col < dt.Columns.Count; col++) // Start from 1
            {
                columnArrays[col - 1] = new double[dt.Rows.Count];

                for (int row = 0; row < dt.Rows.Count; row++)
                {
                    string cellValue = dt.Rows[row][col]?.ToString()?.Trim();

                    // Try parsing the value to double
                    if (double.TryParse(cellValue, out double parsedValue))
                    {
                        columnArrays[col - 1][row] = parsedValue;
                    }
                    else
                    {
                        // Default value for invalid data; you can also throw or log
                        columnArrays[col - 1][row] = 0.0;
                    }
                }
            }

            return columnArrays;
        }
        catch (Exception)
        {
            return null;
        }
    }


    public static string[][] XML_Data_to_Varaiables_Row(string filePath)
    {
        try
        {
            DataSet ds = new DataSet();
            ds.ReadXml(filePath);

            DataTable dt = ds.Tables[0];

            string[][] columnArrays = new string[dt.Columns.Count][];

            for (int col = 0; col < dt.Columns.Count; col++)
            {
                columnArrays[col] = new string[dt.Rows.Count];
                for (int row = 0; row < dt.Rows.Count; row++)
                {
                    columnArrays[col][row] = dt.Rows[row][col].ToString();
                }
            }
            return columnArrays;
        }
        catch (Exception ex)
        {
            return null;
        }
    } //column [0] = first column values in array
    public static List<List<string>> XML_Data_to_List_Columnwise(string filePath)
    {
        try
        {
            DataSet ds = new DataSet();
            ds.ReadXml(filePath);

            if (ds.Tables.Count == 0)
                throw new Exception("No tables found in XML.");

            DataTable dt = ds.Tables[0];
            List<List<string>> columnLists = new List<List<string>>();

            for (int col = 0; col < dt.Columns.Count; col++)
            {
                List<string> columnData = new List<string>();
                for (int row = 0; row < dt.Rows.Count; row++)
                {
                    columnData.Add(dt.Rows[row][col]?.ToString() ?? string.Empty);
                }
                columnLists.Add(columnData);
            }

            return columnLists;
        }
        catch (Exception ex)
        {
            
            return null;
        }
    }

    public static List<List<string>> XML_Data_to_List_Rowwise(string filePath)
    {
        try
        {
            DataSet ds = new DataSet();
            ds.ReadXml(filePath);

            if (ds.Tables.Count == 0)
                throw new Exception("No tables found in XML.");

            DataTable dt = ds.Tables[0];
            List<List<string>> rowLists = new List<List<string>>();

            for (int row = 0; row < dt.Rows.Count; row++)
            {
                List<string> rowData = new List<string>();
                for (int col = 0; col < dt.Columns.Count; col++)
                {
                    rowData.Add(dt.Rows[row][col]?.ToString() ?? string.Empty);
                }
                rowLists.Add(rowData);
            }

            return rowLists;
        }
        catch (Exception ex)
        {
            // Optionally log ex.Message or rethrow the exception
            return null;
        }
    }

    public static List<string[]> XML_Data_to_RowList(string filePath)
    {
        try
        {
            if (!File.Exists(filePath))
                throw new FileNotFoundException("XML file not found.", filePath);

            DataSet ds = new DataSet();
            ds.ReadXml(filePath);

            if (ds.Tables.Count == 0)
                throw new Exception("No tables found in XML data.");

            DataTable dt = ds.Tables[0];
            List<string[]> rowList = new List<string[]>();

            foreach (DataRow row in dt.Rows)
            {
                string[] rowData = row.ItemArray
                                     .Select(item => item?.ToString() ?? string.Empty)
                                     .ToArray();
                rowList.Add(rowData);
            }

            return rowList;
        }
        catch (Exception ex)
        {
            
            return null;
        }
    }
}
    