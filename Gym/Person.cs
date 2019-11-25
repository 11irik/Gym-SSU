using System;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Xml;
using System.Xml.Serialization;

namespace Gym
{
    [Serializable]
    [XmlInclude(typeof(Client)), XmlInclude(typeof(Trainer))]
    public class Person
    {
        public string _lastname { get; set; }
        public string _name { get; set; }
        public string _patronymic { get; set; }
        public string _phonenumber { get; set; }
        public int _id { get; set; }

        public static int _idCounter = 0;

        public Person()
        {

        }

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
