using Lab4_23.Data;
using Lab4_23.Models;
using Microsoft.EntityFrameworkCore;

namespace Lab4_23.Services;

public class StudentService: IStudentService
{
    private Lab4Context _context;
    public IEnumerable<Student> GetStudents()
    {
        return _context.Students.ToList();
    }

    public Task<Student?> GetStudent(Guid id)
    {
        return _context.Students.FirstOrDefaultAsync(s => s.Id == id);
    }
}