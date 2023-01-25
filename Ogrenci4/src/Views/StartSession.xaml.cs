using Ogrenci4.src.ViewModels;

namespace Ogrenci4.src.Views;

public partial class StartSession : ContentPage
{
	public StartSession()
	{
		InitializeComponent();

		this.BindingContext = new VM_StartSession();
	}
}