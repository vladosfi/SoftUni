using System;
using System.IO;

namespace _2.LineNumbers
{
    class LineNumbers
    {
        static void Main()
        {
            using (var reader = new StreamReader(@"Resources\text.txt"))
            {
                int counter = 1;
                using (var writer = new StreamWriter(@"Resources\out-text.txt"))
                {
                    while (true)
                    {
                        var line = reader.ReadLine();

                        if (line == null)
                        {
                            break;
                        }

                        int letterCount = 0;
                        int punctuationCount = 0;

                        foreach (var symbol in line)
                        {
                            if (char.IsLetter(symbol))
                            {

                                letterCount++;
                            }
                            if (char.IsPunctuation(symbol))
                            {

                                punctuationCount++;
                            }
                        }

                        line = $"Line {counter}: {line} ({letterCount})({punctuationCount})";
                        Console.WriteLine(line);
                        writer.WriteLine(line);

                        counter++;
                    }
                }
            }
        }
    }
}

