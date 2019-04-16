using FitnessApp.ModelViews;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FitnessApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewMeasurementPage : ContentPage
    {
        public NewMeasurementPage()
        {
            InitializeComponent();
            //pckdate.Date = DateTime.Now;
            BindingContext = new NewMeasurementViewModel();           
                       
        }
    }//end of class
}//namespace