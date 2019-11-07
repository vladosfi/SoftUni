namespace P03_SalesDatabase.Data
{
    using System;
    using Microsoft.EntityFrameworkCore;

    using Models;

    public class SalesContext : DbContext
    {
        public DbSet<Product> Products { get; set; }

        public DbSet<Sale> Sales { get; set; }

        public DbSet<Store> Stores { get; set; }

        public DbSet<Customer> Customers { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(Config.ConnectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            this.ConfigureProductEntity(modelBuilder);

            this.ConfigureCustomerEntity(modelBuilder);

            this.ConfigureStoresEntity(modelBuilder);

            this.ConfigureSalesEntity(modelBuilder);
        }

        private void ConfigureSalesEntity(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Sale>()
                .HasKey(s => s.SaleId);

            modelBuilder
                .Entity<Sale>()
                .Property(s => s.Date)
                .HasDefaultValueSql("getdate()");

        }

        private void ConfigureStoresEntity(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Store>()
                .HasKey(s => s.StoreId);

            modelBuilder
                .Entity<Store>()
                .HasMany(s => s.Sales)
                .WithOne(s => s.Store);

            modelBuilder
                .Entity<Store>()
                .Property(s => s.Name)
                .HasMaxLength(80)
                .IsUnicode();
        }

        private void ConfigureCustomerEntity(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Customer>()
                .HasKey(c => c.CustomerId);

            modelBuilder
                .Entity<Customer>()
                .HasMany(c => c.Sales)
                .WithOne(c => c.Customer);

            modelBuilder
                .Entity<Customer>()
                .Property(c => c.Name)
                .HasMaxLength(100)
                .IsUnicode();

            modelBuilder
                .Entity<Customer>()
                .Property(c => c.Email)
                .HasMaxLength(80);
        }

        private void ConfigureProductEntity(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Product>()
                .HasKey(p => p.ProductId);

            modelBuilder
                .Entity<Product>()
                .HasMany(p => p.Sales)
                .WithOne(v => v.Product);

            modelBuilder
                .Entity<Product>()
                .Property(p => p.Name)
                .HasMaxLength(50)
                .IsUnicode()
                .IsRequired();

            modelBuilder
                .Entity<Product>()
                .Property(p => p.Description)
                .HasMaxLength(250)
                .HasDefaultValue("No description");
        }
    }
}
