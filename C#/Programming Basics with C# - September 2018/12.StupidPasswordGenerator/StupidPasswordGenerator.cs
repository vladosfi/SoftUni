using System;

namespace _12.StupidPasswordGenerator
{
    class StupidPasswordGenerator
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int l = int.Parse(Console.ReadLine());
            int firstChar = 97;
            int lastChar = firstChar + l;

            for (int a= 1; a <= n; a++)
            {
                for (int b = 1; b <= n; b++)
                {
                    for (int c = firstChar; c < lastChar; c++)
                    {
                        for (int d = firstChar; d < lastChar; d++)
                        {
                            for (int e = b+1; e <= n; e++)
                            {
                                if (a < e && b < e)
                                {
                                    Console.Write($"{a}{b}{(char)c}{(char)d}{e} ");
                                }
                            }
                        }
                    }
                }
            }
            Console.WriteLine();
        }
    }
}
