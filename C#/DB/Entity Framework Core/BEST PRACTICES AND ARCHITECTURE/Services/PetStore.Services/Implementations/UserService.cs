﻿
namespace PetStore.Services.Implementations
{
    using Data;
    using Data.Models;
    using System.Linq;

    public class UserService : IUserService
    {
        private readonly PetStoreDbContext data;

        public UserService(PetStoreDbContext data)
        {
            this.data = data;
        }
        public bool Exists(int userId)
        {
            return this.data.Users.Any(u => u.Id == userId);
        }

        public void Register(string name, string email)
        {
            var user = new User()
            {
                Name = name,
                Email = email
            };

            this.data.Users.Add(user);
            this.data.SaveChanges();
        }
    }
}
