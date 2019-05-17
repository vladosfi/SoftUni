using System;
using System.Collections.Generic;
using System.Linq;

namespace _09.ForceBook
{
    class ForceBook
    {
        static void Main()
        {
            Dictionary<string, List<string>> sides = new Dictionary<string, List<string>>();

            while (true)
            {
                string command = Console.ReadLine();

                if (command.ToLower() == "lumpawaroo")
                {
                    break;
                }

                string[] tokens;
                string forceSide;
                string forceUser;

                if (command.Contains(" | "))
                {
                    tokens = command.Split(" | ");
                    forceSide = tokens[0];
                    forceUser = tokens[1];

                    if (!sides.ContainsKey(forceSide))
                    {
                        sides.Add(forceSide, new List<string>());
                    }

                    if (!UserExist(sides, forceUser))
                    {
                        sides[forceSide].Add(forceUser);
                    }

                }
                else if (command.Contains(" -> "))
                {
                    tokens = command.Split(" -> ");
                    forceSide = tokens[1];
                    forceUser = tokens[0];

                    if (!sides.ContainsKey(forceSide))
                    {
                        sides.Add(forceSide, new List<string>());
                    }

                    if (UserExist(sides, forceUser))
                    {
                        RemoveUser(sides, forceUser);
                    }

                    sides[forceSide].Add(forceUser);

                    Console.WriteLine($"{forceUser} joins the {forceSide} side!");
                }
                
            }


            foreach (var kvp in sides.Where(x => x.Value.Count > 0).OrderByDescending(x => x.Value.Count).ThenBy(x => x.Key))
            {
                Console.WriteLine($"Side: {kvp.Key}, Members: { kvp.Value.Count}");
                foreach (var user in kvp.Value.OrderBy(x => x))
                {
                    Console.WriteLine($"! {user}");
                }
            }
        }

        private static void RemoveUser(Dictionary<string, List<string>> sides, string user)
        {
            foreach (var kvp in sides)
            {
                if (sides[kvp.Key].Contains(user))
                {
                    sides[kvp.Key].Remove(user);
                }
            }
        }

        private static bool UserExist(Dictionary<string, List<string>> sides, string user)
        {
            foreach (var kvp in sides)
            {
                if (sides[kvp.Key].Contains(user))
                {           
                    return true;
                }
            }
            return false;
        }
    }
}
