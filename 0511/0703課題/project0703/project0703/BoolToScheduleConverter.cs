using System;
using System.Globalization;
using System.Windows.Data;

namespace Project0703
{
    public class BoolToScheduleConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is bool isOnSchedule)
            {
                return isOnSchedule ? "オンスケ" : "遅延";
            }
            return "不明";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}