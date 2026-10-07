using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GRT_BG1.Data
{
    public class CCD2Data
    {
        public string OkNok { get; set; }
        public double position { get; set; }
        public bool pick {  get; set; }
        public bool place { get; set; } = false;
    }
}
