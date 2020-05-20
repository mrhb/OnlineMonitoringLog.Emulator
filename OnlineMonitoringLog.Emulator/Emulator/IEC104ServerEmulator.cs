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
    class IEC104ServerEmulator:IEC104ServerEmulatorBase
    {
        private Timer Sendtimer;
        Server server = new Server();
        ASDU floatdataAsdu;
        public  IEC104ServerEmulator()
        {
            /* Initialize data objects */
            server.DebugOutput = true;
            server.MaxQueueSize = 100;

            server.Start();
            floatdataAsdu =  new ASDU(server.GetApplicationLayerParameters(), CauseOfTransmission.INTERROGATED_BY_STATION, false, false, 1, 1, false);
           

            ParamValueChanged += IEC104ServerEmulator_ParamValueChanged1;
            Sendtimer = new Timer(sendTick, null, 0, 200);
        }

        private void sendTick(object state)
        {
            if (floatdataAsdu.NumberOfElements>0)
            server.EnqueueASDU(floatdataAsdu);
            floatdataAsdu = new ASDU(server.GetApplicationLayerParameters(), CauseOfTransmission.INTERROGATED_BY_STATION, false, false, 1, 1, false);
        }

        private void IEC104ServerEmulator_ParamValueChanged1(object sender, ParamValueChangeEventArgs e)
        {          
            floatdataAsdu.AddInformationObject(e.FloatVariables);
    
        }
    }
}
