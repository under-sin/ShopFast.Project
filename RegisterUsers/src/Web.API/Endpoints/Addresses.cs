using Application.Cases.Addresses.Get;
using Carter;
using Microsoft.AspNetCore.Mvc;

namespace Web.API.Endpoints;

public class Addresses : CarterModule {
    public Addresses() : base("/addresses") {
        WithTags("Addresses");
    }

    public override void AddRoutes(IEndpointRouteBuilder app) {
        app.MapGet("/{cep}", async ([FromServices] IGetAddressViaCep useCase, string cep) => {
            var response = await useCase.Execute(cep);
            return Results.Ok(response);
        });
    }
}
