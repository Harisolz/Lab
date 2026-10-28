
using Microsoft.EntityFrameworkCore;
using BTH4.Models;

namespace BTH4.Data
{
    public class SchoolContext : DbContext
    {
        public SchoolContext(
            DbContextOptions<SchoolContext> options)
            : base(options)
        {
        }

        public DbSet<Major> Majors { get; set; }
        public DbSet<Learner> Learners { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }

        protected override void OnModelCreating(
            ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Major>()
                .HasKey(m => m.MajorID);

            modelBuilder.Entity<Learner>()
                .HasKey(l => l.LearnerID);

            modelBuilder.Entity<Course>()
                .HasKey(c => c.CourseID);

            modelBuilder.Entity<Enrollment>()
                .HasKey(e => e.EnrollmentID);

            // Major 1 - N Learner
            modelBuilder.Entity<Learner>()
                .HasOne(l => l.Major)
                .WithMany(m => m.Learners)
                .HasForeignKey(l => l.MajorID)
                .OnDelete(DeleteBehavior.Restrict);

            // Learner 1 - N Enrollment
            modelBuilder.Entity<Enrollment>()
                .HasOne(e => e.Learner)
                .WithMany(l => l.Enrollments)
                .HasForeignKey(e => e.LearnerID)
                .OnDelete(DeleteBehavior.Restrict);

            // Course 1 - N Enrollment
            modelBuilder.Entity<Enrollment>()
                .HasOne(e => e.Course)
                .WithMany(c => c.Enrollments)
                .HasForeignKey(e => e.CourseID)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
