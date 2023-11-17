using Lab4_23.Models;

namespace Lab4_23.Services;

public interface IStudentService
{
    IEnumerable<Student> GetStudents();
    Task<Student?> GetStudent(Guid id);
}