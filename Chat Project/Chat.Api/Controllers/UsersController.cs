
using Chat.Api.Exceptions;
using Chat.Api.Manager;
using Chat.Api.Model.UserModels;
using Microsoft.AspNetCore.Mvc;

namespace Chat.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController(UserManager userManager) : ControllerBase
    {
        private readonly UserManager _userManager = userManager;

        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            var user = await _userManager.GetAllUsers();
            return Ok(user);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetUserById(Guid id)
        {
            try
            {
                var user = await _userManager.GetUsrById(id);
                return Ok(user);
            }
            catch (UserNotFoundException e)
            {
                return NotFound();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] CreateUserModel model)
        {
            var result = await _userManager.Register(model);
            return Ok(result);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {
            try
            {
                var result = await _userManager.Login(model);
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost("{userId:guid}/add-or-update-photo")]
        public async Task<IActionResult> AddOrUpdatePhoto(Guid userId,[FromForm] FileClass model)
        {
            var result = await _userManager.AddOrUpdatePhoto(userId,model.file);
            return Ok(result);
        }

        
    }
    
}

public class FileClass
{
    public  IFormFile file { get; set; }
}


/*
 photo file string xoaltda kelishi misol uchun 
public class PhotoClass
{
    public  string Name { get; set; }

    public  string Description { get; set; }

    public  IFormFile file { get; set; }
}
*/
