using System;
using System.Collections.Generic;
using System.Threading;
using WildFarm.Models.Animals;
using WildFarm.Models.Foods;

namespace WildFarm
{
    public class StartUp
    {
        static void Main()
        {
            Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.InvariantCulture;
            string input = Console.ReadLine();
            List<Animal> animals = new List<Animal>();

            while (input != "End")
            {
                string[] animalInfo = input.Split();
                input = Console.ReadLine();

                Animal animal = AnimalFactory.Create(animalInfo);
                animals.Add(animal);

                string[] foodInfo = input.Split();
                int foodQuantity = int.Parse(foodInfo[1]);

                Food food = FoodFactory.Create(foodInfo);

                Console.WriteLine(animal.ProduceSound());

                try
                {
                    animal.Eat(food);
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }

                input = Console.ReadLine();
            }

            foreach (var animal in animals)
            {
                Console.WriteLine(animal);
            }
        }
    }
}
