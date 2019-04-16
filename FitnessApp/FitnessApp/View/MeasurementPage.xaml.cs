using FitnessApp.ModelViews;
using System;
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
            //pckdate.Date = DateTime.Now;
            BindingContext = new PersonPageViewModel();           
                       
        }
    }//end of class
}//namespace