namespace BTH4.Models
{
    public class Major
    {
        public int MajorID { get; set; }

        public string MajorName { get; set; } = string.Empty;

        public virtual ICollection<Learner> Learners { get; set; }
            = new HashSet<Learner>();
    }
}