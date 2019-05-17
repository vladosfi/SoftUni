using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace _06.WinningTicket
{
    class WinningTicket
    {
        static void Main()
        {
            string[] tickets = Console.ReadLine().Split(", ").Select(x => x.Trim()).ToArray();
            char[] winSymbols = {'@','#','$','^' };
            bool ticketChecked = false;

            for (int i = 0; i < tickets.Length; i++)
            {
                if (tickets[i].Length == 20)
                {
                    string leftPart = tickets[i].Substring(0, 10);
                    string rightPart = tickets[i].Substring(10, 10);
                    ticketChecked = false;

                    foreach (var symbol in winSymbols)
                    {
                        for (int r = 9; r >= 5; r--)
                        {
                            if (SerchRepeatingSymbols(@"(\" + symbol + @")\1{" + r + "}", leftPart, rightPart))
                            {
                                if (r == 9)
                                {
                                    Console.WriteLine($"ticket \"{tickets[i]}\" - {r + 1}{symbol} Jackpot!");
                                }
                                else
                                {
                                    Console.WriteLine($"ticket \"{tickets[i]}\" - {r + 1}{symbol}");
                                }
                                ticketChecked = true;
                                break;
                            }
                        }

                        if (ticketChecked == true)
                        {
                            break;
                        }
                    }

                    if (ticketChecked == false)
                    {
                        Console.WriteLine($"ticket \"{tickets[i]}\" - no match");
                    }
                }
                else
                {
                    Console.WriteLine("invalid ticket");
                }
            }
        }

        public static bool SerchRepeatingSymbols(string pattern, string leftPart, string rightPart)
        {
            Regex regex = new Regex(pattern);
            bool left = regex.IsMatch(leftPart);
            bool right = regex.IsMatch(rightPart);
            return (left && right);
        }
    }
}
