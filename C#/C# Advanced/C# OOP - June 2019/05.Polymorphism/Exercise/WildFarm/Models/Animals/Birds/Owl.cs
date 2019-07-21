using System.Collections.Generic;
using WildFarm.Models.Foods;

namespace WildFarm.Models.Animals.Birds
{
    public class Owl : Bird
    {
        private const double IncreaseValue = 0.25;
        private List<string> allowedFood;

        public Owl(string name, double weight, double wingSize) 
            : base(name, weight, wingSize)
        {
        }

        public override string ProduceSound()
        {
            return "Hoot Hoot";
        }

        public override void Eat(Food food)
        {
            allowedFood = new List<string>()
            {
                nameof(Meat)
            };

            this.BaseEat(food, this.allowedFood, IncreaseValue);
        }
    }
}
