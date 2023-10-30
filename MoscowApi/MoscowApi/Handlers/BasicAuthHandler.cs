using System.Security.Claims;
using System.Text;
using System.Text.Encodings.Web;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Options;
using MoscowApi.Options;
using MoscowApi.Services;

namespace MoscowApi.Handlers
{
    public class BasicAuthHandler : AuthenticationHandler<BasicAuthenticationOptions>
    {
        private readonly UserService _userService;

        public BasicAuthHandler(IOptionsMonitor<BasicAuthenticationOptions> options, ILoggerFactory logger, UrlEncoder encoder, ISystemClock clock, UserService userService)
            : base(options, logger, encoder, clock)
        {
            _userService = userService;
        }
        
        protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            var header = Context.Request.Headers["Authorization"].ToString();
            if (String.IsNullOrEmpty(header))
            {
                return AuthenticateResult.Fail("Unauthorized");
            }
            var identity = new ClaimsIdentity(Scheme.Name);

            var encodedCreds = header.Substring(6);
            var creds = Encoding.UTF8.GetString(Convert.FromBase64String(encodedCreds));
            var uipwd = creds.Split(":");
            var username = uipwd[0];
            var password = uipwd[1];

            var isAuthenticated = await _userService.AuthenticateUserAsync(username, password);

            if (isAuthenticated)
            {
                var principal = new ClaimsPrincipal(identity);
                var ticket = new AuthenticationTicket(principal, Scheme.Name);
                return AuthenticateResult.Success(ticket);
            }

            return AuthenticateResult.Fail("Unauthorized");
        }
    }
}
