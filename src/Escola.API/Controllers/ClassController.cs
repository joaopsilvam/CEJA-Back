using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Enceja.Domain.Entities;
using Enceja.Domain.Interfaces;

namespace Enceja.API.Controllers
{
    [Route("api/class")]
    [ApiController]
    public class ClassController : ControllerBase
    {
        private readonly IClassService _classService;

        public ClassController(IClassService classService)
        {
            _classService = classService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Class>>> GetAll()
        {
            var turmas = await _classService.GetAllAsync();
            return Ok(turmas);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Class>> GetById(int id)
        {
            var turma = await _classService.GetByIdAsync(id);
            if (turma == null)
                return NotFound();

            return Ok(turma);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Class turma)
        {
            if (turma == null)
                return BadRequest("Turma inválida");

            await _classService.AddAsync(turma);
            return CreatedAtAction(nameof(GetAll), new { id = turma.Id }, turma);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] Class turma)
        {
            //if (turma == null || turma.Id != id)
            //    return BadRequest("Dados inconsistentes");

            var turmaExistente = await _classService.GetByIdAsync(id);
            if (turmaExistente == null)
                return NotFound();

            await _classService.UpdateAsync(turma);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var turma = await _classService.GetByIdAsync(id);
            if (turma == null)
                return NotFound();

            await _classService.DeleteAsync(id);
            return NoContent();
        }
    }
}
