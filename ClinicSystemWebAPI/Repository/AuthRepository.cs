using ClinicSystemWebAPI.Data;
using ClinicSystemWebAPI.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace ClinicSystemWebAPI.Repository;

public class AuthRepository : IAuthRepository
{
    private readonly ClinicWebDbContext _context;

    public AuthRepository(ClinicWebDbContext context)
    {
        _context = context;
    }

    public async Task<User> AuthenticateAsync(string username, string password)
    {
        return await _context.Users.FirstOrDefaultAsync(u => u.Username == username && u.Password == password);
    }

    public async Task<bool> RegisterAsync(User user)
    {
        var existingUser = await _context.Users.FirstOrDefaultAsync(u => u.Username == user.Username);

        if (existingUser != null)
            return false;

        _context.Users.Add(user);
        await _context.SaveChangesAsync();
        return true;
    }

}
