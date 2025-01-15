namespace Communication.Requests.Common;

public class AddressRequest {
    public string ZipCode { get; set; } = string.Empty;
    public string Street { get; set; } = string.Empty;
    public string Complement { get; set; } = string.Empty;
    public string Neighborhood { get; set; } = string.Empty;
    public int Number { get; set; }
    public string City { get; set; } = string.Empty;
    public string Uf { get; set; } = string.Empty;
    public string State { get; set; } = string.Empty;
    public string Region { get; set; } = string.Empty;
}
