using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CryptoCoinViewer.Models;
using CryptoCoinViewer.Services;
using static CryptoCoinViewer.Services.LocalizationService;

namespace CryptoCoinViewer.ViewModels
{
    public partial class SettingsViewModel : ViewModelBase
    {
        public IEnumerable<Language> Languages => _localizationService.Languages;

        [ObservableProperty]
        private Language? _selectedLanguage;

        private readonly DialogService _dialogService;
        private readonly LocalizationService _localizationService;
        private readonly SettingsService _settingsService;

        public SettingsViewModel(DialogService dialogService, LocalizationService localizationService, 
            SettingsService settingsService)
        {
            _dialogService = dialogService;
            _localizationService = localizationService;
            _settingsService = settingsService;
        }

        public async Task LoadSettings()
        {
            var settings = await _settingsService.GetSettings();
            if (settings is null)
                return;

            SelectedLanguage = _localizationService.GetLanguage(settings);
        }

        [RelayCommand]
        private async Task SaveSettings()
        {
            var settings = new Settings(SelectedLanguage!.Code);
            _localizationService.ApplyLanguage(settings);
            await _settingsService.Save(settings);
            await _dialogService.ShowSavedSettingsMessage();
        }

    }
}
