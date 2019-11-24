using System;
using System.Text;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Gym
{
    [DataContract]
    public class Training
    {
        [DataMember]
        private Trainer _trainer;
        [DataMember]
        private List<Client> _clients;
        [DataMember]
        private Room _room;
        [DataMember]
        private int _day;
        [DataMember]
        private int _time;


        public Training(Trainer trainer, int day, int time, Room room)
        {
            _trainer = trainer;
            _clients = new List<Client>();
            _day = day;
            _time = time;
            _room = room;
        }

        public void WriteClient(Client client)
        {
            _clients.Add(client);
        }

        public void WriteOutClient(String clientPhone)
        {
            for (int i = _clients.Count - 1; i >= 0; --i)
            {
                if (_clients[i].Phonenumber == clientPhone)
                {
                    _clients.RemoveAt(i);
                    break;
                }
            }
        }

        public bool HasClient(String clientPhone)
        {
            foreach (Client client in _clients)
            {
                if (client.Phonenumber == clientPhone)
                {
                    return true;
                }
            }

            return false;
        }

        public bool HasTrainer(String trainerPhone)
        {
            if (_trainer.Phonenumber == trainerPhone)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool HasRoom(int roomNumber)
        {
            if (_room.Number == roomNumber)
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

        //todo
        public override string ToString()
        {
            StringBuilder s = new StringBuilder();
            s.Append(_trainer.ToString()).Append(" ");
            s.Append(_room.Number).Append(" ");
            s.Append((DayOfWeek)_day).Append(" " + _time + ":00");
            return s.ToString();
        }
    }
}