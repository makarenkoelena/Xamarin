using FitnessApp.ModelViews;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FitnessApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MeasurementPage : ContentPage
    {
        public MeasurementPage()
        {
            InitializeComponent();
            BindingContext = new MeasurementCollectionViewModel();           
            ObservableCollection<PersonViewModel> p = PersonViewModel.ReadPersonListData();               
        }
    }//end of class
}//namespace