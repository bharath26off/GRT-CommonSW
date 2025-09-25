using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;
using AutoIOTest;
using Program;

namespace AutoIOTest
{
    public class Axis
    {
        /// <summary>
        /// Gets the name of the axis or motor.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Gets the type of motor or connection (e.g., "Stepper/Servo").
        /// </summary>
        public string Type { get; }

        /// <summary>
        /// Gets the index of the axis or motor in the list.
        /// </summary>
        public int Index { get; }

        /// <summary>
        /// Delegate used to log messages to the UI or external logger.
        /// </summary>
        private Action<string> Log;      

        /// <summary>
        /// Initializes a new instance of the <see cref="Axis"/> class with the specified parameters.
        /// </summary>
        /// <param name="name">The name of the axis.</param>
        /// <param name="type">The type of motion module (e.g., "Stepper/Servo").</param>
        /// <param name="logAction">The delegate used for logging status messages.</param>
        /// <param name="index">The index of the axis to identify its position or channel.</param>       
        public Axis(string name, string type, Action<string> logAction, int index)
        {
            Name = name;
            Type = type;
            Log = logAction;
            Index = index;            
        }

        /// <summary>
        /// Asynchronously starts the axis by enabling the servo motor.
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous operation. The task result contains <c>true</c> if the servo was successfully started; otherwise, <c>false</c>.
        /// </returns>
        public async Task<bool> StartAsync()
        {
            try
            {
                Log?.Invoke($"{Name} - Starting...");
                return await Task.Run(() =>
                {
                    try
                    {
                        Console.WriteLine("Index :" + Index);
                        //MessageBox.Show("Index :" + Index);
                        // bool result = motorList[Index].ServoOn(true);

                        bool result = AutoIOTesting.TESTAxis.ServoOn(true);
                        if (result)
                        {
                            Log?.Invoke($"{Name} - Start OK ✅");
                            return true;
                        }
                        else
                        {
                            //Log?.Invoke($"{Name} - Start Failed ❌");
                            return false;
                        }
                    }
                    catch
                    {
                        //Log?.Invoke($"{Name} - Start Failed ❌");
                        return false;
                    }
                });
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }
        }

        /// <summary>
        /// Asynchronously jogs the axis by moving it with predefined parameters.
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous operation. The task result contains <c>true</c> if the jog operation was successful; otherwise, <c>false</c>.
        /// </returns>
        public async Task<bool> JogAsync()
        {
            Log?.Invoke($"{Name} - Jogging...");
            return await Task.Run(() =>
            {
                try
                {
                    // bool result = motorList[Index].Jog(1); //motorList[Index].Jog(1, 3000, 1000, 1000);
                    //bool result = AutoCalibration.TESTAxis.Jog(1);
                    bool result = AutoIOTesting.TESTAxis.Move_Abs(1500,7000,1000,1000,5000);
                    if (result)
                    {
                        Log?.Invoke($"{Name} - Jog OK ✅");
                        return true;
                    }
                    else
                    {
                        //Log?.Invoke($"{Name} - Jog Failed ❌");
                        return false;
                    }
                }
                catch
                {
                    //Log?.Invoke($"{Name} - Jog Failed ❌");
                    return false;
                }
            });
        }

        /// <summary>
        /// Asynchronously stops the axis and turns off the servo if the stop is successful.
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous operation. The task result is <c>true</c> if the stop and servo off operations were successful; otherwise, <c>false</c>.
        /// </returns>
        public async Task<bool> StopAsync()
        {
            Log?.Invoke($"{Name} - Stopping...");
            return await Task.Run(() =>
            {
                try
                {
                    // bool result = motorList[Index].Stop();                    
                    bool result = AutoIOTesting.TESTAxis.Stop();
                    if (result)
                    {
                        //update the Button
                        //bool d = motorList[Index].ServoOFF();
                        bool d = AutoIOTesting.TESTAxis.ServoOFF();
                        if (d)
                        {
                            //update the Button
                            //if required do homming
                            //or do enable servo
                            Log?.Invoke($"{Name} - Stop OK ✅");
                            return true;
                        }
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                catch
                {
                    return false;

                }
            });
        }

        /// <summary>
        /// Executes the full auto calibration sequence for the axis asynchronously.
        /// The sequence includes: Start, Jog, and Stop operations.
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous operation. 
        /// The task result is <c>true</c> if all operations (Start, Jog, Stop) succeed; otherwise, <c>false</c>.
        /// </returns>
        public async Task<bool> RunFullSequenceAsync()
        {
            bool started = await StartAsync();
            if (!started)
            {
                Log?.Invoke($"{Name} - Start failed ❌. Exiting sequence.");
                return false;
            }

            Log?.Invoke($"{Name} - Waiting before jog...");
            await Task.Delay(1000);

            bool jogged = await JogAsync();
            if (!jogged)
            {
                Log?.Invoke($"{Name} - Jog failed ❌. Exiting sequence.");
                return false;
            }

            Log?.Invoke($"{Name} - Waiting before stop...");
            await Task.Delay(10000);

            bool stopped = await StopAsync();
            if (!stopped)
            {
                Log?.Invoke($"{Name} - Stop failed ❌. Exiting sequence.");
                return false;
            }

            Log?.Invoke($"{Name} - Waiting before finalizing...");
            await Task.Delay(1000);

            Log?.Invoke($"{Name} - Sequence Complete ✅");
            return true;
        }
    }
}
