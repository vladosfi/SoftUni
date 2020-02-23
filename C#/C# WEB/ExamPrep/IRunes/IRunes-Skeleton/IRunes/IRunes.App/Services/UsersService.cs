using IRunes.Data;
using IRunes.Models;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace IRunes.App.Services
{
    public class UsersService : IUsersService
    {
        private readonly ApplicationDbContext db;

        public UsersService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public string GetUserId(string username, string password)
        {
            var passwordHash = this.Hash(password);
            return this.db.Users
                .Where(x => x.Username == username && x.Password == passwordHash)
                .Select(x => x.Id)
                .FirstOrDefault();
        }

        public void Register(string username, string email, string password)
        {
            var user = new User
            {
                Username = username,
                Email = email,
                Password = Hash(password),
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

        public bool UserNameExist(string username)
        {
            return this.db.Users.Any(x => x.Username == username);
        }

        public bool EmailExist(string email)
        {
            return this.db.Users.Any(x => x.Email == email);
        }

        public string GetUserName(string userId)
        {
            return this.db.Users.Where(x => x.Id == userId).Select(x => x.Username).FirstOrDefault();
        }
    }
}
