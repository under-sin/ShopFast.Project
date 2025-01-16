using Communication.Requests.Common;
using FluentValidation;

namespace Application.Cases.Addresses;

public class AddressRequestValidator : AbstractValidator<AddressRequest> {
    public AddressRequestValidator() {
        RuleFor(x => x.ZipCode)
            .NotEmpty().WithMessage("O CEP é obrigatório.")
            .MaximumLength(9).WithMessage("O CEP deve ter no máximo 9 caracteres.");

        RuleFor(x => x.State)
            .NotEmpty().WithMessage("O estado é obrigatório.")
            .MaximumLength(20).WithMessage("O estado deve ter no máximo 20 caracteres.");

        RuleFor(x => x.City)
            .NotEmpty().WithMessage("A cidade é obrigatória.")
            .MaximumLength(35).WithMessage("A cidade deve ter no máximo 35 caracteres.");

        RuleFor(x => x.Street)
            .NotEmpty().WithMessage("A rua é obrigatória.")
            .MaximumLength(100).WithMessage("A rua deve ter no máximo 100 caracteres.");

        RuleFor(x => x.Neighborhood)
            .NotEmpty().WithMessage("O bairro é obrigatório.")
            .MaximumLength(35).WithMessage("O bairro deve ter no máximo 35 caracteres.");

        RuleFor(x => x.Uf)
            .NotEmpty().WithMessage("A unidade federativa (UF) é obrigatória.")
            .MaximumLength(2).WithMessage("A unidade federativa (UF) deve ter no máximo 2 caracteres.");

        RuleFor(x => x.Number)
            .NotEmpty().WithMessage("O número é obrigatório.");

        RuleFor(x => x.Complement)
            .MaximumLength(50).WithMessage("O complemento deve ter no máximo 50 caracteres.");

        RuleFor(x => x.Region)
            .NotEmpty().WithMessage("A região é obrigatória.")
            .MaximumLength(20).WithMessage("A região deve ter no máximo 20 caracteres.");
    }
}
