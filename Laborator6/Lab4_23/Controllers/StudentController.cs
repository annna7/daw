using Lab4_23.Services;
using Microsoft.AspNetCore.Mvc;

namespace Lab4_23.Controllers;

[Route("api/[controller]/student")]
[ApiController]
public class StudentController: ControllerBase
{
    private readonly IStudentService _studentService;
    public StudentController(IStudentService studentService)
    {
        _studentService = studentService;
    }
    
    [HttpGet]
    public IActionResult GetStudents()
    {
        return Ok(_studentService.GetStudents());
    }
    
    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetStudent(Guid id)
    {
        var student = await _studentService.GetStudent(id);
        if (student == null)
        {
            return NotFound();
        }
        return Ok(student);
    }
}