using System;
using System.Collections.Generic;

namespace _05.ShoppingSpree
{
    class Person
    {
        private string name;
        private decimal money;
        private List<string> bagOfProducts = new List<string>();

        public Person(string name, decimal money)
        {
            this.name = name;
            this.money = money;
        }

        public string Name => this.name;
        public decimal Money => this.money;
        public List<string> BagOfProducts => this.bagOfProducts;

        public void BuyProduct(decimal coast)
        {
            this.money -= coast;
        }

        public void AddToBag(string productName)
        {
            this.bagOfProducts.Add(productName);
        }
    }

    class Product
    {
        private string productName;
        private decimal cost;

        public Product(string productName, decimal cost)
        {
            this.productName = productName;
            this.cost = cost;
        }

        public string ProductName => this.productName;
        public decimal Cost => this.cost;
    }

    class ShoppingSpree
    {
        static void Main()
        {
            List<Person> persons = new List<Person>();
            List<Product> products = new List<Product>();

            string[] personLine = Console.ReadLine().Split(";", StringSplitOptions.RemoveEmptyEntries);
            string[] productLine = Console.ReadLine().Split(";",StringSplitOptions.RemoveEmptyEntries);

            foreach (string person in personLine)
            {
                string[] tokens = person.Split("=");
                string name = tokens[0];
                decimal money = decimal.Parse(tokens[1]);

                persons.Add(new Person(name, money));
            }

            foreach (string product in productLine)
            {
                string[] tokens = product.Split("=");
                string name = tokens[0];
                decimal coast = decimal.Parse(tokens[1]);

                products.Add(new Product(name,coast));
            }


            while (true)
            {
                string command = Console.ReadLine();

                if (command.ToLower() == "end")
                {
                    break;
                }

                string[] tokens = command.Split();
                string personName = tokens[0];
                string productName = tokens[1];

                int indexOfPerson = persons.FindIndex(p => p.Name == personName);
                int indexOfProduct = products.FindIndex(p => p.ProductName == productName);

                if (persons[indexOfPerson].Money >= products[indexOfProduct].Cost)
                {
                    persons[indexOfPerson].BuyProduct(products[indexOfProduct].Cost);
                    persons[indexOfPerson].AddToBag(productName);
                    Console.WriteLine($"{personName} bought {productName}");
                }
                else
                {
                    Console.WriteLine($"{personName} can't afford {productName}");
                }
            }

            foreach (var person in persons)
            {
                if (person.BagOfProducts.Count == 0)
                {
                    Console.WriteLine($"{person.Name} - Nothing bought");
                }
                else
                {
                    Console.Write($"{person.Name} - {string.Join(", ", person.BagOfProducts)}");
                    Console.WriteLine();
                }
            }
        }
    }
}
