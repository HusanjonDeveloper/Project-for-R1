using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace CustomAuthHandler.Controllers;

[Route("api/[controller]")]
[ApiController]

public class UserController : Controller
{
   [HttpPost("Login")]
   public IActionResult Login(string username, string password)
   {
      
     // HttpContext.Response.Cookies.Append("username", username);
     /*
     var role = "Teacher";
     
     var userID = Guid.NewGuid();

     var claims = new List<Claim>();
     
     var claim = new Claim("username",username);
     claims.Add(claim);
     
     var claim1 = new Claim("user-role",role);
     claims.Add(claim1);
     
     var claim2 = new Claim("user_id",userID.ToString());
     claims.Add(claim2);

     HttpContext.User = new ClaimsPrincipal();

     var user = new ClaimsPrincipal();
     */

     var claims = new List<Claim>()
     {
        new Claim("username", username),
        new Claim("password", password)
     };
     
     var key = "asdsadskdfjhskjh1232384763246";
     
    var  _key = new SymmetricSecurityKey(System.Text.Encoding.UTF32.GetBytes(key));

     var securitykey = new SigningCredentials(_key,"HS256");
     
     var security = new JwtSecurityToken(issuer: "Chat.Api",
        audience: "Chat.Client", signingCredentials: securitykey,
        claims: claims);

     var token = new JwtSecurityTokenHandler().WriteToken(security);
     
     
      return Ok(token);
   }

   [HttpGet("Profile")]
   public IActionResult Profile()
   {
      var username = HttpContext.Request.Cookies["username"];

      if (!string.IsNullOrEmpty(username))
      {
         return Ok($"your username {username}"); 
      }
      
      return BadRequest("you ditn't login . try again");
   }
}