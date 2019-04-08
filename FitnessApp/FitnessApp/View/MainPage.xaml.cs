using FitnessApp.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace FitnessApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }
        private void Register_Clicked(object sender, EventArgs e)
        {
            App.Current.MainPage.Navigation.PushAsync(new RegisterPage());//!!!!!!NOT MODALASYNC BACK BUTTON IN THE NEXT PAGE WILL DISSAPEAR
        }

        private void Login_Clicked(object sender, EventArgs e)
        {
            App.Current.MainPage.Navigation.PushAsync(new LoginPage());
        }
        private void Save_New_Clicked(object sender, EventArgs e)
        {
            App.Current.MainPage.Navigation.PushAsync(new InputPage());
        }
    }
}
