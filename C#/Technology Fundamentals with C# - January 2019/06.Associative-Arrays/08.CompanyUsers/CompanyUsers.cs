using System;
using System.Collections.Generic;
using System.Linq;

namespace _08.CompanyUsers
{
    class CompanyUsers
    {
        static void Main()
        {
            Dictionary<string, List<string>> companies = new Dictionary<string, List<string>>();

            while (true)
            {
                string[] tokens = Console.ReadLine().Split(" -> ");
                string name = tokens[0];

                if (name.ToLower() == "end")
                {
                    break;
                }
                string id = tokens[1];

                if (!companies.ContainsKey(name))
                {
                    companies.Add(name, new List<string>());
                }

                if (!companies[name].Contains(id))
                {
                    companies[name].Add(id);
                }
            }

            foreach (var kvp in companies.OrderBy(x => x.Key))
            {
                Console.WriteLine($"{kvp.Key}");

                foreach (var pid in kvp.Value)
                {
                    Console.WriteLine($"-- {pid}");
                }
            }
        }
    }
}
