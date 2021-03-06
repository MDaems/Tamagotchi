﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TamagotchiWebService;

namespace TamagotchiService
{
    public interface IRepository
    {
        List<Tamagotchi> GetAll();
        Tamagotchi Get(int id);
        void Add(string name);
        void Update(Tamagotchi tamagotchi);
    }
}