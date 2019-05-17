using System;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace _10.RageQuit
{
    class RageQuit
    {
        static void Main()
        {
            string input = Console.ReadLine();
            StringBuilder allGibberish = new StringBuilder();
            string pattern = @"(?<gibberish>[^\d]{1,20}(?=\d{1}))(?<number>[1-2][0-9]|[0-9])";

            Regex regex = new Regex(pattern);

            MatchCollection collection = regex.Matches(input);
            foreach (Match match in collection)
            {
                string gibberish = match.Groups["gibberish"].ToString();
                int count = int.Parse(match.Groups["number"].ToString());

                for (int i = 0; i < count; i++)
                {
                    allGibberish.Append(gibberish);
                }
            }

            string badWords = allGibberish.ToString().ToUpper();

            var unique = badWords.ToCharArray().Distinct();
            Console.WriteLine($"Unique symbols used: {unique.Count()}");


            Console.WriteLine(badWords);
        }
    }
}
