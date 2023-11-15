using ClinicSystemWebAPI.Models.Domain;
using ClinicSystemWebAPI.Models.DTO;
using Microsoft.AspNetCore.Mvc;

namespace ClinicSystemWebAPI.Services
{
    public interface IPatientRepository
    {

        public Task<List<Patient>> GetAllPatients();

        public Task<Patient> GetPatientById(int id);

        public Task<bool> AddPatient([FromBody] PatientDTO patient);

        public Task<Patient> UpdatePatient(Patient patient);

        public Task<bool> DeletePatient(int id);

    }
}
