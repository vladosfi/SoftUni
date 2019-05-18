using System;
using System.Collections.Generic;
using System.Linq;

namespace _12.InfernoIII
{
    class InfernoIII
    {
        static void Main()
        {
            Dictionary<string, Dictionary<int, Func<int, int, bool>>> filters = new Dictionary<string, Dictionary<int, Func<int, int, bool>>>();
            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();
            Action<List<int>> print = p => Console.WriteLine(string.Join(" ", p));

            string input = Console.ReadLine();

            while (input != "Forge")
            {
                string[] tokens = input.Split(";");

                string command = tokens[0];
                string functionName = tokens[1];
                int value = int.Parse(tokens[2]);

                Func<int, int, bool> sumFunc = GetFunction(numbers, functionName);

                if (command == "Exclude")
                {
                    if (!filters.ContainsKey(functionName))
                    {
                        filters.Add(functionName, new Dictionary<int, Func<int, int, bool>>());
                    }

                    if (!filters[functionName].ContainsKey(value))
                    {
                        filters[functionName].Add(value, sumFunc);
                    }
                }
                else
                {
                    if (filters.ContainsKey(functionName))
                    {
                        filters[functionName].Remove(value);
                    }
                }

                input = Console.ReadLine();
            }

            List<int> result = new List<int>();

            for (int i = 0; i < numbers.Count; i++)
            {
                bool isValid = true;

                foreach (var filter in filters)
                {
                    foreach (var kvp in filter.Value)
                    {
                        if (kvp.Value(i, kvp.Key))
                        {
                            isValid = false;
                            break;
                        }
                    }
                }

                if (isValid)
                {
                    result.Add(numbers[i]);
                }
            }

            print(result);

        }

        private static Func<int, int, bool> GetFunction(List<int> numbers, string functionName)
        {
            if (functionName == "Sum Left")
            {
                return (i, targetSum) => i == 0 ? numbers[i] == targetSum : numbers[i] + numbers[i - 1] == targetSum;
            }
            else if (functionName == "Sum Right")
            {
                return (i, targetSum) => i == numbers.Count - 1 ? numbers[i] == targetSum : numbers[i] + numbers[i + 1] == targetSum;
            }
            else if (functionName == "Sum Left Right")
            {
                return (i, targetSum) => numbers.Count == 1 ? numbers[i] == targetSum :
                    i == numbers.Count - 1 ? numbers[i - 1] + numbers[i] == targetSum :
                    i == 0 ? numbers[i] + numbers[i + 1] == targetSum :
                    numbers[i - 1] + numbers[i] + numbers[i + 1] == targetSum;
            }

            return null;
        }
    }
}
