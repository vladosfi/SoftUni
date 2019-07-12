namespace PizzaCalories.Core
{
    using System;
    using System.Collections.Generic;
    using PizzaCalories.Model;
    using PizzaCalories.Model.Ingredient;


    public class Engine
    {
        List<Topping> toppings;

        public Engine()
        {
            toppings = new List<Topping>();
        }

        public void Run()
        {
            try
            {
                string[] pizzaInfo = Console.ReadLine().Split(" ");
                string pizzaName = pizzaInfo[1];

                string inputTokens = Console.ReadLine();
                Dough dough = new Dough();

                while (inputTokens != "END")
                {
                    string[] commandTokens = inputTokens.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                    string ingredientName = commandTokens[0];

                    if (ingredientName == "Dough")
                    {
                        string flourType = commandTokens[1];
                        string bakingTechnique = commandTokens[2];
                        int weight = int.Parse(commandTokens[3]);

                        dough = new Dough(flourType, bakingTechnique, weight);
                    }
                    else if (ingredientName == "Topping")
                    {
                        string toppingType = commandTokens[1];
                        int weight = int.Parse(commandTokens[2]);

                        Topping topping = new Topping(toppingType, weight);

                        toppings.Add(topping);
                    }

                    inputTokens = Console.ReadLine();
                }

                Pizza pizza = new Pizza(pizzaName, dough, toppings);

                Console.WriteLine(pizza);
            }
            catch (InvalidOperationException ioe)
            {
                Console.WriteLine(ioe.Message);
            }
            catch (ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
            }
        }
    }
}
