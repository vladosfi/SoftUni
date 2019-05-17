using System;

namespace _06.Cake
{
    class Cake
    {
        static void Main()
        {
            int cakeWidth = int.Parse(Console.ReadLine());
            int cakeLenght = int.Parse(Console.ReadLine());
            int cakeSize = cakeLenght * cakeWidth;
            int cakePieceLeft = cakeSize;
            string inputVal = "";
            int pice = 0;

            while (cakePieceLeft >= 0 && inputVal != "STOP")
            {
                inputVal = Console.ReadLine();

                if (int.TryParse(inputVal, out pice))
                {
                    cakePieceLeft = cakePieceLeft - pice;
                }
            }

            if (cakePieceLeft < 0)
            {
                Console.WriteLine($"No more cake left! You need {cakePieceLeft * -1} pieces more.");
            }
            else if (cakePieceLeft > 0)
            {
                Console.WriteLine($"{cakePieceLeft} pieces are left."); 
            }
        }
    }
}
