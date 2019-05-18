namespace _03.CustomMinFunction
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class CustomMinFunction
    {
        static void Main()
        {
            List<int> numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            Func<List<int>, int> getMin = x => x.Min();
            Console.WriteLine(getMin(numbers));
        }



        //static void Main()
        //{
        //    List<int> numbers = Console.ReadLine()
        //        .Split()
        //        .Select(int.Parse)
        //        .ToList();

        //    Func<List<int>, int> getMin = GetMin;

        //    Console.WriteLine(getMin(numbers));
        //}

        //public static int GetMin(List<int> nums)
        //{
        //    int min = nums[0];

        //    for (int i = 1; i < nums.Count; i++)
        //    {
        //        if (min > nums[i])
        //        {
        //            min = nums[i];
        //        }
        //    }

        //    return min;
        //}
    }
}