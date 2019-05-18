using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace _13.FamilyTree
{
    class StartUp
    {
        static void Main()
        {
            Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.InvariantCulture;
            string dateOrName = Console.ReadLine();

            List<Connection> connections = new List<Connection>();
            List<Person> personInfo = new List<Person>();

            string input = Console.ReadLine();

            while (input != "End")
            {
                if (input.Contains("-"))
                {
                    string[] information = input.Split(" - ");

                    string parentArguiment = information[0];
                    string childArguiment = information[1];

                    Person parent = new Person(parentArguiment);
                    Person child = new Person(childArguiment);

                    Connection connection = new Connection(parent, child);

                    connections.Add(connection);
                }
                else
                {
                    string[] information = input.Split();

                    string name = $"{information[0]} {information[1]}";
                    string birthdate = information[2];

                    Person person = new Person(name, birthdate);

                    personInfo.Add(person);
                }


                input = Console.ReadLine();
            }

            Person mainPerson = personInfo.FirstOrDefault(x => x.BirthDate == dateOrName || x.Name == dateOrName);

            var filteredConnections = connections
                .Where(x => x.Parent.BirthDate == mainPerson.BirthDate
                || x.Child.BirthDate == mainPerson.BirthDate
                || x.Parent.Name == mainPerson.Name
                || x.Child.Name == mainPerson.Name)
                .ToList();


            Result result = new Result();
            result.MainPerson = mainPerson;

            foreach (var connection in filteredConnections)
            {
                bool isChildByDate = connection.Child.BirthDate == mainPerson.BirthDate;
                bool isChildName = connection.Child.Name == mainPerson.Name;

                bool isParentByDate = connection.Parent.BirthDate == mainPerson.BirthDate;
                bool isParentName = connection.Parent.Name == mainPerson.Name;

                if (isChildByDate || isChildName)
                {
                    Person parent = personInfo.FirstOrDefault(
                        x => x.Name == connection.Parent.Name ||
                        x.BirthDate == connection.Parent.BirthDate);

                    result.Parrents.Add(parent);
                }
                else if(isParentByDate || isParentName)
                {
                    Person child = personInfo
                        .FirstOrDefault(x => x.Name == connection.Child.Name ||
                        x.BirthDate == connection.Child.BirthDate);

                    result.Children.Add(child);
                }
            }

            Console.WriteLine(result);
        }
    }
}
