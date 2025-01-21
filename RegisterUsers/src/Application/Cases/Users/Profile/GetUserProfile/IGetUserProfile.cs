using Communication.Responses;
using Domain.Entities.Users;

namespace Application.Cases.Users.Profile.GetUserProfile;

public interface IGetUserProfile {
    Task<ResponseUserProfileJson> Execute(Guid Id);
}
