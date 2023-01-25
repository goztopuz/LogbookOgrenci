
using Ogrenci4.src.Models;
using Ogrenci4.src.ViewModels;
using Ogrenci4.src.Views;
using System.Diagnostics;

namespace Ogrenci4;

public partial class App : Application
{

    public static IDispatcherTimer timer;
    public static  Stopwatch stopwatch = new Stopwatch();

    public static ActiveSession sess = new ActiveSession();
    
    public App()
	{
        Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("ODE2MjcxQDMyMzAyZTM0MmUzMGxZWUlNdmxZZVpTaVdnTmZvM1BLQUpQdlArdFN1MWNSNWNiL0ZNWkFxcXc9");

        InitializeComponent();

        if (Settings.FirstRun)
        {
            MainPage = new AcilisSayfasi();
            Settings.FirstRun = false;

        }

        else
        {
            MainPage = new NavigationPage(new Anasayfa());
        }

        if (DeviceInfo.Current.Idiom == DeviceIdiom.Phone)
        {
            OneSignalSDK.DotNet.OneSignal.Default.Initialize("d077c4a9-a666-4149-8fbf-157236081504");
            OneSignalSDK.DotNet.OneSignal.Default.PromptForPushNotificationsWithUserResponse();

        }



        //OneSignal.Default.Initialize("d077c4a9-a666-4149-8fbf-157236081504");
        //OneSignal.Default.PromptForPushNotificationsWithUserResponse();


        // OneSignal.Default.PromptForPushNotificationsWithUserResponse();
    }
}

