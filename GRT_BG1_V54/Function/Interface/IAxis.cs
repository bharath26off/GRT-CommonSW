using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Master.Interface
{
    public interface IAxis
    {
        bool Move_Abs(double position, double speed, double acc, double deAcc, int timeout);
    }

}
