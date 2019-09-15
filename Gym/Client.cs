using System;

namespace Gym
{
    public class Client
    {
        private string _surname;
        private string _name;
        private string _patronymic; 
        private string _phoneNumber;
        private static string _position = "Client";

        private int _id;
        private static int _idCounter = 0;

        public Client(string surname, string name, string patronymic, string phoneNumber)
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
            return $"{_position} {_surname} {_name} {_patronymic} {_phoneNumber}";
        }
    }
}