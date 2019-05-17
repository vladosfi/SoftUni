using System;

namespace _04.CaesarCipher
{
    class CaesarCipher
    {
        static void Main()
        {
            string text = Console.ReadLine();
            string encryptedText = string.Empty;

            for (int i = 0; i < text.Length; i++)
            {
                encryptedText += (char)((int)text[i] + 3);
            }

            Console.WriteLine(encryptedText);
        }
    }
}
