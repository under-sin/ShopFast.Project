using System;
using Communication.Exceptions;
using Communication.Integrations;
using Communication.Responses;

namespace Application.Cases.Addresses.Get;

public class GetAddressViaCep : IGetAddressViaCep
{
    private readonly IViaCepIntegration _viaCepIntegration;

    public GetAddressViaCep(IViaCepIntegration viaCepIntegration)
    {
        _viaCepIntegration = viaCepIntegration;
    }

    public async Task<ResponseAddressJson> Execute(string cep)
    {
        if (string.IsNullOrWhiteSpace(cep))
            throw new OnErrorValidationException(["o CEP não pode ser nulo"]);

        cep = cep.Replace("-", "");

        return await _viaCepIntegration.GetAddressByCepAsync(cep);
    }
}
