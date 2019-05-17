using System;

namespace _02.OldBooks
{
    class OldBooks
    {
        static void Main()
        {
            string book = Console.ReadLine();
            int capacityOfLibrary = int.Parse(Console.ReadLine());
            string currentBook = "";
            int bookPassed = 0;

            do
            {
                currentBook = Console.ReadLine();
                bookPassed++;
            } while (book != currentBook && capacityOfLibrary > bookPassed);

            if (currentBook != book)
            {
                Console.WriteLine("The book you search is not here!");
                Console.WriteLine($"You checked {bookPassed} books."); 
            }
            else
            {
                Console.WriteLine($"You checked {bookPassed - 1} books and found it."); 
            }
        }
    }
}
