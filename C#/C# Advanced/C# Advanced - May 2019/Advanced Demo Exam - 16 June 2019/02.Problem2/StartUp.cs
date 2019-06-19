using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.Problem2
{
    class StartUp
    {
        static void Main(string[] args)
        {
            string[] vegetablesArray = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            int[] caloriesArray = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            Queue<string> vegetables = new Queue<string>();
            Stack<int> calories = new Stack<int>();

            if (vegetablesArray.Length > 0)
            {
                vegetables = new Queue<string>(vegetablesArray);
            }
            if (vegetablesArray.Length > 0)
            {
                calories = new Stack<int>(caloriesArray);
            }

            List<int> salads = new List<int>();

            Dictionary<string, int> tableOfProducts = new Dictionary<string, int>
            {
                ["tomato"] = 80,
                ["carrot"] = 136,
                ["lettuce"] = 109,
                ["potato"] = 215
            };

            while (vegetables.Any() && calories.Any())
            {

                int saladCaloriesNeeded = calories.Peek();

                while (vegetables.Any() && saladCaloriesNeeded > 0)
                {
                    string currentVegetable = vegetables.Dequeue();

                    if (!tableOfProducts.ContainsKey(currentVegetable))
                    {
                        continue;
                    }

                    saladCaloriesNeeded -= tableOfProducts[currentVegetable];
                }

                salads.Add(calories.Pop());
            }

            if (salads.Count > 0)
            {
                Console.WriteLine(string.Join(" ", salads));
            }

            if (vegetables.Any())
            {
                Console.WriteLine(string.Join(" ", vegetables));
            }
            else if (calories.Any())
            {
                Console.WriteLine(string.Join(" ", calories));
            }
        }
    }
}
