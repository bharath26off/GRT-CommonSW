using GRT_BG1.Data;
using GRT_BG1.Function.Calibration;
using GRT_BG1.Function.DryRun;
using GRT_BG1_V54.Function.Interface;
using Master;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GRT_BG1_V54.Function.CommonClass
{
    

    public class ConveyorSystem
    {
        PalletData palletData = new PalletData();
        WorkingConveyor1 wk1;
        private readonly BlockingCollection<PalletData> _pool = new BlockingCollection<PalletData>();

        public ConveyorSystem(int dataCount)
        {
            // Initialize fixed data objects
            for (int i = 1; i <= dataCount; i++)
            {
                _pool.Add( palletData);
            }
          //   wk1 = new WorkingConveyor1(GlobalVariable.WK1Positions);

        }
        public async Task<PalletData> createpart()
        {
            await LoadPosition();
            return palletData;

        }
        public async Task LoadPosition()
        {
            await GantrySystem.TraversArray(CreatePart, palletData.PalletArr.GetLength(0), palletData.PalletArr.GetLength(1));
        }

        //create each MLB data object
        private async Task CreatePart(int row, int col)
        {
            palletData.PalletArr[row, col] = new PartData
            {
                //PositionX = GlobalVariable.pos[row, col].x, //read position x
                // PositionY = GlobalVariable.pos[row, col].y////read position y
            };

        }
        
        

        public async Task RunAsync()
        {
            // Continuous processing loop
            while (true)
            {
                //if (!_pool.TryTake(out var data, 1000))
                //    break; // exit if no data left
                PalletData data1 = new PalletData();
                LoadingConveyor ld=new LoadingConveyor(GlobalVariable.scannerCnvPositions);
                await ld.Run(data1);

                 WorkingConveyor1 wk1 = new WorkingConveyor1(GlobalVariable.WK1Positions);
                 await wk1.Run(data1);

                WorkingConveyor2 wk2 = new WorkingConveyor2(GlobalVariable.Wk2Positions);
                await wk2.Run(data1);
                
                //data.Reset();
                //_pool.Add(data);

               // Console.WriteLine($"{data} returned to pool\n");
            }
        }

    }
   
}

