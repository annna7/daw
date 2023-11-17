using Lab4_23.Models.Base;

namespace Lab4_23.Models
{
    public class Teacher: BaseEntity
    {
        public string? Name { get; set; }
        public string Subject { get; set; }
        public int YearsOfExperience { get; set; }

        public ICollection<StudentTeacherRelation> StudentsRelations { get; set; }
    }
}