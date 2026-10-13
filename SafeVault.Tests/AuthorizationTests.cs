using SafeVault.Api.Security;
using Xunit;

namespace SafeVault.Tests;

public class AuthorizationTests
{
    [Fact]
    public void User_ShouldHaveAdminRole()
    {
        var auth = new AuthenticationService();

        auth.Register(
            "admin",
            "Password123!",
            ApplicationRoles.Admin);

        var role =
            auth.GetRole("admin");

        Assert.Equal(
            ApplicationRoles.Admin,
            role);
    }

    [Fact]
    public void User_ShouldHaveUserRole()
    {
        var auth = new AuthenticationService();

        auth.Register(
            "user1",
            "Password123!",
            ApplicationRoles.User);

        var role =
            auth.GetRole("user1");

        Assert.Equal(
            ApplicationRoles.User,
            role);
    }

    [Fact]
    public void Guest_ShouldNotBeAdmin()
    {
        var auth = new AuthenticationService();

        auth.Register(
            "guest1",
            "Password123!",
            ApplicationRoles.Guest);

        var role =
            auth.GetRole("guest1");

        Assert.NotEqual(
            ApplicationRoles.Admin,
            role);
    }
}