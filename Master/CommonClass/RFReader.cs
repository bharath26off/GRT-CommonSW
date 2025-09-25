using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Master.CommonClass
{
    internal class RFReader
    {
        MW_EasyPOD EasyPOD;
        UInt32 dwResult, Index;
        public RFReader() 
        { 
        
        }
        public string TryReadRFIDCard()
        {
            try
            {
                UInt32 uiLength, uiRead, uiResult, uiWritten;
                byte[] ReadBuffer = new byte[0x20];
                byte[] ReadBuffer1 = new byte[0x80];//epc

                byte[] WriteBuffer1 = new byte[] { 0x02, 0x41, 0x52, 0x31, 0x2C, 0x30, 0x2C, 0x34 }; //epc
                byte[] WriteBuffer = new byte[] { 0x02, 0x41, 0x52, 0x32, 0x2C, 0x30, 0x2C, 0x34 }; //tid
                //02 41 52 31 2C 32 2C 36 
                //52 32 2C 30 2C 36
                byte[] sResponse = null;
                sResponse = new byte[21];
                string Tag = string.Empty;

                EasyPOD.VID = 0xe6a;
                EasyPOD.PID = 0x317;
                Index = 1;
                uiLength = 128;
                unsafe
                {
                    fixed (MW_EasyPOD* pPOD = &EasyPOD)
                    {
                        dwResult = PODfuncs.ClearPODBuffer(pPOD);
                        dwResult = PODfuncs.DisconnectPOD(pPOD);

                        dwResult = PODfuncs.ConnectPOD(pPOD, Index);

                        if ((dwResult != 0))
                        {
                            MessageBox.Show("Not connected yet");
                        }
                        else
                        {
                            EasyPOD.ReadTimeOut = 200;
                            EasyPOD.WriteTimeOut = 200;

                            dwResult = PODfuncs.WriteData(pPOD, WriteBuffer, 8, &uiWritten);    //Send a request command to reader
                            uiResult = PODfuncs.ReadData(pPOD, ReadBuffer, uiLength, &uiRead);  //Read the response data from reader

                            dwResult = PODfuncs.WriteData(pPOD, WriteBuffer1, 8, &uiWritten);    //Send a request command to reader
                            uiResult = PODfuncs.ReadData(pPOD, ReadBuffer1, uiLength, &uiRead);  //Read the response data from reader

                            string EpcId = null;
                            EpcId = Encoding.ASCII.GetString(ReadBuffer1, 3, ReadBuffer1.Length - 3);  //ASC

                            //txttagId.Text = Encoding.ASCII.GetString(ReadBuffer, 4, ReadBuffer.Length - 8);
                            Tag = Encoding.ASCII.GetString(ReadBuffer, 4, ReadBuffer.Length - 8);
                            // textBox1.Text = Encoding.ASCII.GetString(ReadBuffer, 4, ReadBuffer.Length - 8);

                            string ABC = "";
                            ABC = EpcId.Substring(9);




                            // txtEpcId.Text = GetHexStr(ABC.Substring(0, 10));//;
                        }
                        dwResult = PODfuncs.ClearPODBuffer(pPOD);
                        dwResult = PODfuncs.DisconnectPOD(pPOD);

                    }
                }
                return Tag;
            }

            catch (Exception ex)
            {
                return null;
            }

        }

        public async void AutoreadRFID()
        {
            string tag = null;
            while (true)
            {
                while (tag == null || tag.Contains("\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0"))
                {
                    tag = await TryReadRFIDCardAsync();
                    if (tag != null)
                        MessageBox.Show(tag);

                }
                //if (tag != null)
                //{
                //    MessageBox.Show(tag);
                //    continue;
                //}
            }
        }

        public async Task<string> TryReadRFIDCardAsync()
        {
            return await Task.Run(() => TryReadRFIDCard());
        }

        public void WriteToRFID(string txtFpc)
        {
            
            if (!string.IsNullOrEmpty(txtFpc))
            {
                try
                {

                    UInt32 uiLength, uiRead, uiResult, uiWritten;
                    byte[] ReadBuffer = new byte[0x20];
                    byte[] ReadBuffer1 = new byte[0x40];//epc
                    byte[] sResponse = null;
                    sResponse = new byte[21];

                    EasyPOD.VID = 0xe6a;
                    EasyPOD.PID = 0x317;
                    Index = 1;
                    uiLength = 64;
                    unsafe
                    {
                        fixed (MW_EasyPOD* pPOD = &EasyPOD)
                        {
                            dwResult = PODfuncs.ClearPODBuffer(pPOD);
                            dwResult = PODfuncs.DisconnectPOD(pPOD);

                            dwResult = PODfuncs.ConnectPOD(pPOD, Index);

                            if ((dwResult != 0))
                            {
                                MessageBox.Show("Not connected yet");
                            }
                            else
                            {
                                EasyPOD.ReadTimeOut = 200;
                                EasyPOD.WriteTimeOut = 200;

                                string EPCMAIN = null;

                                EPCMAIN = txtFpc.PadRight(24, '0');



                                byte[] ba = Encoding.Default.GetBytes(EPCMAIN);
                                var hexString = BitConverter.ToString(ba);

                                var hexString1 = hexString.Replace("-", "");

                                var MainString = "024157312C322C362C" + hexString1.ToString();
                                // var MainString = "024157312C302C342C38" + hexString1.ToString();


                                byte[] WriteBufferForMain = StringToByteArrayFastest(MainString.Trim());

                                uint Len = Convert.ToUInt16(WriteBufferForMain.Length);
                                Thread.Sleep(200);
                                dwResult = PODfuncs.WriteData(pPOD, WriteBufferForMain, Len, &uiWritten);    //Send a request command to reader
                                Thread.Sleep(200);
                                uiResult = PODfuncs.ReadData(pPOD, ReadBuffer, uiLength, &uiRead);  //Read the response data from reader


                                string EpcId1 = null;
                                EpcId1 = Encoding.ASCII.GetString(ReadBuffer, 2, ReadBuffer.Length - 3);  //ASC

                                if (EpcId1 != null)
                                {
                                    string abc = EpcId1;
                                    if (abc.Contains("OK"))
                                    {
                                        MessageBox.Show( "Card Write SuccessFully", "Alert Message...", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    }
                                    else
                                    {
                                        MessageBox.Show("Please Try Again !!", "Alert Message...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    }
                                }
                            }
                            dwResult = PODfuncs.ClearPODBuffer(pPOD);
                            dwResult = PODfuncs.DisconnectPOD(pPOD);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show( "Something Wrong Please try agin", "Alert Message...", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }
            }
        }
        public static byte[] StringToByteArrayFastest(string hex)
        {
            if (hex.Length % 2 == 1)
                throw new Exception("The binary key cannot have an odd number of digits");

            byte[] arr = new byte[hex.Length >> 1];

            for (int i = 0; i < hex.Length >> 1; ++i)
            {
                arr[i] = (byte)((GetHexVal(hex[i << 1]) << 4) + (GetHexVal(hex[(i << 1) + 1])));
            }

            return arr;
        }
        public static int GetHexVal(char hex)
        {
            int val = (int)hex;
            return val - (val < 58 ? 48 : 55);
        }


    }
}
