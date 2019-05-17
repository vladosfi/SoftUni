using System;

namespace _06.BalancedBrackets
{
    class BalancedBrackets
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            bool isBalanced = false;
            bool opened = false;
            bool closed = false;

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();

                if (input == "(" && isBalanced == false)
                {
                    isBalanced = true;
                }
                else if (input == ")" && isBalanced == false)
                {
                    break;
                }
                else if (input == ")" && isBalanced == true)
                {
                    isBalanced = false;
                }
            }

            if (isBalanced == true)
            {
                Console.WriteLine("BALANCED");
            }
            else
            {
                Console.WriteLine("UNBALANCED");
            }
        }
    }
}
