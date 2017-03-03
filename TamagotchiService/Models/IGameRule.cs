using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TamagotchiWebService.Models
{
    public interface IGameRule
    {
        Tamagotchi ExecuteGameRule(Tamagotchi tamagotchi);
    }
}