using CommunityToolkit.Mvvm.Messaging;
using Microsoft.Maui.Dispatching;
using Ogrenci4.src.Models;
using Ogrenci4.src.Services;
using Ogrenci4.src.ViewModels.Base;
using Ogrenci4.src.Views;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Ogrenci4.src.ViewModels
{
    public class VM_Anasayfa : ViewModelBase
    {


        ApiService _servis = new ApiService();
      //  int suree = 0;
        // int ogrenciNo = 100;
        public VM_Anasayfa()
        {
            _sonCalismalar = new List<CalismaTumBilgi2>();
            // _isLoading= false;
            AnaCalismaVerileri();
            kk();
           // timer = new Microsoft.Maui.Dispatching.DispatcherTimer();
            ;

            //timer.Interval = TimeSpan.FromSeconds(1);
            //timer.Tick += (s, e) =>
            //{


            //    suree = suree + 1;
            //    //lblTimer.Text= stopwatch.Elapsed.ToString();
            //    TimeSpan time1 = TimeSpan.FromSeconds(suree);
            //    string str = time1.ToString(@"hh\:mm\:ss\:fff");
            //    //  lblTimer.Text = str;

            //    Sayac = str; ;
            //};
          
        }


        private string _seviye = Settings.OgrenciSeviye;
        public string Seviye
        {
            get => _seviye;
        }




        private int _ogrenciNo = Settings.OgrenciNo;
        public int OgrenciNo
        {
            get => _ogrenciNo;
        }


        private string _ogrenciIsim = Settings.OgrenciIsim;
        public string OgrenciIsim
        {
            get => _ogrenciIsim;
        }


        private int _sayac;
        public int Sayac
        {
            get => _sayac;
            set
            {
                _sayac = value;
                OnPropertyChanged();
            }
        }

        public bool _isLoading;
        public bool IsLoading
        {
            get => _isLoading;
            set
            {
                _isLoading = value;
                OnPropertyChanged();
            }
        }

        private bool _sayacVisible = false;
        public bool SayacVisible
        {
            get => _sayacVisible;
            set
            {
                _sayacVisible = value;
                OnPropertyChanged();
            }
        }



        private List<CalismaTumBilgi2> _sonCalismalar;
        public List<CalismaTumBilgi2> SonCalismalar
        {
            get => _sonCalismalar;
            set
            {
                _sonCalismalar = value;
                OnPropertyChanged();
            }
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

        private async void PageRefresh()
        {
            IsLoading = true;
            List<CalismaTumBilgi2> listeR = new();
            List<CalismaTumBilgi2> listeR2 = new();
            List<OgretmenMesaj> listeM = new();
            List<OgretmenMesaj> listeM2 = new();

            listeR = await _servis.KisiCalismalari2(OgrenciNo);
             listeR2 = listeR.OrderByDescending(o => o.StartDate).ToList();

            listeM = await _servis.OgretmenMesajlari(OgrenciNo);
             listeM2 = listeM.OrderByDescending(o => o.msgDate).ToList();
            MesajListe = listeM2;
            SonCalismalar = listeR2;


            IsLoading = false;
        }



        private async void AnaCalismaVerileri()
        {

            _isLoading = true;

            List<CalismaTumBilgi2> liste = new();
            List<CalismaTumBilgi2> liste2 = new();
            List<OgretmenMesaj> listeM = new();
            List<OgretmenMesaj> listeM2 = new();

            liste = await _servis.KisiCalismalari2(OgrenciNo);
            int bb = 22;
             liste2 = liste.OrderByDescending(o => o.StartDate).ToList();
            //SonCalismalar.Clear();
            //ObservableCollection<CalismaTumBilgi> aab = new ObservableCollection<CalismaTumBilgi>();
            //foreach (var item in liste2)
            //{
            //    aab.Add(item);
            //}
             listeM = await _servis.OgretmenMesajlari(OgrenciNo);
             listeM2 = listeM.OrderByDescending(o => o.msgDate).ToList();

            MesajListe = listeM2;
            SonCalismalar = liste2;
            IsLoading = false;

        }
        public ICommand NewStudyCommand => new Command(OnNewStudy);
        async private void OnNewStudy(object obj)
        {
            if (IsBusy == true)
            {
                return;
            }
            IsBusy = true;

            var ss = new NewStudy();
            await Application.Current.MainPage.Navigation.PushAsync(ss);


            IsBusy = false;

        }

        public ICommand NewSessionCommand => new Command(OnNewSession);
        async private void OnNewSession(object obj)
        {
            if (IsBusy == true)
            {
                return;
            }
            IsBusy = true;

            var ss = new StartSession();
            await Application.Current.MainPage.Navigation.PushAsync(ss);


            IsBusy = false;

        }

        public ICommand SessionDetailCommand => new Command(OnSessionDetail);
        private async void OnSessionDetail()
        { 
        if (IsBusy == true)
        {
            return;
        }
        IsBusy = true;

            var ss = new SessionDetail();
        await Application.Current.MainPage.Navigation.PushAsync(ss);


        IsBusy = false;


        }

        public ICommand SureIsletCommand => new Command<int>(OnSureBaslat);
        private void OnSureBaslat(int suree)
        {
            if (IsBusy == true)
            {
                return;
            }
            IsBusy = true;


            Sayac += 1;

            IsBusy = false;


        }

        public ICommand MesajlarCommand => new Command(OnMesajlar);
        private async void OnMesajlar()
        {
            if (IsBusy == true)
            {
                return;
            }
            IsBusy = true;

            // *************


            var ss = new OgretmenMesajlari(MesajListe);
            await Application.Current.MainPage.Navigation.PushAsync(ss);


            //----
            IsBusy = false;

        }


        private CalismaTumBilgi2 _seciliKayit = new();
        public CalismaTumBilgi2 SeciliKayit
        {
            get => _seciliKayit;
            set
            {
                _seciliKayit = value;
                OnPropertyChanged();
            }
        }


        private void kk()
        {
            WeakReferenceMessenger.Default.Register<RefreshMessage>(this, (r, m) =>
            {
                // Handle the message here, with r being the recipient and m being the
                // input message. Using the recipient passed as input makes it so that
                // the lambda expression doesn't capture "this", improving performance.


                //   IslemYap(m.Value.liste);

                var aa = m.Value;

                PageRefresh();

            });

        }


        public ICommand RefreshCommand => new Command(OnRefresh);
        private void OnRefresh()
        {
            if (IsBusy == true)
            {
                return;
            }
            IsBusy = true;
            //   IsLoading = true;
            PageRefresh();

            IsBusy = false;
        }


        public ICommand CollSelectCommand => new Command<string>(OnCollSelect);
        private async void OnCollSelect(string idd)
        {
            if (IsBusy == true)
            {
                return;
            }
            IsBusy = true;

            var sonuc = SonCalismalar.Find(o => o.Id == idd);
            if (sonuc != null)
            {
                var ss = new DetailStudy(sonuc);
                await Application.Current.MainPage.Navigation.PushAsync(ss);
            }

            IsBusy = false;

        }
        public ICommand TappedCommand => new Command<CalismaTumBilgi2>(OnTapped);
        async private void OnTapped(CalismaTumBilgi2 obj)
        {



            if (IsBusy == true)
            {
                return;
            }
            IsBusy = true;


            // ----------------------------

            var ss = new DetailStudy(obj);
            await Application.Current.MainPage.Navigation.PushAsync(ss);

            IsBusy = false;
        }


    }
}
