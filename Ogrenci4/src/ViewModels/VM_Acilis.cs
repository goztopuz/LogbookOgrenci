using Ogrenci4.src.ViewModels.Base;
using Ogrenci4.src.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Ogrenci4.src.ViewModels
{
    public class VM_Acilis : ViewModelBase
    {

        public VM_Acilis()
        {

        }

        public ICommand GirisCommand => new Command(OnGiris);
        private async void OnGiris()
        {




            var sayfa = new Anasayfa();
            await App.Current.MainPage.Navigation.PushModalAsync(sayfa);
        }




    }
}
