using CommunityToolkit.Mvvm.Messaging;
using Ogrenci4.src.Models;

namespace Ogrenci4.src.Views;

public partial class ImageView2 : ContentPage
{
    string _filePath = "";
    public ImageView2(string _path)
	{
		InitializeComponent();

		this.BindingContext = new ViewModels.VM_Image2(_path);
        _filePath  = _path;
    }

    private async void Button_Clicked(object sender, EventArgs e)
    {
        if (_filePath.StartsWith("Uri"))
        {

            //Api'den Sil 
            //Resim Listesinden Sil....(MsgCenter - Düzenle)

            WeakReferenceMessenger.Default.Send(new DosyaApiSilMessage(_filePath));
            WeakReferenceMessenger.Default.Send(new RefreshMessage("DosyaSil"));


        }
        else
        {

            //Resim Listesinden Sil....(MsgCenter - Yeni)
            WeakReferenceMessenger.Default.Send(new DosyaKaldirMessage(_filePath));
        }

        await Navigation.PopAsync();


    }
}