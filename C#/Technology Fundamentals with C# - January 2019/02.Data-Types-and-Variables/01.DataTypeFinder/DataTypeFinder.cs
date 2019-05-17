using System;
using System.Threading;

namespace _01.DataTypeFinder
{
    class DataTypeFinder
    {
        static void Main()
        {
            Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.InvariantCulture;
            while (true)
            {
                string input = Console.ReadLine();
                string dataType;
                int integer;
                char character;
                float floating;
                bool boolean;

                if (input == "END")
                {
                    break;
                }
                else if (int.TryParse(input, out integer))
                {
                    dataType = "integer";
                }
                else if (char.TryParse(input, out character))
                {
                    dataType = "character";
                }
                else if (bool.TryParse(input, out boolean))
                {
                    dataType = "boolean";
                }
                else if (float.TryParse(input, out floating))
                {
                    dataType = "floating point"; 
                }
                else
                {
                    dataType = "string";
                }
                


                Console.WriteLine($"{input} is {dataType} type");
            }
       }
    }
}
