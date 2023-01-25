using Ogrenci4.src.Models;
using Ogrenci4.src.ViewModels.Base;
using Ogrenci4.src.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Ogrenci4.src.ViewModels
{
    public class VM_OgretmenMesajlari : ViewModelBase
    {


        Services.ApiService _servis = new Services.ApiService();

        public VM_OgretmenMesajlari(List<OgretmenMesaj> liste)
        {
            _mesajListe = liste;
        }


        private List<OgretmenMesaj> _mesajListe = new();
        public List<OgretmenMesaj> MesajListe
        {
            get => _mesajListe;
            set
            {
                _mesajListe = value;
                OnPropertyChanged();
            }
        }

        private OgretmenMesaj _seciliKayit = new();
        public OgretmenMesaj SeciliKayit
        {
            get => _seciliKayit;
            set
            {
                _seciliKayit = value;
                //  OnPropertyChanged();
            }
        }

        public ICommand TappedCommand => new Command(OnTapped);
        private async void OnTapped()
        {
            if (IsBusy == true)
            {
                return;
            }
            IsBusy = true;


            // Detay SAyfaya Yönlendirielecek.

            await _servis.MesajOkundu(SeciliKayit);

            var ss = new MesajDetay(SeciliKayit);
            await Application.Current.MainPage.Navigation.PushAsync(ss);

            IsBusy = false;
        }



    }
}

