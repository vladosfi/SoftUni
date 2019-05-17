using System;

namespace _06.TriplesOfLatinLetters
{
    class TriplesOfLatinLetters
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            n = n + 'a';

            for (char f = 'a'; f < n; f++)
            {
                for (char s = 'a'; s < n; s++)
                {
                    for (char t = 'a'; t < n; t++)
                    {
                        Console.WriteLine($"{f}{s}{t}");
                    }
                }
            }
        }
    }
}
