using System;

namespace _06.TicketCombination
{
    class TicketCombination
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            for (int a = 66; a <= 76; a = a + 2)
            {
                for (int b = 102; b >= 97; b--)
                {
                    for (int c = 65; c <= 67; c++)
                    {
                        for (int d = 1; d <= 10; d++)
                        {
                            for (int e = 10; e >= 1; e--)
                            {
                                n--;
                                if (n == 0)
                                {
                                    Console.WriteLine($"Ticket combination: {(char)a}{(char)b}{(char)c}{d}{e}");
                                    Console.WriteLine($"Prize: {d+e+a+b+c} lv.");
                                    return;
                                }
                            }
                        }
                    }
                }
            }

        }
    }
}
