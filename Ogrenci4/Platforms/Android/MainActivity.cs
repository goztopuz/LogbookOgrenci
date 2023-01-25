using Android.App;
using Android.Content.PM;
using Android.OS;

namespace Ogrenci4;

[Activity(Theme = "@style/Maui.SplashTheme", Icon = "@mipmap/aooicon", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize | ConfigChanges.Density)]
public class MainActivity : MauiAppCompatActivity
{
    protected override void OnCreate(Bundle savedInstanceState)
    {
        base.OnCreate(savedInstanceState);

        //... Leave the existing code here
      
      
    }
}
