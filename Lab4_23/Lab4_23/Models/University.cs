using Lab4_23.Models.Base;

namespace Lab4_23.Models
{
    public class University: BaseEntity
    {
        public string? Name { get; set; }
        
        public string? Adress { get; set; }
        
        public string? Headmaster { get; set; }
        
        public int Tuition { get; set; }

        // relation 
        public ICollection<Student>? Students { get; set; }
    }
}