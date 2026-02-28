using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Wpf.ClientServices.Interfaces;
using Wpf.Shared;
using Wpf.ViewModels.Base;
using Shop.Dtos.Register;

namespace Wpf.ViewModels.ViewModels
{
    public class RegisterViewModel : BaseViewModel
    {
        // private Properties 
        private readonly IAuthClientService _authClientService;

        // Constructor 
        public RegisterViewModel(IAuthClientService authClientService)
        {
            _authClientService = authClientService;
            RegisterCommand = new RelayCommand(async _ => await Register());
        }

        // Properties 
        public string? FullName { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }

        public ICommand RegisterCommand { get; } // read only

        // Register 
        private async Task Register()
        {
            var result = await _authClientService.RegisterAsync(
                new RegisterRequestDto
                {
                    FullName = FullName,
                    Email = Email,
                    Password = Password
                });

            // Navigate To Login Form
        }


    }
}
