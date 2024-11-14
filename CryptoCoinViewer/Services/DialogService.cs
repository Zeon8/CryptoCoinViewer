using CryptoCoinViewer.Resources;

namespace CryptoCoinViewer.Services
{
    public class DialogService
    {
        public Task ShowSavedSettingsMessage()
        {
            var messageBox = new Wpf.Ui.Controls.MessageBox
            {
                Title = Locale.SettingsSavedTitle,
                Content = Locale.SettingsSavedMessage,
            };
            return messageBox.ShowDialogAsync();
        }
    }
}
