namespace Application.Cases.Users.Inactive;

public interface IInactiveUser {
    Task Execute(Guid id);
}