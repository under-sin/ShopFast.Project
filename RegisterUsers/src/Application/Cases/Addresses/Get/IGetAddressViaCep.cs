using System;
using Communication.Responses;

namespace Application.Cases.Addresses.Get;

public interface IGetAddressViaCep
{
    Task<ResponseAddressJson> Execute(string cep);
}
