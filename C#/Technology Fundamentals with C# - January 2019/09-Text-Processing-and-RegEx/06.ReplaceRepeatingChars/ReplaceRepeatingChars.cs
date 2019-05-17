using System;

namespace _06.ReplaceRepeatingChars
{
    class ReplaceRepeatingChars
    {
        static void Main()
        {
            string text = Console.ReadLine();
            string result = string.Empty;

            for (int i = 0; i < text.Length; i++)
            {
                if (i == 0)
                {
                    result += text[i];
                }
                else
                {
                    if (text[i] != result[result.Length - 1])
                    {
                        result += text[i];
                    }
                }
            }

            Console.WriteLine(result);

        }
    }
}
