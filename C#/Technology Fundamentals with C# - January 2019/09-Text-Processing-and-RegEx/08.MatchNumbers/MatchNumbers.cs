using System;
using System.Text.RegularExpressions;

namespace _08.MatchNumbers
{
    class MatchNumbers
    {
        static void Main()
        {
            string text = Console.ReadLine();

            Regex regex = new Regex(@"(?<=^|\s)-?[\d]+[.\d+]*($|(?=\s))");

            MatchCollection rx = regex.Matches(text);

            foreach (Match match in rx)
            {
                Console.Write(match + " ");
            }
        }
    }
}
