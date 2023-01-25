using Ogrenci4.src.Models;
using Ogrenci4.src.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Ogrenci4.src.ViewModels
{
    public class VM_MesajDetay : ViewModelBase
    {

        public VM_MesajDetay(OgretmenMesaj mm)
        {
            _mesaj = new OgretmenMesaj();

            _mesaj = mm;
        }

        private OgretmenMesaj _mesaj;
        public OgretmenMesaj Mesaj
        {
            get => _mesaj;
            set
            {
                _mesaj = value;
            }
        }

        public ICommand TamamCommand => new Command(OnTamam);
        private async void OnTamam()
        {
            if (IsBusy == true)
            {
                return;
            }
            IsBusy = true;

            await Application.Current.MainPage.Navigation.PopAsync();



            IsBusy = false;

        }



    }
}
