﻿namespace HealthyHeaven
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Salad
    {
        public string Name { get; private set; }
        private List<Vegetable> products;

        public Salad(string name)
        {
            this.Name = name;
            this.products = new List<Vegetable>();
        }

        public int GetTotalCalories()
        {
            return this.products.Sum(p => p.Calories);
        }

        public int GetProductCount()
        {
            return this.products.Count();
        }

        public void Add(Vegetable product)
        {
            this.products.Add(product);
        }

        public override string ToString()
        {
            StringBuilder productInfo = new StringBuilder();
            productInfo.AppendLine($"* Salad {this.Name} is {GetTotalCalories()} calories and have {GetProductCount()} products:");
         
            foreach (var product in this.products)
            {
                productInfo.AppendLine(product.ToString());
            }
                        
            return productInfo.ToString().TrimEnd();
        }
    }
}
