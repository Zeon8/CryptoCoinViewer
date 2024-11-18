using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using CryptoCoinViewer.ViewModels;

namespace CryptoCoinViewer.Views.Controls
{
    /// <summary>
    /// Interaction logic for CurrencyComboBox.xaml
    /// </summary>
    public partial class CurrencyComboBox : UserControl
    {
        public CurrencyComboBox()
        {
            InitializeComponent();
            
            ComboBox.PreviewTextInput += OnPreviewTextInput;
            ComboBox.KeyDown += OnKeyDown;
        }

        private void OnPreviewTextInput(object? sender, TextCompositionEventArgs? e)
        {
            // Remove last selected item
            ComboBox.SelectedItem = null;
            ComboBox.IsDropDownOpen = true;
        }

        private void OnKeyDown(object? sender, KeyEventArgs e)
        {
            var viewModel = (CurrencyViewModel)DataContext;
            viewModel.UpdateSearchListCommand.Execute(ComboBox.Text);
        }
    }
}
