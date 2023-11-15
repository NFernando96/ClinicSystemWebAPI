using ClinicSystemWebAPI.Models.DTO;
using ClinicSystemWebAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace ClinicSystemWebAPI.Controllers;


[Route("api/[controller]")]
[ApiController]
public class AppointmentController : ControllerBase
{
    private readonly IAppointmentRepository _repository;

    public AppointmentController(IAppointmentRepository repository)
    {
        _repository = repository;
    }


    [HttpGet]
    public async Task<IActionResult> GetAllAppointments()
    {

        var allAppointments = await _repository.GetAllAppointments();
        return Ok(allAppointments);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetAppointmentById(int id)
    {

        var appointment = await _repository.GetAppointmentById(id);
        return Ok(appointment);

    }

    [HttpPost]
    public async Task<IActionResult> AddAppointment([FromBody] AppointmentDTO appointment)
    {

        var isAdded = await _repository.AddAppointment(appointment);

        if (isAdded)
        {
            return Ok("Appointment added successfully!");
        }
        else
        {
            return StatusCode(500, "Failed to add appointment!");
        }
    }

    [HttpPut]
    public async Task<IActionResult> UpdateAppointment(AppointmentDTOPost appointment)
    {

        var updatedAppointment = await _repository.UpdateAppointment(appointment);
        if (updatedAppointment != null)
        {
            return Ok("Appointment updated successfully!");
        }
        else
        {
            return StatusCode(500, "Failed to update appointment!");
        }

    }


    [HttpDelete("id:int")]
    public async Task<IActionResult> DeleteAppointment(int id)
    {
        var isDeleted = await _repository.DeleteAppointment(id);
        if (isDeleted)
        {
            return Ok("Appointment deleted successfully!");
        }
        else
        {
            return StatusCode(500, "Failed to delete appointment!");
        }

    }

}
