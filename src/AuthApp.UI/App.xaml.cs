using AuthApp.UI.ViewModel;
using AuthApp.UI.View;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Windows;
using AuthApp.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using AuthApp.Domain.Services.Interfaces;
using AuthApp.DataAccess.Sevices;

namespace AuthApp.UI
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public IServiceProvider Services { get; }
        public new static App Current => (App)Application.Current;

        public App()
        {
            Services = ConfigureServices();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            var dictionary = new ResourceDictionary();

            dictionary.BeginInit();
            dictionary.Add(new DataTemplateKey(typeof(LogInViewModel)),
               new DataTemplate(typeof(LogInViewModel)) { VisualTree = new FrameworkElementFactory(typeof(LogInView)) });
            dictionary.Add(new DataTemplateKey(typeof(SignUpViewModel)),
              new DataTemplate(typeof(SignUpViewModel)) { VisualTree = new FrameworkElementFactory(typeof(SignUpView)) });
            dictionary.EndInit();

            Resources.MergedDictionaries.Add(dictionary);
        }

        private IServiceProvider ConfigureServices()
        {
            var services = new ServiceCollection();

            //DB
            Action<DbContextOptionsBuilder> configureDbContext = o => o.UseSqlite("Data Source=test.db");
            services.AddSingleton(new DbContextFactory(configureDbContext));
            services.AddSingleton<IUserDataService, UserDataService>();

            //ViewModels
            services.AddSingleton<MainWindowViewModel>();
            services.AddSingleton<LogInViewModel>();
            services.AddSingleton<SignUpViewModel>();

            return services.BuildServiceProvider();

        }
    }
}
