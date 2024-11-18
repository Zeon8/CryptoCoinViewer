using CryptoCoinViewer.ViewModels;
using System.Windows.Controls;

namespace CryptoCoinViewer.Views.Pages
{
    /// <summary>
    /// Interaction logic for SettingsView.xaml
    /// </summary>
    public partial class SettingsView : UserControl
    {
        public SettingsView(SettingsViewModel viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;

            Loaded += (_, _) => Task.Run(viewModel.LoadSettings);
        }
    }
}
