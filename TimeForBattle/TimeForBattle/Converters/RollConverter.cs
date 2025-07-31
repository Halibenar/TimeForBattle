using System.Globalization;

namespace TimeForBattle.Converters;

public class RollConverter : IMultiValueConverter
{
    object? IMultiValueConverter.Convert(object[] values, Type targetType, object? parameter, CultureInfo culture)
    {
        if (values[0] is null || values[1] is null || values[2] is null || values[3] is null || values[4] is null)
            return new Tuple<int?, string?, string?>(null, null, null);

        if (values[0] is int attributeScore && values[1] is bool proficient && values[2] is int proficiencyBonus && values[3] is string modifierName && values[4] is string creatureName)
        {
            double x = ((double)attributeScore - 10) / 2;
            int modifier = (int)Math.Floor(x);

            if (proficient)
                modifier += proficiencyBonus;

            return new Tuple<int?, string?, string?>(modifier, modifierName, creatureName);
        }

        return new Tuple<int?, string?, string?>(null, null, null);
    }

    public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}