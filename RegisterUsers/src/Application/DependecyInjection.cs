using Application.Cases.Users.Inactive;
using Application.Cases.Users.Profile.GetUserProfile;
using Application.Cases.Users.Profile.UpdateUserProfile;
using Application.Cases.Users.Register;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace Application;

public static class DependecyInjection {
    public static void AddApplication(this IServiceCollection services) {
        AddCases(services);
        AddFluentValidation(services);
    }

    private static void AddCases(IServiceCollection services) {
        services.AddScoped<IRegisterUser, RegisterUser>();
        services.AddScoped<IGetUserProfile, GetUserProfile>();
        services.AddScoped<IInactiveUser, InactiveUser>();
        services.AddScoped<IUpdateUserProfile, UpdateUserProfile>();
    }

    private static void AddFluentValidation(IServiceCollection services) {
        services.AddValidatorsFromAssemblyContaining<RegisterUserValidator>();
    }
}
