using System.Text.Encodings.Web;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Options;

namespace CustomAuthHandler.AuthHandlers;

/*
public class AuthHandler : AuthenticationHandler<AuthenticationSchemeOptions>
{
    public AuthHandler(IOptionsMonitor<AuthenticationSchemeOptions>
        options, ILoggerFactory logger, UrlEncoder encoder, ISystemClock clock)
        : base(options, logger, encoder, clock)
    {
        
    }

   
    public AuthHandler(IOptionsMonitor<AuthenticationSchemeOptions>
        options, ILoggerFactory logger, UrlEncoder encoder)
        : base(options, logger, encoder)
    {  
    }

    
    protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
    {
        throw new NotImplementedException();
    }
}
*/