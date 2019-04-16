using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
            string patternPassword = @"^(?=.*\d)(?=.*[a-z])(?=.*[A-Z]).{4,8}$";
            App myapp = (App)Xamarin.Forms.Application.Current;
            try
            {
                if (App.app.checkInfo(entry_email.Text, entry_password.Text))
                {
                    Debug.WriteLine("INSIDE CLICKED!!!!!!!!!!!!!");
                    await App.Current.MainPage.Navigation.PushAsync(new TabbedPage1());
                }
                else if (!entry_email.Text.Contains("@"))
                {
                    await DisplayAlert("Alert", "Email doesnt contain @ symbol", "OK");
                }
                else if (!Regex.IsMatch(entry_password.Text, patternPassword))
                {
                    await DisplayAlert("Alert", "Password must be at least 4 characters, no more than 8 characters, and must include at least one upper case letter, one lower case letter, and one numeric digit.", "OK");
                }
                else
                {
                    await DisplayAlert("Alert", "Invalid username or password", "OK");
                }
            }
            catch (NullReferenceException) { await DisplayAlert("Alert", "Fields can't be empty", "OK"); }

        }
    }
}