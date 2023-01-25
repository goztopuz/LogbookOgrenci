using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ogrenci4.src.Converters
{
    public class SeviyeStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {

            string sonuc = " BRONZ";

            var deger = (string)value;

            if (deger == "altin.png")
            {
                sonuc = " ALTIN";
            }
            else if (deger == "gumus.png")
            {
                sonuc = "GÜMÜŞ";
            }

            return sonuc;


        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
