namespace P01_StudentSystem.Data
{
    using Microsoft.EntityFrameworkCore;
    using P01_StudentSystem.Data.Models;

    public class StudentSystemContext : DbContext
    {
        public DbSet<Student> Students { get; set; }

        public DbSet<Course> Courses { get; set; }

        public DbSet<Resource> Resource { get; set; }

        public DbSet<Homework> HomeworkSubmissions { get; set; }

        public DbSet<StudentCourse> CourseEnrollments { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Config.ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            OnConfiguringStuden(modelBuilder);

        }

        private static void OnConfiguringStuden(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Student>(entity =>
                {
                    entity.HasKey(s => s.StudentId);

                    entity
                        .Property(p => p.Name)
                        .HasMaxLength(100)
                        .IsUnicode()
                        .IsRequired();

                    entity
                        .Property(s => s.PhoneNumber)
                        .HasColumnType("CHAR(10)") //.HasMaxLength(10).IsFixedLength()
                        .IsUnicode(false);

                    entity
                        .Property(s => s.RegisteredOn)
                        .HasDefaultValueSql("GETDATE()");
                });
        }
    }
}
