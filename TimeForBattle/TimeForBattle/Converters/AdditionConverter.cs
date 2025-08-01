using System.Globalization;

namespace TimeForBattle.Converters;

public class AdditionConverter : IMultiValueConverter
{
    public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
    {
        if (values[0] is null || values[1] is null)
            return values[0];

        if (values[0] is int number1 && values[1] is int number2)
            return number1 + number2;

        return values[0];
    }

    public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}