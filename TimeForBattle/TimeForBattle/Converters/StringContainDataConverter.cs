using System.Globalization;

namespace TimeForBattle.Converters;

public class StringContainDataConverter : IValueConverter
{

    object? IValueConverter.Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        if (value is string val)
        {
            return !string.IsNullOrEmpty(val);
        }

        return false;
    }

    object? IValueConverter.ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}
