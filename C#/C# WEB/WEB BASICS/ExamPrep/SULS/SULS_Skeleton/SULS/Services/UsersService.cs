using SULS.Models;
using SULS.ViewModels;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace SULS.Services
{
    public class UsersService : IUsersService
    {
        private readonly ApplicationDbContext db;

        public UsersService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public bool EmailExist(string email)
        {
            return this.db.Users.Any(x => x.Email == email);
        }

        public bool UserExist(string username)
        {
            return this.db.Users.Any(x => x.Username == username);
        }


        void IUsersService.Register(string username, string password, string email)
        {
            var hashedPassword = this.Hash(password);

            var user = new User
            {
                Username = username,
                Password = hashedPassword,
                Email = email,
            };

            this.db.Users.Add(user);
            this.db.SaveChanges();
        }

        private string Hash(string input)
        {
            if (input == null)
            {
                return null;
            }

            var crypt = new SHA256Managed();
            var hash = new StringBuilder();
            byte[] crypto = crypt.ComputeHash(Encoding.UTF8.GetBytes(input));
            foreach (byte theByte in crypto)
            {
                hash.Append(theByte.ToString("x2"));
            }

            return hash.ToString();
        }

        public string GetUserId(string username, string password)
        {
            var hashedPassword = this.Hash(password);

            var userId = this.db.Users
                .Where(x => x.Username == username && x.Password == hashedPassword)
                .Select(x=>x.Id)
                .FirstOrDefault();

            return userId;
        }
    }
}
