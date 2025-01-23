using Communication.Responses;

namespace Communication.Integrations;

public interface IViaCepIntegration
{
    Task<ResponseAddressJson> GetAddressByCepAsync(string cep);
}
