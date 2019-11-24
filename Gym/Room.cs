using System;
using System.Globalization;
using System.Net;
using System.Runtime.Serialization;

namespace Gym
{
    [DataContract]
    public class Room
    {
        [DataMember]
        private string _type;
        [DataMember]
        private int _number;

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