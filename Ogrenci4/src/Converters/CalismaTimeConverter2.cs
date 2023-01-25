using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ogrenci4.src.Converters
{

    public class CalismaTimeConverter2 : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string basBit = "";

            if (value != null)
            {
                var deger = (DateTime)value;

                //var deger2 = (DateTime)parameter;
                basBit = deger.ToShortTimeString() + "-" +
                    deger.ToShortTimeString();

            }

            return basBit;
        }


        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

}
