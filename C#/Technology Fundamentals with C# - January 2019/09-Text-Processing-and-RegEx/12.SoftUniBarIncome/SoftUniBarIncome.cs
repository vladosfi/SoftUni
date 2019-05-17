using System;
using System.Text.RegularExpressions;
using System.Threading;

namespace _12.SoftUniBarIncome
{
    class SoftUniBarIncome
    {
        static void Main()
        {
            //@"%(?<costumer>[A-Z][a-z]+)%[^|$%.]*<(?<product>\w+)>[^|$%.]*\|(?<count>\d+)\|[^|$%.]*(?<price>[\d]+[.\d+]*)\$"
            Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.InvariantCulture;
            string pattern = @"%(?<costumer>[A-Z][a-z]+)%[^|$%.]*<(?<product>\w+)>[^|$%.]*\|(?<count>\d+)\|[^|$%.\d]*(?<price>[\d]+[.\d]*)\$";
            decimal income = 0m;

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "end of shift")
                {
                    break;
                }

                Regex regex = new Regex(pattern);
                MatchCollection collection = regex.Matches(input);

                foreach (Match match in collection)
                {
                    string customerName = match.Groups["costumer"].ToString();
                    string product = match.Groups["product"].ToString();
                    int count = int.Parse(match.Groups["count"].ToString());
                    decimal price = decimal.Parse(match.Groups["price"].ToString());
                    decimal totalPrice = price * count;

                    Console.WriteLine($"{customerName}: {product} - {totalPrice:f02}");

                    income += totalPrice;
                }
            }

            Console.WriteLine($"Total income: {income:f02}");


        }
    }
}
