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
using System.Windows.Input;

namespace AuthApp.UI.ViewModel
{
    public class LogInViewModel : ObservableValidator
    {
        public ICommand LogInCommand { get; }
        public ICommand SignUpCommand { get; }
        private readonly IUserDataService userDataService;
        public LogInViewModel(IUserDataService userDataService)
        {
            this.userDataService = userDataService;
            LogInCommand = new RelayCommand(()=> userDataService.Get(1));
            SignUpCommand = new RelayCommand(() => WeakReferenceMessenger.Default.Send(new NavigationMessage(typeof(SignUpViewModel))));
        }
        
    }
}
