using Microsoft.AspNetCore.Mvc;
using Shop.Application.Interfaces;
using Shop.Dtos.Login;
using Shop.Dtos.Register;

namespace Shop.Api.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        // Constructor to inject the authentication service 
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public IActionResult Login(LoginRequestDto dto)
        {
            var result = _authService.Login(dto);
            return Ok(result);
        }

        [HttpPost("register")]
        public IActionResult Register(RegisterRequestDto dto)
        {
            var result = _authService.Register(dto);
            return Ok(result);
        }
    }
}
