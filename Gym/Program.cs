using System;
using System.Collections.Generic;
using System.Runtime.Serialization.Json;
using System.IO;



namespace Gym
{
    class Program
    {
        public static void Serialize()
        {
            List<Person> _people = new List<Person>();
            Gym gym = Gym.GetInstance();

            gym.AddPerson(new Trainer("f", "f", "f", "f"));
            gym.AddPerson(new Client("a", "a", "a", "a"));
            DataContractJsonSerializer jsonFormatter = new DataContractJsonSerializer(typeof(Gym));

            using (FileStream fs = new FileStream("test.json", FileMode.OpenOrCreate))
            {
                jsonFormatter.WriteObject(fs, gym);
            }

            Console.WriteLine("Serialized: ");
            foreach (Person person in gym.GetPeople())
            {
                Console.WriteLine(person);
            }
            Console.ReadLine();
        }

        public static void DeSerialize()
        {
            List<Person> _people = new List<Person>();
            Gym gym = Gym.GetInstance();

            DataContractJsonSerializer jsonFormatter = new DataContractJsonSerializer(typeof(Gym));

            using (FileStream fs = new FileStream("test.json", FileMode.Open))
            {
                gym = (Gym)jsonFormatter.ReadObject(fs);
            }
            Console.WriteLine("DeSerialized: ");
            foreach (Person person in gym.GetPeople())
            {
                Console.WriteLine(person);
            }
            Console.ReadLine();
        }
        public static void Main(String[] args)
        {
            Serialize();
            DeSerialize();

        }
    }
}
