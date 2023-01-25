using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using CommunityToolkit.Mvvm.Messaging;
using Ogrenci4.src.Models;
using Ogrenci4.src.ViewModels.Base;

namespace Ogrenci4.src.ViewModels
{
    public class VM_StartSession : ViewModelBase
    {

        public VM_StartSession()
        {

        }


        private string _seciliDers = "Türkçe";
        public string SeciliDers
        {
            get => _seciliDers;
            set
            {
                _seciliDers = value;
                OnPropertyChanged();

            }
        }


        private int _sure = 50;
        public int Sure
        {
            get => _sure;
            set
            {
                _sure = value;
                OnPropertyChanged();
            }
        }
        private string _seciliTur = "Konu Çalışma";
        public string SeciliTur
        {
            get => _seciliTur;
            set
            {
                _seciliTur = value;
                OnPropertyChanged();

            }
        }

        private ObservableCollection<SeciliKonu> _seciliKonular = new();

        public ObservableCollection<SeciliKonu> SeciliKonular
        {
            get => _seciliKonular;
            set
            {
                _seciliKonular = value;
                OnPropertyChanged();
            }
        }

        private string _description = "";
        public string Description
        {
            get => _description;
            set
            {
                _description = value;
                OnPropertyChanged();
            }
        }



        public ICommand SelectTypeCommand => new Command<string>(OnSelectType);

        private void OnSelectType(string obj)
        {
            SeciliTur = obj;
        }



        public ICommand SelectDersCommand => new Command<string>(OnSelectDers);
        async private void OnSelectDers(string obj)
        {
            SeciliDers = obj;
        }

        public ICommand SureArttirCommand => new Command(OnSureArttir);
        private void OnSureArttir()
        {
            if (IsBusy == true)
            {
                return;
            }
            IsBusy = true;

            Sure = Sure + 1;
            IsBusy = false;
        }
        public ICommand SureAzaltCommand => new Command(OnSureAzalt);
        private void OnSureAzalt()
        {
            if (IsBusy == true)
            {
                return;
            }
            IsBusy = true;

            Sure = Sure - 1;
            if(Sure <1 )
            {
                Sure = 1;
            }

            IsBusy = false;


        }

        //         WeakReferenceMessenger.Default.Send(new TimerMessage(5));

        public ICommand BaslatCommand => new Command(OnBaslat);
        private void OnBaslat()
        {
            if (IsBusy == true)
            {
                return;

            }
            IsBusy = true;

            WeakReferenceMessenger.Default.Send(new TimerMessage(5));
            App.Current.MainPage.Navigation.PopAsync();

            IsBusy = false;
        }


    }
}
