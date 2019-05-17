using System;
using System.Collections.Generic;

namespace _03.TakeSkipRope
{
    class TakeSkipRope
    {
        static void Main()
        {
            string inputText = Console.ReadLine();
            List<int> numbers = new List<int>();
            List<string> nonNumbers = new List<string>();

            foreach (char character in inputText)
            {
                if (char.IsDigit(character))
                {
                    numbers.Add(character - '0');
                }
                else
                {
                    nonNumbers.Add(character.ToString());
                }
            }

            List<string> decodedText = new List<string>();
            bool take = true;
            int counter = 0;
            int nextAction = numbers[counter];

            for (int i = 0; i < nonNumbers.Count; i++)
            {
                if (i == nextAction)
                {
                    take = !take;
                    counter++;
                    if (numbers.Count <= counter)
                    {
                        break;
                    }
                    nextAction += numbers[counter];
                }

                if (take)
                {
                    decodedText.Add(nonNumbers[i]);
                }
                else if (take == false && numbers[counter] == 0)
                {
                    i--;
                }
            }

            Console.WriteLine(string.Join("",decodedText));
        }
    }
}
