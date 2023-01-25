using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ogrenci4.src.Models
{
    public class CalisilanKonular
    {
        public string Id { get; set; }
        public string CalismaId { get; set; }
        public string Ders { get; set; }

        public string KonuId { get; set; }
        public string KonuName { get; set; }

        public int OgrenciNo { get; set; }
    }
}

