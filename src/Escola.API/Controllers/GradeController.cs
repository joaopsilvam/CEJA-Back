using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Enceja.Domain.Entities;
using Enceja.Domain.Interfaces;

namespace Enceja.API.Controllers
{
    [Route("api/grade")]
    [ApiController]
    public class GradeController : ControllerBase
    {
        private readonly IGradeService _gradeService;

        public GradeController(IGradeService gradeService)
        {
            _gradeService = gradeService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Grade>>> GetAll()
        {
            var notas = await _gradeService.GetAllAsync();
            return Ok(notas);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Grade>> GetById(int id)
        {
            var nota = await _gradeService.GetByIdAsync(id);
            if (nota == null)
                return NotFound();

            return Ok(nota);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Grade nota)
        {
            if (nota == null)
                return BadRequest("Nota inválida");

            await _gradeService.AddAsync(nota);
            return CreatedAtAction(nameof(GetAll), new { id = nota.Id }, nota);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] Grade nota)
        {
            //if (nota == null || nota.Id != id)
            //    return BadRequest("Dados inconsistentes");

            var notaExistente = await _gradeService.GetByIdAsync(id);
            if (notaExistente == null)
                return NotFound();

            await _gradeService.UpdateAsync(nota);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var nota = await _gradeService.GetByIdAsync(id);
            if (nota == null)
                return NotFound();

            await _gradeService.DeleteAsync(id);
            return NoContent();
        }
    }
}
