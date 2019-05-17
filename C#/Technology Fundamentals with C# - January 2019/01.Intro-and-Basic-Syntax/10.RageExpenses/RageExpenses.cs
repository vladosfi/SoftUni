using System;
using System.Threading;

namespace _10.RageExpenses
{
    class RageExpenses
    {
        static void Main()
        {
            Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.InvariantCulture;

            int lostGamesCount = int.Parse(Console.ReadLine());
            decimal headsetPrice = decimal.Parse(Console.ReadLine());
            decimal mousePrice = decimal.Parse(Console.ReadLine());
            decimal keyboardPrice = decimal.Parse(Console.ReadLine());
            decimal displayPrice = decimal.Parse(Console.ReadLine());
            decimal expenses = 0;

            headsetPrice *= Math.Floor(lostGamesCount / 2m);
            mousePrice *= Math.Floor(lostGamesCount / 3m);
            keyboardPrice *= Math.Floor(lostGamesCount / 6m);
            displayPrice *= Math.Floor(lostGamesCount / 12m);

            expenses = headsetPrice + mousePrice + keyboardPrice + displayPrice;

            Console.WriteLine($"Rage expenses: {expenses:F02} lv.");

        }
    }
}
