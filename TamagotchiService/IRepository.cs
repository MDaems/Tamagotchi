using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TamagotchiService.Models;

namespace TamagotchiService
{
    public interface IRepository
    {

        Dictionary<string, Tamagotchi> GetAll();
    }
}