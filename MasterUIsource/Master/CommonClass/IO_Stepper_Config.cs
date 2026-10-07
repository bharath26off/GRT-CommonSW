using DIO;
using IO_Stepper;
using IO_Stepper;
using Master;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Linq;
using VacuumHelperLib;

namespace IO_Stepper
{
    public static class IO_Stepper_Config
    {

        public enum EConvStepper
        {

            LoadingConveyorA,
            LoadingConveyorB,
            WorkingConveyor1A,
            WorkingConveyor1B,
            WorkingConveyor2A,
            WorkingConveyor2B
        }

        public static Dictionary<EConvStepper, IO_Stepper> ConvStepperMotorObj = new Dictionary<EConvStepper, IO_Stepper>();


        static IO_Stepper_Config()
        {
            LoadConvSteppersFromXml();
        }

        public static void LoadConvSteppersFromXml()
        {
            var doc = XDocument.Load(Path.Combine(Application.StartupPath, "Data", "ConveyorStepper.xml"));
            var convStepXml = doc.Descendants("Stepper").ToList();
            if (convStepXml.Count != Enum.GetNames(typeof(EConvStepper)).Length)
            {
                MessageBox.Show("Total Number of Conveyor Stepper in XML does not match EConvStepper enum.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            foreach (var convEnum in Enum.GetValues(typeof(EConvStepper)).Cast<EConvStepper>())
            {
                string convStepName = convEnum.ToString();

                // Find the matching XML element by MotorName
                var elem = convStepXml.FirstOrDefault(x =>
                    string.Equals(x.Attribute("MotorName")?.Value.Trim(), convStepName, StringComparison.OrdinalIgnoreCase));

                if (elem == null)
                {
                    // Optional: handle missing config
                    Console.WriteLine($"Config for {convStepName} not found in XML.");
                    continue;
                }

                try
                {
                    // --- IO_Stepper Properties ---

                    var props = new IO_Stepper_Properties
                    {
                        MotorName = elem.Attribute("MotorName").Value,
                        ForwardCommand = (int)Enum.Parse(typeof(DIDO.EOutput), elem.Attribute("ForwardCommand").Value),
                        ReverseCommand = (int)Enum.Parse(typeof(DIDO.EOutput), elem.Attribute("ReverseCommand").Value),
                        AlarmResetCommand = (int)Enum.Parse(typeof(DIDO.EOutput), elem.Attribute("AlarmResetCommand").Value),
                        AlarmSignal = (int)Enum.Parse(typeof(DIDO.EInput), elem.Attribute("AlarmSignal").Value)
                    };
                    // --- IO_Stepper Error Codes ---
                    var errorCodes = new IO_Stepper_ErrorCodes
                    {
                        ForwardFailedEcode = (int)DIDO.ECode.IO_Stepper_ForwardFail,
                        ReverseFailedEcode = (int)DIDO.ECode.IO_Stepper_ReverseFail,
                        StopFailedEcode = (int)DIDO.ECode.IO_Stepper_StopFail,
                        AlarmResetFailedEcode = (int)DIDO.ECode.IO_Stepper_AlarmResetFail
                    };
                    var IO_step = new IO_Stepper(props, errorCodes);
                    // Register delegates immediately
                    IO_step.RegisterWriteOpsCallback(GlobalVariable.DIDO.WriteOPS); //Write_DO wrapper;
                    IO_step.RegisterReadDICallback(GlobalVariable.DIDO.ReadDI); //DI_RefreshValue wrapper
                    ConvStepperMotorObj[convEnum] = IO_step;

                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error parsing config for {convStepName}: {ex.Message}");
                    MessageBox.Show($"Error parsing config for {convStepName}: {ex.Message}");
                }
            }


        }

    }
}

