using System;

namespace _08.CookieFactory
{
    class CookieFactory
    {
        static void Main()
        {
            int batchNumber = int.Parse(Console.ReadLine());
            string foodstuffs = "";
            bool flour, eggs, sugar;

            for (int i = 1; i <= batchNumber; i++)
            {
                flour = false;
                eggs = false;
                sugar = false;

                while (true)
                {
                    foodstuffs = Console.ReadLine();

                    if (foodstuffs == "Bake!" && flour == true && eggs == true && sugar == true)
                    {
                        Console.WriteLine($"Baking batch number {i}...");
                        break;
                    }
                    else if (foodstuffs == "Bake!")
                    {
                        Console.WriteLine("The batter should contain flour, eggs and sugar!");
                    }

                    if (foodstuffs == "flour")
                    {
                        flour = true;
                    }
                    else if (foodstuffs == "eggs")
                    {
                        eggs = true;
                    }
                    else if (foodstuffs == "sugar")
                    {
                        sugar = true;
                    }
                }
            }


        }
    }
}
