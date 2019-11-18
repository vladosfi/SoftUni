namespace ProductShop
{
    using Newtonsoft.Json;
    using ProductShop.Data;
    using ProductShop.Models;
    using System.IO;
    using System.Linq;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            var context = new ProductShopContext();

            var usersJson = File.ReadAllText("./../../../Datasets/users.json");

            System.Console.WriteLine(usersJson);
            var results = ImportUsers(context, usersJson);
        }

        public static string ImportUsers(ProductShopContext context, string inputJson)
        {
            var users = JsonConvert.DeserializeObject<User[]>(inputJson)
                .Where(u => u.LastName != null && u.LastName.Length >= 3)
                .ToArray();


            context.AddRange(users);
            context.SaveChanges();

            return $"Successfully imported {users.Length}"; ;
        }
    }
}