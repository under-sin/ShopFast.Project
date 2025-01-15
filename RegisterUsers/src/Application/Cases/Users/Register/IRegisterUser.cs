using Communication.Requests;
using Communication.Responses;

namespace Application.Cases.Users.Register;

public interface IRegisterUser {
    Task<RegisterUserResponseJson> Execute(RegisterUserRequestJson request);
}
