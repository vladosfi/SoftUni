using System;

namespace _09.PalindromeIntegers
{
    class PalindromeIntegers
    {
        static void Main()
        {
            while (true)
            {
                string number = Console.ReadLine();

                if (number.ToLower() == "end")
                {
                    break;
                }

                Console.WriteLine(IsPalindrome(number).ToString().ToLower());
            }
        }

        private static bool IsPalindrome(string number)
        {
            if (number.Length == 1)
            {
                return true;
            }
            else
            {
                if (number.Length % 2 == 0)
                {
                    for (int i = 0; i <= number.Length / 2; i++)
                    {
                        if (!(number[i] == number[number.Length - i - 1]))
                        {
                            return false;
                        }
                    }
                }
                else
                {
                    for (int i = 0; i <= (number.Length / 2)-1; i++)
                    {
                        if (!(number[i] == number[number.Length - i - 1]))
                        {
                            return false;
                        }
                    }
                }
            }

            return true;
        }
    }
}
