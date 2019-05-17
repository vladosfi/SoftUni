using System;

namespace _04.PasswordValidator
{
    class PasswordValidator
    {
        static void Main()
        {
            string password = Console.ReadLine();
            bool validPassLength = CheckPassLength(password);
            bool validConsistent = CheckConsistent(password);
            bool validMinimumDigitCount = CheckMinimumDigitCount(password);

            if (validPassLength && validConsistent && validMinimumDigitCount)
            {
                Console.WriteLine("Password is valid");
            }
            else
            {
                if (!validPassLength)
                {
                    Console.WriteLine("Password must be between 6 and 10 characters ");
                }
                if (!validConsistent)
                {
                    Console.WriteLine("Password must consist only of letters and digits");
                }
                if (!validMinimumDigitCount)
                {
                    Console.WriteLine("Password must have at least 2 digits");
                }
            }
        }

        private static bool CheckMinimumDigitCount(string password)
        {
            int counter = 0;

            foreach (char character in password)
            {
                if (char.IsDigit(character))
                {
                    counter++;
                }

                if (counter > 1)
                {
                    return true;
                }
            }

            return false;
        }

        private static bool CheckConsistent(string password)
        {
            foreach (char character in password)
            {
                if (!(char.IsDigit(character) || char.IsLetter(character)))
                {
                    return false;
                }
            }

            return true;
        }

        private static bool CheckPassLength(string password)
        {
            return password.Length >= 6 && password.Length <= 10 ? true : false;
        }
    }
}
