using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XFValueConverter
{
    public class StringToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
           if(value is string)
            {
                var foo = value as string;
                if (foo == "1")
                {
                    return Color.Green;
                } else if (foo == "2")
                {
                    return Color.Red;
                }
                else if (foo == "3")
                {
                    return Color.Blue;
                }
            }
            return Color.Accent;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
