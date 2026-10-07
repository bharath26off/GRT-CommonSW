using System;
using System.Data;
using System.IO;
using System.Net.Sockets;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Linq;

public class TCPIP
{
    private TcpClient client;
    private NetworkStream stream;

    public string Name { get; set; }
    public string IP_Address{ get; private set; }
    public int Port_No { get; private set; }
    public bool Connection_Status { get; private set; }
    public string Received_Data { get; private set; }

   
    public TCPIP(string ipAddress, string portNo)
    {
        //XML_To_Variables();
        IP_Address = ipAddress;
        Port_No = Convert.ToInt32(portNo);
        Connection_Status = false;
        Received_Data = string.Empty;
    }

    public static string[] IP_Address_List = new string[50];

    public static string[] Port_No_List = new string[50];

    public static bool XML_To_Variables()
    {
        try
        {
            XDocument Data = XDocument.Load(Path.Combine(Environment.CurrentDirectory, "Data", "", "TCPIP_Settings.xml"));
            IP_Address_List = Data.Descendants("IP").Select(x => x.Value).ToArray();
            Port_No_List = Data.Descendants("Port").Select(x => x.Value).ToArray();

            return true;
        }
        catch (Exception ex)
        {
            return false;
        }
    }


    public static class CharToHex
    {
        public static string ConvertCodeToDecimal(string code)
        {
            if (code == null) return "";

            string text = code.Trim().ToUpper();
            switch (text)
            {
                case "<NUL>": return "00";
                case "<SOH>": return "01";
                case "<STX>": return "02";
                case "<ETX>": return "03";
                case "<EOT>": return "04";
                case "<ENQ>": return "05";
                case "<ACK>": return "06";
                case "<BEL>": return "07";
                case "<BS>": return "08";
                case "<HT>": return "09";
                case "<LF>": return "10";
                case "<VT>": return "11";
                case "<FF>": return "12";
                case "<CR>": return "13";
                case "<SO>": return "14";
                case "<SI>": return "15";
                case "<DLE>": return "16";
                case "<DC1>": return "17";
                case "<DC2>": return "18";
                case "<DC3>": return "19";
                case "<DC4>": return "20";
                case "<NAK>": return "21";
                case "<SYN>": return "22";
                case "<ETB>": return "23";
                case "<CAN>": return "24";
                case "<EM>": return "25";
                case "<SUB>": return "26";
                case "<ESC>": return "27";
                case "<FS>": return "28";
                case "<GS>": return "29";
                case "<RS>": return "30";
                case "<US>": return "31";
                case "<SP>": return "32";
                default: return code;
            }
        }
    }
    public static byte[] ASCIIToDecimal(string str)
    {
        byte[] array = new byte[0];
        string text = str.Replace("<", ",,,,,<").ToString().Replace(">", ">,,,,,");
        string[] array2 = text.Split(new string[1] { ",,,,," }, StringSplitOptions.None);
        for (int i = 0; i < array2.Length; i++)
        {
            if (!array2[i].StartsWith("<"))
            {
                int num = array.Length;
                Array.Resize(ref array, num + array2[i].Length);
                string text2 = array2[i].ToString();
                for (int j = 0; j < text2.Length; j++)
                {
                    array[num] = (byte)text2[j];
                    num++;
                }
                continue;
            }
            string text3 = array2[i].ToString();
            string text4 = CharToHex.ConvertCodeToDecimal(array2[i].ToString());
            if (text4 == text3)
            {
                int num2 = array.Length;
                Array.Resize(ref array, num2 + array2[i].Length);
                string text5 = array2[i].ToString();
                for (int k = 0; k < text5.Length; k++)
                {
                    array[num2] = (byte)text5[k];
                    num2++;
                }
            }
            else
            {
                int num3 = array.Length;
                Array.Resize(ref array, num3 + 1);
                array[num3] = byte.Parse(text4);
            }
        }
        return array;
    }



    public bool Connect()
    {
        try
        {
            //Arulkumar Fixed random stoppage start
            Disconnect();
            client = new TcpClient();
            var connectResult = client.BeginConnect(IP_Address, Port_No, null, null);
            bool connected = connectResult.AsyncWaitHandle.WaitOne(TimeSpan.FromSeconds(5));
            if (!connected || !client.Connected)
            {
                Connection_Status = false;
                return false;
            }
            client.EndConnect(connectResult);
            //Arulkumar Fixed random stoppage end
            stream = client.GetStream();
            Connection_Status = true;
            Received_Data = "";
            Receive();
            return true;
        }
        catch (Exception ex)
        {
            //MessageBox.Show("IP Address: " + IP_Address + " ,Port No: "+ Port_No + " Connection Failed !");
            Connection_Status = false;
            return false;
        }
    }
    public bool Send(string message)
    {
        try
        {
            if (client != null && client.Connected && stream != null)
            {
                message = message + "<CR><LF>";
                byte[] data = ASCIIToDecimal(message);
                stream.Write(data, 0, data.Length);
                return true;
            }
            else
            {
               // MessageBox.Show("TCPIP Data Send Failed !");
                return false;
            }
            
        }
        catch (Exception ex)
        {
            return false;
        }
    }
    public void Receive()
    {
        try
        {
            if (client != null && client.Connected && stream != null  )
            {
                if (stream.DataAvailable)
                {
                    byte[] buffer = new byte[1024];
                    int bytes = stream.Read(buffer, 0, buffer.Length);
                    if (bytes > 0)
                    {
                        Received_Data = Encoding.UTF8.GetString(buffer, 0, bytes);
                    }
                }
                Connection_Status = true;
            }
            else
            {
                Connection_Status = false;
            }
           // Receive();
        }
        catch (Exception ex)
        {
           // Receive();
        }
    }
    public bool Disconnect()
    {try
        {
            //Arulkumar Fixed random stoppage start
            if (stream != null)
            {
                stream.Close();
                stream.Dispose();
                stream = null;
            }
            if (client != null)
            {
                client.Close();
                client.Dispose();
                client = null;
            }
            //Arulkumar Fixed random stoppage end
            Connection_Status = false;
            return true;
        }
        catch(Exception ex)
        {
            //MessageBox.Show("Disconnection Failed !");
            return false;
        }
    }
}
