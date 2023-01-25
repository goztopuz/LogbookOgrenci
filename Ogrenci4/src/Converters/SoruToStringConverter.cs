using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ogrenci4.src.Converters
{
    public class SoruToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string metin = "";
            if (value != null)
            {
                int deger = (int)value;
                if (deger > 0)
                {
                    string bol1 = String.Format("{0} Soru   ", deger);
                    metin = bol1;
                }


            }

            return metin;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
