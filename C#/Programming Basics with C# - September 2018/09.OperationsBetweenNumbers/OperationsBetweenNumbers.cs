using System;

namespace _09.OperationsBetweenNumbers
{
    class OperationsBetweenNumbers
    {
        static void Main(string[] args)
        {
            int n1 = int.Parse(Console.ReadLine());
            int n2 = int.Parse(Console.ReadLine());
            char operation = char.Parse(Console.ReadLine());
            double result = 0;

            if ((operation == '+' || operation == '-' || operation == '*'))
            {
                switch (operation)
                {
                    case '+':
                        result = n1 + n2;
                        break;
                    case '-':
                        result = n1 - n2;
                        break;
                    case '*':
                        result = n1 * n2;
                        break;
                    default:
                        break;
                }

                if (result % 2 == 0)
                {
                    Console.WriteLine($"{n1} {operation} {n2} = {result} - even");
                }
                else
                {
                    Console.WriteLine($"{n1} {operation} {n2} = {result} - odd");
                }
            }
            else if ((operation == '/' || operation == '%') && n2 == 0)
            {
                Console.WriteLine($"Cannot divide {n1} by zero");
            }
            else if ((operation == '/' || operation == '%') && n2 != 0)
	        {
                if (operation == '/')
                {
                    result = (double)n1 / n2;
                    Console.WriteLine($"{n1} / {n2} = {result:f02}");
                }
                else
                {
                    result = n1 % n2;
                    Console.WriteLine($"{n1} % {n2} = {result}");
                }
            }
        }
    }
}
