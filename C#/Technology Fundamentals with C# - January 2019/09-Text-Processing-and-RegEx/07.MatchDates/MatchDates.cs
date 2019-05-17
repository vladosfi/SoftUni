using System;
using System.Text.RegularExpressions;

namespace _07.MatchDates
{
    class MatchDates
    {
        static void Main()
        {
            string input = Console.ReadLine();

            Regex pattern = new Regex(@"\b(?<day>\d{2})([-.\/])(?<month>[A-Z][a-z]{2})\1(?<year>\d{4})\b");

            MatchCollection matches = pattern.Matches(input);
            foreach (Match match in matches)
            {
                Console.WriteLine($"" +
                    $"Day: {match.Groups["day"].Value}, " +
                    $"Month: {match.Groups["month"].Value}, " +
                    $"Year: {match.Groups["year"].Value}");
            }
        }
    }
}
