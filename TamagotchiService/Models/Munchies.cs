using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TamagotchiWebService.Models
{
    public class Munchies : IGameRule
    {
        public Tamagotchi ExecuteGameRule(Tamagotchi tamagotchi)
        {
            if (tamagotchi.Boredom > 80)
            {
                //TODO: HungerMultiplier
            }
            return tamagotchi;
        }
    }
}