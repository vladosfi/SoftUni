using System;
using System.Collections.Generic;
using WildFarm.Models.Foods;

namespace WildFarm.Models.Animals.Mammals
{
    public class Mouse : Mammal
    {
        private const double IncreaseValue = 0.10;
        private List<string> allowedFood; 

        public Mouse(string name, double weight, string livingRegion)
            : base(name, weight, livingRegion)
        {            
        }
        
        public override string ProduceSound()
        {
            return "Squeak";
        }

        public override void Eat(Food food)
        {
            allowedFood = new List<string>() { nameof(Vegetable), nameof(Fruit) };

            this.BaseEat(food, this.allowedFood, IncreaseValue);
        }
    }
}
