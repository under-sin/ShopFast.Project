using Application.Cases.Users.Register;
using Microsoft.Extensions.DependencyInjection;

namespace Application;

public static class DependecyInjection {
    public static void AddApplication(this IServiceCollection services) {
        AddCases(services);
    }

    private static void AddCases(IServiceCollection services) {
        services.AddScoped<IRegisterUser, RegisterUser>();
    }

    // password encripter
}
