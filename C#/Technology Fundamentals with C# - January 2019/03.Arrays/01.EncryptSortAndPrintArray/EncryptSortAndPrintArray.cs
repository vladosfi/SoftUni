using System;

namespace _01.EncryptSortAndPrintArray
{
    class EncryptSortAndPrintArray
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            string[] sequenceOfStrings = new string[n];
            int[] encryptedStrings = new int[n];
            int[] sortedStrings = new int[n];

            for (int i = 0; i < n; i++)
            {
                sequenceOfStrings[i] = Console.ReadLine();
            }

            //Encrypr
            for (int i = 0; i < n; i++)
            {
                encryptedStrings[i] = EncryptVowel(sequenceOfStrings[i]);
            }

            //Sort
            sortedStrings = BoubleSort(encryptedStrings);

            foreach (int element in sortedStrings)
            {
                Console.WriteLine(element);
            }

        }

        private static int[] BoubleSort(int[] encryptedStrings)
        {
            bool swap = true;

            while (swap)
            {
                swap = false;
                for (int i = 0; i < encryptedStrings.Length - 1; i++)
                {
                    if (encryptedStrings[i] > encryptedStrings[i+1])
                    {
                        int tmp = encryptedStrings[i];
                        encryptedStrings[i] = encryptedStrings[i + 1];
                        encryptedStrings[i + 1] = tmp;
                        swap = true;
                    }
                }
            }

            return encryptedStrings;
        }

        private static int EncryptVowel(string word)
        {
            int encryptionCode = 0;
            int wordLength = word.Length;

            foreach (char letter in word)
            {
                int code = 0;

                switch (letter)
                {
                    case 'A':
                    case 'a':
                    case 'E':
                    case 'e':
                    case 'I':
                    case 'i':
                    case 'O':
                    case 'o':
                    case 'U':
                    case 'u':
                        code = letter * wordLength;
                        break;
                    default:
                        code = letter / wordLength;
                        break;
                }
                encryptionCode += code;
            }

            return encryptionCode;
        }
    }
}
