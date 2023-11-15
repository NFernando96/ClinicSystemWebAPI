using ClinicSystemWebAPI.Models.Domain;

namespace ClinicSystemWebAPI.Repository
{
    public interface IAuthRepository
    {
        Task<User> AuthenticateAsync(string username, string password);
        Task<bool> RegisterAsync(User user);
    }
}
