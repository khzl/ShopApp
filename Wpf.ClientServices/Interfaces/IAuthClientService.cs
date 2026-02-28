using Shop.Dtos.Login;
using Shop.Dtos.Register;
using System;
using System.Collections.Generic;
using System.Text;

namespace Wpf.ClientServices.Interfaces
{
    public interface IAuthClientService
    {
        // Contracts 
        
        // Login
        public Task<LoginResponseDto> LoginAsync(string? email, string? password);

        // Register 
        public Task<RegisterResponseDto> RegisterAsync(RegisterRequestDto dto);
    }
}
