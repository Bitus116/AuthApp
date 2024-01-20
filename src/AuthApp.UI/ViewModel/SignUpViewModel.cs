using AuthApp.Domain.Services;
using AuthApp.Domain.Services.Interfaces;
using AuthApp.UI.Messages;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AuthApp.UI.ViewModel
{
    public class SignUpViewModel : BaseViewModel
    {
        public ICommand BackCommand { get; }
        public ICommand SignUpCommand { get; }

        private string login;
        private string password;
        private string confirmPassword;

        public string? Login
        {
            get => login;
            set => SetProperty(ref login, value); 
        }
        public string? Password 
        { 
            get => password;
            set => SetProperty(ref password, value);
        }
        public string? ConfirmPassword
        {
            get => confirmPassword;
            set => SetProperty(ref confirmPassword, value);
        }

        private readonly IAuthService _authService;
        public SignUpViewModel(IAuthService authService)
        {
            _authService = authService;

            BackCommand = new RelayCommand(() => WeakReferenceMessenger.Default.Send(new NavigationMessage(typeof(LogInViewModel))));
            SignUpCommand = new RelayCommand(SignUp);
        }

        private async void SignUp()
        {
            if (string.IsNullOrEmpty(Login))
            {
                AddError(nameof(Login), "Введите логин");
            }
            if (string.IsNullOrEmpty(Password))
            {
                AddError(nameof(Password), "Введите пароль");
            }
            if (string.IsNullOrEmpty(ConfirmPassword))
            {
                AddError(nameof(ConfirmPassword), "Повторите пароль");
            }
            var result =  await _authService.SignUp(Login, Password, ConfirmPassword);
            switch (result)
            {
                case SignUpResult.Success:
                    RemoveErrors(nameof(Login));
                    RemoveErrors(nameof(Password));
                    RemoveErrors(nameof(ConfirmPassword));
                    WeakReferenceMessenger.Default.Send(new NavigationMessage(typeof(LogInViewModel)));
                    break;
                case SignUpResult.PasswordsDoNotMatch:
                    AddError(nameof(ConfirmPassword), "Пароли не совпадают");
                    break;
                case SignUpResult.UsernameAlreadyExists:
                    AddError(nameof(Login), "Пользователь с таким именем уже существует");
                    break;

            }
        }
    }
}
