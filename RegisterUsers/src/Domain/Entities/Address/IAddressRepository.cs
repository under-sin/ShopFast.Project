using Domain.Entities.Users;

namespace Domain.Entities.Address;

public interface IAddressRepository {
    Task AddAsync(Address address);
    Task<Address?> GetByAddressIdAsync(AddressId id);
    void UpdateAsync(Address address);
}
