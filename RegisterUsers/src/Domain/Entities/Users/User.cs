using Domain.Entities.Address;

using Addr = Domain.Entities.Address;

namespace Domain.Entities.Users;

public class User : BaseEntity {
    public User(UserId id, string name, string email, AddressId addressId) {
        Id = id;
        Name = name;
        Email = email;
        AddressId = addressId;
    }

    public UserId Id { get; private set; }
    public string Name { get; private set; } = string.Empty;
    public string Email { get; private set; } = string.Empty;
    public string Password { get; private set; } = string.Empty;
    public AddressId AddressId { get; private set; }

    // propriedade de navegação
    public Addr.Address Address { get; set; } = default!;

    public void Update(string name, string email) {
        Name = name;
        Email = email;
    }

    public void SetEncryptedPassword(string password) {
        this.Password = password;
    }
    
    public void ActiveUser(bool active) {
        this.Active = active;
    }
}
