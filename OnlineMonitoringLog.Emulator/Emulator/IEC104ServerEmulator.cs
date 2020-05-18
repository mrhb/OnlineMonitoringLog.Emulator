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
        static StepPositionWithCP56Time2a[] stepPositionObjects = new StepPositionWithCP56Time2a[2] ;

        public  IEC104ServerEmulator()
        {
          
            /* Initialize data objects */
          
            for (int i = 0; i < 2; i++)
                stepPositionObjects[i] = new StepPositionWithCP56Time2a(10000 + i, 0, false,
                    new QualityDescriptor(), new CP56Time2a());

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
            ASDU newAsdu = null;

            /* send step position objects */
            stepPositionObjects[i].Value = val;
            stepPositionObjects[i].Timestamp = new CP56Time2a(DateTime.Now);

              
            newAsdu = new ASDU(server.GetApplicationLayerParameters(), CauseOfTransmission.PERIODIC, false, false, 1, 1, false);

            newAsdu.AddInformationObject(stepPositionObjects[i]);
            server.EnqueueASDU(newAsdu);
               
          

        }
    }
}
