using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using CryptoCoinViewer.ViewModels;
using CryptoCoinViewer.Views;
using Wpf.Ui;
using Wpf.Ui.Controls;

namespace CryptoCoinViewer;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : FluentWindow
{
    public MainWindow(MainWindowViewModel viewModel, INavigationService navigationService)
    {
        InitializeComponent();
        DataContext = viewModel;
        navigationService.SetNavigationControl(NavigationView);

        Loaded += (_, _) => navigationService.Navigate(typeof(HomeView));
    }
}