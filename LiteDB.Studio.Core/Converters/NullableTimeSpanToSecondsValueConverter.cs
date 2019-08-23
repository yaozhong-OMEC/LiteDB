using System;
using System.Globalization;
using MvvmCross.Converters;

namespace LiteDB.Studio.Core.Converters
{
    public class NullableTimeSpanToSecondsValueConverter : MvxValueConverter<TimeSpan?>
    {
        protected override object Convert(TimeSpan? value, Type targetType, object parameter, CultureInfo culture)
        {
            return value?.TotalSeconds.ToString(CultureInfo.InvariantCulture) ?? string.Empty;
        }

        protected override TimeSpan? TypedConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is string secondsString && double.TryParse(secondsString, out var secondsDouble))
            {
                return TimeSpan.FromSeconds(secondsDouble);
            }

            return null;
        }
    }
}