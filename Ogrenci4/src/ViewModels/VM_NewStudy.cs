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
    public class VM_NewStudy : ViewModelBase
    {


        private string _seciliDers = "Türkçe";
        public string SeciliDers
        {
            get => _seciliDers;
            set
            {
                _seciliDers = value;
                OnPropertyChanged();

            }
        }

        private string _seciliTur = "Konu Çalışma";
        public string SeciliTur
        {
            get => _seciliTur;
            set
            {
                _seciliTur = value;
                OnPropertyChanged();

            }
        }


        private int _sayfaSayisi = 0;
        public int SayfaSayisi
        {
            get => _sayfaSayisi;
            set
            {
                _sayfaSayisi = value;
                OnPropertyChanged();
            }
        }

        private int _soruSayisi = 0;
        public int SoruSayisi
        {
            get => _soruSayisi;
            set
            {
                _soruSayisi = value;
                OnPropertyChanged();
            }
        }


        private DateTime _basTarih = DateTime.Now;
        public DateTime BasTarih
        {
            get => _basTarih;
            set
            {
                _basTarih = value;
                OnPropertyChanged();
            }
        }

        private TimeSpan _basSaat = new TimeSpan(DateTime.Now.Hour, DateTime.Now.Minute, 0);
        public TimeSpan BasSaat
        {
            get => _basSaat;

            set
            {
                _basSaat = value;
                OnPropertyChanged();
            }
        }

        private TimeSpan _bitSaat = new TimeSpan(DateTime.Now.Hour, DateTime.Now.Minute, 0);
        public TimeSpan BitSaat
        {
            get => _bitSaat;
            set
            {
                _bitSaat = value;
                OnPropertyChanged();

            }
        }
        private DateTime _bitTarih = DateTime.Now;
        public DateTime BitTarih
        {
            get => _bitTarih;
            set
            {
                _bitTarih = value;
                OnPropertyChanged();
            }
        }




        public ICommand SelectTypeCommand => new Command<string>(OnSelectType);

        private void OnSelectType(string obj)
        {
            SeciliTur = obj;
        }

        public ICommand SelectDersCommand => new Command<string>(OnSelectDers);
        async private void OnSelectDers(string obj)
        {
            SeciliDers = obj;
        }



        public ICommand KlavyeKapatCommand => new Command(OnKlavyeKapat);
        private void OnKlavyeKapat()
        {

        }
        public ICommand IlerleCommand => new Command(OnIlerle);
        async private void OnIlerle()
        {
            Console.WriteLine(SayfaSayisi);
            Console.WriteLine(SoruSayisi);



            Calisma _calisma = new Calisma();
            _calisma.Id = Guid.NewGuid().ToString();
            _calisma.QuestionCount = SoruSayisi;
            _calisma.PageCount = SayfaSayisi;
            _calisma.Type = SeciliTur;
            _calisma.Lesson = SeciliDers;

            DateTime BasTarih2 = new DateTime(BasTarih.Year, BasTarih.Month, BasTarih.Day,
                BasSaat.Hours, BasSaat.Minutes, 0);
            _calisma.StartDate = BasTarih2;

            DateTime BitTarih2 = new DateTime(BitTarih.Year, BitTarih.Month, BitTarih.Day,
                BitSaat.Hours, BitSaat.Minutes, 0);

            _calisma.EndDate = BitTarih2;
            var aa = BasSaat;

            var ss = new NewStudySection2(_calisma);
            await Application.Current.MainPage.Navigation.PushAsync(ss);

        }
        public ICommand IptalCommand => new Command(OnIptal);
        async private void OnIptal(object obj)
        {
            if (IsBusy == true)
            {
                return;
            }
            IsBusy = true;

            await Application.Current.MainPage.Navigation.PopModalAsync();
            IsBusy = false;

        }

    }
}
