using Application.Data;
using Communication.Exceptions;
using Communication.Requests;
using Communication.Responses;
using Domain.Entities.Users;
using FluentValidation;
using FluentValidation.Results;

namespace Application.Cases.Users.Profile.UpdateUserProfile;

public class UpdateUserProfile : IUpdateUserProfile {
    private readonly IUserRepository _userRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IValidator<UpdateUserRequestJson> _validator;

    public UpdateUserProfile(IUserRepository userRepository, IValidator<UpdateUserRequestJson> validator, IUnitOfWork unitOfWork) {
        _userRepository = userRepository;
        _validator = validator;
        _unitOfWork = unitOfWork;
    }

    public async Task Execute(Guid id, UpdateUserRequestJson request) {
        var userId = new UserId(id);
        var user = await _userRepository.GetByIdAsync(userId)
            ?? throw new NotFoundException("User not found.");

        await ValidateAsync(userId, request);

        user.Update(request.Name, request.Email);
        _userRepository.UpdateAsync(user);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task ValidateAsync(UserId userId, UpdateUserRequestJson request) {
        var result = _validator.Validate(request);

        var emailExists = await _userRepository.ExistActiveUserWithEmail(request.Email, userId);
        if (emailExists) {
            result.Errors.Add(new ValidationFailure(string.Empty, "E-mail já cadastrado na base de dados"));
        }

        if (!result.IsValid) {
            var errorMessages = result.Errors
                .Select(x => x.ErrorMessage)
                .ToList();

            throw new OnErrorValidationException(errorMessages);
        }
    }
}
