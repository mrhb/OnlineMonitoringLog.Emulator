using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emulator
{
    interface IEmulator
    {
         int InputWaterTemp { get; set; }
        int OutputWaterTemp { get; set; }
       void Start();
        void Stop();
        event PropertyChangedEventHandler ParamValueChanged;

    }
  
}
