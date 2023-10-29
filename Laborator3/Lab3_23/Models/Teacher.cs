using Lab3_23.Models.Base;

namespace Lab3_23.Models
{
    public class Teacher: BaseEntity
    {
        public string? Name { get; set; }
        public string Subject { get; set; }
        public int YearsOfExperience { get; set; }
    }
}