using System;

namespace _03.WeddingInvestment
{
    class WeddingInvestment
    {
        static void Main()
        {
            string orderDuration = Console.ReadLine();
            string contractType = Console.ReadLine();
            string dessert = Console.ReadLine();
            int monthForPay = int.Parse(Console.ReadLine());
            decimal totalSum = 0;
            bool discount = false;

            switch (orderDuration)
            {
                case "one":
                    switch (contractType)
                    {
                        case "Small":
                            totalSum = 9.98m;
                            break;
                        case "Middle":
                            totalSum = 18.99m;
                            break;
                        case "Large":
                            totalSum = 25.98m;
                            break;
                        default:
                            totalSum = 35.99m;
                            break;
                    }
                    break;
                default:
                    discount = true;
                    switch (contractType)
                    {
                        case "Small":
                            totalSum = 8.58m;
                            break;
                        case "Middle":
                            totalSum = 17.09m;
                            break;
                        case "Large":
                            totalSum = 23.59m;
                            break;
                        default:
                            totalSum = 31.79m;
                            break;
                    }
                    break;
            }

            if (dessert == "yes" && totalSum <= 10)
            {
                totalSum = totalSum + 5.5m;
            }
            else if (dessert == "yes" && totalSum <= 30)
            {
                totalSum = totalSum + 4.35m;
            }
            else if (dessert == "yes" && totalSum > 30)
            {
                totalSum = totalSum + 3.85m;
            }

            totalSum = totalSum * monthForPay;

            if (discount)
            {
                totalSum = totalSum - (totalSum * 0.0375m);
            }

            Console.WriteLine($"{totalSum:f02} lv.");
        }
    }
}
