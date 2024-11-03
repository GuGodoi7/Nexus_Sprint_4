using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Options;
using System.Security.Claims;
using Microsoft.Extensions.Logging;
using System.Text.Encodings.Web;

namespace _Nexus.Services.SecurityService
{
    public class TokenAuthenticationHandler : AuthenticationHandler<TokenAuthenticationOptions>
    {
        public TokenAuthenticationHandler(IOptionsMonitor<TokenAuthenticationOptions> options,
                                           ILoggerFactory logger,
                                           UrlEncoder encoder,
                                           ISystemClock clock)
            : base(options, logger, encoder, clock)
        {
        }

        protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            if (!Request.Headers.TryGetValue("Authorization", out var tokenHeader))
            {
                return AuthenticateResult.Fail("Authorization header missing.");
            }

            if (tokenHeader != $"Bearer {Options.Token}")
            {
                return AuthenticateResult.Fail("Unauthorized.");
            }

            var claims = new[] { new Claim(ClaimTypes.Name, "User") };
            var identity = new ClaimsIdentity(claims, "Bearer");
            var principal = new ClaimsPrincipal(identity);
            var ticket = new AuthenticationTicket(principal, "Bearer");

            return AuthenticateResult.Success(ticket);
        }
    }
}
