using Ogrenci4.src.Models;

namespace Ogrenci4.src.Views;

public partial class OgretmenMesajlari : ContentPage
{
	public OgretmenMesajlari(List<OgretmenMesaj> liste)
	{
		InitializeComponent();
        this.BindingContext = new ViewModels.VM_OgretmenMesajlari(liste);

    }
}