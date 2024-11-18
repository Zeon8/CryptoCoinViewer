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
    public MainWindow(MainWindowViewModel viewModel, INavigationService navigationService,
        ISnackbarService snackbarService)
    {
        InitializeComponent();
        DataContext = viewModel;

        navigationService.SetNavigationControl(NavigationView);
        snackbarService.SetSnackbarPresenter(SnackbarPresenter);

        Loaded += (_, _) => navigationService.Navigate(typeof(HomeView));
    }
}