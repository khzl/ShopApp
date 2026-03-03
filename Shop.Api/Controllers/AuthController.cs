using Microsoft.AspNetCore.Mvc;
using Shop.Application.Interfaces;
using Shop.Dtos.Login;
using Shop.Dtos.Register;
using Shop.Dtos.Tokens;

namespace Shop.Api.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController : ControllerBase
    {
        // private properties
        private readonly IAuthService _authService;
        private readonly ITokenService _tokenService;

        // Constructor to inject the authentication service 
        public AuthController(IAuthService authService, ITokenService tokenService)
        {
            _authService = authService;
            _tokenService = tokenService;
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

        [HttpPost("logout")]
        public IActionResult Logout(LogoutRequestDto dto)
        {
            _tokenService.RevokeRefreshToken(dto.RefreshToken);
            return Ok();
        }


    }
}
