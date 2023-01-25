using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ogrenci4.src.Models
{
    public class CalismaTumBilgi
    {

        public CalismaTumBilgi()
        {

            calisma = new Calisma();
            lDosyalar = new List<EkDosyaBilgi>();
            lKonular = new List<CalisilanKonular>();
        }

        public Calisma calisma { get; set; }

        public List<EkDosyaBilgi> lDosyalar { get; set; }

        public List<CalisilanKonular> lKonular { get; set; }
    }

}
