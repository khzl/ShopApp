using Shop.Dtos.Login;
using Shop.Dtos.Register;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Application.Interfaces
{
    public interface IAuthService
    {
        // Contract for the login method, which takes a LoginRequestDto and returns a LoginResponseDto
        
        // Login
        public LoginResponseDto Login(LoginRequestDto request);

        // Register
        public RegisterResponseDto Register(RegisterRequestDto request);
    }
}
