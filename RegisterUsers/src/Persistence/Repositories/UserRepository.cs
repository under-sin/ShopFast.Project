using Application.Data;
using Domain.Entities.Users;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Repositories;

public class UserRepository : IUserRepository {
    private readonly IApplicationDbContext _context;

    public UserRepository(IApplicationDbContext context) {
        _context = context;
    }

    public async Task AddAsync(User user) {
        await _context.Users.AddAsync(user);
    }

    public void Delete(User user) {
        _context.Users.Remove(user);
    }

    public async Task<bool> EmailExistsAsync(string email) {
        return await _context.Users.AnyAsync(u => u.Email == email && u.Active);
    }

    public async Task<bool> ExistActiveUserWithEmail(string email, UserId id) {
        return await _context.Users.AnyAsync(u => u.Email.Equals(email) && u.Id != id && u.Active);
    }

    public async Task<User?> GetByIdAsync(UserId id) {
        return await _context.Users.SingleOrDefaultAsync(u => u.Id == id);
    }

    public void UpdateAsync(User user) {
        _context.Users.Update(user);
    }
}
