using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _01.OddLines
{
    class OddLines
    {
        static void Main()
        {
            using (var reader = new StreamReader(@"Resources\input.txt"))
            {
                int counter = 0;
                while (true)
                {
                    var line = reader.ReadLine();
                    if (line == null)
                    {
                        break;
                    }

                    if (counter % 2 != 0)
                    {
                        Console.WriteLine(line);
                    }

                    counter++;
                }
            }
        }
    }
}
