using System;

namespace _06.ChallengeTheWedding
{
    class ChallengeTheWedding
    {
        static void Main()
        {

            int man = int.Parse(Console.ReadLine());
            int woman = int.Parse(Console.ReadLine());
            int tables = int.Parse(Console.ReadLine());

            for (int m = 1; m <= man && tables > 0; m++)
            {
                for (int w = 1; w <= woman && tables > 0; w++)
                {
                    tables--;
                    Console.Write($"({m} <-> {w}) ");
                }
            }
        }
    }
}
