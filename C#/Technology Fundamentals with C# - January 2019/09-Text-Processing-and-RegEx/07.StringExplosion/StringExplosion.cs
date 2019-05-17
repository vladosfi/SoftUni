using System;

namespace _07.StringExplosion
{
    class StringExplosion
    {
        static void Main()
        {
            string input = Console.ReadLine();
            string result = string.Empty;
            int strength = 0;

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == '>')
                {
                    result += input[i];
                    strength += (input[i+1] - '0') - 1;
                    i++;
                }
                else if(strength > 0)
                {
                    strength--;
                }
                else
                {
                    result += input[i];
                }
            }

            Console.WriteLine(result);
        }
    }
}
