using System.Globalization;

namespace TimeForBattle.Converters;

public class ProficiencyConverter : IMultiValueConverter
{
    object? IMultiValueConverter.Convert(object[] values, Type targetType, object? parameter, CultureInfo culture)
    {
        if (values[0] is not null && values[0] is int attributeScore)
        {
            double x = ((double)attributeScore - 10) / 2;
            int modifier = (int)Math.Floor(x);

            if (values[1] is not null && values[1] is bool proficient && values[2] is not null && values[2] is int proficiencyBonus && proficient)
                modifier += proficiencyBonus;
                    
            if (modifier >= 0)
            {
                return "+" + modifier.ToString();
            }
            else
            {
                return modifier.ToString();
            }
        }

        return values[0];
    }

    public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}