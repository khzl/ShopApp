using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Wpf.ClientServices.Interfaces;
using Wpf.Shared;
using Wpf.ViewModels.Base;

namespace Wpf.ViewModels.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        // private properties 
        private readonly IAuthClientService _authClientService;

        // public Constructor 
        public MainViewModel(IAuthClientService authClientService)
        {
            _authClientService = authClientService;
            LogoutCommand = new RelayCommand(async _ => await Logout());
        }

        // properties
        public ICommand LogoutCommand { get; } // read only

        // private function Logout
        private async Task Logout()
        {
            await _authClientService.LogoutAsync();
            // Navigate to Login View 
        }

    }
}
