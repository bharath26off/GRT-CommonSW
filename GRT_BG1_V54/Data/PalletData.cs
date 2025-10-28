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

    public class PartData
    {
        public string ScannerData { get; set; }
        public string SNno{ get; set; }
        public string cameraData { get; set; }
        public string OkNok {  get; set; }
        public bool pastingcmplt { get; set; } = false;
        public bool Qualify { get; set; }=false;
        public  int cavityNo { get; set; } = 0;
    }

    public class Position
    {
        public double PositionX { get; set; }
        public double PositionY { get; set; }
        public double PositionZ1 { get; set; }
        public double PositionZ2 { get; set; }
        public double PositionR1 { get; set; }
        public double PositionR2
        {
            get; set;
        }
      
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
        



    }
}
