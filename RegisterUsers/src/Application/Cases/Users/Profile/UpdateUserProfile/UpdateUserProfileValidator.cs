using System;
using Communication.Requests;
using FluentValidation;

namespace Application.Cases.Users.Profile.UpdateUserProfile;

public class UpdateUserProfileValidator : AbstractValidator<UpdateUserRequestJson> {
    public UpdateUserProfileValidator() {
        RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessage("Name is required");

        RuleFor(x => x.Email)
            .NotEmpty()
            .WithMessage("Email is required");

        When(user => !string.IsNullOrEmpty(user.Email), () => {
            RuleFor(x => x.Email)
                .EmailAddress()
                .WithMessage("Invalid email");
        });
    }
}