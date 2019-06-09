using System;

namespace DefiningClasses
{
    class StartUp
    {
        static void Main()
        {
            string dayOne = Console.ReadLine();
            string dayTwo = Console.ReadLine();

            DateModifier dateDiff = new DateModifier();

            Console.WriteLine(dateDiff.GetDifferenceInDays(dayOne, dayTwo));
        }
    }
}
