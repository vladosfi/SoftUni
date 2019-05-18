using System;
using System.Collections.Generic;

namespace _05.CountSymbols
{
    class CountSymbols
    {
        static void Main()
        {
            var symbols = new SortedDictionary<char, int>();

            string text = Console.ReadLine();

            foreach (var symbol in text)
            {
                if (!symbols.ContainsKey(symbol))
                {
                    symbols[symbol] = 0;
                }
                symbols[symbol]++;
            }

            foreach (var kvp in symbols)
            {
                Console.WriteLine($"{kvp.Key}: {kvp.Value} time/s");
            }
        }
    }
}
