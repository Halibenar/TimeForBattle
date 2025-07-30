using System.Globalization;

namespace TimeForBattle.Converters;

public class AttributeConverter : IValueConverter
{
    object? IValueConverter.Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        if (value is not null && value is int attributeScore)
        {
            double x = ((double)attributeScore - 10) / 2;
            int modifier = (int)Math.Floor(x);

            if (modifier >= 0)
            {
                return "+" + modifier.ToString();
            }
            else
            {
                return modifier.ToString();
            }
        }

        return value;
    }

    public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}