using System;
using System.Globalization;
using System.Net;

namespace Gym
{
    public class Room
    {
        private string _type; 
        private int _number;
        public static string _tag = "Room";

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
            return $"{_tag};{_type};{_number};";
        }
    }
}