using ContactAppApi.DTOs;
using ContactAppApi.Services.User;
using Microsoft.AspNetCore.Mvc;

namespace ContactAppApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;

        public AuthController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
        {
            var result = await _userService.Authenticate(loginDto);

            if (result == null)
                return NotFound();

            return Ok(result);
        }
    }
}
