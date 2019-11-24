using System;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;

namespace Gym
{
    [DataContract]
    public class Client : Person
    {
        public Client(string surname, string name, string patronymic, string phoneNumber)
            :base(surname, name, patronymic, phoneNumber)
        {

        }
    }
}