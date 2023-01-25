using Ogrenci4.src.Models;

namespace Ogrenci4.src.Views;

public partial class DetailStudy : ContentPage
{
    public DetailStudy(CalismaTumBilgi2 tumu)
    {
        InitializeComponent();
        this.BindingContext = new ViewModels.VM_DetailStudy(tumu);
    }

    private void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
    {
        Image img = (Image)sender;
        var vm = BindingContext as ViewModels.VM_DetailStudy;
        vm.ImageDetailCommand.Execute(img.Source);

    }
}