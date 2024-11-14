using CryptoCoinViewer.Models;
using System.IO;
using System.Text.Json;

namespace CryptoCoinViewer.Services
{
    public class SettingsService
    {
        private Settings? _settings;

        public async Task<Settings?> GetSettings()
        {
            if (_settings is not null)
                return _settings;

            var path = GetPath();
            if (!File.Exists(path))
                return null;

            string text = await File.ReadAllTextAsync(path);
            return _settings = JsonSerializer.Deserialize<Settings?>(text);
        }

        public Task Save(Settings settings)
        {
            _settings = settings;
            var path = GetPath();
            Directory.CreateDirectory(Path.GetDirectoryName(path)!);
            return File.WriteAllTextAsync(path, JsonSerializer.Serialize(settings));
        }

        private string GetPath()
        {
            var appDataFolder = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            return Path.Combine(appDataFolder, "CryptoCoinViewer/settings.json");
        }
    }
}
