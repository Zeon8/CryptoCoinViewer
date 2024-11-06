using System.Windows.Controls;
using CryptoCoinViewer.ViewModels;
using Wpf.Ui.Controls;

namespace CryptoCoinViewer.Views;

public partial class HomeView : UserControl
{
    public HomeView(HomeViewModel viewModel)
    {
        InitializeComponent();
        DataContext = viewModel;
    }

}