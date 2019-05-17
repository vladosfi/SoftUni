using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.BombNumbers
{
    class BombNumbers
    {
        static void Main()
        {
            List<int> seqOfNumbers = Console.ReadLine().Split().Select(int.Parse).ToList();
            int[] bomb = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int specialBombNumber = bomb[0];
            int bombPower = bomb[1];

            while (true)
            {
                if (!seqOfNumbers.Contains(specialBombNumber))
                {
                    break;
                }

                int indexOfBomb = seqOfNumbers.IndexOf(specialBombNumber);
                int startRange = indexOfBomb - bombPower;
                int count = bombPower + bombPower + 1;

                if (startRange < 0)
                {
                    startRange = 0;
                }
                if (startRange + count >= seqOfNumbers.Count)
                {
                    count = seqOfNumbers.Count - startRange;
                }

                seqOfNumbers.RemoveRange(startRange, count);
            }

            Console.WriteLine(seqOfNumbers.Sum());

        }
    }
}
