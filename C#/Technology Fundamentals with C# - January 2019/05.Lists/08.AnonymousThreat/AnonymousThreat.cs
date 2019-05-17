using System;
using System.Collections.Generic;
using System.Linq;

namespace _08.AnonymousThreat
{
    class AnonymousThreat
    {
        static void Main()
        {
            List<string> inputData = Console.ReadLine().Split().ToList();

            while (true)
            {
                string command = Console.ReadLine();

                if (command == "3:1")
                {
                    break;
                }

                string[] tokens = command.Split();
                string action = tokens[0];

                if (action == "merge")
                {
                    int startIndex = int.Parse(tokens[1]);
                    int endIndex = int.Parse(tokens[2]);

                    MergeData(startIndex, endIndex, inputData);

                }
                else if (action == "divide")
                {
                    int index = int.Parse(tokens[1]);
                    int partitions = int.Parse(tokens[2]);

                    DivideData(index, partitions, inputData);
                }
            }

            Console.WriteLine(string.Join(" ",inputData));
        }

        private static void DivideData(int index, int partitions, List<string> inputData)
        {
            string partitionData = inputData[index];
            inputData.RemoveAt(index);
            int partSize = partitionData.Length / partitions;
            int reminder = partitionData.Length % partitions;

            List<string> tmpData = new List<string>();

            for (int i = 0; i < partitions; i++)
            {
                string tmpString = null;

                for (int p = 0; p < partSize; p++)
                {
                    tmpString += partitionData[(i * partSize) + p];
                }

                if (i == partitions -1 && reminder != 0)
                {
                    tmpString += partitionData.Substring(partitionData.Length - reminder);
                }

                tmpData.Add(tmpString);
            }

            inputData.InsertRange(index, tmpData);

        }

        private static void MergeData(int startIndex, int endIndex, List<string> inputData)
        {
            if (startIndex > endIndex)
            {
                startIndex = 0;
            }

            if (startIndex < 0 || startIndex >= inputData.Count)
            {
                startIndex = 0;
            }

            if (endIndex >= inputData.Count)
            {
                endIndex = inputData.Count - 1;
            }



            string mergedData = null;

            for (int i = startIndex; i <= endIndex; i++)
            {
                mergedData += inputData[i];
            }

            int count = endIndex - startIndex;

            if (count >= inputData.Count)
            {
                count = inputData.Count - 2;
            }

            inputData.RemoveRange(startIndex, count+1);

            inputData.Insert(startIndex, mergedData);

        }
    }
}
