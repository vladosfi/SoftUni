using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.CardsGame
{
    class CardsGame
    {
        static void Main()
        {
            List<int> firstPlayerDeck = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            List<int> secondPlayerDeck = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            while (true)
            {
                if (firstPlayerDeck.Count < 1 || secondPlayerDeck.Count < 1)
                {
                    break;
                }

                if (firstPlayerDeck[0] > secondPlayerDeck[0])
                {
                    firstPlayerDeck.Add(firstPlayerDeck[0]);
                    firstPlayerDeck.Add(secondPlayerDeck[0]);
                    firstPlayerDeck.RemoveAt(0);
                    secondPlayerDeck.RemoveAt(0);
                }
                else if (firstPlayerDeck[0] < secondPlayerDeck[0])
                {
                    secondPlayerDeck.Add(secondPlayerDeck[0]);
                    secondPlayerDeck.Add(firstPlayerDeck[0]);
                    secondPlayerDeck.RemoveAt(0);
                    firstPlayerDeck.RemoveAt(0);
                }
                else if(firstPlayerDeck[0] == secondPlayerDeck[0])
                {
                    firstPlayerDeck.RemoveAt(0);
                    secondPlayerDeck.RemoveAt(0);
                }
            }

            if (firstPlayerDeck.Count != 0)
            {
                Console.WriteLine($"First player wins! Sum: {firstPlayerDeck.Sum()}");
            }
            else
            {
                Console.WriteLine($"Second player wins! Sum: {secondPlayerDeck.Sum()}");
            }
        }
    }
}
