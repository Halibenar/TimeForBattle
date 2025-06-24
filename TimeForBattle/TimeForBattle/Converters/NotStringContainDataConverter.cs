using System.Globalization;

namespace TimeForBattle.Converters;

public class NotStringContainDataConverter : IValueConverter
{

    object? IValueConverter.Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        if (value is string val)
        {
            return string.IsNullOrEmpty(val);
        }

        return true;
    }

    object? IValueConverter.ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}
