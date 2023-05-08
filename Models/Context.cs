using Microsoft.EntityFrameworkCore;

namespace StudentWebApi.Models
{
    public class Context : DbContext
    {
        public required DbSet<Student> Students { get; set; }
        public required DbSet<Course> Courses { get; set; }
        public required DbSet<Enrollment> Enrollments { get; set; }
        public Context(DbContextOptions options)
        : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Enrollment>().Property(course => course.Mark).IsRequired(false);
            modelBuilder.Entity<Enrollment>().HasKey(e => new { e.StudentId, e.CourseCode });
            base.OnModelCreating(modelBuilder);
        }
    }
}
