namespace CryptoCoinViewer.Models
{
    public enum ApplicationTheme : byte
    {
        System,
        Light,
        Dark,
        HightConstrast
    }

    public record ApplicationThemeWithName
    {
        public ApplicationTheme Theme { get; init; }

        public string Name => _nameFunction();

        private readonly Func<string> _nameFunction;

        public ApplicationThemeWithName(ApplicationTheme theme, Func<string> nameFunction)
        {
            Theme = theme;
            _nameFunction = nameFunction;
        }
    }
}
