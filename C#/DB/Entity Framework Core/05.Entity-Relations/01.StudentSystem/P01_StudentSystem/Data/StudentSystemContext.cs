namespace P01_StudentSystem.Data
{
    using System;
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
            OnConfiguringCourse(modelBuilder);
            OnConfiguringResource(modelBuilder);
        }

        private void OnConfiguringResource(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Resource>(entity =>
                {
                    entity
                        .HasKey(r => r.ResourceId);

                    entity
                        .Property(r => r.Name)
                        .HasMaxLength(50)
                        .IsUnicode()
                        .IsRequired();

                    entity
                        .Property(r => r.Url)
                        .IsUnicode(false);
                });
        }

        private void OnConfiguringCourse(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Course>(entity =>
                {
                    entity
                        .HasKey(c => c.CourseId);

                    entity
                        .HasMany(c => c.StudentsEnrolled)
                        .WithOne(c => c.Course);

                    entity
                        .HasMany(c => c.Resources)
                        .WithOne(c => c.Course);

                    entity
                        .HasMany(c => c.StudentsEnrolled)
                        .WithOne(c => c.Course);

                    entity
                        .Property(c => c.Name)
                        .HasMaxLength(80)
                        .IsRequired()
                        .IsUnicode();

                    entity
                        .Property(c => c.Description)
                        .IsUnicode();
                });
        }

        private static void OnConfiguringStuden(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Student>(entity =>
                {
                    entity.HasKey(s => s.StudentId);

                    entity
                        .HasMany(s=>s.CourseEnrollments)
                        .WithOne(s => s.Student);

                    entity
                        .HasMany(s => s.HomeworkSubmissions)
                        .WithOne(s => s.Student);

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
