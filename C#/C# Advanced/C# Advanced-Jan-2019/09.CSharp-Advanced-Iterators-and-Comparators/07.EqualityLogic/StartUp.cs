using System;
using System.Collections.Generic;

namespace _07.EqualityLogic
{
    class StartUp
    {
        static void Main()
        {
            SortedSet<Person> sortedPeople = new SortedSet<Person>();
            HashSet<Person> hashPeople = new HashSet<Person>();

            int peopleCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < peopleCount; i++)
            {
                string[] tokens = Console.ReadLine().Split();
                string name = tokens[0];
                int age = int.Parse(tokens[1]);

                Person person = new Person(name, age);

                sortedPeople.Add(person);
                hashPeople.Add(person);
            }

            Console.WriteLine(sortedPeople.Count);
            Console.WriteLine(hashPeople.Count);
        }
    }
}
