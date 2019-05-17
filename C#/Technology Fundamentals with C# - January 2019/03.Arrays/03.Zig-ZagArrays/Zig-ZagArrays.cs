using System;

namespace _03.Zig_ZagArrays
{
    class ZigZagArrays
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            string[] firstArr = new string[n];
            string[] secondArr = new string[n];
            bool zigZag = false;

            for (int i = 0; i < n; i++)
            {
                zigZag = !zigZag;
                string[] tmpArr = Console.ReadLine().Split();

                if (zigZag)
                {
                    firstArr[i] = tmpArr[0];
                    secondArr[i] = tmpArr[1];
                }
                else
                {
                    firstArr[i] = tmpArr[1];
                    secondArr[i] = tmpArr[0];
                }
            }

            Console.WriteLine(string.Join(" ", firstArr));
            Console.WriteLine(string.Join(" ", secondArr));

        }
    }
}
