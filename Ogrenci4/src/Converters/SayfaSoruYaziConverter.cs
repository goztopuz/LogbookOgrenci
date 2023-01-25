using Ogrenci4.src.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ogrenci4.src.Converters
{
    public class SayfaSoruYaziConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string metin = "";
            if (value != null)
            {
                var deger = (CalismaTumBilgi2)value;
                if (deger.QuestionCount > 0)
                {
                    string bol1 = String.Format("{0} Soru   ", deger.QuestionCount);
                    metin = metin + bol1;
                }
                if (deger.PageCount > 0)
                {
                    string bol2 = String.Format(" {0} Sayfa ", deger.PageCount);
                    metin = metin + bol2;
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

