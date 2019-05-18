using System;
using System.Linq;

namespace _03.CountUppercaseWords
{
    class CountUppercaseWords
    {
        static void Main()
        {
            Func<string, bool> isUpper = x => char.IsUpper(x[0]);

            string[] upperWords = Console.ReadLine()
                .Split(new char[] { ' '}, StringSplitOptions.RemoveEmptyEntries)
                .Where(isUpper)
                .ToArray();
            
            foreach (var word in upperWords)
            {
                Console.WriteLine(word);
            }
        }
    }
}
