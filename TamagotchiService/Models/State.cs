using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace TamagotchiWebService
{
    [DataContract]
    public class State
    {
        [DataMember]
        public bool CanPerformAction { get; set; }
        [DataMember]
        public string BusyMessage { get; set; }
        [DataMember]
        public string HighestProperty { get; set; }
        [DataMember]
        public string HighestPropertyMessage { get; set; }

        public State(Tamagotchi tamagotchi)
        {
            CheckIfBusy(tamagotchi);
            CheckIfDead(tamagotchi);
            CheckHighestProperty(tamagotchi);
        }

        private void CheckIfBusy(Tamagotchi tamagotchi)
        {
            if (tamagotchi.BusyTill > DateTime.UtcNow)
            {
                CanPerformAction = false;
                BusyMessage = "Tamagotchi " + tamagotchi.Name + " is busy till: " + tamagotchi.BusyTill.ToLocalTime().ToLongTimeString();
            }
            else
            {
                CanPerformAction = true;
                BusyMessage = "Tamagotchi " + tamagotchi.Name + " wants to do stuff";
            }

           // CanPerformAction = true;
        }

        private void CheckIfDead(Tamagotchi tamagotchi)
        {
            //if (!tamagotchi.Alive)
            //{
            //    CanPerformAction = false;
            //    BusyMessage = "Tamagotchi " + tamagotchi.Name + " has passed away";
            //}
        }

        private void CheckHighestProperty(Tamagotchi tamagotchi)
        {
            if (tamagotchi.Sleep >= tamagotchi.Hunger && tamagotchi.Sleep >= tamagotchi.Boredom)
            {
                HighestProperty = "Sleep";
                HighestPropertyMessage = "Tamagotchi needs sleep: " + tamagotchi.Sleep;
            }
            else if (tamagotchi.Hunger >= tamagotchi.Boredom)
            {
                HighestProperty = "Hunger";
                HighestPropertyMessage = "Tamagotchi is hungry: " + tamagotchi.Hunger;
            }
            else
            {
                HighestProperty = "Boredom";
                HighestPropertyMessage = "Tamagotchi is bored: " + tamagotchi.Boredom;
            }
        }
    }
}