using SafeVault.Security;
using Xunit;

namespace SafeVault.Tests
{
    public class SecurityTests
    {
        [Fact]
        public void Should_Remove_Xss_Content()
        {
            string input =
                "<script>alert('XSS')</script>";

            string result =
                InputValidation.SanitizeInput(input);

            Assert.DoesNotContain(
                "<script>",
                result
            );
        }

        [Fact]
        public void Should_Reject_SqlInjection_Input()
        {
            string maliciousInput =
                "' OR '1'='1";

            bool result =
                InputValidation.ValidateUsername(
                    maliciousInput
                );

            Assert.False(result);
        }

        [Fact]
        public void Should_Accept_Valid_Username()
        {
            bool result =
                InputValidation.ValidateUsername(
                    "salvador123"
                );

            Assert.True(result);
        }

        [Fact]
        public void Should_Accept_Valid_Email()
        {
            bool result =
                InputValidation.ValidateEmail(
                    "user@test.com"
                );

            Assert.True(result);
        }
    }
}