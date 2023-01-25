using Ogrenci4.src.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ogrenci4.src.ViewModels
{
    public class VM_Image2:ViewModelBase
    {
        public VM_Image2(string path)
        {
            _ss= path;
        }

        private string _ss;
        public string SS
        {
            get => _ss;
            set
            {
                _ss = value;
                OnPropertyChanged();

            }
        }
    }
}
