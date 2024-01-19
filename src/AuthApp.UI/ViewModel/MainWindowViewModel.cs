using AuthApp.UI.Messages;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Messaging;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace AuthApp.UI.ViewModel
{
    public class MainWindowViewModel : ObservableObject, IRecipient<NavigationMessage>
    {
        private ObservableObject _currentViewModel;

        public ObservableObject CurrentViewModel
        {
            get => _currentViewModel;
            set => SetProperty(ref _currentViewModel, value);
        }

        public MainWindowViewModel()
        {
            WeakReferenceMessenger.Default.Register(this);
            _currentViewModel = App.Current.Services.GetService(typeof(LogInViewModel))
                as ObservableObject ?? throw new ApplicationException("LogInViewModel doesn`t exist");
        }

        public void Receive(NavigationMessage message)
        {
            try
            {
                if(CurrentViewModel is IDisposable disposable)
                {
                    disposable.Dispose();
                }
                var scope = App.Current.Services.CreateScope();
                var newViewModel = scope.ServiceProvider.GetService(message.ViewModelType);
                if (newViewModel is ObservableObject vmObservableObject)
                {
                    CurrentViewModel = vmObservableObject;
                }
                else
                {
                    throw new ApplicationException("Can not handle navigation request");
                }
            }
            catch(ApplicationException)
            {
                //TODO
            }
        }
    }
}
