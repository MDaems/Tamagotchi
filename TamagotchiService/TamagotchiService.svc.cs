using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Timers;
using TamagotchiWebService;
using TamagotchiWebService.Models;

namespace TamagotchiService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class TamagotchiService : ITamagotchiService
    {
        IRepository tamagotchiRepo;
        List<IGameRule> gameRules;


        public TamagotchiService()
        {
            tamagotchiRepo = new TamagotchiRepo();
            gameRules = new List<IGameRule>();

            gameRules.Add(new Crazy());
            gameRules.Add(new Munchies());
            gameRules.Add(new Starved());
            gameRules.Add(new Exhausted());
        }

        public void AddTamagotchi(string name)
        {
            tamagotchiRepo.Add(name);
        }
        public List<Tamagotchi> GetAllTamagotchies()
        {
            return tamagotchiRepo.GetAll();
        }
        public Tamagotchi GetTamagotchi(int id)
        {
            Tamagotchi tamagotchi = tamagotchiRepo.Get(id);
            //tamagotchi = ApplyGameRules(tamagotchi);
            tamagotchi.State = new State(tamagotchi);
            //tamagotchiRepo.Update(tamagotchi);

            return tamagotchi;
        }             

        public void StartTimer()
        {
            System.Timers.Timer timer = new System.Timers.Timer();
            timer.Elapsed += new System.Timers.ElapsedEventHandler(Time_Elapsed);
            timer.Interval = 5000;
            timer.Enabled = true;
            timer.Start();


        }
        private void Time_Elapsed(object sender, ElapsedEventArgs e)
        {
            //foreach (var tamagotchi in GetAllTamagotchies())
            //{
            //    Tamagotchi tama = tamagotchi;
            //    tama = ApplyGameRules(tama);
            //    tamagotchiRepo.Update(tama);

            //}
            //tamagotchiRepo.UpdateAll();
        }

        public Tamagotchi ApplyGameRules(Tamagotchi tamagotchi)
        {
            foreach (var rule in gameRules)
            {
                rule.ExecuteGameRule(tamagotchi);
            }
            tamagotchiRepo.Update(tamagotchi);

            return tamagotchi;
        }

        public void Eat(int id)
        {
            Tamagotchi tamagotchi = tamagotchiRepo.Get(id);
            //tamagotchi = ApplyGameRules(tamagotchi);

            State state = new State(tamagotchi);

            tamagotchi.State = new State(tamagotchi);

            if (state.CanPerformAction)
            {
                tamagotchi.Hunger -= 50;
                tamagotchi.BusyTill = DateTime.UtcNow.AddSeconds(5);

                state.BusyMessage = tamagotchi.Name + " is eating till " + tamagotchi.BusyTill.AddHours(2).ToLongTimeString();

            }
            tamagotchiRepo.Update(tamagotchi);
        }
        public void Sleep(int id)
        {
            Tamagotchi tamagotchi = tamagotchiRepo.Get(id);
            //tamagotchi = ApplyGameRules(tamagotchi);

            State state = new State(tamagotchi);

            tamagotchi.State = new State(tamagotchi);

            if (state.CanPerformAction)
            {
                tamagotchi.Sleep -= 25;
                tamagotchi.Health += 10;
                tamagotchi.BusyTill = DateTime.UtcNow.AddSeconds(15);

                state.BusyMessage = tamagotchi.Name + " is sleeping till " + tamagotchi.BusyTill.AddHours(2).ToLongTimeString();
            }
            tamagotchiRepo.Update(tamagotchi);
        } 
        public void Play(int id)
        {
            Tamagotchi tamagotchi = tamagotchiRepo.Get(id);
            //tamagotchi = ApplyGameRules(tamagotchi);

            State state = new State(tamagotchi);

            tamagotchi.State = new State(tamagotchi);

            if (state.CanPerformAction)
            {
                tamagotchi.Boredom -= 35;
                tamagotchi.BusyTill = DateTime.UtcNow.AddSeconds(8);

                state.BusyMessage = tamagotchi.Name + " is playing till " + tamagotchi.BusyTill.AddHours(2).ToLongTimeString();

            }
            tamagotchiRepo.Update(tamagotchi);
        }
        public void Hug(int id)
        {
            Tamagotchi tamagotchi = tamagotchiRepo.Get(id);
            //tamagotchi = ApplyGameRules(tamagotchi);

            State state = new State(tamagotchi);

            tamagotchi.State = new State(tamagotchi);

            if (state.CanPerformAction)
            {
                tamagotchi.Hunger -= 10;
                tamagotchi.Sleep -= 10;
                tamagotchi.Boredom -= 10;
                tamagotchi.Health += 10;
                tamagotchi.BusyTill = DateTime.UtcNow.AddSeconds(3);

                state.BusyMessage = tamagotchi.Name + " is huging till " + tamagotchi.BusyTill.AddHours(2).ToLongTimeString();
            }
            tamagotchiRepo.Update(tamagotchi);
        }

        public void ResetTamagotchies()
        {
            tamagotchiRepo.ResetAll();
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
    }
}
