using Application.Data;
using Domain.Entities.Address;
using Domain.Entities.Users;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Repositories;

public class AddressRepository : IAddressRepository {
    private readonly IApplicationDbContext _context;

    public AddressRepository(IApplicationDbContext context) {
        _context = context;
    }

    public async Task AddAsync(Address address) {
        await _context.Addresses.AddAsync(address);
    }

    public async Task<Address?> GetByAddressIdAsync(AddressId id) {
        return await _context.Addresses.SingleOrDefaultAsync(a => a.Id == id);
    }

    public void UpdateAsync(Address address) {
        _context.Addresses.Update(address);
    }
}
