using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ogrenci4.src.Models
{
    public class OgretmenMesaj
    {

        public string Id { get; set; }
        public DateTime msgDate { get; set; } = DateTime.Now;
        public DateTime SonTarih { get; set; } = DateTime.Now.AddDays(5);

        public string Konu { get; set; } = "";
        public string Unite { get; set; } = "";

        public string Mesaj { get; set; } = "";

        public int IlgiliOgrenci { get; set; } = 0;



        public int Sinif { get; set; } = 0;

        public string Sube { get; set; } = "";
        public string Ek1 { get; set; } = "";
        public string Ek2 { get; set; } = "";


        public bool Okundu { get; set; } = false;
    }

}
