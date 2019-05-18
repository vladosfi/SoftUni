using System;
using System.Collections.Generic;
using System.Linq;

namespace _09.SimpleTextEditor
{
    class SimpleTextEditor
    {
        static void Main()
        {
            int commandsCount = int.Parse(Console.ReadLine());

            string text = string.Empty;

            Stack<string> stack = new Stack<string>();

            for (int i = 0; i < commandsCount; i++)
            {
                string[] tockens = Console.ReadLine()
                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                int command = int.Parse(tockens[0]);

                switch (command)
                {
                    case 1:
                        string charactersForAdd = tockens[1];
                        text += charactersForAdd;
                        stack.Push(text);
                        break;
                    case 2:
                        int charsForErase = int.Parse(tockens[1]); ;
                        text = text.Substring(0, text.Length - charsForErase);
                        stack.Push(text);
                        break;
                    case 3:
                        int index = int.Parse(tockens[1]);
                        Console.WriteLine(text[index - 1]);
                        break;
                    case 4:
                        if (stack.Any())
                        {
                            stack.Pop();
                        }
                        else
                        {
                            text = null;
                        }

                        if (stack.Any())
                        {
                            text = stack.Peek();
                        }
                        else
                        {
                            text = null;
                        }

                        break;
                }
            }
        }
    }
}
