using CryptoCoinViewer.Models;

namespace CryptoCoinViewer.Services
{
    public class SettingsApplier
    {
        private readonly LocalizationService _localizationService;
        private readonly ThemeService _themeService;

        public SettingsApplier(LocalizationService localizationService, ThemeService themeService)
        {
            _localizationService = localizationService;
            _themeService = themeService;
        }

        public void ApplySettings(Settings settings)
        {
            _themeService.ApplyTheme(settings.Theme);
            _localizationService.ApplyLanguage(settings.LanguageCode);
        }
    }
}
