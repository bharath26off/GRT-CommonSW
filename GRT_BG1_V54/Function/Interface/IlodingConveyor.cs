using GRT_BG1.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GRT_BG1.Function
{
     public interface IlodingConveyor
    {
        Task LoadingConveyor_Seq(CancellationToken token, PalletData data);
        Task GantryMovement(int row, int col);
       // Task LoadPosition();

    }
}
