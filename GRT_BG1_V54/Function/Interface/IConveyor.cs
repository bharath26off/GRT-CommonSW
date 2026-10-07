using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GRT_BG1_V54.Function.Interface
{
    public interface IConveyor
    {
        Task<bool> EntryScanCnv();
        Task<bool> EntryWk1Cnv();
        Task<bool> EntryWk2Cnv();
        Task<bool> DetectCarrierScanCnv();
        Task<bool> DetectCarrierWk1Cnv();
        Task<bool> DetectCarrierWk2Cnv();
        void MovePlate(bool?[] motorStates);
    }
}
