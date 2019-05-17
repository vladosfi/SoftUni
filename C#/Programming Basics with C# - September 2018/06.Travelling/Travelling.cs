using System;

namespace _06.Travelling
{
    class Travelling
    {
        static void Main()
        {
            string destination = "";
            double minBudget = 0;
            double savedMoney = 0;
            bool success;

            while (true)
            {
                destination = Console.ReadLine();
                if (destination.ToLower() != "end")
                {
                    minBudget = double.Parse(Console.ReadLine());
                    success = false;

                    while (!success)
                    {
                        savedMoney = savedMoney + double.Parse(Console.ReadLine());
                        if (savedMoney >= minBudget)
                        {
                            savedMoney = 0;
                            Console.WriteLine($"Going to {destination}!");
                            success = true;
                        }
                    }
                }
                else
                {
                    break;
                }
            }
        }
    }
}

