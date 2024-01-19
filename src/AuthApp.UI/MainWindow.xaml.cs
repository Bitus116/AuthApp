using AuthApp.UI.ViewModel;
using System.Windows;

namespace AuthApp.UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            DataContext = App.Current.Services.GetService(typeof(MainWindowViewModel));

            InitializeComponent();
        }
    }
}
