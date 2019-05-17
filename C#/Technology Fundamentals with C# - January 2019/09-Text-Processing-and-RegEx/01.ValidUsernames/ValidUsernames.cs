using System;

namespace _01.ValidUsernames
{
    class ValidUsernames
    {
        static void Main()
        {
            string[] input = Console.ReadLine().Split(", ");

            foreach (var username in input)
            {
                if (CheckLenght(username) && ContainOnlyAllowedChars(username))
                {
                    Console.WriteLine(username);
                }
            }
        }

        private static bool ContainOnlyAllowedChars(string username)
        {
            foreach (var character in username)
            {
                if (!char.IsLetterOrDigit(character) 
                    && character != '-' 
                    && character != '_')
                {
                    return false;
                }
            }

            return true;
        }

        private static bool CheckLenght(string username)
        {
            if (username.Length >= 3 && username.Length <= 16)
            {
                return true;
            }

            return false;
        }
    }
}
