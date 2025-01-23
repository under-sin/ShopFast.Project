using Application.Cases.Users.Inactive;
using Application.Cases.Users.Profile.GetUserProfile;
using Application.Cases.Users.Profile.UpdateUserProfile;
using Application.Cases.Users.Register;
using Carter;
using Communication.Requests;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Web.API.Endpoints;

// usando o carter para criar um módulo de rota
// Podemos usar a classe abstratar para definir uma rota padrão e adicionar autenticação
public class Users : CarterModule {
    public Users() : base("/users") {
        WithTags("Users");
    }

    public override void AddRoutes(IEndpointRouteBuilder app) {
        app.MapPost("", async ([FromServices] IRegisterUser useCase, [FromBody] RegisterUserRequestJson request) => {
            var response = await useCase.Execute(request);
            return Results.Created(string.Empty, response);
        });

        app.MapGet("/{id}", async ([FromServices] IGetUserProfile useCase, Guid id) => {
            var response = await useCase.Execute(id);
            return Results.Ok(response);
        });

        app.MapPut("/{id}", async([FromServices] IUpdateUserProfile useCase, [FromBody] UpdateUserRequestJson request, Guid id) => {
            await useCase.Execute(id, request);
            return Results.NoContent();
        });

        app.MapDelete("/{id}", async([FromServices] IInactiveUser useCase, Guid id) => {
            await useCase.Execute(id);
            return Results.NoContent();
        });
    }
}
