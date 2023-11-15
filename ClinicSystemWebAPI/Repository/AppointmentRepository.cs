using ClinicSystemWebAPI.Data;
using ClinicSystemWebAPI.Models.Domain;
using ClinicSystemWebAPI.Models.DTO;
using Microsoft.EntityFrameworkCore;

namespace ClinicSystemWebAPI.Services
{
    public class AppointmentRepository : IAppointmentRepository
    {
        private readonly ClinicWebDbContext _context;

        public AppointmentRepository(ClinicWebDbContext context)
        {
            _context = context;
        }

        public async Task<List<Appointment>> GetAllAppointments()
        {
            var result = await _context.Appointments.ToListAsync();
            return result;
        }

        public async Task<bool> AddAppointment(AppointmentDTO appointment)
        {
            var newAppointment = new Appointment
            {
                DateTime = appointment.DateTime,
                Status = appointment.Status,
                PatientId = appointment.PatientId,
            };

            await _context.Appointments.AddAsync(newAppointment);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<AppointmentDTOPost> UpdateAppointment(AppointmentDTOPost appointment)
        {

            var Updateappoinetment = new Appointment()
            {
                Id = appointment.Id,
                DateTime = appointment.DateTime,
                Status = appointment.Status,
                PatientId = appointment.PatientId,
            };



            _context.Appointments.Update(Updateappoinetment);
            await _context.SaveChangesAsync();


            return appointment;
        }

        public async Task<bool> DeleteAppointment(int id)
        {
            var appointmentToDelete = await _context.Appointments.FindAsync(id);

            if (appointmentToDelete == null)
            {
                return false;
            }

            _context.Appointments.Remove(appointmentToDelete);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<Appointment> GetAppointmentById(int id)
        {
            return await _context.Appointments.FindAsync(id);
        }


    }

}
