namespace CryptoCoinViewer.Models
{
    public record Settings
    {
        public required string LanguageCode { get; init; }

        public required ApplicationTheme Theme { get; init; }
    }
}
