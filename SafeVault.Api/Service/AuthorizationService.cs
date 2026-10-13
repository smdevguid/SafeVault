namespace SafeVault.Security;

public static class AuthorizationService
{
    public static bool HasRole(string userRole, string requiredRole)
    {
        return string.Equals(userRole, requiredRole, StringComparison.OrdinalIgnoreCase);
    }
}

// Ejemplo ASP.NET Core
// [Authorize(Roles = "Admin")]
// public IActionResult AdminDashboard() => View();
