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

            while (true)
            {
                string guest = Console.ReadLine();

                if (guest == "PARTY")
                {
                    break;
                }

                guestList.Add(guest);
            }

            while (true)
            {
                string guest = Console.ReadLine();

                if (guest == "END")
                {
                    break;
                }

                guestList.Remove(guest);
            }

            Console.WriteLine(guestList.Count);
            foreach (var vipGuest in guestList.Where(x=> char.IsDigit(x[0])))
            {
                Console.WriteLine(vipGuest);
            }

            foreach (var regularGuest in guestList.Where(x => char.IsDigit(x[0]) == false))
            {
                Console.WriteLine(regularGuest);
            }
        }
    }
}
