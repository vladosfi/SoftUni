using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.SoftUniParty
{
    class SoftUniParty
    {
        static void Main()
        {
            HashSet<string> guestList = new HashSet<string>();
            string input = Console.ReadLine();

            while (input?.ToLower() != "party")
            {
                if (input.Length == 8)
                {
                    guestList.Add(input);
                }

                input = Console.ReadLine();
            }

            input = Console.ReadLine();

            while (input?.ToLower() != "end")
            {
                if (guestList.Contains(input))
                {
                    guestList.Remove(input);
                }

                input = Console.ReadLine();
            }

            Console.WriteLine(guestList.Count);
            foreach (var guest in guestList.Where(x=>char.IsDigit(x[0])))
            {
                Console.WriteLine(guest);
            }

            foreach (var guest in guestList.Where(x => !char.IsDigit(x[0])))
            {
                Console.WriteLine(guest);
            }
        }
    }
}
