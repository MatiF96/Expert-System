using ClinicSystem.DTO;
using ClinicSystem.Services;
using ClinicSystem.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ClinicSystem.Controllers
{
    [Route("api/[controller]")]
    [Authorize(Policy = "Admin")]
    [ApiController]
    public partial class AdminController : ControllerBase
    {
        private readonly IUsersService _usersService;
        private readonly IAuthService _authService;

        public AdminController(IUsersService usersService, IAuthService authService)
        {
            _usersService = usersService;
            _authService = authService;
        }

        [HttpGet("users")]
        [ProducesResponseType(typeof(List<UserDto>), 200)]
        [ProducesResponseType(401)]
        public async Task<ActionResult> GetAll()
        {
            return Ok(await _usersService.GetAll());
        }
        [HttpGet("users/{userId}")]
        [ProducesResponseType(typeof(UserDto), 200)]
        [ProducesResponseType(typeof(Error), 404)]
        [ProducesResponseType(401)]
        public async Task<ActionResult> Get(int userId)
        {
            var result = await _usersService.Get(userId);
            if (result == null) return NotFound(new Error("User not found"));
            return Ok(result);
        }

        [HttpPost("users/{userId}/role")]
        [ProducesResponseType(typeof(UserDto), 200)]
        [ProducesResponseType(typeof(Error), 400)]
        [ProducesResponseType(typeof(Error), 404)]
        [ProducesResponseType(401)]
        public async Task<ActionResult> Edit(int userId, [FromBody] EditUserRoleDto editUserRole)
        {
            var currentId = int.Parse(User.Claims.First(i => i.Type == ClaimTypes.Sid).Value);
            if (currentId == userId) return BadRequest(new Error("Cannot change role on yourself!"));
            var user = await _usersService.Get(userId);
            if (user == null) return NotFound(new Error("User not found"));
            if (!UserRole.isUserRole(editUserRole.Role)) return BadRequest(new Error("Provide corrent role"));
            var result = await _usersService.ChangeRole(userId, editUserRole.Role);
            return Ok(result);
        }

        [HttpDelete("users/{userId}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(Error), 404)]
        [ProducesResponseType(401)]
        public async Task<ActionResult> Delete(int userId)
        {
            var result = await _usersService.Delete(userId);
            if (result == null) return NotFound(new Error("User not found"));
            return Ok();
        }

        [HttpPost("users")]
        [ProducesResponseType(typeof(UserDto), 200)]
        [ProducesResponseType(typeof(Error), 400)]
        public async Task<ActionResult> AddUser([FromBody] RegisterDto credentials)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new Error("Invalid credentials"));
            }

            if (await _authService.UserExists(credentials.Login))
            {
                return BadRequest(new Error("User with this login already exists"));
            }
            var user = await _authService.Register(credentials);
            return Ok(user);
        }

    }
}
