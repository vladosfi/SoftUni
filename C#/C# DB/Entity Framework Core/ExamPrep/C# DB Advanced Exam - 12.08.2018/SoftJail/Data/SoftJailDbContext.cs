namespace SoftJail.Data
{
    using Microsoft.EntityFrameworkCore;
    using SoftJail.Data.Models;

    public class SoftJailDbContext : DbContext
    {
        public DbSet<Cell> Cells { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Mail> Mails { get; set; }
        public DbSet<Officer> Officers { get; set; }
        public DbSet<OfficerPrisoner> OfficersPrisoners { get; set; }
        public DbSet<Prisoner> Prisoners { get; set; }

        public SoftJailDbContext()
        {
        }

        public SoftJailDbContext(DbContextOptions options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                    .UseSqlServer(Configuration.ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<OfficerPrisoner>()
                .HasKey(op => new
                {
                    op.PrisonerId,
                    op.OfficerId
                });

            builder.Entity<OfficerPrisoner>()
                .HasOne(o => o.Officer)
                .WithMany(b => b.OfficerPrisoners)
                .HasForeignKey(bc => bc.OfficerId);
            builder.Entity<OfficerPrisoner>()
                .HasOne(p => p.Prisoner)
                .WithMany(c => c.PrisonerOfficers)
                .HasForeignKey(bc => bc.PrisonerId);
        }
    }
}