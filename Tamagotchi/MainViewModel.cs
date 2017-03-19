using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Threading;

namespace TamagotchiApp
{
    class MainViewModel : INotifyPropertyChanged
    {
        TamagotchiServiceLocal.TamagotchiServiceClient service;

        private ObservableCollection<TamagotchiVM> _tamagotchies;
        public ObservableCollection<TamagotchiVM> Tamagotchies
        {
            get { return _tamagotchies; }
            set
            {
                _tamagotchies = value;
                RaisePropertyChanged("Tamagotchies");
            }
        }

        private TamagotchiVM _selectedTamagotchi;
        public TamagotchiVM SelectedTamagotchi
        {
            get { return _selectedTamagotchi; }
            set
            {
                _selectedTamagotchi = value;
                RaisePropertyChanged("SelectedTamagotchi");
            }
        }

        private DispatcherTimer UpdateUITimer;
        private DispatcherTimer UpdateTimer;

        public ICommand EatCommand { get; set;}
        public ICommand SleepCommand { get; set; }
        public ICommand PlayCommand { get; set; }
        public ICommand HugCommand { get; set; }

        public MainViewModel()
        {
            Tamagotchies = new ObservableCollection<TamagotchiVM>();

            //creating the object of WCF service client    
            service = new TamagotchiServiceLocal.TamagotchiServiceClient();
                //service.Abort();
           
            //service.ResetTamagotchies();

            foreach (var item in service.GetAllTamagotchies())
            {
                Tamagotchies.Add(new TamagotchiVM(0,item));

                SelectedTamagotchi = Tamagotchies.FirstOrDefault();
            }

            UpdateUITimer = new DispatcherTimer();
            UpdateUITimer.Start();
            UpdateUITimer.Interval = TimeSpan.FromSeconds(2.0);
            UpdateUITimer.Tick += UpdateUI_timer;

            UpdateTimer = new DispatcherTimer();
            UpdateTimer.Start();
            UpdateTimer.Interval = TimeSpan.FromSeconds(5.0);
            UpdateTimer.Tick += Update_timer;

            //service.StartTimer();

            EatCommand = new RelayCommand(Eat);
            SleepCommand = new RelayCommand(Sleep);
            PlayCommand = new RelayCommand(Play);
            HugCommand = new RelayCommand(Hug);
        }

        private void Eat()
        {
            service.Eat(SelectedTamagotchi.ID);
            UpdateTamagotchi();
        }
        private void Sleep()
        {
            service.Sleep(SelectedTamagotchi.ID);
            UpdateTamagotchi();
        }
        private void Play()
        {
            service.Play(SelectedTamagotchi.ID);
            UpdateTamagotchi();

            service.Close();
        }
        private void Hug()
        {
            service.Hug(SelectedTamagotchi.ID);
            UpdateTamagotchi();
        }

        private void UpdateUI_timer(object sender, EventArgs e)
        {
            UpdateTamagotchi();
        }
        private void Update_timer(object sender, EventArgs e)
        {
            foreach (var item in Tamagotchies)
            {
                service.ApplyGameRules(service.GetTamagotchi(item.ID));
            }
            
        }
        private void UpdateTamagotchi()
        {
            SelectedTamagotchi.Update(service.GetTamagotchi(SelectedTamagotchi.ID));
            RaisePropertyChanged("SelectedTamagotchi");
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
