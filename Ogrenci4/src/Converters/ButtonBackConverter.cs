using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ogrenci4.src.Converters
{
    public class ButtonBackConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string deger1 = (string)value;
            string deger2 = (string)parameter;
            if (deger1 == deger2)
            {

                if (DeviceInfo.Platform == DevicePlatform.Android)
                {
                    return Microsoft.Maui.Graphics.Colors.Black;
                }
                else
                {
                    return Microsoft.Maui.Graphics.Colors.Black;
                }

            }
            else
            {
                return Microsoft.Maui.Graphics.Colors.White;
            }


        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
