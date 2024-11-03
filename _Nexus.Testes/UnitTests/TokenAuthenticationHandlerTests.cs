using Xunit;
using Moq;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using System.Text.Encodings.Web;
using _Nexus.Services.SecurityService;

namespace _Nexus.Testes
{
    public class TokenAuthenticationHandlerTests
    {
        [Fact]
        public async Task AuthenticateAsync_ShouldReturnSuccess_WhenTokenIsValid()
        {
            // Arrange
            var mockLoggerFactory = new Mock<ILoggerFactory>();
            var mockOptionsMonitor = new Mock<IOptionsMonitor<TokenAuthenticationOptions>>();
            mockOptionsMonitor.Setup(m => m.CurrentValue).Returns(new TokenAuthenticationOptions());

            var mockEncoder = new Mock<UrlEncoder>();
            var mockClock = new Mock<ISystemClock>();

            var handler = new TokenAuthenticationHandler(
                mockOptionsMonitor.Object,
                mockLoggerFactory.Object,
                mockEncoder.Object,
                mockClock.Object
            );

            var context = new DefaultHttpContext();
            context.Request.Headers["Authorization"] = "Bearer valid_token";

            await handler.InitializeAsync(
                new AuthenticationScheme("Bearer", null, typeof(TokenAuthenticationHandler)),
                context
            );

            // Act
            var result = await handler.AuthenticateAsync();

            // Assert
            Assert.NotNull(result);
            Assert.True(result.Succeeded);
        }
    }
}
