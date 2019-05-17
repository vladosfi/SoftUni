using System;

namespace _02.Divison
{
    class Divison
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            if (n % 2 == 0 || n % 3 == 0 || n % 7 == 0)
            {
                if (n % 10 == 0)
                {
                    Console.WriteLine("The number is divisible by 10");
                }
                else if(n % 7 == 0)
                {
                    Console.WriteLine("The number is divisible by 7");
                }
                else if (n % 6 == 0)
                {
                    Console.WriteLine("The number is divisible by 6");
                }
                else if(n % 3 == 0)
                {
                    Console.WriteLine("The number is divisible by 3");
                }
                else 
                {
                    Console.WriteLine("The number is divisible by 2");
                }
            }
            else
            {
                Console.WriteLine("Not divisible");
            }
            
        }
    }
}
