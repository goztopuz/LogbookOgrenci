using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ogrenci4.src.ViewModels
{
    public static class Settings
    {
        public static bool FirstRun
        {
            get => Preferences.Get(nameof(FirstRun), true);
            set => Preferences.Set(nameof(FirstRun), value);
        }


        public static int OgrenciNo
        {
            get => Preferences.Get(nameof(OgrenciNo), 0);
            set => Preferences.Set(nameof(OgrenciNo), value);
        }

        public static string OgrenciIsim
        {
            get => Preferences.Get(nameof(OgrenciIsim), "");
            set => Preferences.Set(nameof(OgrenciIsim), value);
        }

        public static string OgrenciSeviye
        {
            get => Preferences.Get(nameof(OgrenciSeviye), "");
            set => Preferences.Set(nameof(OgrenciSeviye), value);
        }

    }
}
