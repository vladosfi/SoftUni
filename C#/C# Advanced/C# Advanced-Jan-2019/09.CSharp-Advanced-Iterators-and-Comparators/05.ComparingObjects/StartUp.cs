
using System;
using System.Collections.Generic;

namespace _05.ComparingObjects
{
    class StartUp
    {
        static void Main()
        {
            List<Person> people = new List<Person>();

            string input = Console.ReadLine();

            while (input != "END")
            {
                string[] personArgs = input.Split();
                string name = personArgs[0];
                int age = int.Parse(personArgs[1]);
                string town = personArgs[2];

                Person person = new Person(name, age, town);
                people.Add(person);
                input = Console.ReadLine();
            }

            int n = int.Parse(Console.ReadLine());

            Person currentPerson = people[n - 1];

            int equalPeople = 0;
            int notEqualPeople = 0;

            for (int i = 0; i < people.Count; i++)
            {
                if (currentPerson.CompareTo(people[i]) == 0)
                {
                    equalPeople++;
                }
                else
                {
                    notEqualPeople++;
                }
            }

            if (equalPeople == 1)
            {
                Console.WriteLine("No matches");
            }
            else
            {
                Console.WriteLine($"{equalPeople} {notEqualPeople} {people.Count}");
            }
        }
    }
}
