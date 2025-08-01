﻿using System.Globalization;

namespace TimeForBattle.Converters;

public class RollColorConverter : IValueConverter
{
    object? IValueConverter.Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        if (value is not null && value is int rollValue)
        {
            if (rollValue == 20)
                return Colors.Green;
            else if (rollValue == 1)
                return Colors.Red;
            else
                return Colors.Black;
        }

        return value;
    }

    public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}