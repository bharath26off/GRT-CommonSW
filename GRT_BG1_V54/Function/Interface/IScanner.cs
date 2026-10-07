using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GRT_BG1.Function.Interface
{
    public interface IScanner
    {
        Task<string> Trig_Scanner();
    }
}
