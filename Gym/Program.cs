using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Gym
{
    class Program
    {


        public static void Serialize()
        {
            Gym gym = new Gym();

            gym.AddPerson(new Trainer("f", "f", "f", "f"));
            gym.AddPerson(new Client("a", "a", "a", "a"));
            BinaryFormatter formatter = new BinaryFormatter();

            using (FileStream fs = new FileStream("test.dat", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, gym);
            }
            Console.WriteLine("Serialized:");

            foreach (Person person in gym.GetPersons())
            {
                Console.WriteLine(person);
            }
            Console.ReadLine();
        }

        public static void DeSerialize()
        {
            Gym gym = new Gym();

            BinaryFormatter formatter = new BinaryFormatter();

            using (FileStream fs = new FileStream("test.dat", FileMode.Open))
            {
                gym = (Gym)formatter.Deserialize(fs);
            }
            Console.WriteLine("Deserialized:");
            foreach (Person person in gym.GetPersons())
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
