namespace Domain.Entities.Users;

public interface IUserRepository {
    Task<User?> GetByIdAsync(UserId id);
    Task<User?> GetByEmailAsync(string email);
    Task<bool> ExistActiveUserWithEmail(string email, UserId id);
    Task AddAsync(User user);
    void UpdateAsync(User user);
    void Delete(User user);
}
