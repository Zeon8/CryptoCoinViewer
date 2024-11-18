using CryptoCoinViewer.Models;
using System.Globalization;
using System.IO;
using System.Text.Json;

namespace CryptoCoinViewer.Services
{
    public class SettingsService
    {
        public async Task<Settings?> LoadSettings()
        {
            var path = GetPath();
            if (!File.Exists(path))
                return null;

            string text = await File.ReadAllTextAsync(path);
            return JsonSerializer.Deserialize<Settings?>(text);
        }

        public Task Save(Settings settings)
        {
            var path = GetPath();
            Directory.CreateDirectory(Path.GetDirectoryName(path)!);
            return File.WriteAllTextAsync(path, JsonSerializer.Serialize(settings));
        }

        public Settings GetDefaultSettings() => new Settings
        {
            LanguageCode = CultureInfo.CurrentUICulture.Name,
            Theme = ApplicationTheme.System
        };

        private string GetPath()
        {
            var appDataFolder = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            return Path.Combine(appDataFolder, "CryptoCoinViewer/settings.json");
        }
    }
}
