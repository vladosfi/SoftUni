using System;

namespace _04.EqualPairs
{
    class EqualPairs
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int first = 0;
            int second = 0;
            int doubles = 0;
            int prevDoubles = 0;
            int diff = 0;
            int MaxDiff = 0;
            bool firstPass = true;

            for (int i = 0; i < n; i++)
            {
                first = int.Parse(Console.ReadLine());
                second = int.Parse(Console.ReadLine());

                doubles = first + second;

                if (firstPass == false)
                {
                    if (doubles > prevDoubles)
                    {
                        diff = doubles - prevDoubles;
                    }
                    else
                    {
                        diff = prevDoubles - doubles;
                    }

                    if (Math.Abs(MaxDiff) < Math.Abs(diff))
                    {
                        MaxDiff = diff;
                    }
                }
                
                prevDoubles = doubles;
                firstPass = false;
            }

            if (MaxDiff != 0)
            {
                Console.WriteLine($"No, maxdiff={MaxDiff}");
            }
            else
            {
                Console.WriteLine($"Yes, value={doubles}");
            }
        }
    }
}
