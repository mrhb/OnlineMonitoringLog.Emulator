using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emulator
{
    public interface IEmulator
    {
        int InputWaterTemp { get; set; }
        int OutputWaterTemp { get; set; }
        int OilPress { get; set; }
        int AdvanceSpark { get; set; }
        int ValvePosition { get; set; }
        int ValveFlow { get; set; }
        int ExhaustTemp { get; set; }
        int ElecPower { get; set; }
        int ElecEnergy { get; set; }
        int WorkTime { get; set; }
        int frequency { get; set; }
        int PowerFactor { get; set; }

        void Start();
        void Stop();
        event PropertyChangedEventHandler PropertyChanged;

    }
  
}
