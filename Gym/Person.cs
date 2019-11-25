using System;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;

namespace Gym
{
    [DataContract]
    [KnownType(typeof(Client)), KnownType(typeof(Trainer))]
    public class Person
    {
        [DataMember]
        protected string _lastname { get; set; }
        [DataMember]
        protected string _name { get; set; }
        [DataMember]
        protected string _patronymic { get; set; }
        [DataMember]
        protected string _phonenumber { get; set; }
        [DataMember]
        protected int _id { get; set; }

        private static int _idCounter = 0;

        public Person(string surname, string name, string patronymic, string phoneNumber)
        {
            _lastname = surname;
            _name = name;
            _patronymic = patronymic;
            _phonenumber = phoneNumber;
            _id = ++_idCounter;
        }

        public string Phonenumber
        {
            get => _phonenumber;
        }

        public override string ToString()
        {
            return $"{_lastname};{_name};{_patronymic};{_phonenumber};";
        }
    }
}
