using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace _08.MatchPhoneNumber
{
    class MatchPhoneNumber
    {
        static void Main()
        {
            string input = Console.ReadLine();

            Regex regex = new Regex(@"\+359([\s-])(2)\1(\d{3})\1\d{4}\b");

            MatchCollection match = regex.Matches(input);
            List<string> realPhoneNumbers = new List<string>();

            foreach (var item in match)
            {
                realPhoneNumbers.Add(item.ToString());
            }

            Console.WriteLine(string.Join(", ", realPhoneNumbers));
        }
    }
}
