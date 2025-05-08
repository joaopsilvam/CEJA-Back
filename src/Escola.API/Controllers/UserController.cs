using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Enceja.Domain.Entities;
using Enceja.Domain.Interfaces;
using Microsoft.AspNetCore.Identity;
using Enceja.Domain.Services;
using System;

namespace Enceja.API.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IStudentService _studentService;
        private readonly IPasswordHasher<User> _passwordHasher;

        public UserController(IUserService userService, IPasswordHasher<User> passwordHasher, IStudentService studentService)
        {
            _userService = userService;
            _passwordHasher = passwordHasher;
            _studentService = studentService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetAll()
        {
            var users = await _userService.GetAllAsync();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetById(int id)
        {
            var user = await _userService.GetByIdAsync(id);
            if (user == null)
                return NotFound();

            return Ok(user);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] User user)
        {
            if (user == null)
                return BadRequest("Usuário inválido");

            user.Password = _passwordHasher.HashPassword(user, user.Password);

            using var transaction = await _userService.BeginTransactionAsync();

            try
            {
                // Adiciona sem salvar
                await _userService.AddWithoutSaveAsync(user);

                if (user.Role == RoleType.Student)
                {
                    var registrationNumber = await _studentService.GenerateRegistrationNumberAsync(user.Document);

                    var student = new Student
                    {
                        Id = user.Id,
                        RegistrationNumber = registrationNumber
                    };

                    await _studentService.AddWithoutSaveAsync(student);
                }

                await _userService.SaveChangesAsync();
                await transaction.CommitAsync();

                return CreatedAtAction(nameof(GetAll), new { id = user.Id }, user);
            }
            catch (Exception)
            {
                await transaction.RollbackAsync();
                throw;
            }
        }


        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] User user)
        {
            var existingUser = await _userService.GetByIdAsync(id);
            if (existingUser == null)
                return NotFound();

            user.Password = _passwordHasher.HashPassword(user, user.Password);
            await _userService.UpdateAsync(user);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var user = await _userService.GetByIdAsync(id);
            if (user == null)
                return NotFound();

            await _userService.DeleteAsync(id);
            return NoContent();
        }
    }
}
