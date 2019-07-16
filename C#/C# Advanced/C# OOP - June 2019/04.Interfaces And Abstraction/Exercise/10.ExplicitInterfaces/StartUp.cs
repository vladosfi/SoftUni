using System;

namespace ExplicitInterfaces
{
    public class StartUp
    {
        static void Main()
        {
            string command = Console.ReadLine();
            
            while (command != "End")
            {
                string[] personTokens = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string name = personTokens[0];
                string country = personTokens[1];
                int age = int.Parse(personTokens[2]);

                IPerson person = new Citizen(name, country, age);
                IResident resident = new Citizen(name, country, age);

                Console.WriteLine(person.GetName());
                Console.WriteLine(resident.GetName());

                command = Console.ReadLine();
            }
        }
    }
}
