using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace Gym
{
    class Program
    {
        public static void Serialize()
        {
            Gym gym = new Gym();

            gym.AddPerson(new Trainer("f", "f", "f", "f"));
            gym.AddPerson(new Client("a", "a", "a", "a"));
            XmlSerializer formatter = new XmlSerializer(typeof(Gym));

            using (FileStream fs = new FileStream("test.xml", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, gym);
            }

            foreach(Person person in gym.GetPeople())
            {
                Console.WriteLine(person);
            }
            Console.ReadLine();
        }

        public static void DeSerialize()
        {
            Gym gym = new Gym();

            XmlSerializer formatter = new XmlSerializer(typeof(Gym));

            using (FileStream fs = new FileStream("test.xml", FileMode.Open))
            {
                gym = (Gym)formatter.Deserialize(fs);
            }

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
