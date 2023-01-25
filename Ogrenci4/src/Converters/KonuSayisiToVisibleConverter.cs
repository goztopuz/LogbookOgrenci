using Ogrenci4.src.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ogrenci4.src.Converters
{
    public class KonuSayisiToVisibleConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool durum = true;

            if (value != null)
            {
                var ll = (ObservableCollection<CalisilanKonular>)value;
                if (ll.Count > 0)
                {
                    durum = false;
                }
            }


            return durum;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
