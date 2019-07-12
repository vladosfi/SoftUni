namespace PizzaCalories.Core
{
    using System;
    using System.Collections.Generic;
    using PizzaCalories.Model;
    using PizzaCalories.Model.Ingredient;


    public class Engine
    {
        public void Run()
        {
            string pizzaName = string.Empty;

            try
            {
                pizzaName = GetPizzaName();
            }
            catch (ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
            }

            try
            {
                string command = Console.ReadLine();
                string[] doughTokens = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string flourType = doughTokens[1];
                string bakingTechnique = doughTokens[2];
                double weight = double.Parse(doughTokens[3]);

                Dough dough = new Dough(flourType, bakingTechnique, weight);
                Pizza pizza = new Pizza(pizzaName, dough);

                command = Console.ReadLine();

                while (command != "END")
                {
                    string[] toppingTokens = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                    string toppingType = toppingTokens[1];
                    double weightTopping = double.Parse(toppingTokens[2]);
                    Topping topping = new Topping(toppingType, weightTopping);

                    pizza.AddTopping(topping);

                    command = Console.ReadLine();
                }

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

        private string GetPizzaName()
        {
            string[] pizzaInfo = Console.ReadLine().Split(" ");
            string pizzaName = pizzaInfo[1];
            return pizzaName;
        }
    }
}
