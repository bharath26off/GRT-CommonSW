using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GRT_BG1.Function.Interface
{
    public interface IWorkingConveyor
    {
        Task WorkingCon_Seq();
        Task CameraScan();
        Task GoForPast();
    }
}
