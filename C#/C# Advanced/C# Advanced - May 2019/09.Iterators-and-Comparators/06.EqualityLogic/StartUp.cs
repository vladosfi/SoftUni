using System;
using System.Collections.Generic;

namespace EqualityLogic
{
    class StartUp
    {
        static void Main()
        {
            SortedSet<Person> sortSet = new SortedSet<Person>();
            HashSet<Person> hashSet = new HashSet<Person>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] tokens = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string name = tokens[0];
                int age = int.Parse(tokens[1]);

                Person person = new Person(name, age);

                sortSet.Add(person);
                hashSet.Add(person);
            }

            Console.WriteLine(sortSet.Count);
            Console.WriteLine(hashSet.Count);
        }
    }
}
