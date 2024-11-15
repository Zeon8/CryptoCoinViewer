using CryptoCoinViewer.Models;
using CryptoCoinViewer.Resources;
using Wpf.Ui;
using ApplicationTheme = CryptoCoinViewer.Models.ApplicationTheme;

namespace CryptoCoinViewer.Services
{
    public class ThemeService
    {
        private readonly IThemeService _themeService;

        public IEnumerable<ApplicationThemeWithName> Themes { get; } = [
            new ApplicationThemeWithName(ApplicationTheme.System, () => Locale.SystemTheme),
            new ApplicationThemeWithName(ApplicationTheme.Light, () => Locale.LightTheme),
            new ApplicationThemeWithName(ApplicationTheme.Dark, () => Locale.DarkTheme),
            new ApplicationThemeWithName(ApplicationTheme.HightConstrast, () => Locale.HightConstrastTheme),
        ];

        public ThemeService(IThemeService themeService)
        {
            _themeService = themeService;
        }

        public ApplicationThemeWithName GetTheme(ApplicationTheme theme) => Themes.First(t => t.Theme == theme);

        public void ApplyTheme(ApplicationTheme theme)
        {
            Wpf.Ui.Appearance.ApplicationTheme wpfuiTheme = theme switch
            {
                ApplicationTheme.System => _themeService.GetSystemTheme(),
                ApplicationTheme.Light => Wpf.Ui.Appearance.ApplicationTheme.Light,
                ApplicationTheme.Dark => Wpf.Ui.Appearance.ApplicationTheme.Dark,
                ApplicationTheme.HightConstrast => Wpf.Ui.Appearance.ApplicationTheme.HighContrast,
                _ => throw new ArgumentOutOfRangeException(nameof(theme)),
            };
            _themeService.SetTheme(wpfuiTheme);
        }
    }
}
