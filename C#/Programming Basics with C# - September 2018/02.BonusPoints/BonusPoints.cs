using System;

namespace _02.BonusPoints
{
    class BonusPoints
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            double bonusPoints = 0;
            string lastNumber="";

            if (number <= 100)
            {
                bonusPoints = 5;
            }
            else if (number <= 1000)
            {
                bonusPoints = (double)(number * 0.2);
            }
            else
            {
                bonusPoints = (double)(number * 0.1);
            }

            if(number % 2 == 0)
            {
                bonusPoints = bonusPoints + 1;
            }

            lastNumber = number.ToString();

            if (lastNumber[lastNumber.Length-1] == '5')
            {
                bonusPoints = bonusPoints + 2;
            }

            Console.WriteLine(bonusPoints);
            Console.WriteLine(number + bonusPoints);
        }
    }
}
