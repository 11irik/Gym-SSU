using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Gym
{
    [DataContract]
    public class Training
    {
        [DataMember]
        private int _trainerId;
        [DataMember]
        private List<int> _clientsIds;
        [DataMember]
        private int _roomNumber;
        [DataMember]
        private int _day;
        [DataMember]
        private int _time;
        [NonSerialized] 
        public const string tag = "Training";

        public Training(Trainer trainer, int day, int time, Room room)
        {
            _trainerId = trainer.id;
            _clientsIds = new List<int>();
            _day = day;
            _time = time;
            _roomNumber = room.number;
        }

        public void WriteClient(Client client)
        {
            _clientsIds.Add(client.id);
        }

        public bool WriteOutClient(Client client)
        {
            if (_clientsIds.Remove(client.id))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool HasClient(Client client)
        {
            if (_clientsIds.Contains(client.id))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool IsTrainer(Trainer trainer)
        {
            if (_trainerId == trainer.id)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool IsRoom(Room room)
        {
            if (_roomNumber == room.number)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool IsDate(int day, int time)
        {
            if (_day == day && _time == time)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public int trainerId
        {
            get { return _trainerId; }
        }

        public List<int> clientsIds
        {
            get { return _clientsIds; }
        }

        public override string ToString()
        {
            string str = $"{tag};{_trainerId};{_roomNumber};{_day};{_time};";

            foreach (int id in _clientsIds)
            {
                str += $"{id};";
            }

            return str;
        }
    }
}