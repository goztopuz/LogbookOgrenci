using Ogrenci4.src.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ogrenci4.src.Converters
{
    public class MesajSayiToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string sonuc = "";
            if (value != null)
            {
                var deger = (List<OgretmenMesaj>)value;

                int sayi = deger.Count;
                var liste1 = deger.Where(o => o.Okundu == false);
                int okunmamisSayi = liste1.ToList().Count;

                sonuc = sayi + " Mesaj - " + okunmamisSayi + " Okunmamış";

            }

            return sonuc;

        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

