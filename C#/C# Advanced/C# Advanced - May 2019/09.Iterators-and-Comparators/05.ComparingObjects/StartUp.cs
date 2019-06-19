using System;
using System.Collections.Generic;

namespace _05.ComparingObjects
{
    class StartUp
    {
        static void Main(string[] args)
        {
            List<Person> people = new List<Person>();

            string input = Console.ReadLine();

            while (input != "END")
            {
                string[] tokens = input.Split();
                string name = tokens[0];
                int age = int.Parse(tokens[1]);
                string town = tokens[2];

                Person newPerson = new Person(name, age, town);

                people.Add(newPerson);

                input = Console.ReadLine();
            }

            int indexToCompare = int.Parse(Console.ReadLine()) - 1;
            Person personToCompare = people[indexToCompare];

            int equalPeople = 0;
            int notEqualPeople = 0;
            
            for (int i = 0; i < people.Count; i++)
            {
                if (personToCompare.CompareTo(people[i]) == 0)
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
