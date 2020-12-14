using ClinicSystem.Database;
using ClinicSystem.DTO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicSystem.Services
{
    public class AppointmentsService : IAppointmentsService
    {
        private readonly ClinicDbContext _ctx;

        public AppointmentsService(ClinicDbContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<AppointmentDto> Add(AddAppointmentDto appointmentDto)
        {
            var doctor = await _ctx.Accounts.FindAsync(appointmentDto.DoctorId);
            var patient = await _ctx.Accounts.FindAsync(appointmentDto.PatientId);
            if (doctor == null || patient == null || doctor.AccountType != UserRole.Doctor || patient.AccountType != UserRole.Patient) return null;
            var appointment = new Appointment
            {
                AppointmentDate = appointmentDto.Date,
                AppointmentDoctor = doctor,
                AppointmentPatient = patient
            };

            var result = await _ctx.Appointments.AddAsync(appointment);
            await _ctx.SaveChangesAsync();
            return new AppointmentDto(result.Entity);
        }

        public async Task<int?> Delete(int appointmentId)
        {
            var appointment = await _ctx.Appointments.FindAsync(appointmentId);
            if (appointment == null) return null;
            _ctx.Appointments.Remove(appointment);
            await _ctx.SaveChangesAsync();
            return appointment.AppointmentId;
        }

        public async Task<AppointmentDto> Edit(int appointmentId, EditAppointmentDto appointmentDto)
        {
            var appointment = await _ctx.Appointments
                .Include(d => d.AppointmentDoctor)
                .Include(p => p.AppointmentPatient)
                .SingleOrDefaultAsync(a => a.AppointmentId == appointmentId);
            if (appointment == null) return null;
            appointment.AppointmentDate = appointmentDto.Date;
            _ctx.Appointments.Update(appointment);
            await _ctx.SaveChangesAsync();

            return new AppointmentDto(appointment);
        }

        public async Task<AppointmentDto> Get(int appointmentId)
        {
            var appointment = await _ctx.Appointments
                .Include(d => d.AppointmentDoctor)
                .Include(p => p.AppointmentPatient)
                .SingleOrDefaultAsync(a => a.AppointmentId == appointmentId);
            return new AppointmentDto(appointment);
        }

        public async Task<List<AppointmentDto>> GetAll()
        {
            List<Appointment> appointments = await _ctx.Appointments
                  .Include(d => d.AppointmentDoctor)
                  .Include(p => p.AppointmentPatient).ToListAsync();
            return appointments.Select(a => new AppointmentDto(a)).ToList();
        }

        public async Task<List<AppointmentDto>> GetDoctorAppointments(int doctorId)
        {
            List<Appointment> appointments = await _ctx.Appointments
                  .Where(a => a.AppointmentDoctorId == doctorId)
                  .Include(d => d.AppointmentDoctor)
                  .Include(p => p.AppointmentPatient).ToListAsync();
            return appointments.Select(a => new AppointmentDto(a)).ToList();
        }

        public async Task<List<AppointmentDto>> GetPatientAppointments(int patientId)
        {
            List<Appointment> appointments = await _ctx.Appointments
                  .Where(a => a.AppointmentPatientId == patientId)
                  .Include(d => d.AppointmentDoctor)
                  .Include(p => p.AppointmentPatient).ToListAsync();
            return appointments.Select(a => new AppointmentDto(a)).ToList();
        }
    }
}
