using ClinicSystemWebAPI.Data;
using ClinicSystemWebAPI.Models.Domain;
using ClinicSystemWebAPI.Models.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ClinicSystemWebAPI.Services
{
    public class PatientRepository : IPatientRepository
    {

        private readonly ClinicWebDbContext _context;

        public PatientRepository(ClinicWebDbContext context)
        {
            _context = context;
        }

        public async Task<bool> AddPatient([FromBody] PatientDTO patient)
        {
            var newPatient = new Patient()
            {

                Name = patient.Name,
                Email = patient.Email

            };

            await _context.Patients.AddAsync(newPatient);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeletePatient(int id)
        {
            var patientToDelete = await _context.Patients.FindAsync(id);
            if (patientToDelete == null)
            {
                return false;
            }
            _context.Patients.Remove(patientToDelete);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<List<Patient>> GetAllPatients()
        {
            var result = await _context.Patients.ToListAsync();
            return result;

        }

        public async Task<Patient> GetPatientById(int id)
        {
            return await _context.Patients.FindAsync(id);
        }

        public async Task<Patient> UpdatePatient(Patient patient)
        {
            var updatePatient = new Patient()
            {
                Id = patient.Id,
                Name = patient.Name,
                Email = patient.Email
            };

            _context.Patients.Update(updatePatient);
            await _context.SaveChangesAsync();

            return patient;
        }
    }
}
