using System;

namespace _07.NameWar
{
    class NameWar
    {
        static void Main()
        {
            string name = "";
            string winnerName = "";
            long winnerSum = long.MinValue;
            long currentSum = 0;


            while (true)
            {
                name = Console.ReadLine();
                currentSum = 0;
                if (name.ToLower() == "stop")
                {
                    break;
                }

                for (int i = 0; i < name.Length; i++)
                {
                    currentSum = currentSum + (int)name[i];
                }

                if (winnerSum < currentSum)
                {
                    winnerSum = currentSum;
                    winnerName = name;
                }
            }

            Console.WriteLine($"Winner is {winnerName} - {winnerSum}!");
        }
    }
}
