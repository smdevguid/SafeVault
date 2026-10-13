using SafeVault.Api.Security;
using Microsoft.Extensions.Configuration;
using Xunit;

namespace SafeVault.Tests;

public class JwtTests
{
    [Fact]
    public void GenerateToken_ShouldReturnValue()
    {
        var settings =
            new Dictionary<string, string>
            {
                ["Jwt:Key"] =
                    "SuperSecretKey1234567890123456789",

                ["Jwt:Issuer"] =
                    "SafeVault",

                ["Jwt:Audience"] =
                    "SafeVaultUsers"
            };

        IConfiguration config =
            new ConfigurationBuilder()
                .AddInMemoryCollection(settings!)
                .Build();

        var service =
            new JwtService(config);

        var token =
            service.GenerateToken(
                "salvador",
                "Admin");

        Assert.False(
            string.IsNullOrWhiteSpace(token));
    }
}