using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Gym
{
  internal class CUI
  {
        public static void pain(string[] args)
        {
            Gym gym = new Gym();

            int testCommit = 15;
            testCommit++;

            int caseSwitch;
            bool isEnd = false;
            List<String> strings = new List<string>();
            BinaryFormatter formatter = new BinaryFormatter();

            ShowHelp();

            while (!isEnd)
            {
                caseSwitch = int.Parse(Console.ReadLine());
                strings.Clear();
                switch (caseSwitch)
                {
                    case 1:
                        Console.WriteLine("Enter trainer's full name:");
                        Console.Write("Enter lastname: ");
                        strings.Add(Console.ReadLine());
                        Console.Write("Enter name: ");
                        strings.Add(Console.ReadLine());
                        Console.Write("Enter patronymic: ");
                        strings.Add(Console.ReadLine());
                        Console.Write("Enter trainer's phone number: ");
                        strings.Add(Console.ReadLine());
                        gym.AddTrainer(strings[0], strings[1], strings[2], strings[3]);
                        break;
                    case 2:
                        Console.Write("Enter room type ");
                        strings.Add(Console.ReadLine());
                        Console.Write("Enter room number: ");
                        strings.Add(Console.ReadLine());
                        gym.AddRoom(strings[0], int.Parse(strings[1]));
                        break;
                    case 3:
                        Console.WriteLine("Enter client's full name:");
                        Console.Write("Enter lastname: ");
                        strings.Add(Console.ReadLine());
                        Console.Write("Enter name: ");
                        strings.Add(Console.ReadLine());
                        Console.Write("Enter patronymic: ");
                        strings.Add(Console.ReadLine());
                        Console.Write("Enter client's phone number:");
                        strings.Add(Console.ReadLine());
                        gym.AddClient(strings[0], strings[1], strings[2], strings[3]);
                        break;
                    case 4:
                        Console.Write("Enter trainer's phone number: ");
                        strings.Add(Console.ReadLine());
                        gym.RemoveTrainer(strings[0]);
                        break;
                    case 5:
                        Console.Write("Enter room number: ");
                        strings.Add(Console.ReadLine());
                        gym.RemoveRoom(int.Parse(strings[0]));
                        break;
                    case 6:
                        Console.Write("Enter client's phone number: ");
                        strings.Add(Console.ReadLine());
                        gym.RemoveClient(strings[0]);
                        break;
                    case 7:
                        Console.Write("Enter room number: ");
                        strings.Add(Console.ReadLine());
                        Console.Write("Enter day ");
                        strings.Add(Console.ReadLine());
                        Console.Write("Enter time ");
                        strings.Add(Console.ReadLine());
                        Console.Write("Enter trainer's phone number: ");
                        strings.Add(Console.ReadLine());
                        gym.SetTraining(int.Parse(strings[0]), int.Parse(strings[1]), int.Parse(strings[2]), strings[3]);
                        break;
                    case 8:
                        Console.Write("Enter room number: ");
                        strings.Add(Console.ReadLine());
                        Console.Write("Enter day ");
                        strings.Add(Console.ReadLine());
                        Console.Write("Enter time ");
                        strings.Add(Console.ReadLine());
                        gym.RemoveTraining(int.Parse(strings[0]), int.Parse(strings[1]), int.Parse(strings[2]));
                        break;
                    case 9:
                        Console.Write("Enter room number: ");
                        strings.Add(Console.ReadLine());
                        Console.Write("Enter day ");
                        strings.Add(Console.ReadLine());
                        Console.Write("Enter time ");
                        strings.Add(Console.ReadLine());
                        Console.Write("Enter client's phone number: ");
                        strings.Add(Console.ReadLine());
                        gym.WriteClient(int.Parse(strings[0]), int.Parse(strings[1]), int.Parse(strings[2]), strings[3]);
                        break;
                    case 10:
                        Console.Write("Enter room number: ");
                        strings.Add(Console.ReadLine());
                        Console.Write("Enter day ");
                        strings.Add(Console.ReadLine());
                        Console.Write("Enter time ");
                        strings.Add(Console.ReadLine());
                        Console.Write("Enter client's phone number: ");
                        strings.Add(Console.ReadLine());
                        gym.WriteOutClient(int.Parse(strings[0]), int.Parse(strings[1]), int.Parse(strings[2]), strings[3]);
                        break;
                    case 11:
                        Console.WriteLine(gym.GetTrainers());
                        break;
                    case 12:
                        Console.WriteLine(gym.GetRooms());
                        break;
                    case 13:
                        Console.WriteLine(gym.GetClients());
                        break;
                    case 14:
                        Console.WriteLine(gym.GetSchedule());
                        break;
                    case 15:
                        Console.Write("Enter filename: ");
                        strings.Add(Console.ReadLine());
                        using (FileStream fs = new FileStream(strings[0], FileMode.OpenOrCreate))
                        {                         
                            formatter.Serialize(fs, gym);
                        }
                        break;
                    case 16:
                        Console.Write("Enter filename: ");
                        strings.Add(Console.ReadLine());
                        try
                        {
                            using (FileStream fs = new FileStream(strings[0], FileMode.Open))
                            {
                                gym = (Gym)formatter.Deserialize(fs);
                            }
                        }
                        catch
                        {
                            Console.WriteLine("There is no such a file");
                        }
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

        static void ShowHelp()
        {
            String[] methodNames = {"Add trainer to base - 1", "Add room to base - 2", "Add client to base - 3", "Remove trainer - 4", "Remove room - 5",
                "Remove client - 6", "Set training - 7", "Remove training - 8", "Write client - 9", "Writeout client - 10", "Show trainer base - 11",
                "Show room base - 12", "Show client base - 13", "Show schedule - 14","Save gym - 15", "Open gym - 16", "Show help - 111", "Stop - 100"};

            String s = "";
            for (int i = 0; i < methodNames.Length; ++i)
            {
                s += String.Format("{0, 25}\t", methodNames[i]);
                if (i % 2 != 0)
                {
                    s += "\n";
                }
            }
            Console.WriteLine(s);
        }

    }
}