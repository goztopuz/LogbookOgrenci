using Ogrenci4.src.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ogrenci4.src.Converters
{
    public class CalisilanKonularConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {

            string konular = "";

            if (value != null)
            {

                var deger = (List<CalisilanKonular>)value;

                foreach (var t in deger)
                {
                    konular = konular + t.KonuName + " - ";
                }

            }

            return konular;


        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
