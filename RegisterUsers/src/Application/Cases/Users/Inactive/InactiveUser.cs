using Application.Data;
using Communication.Exceptions;
using Domain.Entities.Users;

namespace Application.Cases.Users.Inactive;

public class InactiveUser : IInactiveUser {
    private readonly IUserRepository _userRepository;
    private readonly IUnitOfWork _unitOfWork;

    public InactiveUser(IUserRepository userRepository, IUnitOfWork unitOfWork) {
        _userRepository = userRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task Execute(Guid id) {
        var userId = new UserId(id);
        var user = await _userRepository.GetByIdAsync(userId) 
            ?? throw new NotFoundException("User not found.");
        user.ActiveUser(false);

        _userRepository.UpdateAsync(user);
        await _unitOfWork.SaveChangesAsync();
    }
}