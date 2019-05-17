using System;

namespace _01.Matrix
{
    class Matrix
    {
        static void Main()
        {
            int ma = int.Parse(Console.ReadLine());
            int mb = int.Parse(Console.ReadLine());
            int mc = int.Parse(Console.ReadLine());
            int md = int.Parse(Console.ReadLine());
            int changeVal = 0;

            if (ma > mb)
            {
                changeVal = mb;
                mb = ma;
                ma = changeVal;
            }
            if (mc > md)
            {
                changeVal = md;
                md = mc;
                mc = changeVal;
            }

            for (int a = ma; a <= mb; a++)
            {
                for (int b = ma; b <= mb; b++)
                {
                    if (a != b)
                    {
                        for (int c = mc; c <= md; c++)
                        {
                            for (int d = mc; d <= md; d++)
                            {
                                if ((c != d) && (a + d == b + c))
                                {
                                    Console.WriteLine($"{a}{b}");
                                    Console.WriteLine($"{c}{d}");
                                    Console.WriteLine();
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
