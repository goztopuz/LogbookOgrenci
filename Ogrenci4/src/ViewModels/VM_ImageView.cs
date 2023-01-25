using Ogrenci4.src.Services;
using Ogrenci4.src.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Ogrenci4.src.ViewModels
{
    public class VM_ImageView : ViewModelBase
    {
        public VM_ImageView()
        {

        }



        public ICommand ResimSilCommand => new Command<string>(OnResimSil);

        private async void OnResimSil(string idd)
        {


            ApiService _servis = new ApiService();
            _servis.DosyaSil(idd);


        }
    }
}

