using PizzaCalories.Exceptions;
using System;

namespace PizzaCalories.Model.Ingredient
{
    public class Topping
    {
        private int weight;
        private string toppingType;
        private const int baseCaloriesPerGram = 2;
        private const double meatModifier = 1.2;
        private const double veggiesModifier = 0.8;
        private const double cheeseModifier = 1.1;
        private const double sauceModifier = 0.9;


        public Topping(string toppingType, int weight)
        {
            this.ToppingType = toppingType;
            this.Weight = weight;
        }

        public string ToppingType
        {
            get
            {
                return this.toppingType;
            }
            private set
            {
                if (!Enum.TryParse(value.ToLower(), out ToppingType validToppingType))
                {
                    throw new InvalidOperationException(
                        string.Format(ExceptionMessages.InvalidTypeOfToppingException, value));
                }

                this.toppingType = value;
            }
        }
        public int Weight
        {
            get
            {
                return this.weight;
            }
            private set
            {
                if (value < 1 || value > 50)
                {
                    throw new InvalidOperationException(
                        string.Format(ExceptionMessages.InvalidValueOfToppingWeightException, this.toppingType));
                }

                this.weight = value;
            }
        }


        public double TotalCalories()
        {
            double totalCalories = (baseCaloriesPerGram * this.Weight);

            switch (this.ToppingType.ToLower())
            {
                case "meat":
                    totalCalories *= meatModifier;
                    break;
                case "veggies":
                    totalCalories *= veggiesModifier;
                    break;
                case "cheese":
                    totalCalories *= cheeseModifier;
                    break;
                case "sauce":
                    totalCalories *= sauceModifier;
                    break;
                default:
                    break;
            }

            return totalCalories;
        }
    }
}
