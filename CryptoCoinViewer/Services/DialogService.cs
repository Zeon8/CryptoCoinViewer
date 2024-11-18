using CryptoCoinViewer.Resources;
using Wpf.Ui;
using Wpf.Ui.Controls;

namespace CryptoCoinViewer.Services
{
    public class DialogService
    {
        private ISnackbarService _snackbarService;

        public DialogService(ISnackbarService snackbarService)
        {
            _snackbarService = snackbarService;
        }

        public Task ShowSavedSettingsMessage()
        {
            var messageBox = new MessageBox
            {
                Title = Locale.SettingsSavedTitle,
                Content = Locale.SettingsSavedMessage,
            };
            return messageBox.ShowDialogAsync();
        }

        public void ShowFailedLoadChartMessage()
        {
            _snackbarService.Show(Locale.FailedLoadChartTitle,
                Locale.FailedLoadChartMessage,
                ControlAppearance.Secondary,
                new SymbolIcon(SymbolRegular.ErrorCircle16),
                TimeSpan.FromSeconds(5));
        }
    }
}
