using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Xml;

namespace Gym
{
    [DataContract]
    internal class Gym
    {
        [DataMember]
        private List<Room>   _rooms;
        [DataMember]
        private List<Trainer>  _trainers;
        [DataMember]
        private List<Client> _clients;
        [DataMember]
        private List<Training> _trainings;
        
        public Gym()
        {
            _rooms   = new List<Room>();
            _trainers = new List<Trainer>();
            _clients = new List<Client>();
            _trainings = new List<Training>();
        }

        public void Add(Trainer trainer)
        {
            _trainers.Add(trainer);
        }

        public void Add(Room room) 
        {
            _rooms.Add(room);
        }

        public void Add(Client client)
        {
            _clients.Add(client);
        }

        public void Remove(Trainer trainer)
        {
            for(int i = 0; i < _trainings.Count; ++i)
            {
                if (_trainings[i].IsTrainer(trainer))
                {
                    _trainings.Remove(_trainings[i]); 
                }
            }

            _trainers.Remove(trainer);
        }

        public void Remove(Room room)
        {
            _rooms.Remove(room);
        }

        public void Remove(Client client)
        {
            foreach (Training training in _trainings)
            {
                training.WriteOutClient(client);
            }

            _clients.Remove(client);
        }

        public Client GetClient(String phoneNum)
        {
            foreach (Client client in _clients)
            {
                if (client.IsPhoneNumber(phoneNum))
                {
                    return client;
                }
            }

            return null;
        }

        public Room GetRoom(int number) 
        {
            foreach (Room room in _rooms)
            {
                if (room.IsRoom(number))
                {
                    return room;
                }
            }

            return null;
        }

        public Trainer GetTrainer(String phoneNum) 
        {
            foreach (Trainer trainer in _trainers)
            {
                if (trainer.IsPhoneNumber(phoneNum))
                {
                    return trainer;
                }
            }

            return null;
        }

        public void GetAllTrainers() 
        {
            foreach (Trainer trainer in _trainers )
            {
                Console.WriteLine(trainer);
            }
        }

        public void GetAllRooms() 
        {
            foreach (Room room in _rooms)
            {
                Console.WriteLine(room);
            }
        }

        public void GetAllClients() 
        {
            foreach (Client client in _clients )
            {
                Console.WriteLine(client);
            }
        }

        public bool IsTrainerFree(Trainer trainer, int day, int time) 
        {
            foreach (Training training in _trainings)
            {
                if (training.IsDate(day, time))
                {
                    if (training.IsTrainer(trainer))
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public bool IsRoomFree(Room room, int day, int time) 
        {
            foreach (Training training in _trainings)
            {
                if (training.IsDate(day, time))
                {
                    if (training.IsRoom(room))
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        public bool IsClientFree(Client client, int day, int time) 
        {
            foreach (Training training in _trainings)
            {
                if (training.IsDate(day, time))
                {
                    if (training.HasClient(client))
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        public void SetTraining(Trainer trainer, int day, int time, Room room) 
        {
            if (IsTrainerFree(trainer, day, time) && IsRoomFree(room, day, time))
            {
                _trainings.Add(new Training(trainer, day, time, room));
            }
        }

        public void RemoveTraining(Trainer trainer, int day, int time) 
        {
            for (int i = 0; i < _trainings.Count; ++i)
            {
                if (_trainings[i].IsTrainer(trainer) && _trainings[i].IsDate(day, time))
                {
                    _trainings.Remove(_trainings[i]);
                    break;
                }
            }
        }

        private Training GetTraining(Trainer trainer, int day, int time)
        {
            foreach (Training training in _trainings)
            {
                if (training.IsTrainer(trainer) && training.IsDate(day, time))
                {
                    return training;
                }
            }

            return null;
        }

        public void WriteClient(Client client, Trainer trainer, int day, int time) 
        {
            Training training = GetTraining(trainer, day, time);
            if (IsClientFree(client, day, time))
            {
                training.WriteClient(client);
            }
        }

        public void WriteOutClient(Client client, Trainer trainer, int day, int time) 
        {
            Training training = GetTraining(trainer, day, time);
            training.WriteOutClient(client);
        }

        private Trainer GetTrainer(int id)
        {
            foreach (Trainer trainer in _trainers)
            {
                if (trainer.IsId(id))
                {
                    return trainer;
                }
            }

            return null;
        }

        private Client GetClient(int id)
        {
            foreach (Client client in _clients)
            {
                if (client.IsId(id))
                {
                    return client;
                }
            }

            return null;
        }

        public void SaveBase()
        {
            using (StreamWriter output = new StreamWriter("base.txt"))
            {
                foreach (Trainer trainer in _trainers)
                {
                    output.WriteLine(trainer);
                }
                foreach (Room room in _rooms)
                {
                    output.WriteLine(room);
                }
            }           
        }

        public void OpenBase(String address)
        {
            using (StreamReader input = new StreamReader(address))
            {
                String s = input.ReadLine();
                string[] entity;
                if (!String.IsNullOrEmpty(s))
                {
                    entity = s.Split();
                }
                else
                {
                    throw new Exception("Base is empty");
                }
                
                while (entity[0] == Trainer.tag)
                {
                    Add(new Trainer(entity[1], entity[2], entity[3], entity[4]));
                    s = input.ReadLine();
                    if (!String.IsNullOrEmpty(s))
                    {
                        entity = s.Split();
                    }
                    else
                    {
                        return;
                    }
                }
                while (entity[0] == Room.tag)
                {
                    Add(new Room(entity[1], int.Parse(entity[2])));
                    s = input.ReadLine();
                    if (!String.IsNullOrEmpty(s))
                    {
                        entity = s.Split();
                    }
                    else
                    {
                        return;
                    }
                }
            }
        }

        private void ShowTraining(Training training)
        {
            string s = "";
            foreach (int id in training.clientsIds)
            {
                s += GetClient(id).ToString() + ", ";
            }

            Console.WriteLine(GetTrainer(training.trainerId).ToString() + '\n' + s);
        }

        public void ShowTrainerSchedule(Trainer trainer)
        {
            foreach (Training training in _trainings)
            {
                if (training.IsTrainer(trainer))
                {
                    ShowTraining(training);
                }
            }
        }

        public void ShowClientSchedule(Client client) 
        {
            foreach (Training training in _trainings)
            {
                if (training.HasClient(client))
                {
                    ShowTraining(training);
                }
            }
        }

        public void ShowFullSchedule() 
        {
            foreach (Training training in _trainings)
            {
                ShowTraining(training);
            }
        }
    }
}