using System;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingSpree
{
    public class Program
    {
        static void Main()
        {
            List<Person> persons = new List<Person>();

            try
            {
                persons = Console.ReadLine().Split(';').ToList()
                    .Select(t => t.Split('='))
                    .Select(p => new Person(p[0], decimal.Parse(p[1])))
                    .ToList();
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }


            string[] inpitProducts = Console.ReadLine().Split(";", StringSplitOptions.RemoveEmptyEntries);
            List<Product> products = new List<Product>();

            foreach (var productNameAndCost in inpitProducts)
            {
                string[] token = productNameAndCost.Split('=', StringSplitOptions.RemoveEmptyEntries);
                string productName = token[0];
                decimal productCost = decimal.Parse(token[1]);

                try
                {
                    Product product = new Product(productName, productCost);
                    products.Add(product);
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                    return;
                }                
            }

            string inputByParams = Console.ReadLine();

            while (inputByParams.ToLower() != "end")
            {
                string[] buyCommand = inputByParams.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string personName = buyCommand[0];
                string productName = buyCommand[1];

                Product product = products.Where(p => p.Name == productName).FirstOrDefault();
                Person person = persons.Where(p => p.Name == personName).FirstOrDefault();

                try
                {
                    person.BuyProduct(product);
                    Console.WriteLine($"{person.Name} bought {product.Name}");
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }

                inputByParams = Console.ReadLine();
            }

            foreach (var person in persons)
            {
                Console.WriteLine($"{person}");
            }
        }
    }
}
