using Communication.Requests;
using FluentValidation;

namespace Application.Cases.Users.Register;

public class RegisterUserValidation : AbstractValidator<RegisterUserRequestJson> {
    public RegisterUserValidation() {
        RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessage("Name is required");

        RuleFor(x => x.Email)
            .NotEmpty()
            .WithMessage("Email is required");

        RuleFor(x => x.Password.Length)
            .GreaterThanOrEqualTo(6)
            .WithMessage("Password must have at least 6 characters");

        // validar endereço

        When(user => !string.IsNullOrEmpty(user.Email), () => {
            RuleFor(x => x.Email)
                .EmailAddress()
                .WithMessage("Invalid email");
        });
    }
}
