using ClinicSystemWebAPI.Models.Domain;
using ClinicSystemWebAPI.Repository;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("upload")]
public class UploadController : ControllerBase
{
    private readonly IBulkPatientUploadRepository _uploadRepository;

    public UploadController(IBulkPatientUploadRepository uploadRepository)
    {
        _uploadRepository = uploadRepository;
    }

    [HttpPost("patients")]
    public async Task<IActionResult> BulkUploadPatients(List<Patient> patients)
    {
        if (patients == null)
        {
            return BadRequest("No patients for upload!");
        }

        try
        {
            await _uploadRepository.AddPatientsAsync(patients);
            return Ok("Patients uploaded successfully!");
        }
        catch (InvalidOperationException)
        {
            return StatusCode(500, "Upload failed!");
        }
    }
}
