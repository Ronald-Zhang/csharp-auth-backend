using Microsoft.AspNetCore.Mvc;
using Backend.Services;
using Backend.DTOs;
using Backend.Helpers;

namespace Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly AuthService _service;
        private readonly IConfiguration _config;

        public AuthController(AuthService service,IConfiguration config)
        {
            _service = service;
            _config = config;
        }

        [HttpPost("register")]
        public IActionResult Register(RegisterDto dto)
        {
            var user = _service.Register(dto);
            return Ok(user);
        }
        [HttpPost("login")]
        public IActionResult Login(LoginDto dto)
        {
            var user = _service.Login(dto);

            if (user == null)
                return Unauthorized();

            var token = JwtHelper.GenerateToken(user.Username, _config["Jwt:Key"]);

            return Ok(new { token });

        }


    }
}