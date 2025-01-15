using Domain.Entities.Address;
using Domain.Entities.Users;
using Microsoft.EntityFrameworkCore;

namespace Application.Data;

public interface IApplicationDbContext {
    DbSet<User> Users { get; set; }
    DbSet<Address> Addresses { get; set; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
