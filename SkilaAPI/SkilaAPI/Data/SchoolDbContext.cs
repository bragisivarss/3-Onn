using EF_Core.Models;
using Microsoft.EntityFrameworkCore;

namespace SkilaAPI.Data
{
    public class SchoolDbContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Mark> Marks { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Teacher> Teachers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Many-to-Many relationship between Teacher and Subject
            modelBuilder.Entity<Teacher>()
                .HasMany(t => t.Subjects)
                .WithMany(s => s.Teachers)
                .UsingEntity(j => j.HasData(
                    new { SubjectsSubjectId = 1, TeachersTeacherId = 1 },
                    new { SubjectsSubjectId = 2, TeachersTeacherId = 1 },
                    new { SubjectsSubjectId = 1, TeachersTeacherId = 2 }
                ));

            // Seed Groups
            modelBuilder.Entity<Group>().HasData(
                new Group { GroupId = 1, Name = "Group A" },
                new Group { GroupId = 2, Name = "Group B" }
            );

            // Seed Subjects
            modelBuilder.Entity<Subject>().HasData(
                new Subject { SubjectId = 1, Title = "Math" },
                new Subject { SubjectId = 2, Title = "Science" }
            );

            // Seed Teachers
            modelBuilder.Entity<Teacher>().HasData(
                new Teacher { TeacherId = 1, FirstName = "Alice", LastName = "Smith" },
                new Teacher { TeacherId = 2, FirstName = "Bob", LastName = "Johnson" }
            );

            // Seed Students
            modelBuilder.Entity<Student>().HasData(
                new Student { StudentId = 1, FirstName = "John", LastName = "Doe", GroupId = 1 },
                new Student { StudentId = 2, FirstName = "Jane", LastName = "Doe", GroupId = 1 }
            );

            // Seed Marks with fixed Date value
            modelBuilder.Entity<Mark>().HasData(
                new Mark { MarkId = 1, StudentId = 1, SubjectId = 1, Date = new DateTime(2023, 1, 1), Value = 85 },
                new Mark { MarkId = 2, StudentId = 2, SubjectId = 2, Date = new DateTime(2023, 1, 1), Value = 90 }
            );
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=SkilaverkAPI;ConnectRetryCount=0");
        }
    }
}
