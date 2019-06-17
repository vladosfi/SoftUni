using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HealthyHeaven
{
    public class Salad
    {
        public string Name { get; set; }
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
            return this.products.Count;
        }

        public void Add(Vegetable product)
        {
            this.products.Add(product);
        }

        public override string ToString()
        {
            StringBuilder productInfo = new StringBuilder();
            productInfo.AppendLine($" * Salad {this.Name} is {GetTotalCalories()} calories and have {GetProductCount()} products:");
         
            foreach (var product in this.products)
            {
                productInfo.AppendLine($"  - {product.Name} have {product.Calories} calories");
            }
                        
            return productInfo.ToString().TrimEnd();
        }
    }
}
