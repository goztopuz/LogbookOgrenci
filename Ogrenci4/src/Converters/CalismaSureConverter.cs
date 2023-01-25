using Ogrenci4.src.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ogrenci4.src.Converters
{
    public class CalismaSureConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {

            string sonuc = "";
            if (value != null)
            {
                CalismaTumBilgi2 cc = (CalismaTumBilgi2)value;

                DateTime d1 = cc.StartDate;
                DateTime d2 = cc.EndDate;

                var d3 = (d2 - d1).Hours;
                var d4 = (d2 - d1).Minutes;

                // sonuc = String.Format("{0} Saat {1] Dk.", d3, d4);


                //var d5 = (d2 - d2).TotalMinutes;
                sonuc = d3.ToString() + "Saat " + d4.ToString() + " Dk.";


                //  sonuc = d5.ToString();
            }


            return sonuc;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

