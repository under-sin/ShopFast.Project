using Application.Cases.Users.Profile.GetUserProfile;
using Application.Cases.Users.Register;
using Carter;
using Communication.Requests;
using Microsoft.AspNetCore.Mvc;

namespace Web.API.Endpoints;

// usando o carter para criar um módulo de rota
// Podemos usar a classe abstratar para definir uma rota padrão e adicionar autenticação
public class Users : ICarterModule {
    public void AddRoutes(IEndpointRouteBuilder app) {
        app.MapPost("/users", async ([FromServices] IRegisterUser useCase, [FromBody] RegisterUserRequestJson request) => {
            var response = await useCase.Execute(request);
            return Results.Created(string.Empty, response);
        });

        app.MapGet("/users/{id}", async ([FromServices] IGetUserProfile useCase, Guid id) => {
            var response = await useCase.Execute(id);
            return Results.Ok(response);
        });
    }
}
