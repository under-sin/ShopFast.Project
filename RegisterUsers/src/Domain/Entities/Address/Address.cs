using Domain.Entities.Users;

namespace Domain.Entities.Address;

public class Address {
    public Address(AddressId id, string zipCode, string street, string complement, string neighborhood, int number, string city, string uf, string state, string region) {
        Id = id;
        ZipCode = zipCode;
        Street = street;
        Complement = complement;
        Neighborhood = neighborhood;
        Number = number;
        City = city;
        Uf = uf;
        State = state;
        Region = region;
    }

    public AddressId Id { get; private set; }
    public string ZipCode { get; private set; } = string.Empty;
    public string Street { get; private set; } = string.Empty;
    public string Complement { get; private set; } = string.Empty;
    public string Neighborhood { get; private set; } = string.Empty;
    public int Number { get; private set; }
    public string City { get; private set; } = string.Empty;
    public string Uf { get; private set; } = string.Empty;
    public string State { get; private set; } = string.Empty;
    public string Region { get; private set; } = string.Empty;

    public void Update(string zipCode, string street, string complement, string neighborhood, int number, string city, string uf, string state, string region) {
        ZipCode = zipCode;
        Street = street;
        Complement = complement;
        Neighborhood = neighborhood;
        Number = number;
        City = city;
        Uf = uf;
        State = state;
        Region = region;
    }
}
