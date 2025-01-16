namespace Domain.Entities.Users;

public interface IPasswordEncripter {
    string Encrypt(string password);
}
