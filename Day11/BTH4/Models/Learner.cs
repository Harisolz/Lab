namespace BTH4.Models
{
    public class Learner
    {
        public int LearnerID { get; set; }

        public string FirstMidName { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;

        public DateTime EnrollmentDate { get; set; }

        public int MajorID { get; set; }

        public virtual Major? Major { get; set; }

        public virtual ICollection<Enrollment> Enrollments
        { get; set; } = new HashSet<Enrollment>();
    }
}