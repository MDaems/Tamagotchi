using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TamagotchiApp
{
    class TamagotchiVM : INotifyPropertyChanged
    {
        private TamagotchiServiceLocal.Tamagotchi _tamagotchi;
        private TamagotchiServiceLocal.State _state;

        public TamagotchiVM(int ID, TamagotchiServiceLocal.Tamagotchi tamagotchi)
        {
            _tamagotchi = tamagotchi;
        }

        public void Update(TamagotchiServiceLocal.Tamagotchi tamagotchi)
        {
            _tamagotchi = tamagotchi;
            _state = tamagotchi.State;
        }

        public int ID
        {
            get
            {
                return _tamagotchi.ID;
            }
        }
        public string Name
        {
            get
            {
                return _tamagotchi.Name;
            }
        }
        public int Age
        {
            get
            {
                return _tamagotchi.Age;
            }
        }
        public int Hunger
        {
            get
            {
                return _tamagotchi.Hunger;
            }
            set
            {
                _tamagotchi.Hunger = value;
            }
        }
        public int Sleep
        {
            get
            {
                return _tamagotchi.Sleep;
            }
            set
            {
                _tamagotchi.Sleep = value;
            }
        }
        public int Boredom
        {
            get
            {
                return _tamagotchi.Boredom;
            }
            set
            {
                _tamagotchi.Boredom = value;
            }
        }
        public int Health
        {
            get
            {
                return _tamagotchi.Health;
            }
            set
            {
                _tamagotchi.Health = value;
            }
        }

        string _displayImage;
        public string DisplayedImage
        {
            get
            {
                if (_state != null)
                {
                    return "/Images/" + _state.HighestProperty + ".png";
                }
                return "";
            }
            set
            {
                _displayImage = "/Images/" + value + ".png";
                RaisePropertyChanged("DisplayedImage");
            }
        }

        string _status;
        public string Status
        {
            get
            {
                if (_state != null)
                {
                    return _state.HighestPropertyMessage;
                }
                return "";
            }
            set
            {
                _status = value;
                RaisePropertyChanged("Status");
            }
        }

        string _actionStatus;
        public string ActionStatus
        {
            get
            {
                if (_state != null)
                {
                    return _state.BusyMessage;
                }
                return "";
            }
            set
            {
                _actionStatus = value;
                RaisePropertyChanged("ActionStatus");
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChanged(string propertyName)
        {
            // take a copy to prevent thread issues
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
