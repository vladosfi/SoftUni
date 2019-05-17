using System;

namespace _06.AccountBalance
{
    class AccountBalance
    {
        static void Main(string[] args)
        {
            double numOfPayments = double.Parse(Console.ReadLine());
            double payment = 0;
            double totalSum = 0;


            while (numOfPayments > 0 && payment >= 0)
            {
                numOfPayments--;

                payment = double.Parse(Console.ReadLine());
                if (payment >= 0)
                {
                    Console.WriteLine($"Increase: {payment:f02}");
                    totalSum = totalSum + payment;
                }
                else
                {
                    Console.WriteLine("Invalid operation!");
                }
            }

            Console.WriteLine($"Total: {totalSum:f02}");

        }
    }
}
