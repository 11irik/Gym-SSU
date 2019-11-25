using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace Gym
{
    class Program
    {
        public static void prog()
        {
            Gym gym = new Gym();

            gym.AddPerson(new Trainer("f", "f", "f", "f"));
            gym.AddPerson(new Client("a", "a", "a", "a"));
            XmlSerializer formatter = new XmlSerializer(typeof(Gym));

            using (FileStream fs = new FileStream("test.xml", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, gym);
            }
        }
        public static void pain(String[] args)
        {
            prog();
        }
    }
}
