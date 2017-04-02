using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using TamagotchiWebService;

namespace TamagotchiService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface ITamagotchiService
    {
        [OperationContract]
        List<Tamagotchi> GetAllTamagotchies();

        [OperationContract]
        Tamagotchi GetTamagotchi(int id);

        [OperationContract]
        void AddTamagotchi(string name);

        [OperationContract]
        void Eat(int id);

        [OperationContract]
        void Sleep(int id);

        [OperationContract]
        void Play(int id);

        [OperationContract]
        void Hug(int id);

        [OperationContract]
        Tamagotchi ApplyGameRules(Tamagotchi tamagotchi);
    }
}
