using System;
using System.Runtime.Serialization;

namespace Gym
{
    [Serializable]
    public class Trainer : Person
    {
        public Trainer()
            :base()
        {

        }
        public Trainer(string surname, string name, string patronymic, string phoneNumber)
            :base(surname, name, patronymic, phoneNumber)
        {
        }
    }
}