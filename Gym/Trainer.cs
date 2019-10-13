using System;
using System.Runtime.Serialization;

namespace Gym
{
    [DataContract]
    public class Trainer
    {
        [DataMember]
        private string _surname;
        [DataMember]
        private string _name;
        [DataMember]
        private string _patronymic;
        [DataMember]
        private string _phoneNumber;
        [DataMember]
        private int _id;
        
        [NonSerialized]
        private static int _idCounter = 0;
        [NonSerialized]
        public static string tag = "Trainer";

        public Trainer(string surname, string name, string patronymic, string phoneNumber)
        {
            _surname = surname;
            _name = name;
            _patronymic = patronymic;
            _phoneNumber = phoneNumber;

            _idCounter++;
            _id = _idCounter;
        }

        public int id
        {
            get { return _id; }
        }

        public bool IsId(int id)
        {
            if (_id == id)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool IsPhoneNumber(string phoneNumber)
        {
            if (_phoneNumber == phoneNumber)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public override string ToString()
        {
            return $"{tag};{_surname};{_name};{_patronymic};{_phoneNumber};";
        }
    }
}