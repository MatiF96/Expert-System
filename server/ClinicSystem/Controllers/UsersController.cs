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
    [ApiController]
    [Authorize]
    public class UsersController : ControllerBase
    {
        private readonly IUsersService _usersService;

        public UsersController(IUsersService usersService)
        {
            _usersService = usersService;
        }

        [HttpPost]
        [ProducesResponseType(typeof(UserDto), 200)]
        [ProducesResponseType(typeof(Error), 400)]
        [ProducesResponseType(typeof(Error), 404)]
        [ProducesResponseType(401)]
        public async Task<ActionResult> Edit([FromBody] EditUserDto editUserDto)
        {
            var userId = int.Parse(User.Claims.First(i => i.Type == ClaimTypes.Sid).Value);
            var result = await _usersService.EditUser(userId, editUserDto);
            return Ok(result);
        }

        [HttpGet("patients")]
        [Authorize(Policy = "Doctor")]
        [ProducesResponseType(typeof(List<UserDto>), 200)]
        [ProducesResponseType(typeof(Error), 404)]
        [ProducesResponseType(401)]
        public async Task<ActionResult> GetPatients()
        {
            var result = await _usersService.GetPatients();
            return Ok(result);
        }
    }
}
