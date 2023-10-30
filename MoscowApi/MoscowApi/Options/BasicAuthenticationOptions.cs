using Microsoft.AspNetCore.Authentication;

namespace MoscowApi.Options;

public class BasicAuthenticationOptions : AuthenticationSchemeOptions
{
    public string Realm { get; set; }
    public string UnauthorizedMessage { get; set; }
}
