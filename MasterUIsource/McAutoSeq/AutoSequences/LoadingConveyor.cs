using DIO;
using DynamicCylinders;
using ExceptionLib;
using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;


namespace Master.AutoSequences
{
    public class LoadingConveyor
    {

        // SEGMENT RELATED VARIABLES
        public static string StationName = "";
        public static string LoadingScannerReceiveString = "";


        public static int iLodingConStep = 10;
        public static Stopwatch Cycle_Time = new Stopwatch();

     
    }
}
