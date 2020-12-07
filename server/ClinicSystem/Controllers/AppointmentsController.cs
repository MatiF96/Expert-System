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
    public class AppointmentsController : ControllerBase
    {
        private readonly IAppointmentsService _appointmentsService;

        public AppointmentsController(IAppointmentsService appointmentsService)
        {
            _appointmentsService = appointmentsService;
        }

        [HttpPost]
        [Authorize(Policy = "Doctor")]
        [ProducesResponseType(typeof(AppointmentDto), 200)]
        [ProducesResponseType(typeof(Error), 400)]
        [ProducesResponseType(typeof(Error), 404)]
        [ProducesResponseType(401)]
        public async Task<ActionResult> Add([FromBody] AddAppointmentDto appointmentDto)
        {
            if (!ModelState.IsValid) return BadRequest(new Error("Provide valid data"));
            var result = await _appointmentsService.Add(appointmentDto);
            if (result == null) return NotFound(new Error("Patient or doctor not found"));
            return Ok(result);
        }

        [HttpPost("{appointmentId}")]
        [Authorize(Policy = "Doctor")]
        [ProducesResponseType(typeof(AppointmentDto), 200)]
        [ProducesResponseType(typeof(Error), 400)]
        [ProducesResponseType(typeof(Error), 404)]
        [ProducesResponseType(401)]
        public async Task<ActionResult> Edit(int appointmentId, [FromBody] EditAppointmentDto appointmentDto)
        {
            if (!ModelState.IsValid) return BadRequest(new Error("Provide valid data"));
            var result = await _appointmentsService.Edit(appointmentId, appointmentDto);
            if (result == null) return NotFound(new Error("Appointment not found"));
            return Ok(result);
        }

        [HttpDelete("{appointmentId}")]
        [Authorize(Policy = "Doctor")]
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(Error), 404)]
        [ProducesResponseType(401)]
        public async Task<ActionResult> Delete(int appointmentId)
        {
            var result = await _appointmentsService.Delete(appointmentId);
            if (result == null) return NotFound(new Error("Appointment not found"));
            return Ok();
        }


        [HttpGet("currentUser")]
        [Authorize(Policy = "Patient")]
        [ProducesResponseType(typeof(List<AppointmentDto>),200)]
        [ProducesResponseType(typeof(Error), 404)]
        [ProducesResponseType(401)]
        public async Task<ActionResult> GetUserAppointments()
        {
            var userId = int.Parse(User.Claims.First(i => i.Type == ClaimTypes.Sid).Value);
            var role = User.Claims.First(i => i.Type == ClaimTypes.Role).Value;
            return role != UserRole.Patient
                ? Ok(await _appointmentsService.GetDoctorAppointments(userId))
                : Ok(await _appointmentsService.GetPatientAppointments(userId));
        }

        [HttpGet]
        [Authorize(Policy = "Admin")]
        [ProducesResponseType(typeof(List<AppointmentDto>), 200)]
        [ProducesResponseType(typeof(Error), 404)]
        [ProducesResponseType(401)]
        public async Task<ActionResult> GetAppointments()
        {
            return Ok(await _appointmentsService.GetAll());
        }

        [HttpGet("{appointmentId}")]
        [Authorize(Policy = "Patient")]
        [ProducesResponseType(typeof(AppointmentDto), 200)]
        [ProducesResponseType(typeof(Error), 404)]
        [ProducesResponseType(401)]
        public async Task<ActionResult> GetById(int appointmentId)
        {
            var result = await _appointmentsService.Get(appointmentId);
            if (result == null) return NotFound(new Error("Appointment not found"));
            return Ok(result);
        }







    }
}
