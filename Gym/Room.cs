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
        [NonSerialized]
        public static string tag = "Room";

        public Room(string type, int num)
        {
            _type = type;
            _number = num;
        }

        public bool IsRoom(int num)
        {
            if (_number == num)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public int number
        {
            get { return _number; }
        }

        public override string ToString()
        {
            return $"{tag};{_type};{_number};";
        }
    }
}