using Lab4_23.Data;
using Lab4_23.Models.DTOs;
using Lab4_23.Models.One_to_Many;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Lab4_23.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DatabaseController : ControllerBase
    {
        private readonly Lab4Context _lab4Context;

        public DatabaseController(Lab4Context lab4Context)
        {
            _lab4Context = lab4Context;
        }

        [HttpGet("model1")]
        public async Task<IActionResult> GetModel1()
        {
            return Ok(await _lab4Context.Models1.ToListAsync());
        }

        [HttpPost("model1")]
        public async Task<IActionResult> Create (Model1DTO model1Dto)
        {
            var newModel1 = new Model1
            {
                Id = Guid.NewGuid(),
                Name = model1Dto.Name
            };

            await _lab4Context.AddAsync(newModel1);
            await _lab4Context.SaveChangesAsync();

            return Ok(newModel1);
        }

        [HttpPost("update")]
        public async Task<IActionResult> Update(Model1DTO model1Dto)
        {
            Model1 model1ById = await _lab4Context.Models1.FirstOrDefaultAsync(x => x.Id == model1Dto.Id);
            if (model1ById == null)
            {
                return BadRequest("Object does not exist");
            }

            model1ById.Name = model1Dto.Name;
            _lab4Context.Update(model1ById);
            await _lab4Context.SaveChangesAsync();
            
            return Ok(model1ById);
        }
        
        [HttpGet("student-include")]
        public async Task<IActionResult> GetAllWithInclude()
        {
            var result = await _lab4Context.Universities.Include(s => s.Students).ThenInclude(m2 => m2.University)
                .ToListAsync();
            
            return Ok(result);
        }
        
        [HttpGet("student-join")]
        public async Task<IActionResult> GetAllWithJoin()
        {
            var result = await _lab4Context.Universities.Join(_lab4Context.Students, university => university.Id, student => student.UniversityId,
                (university, student) => new { university, student }).Select(ob => ob.university).ToListAsync();
            
            return Ok(result);
        }
        
        [HttpGet("student-ordered")]
        public async Task<IActionResult> GetAllOrdered()
        {
            var result = await _lab4Context.Students.OrderBy(s => s.FirstName).ToListAsync();
            
            // list query way
            var result2 = await (from s in _lab4Context.Students
                orderby s.FirstName
                select s).ToListAsync();
            
            return Ok(result);
        }
    }
}
