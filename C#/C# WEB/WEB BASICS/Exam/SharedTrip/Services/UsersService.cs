using SharedTrip.Models;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace SharedTrip.Services
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
            return this.db.Users
                .Where(x => x.Username == username && x.Password == Hash(password))
                .Select(x => x.Id)
                .FirstOrDefault();
        }


        public void RegisterUser(string username, string password, string email)
        {
            string hashedPassword = Hash(password);

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
