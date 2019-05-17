using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.AppendArrays
{
    class AppendArrays
    {
        static void Main()
        {
            List<string> inputList = Console.ReadLine().Split("|").ToList();
            
            inputList.Reverse();

            foreach (var list in inputList)
            {
                List<string> resultList = list.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();

                for (int i = 0; i < resultList.Count; i++)
                {
                    Console.Write(resultList[i] + " ");
                }
            }
            Console.WriteLine();
        }
    }
}
