using System.Collections.Generic;
using WildFarm.Models.Foods;

namespace WildFarm.Models.Animals.Mammals.Felines
{
    public class Cat : Feline
    {
        private const double IncreaseValue = 0.30;
        private List<string> allowedFood;

        public Cat(string name, double weight, string livingRegion, string breed) 
            : base(name, weight, livingRegion, breed)
        {
        }

        public override string ProduceSound()
        {
            return "Meow";
        }

        public override void Eat(Food food)
        {
            allowedFood = new List<string>()
            {
                nameof(Vegetable),
                nameof(Meat)
            };

            this.BaseEat(food, this.allowedFood, IncreaseValue);
        }
    }
}
