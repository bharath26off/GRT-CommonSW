
using ExceptionLib;
using GRT_BG1.Data;
using GRT_BG1.Function.Calibration;
using GRT_BG1.Function.DryRun;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Master.GRT.Function.DryRun
{
    internal class StaticDynamic
    {
        public static int step = 13;
        public static bool firsttimePick = false;
        public static int i_rejection = 10;
        public static int currentState = 10;
        public static bool running = false;
        public static bool WorkingCon_Seq_completed = true;
        public static bool camerascanRuning = false;
        public static bool pastingRunning = false;
        public static event Func<int, int, bool, bool> updatecavity;
        public static event Action clearwk1cavity;
        bool dryrun = false;
        static bool production = false;
        static VisionSystem camera = new VisionSystem();
        string[] ccd2nozzle1;
        string[] ccd2nozle2;
        static PartData[,] Data;
        static string[] splitdataccd3;
        bool firsttimedataupdae = false;

        public static Stopwatch Cycle_Time = new Stopwatch();
        public static int b_gStaticCal_step = 750;

        private bool dontRunFirst = false;

        PalletData pallet;
        // int okParts = 0;
        // int nokParts = 0;
        public int nozzleno = 0;
        //  VisionSystem camera = new VisionSystem();
        WorkingConveyor2 wk2;
        int PreRow = 0; int PreCol = 0;
        static Position[,] pos = null;
        public static Queue<Position> queueZ1 = new Queue<Position>();
        public static Queue<Position> queueZ2 = new Queue<Position>();
        string dtm = DateTime.Now.ToString("HHmmss");
        

        //public WorkingConveyor1(Position[,] position)
        //{
        //    wk2 = new WorkingConveyor2(GlobalVariable.Wk2Positions);
        //    pos = position;
        //}

         



        public static async Task Staticdynamicsequence()
        {
            //b_gStaticCal_step = 750;
            //GlobalVariable.StaticMode_Cal = true;
            while ((GlobalVariable.StaticMode_Cal) || (GlobalVariable.DynamicMode_Cal))
            {
                switch(b_gStaticCal_step)
                {
                    #region Select CCD Calibration Mode
                    case 50:
                        {
                            #region Running Log
                            await Logger.WriteLogasTask(Logger.LogType.Running, "StaticDynamicSeq", "Case 50", "Z axis move to Negative limit", "Action-Move Negaive Limit");
                            #endregion
                            if ((GlobalVariable.StaticMode_Cal) || (GlobalVariable.DynamicMode_Cal))
                            {
                                await Task.Delay(500);
                                #region NextCase
                                b_gStaticCal_step = 100;
                                #endregion
                            }

                            break;
                        }
                        #endregion
                }
            }
        }

    }
}
