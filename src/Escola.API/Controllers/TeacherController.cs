using Microsoft.AspNetCore.Mvc;
using Enceja.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
using Enceja.Domain.Interfaces;

namespace Enceja.API.Controllers
{
    [Route("api/teacher")]
    [ApiController]
    public class TeacherController : ControllerBase
    {
        private readonly ITeacherService _teacherService;

        public TeacherController(ITeacherService teacherService)
        {
            _teacherService = teacherService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Teacher>>> GetAll()
        {
            var teachers = await _teacherService.GetAllAsync();
            return Ok(teachers);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Teacher>> GetById(int id)
        {
            var teacher = await _teacherService.GetByIdAsync(id);
            if (teacher == null)
                return NotFound();
            return Ok(teacher);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Teacher teacher)
        {
            if (teacher == null)
                return BadRequest();

            await _teacherService.AddAsync(teacher);
            return CreatedAtAction(nameof(GetById), new { id = teacher.Id }, teacher);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] Teacher teacher)
        {
            //if (professor == null || professor.Id != id)
            //    return BadRequest();

            await _teacherService.UpdateAsync(teacher);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var teacher = await _teacherService.GetByIdAsync(id);
            if (teacher == null)
                return NotFound();

            await _teacherService.DeleteAsync(id);
            return NoContent();
        }
    }
}
