using Lab4_23.Models.Base;

namespace Lab4_23.Models
{
    public class Locker: BaseEntity
    {
        public int ?Number { get; set; }
        
        public string? Color { get; set; }

        // relation
        public Student? Student { get; set; }
    }
}