using System;
using System.Collections.Generic;
using System.Text;

namespace _09.SimpleTextEditor
{
    class SimpleTextEditor
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            StringBuilder text = new StringBuilder();
            Stack<string> history = new Stack<string>();

            for (int i = 0; i < n; i++)
            {
                string[] tokens = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string command = tokens[0];

                if (command == "1")
                {
                    history.Push(text.ToString());
                    text.Append(tokens[1]);
                }
                else if (command == "2")
                {
                    history.Push(text.ToString());
                    int index = int.Parse(tokens[1]);
                    text.Remove(text.Length - index, index);
                }
                else if (command == "3")
                {
                    int index = int.Parse(tokens[1]);
                    Console.WriteLine(text[index - 1]);
                }
                else if (command == "4")
                {
                    if (history.Count > 0)
                    {
                        text.Clear();
                        text.Append(history.Pop());
                    }
                }
            }
        }
    }
}
