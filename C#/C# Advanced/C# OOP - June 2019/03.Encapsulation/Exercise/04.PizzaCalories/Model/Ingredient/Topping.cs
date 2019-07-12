namespace PizzaCalories.Model.Ingredient
{
    using System;
    using System.Collections.Generic;
    using PizzaCalories.Exceptions;

    public class Topping
    {
        private double weight;
        private string toppingType;
        private const int baseCaloriesPerGram = 2;

        private Dictionary<string, double> validToppingType;

        public Topping(string toppingType, double weight)
        {
            this.validToppingType = new Dictionary<string, double>();
            this.SeedToppingType();
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
                if (!this.validToppingType.ContainsKey(value.ToLower()))
                {
                    throw new InvalidOperationException(
                        string.Format(ExceptionMessages.InvalidTypeOfToppingException, value));
                }

                this.toppingType = value; 
            }
        }

        public double Weight
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

        public double CalculateCalories()
        {
            return (baseCaloriesPerGram * this.Weight) * this.validToppingType[this.ToppingType.ToLower()];
        }

        private void SeedToppingType()
        {
            this.validToppingType.Add("meat", 1.2);
            this.validToppingType.Add("veggies", 0.8);
            this.validToppingType.Add("cheese", 1.1);
            this.validToppingType.Add("sauce", 0.9);
        }
    }
}
