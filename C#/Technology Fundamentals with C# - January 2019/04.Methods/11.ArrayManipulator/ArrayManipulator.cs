using System;
using System.Linq;

//0 0 0 0
//last 1 even
namespace _11.ArrayManipulator
{
    class ArrayManipulator
    {
        static void Main()
        {
            int[] array = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "end")
                {
                    break;
                }

                if (array.Length == 0)
                {
                    continue;
                }

                string[] tockens = input.Split();

                if (tockens[0] == "exchange")
                {
                    int index = int.Parse(tockens[1]);
                    if (index >= 0 && index < array.Length)
                    {
                        ExchangeArrayElements(array, index);
                    }
                    else
                    {
                        Console.WriteLine("Invalid index");
                    }
                }
                else if (tockens[0] == "max")
                {
                    string evenOrOdd = tockens[1];
                    int index = GetMaxEvenOrOdd(evenOrOdd, array);
                    if (index != -1)
                    {
                        Console.WriteLine(index);
                    }
                    else
                    {
                        Console.WriteLine("No matches");
                    }
                }
                else if (tockens[0] == "min")
                {
                    string evenOrOdd = tockens[1];
                    int index = GetMinEvenOrOdd(evenOrOdd, array);
                    if (index != -1)
                    {
                        Console.WriteLine(index);
                    }
                    else
                    {
                        Console.WriteLine("No matches");
                    }
                }
                else if (tockens[0] == "first")
                {
                    string evenOrOdd = tockens[2];
                    int count = int.Parse(tockens[1]);
                    
                    if (count > 0 && count <= array.Length)
                    {
                        int[] first = FirstCountElements(array, count, evenOrOdd);

                        if (first.Length > 0)
                        {
                            Console.WriteLine("[" + string.Join(", ", first) + "]");
                        }
                        else
                        {
                            Console.WriteLine("[]");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid count");
                    }
                }
                else if (tockens[0] == "last")
                {
                    string evenOrOdd = tockens[2];
                    int count = int.Parse(tockens[1]);

                    if (count > 0 && count <= array.Length)
                    {
                        int[] last = LastCountElements(array, count, evenOrOdd);

                        if (last.Length > 0)
                        {
                            Console.WriteLine("[" + string.Join(", ", last) + "]");
                        }
                        else
                        {
                            Console.WriteLine("[]");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid count");
                    }
                }
            }

            Console.WriteLine("[" + string.Join(", ", array) + "]");
        }

        private static int[] LastCountElements(int[] array, int count, string evenOrOdd)
        {
            int[] lastCountElements = new int[0];
            int[] tmpArray = new int[0];
            int satisfyElementCounter = -1;

            for (int i = array.Length - 1; i >= 0 && count > 0; i--)
            {
                if (evenOrOdd == "even" && array[i] % 2 == 0)
                {
                    satisfyElementCounter++;
                    lastCountElements = tmpArray;
                    tmpArray = new int[satisfyElementCounter + 1];
                    CopyArray(lastCountElements, tmpArray);
                    tmpArray[satisfyElementCounter] = array[i];
                    lastCountElements = tmpArray;
                    count--;
                }
                else if (evenOrOdd == "odd" && array[i] % 2 != 0)
                {
                    satisfyElementCounter++;
                    lastCountElements = tmpArray;
                    tmpArray = new int[satisfyElementCounter + 1];
                    CopyArray(lastCountElements, tmpArray);
                    tmpArray[satisfyElementCounter] = array[i];
                    lastCountElements = tmpArray;
                    count--;
                }
            }

            ReverseArray(lastCountElements);
            return lastCountElements;
        }

        private static void ReverseArray(int[] lastCountElements)
        {
            int[] tmpArray = new int[lastCountElements.Length];
            CopyArray(lastCountElements, tmpArray);

            for (int i = 0; i < tmpArray.Length; i++)
            {
                lastCountElements[i] = tmpArray[tmpArray.Length - i - 1];
            }
        }

        private static int[] FirstCountElements(int[] array, int count, string evenOrOdd)
        {
            int[] firstCountElements= new int[0];
            int[] tmpArray = new int[0];
            int satisfyElementCounter = -1;

            for (int i = 0; i < array.Length && count > 0; i++)
            {
                if (evenOrOdd == "even" && array[i] % 2 == 0)
                {
                    satisfyElementCounter++;
                    firstCountElements = tmpArray;
                    tmpArray = new int[satisfyElementCounter + 1];
                    CopyArray(firstCountElements, tmpArray);
                    tmpArray[satisfyElementCounter] = array[i];
                    firstCountElements = tmpArray;
                    count--;
                }
                else if (evenOrOdd == "odd" && array[i] % 2 != 0)
                {
                    satisfyElementCounter++;
                    firstCountElements = tmpArray;
                    tmpArray = new int[satisfyElementCounter + 1];
                    CopyArray(firstCountElements, tmpArray);
                    tmpArray[satisfyElementCounter] = array[i];
                    firstCountElements = tmpArray;
                    count--;
                }
            }
            
            return firstCountElements;
        }

        private static void CopyArray(int[] firstCountElements, int[] tmpArray)
        {
            for (int j = 0; j < firstCountElements.Length; j++)
            {
                tmpArray[j] = firstCountElements[j];
            }
        }

        private static int GetMinEvenOrOdd(string evenOrOdd, int[] array)
        {
            int min = int.MaxValue;
            int minIndex = -1;

            if (evenOrOdd == "even")
            {
                for (int i = 0; i < array.Length; i++)
                {
                    if (array[i] % 2 == 0 && min >= array[i])
                    {
                        min = array[i];
                        minIndex = i;
                    }
                }
            }
            else
            {
                for (int i = 0; i < array.Length; i++)
                {
                    if (array[i] % 2 != 0 && min >= array[i])
                    {
                        min = array[i];
                        minIndex = i;
                    }
                }
            }

            return minIndex;
        }

        private static int GetMaxEvenOrOdd(string evenOrOdd, int[] array)
        {
            int max = int.MinValue;
            int maxIndex = -1;

            if (evenOrOdd == "even")
            {
                for (int i = 0; i < array.Length; i++)
                {
                    if (array[i] %2 == 0 && max <= array[i])
                    {
                        max = array[i];
                        maxIndex = i;
                    }
                }
            }
            else
            {
                for (int i = 0; i < array.Length; i++)
                {
                    if (array[i] % 2 != 0 && max <= array[i])
                    {
                        max = array[i];
                        maxIndex = i;
                    }
                }
            }

            return maxIndex;
        }

        private static void ExchangeArrayElements(int[] array, int index)
        {
            while (index >= 0)
            {
                int firstIndex = array[0];
                for (int i = 0; i < array.Length - 1; i++)
                {
                    array[i] = array[i + 1];
                }
                array[array.Length - 1] = firstIndex;
                index--;
            }
        }
    }
}
