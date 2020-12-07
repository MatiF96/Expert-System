using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using ClinicSystem.DTO;
using ClinicSystem.Services;
using ClinicSystem.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClinicSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly IJwtService _jwtService;

        public AuthController(IAuthService authService, IJwtService jwtService)
        {
            _authService = authService;
            _jwtService = jwtService;
        }

        [HttpPost("register")]
        [ProducesResponseType(typeof(UserDto), 200)]
        [ProducesResponseType(typeof(Error), 400)]
        public async Task<ActionResult> Register([FromBody] RegisterDto credentials)
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

        [HttpPost("login")]
        [ProducesResponseType(typeof(LoginResponse), 200)]
        [ProducesResponseType(typeof(Error), 400)]
        public async Task<ActionResult> Login([FromBody] LoginDto credentials)
        {
            var user = await _authService.Login(credentials);
            if (user == null) return BadRequest(new Error("Invalid credentials"));
            return Ok(new LoginResponse()
            {
                Token = _jwtService.CreateToken(user),
                User = user
            });
        }


        [HttpGet("whoami")]
        [Authorize]
        [ProducesResponseType(typeof(UserDto), 200)]
        [ProducesResponseType(typeof(Error), 404)]

        public async Task<ActionResult> WhoAmIAsync()
        {
            var userId = User.Claims.First(i => i.Type == ClaimTypes.Sid).Value;
            var user = await _authService.GetUserInfo(int.Parse(userId));
            if (user == null) return NotFound(new Error("User not found"));
            return Ok(user);
        }
    }
}
