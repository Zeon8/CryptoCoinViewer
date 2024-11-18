using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CryptoCoinViewer.Models;
using CryptoCoinViewer.Services;
using Wpf.Ui;
using Wpf.Ui.Appearance;
using static CryptoCoinViewer.Services.LocalizationService;
using ThemeService = CryptoCoinViewer.Services.ThemeService;

namespace CryptoCoinViewer.ViewModels
{
    public partial class SettingsViewModel : ViewModelBase
    {
        public IEnumerable<Language> Languages => _localizationService.Languages;

        public IEnumerable<ApplicationThemeWithName> Themes => _themeService.Themes;

        [ObservableProperty]
        private Language? _selectedLanguage;

        [ObservableProperty]
        private ApplicationThemeWithName? _selectedTheme;

        private readonly DialogService _dialogService;
        private readonly LocalizationService _localizationService;
        private readonly ThemeService _themeService;
        private readonly SettingsApplier _settingsApplier;
        private readonly SettingsService _settingsService;

        public SettingsViewModel(DialogService dialogService, LocalizationService localizationService,
            SettingsService settingsService, ThemeService themeService, SettingsApplier settingsApplier)
        {
            _dialogService = dialogService;
            _localizationService = localizationService;
            _settingsService = settingsService;
            _themeService = themeService;
            _settingsApplier = settingsApplier;
        }

        public async Task LoadSettings()
        {
            var settings = await _settingsService.LoadSettings() 
                ?? _settingsService.GetDefaultSettings();
            SelectedLanguage = _localizationService.GetLanguageOrDefault(settings.LanguageCode);
            SelectedTheme = _themeService.GetTheme(settings.Theme);
        }

        [RelayCommand]
        private async Task SaveSettings()
        {
            var settings = new Settings()
            {
                LanguageCode = SelectedLanguage!.Code,
                Theme = SelectedTheme!.Theme,
            };
            _settingsApplier.ApplySettings(settings);
            await _settingsService.Save(settings);
            await _dialogService.ShowSavedSettingsMessage();
        }

    }
}
