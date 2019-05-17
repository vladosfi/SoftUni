using System;

namespace _05.MultiplyBigNumber
{
    class MultiplyBigNumber
    {
        static void Main()
        {
            string bigNumber = Console.ReadLine();
            int singleDigit = int.Parse(Console.ReadLine());
            string result = string.Empty;
            int product = 0;
            int reminder = 0;

            for (int i = 0; i < bigNumber.Length; i++)
            {
                if (bigNumber[0] == '0')
                {
                    bigNumber = bigNumber.Substring(1);
                    i = -1;
                }
            }

            if (singleDigit != 0 && bigNumber != string.Empty)
            {
                for (int i = bigNumber.Length - 1; i >= 0; i--)
                {
                    product = (singleDigit * (int)(bigNumber[i] - '0'));

                    if (reminder != 0)
                    {
                        product += reminder;
                        reminder = 0;
                    }

                    if (product > 9)
                    {
                        reminder = product / 10;
                        product = product % 10;
                    }

                    result = product + result;
                }

                if (reminder != 0)
                {
                    result = reminder + result;
                }
            }
            else
            {
                result = "0";
            }
            

            Console.WriteLine(result);
        }
    }
}
