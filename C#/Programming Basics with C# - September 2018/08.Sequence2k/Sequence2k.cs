using System;

namespace _08.Sequence2k
{
    class Sequence2k
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int k = 1;

            do
            {
                Console.WriteLine(k);
                k = k * 2 + 1;
            } while (k <= n);
            
        }
    }
}
