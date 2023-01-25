using Ogrenci4.src.Models;
using Ogrenci4.src.ViewModels;

namespace Ogrenci4.src.Views;

public partial class NewStrudyLessonToics : ContentPage
{
    public NewStrudyLessonToics(string _ders, List<SeciliKonu> ll)
    {
        InitializeComponent();
        this.BindingContext = new VM_NewStudyLesseonTopic(_ders, ll);
    }
}