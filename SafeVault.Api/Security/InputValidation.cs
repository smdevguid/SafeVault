using System.Text.RegularExpressions;
using System.Net;

namespace SafeVault.Security
{
    public static class InputValidation
    {
        public static string SanitizeInput(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return string.Empty;

            // Codifica caracteres potencialmente peligrosos
            return WebUtility.HtmlEncode(input.Trim());
        }

        public static bool ValidateEmail(string email)
        {
            return Regex.IsMatch(
                email,
                @"^[^@\s]+@[^@\s]+\.[^@\s]+$"
            );
        }

        public static bool ValidateUsername(string username)
        {
            return Regex.IsMatch(
                username,
                @"^[a-zA-Z0-9_]{3,20}$"
            );
        }
    }
}