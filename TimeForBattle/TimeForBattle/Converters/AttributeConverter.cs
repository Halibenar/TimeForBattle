using System.Globalization;

namespace TimeForBattle.Converters;

public class AttributeConverter : IValueConverter
{

    object? IValueConverter.Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        if (value is int val)
        {
            int modifier = (val - 10) / 2;

            if (modifier >= 0)
            {
                return ("+" + modifier.ToString());
            }
            else
            {
                return (modifier.ToString());
            }
        }

        return value;
    }

    object? IValueConverter.ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}
