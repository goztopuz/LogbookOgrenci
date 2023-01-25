using Ogrenci4.src.Models;
using Ogrenci4.src.Services;
using Ogrenci4.src.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Collections.ObjectModel;
using CommunityToolkit.Maui.Core.Extensions;
using CommunityToolkit.Mvvm.Messaging;

namespace Ogrenci4.src.ViewModels
{
    public class VM_NewStudyLesseonTopic : ViewModelBase
    {

        ApiService _servis = new ApiService();

        String _ders;

        public VM_NewStudyLesseonTopic(string ders, List<SeciliKonu> ll)
        {
            _ders = ders;
            //  Doldur(ll);
            OnKonulariAl();

        }

        // public ObservableCollection<SeciliKonu> KonuListesi = new();


        private void Doldur(List<SeciliKonu> ll)
        {

            // this.KonuListesi = new ObservableCollection<SeciliKonu>();
            //  this.Liste2 = new List<SeciliKonu>();


            // KonuListesi.Clear();

            for (int i = 0; i < 10; i++)
            {
                SeciliKonu k1 = new SeciliKonu();
                k1.Id = i.ToString();
                k1.Name = "Konu : " + i.ToString();

                var konuu = ll.Find(o => o.Id == k1.Id);

                if (konuu != null)
                {
                    k1.Secili = true;
                }
                else
                {
                    k1.Secili = false;
                }




                KonuListesi.Add(k1);
                // Liste2.Add(k1);
            }

        }
        private List<SeciliKonu> _liste2;
        public List<SeciliKonu> Liste2
        {
            get { return _liste2; }
            set
            {
                _liste2 = value;
            }
        }

        private ObservableCollection<SeciliKonu> _konuListesi = new();
        public ObservableCollection<SeciliKonu> KonuListesi
        {
            get => _konuListesi;
            set
            {
                _konuListesi = value;
                OnPropertyChanged();
            }
        }

        private SeciliKonu _konu;
        public SeciliKonu Konu
        {
            get => _konu;
            set
            {
                _konu = value;
                OnPropertyChanged();
            }
        }

        public ICommand TamamCommand => new Command(OnTamam);

        async private void OnTamam(object obj)
        {
            if (IsBusy == true)
            {
                return;
            }
            IsBusy = true;


            List<SeciliKonu> _liste = new List<SeciliKonu>();

            foreach (var t in KonuListesi)
            {
                if (t.Secili == true)
                {
                    _liste.Add(t);
                }
            }

            // MessagingCenter.Send<List<SeciliKonu>(_liste, "Konulariİsle");

            SeciliKonuListesi sl = new SeciliKonuListesi();
            sl.liste = _liste;

            WeakReferenceMessenger.Default.Send(new SeciliKonularMessage(sl));


            await Application.Current.MainPage.Navigation.PopAsync();
            IsBusy = false;

        }
        public ICommand TappedCommand => new Command<SeciliKonu>(OnTapped);
        private void OnTapped(SeciliKonu kk)
        {

            if (kk.Secili == true)
            {
                Konu.Secili = false;
            }
            else
            {
                Konu.Secili = true;
            }

            KonuListesi = KonuListesi.ToObservableCollection();

        }


        public ICommand KonulariAlCommand => new Command(OnKonulariAl);

        private async void OnKonulariAl()
        {
            var ll = await _servis.DersKonulariniAl(_ders);

            KonuListesi = ll.ToObservableCollection();

        }


    }
}
