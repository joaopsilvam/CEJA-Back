using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Enceja.Domain.Entities;
using Enceja.Domain.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace Enceja.API.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IPasswordHasher<User> _passwordHasher;

        public UserController(IUserService userService, IPasswordHasher<User> passwordHasher)
        {
            _userService = userService;
            _passwordHasher = passwordHasher;
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
            await _userService.AddAsync(user);
            return CreatedAtAction(nameof(GetAll), new { id = user.Id }, user);
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
