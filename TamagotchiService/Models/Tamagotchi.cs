using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace TamagotchiService.Models
{
    [DataContract]
    public class Tamagotchi
    {
        [DataMember]
        public string Name { get; set; }

        public Tamagotchi(string name)
        {
            Name = name;
        }

    }
}