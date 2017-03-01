using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Timers;
using TamagotchiWebService;

namespace TamagotchiService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class TamagotchiService : ITamagotchiService
    {
        IRepository tamagotchiRepo;

        public TamagotchiService()
        {
            tamagotchiRepo = new TamagotchiRepo();
        }

        public List<Tamagotchi> GetAllTamagotchies()
        {
            return tamagotchiRepo.GetAll();
        }

        public Tamagotchi GetTamagotchi(int id)
        {
            return tamagotchiRepo.Get(id);
        }

        public void AddTamagotchi(string name)
        {
            tamagotchiRepo.Add(name);
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }

        public void StartTimer()
        {
            System.Timers.Timer timer = new System.Timers.Timer();
            timer.Elapsed += new System.Timers.ElapsedEventHandler(Time_Elapsed);
            timer.Interval = 10000;
            timer.Enabled = true;
            timer.Start();
        }

        private void Time_Elapsed(object sender, ElapsedEventArgs e)
        {
            tamagotchiRepo.UpdateAll();
        }
    }
}
