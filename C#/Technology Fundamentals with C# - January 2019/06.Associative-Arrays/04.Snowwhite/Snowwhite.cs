using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.Snowwhite
{
    class Snowwhite
    {
        static void Main()
        {
            Dictionary<string, int> dwarfs = new Dictionary<string, int>();

            while (true)
            {
                string[] tokens = Console.ReadLine().Split(" <:> ");

                if (tokens[0] == "Once upon a time")
                {
                    break;
                }

                string dwarfName = tokens[0];
                string dwarfHatColor = tokens[1];
                int dwarfPhysics = int.Parse(tokens[2]);

                if (!dwarfs.ContainsKey(dwarfName + "<:>" + dwarfHatColor))
                {
                    dwarfs.Add(dwarfName + "<:>" + dwarfHatColor, 0);
                }

                if (dwarfs[dwarfName + "<:>" + dwarfHatColor] < dwarfPhysics)
                {
                    dwarfs[dwarfName + "<:>" + dwarfHatColor] = dwarfPhysics;
                }
            }

            foreach (var dwarf in dwarfs
                .OrderByDescending(x => x.Value)
                .ThenByDescending(x => dwarfs.Where(y => y.Key.Split("<:>")[1] == x.Key.Split("<:>")[1]).Count()))
            {
                Console.WriteLine($"({dwarf.Key.Split("<:>")[1]}) {dwarf.Key.Split("<:>")[0]} <-> {dwarf.Value}");
            }
        }
    }
}
