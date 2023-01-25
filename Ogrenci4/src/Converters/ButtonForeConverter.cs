using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ogrenci4.src.Converters
{
    public class ButtonForeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string deger1 = (string)value;
            string deger2 = (string)parameter;
            if (deger1 == deger2)
            {
                return Microsoft.Maui.Graphics.Colors.White;
            }
            else
            {
                return Microsoft.Maui.Graphics.Colors.Black;
            }

        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
