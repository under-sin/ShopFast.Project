using Application.Data;
using Domain.Entities.Address;
using Domain.Entities.Users;
using Microsoft.EntityFrameworkCore;

namespace Persistence;

public class ApplicationDbContext : DbContext, IApplicationDbContext, IUnitOfWork {
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) 
        : base(options) {}

    protected override void OnModelCreating(ModelBuilder modelBuilder) {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
    }

    public DbSet<User> Users { get; set; }
    public DbSet<Address> Addresses { get; set; }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default) {
        return base.SaveChangesAsync(cancellationToken);
    }
}
