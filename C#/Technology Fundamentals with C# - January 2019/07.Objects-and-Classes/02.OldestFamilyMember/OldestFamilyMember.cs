using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.OldestFamilyMember
{
    class Person
    {
        string name;
        int age;

        public Person(string name, int age)
        {
            this.name = name;
            this.age = age;
        }

        public string Name => this.name;
        public int Age => this.age;
    }

    class Family
    {
        List<Person> persons = new List<Person>();

        public void AddMember(string name, int age)
        {
            persons.Add(new Person(name, age));
        }

        public string GetOldestMember()
        {
            Person oldestPerseon = persons.OrderByDescending(x => x.Age).FirstOrDefault();

            return $"{oldestPerseon.Name} {oldestPerseon.Age}";
        }
    }

    class OldestFamilyMember
    {
        static void Main()
        {
            Family family = new Family();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] tokens = Console.ReadLine().Split();

                string name = tokens[0];
                int age = int.Parse(tokens[1]);

                family.AddMember(name, age);
            }

            Console.WriteLine(family.GetOldestMember());
        }
    }
}
