using BCrypt.Net;

namespace SafeVault.Api.Security;

public class AuthenticationService
{
    private readonly Dictionary<string, (string Hash, string Role)> _users
        = new();

    public bool Register(
        string username,
        string password,
        string role)
    {
        if (_users.ContainsKey(username))
            return false;

        string hash =
            BCrypt.Net.BCrypt.HashPassword(password);

        _users.Add(
            username,
            (hash, role));

        return true;
    }

    public bool ValidateUser(
        string username,
        string password)
    {
        if (!_users.ContainsKey(username))
            return false;

        var user = _users[username];

        return BCrypt.Net.BCrypt.Verify(
            password,
            user.Hash);
    }

    public string? GetRole(string username)
    {
        return _users.TryGetValue(
            username,
            out var user)
            ? user.Role
            : null;
    }
}