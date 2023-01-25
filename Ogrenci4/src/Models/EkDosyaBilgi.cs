using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ogrenci4.src.Models
{
    public class EkDosyaBilgi
    {
        public string Id { get; set; }

        public string CalismaId { get; set; }

        public int OgrenciNo { get; set; }

        public string FileType { get; set; }

        public string Description { get; set; }

        public string FilePath { get; set; }

        public string urlPath { get; set; }
        public DateTime FileDate { get; set; }


    }
}
