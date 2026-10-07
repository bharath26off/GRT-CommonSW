using Master;
using Master.Properties;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


   public class GridView
    {

    public static Image signal_on, signal_off;
    public static void IMPORT_CSV_TO_GRIDVIEW(string filePath, DataGridView dgv)
        {
            if (!File.Exists(filePath))
            {
                MessageBox.Show("CSV file not found.");
                return;
            }

            var lines = File.ReadAllLines(filePath);
            DataTable table = new DataTable();

            if (lines.Length > 0)
            {
                //Read the headers
                string[] headers = lines[0].Split(',');
                foreach (string header in headers)
                {
                    table.Columns.Add(header);
                }

                // Read each line
                for (int i = 1; i < lines.Length; i++)
                {
                    string[] values = lines[i].Split(',');
                    table.Rows.Add(values);
                }

                dgv.DataSource = table;
                foreach (DataGridViewColumn column in dgv.Columns)
                {
                    column.SortMode = DataGridViewColumnSortMode.NotSortable;
                }

                dgv.DataSource = table;
                foreach (DataGridViewColumn column in dgv.Columns)
                {
                    column.SortMode = DataGridViewColumnSortMode.NotSortable;
                }
            }
            else
            {
                MessageBox.Show("CSV Data is Empty !!.");
            }
        }

        public static void EXPORT_GRIDVIEW_TO_CSV(DataGridView dgv, string filePath)
        {
            if (dgv.Rows.Count == 0)
            {
                MessageBox.Show("No data to export.");
                return;
            }

            StringBuilder csvContent = new StringBuilder();

            // Write the headers
            for (int i = 0; i < dgv.Columns.Count; i++)
            {
                csvContent.Append(dgv.Columns[i].HeaderText);
                if (i < dgv.Columns.Count - 1)
                    csvContent.Append(",");
            }
            csvContent.AppendLine();

            // Write the data
            foreach (DataGridViewRow row in dgv.Rows)
            {
                if (!row.IsNewRow) // Skip the new row at the end
                {
                    for (int i = 0; i < dgv.Columns.Count; i++)
                    {
                        var value = row.Cells[i].Value?.ToString().Replace(",", ""); // Optional: remove commas
                        csvContent.Append(value);
                        if (i < dgv.Columns.Count - 1)
                            csvContent.Append(",");
                    }
                    csvContent.AppendLine();
                }
            }

            // Save to file
            try
            {
                File.WriteAllText(filePath, csvContent.ToString());
               // MessageBox.Show("Data exported successfully to " + filePath);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving file: " + ex.Message);
            }
        }

    public static void CSV_DATA_TO_VARIABLES(string filePath)
    {
        try
        {
            if (!File.Exists(filePath))
            {
                MessageBox.Show("CSV file not found.");
                return;
            }
            var lines = File.ReadAllLines(filePath);
            DataTable table = new DataTable();

            if (lines.Length > 0)
            {
                //Read the headers
                string[] headers = lines[0].Split(',');
                foreach (string header in headers)
                {
                    table.Columns.Add(header);
                }

                // Read each line
                for (int i = 1; i < lines.Length; i++)
                {
                    string[] values = lines[i].Split(',');
                    table.Rows.Add(values);
                }
            }
            else
            {
                MessageBox.Show("CSV Data is Empty !!.");
            }
        }
        catch (Exception ex)
        {

        }

    }

    public static void Button_Names_Columns(string[] Names, DataGridView Table,bool button_enable,int button_width,int text_width)
    {
        signal_on = Image.FromFile(@"ICO\signal_on.png");
        signal_off = Image.FromFile(@"ICO\signal_off.png");

        DataGridViewButtonColumn buttonColumn = new DataGridViewButtonColumn();
        buttonColumn.HeaderText = "Status";
        buttonColumn.FlatStyle = FlatStyle.Popup;
        buttonColumn.Width = button_width;  //60
        Table.Columns.Add(buttonColumn);
        buttonColumn.Selected = false;
        if (button_enable)
        {
            buttonColumn.ReadOnly=false;
        }
        else
        {
            buttonColumn.ReadOnly = true;
        }

        DataGridViewTextBoxColumn textColumn = new DataGridViewTextBoxColumn();
        textColumn.HeaderText = "Name";
        textColumn.Width = text_width;  //540
        textColumn.ReadOnly = true;

        Table.Columns.Add(textColumn);

        //Table.Enabled = false;
        Table.ScrollBars = ScrollBars.Vertical;
        Table.ClearSelection();
        Table.AllowUserToAddRows = false;
        Table.AllowUserToResizeColumns = false;
        Table.AllowUserToResizeRows = false;
        


        for (int i = 0; i <Names.Length; i++)
        {
            int rowIndex = Table.Rows.Add();
            Table.Rows[rowIndex].Cells[1].Value =Names[i];
        }
    }

    public static void Images_Names_Columns(string[] Names, DataGridView Table, bool button_enable,int image_width, int text_width)
    {

        signal_on = Image.FromFile(@"ICO\signal_on.png");
        signal_off = Image.FromFile(@"ICO\signal_off.png");
        DataGridViewImageColumn buttonColumn = new DataGridViewImageColumn();
        buttonColumn.ImageLayout = DataGridViewImageCellLayout.Zoom;
        buttonColumn.HeaderText = "Status";
        //buttonColumn.FlatStyle = FlatStyle.Popup;
        buttonColumn.Width = image_width;
        Table.Columns.Add(buttonColumn);
        buttonColumn.Selected = false;
        if (button_enable)
        {
            buttonColumn.ReadOnly = false;
        }
        else
        {
            buttonColumn.ReadOnly = true;
        }

        DataGridViewTextBoxColumn textColumn = new DataGridViewTextBoxColumn();
        textColumn.HeaderText = "Name";
        textColumn.Width = text_width;
        textColumn.ReadOnly = true;
        Table.Columns.Add(textColumn);
        //Table.Enabled = false;
        Table.ScrollBars = ScrollBars.Vertical;
        Table.ClearSelection();
        Table.AllowUserToAddRows = false;
        Table.AllowUserToResizeColumns = false;
        Table.AllowUserToResizeRows = false;



        for (int i = 0; i < Names.Length; i++)
        {
            int rowIndex = Table.Rows.Add();
            Table.Rows[rowIndex].Cells[1].Value = Names[i];
        }
    }

    public static void Names_Text_Columns(string[] Names, string[] Units, DataGridView Table)
    {
        try
        {
            DataGridViewTextBoxColumn textColumn = new DataGridViewTextBoxColumn();
            textColumn.HeaderText = "Name";
            textColumn.Width = 510;
            textColumn.ReadOnly = true;

            Table.Columns.Add(textColumn);


            DataGridViewTextBoxColumn text1Column = new DataGridViewTextBoxColumn();
            text1Column.HeaderText = "Values";
            text1Column.Width = 90;
            text1Column.ReadOnly = true;

            Table.Columns.Add(text1Column);

            DataGridViewTextBoxColumn text2Column = new DataGridViewTextBoxColumn();
            text2Column.HeaderText = "Unit";
            text2Column.Width = 40;
            text2Column.ReadOnly = true;

            Table.Columns.Add(text2Column);


            //Table.Enabled = false;
            Table.ScrollBars = ScrollBars.Vertical;
            Table.ClearSelection();
            Table.AllowUserToAddRows = false;
            Table.AllowUserToResizeColumns = false;
            Table.AllowUserToResizeRows = false;



            for (int i = 0; i < Names.Length; i++)
            {
                int rowIndex = Table.Rows.Add();
                Table.Rows[rowIndex].Cells[0].Value = Names[i];
                Table.Rows[rowIndex].Cells[2].Value = Units[i];
            }
            
        }
        catch (Exception ex)
        {

        }
    }


    public static bool Create_Column_Header(DataGridView table, string column1="", string column2="", string column3="", string column4 = "", string column5 = "", string column6 = "", string column7 = "", string column8 = "", string column9 = "", string column10 = "")
    {
        if (column1 != "")
        {
            table.Columns.Add(column1, column1);
        }
        if (column2 != "")
        {
            table.Columns.Add(column2, column2);
        }
        if (column3 != "")
        {
            table.Columns.Add(column3, column3);
        }
        if (column4 != "")
        {
            table.Columns.Add(column4, column4);
        }
        if (column5 != "")
        {
            table.Columns.Add(column5, column5);
        }
        if (column6 != "")
        {
            table.Columns.Add(column6, column6);
            
        }
        if (column7 != "")
        {
            table.Columns.Add(column7, column7);
        }
        if (column8 != "")
        {
            table.Columns.Add(column8, column8);
        }
        if (column9 != "")
        {
            table.Columns.Add(column9, column9);
        }
        if (column10 != "")
        {
            table.Columns.Add(column10, column10);

        }

        return true;
    }
    public static void Digital_Input_Status(string[] Input_Names, DataGridView Table, bool[] IO_Status)
    {
        for (int i = 0; i < Input_Names.Length; i++)
        {
            if (IO_Status[i] == true)
            {
                //Table.Rows[i].Cells[1].Style.BackColor = Color.Lime;
                Table.Rows[i].Cells[0].Value = signal_on;
            }
            else
            {
                //Table.Rows[i].Cells[1].Style.BackColor = Color.White;
                Table.Rows[i].Cells[0].Value = signal_off;
            }
        }
        Table.ClearSelection();
    }

    public static void Digital_Output_Status(string[] Input_Names, DataGridView Table,bool[] IO_Status)
    {
        for (int i = 0; i < Input_Names.Length; i++)
        {
            if (IO_Status[i] == true)
            {
                Table.Rows[i].Cells[0].Style.BackColor = Color.Lime;
               // Table.Rows[i].Cells[1].Value = signal_on;
            }
            else
            {
                Table.Rows[i].Cells[0].Style.BackColor = Color.White;
               // Table.Rows[i].Cells[1].Value = signal_off;
            }
        }
        Table.ClearSelection();
    }

    public static void Analog_Input_Status(string[] Input_Names, DataGridView Table, Double[] Analog_Status)
    {
        for (int i = 0; i < Input_Names.Length; i++)
        {
            if (i == 0)
            {
                Table.Rows[i].Cells[1].Value = GlobalVariable.loadconverz1.ToString();
            }
            if (i == 1)
            {
                Table.Rows[i].Cells[1].Value = GlobalVariable.loadconverz2.ToString();
            }
            // Table.Rows[i].Cells[1].Value = Analog_Status[i].ToString();

        }
        Table.ClearSelection();
    }
}

