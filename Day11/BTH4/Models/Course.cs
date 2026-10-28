
namespace BTH4.Models
{
    public class Course
    {
        public int CourseID { get; set; }

        public string Title { get; set; } = string.Empty;

        public int Credits { get; set; }

        public virtual ICollection<Enrollment> Enrollments
        { get; set; } = new HashSet<Enrollment>();
    }
}
