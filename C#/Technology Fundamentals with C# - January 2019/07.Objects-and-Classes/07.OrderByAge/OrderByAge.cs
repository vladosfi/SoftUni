using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.OrderByAge
{
    class Person
    {
        string name;
        string id;
        int age;

        public Person(string name, string id, int age)
        {
            this.name = name;
            this.id = id;
            this.age = age;
        }
        
        public string Name => this.name;
        public string ID => this.id;
        public int Age => this.age;
    }
    class OrderByAge
    {
        static void Main()
        {
            List<Person> persons = new List<Person>();

            while (true)
            {
                string input = Console.ReadLine();

                if (input.ToLower() == "end")
                {
                    break;
                }

                string[] tokens = input.Split();
                string name = tokens[0];
                string id = tokens[1];
                int age = int.Parse(tokens[2]);

                Person person = new Person(
                        name,
                        id,
                        age
                    );

                persons.Add(person);
            }

            foreach (var person in persons.OrderBy(x=>x.Age))
            {
                Console.WriteLine($"{person.Name} with ID: {person.ID} is {person.Age} years old.");
            }
        }
    }
}
