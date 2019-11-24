using System;
using System.Runtime.Serialization;

namespace Gym
{
    [DataContract]
    public class Trainer : Person
    {
        public Trainer(string surname, string name, string patronymic, string phoneNumber)
            :base(surname, name, patronymic, phoneNumber)
        {
        }
    }
}