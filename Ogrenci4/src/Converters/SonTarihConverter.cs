using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ogrenci4.src.Converters
{
    public class SonTarihConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string tarih = "";
            if (value != null)
            {
                var deger = (DateTime)value;

                if (deger < DateTime.Now.AddYears(-50))
                {
                    tarih = "Son tarih yok.";
                }
                else
                {
                    tarih = deger.ToShortDateString();
                }



            }
            return tarih;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
