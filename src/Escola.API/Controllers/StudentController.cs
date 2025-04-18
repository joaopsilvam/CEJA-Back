﻿using Enceja.Domain.Interfaces;
using Enceja.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Enceja.Application.DTO.Entities;

namespace Enceja.API.Controllers
{
    [Route("api/student")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;

        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Student>> GetById(int id)
        {
            var student = await _studentService.GetByIdAsync(id);
            if (student == null)
            {
                return NotFound();
            }
            return Ok(student);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Student>>> GetAll()
        {
            var alunos = await _studentService.GetAllAsync();
            return Ok(alunos);
        }

        [HttpGet("GetAllStudentsWithClass")]
        public async Task<ActionResult<IEnumerable<StudentDTO>>> GetAllStudentsWithClass()
        {
            var student = await _studentService.GetAllStudentsWithClass();

            if (student == null)
            {
                return NotFound();
            }
            return Ok(student);
        }

        [HttpGet("buscarAlunoPorTurma/{turmaId}")]
        public async Task<ActionResult<IEnumerable<StudentDTO>>> GetStudentByClass(int classId)
        {
            var alunos = await _studentService.GetStudentByClass(classId);

            if (alunos == null || !alunos.Any())
            {
                return NotFound("Nenhum aluno encontrado para essa turma.");
            }

            return Ok(alunos);
        }


        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Student student)
        {
            if (student == null)
            {
                return BadRequest();
            }
            student.Id = 0;
            await _studentService.AddAsync(student);

            return CreatedAtAction(nameof(GetById), new { id = student.Id }, student);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] Student aluno)
        {
            await _studentService.UpdateAsync(aluno);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var aluno = await _studentService.GetByIdAsync(id);
            if (aluno == null)
            {
                return NotFound();
            }
            await _studentService.DeleteAsync(id);
            return NoContent();
        }
    }
}