namespace CustomStack
{
    using System.Collections.Generic;
    using System.Linq;

    public class StackOfStrings : Stack<string>
    {
        public bool IsEmpty()
        {
            return !this.Any();
        }

        public Stack<string> AddRange(params string[] elements)
        {
            foreach (var element in elements)
            {
                this.Push(element);
            }

            return this;
        }
    }
}
