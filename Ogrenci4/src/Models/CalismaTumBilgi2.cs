using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ogrenci4.src.Models
{
    public class CalismaTumBilgi2
    {
        public CalismaTumBilgi2()
        {
            lKonular = new List<CalisilanKonular>();
            lDosyalar = new List<EkDosyaBilgi>();
        }

        public string Id { get; set; }

        public int OgrenciNo { get; set; }
        public int Sinif { get; set; }

        public string Sube { get; set; }
        public string Isim { get; set; }
        public string Type { get; set; }
        public string Lesson { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public int QuestionCount { get; set; }

        public int PageCount { get; set; }

        public string Description { get; set; }

        public string CalismaColor { get; set; }
        public DateTime AddedDate { get; set; }
        public DateTime SendDate { get; set; }

        public bool Updated { get; set; } = false;

        public bool ServerSended { get; set; } = false;


        public string Konular { get; set; }

        public string IlgiliOdevId { get; set; } = "";
        public string Ek1 { get; set; } = "";
        public string Ek2 { get; set; } = "";

        public List<CalisilanKonular> lKonular { get; set; }

        public List<EkDosyaBilgi> lDosyalar { get; set; }

    }
}
