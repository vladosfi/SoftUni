using System;

namespace _06.FruitShop
{
    class FruitShop
    {
        static void Main(string[] args)
        {
            string fruitName = Console.ReadLine();
            string day = Console.ReadLine();
            double quantity = double.Parse(Console.ReadLine());

            if (day == "Monday" || day == "Tuesday" || day == "Wednesday" || day == "Thursday" || day == "Friday")
            {
                switch (fruitName)
                {
                    case "banana":
                        Console.WriteLine($"{(quantity * 2.50):F02}");
                        break;
                    case "apple":
                        Console.WriteLine($"{(quantity * 1.20):F02}");
                        break;
                    case "orange":
                        Console.WriteLine($"{(quantity * 0.85):F02}");
                        break;
                    case "grapefruit":
                        Console.WriteLine($"{(quantity * 1.45):F02}");
                        break;
                    case "kiwi":
                        Console.WriteLine($"{(quantity * 2.70):F02}");
                        break;
                    case "pineapple":
                        Console.WriteLine($"{(quantity * 5.50):F02}");
                        break;
                    case "grapes":
                        Console.WriteLine($"{(quantity * 3.85):F02}");
                        break;
                    default:
                        Console.WriteLine("error");
                        break;
                }
            }
            else if (day == "Saturday" || day == "Sunday")
            {
                switch (fruitName)
                {
                    case "banana":
                        Console.WriteLine($"{(quantity * 2.70):F02}");
                        break;
                    case "apple":
                        Console.WriteLine($"{(quantity * 1.25):F02}");
                        break;
                    case "orange":
                        Console.WriteLine($"{(quantity * 0.90):F02}");
                        break;
                    case "grapefruit":
                        Console.WriteLine($"{(quantity * 1.60):F02}");
                        break;
                    case "kiwi":
                        Console.WriteLine($"{(quantity * 3.00):F02}");
                        break;
                    case "pineapple":
                        Console.WriteLine($"{(quantity * 5.60):F02}");
                        break;
                    case "grapes":
                        Console.WriteLine($"{(quantity * 4.20):F02}");
                        break;
                    default:
                        Console.WriteLine("error");
                        break;
                }
            }
            else
            {
                Console.WriteLine("error");
            }
        }
    }
}
