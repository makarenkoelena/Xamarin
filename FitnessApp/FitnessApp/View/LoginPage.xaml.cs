using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FitnessApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        private async Task btnLogin_Clicked(object sender, EventArgs e)
        {
            App myapp = (App)Xamarin.Forms.Application.Current;

            if (App.app.checkInfo(entry_email.Text, entry_password.Text))
            {
                await App.Current.MainPage.Navigation.PushAsync(new TabbedPage1());      
            }
        }
    }
}