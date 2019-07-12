

namespace PizzaCalories.Model
{
    using PizzaCalories.Exceptions;
    using PizzaCalories.Model.Ingredient;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Pizza
    {
        private string name;
        private Dough dough;
        private List<Topping> toppings;

        public Pizza(string name, Dough dough)
        {
            this.Name = name;
            this.dough = dough;
            this.toppings = new List<Topping>();
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                if (value.Length < 1 || value.Length > 15)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidPizzaNameException);
                }

                this.name = value;
            }
        }

        public void AddTopping(Topping topping)
        {
            if (this.ToppingCount > 10)
            {
                throw new ArgumentException(ExceptionMessages.ToppingOutOfRangeException);
            }

            this.toppings.Add(topping);
        }

        public int ToppingCount => this.toppings.Count;

        private double TotalCalories
            => this.dough.CalculateCalories() + this.toppings.Sum(t => t.CalculateCalories());

        public override string ToString()
        {
            return $"{this.Name} - {this.TotalCalories:f2} Calories.";
        }
    }
}
