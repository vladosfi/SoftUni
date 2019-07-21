using System.Collections.Generic;
using WildFarm.Models.Foods;

namespace WildFarm.Models.Animals.Mammals
{
    public class Dog : Mammal
    {
        private const double IncreaseValue = 0.40;
        private List<string> allowedFood;

        public Dog(string name, double weight, string livingRegion) 
            : base(name, weight, livingRegion)
        {
        }

        public override string ProduceSound()
        {
            return "Woof!";
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
