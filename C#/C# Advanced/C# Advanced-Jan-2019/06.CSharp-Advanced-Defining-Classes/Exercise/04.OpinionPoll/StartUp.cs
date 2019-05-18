using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    class StartUp
    {
        static void Main()
        {
            List<Person> peoples = new List<Person>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split();

                Person person = new Person();
                person.Name = input[0];
                person.Age = int.Parse(input[1]);

                peoples.Add(person);
            }


            foreach (var p in peoples.Where(x => x.Age > 30).OrderBy(p=>p.Name))
            {
                Console.WriteLine($"{p.Name} - {p.Age}");
            }
        }
    }
}
