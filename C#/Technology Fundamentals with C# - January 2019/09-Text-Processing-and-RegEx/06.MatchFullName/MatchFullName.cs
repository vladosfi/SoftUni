using System;
using System.Text.RegularExpressions;

namespace _06.MatchFullName
{
    class MatchFullName
    {
        static void Main()
        {
            string input = Console.ReadLine();

            Regex pattern = new Regex(@"\b[A-Z][a-z]{1,} ([A-Z][a-z]{1,})\b");

            MatchCollection mathe = pattern.Matches(input);
            foreach (var item in mathe)
            {
                Console.Write($"{item} ");
            }
        }
    }
}
