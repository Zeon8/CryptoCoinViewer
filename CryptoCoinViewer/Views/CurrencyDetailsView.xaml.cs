using System.Windows.Controls;
using CryptoCoinViewer.ViewModels;

namespace CryptoCoinViewer.Views;

public partial class CurrencyDetailsView : UserControl
{
    public CurrencyDetailsView(CurrencyDetailsViewModel viewModel)
    {
        InitializeComponent();
        DataContext = viewModel;
    }
}