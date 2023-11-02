using Lab4_23.Models.Base;
using System.Collections.Generic;

namespace Lab4_23.Models
{
    public class Student: BaseEntity
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public int Age { get; set; }
        public string? Email { get; set; }
        
        // relations
        // many to one between students and universities
        public University? University { get; set; }
        public Guid SchoolId { get; set; }
        
        // one to one between students and lockers
        public Locker? Locker { get; set; }
        public Guid LockerId { get; set; }
        
        // many-to-many between students and teachers
        public ICollection<StudentTeacherRelation>? TeacherRelations { get; set; }
    }
}
