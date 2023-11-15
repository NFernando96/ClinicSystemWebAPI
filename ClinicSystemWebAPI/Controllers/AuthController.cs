using ClinicSystemWebAPI.Models.Domain;
using ClinicSystemWebAPI.Models.DTO;
using ClinicSystemWebAPI.Repository;
using Microsoft.AspNetCore.Mvc;

namespace ClinicSystemWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {

        private readonly IAuthRepository _authRepository;

        public AuthController(IAuthRepository authRepository)
        {
            _authRepository = authRepository;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(UserDTO userDto)
        {
            var user = await _authRepository.AuthenticateAsync(userDto.Username, userDto.Password);

            if (user == null)
                return Unauthorized("Invalid username or password!");


            return Ok($"Welcome, {user.Username}!");
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(UserDTO userDto)
        {
            var isRegistered = await _authRepository.RegisterAsync(new User { Username = userDto.Username, Password = userDto.Password });

            if (!isRegistered)
                return Conflict("Username already exists");

            return Ok($"User {userDto.Username} registered successfully!");
        }
    }
}
