using Domain.Entities.Address;

using Addr = Domain.Entities.Address;

namespace Domain.Entities.Users;

public class User : BaseEntity {
    public User(UserId id, string name, string email, string password, AddressId addressId) {
        Id = id;
        Name = name;
        Email = email;
        Password = password;
        AddressId = addressId;
    }

    public UserId Id { get; private set; }
    public string Name { get; private set; } = string.Empty;
    public string Email { get; private set; } = string.Empty;
    public string Password { get; private set; } = string.Empty;
    public AddressId AddressId { get; private set; }

    // propriedade de navegação
    public Addr.Address Address { get; set; } = default!;

    public void Update(UserId id, string name, string email, string password) {
        Id = id;
        Name = name;
        Email = email;
        Password = password;
    }
}
