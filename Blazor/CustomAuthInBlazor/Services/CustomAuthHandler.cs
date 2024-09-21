using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.AspNetCore.Components.Authorization;

namespace CustomAuthInBlazor.Services;

public class CustomAuthHandler : AuthenticationStateProvider
{
    public override async Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        var claimsPrincipal = await SetClaims();
        
        NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(
            user:claimsPrincipal)));
        
        return await Task.FromResult(new AuthenticationState(
            user:claimsPrincipal));
    }

    public async Task<ClaimsPrincipal> SetClaims(string userId, string username, string role)
    {
        var claimsPrincipal = new ClaimsPrincipal(
            new ClaimsIdentity(
                new List<Claim>()
                {
                    new Claim(ClaimTypes.NameIdentifier,userId),
                    new Claim(ClaimTypes.Name,username),
                    new Claim(ClaimTypes.Role,role)
                },authenticationType:"JWTAuth"));
        
        return claimsPrincipal;
    }

    public async Task<Tuple<string,string,string>> ReadJwtToken()
    {
        var token = " ";

        var security = new JwtSecurityTokenHandler();
        var parsedToken = security.ReadJwtToken(token);
        
        string userId = parsedToken.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)!.Value;
        string username = parsedToken.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Name)!.Value;
        string relo = parsedToken.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role)!.Value;
        
         return new (userId, username, relo);
    }
    
}