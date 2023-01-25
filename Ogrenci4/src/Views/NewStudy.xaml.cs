using CommunityToolkit.Mvvm.Messaging;
using Ogrenci4.src.Models;
using Ogrenci4.src.ViewModels;

namespace Ogrenci4.src.Views;

public partial class NewStudy : ContentPage
{
	public NewStudy()
	{
		InitializeComponent();
        this.BindingContext = new VM_NewStudy();


    }

    private void btnTimer_Clicked(object sender, EventArgs e)
    {
        WeakReferenceMessenger.Default.Send(new TimerMessage(5));

    }
}