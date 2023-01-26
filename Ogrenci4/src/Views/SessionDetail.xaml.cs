namespace Ogrenci4.src.Views;

public partial class SessionDetail : ContentPage
{
    IDispatcherTimer timer;
    int suree;
    public SessionDetail()
	{
		InitializeComponent();

        timer = Dispatcher.CreateTimer();
        timer.Interval = TimeSpan.FromSeconds(1);
        timer.Start();
        timer.Tick += (s, e) =>
        {



            // suree = suree + 1;
          //  App.sess.CurrentSecond += 1;
            suree = App.sess.CurrentSecond;
          
            //lblTimer.Text= stopwatch.Elapsed.ToString();
            TimeSpan time1 = TimeSpan.FromSeconds(suree);
            string str = time1.ToString(@"hh\:mm\:ss");
            lblTimer.Text = str;
        };
    }



}