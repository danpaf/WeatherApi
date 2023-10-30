using System.Security.Cryptography;
using System.Text;
using MoscowApi.Database;
using MoscowApi.Database.Models;

namespace MoscowApi.Services;

public class UserService
{
    private readonly ApplicationContext _context;
    private const int SaltSize = 16;

    public UserService(ApplicationContext context)
    {
        _context = context;
    }

    public async Task<User> CreateUserAsync(string username, string password)
    {
        
        byte[] salt = new byte[SaltSize];
        using (var rng = new RNGCryptoServiceProvider())
        {
            rng.GetBytes(salt);
        }

        byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
        byte[] saltedPasswordBytes = new byte[passwordBytes.Length + salt.Length];
        Array.Copy(passwordBytes, saltedPasswordBytes, passwordBytes.Length);
        Array.Copy(salt, 0, saltedPasswordBytes, passwordBytes.Length, salt.Length);

        using (var sha256 = SHA256.Create())
        {
            byte[] hash = sha256.ComputeHash(saltedPasswordBytes);

            string hashString = BitConverter.ToString(hash).Replace("-", string.Empty);
            string saltString = BitConverter.ToString(salt).Replace("-", string.Empty);

            
            var user = new User
            {
                Username = username,
                PasswordHash = hashString,
                Salt = saltString
            };

            
            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return user;
        }
    }

    public async Task<bool> AuthenticateUserAsync(string username, string password)
    {
        var user = _context.Users.SingleOrDefault(x => x.Username == username);

        if (user == null)
        {
            // throw new UnauthorizedAccessException("User not found");
            return false;
        }

        byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
        byte[] saltBytes = HexToByteArray(user.Salt);

        byte[] saltedPasswordBytes = new byte[passwordBytes.Length + saltBytes.Length];
        Array.Copy(passwordBytes, saltedPasswordBytes, passwordBytes.Length);
        Array.Copy(saltBytes, 0, saltedPasswordBytes, passwordBytes.Length, saltBytes.Length);

        using (var sha256 = SHA256.Create())
        {
            byte[] hash = sha256.ComputeHash(saltedPasswordBytes);

            string hashString = BitConverter.ToString(hash).Replace("-", string.Empty);

            if (hashString != user.PasswordHash)
            {
                return false;
            }
            return true;
        }
    }


    private static byte[] HexToByteArray(string hex)
    {
        int length = hex.Length / 2;
        byte[] bytes = new byte[length];
        for (int i = 0; i < length; i++)
        {
            bytes[i] = Convert.ToByte(hex.Substring(i * 2, 2), 16);
        }
        return bytes;
    }

}

