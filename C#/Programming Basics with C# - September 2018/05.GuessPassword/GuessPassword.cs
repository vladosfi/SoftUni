using System;

namespace _05.GuessPassword
{
    class GuessPassword
    {
        static void Main(string[] args)
        {
            string pass = Console.ReadLine();

            if (pass == "s3cr3t!P@ssw0rd")
            {
                Console.WriteLine("Welcome");
            }
            else
            {
                Console.WriteLine("Wrong password!");
            }


        }
    }
}
