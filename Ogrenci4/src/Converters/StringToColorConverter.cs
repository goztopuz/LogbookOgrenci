using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ogrenci4.src.Converters
{
    public class StringToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Microsoft.Maui.Graphics.Color aa = new();
            aa = Colors.Gray;

            if (value != null)
            {

                string renk = (string)value;

                switch (renk)
                {
                    case "Mavi":
                        aa = Microsoft.Maui.Graphics.Colors.MediumBlue;
                        break;
                    case "Yesil":
                        aa = Microsoft.Maui.Graphics.Colors.MediumSeaGreen;
                        break;
                    case "Mor":
                        aa = Microsoft.Maui.Graphics.Colors.MediumPurple;
                        break;
                    case "Kırmızı":
                        aa = Microsoft.Maui.Graphics.Colors.Red;
                        break;
                    case "Turuncu":
                        aa = Microsoft.Maui.Graphics.Colors.DarkOrange;
                        break;
                    default:
                        break;
                }


            }
            return aa;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
