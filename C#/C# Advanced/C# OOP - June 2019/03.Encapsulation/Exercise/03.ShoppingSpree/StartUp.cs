using System;
using System.Collections.Generic;
using System.Linq;
using ShoppingSpree.Models;

namespace ShoppingSpree
{
    public class StartUp
    {
        static void Main()
        {
            List<Person> persons = new List<Person>();

            try
            {
                persons = Console.ReadLine().Split(';', StringSplitOptions.RemoveEmptyEntries).ToList()
                    .Select(t => t.Split('=', StringSplitOptions.RemoveEmptyEntries))
                    .Select(p => new Person(p[0], decimal.Parse(p[1])))
                    .ToList();
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }

            List<Product> products = new List<Product>();

            try
            {
                products = Console.ReadLine()
                    .Split(";",StringSplitOptions.RemoveEmptyEntries)
                    .ToList()
                    .Select(l => l.Split('=', StringSplitOptions.RemoveEmptyEntries))
                    .Select(p => new Product(p[0], decimal.Parse(p[1])))
                    .ToList();
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
                return;
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
                catch (InvalidOperationException ex)
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
