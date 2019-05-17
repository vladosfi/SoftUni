using System;
using System.Text.RegularExpressions;
using System.Threading;

namespace _11.LettersChangeNumbers
{
    class LettersChangeNumbers
    {
        static void Main()
        {
            Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.InvariantCulture;

            string[] input = Console.ReadLine().Split(new char[] {' ','\t'}, StringSplitOptions.RemoveEmptyEntries);
            double totalSum = 0;

            foreach (var item in input)
            {
                char letterBefore = char.Parse(GetLetterBefore(item));
                char letterAfter = char.Parse(GetLetterAfter(item));
                double number = double.Parse(GetNumber(item));

                if (char.IsLower(letterBefore))
                {
                    number *= letterBefore - 'a' + 1;
                }
                else
                {
                    number /= letterBefore - 'A' + 1;
                }

                if (char.IsLower(letterAfter))
                {
                    number += letterAfter - 'a' + 1;
                }
                else
                {
                    number -= letterAfter - 'A' + 1;
                }

                totalSum += number;
            }

            Console.WriteLine($"{totalSum:f02}");
        }

        private static string GetNumber(string item)
        {
            Regex regex = new Regex(@"(?<=[A-Za-z])[\d]+(?=[A-Za-z])");

            Match match = regex.Match(item);

            return match.ToString();
        }

        private static string GetLetterAfter(string item)
        {
            Regex regex = new Regex(@"(?<=\d)[A-Za-z]");

            Match match = regex.Match(item);

            return match.ToString();
        }

        private static string GetLetterBefore(string item)
        {
            Regex regex = new Regex(@"[A-Za-z](?=\d)");

            Match match = regex.Match(item);

            return match.ToString();
        }
    }
}
