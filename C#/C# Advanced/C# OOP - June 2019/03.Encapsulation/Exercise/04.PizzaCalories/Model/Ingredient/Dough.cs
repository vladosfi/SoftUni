
using PizzaCalories.Exceptions;
using System;

namespace PizzaCalories.Model.Ingredient
{
    public class Dough
    {
        private int weight;
        private string flourType;
        private string bakingTechnique;
        private const double caloriesPerGram = 2;
        private const double whiteModifier = 1.5;
        private const double wholegrainModifier = 1.0;
        private const double crispyModifier = 0.9;
        private const double chewyModifier = 1.1;
        private const double homemadeModifier = 1.0;

        public Dough()
        {

        }

        public Dough(string flourType, string bakingTechnique, int weight)
        {
            this.FlourType = flourType;
            this.BakingTechnique = bakingTechnique;
            this.Weight = weight;
        }

        public string FlourType
        {
            get
            {
                return this.flourType;
            }
            private set
            {
                if (!Enum.TryParse(value.ToLower(), out FlourType validFlourType))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidTypeOfDoughException);
                }

                this.flourType = value;
            }
        }


        public string BakingTechnique
        {
            get
            {
                return this.bakingTechnique;
            }
            private set
            {
                if (!Enum.TryParse(value.ToLower(), out BakingTechnique validBakingTechnique))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidTypeOfDoughException);
                }

                this.bakingTechnique = value;
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
                if (value < 1 || value > 200)
                {
                    throw new ArgumentException(ExceptionMessages.DoughWeightOutOfRangeException);
                }

                this.weight = value;
            }
        }

        public double TotalCalories()
        {
            double totalCalories = (caloriesPerGram * this.Weight);

            switch (this.FlourType.ToLower())
            {
                case "white":
                    totalCalories *= whiteModifier;
                    break;
                case "wholegrain":
                    totalCalories *= wholegrainModifier;
                    break;
                default:
                    break;
            }

            switch (this.BakingTechnique.ToLower())
            {
                case "crispy":
                    totalCalories *= crispyModifier;
                    break;
                case "chewy":
                    totalCalories *= chewyModifier;
                    break;
                case "homemade":
                    totalCalories *= homemadeModifier;
                    break;
                default:
                    break;
            }

            return totalCalories;
        }
    }
}
