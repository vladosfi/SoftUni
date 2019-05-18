﻿using System;
using System.Collections.Generic;

namespace _05.RecordUniqueNames
{
    class RecordUniqueNames
    {
        static void Main()
        {
            HashSet<string> names = new HashSet<string>();
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                names.Add(Console.ReadLine());
            }

            Console.WriteLine();
            foreach (var name in names)
            {
                Console.WriteLine(name);
            }
        }
    }
}
