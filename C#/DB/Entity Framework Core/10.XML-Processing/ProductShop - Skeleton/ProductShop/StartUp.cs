
namespace ProductShop
{
    using AutoMapper;
    using ProductShop.Data;
    using ProductShop.Dtos.Export;
    using ProductShop.Dtos.Import;
    using ProductShop.Models;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Serialization;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            Mapper.Initialize(x => x.AddProfile<ProductShopProfile>());

            using (ProductShopContext context = new ProductShopContext())
            {
                //context.Database.EnsureDeleted();
                //context.Database.EnsureCreated();

                //var usersXml = File.ReadAllText(@"Datasets\users.xml");
                //Console.WriteLine(ImportUsers(context, usersXml));

                //var productsXml = File.ReadAllText(@"Datasets\products.xml");
                //Console.WriteLine(ImportProducts(context, productsXml));

                //var categoriesXml = File.ReadAllText(@"Datasets\categories.xml");
                //Console.WriteLine(ImportCategories(context, categoriesXml));

                //var categoriesProductsXml = File.ReadAllText(@"Datasets\categories-products.xml");
                //Console.WriteLine(ImportCategoryProducts(context, categoriesProductsXml));

                Console.WriteLine(GetProductsInRange(context));
            }
        }

        //Query 5. Products In Range
        public static string GetProductsInRange(ProductShopContext context)
        {
            var products = context
                .Products
                .Take(10)
                .Where(p => p.Price >= 500 && p.Price <= 1000)
                .Select(p => new ExportProductInRangeDto
                {
                    Name = p.Name,
                    Price = p.Price,
                    Buyer = p.Buyer.FirstName + " " + p.Buyer.LastName
                })
                .OrderBy(p => p.Price)
                .ToArray();

            //Serialize XML
            XmlSerializer serializer = new XmlSerializer(typeof(ExportProductInRangeDto[]), new XmlRootAttribute("Products"));

            var sb = new StringBuilder();

            var namespaces = new XmlSerializerNamespaces(new[]
            {
                new XmlQualifiedName("","")
            });

            serializer.Serialize(new StringWriter(sb), products, namespaces);

            return sb.ToString().TrimEnd();
        }

        //Query 4. Import Categories and Products
        public static string ImportCategoryProducts(ProductShopContext context, string inputXml)
        {
            //Validate ProductsId and CategoriesId
            var validProdictId = new HashSet<int>
            (
                context.Products.Select(p => p.Id).ToHashSet()
            );

            var validCategoryId = new HashSet<int>
            (
                context.Categories.Select(p => p.Id).ToHashSet()
            );

            //Deserialize XML
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(CategoryProductDto[]), new XmlRootAttribute("CategoryProducts"));

            var categoriesProductsDto = (CategoryProductDto[])xmlSerializer.Deserialize(new StringReader(inputXml));

            //Remove equal elements ProductsId and CategoriesId
            categoriesProductsDto = categoriesProductsDto.Distinct().ToArray();

            var categoriesProducts = new List<CategoryProduct>();

            foreach (var categoryProductDto in categoriesProductsDto)
            {
                var isValid = validProdictId.Contains(categoryProductDto.ProductId) &&
                validCategoryId.Contains(categoryProductDto.CategoryId);

                if (isValid)
                {
                    var categoryProduct = Mapper.Map<CategoryProduct>(categoryProductDto);

                    categoriesProducts.Add(categoryProduct);
                }
            }

            context.CategoryProducts.AddRange(categoriesProducts);
            context.SaveChanges();

            return $"Successfully imported {categoriesProducts.Count}";
        }


        //Query 3. Import Categories
        public static string ImportCategories(ProductShopContext context, string inputXml)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(CategoryDto[]), new XmlRootAttribute("Categories"));

            var categoriesDto = (CategoryDto[])xmlSerializer.Deserialize(new StringReader(inputXml));

            var categories = new List<Category>();

            foreach (var categoryDto in categoriesDto.Where(c => c.Name != null))
            {
                var category = Mapper.Map<Category>(categoryDto);

                categories.Add(category);
            }

            context.Categories.AddRange(categories);
            context.SaveChanges();

            return $"Successfully imported {categories.Count}";
        }

        //Query 2. Import Products
        public static string ImportProducts(ProductShopContext context, string inputXml)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ProductDto[]), new XmlRootAttribute("Products"));

            var productsDto = (ProductDto[])xmlSerializer.Deserialize(new StringReader(inputXml));

            var products = new List<Product>();

            foreach (var productDto in productsDto)
            {
                var product = Mapper.Map<Product>(productDto);

                products.Add(product);
            }

            context.Products.AddRange(products);
            context.SaveChanges();

            return $"Successfully imported {products.Count}";

        }

        //Query 1. Import Users
        public static string ImportUsers(ProductShopContext context, string inputXml)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(UserDto[]), new XmlRootAttribute("Users"));

            var usersDto = (UserDto[])xmlSerializer.Deserialize(new StringReader(inputXml));

            var users = new List<User>();

            foreach (var userDto in usersDto)
            {
                var user = Mapper.Map<User>(userDto);

                users.Add(user);
            }

            context.Users.AddRange(users);
            context.SaveChanges();

            return $"Successfully imported {users.Count}"; ;
        }
    }
}