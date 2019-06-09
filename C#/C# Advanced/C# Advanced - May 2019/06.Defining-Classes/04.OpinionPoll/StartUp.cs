using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Person> people = new List<Person>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split();
                string personName = input[0];
                int personAge = int.Parse(input[1]);
                Person person = new Person(personName, personAge);
                people.Add(person);
            }

            var peopleOrdered = people.OrderBy(p => p.Name);

            foreach (var perosn in peopleOrdered)
            {
                if (perosn.Age > 30)
                {
                    Console.WriteLine($"{perosn.Name} - {perosn.Age}");
                }
            }
        }
    }
}
