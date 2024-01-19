using AuthApp.UI.Messages;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Windows.Input;

namespace AuthApp.UI.ViewModel
{
    public class SignUpViewModel : ObservableValidator
    {
        public ICommand BackCommand { get; }
        public SignUpViewModel()
        {
            BackCommand = new RelayCommand(()=> WeakReferenceMessenger.Default.Send(new NavigationMessage(typeof(LogInViewModel))));
        }

    }
}
