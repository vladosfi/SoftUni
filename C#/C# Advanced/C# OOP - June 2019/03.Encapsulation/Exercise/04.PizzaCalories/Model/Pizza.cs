using PizzaCalories.Exceptions;
using PizzaCalories.Model.Ingredient;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PizzaCalories.Model
{
    public class Pizza
    {
        private string name;
        private Dough dough;
        private List<Topping> toppings;

        public Pizza(string name, Dough dough, List<Topping> toppings)
        {
            this.Name = name;
            this.Dough = dough;
            this.Toppings = toppings;
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidPizzaNameException);
                }

                this.name = value;
            }
        }

        public Dough Dough
        {
            get
            {
                return this.dough;
            }

            private set
            {
                this.dough = value;
            }
        }

        public List<Topping> Toppings
        {
            get
            {
                return this.toppings;
            }
            private set
            {
                if (value.Count > 10)
                {
                    throw new ArgumentException(ExceptionMessages.ToppingOutOfRangeException);
                }

                this.toppings = new List<Topping>(value);
            }
        }

        private int numberOfToppings => this.toppings.Count;

        private double TotalCalories 
            => this.dough.TotalCalories() + this.toppings.Sum(t => t.TotalCalories());

        public override string ToString()
        {
            return $"{this.Name} - {this.TotalCalories:f2} Calories.";
        }
    }
}
