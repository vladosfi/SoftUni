using System;

namespace DefiningClasses
{
    class StartUp
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            Family family = new Family();

            for (int i = 0; i < n; i++)
            {
                string[] tokens = Console.ReadLine().Split();

                Person person = new Person();
                person.Name = tokens[0];
                person.Age = int.Parse(tokens[1]);

                family.AddMember(person);
            }

            Person oldestPerson = new Person();
            oldestPerson = family.GetOldestMember();

            Console.WriteLine($"{oldestPerson.Name} {oldestPerson.Age}");
        }
    }
}
