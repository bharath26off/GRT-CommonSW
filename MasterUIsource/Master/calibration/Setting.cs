using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Master.GRT.Function.DryRun
{
    // Simple data holder for settings used by the calibration UI
    public class Setting
    {
        public enum ModeType { Static, Dynamic }

        public ModeType Mode { get; set; } = ModeType.Static;

        // Selected CCDs
        public bool CCD1 { get; set; }
        public bool CCD2 { get; set; }
        public bool CCD3 { get; set; }
        public bool CCD4 { get; set; }

        // Static position
        public double StaticX { get; set; }
        public double StaticY { get; set; }
        public double StaticZ { get; set; }

        // Dynamic positions
        public double Dyn1X { get; set; }
        public double Dyn1Y { get; set; }
        public double Dyn1Z { get; set; }

        public double Dyn2X { get; set; }
        public double Dyn2Y { get; set; }
        public double Dyn2Z { get; set; }

        // Motion
        public int Speed { get; set; } = 100; // mm/s

        // Shots
        public int ShotCount { get; set; } = 1;

        public int RunningCount { get; set; } = 0;

        public List<int> SelectedCCDList()
        {
            var list = new List<int>();
            if (CCD1) list.Add(1);
            if (CCD2) list.Add(2);
            if (CCD3) list.Add(3);
            if (CCD4) list.Add(4);
            return list;
        }

        // UI helper logic - enable/disable fields depending on mode
        public bool StaticFieldsEnabled => Mode == ModeType.Static;
        public bool DynamicFieldsEnabled => Mode == ModeType.Dynamic;


    }
}
