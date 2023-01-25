using Ogrenci4.src.Services;
using Ogrenci4.src.ViewModels;

namespace Ogrenci4.src.Views;

public partial class AcilisSayfasi : ContentPage
{
    ApiService _servis = new ApiService();

    public AcilisSayfasi()
	{
		InitializeComponent();
	}

    public bool _isBusy = false;
    public bool IsBusy
    {
        get => _isBusy;
        set
        {
            _isBusy = value;
            OnPropertyChanged();
        }
    }

    private async void Button_Clicked(object sender, EventArgs e)
    {

        if (IsBusy == true)
        {
            return;
        }
        IsBusy = true;
        // int ogrenciNo = Settings.OgrenciNo;
        Settings.OgrenciNo = Convert.ToInt32(txtOgrenciNo.Text);

        var sonuc = await _servis.OgrenciBilgisiAl(Settings.OgrenciNo);

        if (sonuc != null)
        {

            Settings.OgrenciIsim = sonuc.Ad + " " + sonuc.Soyad;
            Settings.OgrenciNo = sonuc.OkulNo;
            Settings.OgrenciSeviye = sonuc.Ek1;

            var MM = new NavigationPage(new Anasayfa());

            App.Current.MainPage = MM;



        }

        else
        {
            await DisplayAlert("Öğrenci Bİlgi", "Kayıtlı Öğrenci Yok", "Tamam");
        }

        IsBusy = false;
    }


}