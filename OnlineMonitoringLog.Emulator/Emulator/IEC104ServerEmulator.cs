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

      

       
                    ASDU newAsdu = null;

     

                  /* send step position objects */
                    

                    for (int i = 0; i < 2; i++)
                    {

                        stepPositionObjects[i].Value = (stepPositionObjects[i].Value + 1) % 63;

                        if (newAsdu == null)
                            newAsdu = new ASDU(server.GetApplicationLayerParameters(), CauseOfTransmission.PERIODIC, false, false, 1, 1, false);

                        if (newAsdu.AddInformationObject(stepPositionObjects[i]) == false)
                        {
                            server.EnqueueASDU(newAsdu);
                            newAsdu = null;
                            i--;
                        }
                    }

                    if (newAsdu != null)
                        server.EnqueueASDU(newAsdu);




            ParamValueChanged += IEC104ServerEmulator_ParamValueChanged;

        }

        private void IEC104ServerEmulator_ParamValueChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            switch (e.PropertyName)
            {
                case "InputWaterTemp":
                    break;

                case "OutputWaterTemp":
                    break;

                default:
                    break;
            }

          


            ASDU newAsdu = null;



            /* send step position objects */


            for (int i = 0; i < 2; i++)
            {

                stepPositionObjects[i].Value = (stepPositionObjects[i].Value + 1) % 63;

                if (newAsdu == null)
                    newAsdu = new ASDU(server.GetApplicationLayerParameters(), CauseOfTransmission.PERIODIC, false, false, 1, 1, false);

                if (newAsdu.AddInformationObject(stepPositionObjects[i]) == false)
                {
                    server.EnqueueASDU(newAsdu);
                    newAsdu = null;
                    i--;
                }
            }

            if (newAsdu != null)
                server.EnqueueASDU(newAsdu);
        }
    }
}
