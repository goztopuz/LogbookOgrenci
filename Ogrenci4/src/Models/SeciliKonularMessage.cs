using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.Messaging.Messages;
namespace Ogrenci4.src.Models
{
    // Create a message
    public class SeciliKonularMessage : ValueChangedMessage<SeciliKonuListesi>
    {
        public SeciliKonularMessage(SeciliKonuListesi ll) : base(ll)
        {

        }
    }


    public class SeciliKonuListesi
    {
        public SeciliKonuListesi()
        {
            liste = new List<SeciliKonu>();
        }
        public List<SeciliKonu> liste { get; set; }
    }


    // DosyaSil API
    public class DosyaApiSilMessage : ValueChangedMessage<string>
    {
        public DosyaApiSilMessage(string value) : base(value)
        {
        }
    }

    public class DosyaKaldirMessage : ValueChangedMessage<string>
    {
        public DosyaKaldirMessage(string value) : base(value)
        {
        }
    }


    public class RefreshMessage : ValueChangedMessage<string>
    {
        public RefreshMessage(string value) : base(value)
        {
        }
    }

    public class TimerMessage : ValueChangedMessage<double>
    {
        public TimerMessage(double value) : base(value)
        {
        }

        public string ders { get; set; } 
        public string konu { get; set; }    
        public string aciklama { get; set; }
        public int sure { get; set; }


    }
}
