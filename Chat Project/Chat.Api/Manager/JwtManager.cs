using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Chat.Api.Entities;
using Chat.Api.Helpers;
using Microsoft.IdentityModel.Tokens;

namespace Chat.Api.Manager;

public class JwtManager
{
    private JwtParameters jwtParam;
    
    private  readonly IConfiguration _configuration;

    public JwtManager(IConfiguration configuration)
    {
        _configuration = configuration;

        jwtParam = _configuration.GetSection("JwtParameters")
            .Get<JwtParameters>()!;
    }

    public string GenerateToken(User user)
    {
        var key = System.Text.Encoding.UTF8.
            GetBytes(jwtParam.Key);
        
        var singingkey = new SigningCredentials(new SymmetricSecurityKey(key),"HS256");

        var clamis = new List<Claim>()
        {
            new Claim(ClaimTypes.Name,user.UserName),
            new Claim(ClaimTypes.NameIdentifier,user.Id.ToString()),
            new Claim(ClaimTypes.Role,user.Role!) // one logic will be
        };
        
        var security = new JwtSecurityToken(issuer:jwtParam.Issuer,
            audience: jwtParam.Audience, signingCredentials:singingkey,
            claims:  clamis, expires: DateTime.Now.AddHours(2));

        var token = new JwtSecurityTokenHandler().WriteToken(security);
        
        return token;
    }
}