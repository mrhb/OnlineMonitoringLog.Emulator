using lib60870;
using lib60870.CS101;
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
    public class IEC104ServerEmulatorBase : IEmulator
    {
        private Timer _timer;
        int count = 0;
        Random rnd = new Random();
        
        public event PropertyChangedEventHandler PropertyChanged;
        #region Parameters
        public event EventHandler<ParamValueChangeEventArgs> ParamValueChanged;
        protected void NotifyParamValueChanged(int ObjectAddress, int val)
        {
            ParamValueChanged?.Invoke(this, new ParamValueChangeEventArgs(ObjectAddress, val));
        }

        int _InputWaterTemp;
        int _OutputWaterTemp;
        int _OilPress;
        int _AdvanceSpark;
        int _ValvePosition;
        int _ValveFlow;
        int _ExhaustTemp;
        int _ElecPower;
        int _ElecEnergy;
        int _WorkTime;
        int _frequency;
        int _PowerFactor;


        public int InputWaterTemp
        {
            get
            {
                return _InputWaterTemp;
            }

            set
            {
                _InputWaterTemp = value;
                NotifyPropertyChanged();
                NotifyParamValueChanged(ObjAddress.InputWaterTemp, value);
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
                NotifyPropertyChanged();
                NotifyParamValueChanged(ObjAddress.OutputWaterTemp, value);
            }
        }

        public int OilPress
        {
            get
            {
                return _OilPress;
            }

            set
            {
                _OilPress = value;
                NotifyPropertyChanged();
                NotifyParamValueChanged(ObjAddress.OilPress, value);
            }
        }

        public int AdvanceSpark
        {
            get
            {
                return _AdvanceSpark;
            }

            set
            {
                _AdvanceSpark = value;
                NotifyPropertyChanged();
                NotifyParamValueChanged(ObjAddress.AdvanceSpark, value);
            }
        }

        public int ValvePosition
        {
            get
            {
                return _ValvePosition;
            }

            set
            {
                _ValvePosition = value;
                NotifyPropertyChanged();
                NotifyParamValueChanged(ObjAddress.ValvePosition, value);
            }
        }

        public int ValveFlow
        {
            get
            {
                return _ValveFlow;
            }

            set
            {
                _ValveFlow = value;
                NotifyPropertyChanged();
                NotifyParamValueChanged(ObjAddress.ValveFlow, value);
            }
        }

        public int ExhaustTemp
        {
            get
            {
                return _ExhaustTemp;
            }

            set
            {
                _ExhaustTemp = value;
                NotifyPropertyChanged();
                NotifyParamValueChanged(ObjAddress.ExhaustTemp, value);
            }
        }

        public int ElecPower
        {
            get
            {
                return _ElecPower;
            }

            set
            {
                _ElecPower = value;
                NotifyPropertyChanged();
                NotifyParamValueChanged(ObjAddress.ElecPower, value);
            }
        }

        public int ElecEnergy
        {
            get
            {
                return _ElecEnergy;
            }

            set
            {
                _ElecEnergy = value;
                NotifyPropertyChanged();
                NotifyParamValueChanged(ObjAddress.ElecEnergy, value);
            }
        }

        public int WorkTime
        {
            get
            {
                return _WorkTime;
            }

            set
            {
                _WorkTime = value;
                NotifyPropertyChanged();
                NotifyParamValueChanged(ObjAddress.WorkTime, value);
            }
        }

        public int frequency
        {
            get
            {
                return _frequency;
            }

            set
            {
                _frequency = value;
                NotifyPropertyChanged();
                NotifyParamValueChanged(ObjAddress.frequency, value);
            }
        }

        public int PowerFactor
        {
            get
            {
                return _PowerFactor;
            }

            set
            {
                _PowerFactor = value;
                NotifyPropertyChanged();
                NotifyParamValueChanged(ObjAddress.PowerFactor, value);
            }
        }

        #endregion
        public IEC104ServerEmulatorBase()
        {
            _timer = new Timer(Timed, null, 0, 500);
        
        }    

        private void Timed(object state)
        {
            InputWaterTemp = rnd.Next(100);
            OutputWaterTemp = rnd.Next(100);
            OilPress = rnd.Next(10000);
            AdvanceSpark = rnd.Next(500);
            ValvePosition = rnd.Next(300);
            ValveFlow = rnd.Next(600);
            ExhaustTemp = rnd.Next(100);
            ElecPower = rnd.Next(1000);
            ElecEnergy = rnd.Next(100);
            WorkTime = rnd.Next(100);
            frequency = rnd.Next(100);
            PowerFactor = rnd.Next(5000);


        }

        protected void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }



        public virtual void Start() { }

        public virtual void Stop() { }

        void IEmulator.Start()
        {
            throw new NotImplementedException();
        }

        void IEmulator.Stop()
        {
            throw new NotImplementedException();
        }
    }
    public class ParamValueChangeEventArgs : EventArgs
    {
        MeasuredValueShortWithCP56Time2a _FloatVariables;
        public ParamValueChangeEventArgs(int ObjectAddress,int val)
        {
            _FloatVariables = new MeasuredValueShortWithCP56Time2a(ObjectAddress, val,
               new QualityDescriptor(), new CP56Time2a(DateTime.Now));
         //   _FloatVariables.Value = val;           
        }
       public MeasuredValueShortWithCP56Time2a FloatVariables { get
            { return _FloatVariables; }  }
    }
    public class ObjAddress
    {
        public const int InputWaterTemp = 1;
        public const int OutputWaterTemp = 2;
        public const int OilPress = 3;
        public const int AdvanceSpark = 4;
        public const int ValvePosition = 5;
        public const int ValveFlow = 6;
        public const int ExhaustTemp = 7;
        public const int ElecPower = 8;
        public const int ElecEnergy = 9;
        public const int WorkTime = 10;
        public const int frequency = 11;
        public const int PowerFactor = 12;
    }
}
