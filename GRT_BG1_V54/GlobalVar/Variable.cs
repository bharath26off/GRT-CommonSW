using GRT_BG1.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GRT_BG1.GlobalVar
{
     public class Variable
    {
       
       public static Queue<PalletData> PalletQueue12 = new Queue<PalletData>();
        public static Queue<PalletData> PalletQueue23 = new Queue<PalletData>();
        public static string csvPath = Environment.CurrentDirectory + @"\Data\MLBPosition.xlsx";
        public static position wk1_FeederPos=new position();
        public static position wk1_CCD2Pos = new position();
        public static position wk1_RejBin = new position();
        public static CCD2Data[] cCD2Data = new CCD2Data[2];
        public static position scan_home = new position();
        public static position wk1_home = new position();
        public static position wk2_home = new position();
    }
    public class position
     {
        public double x {  get; set; }
        public double y { get; set; }
        public double z { get; set; }
        public double R1 { get; set; }
        public double R2 { get; set; }
        public double XVel {  get; set; }
        public double XAcc {  get; set; }
        public double XDeAcc {  get; set; }

        public double ZVel {  get; set; }
        public double ZAcc {  get; set; }
        public double ZDeAcc {  get; set; }

        public double YVel { get; set; }
        public double YAcc { get; set; }
        public double YDeAcc { get; set; }

        public double RVel { get; set; }
        public double RAcc { get; set; }
        public double RDeAcc { get; set; }
    }
}
