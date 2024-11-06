using CryptoCoinViewer.Views;
using Wpf.Ui.Controls;

namespace CryptoCoinViewer.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    public IEnumerable<NavigationViewItem> NavigationItems { get; } = new[]
    {
        new NavigationViewItem("Home", SymbolRegular.Home24, typeof(HomeView)),
        
    };
}