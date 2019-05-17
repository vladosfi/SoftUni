namespace Library.Data
{
    using Microsoft.EntityFrameworkCore;
    using Library.Models;

    public class LibraryDbContext : DbContext
    {
        private const string ConnectionString = @"Server=localhost\SQLEXPRESS;Database=Library;Trusted_Connection=True;";

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConnectionString);
        }

        public virtual DbSet<Book> Books { get; set; }
    }

}

