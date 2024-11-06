using System.Windows.Controls;
using System.Windows.Input;
using CryptoCoinViewer.ViewModels;
using Wpf.Ui.Controls;

namespace CryptoCoinViewer.Views;

public partial class HomeView : UserControl
{
    public HomeView(HomeViewModel viewModel)
    {
        InitializeComponent();
        DataContext = viewModel;

        Loaded += (_, _) => Task.Run(viewModel.Load);
    }

    private void Selector_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        var viewModel = (HomeViewModel)DataContext;
        viewModel.OpenDetailsCommand.Execute(null);
    }
}