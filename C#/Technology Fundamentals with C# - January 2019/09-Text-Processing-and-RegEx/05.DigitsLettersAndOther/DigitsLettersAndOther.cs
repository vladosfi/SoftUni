using System;

namespace _05.DigitsLettersAndOther
{
    class DigitsLettersAndOther
    {
        static void Main()
        {
            string text = Console.ReadLine();
            string digits = null;
            string letters = null;
            string other = null;

            foreach (var item in text)
            {
                if (Char.IsDigit(item))
                {
                    digits += item;
                }
                else if (char.IsLetter(item))
                {
                    letters += item;
                }
                else
                {
                    other += item;
                }
            }
            Console.WriteLine(digits);
            Console.WriteLine(letters);
            Console.WriteLine(other);
        }
    }
}
