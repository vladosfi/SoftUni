using System;
using System.Collections.Generic;

namespace _06.StrategyPattern
{
    class StartUp
    {
        static void Main()
        {
            SortedSet<Person> setByName = new SortedSet<Person>(new PersonNameLengthComparer());
            SortedSet<Person> setByAge = new SortedSet<Person>(new PersonAgeComparer());

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] personArgs = Console.ReadLine().Split();
                string name = personArgs[0];
                int age = int.Parse(personArgs[1]);

                Person person = new Person(name, age);

                setByName.Add(person);
                setByAge.Add(person);
            }

            foreach (Person person in setByName)
            {
                Console.WriteLine(person);
            }

            foreach (Person person in setByAge)
            {
                Console.WriteLine(person);
            }
        }
    }
}
