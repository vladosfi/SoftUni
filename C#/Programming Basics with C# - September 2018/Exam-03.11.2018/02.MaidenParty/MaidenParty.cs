using System;

namespace _02.MaidenParty
{
    class MaidenParty
    {
        static void Main()
        {
            decimal maidenPartyPrice = decimal.Parse(Console.ReadLine());
            decimal loveMessage = decimal.Parse(Console.ReadLine());
            decimal waxRoses = decimal.Parse(Console.ReadLine());
            decimal keyChains = decimal.Parse(Console.ReadLine());
            decimal cartoons = decimal.Parse(Console.ReadLine());
            decimal luckSurprise = decimal.Parse(Console.ReadLine());
            bool discount = false;
            decimal totalProfit = 0;

            if (loveMessage + waxRoses + keyChains + cartoons + luckSurprise >= 25)
            {
                discount = true;
            }

            loveMessage = loveMessage * 0.6m;
            waxRoses = waxRoses * 7.2m;
            keyChains = keyChains * 3.6m;
            cartoons = cartoons * 18.2m;
            luckSurprise = luckSurprise * 22m;

            totalProfit = loveMessage + waxRoses + keyChains + cartoons + luckSurprise;

            if (discount)
            {
                totalProfit = totalProfit - (totalProfit * 0.35m);
            }

            totalProfit = totalProfit - (totalProfit * 0.1m);

            if (totalProfit >= maidenPartyPrice)
            {
                Console.WriteLine($"Yes! {totalProfit - maidenPartyPrice:f02} lv left.");   
            }
            else
            {
                Console.WriteLine($"Not enough money! {maidenPartyPrice - totalProfit:f02} lv needed.");
            }

        }
    }
}
