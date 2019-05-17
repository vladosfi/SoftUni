using System;

namespace _09.CharsToString
{
    class CharsToString
    {
        static void Main()
        {
            char input;
            string str = null;

            for (int i = 0; i < 3; i++)
            {
                input = char.Parse(Console.ReadLine());
                str += input;
            }

            Console.WriteLine(str);


        }
    }
}
