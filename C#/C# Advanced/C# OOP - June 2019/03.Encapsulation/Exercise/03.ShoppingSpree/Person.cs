using System;
using System.Collections.Generic;

namespace ShoppingSpree
{
    public class Person
    {
        private string name;
        private decimal money;
        private List<Product> bagOfProducts;

        public Person(string name, decimal money)
        {
            this.Name = name;
            this.Money = money;
            bagOfProducts = new List<Product>();
        }

        public IReadOnlyList<Product> BagOfProducts
        {
            get
            {
                return this.bagOfProducts.AsReadOnly();
            }            
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            private set
            {
                if (value == string.Empty)
                {
                    throw new ArgumentException("Name cannot be empty");
                }
                this.name = value;
            }
        }

        public decimal Money
        {
            get
            {
                return this.money;
            }

            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Money cannot be negative");
                }

                this.money = value;
            }
        }

        public void BuyProduct(Product product)
        {
            if (this.Money - product.Cost < 0)
            {
                throw new ArgumentException($"{this.Name} can't afford {product.Name}");
            }

            this.Money -= product.Cost;

            this.bagOfProducts.Add(product);
        }

        public override string ToString()
        {
            if (this.BagOfProducts.Count <= 0)
            {
                return $"{this.Name} - Nothing bought";
            }

            return $"{this.Name} - {string.Join(", ", this.BagOfProducts)}";
        }
    }
}
