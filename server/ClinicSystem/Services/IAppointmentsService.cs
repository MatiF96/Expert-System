using ClinicSystem.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicSystem.Services
{
    public interface IAppointmentsService
    {
        Task<AppointmentDto> Add(AddAppointmentDto appointmentDto);
        Task<AppointmentDto> Edit(int appointmentId, EditAppointmentDto appointmentDto);
        Task<int?> Delete(int appointmentId);
        Task<AppointmentDto> Get(int appointmentId);
        Task<List<AppointmentDto>> GetDoctorAppointments(int doctorId);
        Task<List<AppointmentDto>> GetPatientAppointments(int patientId);
        Task<List<AppointmentDto>> GetAll();
    }
}
