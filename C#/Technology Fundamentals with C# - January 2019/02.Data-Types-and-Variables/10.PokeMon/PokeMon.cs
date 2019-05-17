using System;

namespace _10.PokeMon
{
    class PokeMon
    {
        static void Main()
        {
            int pokePower = int.Parse(Console.ReadLine());
            int distance = int.Parse(Console.ReadLine());
            int exhaustionFactor = int.Parse(Console.ReadLine());
            int originalPokePower = pokePower;
            int halfPokePower = 0;
            int countPokes = 0;

            if (pokePower % 2 == 0)
            {
                halfPokePower = originalPokePower / 2;
            }
            

            while (true)
            {
                if (pokePower == halfPokePower && exhaustionFactor != 0)
                {
                    pokePower /= exhaustionFactor;
                }

                if (pokePower < distance)
                {
                    break;
                }

                countPokes++;
                pokePower -= distance;
            }

            Console.WriteLine(pokePower);
            Console.WriteLine(countPokes);
        }
    }
}
