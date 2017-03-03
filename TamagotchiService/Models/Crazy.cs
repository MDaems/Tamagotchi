using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TamagotchiWebService.Models
{
    public class Crazy : IGameRule
    {
        public Tamagotchi ExecuteGameRule(Tamagotchi tamagotchi)
        {
            if (tamagotchi.Sleep > 70 && tamagotchi.Hunger > 10)
            {
                tamagotchi.Health -= 20;
            }
            return tamagotchi;
        }
    }
}