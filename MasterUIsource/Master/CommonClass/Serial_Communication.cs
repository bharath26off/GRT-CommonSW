using ExceptionLib;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;


public class Serial_Communication
{
    public static SerialPort serialPort2;
    public static System.Threading.Timer OPT_IOTimer;
    public bool OPT_Connection_Status = false;
    public static string OPT_Received_Command = string.Empty;
    public string OPT_COM = string.Empty;
    public static COMDetails portDetails = new COMDetails();

    public static string _ConFilePath = Environment.CurrentDirectory + @"\Data\OPT.xml";

    public Serial_Communication(string COMPort)
    {
        OPT_COM = COMPort;

        if (File.Exists(_ConFilePath))
        {
            LoadCOMDetails(OPT_COM);
        }
        else
        {
            MessageBox.Show("OPT Communication File is missing...", "OPT Communication", MessageBoxButtons.OK,
                MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);
        }

    }

    public COMDetails LoadCOMDetails(string name)
    {
        try
        {
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();

            ds.ReadXml(_ConFilePath);
            dt = ds.Tables[0];

            if (dt.Rows.Count > 0)
            {
                var result = dt.AsEnumerable().Where(row => row.Field<string>("Name") == name).FirstOrDefault();

                if (result != null)
                {
                    Enum.TryParse<Parity>(result.ItemArray[3].ToString(), out var par);
                    Enum.TryParse<StopBits>(result.ItemArray[4].ToString(), out var stopBit);
                    Enum.TryParse<Handshake>(result.ItemArray[5].ToString(), out var handshake);
                    portDetails.COMName = result.ItemArray[0].ToString();
                    portDetails.BaudRate = Convert.ToInt32(result.ItemArray[1].ToString());
                    portDetails.DataBits = Convert.ToInt32(result.ItemArray[2].ToString());
                    portDetails.Parity = par;
                    portDetails.StopBits = stopBit;
                    portDetails.HandShake = handshake;
                }
                return portDetails;
            }
            return null;
        }
        catch (Exception ex)
        {
            return null;
        }
    }

    public static void OPT_Controller(COMDetails details)
    {
        serialPort2 = new SerialPort
        {
            PortName = details.COMName,       //CHECK FOR OPT COM PORT AND ASSIGN
            BaudRate = details.BaudRate,
            DataBits = details.DataBits,
            Parity = Parity.None,
            StopBits = StopBits.One,
            Handshake = Handshake.None
        };
    }


    public bool Connect_OPT()
    {
        try
        {
            //Arulkumar Fixed Null start
            if (portDetails == null || string.IsNullOrEmpty(portDetails.COMName))
            {
                OPT_Connection_Status = false;
                return false;
            }
            //Arulkumar Fixed Null end

            OPT_Controller(portDetails);

            if (serialPort2.IsOpen == false)
            {
                serialPort2.Open();
                OPT_Connection_Status = true;
                return true;

            }
            else
            {
                OPT_Connection_Status = true;
                return true;
            }
        }
        catch (Exception ex)
        {
            Logger.WriteLog(Logger.LogType.Error, "Serial_Communication", "", ex.Message, ex.ToString());
           // MessageBox.Show("OPT Connection Failed !!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            OPT_Connection_Status = false;
            return false;
        }
    }

    public bool Disconnect_OPT()
    {
        try
        {
            //Arulkumar Fixed Null start
            if (serialPort2 != null && serialPort2.IsOpen)
            {
                serialPort2.Close();
            }
            //Arulkumar Fixed Null end
            return true;
        }

        catch (Exception ex)
        {
            Logger.WriteLog(Logger.LogType.Error, "Serial_Communication", "", ex.Message, ex.ToString());
           // MessageBox.Show("OPT Disconnection Failed !!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return false;
        }
    }


    public bool Write_OPT(string colour)
    {
        try
        {
            //Arulkumar Fixed Null start
            if (serialPort2 == null || !serialPort2.IsOpen)
            {
                return false;
            }
            //Arulkumar Fixed Null end
            byte[] hexabytes = new byte[] { };

            if (colour == "BLACK")
            {
                hexabytes = new byte[] { 0xFA, 0x03, 0x00, 0x00, 0x01, 0x00 };    //1-13       BLACK  
            }
            else if (colour == "WHITE" || colour == "PINK")
            {
                hexabytes = new byte[] { 0xFA, 0x03, 0x00, 0x00, 0x0E, 0x00 };     //14-26   WHITE AND PINK   
            }
            else if (colour == "RED")
            {
                hexabytes = new byte[] { 0xFA, 0x03, 0x00, 0x00, 0x1B, 0x00 };    //27- 39   RED
            }
            else if (colour == "BLUE")
            {
                hexabytes = new byte[] { 0xFA, 0x03, 0x00, 0x00, 0x28, 0x00 };     //40- 52   BLUE  
            }
            else if (colour == "GREEN")
            {
                hexabytes = new byte[] { 0xFA, 0x03, 0x00, 0x00, 0x35, 0x00 };   //53- 65   GREEN   
            }
            else if (colour == "PURPLE")
            {
                hexabytes = new byte[] { 0xFA, 0x03, 0x00, 0x00, 0x1B, 0x00 };   //27- 39    PURPLE  
            }
            else if (colour == " YELLOW")
            {
                hexabytes = new byte[] { 0xFA, 0x03, 0x00, 0x00, 0x35, 0x00 };    //53- 65   YELLOW
            }
            serialPort2.Write(hexabytes, 0, hexabytes.Length);
            Thread.Sleep(50);
            int bytelength = serialPort2.BytesToRead;
            byte[] receive = new byte[bytelength];
            serialPort2.Read(receive, 0, bytelength);
            OPT_Received_Command = BitConverter.ToString(receive);
            return true;
        }
        catch (Exception ex)
        {
            Logger.WriteLog(Logger.LogType.Error, "Serial_Communication", "", ex.Message, ex.ToString());
            return false;
        }

    }

    private static readonly string filePath = Path.Combine(Environment.CurrentDirectory, "Data", "Communication", "Serial_Details.csv");

    public static string[] COM_Port_Names = new string[50];

    public static void Load_Serial_Details()
    {
        try
        {
            if (!File.Exists(filePath))
            {
                MessageBox.Show(Path.Combine(Environment.CurrentDirectory, "Data", "Communication", "Serial_Details.csv !!! File Missing !!!"), "Info",MessageBoxButtons.OK ,MessageBoxIcon.Information ,MessageBoxDefaultButton.Button1,MessageBoxOptions.ServiceNotification);
                return;
            }
            var lines = File.ReadAllLines(filePath);
            DataTable table = new DataTable();

            if (lines.Length > 0)
            {
                // Read the headers
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
                    COM_Port_Names[i - 1] = values[1];
                }
            }
            else
            {
                MessageBox.Show(Path.Combine(Environment.CurrentDirectory, "Data", "Communication", "Serial_Details.csv !!! Data is Empty !!!"), "Info",MessageBoxButtons.OK,MessageBoxIcon.Information,MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);
            }
        }
        catch (Exception ex)
        {

            Logger.WriteLog(Logger.LogType.Error, "Serial_Communication", "", ex.Message, ex.ToString());
        }
    }
}

public class COMDetails
{
    public string COMName { get; set; }
    public int BaudRate { get; set; }
    public int DataBits { get; set; }
    public Parity Parity { get; set; }
    public StopBits StopBits { get; set; }
    public Handshake HandShake { get; set; }
}
