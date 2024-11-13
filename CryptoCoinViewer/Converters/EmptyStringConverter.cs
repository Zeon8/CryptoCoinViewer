using System.Globalization;
using System.Windows.Data;

namespace CryptoCoinViewer.Converters;

public class EmptyStringConverter : IValueConverter
{
    public object? EmptyObject { get; set; }
    public object? NonEmptyObject { get; set; }
        
    public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        return string.IsNullOrEmpty(value as string) ? NonEmptyObject : EmptyObject;
    }

    public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}