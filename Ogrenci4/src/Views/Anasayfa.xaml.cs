using CommunityToolkit.Mvvm.Messaging;
using Ogrenci4.src.Models;
using Ogrenci4.src.ViewModels;
using System.Diagnostics;

namespace Ogrenci4.src.Views;

public partial class Anasayfa : ContentPage
{

    IDispatcherTimer timer;
    Stopwatch stopwatch = new Stopwatch();

  
    int suree = 0;
    public Anasayfa()
	{
		InitializeComponent();
        kk4();
        this.BindingContext = new VM_Anasayfa();
        var vm = BindingContext as ViewModels.VM_Anasayfa;
        timer = Dispatcher.CreateTimer();
        timer.Interval = TimeSpan.FromSeconds(1);
        timer.Tick += (s, e) =>
        {



            // suree = suree + 1;
            App.sess.CurrentSecond += 1;
            suree = App.sess.CurrentSecond;
            vm.SureIsletCommand.Execute(suree);
            //lblTimer.Text= stopwatch.Elapsed.ToString();
            TimeSpan time1 = TimeSpan.FromSeconds(suree);
            string str = time1.ToString(@"hh\:mm\:ss");
            lblTimer.Text = str;
        };

    }

    private void collKonular_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {


    }

    private void btnGit_Clicked(object sender, EventArgs e)
    {

        var btn = (Button)sender;
        string idd = btn.CommandParameter.ToString();
        var vm = BindingContext as ViewModels.VM_Anasayfa;
        vm.CollSelectCommand.Execute(idd);

    }

    private void btnTimer_Clicked(object sender, EventArgs e)
    {
        stopwatch.Start();
        timer.Start();


    }

    private void kk4()
    {
        WeakReferenceMessenger.Default.Register<TimerMessage>(this, (r, m) =>
        {
            // Handle the message here, with r being the recipient and m being the
            // input message. Using the recipient passed as input makes it so that
            // the lambda expression doesn't capture "this", improving performance.


            //   IslemYap(m.Value.liste);


            //Console.WriteLine(aa.Count);
            //lstKonular.ItemsSource = aa;
            //var vm = BindingContext as ViewModels.VM_NewStudySection2;
            //vm.KonulariIsle.Execute(aa);
            App.sess.CurrentSecond = 0;
            stopwatch.Start();
            timer.Start();
            StckSayac.IsVisible= true;

        });

    }

    private void btnDurdur_Clicked(object sender, EventArgs e)
    {
        stopwatch.Stop();
        timer.Stop();

    }
}