using Microsoft.AspNetCore.Mvc;
using Enceja.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
using Enceja.Domain.Interfaces;
using Enceja.Application.DTO.Entities.Teacher;
using System;
using Microsoft.AspNetCore.Identity;

namespace Enceja.API.Controllers
{
    [Route("api/teacher")]
    [ApiController]
    public class TeacherController : ControllerBase
    {
        private readonly ITeacherService _teacherService;
        private readonly IPasswordHasher<Teacher> _passwordHasher;


        public TeacherController(ITeacherService teacherService, IPasswordHasher<Teacher> passwordHasher)
        {
            _teacherService = teacherService;
            _passwordHasher = passwordHasher;
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
        public async Task<ActionResult> Post([FromBody] TeacherDTO dto)
        {
            if (dto == null)
                return BadRequest();

            try
            {
                var teacher = new Teacher
                {
                    Avatar = dto.Avatar,
                    Name = dto.Name,
                    Email = dto.Email,
                    Document = dto.Document,
                    Phone = dto.Phone,
                    Address = dto.Address,
                    BornDate = dto.BornDate,
                    RoleId = dto.RoleId,
                    Password = _passwordHasher.HashPassword(null, dto.Password)
                };

                await _teacherService.AddAsync(teacher);
                return CreatedAtAction(nameof(GetById), new { id = teacher.Id }, teacher);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
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
