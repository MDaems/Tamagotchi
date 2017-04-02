using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TamagotchiWebService;

namespace TamagotchiService
{
    public class TamagotchiRepo : IRepository
    {
        List<Tamagotchi> tamagotchies;
        TamagotchiWebService.testDBEntities context;

        public TamagotchiRepo()
        {
            context = new TamagotchiWebService.testDBEntities();
            tamagotchies = new List<Tamagotchi>();
            tamagotchies = context.Tamagotchi.ToList();
        }

        public List<Tamagotchi> GetAll()
        {
            tamagotchies = context.Tamagotchi.ToList();
            return tamagotchies;
        }

        public Tamagotchi Get(int id)
        {
            return context.Tamagotchi.Find(id);
        }

        public void Add(string name)
        {
            Tamagotchi tamagotchi = new Tamagotchi();
            tamagotchi.Name = name;
            tamagotchi.Age = 0;
            tamagotchi.Hunger = 0;
            tamagotchi.Sleep = 0;
            tamagotchi.Boredom = 0;
            tamagotchi.Health = 100;
            tamagotchi.IsAlive = true;

            tamagotchi.BusyTill = DateTime.Now;
            tamagotchi.LastAccess = DateTime.Now;

            context.Tamagotchi.Add(tamagotchi);
            context.SaveChanges();

            tamagotchies.Add(tamagotchi);
        }

        public void UpdateAll()
        {
            //foreach (var tamagotchi in tamagotchies)
            //{
            //    var tamaContext = context.Tamagotchi.Find(tamagotchi.ID);

            //    DateTime now = DateTime.Now;
            //    TimeSpan difference = now.Subtract(tamagotchi.LastAccess);
            //    tamaContext.Age += Convert.ToInt32(difference.TotalSeconds);

            //    tamagotchi.LastAccess = DateTime.Now;

            //    Random random = new Random();
            //    tamagotchi.Hunger += random.Next(5, 10);
            //    tamagotchi.Sleep += random.Next(5, 10);
            //    tamagotchi.Boredom += random.Next(5, 10);

            //    if (tamagotchi.Hunger > 100) { tamagotchi.Hunger = 100; }
            //    if (tamagotchi.Sleep > 100) { tamagotchi.Sleep = 100; }
            //    if (tamagotchi.Boredom > 100) { tamagotchi.Boredom = 100; }        
            //}
            //context.SaveChanges();
        }

        public void ResetAll()
        {
            foreach (var tamagotchi in tamagotchies)
            {
                var tamaContext = context.Tamagotchi.Find(tamagotchi.ID);

                tamaContext.Age = 0;
                tamaContext.LastAccess = DateTime.Now;
                tamaContext.Hunger = 0;
                tamaContext.Sleep = 0;
                tamaContext.Boredom = 0;
                tamaContext.Health = 100;

                context.SaveChanges();
            }
        }

        public void Update(Tamagotchi tamagotchi)
        {
            var tamaContext = context.Tamagotchi.Find(tamagotchi.ID);

            DateTime now = DateTime.Now;
            TimeSpan difference = now.Subtract(tamaContext.LastAccess);
            tamaContext.Age += Convert.ToInt32(difference.TotalSeconds);

            tamaContext.LastAccess = DateTime.Now;

            Random random = new Random();
            tamaContext.Hunger += random.Next(5, 10);
            tamaContext.Sleep += random.Next(5, 10);
            tamaContext.Boredom += random.Next(5, 10);

            if (tamaContext.Hunger > 100) { tamaContext.Hunger = 100; }
            if (tamaContext.Sleep > 100) { tamaContext.Sleep = 100; }
            if (tamaContext.Boredom > 100) { tamaContext.Boredom = 100; }
            if (tamaContext.Health > 100) { tamaContext.Health = 100; }

            if (tamaContext.Hunger < 0) { tamaContext.Hunger = 0; }
            if (tamaContext.Sleep < 0) { tamaContext.Sleep = 0; }
            if (tamaContext.Boredom < 0) { tamaContext.Boredom = 0; }
            if (tamaContext.Health < 0) { tamaContext.Health = 0; }

            context.SaveChanges();
        }
    }
}