namespace Lab4_23.Models
{
    public class StudentTeacherRelation
    {
        public Guid StudentId { get; set; }
        public Student? Student { get; set; }

        public Guid TeacherId { get; set; }
        public Teacher? Teacher { get; set; }
    }
}