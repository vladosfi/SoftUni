using System;

namespace _06.MiddleCharacters
{
    class MiddleCharacters
    {
        static void Main()
        {
            string str = Console.ReadLine();
            Console.WriteLine(GetMiddleCharacters(str));

        }

        private static string GetMiddleCharacters(string str)
        {
            string middle = null;

            if (str.Length % 2 == 0)
            {
                middle = str[(str.Length / 2) - 1].ToString() + str[str.Length / 2].ToString();
            }
            else
            {
                middle = str[str.Length / 2].ToString();
            }

            return middle;
        }
    }
}
