using Communication.Exceptions;
using Communication.Requests;
using Communication.Responses;
using Domain.Entities.Users;
using Domain.Entities.Address;
using Application.Data;
using FluentValidation.Results;

namespace Application.Cases.Users.Register;

public class RegisterUser : IRegisterUser {
    private readonly IUserRepository _userRepository;
    private readonly IAddressRepository _addressRepository;
    private readonly IUnitOfWork _unitOfWork;

    public RegisterUser(IUserRepository userRepository, IAddressRepository addressRepository, IUnitOfWork unitOfWork) {
        _userRepository = userRepository;
        _addressRepository = addressRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<RegisterUserResponseJson> Execute(RegisterUserRequestJson request) {
        await ValidateAsync(request);
        (User user, Address address) = request.ToUserAndAddress();
        
        // criptografar senha
        
        await _addressRepository.AddAsync(address);
        await _userRepository.AddAsync(user);
        await _unitOfWork.SaveChangesAsync();

        return new RegisterUserResponseJson { Name = user.Name };
    }

    public async Task ValidateAsync(RegisterUserRequestJson request) {
        var validation = new RegisterUserValidation();
        var result = validation.Validate(request);

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
