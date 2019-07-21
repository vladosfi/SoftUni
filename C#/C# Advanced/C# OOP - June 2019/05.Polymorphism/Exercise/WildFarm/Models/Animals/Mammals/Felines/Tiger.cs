using System.Collections.Generic;
using WildFarm.Models.Foods;

namespace WildFarm.Models.Animals.Mammals.Felines
{
    public class Tiger : Feline
    {
        private const double IncreaseValue = 1.00;
        private List<string> allowedFood;

        public Tiger(string name, double weight, string livingRegion, string breed) 
            : base(name, weight, livingRegion, breed)
        {
        }

        public override string ProduceSound()
        {
            return "ROAR!!!";
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
