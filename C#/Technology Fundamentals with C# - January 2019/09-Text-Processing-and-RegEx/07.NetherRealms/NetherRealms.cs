using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;

namespace _07.NetherRealms
{
    class NetherRealms
    {
        static void Main()
        {
            Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.InvariantCulture;

            List<string> demons = Console.ReadLine().Split(new[] { ',', ' ' },StringSplitOptions.RemoveEmptyEntries).OrderBy(x =>x).ToList();

            foreach (var demon in demons)
            {
                int healthPoints = 0;
                double damagePoints = 0;
                string health = GetMatches(@"[^0-9-+*\/.]+", demon);
                double damage = Getcalculations(@"-?[\d]+[[.\d]*]?", demon,0,'+');
                damagePoints = Getcalculations(@"\*", demon, damage,'*');
                damagePoints = Getcalculations(@"\/", demon, damagePoints, '/');

                foreach (char character in health)
                {
                    healthPoints += (int)character;
                }
                Console.WriteLine($"{demon} - {healthPoints} health, {damagePoints:f02} damage");
            }
        }
        public static double Getcalculations(string pattern, string text, double sum, char operatorSign)
        {
            Regex regex = new Regex(pattern);
            MatchCollection rx = regex.Matches(text);

            if (operatorSign == '*')
            {
                foreach (Match match in rx)
                {
                    sum *= 2;
                }
            }
            else if(operatorSign == '/')
            {
                foreach (Match match in rx)
                {
                    sum /= 2;
                }
            }
            else if (operatorSign == '+')
            {
                foreach (Match match in rx)
                {
                    sum += double.Parse(match.ToString());
                }
            }

            return sum;
        }

        public static string GetMatches(string pattern, string text)
        {
            Regex regex = new Regex(pattern);
            MatchCollection rx = regex.Matches(text);
            string result = string.Empty;

            foreach (Match match in rx)
            {
                result += match;
            }

            return result;
        }
    }
}
