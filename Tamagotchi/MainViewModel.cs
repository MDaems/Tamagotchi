using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        private DispatcherTimer timer;

        public MainViewModel()
        {
            Tamagotchies = new ObservableCollection<TamagotchiVM>();

            //creating the object of WCF service client    
            service = new TamagotchiServiceLocal.TamagotchiServiceClient();

            foreach (var item in service.GetAllTamagotchies())
            {
                Tamagotchies.Add(new TamagotchiVM(0,item));

                SelectedTamagotchi = Tamagotchies.FirstOrDefault();
            }

            timer = new DispatcherTimer();
            timer.Start();
            timer.Interval = TimeSpan.FromSeconds(1.0);
            timer.Tick += timer_Tick;

            service.StartTimer();

        }

        private void timer_Tick(object sender, EventArgs e)
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
