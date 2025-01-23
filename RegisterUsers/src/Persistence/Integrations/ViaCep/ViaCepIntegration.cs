using System.Text.Json;
using Communication.Exceptions;
using Communication.Integrations;
using Communication.Responses;

namespace Infrastructure.Integrations.ViaCep;

public class ViaCepIntegration : IViaCepIntegration
{
    private static readonly HttpClient httpClient = new();
    private readonly string _viaCepUrlBase = "https://viacep.com.br/ws/";

    public async Task<ResponseAddressJson> GetAddressByCepAsync(string cep)
    {
        var response = await httpClient.GetAsync($"{_viaCepUrlBase}{cep}/json/");
        response.EnsureSuccessStatusCode();

        var content = await response.Content.ReadAsStringAsync();
        var viaCepResponse = JsonSerializer.Deserialize<ResponseAddressJson>(content);

        if (viaCepResponse is null)
            throw new NotFoundException("CEP not found.");

        return viaCepResponse;
    }
}
