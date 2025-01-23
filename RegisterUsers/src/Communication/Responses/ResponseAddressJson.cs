namespace Communication.Responses;

public class ResponseAddressJson
{
    public string cep { get; set; } = string.Empty;
    public string logradouro { get; set; } = string.Empty;
    public string complemento { get; set; } = string.Empty;
    public string unidade { get; set; } = string.Empty;
    public string bairro { get; set; } = string.Empty;
    public string localidade { get; set; } = string.Empty;
    public string uf { get; set; } = string.Empty;
    public string estado { get; set; } = string.Empty;
    public string regiao { get; set; } = string.Empty;
}
