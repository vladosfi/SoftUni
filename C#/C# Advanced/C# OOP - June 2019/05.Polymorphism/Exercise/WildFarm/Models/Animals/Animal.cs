using System;
using System.Collections.Generic;
using WildFarm.Models.Foods;

namespace WildFarm.Models.Animals
{
    public abstract class Animal
    {
        public Animal(string name, double weight)
        {
            this.Name = name;
            this.Weight = weight;
            this.FoodEaten = 0;
        }

        public string Name { get; private set; }

        public double Weight{ get; protected set; }

        public int FoodEaten { get; protected set; }

        public abstract string ProduceSound();

        public abstract void Eat(Food food);

        protected void BaseEat(Food food, List<string> eatableFood, double increaseValue)
        {
            string foodType = food.GetType().Name;

            if (!eatableFood.Contains(foodType))
            {
                throw new ArgumentException($"{this.GetType().Name} does not eat {foodType}!");
            }

            this.Weight += food.Quantity * increaseValue;
            this.FoodEaten += food.Quantity;
        }

        public override string ToString()
        {
            return $"{this.GetType().Name} [{this.Name}, ";
        }
    }
}
