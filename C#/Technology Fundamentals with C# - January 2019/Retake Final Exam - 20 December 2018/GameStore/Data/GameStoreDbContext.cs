using GameStore.Models;
using Microsoft.EntityFrameworkCore;

namespace GameStore.Data
{

    

    public class GameStoreDbContext : DbContext
    {
        private const string ConnectionString = @"Server=localhost\SQLEXPRESS;Database=GameStore;Trusted_Connection=True;";

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConnectionString);
        }

        public virtual DbSet<Game> Games { get; set; }
    }

}
