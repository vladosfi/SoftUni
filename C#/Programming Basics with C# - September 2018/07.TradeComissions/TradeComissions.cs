using System;

namespace _07.TradeComissions
{
    class TradeComissions
    {
        static void Main(string[] args)
        {
            string town = Console.ReadLine();
            double sale = double.Parse(Console.ReadLine());
            string result = "";

            if (town == "Sofia")
            {
                if (sale >= 0 && sale <= 500)
                {
                    result = ($"{sale * 0.05:f02}");
                }
                else if (sale > 500 && sale <= 1000)
                {
                    result = ($"{sale * 0.07:f02}");
                }
                else if (sale > 1000 && sale <= 10000)
                {
                    result = ($"{sale * 0.08:f02}");
                }
                else if (sale > 10000)
                {
                    result = ($"{sale * 0.12:f02}");
                }
                else
                {
                    result = "error";
                }
            }
            else if (town == "Varna")
            {
                if (sale >= 0 && sale <= 500)
                {
                    result = ($"{sale * 0.045:f02}");
                }
                else if (sale > 500 && sale <= 1000)
                {
                    result = ($"{sale * 0.075:f02}");
                }
                else if (sale > 1000 && sale <= 10000)
                {
                    result = ($"{sale * 0.10:f02}");
                }
                else if (sale > 10000)
                {
                    result = ($"{sale * 0.13:f02}");
                }
                else
                {
                    result = "error";
                }
            }
            else if (town == "Plovdiv")
            {
                if (sale >= 0 && sale <= 500)
                {
                    result = ($"{sale * 0.055:f02}");
                }
                else if (sale > 500 && sale <= 1000)
                {
                    result = ($"{sale * 0.08:f02}");
                }
                else if (sale > 1000 && sale <= 10000)
                {
                    result = ($"{sale * 0.12:f02}");
                }
                else if (sale > 10000)
                {
                    result = ($"{sale * 0.145:f02}");
                }
                else
                {
                    result = "error";
                }
            }
            else
            {
                result = "error";
            }
            Console.WriteLine(result);
        }
    }
}
