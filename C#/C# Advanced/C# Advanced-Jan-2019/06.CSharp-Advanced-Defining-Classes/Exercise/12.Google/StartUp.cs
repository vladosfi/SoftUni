using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace _12.Google
{
    class StartUp
    {
        static void Main()
        {
            Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.InvariantCulture;
            List<Person> persons = new List<Person>();

            string input = Console.ReadLine();

            while (input != "End")
            {
                string[] tokens = input.Split();
                string personName = tokens[0];
                string identifier = tokens[1];

                int indexOfPerson = persons.FindIndex(p => p.Name == personName);

                if (indexOfPerson == -1)
                {
                    Person person = new Person(personName);
                    persons.Add(person);
                    indexOfPerson = persons.Count - 1;
                }



                if (identifier == "company")
                {
                    persons[indexOfPerson].AddCompany(tokens[2], tokens[3], double.Parse(tokens[4]));
                }
                else if (identifier == "pokemon")
                {
                    persons[indexOfPerson].AddPokemon(tokens[2], tokens[3]);
                }
                else if (identifier == "parents")
                {
                    persons[indexOfPerson].AddParent(tokens[2], tokens[3]);
                }
                else if (identifier == "children")
                {
                    persons[indexOfPerson].AddChild(tokens[2], tokens[3]);
                }
                else if (identifier == "car")
                {
                    persons[indexOfPerson].AddCar(tokens[2], int.Parse(tokens[3]));
                }

                input = Console.ReadLine();
            }

            string serchPerson = Console.ReadLine();

            foreach (var person in persons.Where(p => p.Name == serchPerson))
            {
                Console.WriteLine(person.ToString());
            }
        }
    }
}
