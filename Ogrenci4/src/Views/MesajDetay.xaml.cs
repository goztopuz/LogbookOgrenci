using Ogrenci4.src.Models;

namespace Ogrenci4.src.Views;

public partial class MesajDetay : ContentPage
{
    public MesajDetay(OgretmenMesaj mm)
    {
        InitializeComponent();
        this.BindingContext = new ViewModels.VM_MesajDetay(mm);
    }
}