using System;

namespace _05.Messages
{
    class Messages
    {
        static void Main()
        {
            int lettersCount = int.Parse(Console.ReadLine());
            int mainDigi = 0;
            string letter = string.Empty;
            int offset = 0;
            int letterCode = 0;
            string message = string.Empty;

            for (int i = 0; i < lettersCount; i++)
            {
                letter = Console.ReadLine();
                mainDigi = letter[0] - 48;
                if (mainDigi == 8 || mainDigi == 9)
                {
                    offset = (mainDigi - 2) * 3 + 1;
                }
                else if (mainDigi == 0)
                {
                    //Space
                    offset = -65;
                }
                else
                {
                    offset = (mainDigi - 2) * 3;
                }

                letterCode = offset + letter.Length - 1;
                message = message + Convert.ToChar(letterCode + 97);
            }

            Console.WriteLine(message);
        }
    }
}