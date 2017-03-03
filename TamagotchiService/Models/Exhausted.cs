using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TamagotchiWebService.Models
{
    public class Exhausted : IGameRule
    {
        public Tamagotchi ExecuteGameRule(Tamagotchi tamagotchi)
        {
            if (tamagotchi.Sleep > 80)
            {
                tamagotchi.Health -= 20;
            }
            return tamagotchi;
        }
    }
}