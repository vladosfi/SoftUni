using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.Problem2
{
    class StartUp
    {
        static void Main(string[] args)
        {
            string[] vegetablesArray = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries);
            string cal = Console.ReadLine();
            int[] caloriesArray = new int[0];

            if (cal != string.Empty)
            {
                caloriesArray = cal.Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            }
            
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


            int saladCaloriesNeeded = 0;
            int caloriesLeft = 0;
            while (vegetables.Any() && calories.Any())
            {
                string currentVegetable = vegetables.Dequeue();

                if (!tableOfProducts.ContainsKey(currentVegetable))
                {
                    continue;
                }

                if (saladCaloriesNeeded <= 0)
                {
                    saladCaloriesNeeded = calories.Peek() - Math.Abs(caloriesLeft);
                }

                saladCaloriesNeeded -= tableOfProducts[currentVegetable];


                if (saladCaloriesNeeded <= 0)
                {
                    salads.Add(calories.Pop());
                    caloriesLeft = saladCaloriesNeeded;
                }
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
