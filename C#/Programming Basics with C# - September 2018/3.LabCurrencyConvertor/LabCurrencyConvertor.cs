using System;

namespace _3.LabCurrencyConvertor
{
    class LabCurrencyConvertor
    {
        static void Main()
        {
            double value = double.Parse(Console.ReadLine());
            string inputCurrency = Console.ReadLine();
            string outputCurrency = Console.ReadLine();
            double bgn = 1;
            double usd = 1.79549;
            double eur = 1.95583;
            double gbp = 2.53405;
            double convertedVal=0;


            
            switch (inputCurrency)
            {
                case "BGN":
                    switch (outputCurrency)
                    {
                        case "BGN":
                            convertedVal = value;
                            break;
                        case "USD":
                            convertedVal = value * (bgn / usd);
                            break;
                        case "EUR":
                            convertedVal = value * (bgn / eur);
                            break;
                        case "GBP":
                            convertedVal = value * (bgn / gbp);
                            break;
                        default:
                            Console.WriteLine("Invalid input currency!");
                            break;
                    }
                    break;
                case "USD":
                    switch (outputCurrency)
                    {
                        case "BGN":
                            convertedVal = value * (usd / bgn);
                            break;
                        case "USD":
                            convertedVal = value;
                            break;
                        case "EUR":
                            convertedVal = value * (usd / eur);
                            break;
                        case "GBP":
                            convertedVal = value * (usd / gbp);
                            break;
                        default:
                            Console.WriteLine("Invalid input currency!");
                            break;
                    }
                    break;
                case "EUR":
                    switch (outputCurrency)
                    {
                        case "BGN":
                            convertedVal = value * (eur / bgn);
                            break;
                        case "USD":
                            convertedVal = value * (eur / usd);
                            break;
                        case "EUR":
                            convertedVal = value; 
                            break;
                        case "GBP":
                            convertedVal = value * (eur / gbp);
                            break;
                        default:
                            Console.WriteLine("Invalid input currency!");
                            break;
                    }
                    break;
                case "GBP":
                    switch (outputCurrency)
                    {
                        case "BGN":
                            convertedVal = value * (gbp / bgn);
                            break;
                        case "USD":
                            convertedVal = value * (gbp / usd);
                            break;
                        case "EUR":
                            convertedVal = value * (gbp / eur);
                            break;
                        case "GBP":
                            convertedVal = value; 
                            break;
                        default:
                            Console.WriteLine("Invalid input currency!");
                            break;
                    }
                    break;
                default:
                    Console.WriteLine("Invalid input currency!");
                    break;
            }

            Console.WriteLine($"{convertedVal:F02} {outputCurrency}");
         
            

        }
    }
}
