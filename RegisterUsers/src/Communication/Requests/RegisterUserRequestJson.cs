using Communication.Requests.Common;
using Domain.Entities.Address;
using Domain.Entities.Users;

namespace Communication.Requests;

public class RegisterUserRequestJson {
    public string Email { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public AddressRequest Address { get; set; } = default!;

    public (User, Address) ToUserAndAddress() {
        var userId = new UserId(Guid.NewGuid());
        var addressId = new AddressId(Guid.NewGuid());

        var address = new Address(
            addressId,
            Address.ZipCode,
            Address.Street,
            Address.Complement!,
            Address.Neighborhood,
            Address.Number,
            Address.City,
            Address.Uf,
            Address.State,
            Address.Region
        );

        var user = new User(
            userId,
            Name,
            Email,
            Password,
            addressId
        );

        return (user, address);
    }
}
