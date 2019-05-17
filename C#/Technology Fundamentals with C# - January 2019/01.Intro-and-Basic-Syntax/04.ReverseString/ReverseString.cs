using System;

namespace _04.ReverseString
{
    class ReverseString
    {
        static void Main()
        {
            string text = Console.ReadLine();
            
            for (int i = text.Length - 1; i >= 0; i--)
            {
                Console.Write(text[i]);
            }
        }
    }
}
