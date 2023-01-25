using Ogrenci4.src.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ogrenci4.src.Converters
{
    public class CalismaYokTextConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string msj = "Henüz Çalışma Girilmemiş";

            if (value != null)
            {



                List<CalismaTumBilgi2> ll = (List<CalismaTumBilgi2>)value;

                if (ll.Count > 0)
                {
                    msj = String.Format("{0} Adet Çalışma Girilmiş", ll.Count);

                }
            }
            return msj;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
