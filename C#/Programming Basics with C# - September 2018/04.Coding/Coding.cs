using System;

namespace _04.Coding
{
    class Coding
    {
        static void Main()
        {
            string n = Console.ReadLine();
            char simbol;
            char charCode;
            int digit;
            string rowText = ""; 

            for (int i = n.Length - 1; i >= 0; i--)
            {
                simbol = n[i];
                rowText = "";
                if (simbol == '0')
                {
                    rowText ="ZERO";
                }
                else
                {
                    digit = (simbol - '0'); 
                    charCode = (char)(33 + digit);

                    for (int j = 0; j < digit; j++)
                    {
                        rowText = rowText + charCode;
                    }
                }
                Console.WriteLine(rowText);
            }
                

        }
    }
}
