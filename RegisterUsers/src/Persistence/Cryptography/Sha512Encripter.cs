using System.Security.Cryptography;
using System.Text;
using Domain.Entities.Users;

namespace Persistence.Cryptography;

public class Sha512Encripter : IPasswordEncripter {
    public string Encrypt(string password) {
        var bytes = Encoding.UTF8.GetBytes(password);
        var hashBytes = SHA512.HashData(bytes);

        return StringBytes(hashBytes);
    }

    /// transforma um array de bytes em string.
    private static string StringBytes(byte[] bytes) {
        var sb = new StringBuilder();
        foreach (var b in bytes) {
            var hex = b.ToString("x2");
            sb.Append(hex);
        }

        return sb.ToString();
    }
}
