using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ogrenci4.src.Converters
{

    public class CalismaStartDateConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string tarih = "";
            if (value != null)
            {
                //var deger = (Calisma)value;
                //tarih = deger.StartDate.ToShortDateString();
                var deger = (DateTime)value;
                tarih = deger.ToShortDateString();

            }
            return tarih;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

}
