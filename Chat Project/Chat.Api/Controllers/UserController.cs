
using Chat.Api.Exceptions;
using Chat.Api.Manager;
using Chat.Api.Model.UserModels;
using Microsoft.AspNetCore.Mvc;

namespace Chat.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController(UserManager userManager) : ControllerBase
    {
        private readonly UserManager _userManager = userManager;

        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _userManager.GetAllUsers();
            return Ok(users);
        }
        
        
        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetAllUserById(Guid id)
        {
            try
            {
                var users = await _userManager.GetAllUsers();
                return Ok(users);
            }
            catch (UserNotFoundException e)
            {
                return NotFound();
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody]CreateUserModel model)
        {
            var result = await _userManager.Register(model);
            return Ok(result);
        }
        
        
        
        
    }
}
