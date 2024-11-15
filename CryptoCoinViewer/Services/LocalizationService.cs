using CryptoCoinViewer.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wpf.Ui.Controls;

namespace CryptoCoinViewer.Services
{
    public class LocalizationService
    {
        public record Language(string Name, string Code);

        public IEnumerable<Language> Languages { get; } = [
            new Language("English", "en-US"),
            new Language("Українська", "uk-UA")
        ];

        private Language? GetLanguage(string code)
        {
            return Languages.FirstOrDefault(lang => lang.Code == code);
        }

        public Language GetDefaultLanguage()
        {
            return GetLanguage(CultureInfo.CurrentUICulture.Name) ?? Languages.First();
        }

        public Language GetLanguageOrDefault(string languageCode)
        {
            return GetLanguage(languageCode) ?? GetDefaultLanguage();
        }

        public void ApplyLanguage(string languageCode)
        {
            try
            {
                CultureInfo.CurrentUICulture = CultureInfo.GetCultureInfo(languageCode);
            }
            catch (CultureNotFoundException)
            {
                CultureInfo.CurrentUICulture = CultureInfo.CurrentUICulture;
            }
        }

    }
}
