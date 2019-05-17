using System;

namespace _05.DecryptingMessage
{
    class DecryptingMessage
    {
        static void Main()
        {
            int key = int.Parse(Console.ReadLine());
            int n = int.Parse(Console.ReadLine());
            string decryptedMessage = null;

            for (int i = 0; i < n; i++)
            {
                char character = char.Parse(Console.ReadLine());
                decryptedMessage += (char)(character + key); 
            }

            Console.WriteLine(decryptedMessage);
        }
    }
}
