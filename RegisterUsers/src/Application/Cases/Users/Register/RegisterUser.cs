using Communication.Exceptions;
using Communication.Requests;
using Communication.Responses;
using Domain.Entities.Users;
using Domain.Entities.Address;
using Application.Data;
using FluentValidation.Results;
using FluentValidation;

namespace Application.Cases.Users.Register;

public class RegisterUser : IRegisterUser {
    private readonly IUserRepository _userRepository;
    private readonly IAddressRepository _addressRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IValidator<RegisterUserRequestJson> _validator;
    private readonly IPasswordEncripter _passwordEncripter;

    public RegisterUser(
        IUserRepository userRepository,
        IAddressRepository addressRepository,
        IUnitOfWork unitOfWork,
        IValidator<RegisterUserRequestJson> validator,
        IPasswordEncripter passwordEncripter)
    {
        _userRepository = userRepository;
        _addressRepository = addressRepository;
        _unitOfWork = unitOfWork;
        _validator = validator;
        _passwordEncripter = passwordEncripter;
    }

    public async Task<RegisterUserResponseJson> Execute(RegisterUserRequestJson request) {
        await ValidateAsync(request);
        (User user, Address address) = request.ToUserAndAddress();

        var encryptedPassword = _passwordEncripter.Encrypt(user.Password);
        user.SetEncryptedPassword(encryptedPassword);
        
        await _addressRepository.AddAsync(address);
        await _userRepository.AddAsync(user);
        await _unitOfWork.SaveChangesAsync();

        return new RegisterUserResponseJson { Name = user.Name, Email = user.Email };
    }

    public async Task ValidateAsync(RegisterUserRequestJson request) {
        var result = _validator.Validate(request);

        var emailExists = await _userRepository.EmailExistsAsync(request.Email);
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
