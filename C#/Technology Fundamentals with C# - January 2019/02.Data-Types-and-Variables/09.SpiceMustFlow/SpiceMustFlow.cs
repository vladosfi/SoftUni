using System;

namespace _09.SpiceMustFlow
{
    class SpiceMustFlow
    {
        static void Main()
        {
            int source = int.Parse(Console.ReadLine());
            int yield = 0;
            int consumesPerDay = 26;
            int consumesForExhausted = 26;
            int daysPast = 0;

            while (true)
            {
                if (source < 100)
                {
                    if (yield >= consumesForExhausted)
                    {
                        yield -= consumesForExhausted;
                    }
                    else
                    {
                        yield = 0;
                    }
                    break;
                }

                yield += source;
                source -= 10;
                yield -= consumesPerDay;
                daysPast++;
            }

            Console.WriteLine(daysPast);
            Console.WriteLine(yield);
        }
    }
}
