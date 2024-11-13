using CryptoCoinViewer.ViewModels;
using System.Diagnostics;
using System.Windows.Controls;
using System.Windows.Input;
using Wpf.Ui.Controls;

namespace CryptoCoinViewer.Views
{
    /// <summary>
    /// Interaction logic for ConverterView.xaml
    /// </summary>
    public partial class ConverterView : UserControl
    {
        public ConverterView(ConverterViewModel viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
        }
    }
}
