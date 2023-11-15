using ClinicSystemWebAPI.Models.Domain;
using ClinicSystemWebAPI.Models.DTO;
using ClinicSystemWebAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace ClinicSystemWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly IPatientRepository _repository;

        public PatientController(IPatientRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPatients()
        {
            var allPatients = await _repository.GetAllPatients();
            return Ok(allPatients);

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPatientById(int id)
        {
            var patient = await _repository.GetPatientById(id);
            return Ok(patient);

        }

        [HttpPost]
        public async Task<IActionResult> AddPatient([FromBody] PatientDTO patient)
        {
            var isAdded = await _repository.AddPatient(patient);
            if (isAdded)
            {
                return Ok("Patient added successfully.");
            }
            else
            {
                return StatusCode(500, "Failed to add patient!");
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdatePatient(Patient patient)
        {
            var updatedPatient = await _repository.UpdatePatient(patient);
            if (updatedPatient != null)
            {
                return Ok("Patient updated successfully!");
            }
            else
            {
                return StatusCode(500, "Failed to update patient!");
            }

        }


        [HttpDelete("id:int")]
        public async Task<IActionResult> DeletePatient(int id)
        {

            var isDeleted = await _repository.DeletePatient(id);
            if (isDeleted)
            {
                return Ok("Patient deleted successfully!");
            }
            else
            {
                return StatusCode(500, "Failed to delete patient!");
            }
        }
    }
}
