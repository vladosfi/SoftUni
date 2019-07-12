namespace PizzaCalories.Model.Ingredient
{
    using System;
    using System.Collections.Generic;
    using PizzaCalories.Exceptions;

    public class Dough
    {
        private double weight;
        private string flourType;
        private string bakingTechnique;
        private const double caloriesPerGram = 2;

        private Dictionary<string, double> validFlourTypes;
        private Dictionary<string, double> validBakingTechnique;

        public Dough(string flourType, string bakingTechnique, double weight)
        {
            this.validFlourTypes = new Dictionary<string, double>();
            this.validBakingTechnique = new Dictionary<string, double>();
            this.SeedFlourTypes();
            this.SeedBakingTechniques();

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
                if (!this.validFlourTypes.ContainsKey(value.ToLower()))
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
                if (!this.validBakingTechnique.ContainsKey(value.ToLower()))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidTypeOfDoughException);
                }

                this.bakingTechnique = value;
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
                if (value < 1 || value > 200)
                {
                    throw new ArgumentException(ExceptionMessages.DoughWeightOutOfRangeException);
                }

                this.weight = value;
            }
        }

        public double CalculateCalories()
        {
            double totalCalories = (caloriesPerGram * this.Weight);
            totalCalories *= this.validFlourTypes[this.FlourType.ToLower()];
            totalCalories *= this.validBakingTechnique[this.BakingTechnique.ToLower()];

            return totalCalories;
        }

        private void SeedFlourTypes()
        {
            this.validFlourTypes.Add("white", 1.5);
            this.validFlourTypes.Add("wholegrain", 1.0);
        }

        private void SeedBakingTechniques()
        {
            this.validBakingTechnique.Add("crispy", 0.9);
            this.validBakingTechnique.Add("chewy", 1.1);
            this.validBakingTechnique.Add("homemade", 1.0);
        }
    }
}
