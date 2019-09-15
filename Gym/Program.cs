using System;
using System.Collections.Generic;
using System.Globalization;
using System.Diagnostics;
using System.IO;
using System.Runtime.CompilerServices;

namespace Gym
{
  internal class Program
  {
        public static void Main(string[] args)
        {
            Gym gym = new Gym(); //объявление экземпляра спортивного зала

            //блок вспомогательных переменных
            int caseSwitch;
            bool isEnd = false;
            string[] s;

            Room room;
            Trainer trainer;
            Client client;

            string phoneNum;
            int num;
            int day;
            int time;

            ShowHelp();
            while (!isEnd)
            {
                caseSwitch = int.Parse(Console.ReadLine());
                switch (caseSwitch)
                {
                    case 1:
                        Console.WriteLine("Enter: Surname Name Patronymic PhoneNumber");
                        s = Console.ReadLine().Split();
                        gym.Add(new Trainer(s[0], s[1], s[2], s[3]));
                        break;
                    case 2:
                        Console.WriteLine("Enter: RoomType RoomNumber");
                        s = Console.ReadLine().Split();
                        gym.Add(new Room(s[0], int.Parse(s[1])));
                        break;
                    case 3:
                        Console.WriteLine("Enter: Surname Name Patronymic PhoneNumber");
                        s = Console.ReadLine().Split();
                        gym.Add(new Client(s[0], s[1], s[2], s[3]));
                        break;
                    case 4:
                        Console.WriteLine("Enter trainer's phone number:");
                        phoneNum = Console.ReadLine();
                        trainer = gym.GetTrainer(phoneNum);
                        gym.Remove(trainer);
                        break;
                    case 5:
                        Console.WriteLine("Enter room's number:");
                        num = int.Parse(Console.ReadLine());
                        room = gym.GetRoom(num);
                        gym.Remove(room);
                        break;
                    case 6:
                        Console.WriteLine("Enter client's phone number:");
                        phoneNum = Console.ReadLine();
                        client = gym.GetClient(phoneNum);
                        gym.Remove(client);
                        break;
                    case 7:
                        Console.WriteLine(("Enter: roomNumber trainerNumber day(0-6) time(0-23)"));
                        s = Console.ReadLine().Split();
                        room = gym.GetRoom(int.Parse(s[0]));
                        trainer = gym.GetTrainer(s[1]);
                        day = int.Parse(s[2]);
                        time = int.Parse(s[3]);
                        gym.SetTraining(trainer, day, time, room);
                        break;
                    case 8:
                        Console.WriteLine(("Enter: trainerNumber day(0-6) time(0-23)"));
                        s = Console.ReadLine().Split();
                        trainer = gym.GetTrainer(s[0]);
                        day = int.Parse(s[1]);
                        time = int.Parse(s[2]);
                        gym.RemoveTraining(trainer, day, time);
                        break;
                    case 9:
                        Console.WriteLine(("Enter: trainerNumber clientNumber day(0-6) time(0-23)"));
                        s = Console.ReadLine().Split();
                        trainer = gym.GetTrainer(s[0]);
                        client = gym.GetClient(s[1]);
                        day = int.Parse(s[2]);
                        time = int.Parse(s[3]);
                        gym.WriteClient(client, trainer, day, time);
                        break;
                    case 10:
                        Console.WriteLine(("Enter: trainerNumber clientNumber day(0-6) time(0-23)"));
                        s = Console.ReadLine().Split();
                        trainer = gym.GetTrainer(s[0]);
                        client = gym.GetClient(s[1]);
                        day = int.Parse(s[2]);
                        time = int.Parse(s[3]);
                        gym.WriteOutClient(client, trainer, day, time);
                        break;
                    case 11:
                        Console.WriteLine("Trainers:");
                        gym.GetAllTrainers();
                        break;
                    case 12:
                        Console.WriteLine("Rooms:");
                        gym.GetAllRooms();
                        break;
                    case 13:
                        Console.WriteLine("Clients:");
                        gym.GetAllClients();
                        break;
                    case 14:
                        Console.WriteLine("Enter trainerNumber:");
                        phoneNum = Console.ReadLine();
                        trainer = gym.GetTrainer(phoneNum);
                        gym.ShowTrainerSchedule(trainer);
                        break;
                    case 15:
                        Console.WriteLine("Enter clientNumber:");
                        phoneNum = Console.ReadLine();
                        client = gym.GetClient(phoneNum);
                        gym.ShowClientSchedule(client);
                        break;
                    case 16:
                        Console.WriteLine(("Enter: roomNumber day(0-6) time(0-23)"));
                        s = Console.ReadLine().Split();
                        room = gym.GetRoom(int.Parse(s[0]));
                        day = int.Parse(s[1]);
                        time = int.Parse(s[2]);
                        if (gym.IsRoomFree(room, day, time))
                        {
                            Console.WriteLine("Room is free");
                        }
                        else
                        {
                            Console.WriteLine("Room is not free");
                        }
                        break;
                    case 17:
                        gym.ShowFullSchedule();
                        break;
                    case 111:
                        ShowHelp();
                        break;
                    case 100:
                        isEnd = true;
                        return;
                }
                Console.Write("Enter number of a command:");
            }
        }

        //Консольное меню
        static void ShowHelp()
        {
            Console.WriteLine(      "Add trainer to base - 1\t" + "Show trainer base      - 11\n" +
                                    "Add room to base    - 2\t" + "Show room base         - 12\n" +
                                    "Add client to base  - 3\t" + "Show client base       - 13\n" +

                                    "Remove trainer      - 4\t" + "Show trainer schedule  - 14\n" +
                                    "Remove room         - 5\t" + "Show client schedule   - 15\n" +
                                    "Remove client       - 6\t" + "Show room's free       - 16\n" +

                                    "Set training        - 7\t" + "Show full schedule     - 17\n" +
                                    "Remove training     - 8\t" + "Show help              - 111\n" +
                                    "Write client        - 9\t" + "Exit program           - 100\n" +
                                    "Writeout client     - 10\n" +
                                    "--------------------------------------------------------");
        }
    }
}