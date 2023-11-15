using ClinicSystemWebAPI.Models.Domain;
using ClinicSystemWebAPI.Models.DTO;
using Microsoft.AspNetCore.Mvc;

namespace ClinicSystemWebAPI.Services
{
    public interface IAppointmentRepository
    {
        public Task<List<Appointment>> GetAllAppointments();

        public Task<bool> AddAppointment([FromBody] AppointmentDTO appoinment);

        public Task<AppointmentDTOPost> UpdateAppointment(AppointmentDTOPost appointment);

        public Task<bool> DeleteAppointment(int id);

        public Task<Appointment> GetAppointmentById(int id);


    }
}
