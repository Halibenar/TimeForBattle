using System.Globalization;

namespace TimeForBattle.Converters;

public class InvertedBoolConverter : IValueConverter
{

    object? IValueConverter.Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        if (value is bool val)
            return !val;

        else
            return value;
    }

    object? IValueConverter.ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        if (value is bool val)
            return !val;

        else
            return value;
    }
}
