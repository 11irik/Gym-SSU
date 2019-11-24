using System;
using System.Collections.Generic;

namespace Gym
{
    class Program
    {


        public static void prog()
        {
            List<Person> _people = new List<Person>();

            _people.Add(new Trainer("f", "f", "f", "f"));
            _people.Add(new Client("a", "a", "a", "a"));
            foreach (Trainer trainer in _people)
            {
                Console.WriteLine(trainer);
            }
        }
        public static void pain(String[] args)
        {
            prog();
        }
    }
}
