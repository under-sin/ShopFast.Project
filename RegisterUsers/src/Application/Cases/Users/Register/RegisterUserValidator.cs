using Application.Cases.Addresses;
using Communication.Requests;
using FluentValidation;

namespace Application.Cases.Users.Register;

public class RegisterUserValidator : AbstractValidator<RegisterUserRequestJson> {
    public RegisterUserValidator() {
        RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessage("Name is required");

        RuleFor(x => x.Email)
            .NotEmpty()
            .WithMessage("Email is required");

        RuleFor(x => x.Password.Length)
            .GreaterThanOrEqualTo(6)
            .WithMessage("Password must have at least 6 characters");

        // usa o validation do address no set validator
        RuleFor(x => x.Address)
            .NotEmpty()
            .WithMessage("Address is required")
            .SetValidator(new AddressRequestValidator());

        When(user => !string.IsNullOrEmpty(user.Email), () => {
            RuleFor(x => x.Email)
                .EmailAddress()
                .WithMessage("Invalid email");
        });
    }
}
