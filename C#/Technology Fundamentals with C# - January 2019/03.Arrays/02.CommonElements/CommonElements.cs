using System;

namespace _02.CommonElements
{
    class CommonElements
    {
        static void Main()
        {
            string[] firstArray = Console.ReadLine().Split();
            string[] secondArray = Console.ReadLine().Split();

            foreach (var element in secondArray)
            {
                for (int i = 0; i < firstArray.Length; i++)
                {
                    if (element == firstArray[i])
                    {
                        Console.Write(element + " ");
                    }
                }
            }

        }
    }
}
