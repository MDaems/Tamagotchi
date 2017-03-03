using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TamagotchiWebService.Models
{
    public class Starved : IGameRule
    {
        public Tamagotchi ExecuteGameRule(Tamagotchi tamagotchi)
        {
            if (tamagotchi.Hunger > 80)
            {
                tamagotchi.Health -= 20;
            }
            return tamagotchi;
        }
    }
}