using Enceja.Domain.Interfaces;
using Enceja.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using System;

namespace Enceja.API.Controllers
{
    [Route("api/student")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;
        private readonly IPasswordHasher<Student> _passwordHasher;


        public StudentController(IStudentService studentService, IPasswordHasher<Student> passwordHasher)
        {
            _studentService = studentService;
            _passwordHasher = passwordHasher;

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
        public async Task<ActionResult> Post([FromBody] StudentDTO dto)
        {
            if (dto == null)
                return BadRequest();

            try
            {
                var student = new Student
                {
                    Avatar = dto.Avatar,
                    Name = dto.Name,
                    Email = dto.Email,
                    Document = dto.Document,
                    Phone = dto.Phone,
                    Address = dto.Address,
                    BornDate = dto.BornDate,
                    RoleId = dto.RoleId,
                    Password = _passwordHasher.HashPassword(null, dto.Password),
                    RegistrationNumber = await _studentService.GenerateRegistrationNumberAsync(dto.Document)
                };

                await _studentService.AddAsync(student);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
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