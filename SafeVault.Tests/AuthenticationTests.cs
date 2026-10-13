using SafeVault.Api.Security;
using Xunit;

namespace SafeVault.Tests;

public class AuthenticationTests
{
    [Fact]
    public void Register_ShouldCreateUser()
    {
        var auth = new AuthenticationService();

        var result = auth.Register(
            "salvador",
            "Password123!",
            "User");

        Assert.True(result);
    }

    [Fact]
    public void Register_ShouldRejectDuplicateUser()
    {
        var auth = new AuthenticationService();

        auth.Register(
            "salvador",
            "Password123!",
            "User");

        var result = auth.Register(
            "salvador",
            "AnotherPassword",
            "User");

        Assert.False(result);
    }

    [Fact]
    public void Login_WithValidCredentials_ShouldSucceed()
    {
        var auth = new AuthenticationService();

        auth.Register(
            "salvador",
            "Password123!",
            "User");

        var result = auth.ValidateUser(
            "salvador",
            "Password123!");

        Assert.True(result);
    }

    [Fact]
    public void Login_WithInvalidPassword_ShouldFail()
    {
        var auth = new AuthenticationService();

        auth.Register(
            "salvador",
            "Password123!",
            "User");

        var result = auth.ValidateUser(
            "salvador",
            "WrongPassword");

        Assert.False(result);
    }
}