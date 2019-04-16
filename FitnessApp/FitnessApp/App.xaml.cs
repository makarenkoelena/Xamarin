using FitnessApp.ModelViews;
using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace FitnessApp
{
    public partial class App : Application
    {
        public static UserViewModel app = new UserViewModel();

        public App()
        {
            InitializeComponent();
             MainPage = new MeasurementPage(); // Creates single page application
           // MainPage = new NavigationPage(new MainPage()); // Setup multiple page application
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
