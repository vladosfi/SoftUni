using System;

namespace _08.VowelsSum
{
    class VowelsSum
    {
        static void Main()
        {
            string text = Console.ReadLine();
            int vowelSum = 0;


            for (int i = 0; i < text.Length; i++)
            {
                switch (text[i])
                {
                    case 'a':
                        vowelSum = vowelSum + 1;
                        break;
                    case 'e':
                        vowelSum = vowelSum + 2;
                        break;
                    case 'i':
                        vowelSum = vowelSum + 3;
                        break;
                    case 'o':
                        vowelSum = vowelSum + 4;
                        break;
                    case 'u':
                        vowelSum = vowelSum + 5;
                        break;
                    default:
                        break;
                }
            }

            Console.WriteLine(vowelSum);
            
        }
    }
}
