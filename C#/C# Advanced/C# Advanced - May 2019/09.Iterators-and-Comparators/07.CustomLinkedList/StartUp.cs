using System;

namespace CustomLinkedList
{
    class StartUp
    {
        static void Main()
        {
            var doublyLinkedList = new DoublyLinkedList<string>();

            doublyLinkedList.AddFirst("asdf");
            doublyLinkedList.AddFirst("123");
            doublyLinkedList.AddFirst("asddaaa");

            Console.WriteLine(doublyLinkedList.Contains("123"));

            foreach (var item in doublyLinkedList)
            {
                Console.WriteLine(item);
            }
        }
    }
}
