using System;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;

namespace Gym
{
    [Serializable]
    public class Client : Person
    {
        public Client()
        :base()
        {

        }
        public Client(string surname, string name, string patronymic, string phoneNumber)
            :base(surname, name, patronymic, phoneNumber)
        {

        }
    }
}