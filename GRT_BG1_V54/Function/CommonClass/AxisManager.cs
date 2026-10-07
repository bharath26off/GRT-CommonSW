//using CardDLL;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using static DIO.DIDO;

//namespace Master.CommonClass
//{
//    public class AxisManager
//    {
//        private readonly Dictionary<EAxis, IAxis> _axes;

//        public AxisManager(Dictionary<EAxis, IAxis> axes)
//        {
//            _axes = axes;
//        }

//        public bool MoveTo(EAxis axis, double position, int timeout = 5000)
//        {
//            var cfg = GlobalVariable.g_lstAxisConfig[(int)axis];
//            return _axes[axis].Move_Abs(position, cfg.AutoSpeed, cfg.Acc, cfg.DeAcc, timeout);
//        }
//    }

//}
