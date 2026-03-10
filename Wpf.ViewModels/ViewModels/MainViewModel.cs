using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Wpf.ClientServices.Interfaces;
using Wpf.Shared;
using Wpf.ViewModels.Base;
using Microsoft.Extensions.DependencyInjection;

namespace Wpf.ViewModels.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        // private properties 
        private readonly IAuthClientService _authClientService;
        private BaseViewModel? _currentViewModel;
        private readonly IServiceProvider _serviceProvider;


        // property currentViewModel
        public BaseViewModel? CurrentViewModel
        {
            get => _currentViewModel;
            set
            {
                _currentViewModel = value;
                OnPropertyChanged();
            }
        }

        // public Constructor 
        public MainViewModel(IAuthClientService authClientService , IServiceProvider provider)
        {
            _authClientService = authClientService;
            LogoutCommand = new RelayCommand(async _ => await Logout());

            _serviceProvider = provider;
            // First Screen 
            CurrentViewModel = _serviceProvider.GetRequiredService<LoginViewModel>();
        }

        public void NavigateTo<T>() where T : BaseViewModel
        {
            CurrentViewModel = _serviceProvider.GetRequiredService<T>();
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
