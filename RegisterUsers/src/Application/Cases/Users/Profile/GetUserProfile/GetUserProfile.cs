using Communication.Exceptions;
using Communication.Responses;
using Domain.Entities.Users;

namespace Application.Cases.Users.Profile.GetUserProfile;

public class GetUserProfile(IUserRepository userRepository) : IGetUserProfile {
    private readonly IUserRepository _userRepository = userRepository;

    public async Task<ResponseUserProfileJson> Execute(Guid id) {
        var userId = new UserId(id);
        var user = await _userRepository.GetByIdAsync(userId) 
            ?? throw new NotFoundException("User not found");

        return new ResponseUserProfileJson {
            Name = user.Name,
            Email = user.Email,
            IsActive = user.Active
        };
    }
}
