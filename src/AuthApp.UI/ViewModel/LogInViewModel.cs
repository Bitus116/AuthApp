using AuthApp.Domain.Services.Interfaces;
using AuthApp.UI.Messages;
using AuthApp.UI.View;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace AuthApp.UI.ViewModel
{
    public class LogInViewModel : BaseViewModel
    {
        public string Login {get; set;}
        public string Password {get; set;}
        public ICommand LogInCommand { get; }
        public ICommand SignUpCommand { get; }
        private readonly IAuthService _authService;
        public LogInViewModel(IAuthService authService)
        {
            _authService = authService;
            LogInCommand = new RelayCommand(LogIn);
            SignUpCommand = new RelayCommand(() => WeakReferenceMessenger.Default.Send(new NavigationMessage(typeof(SignUpViewModel))));
        }
        private async void LogIn()
        {
            try
            {
               if( await _authService.LogIn(Login, Password))
               {
                    MessageBox.Show("Sucess!");
                    RemoveErrors(nameof(Password));
               }   
            }
            catch (ArgumentException)
            {
                AddError(nameof(Password), "Введены неверные данные");
            }
        }
    }
}
