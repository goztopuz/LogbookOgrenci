using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ogrenci4.src.Converters
{
    public class SayfaToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string metin = "";
            if (value != null)
            {
                var deger = (int)value;

                if (deger > 0)
                {
                    string bol2 = String.Format("{0} Sayfa ", deger);
                    metin = bol2;
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
