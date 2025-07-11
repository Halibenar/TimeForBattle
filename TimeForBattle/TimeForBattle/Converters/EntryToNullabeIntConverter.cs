using System.Globalization;

namespace TimeForBattle.Converters;

public class EntryToNullableIntConverter : IValueConverter
{

    public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        return (int?)value;
    }
    public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        if (value == null)
        {
            return null;
        }
        var isOk = int.TryParse(value.ToString(), out var num);
        if (!isOk)
        {
            return null;
        }
        return (int?)num;
    }
}
