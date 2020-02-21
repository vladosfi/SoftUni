namespace P01_StudentSystem.Data
{
    using Microsoft.EntityFrameworkCore;
    using P01_StudentSystem.Data.Models;

    public class StudentSystemContext : DbContext
    {
        public StudentSystemContext()
        {
        }

        public StudentSystemContext(DbContextOptions options) 
            : base(options)
        {
        }

        public DbSet<Student> Students { get; set; }

        public DbSet<Course> Courses { get; set; }

        public DbSet<Resource> Resources { get; set; }

        public DbSet<Homework> HomeworkSubmissions { get; set; }

        public DbSet<StudentCourse> StudentCourses { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Config.ConnectionString);
            }
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            OnConfiguringStuden(modelBuilder);
            OnConfiguringCourse(modelBuilder);
            OnConfiguringResource(modelBuilder);
            OnConfiguringHomework(modelBuilder);
            OnConfiguringStudentCourse(modelBuilder);
        }

        private void OnConfiguringStudentCourse(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<StudentCourse>(entity =>
                {
                    entity.HasKey(s => new { s.StudentId, s.CourseId });

                    entity
                        .HasOne(s => s.Student)
                        .WithMany(s => s.CourseEnrollments)
                        .HasForeignKey(s=>s.StudentId);

                    entity
                        .HasOne(s => s.Course)
                        .WithMany(s => s.StudentsEnrolled)
                        .HasForeignKey(s => s.CourseId);
                });
                
        }

        private void OnConfiguringHomework(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Homework>(entity =>
                {
                    entity
                        .HasKey(h => h.HomeworkId);

                    entity
                        .Property(h => h.Content)
                        .IsRequired();

                    entity
                        .HasOne(h => h.Student)
                        .WithMany(h => h.HomeworkSubmissions);

                    entity
                        .HasOne(h => h.Course)
                        .WithMany(h => h.HomeworkSubmissions);
                });
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
                        .IsRequired();

                    entity
                        .HasOne(r => r.Course)
                        .WithMany(r => r.Resources);
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
                        .Property(s => s.Name)
                        .HasMaxLength(100)
                        .IsUnicode()
                        .IsRequired();

                    entity
                        .Property(s => s.PhoneNumber)
                        .HasColumnType("CHAR(10)"); //.HasMaxLength(10).IsFixedLength();

                    entity
                        .Property(s => s.RegisteredOn)
                        .HasDefaultValueSql("GETDATE()");
                });
        }
    }
}
