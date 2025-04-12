using Microsoft.AspNetCore.Mvc;
using Enceja.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
using Enceja.Domain.Interfaces;

namespace Enceja.API.Controllers
{
    [Route("api/subject")]
    [ApiController]
    public class SubjectController : ControllerBase
    {
        private readonly ISubjectService _subjectService;

        public SubjectController(ISubjectService subjectService)
        {
            _subjectService = subjectService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Subject>>> GetAll()
        {
            var subjects = await _subjectService.GetAllAsync();
            return Ok(subjects);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Subject>> GetById(int id)
        {
            var disciplina = await _subjectService.GetByIdAsync(id);
            if (disciplina == null)
                return NotFound();

            return Ok(disciplina);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Subject subject)
        {
            if (subject == null)
                return BadRequest();

            await _subjectService.AddAsync(subject);
            return CreatedAtAction(nameof(GetById), new { id = subject.Id }, subject);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] Subject subject)
        {
            //if (disciplina == null || disciplina.Id != id)
            //    return BadRequest();

            await _subjectService.UpdateAsync(subject);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _subjectService.DeleteAsync(id);
            return NoContent();
        }
    }
}
