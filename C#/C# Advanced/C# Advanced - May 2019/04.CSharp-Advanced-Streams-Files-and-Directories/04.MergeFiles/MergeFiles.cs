using System;
using System.IO;

namespace _04.MergeFiles
{
    class MergeFiles
    {
        static void Main()
        {
            string path = "Resources";
            string filePath = Path.Combine(path, "Input1.txt");
            string filePathExpected = Path.Combine(path, "Input2.txt");
            string fileOutput = Path.Combine(path, "Output.txt");

            using (var readerFileOne = new StreamReader(filePath))
            {
                using (var readerFileTwo = new StreamReader(filePathExpected))
                {
                    using (var writer = new StreamWriter(fileOutput))
                    {
                        while (true)
                        {
                            string lineF1 = readerFileOne.ReadLine();
                            string lineF2 = readerFileTwo.ReadLine();

                            if (lineF1 != null)
                            {
                                writer.WriteLine(lineF1);
                            }

                            if (lineF2 != null)
                            {
                                writer.WriteLine(lineF2);
                            }

                            if (lineF1 == null && lineF2 == null)
                            {
                                break;
                            }
                        }
                    }
                }
            }
        }
    }
}
