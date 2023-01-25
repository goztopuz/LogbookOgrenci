using CommunityToolkit.Mvvm.Messaging;
using Ogrenci4.src.Models;
using Ogrenci4.src.Models;
namespace Ogrenci4.src.Views;

public partial class NewStudySection2 : ContentPage
{
    
    public NewStudySection2(Calisma calisma)
    {
        InitializeComponent();
        
        this.BindingContext = new ViewModels.VM_NewStudySection2(calisma);
        // kk();
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
            Console.WriteLine(aa.Count);
         //   lstKonular.ItemsSource = aa;
            var vm = BindingContext as ViewModels.VM_NewStudySection2;
            vm.KonulariIsle.Execute(aa);
        });

    }
    protected override void OnAppearing()
    {
        base.OnAppearing();
        //this.BindingContext = new ViewModels.VM_NewStudySection2(_calisma);

    }

    private void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
    {
        Image img = (Image)sender;
        var vm = BindingContext as ViewModels.VM_NewStudySection2;
        vm.ImageDetailCommand.Execute(img.Source);

    }
}