using CommunityToolkit.Maui.Core.Extensions;
using CommunityToolkit.Mvvm.Messaging;
using Ogrenci4.src.Models;
using Ogrenci4.src.Services;
using Ogrenci4.src.ViewModels.Base;
using Ogrenci4.src.Views;
using Syncfusion.Maui.ListView;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Ogrenci4.src.ViewModels
{
    public class VM_DetailStudy : ViewModelBase
    {


        // CalismaTumBilgi2 _tum = new CalismaTumBilgi2();
        ApiService _servis = new ApiService();
        public VM_DetailStudy(CalismaTumBilgi2 tum)
        {
            //*_tum = tum;
            //calisma = _tum.calisma;
            _calisma = tum;
            _seciliKonular = tum.lKonular.ToObservableCollection();

            foreach (var t in tum.lDosyalar)
            {
                if (t.FileType == "Image")
                {
                    _resimler.Add(t);
                }
                else if (t.FileType == "Voice")
                {
                    _sesler.Add(t);
                }
                else if (t.FileType == "Video")
                {
                    _videolar.Add(t);
                }
            }

            kk3();



        }


        //private Calisma calisma = new Calisma();
        //public Calisma _calisma
        //{
        //    get => calisma;
        //    set
        //    {
        //        calisma = value;  
        //        OnPropertyChanged();
        //    }
        //}

        private CalismaTumBilgi2 _calisma = new CalismaTumBilgi2();
        public CalismaTumBilgi2 calisma
        {
            get => _calisma;
            set
            {
                _calisma = value;
                OnPropertyChanged();
            }
        }


        private ObservableCollection<CalisilanKonular> _seciliKonular = new();

        public ObservableCollection<CalisilanKonular> SeciliKonular
        {
            get => _seciliKonular;
            set
            {
                _seciliKonular = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<EkDosyaBilgi> _resimler = new();
        public ObservableCollection<EkDosyaBilgi> Resimler
        {
            get => _resimler;
            set
            {
                _resimler = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<EkDosyaBilgi> _videolar = new();
        public ObservableCollection<EkDosyaBilgi> Videolar
        {
            get => _videolar;
            set
            {
                _videolar = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<EkDosyaBilgi> _sesler = new();
        public ObservableCollection<EkDosyaBilgi> Sesler
        {
            get => _sesler;
            set
            {
                _sesler = value;
                OnPropertyChanged();
            }
        }
        private void kk3()
        {
            WeakReferenceMessenger.Default.Register<DosyaApiSilMessage>(this, (r, m) =>
            {
                // Handle the message here, with r being the recipient and m being the
                // input message. Using the recipient passed as input makes it so that
                // the lambda expression doesn't capture "this", improving performance.


                //   IslemYap(m.Value.liste);

                var aa = m.Value;
                //Console.WriteLine(aa.Count);
                //lstKonular.ItemsSource = aa;
                //var vm = BindingContext as ViewModels.VM_NewStudySection2;
                //vm.KonulariIsle.Execute(aa);
                aa = aa.Remove(0, 5);
                var dosya = Resimler.Where(o => o.urlPath == aa).FirstOrDefault();
                if (dosya != null)
                {
                    string idd = dosya.Id;
                    Resimler.Remove(dosya);

                    _servis.DosyaSil(idd);

                }



                //SeciliKonular = aa.ToObservableCollection();

            });
        }
        public ICommand ImageDetailCommand => new Command<ImageSource>(OnImageDetail);
        async private void OnImageDetail(ImageSource obj)
        {
            var ss = new NewImageView(obj);
            await Application.Current.MainPage.Navigation.PushAsync(ss);
        }

        public ICommand ListViewSelectionChangedCommand => new Command(SelectionChangedCommandMethod);

        private async void SelectionChangedCommandMethod(object obj)
        {
            var listView = obj as SfListView;
            //  DisplayAlert("Message", (listView.SelectedItem as Contacts).ContactName + " is selected", "OK");

            var aa = listView.SelectedItem as EkDosyaBilgi;
            var pp = aa.urlPath;
            var ss = new ImageView2(pp);
            listView.SelectedItem = null;
            await Application.Current.MainPage.Navigation.PushAsync(ss);
        }

        public ICommand CalismaSilCommand => new Command(OnCalismaSil);
        private async void OnCalismaSil()
        {
            bool answer = await App.Current.MainPage.DisplayAlert
                ("Silme?", "Çalışma Silinecektir?", "Evet", "Hayır");


            if (answer == true)
            {
                WeakReferenceMessenger.Default.Send(new RefreshMessage("CalismaSil"));

                _servis.CalismaSil(calisma.Id);
                await App.Current.MainPage.Navigation.PopAsync();
            }
            else
            {
                return;
            }

        }
    }
}
