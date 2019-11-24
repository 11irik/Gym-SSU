using System;
using System.Globalization;
using System.Net;
using System.Runtime.Serialization;

namespace Gym
{
    [Serializable]
    public class Room
    {
        public string _type;
        public int _number;

        public Room()
        {

        }

        public Room(string type, int number)
        {
            _type = type;
            _number = number;
        }

        public int Number
        {
            get => _number;
        }

        public override string ToString()
        {
            return $"{_type};{_number}";
        }
    }
}