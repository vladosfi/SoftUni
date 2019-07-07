namespace CustomStack
{
    using System;

    public class StartUp
    {
        static void Main()
        {
            StackOfStrings stringStack = new StackOfStrings();

            Console.WriteLine(stringStack.IsEmpty());
            stringStack.AddRange("1", "2", "8", "3", "6", "3");
            Console.WriteLine(stringStack.IsEmpty());

            foreach (var element in stringStack)
            {
                Console.WriteLine(element);
            }
        }
    }
}
