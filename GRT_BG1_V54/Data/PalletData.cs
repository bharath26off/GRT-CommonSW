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
        public double PositionX { get; set; }
        public double PositionY { get; set; }
        public double PositionR { get; set; }
        public bool pastingcmplt { get; set; } = false;
        public bool Qualify { get; set; }=false;
        public  int cavityNo { get; set; } = 0;
    }
    



}
