using System;

namespace _02.VowelsCount
{
    class VowelsCount
    {
        static void Main()
        {
            string str = Console.ReadLine();

            Console.WriteLine(VowelsCounter(str.ToLower()));
        }

        private static int VowelsCounter(string str)
        {
            int counter = 0;

            foreach (char letter in str)
            {
                if (letter == 'a' || letter == 'e' || letter == 'i' || letter == 'o' || letter == 'u')
                {
                    counter++;
                }
            }

            return counter;
        }
    }
}
