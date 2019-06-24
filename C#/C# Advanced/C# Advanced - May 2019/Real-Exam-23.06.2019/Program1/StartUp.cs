using System;
using System.Collections.Generic;
using System.Linq;

namespace Program1
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int[] chemicalLiquidsArray = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int[] physicalItemsArray = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Queue<int> chemicalLiquids = new Queue<int>(chemicalLiquidsArray);
            Stack<int> physicalItems = new Stack<int>(physicalItemsArray);

            Dictionary<string, int> advancedMaterials = new Dictionary<string, int>();
            advancedMaterials.Add("Glass", 0);
            advancedMaterials.Add("Aluminium", 0);
            advancedMaterials.Add("Lithium", 0);
            advancedMaterials.Add("Carbon fiber", 0);

            while (chemicalLiquids.Count > 0 && physicalItems.Count > 0)
            {
                int liquid = chemicalLiquids.Peek();
                int item = physicalItems.Peek();

                int sumOfMaterials = liquid + item;

                if (sumOfMaterials == 25)
                {
                    advancedMaterials["Glass"] += 1;
                    chemicalLiquids.Dequeue();
                    physicalItems.Pop();
                }
                else if (sumOfMaterials == 50)
                {
                    advancedMaterials["Aluminium"] += 1;
                    chemicalLiquids.Dequeue();
                    physicalItems.Pop();
                }
                else if (sumOfMaterials == 75)
                {
                    advancedMaterials["Lithium"] += 1;
                    chemicalLiquids.Dequeue();
                    physicalItems.Pop();
                }
                else if (sumOfMaterials == 100)
                {
                    advancedMaterials["Carbon fiber"] += 1;
                    chemicalLiquids.Dequeue();
                    physicalItems.Pop();
                }
                else
                {
                    chemicalLiquids.Dequeue();
                    physicalItems.Pop();
                    physicalItems.Push(item + 3);
                }
            }


            if (advancedMaterials.Where(m => m.Value > 0).Count() >= 4)
            {
                Console.WriteLine("Wohoo! You succeeded in building the spaceship!");
            }
            else
            {
                Console.WriteLine("Ugh, what a pity! You didn't have enough materials to build the spaceship.");
            }

            if (chemicalLiquids.Count > 0)
            {
                Console.WriteLine("Liquids left: " + string.Join(", ", chemicalLiquids));
            }
            else
            {
                Console.WriteLine("Liquids left: none");
            }

            if (physicalItems.Count > 0)
            {
                Console.WriteLine("Physical items left: " + string.Join(", ", physicalItems));
            }
            else
            {
                Console.WriteLine("Physical items left: none");
            }

            foreach (var material in advancedMaterials.OrderBy(n => n.Key))
            {
                Console.WriteLine($"{material.Key}: {material.Value}");
            }
        }
    }
}
