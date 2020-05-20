using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using lib60870;
using lib60870.CS101;
using lib60870.CS104;
using System.Threading;

namespace Emulator
{
    class IEC104ServerEmulator:EmulatorBase
    {
        Server server = new Server();
        public  IEC104ServerEmulator()
        {
            /* Initialize data objects */

            server.DebugOutput = true;
            server.MaxQueueSize = 100;

            server.Start();
            ParamValueChanged += IEC104ServerEmulator_ParamValueChanged;

        }

        private void IEC104ServerEmulator_ParamValueChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            int val=new int();
            int i= 0;
            switch (e.PropertyName)
            {
                case "InputWaterTemp":
                    val = InputWaterTemp;
                    i = 0;
                    break;

                case "OutputWaterTemp":
                    val = OutputWaterTemp;
                    i = 1;
                    break;

                default:
                    break;
            }

            ASDU floatdataAsdu = null;
            var   FloatVariables = new MeasuredValueShortWithCP56Time2a(i, 0,
            new QualityDescriptor(), new CP56Time2a(DateTime.Now));
            FloatVariables.Value = val;
            floatdataAsdu = new ASDU(server.GetApplicationLayerParameters(), CauseOfTransmission.PERIODIC, false, false, 1, 1, false);
            floatdataAsdu.AddInformationObject(FloatVariables);
            server.EnqueueASDU(floatdataAsdu);
        }
    }
}
