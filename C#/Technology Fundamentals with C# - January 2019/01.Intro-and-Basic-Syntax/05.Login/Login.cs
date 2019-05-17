using System;

namespace _05.Login
{
    class Login
    {
        static void Main()
        {
            string userName = Console.ReadLine();
            string revercedPassword = null;

            for (int i = userName.Length - 1; i >= 0; i--)
            {
                revercedPassword += userName[i];
            }

            for (int i = 0; i < 4; i++)
            {
                string password = Console.ReadLine();

                if (password == revercedPassword)
                {
                    Console.WriteLine($"User {userName} logged in.");
                    break;
                }
                else
                {
                    if (i == 3)
                    {
                        Console.WriteLine($"User {userName} blocked!");
                    }
                    else
                    {
                        Console.WriteLine("Incorrect password. Try again.");
                    }
                }
            }
        }
    }
}
