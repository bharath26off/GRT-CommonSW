using Advantech.Motion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GRT_BG1.Data
{
    public class PalletData
    {
        public PartData[,] PalletArr { get; set; }
        public Dictionary<string, PartData> Datas { get; set; } = new Dictionary<string, PartData>();
    }

    public class barcodeView
    { 
     
        public string barcodde {  get; set; }
        public string SN{ get; set; }
        public bool Check { get; set; }
        public int check {  get; set; }
    
    }
    public class Tossdata
    { 
    public DateTime DateTime { get; set; }
    public string Material { get; set; }
    public string SN { get; set; }
    public double Toss_X { get; set; }
    public double Toss_Y { get; set; }
    public double Toss_angle { get; set; }
    
    }
    
    public class PartData
    {
        public bool ScannerData { get; set; }
        public string SNno { get; set; }
        public string cameraData { get; set; }
        public string CarrierBarcode { get; set; }
        public string NLTime_stmp { get; set; }
        public string MLBTime_stmp { get; set; }
        public string RechekTime_stmp { get; set; }
        public string FedTime_stmp { get; set; }
        public string OkNok { get; set; }
        public bool pastingcmplt { get; set; } = false;
        public bool Qualify { get; set; } = false;
        public string CCD2receiveX { get; set; }
        public string CCD2receiveY { get; set; }
        public string CCD2receiveR { get; set; }
        public string CCD2receiveError { get; set; }
        public int cavityNo { get; set; } = 0;
        public double CT { get; set; } = 0;
        public double loadcellforce{ get; set; } = 0;
        public double ldforce { get; set; }

        public bool partAvl = true;
        public double Gapx { get; set; }
        public double Gapy { get; set; }
        public double Angle { get; set; }

        public PartData Clone()
        {
            return new PartData
            {
                ScannerData = this.ScannerData,
                SNno = this.SNno,
                cameraData = this.cameraData,
                OkNok = this.OkNok,
                Qualify = this.Qualify,
                CCD2receiveX = this.CCD2receiveX,
                CCD2receiveY = this.CCD2receiveY,
                CCD2receiveR = this.CCD2receiveR,
                cavityNo = this.cavityNo,
                partAvl = this.partAvl,
                 pastingcmplt = this.pastingcmplt,
                 CarrierBarcode=this.CarrierBarcode,
                 NLTime_stmp=this.NLTime_stmp,
                 MLBTime_stmp=this.MLBTime_stmp,
                 FedTime_stmp=this.FedTime_stmp,
                 RechekTime_stmp=this.RechekTime_stmp,
                 CT=this.CT,
                 loadcellforce=this.loadcellforce,
                 Gapx=this.Gapx, 
                 Gapy=this.Gapy,
                 Angle=this.Angle

            };
        }

        public static PartData[,] DeepCopy(PartData[,] original)
        {
            int rows = original.GetLength(0);
            int cols = original.GetLength(1);
            PartData[,] result = new PartData[rows, cols];
            for (int r = 0; r < rows; r++)
            {
                for (int c = 0; c < cols; c++)
                {
                    if (original[r, c] != null)
                    {
                        result[r, c] = original[r, c].Clone();
                    }
                }
            }
            return result;
        }
    }

    public class Position
    {
        public int row { get; set; }
        public int col { get; set; }
        public bool trigger { get; set; } = false;
        public double PositionX { get; set; }
         



        public double PositionY { get; set; }
        public double PositionZ1 { get; set; }
        public double PositionZ2 { get; set; }
        public double PositionR1 { get; set; }
        public double PositionR2 { get; set; }
        public double CavityX { get; set; }
        public double CavityY { get; set; }
        public string Name { get; set; }

        public double X { get; set; }
        public double XVel { get; set; }
        public double XAcc { get; set; }
        public double XDeAcc { get; set; }

        public double Y { get; set; }
        public double YVel { get; set; }
        public double YAcc { get; set; }
        public double YDeAcc { get; set; }

        public double Z { get; set; }
        public double ZVel { get; set; }
        public double ZAcc { get; set; }
        public double ZDeAcc { get; set; }
        public double RVel { get; set; }
        public double RAcc { get; set; }
        public double RDeAcc { get; set; }
        public double PreXVel { get; set; }
        public double PreXAcc { get; set; }
        public double PreXDeAcc { get; set; }

        public double PreYVel { get; set; }
        public double PreYAcc { get; set; }
        public double PreYDeAcc { get; set; }



    }
}
