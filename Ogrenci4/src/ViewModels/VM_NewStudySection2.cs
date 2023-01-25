using CommunityToolkit.Maui.Core.Extensions;
using CommunityToolkit.Mvvm.Messaging;
using Ogrenci4.src.Models;
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
    public class VM_NewStudySection2 : ViewModelBase
    {

        string blobBaseAddress = "https://bulutarge.blob.core.windows.net/bulutargedosyalar/";

        List<SeciliKonu> abcd = new List<SeciliKonu>();

        Calisma calisma = new Calisma();
        public VM_NewStudySection2(Calisma cc)
        {
            calisma = cc;

            // DersAdi = cc.Lesson;
            kk();
            kk2();

        }


        private string _dersAdi = "";
        public string DersAdi
        {
            get => _dersAdi;
            set
            {
                _dersAdi = value;
                OnPropertyChanged();
            }
        }

        private string _description = "";
        public string Description
        {
            get => _description;
            set
            {
                _description = value;
                OnPropertyChanged();
            }
        }

        private string _seciliRenk = "Yok";
        public string SeciliRenk
        {
            get => _seciliRenk;
            set
            {
                _seciliRenk = value;
                OnPropertyChanged();
            }
        }

        private string _gelenResim = "";
        public string GelenResim
        {
            get => _gelenResim;
            set
            {
                _gelenResim = value;
                OnPropertyChanged();
            }
        }

        public ICommand ListViewSelectionChangedCommand => new Command(SelectionChangedCommandMethod);

        private async void SelectionChangedCommandMethod(object obj)
        {
            var listView = obj as SfListView;
            //  DisplayAlert("Message", (listView.SelectedItem as Contacts).ContactName + " is selected", "OK");

            var aa = listView.SelectedItem as EkDosyaBilgi;
            var pp = aa.FilePath;
            var ss = new ImageView2(pp);
            await Application.Current.MainPage.Navigation.PushAsync(ss);
        }
        public ICommand SelectColorCommand => new Command<string>(OnSelectColor);

        private void OnSelectColor(string obj)
        {
            SeciliRenk = obj;
        }

        //public ICommand ClearCommand => new Command(OnClearColor);
        //private void OnClearColor(string obj)
        //{
        //    SeciliRenk = "Yok";
        //}
        public ICommand ClearColorCommand => new Command(OnClearColor);

        private void OnClearColor()
        {
            SeciliRenk = "Yok";
        }
        private ObservableCollection<SeciliKonu> _seciliKonular = new();

        public ObservableCollection<SeciliKonu> SeciliKonular
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




        private void kk2()
        {
            WeakReferenceMessenger.Default.Register<DosyaKaldirMessage>(this, (r, m) =>
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
                aa = aa.Remove(0, 6);
                var dosya = Resimler.Where(o => o.FilePath == aa).FirstOrDefault();
                if (dosya != null)
                {
                    string idd = dosya.Id;


                    Resimler.Remove(dosya);
                }

                //SeciliKonular = aa.ToObservableCollection();

            });

        }
        private void kk()
        {
            WeakReferenceMessenger.Default.Register<SeciliKonularMessage>(this, (r, m) =>
            {
                // Handle the message here, with r being the recipient and m being the
                // input message. Using the recipient passed as input makes it so that
                // the lambda expression doesn't capture "this", improving performance.


                //   IslemYap(m.Value.liste);

                var aa = m.Value.liste;
                //Console.WriteLine(aa.Count);
                //lstKonular.ItemsSource = aa;
                //var vm = BindingContext as ViewModels.VM_NewStudySection2;
                //vm.KonulariIsle.Execute(aa);
                SeciliKonular = aa.ToObservableCollection();

            });

        }


        public void IslemYap(List<SeciliKonu> list)
        {
            foreach (SeciliKonu k in list)
            {
                //abc.Add(k);
                //SeciliKonular.Add(k);
            }
        }
        public ICommand KaldirCommand => new Command(OnKaldir);
        private void OnKaldir(object obj)
        {
            //   SeciliKonular.RemoveAt(0);

            // SeciliKonular = abc.ToObservableCollection();

            Console.WriteLine(abcd.Count);
        }

        public ICommand KonulariIsle => new Command<List<SeciliKonu>>(OnKonulariIsle);

        private void OnKonulariIsle(List<SeciliKonu> liste)
        {
            //SeciliKonular.Clear();
            //SeciliKonular = liste.ToObservableCollection();

            abcd.Clear();

            foreach (var t in liste)
            {
                abcd.Add(t);
            }

        }


        public ICommand KaydetCommand => new Command(OnKaydet);
        async private void OnKaydet(object obj)
        {
            if (IsBusy == true)
            {
                return;
            }
            IsBusy = true;

            // ----- Kaydet ----

            calisma.Id = Guid.NewGuid().ToString().Substring(0, 20);
            calisma.Description = Description;
            calisma.Isim = "";
            calisma.Sube = "";
            calisma.CalismaColor = SeciliRenk;
            calisma.OgrenciNo = Settings.OgrenciNo;
            calisma.AddedDate = DateTime.Now;

            List<EkDosyaBilgi> lDosyalar = new List<EkDosyaBilgi>();
            foreach (var t in Resimler)
            {

                t.CalismaId = calisma.Id;
                t.OgrenciNo = 100;
                t.FileType = "Image";
                lDosyalar.Add(t);
            }

            foreach (EkDosyaBilgi t2 in Videolar)
            {
                t2.CalismaId = calisma.Id;
                t2.OgrenciNo = 100;
                t2.FileType = "Video";
                lDosyalar.Add(t2);
            }
            foreach (var t3 in Sesler)
            {
                t3.CalismaId = calisma.Id;
                t3.OgrenciNo = 100;
                t3.FileType = "Voice";
                lDosyalar.Add(t3);
            }

            List<CalisilanKonular> lKonular = new List<CalisilanKonular>();

            foreach (var t4 in SeciliKonular)
            {

                CalisilanKonular kk = new();
                kk.Id = Guid.NewGuid().ToString().Substring(0, 15);
                kk.CalismaId = calisma.Id;
                kk.KonuId = t4.Id;
                kk.Ders = DersAdi;
                kk.KonuName = t4.Name;
                kk.OgrenciNo = 100;

                lKonular.Add(kk);
            }
            //-----

            Services.ApiService _servis = new();

            _servis.CalismaKaydet(lKonular, lDosyalar, calisma);


            WeakReferenceMessenger.Default.Send(new RefreshMessage("DosyaEkle"));


            await Application.Current.MainPage.Navigation.PopToRootAsync();
            IsBusy = false;

        }

        public ICommand NewTopicCommand => new Command(OnNewTopic);
        async private void OnNewTopic(object obj)
        {
            if (IsBusy == true)
            {
                return;
            }

            IsBusy = true;
            var ss = new NewStrudyLessonToics(calisma.Lesson, SeciliKonular.ToList());
            await Application.Current.MainPage.Navigation.PushAsync(ss);
            IsBusy = false;
        }
        public ICommand DrawButtonCommand => new Command(OnDrawButton);
        async private void OnDrawButton(object obj)
        {
            if (IsBusy == true)
            {
                return;
            }

            IsBusy = true;
            var ss = new NewDrawing();
            await Application.Current.MainPage.Navigation.PushAsync(ss);
            IsBusy = false;

        }

        public ICommand ImageDetailCommand => new Command<ImageSource>(OnImageDetail);
        async private void OnImageDetail(ImageSource obj)
        {
            var ss = new NewImageView(obj);
            await Application.Current.MainPage.Navigation.PushAsync(ss);
        }


        public ICommand SelectColorCommand2 => new Command<string>(OnSelectColor2);

        private void OnSelectColor2(string obj)
        {
            SeciliRenk = obj;
        }
        public ICommand CameraButtonCommand => new Command(OnCameraButton);
        async private void OnCameraButton(object obj)
        {

            string yanit = await
                App.Current.MainPage.DisplayActionSheet("Seçim Yapın?", "İptal", null,
                "Galeriden");

            if (yanit == "Kamera")
            {
                // Kamera İşlemi
                TakePhoto();
            }
            else if (yanit == "Galeriden")
            {
                //Galeri İşlemi
                var ll = await ChooseFromGallery();


                if (ll != "")
                {
                    EkDosyaBilgi ek1 = new EkDosyaBilgi();
                    ek1.Id = Guid.NewGuid().ToString().Substring(0, 20);
                    ek1.FilePath = ll;
                    ek1.Description = "";
                    ek1.FileDate = DateTime.Now;



                    string blobName = Guid.NewGuid().ToString().Substring(0, 15);
                    var ext1 = System.IO.Path.GetExtension(ll);
                    blobName = blobName + ext1;

                    ek1.urlPath = blobBaseAddress + blobName;

                    Resimler.Add(ek1);

                    Services.UploadFileService _servis = new();
                    _servis.FileUpload(ll, blobName);

                }

            }



        }
        public async void TakePhoto()
        {
            if (MediaPicker.Default.IsCaptureSupported)
            {
                FileResult photo = await MediaPicker.Default.CapturePhotoAsync();

                if (photo != null)
                {
                    // save the file into local storage
                    string localFilePath = Path.Combine(FileSystem.CacheDirectory, photo.FileName);

                    using Stream sourceStream = await photo.OpenReadAsync();
                    using FileStream localFileStream = File.OpenWrite(localFilePath);

                    await sourceStream.CopyToAsync(localFileStream);
                }
            }
        }


        public async Task<string> ChooseFromGallery()
        {
            string localFilePath = "";
            if (MediaPicker.Default.IsCaptureSupported)
            {
                FileResult photo = await MediaPicker.Default.PickPhotoAsync();

                if (photo != null)
                {
                    // save the file into local storage
                    localFilePath = Path.Combine(FileSystem.AppDataDirectory, photo.FileName);

                    using Stream sourceStream = await photo.OpenReadAsync();
                    using FileStream localFileStream = File.OpenWrite(localFilePath);

                    await sourceStream.CopyToAsync(localFileStream);

                }
            }
            return localFilePath;

        }
    }
}
