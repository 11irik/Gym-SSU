using System;
using System.Text;
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

        public bool AddTrainer(String lastname, String name, String patronymic, String phoneNumber)
        {
            foreach (Trainer trainer in _trainers)
            {
                if (trainer.Phonenumber == phoneNumber)
                {
                    return false;
                }
            }

            _trainers.Add(new Trainer(lastname, name, patronymic, phoneNumber));
            return true;
        }

        public bool AddRoom(String type, int number) 
        {
            foreach (Room room in _rooms)
            {
                if (room.Number == number)
                {
                    return false;
                }
            }

            _rooms.Add(new Room(type, number));
            return true;
        }

        public bool AddClient(String lastname, String name, String patronymic, String phoneNumber)
        {
            foreach (Client client in _clients)
            {
                if (client.Phonenumber == phoneNumber)
                {
                    return false;
                }
            }

            _clients.Add(new Client(lastname, name, patronymic, phoneNumber));
            return true;
        }

        public void SetTraining(int roomNumber, int day, int time, String trainerPhone)
        {
            foreach (Trainer trainer in _trainers)
            {
                if (trainer.Phonenumber == trainerPhone)
                {
                    if (!IsTrainerBusy(trainerPhone, day, time))
                    {
                        foreach (Room room in _rooms)
                        {
                            if (room.Number == roomNumber)
                            {
                                if (!IsRoomBusy(roomNumber, day, time))
                                {
                                    _trainings.Add(new Training(trainer, day, time, room));
                                }
                                else
                                {
                                    throw new Exception("Room is busy");
                                }
                                break;
                            }
                        }                        
                    }
                    else
                    {
                        throw new Exception("Trainer is busy");
                    }
                    break;
                }
            }
        }

        public void WriteClient(int roomNumber, int day, int time, String clientPhone)
        {
            foreach (Client client in _clients)
            {
                if (client.Phonenumber == clientPhone)
                {
                    if (!IsClientBusy(clientPhone, day, time)) 
                    {                     
                        foreach (Training training in _trainings)                    
                        {                        
                            if (training.HasRoom(roomNumber) && training.IsDate(day, time))                        
                            {                            
                                training.WriteClient(client);                            
                                break;                        
                            }                    
                        }              
                    }
                    else
                    {
                        throw new Exception("Client is busy");
                    }
                    break;
                }
            }
        }

        public void WriteOutClient(int roomNumber, int day, int time, String clientPhone)
        {
            foreach (Training training in _trainings)
            {
                if (training.HasRoom(roomNumber) && training.IsDate(day, time))
                {
                    training.WriteOutClient(clientPhone);
                    break;
                }
            }
        }

        public void RemoveTrainer(String trainerPhone)
        {
            for (int i = _trainers.Count - 1; i >= 0; --i)
            {
                if (_trainers[i].Phonenumber == trainerPhone)
                {
                    _trainers.RemoveAt(i);
                    break;
                }
            }

            for (int i = _trainings.Count; i >= 0; --i)
            {
                if (_trainings[i].HasTrainer(trainerPhone))
                {
                    _trainings.RemoveAt(i);
                }
            }          
        }

        public void RemoveRoom(int roomNumber)
        {
            for (int i = _rooms.Count - 1; i >= 0; --i)
            {
                if (_rooms[i].Number == roomNumber)
                {
                    _rooms.RemoveAt(i);
                }
            }

            for (int i = _trainings.Count; i >= 0; --i)
            {
                if (_trainings[i].HasRoom(roomNumber))
                {
                    _rooms.RemoveAt(i);
                }
            }
        }

        public void RemoveClient(String clientPhone)
        {
            for (int i = _clients.Count - 1; i >= 0; --i)
            {
                if (_clients[i].Phonenumber == clientPhone)
                {
                    _clients.RemoveAt(i);
                    break;
                }
            }

            foreach (Training training in _trainings)
            {
                if (training.HasClient(clientPhone))
                {
                    training.WriteOutClient(clientPhone);
                }
            }
        }

        public void RemoveTraining(int roomNumber, int day, int time)
        {
            for (int i = _trainings.Count - 1; i >= 0; --i)
            {
                if (_trainings[i].HasRoom(roomNumber) && _trainings[i].IsDate(day, time))
                {
                    _trainings.RemoveAt(i);
                    break;
                }
            }
        }

        public String GetTrainers()
        {
            StringBuilder s = new StringBuilder();
            foreach (Trainer trainer in _trainers)
            {
                s.Append(trainer.ToString()).Append('\n');
            }

            return s.ToString();
        }

        public String GetRooms()
        {
            StringBuilder s = new StringBuilder();
            foreach (Room room in _rooms)
            {
                s.Append(room.ToString()).Append('\n');
            }

            return s.ToString();
        }

        public String GetClients()
        {
            StringBuilder s = new StringBuilder();
            foreach (Client client in _clients)
            {
                s.Append(client.ToString()).Append('\n');
            }

            return s.ToString();
        }

        private bool IsClientBusy(String clientPhone, int day, int time)
        {
            foreach (Training training in _trainings)
            {
                if (training.IsDate(day, time))
                {
                    if (training.HasClient(clientPhone))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        private bool IsTrainerBusy(String trainerPhone, int day, int time)
        {
            foreach (Training training in _trainings)
            {
                if (training.IsDate(day, time))
                {
                    if (training.HasTrainer(trainerPhone))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        private bool IsRoomBusy(int roomNumber, int day, int time)
        {
            foreach (Training training in _trainings)
            {
                if (training.IsDate(day, time))
                {
                    if (training.HasRoom(roomNumber))
                    {
                        return true;
                    }
                }
            }
            return false;
        }


        public String GetSchedule()
        {
            StringBuilder s = new StringBuilder();
            foreach (Training training in _trainings)
            {
                s.Append(training.ToString()).Append('\n');
            }

            return s.ToString();
        }

        
    }
}