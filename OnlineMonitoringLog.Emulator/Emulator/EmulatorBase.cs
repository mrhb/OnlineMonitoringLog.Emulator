using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Emulator
{
    abstract class EmulatorBase : IEmulator
    {
        private Timer _timer;
        Random rnd = new Random();
        int _InputWaterTemp;
        int _OutputWaterTemp;

        public event PropertyChangedEventHandler ParamValueChanged;

        public int InputWaterTemp
        {
            get
            {
             return _InputWaterTemp;
            }

            set
            {
                _InputWaterTemp = value;
                NotifyParamValueChanged();
            }
        }

        public int OutputWaterTemp
        {
            get
            {
                return _OutputWaterTemp;
            }

            set
            {
                _OutputWaterTemp = value;
                NotifyParamValueChanged();
            }
        }
        public EmulatorBase()
        {
            _timer = new Timer(Timed, null, 0, 1000);
        
        }

        private void Timed(object state)
        {
            InputWaterTemp = rnd.Next();
            OutputWaterTemp = rnd.Next();
        }

       

        protected void NotifyParamValueChanged([CallerMemberName] String propertyName = "")
        {
            ParamValueChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public virtual void Start() { }

        public virtual void Stop() { }

    }
}
