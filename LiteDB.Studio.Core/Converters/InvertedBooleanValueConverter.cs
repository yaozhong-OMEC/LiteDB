using System;
using System.Globalization;
using MvvmCross.Converters;

namespace LiteDB.Studio.Core.Converters
{
    public class InvertedBooleanValueConverter : MvxValueConverter<bool>
    {
        protected override object Convert(bool value, Type targetType, object parameter, CultureInfo culture)
        {
            return !value;
        }
    }
}