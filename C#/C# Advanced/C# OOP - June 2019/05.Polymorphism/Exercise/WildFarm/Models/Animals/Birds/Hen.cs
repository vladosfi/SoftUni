using System.Collections.Generic;
using WildFarm.Models.Foods;

namespace WildFarm.Models.Animals.Birds
{
    public class Hen : Bird
    {
        private const double IncreaseValue = 0.35;
        private List<string> allowedFood;

        public Hen(string name, double weight, double wingSize)
            : base(name, weight, wingSize)
        {
        }

        public override string ProduceSound()
        {
            return "Cluck";
        }

        public override void Eat(Food food)
        {
            allowedFood = new List<string>()
            {
                nameof(Vegetable),
                nameof(Fruit),
                nameof(Meat),
                nameof(Seeds)

            };

            this.BaseEat(food, this.allowedFood, IncreaseValue);
        }
    }
}
