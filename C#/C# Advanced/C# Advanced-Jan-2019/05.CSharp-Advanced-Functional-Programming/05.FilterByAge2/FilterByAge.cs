using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.FilterByAge2
{
    class Person
    {
        public string Name { get; set; }

        public int Age { get; set; }
    }

    class FilterByAge
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            var people = new List<Person>();

            for (int i = 0; i < n; i++)
            {
                var currentPerson = Console.ReadLine()
                    .Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);

                var person = new Person
                {
                    Name = currentPerson[0],
                    Age = int.Parse(currentPerson[1])
                };

                people.Add(person);
            }

            string condition = Console.ReadLine();
            int age = int.Parse(Console.ReadLine());

            Func<Person, bool> filterPredicate;

            if (condition == "older")
            {
                filterPredicate = p => p.Age >= age;
            }
            else
            {
                filterPredicate = p => p.Age < age;
            }

            string format = Console.ReadLine();

            Func<Person, string> selectFunc;

            if (format == "name age")
            {
                selectFunc = p => $"{p.Name} - {p.Age}";
            }
            else if (format == "name")
            {
                selectFunc = p => $"{p.Name}";
            }
            else
            {
                selectFunc = p => $"{p.Age}";
            }

            people
                .Where(filterPredicate)
                .Select(selectFunc)
                .ToList()
                .ForEach(Console.WriteLine);
        }
    }
}
