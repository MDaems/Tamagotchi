﻿using System;
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
            return context.Tamagotchi.ToList();
        }

        public Tamagotchi Get(int id)
        {
            return context.Tamagotchi.Where(t => t.ID == id).FirstOrDefault();
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

            context.Tamagotchi.Add(tamagotchi);
            context.SaveChanges();
        }

        public void UpdateAll()
        {
            foreach (var tamagotchi in tamagotchies)
            {
                var tamaContext = context.Tamagotchi.Find(tamagotchi.ID);

                DateTime now = DateTime.UtcNow;
                TimeSpan difference = now.Subtract(tamagotchi.LastAccess);
                tamaContext.Age += Convert.ToInt32(difference.TotalSeconds);

                tamagotchi.LastAccess = DateTime.UtcNow;

                Random random = new Random();
                tamagotchi.Hunger += random.Next(15, 35);
                tamagotchi.Sleep += random.Next(15, 35);
                tamagotchi.Boredom += random.Next(15, 35);

                if(tamagotchi.Hunger > 100) { tamagotchi.Hunger = 100; }
                if (tamagotchi.Sleep > 100) { tamagotchi.Sleep = 100; }
                if (tamagotchi.Boredom > 100) { tamagotchi.Boredom = 100; }
            }

            context.SaveChanges();
        }
    }
}