using Communication.Requests;
using Communication.Responses;

namespace Application.Cases.Users.Profile.UpdateUserProfile;

public interface IUpdateUserProfile {
    Task Execute(Guid id, UpdateUserRequestJson request);
}
