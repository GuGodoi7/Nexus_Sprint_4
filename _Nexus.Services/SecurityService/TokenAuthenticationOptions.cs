using Microsoft.AspNetCore.Authentication;

namespace _Nexus.Services.SecurityService
{
    public class TokenAuthenticationOptions : AuthenticationSchemeOptions
    {
        public string Token { get; set; } 
    }
}
