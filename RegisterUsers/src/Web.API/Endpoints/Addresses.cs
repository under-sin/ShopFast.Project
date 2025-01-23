using Carter;

namespace Web.API.Endpoints;

public class Addresses : CarterModule {
    public Addresses() : base("/addresses") {
        WithTags("Addresses");
    }

    public override void AddRoutes(IEndpointRouteBuilder app) {
        app.MapGet("/{cep}", (string cep) => {
            return Results.Ok(cep);
        });
    }
}
